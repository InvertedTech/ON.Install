// <copyright file="Data8.cs" company="APIMatic">
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
    using FortisAPI.Standard.Models.Containers;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Data8.
    /// </summary>
    public class Data8 : BaseModel
    {
        private Models.ActionEnum? action;
        private string locationId;
        private string contactId;
        private Models.AchSecCodeEnum? achSecCode;
        private string message;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "action", true },
            { "location_id", false },
            { "contact_id", false },
            { "ach_sec_code", true },
            { "message", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Data8"/> class.
        /// </summary>
        public Data8()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data8"/> class.
        /// </summary>
        /// <param name="clientToken">client_token.</param>
        /// <param name="action">action.</param>
        /// <param name="digitalWalletsOnly">digitalWalletsOnly.</param>
        /// <param name="methods">methods.</param>
        /// <param name="amount">amount.</param>
        /// <param name="taxAmount">tax_amount.</param>
        /// <param name="secondaryAmount">secondary_amount.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="contactId">contact_id.</param>
        /// <param name="saveAccount">save_account.</param>
        /// <param name="saveAccountTitle">save_account_title.</param>
        /// <param name="title">title.</param>
        /// <param name="achSecCode">ach_sec_code.</param>
        /// <param name="bankFundedOnlyOverride">bank_funded_only_override.</param>
        /// <param name="allowPartialAuthorizationOverride">allow_partial_authorization_override.</param>
        /// <param name="autoDeclineCvvOverride">auto_decline_cvv_override.</param>
        /// <param name="autoDeclineStreetOverride">auto_decline_street_override.</param>
        /// <param name="autoDeclineZipOverride">auto_decline_zip_override.</param>
        /// <param name="message">message.</param>
        public Data8(
            string clientToken,
            Models.ActionEnum? action = Models.ActionEnum.Sale,
            bool? digitalWalletsOnly = false,
            List<Models.Method3> methods = null,
            Data8Amount amount = null,
            Data8TaxAmount taxAmount = null,
            Data8SecondaryAmount secondaryAmount = null,
            string locationId = null,
            string contactId = null,
            Data8SaveAccount saveAccount = null,
            Data8SaveAccountTitle saveAccountTitle = null,
            Data8Title title = null,
            Models.AchSecCodeEnum? achSecCode = Models.AchSecCodeEnum.WEB,
            Data8BankFundedOnlyOverride bankFundedOnlyOverride = null,
            Data8AllowPartialAuthorizationOverride allowPartialAuthorizationOverride = null,
            Data8AutoDeclineCvvOverride autoDeclineCvvOverride = null,
            Data8AutoDeclineStreetOverride autoDeclineStreetOverride = null,
            Data8AutoDeclineZipOverride autoDeclineZipOverride = null,
            string message = null)
        {
            this.Action = action;
            this.DigitalWalletsOnly = digitalWalletsOnly;
            this.Methods = methods;
            this.Amount = amount;
            this.TaxAmount = taxAmount;
            this.SecondaryAmount = secondaryAmount;
            if (locationId != null)
            {
                this.LocationId = locationId;
            }

            if (contactId != null)
            {
                this.ContactId = contactId;
            }

            this.SaveAccount = saveAccount;
            this.SaveAccountTitle = saveAccountTitle;
            this.Title = title;
            this.AchSecCode = achSecCode;
            this.BankFundedOnlyOverride = bankFundedOnlyOverride;
            this.AllowPartialAuthorizationOverride = allowPartialAuthorizationOverride;
            this.AutoDeclineCvvOverride = autoDeclineCvvOverride;
            this.AutoDeclineStreetOverride = autoDeclineStreetOverride;
            this.AutoDeclineZipOverride = autoDeclineZipOverride;
            if (message != null)
            {
                this.Message = message;
            }

            this.ClientToken = clientToken;
        }

        /// <summary>
        /// The action to be performed
        /// </summary>
        [JsonProperty("action")]
        public Models.ActionEnum? Action
        {
            get
            {
                return this.action;
            }

            set
            {
                this.shouldSerialize["action"] = true;
                this.action = value;
            }
        }

        /// <summary>
        /// Gets or sets DigitalWalletsOnly.
        /// </summary>
        [JsonProperty("digitalWalletsOnly", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DigitalWalletsOnly { get; set; }

        /// <summary>
        /// By default the system will try to offer all the availables payment methods from your account. But if you like, you can specify exactly what services you want to use.
        /// </summary>
        [JsonProperty("methods", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.Method3> Methods { get; set; }

        /// <summary>
        /// The total amount to be charged. Allowed on the actions: `sale`, `auth-only`, `refund`
        /// </summary>
        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public Data8Amount Amount { get; set; }

        /// <summary>
        /// Amount of Sales Tax. If supplied, this amount should be already included in the transaction amount. Allowed on the actions: `sale`, `auth-only`, `refund`
        /// </summary>
        [JsonProperty("tax_amount", NullValueHandling = NullValueHandling.Ignore)]
        public Data8TaxAmount TaxAmount { get; set; }

        /// <summary>
        /// Retained Amount. Allowed on the actions: `sale`, `auth-only`, `refund`
        /// </summary>
        [JsonProperty("secondary_amount", NullValueHandling = NullValueHandling.Ignore)]
        public Data8SecondaryAmount SecondaryAmount { get; set; }

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
        /// Contact ID
        /// </summary>
        [JsonProperty("contact_id")]
        public string ContactId
        {
            get
            {
                return this.contactId;
            }

            set
            {
                this.shouldSerialize["contact_id"] = true;
                this.contactId = value;
            }
        }

        /// <summary>
        /// Specifies to tokenize card/bank information within the transaction. Allowed on the actions: `sale`, `auth-only`, `avs-only`, `refund`
        /// </summary>
        [JsonProperty("save_account", NullValueHandling = NullValueHandling.Ignore)]
        public Data8SaveAccount SaveAccount { get; set; }

        /// <summary>
        /// Specifies to tokenize card/bank information within the transaction. Allowed on the actions: `sale`, `auth-only`, `avs-only`, `refund`
        /// </summary>
        [JsonProperty("save_account_title", NullValueHandling = NullValueHandling.Ignore)]
        public Data8SaveAccountTitle SaveAccountTitle { get; set; }

        /// <summary>
        /// A title for the token.
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public Data8Title Title { get; set; }

        /// <summary>
        /// SEC code for the transaction if it's an ACH transaction
        /// </summary>
        [JsonProperty("ach_sec_code")]
        public Models.AchSecCodeEnum? AchSecCode
        {
            get
            {
                return this.achSecCode;
            }

            set
            {
                this.shouldSerialize["ach_sec_code"] = true;
                this.achSecCode = value;
            }
        }

        /// <summary>
        /// Bank Funded Only Override
        /// </summary>
        [JsonProperty("bank_funded_only_override", NullValueHandling = NullValueHandling.Ignore)]
        public Data8BankFundedOnlyOverride BankFundedOnlyOverride { get; set; }

        /// <summary>
        /// Allow partial Authorization Override
        /// </summary>
        [JsonProperty("allow_partial_authorization_override", NullValueHandling = NullValueHandling.Ignore)]
        public Data8AllowPartialAuthorizationOverride AllowPartialAuthorizationOverride { get; set; }

        /// <summary>
        /// Auto Decline Cvv Override
        /// </summary>
        [JsonProperty("auto_decline_cvv_override", NullValueHandling = NullValueHandling.Ignore)]
        public Data8AutoDeclineCvvOverride AutoDeclineCvvOverride { get; set; }

        /// <summary>
        /// Auto Decline Street Override
        /// </summary>
        [JsonProperty("auto_decline_street_override", NullValueHandling = NullValueHandling.Ignore)]
        public Data8AutoDeclineStreetOverride AutoDeclineStreetOverride { get; set; }

        /// <summary>
        /// Auto Decline Zip Override
        /// </summary>
        [JsonProperty("auto_decline_zip_override", NullValueHandling = NullValueHandling.Ignore)]
        public Data8AutoDeclineZipOverride AutoDeclineZipOverride { get; set; }

        /// <summary>
        /// A custom text message that displays after the payment is processed.
        /// </summary>
        [JsonProperty("message")]
        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.shouldSerialize["message"] = true;
                this.message = value;
            }
        }

        /// <summary>
        /// A JWT to be used to create the elements.
        /// > This is a one-time only use token.
        /// > Do not store for long term use, it expires after 48 hours.
        /// </summary>
        [JsonProperty("client_token")]
        public string ClientToken { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data8 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAction()
        {
            this.shouldSerialize["action"] = false;
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
        public void UnsetContactId()
        {
            this.shouldSerialize["contact_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAchSecCode()
        {
            this.shouldSerialize["ach_sec_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMessage()
        {
            this.shouldSerialize["message"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAction()
        {
            return this.shouldSerialize["action"];
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
        public bool ShouldSerializeContactId()
        {
            return this.shouldSerialize["contact_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAchSecCode()
        {
            return this.shouldSerialize["ach_sec_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMessage()
        {
            return this.shouldSerialize["message"];
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
            return obj is Data8 other &&                ((this.Action == null && other.Action == null) || (this.Action?.Equals(other.Action) == true)) &&
                ((this.DigitalWalletsOnly == null && other.DigitalWalletsOnly == null) || (this.DigitalWalletsOnly?.Equals(other.DigitalWalletsOnly) == true)) &&
                ((this.Methods == null && other.Methods == null) || (this.Methods?.Equals(other.Methods) == true)) &&
                ((this.Amount == null && other.Amount == null) || (this.Amount?.Equals(other.Amount) == true)) &&
                ((this.TaxAmount == null && other.TaxAmount == null) || (this.TaxAmount?.Equals(other.TaxAmount) == true)) &&
                ((this.SecondaryAmount == null && other.SecondaryAmount == null) || (this.SecondaryAmount?.Equals(other.SecondaryAmount) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.ContactId == null && other.ContactId == null) || (this.ContactId?.Equals(other.ContactId) == true)) &&
                ((this.SaveAccount == null && other.SaveAccount == null) || (this.SaveAccount?.Equals(other.SaveAccount) == true)) &&
                ((this.SaveAccountTitle == null && other.SaveAccountTitle == null) || (this.SaveAccountTitle?.Equals(other.SaveAccountTitle) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.AchSecCode == null && other.AchSecCode == null) || (this.AchSecCode?.Equals(other.AchSecCode) == true)) &&
                ((this.BankFundedOnlyOverride == null && other.BankFundedOnlyOverride == null) || (this.BankFundedOnlyOverride?.Equals(other.BankFundedOnlyOverride) == true)) &&
                ((this.AllowPartialAuthorizationOverride == null && other.AllowPartialAuthorizationOverride == null) || (this.AllowPartialAuthorizationOverride?.Equals(other.AllowPartialAuthorizationOverride) == true)) &&
                ((this.AutoDeclineCvvOverride == null && other.AutoDeclineCvvOverride == null) || (this.AutoDeclineCvvOverride?.Equals(other.AutoDeclineCvvOverride) == true)) &&
                ((this.AutoDeclineStreetOverride == null && other.AutoDeclineStreetOverride == null) || (this.AutoDeclineStreetOverride?.Equals(other.AutoDeclineStreetOverride) == true)) &&
                ((this.AutoDeclineZipOverride == null && other.AutoDeclineZipOverride == null) || (this.AutoDeclineZipOverride?.Equals(other.AutoDeclineZipOverride) == true)) &&
                ((this.Message == null && other.Message == null) || (this.Message?.Equals(other.Message) == true)) &&
                ((this.ClientToken == null && other.ClientToken == null) || (this.ClientToken?.Equals(other.ClientToken) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Action = {(this.Action == null ? "null" : this.Action.ToString())}");
            toStringOutput.Add($"this.DigitalWalletsOnly = {(this.DigitalWalletsOnly == null ? "null" : this.DigitalWalletsOnly.ToString())}");
            toStringOutput.Add($"this.Methods = {(this.Methods == null ? "null" : $"[{string.Join(", ", this.Methods)} ]")}");
            toStringOutput.Add($"Amount = {(this.Amount == null ? "null" : this.Amount.ToString())}");
            toStringOutput.Add($"TaxAmount = {(this.TaxAmount == null ? "null" : this.TaxAmount.ToString())}");
            toStringOutput.Add($"SecondaryAmount = {(this.SecondaryAmount == null ? "null" : this.SecondaryAmount.ToString())}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.ContactId = {(this.ContactId == null ? "null" : this.ContactId)}");
            toStringOutput.Add($"SaveAccount = {(this.SaveAccount == null ? "null" : this.SaveAccount.ToString())}");
            toStringOutput.Add($"SaveAccountTitle = {(this.SaveAccountTitle == null ? "null" : this.SaveAccountTitle.ToString())}");
            toStringOutput.Add($"Title = {(this.Title == null ? "null" : this.Title.ToString())}");
            toStringOutput.Add($"this.AchSecCode = {(this.AchSecCode == null ? "null" : this.AchSecCode.ToString())}");
            toStringOutput.Add($"BankFundedOnlyOverride = {(this.BankFundedOnlyOverride == null ? "null" : this.BankFundedOnlyOverride.ToString())}");
            toStringOutput.Add($"AllowPartialAuthorizationOverride = {(this.AllowPartialAuthorizationOverride == null ? "null" : this.AllowPartialAuthorizationOverride.ToString())}");
            toStringOutput.Add($"AutoDeclineCvvOverride = {(this.AutoDeclineCvvOverride == null ? "null" : this.AutoDeclineCvvOverride.ToString())}");
            toStringOutput.Add($"AutoDeclineStreetOverride = {(this.AutoDeclineStreetOverride == null ? "null" : this.AutoDeclineStreetOverride.ToString())}");
            toStringOutput.Add($"AutoDeclineZipOverride = {(this.AutoDeclineZipOverride == null ? "null" : this.AutoDeclineZipOverride.ToString())}");
            toStringOutput.Add($"this.Message = {(this.Message == null ? "null" : this.Message)}");
            toStringOutput.Add($"this.ClientToken = {(this.ClientToken == null ? "null" : this.ClientToken)}");

            base.ToString(toStringOutput);
        }
    }
}