// <copyright file="Data32.cs" company="APIMatic">
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
    /// Data32.
    /// </summary>
    public class Data32 : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Data32"/> class.
        /// </summary>
        public Data32()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data32"/> class.
        /// </summary>
        /// <param name="resultCode">resultCode.</param>
        /// <param name="merchantID">merchantID.</param>
        /// <param name="applePay">applePay.</param>
        /// <param name="googlePay">googlePay.</param>
        /// <param name="applePayDomains">applePayDomains.</param>
        /// <param name="message">message.</param>
        /// <param name="googleJWT">googleJWT.</param>
        public Data32(
            bool? resultCode = null,
            string merchantID = null,
            bool? applePay = null,
            bool? googlePay = null,
            object applePayDomains = null,
            string message = null,
            string googleJWT = null)
        {
            this.ResultCode = resultCode;
            this.MerchantID = merchantID;
            this.ApplePay = applePay;
            this.GooglePay = googlePay;
            this.ApplePayDomains = applePayDomains;
            this.Message = message;
            this.GoogleJWT = googleJWT;
        }

        /// <summary>
        /// 0 for success, 1 for error. More details on Message field.
        /// </summary>
        [JsonProperty("resultCode", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ResultCode { get; set; }

        /// <summary>
        /// string needed to set up a Google or Apple Pay button.
        /// </summary>
        [JsonProperty("merchantID", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantID { get; set; }

        /// <summary>
        /// Boolean indicating if Apple Pay is enabled for this merchant.
        /// </summary>
        [JsonProperty("applePay", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ApplePay { get; set; }

        /// <summary>
        /// Boolean indicating if Google Pay is enabled for this merchant.
        /// </summary>
        [JsonProperty("googlePay", NullValueHandling = NullValueHandling.Ignore)]
        public bool? GooglePay { get; set; }

        /// <summary>
        /// Array of the domains registered with apple for this domain.  For Apple Pay, each domain name a merchant uses used has to be registered with Apple before it can be used.  When calling Merchant Details the gateway first checks if the domain provided is already registered for that merchant. If it is, it will return applePay: true and resultCode: 0 and the domain will be listed in appleDomains array.  It will also list all verified domains for that merchant.  If the domain is not verified it will try to verify it and if successful will return applePay: true and the domain will be listed in applePayDomains.  If the domain is not verified successfully the response will return applePay: false and resultCode: 1. Merchant will not be able to process payment in that domain.  Apple verifies the domain by pulling down a verification text file that should be placed on http://domainname.well-known/apple-developer-merchantid-domain-association.  File name must be apple-developer-merchantid-domain-association without a file extension. The contents of the file may be served programmatically. The contents of this file will be the same for all merchants processing Apple Pay.
        /// </summary>
        [JsonProperty("applePayDomains", NullValueHandling = NullValueHandling.Ignore)]
        public object ApplePayDomains { get; set; }

        /// <summary>
        /// Message with information about the results.
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <summary>
        /// String needed in the Google Pay request.
        /// </summary>
        [JsonProperty("googleJWT", NullValueHandling = NullValueHandling.Ignore)]
        public string GoogleJWT { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data32 : ({string.Join(", ", toStringOutput)})";
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
            return obj is Data32 other &&                ((this.ResultCode == null && other.ResultCode == null) || (this.ResultCode?.Equals(other.ResultCode) == true)) &&
                ((this.MerchantID == null && other.MerchantID == null) || (this.MerchantID?.Equals(other.MerchantID) == true)) &&
                ((this.ApplePay == null && other.ApplePay == null) || (this.ApplePay?.Equals(other.ApplePay) == true)) &&
                ((this.GooglePay == null && other.GooglePay == null) || (this.GooglePay?.Equals(other.GooglePay) == true)) &&
                ((this.ApplePayDomains == null && other.ApplePayDomains == null) || (this.ApplePayDomains?.Equals(other.ApplePayDomains) == true)) &&
                ((this.Message == null && other.Message == null) || (this.Message?.Equals(other.Message) == true)) &&
                ((this.GoogleJWT == null && other.GoogleJWT == null) || (this.GoogleJWT?.Equals(other.GoogleJWT) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ResultCode = {(this.ResultCode == null ? "null" : this.ResultCode.ToString())}");
            toStringOutput.Add($"this.MerchantID = {(this.MerchantID == null ? "null" : this.MerchantID)}");
            toStringOutput.Add($"this.ApplePay = {(this.ApplePay == null ? "null" : this.ApplePay.ToString())}");
            toStringOutput.Add($"this.GooglePay = {(this.GooglePay == null ? "null" : this.GooglePay.ToString())}");
            toStringOutput.Add($"ApplePayDomains = {(this.ApplePayDomains == null ? "null" : this.ApplePayDomains.ToString())}");
            toStringOutput.Add($"this.Message = {(this.Message == null ? "null" : this.Message)}");
            toStringOutput.Add($"this.GoogleJWT = {(this.GoogleJWT == null ? "null" : this.GoogleJWT)}");

            base.ToString(toStringOutput);
        }
    }
}