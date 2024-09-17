// <copyright file="V1WalletProviderMerchantDetailsRequest.cs" company="APIMatic">
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
    /// V1WalletProviderMerchantDetailsRequest.
    /// </summary>
    public class V1WalletProviderMerchantDetailsRequest : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1WalletProviderMerchantDetailsRequest"/> class.
        /// </summary>
        public V1WalletProviderMerchantDetailsRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1WalletProviderMerchantDetailsRequest"/> class.
        /// </summary>
        /// <param name="merchantOrigin">merchantOrigin.</param>
        public V1WalletProviderMerchantDetailsRequest(
            string merchantOrigin)
        {
            this.MerchantOrigin = merchantOrigin;
        }

        /// <summary>
        /// Domain name where the Apple or Google pay button is or will be displayed. Full domain name including subdomain.
        /// </summary>
        [JsonProperty("merchantOrigin")]
        public string MerchantOrigin { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1WalletProviderMerchantDetailsRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is V1WalletProviderMerchantDetailsRequest other &&                ((this.MerchantOrigin == null && other.MerchantOrigin == null) || (this.MerchantOrigin?.Equals(other.MerchantOrigin) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MerchantOrigin = {(this.MerchantOrigin == null ? "null" : this.MerchantOrigin)}");

            base.ToString(toStringOutput);
        }
    }
}