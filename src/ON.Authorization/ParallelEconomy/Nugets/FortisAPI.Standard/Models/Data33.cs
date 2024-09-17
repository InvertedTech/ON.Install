// <copyright file="Data33.cs" company="APIMatic">
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
    /// Data33.
    /// </summary>
    public class Data33 : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Data33"/> class.
        /// </summary>
        public Data33()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data33"/> class.
        /// </summary>
        /// <param name="merchantSession">merchantSession.</param>
        public Data33(
            string merchantSession = null)
        {
            this.MerchantSession = merchantSession;
        }

        /// <summary>
        /// String formatted merchantSession object.  Needs to be passed to the session.completeMerchantValidation event in JS.
        /// </summary>
        [JsonProperty("merchantSession", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantSession { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data33 : ({string.Join(", ", toStringOutput)})";
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
            return obj is Data33 other &&                ((this.MerchantSession == null && other.MerchantSession == null) || (this.MerchantSession?.Equals(other.MerchantSession) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MerchantSession = {(this.MerchantSession == null ? "null" : this.MerchantSession)}");

            base.ToString(toStringOutput);
        }
    }
}