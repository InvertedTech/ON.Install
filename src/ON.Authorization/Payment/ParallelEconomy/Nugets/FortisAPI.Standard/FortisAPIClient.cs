// <copyright file="FortisAPIClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
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
        private static readonly Dictionary<Environment, Dictionary<Server, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Server, string>>
        {
            {
                Environment.Sandbox, new Dictionary<Server, string>
                {
                    { Server.Default, "https://api.sandbox.fortis.tech" },
                }
            },
            {
                Environment.Production, new Dictionary<Server, string>
                {
                    { Server.Default, "https://api.fortis.tech" },
                }
            },
        };

        private readonly IDictionary<string, IAuthManager> authManagers;
        private readonly IHttpClient httpClient;
        private readonly HttpCallBack httpCallBack;
        private readonly CustomHeaderAuthenticationManager customHeaderAuthenticationManager;

        private readonly Lazy<AsyncProcessingController> asyncProcessing;
        private readonly Lazy<BatchesController> batches;
        private readonly Lazy<ContactsController> contacts;
        private readonly Lazy<DeviceTermsController> deviceTerms;
        private readonly Lazy<ElementsController> elements;
        private readonly Lazy<LocationsController> locations;
        private readonly Lazy<OnBoardingController> onBoarding;
        private readonly Lazy<QuickInvoicesController> quickInvoices;
        private readonly Lazy<RecurringController> recurring;
        private readonly Lazy<SignaturesController> signatures;
        private readonly Lazy<TagsController> tags;
        private readonly Lazy<TerminalsController> terminals;
        private readonly Lazy<TokensController> tokens;
        private readonly Lazy<TransactionsACHController> transactionsACH;
        private readonly Lazy<TransactionsCreditCardController> transactionsCreditCard;
        private readonly Lazy<TransactionsReadController> transactionsRead;
        private readonly Lazy<Level3DataController> level3Data;
        private readonly Lazy<TransactionsUpdatesController> transactionsUpdates;
        private readonly Lazy<UsersController> users;
        private readonly Lazy<WebhooksController> webhooks;

        private FortisAPIClient(
            Environment environment,
            string customHeaderUserId,
            string customHeaderUserApiKey,
            string customHeaderDeveloperId,
            IDictionary<string, IAuthManager> authManagers,
            IHttpClient httpClient,
            HttpCallBack httpCallBack,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.httpCallBack = httpCallBack;
            this.httpClient = httpClient;
            this.authManagers = (authManagers == null) ? new Dictionary<string, IAuthManager>() : new Dictionary<string, IAuthManager>(authManagers);
            this.HttpClientConfiguration = httpClientConfiguration;

            this.asyncProcessing = new Lazy<AsyncProcessingController>(
                () => new AsyncProcessingController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.batches = new Lazy<BatchesController>(
                () => new BatchesController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.contacts = new Lazy<ContactsController>(
                () => new ContactsController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.deviceTerms = new Lazy<DeviceTermsController>(
                () => new DeviceTermsController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.elements = new Lazy<ElementsController>(
                () => new ElementsController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.locations = new Lazy<LocationsController>(
                () => new LocationsController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.onBoarding = new Lazy<OnBoardingController>(
                () => new OnBoardingController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.quickInvoices = new Lazy<QuickInvoicesController>(
                () => new QuickInvoicesController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.recurring = new Lazy<RecurringController>(
                () => new RecurringController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.signatures = new Lazy<SignaturesController>(
                () => new SignaturesController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.tags = new Lazy<TagsController>(
                () => new TagsController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.terminals = new Lazy<TerminalsController>(
                () => new TerminalsController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.tokens = new Lazy<TokensController>(
                () => new TokensController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.transactionsACH = new Lazy<TransactionsACHController>(
                () => new TransactionsACHController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.transactionsCreditCard = new Lazy<TransactionsCreditCardController>(
                () => new TransactionsCreditCardController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.transactionsRead = new Lazy<TransactionsReadController>(
                () => new TransactionsReadController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.level3Data = new Lazy<Level3DataController>(
                () => new Level3DataController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.transactionsUpdates = new Lazy<TransactionsUpdatesController>(
                () => new TransactionsUpdatesController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.users = new Lazy<UsersController>(
                () => new UsersController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.webhooks = new Lazy<WebhooksController>(
                () => new WebhooksController(this, this.httpClient, this.authManagers, this.httpCallBack));

            if (this.authManagers.ContainsKey("global"))
            {
                this.customHeaderAuthenticationManager = (CustomHeaderAuthenticationManager)this.authManagers["global"];
            }

            if (!this.authManagers.ContainsKey("global")
                || !this.CustomHeaderAuthenticationCredentials.Equals(customHeaderUserId, customHeaderUserApiKey, customHeaderDeveloperId))
            {
                this.customHeaderAuthenticationManager = new CustomHeaderAuthenticationManager(customHeaderUserId, customHeaderUserApiKey, customHeaderDeveloperId);
                this.authManagers["global"] = this.customHeaderAuthenticationManager;
            }
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
        /// Gets DeviceTermsController controller.
        /// </summary>
        public DeviceTermsController DeviceTermsController => this.deviceTerms.Value;

        /// <summary>
        /// Gets ElementsController controller.
        /// </summary>
        public ElementsController ElementsController => this.elements.Value;

        /// <summary>
        /// Gets LocationsController controller.
        /// </summary>
        public LocationsController LocationsController => this.locations.Value;

        /// <summary>
        /// Gets OnBoardingController controller.
        /// </summary>
        public OnBoardingController OnBoardingController => this.onBoarding.Value;

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
        /// Gets TokensController controller.
        /// </summary>
        public TokensController TokensController => this.tokens.Value;

        /// <summary>
        /// Gets TransactionsACHController controller.
        /// </summary>
        public TransactionsACHController TransactionsACHController => this.transactionsACH.Value;

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
        /// Gets UsersController controller.
        /// </summary>
        public UsersController UsersController => this.users.Value;

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
        /// Gets auth managers.
        /// </summary>
        internal IDictionary<string, IAuthManager> AuthManagers => this.authManagers;

        /// <summary>
        /// Gets http client.
        /// </summary>
        internal IHttpClient HttpClient => this.httpClient;

        /// <summary>
        /// Gets http callback.
        /// </summary>
        internal HttpCallBack HttpCallBack => this.httpCallBack;

        /// <summary>
        /// Gets the credentials to use with CustomHeaderAuthentication.
        /// </summary>
        public ICustomHeaderAuthenticationCredentials CustomHeaderAuthenticationCredentials => this.customHeaderAuthenticationManager;

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            StringBuilder url = new StringBuilder(EnvironmentsMap[this.Environment][alias]);
            ApiHelper.AppendUrlWithTemplateParameters(url, this.GetBaseUriParameters());

            return url.ToString();
        }

        /// <summary>
        /// Creates an object of the FortisAPIClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .CustomHeaderAuthenticationCredentials(this.customHeaderAuthenticationManager.UserId, this.customHeaderAuthenticationManager.UserApiKey, this.customHeaderAuthenticationManager.DeveloperId)
                .HttpCallBack(this.httpCallBack)
                .HttpClient(this.httpClient)
                .AuthManagers(this.authManagers)
                .HttpClientConfig(config => config.Build());

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
            string customHeaderUserId = System.Environment.GetEnvironmentVariable("FORTIS_API_STANDARD_CUSTOM_HEADER_USER_ID");
            string customHeaderUserApiKey = System.Environment.GetEnvironmentVariable("FORTIS_API_STANDARD_CUSTOM_HEADER_USER_API_KEY");
            string customHeaderDeveloperId = System.Environment.GetEnvironmentVariable("FORTIS_API_STANDARD_CUSTOM_HEADER_DEVELOPER_ID");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (customHeaderUserId != null && customHeaderUserApiKey != null && customHeaderDeveloperId != null)
            {
                builder.CustomHeaderAuthenticationCredentials(customHeaderUserId, customHeaderUserApiKey, customHeaderDeveloperId);
            }

            return builder.Build();
        }

        /// <summary>
        /// Makes a list of the BaseURL parameters.
        /// </summary>
        /// <returns>Returns the parameters list.</returns>
        private List<KeyValuePair<string, object>> GetBaseUriParameters()
        {
            List<KeyValuePair<string, object>> kvpList = new List<KeyValuePair<string, object>>()
            {
            };
            return kvpList;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = FortisAPI.Standard.Environment.Sandbox;
            private string customHeaderUserId = "";
            private string customHeaderUserApiKey = "";
            private string customHeaderDeveloperId = "";
            private IDictionary<string, IAuthManager> authManagers = new Dictionary<string, IAuthManager>();
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();
            private IHttpClient httpClient;
            private HttpCallBack httpCallBack;

            /// <summary>
            /// Sets credentials for CustomHeaderAuthentication.
            /// </summary>
            /// <param name="customHeaderUserId">CustomHeaderUserId.</param>
            /// <param name="customHeaderUserApiKey">CustomHeaderUserApiKey.</param>
            /// <param name="customHeaderDeveloperId">CustomHeaderDeveloperId.</param>
            /// <returns>Builder.</returns>
            public Builder CustomHeaderAuthenticationCredentials(string customHeaderUserId, string customHeaderUserApiKey, string customHeaderDeveloperId)
            {
                this.customHeaderUserId = customHeaderUserId ?? throw new ArgumentNullException(nameof(customHeaderUserId));
                this.customHeaderUserApiKey = customHeaderUserApiKey ?? throw new ArgumentNullException(nameof(customHeaderUserApiKey));
                this.customHeaderDeveloperId = customHeaderDeveloperId ?? throw new ArgumentNullException(nameof(customHeaderDeveloperId));
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
            /// Sets the IHttpClient for the Builder.
            /// </summary>
            /// <param name="httpClient"> http client. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpClient(IHttpClient httpClient)
            {
                this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
                return this;
            }

            /// <summary>
            /// Sets the authentication managers for the Builder.
            /// </summary>
            /// <param name="authManagers"> auth managers. </param>
            /// <returns>Builder.</returns>
            internal Builder AuthManagers(IDictionary<string, IAuthManager> authManagers)
            {
                this.authManagers = authManagers ?? throw new ArgumentNullException(nameof(authManagers));
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
                this.httpClient = new HttpClientWrapper(this.httpClientConfig.Build());

                return new FortisAPIClient(
                    this.environment,
                    this.customHeaderUserId,
                    this.customHeaderUserApiKey,
                    this.customHeaderDeveloperId,
                    this.authManagers,
                    this.httpClient,
                    this.httpCallBack,
                    this.httpClientConfig.Build());
            }
        }
    }
}
