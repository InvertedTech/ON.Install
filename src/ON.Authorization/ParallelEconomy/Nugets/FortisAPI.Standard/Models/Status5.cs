// <copyright file="Status5.cs" company="APIMatic">
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
    /// Status5.
    /// </summary>
    public class Status5 : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Status5"/> class.
        /// </summary>
        public Status5()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Status5"/> class.
        /// </summary>
        /// <param name="responseCode">response_code.</param>
        /// <param name="reasonCode">reason_code.</param>
        /// <param name="reasonText">reason_text.</param>
        public Status5(
            string responseCode = null,
            string reasonCode = null,
            string reasonText = null)
        {
            this.ResponseCode = responseCode;
            this.ReasonCode = reasonCode;
            this.ReasonText = reasonText;
        }

        /// <summary>
        /// Response code for API response.
        /// </summary>
        [JsonProperty("response_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ResponseCode { get; set; }

        /// <summary>
        /// Reason code for API response.
        /// </summary>
        [JsonProperty("reason_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ReasonCode { get; set; }

        /// <summary>
        /// Reason text returned for any errors from API call.
        /// </summary>
        [JsonProperty("reason_text", NullValueHandling = NullValueHandling.Ignore)]
        public string ReasonText { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Status5 : ({string.Join(", ", toStringOutput)})";
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
            return obj is Status5 other &&                ((this.ResponseCode == null && other.ResponseCode == null) || (this.ResponseCode?.Equals(other.ResponseCode) == true)) &&
                ((this.ReasonCode == null && other.ReasonCode == null) || (this.ReasonCode?.Equals(other.ReasonCode) == true)) &&
                ((this.ReasonText == null && other.ReasonText == null) || (this.ReasonText?.Equals(other.ReasonText) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ResponseCode = {(this.ResponseCode == null ? "null" : this.ResponseCode)}");
            toStringOutput.Add($"this.ReasonCode = {(this.ReasonCode == null ? "null" : this.ReasonCode)}");
            toStringOutput.Add($"this.ReasonText = {(this.ReasonText == null ? "null" : this.ReasonText)}");

            base.ToString(toStringOutput);
        }
    }
}