// <copyright file="FortisAPIClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using APIMatic.Core;
    using APIMatic.Core.Authentication;
    using APIMatic.Core.Types;
    using FortisAPI.Standard.Authentication;
    using FortisAPI.Standard.Controllers;
    using FortisAPI.Standard.Http.Client;
    using FortisAPI.Standard.Utilities;

    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class FortisAPIClient : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Enum, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Enum, string>>
        {
            {
                Environment.Sandbox, new Dictionary<Enum, string>
                {
                    { Server.Default, "https://api.sandbox.fortis.tech" },
                }
            },
            {
                Environment.Production, new Dictionary<Enum, string>
                {
                    { Server.Default, "https://api.fortis.tech" },
                }
            },
        };

        private readonly GlobalConfiguration globalConfiguration;
        private const string userAgent = "APIMATIC 3.0";
        private readonly HttpCallBack httpCallBack;
        private readonly Lazy<AsyncProcessingController> asyncProcessing;
        private readonly Lazy<BatchesController> batches;
        private readonly Lazy<ContactsController> contacts;
        private readonly Lazy<DeclinedRecurringTransactionsController> declinedRecurringTransactions;
        private readonly Lazy<DeviceTermsController> deviceTerms;
        private readonly Lazy<ElementsController> elements;
        private readonly Lazy<FullBoardingController> fullBoarding;
        private readonly Lazy<LocationsController> locations;
        private readonly Lazy<OnBoardingController> onBoarding;
        private readonly Lazy<PaylinksController> paylinks;
        private readonly Lazy<QuickInvoicesController> quickInvoices;
        private readonly Lazy<RecurringController> recurring;
        private readonly Lazy<SignaturesController> signatures;
        private readonly Lazy<TagsController> tags;
        private readonly Lazy<TerminalsController> terminals;
        private readonly Lazy<TicketsController> tickets;
        private readonly Lazy<TokensController> tokens;
        private readonly Lazy<TransactionsACHController> transactionsACH;
        private readonly Lazy<TransactionsCashController> transactionsCash;
        private readonly Lazy<TransactionsCreditCardController> transactionsCreditCard;
        private readonly Lazy<TransactionsReadController> transactionsRead;
        private readonly Lazy<Level3DataController> level3Data;
        private readonly Lazy<TransactionsUpdatesController> transactionsUpdates;
        private readonly Lazy<UserVerificationsController> userVerifications;
        private readonly Lazy<UsersController> users;
        private readonly Lazy<MerchantDetailsController> merchantDetails;
        private readonly Lazy<ApplePayValidateMerchantController> applePayValidateMerchant;
        private readonly Lazy<WebhooksController> webhooks;

        private FortisAPIClient(
            Environment environment,
            UserIdModel userIdModel,
            UserApiKeyModel userApiKeyModel,
            DeveloperIdModel developerIdModel,
            AccessTokenModel accessTokenModel,
            HttpCallBack httpCallBack,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.httpCallBack = httpCallBack;
            this.HttpClientConfiguration = httpClientConfiguration;
            UserIdModel = userIdModel;
            var userIdManager = new UserIdManager(userIdModel);
            UserApiKeyModel = userApiKeyModel;
            var userApiKeyManager = new UserApiKeyManager(userApiKeyModel);
            DeveloperIdModel = developerIdModel;
            var developerIdManager = new DeveloperIdManager(developerIdModel);
            AccessTokenModel = accessTokenModel;
            var accessTokenManager = new AccessTokenManager(accessTokenModel);
            globalConfiguration = new GlobalConfiguration.Builder()
                .AuthManagers(new Dictionary<string, AuthManager> {
                    {"user-id", userIdManager},
                    {"user-api-key", userApiKeyManager},
                    {"developer-id", developerIdManager},
                    {"access-token", accessTokenManager},
                })
                .ApiCallback(httpCallBack)
                .HttpConfiguration(httpClientConfiguration)
                .ServerUrls(EnvironmentsMap[environment], Server.Default)
                .UserAgent(userAgent)
                .Build();

            UserIdCredentials = userIdManager;
            UserApiKeyCredentials = userApiKeyManager;
            DeveloperIdCredentials = developerIdManager;
            AccessTokenCredentials = accessTokenManager;

            this.asyncProcessing = new Lazy<AsyncProcessingController>(
                () => new AsyncProcessingController(globalConfiguration));
            this.batches = new Lazy<BatchesController>(
                () => new BatchesController(globalConfiguration));
            this.contacts = new Lazy<ContactsController>(
                () => new ContactsController(globalConfiguration));
            this.declinedRecurringTransactions = new Lazy<DeclinedRecurringTransactionsController>(
                () => new DeclinedRecurringTransactionsController(globalConfiguration));
            this.deviceTerms = new Lazy<DeviceTermsController>(
                () => new DeviceTermsController(globalConfiguration));
            this.elements = new Lazy<ElementsController>(
                () => new ElementsController(globalConfiguration));
            this.fullBoarding = new Lazy<FullBoardingController>(
                () => new FullBoardingController(globalConfiguration));
            this.locations = new Lazy<LocationsController>(
                () => new LocationsController(globalConfiguration));
            this.onBoarding = new Lazy<OnBoardingController>(
                () => new OnBoardingController(globalConfiguration));
            this.paylinks = new Lazy<PaylinksController>(
                () => new PaylinksController(globalConfiguration));
            this.quickInvoices = new Lazy<QuickInvoicesController>(
                () => new QuickInvoicesController(globalConfiguration));
            this.recurring = new Lazy<RecurringController>(
                () => new RecurringController(globalConfiguration));
            this.signatures = new Lazy<SignaturesController>(
                () => new SignaturesController(globalConfiguration));
            this.tags = new Lazy<TagsController>(
                () => new TagsController(globalConfiguration));
            this.terminals = new Lazy<TerminalsController>(
                () => new TerminalsController(globalConfiguration));
            this.tickets = new Lazy<TicketsController>(
                () => new TicketsController(globalConfiguration));
            this.tokens = new Lazy<TokensController>(
                () => new TokensController(globalConfiguration));
            this.transactionsACH = new Lazy<TransactionsACHController>(
                () => new TransactionsACHController(globalConfiguration));
            this.transactionsCash = new Lazy<TransactionsCashController>(
                () => new TransactionsCashController(globalConfiguration));
            this.transactionsCreditCard = new Lazy<TransactionsCreditCardController>(
                () => new TransactionsCreditCardController(globalConfiguration));
            this.transactionsRead = new Lazy<TransactionsReadController>(
                () => new TransactionsReadController(globalConfiguration));
            this.level3Data = new Lazy<Level3DataController>(
                () => new Level3DataController(globalConfiguration));
            this.transactionsUpdates = new Lazy<TransactionsUpdatesController>(
                () => new TransactionsUpdatesController(globalConfiguration));
            this.userVerifications = new Lazy<UserVerificationsController>(
                () => new UserVerificationsController(globalConfiguration));
            this.users = new Lazy<UsersController>(
                () => new UsersController(globalConfiguration));
            this.merchantDetails = new Lazy<MerchantDetailsController>(
                () => new MerchantDetailsController(globalConfiguration));
            this.applePayValidateMerchant = new Lazy<ApplePayValidateMerchantController>(
                () => new ApplePayValidateMerchantController(globalConfiguration));
            this.webhooks = new Lazy<WebhooksController>(
                () => new WebhooksController(globalConfiguration));
        }

        /// <summary>
        /// Gets AsyncProcessingController controller.
        /// </summary>
        public AsyncProcessingController AsyncProcessingController => this.asyncProcessing.Value;

        /// <summary>
        /// Gets BatchesController controller.
        /// </summary>
        public BatchesController BatchesController => this.batches.Value;

        /// <summary>
        /// Gets ContactsController controller.
        /// </summary>
        public ContactsController ContactsController => this.contacts.Value;

        /// <summary>
        /// Gets DeclinedRecurringTransactionsController controller.
        /// </summary>
        public DeclinedRecurringTransactionsController DeclinedRecurringTransactionsController => this.declinedRecurringTransactions.Value;

        /// <summary>
        /// Gets DeviceTermsController controller.
        /// </summary>
        public DeviceTermsController DeviceTermsController => this.deviceTerms.Value;

        /// <summary>
        /// Gets ElementsController controller.
        /// </summary>
        public ElementsController ElementsController => this.elements.Value;

        /// <summary>
        /// Gets FullBoardingController controller.
        /// </summary>
        public FullBoardingController FullBoardingController => this.fullBoarding.Value;

        /// <summary>
        /// Gets LocationsController controller.
        /// </summary>
        public LocationsController LocationsController => this.locations.Value;

        /// <summary>
        /// Gets OnBoardingController controller.
        /// </summary>
        public OnBoardingController OnBoardingController => this.onBoarding.Value;

        /// <summary>
        /// Gets PaylinksController controller.
        /// </summary>
        public PaylinksController PaylinksController => this.paylinks.Value;

        /// <summary>
        /// Gets QuickInvoicesController controller.
        /// </summary>
        public QuickInvoicesController QuickInvoicesController => this.quickInvoices.Value;

        /// <summary>
        /// Gets RecurringController controller.
        /// </summary>
        public RecurringController RecurringController => this.recurring.Value;

        /// <summary>
        /// Gets SignaturesController controller.
        /// </summary>
        public SignaturesController SignaturesController => this.signatures.Value;

        /// <summary>
        /// Gets TagsController controller.
        /// </summary>
        public TagsController TagsController => this.tags.Value;

        /// <summary>
        /// Gets TerminalsController controller.
        /// </summary>
        public TerminalsController TerminalsController => this.terminals.Value;

        /// <summary>
        /// Gets TicketsController controller.
        /// </summary>
        public TicketsController TicketsController => this.tickets.Value;

        /// <summary>
        /// Gets TokensController controller.
        /// </summary>
        public TokensController TokensController => this.tokens.Value;

        /// <summary>
        /// Gets TransactionsACHController controller.
        /// </summary>
        public TransactionsACHController TransactionsACHController => this.transactionsACH.Value;

        /// <summary>
        /// Gets TransactionsCashController controller.
        /// </summary>
        public TransactionsCashController TransactionsCashController => this.transactionsCash.Value;

        /// <summary>
        /// Gets TransactionsCreditCardController controller.
        /// </summary>
        public TransactionsCreditCardController TransactionsCreditCardController => this.transactionsCreditCard.Value;

        /// <summary>
        /// Gets TransactionsReadController controller.
        /// </summary>
        public TransactionsReadController TransactionsReadController => this.transactionsRead.Value;

        /// <summary>
        /// Gets Level3DataController controller.
        /// </summary>
        public Level3DataController Level3DataController => this.level3Data.Value;

        /// <summary>
        /// Gets TransactionsUpdatesController controller.
        /// </summary>
        public TransactionsUpdatesController TransactionsUpdatesController => this.transactionsUpdates.Value;

        /// <summary>
        /// Gets UserVerificationsController controller.
        /// </summary>
        public UserVerificationsController UserVerificationsController => this.userVerifications.Value;

        /// <summary>
        /// Gets UsersController controller.
        /// </summary>
        public UsersController UsersController => this.users.Value;

        /// <summary>
        /// Gets MerchantDetailsController controller.
        /// </summary>
        public MerchantDetailsController MerchantDetailsController => this.merchantDetails.Value;

        /// <summary>
        /// Gets ApplePayValidateMerchantController controller.
        /// </summary>
        public ApplePayValidateMerchantController ApplePayValidateMerchantController => this.applePayValidateMerchant.Value;

        /// <summary>
        /// Gets WebhooksController controller.
        /// </summary>
        public WebhooksController WebhooksController => this.webhooks.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets http callback.
        /// </summary>
        internal HttpCallBack HttpCallBack => this.httpCallBack;

        /// <summary>
        /// Gets the credentials to use with UserId.
        /// </summary>
        public IUserIdCredentials UserIdCredentials { get; private set; }

        /// <summary>
        /// Gets the credentials model to use with UserId.
        /// </summary>
        public UserIdModel UserIdModel { get; private set; }

        /// <summary>
        /// Gets the credentials to use with UserApiKey.
        /// </summary>
        public IUserApiKeyCredentials UserApiKeyCredentials { get; private set; }

        /// <summary>
        /// Gets the credentials model to use with UserApiKey.
        /// </summary>
        public UserApiKeyModel UserApiKeyModel { get; private set; }

        /// <summary>
        /// Gets the credentials to use with DeveloperId.
        /// </summary>
        public IDeveloperIdCredentials DeveloperIdCredentials { get; private set; }

        /// <summary>
        /// Gets the credentials model to use with DeveloperId.
        /// </summary>
        public DeveloperIdModel DeveloperIdModel { get; private set; }

        /// <summary>
        /// Gets the credentials to use with AccessToken.
        /// </summary>
        public IAccessTokenCredentials AccessTokenCredentials { get; private set; }

        /// <summary>
        /// Gets the credentials model to use with AccessToken.
        /// </summary>
        public AccessTokenModel AccessTokenModel { get; private set; }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            return globalConfiguration.ServerUrl(alias);
        }

        /// <summary>
        /// Creates an object of the FortisAPIClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .HttpCallBack(httpCallBack)
                .HttpClientConfig(config => config.Build());

            if (UserIdModel != null)
            {
                builder.UserIdCredentials(UserIdModel.ToBuilder().Build());
            }

            if (UserApiKeyModel != null)
            {
                builder.UserApiKeyCredentials(UserApiKeyModel.ToBuilder().Build());
            }

            if (DeveloperIdModel != null)
            {
                builder.DeveloperIdCredentials(DeveloperIdModel.ToBuilder().Build());
            }

            if (AccessTokenModel != null)
            {
                builder.AccessTokenCredentials(AccessTokenModel.ToBuilder().Build());
            }

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"Environment = {this.Environment}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> FortisAPIClient.</returns>
        internal static FortisAPIClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("FORTIS_API_STANDARD_ENVIRONMENT");
            string userId = System.Environment.GetEnvironmentVariable("FORTIS_API_STANDARD_USER_ID");
            string userApiKey = System.Environment.GetEnvironmentVariable("FORTIS_API_STANDARD_USER_API_KEY");
            string developerId = System.Environment.GetEnvironmentVariable("FORTIS_API_STANDARD_DEVELOPER_ID");
            string accessToken = System.Environment.GetEnvironmentVariable("FORTIS_API_STANDARD_ACCESS_TOKEN");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (userId != null)
            {
                builder.UserIdCredentials(new UserIdModel
                .Builder(userId)
                .Build());
            }

            if (userApiKey != null)
            {
                builder.UserApiKeyCredentials(new UserApiKeyModel
                .Builder(userApiKey)
                .Build());
            }

            if (developerId != null)
            {
                builder.DeveloperIdCredentials(new DeveloperIdModel
                .Builder(developerId)
                .Build());
            }

            if (accessToken != null)
            {
                builder.AccessTokenCredentials(new AccessTokenModel
                .Builder(accessToken)
                .Build());
            }

            return builder.Build();
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = FortisAPI.Standard.Environment.Sandbox;
            private UserIdModel userIdModel = new UserIdModel();
            private UserApiKeyModel userApiKeyModel = new UserApiKeyModel();
            private DeveloperIdModel developerIdModel = new DeveloperIdModel();
            private AccessTokenModel accessTokenModel = new AccessTokenModel();
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();
            private HttpCallBack httpCallBack;

            /// <summary>
            /// Sets credentials for UserId.
            /// </summary>
            /// <param name="userIdModel">UserIdModel.</param>
            /// <returns>Builder.</returns>
            public Builder UserIdCredentials(UserIdModel userIdModel)
            {
                if (userIdModel is null)
                {
                    throw new ArgumentNullException(nameof(userIdModel));
                }

                this.userIdModel = userIdModel;
                return this;
            }

            /// <summary>
            /// Sets credentials for UserApiKey.
            /// </summary>
            /// <param name="userApiKeyModel">UserApiKeyModel.</param>
            /// <returns>Builder.</returns>
            public Builder UserApiKeyCredentials(UserApiKeyModel userApiKeyModel)
            {
                if (userApiKeyModel is null)
                {
                    throw new ArgumentNullException(nameof(userApiKeyModel));
                }

                this.userApiKeyModel = userApiKeyModel;
                return this;
            }

            /// <summary>
            /// Sets credentials for DeveloperId.
            /// </summary>
            /// <param name="developerIdModel">DeveloperIdModel.</param>
            /// <returns>Builder.</returns>
            public Builder DeveloperIdCredentials(DeveloperIdModel developerIdModel)
            {
                if (developerIdModel is null)
                {
                    throw new ArgumentNullException(nameof(developerIdModel));
                }

                this.developerIdModel = developerIdModel;
                return this;
            }

            /// <summary>
            /// Sets credentials for AccessToken.
            /// </summary>
            /// <param name="accessTokenModel">AccessTokenModel.</param>
            /// <returns>Builder.</returns>
            public Builder AccessTokenCredentials(AccessTokenModel accessTokenModel)
            {
                if (accessTokenModel is null)
                {
                    throw new ArgumentNullException(nameof(accessTokenModel));
                }

                this.accessTokenModel = accessTokenModel;
                return this;
            }

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }

           

            /// <summary>
            /// Sets the HttpCallBack for the Builder.
            /// </summary>
            /// <param name="httpCallBack"> http callback. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpCallBack(HttpCallBack httpCallBack)
            {
                this.httpCallBack = httpCallBack;
                return this;
            }

            /// <summary>
            /// Creates an object of the FortisAPIClient using the values provided for the builder.
            /// </summary>
            /// <returns>FortisAPIClient.</returns>
            public FortisAPIClient Build()
            {

                if (userIdModel.UserId == null)
                {
                    userIdModel = null;
                }
                if (userApiKeyModel.UserApiKey == null)
                {
                    userApiKeyModel = null;
                }
                if (developerIdModel.DeveloperId == null)
                {
                    developerIdModel = null;
                }
                if (accessTokenModel.AccessToken == null)
                {
                    accessTokenModel = null;
                }
                return new FortisAPIClient(
                    environment,
                    userIdModel,
                    userApiKeyModel,
                    developerIdModel,
                    accessTokenModel,
                    httpCallBack,
                    httpClientConfig.Build());
            }
        }
    }
}
