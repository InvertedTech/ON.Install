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
        public readonly PlanList Plans;

        private readonly AppSettings settings;
        private readonly IPlanRecordProvider recordProvider;
        private readonly ILogger<StripeClient> logger;

        private ProductService productService;
        private ProductCreateOptions productOptions;
        private Task loginTask;
        private string bearerToken;
        private DateTime bearerExpiration = DateTime.MinValue;
        private DateTime bearerSoftExpiration = DateTime.MinValue;

        private object syncObject = new();

        public StripeClient(ILogger<StripeClient> logger,IOptions<AppSettings> settings, IPlanRecordProvider recordProvider)
        {
            this.settings = settings.Value;
            this.logger = logger;
            this.recordProvider = recordProvider;
            this.productService = new ProductService();

            // Set Client Secret
            StripeConfiguration.ApiKey = this.settings.StripeClientSecret;

            Plans = recordProvider.GetAll().Result;

            //Setup();
            EnsurePlans().Wait();
        }

        private async Task EnsurePlans()
        {
            //foreach (var tier in SiteConfig.SubscriptionTiers)
            //    var stripePlan = await productService.Get(tier.PlanId);
            //    if (tier.Value > 0)
            //        await EnsurePlan(tier);

            var records = await this.recordProvider.GetAll();
            //logger.LogWarning($"*****Records: {records.Records} *****");
            foreach (var record in records.Records)
                await EnsurePlan(record.PlanId);
        }

        private async Task EnsurePlan(string planId)
        {
            Product product = this.productService.Get(planId);
            if (product == null)
                return;
            else
                // Get product
                logger.LogWarning($"**** prod: {product.Id} ****");

            return;
                
        }

        private void Setup()
        {
            StripeConfiguration.ApiKey = this.settings.StripeClientSecret;

            foreach (var tier in SiteConfig.SubscriptionTiers.Where(t => t.Value > 0))
            {
                //Generate the stripe Product objects
                //if (Plans.Records.FirstOrDefault(l => l.Value == tier.Value) == null)
                //    this.productOptions = new ProductCreateOptions()
                //    {
                //        Name = tier.Name,
                //    };
                //    var newProd = productService.Create(this.productOptions);

                //    Plans.Records.Add(new PlanRecord
                //    {
                //        Name = tier.Name,
                //        Value = (uint)tier.Value,
                //        PlanId = (string)newProd.Id,
                //    });

                //
                // replace with real code setting up plans on stripe
                //
                //

                

                if (Plans.Records.FirstOrDefault(l => l.Value == tier.Value) == null)
                {
                    this.productOptions = new ProductCreateOptions()
                    {
                        Name = tier.Name,
                    };

                    Product newProduct = productService.Create(this.productOptions);
                    logger.LogWarning($"******created product {newProduct.Id}******");

                    Plans.Records.Add(new PlanRecord
                    {
                        Name = tier.Name,
                        Value = (uint)tier.Value * 100,
                        PlanId = newProduct.Id,
                    });
                } else
                {
                    this.productOptions = new ProductCreateOptions()
                    {
                        Name = tier.Name,
                    };

                    Product newProduct = productService.Create(this.productOptions);
                    logger.LogWarning($"******created product {newProduct.Id}******");

                    Plans.Records.Add(new PlanRecord
                    {
                        Name = tier.Name,
                        Value = (uint)tier.Value,
                        PlanId = newProduct.Id,
                    });
                }

                //
                //
                // replace with real code setting up plans on stripe
                //
                //
            }

            recordProvider.SaveAll(Plans).Wait();
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
