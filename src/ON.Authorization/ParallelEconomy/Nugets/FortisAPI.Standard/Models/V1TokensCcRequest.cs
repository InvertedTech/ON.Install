// <copyright file="V1TokensCcRequest.cs" company="APIMatic">
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
    /// V1TokensCcRequest.
    /// </summary>
    public class V1TokensCcRequest
    {
        private string accountHolderName;
        private string accountVaultApiId;
        private string accountvaultC1;
        private string accountvaultC2;
        private string accountvaultC3;
        private Models.AchSecCodeEnum? achSecCode;
        private string contactId;
        private string customerId;
        private string previousAccountVaultApiId;
        private string previousAccountVaultId;
        private string previousTransactionId;
        private string termsAgreeIp;
        private string title;
        private string eSerialNumber;
        private string eTrackData;
        private string eFormat;
        private string eKeyedData;
        private string trackData;
        private string ticket;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "account_holder_name", false },
            { "account_vault_api_id", false },
            { "accountvault_c1", false },
            { "accountvault_c2", false },
            { "accountvault_c3", false },
            { "ach_sec_code", false },
            { "contact_id", false },
            { "customer_id", false },
            { "previous_account_vault_api_id", false },
            { "previous_account_vault_id", false },
            { "previous_transaction_id", false },
            { "terms_agree_ip", false },
            { "title", false },
            { "e_serial_number", false },
            { "e_track_data", false },
            { "e_format", false },
            { "e_keyed_data", false },
            { "track_data", false },
            { "ticket", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="V1TokensCcRequest"/> class.
        /// </summary>
        public V1TokensCcRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1TokensCcRequest"/> class.
        /// </summary>
        /// <param name="accountNumber">account_number.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="expDate">exp_date.</param>
        /// <param name="accountHolderName">account_holder_name.</param>
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
        /// <param name="previousTransactionId">previous_transaction_id.</param>
        /// <param name="termsAgree">terms_agree.</param>
        /// <param name="termsAgreeIp">terms_agree_ip.</param>
        /// <param name="title">title.</param>
        /// <param name="eSerialNumber">e_serial_number.</param>
        /// <param name="eTrackData">e_track_data.</param>
        /// <param name="eFormat">e_format.</param>
        /// <param name="eKeyedData">e_keyed_data.</param>
        /// <param name="runAvs">run_avs.</param>
        /// <param name="trackData">track_data.</param>
        /// <param name="ticket">ticket.</param>
        public V1TokensCcRequest(
            string accountNumber,
            string locationId,
            string expDate,
            string accountHolderName = null,
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
            string previousTransactionId = null,
            bool? termsAgree = null,
            string termsAgreeIp = null,
            string title = null,
            string eSerialNumber = null,
            string eTrackData = null,
            string eFormat = null,
            string eKeyedData = null,
            bool? runAvs = null,
            string trackData = null,
            string ticket = null)
        {
            if (accountHolderName != null)
            {
                this.AccountHolderName = accountHolderName;
            }

            this.AccountNumber = accountNumber;
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

            if (previousTransactionId != null)
            {
                this.PreviousTransactionId = previousTransactionId;
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

            this.ExpDate = expDate;
            if (eSerialNumber != null)
            {
                this.ESerialNumber = eSerialNumber;
            }

            if (eTrackData != null)
            {
                this.ETrackData = eTrackData;
            }

            if (eFormat != null)
            {
                this.EFormat = eFormat;
            }

            if (eKeyedData != null)
            {
                this.EKeyedData = eKeyedData;
            }

            this.RunAvs = runAvs;
            if (trackData != null)
            {
                this.TrackData = trackData;
            }

            if (ticket != null)
            {
                this.Ticket = ticket;
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
        public string AccountNumber { get; set; }

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
        /// Required for CC. The Expiration Date for the credit card. (MMYY format).
        /// </summary>
        [JsonProperty("exp_date")]
        public string ExpDate { get; set; }

        /// <summary>
        /// E Serial Number
        /// </summary>
        [JsonProperty("e_serial_number")]
        public string ESerialNumber
        {
            get
            {
                return this.eSerialNumber;
            }

            set
            {
                this.shouldSerialize["e_serial_number"] = true;
                this.eSerialNumber = value;
            }
        }

        /// <summary>
        /// E Track Data
        /// </summary>
        [JsonProperty("e_track_data")]
        public string ETrackData
        {
            get
            {
                return this.eTrackData;
            }

            set
            {
                this.shouldSerialize["e_track_data"] = true;
                this.eTrackData = value;
            }
        }

        /// <summary>
        /// E Format
        /// </summary>
        [JsonProperty("e_format")]
        public string EFormat
        {
            get
            {
                return this.eFormat;
            }

            set
            {
                this.shouldSerialize["e_format"] = true;
                this.eFormat = value;
            }
        }

        /// <summary>
        /// E Keyed Data
        /// </summary>
        [JsonProperty("e_keyed_data")]
        public string EKeyedData
        {
            get
            {
                return this.eKeyedData;
            }

            set
            {
                this.shouldSerialize["e_keyed_data"] = true;
                this.eKeyedData = value;
            }
        }

        /// <summary>
        /// A flag that will override a product transactions run_avs_on_accountvault_create setting to determine if an avsonly transaction should be run prior to storing the account vault. When storing an account vault with tha run_avs flag, if the avsonly check fails account verification with the processor, the account vault will not be stored in the system. The meaning of the AVS response codes can be found here on this page.This is the new preferred method of validating a credit card and can be used instead of the legacy $1 auth only transaction.Using this flag overrides the default setting for the locations product transactions.
        /// </summary>
        [JsonProperty("run_avs", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RunAvs { get; set; }

        /// <summary>
        /// Track Data from a magnetic card swipe.
        /// </summary>
        [JsonProperty("track_data")]
        public string TrackData
        {
            get
            {
                return this.trackData;
            }

            set
            {
                this.shouldSerialize["track_data"] = true;
                this.trackData = value;
            }
        }

        /// <summary>
        /// A valid ticket that was created to store the token.
        /// </summary>
        [JsonProperty("ticket")]
        public string Ticket
        {
            get
            {
                return this.ticket;
            }

            set
            {
                this.shouldSerialize["ticket"] = true;
                this.ticket = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1TokensCcRequest : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetPreviousTransactionId()
        {
            this.shouldSerialize["previous_transaction_id"] = false;
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
        public void UnsetESerialNumber()
        {
            this.shouldSerialize["e_serial_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetETrackData()
        {
            this.shouldSerialize["e_track_data"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEFormat()
        {
            this.shouldSerialize["e_format"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEKeyedData()
        {
            this.shouldSerialize["e_keyed_data"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTrackData()
        {
            this.shouldSerialize["track_data"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTicket()
        {
            this.shouldSerialize["ticket"] = false;
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
        public bool ShouldSerializePreviousTransactionId()
        {
            return this.shouldSerialize["previous_transaction_id"];
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
        public bool ShouldSerializeESerialNumber()
        {
            return this.shouldSerialize["e_serial_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeETrackData()
        {
            return this.shouldSerialize["e_track_data"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEFormat()
        {
            return this.shouldSerialize["e_format"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEKeyedData()
        {
            return this.shouldSerialize["e_keyed_data"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTrackData()
        {
            return this.shouldSerialize["track_data"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTicket()
        {
            return this.shouldSerialize["ticket"];
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

            return obj is V1TokensCcRequest other &&
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
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.ExpDate == null && other.ExpDate == null) || (this.ExpDate?.Equals(other.ExpDate) == true)) &&
                ((this.ESerialNumber == null && other.ESerialNumber == null) || (this.ESerialNumber?.Equals(other.ESerialNumber) == true)) &&
                ((this.ETrackData == null && other.ETrackData == null) || (this.ETrackData?.Equals(other.ETrackData) == true)) &&
                ((this.EFormat == null && other.EFormat == null) || (this.EFormat?.Equals(other.EFormat) == true)) &&
                ((this.EKeyedData == null && other.EKeyedData == null) || (this.EKeyedData?.Equals(other.EKeyedData) == true)) &&
                ((this.RunAvs == null && other.RunAvs == null) || (this.RunAvs?.Equals(other.RunAvs) == true)) &&
                ((this.TrackData == null && other.TrackData == null) || (this.TrackData?.Equals(other.TrackData) == true)) &&
                ((this.Ticket == null && other.Ticket == null) || (this.Ticket?.Equals(other.Ticket) == true));
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
            toStringOutput.Add($"this.ExpDate = {(this.ExpDate == null ? "null" : this.ExpDate == string.Empty ? "" : this.ExpDate)}");
            toStringOutput.Add($"this.ESerialNumber = {(this.ESerialNumber == null ? "null" : this.ESerialNumber == string.Empty ? "" : this.ESerialNumber)}");
            toStringOutput.Add($"this.ETrackData = {(this.ETrackData == null ? "null" : this.ETrackData == string.Empty ? "" : this.ETrackData)}");
            toStringOutput.Add($"this.EFormat = {(this.EFormat == null ? "null" : this.EFormat == string.Empty ? "" : this.EFormat)}");
            toStringOutput.Add($"this.EKeyedData = {(this.EKeyedData == null ? "null" : this.EKeyedData == string.Empty ? "" : this.EKeyedData)}");
            toStringOutput.Add($"this.RunAvs = {(this.RunAvs == null ? "null" : this.RunAvs.ToString())}");
            toStringOutput.Add($"this.TrackData = {(this.TrackData == null ? "null" : this.TrackData == string.Empty ? "" : this.TrackData)}");
            toStringOutput.Add($"this.Ticket = {(this.Ticket == null ? "null" : this.Ticket == string.Empty ? "" : this.Ticket)}");
        }
    }
}