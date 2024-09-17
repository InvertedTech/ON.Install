// <copyright file="Surcharge.cs" company="APIMatic">
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
    /// Surcharge.
    /// </summary>
    public class Surcharge : BaseModel
    {
        private int? maxTransactionAmount;
        private int? minFeeAmount;
        private int? maxFeeAmount;
        private string applyToUserTypeId;
        private string title;
        private string surchargeLabel;
        private string surchargeTransactionProductId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "max_transaction_amount", false },
            { "min_fee_amount", false },
            { "max_fee_amount", false },
            { "apply_to_user_type_id", false },
            { "title", false },
            { "surcharge_label", false },
            { "surcharge_transaction_product_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Surcharge"/> class.
        /// </summary>
        public Surcharge()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Surcharge"/> class.
        /// </summary>
        /// <param name="surchargeFee">surcharge_fee.</param>
        /// <param name="surchargeRate">surcharge_rate.</param>
        /// <param name="productTransactionId">product_transaction_id.</param>
        /// <param name="id">id.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="modifiedUserId">modified_user_id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="maxTransactionAmount">max_transaction_amount.</param>
        /// <param name="minFeeAmount">min_fee_amount.</param>
        /// <param name="maxFeeAmount">max_fee_amount.</param>
        /// <param name="surchargeOnRecurring">surcharge_on_recurring.</param>
        /// <param name="refundSurcharges">refund_surcharges.</param>
        /// <param name="runAsSeparateTransaction">run_as_separate_transaction.</param>
        /// <param name="applyToUserTypeId">apply_to_user_type_id.</param>
        /// <param name="title">title.</param>
        /// <param name="surchargeLabel">surcharge_label.</param>
        /// <param name="surchargeTransactionProductId">surcharge_transaction_product_id.</param>
        public Surcharge(
            int surchargeFee,
            int surchargeRate,
            string productTransactionId,
            string id,
            string createdUserId,
            string modifiedUserId,
            int createdTs,
            int modifiedTs,
            int? maxTransactionAmount = null,
            int? minFeeAmount = null,
            int? maxFeeAmount = null,
            bool? surchargeOnRecurring = null,
            bool? refundSurcharges = null,
            bool? runAsSeparateTransaction = null,
            string applyToUserTypeId = null,
            string title = null,
            string surchargeLabel = null,
            string surchargeTransactionProductId = null)
        {
            this.SurchargeFee = surchargeFee;
            this.SurchargeRate = surchargeRate;
            if (maxTransactionAmount != null)
            {
                this.MaxTransactionAmount = maxTransactionAmount;
            }

            if (minFeeAmount != null)
            {
                this.MinFeeAmount = minFeeAmount;
            }

            if (maxFeeAmount != null)
            {
                this.MaxFeeAmount = maxFeeAmount;
            }

            this.SurchargeOnRecurring = surchargeOnRecurring;
            this.RefundSurcharges = refundSurcharges;
            this.ProductTransactionId = productTransactionId;
            this.RunAsSeparateTransaction = runAsSeparateTransaction;
            if (applyToUserTypeId != null)
            {
                this.ApplyToUserTypeId = applyToUserTypeId;
            }

            if (title != null)
            {
                this.Title = title;
            }

            if (surchargeLabel != null)
            {
                this.SurchargeLabel = surchargeLabel;
            }

            if (surchargeTransactionProductId != null)
            {
                this.SurchargeTransactionProductId = surchargeTransactionProductId;
            }

            this.Id = id;
            this.CreatedUserId = createdUserId;
            this.ModifiedUserId = modifiedUserId;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
        }

        /// <summary>
        /// Surcharge Fee
        /// </summary>
        [JsonProperty("surcharge_fee")]
        public int SurchargeFee { get; set; }

        /// <summary>
        /// Surcharge Rate
        /// </summary>
        [JsonProperty("surcharge_rate")]
        public int SurchargeRate { get; set; }

        /// <summary>
        /// Max Transaction Amount
        /// </summary>
        [JsonProperty("max_transaction_amount")]
        public int? MaxTransactionAmount
        {
            get
            {
                return this.maxTransactionAmount;
            }

            set
            {
                this.shouldSerialize["max_transaction_amount"] = true;
                this.maxTransactionAmount = value;
            }
        }

        /// <summary>
        /// Min Fee Amount
        /// </summary>
        [JsonProperty("min_fee_amount")]
        public int? MinFeeAmount
        {
            get
            {
                return this.minFeeAmount;
            }

            set
            {
                this.shouldSerialize["min_fee_amount"] = true;
                this.minFeeAmount = value;
            }
        }

        /// <summary>
        /// Max Fee Amount
        /// </summary>
        [JsonProperty("max_fee_amount")]
        public int? MaxFeeAmount
        {
            get
            {
                return this.maxFeeAmount;
            }

            set
            {
                this.shouldSerialize["max_fee_amount"] = true;
                this.maxFeeAmount = value;
            }
        }

        /// <summary>
        /// Surcharge On Recurring
        /// </summary>
        [JsonProperty("surcharge_on_recurring", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SurchargeOnRecurring { get; set; }

        /// <summary>
        /// Refund Surcharges
        /// </summary>
        [JsonProperty("refund_surcharges", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RefundSurcharges { get; set; }

        /// <summary>
        /// Product Transaction Id
        /// </summary>
        [JsonProperty("product_transaction_id")]
        public string ProductTransactionId { get; set; }

        /// <summary>
        /// Run As Separate Transaction
        /// </summary>
        [JsonProperty("run_as_separate_transaction", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RunAsSeparateTransaction { get; set; }

        /// <summary>
        /// Apply To User Type Id
        /// </summary>
        [JsonProperty("apply_to_user_type_id")]
        public string ApplyToUserTypeId
        {
            get
            {
                return this.applyToUserTypeId;
            }

            set
            {
                this.shouldSerialize["apply_to_user_type_id"] = true;
                this.applyToUserTypeId = value;
            }
        }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.shouldSerialize["title"] = true;
                this.title = value;
            }
        }

        /// <summary>
        /// Surcharge Label
        /// </summary>
        [JsonProperty("surcharge_label")]
        public string SurchargeLabel
        {
            get
            {
                return this.surchargeLabel;
            }

            set
            {
                this.shouldSerialize["surcharge_label"] = true;
                this.surchargeLabel = value;
            }
        }

        /// <summary>
        /// Surcharge Transaction Product Id
        /// </summary>
        [JsonProperty("surcharge_transaction_product_id")]
        public string SurchargeTransactionProductId
        {
            get
            {
                return this.surchargeTransactionProductId;
            }

            set
            {
                this.shouldSerialize["surcharge_transaction_product_id"] = true;
                this.surchargeTransactionProductId = value;
            }
        }

        /// <summary>
        /// Surcharge Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// User ID Created the register
        /// </summary>
        [JsonProperty("created_user_id")]
        public string CreatedUserId { get; set; }

        /// <summary>
        /// Last User ID that updated the register
        /// </summary>
        [JsonProperty("modified_user_id")]
        public string ModifiedUserId { get; set; }

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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Surcharge : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMaxTransactionAmount()
        {
            this.shouldSerialize["max_transaction_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMinFeeAmount()
        {
            this.shouldSerialize["min_fee_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMaxFeeAmount()
        {
            this.shouldSerialize["max_fee_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetApplyToUserTypeId()
        {
            this.shouldSerialize["apply_to_user_type_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTitle()
        {
            this.shouldSerialize["title"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSurchargeLabel()
        {
            this.shouldSerialize["surcharge_label"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSurchargeTransactionProductId()
        {
            this.shouldSerialize["surcharge_transaction_product_id"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMaxTransactionAmount()
        {
            return this.shouldSerialize["max_transaction_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMinFeeAmount()
        {
            return this.shouldSerialize["min_fee_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMaxFeeAmount()
        {
            return this.shouldSerialize["max_fee_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeApplyToUserTypeId()
        {
            return this.shouldSerialize["apply_to_user_type_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTitle()
        {
            return this.shouldSerialize["title"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSurchargeLabel()
        {
            return this.shouldSerialize["surcharge_label"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSurchargeTransactionProductId()
        {
            return this.shouldSerialize["surcharge_transaction_product_id"];
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
            return obj is Surcharge other &&                this.SurchargeFee.Equals(other.SurchargeFee) &&
                this.SurchargeRate.Equals(other.SurchargeRate) &&
                ((this.MaxTransactionAmount == null && other.MaxTransactionAmount == null) || (this.MaxTransactionAmount?.Equals(other.MaxTransactionAmount) == true)) &&
                ((this.MinFeeAmount == null && other.MinFeeAmount == null) || (this.MinFeeAmount?.Equals(other.MinFeeAmount) == true)) &&
                ((this.MaxFeeAmount == null && other.MaxFeeAmount == null) || (this.MaxFeeAmount?.Equals(other.MaxFeeAmount) == true)) &&
                ((this.SurchargeOnRecurring == null && other.SurchargeOnRecurring == null) || (this.SurchargeOnRecurring?.Equals(other.SurchargeOnRecurring) == true)) &&
                ((this.RefundSurcharges == null && other.RefundSurcharges == null) || (this.RefundSurcharges?.Equals(other.RefundSurcharges) == true)) &&
                ((this.ProductTransactionId == null && other.ProductTransactionId == null) || (this.ProductTransactionId?.Equals(other.ProductTransactionId) == true)) &&
                ((this.RunAsSeparateTransaction == null && other.RunAsSeparateTransaction == null) || (this.RunAsSeparateTransaction?.Equals(other.RunAsSeparateTransaction) == true)) &&
                ((this.ApplyToUserTypeId == null && other.ApplyToUserTypeId == null) || (this.ApplyToUserTypeId?.Equals(other.ApplyToUserTypeId) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.SurchargeLabel == null && other.SurchargeLabel == null) || (this.SurchargeLabel?.Equals(other.SurchargeLabel) == true)) &&
                ((this.SurchargeTransactionProductId == null && other.SurchargeTransactionProductId == null) || (this.SurchargeTransactionProductId?.Equals(other.SurchargeTransactionProductId) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true)) &&
                ((this.ModifiedUserId == null && other.ModifiedUserId == null) || (this.ModifiedUserId?.Equals(other.ModifiedUserId) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs);
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SurchargeFee = {this.SurchargeFee}");
            toStringOutput.Add($"this.SurchargeRate = {this.SurchargeRate}");
            toStringOutput.Add($"this.MaxTransactionAmount = {(this.MaxTransactionAmount == null ? "null" : this.MaxTransactionAmount.ToString())}");
            toStringOutput.Add($"this.MinFeeAmount = {(this.MinFeeAmount == null ? "null" : this.MinFeeAmount.ToString())}");
            toStringOutput.Add($"this.MaxFeeAmount = {(this.MaxFeeAmount == null ? "null" : this.MaxFeeAmount.ToString())}");
            toStringOutput.Add($"this.SurchargeOnRecurring = {(this.SurchargeOnRecurring == null ? "null" : this.SurchargeOnRecurring.ToString())}");
            toStringOutput.Add($"this.RefundSurcharges = {(this.RefundSurcharges == null ? "null" : this.RefundSurcharges.ToString())}");
            toStringOutput.Add($"this.ProductTransactionId = {(this.ProductTransactionId == null ? "null" : this.ProductTransactionId)}");
            toStringOutput.Add($"this.RunAsSeparateTransaction = {(this.RunAsSeparateTransaction == null ? "null" : this.RunAsSeparateTransaction.ToString())}");
            toStringOutput.Add($"this.ApplyToUserTypeId = {(this.ApplyToUserTypeId == null ? "null" : this.ApplyToUserTypeId)}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
            toStringOutput.Add($"this.SurchargeLabel = {(this.SurchargeLabel == null ? "null" : this.SurchargeLabel)}");
            toStringOutput.Add($"this.SurchargeTransactionProductId = {(this.SurchargeTransactionProductId == null ? "null" : this.SurchargeTransactionProductId)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.ModifiedUserId = {(this.ModifiedUserId == null ? "null" : this.ModifiedUserId)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");

            base.ToString(toStringOutput);
        }
    }
}