// <copyright file="V1RecurringsDeferPaymentRequest.cs" company="APIMatic">
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
    /// V1RecurringsDeferPaymentRequest.
    /// </summary>
    public class V1RecurringsDeferPaymentRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1RecurringsDeferPaymentRequest"/> class.
        /// </summary>
        public V1RecurringsDeferPaymentRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1RecurringsDeferPaymentRequest"/> class.
        /// </summary>
        /// <param name="deferCount">defer_count.</param>
        public V1RecurringsDeferPaymentRequest(
            int deferCount)
        {
            this.DeferCount = deferCount;
        }

        /// <summary>
        /// Defer Count
        /// </summary>
        [JsonProperty("defer_count")]
        public int DeferCount { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1RecurringsDeferPaymentRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1RecurringsDeferPaymentRequest other &&
                this.DeferCount.Equals(other.DeferCount);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DeferCount = {this.DeferCount}");
        }
    }
}