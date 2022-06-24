// <copyright file="V1RecurringsSkipPaymentRequest.cs" company="APIMatic">
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
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// V1RecurringsSkipPaymentRequest.
    /// </summary>
    public class V1RecurringsSkipPaymentRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1RecurringsSkipPaymentRequest"/> class.
        /// </summary>
        public V1RecurringsSkipPaymentRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1RecurringsSkipPaymentRequest"/> class.
        /// </summary>
        /// <param name="skipCount">skip_count.</param>
        public V1RecurringsSkipPaymentRequest(
            int skipCount)
        {
            this.SkipCount = skipCount;
        }

        /// <summary>
        /// Skip Count
        /// </summary>
        [JsonProperty("skip_count")]
        public int SkipCount { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1RecurringsSkipPaymentRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1RecurringsSkipPaymentRequest other &&
                this.SkipCount.Equals(other.SkipCount);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SkipCount = {this.SkipCount}");
        }
    }
}