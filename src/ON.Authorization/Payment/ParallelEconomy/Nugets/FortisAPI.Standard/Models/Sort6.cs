// <copyright file="Sort6.cs" company="APIMatic">
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
    /// Sort6.
    /// </summary>
    public class Sort6
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sort6"/> class.
        /// </summary>
        public Sort6()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sort6"/> class.
        /// </summary>
        /// <param name="accountVaultId">account_vault_id.</param>
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
        /// <param name="id">id.</param>
        /// <param name="nextRunDate">next_run_date.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="recurringTypeId">recurring_type_id.</param>
        public Sort6(
            string accountVaultId = null,
            Models.ActiveEnum? active = null,
            string description = null,
            string endDate = null,
            int? installmentTotalCount = null,
            int? interval = null,
            Models.IntervalTypeEnum? intervalType = null,
            string locationId = null,
            int? notificationDays = null,
            Models.PaymentMethodEnum? paymentMethod = null,
            string productTransactionId = null,
            string recurringId = null,
            string recurringApiId = null,
            string startDate = null,
            Models.StatusEnum? status = null,
            double? transactionAmount = null,
            bool? termsAgree = null,
            string termsAgreeIp = null,
            string recurringC1 = null,
            string recurringC2 = null,
            string recurringC3 = null,
            bool? sendToProcAsRecur = null,
            string id = null,
            string nextRunDate = null,
            int? createdTs = null,
            int? modifiedTs = null,
            Models.RecurringTypeIdEnum? recurringTypeId = null)
        {
            this.AccountVaultId = accountVaultId;
            this.Active = active;
            this.Description = description;
            this.EndDate = endDate;
            this.InstallmentTotalCount = installmentTotalCount;
            this.Interval = interval;
            this.IntervalType = intervalType;
            this.LocationId = locationId;
            this.NotificationDays = notificationDays;
            this.PaymentMethod = paymentMethod;
            this.ProductTransactionId = productTransactionId;
            this.RecurringId = recurringId;
            this.RecurringApiId = recurringApiId;
            this.StartDate = startDate;
            this.Status = status;
            this.TransactionAmount = transactionAmount;
            this.TermsAgree = termsAgree;
            this.TermsAgreeIp = termsAgreeIp;
            this.RecurringC1 = recurringC1;
            this.RecurringC2 = recurringC2;
            this.RecurringC3 = recurringC3;
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
        [JsonProperty("account_vault_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountVaultId { get; set; }

        /// <summary>
        /// Active
        /// </summary>
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ActiveEnum? Active { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// End date
        /// </summary>
        [JsonProperty("end_date", NullValueHandling = NullValueHandling.Ignore)]
        public string EndDate { get; set; }

        /// <summary>
        /// Installment Total Count
        /// </summary>
        [JsonProperty("installment_total_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? InstallmentTotalCount { get; set; }

        /// <summary>
        /// Interval
        /// </summary>
        [JsonProperty("interval", NullValueHandling = NullValueHandling.Ignore)]
        public int? Interval { get; set; }

        /// <summary>
        /// Interval Type
        /// </summary>
        [JsonProperty("interval_type", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.IntervalTypeEnum? IntervalType { get; set; }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; set; }

        /// <summary>
        /// Notification Days
        /// </summary>
        [JsonProperty("notification_days", NullValueHandling = NullValueHandling.Ignore)]
        public int? NotificationDays { get; set; }

        /// <summary>
        /// Payment Method
        /// </summary>
        [JsonProperty("payment_method", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentMethodEnum? PaymentMethod { get; set; }

        /// <summary>
        /// Product Transaction ID
        /// </summary>
        [JsonProperty("product_transaction_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTransactionId { get; set; }

        /// <summary>
        /// Recurring ID
        /// </summary>
        [JsonProperty("recurring_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RecurringId { get; set; }

        /// <summary>
        /// Recurring Api ID
        /// </summary>
        [JsonProperty("recurring_api_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RecurringApiId { get; set; }

        /// <summary>
        /// Start date
        /// </summary>
        [JsonProperty("start_date", NullValueHandling = NullValueHandling.Ignore)]
        public string StartDate { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [JsonProperty("status", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.StatusEnum? Status { get; set; }

        /// <summary>
        /// Transaction amount
        /// </summary>
        [JsonProperty("transaction_amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? TransactionAmount { get; set; }

        /// <summary>
        /// Terms Agree
        /// </summary>
        [JsonProperty("terms_agree", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TermsAgree { get; set; }

        /// <summary>
        /// Terms Agree Ip
        /// </summary>
        [JsonProperty("terms_agree_ip", NullValueHandling = NullValueHandling.Ignore)]
        public string TermsAgreeIp { get; set; }

        /// <summary>
        /// Custom field used for integrations
        /// </summary>
        [JsonProperty("recurring_c1", NullValueHandling = NullValueHandling.Ignore)]
        public string RecurringC1 { get; set; }

        /// <summary>
        /// Custom field used for integrations
        /// </summary>
        [JsonProperty("recurring_c2", NullValueHandling = NullValueHandling.Ignore)]
        public string RecurringC2 { get; set; }

        /// <summary>
        /// Custom field used for integrations
        /// </summary>
        [JsonProperty("recurring_c3", NullValueHandling = NullValueHandling.Ignore)]
        public string RecurringC3 { get; set; }

        /// <summary>
        /// Send To Proc As Recur
        /// </summary>
        [JsonProperty("send_to_proc_as_recur", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SendToProcAsRecur { get; set; }

        /// <summary>
        /// Recurring ID
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Next Run Date
        /// </summary>
        [JsonProperty("next_run_date", NullValueHandling = NullValueHandling.Ignore)]
        public string NextRunDate { get; set; }

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
        /// Recurring Type
        /// </summary>
        [JsonProperty("recurring_type_id", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.RecurringTypeIdEnum? RecurringTypeId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Sort6 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Sort6 other &&
                ((this.AccountVaultId == null && other.AccountVaultId == null) || (this.AccountVaultId?.Equals(other.AccountVaultId) == true)) &&
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
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.NextRunDate == null && other.NextRunDate == null) || (this.NextRunDate?.Equals(other.NextRunDate) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.ModifiedTs == null && other.ModifiedTs == null) || (this.ModifiedTs?.Equals(other.ModifiedTs) == true)) &&
                ((this.RecurringTypeId == null && other.RecurringTypeId == null) || (this.RecurringTypeId?.Equals(other.RecurringTypeId) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AccountVaultId = {(this.AccountVaultId == null ? "null" : this.AccountVaultId == string.Empty ? "" : this.AccountVaultId)}");
            toStringOutput.Add($"this.Active = {(this.Active == null ? "null" : this.Active.ToString())}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.EndDate = {(this.EndDate == null ? "null" : this.EndDate == string.Empty ? "" : this.EndDate)}");
            toStringOutput.Add($"this.InstallmentTotalCount = {(this.InstallmentTotalCount == null ? "null" : this.InstallmentTotalCount.ToString())}");
            toStringOutput.Add($"this.Interval = {(this.Interval == null ? "null" : this.Interval.ToString())}");
            toStringOutput.Add($"this.IntervalType = {(this.IntervalType == null ? "null" : this.IntervalType.ToString())}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.NotificationDays = {(this.NotificationDays == null ? "null" : this.NotificationDays.ToString())}");
            toStringOutput.Add($"this.PaymentMethod = {(this.PaymentMethod == null ? "null" : this.PaymentMethod.ToString())}");
            toStringOutput.Add($"this.ProductTransactionId = {(this.ProductTransactionId == null ? "null" : this.ProductTransactionId == string.Empty ? "" : this.ProductTransactionId)}");
            toStringOutput.Add($"this.RecurringId = {(this.RecurringId == null ? "null" : this.RecurringId == string.Empty ? "" : this.RecurringId)}");
            toStringOutput.Add($"this.RecurringApiId = {(this.RecurringApiId == null ? "null" : this.RecurringApiId == string.Empty ? "" : this.RecurringApiId)}");
            toStringOutput.Add($"this.StartDate = {(this.StartDate == null ? "null" : this.StartDate == string.Empty ? "" : this.StartDate)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.TransactionAmount = {(this.TransactionAmount == null ? "null" : this.TransactionAmount.ToString())}");
            toStringOutput.Add($"this.TermsAgree = {(this.TermsAgree == null ? "null" : this.TermsAgree.ToString())}");
            toStringOutput.Add($"this.TermsAgreeIp = {(this.TermsAgreeIp == null ? "null" : this.TermsAgreeIp == string.Empty ? "" : this.TermsAgreeIp)}");
            toStringOutput.Add($"this.RecurringC1 = {(this.RecurringC1 == null ? "null" : this.RecurringC1 == string.Empty ? "" : this.RecurringC1)}");
            toStringOutput.Add($"this.RecurringC2 = {(this.RecurringC2 == null ? "null" : this.RecurringC2 == string.Empty ? "" : this.RecurringC2)}");
            toStringOutput.Add($"this.RecurringC3 = {(this.RecurringC3 == null ? "null" : this.RecurringC3 == string.Empty ? "" : this.RecurringC3)}");
            toStringOutput.Add($"this.SendToProcAsRecur = {(this.SendToProcAsRecur == null ? "null" : this.SendToProcAsRecur.ToString())}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.NextRunDate = {(this.NextRunDate == null ? "null" : this.NextRunDate == string.Empty ? "" : this.NextRunDate)}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.ModifiedTs = {(this.ModifiedTs == null ? "null" : this.ModifiedTs.ToString())}");
            toStringOutput.Add($"this.RecurringTypeId = {(this.RecurringTypeId == null ? "null" : this.RecurringTypeId.ToString())}");
        }
    }
}