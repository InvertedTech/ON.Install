// <copyright file="TransactionReference.cs" company="APIMatic">
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
    /// TransactionReference.
    /// </summary>
    public class TransactionReference : BaseModel
    {
        private string transactionId;
        private string previousTransactionId;
        private int? transactionAmount;
        private int? previousTransactionAmount;
        private double? previousTransactionCreatedTs;
        private string referenceType;
        private int? createdTs;
        private string createdUserId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "transaction_id", false },
            { "previous_transaction_id", false },
            { "transaction_amount", false },
            { "previous_transaction_amount", false },
            { "previous_transaction_created_ts", false },
            { "reference_type", false },
            { "created_ts", false },
            { "created_user_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionReference"/> class.
        /// </summary>
        public TransactionReference()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionReference"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="transactionId">transaction_id.</param>
        /// <param name="previousTransactionId">previous_transaction_id.</param>
        /// <param name="transactionAmount">transaction_amount.</param>
        /// <param name="previousTransactionAmount">previous_transaction_amount.</param>
        /// <param name="previousTransactionCreatedTs">previous_transaction_created_ts.</param>
        /// <param name="referenceType">reference_type.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="createdUserId">created_user_id.</param>
        public TransactionReference(
            string id = null,
            string transactionId = null,
            string previousTransactionId = null,
            int? transactionAmount = null,
            int? previousTransactionAmount = null,
            double? previousTransactionCreatedTs = null,
            string referenceType = null,
            int? createdTs = null,
            string createdUserId = null)
        {
            this.Id = id;
            if (transactionId != null)
            {
                this.TransactionId = transactionId;
            }

            if (previousTransactionId != null)
            {
                this.PreviousTransactionId = previousTransactionId;
            }

            if (transactionAmount != null)
            {
                this.TransactionAmount = transactionAmount;
            }

            if (previousTransactionAmount != null)
            {
                this.PreviousTransactionAmount = previousTransactionAmount;
            }

            if (previousTransactionCreatedTs != null)
            {
                this.PreviousTransactionCreatedTs = previousTransactionCreatedTs;
            }

            if (referenceType != null)
            {
                this.ReferenceType = referenceType;
            }

            if (createdTs != null)
            {
                this.CreatedTs = createdTs;
            }

            if (createdUserId != null)
            {
                this.CreatedUserId = createdUserId;
            }

        }

        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Transaction ID
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId
        {
            get
            {
                return this.transactionId;
            }

            set
            {
                this.shouldSerialize["transaction_id"] = true;
                this.transactionId = value;
            }
        }

        /// <summary>
        /// Previous Transaction ID
        /// </summary>
        [JsonProperty("previous_transaction_id")]
        public string PreviousTransactionId
        {
            get
            {
                return this.previousTransactionId;
            }

            set
            {
                this.shouldSerialize["previous_transaction_id"] = true;
                this.previousTransactionId = value;
            }
        }

        /// <summary>
        /// Transaction Amount
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
        /// Previous Transaction Amount
        /// </summary>
        [JsonProperty("previous_transaction_amount")]
        public int? PreviousTransactionAmount
        {
            get
            {
                return this.previousTransactionAmount;
            }

            set
            {
                this.shouldSerialize["previous_transaction_amount"] = true;
                this.previousTransactionAmount = value;
            }
        }

        /// <summary>
        /// Previous Transaction Created Timestamp
        /// </summary>
        [JsonProperty("previous_transaction_created_ts")]
        public double? PreviousTransactionCreatedTs
        {
            get
            {
                return this.previousTransactionCreatedTs;
            }

            set
            {
                this.shouldSerialize["previous_transaction_created_ts"] = true;
                this.previousTransactionCreatedTs = value;
            }
        }

        /// <summary>
        /// Reference Type
        /// </summary>
        [JsonProperty("reference_type")]
        public string ReferenceType
        {
            get
            {
                return this.referenceType;
            }

            set
            {
                this.shouldSerialize["reference_type"] = true;
                this.referenceType = value;
            }
        }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int? CreatedTs
        {
            get
            {
                return this.createdTs;
            }

            set
            {
                this.shouldSerialize["created_ts"] = true;
                this.createdTs = value;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TransactionReference : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTransactionId()
        {
            this.shouldSerialize["transaction_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPreviousTransactionId()
        {
            this.shouldSerialize["previous_transaction_id"] = false;
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
        public void UnsetPreviousTransactionAmount()
        {
            this.shouldSerialize["previous_transaction_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPreviousTransactionCreatedTs()
        {
            this.shouldSerialize["previous_transaction_created_ts"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReferenceType()
        {
            this.shouldSerialize["reference_type"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCreatedTs()
        {
            this.shouldSerialize["created_ts"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCreatedUserId()
        {
            this.shouldSerialize["created_user_id"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTransactionId()
        {
            return this.shouldSerialize["transaction_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePreviousTransactionId()
        {
            return this.shouldSerialize["previous_transaction_id"];
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
        public bool ShouldSerializePreviousTransactionAmount()
        {
            return this.shouldSerialize["previous_transaction_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePreviousTransactionCreatedTs()
        {
            return this.shouldSerialize["previous_transaction_created_ts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReferenceType()
        {
            return this.shouldSerialize["reference_type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCreatedTs()
        {
            return this.shouldSerialize["created_ts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCreatedUserId()
        {
            return this.shouldSerialize["created_user_id"];
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
            return obj is TransactionReference other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.TransactionId == null && other.TransactionId == null) || (this.TransactionId?.Equals(other.TransactionId) == true)) &&
                ((this.PreviousTransactionId == null && other.PreviousTransactionId == null) || (this.PreviousTransactionId?.Equals(other.PreviousTransactionId) == true)) &&
                ((this.TransactionAmount == null && other.TransactionAmount == null) || (this.TransactionAmount?.Equals(other.TransactionAmount) == true)) &&
                ((this.PreviousTransactionAmount == null && other.PreviousTransactionAmount == null) || (this.PreviousTransactionAmount?.Equals(other.PreviousTransactionAmount) == true)) &&
                ((this.PreviousTransactionCreatedTs == null && other.PreviousTransactionCreatedTs == null) || (this.PreviousTransactionCreatedTs?.Equals(other.PreviousTransactionCreatedTs) == true)) &&
                ((this.ReferenceType == null && other.ReferenceType == null) || (this.ReferenceType?.Equals(other.ReferenceType) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.TransactionId = {(this.TransactionId == null ? "null" : this.TransactionId)}");
            toStringOutput.Add($"this.PreviousTransactionId = {(this.PreviousTransactionId == null ? "null" : this.PreviousTransactionId)}");
            toStringOutput.Add($"this.TransactionAmount = {(this.TransactionAmount == null ? "null" : this.TransactionAmount.ToString())}");
            toStringOutput.Add($"this.PreviousTransactionAmount = {(this.PreviousTransactionAmount == null ? "null" : this.PreviousTransactionAmount.ToString())}");
            toStringOutput.Add($"this.PreviousTransactionCreatedTs = {(this.PreviousTransactionCreatedTs == null ? "null" : this.PreviousTransactionCreatedTs.ToString())}");
            toStringOutput.Add($"this.ReferenceType = {(this.ReferenceType == null ? "null" : this.ReferenceType)}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}