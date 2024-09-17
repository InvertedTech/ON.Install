// <copyright file="HostedPaymentPage.cs" company="APIMatic">
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
    /// HostedPaymentPage.
    /// </summary>
    public class HostedPaymentPage : BaseModel
    {
        private string userId;
        private string locationId;
        private string locationApiId;
        private double? redirectUrlDelay;
        private int? minPaymentAmount;
        private long? maxPaymentAmount;
        private string redirectUrlOnApprove;
        private string redirectUrlOnDecline;
        private string encryptionKey;
        private string stylesheetUrl;
        private string createdUserId;
        private string modifiedUserId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "user_id", false },
            { "location_id", false },
            { "location_api_id", false },
            { "redirect_url_delay", true },
            { "min_payment_amount", false },
            { "max_payment_amount", true },
            { "redirect_url_on_approve", false },
            { "redirect_url_on_decline", false },
            { "encryption_key", false },
            { "stylesheet_url", false },
            { "created_user_id", false },
            { "modified_user_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="HostedPaymentPage"/> class.
        /// </summary>
        public HostedPaymentPage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HostedPaymentPage"/> class.
        /// </summary>
        /// <param name="productTransactionId">product_transaction_id.</param>
        /// <param name="title">title.</param>
        /// <param name="fieldConfiguration">field_configuration.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="userId">user_id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="locationApiId">location_api_id.</param>
        /// <param name="redirectUrlDelay">redirect_url_delay.</param>
        /// <param name="minPaymentAmount">min_payment_amount.</param>
        /// <param name="maxPaymentAmount">max_payment_amount.</param>
        /// <param name="redirectUrlOnApprove">redirect_url_on_approve.</param>
        /// <param name="redirectUrlOnDecline">redirect_url_on_decline.</param>
        /// <param name="encryptionKey">encryption_key.</param>
        /// <param name="stylesheetUrl">stylesheet_url.</param>
        /// <param name="parentSendMessage">parent_send_message.</param>
        /// <param name="hideOptionalFields">hide_optional_fields.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="modifiedUserId">modified_user_id.</param>
        public HostedPaymentPage(
            string productTransactionId,
            string title,
            Models.FieldConfiguration fieldConfiguration,
            string id,
            int createdTs,
            int modifiedTs,
            string userId = null,
            string locationId = null,
            string locationApiId = null,
            double? redirectUrlDelay = 15,
            int? minPaymentAmount = null,
            long? maxPaymentAmount = 9999999999L,
            string redirectUrlOnApprove = null,
            string redirectUrlOnDecline = null,
            string encryptionKey = null,
            string stylesheetUrl = null,
            bool? parentSendMessage = null,
            bool? hideOptionalFields = null,
            string createdUserId = null,
            string modifiedUserId = null)
        {
            if (userId != null)
            {
                this.UserId = userId;
            }

            if (locationId != null)
            {
                this.LocationId = locationId;
            }

            if (locationApiId != null)
            {
                this.LocationApiId = locationApiId;
            }

            this.ProductTransactionId = productTransactionId;
            this.Title = title;
            this.RedirectUrlDelay = redirectUrlDelay;
            if (minPaymentAmount != null)
            {
                this.MinPaymentAmount = minPaymentAmount;
            }

            this.MaxPaymentAmount = maxPaymentAmount;
            if (redirectUrlOnApprove != null)
            {
                this.RedirectUrlOnApprove = redirectUrlOnApprove;
            }

            if (redirectUrlOnDecline != null)
            {
                this.RedirectUrlOnDecline = redirectUrlOnDecline;
            }

            this.FieldConfiguration = fieldConfiguration;
            if (encryptionKey != null)
            {
                this.EncryptionKey = encryptionKey;
            }

            if (stylesheetUrl != null)
            {
                this.StylesheetUrl = stylesheetUrl;
            }

            this.ParentSendMessage = parentSendMessage;
            this.HideOptionalFields = hideOptionalFields;
            this.Id = id;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            if (createdUserId != null)
            {
                this.CreatedUserId = createdUserId;
            }

            if (modifiedUserId != null)
            {
                this.ModifiedUserId = modifiedUserId;
            }

        }

        /// <summary>
        /// User ID
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId
        {
            get
            {
                return this.userId;
            }

            set
            {
                this.shouldSerialize["user_id"] = true;
                this.userId = value;
            }
        }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId
        {
            get
            {
                return this.locationId;
            }

            set
            {
                this.shouldSerialize["location_id"] = true;
                this.locationId = value;
            }
        }

        /// <summary>
        /// Location Api Id
        /// </summary>
        [JsonProperty("location_api_id")]
        public string LocationApiId
        {
            get
            {
                return this.locationApiId;
            }

            set
            {
                this.shouldSerialize["location_api_id"] = true;
                this.locationApiId = value;
            }
        }

        /// <summary>
        /// Product Transaction ID
        /// </summary>
        [JsonProperty("product_transaction_id")]
        public string ProductTransactionId { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Redirect Url Delay
        /// </summary>
        [JsonProperty("redirect_url_delay")]
        public double? RedirectUrlDelay
        {
            get
            {
                return this.redirectUrlDelay;
            }

            set
            {
                this.shouldSerialize["redirect_url_delay"] = true;
                this.redirectUrlDelay = value;
            }
        }

        /// <summary>
        /// Min Payment Amount
        /// </summary>
        [JsonProperty("min_payment_amount")]
        public int? MinPaymentAmount
        {
            get
            {
                return this.minPaymentAmount;
            }

            set
            {
                this.shouldSerialize["min_payment_amount"] = true;
                this.minPaymentAmount = value;
            }
        }

        /// <summary>
        /// Max Payment Amount
        /// </summary>
        [JsonProperty("max_payment_amount")]
        public long? MaxPaymentAmount
        {
            get
            {
                return this.maxPaymentAmount;
            }

            set
            {
                this.shouldSerialize["max_payment_amount"] = true;
                this.maxPaymentAmount = value;
            }
        }

        /// <summary>
        /// Redirect Url On Approval
        /// </summary>
        [JsonProperty("redirect_url_on_approve")]
        public string RedirectUrlOnApprove
        {
            get
            {
                return this.redirectUrlOnApprove;
            }

            set
            {
                this.shouldSerialize["redirect_url_on_approve"] = true;
                this.redirectUrlOnApprove = value;
            }
        }

        /// <summary>
        /// Redirect Url On Decline
        /// </summary>
        [JsonProperty("redirect_url_on_decline")]
        public string RedirectUrlOnDecline
        {
            get
            {
                return this.redirectUrlOnDecline;
            }

            set
            {
                this.shouldSerialize["redirect_url_on_decline"] = true;
                this.redirectUrlOnDecline = value;
            }
        }

        /// <summary>
        /// field_configuration
        /// </summary>
        [JsonProperty("field_configuration")]
        public Models.FieldConfiguration FieldConfiguration { get; set; }

        /// <summary>
        /// Encryption Key
        /// </summary>
        [JsonProperty("encryption_key")]
        public string EncryptionKey
        {
            get
            {
                return this.encryptionKey;
            }

            set
            {
                this.shouldSerialize["encryption_key"] = true;
                this.encryptionKey = value;
            }
        }

        /// <summary>
        /// Stylesheet Url
        /// </summary>
        [JsonProperty("stylesheet_url")]
        public string StylesheetUrl
        {
            get
            {
                return this.stylesheetUrl;
            }

            set
            {
                this.shouldSerialize["stylesheet_url"] = true;
                this.stylesheetUrl = value;
            }
        }

        /// <summary>
        /// Parent Send Message
        /// </summary>
        [JsonProperty("parent_send_message", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ParentSendMessage { get; set; }

        /// <summary>
        /// Hide Optional Fields
        /// </summary>
        [JsonProperty("hide_optional_fields", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HideOptionalFields { get; set; }

        /// <summary>
        /// Hosted Payment Page Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int CreatedTs { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts")]
        public int ModifiedTs { get; set; }

        /// <summary>
        /// System generated id for user who created record
        /// </summary>
        [JsonProperty("created_user_id")]
        public string CreatedUserId
        {
            get
            {
                return this.createdUserId;
            }

            set
            {
                this.shouldSerialize["created_user_id"] = true;
                this.createdUserId = value;
            }
        }

        /// <summary>
        /// System generated id for user who created record
        /// </summary>
        [JsonProperty("modified_user_id")]
        public string ModifiedUserId
        {
            get
            {
                return this.modifiedUserId;
            }

            set
            {
                this.shouldSerialize["modified_user_id"] = true;
                this.modifiedUserId = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"HostedPaymentPage : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetUserId()
        {
            this.shouldSerialize["user_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocationId()
        {
            this.shouldSerialize["location_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocationApiId()
        {
            this.shouldSerialize["location_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRedirectUrlDelay()
        {
            this.shouldSerialize["redirect_url_delay"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMinPaymentAmount()
        {
            this.shouldSerialize["min_payment_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMaxPaymentAmount()
        {
            this.shouldSerialize["max_payment_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRedirectUrlOnApprove()
        {
            this.shouldSerialize["redirect_url_on_approve"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRedirectUrlOnDecline()
        {
            this.shouldSerialize["redirect_url_on_decline"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEncryptionKey()
        {
            this.shouldSerialize["encryption_key"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetStylesheetUrl()
        {
            this.shouldSerialize["stylesheet_url"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCreatedUserId()
        {
            this.shouldSerialize["created_user_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetModifiedUserId()
        {
            this.shouldSerialize["modified_user_id"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUserId()
        {
            return this.shouldSerialize["user_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationApiId()
        {
            return this.shouldSerialize["location_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRedirectUrlDelay()
        {
            return this.shouldSerialize["redirect_url_delay"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMinPaymentAmount()
        {
            return this.shouldSerialize["min_payment_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMaxPaymentAmount()
        {
            return this.shouldSerialize["max_payment_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRedirectUrlOnApprove()
        {
            return this.shouldSerialize["redirect_url_on_approve"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRedirectUrlOnDecline()
        {
            return this.shouldSerialize["redirect_url_on_decline"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEncryptionKey()
        {
            return this.shouldSerialize["encryption_key"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStylesheetUrl()
        {
            return this.shouldSerialize["stylesheet_url"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCreatedUserId()
        {
            return this.shouldSerialize["created_user_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModifiedUserId()
        {
            return this.shouldSerialize["modified_user_id"];
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
            return obj is HostedPaymentPage other &&                ((this.UserId == null && other.UserId == null) || (this.UserId?.Equals(other.UserId) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.LocationApiId == null && other.LocationApiId == null) || (this.LocationApiId?.Equals(other.LocationApiId) == true)) &&
                ((this.ProductTransactionId == null && other.ProductTransactionId == null) || (this.ProductTransactionId?.Equals(other.ProductTransactionId) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.RedirectUrlDelay == null && other.RedirectUrlDelay == null) || (this.RedirectUrlDelay?.Equals(other.RedirectUrlDelay) == true)) &&
                ((this.MinPaymentAmount == null && other.MinPaymentAmount == null) || (this.MinPaymentAmount?.Equals(other.MinPaymentAmount) == true)) &&
                ((this.MaxPaymentAmount == null && other.MaxPaymentAmount == null) || (this.MaxPaymentAmount?.Equals(other.MaxPaymentAmount) == true)) &&
                ((this.RedirectUrlOnApprove == null && other.RedirectUrlOnApprove == null) || (this.RedirectUrlOnApprove?.Equals(other.RedirectUrlOnApprove) == true)) &&
                ((this.RedirectUrlOnDecline == null && other.RedirectUrlOnDecline == null) || (this.RedirectUrlOnDecline?.Equals(other.RedirectUrlOnDecline) == true)) &&
                ((this.FieldConfiguration == null && other.FieldConfiguration == null) || (this.FieldConfiguration?.Equals(other.FieldConfiguration) == true)) &&
                ((this.EncryptionKey == null && other.EncryptionKey == null) || (this.EncryptionKey?.Equals(other.EncryptionKey) == true)) &&
                ((this.StylesheetUrl == null && other.StylesheetUrl == null) || (this.StylesheetUrl?.Equals(other.StylesheetUrl) == true)) &&
                ((this.ParentSendMessage == null && other.ParentSendMessage == null) || (this.ParentSendMessage?.Equals(other.ParentSendMessage) == true)) &&
                ((this.HideOptionalFields == null && other.HideOptionalFields == null) || (this.HideOptionalFields?.Equals(other.HideOptionalFields) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true)) &&
                ((this.ModifiedUserId == null && other.ModifiedUserId == null) || (this.ModifiedUserId?.Equals(other.ModifiedUserId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.UserId = {(this.UserId == null ? "null" : this.UserId)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.LocationApiId = {(this.LocationApiId == null ? "null" : this.LocationApiId)}");
            toStringOutput.Add($"this.ProductTransactionId = {(this.ProductTransactionId == null ? "null" : this.ProductTransactionId)}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
            toStringOutput.Add($"this.RedirectUrlDelay = {(this.RedirectUrlDelay == null ? "null" : this.RedirectUrlDelay.ToString())}");
            toStringOutput.Add($"this.MinPaymentAmount = {(this.MinPaymentAmount == null ? "null" : this.MinPaymentAmount.ToString())}");
            toStringOutput.Add($"this.MaxPaymentAmount = {(this.MaxPaymentAmount == null ? "null" : this.MaxPaymentAmount.ToString())}");
            toStringOutput.Add($"this.RedirectUrlOnApprove = {(this.RedirectUrlOnApprove == null ? "null" : this.RedirectUrlOnApprove)}");
            toStringOutput.Add($"this.RedirectUrlOnDecline = {(this.RedirectUrlOnDecline == null ? "null" : this.RedirectUrlOnDecline)}");
            toStringOutput.Add($"this.FieldConfiguration = {(this.FieldConfiguration == null ? "null" : this.FieldConfiguration.ToString())}");
            toStringOutput.Add($"this.EncryptionKey = {(this.EncryptionKey == null ? "null" : this.EncryptionKey)}");
            toStringOutput.Add($"this.StylesheetUrl = {(this.StylesheetUrl == null ? "null" : this.StylesheetUrl)}");
            toStringOutput.Add($"this.ParentSendMessage = {(this.ParentSendMessage == null ? "null" : this.ParentSendMessage.ToString())}");
            toStringOutput.Add($"this.HideOptionalFields = {(this.HideOptionalFields == null ? "null" : this.HideOptionalFields.ToString())}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.ModifiedUserId = {(this.ModifiedUserId == null ? "null" : this.ModifiedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}