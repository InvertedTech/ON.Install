using FortisAPI.Standard.Controllers;
using FortisAPI.Standard.Exceptions;
using FortisAPI.Standard.Models;
using Microsoft.Extensions.Options;
using ON.Authentication;
using ON.Authorization.Payment.ParallelEconomy.Clients.Models;
using ON.Authorization.Payment.ParallelEconomy.Data;
using ON.Authorization.Payment.ParallelEconomy.Models;
using ON.Fragments.Authorization.Payment.ParallelEconomy;
using ON.Fragments.Authorization.Payment.Paypal;
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

namespace ON.Authorization.Payment.ParallelEconomy.Clients
{
    public class ParallelEconomyClient
    {
        private readonly SettingsClient settingsClient;
        private readonly SubscriptionTierHelper subHelper;

        private const string DeveloperId = "IphR7xVH";

        private FortisAPI.Standard.FortisAPIClient client;

        public ParallelEconomyClient(SettingsClient settingsClient, SubscriptionTierHelper subHelper)
        {
            this.settingsClient = settingsClient;
            this.subHelper = subHelper;

            client = GetClient().Result;
        }

        public bool IsEnabled => (settingsClient.PublicData?.Subscription?.ParallelEconomy?.Enabled ?? false)
                              && (settingsClient.PublicData?.Subscription?.ParallelEconomy?.IsValid ?? false)
                              && (settingsClient.OwnerData?.Subscription?.ParallelEconomy?.IsValid ?? false);

        public async Task<PaypalNewDetails?> GetNewDetails(uint amountCents)
        {
            if (!IsEnabled)
                return null;

            var intent = await GetNewPaymentIntent(amountCents);
            if (intent == null)
                return null;

            return new()
            {
                PlanId = intent,
            };
        }

        internal async Task<bool> CancelSubscription(string subscriptionId, string reason)
        {
            try
            {
                var res = await client.RecurringController.DeleteRecurringRecordAsync(subscriptionId);
                return res.Data.Status == StatusEnum.Ended;
            }
            catch { }

            return false;
        }

        internal async Task<ResponseRecurring?> GetSubscription(string subscriptionId)
        {
            try
            {
                return await client.RecurringController.ViewSingleRecurringRecordAsync(subscriptionId);
            }
            catch { }

            return null;
        }

        internal async Task<ResponseContact?> CreateContact(ONUser user)
        {
            try
            {
                var contact = await GetContactByAccountNumber(user);
                if (contact != null)
                    return contact;

                return client.ContactsController.CreateANewContact(new V1ContactsRequest()
                {
                    AccountNumber = user.Id.ToString(),
                    LastName = user.UserName,
                    LocationId = settingsClient.OwnerData.Subscription.ParallelEconomy.LocationId,
                    UpdateIfExists = UpdateIfExistsEnum.Enum1,
                });
            }
            catch { }

            return null;
        }

        internal async Task<ResponseRecurring?> CreateSubscription(string tokenId, int amountCents, DateTime startDate)
        {
            try
            {
                return await client.RecurringController.CreateANewRecurringRecordAsync(new V1RecurringsRequest()
                {
                    Active = ActiveEnum.Enum1,
                    AccountVaultId = tokenId,
                    Interval = 1,
                    IntervalType = IntervalTypeEnum.M,
                    LocationId = settingsClient.OwnerData.Subscription.ParallelEconomy.LocationId,
                    StartDate = startDate.ToString("yyyy-MM-dd"),
                    TransactionAmount = amountCents / 100.0,
                    PaymentMethod = PaymentMethodEnum.Cc,
                    
                    
                });
            }
            catch { }

            return null;
        }

        internal async Task<ResponseRecurring?> CreateSubscriptionFromTransaction(string tranId, ONUser user)
        {
            try
            {
                var trans = await GetTransaction(tranId);
                if (trans == null)
                    return null;

                try
                {
                    if (trans.Data.AuthAmount != trans.Data.TransactionAmount)
                    {
                        // Void transaction in case of partial auth
                        await VoidTransaction(tranId);
                        return null;
                    }

                    var contact = await CreateContact(user);
                    if (contact == null)
                        return null;

                    var token = await GetNewPreviousTransactionToken(tranId, contact);
                    if (token == null)
                        return null;

                    return await CreateSubscription(token.Data.Id, trans.Data.TransactionAmount, DateTime.UtcNow.AddMonths(1));
                }
                catch
                {
                    // Void transaction in case of error
                    await VoidTransaction(tranId);
                }
            }
            catch { }

            return null;
        }

        internal async Task<IEnumerable<ResponseContact>> GetAllContacts()
        {
            int page = 1;
            List<ResponseContact> contacts = new List<ResponseContact>();
            try
            {
                var res = await client.ContactsController.ListAllContactsAsync(new Page() { Number = page, Size = 5000 });
                contacts.AddRange(res.List.Select(l => l.ToResponseContact()));
            }
            catch { }

            return contacts;
        }

        internal async Task<ResponseContact?> GetContact(string contactId)
        {
            try
            {
                return await client.ContactsController.ViewSingleContactAsync(contactId);
            }
            catch { }

            return null;
        }

        internal async Task<ResponseContact?> GetContactByAccountNumber(ONUser user)
        {
            try
            {
                var list = await client.ContactsController.ListAllContactsAsync(new Page() { Number = 1, Size = 1 }, null, new Filter1()
                {
                    AccountNumber = user.Id.ToString()
                });

                var item = list?.List?.FirstOrDefault();
                if (item != null)
                    return item.ToResponseContact();
            }
            catch { }

            return null;
        }

        internal async Task<ResponseTransaction?> GetTransaction(string tranId)
        {
            try
            {
                return await client.TransactionsReadController.GetTransactionAsync(tranId);
            }
            catch { }

            return null;
        }

        internal async Task<string> GetNewPaymentIntent(uint amount)
        {
            ElementsController elementsController = client.ElementsController;
            var body = new V1ElementsTransactionIntentionRequest()
            {
                Action = ActionEnum.Sale,
                Amount = (int)amount * 100,
                Methods = new List<Method>(),
                
                LocationId = settingsClient.OwnerData.Subscription.ParallelEconomy.LocationId
            };
            body.Methods.Add(new Method(TypeEnum.Cc, settingsClient.OwnerData.Subscription.ParallelEconomy.ProductId));

            try
            {
                ResponseTransactionIntention result = await elementsController.TransactionIntentionAsync(body);
                return result.Data.ClientToken;
            }
            catch (ApiException)
            {
                return "";
            };
        }

        internal async Task<ResponseToken?> GetNewPreviousTransactionToken(string tranId, ResponseContact contact)
        {
            try
            {
                return await client.TokensController.CreateANewPreviousTransactionTokenAsync(new V1TokensPreviousTransactionRequest()
                {
                    LocationId = settingsClient.OwnerData.Subscription.ParallelEconomy.LocationId,
                    PreviousTransactionId = tranId,
                    ContactId = contact.Data.Id,
                });
            }
            catch { }

            return null;
        }

        internal async Task<ResponseTransaction?> ProcessOneTimeSale(string ccTokenId, uint cents)
        {
            try
            {
                return await client.TransactionsCreditCardController.CCSaleTokenizedAsync(new V1TransactionsCcSaleTokenRequest()
                {
                    TransactionApiId = ccTokenId,
                    TransactionAmount = (int)cents,
                });
            }
            catch { }

            return null;
        }

        internal async Task<ResponseTransaction?> VoidTransaction(string tranId)
        {
            try
            {
                return await client.TransactionsUpdatesController.VoidAsync(tranId);
            }
            catch { }

            return null;
        }

        private Task<FortisAPI.Standard.FortisAPIClient> GetClient()
        {
            FortisAPI.Standard.FortisAPIClient client = new FortisAPI.Standard.FortisAPIClient.Builder()
                .CustomHeaderAuthenticationCredentials(settingsClient.OwnerData.Subscription.ParallelEconomy.UserId, settingsClient.OwnerData.Subscription.ParallelEconomy.UserApiKey, DeveloperId)
                .Environment(settingsClient.PublicData.Subscription.ParallelEconomy.IsTest ? FortisAPI.Standard.Environment.Sandbox : FortisAPI.Standard.Environment.Production)
                .HttpClientConfig(config => config.NumberOfRetries(0))
                .Build();

            return Task.FromResult(client);
        }
    }
}
