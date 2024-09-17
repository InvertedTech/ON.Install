// <copyright file="TagTransaction.cs" company="APIMatic">
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
    /// TagTransaction.
    /// </summary>
    public class TagTransaction : BaseModel
    {
        private string paymentMethod;
        private string created;
        private string modified;
        private int? createdTs;
        private int? modifiedTs;
        private string createdUserId;
        private string modifiedUserId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "payment_method", false },
            { "created", false },
            { "modified", false },
            { "created_ts", false },
            { "modified_ts", false },
            { "created_user_id", false },
            { "modified_user_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="TagTransaction"/> class.
        /// </summary>
        public TagTransaction()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TagTransaction"/> class.
        /// </summary>
        /// <param name="tagId">tag_id.</param>
        /// <param name="transactionId">transaction_id.</param>
        /// <param name="id">id.</param>
        /// <param name="paymentMethod">payment_method.</param>
        /// <param name="created">created.</param>
        /// <param name="modified">modified.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="modifiedUserId">modified_user_id.</param>
        public TagTransaction(
            string tagId,
            string transactionId,
            string id = null,
            string paymentMethod = null,
            string created = null,
            string modified = null,
            int? createdTs = null,
            int? modifiedTs = null,
            string createdUserId = null,
            string modifiedUserId = null)
        {
            this.Id = id;
            this.TagId = tagId;
            this.TransactionId = transactionId;
            if (paymentMethod != null)
            {
                this.PaymentMethod = paymentMethod;
            }

            if (created != null)
            {
                this.Created = created;
            }

            if (modified != null)
            {
                this.Modified = modified;
            }

            if (createdTs != null)
            {
                this.CreatedTs = createdTs;
            }

            if (modifiedTs != null)
            {
                this.ModifiedTs = modifiedTs;
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
        /// Tag
        /// </summary>
        [JsonProperty("tag_id")]
        public string TagId { get; set; }

        /// <summary>
        /// Transaction ID
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Payment Method
        /// </summary>
        [JsonProperty("payment_method")]
        public string PaymentMethod
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
        /// Created
        /// </summary>
        [JsonProperty("created")]
        public string Created
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
        public string Modified
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
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts")]
        public int? ModifiedTs
        {
            get
            {
                return this.modifiedTs;
            }

            set
            {
                this.shouldSerialize["modified_ts"] = true;
                this.modifiedTs = value;
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

            return $"TagTransaction : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetCreatedTs()
        {
            this.shouldSerialize["created_ts"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetModifiedTs()
        {
            this.shouldSerialize["modified_ts"] = false;
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
        public bool ShouldSerializePaymentMethod()
        {
            return this.shouldSerialize["payment_method"];
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
        public bool ShouldSerializeCreatedTs()
        {
            return this.shouldSerialize["created_ts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModifiedTs()
        {
            return this.shouldSerialize["modified_ts"];
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
            return obj is TagTransaction other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.TagId == null && other.TagId == null) || (this.TagId?.Equals(other.TagId) == true)) &&
                ((this.TransactionId == null && other.TransactionId == null) || (this.TransactionId?.Equals(other.TransactionId) == true)) &&
                ((this.PaymentMethod == null && other.PaymentMethod == null) || (this.PaymentMethod?.Equals(other.PaymentMethod) == true)) &&
                ((this.Created == null && other.Created == null) || (this.Created?.Equals(other.Created) == true)) &&
                ((this.Modified == null && other.Modified == null) || (this.Modified?.Equals(other.Modified) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.ModifiedTs == null && other.ModifiedTs == null) || (this.ModifiedTs?.Equals(other.ModifiedTs) == true)) &&
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
            toStringOutput.Add($"this.TagId = {(this.TagId == null ? "null" : this.TagId)}");
            toStringOutput.Add($"this.TransactionId = {(this.TransactionId == null ? "null" : this.TransactionId)}");
            toStringOutput.Add($"this.PaymentMethod = {(this.PaymentMethod == null ? "null" : this.PaymentMethod)}");
            toStringOutput.Add($"this.Created = {(this.Created == null ? "null" : this.Created)}");
            toStringOutput.Add($"this.Modified = {(this.Modified == null ? "null" : this.Modified)}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.ModifiedTs = {(this.ModifiedTs == null ? "null" : this.ModifiedTs.ToString())}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.ModifiedUserId = {(this.ModifiedUserId == null ? "null" : this.ModifiedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}