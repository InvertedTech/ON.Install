// <copyright file="Data16.cs" company="APIMatic">
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
    /// Data16.
    /// </summary>
    public class Data16 : BaseModel
    {
        private string contactId;
        private string accountVaultApiId;
        private string tokenApiId;
        private string description;
        private string endDate;
        private int? installmentTotalCount;
        private int? notificationDays;
        private string productTransactionId;
        private string recurringId;
        private string recurringApiId;
        private string termsAgreeIp;
        private string recurringC1;
        private string recurringC2;
        private string recurringC3;
        private int? secondaryAmount;
        private int? installmentAmountTotal;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "contact_id", false },
            { "account_vault_api_id", false },
            { "token_api_id", false },
            { "description", false },
            { "end_date", false },
            { "installment_total_count", false },
            { "notification_days", false },
            { "product_transaction_id", false },
            { "recurring_id", false },
            { "recurring_api_id", false },
            { "terms_agree_ip", false },
            { "recurring_c1", false },
            { "recurring_c2", false },
            { "recurring_c3", false },
            { "secondary_amount", false },
            { "installment_amount_total", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Data16"/> class.
        /// </summary>
        public Data16()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data16"/> class.
        /// </summary>
        /// <param name="active">active.</param>
        /// <param name="interval">interval.</param>
        /// <param name="intervalType">interval_type.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="paymentMethod">payment_method.</param>
        /// <param name="startDate">start_date.</param>
        /// <param name="status">status.</param>
        /// <param name="transactionAmount">transaction_amount.</param>
        /// <param name="id">id.</param>
        /// <param name="nextRunDate">next_run_date.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="recurringTypeId">recurring_type_id.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="accountVaultId">account_vault_id.</param>
        /// <param name="tokenId">token_id.</param>
        /// <param name="contactId">contact_id.</param>
        /// <param name="accountVaultApiId">account_vault_api_id.</param>
        /// <param name="tokenApiId">token_api_id.</param>
        /// <param name="joi">_joi.</param>
        /// <param name="description">description.</param>
        /// <param name="endDate">end_date.</param>
        /// <param name="installmentTotalCount">installment_total_count.</param>
        /// <param name="notificationDays">notification_days.</param>
        /// <param name="productTransactionId">product_transaction_id.</param>
        /// <param name="recurringId">recurring_id.</param>
        /// <param name="recurringApiId">recurring_api_id.</param>
        /// <param name="termsAgree">terms_agree.</param>
        /// <param name="termsAgreeIp">terms_agree_ip.</param>
        /// <param name="recurringC1">recurring_c1.</param>
        /// <param name="recurringC2">recurring_c2.</param>
        /// <param name="recurringC3">recurring_c3.</param>
        /// <param name="sendToProcAsRecur">send_to_proc_as_recur.</param>
        /// <param name="tags">tags.</param>
        /// <param name="secondaryAmount">secondary_amount.</param>
        /// <param name="currency">currency.</param>
        /// <param name="installmentAmountTotal">installment_amount_total.</param>
        /// <param name="logEmails">log_emails.</param>
        /// <param name="contact">contact.</param>
        /// <param name="accountVault">account_vault.</param>
        /// <param name="createdUser">created_user.</param>
        /// <param name="signature">signature.</param>
        /// <param name="paymentSchedule">payment_schedule.</param>
        /// <param name="location">location.</param>
        /// <param name="productTransaction">product_transaction.</param>
        /// <param name="nextRunDateMin">next_run_date_min.</param>
        /// <param name="nextRunDateMax">next_run_date_max.</param>
        /// <param name="allTags">all_tags.</param>
        /// <param name="changelogs">changelogs.</param>
        /// <param name="forecast">forecast.</param>
        /// <param name="recurringSplits">recurring_splits.</param>
        public Data16(
            bool active,
            int interval,
            Models.IntervalTypeEnum intervalType,
            string locationId,
            Models.PaymentMethod1Enum paymentMethod,
            string startDate,
            Models.StatusEnum status,
            int transactionAmount,
            string id,
            string nextRunDate,
            int createdTs,
            int modifiedTs,
            Models.RecurringTypeIdEnum recurringTypeId,
            string createdUserId,
            string accountVaultId = null,
            string tokenId = null,
            string contactId = null,
            string accountVaultApiId = null,
            string tokenApiId = null,
            Models.Joi joi = null,
            string description = null,
            string endDate = null,
            int? installmentTotalCount = null,
            int? notificationDays = null,
            string productTransactionId = null,
            string recurringId = null,
            string recurringApiId = null,
            bool? termsAgree = null,
            string termsAgreeIp = null,
            string recurringC1 = null,
            string recurringC2 = null,
            string recurringC3 = null,
            bool? sendToProcAsRecur = null,
            List<Models.Tag> tags = null,
            int? secondaryAmount = null,
            string currency = null,
            int? installmentAmountTotal = null,
            List<Models.LogEmail> logEmails = null,
            Models.Contact1 contact = null,
            Models.AccountVault accountVault = null,
            Models.CreatedUser createdUser = null,
            Models.Signature signature = null,
            List<string> paymentSchedule = null,
            Models.Location location = null,
            Models.ProductTransaction productTransaction = null,
            string nextRunDateMin = null,
            string nextRunDateMax = null,
            List<Models.AllTag> allTags = null,
            List<Models.Changelog> changelogs = null,
            Models.Forecast forecast = null,
            List<Models.RecurringSplit> recurringSplits = null)
        {
            this.AccountVaultId = accountVaultId;
            this.TokenId = tokenId;
            if (contactId != null)
            {
                this.ContactId = contactId;
            }

            if (accountVaultApiId != null)
            {
                this.AccountVaultApiId = accountVaultApiId;
            }

            if (tokenApiId != null)
            {
                this.TokenApiId = tokenApiId;
            }

            this.Joi = joi;
            this.Active = active;
            if (description != null)
            {
                this.Description = description;
            }

            if (endDate != null)
            {
                this.EndDate = endDate;
            }

            if (installmentTotalCount != null)
            {
                this.InstallmentTotalCount = installmentTotalCount;
            }

            this.Interval = interval;
            this.IntervalType = intervalType;
            this.LocationId = locationId;
            if (notificationDays != null)
            {
                this.NotificationDays = notificationDays;
            }

            this.PaymentMethod = paymentMethod;
            if (productTransactionId != null)
            {
                this.ProductTransactionId = productTransactionId;
            }

            if (recurringId != null)
            {
                this.RecurringId = recurringId;
            }

            if (recurringApiId != null)
            {
                this.RecurringApiId = recurringApiId;
            }

            this.StartDate = startDate;
            this.Status = status;
            this.TransactionAmount = transactionAmount;
            this.TermsAgree = termsAgree;
            if (termsAgreeIp != null)
            {
                this.TermsAgreeIp = termsAgreeIp;
            }

            if (recurringC1 != null)
            {
                this.RecurringC1 = recurringC1;
            }

            if (recurringC2 != null)
            {
                this.RecurringC2 = recurringC2;
            }

            if (recurringC3 != null)
            {
                this.RecurringC3 = recurringC3;
            }

            this.SendToProcAsRecur = sendToProcAsRecur;
            this.Tags = tags;
            if (secondaryAmount != null)
            {
                this.SecondaryAmount = secondaryAmount;
            }

            this.Currency = currency;
            this.Id = id;
            this.NextRunDate = nextRunDate;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            this.RecurringTypeId = recurringTypeId;
            if (installmentAmountTotal != null)
            {
                this.InstallmentAmountTotal = installmentAmountTotal;
            }

            this.CreatedUserId = createdUserId;
            this.LogEmails = logEmails;
            this.Contact = contact;
            this.AccountVault = accountVault;
            this.CreatedUser = createdUser;
            this.Signature = signature;
            this.PaymentSchedule = paymentSchedule;
            this.Location = location;
            this.ProductTransaction = productTransaction;
            this.NextRunDateMin = nextRunDateMin;
            this.NextRunDateMax = nextRunDateMax;
            this.AllTags = allTags;
            this.Changelogs = changelogs;
            this.Forecast = forecast;
            this.RecurringSplits = recurringSplits;
        }

        /// <summary>
        /// Token ID
        /// </summary>
        [JsonProperty("account_vault_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountVaultId { get; set; }

        /// <summary>
        /// Token ID
        /// </summary>
        [JsonProperty("token_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TokenId { get; set; }

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
        /// Token API ID
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
        /// Token API ID
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
        /// Gets or sets Joi.
        /// </summary>
        [JsonProperty("_joi", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Joi Joi { get; set; }

        /// <summary>
        /// Active
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

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
        /// End date
        /// </summary>
        [JsonProperty("end_date")]
        public string EndDate
        {
            get
            {
                return this.endDate;
            }

            set
            {
                this.shouldSerialize["end_date"] = true;
                this.endDate = value;
            }
        }

        /// <summary>
        /// Installment Total Count
        /// </summary>
        [JsonProperty("installment_total_count")]
        public int? InstallmentTotalCount
        {
            get
            {
                return this.installmentTotalCount;
            }

            set
            {
                this.shouldSerialize["installment_total_count"] = true;
                this.installmentTotalCount = value;
            }
        }

        /// <summary>
        /// Interval
        /// </summary>
        [JsonProperty("interval")]
        public int Interval { get; set; }

        /// <summary>
        /// Interval Type
        /// </summary>
        [JsonProperty("interval_type")]
        public Models.IntervalTypeEnum IntervalType { get; set; }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        /// <summary>
        /// Notification Days
        /// </summary>
        [JsonProperty("notification_days")]
        public int? NotificationDays
        {
            get
            {
                return this.notificationDays;
            }

            set
            {
                this.shouldSerialize["notification_days"] = true;
                this.notificationDays = value;
            }
        }

        /// <summary>
        /// Payment Method
        /// </summary>
        [JsonProperty("payment_method")]
        public Models.PaymentMethod1Enum PaymentMethod { get; set; }

        /// <summary>
        /// Product Transaction ID
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
        /// Recurring ID
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
        /// Recurring Api ID
        /// </summary>
        [JsonProperty("recurring_api_id")]
        public string RecurringApiId
        {
            get
            {
                return this.recurringApiId;
            }

            set
            {
                this.shouldSerialize["recurring_api_id"] = true;
                this.recurringApiId = value;
            }
        }

        /// <summary>
        /// Start date
        /// </summary>
        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [JsonProperty("status")]
        public Models.StatusEnum Status { get; set; }

        /// <summary>
        /// Transaction amount
        /// </summary>
        [JsonProperty("transaction_amount")]
        public int TransactionAmount { get; set; }

        /// <summary>
        /// Terms Agree
        /// </summary>
        [JsonProperty("terms_agree", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TermsAgree { get; set; }

        /// <summary>
        /// Terms Agree Ip
        /// </summary>
        [JsonProperty("terms_agree_ip")]
        public string TermsAgreeIp
        {
            get
            {
                return this.termsAgreeIp;
            }

            set
            {
                this.shouldSerialize["terms_agree_ip"] = true;
                this.termsAgreeIp = value;
            }
        }

        /// <summary>
        /// Custom field used for integrations
        /// </summary>
        [JsonProperty("recurring_c1")]
        public string RecurringC1
        {
            get
            {
                return this.recurringC1;
            }

            set
            {
                this.shouldSerialize["recurring_c1"] = true;
                this.recurringC1 = value;
            }
        }

        /// <summary>
        /// Custom field used for integrations
        /// </summary>
        [JsonProperty("recurring_c2")]
        public string RecurringC2
        {
            get
            {
                return this.recurringC2;
            }

            set
            {
                this.shouldSerialize["recurring_c2"] = true;
                this.recurringC2 = value;
            }
        }

        /// <summary>
        /// Custom field used for integrations
        /// </summary>
        [JsonProperty("recurring_c3")]
        public string RecurringC3
        {
            get
            {
                return this.recurringC3;
            }

            set
            {
                this.shouldSerialize["recurring_c3"] = true;
                this.recurringC3 = value;
            }
        }

        /// <summary>
        /// Send To Proc As Recur
        /// </summary>
        [JsonProperty("send_to_proc_as_recur", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SendToProcAsRecur { get; set; }

        /// <summary>
        /// Tag Information on `expand`
        /// </summary>
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.Tag> Tags { get; set; }

        /// <summary>
        /// Retained Amount
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
        /// Gets or sets Currency.
        /// </summary>
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        /// <summary>
        /// Recurring ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Next Run Date
        /// </summary>
        [JsonProperty("next_run_date")]
        public string NextRunDate { get; set; }

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
        /// Recurring Type
        /// </summary>
        [JsonProperty("recurring_type_id")]
        public Models.RecurringTypeIdEnum RecurringTypeId { get; set; }

        /// <summary>
        /// Installment Amount Total
        /// </summary>
        [JsonProperty("installment_amount_total")]
        public int? InstallmentAmountTotal
        {
            get
            {
                return this.installmentAmountTotal;
            }

            set
            {
                this.shouldSerialize["installment_amount_total"] = true;
                this.installmentAmountTotal = value;
            }
        }

        /// <summary>
        /// User ID Created the register
        /// </summary>
        [JsonProperty("created_user_id")]
        public string CreatedUserId { get; set; }

        /// <summary>
        /// Log Email Information on `expand`
        /// </summary>
        [JsonProperty("log_emails", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.LogEmail> LogEmails { get; set; }

        /// <summary>
        /// Contact Information on `expand`
        /// </summary>
        [JsonProperty("contact", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Contact1 Contact { get; set; }

        /// <summary>
        /// Token Information on `expand`
        /// </summary>
        [JsonProperty("account_vault", NullValueHandling = NullValueHandling.Ignore)]
        public Models.AccountVault AccountVault { get; set; }

        /// <summary>
        /// User Information on `expand`
        /// </summary>
        [JsonProperty("created_user", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CreatedUser CreatedUser { get; set; }

        /// <summary>
        /// Signature Information on `expand`
        /// </summary>
        [JsonProperty("signature", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Signature Signature { get; set; }

        /// <summary>
        /// Payment Schedule Information on `expand`
        /// </summary>
        [JsonProperty("payment_schedule", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> PaymentSchedule { get; set; }

        /// <summary>
        /// Location Information on `expand`
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Location Location { get; set; }

        /// <summary>
        /// Product Transaction Information on `expand`
        /// </summary>
        [JsonProperty("product_transaction", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ProductTransaction ProductTransaction { get; set; }

        /// <summary>
        /// Next Run Date Min Information on `expand`
        /// </summary>
        [JsonProperty("next_run_date_min", NullValueHandling = NullValueHandling.Ignore)]
        public string NextRunDateMin { get; set; }

        /// <summary>
        /// Next Run Date Max Information on `expand`
        /// </summary>
        [JsonProperty("next_run_date_max", NullValueHandling = NullValueHandling.Ignore)]
        public string NextRunDateMax { get; set; }

        /// <summary>
        /// All Tag Information on `expand`
        /// </summary>
        [JsonProperty("all_tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.AllTag> AllTags { get; set; }

        /// <summary>
        /// Changelog Information on `expand`
        /// </summary>
        [JsonProperty("changelogs", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.Changelog> Changelogs { get; set; }

        /// <summary>
        /// Forecast Information on `expand`
        /// </summary>
        [JsonProperty("forecast", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Forecast Forecast { get; set; }

        /// <summary>
        /// Recurring Split Information on `expand`
        /// </summary>
        [JsonProperty("recurring_splits", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.RecurringSplit> RecurringSplits { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data16 : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetAccountVaultApiId()
        {
            this.shouldSerialize["account_vault_api_id"] = false;
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
        public void UnsetDescription()
        {
            this.shouldSerialize["description"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEndDate()
        {
            this.shouldSerialize["end_date"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetInstallmentTotalCount()
        {
            this.shouldSerialize["installment_total_count"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetNotificationDays()
        {
            this.shouldSerialize["notification_days"] = false;
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
        public void UnsetRecurringId()
        {
            this.shouldSerialize["recurring_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRecurringApiId()
        {
            this.shouldSerialize["recurring_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTermsAgreeIp()
        {
            this.shouldSerialize["terms_agree_ip"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRecurringC1()
        {
            this.shouldSerialize["recurring_c1"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRecurringC2()
        {
            this.shouldSerialize["recurring_c2"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRecurringC3()
        {
            this.shouldSerialize["recurring_c3"] = false;
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
        public void UnsetInstallmentAmountTotal()
        {
            this.shouldSerialize["installment_amount_total"] = false;
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
        public bool ShouldSerializeAccountVaultApiId()
        {
            return this.shouldSerialize["account_vault_api_id"];
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
        public bool ShouldSerializeDescription()
        {
            return this.shouldSerialize["description"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEndDate()
        {
            return this.shouldSerialize["end_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInstallmentTotalCount()
        {
            return this.shouldSerialize["installment_total_count"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNotificationDays()
        {
            return this.shouldSerialize["notification_days"];
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
        public bool ShouldSerializeRecurringId()
        {
            return this.shouldSerialize["recurring_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRecurringApiId()
        {
            return this.shouldSerialize["recurring_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTermsAgreeIp()
        {
            return this.shouldSerialize["terms_agree_ip"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRecurringC1()
        {
            return this.shouldSerialize["recurring_c1"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRecurringC2()
        {
            return this.shouldSerialize["recurring_c2"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRecurringC3()
        {
            return this.shouldSerialize["recurring_c3"];
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
        public bool ShouldSerializeInstallmentAmountTotal()
        {
            return this.shouldSerialize["installment_amount_total"];
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
            return obj is Data16 other &&                ((this.AccountVaultId == null && other.AccountVaultId == null) || (this.AccountVaultId?.Equals(other.AccountVaultId) == true)) &&
                ((this.TokenId == null && other.TokenId == null) || (this.TokenId?.Equals(other.TokenId) == true)) &&
                ((this.ContactId == null && other.ContactId == null) || (this.ContactId?.Equals(other.ContactId) == true)) &&
                ((this.AccountVaultApiId == null && other.AccountVaultApiId == null) || (this.AccountVaultApiId?.Equals(other.AccountVaultApiId) == true)) &&
                ((this.TokenApiId == null && other.TokenApiId == null) || (this.TokenApiId?.Equals(other.TokenApiId) == true)) &&
                ((this.Joi == null && other.Joi == null) || (this.Joi?.Equals(other.Joi) == true)) &&
                this.Active.Equals(other.Active) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.EndDate == null && other.EndDate == null) || (this.EndDate?.Equals(other.EndDate) == true)) &&
                ((this.InstallmentTotalCount == null && other.InstallmentTotalCount == null) || (this.InstallmentTotalCount?.Equals(other.InstallmentTotalCount) == true)) &&
                this.Interval.Equals(other.Interval) &&
                this.IntervalType.Equals(other.IntervalType) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.NotificationDays == null && other.NotificationDays == null) || (this.NotificationDays?.Equals(other.NotificationDays) == true)) &&
                this.PaymentMethod.Equals(other.PaymentMethod) &&
                ((this.ProductTransactionId == null && other.ProductTransactionId == null) || (this.ProductTransactionId?.Equals(other.ProductTransactionId) == true)) &&
                ((this.RecurringId == null && other.RecurringId == null) || (this.RecurringId?.Equals(other.RecurringId) == true)) &&
                ((this.RecurringApiId == null && other.RecurringApiId == null) || (this.RecurringApiId?.Equals(other.RecurringApiId) == true)) &&
                ((this.StartDate == null && other.StartDate == null) || (this.StartDate?.Equals(other.StartDate) == true)) &&
                this.Status.Equals(other.Status) &&
                this.TransactionAmount.Equals(other.TransactionAmount) &&
                ((this.TermsAgree == null && other.TermsAgree == null) || (this.TermsAgree?.Equals(other.TermsAgree) == true)) &&
                ((this.TermsAgreeIp == null && other.TermsAgreeIp == null) || (this.TermsAgreeIp?.Equals(other.TermsAgreeIp) == true)) &&
                ((this.RecurringC1 == null && other.RecurringC1 == null) || (this.RecurringC1?.Equals(other.RecurringC1) == true)) &&
                ((this.RecurringC2 == null && other.RecurringC2 == null) || (this.RecurringC2?.Equals(other.RecurringC2) == true)) &&
                ((this.RecurringC3 == null && other.RecurringC3 == null) || (this.RecurringC3?.Equals(other.RecurringC3) == true)) &&
                ((this.SendToProcAsRecur == null && other.SendToProcAsRecur == null) || (this.SendToProcAsRecur?.Equals(other.SendToProcAsRecur) == true)) &&
                ((this.Tags == null && other.Tags == null) || (this.Tags?.Equals(other.Tags) == true)) &&
                ((this.SecondaryAmount == null && other.SecondaryAmount == null) || (this.SecondaryAmount?.Equals(other.SecondaryAmount) == true)) &&
                ((this.Currency == null && other.Currency == null) || (this.Currency?.Equals(other.Currency) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.NextRunDate == null && other.NextRunDate == null) || (this.NextRunDate?.Equals(other.NextRunDate) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                this.RecurringTypeId.Equals(other.RecurringTypeId) &&
                ((this.InstallmentAmountTotal == null && other.InstallmentAmountTotal == null) || (this.InstallmentAmountTotal?.Equals(other.InstallmentAmountTotal) == true)) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true)) &&
                ((this.LogEmails == null && other.LogEmails == null) || (this.LogEmails?.Equals(other.LogEmails) == true)) &&
                ((this.Contact == null && other.Contact == null) || (this.Contact?.Equals(other.Contact) == true)) &&
                ((this.AccountVault == null && other.AccountVault == null) || (this.AccountVault?.Equals(other.AccountVault) == true)) &&
                ((this.CreatedUser == null && other.CreatedUser == null) || (this.CreatedUser?.Equals(other.CreatedUser) == true)) &&
                ((this.Signature == null && other.Signature == null) || (this.Signature?.Equals(other.Signature) == true)) &&
                ((this.PaymentSchedule == null && other.PaymentSchedule == null) || (this.PaymentSchedule?.Equals(other.PaymentSchedule) == true)) &&
                ((this.Location == null && other.Location == null) || (this.Location?.Equals(other.Location) == true)) &&
                ((this.ProductTransaction == null && other.ProductTransaction == null) || (this.ProductTransaction?.Equals(other.ProductTransaction) == true)) &&
                ((this.NextRunDateMin == null && other.NextRunDateMin == null) || (this.NextRunDateMin?.Equals(other.NextRunDateMin) == true)) &&
                ((this.NextRunDateMax == null && other.NextRunDateMax == null) || (this.NextRunDateMax?.Equals(other.NextRunDateMax) == true)) &&
                ((this.AllTags == null && other.AllTags == null) || (this.AllTags?.Equals(other.AllTags) == true)) &&
                ((this.Changelogs == null && other.Changelogs == null) || (this.Changelogs?.Equals(other.Changelogs) == true)) &&
                ((this.Forecast == null && other.Forecast == null) || (this.Forecast?.Equals(other.Forecast) == true)) &&
                ((this.RecurringSplits == null && other.RecurringSplits == null) || (this.RecurringSplits?.Equals(other.RecurringSplits) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AccountVaultId = {(this.AccountVaultId == null ? "null" : this.AccountVaultId)}");
            toStringOutput.Add($"this.TokenId = {(this.TokenId == null ? "null" : this.TokenId)}");
            toStringOutput.Add($"this.ContactId = {(this.ContactId == null ? "null" : this.ContactId)}");
            toStringOutput.Add($"this.AccountVaultApiId = {(this.AccountVaultApiId == null ? "null" : this.AccountVaultApiId)}");
            toStringOutput.Add($"this.TokenApiId = {(this.TokenApiId == null ? "null" : this.TokenApiId)}");
            toStringOutput.Add($"this.Joi = {(this.Joi == null ? "null" : this.Joi.ToString())}");
            toStringOutput.Add($"this.Active = {this.Active}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description)}");
            toStringOutput.Add($"this.EndDate = {(this.EndDate == null ? "null" : this.EndDate)}");
            toStringOutput.Add($"this.InstallmentTotalCount = {(this.InstallmentTotalCount == null ? "null" : this.InstallmentTotalCount.ToString())}");
            toStringOutput.Add($"this.Interval = {this.Interval}");
            toStringOutput.Add($"this.IntervalType = {this.IntervalType}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.NotificationDays = {(this.NotificationDays == null ? "null" : this.NotificationDays.ToString())}");
            toStringOutput.Add($"this.PaymentMethod = {this.PaymentMethod}");
            toStringOutput.Add($"this.ProductTransactionId = {(this.ProductTransactionId == null ? "null" : this.ProductTransactionId)}");
            toStringOutput.Add($"this.RecurringId = {(this.RecurringId == null ? "null" : this.RecurringId)}");
            toStringOutput.Add($"this.RecurringApiId = {(this.RecurringApiId == null ? "null" : this.RecurringApiId)}");
            toStringOutput.Add($"this.StartDate = {(this.StartDate == null ? "null" : this.StartDate)}");
            toStringOutput.Add($"this.Status = {this.Status}");
            toStringOutput.Add($"this.TransactionAmount = {this.TransactionAmount}");
            toStringOutput.Add($"this.TermsAgree = {(this.TermsAgree == null ? "null" : this.TermsAgree.ToString())}");
            toStringOutput.Add($"this.TermsAgreeIp = {(this.TermsAgreeIp == null ? "null" : this.TermsAgreeIp)}");
            toStringOutput.Add($"this.RecurringC1 = {(this.RecurringC1 == null ? "null" : this.RecurringC1)}");
            toStringOutput.Add($"this.RecurringC2 = {(this.RecurringC2 == null ? "null" : this.RecurringC2)}");
            toStringOutput.Add($"this.RecurringC3 = {(this.RecurringC3 == null ? "null" : this.RecurringC3)}");
            toStringOutput.Add($"this.SendToProcAsRecur = {(this.SendToProcAsRecur == null ? "null" : this.SendToProcAsRecur.ToString())}");
            toStringOutput.Add($"this.Tags = {(this.Tags == null ? "null" : $"[{string.Join(", ", this.Tags)} ]")}");
            toStringOutput.Add($"this.SecondaryAmount = {(this.SecondaryAmount == null ? "null" : this.SecondaryAmount.ToString())}");
            toStringOutput.Add($"this.Currency = {(this.Currency == null ? "null" : this.Currency)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.NextRunDate = {(this.NextRunDate == null ? "null" : this.NextRunDate)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.RecurringTypeId = {this.RecurringTypeId}");
            toStringOutput.Add($"this.InstallmentAmountTotal = {(this.InstallmentAmountTotal == null ? "null" : this.InstallmentAmountTotal.ToString())}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.LogEmails = {(this.LogEmails == null ? "null" : $"[{string.Join(", ", this.LogEmails)} ]")}");
            toStringOutput.Add($"this.Contact = {(this.Contact == null ? "null" : this.Contact.ToString())}");
            toStringOutput.Add($"this.AccountVault = {(this.AccountVault == null ? "null" : this.AccountVault.ToString())}");
            toStringOutput.Add($"this.CreatedUser = {(this.CreatedUser == null ? "null" : this.CreatedUser.ToString())}");
            toStringOutput.Add($"this.Signature = {(this.Signature == null ? "null" : this.Signature.ToString())}");
            toStringOutput.Add($"this.PaymentSchedule = {(this.PaymentSchedule == null ? "null" : $"[{string.Join(", ", this.PaymentSchedule)} ]")}");
            toStringOutput.Add($"this.Location = {(this.Location == null ? "null" : this.Location.ToString())}");
            toStringOutput.Add($"this.ProductTransaction = {(this.ProductTransaction == null ? "null" : this.ProductTransaction.ToString())}");
            toStringOutput.Add($"this.NextRunDateMin = {(this.NextRunDateMin == null ? "null" : this.NextRunDateMin)}");
            toStringOutput.Add($"this.NextRunDateMax = {(this.NextRunDateMax == null ? "null" : this.NextRunDateMax)}");
            toStringOutput.Add($"this.AllTags = {(this.AllTags == null ? "null" : $"[{string.Join(", ", this.AllTags)} ]")}");
            toStringOutput.Add($"this.Changelogs = {(this.Changelogs == null ? "null" : $"[{string.Join(", ", this.Changelogs)} ]")}");
            toStringOutput.Add($"this.Forecast = {(this.Forecast == null ? "null" : this.Forecast.ToString())}");
            toStringOutput.Add($"this.RecurringSplits = {(this.RecurringSplits == null ? "null" : $"[{string.Join(", ", this.RecurringSplits)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}