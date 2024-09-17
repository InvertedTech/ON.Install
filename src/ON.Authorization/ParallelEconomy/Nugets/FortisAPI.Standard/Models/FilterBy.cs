// <copyright file="FilterBy.cs" company="APIMatic">
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
    using FortisAPI.Standard.Models.Containers;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// FilterBy.
    /// </summary>
    public class FilterBy : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterBy"/> class.
        /// </summary>
        public FilterBy()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterBy"/> class.
        /// </summary>
        /// <param name="key">key.</param>
        /// <param name="mOperator">operator.</param>
        /// <param name="mValue">value.</param>
        public FilterBy(
            string key,
            FilterByOperator mOperator,
            FilterByValue mValue)
        {
            this.Key = key;
            this.MOperator = mOperator;
            this.MValue = mValue;
        }

        /// <summary>
        /// Resource key to filter by
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// <![CDATA[
        /// Filter operand.  Please note `=` does not imply a strict equality check.
        /// Only time fields support the `<=` and `>=` operators.
        /// ]]>
        /// </summary>
        [JsonProperty("operator")]
        public FilterByOperator MOperator { get; set; }

        /// <summary>
        /// Filter value.
        /// For time fields, `value` must be sent in Unix format: `946702799`
        /// </summary>
        [JsonProperty("value")]
        public FilterByValue MValue { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FilterBy : ({string.Join(", ", toStringOutput)})";
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
            return obj is FilterBy other &&                ((this.Key == null && other.Key == null) || (this.Key?.Equals(other.Key) == true)) &&
                ((this.MOperator == null && other.MOperator == null) || (this.MOperator?.Equals(other.MOperator) == true)) &&
                ((this.MValue == null && other.MValue == null) || (this.MValue?.Equals(other.MValue) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Key = {(this.Key == null ? "null" : this.Key)}");
            toStringOutput.Add($"MOperator = {(this.MOperator == null ? "null" : this.MOperator.ToString())}");
            toStringOutput.Add($"MValue = {(this.MValue == null ? "null" : this.MValue.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}