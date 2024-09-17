using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Authorization.Stripe.Service.Clients.Models;
using ON.Authorization.Stripe.Service.Data;
using ON.Authorization.Stripe.Service.Models;
using ON.Fragments.Authorization.Payment.Stripe;
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
            this.Products = new ProductList();

            // Set Client Secret
            StripeConfiguration.ApiKey = this.settings.StripeClientSecret;

            // Products = recordProvider.GetAll().Result;
            EnsureProducts();
            //int size = Products.CalculateSize();

            //if (size == 0)
            //{
            //    EnsureProducts();
            //    logger.LogWarning(Products.CalculateSize().ToString());
            //}
            
        }

        private string CreatePaymentLink(string priceId)
        {
            var opts = new PaymentLinkCreateOptions()
            {
                LineItems = new List<PaymentLinkLineItemOptions>
                {
                    new PaymentLinkLineItemOptions
                    {
                        Price = priceId,
                        Quantity = 1,
                    },
                },
            };

            var service = new PaymentLinkService();
            var link =  service.CreateAsync(opts);
            return link.Result.Url.ToString();
        }

        // TODO: Validate metadata has key url
        private void EnsureProducts()
        {
            var stripeProducts = productService.List();
            logger.LogWarning($"****PRODS: {stripeProducts}");

            foreach (Product prod in stripeProducts)
            {
                if (prod.Active == true)
                {
                    var priceId = GetPriceId(prod.Id);
                    var url = CreatePaymentLink(priceId);
                    prod.Url = url;
                    //logger.LogWarning(prod.Name);
                    if (priceId != "not found" && HasProperName(prod.Name.ToLower()))
                    {
                        var name = prod.Name;
                        var price = GetPrice(name.ToLower());
                        logger.LogWarning(url);

                        if (name == null)
                        {
                            Products.Records.Add(new ProductRecord { CheckoutUrl = url, PriceId = priceId, ProductId = prod.Id, Name = "NoName", Price = 0 });
                        }
                        else
                        {
                            Products.Records.Add(new ProductRecord { CheckoutUrl = prod.Url, PriceId = priceId, ProductId = prod.Id, Name = name, Price = price });
                        }
                    }
                }
                
            }

            recordProvider.SaveAll(Products).Wait();
        }

        private string GetPriceUrl(string productId)
        {
            var stripePrices = this.priceService.List();

            foreach (Price price in stripePrices)
            {
                logger.LogWarning($"&&&PRICE {price}");
            }

            return "not found";
        }


        private bool HasProperName(string name)
        {
            bool isCorrectName;

            switch (name)
            {
                case "lord of the manor":
                    isCorrectName = true;
                    break;
                case "the best!":
                    isCorrectName = true;
                    break;
                case "big spender":
                    isCorrectName = true;
                    break;
                case "awesome member":
                    isCorrectName = true;
                    break;
                case "member":
                    isCorrectName = true;
                    break;
                default:
                    isCorrectName = false;
                    break;
            }

            return isCorrectName;
        }

        // TODO Convert price from float to int and pass in priceid
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
            //logger.LogWarning($"$$$$GETPRICEID: {stripePrices}");

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
