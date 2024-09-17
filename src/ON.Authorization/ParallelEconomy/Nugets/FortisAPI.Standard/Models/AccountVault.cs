// <copyright file="AccountVault.cs" company="APIMatic">
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
    /// AccountVault.
    /// </summary>
    public class AccountVault : BaseModel
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
        private string previousAccountVaultApiId;
        private string previousTokenApiId;
        private string previousAccountVaultId;
        private string previousTokenId;
        private string previousTransactionId;
        private AccountVaultAccountNumber accountNumber;
        private string termsAgreeIp;
        private string title;
        private string eSerialNumber;
        private string eTrackData;
        private string eFormat;
        private string eKeyedData;
        private int? expiringInMonths;
        private string expDate;
        private string ticket;
        private string trackData;
        private string createdUserId;
        private int? cauLastUpdatedTs;
        private string cardBin;
        private string routingNumber;
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
            { "previous_account_vault_api_id", false },
            { "previous_token_api_id", false },
            { "previous_account_vault_id", false },
            { "previous_token_id", false },
            { "previous_transaction_id", false },
            { "account_number", false },
            { "terms_agree_ip", false },
            { "title", false },
            { "e_serial_number", false },
            { "e_track_data", false },
            { "e_format", false },
            { "e_keyed_data", false },
            { "expiring_in_months", false },
            { "exp_date", false },
            { "ticket", false },
            { "track_data", false },
            { "created_user_id", false },
            { "cau_last_updated_ts", false },
            { "card_bin", false },
            { "routing_number", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountVault"/> class.
        /// </summary>
        public AccountVault()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountVault"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="id">id.</param>
        /// <param name="accountType">account_type.</param>
        /// <param name="cauSummaryStatusId">cau_summary_status_id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="firstSix">first_six.</param>
        /// <param name="hasRecurring">has_recurring.</param>
        /// <param name="lastFour">last_four.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="paymentMethod">payment_method.</param>
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
        /// <param name="active">active.</param>
        /// <param name="eSerialNumber">e_serial_number.</param>
        /// <param name="eTrackData">e_track_data.</param>
        /// <param name="eFormat">e_format.</param>
        /// <param name="eKeyedData">e_keyed_data.</param>
        /// <param name="expiringInMonths">expiring_in_months.</param>
        /// <param name="expDate">exp_date.</param>
        /// <param name="ticket">ticket.</param>
        /// <param name="trackData">track_data.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="cauLastUpdatedTs">cau_last_updated_ts.</param>
        /// <param name="cardBin">card_bin.</param>
        /// <param name="routingNumber">routing_number.</param>
        public AccountVault(
            string locationId,
            string id,
            string accountType,
            Models.CauSummaryStatusIdEnum cauSummaryStatusId,
            int createdTs,
            string firstSix,
            bool hasRecurring,
            string lastFour,
            int modifiedTs,
            Models.PaymentMethod13Enum paymentMethod,
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
            string previousAccountVaultApiId = null,
            string previousTokenApiId = null,
            string previousAccountVaultId = null,
            string previousTokenId = null,
            string previousTransactionId = null,
            AccountVaultAccountNumber accountNumber = null,
            bool? termsAgree = null,
            string termsAgreeIp = null,
            string title = null,
            Models.Joi4 joi = null,
            bool? active = null,
            string eSerialNumber = null,
            string eTrackData = null,
            string eFormat = null,
            string eKeyedData = null,
            int? expiringInMonths = null,
            string expDate = null,
            string ticket = null,
            string trackData = null,
            string createdUserId = null,
            int? cauLastUpdatedTs = null,
            string cardBin = null,
            string routingNumber = null)
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
            this.LocationId = locationId;
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
            this.Id = id;
            this.AccountType = accountType;
            this.Active = active;
            this.CauSummaryStatusId = cauSummaryStatusId;
            this.CreatedTs = createdTs;
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

            if (expiringInMonths != null)
            {
                this.ExpiringInMonths = expiringInMonths;
            }

            if (expDate != null)
            {
                this.ExpDate = expDate;
            }

            this.FirstSix = firstSix;
            this.HasRecurring = hasRecurring;
            this.LastFour = lastFour;
            this.ModifiedTs = modifiedTs;
            this.PaymentMethod = paymentMethod;
            if (ticket != null)
            {
                this.Ticket = ticket;
            }

            if (trackData != null)
            {
                this.TrackData = trackData;
            }

            if (createdUserId != null)
            {
                this.CreatedUserId = createdUserId;
            }

            if (cauLastUpdatedTs != null)
            {
                this.CauLastUpdatedTs = cauLastUpdatedTs;
            }

            if (cardBin != null)
            {
                this.CardBin = cardBin;
            }

            if (routingNumber != null)
            {
                this.RoutingNumber = routingNumber;
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
        public string LocationId { get; set; }

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
        public AccountVaultAccountNumber AccountNumber
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
        /// A unique, system-generated identifier for the Token.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Account type
        /// </summary>
        [JsonProperty("account_type")]
        public string AccountType { get; set; }

        /// <summary>
        /// Register is Active
        /// </summary>
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Active { get; set; }

        /// <summary>
        /// CAU Summary Status ID.
        /// </summary>
        [JsonProperty("cau_summary_status_id")]
        public Models.CauSummaryStatusIdEnum CauSummaryStatusId { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int CreatedTs { get; set; }

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
        /// Determined by API based on card exp_date.
        /// </summary>
        [JsonProperty("expiring_in_months")]
        public int? ExpiringInMonths
        {
            get
            {
                return this.expiringInMonths;
            }

            set
            {
                this.shouldSerialize["expiring_in_months"] = true;
                this.expiringInMonths = value;
            }
        }

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

        /// <summary>
        /// The first six numbers of an account number.  System will generate a value for this field automatically.
        /// </summary>
        [JsonProperty("first_six")]
        public string FirstSix { get; set; }

        /// <summary>
        /// True indicates that this token is tied to a Recurring Payment
        /// </summary>
        [JsonProperty("has_recurring")]
        public bool HasRecurring { get; set; }

        /// <summary>
        /// The last four numbers of an account number.  System will generate a value for this field automatically.
        /// </summary>
        [JsonProperty("last_four")]
        public string LastFour { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts")]
        public int ModifiedTs { get; set; }

        /// <summary>
        /// Must be provided as either 'cc' or 'ach'.
        /// </summary>
        [JsonProperty("payment_method")]
        public Models.PaymentMethod13Enum PaymentMethod { get; set; }

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
        /// User ID Created the register
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
        /// CAU Last Updated Timestamp
        /// </summary>
        [JsonProperty("cau_last_updated_ts")]
        public int? CauLastUpdatedTs
        {
            get
            {
                return this.cauLastUpdatedTs;
            }

            set
            {
                this.shouldSerialize["cau_last_updated_ts"] = true;
                this.cauLastUpdatedTs = value;
            }
        }

        /// <summary>
        /// Card bin
        /// </summary>
        [JsonProperty("card_bin")]
        public string CardBin
        {
            get
            {
                return this.cardBin;
            }

            set
            {
                this.shouldSerialize["card_bin"] = true;
                this.cardBin = value;
            }
        }

        /// <summary>
        /// Required for ACH. The Routing Number for the bank account being used.
        /// </summary>
        [JsonProperty("routing_number")]
        public string RoutingNumber
        {
            get
            {
                return this.routingNumber;
            }

            set
            {
                this.shouldSerialize["routing_number"] = true;
                this.routingNumber = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AccountVault : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetExpiringInMonths()
        {
            this.shouldSerialize["expiring_in_months"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetExpDate()
        {
            this.shouldSerialize["exp_date"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTicket()
        {
            this.shouldSerialize["ticket"] = false;
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
        public void UnsetCreatedUserId()
        {
            this.shouldSerialize["created_user_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCauLastUpdatedTs()
        {
            this.shouldSerialize["cau_last_updated_ts"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCardBin()
        {
            this.shouldSerialize["card_bin"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRoutingNumber()
        {
            this.shouldSerialize["routing_number"] = false;
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
        public bool ShouldSerializeExpiringInMonths()
        {
            return this.shouldSerialize["expiring_in_months"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeExpDate()
        {
            return this.shouldSerialize["exp_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTicket()
        {
            return this.shouldSerialize["ticket"];
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
        public bool ShouldSerializeCreatedUserId()
        {
            return this.shouldSerialize["created_user_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCauLastUpdatedTs()
        {
            return this.shouldSerialize["cau_last_updated_ts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCardBin()
        {
            return this.shouldSerialize["card_bin"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRoutingNumber()
        {
            return this.shouldSerialize["routing_number"];
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
            return obj is AccountVault other &&                ((this.AccountHolderName == null && other.AccountHolderName == null) || (this.AccountHolderName?.Equals(other.AccountHolderName) == true)) &&
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
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.AccountType == null && other.AccountType == null) || (this.AccountType?.Equals(other.AccountType) == true)) &&
                ((this.Active == null && other.Active == null) || (this.Active?.Equals(other.Active) == true)) &&
                this.CauSummaryStatusId.Equals(other.CauSummaryStatusId) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                ((this.ESerialNumber == null && other.ESerialNumber == null) || (this.ESerialNumber?.Equals(other.ESerialNumber) == true)) &&
                ((this.ETrackData == null && other.ETrackData == null) || (this.ETrackData?.Equals(other.ETrackData) == true)) &&
                ((this.EFormat == null && other.EFormat == null) || (this.EFormat?.Equals(other.EFormat) == true)) &&
                ((this.EKeyedData == null && other.EKeyedData == null) || (this.EKeyedData?.Equals(other.EKeyedData) == true)) &&
                ((this.ExpiringInMonths == null && other.ExpiringInMonths == null) || (this.ExpiringInMonths?.Equals(other.ExpiringInMonths) == true)) &&
                ((this.ExpDate == null && other.ExpDate == null) || (this.ExpDate?.Equals(other.ExpDate) == true)) &&
                ((this.FirstSix == null && other.FirstSix == null) || (this.FirstSix?.Equals(other.FirstSix) == true)) &&
                this.HasRecurring.Equals(other.HasRecurring) &&
                ((this.LastFour == null && other.LastFour == null) || (this.LastFour?.Equals(other.LastFour) == true)) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                this.PaymentMethod.Equals(other.PaymentMethod) &&
                ((this.Ticket == null && other.Ticket == null) || (this.Ticket?.Equals(other.Ticket) == true)) &&
                ((this.TrackData == null && other.TrackData == null) || (this.TrackData?.Equals(other.TrackData) == true)) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true)) &&
                ((this.CauLastUpdatedTs == null && other.CauLastUpdatedTs == null) || (this.CauLastUpdatedTs?.Equals(other.CauLastUpdatedTs) == true)) &&
                ((this.CardBin == null && other.CardBin == null) || (this.CardBin?.Equals(other.CardBin) == true)) &&
                ((this.RoutingNumber == null && other.RoutingNumber == null) || (this.RoutingNumber?.Equals(other.RoutingNumber) == true));
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
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.AccountType = {(this.AccountType == null ? "null" : this.AccountType)}");
            toStringOutput.Add($"this.Active = {(this.Active == null ? "null" : this.Active.ToString())}");
            toStringOutput.Add($"this.CauSummaryStatusId = {this.CauSummaryStatusId}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ESerialNumber = {(this.ESerialNumber == null ? "null" : this.ESerialNumber)}");
            toStringOutput.Add($"this.ETrackData = {(this.ETrackData == null ? "null" : this.ETrackData)}");
            toStringOutput.Add($"this.EFormat = {(this.EFormat == null ? "null" : this.EFormat)}");
            toStringOutput.Add($"this.EKeyedData = {(this.EKeyedData == null ? "null" : this.EKeyedData)}");
            toStringOutput.Add($"this.ExpiringInMonths = {(this.ExpiringInMonths == null ? "null" : this.ExpiringInMonths.ToString())}");
            toStringOutput.Add($"this.ExpDate = {(this.ExpDate == null ? "null" : this.ExpDate)}");
            toStringOutput.Add($"this.FirstSix = {(this.FirstSix == null ? "null" : this.FirstSix)}");
            toStringOutput.Add($"this.HasRecurring = {this.HasRecurring}");
            toStringOutput.Add($"this.LastFour = {(this.LastFour == null ? "null" : this.LastFour)}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.PaymentMethod = {this.PaymentMethod}");
            toStringOutput.Add($"this.Ticket = {(this.Ticket == null ? "null" : this.Ticket)}");
            toStringOutput.Add($"this.TrackData = {(this.TrackData == null ? "null" : this.TrackData)}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.CauLastUpdatedTs = {(this.CauLastUpdatedTs == null ? "null" : this.CauLastUpdatedTs.ToString())}");
            toStringOutput.Add($"this.CardBin = {(this.CardBin == null ? "null" : this.CardBin)}");
            toStringOutput.Add($"this.RoutingNumber = {(this.RoutingNumber == null ? "null" : this.RoutingNumber)}");

            base.ToString(toStringOutput);
        }
    }
}