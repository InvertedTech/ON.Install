// <copyright file="Order19.cs" company="APIMatic">
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
    /// Order19.
    /// </summary>
    public class Order19 : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Order19"/> class.
        /// </summary>
        public Order19()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order19"/> class.
        /// </summary>
        /// <param name="key">key.</param>
        /// <param name="mOperator">operator.</param>
        public Order19(
            string key,
            Models.OperatorEnum mOperator)
        {
            this.Key = key;
            this.MOperator = mOperator;
        }

        /// <summary>
        /// Resource key to order by.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// The order. Ascending or descending.
        /// </summary>
        [JsonProperty("operator")]
        public Models.OperatorEnum MOperator { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Order19 : ({string.Join(", ", toStringOutput)})";
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
            return obj is Order19 other &&                ((this.Key == null && other.Key == null) || (this.Key?.Equals(other.Key) == true)) &&
                this.MOperator.Equals(other.MOperator);
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Key = {(this.Key == null ? "null" : this.Key)}");
            toStringOutput.Add($"this.MOperator = {this.MOperator}");

            base.ToString(toStringOutput);
        }
    }
}