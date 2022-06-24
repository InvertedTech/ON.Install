// <copyright file="Data14.cs" company="APIMatic">
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
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Data14.
    /// </summary>
    public class Data14
    {
        private string checkinDate;
        private string checkoutDate;
        private string clerkNumber;
        private string contactApiId;
        private string contactId;
        private string customData;
        private string customerId;
        private string description;
        private Models.IiasIndEnum? iiasInd;
        private string imageFront;
        private string imageBack;
        private double? installmentNumber;
        private double? installmentCount;
        private string locationApiId;
        private string locationId;
        private string notificationEmailAddress;
        private string orderNumber;
        private string poNumber;
        private string previousTransactionId;
        private string productTransactionId;
        private string quickInvoiceId;
        private double? recurringNumber;
        private string roomNum;
        private double? roomRate;
        private string saveAccountTitle;
        private int? subtotalAmount;
        private int? surchargeAmount;
        private int? tax;
        private int? tipAmount;
        private string transactionApiId;
        private string transactionC1;
        private string transactionC2;
        private string transactionC3;
        private string transactionC4;
        private string accountHolderName;
        private string accountType;
        private string accountVaultApiId;
        private string accountVaultId;
        private string achIdentifier;
        private Models.AchSecCode2Enum? achSecCode;
        private double? authAmount;
        private string authCode;
        private Models.AvsEnum? avs;
        private string avsEnhanced;
        private string checkNumber;
        private string customerIp;
        private string cvvResponse;
        private Models.EntryModeIdEnum? entryModeId;
        private string firstSix;
        private string lastFour;
        private string terminalSerialNumber;
        private string transactionSettlementStatus;
        private string chargeBackDate;
        private string notificationEmailSent;
        private string par;
        private double? reasonCodeId;
        private string recurringId;
        private string settleDate;
        private Models.StatusId2Enum? statusId;
        private string transactionBatchId;
        private Models.TypeIdEnum? typeId;
        private string verbiage;
        private string voidDate;
        private string batch;
        private string responseMessage;
        private string returnDate;
        private int? trxSourceId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "checkin_date", false },
            { "checkout_date", false },
            { "clerk_number", false },
            { "contact_api_id", false },
            { "contact_id", false },
            { "custom_data", false },
            { "customer_id", false },
            { "description", false },
            { "iias_ind", false },
            { "image_front", false },
            { "image_back", false },
            { "installment_number", false },
            { "installment_count", false },
            { "location_api_id", false },
            { "location_id", false },
            { "notification_email_address", false },
            { "order_number", false },
            { "po_number", false },
            { "previous_transaction_id", false },
            { "product_transaction_id", false },
            { "quick_invoice_id", false },
            { "recurring_number", false },
            { "room_num", false },
            { "room_rate", false },
            { "save_account_title", false },
            { "subtotal_amount", false },
            { "surcharge_amount", false },
            { "tax", false },
            { "tip_amount", false },
            { "transaction_api_id", false },
            { "transaction_c1", false },
            { "transaction_c2", false },
            { "transaction_c3", false },
            { "transaction_c4", false },
            { "account_holder_name", false },
            { "account_type", false },
            { "account_vault_api_id", false },
            { "account_vault_id", false },
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
            { "first_six", false },
            { "last_four", false },
            { "terminal_serial_number", false },
            { "transaction_settlement_status", false },
            { "charge_back_date", false },
            { "notification_email_sent", false },
            { "par", false },
            { "reason_code_id", false },
            { "recurring_id", false },
            { "settle_date", false },
            { "status_id", false },
            { "transaction_batch_id", false },
            { "type_id", false },
            { "verbiage", false },
            { "void_date", false },
            { "batch", false },
            { "response_message", false },
            { "return_date", false },
            { "trx_source_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Data14"/> class.
        /// </summary>
        public Data14()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data14"/> class.
        /// </summary>
        /// <param name="transactionAmount">transaction_amount.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="paymentMethod">payment_method.</param>
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
        /// <param name="identityVerification">identity_verification.</param>
        /// <param name="iiasInd">iias_ind.</param>
        /// <param name="imageFront">image_front.</param>
        /// <param name="imageBack">image_back.</param>
        /// <param name="installment">installment.</param>
        /// <param name="installmentNumber">installment_number.</param>
        /// <param name="installmentCount">installment_count.</param>
        /// <param name="locationApiId">location_api_id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="noShow">no_show.</param>
        /// <param name="notificationEmailAddress">notification_email_address.</param>
        /// <param name="orderNumber">order_number.</param>
        /// <param name="poNumber">po_number.</param>
        /// <param name="previousTransactionId">previous_transaction_id.</param>
        /// <param name="productTransactionId">product_transaction_id.</param>
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
        /// <param name="transactionApiId">transaction_api_id.</param>
        /// <param name="transactionC1">transaction_c1.</param>
        /// <param name="transactionC2">transaction_c2.</param>
        /// <param name="transactionC3">transaction_c3.</param>
        /// <param name="transactionC4">transaction_c4.</param>
        /// <param name="accountHolderName">account_holder_name.</param>
        /// <param name="accountType">account_type.</param>
        /// <param name="accountVaultApiId">account_vault_api_id.</param>
        /// <param name="accountVaultId">account_vault_id.</param>
        /// <param name="achIdentifier">ach_identifier.</param>
        /// <param name="achSecCode">ach_sec_code.</param>
        /// <param name="advanceDeposit">advance_deposit.</param>
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
        /// <param name="statusId">status_id.</param>
        /// <param name="transactionBatchId">transaction_batch_id.</param>
        /// <param name="typeId">type_id.</param>
        /// <param name="verbiage">verbiage.</param>
        /// <param name="voidDate">void_date.</param>
        /// <param name="batch">batch.</param>
        /// <param name="termsAgree">terms_agree.</param>
        /// <param name="responseMessage">response_message.</param>
        /// <param name="returnDate">return_date.</param>
        /// <param name="trxSourceId">trx_source_id.</param>
        public Data14(
            int transactionAmount,
            string id,
            int createdTs,
            int modifiedTs,
            Models.PaymentMethod4Enum paymentMethod,
            List<Models.AdditionalAmount> additionalAmounts = null,
            Models.BillingAddress2 billingAddress = null,
            string checkinDate = null,
            string checkoutDate = null,
            string clerkNumber = null,
            string contactApiId = null,
            string contactId = null,
            string customData = null,
            string customerId = null,
            string description = null,
            Models.IdentityVerification2 identityVerification = null,
            Models.IiasIndEnum? iiasInd = null,
            string imageFront = null,
            string imageBack = null,
            bool? installment = null,
            double? installmentNumber = null,
            double? installmentCount = null,
            string locationApiId = null,
            string locationId = null,
            bool? noShow = null,
            string notificationEmailAddress = null,
            string orderNumber = null,
            string poNumber = null,
            string previousTransactionId = null,
            string productTransactionId = null,
            string quickInvoiceId = null,
            bool? recurring = null,
            double? recurringNumber = null,
            string roomNum = null,
            double? roomRate = null,
            bool? saveAccount = null,
            string saveAccountTitle = null,
            int? subtotalAmount = null,
            int? surchargeAmount = null,
            List<Models.Tag> tags = null,
            int? tax = null,
            int? tipAmount = null,
            string transactionApiId = null,
            string transactionC1 = null,
            string transactionC2 = null,
            string transactionC3 = null,
            string transactionC4 = null,
            string accountHolderName = null,
            string accountType = null,
            string accountVaultApiId = null,
            string accountVaultId = null,
            string achIdentifier = null,
            Models.AchSecCode2Enum? achSecCode = null,
            bool? advanceDeposit = null,
            double? authAmount = null,
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
            string notificationEmailSent = null,
            string par = null,
            double? reasonCodeId = null,
            string recurringId = null,
            string settleDate = null,
            Models.StatusId2Enum? statusId = null,
            string transactionBatchId = null,
            Models.TypeIdEnum? typeId = null,
            string verbiage = null,
            string voidDate = null,
            string batch = null,
            bool? termsAgree = null,
            string responseMessage = null,
            string returnDate = null,
            int? trxSourceId = null)
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

            if (customData != null)
            {
                this.CustomData = customData;
            }

            if (customerId != null)
            {
                this.CustomerId = customerId;
            }

            if (description != null)
            {
                this.Description = description;
            }

            this.IdentityVerification = identityVerification;
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

            if (previousTransactionId != null)
            {
                this.PreviousTransactionId = previousTransactionId;
            }

            if (productTransactionId != null)
            {
                this.ProductTransactionId = productTransactionId;
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

            this.TransactionAmount = transactionAmount;
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

            if (transactionC4 != null)
            {
                this.TransactionC4 = transactionC4;
            }

            this.Id = id;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            if (accountHolderName != null)
            {
                this.AccountHolderName = accountHolderName;
            }

            if (accountType != null)
            {
                this.AccountType = accountType;
            }

            if (accountVaultApiId != null)
            {
                this.AccountVaultApiId = accountVaultApiId;
            }

            if (accountVaultId != null)
            {
                this.AccountVaultId = accountVaultId;
            }

            if (achIdentifier != null)
            {
                this.AchIdentifier = achIdentifier;
            }

            if (achSecCode != null)
            {
                this.AchSecCode = achSecCode;
            }

            this.AdvanceDeposit = advanceDeposit;
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

            this.EmvReceiptData = emvReceiptData;
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
            if (notificationEmailSent != null)
            {
                this.NotificationEmailSent = notificationEmailSent;
            }

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

            if (statusId != null)
            {
                this.StatusId = statusId;
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

        }

        /// <summary>
        /// Additional amounts
        /// </summary>
        [JsonProperty("additional_amounts", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.AdditionalAmount> AdditionalAmounts { get; set; }

        /// <summary>
        /// The City portion of the address associated with the Credit Card (CC) or Bank Account (ACH).
        /// </summary>
        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BillingAddress2 BillingAddress { get; set; }

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
        [JsonProperty("custom_data")]
        public string CustomData
        {
            get
            {
                return this.customData;
            }

            set
            {
                this.shouldSerialize["custom_data"] = true;
                this.customData = value;
            }
        }

        /// <summary>
        /// Can be used by Merchants to identify Contacts in our system by an ID from another system.
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
        /// Identity Verification
        /// </summary>
        [JsonProperty("identity_verification", NullValueHandling = NullValueHandling.Ignore)]
        public Models.IdentityVerification2 IdentityVerification { get; set; }

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
        /// A base64 encoded string for the image.  Used with Check21 ACH transactions.
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
        /// A base64 encoded string for the image.  Used with Check21 ACH transactions.
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
        public double? InstallmentNumber
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
        public double? InstallmentCount
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
        /// previous_transaction_id is used as token to run transaction. Account details OR previous_transaction_id should be passed to run transaction.
        /// </summary>
        [JsonProperty("previous_transaction_id")]
        public string PreviousTransactionId
        {
            get
            {
                return this.previousTransactionId;
            }

            set
            {
                this.shouldSerialize["previous_transaction_id"] = true;
                this.previousTransactionId = value;
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
        /// Can be used to associate a transaction to a Quick Invoice.  Quick Invoice transactions will have a value for this field automatically.
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
        /// Flag that is allowed to be passed on card not present industries to signify the transaction is an ongoing recurring transaction. Possible values to send are 0 or 1. This field must be 0 or not present if installment is sent as 1.
        /// </summary>
        [JsonProperty("recurring", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Recurring { get; set; }

        /// <summary>
        /// If this is an ongoing recurring and recurring field is being passed as 1, then this field must have a vlue of 1-999 specifying the current recurring number that is running.
        /// </summary>
        [JsonProperty("recurring_number")]
        public double? RecurringNumber
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
        public double? RoomRate
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
        /// If saving account vault while running a transaction, this will be the title of the account vault.
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
        /// Tags
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
        public int TransactionAmount { get; set; }

        /// <summary>
        /// See api_id page for more details
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
        /// Custom field 4 for api users to store custom data
        /// </summary>
        [JsonProperty("transaction_c4")]
        public string TransactionC4
        {
            get
            {
                return this.transactionC4;
            }

            set
            {
                this.shouldSerialize["transaction_c4"] = true;
                this.transactionC4 = value;
            }
        }

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
        /// This can be supplied in place of account_vault_id if you would like to use an account vault for the transaction and are using your own custom api_id's to track accountvaults in the system.
        /// </summary>
        [JsonProperty("account_vault_api_id")]
        public string AccountVaultApiId
        {
            get
            {
                return this.accountVaultApiId;
            }

            set
            {
                this.shouldSerialize["account_vault_api_id"] = true;
                this.accountVaultApiId = value;
            }
        }

        /// <summary>
        /// Required if account_number,  track_data, micr_data is not provided.
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
        [JsonProperty("ach_sec_code", ItemConverterType = typeof(StringEnumConverter))]
        public Models.AchSecCode2Enum? AchSecCode
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
        /// Advance Deposit
        /// </summary>
        [JsonProperty("advance_deposit", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AdvanceDeposit { get; set; }

        /// <summary>
        /// Authorization Amount
        /// </summary>
        [JsonProperty("auth_amount")]
        public double? AuthAmount
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
        [JsonProperty("avs", ItemConverterType = typeof(StringEnumConverter))]
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
        [JsonProperty("entry_mode_id", ItemConverterType = typeof(StringEnumConverter))]
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
        [JsonProperty("emv_receipt_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.EmvReceiptData EmvReceiptData { get; set; }

        /// <summary>
        /// First six numbers of account_number.  Automatically generated by system.
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
        /// Last four numbers of account_number.  Automatically generated by the system.
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
        [JsonProperty("payment_method", ItemConverterType = typeof(StringEnumConverter))]
        public Models.PaymentMethod4Enum PaymentMethod { get; set; }

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
        [JsonProperty("notification_email_sent")]
        public string NotificationEmailSent
        {
            get
            {
                return this.notificationEmailSent;
            }

            set
            {
                this.shouldSerialize["notification_email_sent"] = true;
                this.notificationEmailSent = value;
            }
        }

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
        /// Response reason code that provides more detail as to the result of the transaction. The reason code list can be found here: Response Reason Codes
        /// </summary>
        [JsonProperty("reason_code_id")]
        public double? ReasonCodeId
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
        /// </summary>
        [JsonProperty("status_id")]
        public Models.StatusId2Enum? StatusId
        {
            get
            {
                return this.statusId;
            }

            set
            {
                this.shouldSerialize["status_id"] = true;
                this.statusId = value;
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
        /// </summary>
        [JsonProperty("trx_source_id")]
        public int? TrxSourceId
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data14 : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetCustomData()
        {
            this.shouldSerialize["custom_data"] = false;
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
        public void UnsetPreviousTransactionId()
        {
            this.shouldSerialize["previous_transaction_id"] = false;
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
        public void UnsetTransactionC4()
        {
            this.shouldSerialize["transaction_c4"] = false;
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
        public void UnsetAccountVaultApiId()
        {
            this.shouldSerialize["account_vault_api_id"] = false;
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
        public void UnsetNotificationEmailSent()
        {
            this.shouldSerialize["notification_email_sent"] = false;
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
        public void UnsetStatusId()
        {
            this.shouldSerialize["status_id"] = false;
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
        public bool ShouldSerializeCustomData()
        {
            return this.shouldSerialize["custom_data"];
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
        public bool ShouldSerializePreviousTransactionId()
        {
            return this.shouldSerialize["previous_transaction_id"];
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
        public bool ShouldSerializeTransactionC4()
        {
            return this.shouldSerialize["transaction_c4"];
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
        public bool ShouldSerializeAccountVaultApiId()
        {
            return this.shouldSerialize["account_vault_api_id"];
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
        public bool ShouldSerializeNotificationEmailSent()
        {
            return this.shouldSerialize["notification_email_sent"];
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
        public bool ShouldSerializeStatusId()
        {
            return this.shouldSerialize["status_id"];
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

            return obj is Data14 other &&
                ((this.AdditionalAmounts == null && other.AdditionalAmounts == null) || (this.AdditionalAmounts?.Equals(other.AdditionalAmounts) == true)) &&
                ((this.BillingAddress == null && other.BillingAddress == null) || (this.BillingAddress?.Equals(other.BillingAddress) == true)) &&
                ((this.CheckinDate == null && other.CheckinDate == null) || (this.CheckinDate?.Equals(other.CheckinDate) == true)) &&
                ((this.CheckoutDate == null && other.CheckoutDate == null) || (this.CheckoutDate?.Equals(other.CheckoutDate) == true)) &&
                ((this.ClerkNumber == null && other.ClerkNumber == null) || (this.ClerkNumber?.Equals(other.ClerkNumber) == true)) &&
                ((this.ContactApiId == null && other.ContactApiId == null) || (this.ContactApiId?.Equals(other.ContactApiId) == true)) &&
                ((this.ContactId == null && other.ContactId == null) || (this.ContactId?.Equals(other.ContactId) == true)) &&
                ((this.CustomData == null && other.CustomData == null) || (this.CustomData?.Equals(other.CustomData) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.IdentityVerification == null && other.IdentityVerification == null) || (this.IdentityVerification?.Equals(other.IdentityVerification) == true)) &&
                ((this.IiasInd == null && other.IiasInd == null) || (this.IiasInd?.Equals(other.IiasInd) == true)) &&
                ((this.ImageFront == null && other.ImageFront == null) || (this.ImageFront?.Equals(other.ImageFront) == true)) &&
                ((this.ImageBack == null && other.ImageBack == null) || (this.ImageBack?.Equals(other.ImageBack) == true)) &&
                ((this.Installment == null && other.Installment == null) || (this.Installment?.Equals(other.Installment) == true)) &&
                ((this.InstallmentNumber == null && other.InstallmentNumber == null) || (this.InstallmentNumber?.Equals(other.InstallmentNumber) == true)) &&
                ((this.InstallmentCount == null && other.InstallmentCount == null) || (this.InstallmentCount?.Equals(other.InstallmentCount) == true)) &&
                ((this.LocationApiId == null && other.LocationApiId == null) || (this.LocationApiId?.Equals(other.LocationApiId) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.NoShow == null && other.NoShow == null) || (this.NoShow?.Equals(other.NoShow) == true)) &&
                ((this.NotificationEmailAddress == null && other.NotificationEmailAddress == null) || (this.NotificationEmailAddress?.Equals(other.NotificationEmailAddress) == true)) &&
                ((this.OrderNumber == null && other.OrderNumber == null) || (this.OrderNumber?.Equals(other.OrderNumber) == true)) &&
                ((this.PoNumber == null && other.PoNumber == null) || (this.PoNumber?.Equals(other.PoNumber) == true)) &&
                ((this.PreviousTransactionId == null && other.PreviousTransactionId == null) || (this.PreviousTransactionId?.Equals(other.PreviousTransactionId) == true)) &&
                ((this.ProductTransactionId == null && other.ProductTransactionId == null) || (this.ProductTransactionId?.Equals(other.ProductTransactionId) == true)) &&
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
                this.TransactionAmount.Equals(other.TransactionAmount) &&
                ((this.TransactionApiId == null && other.TransactionApiId == null) || (this.TransactionApiId?.Equals(other.TransactionApiId) == true)) &&
                ((this.TransactionC1 == null && other.TransactionC1 == null) || (this.TransactionC1?.Equals(other.TransactionC1) == true)) &&
                ((this.TransactionC2 == null && other.TransactionC2 == null) || (this.TransactionC2?.Equals(other.TransactionC2) == true)) &&
                ((this.TransactionC3 == null && other.TransactionC3 == null) || (this.TransactionC3?.Equals(other.TransactionC3) == true)) &&
                ((this.TransactionC4 == null && other.TransactionC4 == null) || (this.TransactionC4?.Equals(other.TransactionC4) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                ((this.AccountHolderName == null && other.AccountHolderName == null) || (this.AccountHolderName?.Equals(other.AccountHolderName) == true)) &&
                ((this.AccountType == null && other.AccountType == null) || (this.AccountType?.Equals(other.AccountType) == true)) &&
                ((this.AccountVaultApiId == null && other.AccountVaultApiId == null) || (this.AccountVaultApiId?.Equals(other.AccountVaultApiId) == true)) &&
                ((this.AccountVaultId == null && other.AccountVaultId == null) || (this.AccountVaultId?.Equals(other.AccountVaultId) == true)) &&
                ((this.AchIdentifier == null && other.AchIdentifier == null) || (this.AchIdentifier?.Equals(other.AchIdentifier) == true)) &&
                ((this.AchSecCode == null && other.AchSecCode == null) || (this.AchSecCode?.Equals(other.AchSecCode) == true)) &&
                ((this.AdvanceDeposit == null && other.AdvanceDeposit == null) || (this.AdvanceDeposit?.Equals(other.AdvanceDeposit) == true)) &&
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
                ((this.StatusId == null && other.StatusId == null) || (this.StatusId?.Equals(other.StatusId) == true)) &&
                ((this.TransactionBatchId == null && other.TransactionBatchId == null) || (this.TransactionBatchId?.Equals(other.TransactionBatchId) == true)) &&
                ((this.TypeId == null && other.TypeId == null) || (this.TypeId?.Equals(other.TypeId) == true)) &&
                ((this.Verbiage == null && other.Verbiage == null) || (this.Verbiage?.Equals(other.Verbiage) == true)) &&
                ((this.VoidDate == null && other.VoidDate == null) || (this.VoidDate?.Equals(other.VoidDate) == true)) &&
                ((this.Batch == null && other.Batch == null) || (this.Batch?.Equals(other.Batch) == true)) &&
                ((this.TermsAgree == null && other.TermsAgree == null) || (this.TermsAgree?.Equals(other.TermsAgree) == true)) &&
                ((this.ResponseMessage == null && other.ResponseMessage == null) || (this.ResponseMessage?.Equals(other.ResponseMessage) == true)) &&
                ((this.ReturnDate == null && other.ReturnDate == null) || (this.ReturnDate?.Equals(other.ReturnDate) == true)) &&
                ((this.TrxSourceId == null && other.TrxSourceId == null) || (this.TrxSourceId?.Equals(other.TrxSourceId) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AdditionalAmounts = {(this.AdditionalAmounts == null ? "null" : $"[{string.Join(", ", this.AdditionalAmounts)} ]")}");
            toStringOutput.Add($"this.BillingAddress = {(this.BillingAddress == null ? "null" : this.BillingAddress.ToString())}");
            toStringOutput.Add($"this.CheckinDate = {(this.CheckinDate == null ? "null" : this.CheckinDate == string.Empty ? "" : this.CheckinDate)}");
            toStringOutput.Add($"this.CheckoutDate = {(this.CheckoutDate == null ? "null" : this.CheckoutDate == string.Empty ? "" : this.CheckoutDate)}");
            toStringOutput.Add($"this.ClerkNumber = {(this.ClerkNumber == null ? "null" : this.ClerkNumber == string.Empty ? "" : this.ClerkNumber)}");
            toStringOutput.Add($"this.ContactApiId = {(this.ContactApiId == null ? "null" : this.ContactApiId == string.Empty ? "" : this.ContactApiId)}");
            toStringOutput.Add($"this.ContactId = {(this.ContactId == null ? "null" : this.ContactId == string.Empty ? "" : this.ContactId)}");
            toStringOutput.Add($"this.CustomData = {(this.CustomData == null ? "null" : this.CustomData == string.Empty ? "" : this.CustomData)}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId == string.Empty ? "" : this.CustomerId)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.IdentityVerification = {(this.IdentityVerification == null ? "null" : this.IdentityVerification.ToString())}");
            toStringOutput.Add($"this.IiasInd = {(this.IiasInd == null ? "null" : this.IiasInd.ToString())}");
            toStringOutput.Add($"this.ImageFront = {(this.ImageFront == null ? "null" : this.ImageFront == string.Empty ? "" : this.ImageFront)}");
            toStringOutput.Add($"this.ImageBack = {(this.ImageBack == null ? "null" : this.ImageBack == string.Empty ? "" : this.ImageBack)}");
            toStringOutput.Add($"this.Installment = {(this.Installment == null ? "null" : this.Installment.ToString())}");
            toStringOutput.Add($"this.InstallmentNumber = {(this.InstallmentNumber == null ? "null" : this.InstallmentNumber.ToString())}");
            toStringOutput.Add($"this.InstallmentCount = {(this.InstallmentCount == null ? "null" : this.InstallmentCount.ToString())}");
            toStringOutput.Add($"this.LocationApiId = {(this.LocationApiId == null ? "null" : this.LocationApiId == string.Empty ? "" : this.LocationApiId)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.NoShow = {(this.NoShow == null ? "null" : this.NoShow.ToString())}");
            toStringOutput.Add($"this.NotificationEmailAddress = {(this.NotificationEmailAddress == null ? "null" : this.NotificationEmailAddress == string.Empty ? "" : this.NotificationEmailAddress)}");
            toStringOutput.Add($"this.OrderNumber = {(this.OrderNumber == null ? "null" : this.OrderNumber == string.Empty ? "" : this.OrderNumber)}");
            toStringOutput.Add($"this.PoNumber = {(this.PoNumber == null ? "null" : this.PoNumber == string.Empty ? "" : this.PoNumber)}");
            toStringOutput.Add($"this.PreviousTransactionId = {(this.PreviousTransactionId == null ? "null" : this.PreviousTransactionId == string.Empty ? "" : this.PreviousTransactionId)}");
            toStringOutput.Add($"this.ProductTransactionId = {(this.ProductTransactionId == null ? "null" : this.ProductTransactionId == string.Empty ? "" : this.ProductTransactionId)}");
            toStringOutput.Add($"this.QuickInvoiceId = {(this.QuickInvoiceId == null ? "null" : this.QuickInvoiceId == string.Empty ? "" : this.QuickInvoiceId)}");
            toStringOutput.Add($"this.Recurring = {(this.Recurring == null ? "null" : this.Recurring.ToString())}");
            toStringOutput.Add($"this.RecurringNumber = {(this.RecurringNumber == null ? "null" : this.RecurringNumber.ToString())}");
            toStringOutput.Add($"this.RoomNum = {(this.RoomNum == null ? "null" : this.RoomNum == string.Empty ? "" : this.RoomNum)}");
            toStringOutput.Add($"this.RoomRate = {(this.RoomRate == null ? "null" : this.RoomRate.ToString())}");
            toStringOutput.Add($"this.SaveAccount = {(this.SaveAccount == null ? "null" : this.SaveAccount.ToString())}");
            toStringOutput.Add($"this.SaveAccountTitle = {(this.SaveAccountTitle == null ? "null" : this.SaveAccountTitle == string.Empty ? "" : this.SaveAccountTitle)}");
            toStringOutput.Add($"this.SubtotalAmount = {(this.SubtotalAmount == null ? "null" : this.SubtotalAmount.ToString())}");
            toStringOutput.Add($"this.SurchargeAmount = {(this.SurchargeAmount == null ? "null" : this.SurchargeAmount.ToString())}");
            toStringOutput.Add($"this.Tags = {(this.Tags == null ? "null" : $"[{string.Join(", ", this.Tags)} ]")}");
            toStringOutput.Add($"this.Tax = {(this.Tax == null ? "null" : this.Tax.ToString())}");
            toStringOutput.Add($"this.TipAmount = {(this.TipAmount == null ? "null" : this.TipAmount.ToString())}");
            toStringOutput.Add($"this.TransactionAmount = {this.TransactionAmount}");
            toStringOutput.Add($"this.TransactionApiId = {(this.TransactionApiId == null ? "null" : this.TransactionApiId == string.Empty ? "" : this.TransactionApiId)}");
            toStringOutput.Add($"this.TransactionC1 = {(this.TransactionC1 == null ? "null" : this.TransactionC1 == string.Empty ? "" : this.TransactionC1)}");
            toStringOutput.Add($"this.TransactionC2 = {(this.TransactionC2 == null ? "null" : this.TransactionC2 == string.Empty ? "" : this.TransactionC2)}");
            toStringOutput.Add($"this.TransactionC3 = {(this.TransactionC3 == null ? "null" : this.TransactionC3 == string.Empty ? "" : this.TransactionC3)}");
            toStringOutput.Add($"this.TransactionC4 = {(this.TransactionC4 == null ? "null" : this.TransactionC4 == string.Empty ? "" : this.TransactionC4)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.AccountHolderName = {(this.AccountHolderName == null ? "null" : this.AccountHolderName == string.Empty ? "" : this.AccountHolderName)}");
            toStringOutput.Add($"this.AccountType = {(this.AccountType == null ? "null" : this.AccountType == string.Empty ? "" : this.AccountType)}");
            toStringOutput.Add($"this.AccountVaultApiId = {(this.AccountVaultApiId == null ? "null" : this.AccountVaultApiId == string.Empty ? "" : this.AccountVaultApiId)}");
            toStringOutput.Add($"this.AccountVaultId = {(this.AccountVaultId == null ? "null" : this.AccountVaultId == string.Empty ? "" : this.AccountVaultId)}");
            toStringOutput.Add($"this.AchIdentifier = {(this.AchIdentifier == null ? "null" : this.AchIdentifier == string.Empty ? "" : this.AchIdentifier)}");
            toStringOutput.Add($"this.AchSecCode = {(this.AchSecCode == null ? "null" : this.AchSecCode.ToString())}");
            toStringOutput.Add($"this.AdvanceDeposit = {(this.AdvanceDeposit == null ? "null" : this.AdvanceDeposit.ToString())}");
            toStringOutput.Add($"this.AuthAmount = {(this.AuthAmount == null ? "null" : this.AuthAmount.ToString())}");
            toStringOutput.Add($"this.AuthCode = {(this.AuthCode == null ? "null" : this.AuthCode == string.Empty ? "" : this.AuthCode)}");
            toStringOutput.Add($"this.Avs = {(this.Avs == null ? "null" : this.Avs.ToString())}");
            toStringOutput.Add($"this.AvsEnhanced = {(this.AvsEnhanced == null ? "null" : this.AvsEnhanced == string.Empty ? "" : this.AvsEnhanced)}");
            toStringOutput.Add($"this.CardholderPresent = {(this.CardholderPresent == null ? "null" : this.CardholderPresent.ToString())}");
            toStringOutput.Add($"this.CardPresent = {(this.CardPresent == null ? "null" : this.CardPresent.ToString())}");
            toStringOutput.Add($"this.CheckNumber = {(this.CheckNumber == null ? "null" : this.CheckNumber == string.Empty ? "" : this.CheckNumber)}");
            toStringOutput.Add($"this.CustomerIp = {(this.CustomerIp == null ? "null" : this.CustomerIp == string.Empty ? "" : this.CustomerIp)}");
            toStringOutput.Add($"this.CvvResponse = {(this.CvvResponse == null ? "null" : this.CvvResponse == string.Empty ? "" : this.CvvResponse)}");
            toStringOutput.Add($"this.EntryModeId = {(this.EntryModeId == null ? "null" : this.EntryModeId.ToString())}");
            toStringOutput.Add($"this.EmvReceiptData = {(this.EmvReceiptData == null ? "null" : this.EmvReceiptData.ToString())}");
            toStringOutput.Add($"this.FirstSix = {(this.FirstSix == null ? "null" : this.FirstSix == string.Empty ? "" : this.FirstSix)}");
            toStringOutput.Add($"this.LastFour = {(this.LastFour == null ? "null" : this.LastFour == string.Empty ? "" : this.LastFour)}");
            toStringOutput.Add($"this.PaymentMethod = {this.PaymentMethod}");
            toStringOutput.Add($"this.TerminalSerialNumber = {(this.TerminalSerialNumber == null ? "null" : this.TerminalSerialNumber == string.Empty ? "" : this.TerminalSerialNumber)}");
            toStringOutput.Add($"this.TransactionSettlementStatus = {(this.TransactionSettlementStatus == null ? "null" : this.TransactionSettlementStatus == string.Empty ? "" : this.TransactionSettlementStatus)}");
            toStringOutput.Add($"this.ChargeBackDate = {(this.ChargeBackDate == null ? "null" : this.ChargeBackDate == string.Empty ? "" : this.ChargeBackDate)}");
            toStringOutput.Add($"this.IsRecurring = {(this.IsRecurring == null ? "null" : this.IsRecurring.ToString())}");
            toStringOutput.Add($"this.NotificationEmailSent = {(this.NotificationEmailSent == null ? "null" : this.NotificationEmailSent == string.Empty ? "" : this.NotificationEmailSent)}");
            toStringOutput.Add($"this.Par = {(this.Par == null ? "null" : this.Par == string.Empty ? "" : this.Par)}");
            toStringOutput.Add($"this.ReasonCodeId = {(this.ReasonCodeId == null ? "null" : this.ReasonCodeId.ToString())}");
            toStringOutput.Add($"this.RecurringId = {(this.RecurringId == null ? "null" : this.RecurringId == string.Empty ? "" : this.RecurringId)}");
            toStringOutput.Add($"this.SettleDate = {(this.SettleDate == null ? "null" : this.SettleDate == string.Empty ? "" : this.SettleDate)}");
            toStringOutput.Add($"this.StatusId = {(this.StatusId == null ? "null" : this.StatusId.ToString())}");
            toStringOutput.Add($"this.TransactionBatchId = {(this.TransactionBatchId == null ? "null" : this.TransactionBatchId == string.Empty ? "" : this.TransactionBatchId)}");
            toStringOutput.Add($"this.TypeId = {(this.TypeId == null ? "null" : this.TypeId.ToString())}");
            toStringOutput.Add($"this.Verbiage = {(this.Verbiage == null ? "null" : this.Verbiage == string.Empty ? "" : this.Verbiage)}");
            toStringOutput.Add($"this.VoidDate = {(this.VoidDate == null ? "null" : this.VoidDate == string.Empty ? "" : this.VoidDate)}");
            toStringOutput.Add($"this.Batch = {(this.Batch == null ? "null" : this.Batch == string.Empty ? "" : this.Batch)}");
            toStringOutput.Add($"this.TermsAgree = {(this.TermsAgree == null ? "null" : this.TermsAgree.ToString())}");
            toStringOutput.Add($"this.ResponseMessage = {(this.ResponseMessage == null ? "null" : this.ResponseMessage == string.Empty ? "" : this.ResponseMessage)}");
            toStringOutput.Add($"this.ReturnDate = {(this.ReturnDate == null ? "null" : this.ReturnDate == string.Empty ? "" : this.ReturnDate)}");
            toStringOutput.Add($"this.TrxSourceId = {(this.TrxSourceId == null ? "null" : this.TrxSourceId.ToString())}");
        }
    }
}