// <copyright file="V1QuickInvoicesRequest.cs" company="APIMatic">
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
    /// V1QuickInvoicesRequest.
    /// </summary>
    public class V1QuickInvoicesRequest
    {
        private string achProductTransactionId;
        private string email;
        private string contactId;
        private string contactApiId;
        private string customerId;
        private string expireDate;
        private string invoiceNumber;
        private string itemHeader;
        private string itemFooter;
        private double? amountDue;
        private string notificationEmail;
        private double? paymentStatusId;
        private double? statusId;
        private string note;
        private int? notificationDaysBeforeDueDate;
        private int? notificationDaysAfterDueDate;
        private double? remainingBalance;
        private double? singlePaymentMinAmount;
        private double? singlePaymentMaxAmount;
        private string cellPhone;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "ach_product_transaction_id", false },
            { "email", false },
            { "contact_id", false },
            { "contact_api_id", false },
            { "customer_id", false },
            { "expire_date", false },
            { "invoice_number", false },
            { "item_header", false },
            { "item_footer", false },
            { "amount_due", false },
            { "notification_email", false },
            { "payment_status_id", false },
            { "status_id", false },
            { "note", false },
            { "notification_days_before_due_date", false },
            { "notification_days_after_due_date", false },
            { "remaining_balance", false },
            { "single_payment_min_amount", false },
            { "single_payment_max_amount", true },
            { "cell_phone", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="V1QuickInvoicesRequest"/> class.
        /// </summary>
        public V1QuickInvoicesRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1QuickInvoicesRequest"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="title">title.</param>
        /// <param name="ccProductTransactionId">cc_product_transaction_id.</param>
        /// <param name="dueDate">due_date.</param>
        /// <param name="itemList">item_list.</param>
        /// <param name="achProductTransactionId">ach_product_transaction_id.</param>
        /// <param name="allowOverpayment">allow_overpayment.</param>
        /// <param name="email">email.</param>
        /// <param name="contactId">contact_id.</param>
        /// <param name="contactApiId">contact_api_id.</param>
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
        /// <param name="paymentStatusId">payment_status_id.</param>
        /// <param name="statusId">status_id.</param>
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
        public V1QuickInvoicesRequest(
            string locationId,
            string title,
            string ccProductTransactionId,
            string dueDate,
            List<Models.ItemList> itemList,
            string achProductTransactionId = null,
            bool? allowOverpayment = null,
            string email = null,
            string contactId = null,
            string contactApiId = null,
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
            double? paymentStatusId = null,
            double? statusId = null,
            string note = null,
            int? notificationDaysBeforeDueDate = null,
            int? notificationDaysAfterDueDate = null,
            bool? notificationOnDueDate = null,
            bool? sendTextToPay = null,
            object files = null,
            double? remainingBalance = null,
            double? singlePaymentMinAmount = null,
            double? singlePaymentMaxAmount = 9999999.99,
            string cellPhone = null)
        {
            this.LocationId = locationId;
            this.Title = title;
            this.CcProductTransactionId = ccProductTransactionId;
            if (achProductTransactionId != null)
            {
                this.AchProductTransactionId = achProductTransactionId;
            }

            this.DueDate = dueDate;
            this.ItemList = itemList;
            this.AllowOverpayment = allowOverpayment;
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

            if (paymentStatusId != null)
            {
                this.PaymentStatusId = paymentStatusId;
            }

            if (statusId != null)
            {
                this.StatusId = statusId;
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

        }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Transaction ID
        /// </summary>
        [JsonProperty("cc_product_transaction_id")]
        public string CcProductTransactionId { get; set; }

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
        /// Payment Status Id
        /// </summary>
        [JsonProperty("payment_status_id")]
        public double? PaymentStatusId
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
        /// Status Id
        /// </summary>
        [JsonProperty("status_id")]
        public double? StatusId
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
        /// Files
        /// </summary>
        [JsonProperty("files", NullValueHandling = NullValueHandling.Ignore)]
        public object Files { get; set; }

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
        public double? SinglePaymentMinAmount
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
        public double? SinglePaymentMaxAmount
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1QuickInvoicesRequest : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetPaymentStatusId()
        {
            this.shouldSerialize["payment_status_id"] = false;
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
        public bool ShouldSerializePaymentStatusId()
        {
            return this.shouldSerialize["payment_status_id"];
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

            return obj is V1QuickInvoicesRequest other &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.CcProductTransactionId == null && other.CcProductTransactionId == null) || (this.CcProductTransactionId?.Equals(other.CcProductTransactionId) == true)) &&
                ((this.AchProductTransactionId == null && other.AchProductTransactionId == null) || (this.AchProductTransactionId?.Equals(other.AchProductTransactionId) == true)) &&
                ((this.DueDate == null && other.DueDate == null) || (this.DueDate?.Equals(other.DueDate) == true)) &&
                ((this.ItemList == null && other.ItemList == null) || (this.ItemList?.Equals(other.ItemList) == true)) &&
                ((this.AllowOverpayment == null && other.AllowOverpayment == null) || (this.AllowOverpayment?.Equals(other.AllowOverpayment) == true)) &&
                ((this.Email == null && other.Email == null) || (this.Email?.Equals(other.Email) == true)) &&
                ((this.ContactId == null && other.ContactId == null) || (this.ContactId?.Equals(other.ContactId) == true)) &&
                ((this.ContactApiId == null && other.ContactApiId == null) || (this.ContactApiId?.Equals(other.ContactApiId) == true)) &&
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
                ((this.PaymentStatusId == null && other.PaymentStatusId == null) || (this.PaymentStatusId?.Equals(other.PaymentStatusId) == true)) &&
                ((this.StatusId == null && other.StatusId == null) || (this.StatusId?.Equals(other.StatusId) == true)) &&
                ((this.Note == null && other.Note == null) || (this.Note?.Equals(other.Note) == true)) &&
                ((this.NotificationDaysBeforeDueDate == null && other.NotificationDaysBeforeDueDate == null) || (this.NotificationDaysBeforeDueDate?.Equals(other.NotificationDaysBeforeDueDate) == true)) &&
                ((this.NotificationDaysAfterDueDate == null && other.NotificationDaysAfterDueDate == null) || (this.NotificationDaysAfterDueDate?.Equals(other.NotificationDaysAfterDueDate) == true)) &&
                ((this.NotificationOnDueDate == null && other.NotificationOnDueDate == null) || (this.NotificationOnDueDate?.Equals(other.NotificationOnDueDate) == true)) &&
                ((this.SendTextToPay == null && other.SendTextToPay == null) || (this.SendTextToPay?.Equals(other.SendTextToPay) == true)) &&
                ((this.Files == null && other.Files == null) || (this.Files?.Equals(other.Files) == true)) &&
                ((this.RemainingBalance == null && other.RemainingBalance == null) || (this.RemainingBalance?.Equals(other.RemainingBalance) == true)) &&
                ((this.SinglePaymentMinAmount == null && other.SinglePaymentMinAmount == null) || (this.SinglePaymentMinAmount?.Equals(other.SinglePaymentMinAmount) == true)) &&
                ((this.SinglePaymentMaxAmount == null && other.SinglePaymentMaxAmount == null) || (this.SinglePaymentMaxAmount?.Equals(other.SinglePaymentMaxAmount) == true)) &&
                ((this.CellPhone == null && other.CellPhone == null) || (this.CellPhone?.Equals(other.CellPhone) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title == string.Empty ? "" : this.Title)}");
            toStringOutput.Add($"this.CcProductTransactionId = {(this.CcProductTransactionId == null ? "null" : this.CcProductTransactionId == string.Empty ? "" : this.CcProductTransactionId)}");
            toStringOutput.Add($"this.AchProductTransactionId = {(this.AchProductTransactionId == null ? "null" : this.AchProductTransactionId == string.Empty ? "" : this.AchProductTransactionId)}");
            toStringOutput.Add($"this.DueDate = {(this.DueDate == null ? "null" : this.DueDate == string.Empty ? "" : this.DueDate)}");
            toStringOutput.Add($"this.ItemList = {(this.ItemList == null ? "null" : $"[{string.Join(", ", this.ItemList)} ]")}");
            toStringOutput.Add($"this.AllowOverpayment = {(this.AllowOverpayment == null ? "null" : this.AllowOverpayment.ToString())}");
            toStringOutput.Add($"this.Email = {(this.Email == null ? "null" : this.Email == string.Empty ? "" : this.Email)}");
            toStringOutput.Add($"this.ContactId = {(this.ContactId == null ? "null" : this.ContactId == string.Empty ? "" : this.ContactId)}");
            toStringOutput.Add($"this.ContactApiId = {(this.ContactApiId == null ? "null" : this.ContactApiId == string.Empty ? "" : this.ContactApiId)}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId == string.Empty ? "" : this.CustomerId)}");
            toStringOutput.Add($"this.ExpireDate = {(this.ExpireDate == null ? "null" : this.ExpireDate == string.Empty ? "" : this.ExpireDate)}");
            toStringOutput.Add($"this.AllowPartialPay = {(this.AllowPartialPay == null ? "null" : this.AllowPartialPay.ToString())}");
            toStringOutput.Add($"this.AttachFilesToEmail = {(this.AttachFilesToEmail == null ? "null" : this.AttachFilesToEmail.ToString())}");
            toStringOutput.Add($"this.SendEmail = {(this.SendEmail == null ? "null" : this.SendEmail.ToString())}");
            toStringOutput.Add($"this.InvoiceNumber = {(this.InvoiceNumber == null ? "null" : this.InvoiceNumber == string.Empty ? "" : this.InvoiceNumber)}");
            toStringOutput.Add($"this.ItemHeader = {(this.ItemHeader == null ? "null" : this.ItemHeader == string.Empty ? "" : this.ItemHeader)}");
            toStringOutput.Add($"this.ItemFooter = {(this.ItemFooter == null ? "null" : this.ItemFooter == string.Empty ? "" : this.ItemFooter)}");
            toStringOutput.Add($"this.AmountDue = {(this.AmountDue == null ? "null" : this.AmountDue.ToString())}");
            toStringOutput.Add($"this.NotificationEmail = {(this.NotificationEmail == null ? "null" : this.NotificationEmail == string.Empty ? "" : this.NotificationEmail)}");
            toStringOutput.Add($"this.PaymentStatusId = {(this.PaymentStatusId == null ? "null" : this.PaymentStatusId.ToString())}");
            toStringOutput.Add($"this.StatusId = {(this.StatusId == null ? "null" : this.StatusId.ToString())}");
            toStringOutput.Add($"this.Note = {(this.Note == null ? "null" : this.Note == string.Empty ? "" : this.Note)}");
            toStringOutput.Add($"this.NotificationDaysBeforeDueDate = {(this.NotificationDaysBeforeDueDate == null ? "null" : this.NotificationDaysBeforeDueDate.ToString())}");
            toStringOutput.Add($"this.NotificationDaysAfterDueDate = {(this.NotificationDaysAfterDueDate == null ? "null" : this.NotificationDaysAfterDueDate.ToString())}");
            toStringOutput.Add($"this.NotificationOnDueDate = {(this.NotificationOnDueDate == null ? "null" : this.NotificationOnDueDate.ToString())}");
            toStringOutput.Add($"this.SendTextToPay = {(this.SendTextToPay == null ? "null" : this.SendTextToPay.ToString())}");
            toStringOutput.Add($"Files = {(this.Files == null ? "null" : this.Files.ToString())}");
            toStringOutput.Add($"this.RemainingBalance = {(this.RemainingBalance == null ? "null" : this.RemainingBalance.ToString())}");
            toStringOutput.Add($"this.SinglePaymentMinAmount = {(this.SinglePaymentMinAmount == null ? "null" : this.SinglePaymentMinAmount.ToString())}");
            toStringOutput.Add($"this.SinglePaymentMaxAmount = {(this.SinglePaymentMaxAmount == null ? "null" : this.SinglePaymentMaxAmount.ToString())}");
            toStringOutput.Add($"this.CellPhone = {(this.CellPhone == null ? "null" : this.CellPhone == string.Empty ? "" : this.CellPhone)}");
        }
    }
}