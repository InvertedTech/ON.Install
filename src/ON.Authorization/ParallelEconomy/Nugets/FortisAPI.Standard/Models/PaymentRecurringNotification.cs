// <copyright file="PaymentRecurringNotification.cs" company="APIMatic">
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
    /// PaymentRecurringNotification.
    /// </summary>
    public class PaymentRecurringNotification : BaseModel
    {
        private string declinedTransactionId;
        private string paymentTransactionId;
        private int? createdTs;
        private string createdUserId;
        private int? modifiedTs;
        private string modifiedUserId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "declined_transaction_id", false },
            { "payment_transaction_id", false },
            { "created_ts", false },
            { "created_user_id", false },
            { "modified_ts", false },
            { "modified_user_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRecurringNotification"/> class.
        /// </summary>
        public PaymentRecurringNotification()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRecurringNotification"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="declinedTransactionId">declined_transaction_id.</param>
        /// <param name="paymentTransactionId">payment_transaction_id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="modifiedUserId">modified_user_id.</param>
        public PaymentRecurringNotification(
            string id = null,
            string declinedTransactionId = null,
            string paymentTransactionId = null,
            int? createdTs = null,
            string createdUserId = null,
            int? modifiedTs = null,
            string modifiedUserId = null)
        {
            this.Id = id;
            if (declinedTransactionId != null)
            {
                this.DeclinedTransactionId = declinedTransactionId;
            }

            if (paymentTransactionId != null)
            {
                this.PaymentTransactionId = paymentTransactionId;
            }

            if (createdTs != null)
            {
                this.CreatedTs = createdTs;
            }

            if (createdUserId != null)
            {
                this.CreatedUserId = createdUserId;
            }

            if (modifiedTs != null)
            {
                this.ModifiedTs = modifiedTs;
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
        /// Declined Transaction ID
        /// </summary>
        [JsonProperty("declined_transaction_id")]
        public string DeclinedTransactionId
        {
            get
            {
                return this.declinedTransactionId;
            }

            set
            {
                this.shouldSerialize["declined_transaction_id"] = true;
                this.declinedTransactionId = value;
            }
        }

        /// <summary>
        /// Payment Transaction ID
        /// </summary>
        [JsonProperty("payment_transaction_id")]
        public string PaymentTransactionId
        {
            get
            {
                return this.paymentTransactionId;
            }

            set
            {
                this.shouldSerialize["payment_transaction_id"] = true;
                this.paymentTransactionId = value;
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

            return $"PaymentRecurringNotification : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDeclinedTransactionId()
        {
            this.shouldSerialize["declined_transaction_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPaymentTransactionId()
        {
            this.shouldSerialize["payment_transaction_id"] = false;
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
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetModifiedTs()
        {
            this.shouldSerialize["modified_ts"] = false;
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
        public bool ShouldSerializeDeclinedTransactionId()
        {
            return this.shouldSerialize["declined_transaction_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentTransactionId()
        {
            return this.shouldSerialize["payment_transaction_id"];
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
            return obj is PaymentRecurringNotification other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.DeclinedTransactionId == null && other.DeclinedTransactionId == null) || (this.DeclinedTransactionId?.Equals(other.DeclinedTransactionId) == true)) &&
                ((this.PaymentTransactionId == null && other.PaymentTransactionId == null) || (this.PaymentTransactionId?.Equals(other.PaymentTransactionId) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true)) &&
                ((this.ModifiedTs == null && other.ModifiedTs == null) || (this.ModifiedTs?.Equals(other.ModifiedTs) == true)) &&
                ((this.ModifiedUserId == null && other.ModifiedUserId == null) || (this.ModifiedUserId?.Equals(other.ModifiedUserId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.DeclinedTransactionId = {(this.DeclinedTransactionId == null ? "null" : this.DeclinedTransactionId)}");
            toStringOutput.Add($"this.PaymentTransactionId = {(this.PaymentTransactionId == null ? "null" : this.PaymentTransactionId)}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.ModifiedTs = {(this.ModifiedTs == null ? "null" : this.ModifiedTs.ToString())}");
            toStringOutput.Add($"this.ModifiedUserId = {(this.ModifiedUserId == null ? "null" : this.ModifiedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}