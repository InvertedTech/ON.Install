// <copyright file="KycResponseObject.cs" company="APIMatic">
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
    /// KycResponseObject.
    /// </summary>
    public class KycResponseObject : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KycResponseObject"/> class.
        /// </summary>
        public KycResponseObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KycResponseObject"/> class.
        /// </summary>
        /// <param name="mValue">value.</param>
        /// <param name="type">type.</param>
        public KycResponseObject(
            string mValue,
            string type)
        {
            this.MValue = mValue;
            this.Type = type;
        }

        /// <summary>
        /// KYC object value.
        /// </summary>
        [JsonProperty("value")]
        public string MValue { get; set; }

        /// <summary>
        /// KYC oject type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"KycResponseObject : ({string.Join(", ", toStringOutput)})";
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
            return obj is KycResponseObject other &&                ((this.MValue == null && other.MValue == null) || (this.MValue?.Equals(other.MValue) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MValue = {(this.MValue == null ? "null" : this.MValue)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type)}");

            base.ToString(toStringOutput);
        }
    }
}