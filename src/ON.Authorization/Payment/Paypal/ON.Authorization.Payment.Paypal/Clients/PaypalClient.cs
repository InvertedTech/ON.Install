using Microsoft.Extensions.Options;
using ON.Authorization.Payment.Paypal.Clients.Models;
using ON.Authorization.Payment.Paypal.Data;
using ON.Authorization.Payment.Paypal.Models;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment.Paypal;
using ON.Fragments.Settings;
using ON.Settings;
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

namespace ON.Authorization.Payment.Paypal.Clients
{
    public class PaypalClient
    {
        private readonly SettingsClient settingsClient;

        private readonly Dictionary<uint, PlanRecordModel> CachedPlans = new();

        private Task? loginTask;
        private string? bearerToken;
        private DateTime bearerExpiration = DateTime.MinValue;
        private DateTime bearerSoftExpiration = DateTime.MinValue;

        private object syncObject = new();

        public PaypalClient(SettingsClient settingsClient)
        {
            this.settingsClient = settingsClient;
        }

        public bool IsEnabled => (settingsClient.PublicData?.Subscription?.Paypal?.Enabled ?? false)
                              && (settingsClient.PublicData?.Subscription?.Paypal?.IsValid ?? false)
                              && (settingsClient.OwnerData?.Subscription?.Paypal?.IsValid ?? false);

        public async Task<PaypalNewDetails?> GetNewDetails(uint amountCents)
        {
            if (!IsEnabled)
                return null;

            var plan = await GetPlan(amountCents);
            if (plan == null)
                return null;

            return new()
            {
                PlanId = plan.id,
            };
        }

        public async Task<PlanRecordModel?> GetPlan(uint amountCents)
        {
            if (CachedPlans.TryGetValue(amountCents, out var cached))
                return cached;

            var plan = await GetPlanFromPaypal(GetPlanId(amountCents));
            if (plan != null)
            {
                CachedPlans[amountCents] = plan;
                return plan;
            }

            var created = await CreatePlan(amountCents);
            if (created != null)
            {
                CachedPlans[amountCents] = created;
                return created;
            }

            return null;
        }

        private async Task<ProductRecordModel?> GetProduct(uint amountCents)
        {
            var p = await GetProductFromPaypal(amountCents);
            if (p != null)
                return p;

            return await CreateProduct(amountCents);
        }

        private async Task<PlanRecordModel?> CreatePlan(uint amountCents)
        {
            try
            {
                await GetProduct(amountCents);

                CancellationTokenSource timeout = new CancellationTokenSource();
                timeout.CancelAfter(3000);
                var client = await GetClient();
                if (client == null)
                    return null;

                var plan = PlanRecordModel.Create(amountCents, GetProductId(amountCents));
                plan.id = GetPlanId(amountCents);
                plan.product_id = GetProductId(amountCents);
                plan.name = (amountCents / 100.0).ToString("0.00") + " Subscription";

                var httpRes = await client.PostAsJsonAsync("/v1/billing/plans", plan, timeout.Token);

                if (httpRes.IsSuccessStatusCode)
                    return JsonSerializer.Deserialize<PlanRecordModel>(await httpRes.Content.ReadAsStringAsync());
            }
            catch { }

            return null;
        }

        private async Task<ProductRecordModel?> CreateProduct(uint amountCents)
        {
            try
            {
                CancellationTokenSource timeout = new CancellationTokenSource();
                timeout.CancelAfter(3000);
                var client = await GetClient();
                if (client == null)
                    return null;

                var product = new ProductRecordModel()
                {
                    id = GetProductId(amountCents),
                    name = (amountCents / 100.0).ToString("0.00") + " Subscription",
                };

                var httpRes = await client.PostAsJsonAsync("/v1/catalogs/products", product, timeout.Token);

                if (httpRes.IsSuccessStatusCode)
                    return JsonSerializer.Deserialize<ProductRecordModel>(await httpRes.Content.ReadAsStringAsync());
            }
            catch { }

            return null;
        }

        public async Task<bool> CancelSubscription(string subscriptionId, string reason)
        {
            try
            {
                CancellationTokenSource timeout = new CancellationTokenSource();
                timeout.CancelAfter(3000);
                var client = await GetClient();
                if (client == null)
                    return false;

                var httpRes = await client.PostAsJsonAsync("/v1/billing/subscriptions/" + subscriptionId + "/cancel", new { reason = reason }, timeout.Token);

                if (httpRes.IsSuccessStatusCode)
                    return true;
            }
            catch { }

            return false;
        }

        internal async Task<SubscriptionModel?> GetSubscription(string subscriptionId)
        {
            try
            {
                CancellationTokenSource timeout = new CancellationTokenSource();
                timeout.CancelAfter(3000);
                var client = await GetClient();
                if (client == null)
                    return null;

                var httpRes = await client.GetAsync("/v1/billing/subscriptions/" + subscriptionId, timeout.Token);

                if (httpRes.IsSuccessStatusCode)
                    return JsonSerializer.Deserialize<SubscriptionModel>(await httpRes.Content.ReadAsStringAsync());
            }
            catch { }

            return null;
        }

        private async Task<PlanRecordModel?> GetPlanFromPaypal(string planId)
        {
            try
            {
                CancellationTokenSource timeout = new CancellationTokenSource();
                timeout.CancelAfter(3000);
                var client = await GetClient();
                if (client == null)
                    return null;

                var httpRes = await client.GetAsync("/v1/billing/plans/" + planId, timeout.Token);

                if (httpRes.IsSuccessStatusCode)
                    return JsonSerializer.Deserialize<PlanRecordModel>(await httpRes.Content.ReadAsStringAsync());
            }
            catch { }

            return null;
        }

        private async Task<ProductRecordModel?> GetProductFromPaypal(uint amountCents)
        {
            try
            {
                CancellationTokenSource timeout = new CancellationTokenSource();
                timeout.CancelAfter(3000);
                var client = await GetClient();
                if (client == null)
                    return null;

                var httpRes = await client.GetAsync("/v1/catalogs/products/" + GetProductId(amountCents), timeout.Token);

                if (httpRes.IsSuccessStatusCode)
                    return JsonSerializer.Deserialize<ProductRecordModel>(await httpRes.Content.ReadAsStringAsync());
            }
            catch { }

            return null;
        }

        private string GetPlanId(uint amountCents)
        {
            return "ONF-PLAN-" + amountCents;
        }

        private string GetProductId(uint amountCents)
        {
            return "ONF-PROD-" + amountCents;
        }

        private async Task<HttpClient?> GetClient()
        {
            var settings = settingsClient.OwnerData.Subscription.Paypal;

            var token = await GetBearerToken();
            if (token == null)
                return null;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(settingsClient.PublicData.Subscription.Paypal.Url);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            client.DefaultRequestHeaders.AcceptLanguage.Add(StringWithQualityHeaderValue.Parse("en_US"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return client;
        }

        private async Task<string?> GetBearerToken()
        {
            var now = DateTime.UtcNow;

            if (now > bearerSoftExpiration)
            {
                lock (syncObject)
                {
                    if (loginTask == null)
                    {
                        loginTask = DoLogin();
                    }
                }
            }

            if (now > bearerExpiration && loginTask != null)
                await loginTask;

            return bearerToken;
        }

        private async Task DoLogin()
        {
            try
            {
                var pub = settingsClient.PublicData.Subscription.Paypal;
                var own = settingsClient.OwnerData.Subscription.Paypal;

                CancellationTokenSource timeout = new CancellationTokenSource();
                timeout.CancelAfter(3000);
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(pub.Url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                client.DefaultRequestHeaders.AcceptLanguage.Add(StringWithQualityHeaderValue.Parse("en_US"));
                client.DefaultRequestHeaders.ConnectionClose = true;

                var authenticationString = pub.ClientID + ":" + own.ClientSecret;
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
            catch
            {

            }
            loginTask = null;
        }
    }
}
