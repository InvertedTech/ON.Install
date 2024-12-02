// <copyright file="V1WalletProviderApplePayValidateMerchantRequest.cs" company="APIMatic">
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
    /// V1WalletProviderApplePayValidateMerchantRequest.
    /// </summary>
    public class V1WalletProviderApplePayValidateMerchantRequest : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1WalletProviderApplePayValidateMerchantRequest"/> class.
        /// </summary>
        public V1WalletProviderApplePayValidateMerchantRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1WalletProviderApplePayValidateMerchantRequest"/> class.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="merchantId">merchantId.</param>
        /// <param name="domainName">domainName.</param>
        /// <param name="displayName">displayName.</param>
        public V1WalletProviderApplePayValidateMerchantRequest(
            string url,
            string merchantId,
            string domainName,
            string displayName)
        {
            this.Url = url;
            this.MerchantId = merchantId;
            this.DomainName = domainName;
            this.DisplayName = displayName;
        }

        /// <summary>
        /// Url obtained in the ApplePay button click event. Apple's URL that needs to be called to validate merchant.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Merchant ID
        /// </summary>
        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

        /// <summary>
        /// Domain Name
        /// </summary>
        [JsonProperty("domainName")]
        public string DomainName { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1WalletProviderApplePayValidateMerchantRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is V1WalletProviderApplePayValidateMerchantRequest other &&                ((this.Url == null && other.Url == null) || (this.Url?.Equals(other.Url) == true)) &&
                ((this.MerchantId == null && other.MerchantId == null) || (this.MerchantId?.Equals(other.MerchantId) == true)) &&
                ((this.DomainName == null && other.DomainName == null) || (this.DomainName?.Equals(other.DomainName) == true)) &&
                ((this.DisplayName == null && other.DisplayName == null) || (this.DisplayName?.Equals(other.DisplayName) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Url = {(this.Url == null ? "null" : this.Url)}");
            toStringOutput.Add($"this.MerchantId = {(this.MerchantId == null ? "null" : this.MerchantId)}");
            toStringOutput.Add($"this.DomainName = {(this.DomainName == null ? "null" : this.DomainName)}");
            toStringOutput.Add($"this.DisplayName = {(this.DisplayName == null ? "null" : this.DisplayName)}");

            base.ToString(toStringOutput);
        }
    }
}