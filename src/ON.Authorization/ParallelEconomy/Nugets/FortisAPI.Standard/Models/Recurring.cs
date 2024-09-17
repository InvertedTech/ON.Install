// <copyright file="Recurring.cs" company="APIMatic">
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
    /// Recurring.
    /// </summary>
    public class Recurring : BaseModel
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
        private List<string> tags;
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
            { "tags", false },
            { "secondary_amount", false },
            { "installment_amount_total", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Recurring"/> class.
        /// </summary>
        public Recurring()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Recurring"/> class.
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
        public Recurring(
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
            List<string> tags = null,
            int? secondaryAmount = null,
            string currency = null,
            int? installmentAmountTotal = null)
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
            if (tags != null)
            {
                this.Tags = tags;
            }

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
        /// Tags
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags
        {
            get
            {
                return this.tags;
            }

            set
            {
                this.shouldSerialize["tags"] = true;
                this.tags = value;
            }
        }

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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Recurring : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetTags()
        {
            this.shouldSerialize["tags"] = false;
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
        public bool ShouldSerializeTags()
        {
            return this.shouldSerialize["tags"];
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
            return obj is Recurring other &&                ((this.AccountVaultId == null && other.AccountVaultId == null) || (this.AccountVaultId?.Equals(other.AccountVaultId) == true)) &&
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
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true));
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

            base.ToString(toStringOutput);
        }
    }
}