// <copyright file="List6.cs" company="APIMatic">
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
    /// List6.
    /// </summary>
    public class List6
    {
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
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
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
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="List6"/> class.
        /// </summary>
        public List6()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="List6"/> class.
        /// </summary>
        /// <param name="accountVaultId">account_vault_id.</param>
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
        public List6(
            string accountVaultId,
            Models.ActiveEnum active,
            int interval,
            Models.IntervalTypeEnum intervalType,
            string locationId,
            Models.PaymentMethodEnum paymentMethod,
            string startDate,
            Models.StatusEnum status,
            double transactionAmount,
            string id,
            string nextRunDate,
            int createdTs,
            int modifiedTs,
            Models.RecurringTypeIdEnum recurringTypeId,
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
            bool? sendToProcAsRecur = null)
        {
            this.AccountVaultId = accountVaultId;
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
            this.Id = id;
            this.NextRunDate = nextRunDate;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            this.RecurringTypeId = recurringTypeId;
        }

        /// <summary>
        /// Token ID
        /// </summary>
        [JsonProperty("account_vault_id")]
        public string AccountVaultId { get; set; }

        /// <summary>
        /// Active
        /// </summary>
        [JsonProperty("active")]
        public Models.ActiveEnum Active { get; set; }

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
        [JsonProperty("interval_type", ItemConverterType = typeof(StringEnumConverter))]
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
        [JsonProperty("payment_method", ItemConverterType = typeof(StringEnumConverter))]
        public Models.PaymentMethodEnum PaymentMethod { get; set; }

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
        [JsonProperty("status", ItemConverterType = typeof(StringEnumConverter))]
        public Models.StatusEnum Status { get; set; }

        /// <summary>
        /// Transaction amount
        /// </summary>
        [JsonProperty("transaction_amount")]
        public double TransactionAmount { get; set; }

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
        [JsonProperty("recurring_type_id", ItemConverterType = typeof(StringEnumConverter))]
        public Models.RecurringTypeIdEnum RecurringTypeId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"List6 : ({string.Join(", ", toStringOutput)})";
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

            return obj is List6 other &&
                ((this.AccountVaultId == null && other.AccountVaultId == null) || (this.AccountVaultId?.Equals(other.AccountVaultId) == true)) &&
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
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.NextRunDate == null && other.NextRunDate == null) || (this.NextRunDate?.Equals(other.NextRunDate) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                this.RecurringTypeId.Equals(other.RecurringTypeId);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AccountVaultId = {(this.AccountVaultId == null ? "null" : this.AccountVaultId == string.Empty ? "" : this.AccountVaultId)}");
            toStringOutput.Add($"this.Active = {this.Active}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.EndDate = {(this.EndDate == null ? "null" : this.EndDate == string.Empty ? "" : this.EndDate)}");
            toStringOutput.Add($"this.InstallmentTotalCount = {(this.InstallmentTotalCount == null ? "null" : this.InstallmentTotalCount.ToString())}");
            toStringOutput.Add($"this.Interval = {this.Interval}");
            toStringOutput.Add($"this.IntervalType = {this.IntervalType}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.NotificationDays = {(this.NotificationDays == null ? "null" : this.NotificationDays.ToString())}");
            toStringOutput.Add($"this.PaymentMethod = {this.PaymentMethod}");
            toStringOutput.Add($"this.ProductTransactionId = {(this.ProductTransactionId == null ? "null" : this.ProductTransactionId == string.Empty ? "" : this.ProductTransactionId)}");
            toStringOutput.Add($"this.RecurringId = {(this.RecurringId == null ? "null" : this.RecurringId == string.Empty ? "" : this.RecurringId)}");
            toStringOutput.Add($"this.RecurringApiId = {(this.RecurringApiId == null ? "null" : this.RecurringApiId == string.Empty ? "" : this.RecurringApiId)}");
            toStringOutput.Add($"this.StartDate = {(this.StartDate == null ? "null" : this.StartDate == string.Empty ? "" : this.StartDate)}");
            toStringOutput.Add($"this.Status = {this.Status}");
            toStringOutput.Add($"this.TransactionAmount = {this.TransactionAmount}");
            toStringOutput.Add($"this.TermsAgree = {(this.TermsAgree == null ? "null" : this.TermsAgree.ToString())}");
            toStringOutput.Add($"this.TermsAgreeIp = {(this.TermsAgreeIp == null ? "null" : this.TermsAgreeIp == string.Empty ? "" : this.TermsAgreeIp)}");
            toStringOutput.Add($"this.RecurringC1 = {(this.RecurringC1 == null ? "null" : this.RecurringC1 == string.Empty ? "" : this.RecurringC1)}");
            toStringOutput.Add($"this.RecurringC2 = {(this.RecurringC2 == null ? "null" : this.RecurringC2 == string.Empty ? "" : this.RecurringC2)}");
            toStringOutput.Add($"this.RecurringC3 = {(this.RecurringC3 == null ? "null" : this.RecurringC3 == string.Empty ? "" : this.RecurringC3)}");
            toStringOutput.Add($"this.SendToProcAsRecur = {(this.SendToProcAsRecur == null ? "null" : this.SendToProcAsRecur.ToString())}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.NextRunDate = {(this.NextRunDate == null ? "null" : this.NextRunDate == string.Empty ? "" : this.NextRunDate)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.RecurringTypeId = {this.RecurringTypeId}");
        }
    }
}