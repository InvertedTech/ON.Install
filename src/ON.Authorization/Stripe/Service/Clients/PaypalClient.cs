using Microsoft.Extensions.Options;
using ON.Authorization.Stripe.Service.Data;
using ON.Authorization.Stripe.Service.Models;
using ON.Fragments.Authorization.Payments.Stripe;
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

        private Task loginTask;
        private string bearerToken;
        private DateTime bearerExpiration = DateTime.MinValue;
        private DateTime bearerSoftExpiration = DateTime.MinValue;

        private object syncObject = new();

        public StripeClient(IOptions<AppSettings> settings, IPlanRecordProvider recordProvider)
        {
            this.settings = settings.Value;
            this.recordProvider = recordProvider;

            Plans = recordProvider.GetAll().Result;

            Setup();
        }

        private void Setup()
        {
            foreach (var tier in SiteConfig.SubscriptionTiers.Where(t => t.Value > 0))
            {
                //
                //
                // replace with real code setting up plans on stripe
                //
                //
                if (Plans.Records.FirstOrDefault(l => l.Value == tier.Value) == null)
                    Plans.Records.Add(new PlanRecord
                    {
                        Name = tier.Name,
                        Value = (uint)tier.Value,
                        PlanId = "asdf",
                    });
                //
                //
                // replace with real code setting up plans on stripe
                //
                //
            }

            recordProvider.SaveAll(Plans).Wait();
        }
    }
}
