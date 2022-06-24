// <copyright file="Filter11.cs" company="APIMatic">
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
    /// Filter11.
    /// </summary>
    public class Filter11
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Filter11"/> class.
        /// </summary>
        public Filter11()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Filter11"/> class.
        /// </summary>
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
        /// <param name="transactionAmount">transaction_amount.</param>
        /// <param name="transactionApiId">transaction_api_id.</param>
        /// <param name="transactionC1">transaction_c1.</param>
        /// <param name="transactionC2">transaction_c2.</param>
        /// <param name="transactionC3">transaction_c3.</param>
        /// <param name="transactionC4">transaction_c4.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
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
        /// <param name="paymentMethod">payment_method.</param>
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
        public Filter11(
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
            int? transactionAmount = null,
            string transactionApiId = null,
            string transactionC1 = null,
            string transactionC2 = null,
            string transactionC3 = null,
            string transactionC4 = null,
            string id = null,
            int? createdTs = null,
            int? modifiedTs = null,
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
            Models.PaymentMethod4Enum? paymentMethod = null,
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
            this.CheckinDate = checkinDate;
            this.CheckoutDate = checkoutDate;
            this.ClerkNumber = clerkNumber;
            this.ContactApiId = contactApiId;
            this.ContactId = contactId;
            this.CustomData = customData;
            this.CustomerId = customerId;
            this.Description = description;
            this.IdentityVerification = identityVerification;
            this.IiasInd = iiasInd;
            this.ImageFront = imageFront;
            this.ImageBack = imageBack;
            this.Installment = installment;
            this.InstallmentNumber = installmentNumber;
            this.InstallmentCount = installmentCount;
            this.LocationApiId = locationApiId;
            this.LocationId = locationId;
            this.NoShow = noShow;
            this.NotificationEmailAddress = notificationEmailAddress;
            this.OrderNumber = orderNumber;
            this.PoNumber = poNumber;
            this.PreviousTransactionId = previousTransactionId;
            this.ProductTransactionId = productTransactionId;
            this.QuickInvoiceId = quickInvoiceId;
            this.Recurring = recurring;
            this.RecurringNumber = recurringNumber;
            this.RoomNum = roomNum;
            this.RoomRate = roomRate;
            this.SaveAccount = saveAccount;
            this.SaveAccountTitle = saveAccountTitle;
            this.SubtotalAmount = subtotalAmount;
            this.SurchargeAmount = surchargeAmount;
            this.Tags = tags;
            this.Tax = tax;
            this.TipAmount = tipAmount;
            this.TransactionAmount = transactionAmount;
            this.TransactionApiId = transactionApiId;
            this.TransactionC1 = transactionC1;
            this.TransactionC2 = transactionC2;
            this.TransactionC3 = transactionC3;
            this.TransactionC4 = transactionC4;
            this.Id = id;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            this.AccountHolderName = accountHolderName;
            this.AccountType = accountType;
            this.AccountVaultApiId = accountVaultApiId;
            this.AccountVaultId = accountVaultId;
            this.AchIdentifier = achIdentifier;
            this.AchSecCode = achSecCode;
            this.AdvanceDeposit = advanceDeposit;
            this.AuthAmount = authAmount;
            this.AuthCode = authCode;
            this.Avs = avs;
            this.AvsEnhanced = avsEnhanced;
            this.CardholderPresent = cardholderPresent;
            this.CardPresent = cardPresent;
            this.CheckNumber = checkNumber;
            this.CustomerIp = customerIp;
            this.CvvResponse = cvvResponse;
            this.EntryModeId = entryModeId;
            this.EmvReceiptData = emvReceiptData;
            this.FirstSix = firstSix;
            this.LastFour = lastFour;
            this.PaymentMethod = paymentMethod;
            this.TerminalSerialNumber = terminalSerialNumber;
            this.TransactionSettlementStatus = transactionSettlementStatus;
            this.ChargeBackDate = chargeBackDate;
            this.IsRecurring = isRecurring;
            this.NotificationEmailSent = notificationEmailSent;
            this.Par = par;
            this.ReasonCodeId = reasonCodeId;
            this.RecurringId = recurringId;
            this.SettleDate = settleDate;
            this.StatusId = statusId;
            this.TransactionBatchId = transactionBatchId;
            this.TypeId = typeId;
            this.Verbiage = verbiage;
            this.VoidDate = voidDate;
            this.Batch = batch;
            this.TermsAgree = termsAgree;
            this.ResponseMessage = responseMessage;
            this.ReturnDate = returnDate;
            this.TrxSourceId = trxSourceId;
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
        [JsonProperty("checkin_date", NullValueHandling = NullValueHandling.Ignore)]
        public string CheckinDate { get; set; }

        /// <summary>
        /// Checkout Date - The time difference between checkin_date and checkout_date must be less than or equal to 99 days.
        /// </summary>
        [JsonProperty("checkout_date", NullValueHandling = NullValueHandling.Ignore)]
        public string CheckoutDate { get; set; }

        /// <summary>
        /// Clerk or Employee Identifier
        /// </summary>
        [JsonProperty("clerk_number", NullValueHandling = NullValueHandling.Ignore)]
        public string ClerkNumber { get; set; }

        /// <summary>
        /// This can be supplied in place of contact_id if you would like to use a contact for the transaction and are using your own custom api_id's to track contacts in the system.
        /// </summary>
        [JsonProperty("contact_api_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ContactApiId { get; set; }

        /// <summary>
        /// If contact_id is provided, ensure it belongs to the same location as the transaction. You cannot move transaction across locations.
        /// </summary>
        [JsonProperty("contact_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ContactId { get; set; }

        /// <summary>
        /// A field that allows custom JSON to be entered to store extra data.
        /// </summary>
        [JsonProperty("custom_data", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomData { get; set; }

        /// <summary>
        /// Can be used by Merchants to identify Contacts in our system by an ID from another system.
        /// </summary>
        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Identity Verification
        /// </summary>
        [JsonProperty("identity_verification", NullValueHandling = NullValueHandling.Ignore)]
        public Models.IdentityVerification2 IdentityVerification { get; set; }

        /// <summary>
        /// Possible values are '0', '1','2'
        /// </summary>
        [JsonProperty("iias_ind", NullValueHandling = NullValueHandling.Ignore)]
        public Models.IiasIndEnum? IiasInd { get; set; }

        /// <summary>
        /// A base64 encoded string for the image.  Used with Check21 ACH transactions.
        /// </summary>
        [JsonProperty("image_front", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageFront { get; set; }

        /// <summary>
        /// A base64 encoded string for the image.  Used with Check21 ACH transactions.
        /// </summary>
        [JsonProperty("image_back", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageBack { get; set; }

        /// <summary>
        /// Flag that is allowed to be passed on card not present industries to signify the transaction is a fixed installment plan transaction.
        /// </summary>
        [JsonProperty("installment", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Installment { get; set; }

        /// <summary>
        /// If this is a fixed installment plan and installment field is being passed as 1, then this field must have a vlue of 1-999 specifying the current installment number that is running.
        /// </summary>
        [JsonProperty("installment_number", NullValueHandling = NullValueHandling.Ignore)]
        public double? InstallmentNumber { get; set; }

        /// <summary>
        /// If this is a fixed installment plan and installment field is being passed as 1, then this field must have a vlue of 1-999 specifying the total number of installments on the plan. This number must be grater than or equal to installment_number.
        /// </summary>
        [JsonProperty("installment_count", NullValueHandling = NullValueHandling.Ignore)]
        public double? InstallmentCount { get; set; }

        /// <summary>
        /// This can be supplied in place of location_id for the transaction if you are using your own custom api_id's for your locations.
        /// </summary>
        [JsonProperty("location_api_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationApiId { get; set; }

        /// <summary>
        /// A valid Location Id to associate the transaction with.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; set; }

        /// <summary>
        /// Used in Lodging
        /// </summary>
        [JsonProperty("no_show", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NoShow { get; set; }

        /// <summary>
        /// If email is supplied then receipt will be emailed
        /// </summary>
        [JsonProperty("notification_email_address", NullValueHandling = NullValueHandling.Ignore)]
        public string NotificationEmailAddress { get; set; }

        /// <summary>
        /// Required for CC transactions , if merchant's deposit account's duplicate check per batch has 'order_number' field
        /// </summary>
        [JsonProperty("order_number", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Purchase Order number
        /// </summary>
        [JsonProperty("po_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PoNumber { get; set; }

        /// <summary>
        /// previous_transaction_id is used as token to run transaction. Account details OR previous_transaction_id should be passed to run transaction.
        /// </summary>
        [JsonProperty("previous_transaction_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PreviousTransactionId { get; set; }

        /// <summary>
        /// The Product's method (cc/ach) has to match the action. If not provided, the API will use the default configured for the Location.
        /// </summary>
        [JsonProperty("product_transaction_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTransactionId { get; set; }

        /// <summary>
        /// Can be used to associate a transaction to a Quick Invoice.  Quick Invoice transactions will have a value for this field automatically.
        /// </summary>
        [JsonProperty("quick_invoice_id", NullValueHandling = NullValueHandling.Ignore)]
        public string QuickInvoiceId { get; set; }

        /// <summary>
        /// Flag that is allowed to be passed on card not present industries to signify the transaction is an ongoing recurring transaction. Possible values to send are 0 or 1. This field must be 0 or not present if installment is sent as 1.
        /// </summary>
        [JsonProperty("recurring", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Recurring { get; set; }

        /// <summary>
        /// If this is an ongoing recurring and recurring field is being passed as 1, then this field must have a vlue of 1-999 specifying the current recurring number that is running.
        /// </summary>
        [JsonProperty("recurring_number", NullValueHandling = NullValueHandling.Ignore)]
        public double? RecurringNumber { get; set; }

        /// <summary>
        /// Used in Lodging
        /// </summary>
        [JsonProperty("room_num", NullValueHandling = NullValueHandling.Ignore)]
        public string RoomNum { get; set; }

        /// <summary>
        /// Required if merchant industry type is lodging.
        /// </summary>
        [JsonProperty("room_rate", NullValueHandling = NullValueHandling.Ignore)]
        public double? RoomRate { get; set; }

        /// <summary>
        /// Specifies to save account to contacts profile if account_number/track_data is present with either contact_id or contact_api_id in params.
        /// </summary>
        [JsonProperty("save_account", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SaveAccount { get; set; }

        /// <summary>
        /// If saving account vault while running a transaction, this will be the title of the account vault.
        /// </summary>
        [JsonProperty("save_account_title", NullValueHandling = NullValueHandling.Ignore)]
        public string SaveAccountTitle { get; set; }

        /// <summary>
        /// This field is allowed and required for transactions that have a product where surcharge is configured. Use only integer numbers, so $10.99 will be 1099.
        /// </summary>
        [JsonProperty("subtotal_amount", NullValueHandling = NullValueHandling.Ignore)]
        public int? SubtotalAmount { get; set; }

        /// <summary>
        /// This field is allowed and required for transactions that have a product where surcharge is configured. Use only integer numbers, so $10.99 will be 1099.
        /// </summary>
        [JsonProperty("surcharge_amount", NullValueHandling = NullValueHandling.Ignore)]
        public int? SurchargeAmount { get; set; }

        /// <summary>
        /// Tags
        /// </summary>
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.Tag> Tags { get; set; }

        /// <summary>
        /// Amount of Sales tax - If supplied, this amount should be included in the total transaction_amount field. Use only integer numbers, so $10.99 will be 1099.
        /// </summary>
        [JsonProperty("tax", NullValueHandling = NullValueHandling.Ignore)]
        public int? Tax { get; set; }

        /// <summary>
        /// Optional tip amount. Tip is not supported for lodging and ecommerce merchants. Use only integer numbers, so $10.99 will be 1099.
        /// </summary>
        [JsonProperty("tip_amount", NullValueHandling = NullValueHandling.Ignore)]
        public int? TipAmount { get; set; }

        /// <summary>
        /// Amount of the transaction. This should always be the desired settle amount of the transaction. Use only integer numbers, so $10.99 will be 1099.
        /// </summary>
        [JsonProperty("transaction_amount", NullValueHandling = NullValueHandling.Ignore)]
        public int? TransactionAmount { get; set; }

        /// <summary>
        /// See api_id page for more details
        /// </summary>
        [JsonProperty("transaction_api_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionApiId { get; set; }

        /// <summary>
        /// Custom field 1 for api users to store custom data
        /// </summary>
        [JsonProperty("transaction_c1", NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionC1 { get; set; }

        /// <summary>
        /// Custom field 2 for api users to store custom data
        /// </summary>
        [JsonProperty("transaction_c2", NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionC2 { get; set; }

        /// <summary>
        /// Custom field 3 for api users to store custom data
        /// </summary>
        [JsonProperty("transaction_c3", NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionC3 { get; set; }

        /// <summary>
        /// Custom field 4 for api users to store custom data
        /// </summary>
        [JsonProperty("transaction_c4", NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionC4 { get; set; }

        /// <summary>
        /// Transaction ID
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? CreatedTs { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? ModifiedTs { get; set; }

        /// <summary>
        /// For CC, this is the 'Name (as it appears) on Card'. For ACH, this is the 'Name on Account'.
        /// </summary>
        [JsonProperty("account_holder_name", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountHolderName { get; set; }

        /// <summary>
        /// Required for ACH transactions if account_vault_id is not provided.
        /// </summary>
        [JsonProperty("account_type", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountType { get; set; }

        /// <summary>
        /// This can be supplied in place of account_vault_id if you would like to use an account vault for the transaction and are using your own custom api_id's to track accountvaults in the system.
        /// </summary>
        [JsonProperty("account_vault_api_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountVaultApiId { get; set; }

        /// <summary>
        /// Required if account_number,  track_data, micr_data is not provided.
        /// </summary>
        [JsonProperty("account_vault_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountVaultId { get; set; }

        /// <summary>
        /// Required for ACH transactions in certain scenarios.
        /// </summary>
        [JsonProperty("ach_identifier", NullValueHandling = NullValueHandling.Ignore)]
        public string AchIdentifier { get; set; }

        /// <summary>
        /// Required for ACH transactions if account_vault_id is not provided.
        /// </summary>
        [JsonProperty("ach_sec_code", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.AchSecCode2Enum? AchSecCode { get; set; }

        /// <summary>
        /// Advance Deposit
        /// </summary>
        [JsonProperty("advance_deposit", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AdvanceDeposit { get; set; }

        /// <summary>
        /// Authorization Amount
        /// </summary>
        [JsonProperty("auth_amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? AuthAmount { get; set; }

        /// <summary>
        /// Required on force transactions. Ignored for all other actions.
        /// </summary>
        [JsonProperty("auth_code", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthCode { get; set; }

        /// <summary>
        /// AVS
        /// </summary>
        [JsonProperty("avs", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.AvsEnum? Avs { get; set; }

        /// <summary>
        /// AVS Enhanced
        /// </summary>
        [JsonProperty("avs_enhanced", NullValueHandling = NullValueHandling.Ignore)]
        public string AvsEnhanced { get; set; }

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
        [JsonProperty("check_number", NullValueHandling = NullValueHandling.Ignore)]
        public string CheckNumber { get; set; }

        /// <summary>
        /// Can be used to store customer IP Address
        /// </summary>
        [JsonProperty("customer_ip", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerIp { get; set; }

        /// <summary>
        /// Obfuscated CVV
        /// </summary>
        [JsonProperty("cvv_response", NullValueHandling = NullValueHandling.Ignore)]
        public string CvvResponse { get; set; }

        /// <summary>
        /// Entry Mode - See entry mode section for more detail
        /// </summary>
        [JsonProperty("entry_mode_id", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.EntryModeIdEnum? EntryModeId { get; set; }

        /// <summary>
        /// This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM
        /// </summary>
        [JsonProperty("emv_receipt_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.EmvReceiptData EmvReceiptData { get; set; }

        /// <summary>
        /// First six numbers of account_number.  Automatically generated by system.
        /// </summary>
        [JsonProperty("first_six", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstSix { get; set; }

        /// <summary>
        /// Last four numbers of account_number.  Automatically generated by the system.
        /// </summary>
        [JsonProperty("last_four", NullValueHandling = NullValueHandling.Ignore)]
        public string LastFour { get; set; }

        /// <summary>
        /// 'cc' or 'ach'
        /// </summary>
        [JsonProperty("payment_method", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentMethod4Enum? PaymentMethod { get; set; }

        /// <summary>
        /// If transaction was processed using a terminal, this field would contain the terminal's serial number
        /// </summary>
        [JsonProperty("terminal_serial_number", NullValueHandling = NullValueHandling.Ignore)]
        public string TerminalSerialNumber { get; set; }

        /// <summary>
        /// (Deprecated field)
        /// </summary>
        [JsonProperty("transaction_settlement_status", NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionSettlementStatus { get; set; }

        /// <summary>
        /// Charge Back Date (ACH Trxs)
        /// </summary>
        [JsonProperty("charge_back_date", NullValueHandling = NullValueHandling.Ignore)]
        public string ChargeBackDate { get; set; }

        /// <summary>
        /// Flag that is allowed to be passed on card not present industries to signify the transaction is a fixed installment plan transaction.
        /// </summary>
        [JsonProperty("is_recurring", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRecurring { get; set; }

        /// <summary>
        /// Indicates if email receipt has been sent
        /// </summary>
        [JsonProperty("notification_email_sent", NullValueHandling = NullValueHandling.Ignore)]
        public string NotificationEmailSent { get; set; }

        /// <summary>
        /// A field usually returned form the processor to uniquely identifier a specific cardholder's credit card.
        /// </summary>
        [JsonProperty("par", NullValueHandling = NullValueHandling.Ignore)]
        public string Par { get; set; }

        /// <summary>
        /// Response reason code that provides more detail as to the result of the transaction. The reason code list can be found here: Response Reason Codes
        /// </summary>
        [JsonProperty("reason_code_id", NullValueHandling = NullValueHandling.Ignore)]
        public double? ReasonCodeId { get; set; }

        /// <summary>
        /// A unique identifer used to associate a transaction with a Recurring.
        /// </summary>
        [JsonProperty("recurring_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RecurringId { get; set; }

        /// <summary>
        /// Settle date
        /// </summary>
        [JsonProperty("settle_date", NullValueHandling = NullValueHandling.Ignore)]
        public string SettleDate { get; set; }

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
        [JsonProperty("status_id", NullValueHandling = NullValueHandling.Ignore)]
        public Models.StatusId2Enum? StatusId { get; set; }

        /// <summary>
        /// For cc transactions, this is the id of the batch the transaction belongs to (not to be confused with batch number). This will be null for transactions that do not settle (void and authonly).
        /// </summary>
        [JsonProperty("transaction_batch_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionBatchId { get; set; }

        /// <summary>
        /// Type ID - See type id section for more detail
        /// </summary>
        [JsonProperty("type_id", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TypeIdEnum? TypeId { get; set; }

        /// <summary>
        /// Verbiage -Do not use verbiage to see if the transaction was approved, use status_id
        /// </summary>
        [JsonProperty("verbiage", NullValueHandling = NullValueHandling.Ignore)]
        public string Verbiage { get; set; }

        /// <summary>
        /// void date
        /// </summary>
        [JsonProperty("void_date", NullValueHandling = NullValueHandling.Ignore)]
        public string VoidDate { get; set; }

        /// <summary>
        /// Batch
        /// </summary>
        [JsonProperty("batch", NullValueHandling = NullValueHandling.Ignore)]
        public string Batch { get; set; }

        /// <summary>
        /// Terms Agreement
        /// </summary>
        [JsonProperty("terms_agree", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TermsAgree { get; set; }

        /// <summary>
        /// Response Message
        /// </summary>
        [JsonProperty("response_message", NullValueHandling = NullValueHandling.Ignore)]
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Return Date
        /// </summary>
        [JsonProperty("return_date", NullValueHandling = NullValueHandling.Ignore)]
        public string ReturnDate { get; set; }

        /// <summary>
        /// How the transaction was obtained by the API.
        /// </summary>
        [JsonProperty("trx_source_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? TrxSourceId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Filter11 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Filter11 other &&
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
                ((this.TransactionAmount == null && other.TransactionAmount == null) || (this.TransactionAmount?.Equals(other.TransactionAmount) == true)) &&
                ((this.TransactionApiId == null && other.TransactionApiId == null) || (this.TransactionApiId?.Equals(other.TransactionApiId) == true)) &&
                ((this.TransactionC1 == null && other.TransactionC1 == null) || (this.TransactionC1?.Equals(other.TransactionC1) == true)) &&
                ((this.TransactionC2 == null && other.TransactionC2 == null) || (this.TransactionC2?.Equals(other.TransactionC2) == true)) &&
                ((this.TransactionC3 == null && other.TransactionC3 == null) || (this.TransactionC3?.Equals(other.TransactionC3) == true)) &&
                ((this.TransactionC4 == null && other.TransactionC4 == null) || (this.TransactionC4?.Equals(other.TransactionC4) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.ModifiedTs == null && other.ModifiedTs == null) || (this.ModifiedTs?.Equals(other.ModifiedTs) == true)) &&
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
                ((this.PaymentMethod == null && other.PaymentMethod == null) || (this.PaymentMethod?.Equals(other.PaymentMethod) == true)) &&
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
            toStringOutput.Add($"this.TransactionAmount = {(this.TransactionAmount == null ? "null" : this.TransactionAmount.ToString())}");
            toStringOutput.Add($"this.TransactionApiId = {(this.TransactionApiId == null ? "null" : this.TransactionApiId == string.Empty ? "" : this.TransactionApiId)}");
            toStringOutput.Add($"this.TransactionC1 = {(this.TransactionC1 == null ? "null" : this.TransactionC1 == string.Empty ? "" : this.TransactionC1)}");
            toStringOutput.Add($"this.TransactionC2 = {(this.TransactionC2 == null ? "null" : this.TransactionC2 == string.Empty ? "" : this.TransactionC2)}");
            toStringOutput.Add($"this.TransactionC3 = {(this.TransactionC3 == null ? "null" : this.TransactionC3 == string.Empty ? "" : this.TransactionC3)}");
            toStringOutput.Add($"this.TransactionC4 = {(this.TransactionC4 == null ? "null" : this.TransactionC4 == string.Empty ? "" : this.TransactionC4)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.ModifiedTs = {(this.ModifiedTs == null ? "null" : this.ModifiedTs.ToString())}");
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
            toStringOutput.Add($"this.PaymentMethod = {(this.PaymentMethod == null ? "null" : this.PaymentMethod.ToString())}");
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