// <copyright file="Conditions161.cs" company="APIMatic">
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
    /// Conditions161.
    /// </summary>
    public class Conditions161 : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Conditions161"/> class.
        /// </summary>
        public Conditions161()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Conditions161"/> class.
        /// </summary>
        /// <param name="method">method.</param>
        /// <param name="values">values.</param>
        public Conditions161(
            Models.Method43Enum? method = null,
            Models.Values41Enum? values = null)
        {
            this.Method = method;
            this.Values = values;
        }

        /// <summary>
        /// Gets or sets Method.
        /// </summary>
        [JsonProperty("method", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Method43Enum? Method { get; set; }

        /// <summary>
        /// Gets or sets Values.
        /// </summary>
        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Values41Enum? Values { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Conditions161 : ({string.Join(", ", toStringOutput)})";
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
            return obj is Conditions161 other &&                ((this.Method == null && other.Method == null) || (this.Method?.Equals(other.Method) == true)) &&
                ((this.Values == null && other.Values == null) || (this.Values?.Equals(other.Values) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Method = {(this.Method == null ? "null" : this.Method.ToString())}");
            toStringOutput.Add($"this.Values = {(this.Values == null ? "null" : this.Values.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}