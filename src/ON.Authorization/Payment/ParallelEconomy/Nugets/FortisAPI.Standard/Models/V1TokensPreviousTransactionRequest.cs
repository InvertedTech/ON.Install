// <copyright file="V1TokensPreviousTransactionRequest.cs" company="APIMatic">
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
    /// V1TokensPreviousTransactionRequest.
    /// </summary>
    public class V1TokensPreviousTransactionRequest
    {
        private string accountHolderName;
        private string accountNumber;
        private string accountVaultApiId;
        private string accountvaultC1;
        private string accountvaultC2;
        private string accountvaultC3;
        private Models.AchSecCodeEnum? achSecCode;
        private string contactId;
        private string customerId;
        private string previousAccountVaultApiId;
        private string previousAccountVaultId;
        private string termsAgreeIp;
        private string title;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "account_holder_name", false },
            { "account_number", false },
            { "account_vault_api_id", false },
            { "accountvault_c1", false },
            { "accountvault_c2", false },
            { "accountvault_c3", false },
            { "ach_sec_code", false },
            { "contact_id", false },
            { "customer_id", false },
            { "previous_account_vault_api_id", false },
            { "previous_account_vault_id", false },
            { "terms_agree_ip", false },
            { "title", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="V1TokensPreviousTransactionRequest"/> class.
        /// </summary>
        public V1TokensPreviousTransactionRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1TokensPreviousTransactionRequest"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="previousTransactionId">previous_transaction_id.</param>
        /// <param name="accountHolderName">account_holder_name.</param>
        /// <param name="accountNumber">account_number.</param>
        /// <param name="accountVaultApiId">account_vault_api_id.</param>
        /// <param name="accountvaultC1">accountvault_c1.</param>
        /// <param name="accountvaultC2">accountvault_c2.</param>
        /// <param name="accountvaultC3">accountvault_c3.</param>
        /// <param name="achSecCode">ach_sec_code.</param>
        /// <param name="billingAddress">billing_address.</param>
        /// <param name="contactId">contact_id.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="identityVerification">identity_verification.</param>
        /// <param name="previousAccountVaultApiId">previous_account_vault_api_id.</param>
        /// <param name="previousAccountVaultId">previous_account_vault_id.</param>
        /// <param name="termsAgree">terms_agree.</param>
        /// <param name="termsAgreeIp">terms_agree_ip.</param>
        /// <param name="title">title.</param>
        public V1TokensPreviousTransactionRequest(
            string locationId,
            string previousTransactionId,
            string accountHolderName = null,
            string accountNumber = null,
            string accountVaultApiId = null,
            string accountvaultC1 = null,
            string accountvaultC2 = null,
            string accountvaultC3 = null,
            Models.AchSecCodeEnum? achSecCode = null,
            Models.BillingAddress billingAddress = null,
            string contactId = null,
            string customerId = null,
            Models.IdentityVerification identityVerification = null,
            string previousAccountVaultApiId = null,
            string previousAccountVaultId = null,
            bool? termsAgree = null,
            string termsAgreeIp = null,
            string title = null)
        {
            if (accountHolderName != null)
            {
                this.AccountHolderName = accountHolderName;
            }

            if (accountNumber != null)
            {
                this.AccountNumber = accountNumber;
            }

            if (accountVaultApiId != null)
            {
                this.AccountVaultApiId = accountVaultApiId;
            }

            if (accountvaultC1 != null)
            {
                this.AccountvaultC1 = accountvaultC1;
            }

            if (accountvaultC2 != null)
            {
                this.AccountvaultC2 = accountvaultC2;
            }

            if (accountvaultC3 != null)
            {
                this.AccountvaultC3 = accountvaultC3;
            }

            if (achSecCode != null)
            {
                this.AchSecCode = achSecCode;
            }

            this.BillingAddress = billingAddress;
            if (contactId != null)
            {
                this.ContactId = contactId;
            }

            if (customerId != null)
            {
                this.CustomerId = customerId;
            }

            this.IdentityVerification = identityVerification;
            this.LocationId = locationId;
            if (previousAccountVaultApiId != null)
            {
                this.PreviousAccountVaultApiId = previousAccountVaultApiId;
            }

            if (previousAccountVaultId != null)
            {
                this.PreviousAccountVaultId = previousAccountVaultId;
            }

            this.PreviousTransactionId = previousTransactionId;
            this.TermsAgree = termsAgree;
            if (termsAgreeIp != null)
            {
                this.TermsAgreeIp = termsAgreeIp;
            }

            if (title != null)
            {
                this.Title = title;
            }

        }

        /// <summary>
        /// Account holder name
        /// </summary>
        [JsonProperty("account_holder_name")]
        public string AccountHolderName
        {
            get
            {
                return this.accountHolderName;
            }

            set
            {
                this.shouldSerialize["account_holder_name"] = true;
                this.accountHolderName = value;
            }
        }

        /// <summary>
        /// Account number
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber
        {
            get
            {
                return this.accountNumber;
            }

            set
            {
                this.shouldSerialize["account_number"] = true;
                this.accountNumber = value;
            }
        }

        /// <summary>
        /// This field can be used to correlate Account Vaults in our system to data within an outside software integration
        /// </summary>
        [JsonProperty("account_vault_api_id")]
        public string AccountVaultApiId
        {
            get
            {
                return this.accountVaultApiId;
            }

            set
            {
                this.shouldSerialize["account_vault_api_id"] = true;
                this.accountVaultApiId = value;
            }
        }

        /// <summary>
        /// Custom field 1 for API users to store custom data
        /// </summary>
        [JsonProperty("accountvault_c1")]
        public string AccountvaultC1
        {
            get
            {
                return this.accountvaultC1;
            }

            set
            {
                this.shouldSerialize["accountvault_c1"] = true;
                this.accountvaultC1 = value;
            }
        }

        /// <summary>
        /// Custom field 2 for API users to store custom data
        /// </summary>
        [JsonProperty("accountvault_c2")]
        public string AccountvaultC2
        {
            get
            {
                return this.accountvaultC2;
            }

            set
            {
                this.shouldSerialize["accountvault_c2"] = true;
                this.accountvaultC2 = value;
            }
        }

        /// <summary>
        /// Custom field 3 for API users to store custom data
        /// </summary>
        [JsonProperty("accountvault_c3")]
        public string AccountvaultC3
        {
            get
            {
                return this.accountvaultC3;
            }

            set
            {
                this.shouldSerialize["accountvault_c3"] = true;
                this.accountvaultC3 = value;
            }
        }

        /// <summary>
        /// SEC code for the account
        /// </summary>
        [JsonProperty("ach_sec_code", ItemConverterType = typeof(StringEnumConverter))]
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
        /// The Street portion of the address associated with the Credit Card (CC) or Bank Account (ACH).
        /// </summary>
        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BillingAddress BillingAddress { get; set; }

        /// <summary>
        /// Used to associate the Account Vault with a Contact.
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
        /// Used to store a customer identification number.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId
        {
            get
            {
                return this.customerId;
            }

            set
            {
                this.shouldSerialize["customer_id"] = true;
                this.customerId = value;
            }
        }

        /// <summary>
        /// Identity verification
        /// </summary>
        [JsonProperty("identity_verification", NullValueHandling = NullValueHandling.Ignore)]
        public Models.IdentityVerification IdentityVerification { get; set; }

        /// <summary>
        /// A valid Location Id associated with the Contact for this Token
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        /// <summary>
        /// Can be used to pull payment info from a previous account vault api id.
        /// </summary>
        [JsonProperty("previous_account_vault_api_id")]
        public string PreviousAccountVaultApiId
        {
            get
            {
                return this.previousAccountVaultApiId;
            }

            set
            {
                this.shouldSerialize["previous_account_vault_api_id"] = true;
                this.previousAccountVaultApiId = value;
            }
        }

        /// <summary>
        /// Can be used to pull payment info from a previous account vault.
        /// </summary>
        [JsonProperty("previous_account_vault_id")]
        public string PreviousAccountVaultId
        {
            get
            {
                return this.previousAccountVaultId;
            }

            set
            {
                this.shouldSerialize["previous_account_vault_id"] = true;
                this.previousAccountVaultId = value;
            }
        }

        /// <summary>
        /// Can be used to pull payment info from a previous transaction.
        /// </summary>
        [JsonProperty("previous_transaction_id")]
        public string PreviousTransactionId { get; set; }

        /// <summary>
        /// Terms agreement.
        /// </summary>
        [JsonProperty("terms_agree", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TermsAgree { get; set; }

        /// <summary>
        /// The ip address of the client that agreed to terms.
        /// </summary>
        [JsonProperty("terms_agree_ip")]
        public string TermsAgreeIp
        {
            get
            {
                return this.termsAgreeIp;
            }

            set
            {
                this.shouldSerialize["terms_agree_ip"] = true;
                this.termsAgreeIp = value;
            }
        }

        /// <summary>
        /// Used to describe the Token for easier identification within our UI.
        /// </summary>
        [JsonProperty("title")]
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.shouldSerialize["title"] = true;
                this.title = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1TokensPreviousTransactionRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAccountHolderName()
        {
            this.shouldSerialize["account_holder_name"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAccountNumber()
        {
            this.shouldSerialize["account_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAccountVaultApiId()
        {
            this.shouldSerialize["account_vault_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAccountvaultC1()
        {
            this.shouldSerialize["accountvault_c1"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAccountvaultC2()
        {
            this.shouldSerialize["accountvault_c2"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAccountvaultC3()
        {
            this.shouldSerialize["accountvault_c3"] = false;
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
        public void UnsetContactId()
        {
            this.shouldSerialize["contact_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCustomerId()
        {
            this.shouldSerialize["customer_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPreviousAccountVaultApiId()
        {
            this.shouldSerialize["previous_account_vault_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPreviousAccountVaultId()
        {
            this.shouldSerialize["previous_account_vault_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTermsAgreeIp()
        {
            this.shouldSerialize["terms_agree_ip"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTitle()
        {
            this.shouldSerialize["title"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountHolderName()
        {
            return this.shouldSerialize["account_holder_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountNumber()
        {
            return this.shouldSerialize["account_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountVaultApiId()
        {
            return this.shouldSerialize["account_vault_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountvaultC1()
        {
            return this.shouldSerialize["accountvault_c1"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountvaultC2()
        {
            return this.shouldSerialize["accountvault_c2"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountvaultC3()
        {
            return this.shouldSerialize["accountvault_c3"];
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
        public bool ShouldSerializeContactId()
        {
            return this.shouldSerialize["contact_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerId()
        {
            return this.shouldSerialize["customer_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePreviousAccountVaultApiId()
        {
            return this.shouldSerialize["previous_account_vault_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePreviousAccountVaultId()
        {
            return this.shouldSerialize["previous_account_vault_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTermsAgreeIp()
        {
            return this.shouldSerialize["terms_agree_ip"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTitle()
        {
            return this.shouldSerialize["title"];
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

            return obj is V1TokensPreviousTransactionRequest other &&
                ((this.AccountHolderName == null && other.AccountHolderName == null) || (this.AccountHolderName?.Equals(other.AccountHolderName) == true)) &&
                ((this.AccountNumber == null && other.AccountNumber == null) || (this.AccountNumber?.Equals(other.AccountNumber) == true)) &&
                ((this.AccountVaultApiId == null && other.AccountVaultApiId == null) || (this.AccountVaultApiId?.Equals(other.AccountVaultApiId) == true)) &&
                ((this.AccountvaultC1 == null && other.AccountvaultC1 == null) || (this.AccountvaultC1?.Equals(other.AccountvaultC1) == true)) &&
                ((this.AccountvaultC2 == null && other.AccountvaultC2 == null) || (this.AccountvaultC2?.Equals(other.AccountvaultC2) == true)) &&
                ((this.AccountvaultC3 == null && other.AccountvaultC3 == null) || (this.AccountvaultC3?.Equals(other.AccountvaultC3) == true)) &&
                ((this.AchSecCode == null && other.AchSecCode == null) || (this.AchSecCode?.Equals(other.AchSecCode) == true)) &&
                ((this.BillingAddress == null && other.BillingAddress == null) || (this.BillingAddress?.Equals(other.BillingAddress) == true)) &&
                ((this.ContactId == null && other.ContactId == null) || (this.ContactId?.Equals(other.ContactId) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.IdentityVerification == null && other.IdentityVerification == null) || (this.IdentityVerification?.Equals(other.IdentityVerification) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.PreviousAccountVaultApiId == null && other.PreviousAccountVaultApiId == null) || (this.PreviousAccountVaultApiId?.Equals(other.PreviousAccountVaultApiId) == true)) &&
                ((this.PreviousAccountVaultId == null && other.PreviousAccountVaultId == null) || (this.PreviousAccountVaultId?.Equals(other.PreviousAccountVaultId) == true)) &&
                ((this.PreviousTransactionId == null && other.PreviousTransactionId == null) || (this.PreviousTransactionId?.Equals(other.PreviousTransactionId) == true)) &&
                ((this.TermsAgree == null && other.TermsAgree == null) || (this.TermsAgree?.Equals(other.TermsAgree) == true)) &&
                ((this.TermsAgreeIp == null && other.TermsAgreeIp == null) || (this.TermsAgreeIp?.Equals(other.TermsAgreeIp) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AccountHolderName = {(this.AccountHolderName == null ? "null" : this.AccountHolderName == string.Empty ? "" : this.AccountHolderName)}");
            toStringOutput.Add($"this.AccountNumber = {(this.AccountNumber == null ? "null" : this.AccountNumber == string.Empty ? "" : this.AccountNumber)}");
            toStringOutput.Add($"this.AccountVaultApiId = {(this.AccountVaultApiId == null ? "null" : this.AccountVaultApiId == string.Empty ? "" : this.AccountVaultApiId)}");
            toStringOutput.Add($"this.AccountvaultC1 = {(this.AccountvaultC1 == null ? "null" : this.AccountvaultC1 == string.Empty ? "" : this.AccountvaultC1)}");
            toStringOutput.Add($"this.AccountvaultC2 = {(this.AccountvaultC2 == null ? "null" : this.AccountvaultC2 == string.Empty ? "" : this.AccountvaultC2)}");
            toStringOutput.Add($"this.AccountvaultC3 = {(this.AccountvaultC3 == null ? "null" : this.AccountvaultC3 == string.Empty ? "" : this.AccountvaultC3)}");
            toStringOutput.Add($"this.AchSecCode = {(this.AchSecCode == null ? "null" : this.AchSecCode.ToString())}");
            toStringOutput.Add($"this.BillingAddress = {(this.BillingAddress == null ? "null" : this.BillingAddress.ToString())}");
            toStringOutput.Add($"this.ContactId = {(this.ContactId == null ? "null" : this.ContactId == string.Empty ? "" : this.ContactId)}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId == string.Empty ? "" : this.CustomerId)}");
            toStringOutput.Add($"this.IdentityVerification = {(this.IdentityVerification == null ? "null" : this.IdentityVerification.ToString())}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.PreviousAccountVaultApiId = {(this.PreviousAccountVaultApiId == null ? "null" : this.PreviousAccountVaultApiId == string.Empty ? "" : this.PreviousAccountVaultApiId)}");
            toStringOutput.Add($"this.PreviousAccountVaultId = {(this.PreviousAccountVaultId == null ? "null" : this.PreviousAccountVaultId == string.Empty ? "" : this.PreviousAccountVaultId)}");
            toStringOutput.Add($"this.PreviousTransactionId = {(this.PreviousTransactionId == null ? "null" : this.PreviousTransactionId == string.Empty ? "" : this.PreviousTransactionId)}");
            toStringOutput.Add($"this.TermsAgree = {(this.TermsAgree == null ? "null" : this.TermsAgree.ToString())}");
            toStringOutput.Add($"this.TermsAgreeIp = {(this.TermsAgreeIp == null ? "null" : this.TermsAgreeIp == string.Empty ? "" : this.TermsAgreeIp)}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title == string.Empty ? "" : this.Title)}");
        }
    }
}