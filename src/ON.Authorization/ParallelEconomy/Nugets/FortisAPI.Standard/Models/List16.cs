// <copyright file="List16.cs" company="APIMatic">
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
    /// List16.
    /// </summary>
    public class List16 : BaseModel
    {
        private string checkinDate;
        private string checkoutDate;
        private string clerkNumber;
        private string contactApiId;
        private string contactId;
        private string customerId;
        private string description;
        private Models.IiasIndEnum? iiasInd;
        private string imageFront;
        private string imageBack;
        private int? installmentNumber;
        private int? installmentCount;
        private string locationApiId;
        private string locationId;
        private string productTransactionId;
        private string notificationEmailAddress;
        private string orderNumber;
        private string poNumber;
        private string quickInvoiceId;
        private int? recurringNumber;
        private string roomNum;
        private int? roomRate;
        private string saveAccountTitle;
        private int? subtotalAmount;
        private int? surchargeAmount;
        private int? tax;
        private int? tipAmount;
        private int? transactionAmount;
        private int? secondaryAmount;
        private string transactionApiId;
        private string transactionC1;
        private string transactionC2;
        private string transactionC3;
        private string terminalId;
        private string accountHolderName;
        private string accountType;
        private string tokenApiId;
        private string tokenId;
        private string achIdentifier;
        private Models.AchSecCode1Enum? achSecCode;
        private int? authAmount;
        private string authCode;
        private Models.AvsEnum? avs;
        private string avsEnhanced;
        private string checkNumber;
        private string customerIp;
        private string cvvResponse;
        private Models.EntryModeIdEnum? entryModeId;
        private Models.EmvReceiptData emvReceiptData;
        private string firstSix;
        private string lastFour;
        private string terminalSerialNumber;
        private string transactionSettlementStatus;
        private string chargeBackDate;
        private string par;
        private Models.ReasonCodeId1Enum? reasonCodeId;
        private string recurringId;
        private string settleDate;
        private Models.StatusCode17Enum? statusCode;
        private string transactionBatchId;
        private Models.TypeIdEnum? typeId;
        private string verbiage;
        private string voidDate;
        private string batch;
        private string responseMessage;
        private string returnDate;
        private Models.TrxSourceIdEnum? trxSourceId;
        private string routingNumber;
        private Models.TrxSourceCodeEnum? trxSourceCode;
        private string paylinkId;
        private double? currencyCode;
        private string createdUserId;
        private string transactionCode;
        private string effectiveDate;
        private string notificationPhone;
        private string cavvResult;
        private string recurringFlag;
        private int? installmentTotal;
        private int? installmentCounter;
        private string accountVaultId;
        private string stan;
        private string currency;
        private string cardBin;
        private string developerCompanyId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "checkin_date", false },
            { "checkout_date", false },
            { "clerk_number", false },
            { "contact_api_id", false },
            { "contact_id", false },
            { "customer_id", false },
            { "description", false },
            { "iias_ind", false },
            { "image_front", false },
            { "image_back", false },
            { "installment_number", false },
            { "installment_count", false },
            { "location_api_id", false },
            { "location_id", false },
            { "product_transaction_id", false },
            { "notification_email_address", false },
            { "order_number", false },
            { "po_number", false },
            { "quick_invoice_id", false },
            { "recurring_number", false },
            { "room_num", false },
            { "room_rate", false },
            { "save_account_title", false },
            { "subtotal_amount", false },
            { "surcharge_amount", false },
            { "tax", false },
            { "tip_amount", false },
            { "transaction_amount", false },
            { "secondary_amount", false },
            { "transaction_api_id", false },
            { "transaction_c1", false },
            { "transaction_c2", false },
            { "transaction_c3", false },
            { "terminal_id", false },
            { "account_holder_name", false },
            { "account_type", false },
            { "token_api_id", false },
            { "token_id", false },
            { "ach_identifier", false },
            { "ach_sec_code", false },
            { "auth_amount", false },
            { "auth_code", false },
            { "avs", false },
            { "avs_enhanced", false },
            { "check_number", false },
            { "customer_ip", false },
            { "cvv_response", false },
            { "entry_mode_id", false },
            { "emv_receipt_data", false },
            { "first_six", false },
            { "last_four", false },
            { "terminal_serial_number", false },
            { "transaction_settlement_status", false },
            { "charge_back_date", false },
            { "par", false },
            { "reason_code_id", false },
            { "recurring_id", false },
            { "settle_date", false },
            { "status_code", false },
            { "transaction_batch_id", false },
            { "type_id", false },
            { "verbiage", false },
            { "void_date", false },
            { "batch", false },
            { "response_message", false },
            { "return_date", false },
            { "trx_source_id", false },
            { "routing_number", false },
            { "trx_source_code", false },
            { "paylink_id", false },
            { "currency_code", true },
            { "created_user_id", false },
            { "transaction_code", false },
            { "effective_date", false },
            { "notification_phone", false },
            { "cavv_result", false },
            { "recurring_flag", false },
            { "installment_total", false },
            { "installment_counter", false },
            { "account_vault_id", false },
            { "stan", false },
            { "currency", false },
            { "card_bin", false },
            { "developer_company_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="List16"/> class.
        /// </summary>
        public List16()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="List16"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="paymentMethod">payment_method.</param>
        /// <param name="modifiedUserId">modified_user_id.</param>
        /// <param name="hostedPaymentPageId">hosted_payment_page_id.</param>
        /// <param name="additionalAmounts">additional_amounts.</param>
        /// <param name="billingAddress">billing_address.</param>
        /// <param name="checkinDate">checkin_date.</param>
        /// <param name="checkoutDate">checkout_date.</param>
        /// <param name="clerkNumber">clerk_number.</param>
        /// <param name="contactApiId">contact_api_id.</param>
        /// <param name="contactId">contact_id.</param>
        /// <param name="customData">custom_data.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="description">description.</param>
        /// <param name="iiasInd">iias_ind.</param>
        /// <param name="imageFront">image_front.</param>
        /// <param name="imageBack">image_back.</param>
        /// <param name="installment">installment.</param>
        /// <param name="installmentNumber">installment_number.</param>
        /// <param name="installmentCount">installment_count.</param>
        /// <param name="locationApiId">location_api_id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="productTransactionId">product_transaction_id.</param>
        /// <param name="advanceDeposit">advance_deposit.</param>
        /// <param name="noShow">no_show.</param>
        /// <param name="notificationEmailAddress">notification_email_address.</param>
        /// <param name="orderNumber">order_number.</param>
        /// <param name="poNumber">po_number.</param>
        /// <param name="quickInvoiceId">quick_invoice_id.</param>
        /// <param name="recurring">recurring.</param>
        /// <param name="recurringNumber">recurring_number.</param>
        /// <param name="roomNum">room_num.</param>
        /// <param name="roomRate">room_rate.</param>
        /// <param name="saveAccount">save_account.</param>
        /// <param name="saveAccountTitle">save_account_title.</param>
        /// <param name="subtotalAmount">subtotal_amount.</param>
        /// <param name="surchargeAmount">surcharge_amount.</param>
        /// <param name="tags">tags.</param>
        /// <param name="tax">tax.</param>
        /// <param name="tipAmount">tip_amount.</param>
        /// <param name="transactionAmount">transaction_amount.</param>
        /// <param name="secondaryAmount">secondary_amount.</param>
        /// <param name="transactionApiId">transaction_api_id.</param>
        /// <param name="transactionC1">transaction_c1.</param>
        /// <param name="transactionC2">transaction_c2.</param>
        /// <param name="transactionC3">transaction_c3.</param>
        /// <param name="bankFundedOnlyOverride">bank_funded_only_override.</param>
        /// <param name="allowPartialAuthorizationOverride">allow_partial_authorization_override.</param>
        /// <param name="autoDeclineCvvOverride">auto_decline_cvv_override.</param>
        /// <param name="autoDeclineStreetOverride">auto_decline_street_override.</param>
        /// <param name="autoDeclineZipOverride">auto_decline_zip_override.</param>
        /// <param name="terminalId">terminal_id.</param>
        /// <param name="accountHolderName">account_holder_name.</param>
        /// <param name="accountType">account_type.</param>
        /// <param name="tokenApiId">token_api_id.</param>
        /// <param name="tokenId">token_id.</param>
        /// <param name="achIdentifier">ach_identifier.</param>
        /// <param name="achSecCode">ach_sec_code.</param>
        /// <param name="authAmount">auth_amount.</param>
        /// <param name="authCode">auth_code.</param>
        /// <param name="avs">avs.</param>
        /// <param name="avsEnhanced">avs_enhanced.</param>
        /// <param name="cardholderPresent">cardholder_present.</param>
        /// <param name="cardPresent">card_present.</param>
        /// <param name="checkNumber">check_number.</param>
        /// <param name="customerIp">customer_ip.</param>
        /// <param name="cvvResponse">cvv_response.</param>
        /// <param name="entryModeId">entry_mode_id.</param>
        /// <param name="emvReceiptData">emv_receipt_data.</param>
        /// <param name="firstSix">first_six.</param>
        /// <param name="lastFour">last_four.</param>
        /// <param name="terminalSerialNumber">terminal_serial_number.</param>
        /// <param name="transactionSettlementStatus">transaction_settlement_status.</param>
        /// <param name="chargeBackDate">charge_back_date.</param>
        /// <param name="isRecurring">is_recurring.</param>
        /// <param name="notificationEmailSent">notification_email_sent.</param>
        /// <param name="par">par.</param>
        /// <param name="reasonCodeId">reason_code_id.</param>
        /// <param name="recurringId">recurring_id.</param>
        /// <param name="settleDate">settle_date.</param>
        /// <param name="statusCode">status_code.</param>
        /// <param name="transactionBatchId">transaction_batch_id.</param>
        /// <param name="typeId">type_id.</param>
        /// <param name="verbiage">verbiage.</param>
        /// <param name="voidDate">void_date.</param>
        /// <param name="batch">batch.</param>
        /// <param name="termsAgree">terms_agree.</param>
        /// <param name="responseMessage">response_message.</param>
        /// <param name="returnDate">return_date.</param>
        /// <param name="trxSourceId">trx_source_id.</param>
        /// <param name="routingNumber">routing_number.</param>
        /// <param name="trxSourceCode">trx_source_code.</param>
        /// <param name="paylinkId">paylink_id.</param>
        /// <param name="currencyCode">currency_code.</param>
        /// <param name="isAccountvault">is_accountvault.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="transactionCode">transaction_code.</param>
        /// <param name="effectiveDate">effective_date.</param>
        /// <param name="notificationPhone">notification_phone.</param>
        /// <param name="cavvResult">cavv_result.</param>
        /// <param name="recurringFlag">recurring_flag.</param>
        /// <param name="isToken">is_token.</param>
        /// <param name="installmentTotal">installment_total.</param>
        /// <param name="installmentCounter">installment_counter.</param>
        /// <param name="accountVaultId">account_vault_id.</param>
        /// <param name="stan">stan.</param>
        /// <param name="currency">currency.</param>
        /// <param name="cardBin">card_bin.</param>
        /// <param name="accountVault">account_vault.</param>
        /// <param name="quickInvoice">quick_invoice.</param>
        /// <param name="logEmails">log_emails.</param>
        /// <param name="isVoidable">is_voidable.</param>
        /// <param name="isReversible">is_reversible.</param>
        /// <param name="isRefundable">is_refundable.</param>
        /// <param name="isCompletable">is_completable.</param>
        /// <param name="isSettled">is_settled.</param>
        /// <param name="createdUser">created_user.</param>
        /// <param name="location">location.</param>
        /// <param name="contact">contact.</param>
        /// <param name="changelogs">changelogs.</param>
        /// <param name="productTransaction">product_transaction.</param>
        /// <param name="allTags">all_tags.</param>
        /// <param name="tagTransactions">tagTransactions.</param>
        /// <param name="declinedRecurringNotification">declined_recurring_notification.</param>
        /// <param name="paymentRecurringNotification">payment_recurring_notification.</param>
        /// <param name="developerCompany">developer_company.</param>
        /// <param name="terminal">terminal.</param>
        /// <param name="hostedPaymentPage">hosted_payment_page.</param>
        /// <param name="transactionLevel3">transaction_level3.</param>
        /// <param name="developerCompanyId">developer_company_id.</param>
        /// <param name="transactionHistories">transaction_histories.</param>
        /// <param name="surchargeTransaction">surcharge_transaction.</param>
        /// <param name="surcharge">surcharge.</param>
        /// <param name="signature">signature.</param>
        /// <param name="reasonCode">reason_code.</param>
        /// <param name="type">type.</param>
        /// <param name="status">status.</param>
        /// <param name="transactionBatch">transaction_batch.</param>
        /// <param name="transactionSplits">transaction_splits.</param>
        /// <param name="postbackLogs">postback_logs.</param>
        /// <param name="currencyType">currency_type.</param>
        /// <param name="transactionReferences">transaction_references.</param>
        public List16(
            string id,
            int createdTs,
            int modifiedTs,
            Models.PaymentMethod6Enum paymentMethod,
            string modifiedUserId,
            string hostedPaymentPageId,
            List<Models.AdditionalAmount> additionalAmounts = null,
            Models.BillingAddress billingAddress = null,
            string checkinDate = null,
            string checkoutDate = null,
            string clerkNumber = null,
            string contactApiId = null,
            string contactId = null,
            object customData = null,
            string customerId = null,
            string description = null,
            Models.IiasIndEnum? iiasInd = null,
            string imageFront = null,
            string imageBack = null,
            bool? installment = null,
            int? installmentNumber = null,
            int? installmentCount = null,
            string locationApiId = null,
            string locationId = null,
            string productTransactionId = null,
            bool? advanceDeposit = null,
            bool? noShow = null,
            string notificationEmailAddress = null,
            string orderNumber = null,
            string poNumber = null,
            string quickInvoiceId = null,
            Models.Recurring3 recurring = null,
            int? recurringNumber = null,
            string roomNum = null,
            int? roomRate = null,
            bool? saveAccount = null,
            string saveAccountTitle = null,
            int? subtotalAmount = null,
            int? surchargeAmount = null,
            List<Models.Tag> tags = null,
            int? tax = null,
            int? tipAmount = null,
            int? transactionAmount = null,
            int? secondaryAmount = null,
            string transactionApiId = null,
            string transactionC1 = null,
            string transactionC2 = null,
            string transactionC3 = null,
            bool? bankFundedOnlyOverride = null,
            bool? allowPartialAuthorizationOverride = null,
            bool? autoDeclineCvvOverride = null,
            bool? autoDeclineStreetOverride = null,
            bool? autoDeclineZipOverride = null,
            string terminalId = null,
            string accountHolderName = null,
            string accountType = null,
            string tokenApiId = null,
            string tokenId = null,
            string achIdentifier = null,
            Models.AchSecCode1Enum? achSecCode = null,
            int? authAmount = null,
            string authCode = null,
            Models.AvsEnum? avs = null,
            string avsEnhanced = null,
            bool? cardholderPresent = null,
            bool? cardPresent = null,
            string checkNumber = null,
            string customerIp = null,
            string cvvResponse = null,
            Models.EntryModeIdEnum? entryModeId = null,
            Models.EmvReceiptData emvReceiptData = null,
            string firstSix = null,
            string lastFour = null,
            string terminalSerialNumber = null,
            string transactionSettlementStatus = null,
            string chargeBackDate = null,
            bool? isRecurring = null,
            bool? notificationEmailSent = null,
            string par = null,
            Models.ReasonCodeId1Enum? reasonCodeId = null,
            string recurringId = null,
            string settleDate = null,
            Models.StatusCode17Enum? statusCode = null,
            string transactionBatchId = null,
            Models.TypeIdEnum? typeId = null,
            string verbiage = null,
            string voidDate = null,
            string batch = null,
            bool? termsAgree = null,
            string responseMessage = null,
            string returnDate = null,
            Models.TrxSourceIdEnum? trxSourceId = null,
            string routingNumber = null,
            Models.TrxSourceCodeEnum? trxSourceCode = null,
            string paylinkId = null,
            double? currencyCode = 840,
            bool? isAccountvault = null,
            string createdUserId = null,
            string transactionCode = null,
            string effectiveDate = null,
            string notificationPhone = null,
            string cavvResult = null,
            string recurringFlag = null,
            bool? isToken = null,
            int? installmentTotal = null,
            int? installmentCounter = null,
            string accountVaultId = null,
            string stan = null,
            string currency = null,
            string cardBin = null,
            Models.AccountVault accountVault = null,
            Models.QuickInvoice quickInvoice = null,
            List<Models.LogEmail> logEmails = null,
            bool? isVoidable = null,
            bool? isReversible = null,
            bool? isRefundable = null,
            bool? isCompletable = null,
            bool? isSettled = null,
            Models.CreatedUser createdUser = null,
            Models.Location location = null,
            Models.Contact1 contact = null,
            List<Models.Changelog> changelogs = null,
            Models.ProductTransaction productTransaction = null,
            List<Models.AllTag> allTags = null,
            List<Models.TagTransaction> tagTransactions = null,
            Models.DeclinedRecurringNotification declinedRecurringNotification = null,
            Models.PaymentRecurringNotification paymentRecurringNotification = null,
            Models.DeveloperCompany developerCompany = null,
            Models.Terminal terminal = null,
            Models.HostedPaymentPage hostedPaymentPage = null,
            Models.TransactionLevel3 transactionLevel3 = null,
            string developerCompanyId = null,
            List<Models.TransactionHistory> transactionHistories = null,
            Models.SurchargeTransaction surchargeTransaction = null,
            Models.Surcharge surcharge = null,
            Models.Signature signature = null,
            Models.ReasonCode reasonCode = null,
            Models.Type6 type = null,
            Models.Status11 status = null,
            Models.TransactionBatch transactionBatch = null,
            List<Models.TransactionSplit> transactionSplits = null,
            List<Models.PostbackLog> postbackLogs = null,
            Models.CurrencyType currencyType = null,
            List<Models.TransactionReference> transactionReferences = null)
        {
            this.AdditionalAmounts = additionalAmounts;
            this.BillingAddress = billingAddress;
            if (checkinDate != null)
            {
                this.CheckinDate = checkinDate;
            }

            if (checkoutDate != null)
            {
                this.CheckoutDate = checkoutDate;
            }

            if (clerkNumber != null)
            {
                this.ClerkNumber = clerkNumber;
            }

            if (contactApiId != null)
            {
                this.ContactApiId = contactApiId;
            }

            if (contactId != null)
            {
                this.ContactId = contactId;
            }

            this.CustomData = customData;
            if (customerId != null)
            {
                this.CustomerId = customerId;
            }

            if (description != null)
            {
                this.Description = description;
            }

            if (iiasInd != null)
            {
                this.IiasInd = iiasInd;
            }

            if (imageFront != null)
            {
                this.ImageFront = imageFront;
            }

            if (imageBack != null)
            {
                this.ImageBack = imageBack;
            }

            this.Installment = installment;
            if (installmentNumber != null)
            {
                this.InstallmentNumber = installmentNumber;
            }

            if (installmentCount != null)
            {
                this.InstallmentCount = installmentCount;
            }

            if (locationApiId != null)
            {
                this.LocationApiId = locationApiId;
            }

            if (locationId != null)
            {
                this.LocationId = locationId;
            }

            if (productTransactionId != null)
            {
                this.ProductTransactionId = productTransactionId;
            }

            this.AdvanceDeposit = advanceDeposit;
            this.NoShow = noShow;
            if (notificationEmailAddress != null)
            {
                this.NotificationEmailAddress = notificationEmailAddress;
            }

            if (orderNumber != null)
            {
                this.OrderNumber = orderNumber;
            }

            if (poNumber != null)
            {
                this.PoNumber = poNumber;
            }

            if (quickInvoiceId != null)
            {
                this.QuickInvoiceId = quickInvoiceId;
            }

            this.Recurring = recurring;
            if (recurringNumber != null)
            {
                this.RecurringNumber = recurringNumber;
            }

            if (roomNum != null)
            {
                this.RoomNum = roomNum;
            }

            if (roomRate != null)
            {
                this.RoomRate = roomRate;
            }

            this.SaveAccount = saveAccount;
            if (saveAccountTitle != null)
            {
                this.SaveAccountTitle = saveAccountTitle;
            }

            if (subtotalAmount != null)
            {
                this.SubtotalAmount = subtotalAmount;
            }

            if (surchargeAmount != null)
            {
                this.SurchargeAmount = surchargeAmount;
            }

            this.Tags = tags;
            if (tax != null)
            {
                this.Tax = tax;
            }

            if (tipAmount != null)
            {
                this.TipAmount = tipAmount;
            }

            if (transactionAmount != null)
            {
                this.TransactionAmount = transactionAmount;
            }

            if (secondaryAmount != null)
            {
                this.SecondaryAmount = secondaryAmount;
            }

            if (transactionApiId != null)
            {
                this.TransactionApiId = transactionApiId;
            }

            if (transactionC1 != null)
            {
                this.TransactionC1 = transactionC1;
            }

            if (transactionC2 != null)
            {
                this.TransactionC2 = transactionC2;
            }

            if (transactionC3 != null)
            {
                this.TransactionC3 = transactionC3;
            }

            this.BankFundedOnlyOverride = bankFundedOnlyOverride;
            this.AllowPartialAuthorizationOverride = allowPartialAuthorizationOverride;
            this.AutoDeclineCvvOverride = autoDeclineCvvOverride;
            this.AutoDeclineStreetOverride = autoDeclineStreetOverride;
            this.AutoDeclineZipOverride = autoDeclineZipOverride;
            this.Id = id;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            if (terminalId != null)
            {
                this.TerminalId = terminalId;
            }

            if (accountHolderName != null)
            {
                this.AccountHolderName = accountHolderName;
            }

            if (accountType != null)
            {
                this.AccountType = accountType;
            }

            if (tokenApiId != null)
            {
                this.TokenApiId = tokenApiId;
            }

            if (tokenId != null)
            {
                this.TokenId = tokenId;
            }

            if (achIdentifier != null)
            {
                this.AchIdentifier = achIdentifier;
            }

            if (achSecCode != null)
            {
                this.AchSecCode = achSecCode;
            }

            if (authAmount != null)
            {
                this.AuthAmount = authAmount;
            }

            if (authCode != null)
            {
                this.AuthCode = authCode;
            }

            if (avs != null)
            {
                this.Avs = avs;
            }

            if (avsEnhanced != null)
            {
                this.AvsEnhanced = avsEnhanced;
            }

            this.CardholderPresent = cardholderPresent;
            this.CardPresent = cardPresent;
            if (checkNumber != null)
            {
                this.CheckNumber = checkNumber;
            }

            if (customerIp != null)
            {
                this.CustomerIp = customerIp;
            }

            if (cvvResponse != null)
            {
                this.CvvResponse = cvvResponse;
            }

            if (entryModeId != null)
            {
                this.EntryModeId = entryModeId;
            }

            if (emvReceiptData != null)
            {
                this.EmvReceiptData = emvReceiptData;
            }

            if (firstSix != null)
            {
                this.FirstSix = firstSix;
            }

            if (lastFour != null)
            {
                this.LastFour = lastFour;
            }

            this.PaymentMethod = paymentMethod;
            if (terminalSerialNumber != null)
            {
                this.TerminalSerialNumber = terminalSerialNumber;
            }

            if (transactionSettlementStatus != null)
            {
                this.TransactionSettlementStatus = transactionSettlementStatus;
            }

            if (chargeBackDate != null)
            {
                this.ChargeBackDate = chargeBackDate;
            }

            this.IsRecurring = isRecurring;
            this.NotificationEmailSent = notificationEmailSent;
            if (par != null)
            {
                this.Par = par;
            }

            if (reasonCodeId != null)
            {
                this.ReasonCodeId = reasonCodeId;
            }

            if (recurringId != null)
            {
                this.RecurringId = recurringId;
            }

            if (settleDate != null)
            {
                this.SettleDate = settleDate;
            }

            if (statusCode != null)
            {
                this.StatusCode = statusCode;
            }

            if (transactionBatchId != null)
            {
                this.TransactionBatchId = transactionBatchId;
            }

            if (typeId != null)
            {
                this.TypeId = typeId;
            }

            if (verbiage != null)
            {
                this.Verbiage = verbiage;
            }

            if (voidDate != null)
            {
                this.VoidDate = voidDate;
            }

            if (batch != null)
            {
                this.Batch = batch;
            }

            this.TermsAgree = termsAgree;
            if (responseMessage != null)
            {
                this.ResponseMessage = responseMessage;
            }

            if (returnDate != null)
            {
                this.ReturnDate = returnDate;
            }

            if (trxSourceId != null)
            {
                this.TrxSourceId = trxSourceId;
            }

            if (routingNumber != null)
            {
                this.RoutingNumber = routingNumber;
            }

            if (trxSourceCode != null)
            {
                this.TrxSourceCode = trxSourceCode;
            }

            if (paylinkId != null)
            {
                this.PaylinkId = paylinkId;
            }

            this.CurrencyCode = currencyCode;
            this.IsAccountvault = isAccountvault;
            if (createdUserId != null)
            {
                this.CreatedUserId = createdUserId;
            }

            this.ModifiedUserId = modifiedUserId;
            if (transactionCode != null)
            {
                this.TransactionCode = transactionCode;
            }

            if (effectiveDate != null)
            {
                this.EffectiveDate = effectiveDate;
            }

            if (notificationPhone != null)
            {
                this.NotificationPhone = notificationPhone;
            }

            if (cavvResult != null)
            {
                this.CavvResult = cavvResult;
            }

            if (recurringFlag != null)
            {
                this.RecurringFlag = recurringFlag;
            }

            this.IsToken = isToken;
            if (installmentTotal != null)
            {
                this.InstallmentTotal = installmentTotal;
            }

            if (installmentCounter != null)
            {
                this.InstallmentCounter = installmentCounter;
            }

            if (accountVaultId != null)
            {
                this.AccountVaultId = accountVaultId;
            }

            this.HostedPaymentPageId = hostedPaymentPageId;
            if (stan != null)
            {
                this.Stan = stan;
            }

            if (currency != null)
            {
                this.Currency = currency;
            }

            if (cardBin != null)
            {
                this.CardBin = cardBin;
            }

            this.AccountVault = accountVault;
            this.QuickInvoice = quickInvoice;
            this.LogEmails = logEmails;
            this.IsVoidable = isVoidable;
            this.IsReversible = isReversible;
            this.IsRefundable = isRefundable;
            this.IsCompletable = isCompletable;
            this.IsSettled = isSettled;
            this.CreatedUser = createdUser;
            this.Location = location;
            this.Contact = contact;
            this.Changelogs = changelogs;
            this.ProductTransaction = productTransaction;
            this.AllTags = allTags;
            this.TagTransactions = tagTransactions;
            this.DeclinedRecurringNotification = declinedRecurringNotification;
            this.PaymentRecurringNotification = paymentRecurringNotification;
            this.DeveloperCompany = developerCompany;
            this.Terminal = terminal;
            this.HostedPaymentPage = hostedPaymentPage;
            this.TransactionLevel3 = transactionLevel3;
            if (developerCompanyId != null)
            {
                this.DeveloperCompanyId = developerCompanyId;
            }

            this.TransactionHistories = transactionHistories;
            this.SurchargeTransaction = surchargeTransaction;
            this.Surcharge = surcharge;
            this.Signature = signature;
            this.ReasonCode = reasonCode;
            this.Type = type;
            this.Status = status;
            this.TransactionBatch = transactionBatch;
            this.TransactionSplits = transactionSplits;
            this.PostbackLogs = postbackLogs;
            this.CurrencyType = currencyType;
            this.TransactionReferences = transactionReferences;
        }

        /// <summary>
        /// Additional amounts
        /// </summary>
        [JsonProperty("additional_amounts", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.AdditionalAmount> AdditionalAmounts { get; set; }

        /// <summary>
        /// Billing Address Object
        /// </summary>
        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BillingAddress BillingAddress { get; set; }

        /// <summary>
        /// Checkin Date - The time difference between checkin_date and checkout_date must be less than or equal to 99 days.
        /// </summary>
        [JsonProperty("checkin_date")]
        public string CheckinDate
        {
            get
            {
                return this.checkinDate;
            }

            set
            {
                this.shouldSerialize["checkin_date"] = true;
                this.checkinDate = value;
            }
        }

        /// <summary>
        /// Checkout Date - The time difference between checkin_date and checkout_date must be less than or equal to 99 days.
        /// </summary>
        [JsonProperty("checkout_date")]
        public string CheckoutDate
        {
            get
            {
                return this.checkoutDate;
            }

            set
            {
                this.shouldSerialize["checkout_date"] = true;
                this.checkoutDate = value;
            }
        }

        /// <summary>
        /// Clerk or Employee Identifier
        /// </summary>
        [JsonProperty("clerk_number")]
        public string ClerkNumber
        {
            get
            {
                return this.clerkNumber;
            }

            set
            {
                this.shouldSerialize["clerk_number"] = true;
                this.clerkNumber = value;
            }
        }

        /// <summary>
        /// This can be supplied in place of contact_id if you would like to use a contact for the transaction and are using your own custom api_id's to track contacts in the system.
        /// </summary>
        [JsonProperty("contact_api_id")]
        public string ContactApiId
        {
            get
            {
                return this.contactApiId;
            }

            set
            {
                this.shouldSerialize["contact_api_id"] = true;
                this.contactApiId = value;
            }
        }

        /// <summary>
        /// If contact_id is provided, ensure it belongs to the same location as the transaction. You cannot move transaction across locations.
        /// </summary>
        [JsonProperty("contact_id")]
        public string ContactId
        {
            get
            {
                return this.contactId;
            }

            set
            {
                this.shouldSerialize["contact_id"] = true;
                this.contactId = value;
            }
        }

        /// <summary>
        /// A field that allows custom JSON to be entered to store extra data.
        /// </summary>
        [JsonProperty("custom_data", NullValueHandling = NullValueHandling.Ignore)]
        public object CustomData { get; set; }

        /// <summary>
        /// Can be used by Merchants to identify Contacts in our system by an ID from another system.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId
        {
            get
            {
                return this.customerId;
            }

            set
            {
                this.shouldSerialize["customer_id"] = true;
                this.customerId = value;
            }
        }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("description")]
        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                this.shouldSerialize["description"] = true;
                this.description = value;
            }
        }

        /// <summary>
        /// Possible values are '0', '1','2'
        /// </summary>
        [JsonProperty("iias_ind")]
        public Models.IiasIndEnum? IiasInd
        {
            get
            {
                return this.iiasInd;
            }

            set
            {
                this.shouldSerialize["iias_ind"] = true;
                this.iiasInd = value;
            }
        }

        /// <summary>
        /// A base64 encoded string for the image.  Used with Check21 ACH transactions.
        /// </summary>
        [JsonProperty("image_front")]
        public string ImageFront
        {
            get
            {
                return this.imageFront;
            }

            set
            {
                this.shouldSerialize["image_front"] = true;
                this.imageFront = value;
            }
        }

        /// <summary>
        /// A base64 encoded string for the image.  Used with Check21 ACH transactions.
        /// </summary>
        [JsonProperty("image_back")]
        public string ImageBack
        {
            get
            {
                return this.imageBack;
            }

            set
            {
                this.shouldSerialize["image_back"] = true;
                this.imageBack = value;
            }
        }

        /// <summary>
        /// Flag that is allowed to be passed on card not present industries to signify the transaction is a fixed installment plan transaction.
        /// </summary>
        [JsonProperty("installment", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Installment { get; set; }

        /// <summary>
        /// If this is a fixed installment plan and installment field is being passed as 1, then this field must have a vlue of 1-999 specifying the current installment number that is running.
        /// </summary>
        [JsonProperty("installment_number")]
        public int? InstallmentNumber
        {
            get
            {
                return this.installmentNumber;
            }

            set
            {
                this.shouldSerialize["installment_number"] = true;
                this.installmentNumber = value;
            }
        }

        /// <summary>
        /// If this is a fixed installment plan and installment field is being passed as 1, then this field must have a vlue of 1-999 specifying the total number of installments on the plan. This number must be grater than or equal to installment_number.
        /// </summary>
        [JsonProperty("installment_count")]
        public int? InstallmentCount
        {
            get
            {
                return this.installmentCount;
            }

            set
            {
                this.shouldSerialize["installment_count"] = true;
                this.installmentCount = value;
            }
        }

        /// <summary>
        /// This can be supplied in place of location_id for the transaction if you are using your own custom api_id's for your locations.
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
        /// A valid Location Id to associate the transaction with.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId
        {
            get
            {
                return this.locationId;
            }

            set
            {
                this.shouldSerialize["location_id"] = true;
                this.locationId = value;
            }
        }

        /// <summary>
        /// The Product's method (cc/ach) has to match the action. If not provided, the API will use the default configured for the Location.
        /// </summary>
        [JsonProperty("product_transaction_id")]
        public string ProductTransactionId
        {
            get
            {
                return this.productTransactionId;
            }

            set
            {
                this.shouldSerialize["product_transaction_id"] = true;
                this.productTransactionId = value;
            }
        }

        /// <summary>
        /// Advance Deposit
        /// </summary>
        [JsonProperty("advance_deposit", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AdvanceDeposit { get; set; }

        /// <summary>
        /// Used in Lodging
        /// </summary>
        [JsonProperty("no_show", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NoShow { get; set; }

        /// <summary>
        /// If email is supplied then receipt will be emailed
        /// </summary>
        [JsonProperty("notification_email_address")]
        public string NotificationEmailAddress
        {
            get
            {
                return this.notificationEmailAddress;
            }

            set
            {
                this.shouldSerialize["notification_email_address"] = true;
                this.notificationEmailAddress = value;
            }
        }

        /// <summary>
        /// Required for CC transactions , if merchant's deposit account's duplicate check per batch has 'order_number' field
        /// </summary>
        [JsonProperty("order_number")]
        public string OrderNumber
        {
            get
            {
                return this.orderNumber;
            }

            set
            {
                this.shouldSerialize["order_number"] = true;
                this.orderNumber = value;
            }
        }

        /// <summary>
        /// Purchase Order number
        /// </summary>
        [JsonProperty("po_number")]
        public string PoNumber
        {
            get
            {
                return this.poNumber;
            }

            set
            {
                this.shouldSerialize["po_number"] = true;
                this.poNumber = value;
            }
        }

        /// <summary>
        /// Can be used to associate a transaction to a Quick Invoice.  Quick Invoice transactions will have a value for this field automatically.
        /// </summary>
        [JsonProperty("quick_invoice_id")]
        public string QuickInvoiceId
        {
            get
            {
                return this.quickInvoiceId;
            }

            set
            {
                this.shouldSerialize["quick_invoice_id"] = true;
                this.quickInvoiceId = value;
            }
        }

        /// <summary>
        /// Recurring Information on `expand`
        /// </summary>
        [JsonProperty("recurring", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Recurring3 Recurring { get; set; }

        /// <summary>
        /// If this is an ongoing recurring and recurring field is being passed as 1, then this field must have a vlue of 1-999 specifying the current recurring number that is running.
        /// </summary>
        [JsonProperty("recurring_number")]
        public int? RecurringNumber
        {
            get
            {
                return this.recurringNumber;
            }

            set
            {
                this.shouldSerialize["recurring_number"] = true;
                this.recurringNumber = value;
            }
        }

        /// <summary>
        /// Used in Lodging
        /// </summary>
        [JsonProperty("room_num")]
        public string RoomNum
        {
            get
            {
                return this.roomNum;
            }

            set
            {
                this.shouldSerialize["room_num"] = true;
                this.roomNum = value;
            }
        }

        /// <summary>
        /// Required if merchant industry type is lodging.
        /// </summary>
        [JsonProperty("room_rate")]
        public int? RoomRate
        {
            get
            {
                return this.roomRate;
            }

            set
            {
                this.shouldSerialize["room_rate"] = true;
                this.roomRate = value;
            }
        }

        /// <summary>
        /// Specifies to save account to contacts profile if account_number/track_data is present with either contact_id or contact_api_id in params.
        /// </summary>
        [JsonProperty("save_account", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SaveAccount { get; set; }

        /// <summary>
        /// If saving token while running a transaction, this will be the title of the token.
        /// </summary>
        [JsonProperty("save_account_title")]
        public string SaveAccountTitle
        {
            get
            {
                return this.saveAccountTitle;
            }

            set
            {
                this.shouldSerialize["save_account_title"] = true;
                this.saveAccountTitle = value;
            }
        }

        /// <summary>
        /// This field is allowed and required for transactions that have a product where surcharge is configured. Use only integer numbers, so $10.99 will be 1099.
        /// </summary>
        [JsonProperty("subtotal_amount")]
        public int? SubtotalAmount
        {
            get
            {
                return this.subtotalAmount;
            }

            set
            {
                this.shouldSerialize["subtotal_amount"] = true;
                this.subtotalAmount = value;
            }
        }

        /// <summary>
        /// This field is allowed and required for transactions that have a product where surcharge is configured. Use only integer numbers, so $10.99 will be 1099.
        /// </summary>
        [JsonProperty("surcharge_amount")]
        public int? SurchargeAmount
        {
            get
            {
                return this.surchargeAmount;
            }

            set
            {
                this.shouldSerialize["surcharge_amount"] = true;
                this.surchargeAmount = value;
            }
        }

        /// <summary>
        /// Tag Information on `expand`
        /// </summary>
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.Tag> Tags { get; set; }

        /// <summary>
        /// Amount of Sales tax - If supplied, this amount should be included in the total transaction_amount field. Use only integer numbers, so $10.99 will be 1099.
        /// </summary>
        [JsonProperty("tax")]
        public int? Tax
        {
            get
            {
                return this.tax;
            }

            set
            {
                this.shouldSerialize["tax"] = true;
                this.tax = value;
            }
        }

        /// <summary>
        /// Optional tip amount. Tip is not supported for lodging and ecommerce merchants. Use only integer numbers, so $10.99 will be 1099.
        /// </summary>
        [JsonProperty("tip_amount")]
        public int? TipAmount
        {
            get
            {
                return this.tipAmount;
            }

            set
            {
                this.shouldSerialize["tip_amount"] = true;
                this.tipAmount = value;
            }
        }

        /// <summary>
        /// Amount of the transaction. This should always be the desired settle amount of the transaction. Use only integer numbers, so $10.99 will be 1099.
        /// </summary>
        [JsonProperty("transaction_amount")]
        public int? TransactionAmount
        {
            get
            {
                return this.transactionAmount;
            }

            set
            {
                this.shouldSerialize["transaction_amount"] = true;
                this.transactionAmount = value;
            }
        }

        /// <summary>
        /// Retained Amount of the transaction. This should always be less than transaction amount. Use only integer numbers, so $10.99 will be 1099
        /// </summary>
        [JsonProperty("secondary_amount")]
        public int? SecondaryAmount
        {
            get
            {
                return this.secondaryAmount;
            }

            set
            {
                this.shouldSerialize["secondary_amount"] = true;
                this.secondaryAmount = value;
            }
        }

        /// <summary>
        /// See api_id page for more details
        /// </summary>
        [JsonProperty("transaction_api_id")]
        public string TransactionApiId
        {
            get
            {
                return this.transactionApiId;
            }

            set
            {
                this.shouldSerialize["transaction_api_id"] = true;
                this.transactionApiId = value;
            }
        }

        /// <summary>
        /// Custom field 1 for api users to store custom data
        /// </summary>
        [JsonProperty("transaction_c1")]
        public string TransactionC1
        {
            get
            {
                return this.transactionC1;
            }

            set
            {
                this.shouldSerialize["transaction_c1"] = true;
                this.transactionC1 = value;
            }
        }

        /// <summary>
        /// Custom field 2 for api users to store custom data
        /// </summary>
        [JsonProperty("transaction_c2")]
        public string TransactionC2
        {
            get
            {
                return this.transactionC2;
            }

            set
            {
                this.shouldSerialize["transaction_c2"] = true;
                this.transactionC2 = value;
            }
        }

        /// <summary>
        /// Custom field 3 for api users to store custom data
        /// </summary>
        [JsonProperty("transaction_c3")]
        public string TransactionC3
        {
            get
            {
                return this.transactionC3;
            }

            set
            {
                this.shouldSerialize["transaction_c3"] = true;
                this.transactionC3 = value;
            }
        }

        /// <summary>
        /// Bank Funded Only Override
        /// </summary>
        [JsonProperty("bank_funded_only_override", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BankFundedOnlyOverride { get; set; }

        /// <summary>
        /// Allow Partial Authorization Override
        /// </summary>
        [JsonProperty("allow_partial_authorization_override", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowPartialAuthorizationOverride { get; set; }

        /// <summary>
        /// Auto Decline CVV Override
        /// </summary>
        [JsonProperty("auto_decline_cvv_override", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoDeclineCvvOverride { get; set; }

        /// <summary>
        /// Auto Decline Street Override
        /// </summary>
        [JsonProperty("auto_decline_street_override", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoDeclineStreetOverride { get; set; }

        /// <summary>
        /// Auto Decline Zip Override
        /// </summary>
        [JsonProperty("auto_decline_zip_override", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoDeclineZipOverride { get; set; }

        /// <summary>
        /// Transaction ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int CreatedTs { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts")]
        public int ModifiedTs { get; set; }

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
        /// For CC, this is the 'Name (as it appears) on Card'. For ACH, this is the 'Name on Account'.
        /// </summary>
        [JsonProperty("account_holder_name")]
        public string AccountHolderName
        {
            get
            {
                return this.accountHolderName;
            }

            set
            {
                this.shouldSerialize["account_holder_name"] = true;
                this.accountHolderName = value;
            }
        }

        /// <summary>
        /// Required for ACH transactions if account_vault_id is not provided.
        /// </summary>
        [JsonProperty("account_type")]
        public string AccountType
        {
            get
            {
                return this.accountType;
            }

            set
            {
                this.shouldSerialize["account_type"] = true;
                this.accountType = value;
            }
        }

        /// <summary>
        /// This can be supplied in place of account_vault_id if you would like to use an token for the transaction and are using your own custom api_id's to track accountvaults in the system.
        /// </summary>
        [JsonProperty("token_api_id")]
        public string TokenApiId
        {
            get
            {
                return this.tokenApiId;
            }

            set
            {
                this.shouldSerialize["token_api_id"] = true;
                this.tokenApiId = value;
            }
        }

        /// <summary>
        /// Required if account_number,  track_data, micr_data is not provided.
        /// </summary>
        [JsonProperty("token_id")]
        public string TokenId
        {
            get
            {
                return this.tokenId;
            }

            set
            {
                this.shouldSerialize["token_id"] = true;
                this.tokenId = value;
            }
        }

        /// <summary>
        /// Required for ACH transactions in certain scenarios.
        /// </summary>
        [JsonProperty("ach_identifier")]
        public string AchIdentifier
        {
            get
            {
                return this.achIdentifier;
            }

            set
            {
                this.shouldSerialize["ach_identifier"] = true;
                this.achIdentifier = value;
            }
        }

        /// <summary>
        /// Required for ACH transactions if account_vault_id is not provided.
        /// </summary>
        [JsonProperty("ach_sec_code")]
        public Models.AchSecCode1Enum? AchSecCode
        {
            get
            {
                return this.achSecCode;
            }

            set
            {
                this.shouldSerialize["ach_sec_code"] = true;
                this.achSecCode = value;
            }
        }

        /// <summary>
        /// Authorization Amount
        /// </summary>
        [JsonProperty("auth_amount")]
        public int? AuthAmount
        {
            get
            {
                return this.authAmount;
            }

            set
            {
                this.shouldSerialize["auth_amount"] = true;
                this.authAmount = value;
            }
        }

        /// <summary>
        /// Required on force transactions. Ignored for all other actions.
        /// </summary>
        [JsonProperty("auth_code")]
        public string AuthCode
        {
            get
            {
                return this.authCode;
            }

            set
            {
                this.shouldSerialize["auth_code"] = true;
                this.authCode = value;
            }
        }

        /// <summary>
        /// AVS
        /// </summary>
        [JsonProperty("avs")]
        public Models.AvsEnum? Avs
        {
            get
            {
                return this.avs;
            }

            set
            {
                this.shouldSerialize["avs"] = true;
                this.avs = value;
            }
        }

        /// <summary>
        /// AVS Enhanced
        /// </summary>
        [JsonProperty("avs_enhanced")]
        public string AvsEnhanced
        {
            get
            {
                return this.avsEnhanced;
            }

            set
            {
                this.shouldSerialize["avs_enhanced"] = true;
                this.avsEnhanced = value;
            }
        }

        /// <summary>
        /// If the cardholder is present at the point of service
        /// </summary>
        [JsonProperty("cardholder_present", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CardholderPresent { get; set; }

        /// <summary>
        /// A POST only field to specify whether or not the card is present.
        /// </summary>
        [JsonProperty("card_present", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CardPresent { get; set; }

        /// <summary>
        /// Required for transactions using TEL SEC code.
        /// </summary>
        [JsonProperty("check_number")]
        public string CheckNumber
        {
            get
            {
                return this.checkNumber;
            }

            set
            {
                this.shouldSerialize["check_number"] = true;
                this.checkNumber = value;
            }
        }

        /// <summary>
        /// Can be used to store customer IP Address
        /// </summary>
        [JsonProperty("customer_ip")]
        public string CustomerIp
        {
            get
            {
                return this.customerIp;
            }

            set
            {
                this.shouldSerialize["customer_ip"] = true;
                this.customerIp = value;
            }
        }

        /// <summary>
        /// Obfuscated CVV
        /// </summary>
        [JsonProperty("cvv_response")]
        public string CvvResponse
        {
            get
            {
                return this.cvvResponse;
            }

            set
            {
                this.shouldSerialize["cvv_response"] = true;
                this.cvvResponse = value;
            }
        }

        /// <summary>
        /// Entry Mode - See entry mode section for more detail
        /// </summary>
        [JsonProperty("entry_mode_id")]
        public Models.EntryModeIdEnum? EntryModeId
        {
            get
            {
                return this.entryModeId;
            }

            set
            {
                this.shouldSerialize["entry_mode_id"] = true;
                this.entryModeId = value;
            }
        }

        /// <summary>
        /// This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM
        /// </summary>
        [JsonProperty("emv_receipt_data")]
        public Models.EmvReceiptData EmvReceiptData
        {
            get
            {
                return this.emvReceiptData;
            }

            set
            {
                this.shouldSerialize["emv_receipt_data"] = true;
                this.emvReceiptData = value;
            }
        }

        /// <summary>
        /// First six numbers of account_number.  Automatically generated by system.
        /// </summary>
        [JsonProperty("first_six")]
        public string FirstSix
        {
            get
            {
                return this.firstSix;
            }

            set
            {
                this.shouldSerialize["first_six"] = true;
                this.firstSix = value;
            }
        }

        /// <summary>
        /// Last four numbers of account_number.  Automatically generated by the system.
        /// </summary>
        [JsonProperty("last_four")]
        public string LastFour
        {
            get
            {
                return this.lastFour;
            }

            set
            {
                this.shouldSerialize["last_four"] = true;
                this.lastFour = value;
            }
        }

        /// <summary>
        /// 'cc' or 'ach'
        /// </summary>
        [JsonProperty("payment_method")]
        public Models.PaymentMethod6Enum PaymentMethod { get; set; }

        /// <summary>
        /// If transaction was processed using a terminal, this field would contain the terminal's serial number
        /// </summary>
        [JsonProperty("terminal_serial_number")]
        public string TerminalSerialNumber
        {
            get
            {
                return this.terminalSerialNumber;
            }

            set
            {
                this.shouldSerialize["terminal_serial_number"] = true;
                this.terminalSerialNumber = value;
            }
        }

        /// <summary>
        /// (Deprecated field)
        /// </summary>
        [JsonProperty("transaction_settlement_status")]
        public string TransactionSettlementStatus
        {
            get
            {
                return this.transactionSettlementStatus;
            }

            set
            {
                this.shouldSerialize["transaction_settlement_status"] = true;
                this.transactionSettlementStatus = value;
            }
        }

        /// <summary>
        /// Charge Back Date (ACH Trxs)
        /// </summary>
        [JsonProperty("charge_back_date")]
        public string ChargeBackDate
        {
            get
            {
                return this.chargeBackDate;
            }

            set
            {
                this.shouldSerialize["charge_back_date"] = true;
                this.chargeBackDate = value;
            }
        }

        /// <summary>
        /// Flag that is allowed to be passed on card not present industries to signify the transaction is a fixed installment plan transaction.
        /// </summary>
        [JsonProperty("is_recurring", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRecurring { get; set; }

        /// <summary>
        /// Indicates if email receipt has been sent
        /// </summary>
        [JsonProperty("notification_email_sent", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NotificationEmailSent { get; set; }

        /// <summary>
        /// A field usually returned form the processor to uniquely identifier a specific cardholder's credit card.
        /// </summary>
        [JsonProperty("par")]
        public string Par
        {
            get
            {
                return this.par;
            }

            set
            {
                this.shouldSerialize["par"] = true;
                this.par = value;
            }
        }

        /// <summary>
        /// Response reason code that provides more detail as to the result of the transaction. The reason code list can be found here: Response Reason Codes
        /// >0 - N/A
        /// >
        /// >1000 - CC - Approved / ACH - Accepted
        /// >
        /// >1000 - CC - Approved / ACH - Accepted
        /// >
        /// >1001 - AuthCompleted
        /// >
        /// >1002 - Forced
        /// >
        /// >1003 - AuthOnly Declined
        /// >
        /// >1004 - Validation Failure (System Run Trx)
        /// >
        /// >1005 - Processor Response Invalid
        /// >
        /// >1200 - Voided
        /// >
        /// >1201 - Partial Approval
        /// >
        /// >1240 - Approved, optional fields are missing (Paya ACH only)
        /// >
        /// >1301 - Account Deactivated for Fraud
        /// >
        /// >1302-1399 - Reserved for Future Fraud Reason Codes
        /// >
        /// >1500 - Generic Decline
        /// >
        /// >1510 - Call
        /// >
        /// >1518 - Transaction Not Permitted - Terminal
        /// >
        /// >1520 - Pickup Card
        /// >
        /// >1530 - Retry Trx
        /// >
        /// >1531 - Communication Error
        /// >
        /// >1540 - Setup Issue, contact Support
        /// >
        /// >1541 - Device is not signature capable
        /// >
        /// >1588 - Data could not be de-tokenized
        /// >
        /// >1599 - Other Reason
        /// >
        /// >1601 - Generic Decline
        /// >
        /// >1602 - Call
        /// >
        /// >1603 - No Reply
        /// >
        /// >1604 - Pickup Card - No Fraud
        /// >
        /// >1605 - Pickup Card - Fraud
        /// >
        /// >1606 - Pickup Card - Lost
        /// >
        /// >1607 - Pickup Card - Stolen
        /// >
        /// >1608 - Account Error
        /// >
        /// >1609 - Already Reversed
        /// >
        /// >1610 - Bad PIN
        /// >
        /// >1611 - Cashback Exceeded
        /// >
        /// >1612 - Cashback Not Available
        /// >
        /// >1613 - CID Error
        /// >
        /// >1614 - Date Error
        /// >
        /// >1615 - Do Not Honor
        /// >
        /// >1616 - NSF
        /// >
        /// >1618 - Invalid Service Code
        /// >
        /// >1619 - Exceeded activity limit
        /// >
        /// >1620 - Violation
        /// >
        /// >1621 - Encryption Error
        /// >
        /// >1622 - Card Expired
        /// >
        /// >1623 - Renter
        /// >
        /// >1624 - Security Violation
        /// >
        /// >1625 - Card Not Permitted
        /// >
        /// >1626 - Trans Not Permitted
        /// >
        /// >1627 - System Error
        /// >
        /// >1628 - Bad Merchant ID
        /// >
        /// >1629 - Duplicate Batch (Already Closed)
        /// >
        /// >1630 - Batch Rejected
        /// >
        /// >1631 - Account Closed
        /// >
        /// >1632 - PIN tries exceeded
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >1640 - Required fields are missing (ACH only)
        /// >
        /// >1641 - Previously declined transaction (1640)
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >
        /// >1650 - Contact Support
        /// >
        /// >1651 - Max Sending - Throttle Limit Hit (ACH only)
        /// >
        /// >1652 - Max Attempts Exceeded
        /// >
        /// >1653 - Contact Support
        /// >
        /// >1654 - Voided - Online Reversal Failed
        /// >
        /// >1655 - Decline (AVS Auto Reversal)
        /// >
        /// >1656 - Decline (CVV Auto Reversal)
        /// >
        /// >1657 - Decline (Partial Auth Auto Reversal)
        /// >
        /// >1658 - Expired Authorization
        /// >
        /// >1659 - Declined - Partial Approval not Supported
        /// >
        /// >1660 - Bank Account Error, please delete and re-add Token
        /// >
        /// >1661 - Declined AuthIncrement
        /// >
        /// >1662 - Auto Reversal - Processor can't settle
        /// >
        /// >1663 - Manager Needed (Needs override transaction)
        /// >
        /// >1664 - Token Not Found: Sharing Group Unavailable
        /// >
        /// >1665 - Contact Not Found: Sharing Group Unavailable
        /// >
        /// >1666 - Amount Error
        /// >
        /// >1667 - Action Not Allowed in Current State
        /// >
        /// >1668 - Original Authorization Not Valid
        /// >
        /// >1701 - Chip Reject
        /// >
        /// >1800 - Incorrect CVV
        /// >
        /// >1801 - Duplicate Transaction
        /// >
        /// >1802 - MID/TID Not Registered
        /// >
        /// >1803 - Stop Recurring
        /// >
        /// >1804 - No Transactions in Batch
        /// >
        /// >1805 - Batch Does Not Exist
        /// >
        /// >
        /// >
        /// **ACH Reject Reason Codes**
        /// | Code | E-Code | Verbiage | Short Description | Long Description |
        /// | ----------- | ----------- | ----------- | ----------- | ----------- |
        /// | 2101 | Rejected-R01 |  | Insufficient funds | Available balance is not sufficient to cover the amount of the debit entry |
        /// | 2102 | Rejected-R02  | E02 | Bank account closed | Previously active amount has been closed by the customer of RDFI |
        /// | 2103 | Rejected-R03 | E03 | No bank account/unable to locate account | Account number does not correspond to the individual identified in the entry, or the account number designated is not an open account |
        /// | 2104 | Rejected-R04  | E04 | Invalid bank account number | Account number structure is not valid |
        /// | 2105 | Rejected-R05  | E05 | Reserved | Currently not in use |
        /// | 2106 | Rejected-R06 |  | Returned per ODFI request | ODFI requested the RDFI to return the entry |
        /// | 2107 | Rejected-R07 | E07 | Authorization revoked by customer | Receiver has revoked authorization |
        /// | 2108 | Rejected-R08 | E08 | Payment stopped | Receiver of a recurring debit has stopped payment of an entry |
        /// | 2109 | Rejected-R09 |  | Uncollected funds | Collected funds are not sufficient for payment of the debit entry |
        /// | 2110 | Rejected-R10 | E10 | Customer Advises Originator is Not Known to Receiver and/or Is Not Authorized by Receiver to Debit Receiver’s Account | Receiver has advised RDFI that originator is not authorized to debit his bank account |
        /// | 2111 | Rejected-R11 |  | Customer Advises Entry Not In Accordance with the Terms of the Authorization | To be used when there is an error in the authorization |
        /// | 2112 | Rejected-R12 |  | Branch sold to another RDFI | RDFI unable to post entry destined for a bank account maintained at a branch sold to another financial institution |
        /// | 2113 | Rejected-R13 |  | RDFI not qualified to participate | Financial institution does not receive commercial ACH entries |
        /// | 2114 | Rejected-R14 | E14 | Representative payee deceased or unable to continue in that capacity | The representative payee authorized to accept entries on behalf of a beneficiary is either deceased or unable to continue in that capacity |
        /// | 2115 | Rejected-R15 | E15 | Beneficiary or bank account holder deceased | (Other than representative payee) deceased* - (1) the beneficiary entitled to payments is deceased or (2) the bank account holder other than a representative payee is deceased |
        /// | 2116 | Rejected-R16 | E16 | Bank account frozen | Funds in bank account are unavailable due to action by RDFI or legal order |
        /// | 2117 | Rejected-R17 |  | File record edit criteria | Entry with Invalid Account Number Initiated Under Questionable Circumstances |
        /// | 2118 | Rejected-R18 |  | Improper effective entry date | Entries have been presented prior to the first available processing window for the effective date. |
        /// | 2119 | Rejected-R19 |  | Amount field error | Improper formatting of the amount field |
        /// | 2120 | Rejected-R20 |  | Non-payment bank account | Entry destined for non-payment bank account defined by reg. |
        /// | 2121 | Rejected-R21 |  | Invalid company Identification | The company ID information not valid (normally CIE entries) |
        /// | 2122 | Rejected-R22 |  | Invalid individual ID number | Individual id used by receiver is incorrect (CIE entries) |
        /// | 2123 | Rejected-R23 |  | Credit entry refused by receiver | Receiver returned entry because minimum or exact amount not remitted, bank account is subject to litigation, or payment represents an overpayment, originator is not known to receiver or receiver has not authorized this credit entry to this bank account |
        /// | 2124 | Rejected-R24 |  | Duplicate entry | RDFI has received a duplicate entry |
        /// | 2125 | Rejected-R25 |  | Addenda error | Improper formatting of the addenda record information |
        /// | 2126 | Rejected-R26 |  | Mandatory field error | Improper information in one of the mandatory fields |
        /// | 2127 | Rejected-R27 |  | Trace number error | Original entry trace number is not valid for return entry; or addenda trace numbers do not correspond with entry detail record |
        /// | 2128 | Rejected-R28 |  | Transit routing number check digit error | Check digit for the transit routing number is incorrect |
        /// | 2129 | Rejected-R29 | E29 | Corporate customer advises not authorized | RDFI has been notified by corporate receiver that debit entry of originator is not authorized |
        /// | 2130 | Rejected-R30 |  | RDFI not participant in check truncation program | Financial institution not participating in automated check safekeeping application |
        /// | 2131 | Rejected-R31 |  | Permissible return entry (CCD and CTX only) | RDFI has been notified by the ODFI that it agrees to accept a CCD or CTX return entry |
        /// | 2132 | Rejected-R32 |  | RDFI non-settlement | RDFI is not able to settle the entry |
        /// | 2133 | Rejected-R33 |  | Return of XCK entry | RDFI determines at its sole discretion to return an XCK entry; an XCK return entry may be initiated by midnight of the sixtieth day following the settlement date if the XCK entry |
        /// | 2134 | Rejected-R34 |  | Limited participation RDFI | RDFI participation has been limited by a federal or state supervisor |
        /// | 2135 | Rejected-R35 |  | Return of improper debit entry | ACH debit not permitted for use with the CIE standard entry class code (except for reversals) |
        /// | 2136 | Rejected-R36 |  | Return of Improper Credit Entry |  |
        /// | 2137 | Rejected-R37 |  | Source Document Presented for Payment |  |
        /// | 2138 | Rejected-R38 |  | Stop Payment on Source Document |  |
        /// | 2139 | Rejected-R39 |  | Improper Source Document |  |
        /// | 2140 | Rejected-R40 |  | Return of ENR Entry by Federal Government Agency |  |
        /// | 2141 | Rejected-R41 |  | Invalid Transaction Code |  |
        /// | 2142 | Rejected-R42 |  | Routing Number/Check Digit Error |  |
        /// | 2143 | Rejected-R43 |  | Invalid DFI Account Number |  |
        /// | 2144 | Rejected-R44 |  | Invalid Individual ID Number/Identification |  |
        /// | 2145 | Rejected-R45 |  | Invalid Individual Name/Company Name |  |
        /// | 2146 | Rejected-R46 |  | Invalid Representative Payee Indicator |  |
        /// | 2147 | Rejected-R47 |  | Duplicate Enrollment |  |
        /// | 2150 | Rejected-R50 |  | State Law Affecting RCK Acceptance |  |
        /// | 2151 | Rejected-R51 |  | Item is Ineligible, Notice Not Provided, etc. |  |
        /// | 2152 | Rejected-R52 |  | Stop Payment on Item (adjustment entries) |  |
        /// | 2153 | Rejected-R53 |  | Item and ACH Entry Presented for Payment |  |
        /// | 2161 | Rejected-R61 |  | Misrouted Return |  |
        /// | 2162 | Rejected-R62 |  | Incorrect Trace Number |  |
        /// | 2163 | Rejected-R63 |  | Incorrect Dollar Amount |  |
        /// | 2164 | Rejected-R64 |  | Incorrect Individual Identification |  |
        /// | 2165 | Rejected-R65 |  | Incorrect Transaction Code |  |
        /// | 2166 | Rejected-R66 |  | Incorrect Company Identification |  |
        /// | 2167 | Rejected-R67 |  | Duplicate Return |  |
        /// | 2168 | Rejected-R68 |  | Untimely Return |  |
        /// | 2169 | Rejected-R69 |  | Multiple Errors |  |
        /// | 2170 | Rejected-R70 |  | Permissible Return Entry Not Accepted |  |
        /// | 2171 | Rejected-R71 |  | Misrouted Dishonored Return |  |
        /// | 2172 | Rejected-R72 |  | Untimely Dishonored Return |  |
        /// | 2173 | Rejected-R73 |  | Timely Original Return |  |
        /// | 2174 | Rejected-R74 |  | Corrected Return |  |
        /// | 2180 | Rejected-R80 |  | Cross-Border Payment Coding Error |  |
        /// | 2181 | Rejected-R81 |  | Non-Participant in Cross-Border Program |  |
        /// | 2182 | Rejected-R82 |  | Invalid Foreign Receiving DFI Identification |  |
        /// | 2183 | Rejected-R83 |  | Foreign Receiving DFI Unable to Settle |  |
        /// | 2200 | Voided |  | Processor Void | The transaction was voided by the processor before being sent to the bank |
        /// | 2201 | Rejected-C01 |  |  |  |
        /// | 2202 | Rejected-C02 |  |  |  |
        /// | 2203 | Rejected-C03 |  |  |  |
        /// | 2204 | Rejected-C04 |  |  |  |
        /// | 2205 | Rejected-C05 |  |  |  |
        /// | 2206 | Rejected-C06 |  |  |  |
        /// | 2207 | Rejected-C07 |  |  |  |
        /// | 2208 | Rejected-C08 |  |  |  |
        /// | 2209 | Rejected-C09 |  |  |  |
        /// | 2210 | Rejected-C10 |  |  |  |
        /// | 2211 | Rejected-C11 |  |  |  |
        /// | 2212 | Rejected-C12 |  |  |  |
        /// | 2213 | Rejected-C13 |  |  |  |
        /// | 2261 | Rejected-C61 |  |  |  |
        /// | 2262 | Rejected-C62 |  |  |  |
        /// | 2263 | Rejected-C63 |  |  |  |
        /// | 2264 | Rejected-C64 |  |  |  |
        /// | 2265 | Rejected-C65 |  |  |  |
        /// | 2266 | Rejected-C66 |  |  |  |
        /// | 2267 | Rejected-C67 |  |  |  |
        /// | 2268 | Rejected-C68 |  |  |  |
        /// | 2269 | Rejected-C69 |  |  |  |
        /// | 2301 | Rejected-X01 |  | Misc Check 21 Return |  |
        /// | 2304 | Rejected-X04 |  | Invalid Image |  |
        /// | 2305 | Rejected-X05 | E95 | Breach of Warranty |  |
        /// | 2306 | Rejected-X06 | E96 | Counterfeit / Forgery |  |
        /// | 2307 | Rejected-X07 | E97 | Refer to Maker |  |
        /// | 2308 | Rejected-X08 |  | Maximum Payment Attempts |  |
        /// | 2309 | Rejected-X09 |  | Item Cannot be Re-presented |  |
        /// | 2310 | Rejected-X10 |  | Not Our Item |  |
        /// | 2321 | Rejected-X21 |  | Pay None |  |
        /// | 2322 | Rejected-X22 |  | Pay All |  |
        /// | 2323 | Rejected-X23 | E93 | Non-Negotiable |  |
        /// | 2329 | Rejected-X29 |  | Stale Dated |  |
        /// | 2345 | Rejected-X45 |  | Misc Return |  |
        /// | 2371 | Rejected-X71 |  | RCK - 2nd Time |  |
        /// | 2372 | Rejected-X72 |  | RCK Reject - ACH |  |
        /// | 2373 | Rejected-X73 |  | RCK Reject - Payer |  |
        /// </summary>
        [JsonProperty("reason_code_id")]
        public Models.ReasonCodeId1Enum? ReasonCodeId
        {
            get
            {
                return this.reasonCodeId;
            }

            set
            {
                this.shouldSerialize["reason_code_id"] = true;
                this.reasonCodeId = value;
            }
        }

        /// <summary>
        /// A unique identifer used to associate a transaction with a Recurring.
        /// </summary>
        [JsonProperty("recurring_id")]
        public string RecurringId
        {
            get
            {
                return this.recurringId;
            }

            set
            {
                this.shouldSerialize["recurring_id"] = true;
                this.recurringId = value;
            }
        }

        /// <summary>
        /// Settle date
        /// </summary>
        [JsonProperty("settle_date")]
        public string SettleDate
        {
            get
            {
                return this.settleDate;
            }

            set
            {
                this.shouldSerialize["settle_date"] = true;
                this.settleDate = value;
            }
        }

        /// <summary>
        /// Status ID - See status id section for more detail
        /// >101 - Sale cc Approved
        /// >
        /// >102 - Sale cc AuthOnly
        /// >
        /// >111 - Refund cc Refunded
        /// >
        /// >121 - Credit/Debit/Refund cc AvsOnly
        /// >
        /// >131 - Credit/Debit/Refund ach Pending Origination
        /// >
        /// >132 - Credit/Debit/Refund ach Originating
        /// >
        /// >133 - Credit/Debit/Refund ach Originated
        /// >
        /// >134 - Credit/Debit/Refund ach Settled
        /// >
        /// >191 - Settled (depracated - batches are now settled on the /v2/transactionbatches endpoint)
        /// >
        /// >201 - All cc/ach Voided
        /// >
        /// >301 - All cc/ach Declined
        /// >
        /// >331 - Credit/Debit/Refund ach Charged Back
        /// >
        /// </summary>
        [JsonProperty("status_code")]
        public Models.StatusCode17Enum? StatusCode
        {
            get
            {
                return this.statusCode;
            }

            set
            {
                this.shouldSerialize["status_code"] = true;
                this.statusCode = value;
            }
        }

        /// <summary>
        /// For cc transactions, this is the id of the batch the transaction belongs to (not to be confused with batch number). This will be null for transactions that do not settle (void and authonly).
        /// </summary>
        [JsonProperty("transaction_batch_id")]
        public string TransactionBatchId
        {
            get
            {
                return this.transactionBatchId;
            }

            set
            {
                this.shouldSerialize["transaction_batch_id"] = true;
                this.transactionBatchId = value;
            }
        }

        /// <summary>
        /// Type ID - See type id section for more detail
        /// </summary>
        [JsonProperty("type_id")]
        public Models.TypeIdEnum? TypeId
        {
            get
            {
                return this.typeId;
            }

            set
            {
                this.shouldSerialize["type_id"] = true;
                this.typeId = value;
            }
        }

        /// <summary>
        /// Verbiage -Do not use verbiage to see if the transaction was approved, use status_id
        /// </summary>
        [JsonProperty("verbiage")]
        public string Verbiage
        {
            get
            {
                return this.verbiage;
            }

            set
            {
                this.shouldSerialize["verbiage"] = true;
                this.verbiage = value;
            }
        }

        /// <summary>
        /// void date
        /// </summary>
        [JsonProperty("void_date")]
        public string VoidDate
        {
            get
            {
                return this.voidDate;
            }

            set
            {
                this.shouldSerialize["void_date"] = true;
                this.voidDate = value;
            }
        }

        /// <summary>
        /// Batch
        /// </summary>
        [JsonProperty("batch")]
        public string Batch
        {
            get
            {
                return this.batch;
            }

            set
            {
                this.shouldSerialize["batch"] = true;
                this.batch = value;
            }
        }

        /// <summary>
        /// Terms Agreement
        /// </summary>
        [JsonProperty("terms_agree", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TermsAgree { get; set; }

        /// <summary>
        /// Response Message
        /// </summary>
        [JsonProperty("response_message")]
        public string ResponseMessage
        {
            get
            {
                return this.responseMessage;
            }

            set
            {
                this.shouldSerialize["response_message"] = true;
                this.responseMessage = value;
            }
        }

        /// <summary>
        /// Return Date
        /// </summary>
        [JsonProperty("return_date")]
        public string ReturnDate
        {
            get
            {
                return this.returnDate;
            }

            set
            {
                this.shouldSerialize["return_date"] = true;
                this.returnDate = value;
            }
        }

        /// <summary>
        /// How the transaction was obtained by the API.
        /// >1 - Unknown - The origination of this transaction could not be determined.
        /// >
        /// >2 - Mobile - The origination of this transaction is through the mobile application. This is always a merchant submitted payment.
        /// >
        /// >3 - Web - The origination of this transaction is through a web browser. This is always a merchant submitted payment. Examples include Virtual Terminal, Contact Charge, and Transaction Details - Run Again pages.
        /// >
        /// >4 - IVR Transaction - The origination of this transaction is over the phone. This payment is submitted by an automated system initiated by the cardholder.
        /// >
        /// >5 - Contact Statement - The orignation of this transaction is through a Vericle statement.
        /// >
        /// >6 - Contact Payment Mobile - The origination of this transaction is through the mobile application. This is always submitted by a contact user.
        /// >
        /// >7 - Contact Payment - The origination of this transaction is through a web browser. This is always submitted by a contact user.
        /// >
        /// >8 - Quick Invoice - The orignation of this transaction is through a Quick Invoice. This is typically submitted by a contact user, however the transaction can also be submitted by a merchant.
        /// >
        /// >9 - Payform - The origination of this transaction is through a Payform. This is typically a merchant submitted transaction, and is always from an internal developer.
        /// >
        /// >10 - Hosted Payment Page - The orignation of this transaction is through a Hosted Payment Page. This is typically a cardholder submitted transaction.
        /// >
        /// >11 - Emulator -  The origination of this transaction is through Auth.Net emulator. This is typically submitted through an integration to a website or a shopping cart.
        /// >
        /// >12 - Integration - The orignation of this transaction is through an integrated solution. This will always be from an external developer.
        /// >
        /// >13 - Recurring Billing - The orignation of this transaction is through a scheduled recurring payment. This payment is system-initiated based on a payment schedule that has been configured.
        /// >
        /// >14 - Recurring Secondary - This feature has not been implented yet.
        /// >
        /// >15 - Declined Recurring Email - The orignation of this transaction is through the email notification sent when a recurring payment has been declined. This is typically submitted by a cardholder.
        /// >
        /// >16 - Paylink - The orignation of this transaction is through a Paylink. This is typically submitted by a contact user, however the transaction can also be submitted by a merchant.
        /// >
        /// >17 - Elements - The origination of this transaction is through the Elements payments page. This can be a cardholder submitted or a merchant submitted transaction.
        /// >
        /// >18 - ACH Import - The origination of this transaction is through an ACH file import. This is a merchant initiated process.
        /// >
        /// </summary>
        [JsonProperty("trx_source_id")]
        public Models.TrxSourceIdEnum? TrxSourceId
        {
            get
            {
                return this.trxSourceId;
            }

            set
            {
                this.shouldSerialize["trx_source_id"] = true;
                this.trxSourceId = value;
            }
        }

        /// <summary>
        /// This field is read only for ach on transactions. Must be supplied if account_vault_id is not provided.
        /// </summary>
        [JsonProperty("routing_number")]
        public string RoutingNumber
        {
            get
            {
                return this.routingNumber;
            }

            set
            {
                this.shouldSerialize["routing_number"] = true;
                this.routingNumber = value;
            }
        }

        /// <summary>
        /// How the transaction was obtained by the API.
        /// >1 - Unknown - The origination of this transaction could not be determined.
        /// >
        /// >2 - Mobile - The origination of this transaction is through the mobile application. This is always a merchant submitted payment.
        /// >
        /// >3 - Web - The origination of this transaction is through a web browser. This is always a merchant submitted payment. Examples include Virtual Terminal, Contact Charge, and Transaction Details - Run Again pages.
        /// >
        /// >4 - IVR Transaction - The origination of this transaction is over the phone. This payment is submitted by an automated system initiated by the cardholder.
        /// >
        /// >5 - Contact Statement - The orignation of this transaction is through a Vericle statement.
        /// >
        /// >6 - Contact Payment Mobile - The origination of this transaction is through the mobile application. This is always submitted by a contact user.
        /// >
        /// >7 - Contact Payment - The origination of this transaction is through a web browser. This is always submitted by a contact user.
        /// >
        /// >8 - Quick Invoice - The orignation of this transaction is through a Quick Invoice. This is typically submitted by a contact user, however the transaction can also be submitted by a merchant.
        /// >
        /// >9 - Payform - The origination of this transaction is through a Payform. This is typically a merchant submitted transaction, and is always from an internal developer.
        /// >
        /// >10 - Hosted Payment Page - The orignation of this transaction is through a Hosted Payment Page. This is typically a cardholder submitted transaction.
        /// >
        /// >11 - Emulator -  The origination of this transaction is through Auth.Net emulator. This is typically submitted through an integration to a website or a shopping cart.
        /// >
        /// >12 - Integration - The orignation of this transaction is through an integrated solution. This will always be from an external developer.
        /// >
        /// >13 - Recurring Billing - The orignation of this transaction is through a scheduled recurring payment. This payment is system-initiated based on a payment schedule that has been configured.
        /// >
        /// >14 - Recurring Secondary - This feature has not been implented yet.
        /// >
        /// >15 - Declined Recurring Email - The orignation of this transaction is through the email notification sent when a recurring payment has been declined. This is typically submitted by a cardholder.
        /// >
        /// >16 - Paylink - The orignation of this transaction is through a Paylink. This is typically submitted by a contact user, however the transaction can also be submitted by a merchant.
        /// >
        /// >17 - Elements - The origination of this transaction is through the Elements payments page. This can be a cardholder submitted or a merchant submitted transaction.
        /// >
        /// >18 - ACH Import - The origination of this transaction is through an ACH file import. This is a merchant initiated process.
        /// >
        /// </summary>
        [JsonProperty("trx_source_code")]
        public Models.TrxSourceCodeEnum? TrxSourceCode
        {
            get
            {
                return this.trxSourceCode;
            }

            set
            {
                this.shouldSerialize["trx_source_code"] = true;
                this.trxSourceCode = value;
            }
        }

        /// <summary>
        /// Paylink Id
        /// </summary>
        [JsonProperty("paylink_id")]
        public string PaylinkId
        {
            get
            {
                return this.paylinkId;
            }

            set
            {
                this.shouldSerialize["paylink_id"] = true;
                this.paylinkId = value;
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
        /// Is Token Transaction
        /// </summary>
        [JsonProperty("is_accountvault", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsAccountvault { get; set; }

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
        public string ModifiedUserId { get; set; }

        /// <summary>
        /// Transaction Code
        /// </summary>
        [JsonProperty("transaction_code")]
        public string TransactionCode
        {
            get
            {
                return this.transactionCode;
            }

            set
            {
                this.shouldSerialize["transaction_code"] = true;
                this.transactionCode = value;
            }
        }

        /// <summary>
        /// For ACH only, this is optional and defaults to current day.
        /// </summary>
        [JsonProperty("effective_date")]
        public string EffectiveDate
        {
            get
            {
                return this.effectiveDate;
            }

            set
            {
                this.shouldSerialize["effective_date"] = true;
                this.effectiveDate = value;
            }
        }

        /// <summary>
        /// Notification Phone
        /// </summary>
        [JsonProperty("notification_phone")]
        public string NotificationPhone
        {
            get
            {
                return this.notificationPhone;
            }

            set
            {
                this.shouldSerialize["notification_phone"] = true;
                this.notificationPhone = value;
            }
        }

        /// <summary>
        /// Cavv Result
        /// </summary>
        [JsonProperty("cavv_result")]
        public string CavvResult
        {
            get
            {
                return this.cavvResult;
            }

            set
            {
                this.shouldSerialize["cavv_result"] = true;
                this.cavvResult = value;
            }
        }

        /// <summary>
        /// Recurring Flag
        /// </summary>
        [JsonProperty("recurring_flag")]
        public string RecurringFlag
        {
            get
            {
                return this.recurringFlag;
            }

            set
            {
                this.shouldSerialize["recurring_flag"] = true;
                this.recurringFlag = value;
            }
        }

        /// <summary>
        /// Is Token Transaction
        /// </summary>
        [JsonProperty("is_token", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsToken { get; set; }

        /// <summary>
        /// Installment Total
        /// </summary>
        [JsonProperty("installment_total")]
        public int? InstallmentTotal
        {
            get
            {
                return this.installmentTotal;
            }

            set
            {
                this.shouldSerialize["installment_total"] = true;
                this.installmentTotal = value;
            }
        }

        /// <summary>
        /// Installment Counter
        /// </summary>
        [JsonProperty("installment_counter")]
        public int? InstallmentCounter
        {
            get
            {
                return this.installmentCounter;
            }

            set
            {
                this.shouldSerialize["installment_counter"] = true;
                this.installmentCounter = value;
            }
        }

        /// <summary>
        /// Token ID
        /// </summary>
        [JsonProperty("account_vault_id")]
        public string AccountVaultId
        {
            get
            {
                return this.accountVaultId;
            }

            set
            {
                this.shouldSerialize["account_vault_id"] = true;
                this.accountVaultId = value;
            }
        }

        /// <summary>
        /// Hosted Payment Page Id
        /// </summary>
        [JsonProperty("hosted_payment_page_id")]
        public string HostedPaymentPageId { get; set; }

        /// <summary>
        /// Gets or sets Stan.
        /// </summary>
        [JsonProperty("stan")]
        public string Stan
        {
            get
            {
                return this.stan;
            }

            set
            {
                this.shouldSerialize["stan"] = true;
                this.stan = value;
            }
        }

        /// <summary>
        /// Currency
        /// </summary>
        [JsonProperty("currency")]
        public string Currency
        {
            get
            {
                return this.currency;
            }

            set
            {
                this.shouldSerialize["currency"] = true;
                this.currency = value;
            }
        }

        /// <summary>
        /// Card Bin
        /// </summary>
        [JsonProperty("card_bin")]
        public string CardBin
        {
            get
            {
                return this.cardBin;
            }

            set
            {
                this.shouldSerialize["card_bin"] = true;
                this.cardBin = value;
            }
        }

        /// <summary>
        /// Token Information on `expand`
        /// </summary>
        [JsonProperty("account_vault", NullValueHandling = NullValueHandling.Ignore)]
        public Models.AccountVault AccountVault { get; set; }

        /// <summary>
        /// Quick Invoice Information on `expand`
        /// </summary>
        [JsonProperty("quick_invoice", NullValueHandling = NullValueHandling.Ignore)]
        public Models.QuickInvoice QuickInvoice { get; set; }

        /// <summary>
        /// Log Email Information on `expand`
        /// </summary>
        [JsonProperty("log_emails", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.LogEmail> LogEmails { get; set; }

        /// <summary>
        /// Is Voidable Information on `expand`
        /// </summary>
        [JsonProperty("is_voidable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsVoidable { get; set; }

        /// <summary>
        /// Is Reversible Information on `expand`
        /// </summary>
        [JsonProperty("is_reversible", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsReversible { get; set; }

        /// <summary>
        /// Is Refundable Information on `expand`
        /// </summary>
        [JsonProperty("is_refundable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRefundable { get; set; }

        /// <summary>
        /// Is Competable Information on `expand`
        /// </summary>
        [JsonProperty("is_completable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsCompletable { get; set; }

        /// <summary>
        /// Is Settled Information on `expand`
        /// </summary>
        [JsonProperty("is_settled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsSettled { get; set; }

        /// <summary>
        /// User Information on `expand`
        /// </summary>
        [JsonProperty("created_user", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CreatedUser CreatedUser { get; set; }

        /// <summary>
        /// Location Information on `expand`
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Location Location { get; set; }

        /// <summary>
        /// Contact Information on `expand`
        /// </summary>
        [JsonProperty("contact", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Contact1 Contact { get; set; }

        /// <summary>
        /// Changelog Information on `expand`
        /// </summary>
        [JsonProperty("changelogs", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.Changelog> Changelogs { get; set; }

        /// <summary>
        /// Product Transaction Information on `expand`
        /// </summary>
        [JsonProperty("product_transaction", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ProductTransaction ProductTransaction { get; set; }

        /// <summary>
        /// All Tag Information on `expand`
        /// </summary>
        [JsonProperty("all_tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.AllTag> AllTags { get; set; }

        /// <summary>
        /// TagTransaction Information on `expand`
        /// </summary>
        [JsonProperty("tagTransactions", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.TagTransaction> TagTransactions { get; set; }

        /// <summary>
        /// Declined Recurring Notification Information on `expand`
        /// </summary>
        [JsonProperty("declined_recurring_notification", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DeclinedRecurringNotification DeclinedRecurringNotification { get; set; }

        /// <summary>
        /// Payment Recurring Notification Information on `expand`
        /// </summary>
        [JsonProperty("payment_recurring_notification", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentRecurringNotification PaymentRecurringNotification { get; set; }

        /// <summary>
        /// Developer Company Information on `expand`
        /// </summary>
        [JsonProperty("developer_company", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DeveloperCompany DeveloperCompany { get; set; }

        /// <summary>
        /// Terminal Information on `expand`
        /// </summary>
        [JsonProperty("terminal", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Terminal Terminal { get; set; }

        /// <summary>
        /// Hosted Payment Page Information on `expand`
        /// </summary>
        [JsonProperty("hosted_payment_page", NullValueHandling = NullValueHandling.Ignore)]
        public Models.HostedPaymentPage HostedPaymentPage { get; set; }

        /// <summary>
        /// Transaction Level3 Information on `expand`
        /// </summary>
        [JsonProperty("transaction_level3", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TransactionLevel3 TransactionLevel3 { get; set; }

        /// <summary>
        /// Developer Company Id Information on `expand`
        /// </summary>
        [JsonProperty("developer_company_id")]
        public string DeveloperCompanyId
        {
            get
            {
                return this.developerCompanyId;
            }

            set
            {
                this.shouldSerialize["developer_company_id"] = true;
                this.developerCompanyId = value;
            }
        }

        /// <summary>
        /// Transaction History Information on `expand`
        /// </summary>
        [JsonProperty("transaction_histories", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.TransactionHistory> TransactionHistories { get; set; }

        /// <summary>
        /// Surcharge Transaction Information on `expand`
        /// </summary>
        [JsonProperty("surcharge_transaction", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SurchargeTransaction SurchargeTransaction { get; set; }

        /// <summary>
        /// Surcharge Information on `expand`
        /// </summary>
        [JsonProperty("surcharge", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Surcharge Surcharge { get; set; }

        /// <summary>
        /// Signature Information on `expand`
        /// </summary>
        [JsonProperty("signature", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Signature Signature { get; set; }

        /// <summary>
        /// Reason Code Information on `expand`
        /// </summary>
        [JsonProperty("reason_code", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ReasonCode ReasonCode { get; set; }

        /// <summary>
        /// Type Information on `expand`
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Type6 Type { get; set; }

        /// <summary>
        /// Status Information on `expand`
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Status11 Status { get; set; }

        /// <summary>
        /// Transaction Batch Information on `expand`
        /// </summary>
        [JsonProperty("transaction_batch", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TransactionBatch TransactionBatch { get; set; }

        /// <summary>
        /// Transaction Split Information on `expand`
        /// </summary>
        [JsonProperty("transaction_splits", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.TransactionSplit> TransactionSplits { get; set; }

        /// <summary>
        /// Postback Log Information on `expand`
        /// </summary>
        [JsonProperty("postback_logs", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.PostbackLog> PostbackLogs { get; set; }

        /// <summary>
        /// Currency Type Information on `expand`
        /// </summary>
        [JsonProperty("currency_type", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CurrencyType CurrencyType { get; set; }

        /// <summary>
        /// Transaction Reference Information on `expand`
        /// </summary>
        [JsonProperty("transaction_references", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.TransactionReference> TransactionReferences { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"List16 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCheckinDate()
        {
            this.shouldSerialize["checkin_date"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCheckoutDate()
        {
            this.shouldSerialize["checkout_date"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetClerkNumber()
        {
            this.shouldSerialize["clerk_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetContactApiId()
        {
            this.shouldSerialize["contact_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetContactId()
        {
            this.shouldSerialize["contact_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCustomerId()
        {
            this.shouldSerialize["customer_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDescription()
        {
            this.shouldSerialize["description"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetIiasInd()
        {
            this.shouldSerialize["iias_ind"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetImageFront()
        {
            this.shouldSerialize["image_front"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetImageBack()
        {
            this.shouldSerialize["image_back"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetInstallmentNumber()
        {
            this.shouldSerialize["installment_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetInstallmentCount()
        {
            this.shouldSerialize["installment_count"] = false;
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
        public void UnsetLocationId()
        {
            this.shouldSerialize["location_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetProductTransactionId()
        {
            this.shouldSerialize["product_transaction_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetNotificationEmailAddress()
        {
            this.shouldSerialize["notification_email_address"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetOrderNumber()
        {
            this.shouldSerialize["order_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPoNumber()
        {
            this.shouldSerialize["po_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetQuickInvoiceId()
        {
            this.shouldSerialize["quick_invoice_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRecurringNumber()
        {
            this.shouldSerialize["recurring_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRoomNum()
        {
            this.shouldSerialize["room_num"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRoomRate()
        {
            this.shouldSerialize["room_rate"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSaveAccountTitle()
        {
            this.shouldSerialize["save_account_title"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSubtotalAmount()
        {
            this.shouldSerialize["subtotal_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSurchargeAmount()
        {
            this.shouldSerialize["surcharge_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTax()
        {
            this.shouldSerialize["tax"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTipAmount()
        {
            this.shouldSerialize["tip_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTransactionAmount()
        {
            this.shouldSerialize["transaction_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSecondaryAmount()
        {
            this.shouldSerialize["secondary_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTransactionApiId()
        {
            this.shouldSerialize["transaction_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTransactionC1()
        {
            this.shouldSerialize["transaction_c1"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTransactionC2()
        {
            this.shouldSerialize["transaction_c2"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTransactionC3()
        {
            this.shouldSerialize["transaction_c3"] = false;
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
        public void UnsetAccountHolderName()
        {
            this.shouldSerialize["account_holder_name"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAccountType()
        {
            this.shouldSerialize["account_type"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTokenApiId()
        {
            this.shouldSerialize["token_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTokenId()
        {
            this.shouldSerialize["token_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAchIdentifier()
        {
            this.shouldSerialize["ach_identifier"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAchSecCode()
        {
            this.shouldSerialize["ach_sec_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAuthAmount()
        {
            this.shouldSerialize["auth_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAuthCode()
        {
            this.shouldSerialize["auth_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAvs()
        {
            this.shouldSerialize["avs"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAvsEnhanced()
        {
            this.shouldSerialize["avs_enhanced"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCheckNumber()
        {
            this.shouldSerialize["check_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCustomerIp()
        {
            this.shouldSerialize["customer_ip"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCvvResponse()
        {
            this.shouldSerialize["cvv_response"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEntryModeId()
        {
            this.shouldSerialize["entry_mode_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEmvReceiptData()
        {
            this.shouldSerialize["emv_receipt_data"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFirstSix()
        {
            this.shouldSerialize["first_six"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLastFour()
        {
            this.shouldSerialize["last_four"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTerminalSerialNumber()
        {
            this.shouldSerialize["terminal_serial_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTransactionSettlementStatus()
        {
            this.shouldSerialize["transaction_settlement_status"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetChargeBackDate()
        {
            this.shouldSerialize["charge_back_date"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPar()
        {
            this.shouldSerialize["par"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReasonCodeId()
        {
            this.shouldSerialize["reason_code_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRecurringId()
        {
            this.shouldSerialize["recurring_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSettleDate()
        {
            this.shouldSerialize["settle_date"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetStatusCode()
        {
            this.shouldSerialize["status_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTransactionBatchId()
        {
            this.shouldSerialize["transaction_batch_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTypeId()
        {
            this.shouldSerialize["type_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetVerbiage()
        {
            this.shouldSerialize["verbiage"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetVoidDate()
        {
            this.shouldSerialize["void_date"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetBatch()
        {
            this.shouldSerialize["batch"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetResponseMessage()
        {
            this.shouldSerialize["response_message"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReturnDate()
        {
            this.shouldSerialize["return_date"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTrxSourceId()
        {
            this.shouldSerialize["trx_source_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRoutingNumber()
        {
            this.shouldSerialize["routing_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTrxSourceCode()
        {
            this.shouldSerialize["trx_source_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPaylinkId()
        {
            this.shouldSerialize["paylink_id"] = false;
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
        public void UnsetCreatedUserId()
        {
            this.shouldSerialize["created_user_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTransactionCode()
        {
            this.shouldSerialize["transaction_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEffectiveDate()
        {
            this.shouldSerialize["effective_date"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetNotificationPhone()
        {
            this.shouldSerialize["notification_phone"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCavvResult()
        {
            this.shouldSerialize["cavv_result"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRecurringFlag()
        {
            this.shouldSerialize["recurring_flag"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetInstallmentTotal()
        {
            this.shouldSerialize["installment_total"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetInstallmentCounter()
        {
            this.shouldSerialize["installment_counter"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAccountVaultId()
        {
            this.shouldSerialize["account_vault_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetStan()
        {
            this.shouldSerialize["stan"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCurrency()
        {
            this.shouldSerialize["currency"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCardBin()
        {
            this.shouldSerialize["card_bin"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDeveloperCompanyId()
        {
            this.shouldSerialize["developer_company_id"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCheckinDate()
        {
            return this.shouldSerialize["checkin_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCheckoutDate()
        {
            return this.shouldSerialize["checkout_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeClerkNumber()
        {
            return this.shouldSerialize["clerk_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeContactApiId()
        {
            return this.shouldSerialize["contact_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeContactId()
        {
            return this.shouldSerialize["contact_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerId()
        {
            return this.shouldSerialize["customer_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDescription()
        {
            return this.shouldSerialize["description"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIiasInd()
        {
            return this.shouldSerialize["iias_ind"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeImageFront()
        {
            return this.shouldSerialize["image_front"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeImageBack()
        {
            return this.shouldSerialize["image_back"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInstallmentNumber()
        {
            return this.shouldSerialize["installment_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInstallmentCount()
        {
            return this.shouldSerialize["installment_count"];
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
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeProductTransactionId()
        {
            return this.shouldSerialize["product_transaction_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNotificationEmailAddress()
        {
            return this.shouldSerialize["notification_email_address"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrderNumber()
        {
            return this.shouldSerialize["order_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePoNumber()
        {
            return this.shouldSerialize["po_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeQuickInvoiceId()
        {
            return this.shouldSerialize["quick_invoice_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRecurringNumber()
        {
            return this.shouldSerialize["recurring_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRoomNum()
        {
            return this.shouldSerialize["room_num"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRoomRate()
        {
            return this.shouldSerialize["room_rate"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSaveAccountTitle()
        {
            return this.shouldSerialize["save_account_title"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSubtotalAmount()
        {
            return this.shouldSerialize["subtotal_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSurchargeAmount()
        {
            return this.shouldSerialize["surcharge_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTax()
        {
            return this.shouldSerialize["tax"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTipAmount()
        {
            return this.shouldSerialize["tip_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTransactionAmount()
        {
            return this.shouldSerialize["transaction_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSecondaryAmount()
        {
            return this.shouldSerialize["secondary_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTransactionApiId()
        {
            return this.shouldSerialize["transaction_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTransactionC1()
        {
            return this.shouldSerialize["transaction_c1"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTransactionC2()
        {
            return this.shouldSerialize["transaction_c2"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTransactionC3()
        {
            return this.shouldSerialize["transaction_c3"];
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
        public bool ShouldSerializeAccountHolderName()
        {
            return this.shouldSerialize["account_holder_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountType()
        {
            return this.shouldSerialize["account_type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTokenApiId()
        {
            return this.shouldSerialize["token_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTokenId()
        {
            return this.shouldSerialize["token_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAchIdentifier()
        {
            return this.shouldSerialize["ach_identifier"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAchSecCode()
        {
            return this.shouldSerialize["ach_sec_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAuthAmount()
        {
            return this.shouldSerialize["auth_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAuthCode()
        {
            return this.shouldSerialize["auth_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAvs()
        {
            return this.shouldSerialize["avs"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAvsEnhanced()
        {
            return this.shouldSerialize["avs_enhanced"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCheckNumber()
        {
            return this.shouldSerialize["check_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerIp()
        {
            return this.shouldSerialize["customer_ip"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCvvResponse()
        {
            return this.shouldSerialize["cvv_response"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEntryModeId()
        {
            return this.shouldSerialize["entry_mode_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmvReceiptData()
        {
            return this.shouldSerialize["emv_receipt_data"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFirstSix()
        {
            return this.shouldSerialize["first_six"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLastFour()
        {
            return this.shouldSerialize["last_four"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTerminalSerialNumber()
        {
            return this.shouldSerialize["terminal_serial_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTransactionSettlementStatus()
        {
            return this.shouldSerialize["transaction_settlement_status"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeChargeBackDate()
        {
            return this.shouldSerialize["charge_back_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePar()
        {
            return this.shouldSerialize["par"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReasonCodeId()
        {
            return this.shouldSerialize["reason_code_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRecurringId()
        {
            return this.shouldSerialize["recurring_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSettleDate()
        {
            return this.shouldSerialize["settle_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStatusCode()
        {
            return this.shouldSerialize["status_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTransactionBatchId()
        {
            return this.shouldSerialize["transaction_batch_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTypeId()
        {
            return this.shouldSerialize["type_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeVerbiage()
        {
            return this.shouldSerialize["verbiage"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeVoidDate()
        {
            return this.shouldSerialize["void_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBatch()
        {
            return this.shouldSerialize["batch"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeResponseMessage()
        {
            return this.shouldSerialize["response_message"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReturnDate()
        {
            return this.shouldSerialize["return_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTrxSourceId()
        {
            return this.shouldSerialize["trx_source_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRoutingNumber()
        {
            return this.shouldSerialize["routing_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTrxSourceCode()
        {
            return this.shouldSerialize["trx_source_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaylinkId()
        {
            return this.shouldSerialize["paylink_id"];
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
        public bool ShouldSerializeCreatedUserId()
        {
            return this.shouldSerialize["created_user_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTransactionCode()
        {
            return this.shouldSerialize["transaction_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEffectiveDate()
        {
            return this.shouldSerialize["effective_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNotificationPhone()
        {
            return this.shouldSerialize["notification_phone"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCavvResult()
        {
            return this.shouldSerialize["cavv_result"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRecurringFlag()
        {
            return this.shouldSerialize["recurring_flag"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInstallmentTotal()
        {
            return this.shouldSerialize["installment_total"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInstallmentCounter()
        {
            return this.shouldSerialize["installment_counter"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountVaultId()
        {
            return this.shouldSerialize["account_vault_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStan()
        {
            return this.shouldSerialize["stan"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCurrency()
        {
            return this.shouldSerialize["currency"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCardBin()
        {
            return this.shouldSerialize["card_bin"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDeveloperCompanyId()
        {
            return this.shouldSerialize["developer_company_id"];
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
            return obj is List16 other &&                ((this.AdditionalAmounts == null && other.AdditionalAmounts == null) || (this.AdditionalAmounts?.Equals(other.AdditionalAmounts) == true)) &&
                ((this.BillingAddress == null && other.BillingAddress == null) || (this.BillingAddress?.Equals(other.BillingAddress) == true)) &&
                ((this.CheckinDate == null && other.CheckinDate == null) || (this.CheckinDate?.Equals(other.CheckinDate) == true)) &&
                ((this.CheckoutDate == null && other.CheckoutDate == null) || (this.CheckoutDate?.Equals(other.CheckoutDate) == true)) &&
                ((this.ClerkNumber == null && other.ClerkNumber == null) || (this.ClerkNumber?.Equals(other.ClerkNumber) == true)) &&
                ((this.ContactApiId == null && other.ContactApiId == null) || (this.ContactApiId?.Equals(other.ContactApiId) == true)) &&
                ((this.ContactId == null && other.ContactId == null) || (this.ContactId?.Equals(other.ContactId) == true)) &&
                ((this.CustomData == null && other.CustomData == null) || (this.CustomData?.Equals(other.CustomData) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.IiasInd == null && other.IiasInd == null) || (this.IiasInd?.Equals(other.IiasInd) == true)) &&
                ((this.ImageFront == null && other.ImageFront == null) || (this.ImageFront?.Equals(other.ImageFront) == true)) &&
                ((this.ImageBack == null && other.ImageBack == null) || (this.ImageBack?.Equals(other.ImageBack) == true)) &&
                ((this.Installment == null && other.Installment == null) || (this.Installment?.Equals(other.Installment) == true)) &&
                ((this.InstallmentNumber == null && other.InstallmentNumber == null) || (this.InstallmentNumber?.Equals(other.InstallmentNumber) == true)) &&
                ((this.InstallmentCount == null && other.InstallmentCount == null) || (this.InstallmentCount?.Equals(other.InstallmentCount) == true)) &&
                ((this.LocationApiId == null && other.LocationApiId == null) || (this.LocationApiId?.Equals(other.LocationApiId) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.ProductTransactionId == null && other.ProductTransactionId == null) || (this.ProductTransactionId?.Equals(other.ProductTransactionId) == true)) &&
                ((this.AdvanceDeposit == null && other.AdvanceDeposit == null) || (this.AdvanceDeposit?.Equals(other.AdvanceDeposit) == true)) &&
                ((this.NoShow == null && other.NoShow == null) || (this.NoShow?.Equals(other.NoShow) == true)) &&
                ((this.NotificationEmailAddress == null && other.NotificationEmailAddress == null) || (this.NotificationEmailAddress?.Equals(other.NotificationEmailAddress) == true)) &&
                ((this.OrderNumber == null && other.OrderNumber == null) || (this.OrderNumber?.Equals(other.OrderNumber) == true)) &&
                ((this.PoNumber == null && other.PoNumber == null) || (this.PoNumber?.Equals(other.PoNumber) == true)) &&
                ((this.QuickInvoiceId == null && other.QuickInvoiceId == null) || (this.QuickInvoiceId?.Equals(other.QuickInvoiceId) == true)) &&
                ((this.Recurring == null && other.Recurring == null) || (this.Recurring?.Equals(other.Recurring) == true)) &&
                ((this.RecurringNumber == null && other.RecurringNumber == null) || (this.RecurringNumber?.Equals(other.RecurringNumber) == true)) &&
                ((this.RoomNum == null && other.RoomNum == null) || (this.RoomNum?.Equals(other.RoomNum) == true)) &&
                ((this.RoomRate == null && other.RoomRate == null) || (this.RoomRate?.Equals(other.RoomRate) == true)) &&
                ((this.SaveAccount == null && other.SaveAccount == null) || (this.SaveAccount?.Equals(other.SaveAccount) == true)) &&
                ((this.SaveAccountTitle == null && other.SaveAccountTitle == null) || (this.SaveAccountTitle?.Equals(other.SaveAccountTitle) == true)) &&
                ((this.SubtotalAmount == null && other.SubtotalAmount == null) || (this.SubtotalAmount?.Equals(other.SubtotalAmount) == true)) &&
                ((this.SurchargeAmount == null && other.SurchargeAmount == null) || (this.SurchargeAmount?.Equals(other.SurchargeAmount) == true)) &&
                ((this.Tags == null && other.Tags == null) || (this.Tags?.Equals(other.Tags) == true)) &&
                ((this.Tax == null && other.Tax == null) || (this.Tax?.Equals(other.Tax) == true)) &&
                ((this.TipAmount == null && other.TipAmount == null) || (this.TipAmount?.Equals(other.TipAmount) == true)) &&
                ((this.TransactionAmount == null && other.TransactionAmount == null) || (this.TransactionAmount?.Equals(other.TransactionAmount) == true)) &&
                ((this.SecondaryAmount == null && other.SecondaryAmount == null) || (this.SecondaryAmount?.Equals(other.SecondaryAmount) == true)) &&
                ((this.TransactionApiId == null && other.TransactionApiId == null) || (this.TransactionApiId?.Equals(other.TransactionApiId) == true)) &&
                ((this.TransactionC1 == null && other.TransactionC1 == null) || (this.TransactionC1?.Equals(other.TransactionC1) == true)) &&
                ((this.TransactionC2 == null && other.TransactionC2 == null) || (this.TransactionC2?.Equals(other.TransactionC2) == true)) &&
                ((this.TransactionC3 == null && other.TransactionC3 == null) || (this.TransactionC3?.Equals(other.TransactionC3) == true)) &&
                ((this.BankFundedOnlyOverride == null && other.BankFundedOnlyOverride == null) || (this.BankFundedOnlyOverride?.Equals(other.BankFundedOnlyOverride) == true)) &&
                ((this.AllowPartialAuthorizationOverride == null && other.AllowPartialAuthorizationOverride == null) || (this.AllowPartialAuthorizationOverride?.Equals(other.AllowPartialAuthorizationOverride) == true)) &&
                ((this.AutoDeclineCvvOverride == null && other.AutoDeclineCvvOverride == null) || (this.AutoDeclineCvvOverride?.Equals(other.AutoDeclineCvvOverride) == true)) &&
                ((this.AutoDeclineStreetOverride == null && other.AutoDeclineStreetOverride == null) || (this.AutoDeclineStreetOverride?.Equals(other.AutoDeclineStreetOverride) == true)) &&
                ((this.AutoDeclineZipOverride == null && other.AutoDeclineZipOverride == null) || (this.AutoDeclineZipOverride?.Equals(other.AutoDeclineZipOverride) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                ((this.TerminalId == null && other.TerminalId == null) || (this.TerminalId?.Equals(other.TerminalId) == true)) &&
                ((this.AccountHolderName == null && other.AccountHolderName == null) || (this.AccountHolderName?.Equals(other.AccountHolderName) == true)) &&
                ((this.AccountType == null && other.AccountType == null) || (this.AccountType?.Equals(other.AccountType) == true)) &&
                ((this.TokenApiId == null && other.TokenApiId == null) || (this.TokenApiId?.Equals(other.TokenApiId) == true)) &&
                ((this.TokenId == null && other.TokenId == null) || (this.TokenId?.Equals(other.TokenId) == true)) &&
                ((this.AchIdentifier == null && other.AchIdentifier == null) || (this.AchIdentifier?.Equals(other.AchIdentifier) == true)) &&
                ((this.AchSecCode == null && other.AchSecCode == null) || (this.AchSecCode?.Equals(other.AchSecCode) == true)) &&
                ((this.AuthAmount == null && other.AuthAmount == null) || (this.AuthAmount?.Equals(other.AuthAmount) == true)) &&
                ((this.AuthCode == null && other.AuthCode == null) || (this.AuthCode?.Equals(other.AuthCode) == true)) &&
                ((this.Avs == null && other.Avs == null) || (this.Avs?.Equals(other.Avs) == true)) &&
                ((this.AvsEnhanced == null && other.AvsEnhanced == null) || (this.AvsEnhanced?.Equals(other.AvsEnhanced) == true)) &&
                ((this.CardholderPresent == null && other.CardholderPresent == null) || (this.CardholderPresent?.Equals(other.CardholderPresent) == true)) &&
                ((this.CardPresent == null && other.CardPresent == null) || (this.CardPresent?.Equals(other.CardPresent) == true)) &&
                ((this.CheckNumber == null && other.CheckNumber == null) || (this.CheckNumber?.Equals(other.CheckNumber) == true)) &&
                ((this.CustomerIp == null && other.CustomerIp == null) || (this.CustomerIp?.Equals(other.CustomerIp) == true)) &&
                ((this.CvvResponse == null && other.CvvResponse == null) || (this.CvvResponse?.Equals(other.CvvResponse) == true)) &&
                ((this.EntryModeId == null && other.EntryModeId == null) || (this.EntryModeId?.Equals(other.EntryModeId) == true)) &&
                ((this.EmvReceiptData == null && other.EmvReceiptData == null) || (this.EmvReceiptData?.Equals(other.EmvReceiptData) == true)) &&
                ((this.FirstSix == null && other.FirstSix == null) || (this.FirstSix?.Equals(other.FirstSix) == true)) &&
                ((this.LastFour == null && other.LastFour == null) || (this.LastFour?.Equals(other.LastFour) == true)) &&
                this.PaymentMethod.Equals(other.PaymentMethod) &&
                ((this.TerminalSerialNumber == null && other.TerminalSerialNumber == null) || (this.TerminalSerialNumber?.Equals(other.TerminalSerialNumber) == true)) &&
                ((this.TransactionSettlementStatus == null && other.TransactionSettlementStatus == null) || (this.TransactionSettlementStatus?.Equals(other.TransactionSettlementStatus) == true)) &&
                ((this.ChargeBackDate == null && other.ChargeBackDate == null) || (this.ChargeBackDate?.Equals(other.ChargeBackDate) == true)) &&
                ((this.IsRecurring == null && other.IsRecurring == null) || (this.IsRecurring?.Equals(other.IsRecurring) == true)) &&
                ((this.NotificationEmailSent == null && other.NotificationEmailSent == null) || (this.NotificationEmailSent?.Equals(other.NotificationEmailSent) == true)) &&
                ((this.Par == null && other.Par == null) || (this.Par?.Equals(other.Par) == true)) &&
                ((this.ReasonCodeId == null && other.ReasonCodeId == null) || (this.ReasonCodeId?.Equals(other.ReasonCodeId) == true)) &&
                ((this.RecurringId == null && other.RecurringId == null) || (this.RecurringId?.Equals(other.RecurringId) == true)) &&
                ((this.SettleDate == null && other.SettleDate == null) || (this.SettleDate?.Equals(other.SettleDate) == true)) &&
                ((this.StatusCode == null && other.StatusCode == null) || (this.StatusCode?.Equals(other.StatusCode) == true)) &&
                ((this.TransactionBatchId == null && other.TransactionBatchId == null) || (this.TransactionBatchId?.Equals(other.TransactionBatchId) == true)) &&
                ((this.TypeId == null && other.TypeId == null) || (this.TypeId?.Equals(other.TypeId) == true)) &&
                ((this.Verbiage == null && other.Verbiage == null) || (this.Verbiage?.Equals(other.Verbiage) == true)) &&
                ((this.VoidDate == null && other.VoidDate == null) || (this.VoidDate?.Equals(other.VoidDate) == true)) &&
                ((this.Batch == null && other.Batch == null) || (this.Batch?.Equals(other.Batch) == true)) &&
                ((this.TermsAgree == null && other.TermsAgree == null) || (this.TermsAgree?.Equals(other.TermsAgree) == true)) &&
                ((this.ResponseMessage == null && other.ResponseMessage == null) || (this.ResponseMessage?.Equals(other.ResponseMessage) == true)) &&
                ((this.ReturnDate == null && other.ReturnDate == null) || (this.ReturnDate?.Equals(other.ReturnDate) == true)) &&
                ((this.TrxSourceId == null && other.TrxSourceId == null) || (this.TrxSourceId?.Equals(other.TrxSourceId) == true)) &&
                ((this.RoutingNumber == null && other.RoutingNumber == null) || (this.RoutingNumber?.Equals(other.RoutingNumber) == true)) &&
                ((this.TrxSourceCode == null && other.TrxSourceCode == null) || (this.TrxSourceCode?.Equals(other.TrxSourceCode) == true)) &&
                ((this.PaylinkId == null && other.PaylinkId == null) || (this.PaylinkId?.Equals(other.PaylinkId) == true)) &&
                ((this.CurrencyCode == null && other.CurrencyCode == null) || (this.CurrencyCode?.Equals(other.CurrencyCode) == true)) &&
                ((this.IsAccountvault == null && other.IsAccountvault == null) || (this.IsAccountvault?.Equals(other.IsAccountvault) == true)) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true)) &&
                ((this.ModifiedUserId == null && other.ModifiedUserId == null) || (this.ModifiedUserId?.Equals(other.ModifiedUserId) == true)) &&
                ((this.TransactionCode == null && other.TransactionCode == null) || (this.TransactionCode?.Equals(other.TransactionCode) == true)) &&
                ((this.EffectiveDate == null && other.EffectiveDate == null) || (this.EffectiveDate?.Equals(other.EffectiveDate) == true)) &&
                ((this.NotificationPhone == null && other.NotificationPhone == null) || (this.NotificationPhone?.Equals(other.NotificationPhone) == true)) &&
                ((this.CavvResult == null && other.CavvResult == null) || (this.CavvResult?.Equals(other.CavvResult) == true)) &&
                ((this.RecurringFlag == null && other.RecurringFlag == null) || (this.RecurringFlag?.Equals(other.RecurringFlag) == true)) &&
                ((this.IsToken == null && other.IsToken == null) || (this.IsToken?.Equals(other.IsToken) == true)) &&
                ((this.InstallmentTotal == null && other.InstallmentTotal == null) || (this.InstallmentTotal?.Equals(other.InstallmentTotal) == true)) &&
                ((this.InstallmentCounter == null && other.InstallmentCounter == null) || (this.InstallmentCounter?.Equals(other.InstallmentCounter) == true)) &&
                ((this.AccountVaultId == null && other.AccountVaultId == null) || (this.AccountVaultId?.Equals(other.AccountVaultId) == true)) &&
                ((this.HostedPaymentPageId == null && other.HostedPaymentPageId == null) || (this.HostedPaymentPageId?.Equals(other.HostedPaymentPageId) == true)) &&
                ((this.Stan == null && other.Stan == null) || (this.Stan?.Equals(other.Stan) == true)) &&
                ((this.Currency == null && other.Currency == null) || (this.Currency?.Equals(other.Currency) == true)) &&
                ((this.CardBin == null && other.CardBin == null) || (this.CardBin?.Equals(other.CardBin) == true)) &&
                ((this.AccountVault == null && other.AccountVault == null) || (this.AccountVault?.Equals(other.AccountVault) == true)) &&
                ((this.QuickInvoice == null && other.QuickInvoice == null) || (this.QuickInvoice?.Equals(other.QuickInvoice) == true)) &&
                ((this.LogEmails == null && other.LogEmails == null) || (this.LogEmails?.Equals(other.LogEmails) == true)) &&
                ((this.IsVoidable == null && other.IsVoidable == null) || (this.IsVoidable?.Equals(other.IsVoidable) == true)) &&
                ((this.IsReversible == null && other.IsReversible == null) || (this.IsReversible?.Equals(other.IsReversible) == true)) &&
                ((this.IsRefundable == null && other.IsRefundable == null) || (this.IsRefundable?.Equals(other.IsRefundable) == true)) &&
                ((this.IsCompletable == null && other.IsCompletable == null) || (this.IsCompletable?.Equals(other.IsCompletable) == true)) &&
                ((this.IsSettled == null && other.IsSettled == null) || (this.IsSettled?.Equals(other.IsSettled) == true)) &&
                ((this.CreatedUser == null && other.CreatedUser == null) || (this.CreatedUser?.Equals(other.CreatedUser) == true)) &&
                ((this.Location == null && other.Location == null) || (this.Location?.Equals(other.Location) == true)) &&
                ((this.Contact == null && other.Contact == null) || (this.Contact?.Equals(other.Contact) == true)) &&
                ((this.Changelogs == null && other.Changelogs == null) || (this.Changelogs?.Equals(other.Changelogs) == true)) &&
                ((this.ProductTransaction == null && other.ProductTransaction == null) || (this.ProductTransaction?.Equals(other.ProductTransaction) == true)) &&
                ((this.AllTags == null && other.AllTags == null) || (this.AllTags?.Equals(other.AllTags) == true)) &&
                ((this.TagTransactions == null && other.TagTransactions == null) || (this.TagTransactions?.Equals(other.TagTransactions) == true)) &&
                ((this.DeclinedRecurringNotification == null && other.DeclinedRecurringNotification == null) || (this.DeclinedRecurringNotification?.Equals(other.DeclinedRecurringNotification) == true)) &&
                ((this.PaymentRecurringNotification == null && other.PaymentRecurringNotification == null) || (this.PaymentRecurringNotification?.Equals(other.PaymentRecurringNotification) == true)) &&
                ((this.DeveloperCompany == null && other.DeveloperCompany == null) || (this.DeveloperCompany?.Equals(other.DeveloperCompany) == true)) &&
                ((this.Terminal == null && other.Terminal == null) || (this.Terminal?.Equals(other.Terminal) == true)) &&
                ((this.HostedPaymentPage == null && other.HostedPaymentPage == null) || (this.HostedPaymentPage?.Equals(other.HostedPaymentPage) == true)) &&
                ((this.TransactionLevel3 == null && other.TransactionLevel3 == null) || (this.TransactionLevel3?.Equals(other.TransactionLevel3) == true)) &&
                ((this.DeveloperCompanyId == null && other.DeveloperCompanyId == null) || (this.DeveloperCompanyId?.Equals(other.DeveloperCompanyId) == true)) &&
                ((this.TransactionHistories == null && other.TransactionHistories == null) || (this.TransactionHistories?.Equals(other.TransactionHistories) == true)) &&
                ((this.SurchargeTransaction == null && other.SurchargeTransaction == null) || (this.SurchargeTransaction?.Equals(other.SurchargeTransaction) == true)) &&
                ((this.Surcharge == null && other.Surcharge == null) || (this.Surcharge?.Equals(other.Surcharge) == true)) &&
                ((this.Signature == null && other.Signature == null) || (this.Signature?.Equals(other.Signature) == true)) &&
                ((this.ReasonCode == null && other.ReasonCode == null) || (this.ReasonCode?.Equals(other.ReasonCode) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.TransactionBatch == null && other.TransactionBatch == null) || (this.TransactionBatch?.Equals(other.TransactionBatch) == true)) &&
                ((this.TransactionSplits == null && other.TransactionSplits == null) || (this.TransactionSplits?.Equals(other.TransactionSplits) == true)) &&
                ((this.PostbackLogs == null && other.PostbackLogs == null) || (this.PostbackLogs?.Equals(other.PostbackLogs) == true)) &&
                ((this.CurrencyType == null && other.CurrencyType == null) || (this.CurrencyType?.Equals(other.CurrencyType) == true)) &&
                ((this.TransactionReferences == null && other.TransactionReferences == null) || (this.TransactionReferences?.Equals(other.TransactionReferences) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AdditionalAmounts = {(this.AdditionalAmounts == null ? "null" : $"[{string.Join(", ", this.AdditionalAmounts)} ]")}");
            toStringOutput.Add($"this.BillingAddress = {(this.BillingAddress == null ? "null" : this.BillingAddress.ToString())}");
            toStringOutput.Add($"this.CheckinDate = {(this.CheckinDate == null ? "null" : this.CheckinDate)}");
            toStringOutput.Add($"this.CheckoutDate = {(this.CheckoutDate == null ? "null" : this.CheckoutDate)}");
            toStringOutput.Add($"this.ClerkNumber = {(this.ClerkNumber == null ? "null" : this.ClerkNumber)}");
            toStringOutput.Add($"this.ContactApiId = {(this.ContactApiId == null ? "null" : this.ContactApiId)}");
            toStringOutput.Add($"this.ContactId = {(this.ContactId == null ? "null" : this.ContactId)}");
            toStringOutput.Add($"CustomData = {(this.CustomData == null ? "null" : this.CustomData.ToString())}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description)}");
            toStringOutput.Add($"this.IiasInd = {(this.IiasInd == null ? "null" : this.IiasInd.ToString())}");
            toStringOutput.Add($"this.ImageFront = {(this.ImageFront == null ? "null" : this.ImageFront)}");
            toStringOutput.Add($"this.ImageBack = {(this.ImageBack == null ? "null" : this.ImageBack)}");
            toStringOutput.Add($"this.Installment = {(this.Installment == null ? "null" : this.Installment.ToString())}");
            toStringOutput.Add($"this.InstallmentNumber = {(this.InstallmentNumber == null ? "null" : this.InstallmentNumber.ToString())}");
            toStringOutput.Add($"this.InstallmentCount = {(this.InstallmentCount == null ? "null" : this.InstallmentCount.ToString())}");
            toStringOutput.Add($"this.LocationApiId = {(this.LocationApiId == null ? "null" : this.LocationApiId)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.ProductTransactionId = {(this.ProductTransactionId == null ? "null" : this.ProductTransactionId)}");
            toStringOutput.Add($"this.AdvanceDeposit = {(this.AdvanceDeposit == null ? "null" : this.AdvanceDeposit.ToString())}");
            toStringOutput.Add($"this.NoShow = {(this.NoShow == null ? "null" : this.NoShow.ToString())}");
            toStringOutput.Add($"this.NotificationEmailAddress = {(this.NotificationEmailAddress == null ? "null" : this.NotificationEmailAddress)}");
            toStringOutput.Add($"this.OrderNumber = {(this.OrderNumber == null ? "null" : this.OrderNumber)}");
            toStringOutput.Add($"this.PoNumber = {(this.PoNumber == null ? "null" : this.PoNumber)}");
            toStringOutput.Add($"this.QuickInvoiceId = {(this.QuickInvoiceId == null ? "null" : this.QuickInvoiceId)}");
            toStringOutput.Add($"this.Recurring = {(this.Recurring == null ? "null" : this.Recurring.ToString())}");
            toStringOutput.Add($"this.RecurringNumber = {(this.RecurringNumber == null ? "null" : this.RecurringNumber.ToString())}");
            toStringOutput.Add($"this.RoomNum = {(this.RoomNum == null ? "null" : this.RoomNum)}");
            toStringOutput.Add($"this.RoomRate = {(this.RoomRate == null ? "null" : this.RoomRate.ToString())}");
            toStringOutput.Add($"this.SaveAccount = {(this.SaveAccount == null ? "null" : this.SaveAccount.ToString())}");
            toStringOutput.Add($"this.SaveAccountTitle = {(this.SaveAccountTitle == null ? "null" : this.SaveAccountTitle)}");
            toStringOutput.Add($"this.SubtotalAmount = {(this.SubtotalAmount == null ? "null" : this.SubtotalAmount.ToString())}");
            toStringOutput.Add($"this.SurchargeAmount = {(this.SurchargeAmount == null ? "null" : this.SurchargeAmount.ToString())}");
            toStringOutput.Add($"this.Tags = {(this.Tags == null ? "null" : $"[{string.Join(", ", this.Tags)} ]")}");
            toStringOutput.Add($"this.Tax = {(this.Tax == null ? "null" : this.Tax.ToString())}");
            toStringOutput.Add($"this.TipAmount = {(this.TipAmount == null ? "null" : this.TipAmount.ToString())}");
            toStringOutput.Add($"this.TransactionAmount = {(this.TransactionAmount == null ? "null" : this.TransactionAmount.ToString())}");
            toStringOutput.Add($"this.SecondaryAmount = {(this.SecondaryAmount == null ? "null" : this.SecondaryAmount.ToString())}");
            toStringOutput.Add($"this.TransactionApiId = {(this.TransactionApiId == null ? "null" : this.TransactionApiId)}");
            toStringOutput.Add($"this.TransactionC1 = {(this.TransactionC1 == null ? "null" : this.TransactionC1)}");
            toStringOutput.Add($"this.TransactionC2 = {(this.TransactionC2 == null ? "null" : this.TransactionC2)}");
            toStringOutput.Add($"this.TransactionC3 = {(this.TransactionC3 == null ? "null" : this.TransactionC3)}");
            toStringOutput.Add($"this.BankFundedOnlyOverride = {(this.BankFundedOnlyOverride == null ? "null" : this.BankFundedOnlyOverride.ToString())}");
            toStringOutput.Add($"this.AllowPartialAuthorizationOverride = {(this.AllowPartialAuthorizationOverride == null ? "null" : this.AllowPartialAuthorizationOverride.ToString())}");
            toStringOutput.Add($"this.AutoDeclineCvvOverride = {(this.AutoDeclineCvvOverride == null ? "null" : this.AutoDeclineCvvOverride.ToString())}");
            toStringOutput.Add($"this.AutoDeclineStreetOverride = {(this.AutoDeclineStreetOverride == null ? "null" : this.AutoDeclineStreetOverride.ToString())}");
            toStringOutput.Add($"this.AutoDeclineZipOverride = {(this.AutoDeclineZipOverride == null ? "null" : this.AutoDeclineZipOverride.ToString())}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.TerminalId = {(this.TerminalId == null ? "null" : this.TerminalId)}");
            toStringOutput.Add($"this.AccountHolderName = {(this.AccountHolderName == null ? "null" : this.AccountHolderName)}");
            toStringOutput.Add($"this.AccountType = {(this.AccountType == null ? "null" : this.AccountType)}");
            toStringOutput.Add($"this.TokenApiId = {(this.TokenApiId == null ? "null" : this.TokenApiId)}");
            toStringOutput.Add($"this.TokenId = {(this.TokenId == null ? "null" : this.TokenId)}");
            toStringOutput.Add($"this.AchIdentifier = {(this.AchIdentifier == null ? "null" : this.AchIdentifier)}");
            toStringOutput.Add($"this.AchSecCode = {(this.AchSecCode == null ? "null" : this.AchSecCode.ToString())}");
            toStringOutput.Add($"this.AuthAmount = {(this.AuthAmount == null ? "null" : this.AuthAmount.ToString())}");
            toStringOutput.Add($"this.AuthCode = {(this.AuthCode == null ? "null" : this.AuthCode)}");
            toStringOutput.Add($"this.Avs = {(this.Avs == null ? "null" : this.Avs.ToString())}");
            toStringOutput.Add($"this.AvsEnhanced = {(this.AvsEnhanced == null ? "null" : this.AvsEnhanced)}");
            toStringOutput.Add($"this.CardholderPresent = {(this.CardholderPresent == null ? "null" : this.CardholderPresent.ToString())}");
            toStringOutput.Add($"this.CardPresent = {(this.CardPresent == null ? "null" : this.CardPresent.ToString())}");
            toStringOutput.Add($"this.CheckNumber = {(this.CheckNumber == null ? "null" : this.CheckNumber)}");
            toStringOutput.Add($"this.CustomerIp = {(this.CustomerIp == null ? "null" : this.CustomerIp)}");
            toStringOutput.Add($"this.CvvResponse = {(this.CvvResponse == null ? "null" : this.CvvResponse)}");
            toStringOutput.Add($"this.EntryModeId = {(this.EntryModeId == null ? "null" : this.EntryModeId.ToString())}");
            toStringOutput.Add($"this.EmvReceiptData = {(this.EmvReceiptData == null ? "null" : this.EmvReceiptData.ToString())}");
            toStringOutput.Add($"this.FirstSix = {(this.FirstSix == null ? "null" : this.FirstSix)}");
            toStringOutput.Add($"this.LastFour = {(this.LastFour == null ? "null" : this.LastFour)}");
            toStringOutput.Add($"this.PaymentMethod = {this.PaymentMethod}");
            toStringOutput.Add($"this.TerminalSerialNumber = {(this.TerminalSerialNumber == null ? "null" : this.TerminalSerialNumber)}");
            toStringOutput.Add($"this.TransactionSettlementStatus = {(this.TransactionSettlementStatus == null ? "null" : this.TransactionSettlementStatus)}");
            toStringOutput.Add($"this.ChargeBackDate = {(this.ChargeBackDate == null ? "null" : this.ChargeBackDate)}");
            toStringOutput.Add($"this.IsRecurring = {(this.IsRecurring == null ? "null" : this.IsRecurring.ToString())}");
            toStringOutput.Add($"this.NotificationEmailSent = {(this.NotificationEmailSent == null ? "null" : this.NotificationEmailSent.ToString())}");
            toStringOutput.Add($"this.Par = {(this.Par == null ? "null" : this.Par)}");
            toStringOutput.Add($"this.ReasonCodeId = {(this.ReasonCodeId == null ? "null" : this.ReasonCodeId.ToString())}");
            toStringOutput.Add($"this.RecurringId = {(this.RecurringId == null ? "null" : this.RecurringId)}");
            toStringOutput.Add($"this.SettleDate = {(this.SettleDate == null ? "null" : this.SettleDate)}");
            toStringOutput.Add($"this.StatusCode = {(this.StatusCode == null ? "null" : this.StatusCode.ToString())}");
            toStringOutput.Add($"this.TransactionBatchId = {(this.TransactionBatchId == null ? "null" : this.TransactionBatchId)}");
            toStringOutput.Add($"this.TypeId = {(this.TypeId == null ? "null" : this.TypeId.ToString())}");
            toStringOutput.Add($"this.Verbiage = {(this.Verbiage == null ? "null" : this.Verbiage)}");
            toStringOutput.Add($"this.VoidDate = {(this.VoidDate == null ? "null" : this.VoidDate)}");
            toStringOutput.Add($"this.Batch = {(this.Batch == null ? "null" : this.Batch)}");
            toStringOutput.Add($"this.TermsAgree = {(this.TermsAgree == null ? "null" : this.TermsAgree.ToString())}");
            toStringOutput.Add($"this.ResponseMessage = {(this.ResponseMessage == null ? "null" : this.ResponseMessage)}");
            toStringOutput.Add($"this.ReturnDate = {(this.ReturnDate == null ? "null" : this.ReturnDate)}");
            toStringOutput.Add($"this.TrxSourceId = {(this.TrxSourceId == null ? "null" : this.TrxSourceId.ToString())}");
            toStringOutput.Add($"this.RoutingNumber = {(this.RoutingNumber == null ? "null" : this.RoutingNumber)}");
            toStringOutput.Add($"this.TrxSourceCode = {(this.TrxSourceCode == null ? "null" : this.TrxSourceCode.ToString())}");
            toStringOutput.Add($"this.PaylinkId = {(this.PaylinkId == null ? "null" : this.PaylinkId)}");
            toStringOutput.Add($"this.CurrencyCode = {(this.CurrencyCode == null ? "null" : this.CurrencyCode.ToString())}");
            toStringOutput.Add($"this.IsAccountvault = {(this.IsAccountvault == null ? "null" : this.IsAccountvault.ToString())}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.ModifiedUserId = {(this.ModifiedUserId == null ? "null" : this.ModifiedUserId)}");
            toStringOutput.Add($"this.TransactionCode = {(this.TransactionCode == null ? "null" : this.TransactionCode)}");
            toStringOutput.Add($"this.EffectiveDate = {(this.EffectiveDate == null ? "null" : this.EffectiveDate)}");
            toStringOutput.Add($"this.NotificationPhone = {(this.NotificationPhone == null ? "null" : this.NotificationPhone)}");
            toStringOutput.Add($"this.CavvResult = {(this.CavvResult == null ? "null" : this.CavvResult)}");
            toStringOutput.Add($"this.RecurringFlag = {(this.RecurringFlag == null ? "null" : this.RecurringFlag)}");
            toStringOutput.Add($"this.IsToken = {(this.IsToken == null ? "null" : this.IsToken.ToString())}");
            toStringOutput.Add($"this.InstallmentTotal = {(this.InstallmentTotal == null ? "null" : this.InstallmentTotal.ToString())}");
            toStringOutput.Add($"this.InstallmentCounter = {(this.InstallmentCounter == null ? "null" : this.InstallmentCounter.ToString())}");
            toStringOutput.Add($"this.AccountVaultId = {(this.AccountVaultId == null ? "null" : this.AccountVaultId)}");
            toStringOutput.Add($"this.HostedPaymentPageId = {(this.HostedPaymentPageId == null ? "null" : this.HostedPaymentPageId)}");
            toStringOutput.Add($"this.Stan = {(this.Stan == null ? "null" : this.Stan)}");
            toStringOutput.Add($"this.Currency = {(this.Currency == null ? "null" : this.Currency)}");
            toStringOutput.Add($"this.CardBin = {(this.CardBin == null ? "null" : this.CardBin)}");
            toStringOutput.Add($"this.AccountVault = {(this.AccountVault == null ? "null" : this.AccountVault.ToString())}");
            toStringOutput.Add($"this.QuickInvoice = {(this.QuickInvoice == null ? "null" : this.QuickInvoice.ToString())}");
            toStringOutput.Add($"this.LogEmails = {(this.LogEmails == null ? "null" : $"[{string.Join(", ", this.LogEmails)} ]")}");
            toStringOutput.Add($"this.IsVoidable = {(this.IsVoidable == null ? "null" : this.IsVoidable.ToString())}");
            toStringOutput.Add($"this.IsReversible = {(this.IsReversible == null ? "null" : this.IsReversible.ToString())}");
            toStringOutput.Add($"this.IsRefundable = {(this.IsRefundable == null ? "null" : this.IsRefundable.ToString())}");
            toStringOutput.Add($"this.IsCompletable = {(this.IsCompletable == null ? "null" : this.IsCompletable.ToString())}");
            toStringOutput.Add($"this.IsSettled = {(this.IsSettled == null ? "null" : this.IsSettled.ToString())}");
            toStringOutput.Add($"this.CreatedUser = {(this.CreatedUser == null ? "null" : this.CreatedUser.ToString())}");
            toStringOutput.Add($"this.Location = {(this.Location == null ? "null" : this.Location.ToString())}");
            toStringOutput.Add($"this.Contact = {(this.Contact == null ? "null" : this.Contact.ToString())}");
            toStringOutput.Add($"this.Changelogs = {(this.Changelogs == null ? "null" : $"[{string.Join(", ", this.Changelogs)} ]")}");
            toStringOutput.Add($"this.ProductTransaction = {(this.ProductTransaction == null ? "null" : this.ProductTransaction.ToString())}");
            toStringOutput.Add($"this.AllTags = {(this.AllTags == null ? "null" : $"[{string.Join(", ", this.AllTags)} ]")}");
            toStringOutput.Add($"this.TagTransactions = {(this.TagTransactions == null ? "null" : $"[{string.Join(", ", this.TagTransactions)} ]")}");
            toStringOutput.Add($"this.DeclinedRecurringNotification = {(this.DeclinedRecurringNotification == null ? "null" : this.DeclinedRecurringNotification.ToString())}");
            toStringOutput.Add($"this.PaymentRecurringNotification = {(this.PaymentRecurringNotification == null ? "null" : this.PaymentRecurringNotification.ToString())}");
            toStringOutput.Add($"this.DeveloperCompany = {(this.DeveloperCompany == null ? "null" : this.DeveloperCompany.ToString())}");
            toStringOutput.Add($"this.Terminal = {(this.Terminal == null ? "null" : this.Terminal.ToString())}");
            toStringOutput.Add($"this.HostedPaymentPage = {(this.HostedPaymentPage == null ? "null" : this.HostedPaymentPage.ToString())}");
            toStringOutput.Add($"this.TransactionLevel3 = {(this.TransactionLevel3 == null ? "null" : this.TransactionLevel3.ToString())}");
            toStringOutput.Add($"this.DeveloperCompanyId = {(this.DeveloperCompanyId == null ? "null" : this.DeveloperCompanyId)}");
            toStringOutput.Add($"this.TransactionHistories = {(this.TransactionHistories == null ? "null" : $"[{string.Join(", ", this.TransactionHistories)} ]")}");
            toStringOutput.Add($"this.SurchargeTransaction = {(this.SurchargeTransaction == null ? "null" : this.SurchargeTransaction.ToString())}");
            toStringOutput.Add($"this.Surcharge = {(this.Surcharge == null ? "null" : this.Surcharge.ToString())}");
            toStringOutput.Add($"this.Signature = {(this.Signature == null ? "null" : this.Signature.ToString())}");
            toStringOutput.Add($"this.ReasonCode = {(this.ReasonCode == null ? "null" : this.ReasonCode.ToString())}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.TransactionBatch = {(this.TransactionBatch == null ? "null" : this.TransactionBatch.ToString())}");
            toStringOutput.Add($"this.TransactionSplits = {(this.TransactionSplits == null ? "null" : $"[{string.Join(", ", this.TransactionSplits)} ]")}");
            toStringOutput.Add($"this.PostbackLogs = {(this.PostbackLogs == null ? "null" : $"[{string.Join(", ", this.PostbackLogs)} ]")}");
            toStringOutput.Add($"this.CurrencyType = {(this.CurrencyType == null ? "null" : this.CurrencyType.ToString())}");
            toStringOutput.Add($"this.TransactionReferences = {(this.TransactionReferences == null ? "null" : $"[{string.Join(", ", this.TransactionReferences)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}