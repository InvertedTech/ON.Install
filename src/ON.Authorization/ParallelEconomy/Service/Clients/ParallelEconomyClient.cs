using FortisAPI.Standard.Authentication;
using FortisAPI.Standard.Controllers;
using FortisAPI.Standard.Exceptions;
using FortisAPI.Standard.Models;
using FortisAPI.Standard.Models.Containers;
using Microsoft.Extensions.Options;
using ON.Authentication;
using ON.Authorization.ParallelEconomy.Service.Clients.Models;
using ON.Authorization.ParallelEconomy.Service.Data;
using ON.Authorization.ParallelEconomy.Service.Models;
using ON.Fragments.Authorization.Payment.ParallelEconomy;
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

namespace ON.Authorization.ParallelEconomy.Service.Clients
{
    public class ParallelEconomyClient
    {
        public readonly PlanList Plans;

        private readonly AppSettings settings;
        private readonly SubscriptionTierHelper subHelper;

        private FortisAPI.Standard.FortisAPIClient client;

        public ParallelEconomyClient(IOptions<AppSettings> settings, SubscriptionTierHelper subHelper)
        {
            this.settings = settings.Value;
            this.subHelper = subHelper;

            client = GetClient().Result;

            Plans = new PlanList();

            Plans.Records.AddRange(this.subHelper.GetAll().Select(s => new PlanRecord() { Name = s.Name, Value = (uint)s.AmountCents }));
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

        internal async Task<ResponseRecurring> GetSubscription(string subscriptionId)
        {
            try
            {
                return await client.RecurringController.ViewSingleRecurringRecordAsync(subscriptionId);
            }
            catch { }

            return null;
        }

        internal async Task<ResponseContact> CreateContact(ONUser user)
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
                    LocationId = settings.ParallelEconomyLocationId,
                    UpdateIfExists = UpdateIfExistsEnum.Enum1,
                });
            }
            catch { }

            return null;
        }

        internal async Task<ResponseRecurring> CreateSubscription(string tokenId, int? amountCents, DateTime startDate)
        {
            if (!amountCents.HasValue)
                return null;

            try
            {
                return await client.RecurringController.CreateANewRecurringRecordAsync(new V1RecurringsRequest()
                {
                    Active = true,
                    AccountVaultId = tokenId,
                    Interval = 1,
                    IntervalType = IntervalTypeEnum.M,
                    LocationId = settings.ParallelEconomyLocationId,
                    StartDate = startDate.ToString("yyyy-MM-dd"),
                    TransactionAmount = amountCents.Value,
                    PaymentMethod = PaymentMethod1Enum.Cc,


                });
            }
            catch { }

            return null;
        }

        internal async Task<ResponseRecurring> CreateSubscriptionFromTransaction(string tranId, ONUser user)
        {
            try
            {
                var trans = await GetTransaction(tranId);
                try
                {
                    if (trans.Data.AuthAmount != trans.Data.TransactionAmount)
                    {
                        // Void transaction in case of partial auth
                        await VoidTransaction(tranId);
                        return null;
                    }

                    var contact = await CreateContact(user);
                    var token = await GetNewPreviousTransactionToken(tranId, contact);
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

        internal async Task<ResponseContact> GetContact(string contactId)
        {
            try
            {
                return await client.ContactsController.ViewSingleContactAsync(contactId);
            }
            catch { }

            return null;
        }

        internal async Task<ResponseContact> GetContactByAccountNumber(ONUser user)
        {
            try
            {
                var filters = new List<FilterBy>();
                filters.Add(new FilterBy
                {
                    Key = "account_number",
                    MOperator = FilterByOperator.FromOperator1(Operator1Enum.Enum0),
                    MValue = FilterByValue.FromFilterByValueCase1(FilterByValueCase1.FromString(user.Id.ToString())),
                });
                filters.Add(new FilterBy
                {
                    Key = "account_number",
                    MOperator = FilterByOperator.FromOperator1(Operator1Enum.Enum1),
                    MValue = FilterByValue.FromFilterByValueCase1(FilterByValueCase1.FromString(user.Id.ToString())),
                });

                var list = await client.ContactsController.ListAllContactsAsync(new Page() { Number = 1, Size = 1 }, null, filters);

                var item = list?.List?.FirstOrDefault();
                if (item != null)
                    return item.ToResponseContact();
            }
            catch { }

            return null;
        }

        internal async Task<ResponseTransaction> GetTransaction(string tranId)
        {
            try
            {
                return await client.TransactionsReadController.GetTransactionAsync(tranId);
            }
            catch { }

            return null;
        }

        internal async Task<string> GetNewPaymentIntent(uint amountCents)
        {
            ElementsController elementsController = client.ElementsController;
            var body = new V1ElementsTransactionIntentionRequest()
            {
                Action = ActionEnum.Sale,
                Amount = FortisAPI.Standard.Models.Containers.V1ElementsTransactionIntentionRequestAmount.FromNumber((int)amountCents),
                Methods = new(),
                LocationId = settings.ParallelEconomyLocationId
            };
            body.Methods.Add(new(TypeEnum.Cc, settings.ParallelEconomyProductId));

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

        internal async Task<ResponseToken> GetNewPreviousTransactionToken(string tranId, ResponseContact contact)
        {
            try
            {
                return await client.TokensController.CreateANewPreviousTransactionTokenAsync(new V1TokensPreviousTransactionRequest()
                {
                    LocationId = settings.ParallelEconomyLocationId,
                    PreviousTransactionId = tranId,
                    ContactId = contact.Data.Id,
                });
            }
            catch { }

            return null;
        }

        internal async Task<ResponseTransaction> ProcessOneTimeSale(string ccTokenId, uint cents)
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

        internal async Task<ResponseTransaction> VoidTransaction(string tranId)
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
                .UserIdCredentials(new UserIdModel.Builder(settings.ParallelEconomyUserId).Build())
                .UserApiKeyCredentials(new UserApiKeyModel.Builder(settings.ParallelEconomyUserApiKey).Build())
                .DeveloperIdCredentials(new DeveloperIdModel.Builder(settings.ParallelEconomyDeveloperId).Build())
                //.AccessTokenCredentials(new AccessTokenModel.Builder("access-token").Build())
                .Environment(settings.ParallelEconomyIsTest ? FortisAPI.Standard.Environment.Sandbox : FortisAPI.Standard.Environment.Production)
                .HttpClientConfig(config => config.NumberOfRetries(0))
                .Build();

            return Task.FromResult(client);
        }
    }
}
