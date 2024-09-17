// <copyright file="V1QuickInvoicesTransactionRequest.cs" company="APIMatic">
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
    /// V1QuickInvoicesTransactionRequest.
    /// </summary>
    public class V1QuickInvoicesTransactionRequest : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1QuickInvoicesTransactionRequest"/> class.
        /// </summary>
        public V1QuickInvoicesTransactionRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1QuickInvoicesTransactionRequest"/> class.
        /// </summary>
        /// <param name="transactionId">transaction_id.</param>
        public V1QuickInvoicesTransactionRequest(
            string transactionId)
        {
            this.TransactionId = transactionId;
        }

        /// <summary>
        /// Transaction ID
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1QuickInvoicesTransactionRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is V1QuickInvoicesTransactionRequest other &&                ((this.TransactionId == null && other.TransactionId == null) || (this.TransactionId?.Equals(other.TransactionId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TransactionId = {(this.TransactionId == null ? "null" : this.TransactionId)}");

            base.ToString(toStringOutput);
        }
    }
}