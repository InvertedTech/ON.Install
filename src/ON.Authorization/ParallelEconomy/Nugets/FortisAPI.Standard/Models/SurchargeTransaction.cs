// <copyright file="SurchargeTransaction.cs" company="APIMatic">
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
    /// SurchargeTransaction.
    /// </summary>
    public class SurchargeTransaction : BaseModel
    {
        private int? surchargeAmount;
        private int? surchargeTransactionMin;
        private int? surchargeTransactionMax;
        private int? created;
        private int? modified;
        private string createdUserId;
        private string modifiedUserId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "surcharge_amount", false },
            { "surcharge_transaction_min", false },
            { "surcharge_transaction_max", false },
            { "created", false },
            { "modified", false },
            { "created_user_id", false },
            { "modified_user_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="SurchargeTransaction"/> class.
        /// </summary>
        public SurchargeTransaction()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SurchargeTransaction"/> class.
        /// </summary>
        /// <param name="modelName">model_name.</param>
        /// <param name="transactionId">transaction_id.</param>
        /// <param name="surchargeFee">surcharge_fee.</param>
        /// <param name="surchargeRate">surcharge_rate.</param>
        /// <param name="id">id.</param>
        /// <param name="surchargeAmount">surcharge_amount.</param>
        /// <param name="surchargeTransactionMin">surcharge_transaction_min.</param>
        /// <param name="surchargeTransactionMax">surcharge_transaction_max.</param>
        /// <param name="created">created.</param>
        /// <param name="modified">modified.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="modifiedUserId">modified_user_id.</param>
        public SurchargeTransaction(
            string modelName,
            string transactionId,
            int surchargeFee,
            int surchargeRate,
            string id = null,
            int? surchargeAmount = null,
            int? surchargeTransactionMin = null,
            int? surchargeTransactionMax = null,
            int? created = null,
            int? modified = null,
            string createdUserId = null,
            string modifiedUserId = null)
        {
            this.Id = id;
            this.ModelName = modelName;
            this.TransactionId = transactionId;
            this.SurchargeFee = surchargeFee;
            this.SurchargeRate = surchargeRate;
            if (surchargeAmount != null)
            {
                this.SurchargeAmount = surchargeAmount;
            }

            if (surchargeTransactionMin != null)
            {
                this.SurchargeTransactionMin = surchargeTransactionMin;
            }

            if (surchargeTransactionMax != null)
            {
                this.SurchargeTransactionMax = surchargeTransactionMax;
            }

            if (created != null)
            {
                this.Created = created;
            }

            if (modified != null)
            {
                this.Modified = modified;
            }

            if (createdUserId != null)
            {
                this.CreatedUserId = createdUserId;
            }

            if (modifiedUserId != null)
            {
                this.ModifiedUserId = modifiedUserId;
            }

        }

        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Model Name
        /// </summary>
        [JsonProperty("model_name")]
        public string ModelName { get; set; }

        /// <summary>
        /// Transaction ID
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

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
        /// Surcharge Amount
        /// </summary>
        [JsonProperty("surcharge_amount")]
        public int? SurchargeAmount
        {
            get
            {
                return this.surchargeAmount;
            }

            set
            {
                this.shouldSerialize["surcharge_amount"] = true;
                this.surchargeAmount = value;
            }
        }

        /// <summary>
        /// Surcharge Transaction Minimum
        /// </summary>
        [JsonProperty("surcharge_transaction_min")]
        public int? SurchargeTransactionMin
        {
            get
            {
                return this.surchargeTransactionMin;
            }

            set
            {
                this.shouldSerialize["surcharge_transaction_min"] = true;
                this.surchargeTransactionMin = value;
            }
        }

        /// <summary>
        /// Surcharge Transaction Maximum
        /// </summary>
        [JsonProperty("surcharge_transaction_max")]
        public int? SurchargeTransactionMax
        {
            get
            {
                return this.surchargeTransactionMax;
            }

            set
            {
                this.shouldSerialize["surcharge_transaction_max"] = true;
                this.surchargeTransactionMax = value;
            }
        }

        /// <summary>
        /// Created
        /// </summary>
        [JsonProperty("created")]
        public int? Created
        {
            get
            {
                return this.created;
            }

            set
            {
                this.shouldSerialize["created"] = true;
                this.created = value;
            }
        }

        /// <summary>
        /// Modified
        /// </summary>
        [JsonProperty("modified")]
        public int? Modified
        {
            get
            {
                return this.modified;
            }

            set
            {
                this.shouldSerialize["modified"] = true;
                this.modified = value;
            }
        }

        /// <summary>
        /// User ID Created the register
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
        /// Last User ID that updated the register
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SurchargeTransaction : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSurchargeAmount()
        {
            this.shouldSerialize["surcharge_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSurchargeTransactionMin()
        {
            this.shouldSerialize["surcharge_transaction_min"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSurchargeTransactionMax()
        {
            this.shouldSerialize["surcharge_transaction_max"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCreated()
        {
            this.shouldSerialize["created"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetModified()
        {
            this.shouldSerialize["modified"] = false;
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
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSurchargeAmount()
        {
            return this.shouldSerialize["surcharge_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSurchargeTransactionMin()
        {
            return this.shouldSerialize["surcharge_transaction_min"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSurchargeTransactionMax()
        {
            return this.shouldSerialize["surcharge_transaction_max"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCreated()
        {
            return this.shouldSerialize["created"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModified()
        {
            return this.shouldSerialize["modified"];
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
            return obj is SurchargeTransaction other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.ModelName == null && other.ModelName == null) || (this.ModelName?.Equals(other.ModelName) == true)) &&
                ((this.TransactionId == null && other.TransactionId == null) || (this.TransactionId?.Equals(other.TransactionId) == true)) &&
                this.SurchargeFee.Equals(other.SurchargeFee) &&
                this.SurchargeRate.Equals(other.SurchargeRate) &&
                ((this.SurchargeAmount == null && other.SurchargeAmount == null) || (this.SurchargeAmount?.Equals(other.SurchargeAmount) == true)) &&
                ((this.SurchargeTransactionMin == null && other.SurchargeTransactionMin == null) || (this.SurchargeTransactionMin?.Equals(other.SurchargeTransactionMin) == true)) &&
                ((this.SurchargeTransactionMax == null && other.SurchargeTransactionMax == null) || (this.SurchargeTransactionMax?.Equals(other.SurchargeTransactionMax) == true)) &&
                ((this.Created == null && other.Created == null) || (this.Created?.Equals(other.Created) == true)) &&
                ((this.Modified == null && other.Modified == null) || (this.Modified?.Equals(other.Modified) == true)) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true)) &&
                ((this.ModifiedUserId == null && other.ModifiedUserId == null) || (this.ModifiedUserId?.Equals(other.ModifiedUserId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.ModelName = {(this.ModelName == null ? "null" : this.ModelName)}");
            toStringOutput.Add($"this.TransactionId = {(this.TransactionId == null ? "null" : this.TransactionId)}");
            toStringOutput.Add($"this.SurchargeFee = {this.SurchargeFee}");
            toStringOutput.Add($"this.SurchargeRate = {this.SurchargeRate}");
            toStringOutput.Add($"this.SurchargeAmount = {(this.SurchargeAmount == null ? "null" : this.SurchargeAmount.ToString())}");
            toStringOutput.Add($"this.SurchargeTransactionMin = {(this.SurchargeTransactionMin == null ? "null" : this.SurchargeTransactionMin.ToString())}");
            toStringOutput.Add($"this.SurchargeTransactionMax = {(this.SurchargeTransactionMax == null ? "null" : this.SurchargeTransactionMax.ToString())}");
            toStringOutput.Add($"this.Created = {(this.Created == null ? "null" : this.Created.ToString())}");
            toStringOutput.Add($"this.Modified = {(this.Modified == null ? "null" : this.Modified.ToString())}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.ModifiedUserId = {(this.ModifiedUserId == null ? "null" : this.ModifiedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}