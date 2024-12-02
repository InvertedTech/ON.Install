// <copyright file="Method3.cs" company="APIMatic">
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
    /// Method3.
    /// </summary>
    public class Method3 : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Method3"/> class.
        /// </summary>
        public Method3()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Method3"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="productTransactionId">product_transaction_id.</param>
        public Method3(
            Models.TypeEnum type,
            string productTransactionId)
        {
            this.Type = type;
            this.ProductTransactionId = productTransactionId;
        }

        /// <summary>
        /// Payment type. Must be unique.
        /// </summary>
        [JsonProperty("type")]
        public Models.TypeEnum Type { get; set; }

        /// <summary>
        /// The Product's method (cc/ach) has to match the type.
        /// </summary>
        [JsonProperty("product_transaction_id")]
        public string ProductTransactionId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Method3 : ({string.Join(", ", toStringOutput)})";
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
            return obj is Method3 other &&                this.Type.Equals(other.Type) &&
                ((this.ProductTransactionId == null && other.ProductTransactionId == null) || (this.ProductTransactionId?.Equals(other.ProductTransactionId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {this.Type}");
            toStringOutput.Add($"this.ProductTransactionId = {(this.ProductTransactionId == null ? "null" : this.ProductTransactionId)}");

            base.ToString(toStringOutput);
        }
    }
}