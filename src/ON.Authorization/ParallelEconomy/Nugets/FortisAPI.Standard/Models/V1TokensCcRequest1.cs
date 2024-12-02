// <copyright file="V1TokensCcRequest1.cs" company="APIMatic">
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
    /// V1TokensCcRequest1.
    /// </summary>
    public class V1TokensCcRequest1 : BaseModel
    {
        private string accountHolderName;
        private string accountVaultApiId;
        private string tokenApiId;
        private string accountvaultC1;
        private string accountvaultC2;
        private string accountvaultC3;
        private string tokenC1;
        private string tokenC2;
        private string tokenC3;
        private Models.AchSecCode3Enum? achSecCode;
        private string contactId;
        private string customerId;
        private string locationId;
        private string previousAccountVaultApiId;
        private string previousTokenApiId;
        private string previousAccountVaultId;
        private string previousTokenId;
        private string previousTransactionId;
        private V1TokensCcRequest1AccountNumber accountNumber;
        private string termsAgreeIp;
        private string title;
        private string expDate;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "account_holder_name", false },
            { "account_vault_api_id", false },
            { "token_api_id", false },
            { "accountvault_c1", false },
            { "accountvault_c2", false },
            { "accountvault_c3", false },
            { "token_c1", false },
            { "token_c2", false },
            { "token_c3", false },
            { "ach_sec_code", false },
            { "contact_id", false },
            { "customer_id", false },
            { "location_id", false },
            { "previous_account_vault_api_id", false },
            { "previous_token_api_id", false },
            { "previous_account_vault_id", false },
            { "previous_token_id", false },
            { "previous_transaction_id", false },
            { "account_number", false },
            { "terms_agree_ip", false },
            { "title", false },
            { "exp_date", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="V1TokensCcRequest1"/> class.
        /// </summary>
        public V1TokensCcRequest1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1TokensCcRequest1"/> class.
        /// </summary>
        /// <param name="accountHolderName">account_holder_name.</param>
        /// <param name="accountVaultApiId">account_vault_api_id.</param>
        /// <param name="tokenApiId">token_api_id.</param>
        /// <param name="accountvaultC1">accountvault_c1.</param>
        /// <param name="accountvaultC2">accountvault_c2.</param>
        /// <param name="accountvaultC3">accountvault_c3.</param>
        /// <param name="tokenC1">token_c1.</param>
        /// <param name="tokenC2">token_c2.</param>
        /// <param name="tokenC3">token_c3.</param>
        /// <param name="achSecCode">ach_sec_code.</param>
        /// <param name="billingAddress">billing_address.</param>
        /// <param name="contactId">contact_id.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="identityVerification">identity_verification.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="previousAccountVaultApiId">previous_account_vault_api_id.</param>
        /// <param name="previousTokenApiId">previous_token_api_id.</param>
        /// <param name="previousAccountVaultId">previous_account_vault_id.</param>
        /// <param name="previousTokenId">previous_token_id.</param>
        /// <param name="previousTransactionId">previous_transaction_id.</param>
        /// <param name="accountNumber">account_number.</param>
        /// <param name="termsAgree">terms_agree.</param>
        /// <param name="termsAgreeIp">terms_agree_ip.</param>
        /// <param name="title">title.</param>
        /// <param name="joi">_joi.</param>
        /// <param name="expDate">exp_date.</param>
        public V1TokensCcRequest1(
            string accountHolderName = null,
            string accountVaultApiId = null,
            string tokenApiId = null,
            string accountvaultC1 = null,
            string accountvaultC2 = null,
            string accountvaultC3 = null,
            string tokenC1 = null,
            string tokenC2 = null,
            string tokenC3 = null,
            Models.AchSecCode3Enum? achSecCode = null,
            Models.BillingAddress billingAddress = null,
            string contactId = null,
            string customerId = null,
            Models.IdentityVerification2 identityVerification = null,
            string locationId = null,
            string previousAccountVaultApiId = null,
            string previousTokenApiId = null,
            string previousAccountVaultId = null,
            string previousTokenId = null,
            string previousTransactionId = null,
            V1TokensCcRequest1AccountNumber accountNumber = null,
            bool? termsAgree = null,
            string termsAgreeIp = null,
            string title = null,
            Models.Joi4 joi = null,
            string expDate = null)
        {
            if (accountHolderName != null)
            {
                this.AccountHolderName = accountHolderName;
            }

            if (accountVaultApiId != null)
            {
                this.AccountVaultApiId = accountVaultApiId;
            }

            if (tokenApiId != null)
            {
                this.TokenApiId = tokenApiId;
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

            if (tokenC1 != null)
            {
                this.TokenC1 = tokenC1;
            }

            if (tokenC2 != null)
            {
                this.TokenC2 = tokenC2;
            }

            if (tokenC3 != null)
            {
                this.TokenC3 = tokenC3;
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
            if (locationId != null)
            {
                this.LocationId = locationId;
            }

            if (previousAccountVaultApiId != null)
            {
                this.PreviousAccountVaultApiId = previousAccountVaultApiId;
            }

            if (previousTokenApiId != null)
            {
                this.PreviousTokenApiId = previousTokenApiId;
            }

            if (previousAccountVaultId != null)
            {
                this.PreviousAccountVaultId = previousAccountVaultId;
            }

            if (previousTokenId != null)
            {
                this.PreviousTokenId = previousTokenId;
            }

            if (previousTransactionId != null)
            {
                this.PreviousTransactionId = previousTransactionId;
            }

            if (accountNumber != null)
            {
                this.AccountNumber = accountNumber;
            }

            this.TermsAgree = termsAgree;
            if (termsAgreeIp != null)
            {
                this.TermsAgreeIp = termsAgreeIp;
            }

            if (title != null)
            {
                this.Title = title;
            }

            this.Joi = joi;
            if (expDate != null)
            {
                this.ExpDate = expDate;
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
        /// This field can be used to correlate Tokens in our system to data within an outside software integration
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
        /// This field can be used to correlate Tokens in our system to data within an outside software integration
        /// </summary>
        [JsonProperty("token_api_id")]
        public string TokenApiId
        {
            get
            {
                return this.tokenApiId;
            }

            set
            {
                this.shouldSerialize["token_api_id"] = true;
                this.tokenApiId = value;
            }
        }

        /// <summary>
        /// DEPRECATED (Use token_c1 instead)
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
        /// DEPRECATED (Use token_c2 instead)
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
        /// DEPRECATED (Use token_c3 instead)
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
        /// Custom field 1 for API users to store custom data
        /// </summary>
        [JsonProperty("token_c1")]
        public string TokenC1
        {
            get
            {
                return this.tokenC1;
            }

            set
            {
                this.shouldSerialize["token_c1"] = true;
                this.tokenC1 = value;
            }
        }

        /// <summary>
        /// Custom field 2 for API users to store custom data
        /// </summary>
        [JsonProperty("token_c2")]
        public string TokenC2
        {
            get
            {
                return this.tokenC2;
            }

            set
            {
                this.shouldSerialize["token_c2"] = true;
                this.tokenC2 = value;
            }
        }

        /// <summary>
        /// Custom field 3 for API users to store custom data
        /// </summary>
        [JsonProperty("token_c3")]
        public string TokenC3
        {
            get
            {
                return this.tokenC3;
            }

            set
            {
                this.shouldSerialize["token_c3"] = true;
                this.tokenC3 = value;
            }
        }

        /// <summary>
        /// SEC code for the account
        /// </summary>
        [JsonProperty("ach_sec_code")]
        public Models.AchSecCode3Enum? AchSecCode
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
        /// Billing Address Object
        /// </summary>
        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BillingAddress BillingAddress { get; set; }

        /// <summary>
        /// Used to associate the Token with a Contact.
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
        public Models.IdentityVerification2 IdentityVerification { get; set; }

        /// <summary>
        /// A valid Location Id associated with the Contact for this Token
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
        /// Can be used to pull payment info from a previous token api id.
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
        /// Can be used to pull payment info from a previous token api id.
        /// </summary>
        [JsonProperty("previous_token_api_id")]
        public string PreviousTokenApiId
        {
            get
            {
                return this.previousTokenApiId;
            }

            set
            {
                this.shouldSerialize["previous_token_api_id"] = true;
                this.previousTokenApiId = value;
            }
        }

        /// <summary>
        /// Can be used to pull payment info from a previous token.
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
        /// Can be used to pull payment info from a previous token.
        /// </summary>
        [JsonProperty("previous_token_id")]
        public string PreviousTokenId
        {
            get
            {
                return this.previousTokenId;
            }

            set
            {
                this.shouldSerialize["previous_token_id"] = true;
                this.previousTokenId = value;
            }
        }

        /// <summary>
        /// Can be used to pull payment info from a previous transaction.
        /// </summary>
        [JsonProperty("previous_transaction_id")]
        public string PreviousTransactionId
        {
            get
            {
                return this.previousTransactionId;
            }

            set
            {
                this.shouldSerialize["previous_transaction_id"] = true;
                this.previousTransactionId = value;
            }
        }

        /// <summary>
        /// Account number
        /// </summary>
        [JsonProperty("account_number")]
        public V1TokensCcRequest1AccountNumber AccountNumber
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

        /// <summary>
        /// Gets or sets Joi.
        /// </summary>
        [JsonProperty("_joi", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Joi4 Joi { get; set; }

        /// <summary>
        /// Required for CC. The Expiration Date for the credit card. (MMYY format).
        /// </summary>
        [JsonProperty("exp_date")]
        public string ExpDate
        {
            get
            {
                return this.expDate;
            }

            set
            {
                this.shouldSerialize["exp_date"] = true;
                this.expDate = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1TokensCcRequest1 : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetAccountVaultApiId()
        {
            this.shouldSerialize["account_vault_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTokenApiId()
        {
            this.shouldSerialize["token_api_id"] = false;
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
        public void UnsetTokenC1()
        {
            this.shouldSerialize["token_c1"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTokenC2()
        {
            this.shouldSerialize["token_c2"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTokenC3()
        {
            this.shouldSerialize["token_c3"] = false;
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
        public void UnsetLocationId()
        {
            this.shouldSerialize["location_id"] = false;
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
        public void UnsetPreviousTokenApiId()
        {
            this.shouldSerialize["previous_token_api_id"] = false;
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
        public void UnsetPreviousTokenId()
        {
            this.shouldSerialize["previous_token_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPreviousTransactionId()
        {
            this.shouldSerialize["previous_transaction_id"] = false;
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
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetExpDate()
        {
            this.shouldSerialize["exp_date"] = false;
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
        public bool ShouldSerializeAccountVaultApiId()
        {
            return this.shouldSerialize["account_vault_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTokenApiId()
        {
            return this.shouldSerialize["token_api_id"];
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
        public bool ShouldSerializeTokenC1()
        {
            return this.shouldSerialize["token_c1"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTokenC2()
        {
            return this.shouldSerialize["token_c2"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTokenC3()
        {
            return this.shouldSerialize["token_c3"];
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
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
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
        public bool ShouldSerializePreviousTokenApiId()
        {
            return this.shouldSerialize["previous_token_api_id"];
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
        public bool ShouldSerializePreviousTokenId()
        {
            return this.shouldSerialize["previous_token_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePreviousTransactionId()
        {
            return this.shouldSerialize["previous_transaction_id"];
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

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeExpDate()
        {
            return this.shouldSerialize["exp_date"];
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
            return obj is V1TokensCcRequest1 other &&                ((this.AccountHolderName == null && other.AccountHolderName == null) || (this.AccountHolderName?.Equals(other.AccountHolderName) == true)) &&
                ((this.AccountVaultApiId == null && other.AccountVaultApiId == null) || (this.AccountVaultApiId?.Equals(other.AccountVaultApiId) == true)) &&
                ((this.TokenApiId == null && other.TokenApiId == null) || (this.TokenApiId?.Equals(other.TokenApiId) == true)) &&
                ((this.AccountvaultC1 == null && other.AccountvaultC1 == null) || (this.AccountvaultC1?.Equals(other.AccountvaultC1) == true)) &&
                ((this.AccountvaultC2 == null && other.AccountvaultC2 == null) || (this.AccountvaultC2?.Equals(other.AccountvaultC2) == true)) &&
                ((this.AccountvaultC3 == null && other.AccountvaultC3 == null) || (this.AccountvaultC3?.Equals(other.AccountvaultC3) == true)) &&
                ((this.TokenC1 == null && other.TokenC1 == null) || (this.TokenC1?.Equals(other.TokenC1) == true)) &&
                ((this.TokenC2 == null && other.TokenC2 == null) || (this.TokenC2?.Equals(other.TokenC2) == true)) &&
                ((this.TokenC3 == null && other.TokenC3 == null) || (this.TokenC3?.Equals(other.TokenC3) == true)) &&
                ((this.AchSecCode == null && other.AchSecCode == null) || (this.AchSecCode?.Equals(other.AchSecCode) == true)) &&
                ((this.BillingAddress == null && other.BillingAddress == null) || (this.BillingAddress?.Equals(other.BillingAddress) == true)) &&
                ((this.ContactId == null && other.ContactId == null) || (this.ContactId?.Equals(other.ContactId) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.IdentityVerification == null && other.IdentityVerification == null) || (this.IdentityVerification?.Equals(other.IdentityVerification) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.PreviousAccountVaultApiId == null && other.PreviousAccountVaultApiId == null) || (this.PreviousAccountVaultApiId?.Equals(other.PreviousAccountVaultApiId) == true)) &&
                ((this.PreviousTokenApiId == null && other.PreviousTokenApiId == null) || (this.PreviousTokenApiId?.Equals(other.PreviousTokenApiId) == true)) &&
                ((this.PreviousAccountVaultId == null && other.PreviousAccountVaultId == null) || (this.PreviousAccountVaultId?.Equals(other.PreviousAccountVaultId) == true)) &&
                ((this.PreviousTokenId == null && other.PreviousTokenId == null) || (this.PreviousTokenId?.Equals(other.PreviousTokenId) == true)) &&
                ((this.PreviousTransactionId == null && other.PreviousTransactionId == null) || (this.PreviousTransactionId?.Equals(other.PreviousTransactionId) == true)) &&
                ((this.AccountNumber == null && other.AccountNumber == null) || (this.AccountNumber?.Equals(other.AccountNumber) == true)) &&
                ((this.TermsAgree == null && other.TermsAgree == null) || (this.TermsAgree?.Equals(other.TermsAgree) == true)) &&
                ((this.TermsAgreeIp == null && other.TermsAgreeIp == null) || (this.TermsAgreeIp?.Equals(other.TermsAgreeIp) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.Joi == null && other.Joi == null) || (this.Joi?.Equals(other.Joi) == true)) &&
                ((this.ExpDate == null && other.ExpDate == null) || (this.ExpDate?.Equals(other.ExpDate) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AccountHolderName = {(this.AccountHolderName == null ? "null" : this.AccountHolderName)}");
            toStringOutput.Add($"this.AccountVaultApiId = {(this.AccountVaultApiId == null ? "null" : this.AccountVaultApiId)}");
            toStringOutput.Add($"this.TokenApiId = {(this.TokenApiId == null ? "null" : this.TokenApiId)}");
            toStringOutput.Add($"this.AccountvaultC1 = {(this.AccountvaultC1 == null ? "null" : this.AccountvaultC1)}");
            toStringOutput.Add($"this.AccountvaultC2 = {(this.AccountvaultC2 == null ? "null" : this.AccountvaultC2)}");
            toStringOutput.Add($"this.AccountvaultC3 = {(this.AccountvaultC3 == null ? "null" : this.AccountvaultC3)}");
            toStringOutput.Add($"this.TokenC1 = {(this.TokenC1 == null ? "null" : this.TokenC1)}");
            toStringOutput.Add($"this.TokenC2 = {(this.TokenC2 == null ? "null" : this.TokenC2)}");
            toStringOutput.Add($"this.TokenC3 = {(this.TokenC3 == null ? "null" : this.TokenC3)}");
            toStringOutput.Add($"this.AchSecCode = {(this.AchSecCode == null ? "null" : this.AchSecCode.ToString())}");
            toStringOutput.Add($"this.BillingAddress = {(this.BillingAddress == null ? "null" : this.BillingAddress.ToString())}");
            toStringOutput.Add($"this.ContactId = {(this.ContactId == null ? "null" : this.ContactId)}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId)}");
            toStringOutput.Add($"this.IdentityVerification = {(this.IdentityVerification == null ? "null" : this.IdentityVerification.ToString())}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.PreviousAccountVaultApiId = {(this.PreviousAccountVaultApiId == null ? "null" : this.PreviousAccountVaultApiId)}");
            toStringOutput.Add($"this.PreviousTokenApiId = {(this.PreviousTokenApiId == null ? "null" : this.PreviousTokenApiId)}");
            toStringOutput.Add($"this.PreviousAccountVaultId = {(this.PreviousAccountVaultId == null ? "null" : this.PreviousAccountVaultId)}");
            toStringOutput.Add($"this.PreviousTokenId = {(this.PreviousTokenId == null ? "null" : this.PreviousTokenId)}");
            toStringOutput.Add($"this.PreviousTransactionId = {(this.PreviousTransactionId == null ? "null" : this.PreviousTransactionId)}");
            toStringOutput.Add($"AccountNumber = {(this.AccountNumber == null ? "null" : this.AccountNumber.ToString())}");
            toStringOutput.Add($"this.TermsAgree = {(this.TermsAgree == null ? "null" : this.TermsAgree.ToString())}");
            toStringOutput.Add($"this.TermsAgreeIp = {(this.TermsAgreeIp == null ? "null" : this.TermsAgreeIp)}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
            toStringOutput.Add($"this.Joi = {(this.Joi == null ? "null" : this.Joi.ToString())}");
            toStringOutput.Add($"this.ExpDate = {(this.ExpDate == null ? "null" : this.ExpDate)}");

            base.ToString(toStringOutput);
        }
    }
}