using ON.Fragments.Authorization;

namespace ON.Authorization.ParallelEconomy.Service.Clients.Models
{
    public class PlanRecordModel
    {
        public string id { get; set; }
        public string product_id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public BillingCycles[] billing_cycles { get; set; }
        public PaymentPreferences payment_preferences { get; set; }

        public static PlanRecordModel Create(SubscriptionTier tier, string product_id)
        {
            return new()
            {
                product_id = product_id,
                status =  "ACTIVE",
                billing_cycles = new BillingCycles[] { BillingCycles.Create(tier) },
                payment_preferences = PaymentPreferences.Create(),
            };
        }

        public class BillingCycles
        {
            public Frequency frequency { get; set; }
            public string tenure_type { get; set; }
            public int sequence { get; set; }
            public int total_cycles { get; set; }
            public PricingScheme pricing_scheme { get; set; }

            public static BillingCycles Create(SubscriptionTier tier)
            {
                return new()
                {
                    frequency = Frequency.Create(),
                    tenure_type = "REGULAR",
                    sequence = 1,
                    total_cycles = 0,
                    pricing_scheme = PricingScheme.Create(tier),
                };
            }

            public class Frequency
            {
                public string interval_unit { get; set; }
                public int interval_count { get; set; }

                public static Frequency Create()
                {
                    return new()
                    {
                        interval_unit = "MONTH",
                        interval_count = 1,
                    };
                }
            }

            public class PricingScheme
            {
                public FixedPrice fixed_price { get; set; } = new();

                public static PricingScheme Create(SubscriptionTier tier)
                {
                    return new()
                    {
                        fixed_price = FixedPrice.Create(tier)
                    };
                }

                public class FixedPrice
                {
                    public string value { get; set; }
                    public string currency_code { get; set; }

                    public static FixedPrice Create(SubscriptionTier tier)
                    {
                        return new()
                        {
                            value = tier.Amount.ToString(),
                            currency_code = "USD",
                        };
                    }
                }
            }
        }

        public class PaymentPreferences
        {
            public bool auto_bill_outstanding { get; set; }
            public int payment_failure_threshold { get; set; }

            public static PaymentPreferences Create()
            {
                return new()
                {
                    auto_bill_outstanding = true,
                    payment_failure_threshold = 0,
                };
            }
        }
    }

}
