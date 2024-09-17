// <copyright file="List9.cs" company="APIMatic">
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
    using FortisAPI.Standard.Http.Client;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// List9.
    /// </summary>
    public class List9 : BaseModel
    {
        private string locationId;
        private string ccProductTransactionId;
        private string achProductTransactionId;
        private bool? bankFundedOnlyOverride;
        private string email;
        private string contactId;
        private string contactApiId;
        private string quickInvoiceApiId;
        private string customerId;
        private string expireDate;
        private string invoiceNumber;
        private string itemHeader;
        private string itemFooter;
        private double? amountDue;
        private string notificationEmail;
        private Models.StatusIdEnum? statusId;
        private Models.StatusCode12Enum? statusCode;
        private string note;
        private int? notificationDaysBeforeDueDate;
        private int? notificationDaysAfterDueDate;
        private double? remainingBalance;
        private int? singlePaymentMinAmount;
        private int? singlePaymentMaxAmount;
        private string cellPhone;
        private string createdUserId;
        private string modifiedUserId;
        private int? paymentStatusId;
        private string paymentUrl;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "location_id", false },
            { "cc_product_transaction_id", false },
            { "ach_product_transaction_id", false },
            { "bank_funded_only_override", false },
            { "email", false },
            { "contact_id", false },
            { "contact_api_id", false },
            { "quick_invoice_api_id", false },
            { "customer_id", false },
            { "expire_date", false },
            { "invoice_number", false },
            { "item_header", false },
            { "item_footer", false },
            { "amount_due", false },
            { "notification_email", false },
            { "status_id", false },
            { "status_code", false },
            { "note", false },
            { "notification_days_before_due_date", false },
            { "notification_days_after_due_date", false },
            { "remaining_balance", false },
            { "single_payment_min_amount", false },
            { "single_payment_max_amount", true },
            { "cell_phone", false },
            { "created_user_id", false },
            { "modified_user_id", false },
            { "payment_status_id", false },
            { "payment_url", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="List9"/> class.
        /// </summary>
        public List9()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="List9"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="dueDate">due_date.</param>
        /// <param name="itemList">item_list.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="ccProductTransactionId">cc_product_transaction_id.</param>
        /// <param name="achProductTransactionId">ach_product_transaction_id.</param>
        /// <param name="allowOverpayment">allow_overpayment.</param>
        /// <param name="bankFundedOnlyOverride">bank_funded_only_override.</param>
        /// <param name="email">email.</param>
        /// <param name="contactId">contact_id.</param>
        /// <param name="contactApiId">contact_api_id.</param>
        /// <param name="quickInvoiceApiId">quick_invoice_api_id.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="expireDate">expire_date.</param>
        /// <param name="allowPartialPay">allow_partial_pay.</param>
        /// <param name="attachFilesToEmail">attach_files_to_email.</param>
        /// <param name="sendEmail">send_email.</param>
        /// <param name="invoiceNumber">invoice_number.</param>
        /// <param name="itemHeader">item_header.</param>
        /// <param name="itemFooter">item_footer.</param>
        /// <param name="amountDue">amount_due.</param>
        /// <param name="notificationEmail">notification_email.</param>
        /// <param name="statusId">status_id.</param>
        /// <param name="statusCode">status_code.</param>
        /// <param name="note">note.</param>
        /// <param name="notificationDaysBeforeDueDate">notification_days_before_due_date.</param>
        /// <param name="notificationDaysAfterDueDate">notification_days_after_due_date.</param>
        /// <param name="notificationOnDueDate">notification_on_due_date.</param>
        /// <param name="sendTextToPay">send_text_to_pay.</param>
        /// <param name="files">files.</param>
        /// <param name="remainingBalance">remaining_balance.</param>
        /// <param name="singlePaymentMinAmount">single_payment_min_amount.</param>
        /// <param name="singlePaymentMaxAmount">single_payment_max_amount.</param>
        /// <param name="cellPhone">cell_phone.</param>
        /// <param name="tags">tags.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="modifiedUserId">modified_user_id.</param>
        /// <param name="active">active.</param>
        /// <param name="paymentStatusId">payment_status_id.</param>
        /// <param name="isActive">is_active.</param>
        /// <param name="quickInvoiceSetting">quick_invoice_setting.</param>
        /// <param name="quickInvoiceViews">quick_invoice_views.</param>
        /// <param name="location">location.</param>
        /// <param name="createdUser">created_user.</param>
        /// <param name="modifiedUser">modified_user.</param>
        /// <param name="changelogs">changelogs.</param>
        /// <param name="contact">contact.</param>
        /// <param name="logEmails">log_emails.</param>
        /// <param name="logSms">log_sms.</param>
        /// <param name="transactions">transactions.</param>
        /// <param name="ccProductTransaction">cc_product_transaction.</param>
        /// <param name="achProductTransaction">ach_product_transaction.</param>
        /// <param name="emailBlacklist">email_blacklist.</param>
        /// <param name="smsBlacklist">sms_blacklist.</param>
        /// <param name="paymentUrl">payment_url.</param>
        public List9(
            string title,
            string dueDate,
            List<Models.ItemList> itemList,
            string id,
            int createdTs,
            int modifiedTs,
            string locationId = null,
            string ccProductTransactionId = null,
            string achProductTransactionId = null,
            bool? allowOverpayment = null,
            bool? bankFundedOnlyOverride = null,
            string email = null,
            string contactId = null,
            string contactApiId = null,
            string quickInvoiceApiId = null,
            string customerId = null,
            string expireDate = null,
            bool? allowPartialPay = null,
            bool? attachFilesToEmail = null,
            bool? sendEmail = null,
            string invoiceNumber = null,
            string itemHeader = null,
            string itemFooter = null,
            double? amountDue = null,
            string notificationEmail = null,
            Models.StatusIdEnum? statusId = null,
            Models.StatusCode12Enum? statusCode = null,
            string note = null,
            int? notificationDaysBeforeDueDate = null,
            int? notificationDaysAfterDueDate = null,
            bool? notificationOnDueDate = null,
            bool? sendTextToPay = null,
            List<Models.File> files = null,
            double? remainingBalance = null,
            int? singlePaymentMinAmount = null,
            int? singlePaymentMaxAmount = 999999999,
            string cellPhone = null,
            List<Models.Tag> tags = null,
            string createdUserId = null,
            string modifiedUserId = null,
            bool? active = null,
            int? paymentStatusId = null,
            bool? isActive = null,
            Models.QuickInvoiceSetting quickInvoiceSetting = null,
            List<Models.QuickInvoiceView> quickInvoiceViews = null,
            Models.Location location = null,
            Models.CreatedUser createdUser = null,
            Models.ModifiedUser modifiedUser = null,
            List<Models.Changelog> changelogs = null,
            Models.Contact1 contact = null,
            List<Models.LogEmail> logEmails = null,
            Models.LogSms logSms = null,
            List<Models.Transaction> transactions = null,
            Models.CcProductTransaction ccProductTransaction = null,
            Models.AchProductTransaction achProductTransaction = null,
            Models.EmailBlacklist emailBlacklist = null,
            Models.SmsBlacklist smsBlacklist = null,
            string paymentUrl = null)
        {
            if (locationId != null)
            {
                this.LocationId = locationId;
            }

            this.Title = title;
            if (ccProductTransactionId != null)
            {
                this.CcProductTransactionId = ccProductTransactionId;
            }

            if (achProductTransactionId != null)
            {
                this.AchProductTransactionId = achProductTransactionId;
            }

            this.DueDate = dueDate;
            this.ItemList = itemList;
            this.AllowOverpayment = allowOverpayment;
            if (bankFundedOnlyOverride != null)
            {
                this.BankFundedOnlyOverride = bankFundedOnlyOverride;
            }

            if (email != null)
            {
                this.Email = email;
            }

            if (contactId != null)
            {
                this.ContactId = contactId;
            }

            if (contactApiId != null)
            {
                this.ContactApiId = contactApiId;
            }

            if (quickInvoiceApiId != null)
            {
                this.QuickInvoiceApiId = quickInvoiceApiId;
            }

            if (customerId != null)
            {
                this.CustomerId = customerId;
            }

            if (expireDate != null)
            {
                this.ExpireDate = expireDate;
            }

            this.AllowPartialPay = allowPartialPay;
            this.AttachFilesToEmail = attachFilesToEmail;
            this.SendEmail = sendEmail;
            if (invoiceNumber != null)
            {
                this.InvoiceNumber = invoiceNumber;
            }

            if (itemHeader != null)
            {
                this.ItemHeader = itemHeader;
            }

            if (itemFooter != null)
            {
                this.ItemFooter = itemFooter;
            }

            if (amountDue != null)
            {
                this.AmountDue = amountDue;
            }

            if (notificationEmail != null)
            {
                this.NotificationEmail = notificationEmail;
            }

            if (statusId != null)
            {
                this.StatusId = statusId;
            }

            if (statusCode != null)
            {
                this.StatusCode = statusCode;
            }

            if (note != null)
            {
                this.Note = note;
            }

            if (notificationDaysBeforeDueDate != null)
            {
                this.NotificationDaysBeforeDueDate = notificationDaysBeforeDueDate;
            }

            if (notificationDaysAfterDueDate != null)
            {
                this.NotificationDaysAfterDueDate = notificationDaysAfterDueDate;
            }

            this.NotificationOnDueDate = notificationOnDueDate;
            this.SendTextToPay = sendTextToPay;
            this.Files = files;
            if (remainingBalance != null)
            {
                this.RemainingBalance = remainingBalance;
            }

            if (singlePaymentMinAmount != null)
            {
                this.SinglePaymentMinAmount = singlePaymentMinAmount;
            }

            this.SinglePaymentMaxAmount = singlePaymentMaxAmount;
            if (cellPhone != null)
            {
                this.CellPhone = cellPhone;
            }

            this.Tags = tags;
            this.Id = id;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            if (createdUserId != null)
            {
                this.CreatedUserId = createdUserId;
            }

            if (modifiedUserId != null)
            {
                this.ModifiedUserId = modifiedUserId;
            }

            this.Active = active;
            if (paymentStatusId != null)
            {
                this.PaymentStatusId = paymentStatusId;
            }

            this.IsActive = isActive;
            this.QuickInvoiceSetting = quickInvoiceSetting;
            this.QuickInvoiceViews = quickInvoiceViews;
            this.Location = location;
            this.CreatedUser = createdUser;
            this.ModifiedUser = modifiedUser;
            this.Changelogs = changelogs;
            this.Contact = contact;
            this.LogEmails = logEmails;
            this.LogSms = logSms;
            this.Transactions = transactions;
            this.CcProductTransaction = ccProductTransaction;
            this.AchProductTransaction = achProductTransaction;
            this.EmailBlacklist = emailBlacklist;
            this.SmsBlacklist = smsBlacklist;
            if (paymentUrl != null)
            {
                this.PaymentUrl = paymentUrl;
            }

        }

        /// <summary>
        /// Location ID
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
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Transaction ID
        /// </summary>
        [JsonProperty("cc_product_transaction_id")]
        public string CcProductTransactionId
        {
            get
            {
                return this.ccProductTransactionId;
            }

            set
            {
                this.shouldSerialize["cc_product_transaction_id"] = true;
                this.ccProductTransactionId = value;
            }
        }

        /// <summary>
        /// ACH Product Transaction Id
        /// </summary>
        [JsonProperty("ach_product_transaction_id")]
        public string AchProductTransactionId
        {
            get
            {
                return this.achProductTransactionId;
            }

            set
            {
                this.shouldSerialize["ach_product_transaction_id"] = true;
                this.achProductTransactionId = value;
            }
        }

        /// <summary>
        /// Due Date, Format: Y-m-d
        /// </summary>
        [JsonProperty("due_date")]
        public string DueDate { get; set; }

        /// <summary>
        /// Item List
        /// </summary>
        [JsonProperty("item_list")]
        public List<Models.ItemList> ItemList { get; set; }

        /// <summary>
        /// Allow Overpayment.
        /// </summary>
        [JsonProperty("allow_overpayment", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowOverpayment { get; set; }

        /// <summary>
        /// Bank Funded Only override
        /// </summary>
        [JsonProperty("bank_funded_only_override")]
        public bool? BankFundedOnlyOverride
        {
            get
            {
                return this.bankFundedOnlyOverride;
            }

            set
            {
                this.shouldSerialize["bank_funded_only_override"] = true;
                this.bankFundedOnlyOverride = value;
            }
        }

        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty("email")]
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.shouldSerialize["email"] = true;
                this.email = value;
            }
        }

        /// <summary>
        /// Contact ID
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
        /// Contact API Id
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
        /// Quick Invoice API Id
        /// </summary>
        [JsonProperty("quick_invoice_api_id")]
        public string QuickInvoiceApiId
        {
            get
            {
                return this.quickInvoiceApiId;
            }

            set
            {
                this.shouldSerialize["quick_invoice_api_id"] = true;
                this.quickInvoiceApiId = value;
            }
        }

        /// <summary>
        /// Customer Id
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
        /// Expire Date.
        /// </summary>
        [JsonProperty("expire_date")]
        public string ExpireDate
        {
            get
            {
                return this.expireDate;
            }

            set
            {
                this.shouldSerialize["expire_date"] = true;
                this.expireDate = value;
            }
        }

        /// <summary>
        /// Allow partial pay
        /// </summary>
        [JsonProperty("allow_partial_pay", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowPartialPay { get; set; }

        /// <summary>
        /// Attach Files to Email
        /// </summary>
        [JsonProperty("attach_files_to_email", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AttachFilesToEmail { get; set; }

        /// <summary>
        /// Send Email
        /// </summary>
        [JsonProperty("send_email", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SendEmail { get; set; }

        /// <summary>
        /// Invoice number
        /// </summary>
        [JsonProperty("invoice_number")]
        public string InvoiceNumber
        {
            get
            {
                return this.invoiceNumber;
            }

            set
            {
                this.shouldSerialize["invoice_number"] = true;
                this.invoiceNumber = value;
            }
        }

        /// <summary>
        /// Item Header
        /// </summary>
        [JsonProperty("item_header")]
        public string ItemHeader
        {
            get
            {
                return this.itemHeader;
            }

            set
            {
                this.shouldSerialize["item_header"] = true;
                this.itemHeader = value;
            }
        }

        /// <summary>
        /// Item footer
        /// </summary>
        [JsonProperty("item_footer")]
        public string ItemFooter
        {
            get
            {
                return this.itemFooter;
            }

            set
            {
                this.shouldSerialize["item_footer"] = true;
                this.itemFooter = value;
            }
        }

        /// <summary>
        /// Amount Due
        /// </summary>
        [JsonProperty("amount_due")]
        public double? AmountDue
        {
            get
            {
                return this.amountDue;
            }

            set
            {
                this.shouldSerialize["amount_due"] = true;
                this.amountDue = value;
            }
        }

        /// <summary>
        /// Notification email
        /// </summary>
        [JsonProperty("notification_email")]
        public string NotificationEmail
        {
            get
            {
                return this.notificationEmail;
            }

            set
            {
                this.shouldSerialize["notification_email"] = true;
                this.notificationEmail = value;
            }
        }

        /// <summary>
        /// (DEPRECATED) Status Id
        /// </summary>
        [JsonProperty("status_id")]
        public Models.StatusIdEnum? StatusId
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
        /// Status Code
        /// </summary>
        [JsonProperty("status_code")]
        public Models.StatusCode12Enum? StatusCode
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
        /// Note
        /// </summary>
        [JsonProperty("note")]
        public string Note
        {
            get
            {
                return this.note;
            }

            set
            {
                this.shouldSerialize["note"] = true;
                this.note = value;
            }
        }

        /// <summary>
        /// Notification days before due date
        /// </summary>
        [JsonProperty("notification_days_before_due_date")]
        public int? NotificationDaysBeforeDueDate
        {
            get
            {
                return this.notificationDaysBeforeDueDate;
            }

            set
            {
                this.shouldSerialize["notification_days_before_due_date"] = true;
                this.notificationDaysBeforeDueDate = value;
            }
        }

        /// <summary>
        /// Notification days after due date
        /// </summary>
        [JsonProperty("notification_days_after_due_date")]
        public int? NotificationDaysAfterDueDate
        {
            get
            {
                return this.notificationDaysAfterDueDate;
            }

            set
            {
                this.shouldSerialize["notification_days_after_due_date"] = true;
                this.notificationDaysAfterDueDate = value;
            }
        }

        /// <summary>
        /// Notification on due date
        /// </summary>
        [JsonProperty("notification_on_due_date", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NotificationOnDueDate { get; set; }

        /// <summary>
        /// Send Text To Pay
        /// </summary>
        [JsonProperty("send_text_to_pay", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SendTextToPay { get; set; }

        /// <summary>
        /// File Information on `expand`
        /// </summary>
        [JsonProperty("files", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.File> Files { get; set; }

        /// <summary>
        /// Remaining Balance
        /// </summary>
        [JsonProperty("remaining_balance")]
        public double? RemainingBalance
        {
            get
            {
                return this.remainingBalance;
            }

            set
            {
                this.shouldSerialize["remaining_balance"] = true;
                this.remainingBalance = value;
            }
        }

        /// <summary>
        /// Single Payment Min Amount
        /// </summary>
        [JsonProperty("single_payment_min_amount")]
        public int? SinglePaymentMinAmount
        {
            get
            {
                return this.singlePaymentMinAmount;
            }

            set
            {
                this.shouldSerialize["single_payment_min_amount"] = true;
                this.singlePaymentMinAmount = value;
            }
        }

        /// <summary>
        /// Single Payment Max Amount
        /// </summary>
        [JsonProperty("single_payment_max_amount")]
        public int? SinglePaymentMaxAmount
        {
            get
            {
                return this.singlePaymentMaxAmount;
            }

            set
            {
                this.shouldSerialize["single_payment_max_amount"] = true;
                this.singlePaymentMaxAmount = value;
            }
        }

        /// <summary>
        /// Cell Phone
        /// </summary>
        [JsonProperty("cell_phone")]
        public string CellPhone
        {
            get
            {
                return this.cellPhone;
            }

            set
            {
                this.shouldSerialize["cell_phone"] = true;
                this.cellPhone = value;
            }
        }

        /// <summary>
        /// Tag Information on `expand`
        /// </summary>
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.Tag> Tags { get; set; }

        /// <summary>
        /// Quick Invoice ID
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
        /// Created User Id
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
        /// Modified User Id
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
        /// Active status
        /// </summary>
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Active { get; set; }

        /// <summary>
        /// Payment Status Id
        /// </summary>
        [JsonProperty("payment_status_id")]
        public int? PaymentStatusId
        {
            get
            {
                return this.paymentStatusId;
            }

            set
            {
                this.shouldSerialize["payment_status_id"] = true;
                this.paymentStatusId = value;
            }
        }

        /// <summary>
        /// Register is active
        /// </summary>
        [JsonProperty("is_active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Quick Invoice Setting Information on `expand`
        /// </summary>
        [JsonProperty("quick_invoice_setting", NullValueHandling = NullValueHandling.Ignore)]
        public Models.QuickInvoiceSetting QuickInvoiceSetting { get; set; }

        /// <summary>
        /// Quick Invoice View Information on `expand`
        /// </summary>
        [JsonProperty("quick_invoice_views", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.QuickInvoiceView> QuickInvoiceViews { get; set; }

        /// <summary>
        /// Location Information on `expand`
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Location Location { get; set; }

        /// <summary>
        /// User Information on `expand`
        /// </summary>
        [JsonProperty("created_user", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CreatedUser CreatedUser { get; set; }

        /// <summary>
        /// Modified User Information on `expand`
        /// </summary>
        [JsonProperty("modified_user", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ModifiedUser ModifiedUser { get; set; }

        /// <summary>
        /// Changelog Information on `expand`
        /// </summary>
        [JsonProperty("changelogs", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.Changelog> Changelogs { get; set; }

        /// <summary>
        /// Contact Information on `expand`
        /// </summary>
        [JsonProperty("contact", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Contact1 Contact { get; set; }

        /// <summary>
        /// Log Email Information on `expand`
        /// </summary>
        [JsonProperty("log_emails", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.LogEmail> LogEmails { get; set; }

        /// <summary>
        /// Log Sms Information on `expand`
        /// </summary>
        [JsonProperty("log_sms", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LogSms LogSms { get; set; }

        /// <summary>
        /// Transaction Information on `expand`
        /// </summary>
        [JsonProperty("transactions", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.Transaction> Transactions { get; set; }

        /// <summary>
        /// Cc Product Transaction Information on `expand`
        /// </summary>
        [JsonProperty("cc_product_transaction", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CcProductTransaction CcProductTransaction { get; set; }

        /// <summary>
        /// Ach Product Transaction Information on `expand`
        /// </summary>
        [JsonProperty("ach_product_transaction", NullValueHandling = NullValueHandling.Ignore)]
        public Models.AchProductTransaction AchProductTransaction { get; set; }

        /// <summary>
        /// Email Blacklist Information on `expand`
        /// </summary>
        [JsonProperty("email_blacklist", NullValueHandling = NullValueHandling.Ignore)]
        public Models.EmailBlacklist EmailBlacklist { get; set; }

        /// <summary>
        /// Sms Blacklist Information on `expand`
        /// </summary>
        [JsonProperty("sms_blacklist", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SmsBlacklist SmsBlacklist { get; set; }

        /// <summary>
        /// Payment Url Information on `expand`
        /// </summary>
        [JsonProperty("payment_url")]
        public string PaymentUrl
        {
            get
            {
                return this.paymentUrl;
            }

            set
            {
                this.shouldSerialize["payment_url"] = true;
                this.paymentUrl = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"List9 : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetCcProductTransactionId()
        {
            this.shouldSerialize["cc_product_transaction_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAchProductTransactionId()
        {
            this.shouldSerialize["ach_product_transaction_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetBankFundedOnlyOverride()
        {
            this.shouldSerialize["bank_funded_only_override"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEmail()
        {
            this.shouldSerialize["email"] = false;
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
        public void UnsetContactApiId()
        {
            this.shouldSerialize["contact_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetQuickInvoiceApiId()
        {
            this.shouldSerialize["quick_invoice_api_id"] = false;
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
        public void UnsetExpireDate()
        {
            this.shouldSerialize["expire_date"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetInvoiceNumber()
        {
            this.shouldSerialize["invoice_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetItemHeader()
        {
            this.shouldSerialize["item_header"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetItemFooter()
        {
            this.shouldSerialize["item_footer"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAmountDue()
        {
            this.shouldSerialize["amount_due"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetNotificationEmail()
        {
            this.shouldSerialize["notification_email"] = false;
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
        public void UnsetStatusCode()
        {
            this.shouldSerialize["status_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetNote()
        {
            this.shouldSerialize["note"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetNotificationDaysBeforeDueDate()
        {
            this.shouldSerialize["notification_days_before_due_date"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetNotificationDaysAfterDueDate()
        {
            this.shouldSerialize["notification_days_after_due_date"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRemainingBalance()
        {
            this.shouldSerialize["remaining_balance"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSinglePaymentMinAmount()
        {
            this.shouldSerialize["single_payment_min_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSinglePaymentMaxAmount()
        {
            this.shouldSerialize["single_payment_max_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCellPhone()
        {
            this.shouldSerialize["cell_phone"] = false;
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
        public void UnsetPaymentStatusId()
        {
            this.shouldSerialize["payment_status_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPaymentUrl()
        {
            this.shouldSerialize["payment_url"] = false;
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
        public bool ShouldSerializeCcProductTransactionId()
        {
            return this.shouldSerialize["cc_product_transaction_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAchProductTransactionId()
        {
            return this.shouldSerialize["ach_product_transaction_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBankFundedOnlyOverride()
        {
            return this.shouldSerialize["bank_funded_only_override"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmail()
        {
            return this.shouldSerialize["email"];
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
        public bool ShouldSerializeContactApiId()
        {
            return this.shouldSerialize["contact_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeQuickInvoiceApiId()
        {
            return this.shouldSerialize["quick_invoice_api_id"];
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
        public bool ShouldSerializeExpireDate()
        {
            return this.shouldSerialize["expire_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInvoiceNumber()
        {
            return this.shouldSerialize["invoice_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeItemHeader()
        {
            return this.shouldSerialize["item_header"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeItemFooter()
        {
            return this.shouldSerialize["item_footer"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAmountDue()
        {
            return this.shouldSerialize["amount_due"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNotificationEmail()
        {
            return this.shouldSerialize["notification_email"];
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
        public bool ShouldSerializeStatusCode()
        {
            return this.shouldSerialize["status_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNote()
        {
            return this.shouldSerialize["note"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNotificationDaysBeforeDueDate()
        {
            return this.shouldSerialize["notification_days_before_due_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNotificationDaysAfterDueDate()
        {
            return this.shouldSerialize["notification_days_after_due_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRemainingBalance()
        {
            return this.shouldSerialize["remaining_balance"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSinglePaymentMinAmount()
        {
            return this.shouldSerialize["single_payment_min_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSinglePaymentMaxAmount()
        {
            return this.shouldSerialize["single_payment_max_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCellPhone()
        {
            return this.shouldSerialize["cell_phone"];
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
        public bool ShouldSerializePaymentStatusId()
        {
            return this.shouldSerialize["payment_status_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentUrl()
        {
            return this.shouldSerialize["payment_url"];
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
            return obj is List9 other &&                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.CcProductTransactionId == null && other.CcProductTransactionId == null) || (this.CcProductTransactionId?.Equals(other.CcProductTransactionId) == true)) &&
                ((this.AchProductTransactionId == null && other.AchProductTransactionId == null) || (this.AchProductTransactionId?.Equals(other.AchProductTransactionId) == true)) &&
                ((this.DueDate == null && other.DueDate == null) || (this.DueDate?.Equals(other.DueDate) == true)) &&
                ((this.ItemList == null && other.ItemList == null) || (this.ItemList?.Equals(other.ItemList) == true)) &&
                ((this.AllowOverpayment == null && other.AllowOverpayment == null) || (this.AllowOverpayment?.Equals(other.AllowOverpayment) == true)) &&
                ((this.BankFundedOnlyOverride == null && other.BankFundedOnlyOverride == null) || (this.BankFundedOnlyOverride?.Equals(other.BankFundedOnlyOverride) == true)) &&
                ((this.Email == null && other.Email == null) || (this.Email?.Equals(other.Email) == true)) &&
                ((this.ContactId == null && other.ContactId == null) || (this.ContactId?.Equals(other.ContactId) == true)) &&
                ((this.ContactApiId == null && other.ContactApiId == null) || (this.ContactApiId?.Equals(other.ContactApiId) == true)) &&
                ((this.QuickInvoiceApiId == null && other.QuickInvoiceApiId == null) || (this.QuickInvoiceApiId?.Equals(other.QuickInvoiceApiId) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.ExpireDate == null && other.ExpireDate == null) || (this.ExpireDate?.Equals(other.ExpireDate) == true)) &&
                ((this.AllowPartialPay == null && other.AllowPartialPay == null) || (this.AllowPartialPay?.Equals(other.AllowPartialPay) == true)) &&
                ((this.AttachFilesToEmail == null && other.AttachFilesToEmail == null) || (this.AttachFilesToEmail?.Equals(other.AttachFilesToEmail) == true)) &&
                ((this.SendEmail == null && other.SendEmail == null) || (this.SendEmail?.Equals(other.SendEmail) == true)) &&
                ((this.InvoiceNumber == null && other.InvoiceNumber == null) || (this.InvoiceNumber?.Equals(other.InvoiceNumber) == true)) &&
                ((this.ItemHeader == null && other.ItemHeader == null) || (this.ItemHeader?.Equals(other.ItemHeader) == true)) &&
                ((this.ItemFooter == null && other.ItemFooter == null) || (this.ItemFooter?.Equals(other.ItemFooter) == true)) &&
                ((this.AmountDue == null && other.AmountDue == null) || (this.AmountDue?.Equals(other.AmountDue) == true)) &&
                ((this.NotificationEmail == null && other.NotificationEmail == null) || (this.NotificationEmail?.Equals(other.NotificationEmail) == true)) &&
                ((this.StatusId == null && other.StatusId == null) || (this.StatusId?.Equals(other.StatusId) == true)) &&
                ((this.StatusCode == null && other.StatusCode == null) || (this.StatusCode?.Equals(other.StatusCode) == true)) &&
                ((this.Note == null && other.Note == null) || (this.Note?.Equals(other.Note) == true)) &&
                ((this.NotificationDaysBeforeDueDate == null && other.NotificationDaysBeforeDueDate == null) || (this.NotificationDaysBeforeDueDate?.Equals(other.NotificationDaysBeforeDueDate) == true)) &&
                ((this.NotificationDaysAfterDueDate == null && other.NotificationDaysAfterDueDate == null) || (this.NotificationDaysAfterDueDate?.Equals(other.NotificationDaysAfterDueDate) == true)) &&
                ((this.NotificationOnDueDate == null && other.NotificationOnDueDate == null) || (this.NotificationOnDueDate?.Equals(other.NotificationOnDueDate) == true)) &&
                ((this.SendTextToPay == null && other.SendTextToPay == null) || (this.SendTextToPay?.Equals(other.SendTextToPay) == true)) &&
                ((this.Files == null && other.Files == null) || (this.Files?.Equals(other.Files) == true)) &&
                ((this.RemainingBalance == null && other.RemainingBalance == null) || (this.RemainingBalance?.Equals(other.RemainingBalance) == true)) &&
                ((this.SinglePaymentMinAmount == null && other.SinglePaymentMinAmount == null) || (this.SinglePaymentMinAmount?.Equals(other.SinglePaymentMinAmount) == true)) &&
                ((this.SinglePaymentMaxAmount == null && other.SinglePaymentMaxAmount == null) || (this.SinglePaymentMaxAmount?.Equals(other.SinglePaymentMaxAmount) == true)) &&
                ((this.CellPhone == null && other.CellPhone == null) || (this.CellPhone?.Equals(other.CellPhone) == true)) &&
                ((this.Tags == null && other.Tags == null) || (this.Tags?.Equals(other.Tags) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true)) &&
                ((this.ModifiedUserId == null && other.ModifiedUserId == null) || (this.ModifiedUserId?.Equals(other.ModifiedUserId) == true)) &&
                ((this.Active == null && other.Active == null) || (this.Active?.Equals(other.Active) == true)) &&
                ((this.PaymentStatusId == null && other.PaymentStatusId == null) || (this.PaymentStatusId?.Equals(other.PaymentStatusId) == true)) &&
                ((this.IsActive == null && other.IsActive == null) || (this.IsActive?.Equals(other.IsActive) == true)) &&
                ((this.QuickInvoiceSetting == null && other.QuickInvoiceSetting == null) || (this.QuickInvoiceSetting?.Equals(other.QuickInvoiceSetting) == true)) &&
                ((this.QuickInvoiceViews == null && other.QuickInvoiceViews == null) || (this.QuickInvoiceViews?.Equals(other.QuickInvoiceViews) == true)) &&
                ((this.Location == null && other.Location == null) || (this.Location?.Equals(other.Location) == true)) &&
                ((this.CreatedUser == null && other.CreatedUser == null) || (this.CreatedUser?.Equals(other.CreatedUser) == true)) &&
                ((this.ModifiedUser == null && other.ModifiedUser == null) || (this.ModifiedUser?.Equals(other.ModifiedUser) == true)) &&
                ((this.Changelogs == null && other.Changelogs == null) || (this.Changelogs?.Equals(other.Changelogs) == true)) &&
                ((this.Contact == null && other.Contact == null) || (this.Contact?.Equals(other.Contact) == true)) &&
                ((this.LogEmails == null && other.LogEmails == null) || (this.LogEmails?.Equals(other.LogEmails) == true)) &&
                ((this.LogSms == null && other.LogSms == null) || (this.LogSms?.Equals(other.LogSms) == true)) &&
                ((this.Transactions == null && other.Transactions == null) || (this.Transactions?.Equals(other.Transactions) == true)) &&
                ((this.CcProductTransaction == null && other.CcProductTransaction == null) || (this.CcProductTransaction?.Equals(other.CcProductTransaction) == true)) &&
                ((this.AchProductTransaction == null && other.AchProductTransaction == null) || (this.AchProductTransaction?.Equals(other.AchProductTransaction) == true)) &&
                ((this.EmailBlacklist == null && other.EmailBlacklist == null) || (this.EmailBlacklist?.Equals(other.EmailBlacklist) == true)) &&
                ((this.SmsBlacklist == null && other.SmsBlacklist == null) || (this.SmsBlacklist?.Equals(other.SmsBlacklist) == true)) &&
                ((this.PaymentUrl == null && other.PaymentUrl == null) || (this.PaymentUrl?.Equals(other.PaymentUrl) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
            toStringOutput.Add($"this.CcProductTransactionId = {(this.CcProductTransactionId == null ? "null" : this.CcProductTransactionId)}");
            toStringOutput.Add($"this.AchProductTransactionId = {(this.AchProductTransactionId == null ? "null" : this.AchProductTransactionId)}");
            toStringOutput.Add($"this.DueDate = {(this.DueDate == null ? "null" : this.DueDate)}");
            toStringOutput.Add($"this.ItemList = {(this.ItemList == null ? "null" : $"[{string.Join(", ", this.ItemList)} ]")}");
            toStringOutput.Add($"this.AllowOverpayment = {(this.AllowOverpayment == null ? "null" : this.AllowOverpayment.ToString())}");
            toStringOutput.Add($"this.BankFundedOnlyOverride = {(this.BankFundedOnlyOverride == null ? "null" : this.BankFundedOnlyOverride.ToString())}");
            toStringOutput.Add($"this.Email = {(this.Email == null ? "null" : this.Email)}");
            toStringOutput.Add($"this.ContactId = {(this.ContactId == null ? "null" : this.ContactId)}");
            toStringOutput.Add($"this.ContactApiId = {(this.ContactApiId == null ? "null" : this.ContactApiId)}");
            toStringOutput.Add($"this.QuickInvoiceApiId = {(this.QuickInvoiceApiId == null ? "null" : this.QuickInvoiceApiId)}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId)}");
            toStringOutput.Add($"this.ExpireDate = {(this.ExpireDate == null ? "null" : this.ExpireDate)}");
            toStringOutput.Add($"this.AllowPartialPay = {(this.AllowPartialPay == null ? "null" : this.AllowPartialPay.ToString())}");
            toStringOutput.Add($"this.AttachFilesToEmail = {(this.AttachFilesToEmail == null ? "null" : this.AttachFilesToEmail.ToString())}");
            toStringOutput.Add($"this.SendEmail = {(this.SendEmail == null ? "null" : this.SendEmail.ToString())}");
            toStringOutput.Add($"this.InvoiceNumber = {(this.InvoiceNumber == null ? "null" : this.InvoiceNumber)}");
            toStringOutput.Add($"this.ItemHeader = {(this.ItemHeader == null ? "null" : this.ItemHeader)}");
            toStringOutput.Add($"this.ItemFooter = {(this.ItemFooter == null ? "null" : this.ItemFooter)}");
            toStringOutput.Add($"this.AmountDue = {(this.AmountDue == null ? "null" : this.AmountDue.ToString())}");
            toStringOutput.Add($"this.NotificationEmail = {(this.NotificationEmail == null ? "null" : this.NotificationEmail)}");
            toStringOutput.Add($"this.StatusId = {(this.StatusId == null ? "null" : this.StatusId.ToString())}");
            toStringOutput.Add($"this.StatusCode = {(this.StatusCode == null ? "null" : this.StatusCode.ToString())}");
            toStringOutput.Add($"this.Note = {(this.Note == null ? "null" : this.Note)}");
            toStringOutput.Add($"this.NotificationDaysBeforeDueDate = {(this.NotificationDaysBeforeDueDate == null ? "null" : this.NotificationDaysBeforeDueDate.ToString())}");
            toStringOutput.Add($"this.NotificationDaysAfterDueDate = {(this.NotificationDaysAfterDueDate == null ? "null" : this.NotificationDaysAfterDueDate.ToString())}");
            toStringOutput.Add($"this.NotificationOnDueDate = {(this.NotificationOnDueDate == null ? "null" : this.NotificationOnDueDate.ToString())}");
            toStringOutput.Add($"this.SendTextToPay = {(this.SendTextToPay == null ? "null" : this.SendTextToPay.ToString())}");
            toStringOutput.Add($"this.Files = {(this.Files == null ? "null" : $"[{string.Join(", ", this.Files)} ]")}");
            toStringOutput.Add($"this.RemainingBalance = {(this.RemainingBalance == null ? "null" : this.RemainingBalance.ToString())}");
            toStringOutput.Add($"this.SinglePaymentMinAmount = {(this.SinglePaymentMinAmount == null ? "null" : this.SinglePaymentMinAmount.ToString())}");
            toStringOutput.Add($"this.SinglePaymentMaxAmount = {(this.SinglePaymentMaxAmount == null ? "null" : this.SinglePaymentMaxAmount.ToString())}");
            toStringOutput.Add($"this.CellPhone = {(this.CellPhone == null ? "null" : this.CellPhone)}");
            toStringOutput.Add($"this.Tags = {(this.Tags == null ? "null" : $"[{string.Join(", ", this.Tags)} ]")}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.ModifiedUserId = {(this.ModifiedUserId == null ? "null" : this.ModifiedUserId)}");
            toStringOutput.Add($"this.Active = {(this.Active == null ? "null" : this.Active.ToString())}");
            toStringOutput.Add($"this.PaymentStatusId = {(this.PaymentStatusId == null ? "null" : this.PaymentStatusId.ToString())}");
            toStringOutput.Add($"this.IsActive = {(this.IsActive == null ? "null" : this.IsActive.ToString())}");
            toStringOutput.Add($"this.QuickInvoiceSetting = {(this.QuickInvoiceSetting == null ? "null" : this.QuickInvoiceSetting.ToString())}");
            toStringOutput.Add($"this.QuickInvoiceViews = {(this.QuickInvoiceViews == null ? "null" : $"[{string.Join(", ", this.QuickInvoiceViews)} ]")}");
            toStringOutput.Add($"this.Location = {(this.Location == null ? "null" : this.Location.ToString())}");
            toStringOutput.Add($"this.CreatedUser = {(this.CreatedUser == null ? "null" : this.CreatedUser.ToString())}");
            toStringOutput.Add($"this.ModifiedUser = {(this.ModifiedUser == null ? "null" : this.ModifiedUser.ToString())}");
            toStringOutput.Add($"this.Changelogs = {(this.Changelogs == null ? "null" : $"[{string.Join(", ", this.Changelogs)} ]")}");
            toStringOutput.Add($"this.Contact = {(this.Contact == null ? "null" : this.Contact.ToString())}");
            toStringOutput.Add($"this.LogEmails = {(this.LogEmails == null ? "null" : $"[{string.Join(", ", this.LogEmails)} ]")}");
            toStringOutput.Add($"this.LogSms = {(this.LogSms == null ? "null" : this.LogSms.ToString())}");
            toStringOutput.Add($"this.Transactions = {(this.Transactions == null ? "null" : $"[{string.Join(", ", this.Transactions)} ]")}");
            toStringOutput.Add($"this.CcProductTransaction = {(this.CcProductTransaction == null ? "null" : this.CcProductTransaction.ToString())}");
            toStringOutput.Add($"this.AchProductTransaction = {(this.AchProductTransaction == null ? "null" : this.AchProductTransaction.ToString())}");
            toStringOutput.Add($"this.EmailBlacklist = {(this.EmailBlacklist == null ? "null" : this.EmailBlacklist.ToString())}");
            toStringOutput.Add($"this.SmsBlacklist = {(this.SmsBlacklist == null ? "null" : this.SmsBlacklist.ToString())}");
            toStringOutput.Add($"this.PaymentUrl = {(this.PaymentUrl == null ? "null" : this.PaymentUrl)}");

            base.ToString(toStringOutput);
        }
    }
}