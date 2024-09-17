// <copyright file="TransactionSplit.cs" company="APIMatic">
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
    /// TransactionSplit.
    /// </summary>
    public class TransactionSplit : BaseModel
    {
        private string createdUserId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "created_user_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionSplit"/> class.
        /// </summary>
        public TransactionSplit()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionSplit"/> class.
        /// </summary>
        /// <param name="transactionId">transaction_id.</param>
        /// <param name="contactId">contact_id.</param>
        /// <param name="amount">amount.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="createdUserId">created_user_id.</param>
        public TransactionSplit(
            string transactionId,
            string contactId,
            int amount,
            string id,
            int createdTs,
            string createdUserId = null)
        {
            this.TransactionId = transactionId;
            this.ContactId = contactId;
            this.Amount = amount;
            this.Id = id;
            this.CreatedTs = createdTs;
            if (createdUserId != null)
            {
                this.CreatedUserId = createdUserId;
            }

        }

        /// <summary>
        /// Transaction ID
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Contact ID
        /// </summary>
        [JsonProperty("contact_id")]
        public string ContactId { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Transaction Splits ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int CreatedTs { get; set; }

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

            return $"TransactionSplit : ({string.Join(", ", toStringOutput)})";
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
            return obj is TransactionSplit other &&                ((this.TransactionId == null && other.TransactionId == null) || (this.TransactionId?.Equals(other.TransactionId) == true)) &&
                ((this.ContactId == null && other.ContactId == null) || (this.ContactId?.Equals(other.ContactId) == true)) &&
                this.Amount.Equals(other.Amount) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TransactionId = {(this.TransactionId == null ? "null" : this.TransactionId)}");
            toStringOutput.Add($"this.ContactId = {(this.ContactId == null ? "null" : this.ContactId)}");
            toStringOutput.Add($"this.Amount = {this.Amount}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}