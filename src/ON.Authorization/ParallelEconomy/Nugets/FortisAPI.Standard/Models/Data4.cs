// <copyright file="Data4.cs" company="APIMatic">
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
    /// Data4.
    /// </summary>
    public class Data4 : BaseModel
    {
        private string accountHolderName;
        private List<string> tags;
        private string routing;
        private Models.ReasonCodeIdEnum? reasonCodeId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "account_holder_name", false },
            { "tags", false },
            { "routing", false },
            { "reason_code_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Data4"/> class.
        /// </summary>
        public Data4()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data4"/> class.
        /// </summary>
        /// <param name="declinedRecurringTransactionId">declined_recurring_transaction_id.</param>
        /// <param name="accountNumber">account_number.</param>
        /// <param name="expDate">exp_date.</param>
        /// <param name="transactionAmount">transaction_amount.</param>
        /// <param name="firstSix">first_six.</param>
        /// <param name="lastFour">last_four.</param>
        /// <param name="accountHolderName">account_holder_name.</param>
        /// <param name="description">description.</param>
        /// <param name="billingAddress">billing_address.</param>
        /// <param name="tags">tags.</param>
        /// <param name="id">id.</param>
        /// <param name="routing">routing.</param>
        /// <param name="statusId">status_id.</param>
        /// <param name="reasonCodeId">reason_code_id.</param>
        /// <param name="typeId">type_id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="createdUserId">created_user_id.</param>
        public Data4(
            string declinedRecurringTransactionId,
            string accountNumber,
            string expDate,
            int transactionAmount,
            string firstSix,
            string lastFour,
            string accountHolderName = null,
            string description = null,
            Models.BillingAddress billingAddress = null,
            List<string> tags = null,
            string id = null,
            string routing = null,
            double? statusId = null,
            Models.ReasonCodeIdEnum? reasonCodeId = null,
            double? typeId = null,
            int? createdTs = null,
            string createdUserId = null)
        {
            this.DeclinedRecurringTransactionId = declinedRecurringTransactionId;
            this.AccountNumber = accountNumber;
            if (accountHolderName != null)
            {
                this.AccountHolderName = accountHolderName;
            }

            this.ExpDate = expDate;
            this.TransactionAmount = transactionAmount;
            this.Description = description;
            this.BillingAddress = billingAddress;
            if (tags != null)
            {
                this.Tags = tags;
            }

            this.Id = id;
            this.FirstSix = firstSix;
            this.LastFour = lastFour;
            if (routing != null)
            {
                this.Routing = routing;
            }

            this.StatusId = statusId;
            if (reasonCodeId != null)
            {
                this.ReasonCodeId = reasonCodeId;
            }

            this.TypeId = typeId;
            this.CreatedTs = createdTs;
            this.CreatedUserId = createdUserId;
        }

        /// <summary>
        /// Declined Recurring Transaction Id
        /// </summary>
        [JsonProperty("declined_recurring_transaction_id")]
        public string DeclinedRecurringTransactionId { get; set; }

        /// <summary>
        /// Account Number
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Account Holder Name
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
        /// Exp Date
        /// </summary>
        [JsonProperty("exp_date")]
        public string ExpDate { get; set; }

        /// <summary>
        /// Transaction Amount
        /// </summary>
        [JsonProperty("transaction_amount")]
        public int TransactionAmount { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Billing Address Object
        /// </summary>
        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BillingAddress BillingAddress { get; set; }

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
        /// Id
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// First Six
        /// </summary>
        [JsonProperty("first_six")]
        public string FirstSix { get; set; }

        /// <summary>
        /// Last Four
        /// </summary>
        [JsonProperty("last_four")]
        public string LastFour { get; set; }

        /// <summary>
        /// Routing
        /// </summary>
        [JsonProperty("routing")]
        public string Routing
        {
            get
            {
                return this.routing;
            }

            set
            {
                this.shouldSerialize["routing"] = true;
                this.routing = value;
            }
        }

        /// <summary>
        /// Status Id
        /// </summary>
        [JsonProperty("status_id", NullValueHandling = NullValueHandling.Ignore)]
        public double? StatusId { get; set; }

        /// <summary>
        /// Reason Code Id
        /// </summary>
        [JsonProperty("reason_code_id")]
        public Models.ReasonCodeIdEnum? ReasonCodeId
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
        /// Type Id
        /// </summary>
        [JsonProperty("type_id", NullValueHandling = NullValueHandling.Ignore)]
        public double? TypeId { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? CreatedTs { get; set; }

        /// <summary>
        /// User ID Created the register
        /// </summary>
        [JsonProperty("created_user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedUserId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data4 : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetTags()
        {
            this.shouldSerialize["tags"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRouting()
        {
            this.shouldSerialize["routing"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReasonCodeId()
        {
            this.shouldSerialize["reason_code_id"] = false;
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
        public bool ShouldSerializeTags()
        {
            return this.shouldSerialize["tags"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRouting()
        {
            return this.shouldSerialize["routing"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReasonCodeId()
        {
            return this.shouldSerialize["reason_code_id"];
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
            return obj is Data4 other &&                ((this.DeclinedRecurringTransactionId == null && other.DeclinedRecurringTransactionId == null) || (this.DeclinedRecurringTransactionId?.Equals(other.DeclinedRecurringTransactionId) == true)) &&
                ((this.AccountNumber == null && other.AccountNumber == null) || (this.AccountNumber?.Equals(other.AccountNumber) == true)) &&
                ((this.AccountHolderName == null && other.AccountHolderName == null) || (this.AccountHolderName?.Equals(other.AccountHolderName) == true)) &&
                ((this.ExpDate == null && other.ExpDate == null) || (this.ExpDate?.Equals(other.ExpDate) == true)) &&
                this.TransactionAmount.Equals(other.TransactionAmount) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.BillingAddress == null && other.BillingAddress == null) || (this.BillingAddress?.Equals(other.BillingAddress) == true)) &&
                ((this.Tags == null && other.Tags == null) || (this.Tags?.Equals(other.Tags) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.FirstSix == null && other.FirstSix == null) || (this.FirstSix?.Equals(other.FirstSix) == true)) &&
                ((this.LastFour == null && other.LastFour == null) || (this.LastFour?.Equals(other.LastFour) == true)) &&
                ((this.Routing == null && other.Routing == null) || (this.Routing?.Equals(other.Routing) == true)) &&
                ((this.StatusId == null && other.StatusId == null) || (this.StatusId?.Equals(other.StatusId) == true)) &&
                ((this.ReasonCodeId == null && other.ReasonCodeId == null) || (this.ReasonCodeId?.Equals(other.ReasonCodeId) == true)) &&
                ((this.TypeId == null && other.TypeId == null) || (this.TypeId?.Equals(other.TypeId) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DeclinedRecurringTransactionId = {(this.DeclinedRecurringTransactionId == null ? "null" : this.DeclinedRecurringTransactionId)}");
            toStringOutput.Add($"this.AccountNumber = {(this.AccountNumber == null ? "null" : this.AccountNumber)}");
            toStringOutput.Add($"this.AccountHolderName = {(this.AccountHolderName == null ? "null" : this.AccountHolderName)}");
            toStringOutput.Add($"this.ExpDate = {(this.ExpDate == null ? "null" : this.ExpDate)}");
            toStringOutput.Add($"this.TransactionAmount = {this.TransactionAmount}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description)}");
            toStringOutput.Add($"this.BillingAddress = {(this.BillingAddress == null ? "null" : this.BillingAddress.ToString())}");
            toStringOutput.Add($"this.Tags = {(this.Tags == null ? "null" : $"[{string.Join(", ", this.Tags)} ]")}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.FirstSix = {(this.FirstSix == null ? "null" : this.FirstSix)}");
            toStringOutput.Add($"this.LastFour = {(this.LastFour == null ? "null" : this.LastFour)}");
            toStringOutput.Add($"this.Routing = {(this.Routing == null ? "null" : this.Routing)}");
            toStringOutput.Add($"this.StatusId = {(this.StatusId == null ? "null" : this.StatusId.ToString())}");
            toStringOutput.Add($"this.ReasonCodeId = {(this.ReasonCodeId == null ? "null" : this.ReasonCodeId.ToString())}");
            toStringOutput.Add($"this.TypeId = {(this.TypeId == null ? "null" : this.TypeId.ToString())}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}