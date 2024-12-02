// <copyright file="Response416dateRange.cs" company="APIMatic">
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
    /// Response416dateRange.
    /// </summary>
    public class Response416dateRange : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Response416dateRange"/> class.
        /// </summary>
        public Response416dateRange()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response416dateRange"/> class.
        /// </summary>
        /// <param name="statusCode">statusCode.</param>
        /// <param name="error">error.</param>
        /// <param name="message">message.</param>
        public Response416dateRange(
            int? statusCode = null,
            string error = null,
            string message = null)
        {
            this.StatusCode = statusCode;
            this.Error = error;
            this.Message = message;
        }

        /// <summary>
        /// Response code
        /// </summary>
        [JsonProperty("statusCode", NullValueHandling = NullValueHandling.Ignore)]
        public int? StatusCode { get; set; }

        /// <summary>
        /// Requested Range Not Satisfiable
        /// </summary>
        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }

        /// <summary>
        /// The "fieldDate" should be less or equal to "ISODate".
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Response416dateRange : ({string.Join(", ", toStringOutput)})";
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
            return obj is Response416dateRange other &&                ((this.StatusCode == null && other.StatusCode == null) || (this.StatusCode?.Equals(other.StatusCode) == true)) &&
                ((this.Error == null && other.Error == null) || (this.Error?.Equals(other.Error) == true)) &&
                ((this.Message == null && other.Message == null) || (this.Message?.Equals(other.Message) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.StatusCode = {(this.StatusCode == null ? "null" : this.StatusCode.ToString())}");
            toStringOutput.Add($"this.Error = {(this.Error == null ? "null" : this.Error)}");
            toStringOutput.Add($"this.Message = {(this.Message == null ? "null" : this.Message)}");

            base.ToString(toStringOutput);
        }
    }
}