// <copyright file="AchProductTransaction.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// AchProductTransaction.
    /// </summary>
    public class AchProductTransaction : BaseModel
    {
        private string processorVersion;
        private Models.IndustryTypeEnum? industryType;
        private Models.ProcessorEnum? processor;
        private string mcc;
        private Models.TaxSurchargeConfigEnum? taxSurchargeConfig;
        private string terminalId;
        private Models.PartnerEnum? partner;
        private string productAchPvStoreId;
        private string invoiceAdjustmentTitle;
        private string locationApiId;
        private string billingLocationApiId;
        private string portfolioId;
        private string portfolioValidationRule;
        private string subProcessor;
        private string merchantId;
        private string receiptHeader;
        private string receiptFooter;
        private string receiptAddAccountAboveSignature;
        private string receiptAddRecurringAboveSignature;
        private string receiptVtAboveSignature;
        private Models.DefaultTransactionTypeEnum? defaultTransactionType;
        private string username;
        private string password;
        private double? currentBatch;
        private string dupCheckPerBatch;
        private string agentCode;
        private string salesOfficeId;
        private double? hostedPaymentPageMaxAllowed;
        private string surchargeId;
        private Models.CauSubscribeTypeIdEnum? cauSubscribeTypeId;
        private string cauAccountNumber;
        private string locationBillingAccountId;
        private string productBillingGroupId;
        private string accountNumber;
        private string authenticationCode;
        private string tz;
        private double? currencyCode;
        private double? currentStan;
        private int? createdTs;
        private int? modifiedTs;
        private string createdUserId;
        private string modifiedUserId;
        private string productTransactionApiId;
        private string fortisId;
        private string productBillingGroupCode;
        private Models.CauSubscribeTypeCodeEnum? cauSubscribeTypeCode;
        private string merchantCode;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "processor_version", false },
            { "industry_type", false },
            { "processor", false },
            { "mcc", false },
            { "tax_surcharge_config", true },
            { "terminal_id", false },
            { "partner", false },
            { "product_ach_pv_store_id", false },
            { "invoice_adjustment_title", false },
            { "location_api_id", false },
            { "billing_location_api_id", false },
            { "portfolio_id", false },
            { "portfolioValidationRule", false },
            { "sub_processor", false },
            { "merchant_id", false },
            { "receipt_header", false },
            { "receipt_footer", false },
            { "receipt_add_account_above_signature", false },
            { "receipt_add_recurring_above_signature", false },
            { "receipt_vt_above_signature", false },
            { "default_transaction_type", false },
            { "username", false },
            { "password", false },
            { "current_batch", true },
            { "dup_check_per_batch", false },
            { "agent_code", false },
            { "sales_office_id", false },
            { "hosted_payment_page_max_allowed", true },
            { "surcharge_id", false },
            { "cau_subscribe_type_id", false },
            { "cau_account_number", false },
            { "location_billing_account_id", false },
            { "product_billing_group_id", false },
            { "account_number", false },
            { "authentication_code", false },
            { "tz", false },
            { "currency_code", true },
            { "current_stan", true },
            { "created_ts", false },
            { "modified_ts", false },
            { "created_user_id", false },
            { "modified_user_id", false },
            { "product_transaction_api_id", false },
            { "fortis_id", false },
            { "product_billing_group_code", false },
            { "cau_subscribe_type_code", false },
            { "merchant_code", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="AchProductTransaction"/> class.
        /// </summary>
        public AchProductTransaction()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AchProductTransaction"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="paymentMethod">payment_method.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="id">id.</param>
        /// <param name="processorVersion">processor_version.</param>
        /// <param name="industryType">industry_type.</param>
        /// <param name="processor">processor.</param>
        /// <param name="mcc">mcc.</param>
        /// <param name="taxSurchargeConfig">tax_surcharge_config.</param>
        /// <param name="terminalId">terminal_id.</param>
        /// <param name="partner">partner.</param>
        /// <param name="productAchPvStoreId">product_ach_pv_store_id.</param>
        /// <param name="invoiceAdjustmentTitle">invoice_adjustment_title.</param>
        /// <param name="locationApiId">location_api_id.</param>
        /// <param name="billingLocationApiId">billing_location_api_id.</param>
        /// <param name="portfolioId">portfolio_id.</param>
        /// <param name="portfolioValidationRule">portfolioValidationRule.</param>
        /// <param name="subProcessor">sub_processor.</param>
        /// <param name="surcharge">surcharge.</param>
        /// <param name="processorData">processor_data.</param>
        /// <param name="vtClerkNumber">vt_clerk_number.</param>
        /// <param name="vtBillingPhone">vt_billing_phone.</param>
        /// <param name="vtEnableTip">vt_enable_tip.</param>
        /// <param name="achAllowDebit">ach_allow_debit.</param>
        /// <param name="achAllowCredit">ach_allow_credit.</param>
        /// <param name="achAllowRefund">ach_allow_refund.</param>
        /// <param name="vtCvv">vt_cvv.</param>
        /// <param name="vtStreet">vt_street.</param>
        /// <param name="vtZip">vt_zip.</param>
        /// <param name="vtOrderNum">vt_order_num.</param>
        /// <param name="vtEnable">vt_enable.</param>
        /// <param name="receiptShowContactName">receipt_show_contact_name.</param>
        /// <param name="displayAvs">display_avs.</param>
        /// <param name="cardTypeVisa">card_type_visa.</param>
        /// <param name="cardTypeMc">card_type_mc.</param>
        /// <param name="cardTypeDisc">card_type_disc.</param>
        /// <param name="cardTypeAmex">card_type_amex.</param>
        /// <param name="cardTypeDiners">card_type_diners.</param>
        /// <param name="cardTypeJcb">card_type_jcb.</param>
        /// <param name="invoiceLocation">invoice_location.</param>
        /// <param name="allowPartialAuthorization">allow_partial_authorization.</param>
        /// <param name="allowRecurringPartialAuthorization">allow_recurring_partial_authorization.</param>
        /// <param name="autoDeclineCvv">auto_decline_cvv.</param>
        /// <param name="autoDeclineStreet">auto_decline_street.</param>
        /// <param name="autoDeclineZip">auto_decline_zip.</param>
        /// <param name="splitPaymentsAllow">split_payments_allow.</param>
        /// <param name="vtShowCustomFields">vt_show_custom_fields.</param>
        /// <param name="receiptShowCustomFields">receipt_show_custom_fields.</param>
        /// <param name="vtOverrideSalesTaxAllowed">vt_override_sales_tax_allowed.</param>
        /// <param name="vtEnableSalesTax">vt_enable_sales_tax.</param>
        /// <param name="vtRequireZip">vt_require_zip.</param>
        /// <param name="vtRequireStreet">vt_require_street.</param>
        /// <param name="autoDeclineCavv">auto_decline_cavv.</param>
        /// <param name="merchantId">merchant_id.</param>
        /// <param name="receiptHeader">receipt_header.</param>
        /// <param name="receiptFooter">receipt_footer.</param>
        /// <param name="receiptAddAccountAboveSignature">receipt_add_account_above_signature.</param>
        /// <param name="receiptAddRecurringAboveSignature">receipt_add_recurring_above_signature.</param>
        /// <param name="receiptVtAboveSignature">receipt_vt_above_signature.</param>
        /// <param name="defaultTransactionType">default_transaction_type.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <param name="currentBatch">current_batch.</param>
        /// <param name="dupCheckPerBatch">dup_check_per_batch.</param>
        /// <param name="agentCode">agent_code.</param>
        /// <param name="paylinkAllow">paylink_allow.</param>
        /// <param name="quickInvoiceAllow">quick_invoice_allow.</param>
        /// <param name="level3Allow">level3_allow.</param>
        /// <param name="payfacEnable">payfac_enable.</param>
        /// <param name="salesOfficeId">sales_office_id.</param>
        /// <param name="hostedPaymentPageMaxAllowed">hosted_payment_page_max_allowed.</param>
        /// <param name="hostedPaymentPageAllow">hosted_payment_page_allow.</param>
        /// <param name="surchargeId">surcharge_id.</param>
        /// <param name="level3Default">level3_default.</param>
        /// <param name="cauSubscribeTypeId">cau_subscribe_type_id.</param>
        /// <param name="cauAccountNumber">cau_account_number.</param>
        /// <param name="locationBillingAccountId">location_billing_account_id.</param>
        /// <param name="productBillingGroupId">product_billing_group_id.</param>
        /// <param name="accountNumber">account_number.</param>
        /// <param name="runAvsOnAccountvaultCreate">run_avs_on_accountvault_create.</param>
        /// <param name="accountvaultExpireNotificationEmailEnable">accountvault_expire_notification_email_enable.</param>
        /// <param name="debitAllowVoid">debit_allow_void.</param>
        /// <param name="quickInvoiceTextToPay">quick_invoice_text_to_pay.</param>
        /// <param name="authenticationCode">authentication_code.</param>
        /// <param name="smsEnable">sms_enable.</param>
        /// <param name="vtShowCurrency">vt_show_currency.</param>
        /// <param name="receiptShowCurrency">receipt_show_currency.</param>
        /// <param name="allowBlindRefund">allow_blind_refund.</param>
        /// <param name="vtShowCompanyName">vt_show_company_name.</param>
        /// <param name="receiptShowCompanyName">receipt_show_company_name.</param>
        /// <param name="bankFundedOnly">bank_funded_only.</param>
        /// <param name="requireCvvOnKeyedCnp">require_cvv_on_keyed_cnp.</param>
        /// <param name="requireCvvOnTokenizedCnp">require_cvv_on_tokenized_cnp.</param>
        /// <param name="showSecondaryAmount">show_secondary_amount.</param>
        /// <param name="allowSecondaryAmount">allow_secondary_amount.</param>
        /// <param name="showGooglePay">show_google_pay.</param>
        /// <param name="showApplePay">show_apple_pay.</param>
        /// <param name="receiptLogo">receipt_logo.</param>
        /// <param name="active">active.</param>
        /// <param name="tz">tz.</param>
        /// <param name="currencyCode">currency_code.</param>
        /// <param name="currentStan">current_stan.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="modifiedUserId">modified_user_id.</param>
        /// <param name="productTransactionApiId">product_transaction_api_id.</param>
        /// <param name="transactionAmountNotificationThreshold">transaction_amount_notification_threshold.</param>
        /// <param name="isSecondaryAmountAllowed">is_secondary_amount_allowed.</param>
        /// <param name="batchRiskConfig">batch_risk_config.</param>
        /// <param name="fortisId">fortis_id.</param>
        /// <param name="productBillingGroupCode">product_billing_group_code.</param>
        /// <param name="cauSubscribeTypeCode">cau_subscribe_type_code.</param>
        /// <param name="merchantCode">merchant_code.</param>
        public AchProductTransaction(
            string title,
            Models.PaymentMethodEnum paymentMethod,
            string locationId,
            string id,
            string processorVersion = null,
            Models.IndustryTypeEnum? industryType = null,
            Models.ProcessorEnum? processor = null,
            string mcc = null,
            Models.TaxSurchargeConfigEnum? taxSurchargeConfig = Models.TaxSurchargeConfigEnum.Enum2,
            string terminalId = null,
            Models.PartnerEnum? partner = null,
            string productAchPvStoreId = null,
            string invoiceAdjustmentTitle = null,
            string locationApiId = null,
            string billingLocationApiId = null,
            string portfolioId = null,
            string portfolioValidationRule = null,
            string subProcessor = null,
            object surcharge = null,
            object processorData = null,
            bool? vtClerkNumber = null,
            bool? vtBillingPhone = null,
            bool? vtEnableTip = null,
            bool? achAllowDebit = null,
            bool? achAllowCredit = null,
            bool? achAllowRefund = null,
            bool? vtCvv = null,
            bool? vtStreet = null,
            bool? vtZip = null,
            bool? vtOrderNum = null,
            bool? vtEnable = null,
            bool? receiptShowContactName = null,
            bool? displayAvs = null,
            bool? cardTypeVisa = null,
            bool? cardTypeMc = null,
            bool? cardTypeDisc = null,
            bool? cardTypeAmex = null,
            bool? cardTypeDiners = null,
            bool? cardTypeJcb = null,
            bool? invoiceLocation = null,
            bool? allowPartialAuthorization = null,
            bool? allowRecurringPartialAuthorization = null,
            bool? autoDeclineCvv = null,
            bool? autoDeclineStreet = null,
            bool? autoDeclineZip = null,
            bool? splitPaymentsAllow = null,
            bool? vtShowCustomFields = null,
            bool? receiptShowCustomFields = null,
            bool? vtOverrideSalesTaxAllowed = null,
            bool? vtEnableSalesTax = null,
            bool? vtRequireZip = null,
            bool? vtRequireStreet = null,
            bool? autoDeclineCavv = null,
            string merchantId = null,
            string receiptHeader = null,
            string receiptFooter = null,
            string receiptAddAccountAboveSignature = null,
            string receiptAddRecurringAboveSignature = null,
            string receiptVtAboveSignature = null,
            Models.DefaultTransactionTypeEnum? defaultTransactionType = null,
            string username = null,
            string password = null,
            double? currentBatch = 1,
            string dupCheckPerBatch = null,
            string agentCode = null,
            bool? paylinkAllow = null,
            bool? quickInvoiceAllow = null,
            bool? level3Allow = null,
            bool? payfacEnable = null,
            string salesOfficeId = null,
            double? hostedPaymentPageMaxAllowed = 5,
            bool? hostedPaymentPageAllow = null,
            string surchargeId = null,
            object level3Default = null,
            Models.CauSubscribeTypeIdEnum? cauSubscribeTypeId = null,
            string cauAccountNumber = null,
            string locationBillingAccountId = null,
            string productBillingGroupId = null,
            string accountNumber = null,
            bool? runAvsOnAccountvaultCreate = null,
            bool? accountvaultExpireNotificationEmailEnable = null,
            bool? debitAllowVoid = null,
            bool? quickInvoiceTextToPay = null,
            string authenticationCode = null,
            bool? smsEnable = null,
            bool? vtShowCurrency = null,
            bool? receiptShowCurrency = null,
            bool? allowBlindRefund = null,
            bool? vtShowCompanyName = null,
            bool? receiptShowCompanyName = null,
            bool? bankFundedOnly = null,
            bool? requireCvvOnKeyedCnp = null,
            bool? requireCvvOnTokenizedCnp = null,
            bool? showSecondaryAmount = null,
            bool? allowSecondaryAmount = null,
            bool? showGooglePay = null,
            bool? showApplePay = null,
            string receiptLogo = null,
            bool? active = null,
            string tz = null,
            double? currencyCode = 840,
            double? currentStan = 1,
            int? createdTs = null,
            int? modifiedTs = null,
            string createdUserId = null,
            string modifiedUserId = null,
            string productTransactionApiId = null,
            int? transactionAmountNotificationThreshold = null,
            bool? isSecondaryAmountAllowed = null,
            object batchRiskConfig = null,
            string fortisId = null,
            string productBillingGroupCode = null,
            Models.CauSubscribeTypeCodeEnum? cauSubscribeTypeCode = null,
            string merchantCode = null)
        {
            if (processorVersion != null)
            {
                this.ProcessorVersion = processorVersion;
            }

            if (industryType != null)
            {
                this.IndustryType = industryType;
            }

            this.Title = title;
            this.PaymentMethod = paymentMethod;
            if (processor != null)
            {
                this.Processor = processor;
            }

            if (mcc != null)
            {
                this.Mcc = mcc;
            }

            this.TaxSurchargeConfig = taxSurchargeConfig;
            if (terminalId != null)
            {
                this.TerminalId = terminalId;
            }

            if (partner != null)
            {
                this.Partner = partner;
            }

            if (productAchPvStoreId != null)
            {
                this.ProductAchPvStoreId = productAchPvStoreId;
            }

            if (invoiceAdjustmentTitle != null)
            {
                this.InvoiceAdjustmentTitle = invoiceAdjustmentTitle;
            }

            this.LocationId = locationId;
            if (locationApiId != null)
            {
                this.LocationApiId = locationApiId;
            }

            if (billingLocationApiId != null)
            {
                this.BillingLocationApiId = billingLocationApiId;
            }

            if (portfolioId != null)
            {
                this.PortfolioId = portfolioId;
            }

            if (portfolioValidationRule != null)
            {
                this.PortfolioValidationRule = portfolioValidationRule;
            }

            if (subProcessor != null)
            {
                this.SubProcessor = subProcessor;
            }

            this.Surcharge = surcharge;
            this.ProcessorData = processorData;
            this.VtClerkNumber = vtClerkNumber;
            this.VtBillingPhone = vtBillingPhone;
            this.VtEnableTip = vtEnableTip;
            this.AchAllowDebit = achAllowDebit;
            this.AchAllowCredit = achAllowCredit;
            this.AchAllowRefund = achAllowRefund;
            this.VtCvv = vtCvv;
            this.VtStreet = vtStreet;
            this.VtZip = vtZip;
            this.VtOrderNum = vtOrderNum;
            this.VtEnable = vtEnable;
            this.ReceiptShowContactName = receiptShowContactName;
            this.DisplayAvs = displayAvs;
            this.CardTypeVisa = cardTypeVisa;
            this.CardTypeMc = cardTypeMc;
            this.CardTypeDisc = cardTypeDisc;
            this.CardTypeAmex = cardTypeAmex;
            this.CardTypeDiners = cardTypeDiners;
            this.CardTypeJcb = cardTypeJcb;
            this.InvoiceLocation = invoiceLocation;
            this.AllowPartialAuthorization = allowPartialAuthorization;
            this.AllowRecurringPartialAuthorization = allowRecurringPartialAuthorization;
            this.AutoDeclineCvv = autoDeclineCvv;
            this.AutoDeclineStreet = autoDeclineStreet;
            this.AutoDeclineZip = autoDeclineZip;
            this.SplitPaymentsAllow = splitPaymentsAllow;
            this.VtShowCustomFields = vtShowCustomFields;
            this.ReceiptShowCustomFields = receiptShowCustomFields;
            this.VtOverrideSalesTaxAllowed = vtOverrideSalesTaxAllowed;
            this.VtEnableSalesTax = vtEnableSalesTax;
            this.VtRequireZip = vtRequireZip;
            this.VtRequireStreet = vtRequireStreet;
            this.AutoDeclineCavv = autoDeclineCavv;
            if (merchantId != null)
            {
                this.MerchantId = merchantId;
            }

            if (receiptHeader != null)
            {
                this.ReceiptHeader = receiptHeader;
            }

            if (receiptFooter != null)
            {
                this.ReceiptFooter = receiptFooter;
            }

            if (receiptAddAccountAboveSignature != null)
            {
                this.ReceiptAddAccountAboveSignature = receiptAddAccountAboveSignature;
            }

            if (receiptAddRecurringAboveSignature != null)
            {
                this.ReceiptAddRecurringAboveSignature = receiptAddRecurringAboveSignature;
            }

            if (receiptVtAboveSignature != null)
            {
                this.ReceiptVtAboveSignature = receiptVtAboveSignature;
            }

            if (defaultTransactionType != null)
            {
                this.DefaultTransactionType = defaultTransactionType;
            }

            if (username != null)
            {
                this.Username = username;
            }

            if (password != null)
            {
                this.Password = password;
            }

            this.CurrentBatch = currentBatch;
            if (dupCheckPerBatch != null)
            {
                this.DupCheckPerBatch = dupCheckPerBatch;
            }

            if (agentCode != null)
            {
                this.AgentCode = agentCode;
            }

            this.PaylinkAllow = paylinkAllow;
            this.QuickInvoiceAllow = quickInvoiceAllow;
            this.Level3Allow = level3Allow;
            this.PayfacEnable = payfacEnable;
            if (salesOfficeId != null)
            {
                this.SalesOfficeId = salesOfficeId;
            }

            this.HostedPaymentPageMaxAllowed = hostedPaymentPageMaxAllowed;
            this.HostedPaymentPageAllow = hostedPaymentPageAllow;
            if (surchargeId != null)
            {
                this.SurchargeId = surchargeId;
            }

            this.Level3Default = level3Default;
            if (cauSubscribeTypeId != null)
            {
                this.CauSubscribeTypeId = cauSubscribeTypeId;
            }

            if (cauAccountNumber != null)
            {
                this.CauAccountNumber = cauAccountNumber;
            }

            if (locationBillingAccountId != null)
            {
                this.LocationBillingAccountId = locationBillingAccountId;
            }

            if (productBillingGroupId != null)
            {
                this.ProductBillingGroupId = productBillingGroupId;
            }

            if (accountNumber != null)
            {
                this.AccountNumber = accountNumber;
            }

            this.RunAvsOnAccountvaultCreate = runAvsOnAccountvaultCreate;
            this.AccountvaultExpireNotificationEmailEnable = accountvaultExpireNotificationEmailEnable;
            this.DebitAllowVoid = debitAllowVoid;
            this.QuickInvoiceTextToPay = quickInvoiceTextToPay;
            if (authenticationCode != null)
            {
                this.AuthenticationCode = authenticationCode;
            }

            this.SmsEnable = smsEnable;
            this.VtShowCurrency = vtShowCurrency;
            this.ReceiptShowCurrency = receiptShowCurrency;
            this.AllowBlindRefund = allowBlindRefund;
            this.VtShowCompanyName = vtShowCompanyName;
            this.ReceiptShowCompanyName = receiptShowCompanyName;
            this.BankFundedOnly = bankFundedOnly;
            this.RequireCvvOnKeyedCnp = requireCvvOnKeyedCnp;
            this.RequireCvvOnTokenizedCnp = requireCvvOnTokenizedCnp;
            this.ShowSecondaryAmount = showSecondaryAmount;
            this.AllowSecondaryAmount = allowSecondaryAmount;
            this.ShowGooglePay = showGooglePay;
            this.ShowApplePay = showApplePay;
            this.Id = id;
            this.ReceiptLogo = receiptLogo;
            this.Active = active;
            if (tz != null)
            {
                this.Tz = tz;
            }

            this.CurrencyCode = currencyCode;
            this.CurrentStan = currentStan;
            if (createdTs != null)
            {
                this.CreatedTs = createdTs;
            }

            if (modifiedTs != null)
            {
                this.ModifiedTs = modifiedTs;
            }

            if (createdUserId != null)
            {
                this.CreatedUserId = createdUserId;
            }

            if (modifiedUserId != null)
            {
                this.ModifiedUserId = modifiedUserId;
            }

            if (productTransactionApiId != null)
            {
                this.ProductTransactionApiId = productTransactionApiId;
            }

            this.TransactionAmountNotificationThreshold = transactionAmountNotificationThreshold;
            this.IsSecondaryAmountAllowed = isSecondaryAmountAllowed;
            this.BatchRiskConfig = batchRiskConfig;
            if (fortisId != null)
            {
                this.FortisId = fortisId;
            }

            if (productBillingGroupCode != null)
            {
                this.ProductBillingGroupCode = productBillingGroupCode;
            }

            if (cauSubscribeTypeCode != null)
            {
                this.CauSubscribeTypeCode = cauSubscribeTypeCode;
            }

            if (merchantCode != null)
            {
                this.MerchantCode = merchantCode;
            }

        }

        /// <summary>
        /// Processor Version
        /// </summary>
        [JsonProperty("processor_version")]
        public string ProcessorVersion
        {
            get
            {
                return this.processorVersion;
            }

            set
            {
                this.shouldSerialize["processor_version"] = true;
                this.processorVersion = value;
            }
        }

        /// <summary>
        /// Industry Type
        /// </summary>
        [JsonProperty("industry_type")]
        public Models.IndustryTypeEnum? IndustryType
        {
            get
            {
                return this.industryType;
            }

            set
            {
                this.shouldSerialize["industry_type"] = true;
                this.industryType = value;
            }
        }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Payment method
        /// </summary>
        [JsonProperty("payment_method")]
        public Models.PaymentMethodEnum PaymentMethod { get; set; }

        /// <summary>
        /// Processor
        /// </summary>
        [JsonProperty("processor")]
        public Models.ProcessorEnum? Processor
        {
            get
            {
                return this.processor;
            }

            set
            {
                this.shouldSerialize["processor"] = true;
                this.processor = value;
            }
        }

        /// <summary>
        /// MCC
        /// </summary>
        [JsonProperty("mcc")]
        public string Mcc
        {
            get
            {
                return this.mcc;
            }

            set
            {
                this.shouldSerialize["mcc"] = true;
                this.mcc = value;
            }
        }

        /// <summary>
        /// Tax Surcharge Config
        /// </summary>
        [JsonProperty("tax_surcharge_config")]
        public Models.TaxSurchargeConfigEnum? TaxSurchargeConfig
        {
            get
            {
                return this.taxSurchargeConfig;
            }

            set
            {
                this.shouldSerialize["tax_surcharge_config"] = true;
                this.taxSurchargeConfig = value;
            }
        }

        /// <summary>
        /// Terminal ID
        /// </summary>
        [JsonProperty("terminal_id")]
        public string TerminalId
        {
            get
            {
                return this.terminalId;
            }

            set
            {
                this.shouldSerialize["terminal_id"] = true;
                this.terminalId = value;
            }
        }

        /// <summary>
        /// Partner
        /// </summary>
        [JsonProperty("partner")]
        public Models.PartnerEnum? Partner
        {
            get
            {
                return this.partner;
            }

            set
            {
                this.shouldSerialize["partner"] = true;
                this.partner = value;
            }
        }

        /// <summary>
        /// Product Ach Pv Store ID
        /// </summary>
        [JsonProperty("product_ach_pv_store_id")]
        public string ProductAchPvStoreId
        {
            get
            {
                return this.productAchPvStoreId;
            }

            set
            {
                this.shouldSerialize["product_ach_pv_store_id"] = true;
                this.productAchPvStoreId = value;
            }
        }

        /// <summary>
        /// Invoice Adjustment Title
        /// </summary>
        [JsonProperty("invoice_adjustment_title")]
        public string InvoiceAdjustmentTitle
        {
            get
            {
                return this.invoiceAdjustmentTitle;
            }

            set
            {
                this.shouldSerialize["invoice_adjustment_title"] = true;
                this.invoiceAdjustmentTitle = value;
            }
        }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        /// <summary>
        /// Location Api ID
        /// </summary>
        [JsonProperty("location_api_id")]
        public string LocationApiId
        {
            get
            {
                return this.locationApiId;
            }

            set
            {
                this.shouldSerialize["location_api_id"] = true;
                this.locationApiId = value;
            }
        }

        /// <summary>
        /// Billing Location API ID
        /// </summary>
        [JsonProperty("billing_location_api_id")]
        public string BillingLocationApiId
        {
            get
            {
                return this.billingLocationApiId;
            }

            set
            {
                this.shouldSerialize["billing_location_api_id"] = true;
                this.billingLocationApiId = value;
            }
        }

        /// <summary>
        /// Portfolio ID
        /// </summary>
        [JsonProperty("portfolio_id")]
        public string PortfolioId
        {
            get
            {
                return this.portfolioId;
            }

            set
            {
                this.shouldSerialize["portfolio_id"] = true;
                this.portfolioId = value;
            }
        }

        /// <summary>
        /// Product Validation Rule
        /// </summary>
        [JsonProperty("portfolioValidationRule")]
        public string PortfolioValidationRule
        {
            get
            {
                return this.portfolioValidationRule;
            }

            set
            {
                this.shouldSerialize["portfolioValidationRule"] = true;
                this.portfolioValidationRule = value;
            }
        }

        /// <summary>
        /// Sub Processor
        /// </summary>
        [JsonProperty("sub_processor")]
        public string SubProcessor
        {
            get
            {
                return this.subProcessor;
            }

            set
            {
                this.shouldSerialize["sub_processor"] = true;
                this.subProcessor = value;
            }
        }

        /// <summary>
        /// Surcharge
        /// </summary>
        [JsonProperty("surcharge", NullValueHandling = NullValueHandling.Ignore)]
        public object Surcharge { get; set; }

        /// <summary>
        /// Gets or sets ProcessorData.
        /// </summary>
        [JsonProperty("processor_data", NullValueHandling = NullValueHandling.Ignore)]
        public object ProcessorData { get; set; }

        /// <summary>
        /// Vt Clerk Number
        /// </summary>
        [JsonProperty("vt_clerk_number", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VtClerkNumber { get; set; }

        /// <summary>
        /// Card Type JCB
        /// </summary>
        [JsonProperty("vt_billing_phone", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VtBillingPhone { get; set; }

        /// <summary>
        /// VT Enable Tip
        /// </summary>
        [JsonProperty("vt_enable_tip", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VtEnableTip { get; set; }

        /// <summary>
        /// Ach Allow Debit
        /// </summary>
        [JsonProperty("ach_allow_debit", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AchAllowDebit { get; set; }

        /// <summary>
        /// Ach Allow Credit
        /// </summary>
        [JsonProperty("ach_allow_credit", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AchAllowCredit { get; set; }

        /// <summary>
        /// Ach Allow Refund
        /// </summary>
        [JsonProperty("ach_allow_refund", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AchAllowRefund { get; set; }

        /// <summary>
        /// VT CVV
        /// </summary>
        [JsonProperty("vt_cvv", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VtCvv { get; set; }

        /// <summary>
        /// VT Street
        /// </summary>
        [JsonProperty("vt_street", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VtStreet { get; set; }

        /// <summary>
        /// VT Zip
        /// </summary>
        [JsonProperty("vt_zip", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VtZip { get; set; }

        /// <summary>
        /// VT Order Num
        /// </summary>
        [JsonProperty("vt_order_num", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VtOrderNum { get; set; }

        /// <summary>
        /// VT Enable
        /// </summary>
        [JsonProperty("vt_enable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VtEnable { get; set; }

        /// <summary>
        /// Receipt Show Contact Name
        /// </summary>
        [JsonProperty("receipt_show_contact_name", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReceiptShowContactName { get; set; }

        /// <summary>
        /// Display Avs
        /// </summary>
        [JsonProperty("display_avs", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DisplayAvs { get; set; }

        /// <summary>
        /// Card Type Visa
        /// </summary>
        [JsonProperty("card_type_visa", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CardTypeVisa { get; set; }

        /// <summary>
        /// Card Type Mc
        /// </summary>
        [JsonProperty("card_type_mc", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CardTypeMc { get; set; }

        /// <summary>
        /// Card Type Disc
        /// </summary>
        [JsonProperty("card_type_disc", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CardTypeDisc { get; set; }

        /// <summary>
        /// Card Type Amex
        /// </summary>
        [JsonProperty("card_type_amex", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CardTypeAmex { get; set; }

        /// <summary>
        /// Card Type Dinners
        /// </summary>
        [JsonProperty("card_type_diners", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CardTypeDiners { get; set; }

        /// <summary>
        /// Gets or sets CardTypeJcb.
        /// </summary>
        [JsonProperty("card_type_jcb", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CardTypeJcb { get; set; }

        /// <summary>
        /// Invoice Location
        /// </summary>
        [JsonProperty("invoice_location", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InvoiceLocation { get; set; }

        /// <summary>
        /// Allow Partial Authorization
        /// </summary>
        [JsonProperty("allow_partial_authorization", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowPartialAuthorization { get; set; }

        /// <summary>
        /// Allow Recurring Partial Authorization
        /// </summary>
        [JsonProperty("allow_recurring_partial_authorization", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowRecurringPartialAuthorization { get; set; }

        /// <summary>
        /// Auto Decline Cvv
        /// </summary>
        [JsonProperty("auto_decline_cvv", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoDeclineCvv { get; set; }

        /// <summary>
        /// Auto Decline Street
        /// </summary>
        [JsonProperty("auto_decline_street", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoDeclineStreet { get; set; }

        /// <summary>
        /// Auto Decline ZIP
        /// </summary>
        [JsonProperty("auto_decline_zip", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoDeclineZip { get; set; }

        /// <summary>
        /// Split Payments Allow
        /// </summary>
        [JsonProperty("split_payments_allow", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SplitPaymentsAllow { get; set; }

        /// <summary>
        /// Vt Show Custom Fields
        /// </summary>
        [JsonProperty("vt_show_custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VtShowCustomFields { get; set; }

        /// <summary>
        /// Receipt Show Custom Fields
        /// </summary>
        [JsonProperty("receipt_show_custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReceiptShowCustomFields { get; set; }

        /// <summary>
        /// Vt Override Sales Tax Allowed
        /// </summary>
        [JsonProperty("vt_override_sales_tax_allowed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VtOverrideSalesTaxAllowed { get; set; }

        /// <summary>
        /// Vt Enable Sales Tax
        /// </summary>
        [JsonProperty("vt_enable_sales_tax", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VtEnableSalesTax { get; set; }

        /// <summary>
        /// Vt Require ZIP
        /// </summary>
        [JsonProperty("vt_require_zip", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VtRequireZip { get; set; }

        /// <summary>
        /// Vt Require Street
        /// </summary>
        [JsonProperty("vt_require_street", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VtRequireStreet { get; set; }

        /// <summary>
        /// Auto Decline Cavv
        /// </summary>
        [JsonProperty("auto_decline_cavv", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoDeclineCavv { get; set; }

        /// <summary>
        /// Merchant ID
        /// </summary>
        [JsonProperty("merchant_id")]
        public string MerchantId
        {
            get
            {
                return this.merchantId;
            }

            set
            {
                this.shouldSerialize["merchant_id"] = true;
                this.merchantId = value;
            }
        }

        /// <summary>
        /// Receipt Header
        /// </summary>
        [JsonProperty("receipt_header")]
        public string ReceiptHeader
        {
            get
            {
                return this.receiptHeader;
            }

            set
            {
                this.shouldSerialize["receipt_header"] = true;
                this.receiptHeader = value;
            }
        }

        /// <summary>
        /// Receipt Footer
        /// </summary>
        [JsonProperty("receipt_footer")]
        public string ReceiptFooter
        {
            get
            {
                return this.receiptFooter;
            }

            set
            {
                this.shouldSerialize["receipt_footer"] = true;
                this.receiptFooter = value;
            }
        }

        /// <summary>
        /// Receipt Add Account Above Signature
        /// </summary>
        [JsonProperty("receipt_add_account_above_signature")]
        public string ReceiptAddAccountAboveSignature
        {
            get
            {
                return this.receiptAddAccountAboveSignature;
            }

            set
            {
                this.shouldSerialize["receipt_add_account_above_signature"] = true;
                this.receiptAddAccountAboveSignature = value;
            }
        }

        /// <summary>
        /// Receipt Add Recurring Above Signature
        /// </summary>
        [JsonProperty("receipt_add_recurring_above_signature")]
        public string ReceiptAddRecurringAboveSignature
        {
            get
            {
                return this.receiptAddRecurringAboveSignature;
            }

            set
            {
                this.shouldSerialize["receipt_add_recurring_above_signature"] = true;
                this.receiptAddRecurringAboveSignature = value;
            }
        }

        /// <summary>
        /// Receipt VT Above Signature
        /// </summary>
        [JsonProperty("receipt_vt_above_signature")]
        public string ReceiptVtAboveSignature
        {
            get
            {
                return this.receiptVtAboveSignature;
            }

            set
            {
                this.shouldSerialize["receipt_vt_above_signature"] = true;
                this.receiptVtAboveSignature = value;
            }
        }

        /// <summary>
        /// Default Transaction Type
        /// </summary>
        [JsonProperty("default_transaction_type")]
        public Models.DefaultTransactionTypeEnum? DefaultTransactionType
        {
            get
            {
                return this.defaultTransactionType;
            }

            set
            {
                this.shouldSerialize["default_transaction_type"] = true;
                this.defaultTransactionType = value;
            }
        }

        /// <summary>
        /// Username
        /// </summary>
        [JsonProperty("username")]
        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                this.shouldSerialize["username"] = true;
                this.username = value;
            }
        }

        /// <summary>
        /// Passowrd
        /// </summary>
        [JsonProperty("password")]
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.shouldSerialize["password"] = true;
                this.password = value;
            }
        }

        /// <summary>
        /// Current Batch
        /// </summary>
        [JsonProperty("current_batch")]
        public double? CurrentBatch
        {
            get
            {
                return this.currentBatch;
            }

            set
            {
                this.shouldSerialize["current_batch"] = true;
                this.currentBatch = value;
            }
        }

        /// <summary>
        /// Dup Check Per Batch
        /// </summary>
        [JsonProperty("dup_check_per_batch")]
        public string DupCheckPerBatch
        {
            get
            {
                return this.dupCheckPerBatch;
            }

            set
            {
                this.shouldSerialize["dup_check_per_batch"] = true;
                this.dupCheckPerBatch = value;
            }
        }

        /// <summary>
        /// Agent Code
        /// </summary>
        [JsonProperty("agent_code")]
        public string AgentCode
        {
            get
            {
                return this.agentCode;
            }

            set
            {
                this.shouldSerialize["agent_code"] = true;
                this.agentCode = value;
            }
        }

        /// <summary>
        /// Paylink Allow
        /// </summary>
        [JsonProperty("paylink_allow", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PaylinkAllow { get; set; }

        /// <summary>
        /// Quick Invoice Allow
        /// </summary>
        [JsonProperty("quick_invoice_allow", NullValueHandling = NullValueHandling.Ignore)]
        public bool? QuickInvoiceAllow { get; set; }

        /// <summary>
        /// Level3 Allow
        /// </summary>
        [JsonProperty("level3_allow", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Level3Allow { get; set; }

        /// <summary>
        /// Payfac Enable
        /// </summary>
        [JsonProperty("payfac_enable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PayfacEnable { get; set; }

        /// <summary>
        /// Sales Office ID
        /// </summary>
        [JsonProperty("sales_office_id")]
        public string SalesOfficeId
        {
            get
            {
                return this.salesOfficeId;
            }

            set
            {
                this.shouldSerialize["sales_office_id"] = true;
                this.salesOfficeId = value;
            }
        }

        /// <summary>
        /// Hosted Payment Page Max Allowed
        /// </summary>
        [JsonProperty("hosted_payment_page_max_allowed")]
        public double? HostedPaymentPageMaxAllowed
        {
            get
            {
                return this.hostedPaymentPageMaxAllowed;
            }

            set
            {
                this.shouldSerialize["hosted_payment_page_max_allowed"] = true;
                this.hostedPaymentPageMaxAllowed = value;
            }
        }

        /// <summary>
        /// Hosted Payment Page Allow
        /// </summary>
        [JsonProperty("hosted_payment_page_allow", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HostedPaymentPageAllow { get; set; }

        /// <summary>
        /// Surcharge ID
        /// </summary>
        [JsonProperty("surcharge_id")]
        public string SurchargeId
        {
            get
            {
                return this.surchargeId;
            }

            set
            {
                this.shouldSerialize["surcharge_id"] = true;
                this.surchargeId = value;
            }
        }

        /// <summary>
        /// Level3 Default
        /// </summary>
        [JsonProperty("level3_default", NullValueHandling = NullValueHandling.Ignore)]
        public object Level3Default { get; set; }

        /// <summary>
        /// Cau Subscribe Type ID
        /// </summary>
        [JsonProperty("cau_subscribe_type_id")]
        public Models.CauSubscribeTypeIdEnum? CauSubscribeTypeId
        {
            get
            {
                return this.cauSubscribeTypeId;
            }

            set
            {
                this.shouldSerialize["cau_subscribe_type_id"] = true;
                this.cauSubscribeTypeId = value;
            }
        }

        /// <summary>
        /// Cau Account Number
        /// </summary>
        [JsonProperty("cau_account_number")]
        public string CauAccountNumber
        {
            get
            {
                return this.cauAccountNumber;
            }

            set
            {
                this.shouldSerialize["cau_account_number"] = true;
                this.cauAccountNumber = value;
            }
        }

        /// <summary>
        /// Location Billing Account ID
        /// </summary>
        [JsonProperty("location_billing_account_id")]
        public string LocationBillingAccountId
        {
            get
            {
                return this.locationBillingAccountId;
            }

            set
            {
                this.shouldSerialize["location_billing_account_id"] = true;
                this.locationBillingAccountId = value;
            }
        }

        /// <summary>
        /// Product Billing Group ID
        /// </summary>
        [JsonProperty("product_billing_group_id")]
        public string ProductBillingGroupId
        {
            get
            {
                return this.productBillingGroupId;
            }

            set
            {
                this.shouldSerialize["product_billing_group_id"] = true;
                this.productBillingGroupId = value;
            }
        }

        /// <summary>
        /// Account number
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber
        {
            get
            {
                return this.accountNumber;
            }

            set
            {
                this.shouldSerialize["account_number"] = true;
                this.accountNumber = value;
            }
        }

        /// <summary>
        /// Run Avs On Accountvault Create
        /// </summary>
        [JsonProperty("run_avs_on_accountvault_create", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RunAvsOnAccountvaultCreate { get; set; }

        /// <summary>
        /// Accountvault Expire Notification Email Enable
        /// </summary>
        [JsonProperty("accountvault_expire_notification_email_enable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AccountvaultExpireNotificationEmailEnable { get; set; }

        /// <summary>
        /// Debit Allow Void
        /// </summary>
        [JsonProperty("debit_allow_void", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DebitAllowVoid { get; set; }

        /// <summary>
        /// Quick Invoice Text To Pay
        /// </summary>
        [JsonProperty("quick_invoice_text_to_pay", NullValueHandling = NullValueHandling.Ignore)]
        public bool? QuickInvoiceTextToPay { get; set; }

        /// <summary>
        /// Authentication Code
        /// </summary>
        [JsonProperty("authentication_code")]
        public string AuthenticationCode
        {
            get
            {
                return this.authenticationCode;
            }

            set
            {
                this.shouldSerialize["authentication_code"] = true;
                this.authenticationCode = value;
            }
        }

        /// <summary>
        /// SMS Enable
        /// </summary>
        [JsonProperty("sms_enable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SmsEnable { get; set; }

        /// <summary>
        /// Vt Show Currency
        /// </summary>
        [JsonProperty("vt_show_currency", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VtShowCurrency { get; set; }

        /// <summary>
        /// Receipt Show Currency
        /// </summary>
        [JsonProperty("receipt_show_currency", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReceiptShowCurrency { get; set; }

        /// <summary>
        /// Allow Blind Refund
        /// </summary>
        [JsonProperty("allow_blind_refund", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowBlindRefund { get; set; }

        /// <summary>
        /// Vt Show Company Name
        /// </summary>
        [JsonProperty("vt_show_company_name", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VtShowCompanyName { get; set; }

        /// <summary>
        /// Receipt Show Company Name
        /// </summary>
        [JsonProperty("receipt_show_company_name", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReceiptShowCompanyName { get; set; }

        /// <summary>
        /// Bank Funded Only
        /// </summary>
        [JsonProperty("bank_funded_only", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BankFundedOnly { get; set; }

        /// <summary>
        /// Require CVV on keyed CNP
        /// </summary>
        [JsonProperty("require_cvv_on_keyed_cnp", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RequireCvvOnKeyedCnp { get; set; }

        /// <summary>
        /// Require CVV on tokenized CNP
        /// </summary>
        [JsonProperty("require_cvv_on_tokenized_cnp", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RequireCvvOnTokenizedCnp { get; set; }

        /// <summary>
        /// Show Retained Amount
        /// </summary>
        [JsonProperty("show_secondary_amount", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowSecondaryAmount { get; set; }

        /// <summary>
        /// Allow Retained Amount
        /// </summary>
        [JsonProperty("allow_secondary_amount", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowSecondaryAmount { get; set; }

        /// <summary>
        /// Vt Require Street
        /// </summary>
        [JsonProperty("show_google_pay", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowGooglePay { get; set; }

        /// <summary>
        /// Vt Require Street
        /// </summary>
        [JsonProperty("show_apple_pay", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowApplePay { get; set; }

        /// <summary>
        /// User Reports ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Receipt Logo
        /// </summary>
        [JsonProperty("receipt_logo", NullValueHandling = NullValueHandling.Ignore)]
        public string ReceiptLogo { get; set; }

        /// <summary>
        /// Active
        /// </summary>
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Active { get; set; }

        /// <summary>
        /// TZ
        /// </summary>
        [JsonProperty("tz")]
        public string Tz
        {
            get
            {
                return this.tz;
            }

            set
            {
                this.shouldSerialize["tz"] = true;
                this.tz = value;
            }
        }

        /// <summary>
        /// Currency Code
        /// </summary>
        [JsonProperty("currency_code")]
        public double? CurrencyCode
        {
            get
            {
                return this.currencyCode;
            }

            set
            {
                this.shouldSerialize["currency_code"] = true;
                this.currencyCode = value;
            }
        }

        /// <summary>
        /// Current Stan
        /// </summary>
        [JsonProperty("current_stan")]
        public double? CurrentStan
        {
            get
            {
                return this.currentStan;
            }

            set
            {
                this.shouldSerialize["current_stan"] = true;
                this.currentStan = value;
            }
        }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int? CreatedTs
        {
            get
            {
                return this.createdTs;
            }

            set
            {
                this.shouldSerialize["created_ts"] = true;
                this.createdTs = value;
            }
        }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts")]
        public int? ModifiedTs
        {
            get
            {
                return this.modifiedTs;
            }

            set
            {
                this.shouldSerialize["modified_ts"] = true;
                this.modifiedTs = value;
            }
        }

        /// <summary>
        /// User ID Created the register
        /// </summary>
        [JsonProperty("created_user_id")]
        public string CreatedUserId
        {
            get
            {
                return this.createdUserId;
            }

            set
            {
                this.shouldSerialize["created_user_id"] = true;
                this.createdUserId = value;
            }
        }

        /// <summary>
        /// Last User ID that updated the register
        /// </summary>
        [JsonProperty("modified_user_id")]
        public string ModifiedUserId
        {
            get
            {
                return this.modifiedUserId;
            }

            set
            {
                this.shouldSerialize["modified_user_id"] = true;
                this.modifiedUserId = value;
            }
        }

        /// <summary>
        /// Product Transaction API ID
        /// </summary>
        [JsonProperty("product_transaction_api_id")]
        public string ProductTransactionApiId
        {
            get
            {
                return this.productTransactionApiId;
            }

            set
            {
                this.shouldSerialize["product_transaction_api_id"] = true;
                this.productTransactionApiId = value;
            }
        }

        /// <summary>
        /// Transaction Amount Notification Treshold
        /// </summary>
        [JsonProperty("transaction_amount_notification_threshold", NullValueHandling = NullValueHandling.Ignore)]
        public int? TransactionAmountNotificationThreshold { get; set; }

        /// <summary>
        /// Allow Retained Amount
        /// </summary>
        [JsonProperty("is_secondary_amount_allowed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsSecondaryAmountAllowed { get; set; }

        /// <summary>
        /// Batch Risk Config
        /// </summary>
        [JsonProperty("batch_risk_config", NullValueHandling = NullValueHandling.Ignore)]
        public object BatchRiskConfig { get; set; }

        /// <summary>
        /// Gets or sets FortisId.
        /// </summary>
        [JsonProperty("fortis_id")]
        public string FortisId
        {
            get
            {
                return this.fortisId;
            }

            set
            {
                this.shouldSerialize["fortis_id"] = true;
                this.fortisId = value;
            }
        }

        /// <summary>
        /// Product Billing Group Code
        /// </summary>
        [JsonProperty("product_billing_group_code")]
        public string ProductBillingGroupCode
        {
            get
            {
                return this.productBillingGroupCode;
            }

            set
            {
                this.shouldSerialize["product_billing_group_code"] = true;
                this.productBillingGroupCode = value;
            }
        }

        /// <summary>
        /// Cau Subscribe Type Code
        /// </summary>
        [JsonProperty("cau_subscribe_type_code")]
        public Models.CauSubscribeTypeCodeEnum? CauSubscribeTypeCode
        {
            get
            {
                return this.cauSubscribeTypeCode;
            }

            set
            {
                this.shouldSerialize["cau_subscribe_type_code"] = true;
                this.cauSubscribeTypeCode = value;
            }
        }

        /// <summary>
        /// Merchant Code
        /// </summary>
        [JsonProperty("merchant_code")]
        public string MerchantCode
        {
            get
            {
                return this.merchantCode;
            }

            set
            {
                this.shouldSerialize["merchant_code"] = true;
                this.merchantCode = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AchProductTransaction : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetProcessorVersion()
        {
            this.shouldSerialize["processor_version"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetIndustryType()
        {
            this.shouldSerialize["industry_type"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetProcessor()
        {
            this.shouldSerialize["processor"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMcc()
        {
            this.shouldSerialize["mcc"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTaxSurchargeConfig()
        {
            this.shouldSerialize["tax_surcharge_config"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTerminalId()
        {
            this.shouldSerialize["terminal_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPartner()
        {
            this.shouldSerialize["partner"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetProductAchPvStoreId()
        {
            this.shouldSerialize["product_ach_pv_store_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetInvoiceAdjustmentTitle()
        {
            this.shouldSerialize["invoice_adjustment_title"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocationApiId()
        {
            this.shouldSerialize["location_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetBillingLocationApiId()
        {
            this.shouldSerialize["billing_location_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPortfolioId()
        {
            this.shouldSerialize["portfolio_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPortfolioValidationRule()
        {
            this.shouldSerialize["portfolioValidationRule"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSubProcessor()
        {
            this.shouldSerialize["sub_processor"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMerchantId()
        {
            this.shouldSerialize["merchant_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReceiptHeader()
        {
            this.shouldSerialize["receipt_header"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReceiptFooter()
        {
            this.shouldSerialize["receipt_footer"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReceiptAddAccountAboveSignature()
        {
            this.shouldSerialize["receipt_add_account_above_signature"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReceiptAddRecurringAboveSignature()
        {
            this.shouldSerialize["receipt_add_recurring_above_signature"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReceiptVtAboveSignature()
        {
            this.shouldSerialize["receipt_vt_above_signature"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDefaultTransactionType()
        {
            this.shouldSerialize["default_transaction_type"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetUsername()
        {
            this.shouldSerialize["username"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPassword()
        {
            this.shouldSerialize["password"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCurrentBatch()
        {
            this.shouldSerialize["current_batch"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDupCheckPerBatch()
        {
            this.shouldSerialize["dup_check_per_batch"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAgentCode()
        {
            this.shouldSerialize["agent_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSalesOfficeId()
        {
            this.shouldSerialize["sales_office_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetHostedPaymentPageMaxAllowed()
        {
            this.shouldSerialize["hosted_payment_page_max_allowed"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSurchargeId()
        {
            this.shouldSerialize["surcharge_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCauSubscribeTypeId()
        {
            this.shouldSerialize["cau_subscribe_type_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCauAccountNumber()
        {
            this.shouldSerialize["cau_account_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocationBillingAccountId()
        {
            this.shouldSerialize["location_billing_account_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetProductBillingGroupId()
        {
            this.shouldSerialize["product_billing_group_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAccountNumber()
        {
            this.shouldSerialize["account_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAuthenticationCode()
        {
            this.shouldSerialize["authentication_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTz()
        {
            this.shouldSerialize["tz"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCurrencyCode()
        {
            this.shouldSerialize["currency_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCurrentStan()
        {
            this.shouldSerialize["current_stan"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCreatedTs()
        {
            this.shouldSerialize["created_ts"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetModifiedTs()
        {
            this.shouldSerialize["modified_ts"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCreatedUserId()
        {
            this.shouldSerialize["created_user_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetModifiedUserId()
        {
            this.shouldSerialize["modified_user_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetProductTransactionApiId()
        {
            this.shouldSerialize["product_transaction_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFortisId()
        {
            this.shouldSerialize["fortis_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetProductBillingGroupCode()
        {
            this.shouldSerialize["product_billing_group_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCauSubscribeTypeCode()
        {
            this.shouldSerialize["cau_subscribe_type_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMerchantCode()
        {
            this.shouldSerialize["merchant_code"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeProcessorVersion()
        {
            return this.shouldSerialize["processor_version"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIndustryType()
        {
            return this.shouldSerialize["industry_type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeProcessor()
        {
            return this.shouldSerialize["processor"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMcc()
        {
            return this.shouldSerialize["mcc"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTaxSurchargeConfig()
        {
            return this.shouldSerialize["tax_surcharge_config"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTerminalId()
        {
            return this.shouldSerialize["terminal_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePartner()
        {
            return this.shouldSerialize["partner"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeProductAchPvStoreId()
        {
            return this.shouldSerialize["product_ach_pv_store_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInvoiceAdjustmentTitle()
        {
            return this.shouldSerialize["invoice_adjustment_title"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationApiId()
        {
            return this.shouldSerialize["location_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBillingLocationApiId()
        {
            return this.shouldSerialize["billing_location_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePortfolioId()
        {
            return this.shouldSerialize["portfolio_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePortfolioValidationRule()
        {
            return this.shouldSerialize["portfolioValidationRule"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSubProcessor()
        {
            return this.shouldSerialize["sub_processor"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMerchantId()
        {
            return this.shouldSerialize["merchant_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReceiptHeader()
        {
            return this.shouldSerialize["receipt_header"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReceiptFooter()
        {
            return this.shouldSerialize["receipt_footer"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReceiptAddAccountAboveSignature()
        {
            return this.shouldSerialize["receipt_add_account_above_signature"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReceiptAddRecurringAboveSignature()
        {
            return this.shouldSerialize["receipt_add_recurring_above_signature"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReceiptVtAboveSignature()
        {
            return this.shouldSerialize["receipt_vt_above_signature"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDefaultTransactionType()
        {
            return this.shouldSerialize["default_transaction_type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUsername()
        {
            return this.shouldSerialize["username"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePassword()
        {
            return this.shouldSerialize["password"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCurrentBatch()
        {
            return this.shouldSerialize["current_batch"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDupCheckPerBatch()
        {
            return this.shouldSerialize["dup_check_per_batch"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAgentCode()
        {
            return this.shouldSerialize["agent_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSalesOfficeId()
        {
            return this.shouldSerialize["sales_office_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeHostedPaymentPageMaxAllowed()
        {
            return this.shouldSerialize["hosted_payment_page_max_allowed"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSurchargeId()
        {
            return this.shouldSerialize["surcharge_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCauSubscribeTypeId()
        {
            return this.shouldSerialize["cau_subscribe_type_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCauAccountNumber()
        {
            return this.shouldSerialize["cau_account_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationBillingAccountId()
        {
            return this.shouldSerialize["location_billing_account_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeProductBillingGroupId()
        {
            return this.shouldSerialize["product_billing_group_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountNumber()
        {
            return this.shouldSerialize["account_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAuthenticationCode()
        {
            return this.shouldSerialize["authentication_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTz()
        {
            return this.shouldSerialize["tz"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCurrencyCode()
        {
            return this.shouldSerialize["currency_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCurrentStan()
        {
            return this.shouldSerialize["current_stan"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCreatedTs()
        {
            return this.shouldSerialize["created_ts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModifiedTs()
        {
            return this.shouldSerialize["modified_ts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCreatedUserId()
        {
            return this.shouldSerialize["created_user_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModifiedUserId()
        {
            return this.shouldSerialize["modified_user_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeProductTransactionApiId()
        {
            return this.shouldSerialize["product_transaction_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFortisId()
        {
            return this.shouldSerialize["fortis_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeProductBillingGroupCode()
        {
            return this.shouldSerialize["product_billing_group_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCauSubscribeTypeCode()
        {
            return this.shouldSerialize["cau_subscribe_type_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMerchantCode()
        {
            return this.shouldSerialize["merchant_code"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is AchProductTransaction other &&                ((this.ProcessorVersion == null && other.ProcessorVersion == null) || (this.ProcessorVersion?.Equals(other.ProcessorVersion) == true)) &&
                ((this.IndustryType == null && other.IndustryType == null) || (this.IndustryType?.Equals(other.IndustryType) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                this.PaymentMethod.Equals(other.PaymentMethod) &&
                ((this.Processor == null && other.Processor == null) || (this.Processor?.Equals(other.Processor) == true)) &&
                ((this.Mcc == null && other.Mcc == null) || (this.Mcc?.Equals(other.Mcc) == true)) &&
                ((this.TaxSurchargeConfig == null && other.TaxSurchargeConfig == null) || (this.TaxSurchargeConfig?.Equals(other.TaxSurchargeConfig) == true)) &&
                ((this.TerminalId == null && other.TerminalId == null) || (this.TerminalId?.Equals(other.TerminalId) == true)) &&
                ((this.Partner == null && other.Partner == null) || (this.Partner?.Equals(other.Partner) == true)) &&
                ((this.ProductAchPvStoreId == null && other.ProductAchPvStoreId == null) || (this.ProductAchPvStoreId?.Equals(other.ProductAchPvStoreId) == true)) &&
                ((this.InvoiceAdjustmentTitle == null && other.InvoiceAdjustmentTitle == null) || (this.InvoiceAdjustmentTitle?.Equals(other.InvoiceAdjustmentTitle) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.LocationApiId == null && other.LocationApiId == null) || (this.LocationApiId?.Equals(other.LocationApiId) == true)) &&
                ((this.BillingLocationApiId == null && other.BillingLocationApiId == null) || (this.BillingLocationApiId?.Equals(other.BillingLocationApiId) == true)) &&
                ((this.PortfolioId == null && other.PortfolioId == null) || (this.PortfolioId?.Equals(other.PortfolioId) == true)) &&
                ((this.PortfolioValidationRule == null && other.PortfolioValidationRule == null) || (this.PortfolioValidationRule?.Equals(other.PortfolioValidationRule) == true)) &&
                ((this.SubProcessor == null && other.SubProcessor == null) || (this.SubProcessor?.Equals(other.SubProcessor) == true)) &&
                ((this.Surcharge == null && other.Surcharge == null) || (this.Surcharge?.Equals(other.Surcharge) == true)) &&
                ((this.ProcessorData == null && other.ProcessorData == null) || (this.ProcessorData?.Equals(other.ProcessorData) == true)) &&
                ((this.VtClerkNumber == null && other.VtClerkNumber == null) || (this.VtClerkNumber?.Equals(other.VtClerkNumber) == true)) &&
                ((this.VtBillingPhone == null && other.VtBillingPhone == null) || (this.VtBillingPhone?.Equals(other.VtBillingPhone) == true)) &&
                ((this.VtEnableTip == null && other.VtEnableTip == null) || (this.VtEnableTip?.Equals(other.VtEnableTip) == true)) &&
                ((this.AchAllowDebit == null && other.AchAllowDebit == null) || (this.AchAllowDebit?.Equals(other.AchAllowDebit) == true)) &&
                ((this.AchAllowCredit == null && other.AchAllowCredit == null) || (this.AchAllowCredit?.Equals(other.AchAllowCredit) == true)) &&
                ((this.AchAllowRefund == null && other.AchAllowRefund == null) || (this.AchAllowRefund?.Equals(other.AchAllowRefund) == true)) &&
                ((this.VtCvv == null && other.VtCvv == null) || (this.VtCvv?.Equals(other.VtCvv) == true)) &&
                ((this.VtStreet == null && other.VtStreet == null) || (this.VtStreet?.Equals(other.VtStreet) == true)) &&
                ((this.VtZip == null && other.VtZip == null) || (this.VtZip?.Equals(other.VtZip) == true)) &&
                ((this.VtOrderNum == null && other.VtOrderNum == null) || (this.VtOrderNum?.Equals(other.VtOrderNum) == true)) &&
                ((this.VtEnable == null && other.VtEnable == null) || (this.VtEnable?.Equals(other.VtEnable) == true)) &&
                ((this.ReceiptShowContactName == null && other.ReceiptShowContactName == null) || (this.ReceiptShowContactName?.Equals(other.ReceiptShowContactName) == true)) &&
                ((this.DisplayAvs == null && other.DisplayAvs == null) || (this.DisplayAvs?.Equals(other.DisplayAvs) == true)) &&
                ((this.CardTypeVisa == null && other.CardTypeVisa == null) || (this.CardTypeVisa?.Equals(other.CardTypeVisa) == true)) &&
                ((this.CardTypeMc == null && other.CardTypeMc == null) || (this.CardTypeMc?.Equals(other.CardTypeMc) == true)) &&
                ((this.CardTypeDisc == null && other.CardTypeDisc == null) || (this.CardTypeDisc?.Equals(other.CardTypeDisc) == true)) &&
                ((this.CardTypeAmex == null && other.CardTypeAmex == null) || (this.CardTypeAmex?.Equals(other.CardTypeAmex) == true)) &&
                ((this.CardTypeDiners == null && other.CardTypeDiners == null) || (this.CardTypeDiners?.Equals(other.CardTypeDiners) == true)) &&
                ((this.CardTypeJcb == null && other.CardTypeJcb == null) || (this.CardTypeJcb?.Equals(other.CardTypeJcb) == true)) &&
                ((this.InvoiceLocation == null && other.InvoiceLocation == null) || (this.InvoiceLocation?.Equals(other.InvoiceLocation) == true)) &&
                ((this.AllowPartialAuthorization == null && other.AllowPartialAuthorization == null) || (this.AllowPartialAuthorization?.Equals(other.AllowPartialAuthorization) == true)) &&
                ((this.AllowRecurringPartialAuthorization == null && other.AllowRecurringPartialAuthorization == null) || (this.AllowRecurringPartialAuthorization?.Equals(other.AllowRecurringPartialAuthorization) == true)) &&
                ((this.AutoDeclineCvv == null && other.AutoDeclineCvv == null) || (this.AutoDeclineCvv?.Equals(other.AutoDeclineCvv) == true)) &&
                ((this.AutoDeclineStreet == null && other.AutoDeclineStreet == null) || (this.AutoDeclineStreet?.Equals(other.AutoDeclineStreet) == true)) &&
                ((this.AutoDeclineZip == null && other.AutoDeclineZip == null) || (this.AutoDeclineZip?.Equals(other.AutoDeclineZip) == true)) &&
                ((this.SplitPaymentsAllow == null && other.SplitPaymentsAllow == null) || (this.SplitPaymentsAllow?.Equals(other.SplitPaymentsAllow) == true)) &&
                ((this.VtShowCustomFields == null && other.VtShowCustomFields == null) || (this.VtShowCustomFields?.Equals(other.VtShowCustomFields) == true)) &&
                ((this.ReceiptShowCustomFields == null && other.ReceiptShowCustomFields == null) || (this.ReceiptShowCustomFields?.Equals(other.ReceiptShowCustomFields) == true)) &&
                ((this.VtOverrideSalesTaxAllowed == null && other.VtOverrideSalesTaxAllowed == null) || (this.VtOverrideSalesTaxAllowed?.Equals(other.VtOverrideSalesTaxAllowed) == true)) &&
                ((this.VtEnableSalesTax == null && other.VtEnableSalesTax == null) || (this.VtEnableSalesTax?.Equals(other.VtEnableSalesTax) == true)) &&
                ((this.VtRequireZip == null && other.VtRequireZip == null) || (this.VtRequireZip?.Equals(other.VtRequireZip) == true)) &&
                ((this.VtRequireStreet == null && other.VtRequireStreet == null) || (this.VtRequireStreet?.Equals(other.VtRequireStreet) == true)) &&
                ((this.AutoDeclineCavv == null && other.AutoDeclineCavv == null) || (this.AutoDeclineCavv?.Equals(other.AutoDeclineCavv) == true)) &&
                ((this.MerchantId == null && other.MerchantId == null) || (this.MerchantId?.Equals(other.MerchantId) == true)) &&
                ((this.ReceiptHeader == null && other.ReceiptHeader == null) || (this.ReceiptHeader?.Equals(other.ReceiptHeader) == true)) &&
                ((this.ReceiptFooter == null && other.ReceiptFooter == null) || (this.ReceiptFooter?.Equals(other.ReceiptFooter) == true)) &&
                ((this.ReceiptAddAccountAboveSignature == null && other.ReceiptAddAccountAboveSignature == null) || (this.ReceiptAddAccountAboveSignature?.Equals(other.ReceiptAddAccountAboveSignature) == true)) &&
                ((this.ReceiptAddRecurringAboveSignature == null && other.ReceiptAddRecurringAboveSignature == null) || (this.ReceiptAddRecurringAboveSignature?.Equals(other.ReceiptAddRecurringAboveSignature) == true)) &&
                ((this.ReceiptVtAboveSignature == null && other.ReceiptVtAboveSignature == null) || (this.ReceiptVtAboveSignature?.Equals(other.ReceiptVtAboveSignature) == true)) &&
                ((this.DefaultTransactionType == null && other.DefaultTransactionType == null) || (this.DefaultTransactionType?.Equals(other.DefaultTransactionType) == true)) &&
                ((this.Username == null && other.Username == null) || (this.Username?.Equals(other.Username) == true)) &&
                ((this.Password == null && other.Password == null) || (this.Password?.Equals(other.Password) == true)) &&
                ((this.CurrentBatch == null && other.CurrentBatch == null) || (this.CurrentBatch?.Equals(other.CurrentBatch) == true)) &&
                ((this.DupCheckPerBatch == null && other.DupCheckPerBatch == null) || (this.DupCheckPerBatch?.Equals(other.DupCheckPerBatch) == true)) &&
                ((this.AgentCode == null && other.AgentCode == null) || (this.AgentCode?.Equals(other.AgentCode) == true)) &&
                ((this.PaylinkAllow == null && other.PaylinkAllow == null) || (this.PaylinkAllow?.Equals(other.PaylinkAllow) == true)) &&
                ((this.QuickInvoiceAllow == null && other.QuickInvoiceAllow == null) || (this.QuickInvoiceAllow?.Equals(other.QuickInvoiceAllow) == true)) &&
                ((this.Level3Allow == null && other.Level3Allow == null) || (this.Level3Allow?.Equals(other.Level3Allow) == true)) &&
                ((this.PayfacEnable == null && other.PayfacEnable == null) || (this.PayfacEnable?.Equals(other.PayfacEnable) == true)) &&
                ((this.SalesOfficeId == null && other.SalesOfficeId == null) || (this.SalesOfficeId?.Equals(other.SalesOfficeId) == true)) &&
                ((this.HostedPaymentPageMaxAllowed == null && other.HostedPaymentPageMaxAllowed == null) || (this.HostedPaymentPageMaxAllowed?.Equals(other.HostedPaymentPageMaxAllowed) == true)) &&
                ((this.HostedPaymentPageAllow == null && other.HostedPaymentPageAllow == null) || (this.HostedPaymentPageAllow?.Equals(other.HostedPaymentPageAllow) == true)) &&
                ((this.SurchargeId == null && other.SurchargeId == null) || (this.SurchargeId?.Equals(other.SurchargeId) == true)) &&
                ((this.Level3Default == null && other.Level3Default == null) || (this.Level3Default?.Equals(other.Level3Default) == true)) &&
                ((this.CauSubscribeTypeId == null && other.CauSubscribeTypeId == null) || (this.CauSubscribeTypeId?.Equals(other.CauSubscribeTypeId) == true)) &&
                ((this.CauAccountNumber == null && other.CauAccountNumber == null) || (this.CauAccountNumber?.Equals(other.CauAccountNumber) == true)) &&
                ((this.LocationBillingAccountId == null && other.LocationBillingAccountId == null) || (this.LocationBillingAccountId?.Equals(other.LocationBillingAccountId) == true)) &&
                ((this.ProductBillingGroupId == null && other.ProductBillingGroupId == null) || (this.ProductBillingGroupId?.Equals(other.ProductBillingGroupId) == true)) &&
                ((this.AccountNumber == null && other.AccountNumber == null) || (this.AccountNumber?.Equals(other.AccountNumber) == true)) &&
                ((this.RunAvsOnAccountvaultCreate == null && other.RunAvsOnAccountvaultCreate == null) || (this.RunAvsOnAccountvaultCreate?.Equals(other.RunAvsOnAccountvaultCreate) == true)) &&
                ((this.AccountvaultExpireNotificationEmailEnable == null && other.AccountvaultExpireNotificationEmailEnable == null) || (this.AccountvaultExpireNotificationEmailEnable?.Equals(other.AccountvaultExpireNotificationEmailEnable) == true)) &&
                ((this.DebitAllowVoid == null && other.DebitAllowVoid == null) || (this.DebitAllowVoid?.Equals(other.DebitAllowVoid) == true)) &&
                ((this.QuickInvoiceTextToPay == null && other.QuickInvoiceTextToPay == null) || (this.QuickInvoiceTextToPay?.Equals(other.QuickInvoiceTextToPay) == true)) &&
                ((this.AuthenticationCode == null && other.AuthenticationCode == null) || (this.AuthenticationCode?.Equals(other.AuthenticationCode) == true)) &&
                ((this.SmsEnable == null && other.SmsEnable == null) || (this.SmsEnable?.Equals(other.SmsEnable) == true)) &&
                ((this.VtShowCurrency == null && other.VtShowCurrency == null) || (this.VtShowCurrency?.Equals(other.VtShowCurrency) == true)) &&
                ((this.ReceiptShowCurrency == null && other.ReceiptShowCurrency == null) || (this.ReceiptShowCurrency?.Equals(other.ReceiptShowCurrency) == true)) &&
                ((this.AllowBlindRefund == null && other.AllowBlindRefund == null) || (this.AllowBlindRefund?.Equals(other.AllowBlindRefund) == true)) &&
                ((this.VtShowCompanyName == null && other.VtShowCompanyName == null) || (this.VtShowCompanyName?.Equals(other.VtShowCompanyName) == true)) &&
                ((this.ReceiptShowCompanyName == null && other.ReceiptShowCompanyName == null) || (this.ReceiptShowCompanyName?.Equals(other.ReceiptShowCompanyName) == true)) &&
                ((this.BankFundedOnly == null && other.BankFundedOnly == null) || (this.BankFundedOnly?.Equals(other.BankFundedOnly) == true)) &&
                ((this.RequireCvvOnKeyedCnp == null && other.RequireCvvOnKeyedCnp == null) || (this.RequireCvvOnKeyedCnp?.Equals(other.RequireCvvOnKeyedCnp) == true)) &&
                ((this.RequireCvvOnTokenizedCnp == null && other.RequireCvvOnTokenizedCnp == null) || (this.RequireCvvOnTokenizedCnp?.Equals(other.RequireCvvOnTokenizedCnp) == true)) &&
                ((this.ShowSecondaryAmount == null && other.ShowSecondaryAmount == null) || (this.ShowSecondaryAmount?.Equals(other.ShowSecondaryAmount) == true)) &&
                ((this.AllowSecondaryAmount == null && other.AllowSecondaryAmount == null) || (this.AllowSecondaryAmount?.Equals(other.AllowSecondaryAmount) == true)) &&
                ((this.ShowGooglePay == null && other.ShowGooglePay == null) || (this.ShowGooglePay?.Equals(other.ShowGooglePay) == true)) &&
                ((this.ShowApplePay == null && other.ShowApplePay == null) || (this.ShowApplePay?.Equals(other.ShowApplePay) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.ReceiptLogo == null && other.ReceiptLogo == null) || (this.ReceiptLogo?.Equals(other.ReceiptLogo) == true)) &&
                ((this.Active == null && other.Active == null) || (this.Active?.Equals(other.Active) == true)) &&
                ((this.Tz == null && other.Tz == null) || (this.Tz?.Equals(other.Tz) == true)) &&
                ((this.CurrencyCode == null && other.CurrencyCode == null) || (this.CurrencyCode?.Equals(other.CurrencyCode) == true)) &&
                ((this.CurrentStan == null && other.CurrentStan == null) || (this.CurrentStan?.Equals(other.CurrentStan) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.ModifiedTs == null && other.ModifiedTs == null) || (this.ModifiedTs?.Equals(other.ModifiedTs) == true)) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true)) &&
                ((this.ModifiedUserId == null && other.ModifiedUserId == null) || (this.ModifiedUserId?.Equals(other.ModifiedUserId) == true)) &&
                ((this.ProductTransactionApiId == null && other.ProductTransactionApiId == null) || (this.ProductTransactionApiId?.Equals(other.ProductTransactionApiId) == true)) &&
                ((this.TransactionAmountNotificationThreshold == null && other.TransactionAmountNotificationThreshold == null) || (this.TransactionAmountNotificationThreshold?.Equals(other.TransactionAmountNotificationThreshold) == true)) &&
                ((this.IsSecondaryAmountAllowed == null && other.IsSecondaryAmountAllowed == null) || (this.IsSecondaryAmountAllowed?.Equals(other.IsSecondaryAmountAllowed) == true)) &&
                ((this.BatchRiskConfig == null && other.BatchRiskConfig == null) || (this.BatchRiskConfig?.Equals(other.BatchRiskConfig) == true)) &&
                ((this.FortisId == null && other.FortisId == null) || (this.FortisId?.Equals(other.FortisId) == true)) &&
                ((this.ProductBillingGroupCode == null && other.ProductBillingGroupCode == null) || (this.ProductBillingGroupCode?.Equals(other.ProductBillingGroupCode) == true)) &&
                ((this.CauSubscribeTypeCode == null && other.CauSubscribeTypeCode == null) || (this.CauSubscribeTypeCode?.Equals(other.CauSubscribeTypeCode) == true)) &&
                ((this.MerchantCode == null && other.MerchantCode == null) || (this.MerchantCode?.Equals(other.MerchantCode) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ProcessorVersion = {(this.ProcessorVersion == null ? "null" : this.ProcessorVersion)}");
            toStringOutput.Add($"this.IndustryType = {(this.IndustryType == null ? "null" : this.IndustryType.ToString())}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
            toStringOutput.Add($"this.PaymentMethod = {this.PaymentMethod}");
            toStringOutput.Add($"this.Processor = {(this.Processor == null ? "null" : this.Processor.ToString())}");
            toStringOutput.Add($"this.Mcc = {(this.Mcc == null ? "null" : this.Mcc)}");
            toStringOutput.Add($"this.TaxSurchargeConfig = {(this.TaxSurchargeConfig == null ? "null" : this.TaxSurchargeConfig.ToString())}");
            toStringOutput.Add($"this.TerminalId = {(this.TerminalId == null ? "null" : this.TerminalId)}");
            toStringOutput.Add($"this.Partner = {(this.Partner == null ? "null" : this.Partner.ToString())}");
            toStringOutput.Add($"this.ProductAchPvStoreId = {(this.ProductAchPvStoreId == null ? "null" : this.ProductAchPvStoreId)}");
            toStringOutput.Add($"this.InvoiceAdjustmentTitle = {(this.InvoiceAdjustmentTitle == null ? "null" : this.InvoiceAdjustmentTitle)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.LocationApiId = {(this.LocationApiId == null ? "null" : this.LocationApiId)}");
            toStringOutput.Add($"this.BillingLocationApiId = {(this.BillingLocationApiId == null ? "null" : this.BillingLocationApiId)}");
            toStringOutput.Add($"this.PortfolioId = {(this.PortfolioId == null ? "null" : this.PortfolioId)}");
            toStringOutput.Add($"this.PortfolioValidationRule = {(this.PortfolioValidationRule == null ? "null" : this.PortfolioValidationRule)}");
            toStringOutput.Add($"this.SubProcessor = {(this.SubProcessor == null ? "null" : this.SubProcessor)}");
            toStringOutput.Add($"Surcharge = {(this.Surcharge == null ? "null" : this.Surcharge.ToString())}");
            toStringOutput.Add($"ProcessorData = {(this.ProcessorData == null ? "null" : this.ProcessorData.ToString())}");
            toStringOutput.Add($"this.VtClerkNumber = {(this.VtClerkNumber == null ? "null" : this.VtClerkNumber.ToString())}");
            toStringOutput.Add($"this.VtBillingPhone = {(this.VtBillingPhone == null ? "null" : this.VtBillingPhone.ToString())}");
            toStringOutput.Add($"this.VtEnableTip = {(this.VtEnableTip == null ? "null" : this.VtEnableTip.ToString())}");
            toStringOutput.Add($"this.AchAllowDebit = {(this.AchAllowDebit == null ? "null" : this.AchAllowDebit.ToString())}");
            toStringOutput.Add($"this.AchAllowCredit = {(this.AchAllowCredit == null ? "null" : this.AchAllowCredit.ToString())}");
            toStringOutput.Add($"this.AchAllowRefund = {(this.AchAllowRefund == null ? "null" : this.AchAllowRefund.ToString())}");
            toStringOutput.Add($"this.VtCvv = {(this.VtCvv == null ? "null" : this.VtCvv.ToString())}");
            toStringOutput.Add($"this.VtStreet = {(this.VtStreet == null ? "null" : this.VtStreet.ToString())}");
            toStringOutput.Add($"this.VtZip = {(this.VtZip == null ? "null" : this.VtZip.ToString())}");
            toStringOutput.Add($"this.VtOrderNum = {(this.VtOrderNum == null ? "null" : this.VtOrderNum.ToString())}");
            toStringOutput.Add($"this.VtEnable = {(this.VtEnable == null ? "null" : this.VtEnable.ToString())}");
            toStringOutput.Add($"this.ReceiptShowContactName = {(this.ReceiptShowContactName == null ? "null" : this.ReceiptShowContactName.ToString())}");
            toStringOutput.Add($"this.DisplayAvs = {(this.DisplayAvs == null ? "null" : this.DisplayAvs.ToString())}");
            toStringOutput.Add($"this.CardTypeVisa = {(this.CardTypeVisa == null ? "null" : this.CardTypeVisa.ToString())}");
            toStringOutput.Add($"this.CardTypeMc = {(this.CardTypeMc == null ? "null" : this.CardTypeMc.ToString())}");
            toStringOutput.Add($"this.CardTypeDisc = {(this.CardTypeDisc == null ? "null" : this.CardTypeDisc.ToString())}");
            toStringOutput.Add($"this.CardTypeAmex = {(this.CardTypeAmex == null ? "null" : this.CardTypeAmex.ToString())}");
            toStringOutput.Add($"this.CardTypeDiners = {(this.CardTypeDiners == null ? "null" : this.CardTypeDiners.ToString())}");
            toStringOutput.Add($"this.CardTypeJcb = {(this.CardTypeJcb == null ? "null" : this.CardTypeJcb.ToString())}");
            toStringOutput.Add($"this.InvoiceLocation = {(this.InvoiceLocation == null ? "null" : this.InvoiceLocation.ToString())}");
            toStringOutput.Add($"this.AllowPartialAuthorization = {(this.AllowPartialAuthorization == null ? "null" : this.AllowPartialAuthorization.ToString())}");
            toStringOutput.Add($"this.AllowRecurringPartialAuthorization = {(this.AllowRecurringPartialAuthorization == null ? "null" : this.AllowRecurringPartialAuthorization.ToString())}");
            toStringOutput.Add($"this.AutoDeclineCvv = {(this.AutoDeclineCvv == null ? "null" : this.AutoDeclineCvv.ToString())}");
            toStringOutput.Add($"this.AutoDeclineStreet = {(this.AutoDeclineStreet == null ? "null" : this.AutoDeclineStreet.ToString())}");
            toStringOutput.Add($"this.AutoDeclineZip = {(this.AutoDeclineZip == null ? "null" : this.AutoDeclineZip.ToString())}");
            toStringOutput.Add($"this.SplitPaymentsAllow = {(this.SplitPaymentsAllow == null ? "null" : this.SplitPaymentsAllow.ToString())}");
            toStringOutput.Add($"this.VtShowCustomFields = {(this.VtShowCustomFields == null ? "null" : this.VtShowCustomFields.ToString())}");
            toStringOutput.Add($"this.ReceiptShowCustomFields = {(this.ReceiptShowCustomFields == null ? "null" : this.ReceiptShowCustomFields.ToString())}");
            toStringOutput.Add($"this.VtOverrideSalesTaxAllowed = {(this.VtOverrideSalesTaxAllowed == null ? "null" : this.VtOverrideSalesTaxAllowed.ToString())}");
            toStringOutput.Add($"this.VtEnableSalesTax = {(this.VtEnableSalesTax == null ? "null" : this.VtEnableSalesTax.ToString())}");
            toStringOutput.Add($"this.VtRequireZip = {(this.VtRequireZip == null ? "null" : this.VtRequireZip.ToString())}");
            toStringOutput.Add($"this.VtRequireStreet = {(this.VtRequireStreet == null ? "null" : this.VtRequireStreet.ToString())}");
            toStringOutput.Add($"this.AutoDeclineCavv = {(this.AutoDeclineCavv == null ? "null" : this.AutoDeclineCavv.ToString())}");
            toStringOutput.Add($"this.MerchantId = {(this.MerchantId == null ? "null" : this.MerchantId)}");
            toStringOutput.Add($"this.ReceiptHeader = {(this.ReceiptHeader == null ? "null" : this.ReceiptHeader)}");
            toStringOutput.Add($"this.ReceiptFooter = {(this.ReceiptFooter == null ? "null" : this.ReceiptFooter)}");
            toStringOutput.Add($"this.ReceiptAddAccountAboveSignature = {(this.ReceiptAddAccountAboveSignature == null ? "null" : this.ReceiptAddAccountAboveSignature)}");
            toStringOutput.Add($"this.ReceiptAddRecurringAboveSignature = {(this.ReceiptAddRecurringAboveSignature == null ? "null" : this.ReceiptAddRecurringAboveSignature)}");
            toStringOutput.Add($"this.ReceiptVtAboveSignature = {(this.ReceiptVtAboveSignature == null ? "null" : this.ReceiptVtAboveSignature)}");
            toStringOutput.Add($"this.DefaultTransactionType = {(this.DefaultTransactionType == null ? "null" : this.DefaultTransactionType.ToString())}");
            toStringOutput.Add($"this.Username = {(this.Username == null ? "null" : this.Username)}");
            toStringOutput.Add($"this.Password = {(this.Password == null ? "null" : this.Password)}");
            toStringOutput.Add($"this.CurrentBatch = {(this.CurrentBatch == null ? "null" : this.CurrentBatch.ToString())}");
            toStringOutput.Add($"this.DupCheckPerBatch = {(this.DupCheckPerBatch == null ? "null" : this.DupCheckPerBatch)}");
            toStringOutput.Add($"this.AgentCode = {(this.AgentCode == null ? "null" : this.AgentCode)}");
            toStringOutput.Add($"this.PaylinkAllow = {(this.PaylinkAllow == null ? "null" : this.PaylinkAllow.ToString())}");
            toStringOutput.Add($"this.QuickInvoiceAllow = {(this.QuickInvoiceAllow == null ? "null" : this.QuickInvoiceAllow.ToString())}");
            toStringOutput.Add($"this.Level3Allow = {(this.Level3Allow == null ? "null" : this.Level3Allow.ToString())}");
            toStringOutput.Add($"this.PayfacEnable = {(this.PayfacEnable == null ? "null" : this.PayfacEnable.ToString())}");
            toStringOutput.Add($"this.SalesOfficeId = {(this.SalesOfficeId == null ? "null" : this.SalesOfficeId)}");
            toStringOutput.Add($"this.HostedPaymentPageMaxAllowed = {(this.HostedPaymentPageMaxAllowed == null ? "null" : this.HostedPaymentPageMaxAllowed.ToString())}");
            toStringOutput.Add($"this.HostedPaymentPageAllow = {(this.HostedPaymentPageAllow == null ? "null" : this.HostedPaymentPageAllow.ToString())}");
            toStringOutput.Add($"this.SurchargeId = {(this.SurchargeId == null ? "null" : this.SurchargeId)}");
            toStringOutput.Add($"Level3Default = {(this.Level3Default == null ? "null" : this.Level3Default.ToString())}");
            toStringOutput.Add($"this.CauSubscribeTypeId = {(this.CauSubscribeTypeId == null ? "null" : this.CauSubscribeTypeId.ToString())}");
            toStringOutput.Add($"this.CauAccountNumber = {(this.CauAccountNumber == null ? "null" : this.CauAccountNumber)}");
            toStringOutput.Add($"this.LocationBillingAccountId = {(this.LocationBillingAccountId == null ? "null" : this.LocationBillingAccountId)}");
            toStringOutput.Add($"this.ProductBillingGroupId = {(this.ProductBillingGroupId == null ? "null" : this.ProductBillingGroupId)}");
            toStringOutput.Add($"this.AccountNumber = {(this.AccountNumber == null ? "null" : this.AccountNumber)}");
            toStringOutput.Add($"this.RunAvsOnAccountvaultCreate = {(this.RunAvsOnAccountvaultCreate == null ? "null" : this.RunAvsOnAccountvaultCreate.ToString())}");
            toStringOutput.Add($"this.AccountvaultExpireNotificationEmailEnable = {(this.AccountvaultExpireNotificationEmailEnable == null ? "null" : this.AccountvaultExpireNotificationEmailEnable.ToString())}");
            toStringOutput.Add($"this.DebitAllowVoid = {(this.DebitAllowVoid == null ? "null" : this.DebitAllowVoid.ToString())}");
            toStringOutput.Add($"this.QuickInvoiceTextToPay = {(this.QuickInvoiceTextToPay == null ? "null" : this.QuickInvoiceTextToPay.ToString())}");
            toStringOutput.Add($"this.AuthenticationCode = {(this.AuthenticationCode == null ? "null" : this.AuthenticationCode)}");
            toStringOutput.Add($"this.SmsEnable = {(this.SmsEnable == null ? "null" : this.SmsEnable.ToString())}");
            toStringOutput.Add($"this.VtShowCurrency = {(this.VtShowCurrency == null ? "null" : this.VtShowCurrency.ToString())}");
            toStringOutput.Add($"this.ReceiptShowCurrency = {(this.ReceiptShowCurrency == null ? "null" : this.ReceiptShowCurrency.ToString())}");
            toStringOutput.Add($"this.AllowBlindRefund = {(this.AllowBlindRefund == null ? "null" : this.AllowBlindRefund.ToString())}");
            toStringOutput.Add($"this.VtShowCompanyName = {(this.VtShowCompanyName == null ? "null" : this.VtShowCompanyName.ToString())}");
            toStringOutput.Add($"this.ReceiptShowCompanyName = {(this.ReceiptShowCompanyName == null ? "null" : this.ReceiptShowCompanyName.ToString())}");
            toStringOutput.Add($"this.BankFundedOnly = {(this.BankFundedOnly == null ? "null" : this.BankFundedOnly.ToString())}");
            toStringOutput.Add($"this.RequireCvvOnKeyedCnp = {(this.RequireCvvOnKeyedCnp == null ? "null" : this.RequireCvvOnKeyedCnp.ToString())}");
            toStringOutput.Add($"this.RequireCvvOnTokenizedCnp = {(this.RequireCvvOnTokenizedCnp == null ? "null" : this.RequireCvvOnTokenizedCnp.ToString())}");
            toStringOutput.Add($"this.ShowSecondaryAmount = {(this.ShowSecondaryAmount == null ? "null" : this.ShowSecondaryAmount.ToString())}");
            toStringOutput.Add($"this.AllowSecondaryAmount = {(this.AllowSecondaryAmount == null ? "null" : this.AllowSecondaryAmount.ToString())}");
            toStringOutput.Add($"this.ShowGooglePay = {(this.ShowGooglePay == null ? "null" : this.ShowGooglePay.ToString())}");
            toStringOutput.Add($"this.ShowApplePay = {(this.ShowApplePay == null ? "null" : this.ShowApplePay.ToString())}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.ReceiptLogo = {(this.ReceiptLogo == null ? "null" : this.ReceiptLogo)}");
            toStringOutput.Add($"this.Active = {(this.Active == null ? "null" : this.Active.ToString())}");
            toStringOutput.Add($"this.Tz = {(this.Tz == null ? "null" : this.Tz)}");
            toStringOutput.Add($"this.CurrencyCode = {(this.CurrencyCode == null ? "null" : this.CurrencyCode.ToString())}");
            toStringOutput.Add($"this.CurrentStan = {(this.CurrentStan == null ? "null" : this.CurrentStan.ToString())}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.ModifiedTs = {(this.ModifiedTs == null ? "null" : this.ModifiedTs.ToString())}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.ModifiedUserId = {(this.ModifiedUserId == null ? "null" : this.ModifiedUserId)}");
            toStringOutput.Add($"this.ProductTransactionApiId = {(this.ProductTransactionApiId == null ? "null" : this.ProductTransactionApiId)}");
            toStringOutput.Add($"this.TransactionAmountNotificationThreshold = {(this.TransactionAmountNotificationThreshold == null ? "null" : this.TransactionAmountNotificationThreshold.ToString())}");
            toStringOutput.Add($"this.IsSecondaryAmountAllowed = {(this.IsSecondaryAmountAllowed == null ? "null" : this.IsSecondaryAmountAllowed.ToString())}");
            toStringOutput.Add($"BatchRiskConfig = {(this.BatchRiskConfig == null ? "null" : this.BatchRiskConfig.ToString())}");
            toStringOutput.Add($"this.FortisId = {(this.FortisId == null ? "null" : this.FortisId)}");
            toStringOutput.Add($"this.ProductBillingGroupCode = {(this.ProductBillingGroupCode == null ? "null" : this.ProductBillingGroupCode)}");
            toStringOutput.Add($"this.CauSubscribeTypeCode = {(this.CauSubscribeTypeCode == null ? "null" : this.CauSubscribeTypeCode.ToString())}");
            toStringOutput.Add($"this.MerchantCode = {(this.MerchantCode == null ? "null" : this.MerchantCode)}");

            base.ToString(toStringOutput);
        }
    }
}