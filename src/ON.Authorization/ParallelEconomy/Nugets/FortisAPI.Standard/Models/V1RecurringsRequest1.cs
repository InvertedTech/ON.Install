// <copyright file="V1RecurringsRequest1.cs" company="APIMatic">
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
    /// V1RecurringsRequest1.
    /// </summary>
    public class V1RecurringsRequest1 : BaseModel
    {
        private string nextRunDate;
        private string accountVaultId;
        private string tokenId;
        private string description;
        private string endDate;
        private int? installmentTotalCount;
        private int? interval;
        private Models.IntervalTypeEnum? intervalType;
        private string locationId;
        private int? notificationDays;
        private Models.PaymentMethod1Enum? paymentMethod;
        private string productTransactionId;
        private string recurringId;
        private string recurringApiId;
        private string startDate;
        private Models.StatusEnum? status;
        private int? transactionAmount;
        private string termsAgreeIp;
        private string recurringC1;
        private string recurringC2;
        private string recurringC3;
        private List<string> tags;
        private int? secondaryAmount;
        private string contactId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "next_run_date", false },
            { "account_vault_id", false },
            { "token_id", false },
            { "description", false },
            { "end_date", false },
            { "installment_total_count", false },
            { "interval", false },
            { "interval_type", false },
            { "location_id", false },
            { "notification_days", false },
            { "payment_method", false },
            { "product_transaction_id", false },
            { "recurring_id", false },
            { "recurring_api_id", false },
            { "start_date", false },
            { "status", false },
            { "transaction_amount", false },
            { "terms_agree_ip", false },
            { "recurring_c1", false },
            { "recurring_c2", false },
            { "recurring_c3", false },
            { "tags", false },
            { "secondary_amount", false },
            { "contact_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="V1RecurringsRequest1"/> class.
        /// </summary>
        public V1RecurringsRequest1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1RecurringsRequest1"/> class.
        /// </summary>
        /// <param name="nextRunDate">next_run_date.</param>
        /// <param name="accountVaultId">account_vault_id.</param>
        /// <param name="tokenId">token_id.</param>
        /// <param name="active">active.</param>
        /// <param name="description">description.</param>
        /// <param name="endDate">end_date.</param>
        /// <param name="installmentTotalCount">installment_total_count.</param>
        /// <param name="interval">interval.</param>
        /// <param name="intervalType">interval_type.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="notificationDays">notification_days.</param>
        /// <param name="paymentMethod">payment_method.</param>
        /// <param name="productTransactionId">product_transaction_id.</param>
        /// <param name="recurringId">recurring_id.</param>
        /// <param name="recurringApiId">recurring_api_id.</param>
        /// <param name="startDate">start_date.</param>
        /// <param name="status">status.</param>
        /// <param name="transactionAmount">transaction_amount.</param>
        /// <param name="termsAgree">terms_agree.</param>
        /// <param name="termsAgreeIp">terms_agree_ip.</param>
        /// <param name="recurringC1">recurring_c1.</param>
        /// <param name="recurringC2">recurring_c2.</param>
        /// <param name="recurringC3">recurring_c3.</param>
        /// <param name="sendToProcAsRecur">send_to_proc_as_recur.</param>
        /// <param name="tags">tags.</param>
        /// <param name="secondaryAmount">secondary_amount.</param>
        /// <param name="contactId">contact_id.</param>
        public V1RecurringsRequest1(
            string nextRunDate = null,
            string accountVaultId = null,
            string tokenId = null,
            bool? active = null,
            string description = null,
            string endDate = null,
            int? installmentTotalCount = null,
            int? interval = null,
            Models.IntervalTypeEnum? intervalType = null,
            string locationId = null,
            int? notificationDays = null,
            Models.PaymentMethod1Enum? paymentMethod = null,
            string productTransactionId = null,
            string recurringId = null,
            string recurringApiId = null,
            string startDate = null,
            Models.StatusEnum? status = null,
            int? transactionAmount = null,
            bool? termsAgree = null,
            string termsAgreeIp = null,
            string recurringC1 = null,
            string recurringC2 = null,
            string recurringC3 = null,
            bool? sendToProcAsRecur = null,
            List<string> tags = null,
            int? secondaryAmount = null,
            string contactId = null)
        {
            if (nextRunDate != null)
            {
                this.NextRunDate = nextRunDate;
            }

            if (accountVaultId != null)
            {
                this.AccountVaultId = accountVaultId;
            }

            if (tokenId != null)
            {
                this.TokenId = tokenId;
            }

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

            if (interval != null)
            {
                this.Interval = interval;
            }

            if (intervalType != null)
            {
                this.IntervalType = intervalType;
            }

            if (locationId != null)
            {
                this.LocationId = locationId;
            }

            if (notificationDays != null)
            {
                this.NotificationDays = notificationDays;
            }

            if (paymentMethod != null)
            {
                this.PaymentMethod = paymentMethod;
            }

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

            if (startDate != null)
            {
                this.StartDate = startDate;
            }

            if (status != null)
            {
                this.Status = status;
            }

            if (transactionAmount != null)
            {
                this.TransactionAmount = transactionAmount;
            }

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

            if (contactId != null)
            {
                this.ContactId = contactId;
            }

        }

        /// <summary>
        /// Next Run Date
        /// </summary>
        [JsonProperty("next_run_date")]
        public string NextRunDate
        {
            get
            {
                return this.nextRunDate;
            }

            set
            {
                this.shouldSerialize["next_run_date"] = true;
                this.nextRunDate = value;
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
        /// Token ID
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
        /// Active
        /// </summary>
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Active { get; set; }

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
        public int? Interval
        {
            get
            {
                return this.interval;
            }

            set
            {
                this.shouldSerialize["interval"] = true;
                this.interval = value;
            }
        }

        /// <summary>
        /// Interval Type
        /// </summary>
        [JsonProperty("interval_type")]
        public Models.IntervalTypeEnum? IntervalType
        {
            get
            {
                return this.intervalType;
            }

            set
            {
                this.shouldSerialize["interval_type"] = true;
                this.intervalType = value;
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
        public Models.PaymentMethod1Enum? PaymentMethod
        {
            get
            {
                return this.paymentMethod;
            }

            set
            {
                this.shouldSerialize["payment_method"] = true;
                this.paymentMethod = value;
            }
        }

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
        public string StartDate
        {
            get
            {
                return this.startDate;
            }

            set
            {
                this.shouldSerialize["start_date"] = true;
                this.startDate = value;
            }
        }

        /// <summary>
        /// Status
        /// </summary>
        [JsonProperty("status")]
        public Models.StatusEnum? Status
        {
            get
            {
                return this.status;
            }

            set
            {
                this.shouldSerialize["status"] = true;
                this.status = value;
            }
        }

        /// <summary>
        /// Transaction amount
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1RecurringsRequest1 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetNextRunDate()
        {
            this.shouldSerialize["next_run_date"] = false;
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
        public void UnsetTokenId()
        {
            this.shouldSerialize["token_id"] = false;
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
        public void UnsetInterval()
        {
            this.shouldSerialize["interval"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetIntervalType()
        {
            this.shouldSerialize["interval_type"] = false;
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
        public void UnsetNotificationDays()
        {
            this.shouldSerialize["notification_days"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPaymentMethod()
        {
            this.shouldSerialize["payment_method"] = false;
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
        public void UnsetStartDate()
        {
            this.shouldSerialize["start_date"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetStatus()
        {
            this.shouldSerialize["status"] = false;
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
        public void UnsetContactId()
        {
            this.shouldSerialize["contact_id"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNextRunDate()
        {
            return this.shouldSerialize["next_run_date"];
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
        public bool ShouldSerializeTokenId()
        {
            return this.shouldSerialize["token_id"];
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
        public bool ShouldSerializeInterval()
        {
            return this.shouldSerialize["interval"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIntervalType()
        {
            return this.shouldSerialize["interval_type"];
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
        public bool ShouldSerializeNotificationDays()
        {
            return this.shouldSerialize["notification_days"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentMethod()
        {
            return this.shouldSerialize["payment_method"];
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
        public bool ShouldSerializeStartDate()
        {
            return this.shouldSerialize["start_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStatus()
        {
            return this.shouldSerialize["status"];
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
        public bool ShouldSerializeContactId()
        {
            return this.shouldSerialize["contact_id"];
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
            return obj is V1RecurringsRequest1 other &&                ((this.NextRunDate == null && other.NextRunDate == null) || (this.NextRunDate?.Equals(other.NextRunDate) == true)) &&
                ((this.AccountVaultId == null && other.AccountVaultId == null) || (this.AccountVaultId?.Equals(other.AccountVaultId) == true)) &&
                ((this.TokenId == null && other.TokenId == null) || (this.TokenId?.Equals(other.TokenId) == true)) &&
                ((this.Active == null && other.Active == null) || (this.Active?.Equals(other.Active) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.EndDate == null && other.EndDate == null) || (this.EndDate?.Equals(other.EndDate) == true)) &&
                ((this.InstallmentTotalCount == null && other.InstallmentTotalCount == null) || (this.InstallmentTotalCount?.Equals(other.InstallmentTotalCount) == true)) &&
                ((this.Interval == null && other.Interval == null) || (this.Interval?.Equals(other.Interval) == true)) &&
                ((this.IntervalType == null && other.IntervalType == null) || (this.IntervalType?.Equals(other.IntervalType) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.NotificationDays == null && other.NotificationDays == null) || (this.NotificationDays?.Equals(other.NotificationDays) == true)) &&
                ((this.PaymentMethod == null && other.PaymentMethod == null) || (this.PaymentMethod?.Equals(other.PaymentMethod) == true)) &&
                ((this.ProductTransactionId == null && other.ProductTransactionId == null) || (this.ProductTransactionId?.Equals(other.ProductTransactionId) == true)) &&
                ((this.RecurringId == null && other.RecurringId == null) || (this.RecurringId?.Equals(other.RecurringId) == true)) &&
                ((this.RecurringApiId == null && other.RecurringApiId == null) || (this.RecurringApiId?.Equals(other.RecurringApiId) == true)) &&
                ((this.StartDate == null && other.StartDate == null) || (this.StartDate?.Equals(other.StartDate) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.TransactionAmount == null && other.TransactionAmount == null) || (this.TransactionAmount?.Equals(other.TransactionAmount) == true)) &&
                ((this.TermsAgree == null && other.TermsAgree == null) || (this.TermsAgree?.Equals(other.TermsAgree) == true)) &&
                ((this.TermsAgreeIp == null && other.TermsAgreeIp == null) || (this.TermsAgreeIp?.Equals(other.TermsAgreeIp) == true)) &&
                ((this.RecurringC1 == null && other.RecurringC1 == null) || (this.RecurringC1?.Equals(other.RecurringC1) == true)) &&
                ((this.RecurringC2 == null && other.RecurringC2 == null) || (this.RecurringC2?.Equals(other.RecurringC2) == true)) &&
                ((this.RecurringC3 == null && other.RecurringC3 == null) || (this.RecurringC3?.Equals(other.RecurringC3) == true)) &&
                ((this.SendToProcAsRecur == null && other.SendToProcAsRecur == null) || (this.SendToProcAsRecur?.Equals(other.SendToProcAsRecur) == true)) &&
                ((this.Tags == null && other.Tags == null) || (this.Tags?.Equals(other.Tags) == true)) &&
                ((this.SecondaryAmount == null && other.SecondaryAmount == null) || (this.SecondaryAmount?.Equals(other.SecondaryAmount) == true)) &&
                ((this.ContactId == null && other.ContactId == null) || (this.ContactId?.Equals(other.ContactId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.NextRunDate = {(this.NextRunDate == null ? "null" : this.NextRunDate)}");
            toStringOutput.Add($"this.AccountVaultId = {(this.AccountVaultId == null ? "null" : this.AccountVaultId)}");
            toStringOutput.Add($"this.TokenId = {(this.TokenId == null ? "null" : this.TokenId)}");
            toStringOutput.Add($"this.Active = {(this.Active == null ? "null" : this.Active.ToString())}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description)}");
            toStringOutput.Add($"this.EndDate = {(this.EndDate == null ? "null" : this.EndDate)}");
            toStringOutput.Add($"this.InstallmentTotalCount = {(this.InstallmentTotalCount == null ? "null" : this.InstallmentTotalCount.ToString())}");
            toStringOutput.Add($"this.Interval = {(this.Interval == null ? "null" : this.Interval.ToString())}");
            toStringOutput.Add($"this.IntervalType = {(this.IntervalType == null ? "null" : this.IntervalType.ToString())}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.NotificationDays = {(this.NotificationDays == null ? "null" : this.NotificationDays.ToString())}");
            toStringOutput.Add($"this.PaymentMethod = {(this.PaymentMethod == null ? "null" : this.PaymentMethod.ToString())}");
            toStringOutput.Add($"this.ProductTransactionId = {(this.ProductTransactionId == null ? "null" : this.ProductTransactionId)}");
            toStringOutput.Add($"this.RecurringId = {(this.RecurringId == null ? "null" : this.RecurringId)}");
            toStringOutput.Add($"this.RecurringApiId = {(this.RecurringApiId == null ? "null" : this.RecurringApiId)}");
            toStringOutput.Add($"this.StartDate = {(this.StartDate == null ? "null" : this.StartDate)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.TransactionAmount = {(this.TransactionAmount == null ? "null" : this.TransactionAmount.ToString())}");
            toStringOutput.Add($"this.TermsAgree = {(this.TermsAgree == null ? "null" : this.TermsAgree.ToString())}");
            toStringOutput.Add($"this.TermsAgreeIp = {(this.TermsAgreeIp == null ? "null" : this.TermsAgreeIp)}");
            toStringOutput.Add($"this.RecurringC1 = {(this.RecurringC1 == null ? "null" : this.RecurringC1)}");
            toStringOutput.Add($"this.RecurringC2 = {(this.RecurringC2 == null ? "null" : this.RecurringC2)}");
            toStringOutput.Add($"this.RecurringC3 = {(this.RecurringC3 == null ? "null" : this.RecurringC3)}");
            toStringOutput.Add($"this.SendToProcAsRecur = {(this.SendToProcAsRecur == null ? "null" : this.SendToProcAsRecur.ToString())}");
            toStringOutput.Add($"this.Tags = {(this.Tags == null ? "null" : $"[{string.Join(", ", this.Tags)} ]")}");
            toStringOutput.Add($"this.SecondaryAmount = {(this.SecondaryAmount == null ? "null" : this.SecondaryAmount.ToString())}");
            toStringOutput.Add($"this.ContactId = {(this.ContactId == null ? "null" : this.ContactId)}");

            base.ToString(toStringOutput);
        }
    }
}