using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Authorization.Stripe.Service.Clients.Models;
using ON.Authorization.Stripe.Service.Data;
using ON.Authorization.Stripe.Service.Models;
using ON.Fragments.Authorization.Payments.Stripe;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ON.Authorization.Stripe.Service.Clients
{
    public class StripeClient
    {
        public readonly ProductList Products;

        private readonly AppSettings settings;
        private readonly IProductRecordProvider recordProvider;
        private readonly ILogger<StripeClient> logger;

        private ProductService productService;
        private PriceService priceService;
        private ProductCreateOptions productOptions;
        private Task loginTask;
        private string bearerToken;
        private DateTime bearerExpiration = DateTime.MinValue;
        private DateTime bearerSoftExpiration = DateTime.MinValue;

        private object syncObject = new();

        public StripeClient(ILogger<StripeClient> logger,IOptions<AppSettings> settings, IProductRecordProvider recordProvider)
        {
            this.settings = settings.Value;
            this.logger = logger;
            this.recordProvider = recordProvider;
            this.productService = new ProductService();
            this.priceService = new PriceService();

            // Set Client Secret
            StripeConfiguration.ApiKey = this.settings.StripeClientSecret;

            Products = recordProvider.GetAll().Result;
            int size = Products.CalculateSize();

            if (size == 0)
            {
                EnsureProducts();
                logger.LogWarning(Products.CalculateSize().ToString());
            }
        }

        private void EnsureProducts()
        {
            var stripeProducts = productService.List();

            foreach (Product prod in stripeProducts)
            {
                var priceId = GetPriceId(prod.Id);
                var name = prod.Name;
                var price = GetPrice(name.ToLower());

                if (name == null)
                {
                    Products.Records.Add(new ProductRecord { CheckoutUrl = "Not Found", PriceId = priceId, ProductId = prod.Id, Name = "NoName", Price = 0 });
                }
                else
                {
                    Products.Records.Add(new ProductRecord { CheckoutUrl = "Not Found", PriceId = priceId, ProductId = prod.Id, Name = prod.Name, Price = price });
                }
                
            }

            recordProvider.SaveAll(Products).Wait();
        }

        private int GetPrice(string name)
        {
            int price;

            switch(name)
            {
                case "lord of the manor":
                    price = 100;
                    break;
                case "the best!":
                    price = 50;
                    break;
                case "big spender":
                    price = 20;
                    break;
                case "awesome member":
                    price = 10;
                    break;
                case "member":
                    price = 5;
                    break;
                default:
                    price = 0;
                    break;
            }

            return price;
        }

        private string GetPriceId(string productId)
        {
            var stripePrices = this.priceService.List();

            foreach (Price price in stripePrices)
            {
                if (price.ProductId == productId)
                    return price.Id;
            }

            return "not found";
        }

        //private async Task<ProductRecordModel> CreateProduct(SubscriptionTier tier)
        //{
        //    try
        //    {
        //        var client = await GetClient();
        //    }
        //    catch { }
        //}

        private async Task<HttpClient> GetClient()
        {
            var token = await GetBearerToken();
            if (token == null)
                    return null;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(settings.StripeUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            client.DefaultRequestHeaders.AcceptLanguage.Add(StringWithQualityHeaderValue.Parse("en_US"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return client;
        }

        private async Task<string> GetBearerToken()
        {
            var currentDateTime = DateTime.UtcNow;

            if (currentDateTime > bearerSoftExpiration)
            {
                lock (syncObject)
                {
                    if (loginTask == null)
                    {
                        loginTask = DoLogin();
                    }
                }
            }

            if (currentDateTime > bearerExpiration)
                await loginTask;

            return bearerToken;
        }

        private async Task DoLogin()
        {
            try
            {
                CancellationTokenSource timeout = new CancellationTokenSource();
                timeout.CancelAfter(3000);

                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(settings.StripeUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                client.DefaultRequestHeaders.AcceptLanguage.Add(StringWithQualityHeaderValue.Parse("en_US"));
                client.DefaultRequestHeaders.ConnectionClose = true;

                var authenticationString = settings.StripeClientID + ":" + settings.StripeClientSecret;
                var base64EncodedAuthenticationString = Convert.ToBase64String(Encoding.ASCII.GetBytes(authenticationString));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);

                var dict = new Dictionary<string, string>();
                dict["grant_type"] = "client_credentials";

                var httpRes = await client.PostAsync("/v1/oauth2/token", new FormUrlEncodedContent(dict), timeout.Token);

                if (httpRes.IsSuccessStatusCode)
                {
                    var jsonRes = JsonSerializer.Deserialize<OAuthResponseModel>(await httpRes.Content.ReadAsStringAsync());
                    if (jsonRes != null)
                    {
                        bearerToken = jsonRes.access_token;
                        bearerExpiration = DateTime.UtcNow.AddSeconds(jsonRes.expires_in);
                        bearerSoftExpiration = DateTime.UtcNow.AddSeconds(jsonRes.expires_in / 2);
                    }
                }
            }
            catch { }

            loginTask = null;
        }
    }
}
