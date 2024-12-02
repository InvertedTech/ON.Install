// <copyright file="Addon.cs" company="APIMatic">
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
    /// Addon.
    /// </summary>
    public class Addon : BaseModel
    {
        private string locationSetupUrl;
        private string userSetupUrl;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "location_setup_url", false },
            { "user_setup_url", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Addon"/> class.
        /// </summary>
        public Addon()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Addon"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="secret">secret.</param>
        /// <param name="iframeUrl">iframe_url.</param>
        /// <param name="locationSetupUrl">location_setup_url.</param>
        /// <param name="userSetupUrl">user_setup_url.</param>
        /// <param name="encryptUrlParams">encrypt_url_params.</param>
        public Addon(
            string title,
            string secret,
            string iframeUrl,
            string locationSetupUrl = null,
            string userSetupUrl = null,
            bool? encryptUrlParams = null)
        {
            this.Title = title;
            this.Secret = secret;
            this.IframeUrl = iframeUrl;
            if (locationSetupUrl != null)
            {
                this.LocationSetupUrl = locationSetupUrl;
            }

            if (userSetupUrl != null)
            {
                this.UserSetupUrl = userSetupUrl;
            }

            this.EncryptUrlParams = encryptUrlParams;
        }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Secret
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// Iframe URL
        /// </summary>
        [JsonProperty("iframe_url")]
        public string IframeUrl { get; set; }

        /// <summary>
        /// Location Setup URL
        /// </summary>
        [JsonProperty("location_setup_url")]
        public string LocationSetupUrl
        {
            get
            {
                return this.locationSetupUrl;
            }

            set
            {
                this.shouldSerialize["location_setup_url"] = true;
                this.locationSetupUrl = value;
            }
        }

        /// <summary>
        /// User Setup URL
        /// </summary>
        [JsonProperty("user_setup_url")]
        public string UserSetupUrl
        {
            get
            {
                return this.userSetupUrl;
            }

            set
            {
                this.shouldSerialize["user_setup_url"] = true;
                this.userSetupUrl = value;
            }
        }

        /// <summary>
        /// Encrypt URL Params
        /// </summary>
        [JsonProperty("encrypt_url_params", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EncryptUrlParams { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Addon : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocationSetupUrl()
        {
            this.shouldSerialize["location_setup_url"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetUserSetupUrl()
        {
            this.shouldSerialize["user_setup_url"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationSetupUrl()
        {
            return this.shouldSerialize["location_setup_url"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUserSetupUrl()
        {
            return this.shouldSerialize["user_setup_url"];
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
            return obj is Addon other &&                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.Secret == null && other.Secret == null) || (this.Secret?.Equals(other.Secret) == true)) &&
                ((this.IframeUrl == null && other.IframeUrl == null) || (this.IframeUrl?.Equals(other.IframeUrl) == true)) &&
                ((this.LocationSetupUrl == null && other.LocationSetupUrl == null) || (this.LocationSetupUrl?.Equals(other.LocationSetupUrl) == true)) &&
                ((this.UserSetupUrl == null && other.UserSetupUrl == null) || (this.UserSetupUrl?.Equals(other.UserSetupUrl) == true)) &&
                ((this.EncryptUrlParams == null && other.EncryptUrlParams == null) || (this.EncryptUrlParams?.Equals(other.EncryptUrlParams) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
            toStringOutput.Add($"this.Secret = {(this.Secret == null ? "null" : this.Secret)}");
            toStringOutput.Add($"this.IframeUrl = {(this.IframeUrl == null ? "null" : this.IframeUrl)}");
            toStringOutput.Add($"this.LocationSetupUrl = {(this.LocationSetupUrl == null ? "null" : this.LocationSetupUrl)}");
            toStringOutput.Add($"this.UserSetupUrl = {(this.UserSetupUrl == null ? "null" : this.UserSetupUrl)}");
            toStringOutput.Add($"this.EncryptUrlParams = {(this.EncryptUrlParams == null ? "null" : this.EncryptUrlParams.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}