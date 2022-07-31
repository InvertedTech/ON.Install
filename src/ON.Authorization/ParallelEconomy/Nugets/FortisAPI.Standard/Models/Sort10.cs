// <copyright file="Sort10.cs" company="APIMatic">
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
    /// Sort10.
    /// </summary>
    public class Sort10
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sort10"/> class.
        /// </summary>
        public Sort10()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sort10"/> class.
        /// </summary>
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
        /// <param name="locationId">location_id.</param>
        /// <param name="previousAccountVaultApiId">previous_account_vault_api_id.</param>
        /// <param name="previousAccountVaultId">previous_account_vault_id.</param>
        /// <param name="previousTransactionId">previous_transaction_id.</param>
        /// <param name="termsAgree">terms_agree.</param>
        /// <param name="termsAgreeIp">terms_agree_ip.</param>
        /// <param name="title">title.</param>
        /// <param name="id">id.</param>
        /// <param name="accountType">account_type.</param>
        /// <param name="active">active.</param>
        /// <param name="cauSummaryStatusId">cau_summary_status_id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="eSerialNumber">e_serial_number.</param>
        /// <param name="eTrackData">e_track_data.</param>
        /// <param name="eFormat">e_format.</param>
        /// <param name="eKeyedData">e_keyed_data.</param>
        /// <param name="expiringInMonths">expiring_in_months.</param>
        /// <param name="firstSix">first_six.</param>
        /// <param name="hasRecurring">has_recurring.</param>
        /// <param name="lastFour">last_four.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="paymentMethod">payment_method.</param>
        /// <param name="ticket">ticket.</param>
        /// <param name="trackData">track_data.</param>
        public Sort10(
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
            string locationId = null,
            string previousAccountVaultApiId = null,
            string previousAccountVaultId = null,
            string previousTransactionId = null,
            bool? termsAgree = null,
            string termsAgreeIp = null,
            string title = null,
            string id = null,
            string accountType = null,
            bool? active = null,
            Models.CauSummaryStatusIdEnum? cauSummaryStatusId = null,
            int? createdTs = null,
            string eSerialNumber = null,
            string eTrackData = null,
            string eFormat = null,
            string eKeyedData = null,
            int? expiringInMonths = null,
            string firstSix = null,
            bool? hasRecurring = null,
            string lastFour = null,
            int? modifiedTs = null,
            Models.PaymentMethod2Enum? paymentMethod = null,
            string ticket = null,
            string trackData = null)
        {
            this.AccountHolderName = accountHolderName;
            this.AccountNumber = accountNumber;
            this.AccountVaultApiId = accountVaultApiId;
            this.AccountvaultC1 = accountvaultC1;
            this.AccountvaultC2 = accountvaultC2;
            this.AccountvaultC3 = accountvaultC3;
            this.AchSecCode = achSecCode;
            this.BillingAddress = billingAddress;
            this.ContactId = contactId;
            this.CustomerId = customerId;
            this.IdentityVerification = identityVerification;
            this.LocationId = locationId;
            this.PreviousAccountVaultApiId = previousAccountVaultApiId;
            this.PreviousAccountVaultId = previousAccountVaultId;
            this.PreviousTransactionId = previousTransactionId;
            this.TermsAgree = termsAgree;
            this.TermsAgreeIp = termsAgreeIp;
            this.Title = title;
            this.Id = id;
            this.AccountType = accountType;
            this.Active = active;
            this.CauSummaryStatusId = cauSummaryStatusId;
            this.CreatedTs = createdTs;
            this.ESerialNumber = eSerialNumber;
            this.ETrackData = eTrackData;
            this.EFormat = eFormat;
            this.EKeyedData = eKeyedData;
            this.ExpiringInMonths = expiringInMonths;
            this.FirstSix = firstSix;
            this.HasRecurring = hasRecurring;
            this.LastFour = lastFour;
            this.ModifiedTs = modifiedTs;
            this.PaymentMethod = paymentMethod;
            this.Ticket = ticket;
            this.TrackData = trackData;
        }

        /// <summary>
        /// Account holder name
        /// </summary>
        [JsonProperty("account_holder_name", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountHolderName { get; set; }

        /// <summary>
        /// Account number
        /// </summary>
        [JsonProperty("account_number", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// This field can be used to correlate Account Vaults in our system to data within an outside software integration
        /// </summary>
        [JsonProperty("account_vault_api_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountVaultApiId { get; set; }

        /// <summary>
        /// Custom field 1 for API users to store custom data
        /// </summary>
        [JsonProperty("accountvault_c1", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountvaultC1 { get; set; }

        /// <summary>
        /// Custom field 2 for API users to store custom data
        /// </summary>
        [JsonProperty("accountvault_c2", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountvaultC2 { get; set; }

        /// <summary>
        /// Custom field 3 for API users to store custom data
        /// </summary>
        [JsonProperty("accountvault_c3", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountvaultC3 { get; set; }

        /// <summary>
        /// SEC code for the account
        /// </summary>
        [JsonProperty("ach_sec_code", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.AchSecCodeEnum? AchSecCode { get; set; }

        /// <summary>
        /// The Street portion of the address associated with the Credit Card (CC) or Bank Account (ACH).
        /// </summary>
        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BillingAddress BillingAddress { get; set; }

        /// <summary>
        /// Used to associate the Account Vault with a Contact.
        /// </summary>
        [JsonProperty("contact_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ContactId { get; set; }

        /// <summary>
        /// Used to store a customer identification number.
        /// </summary>
        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Identity verification
        /// </summary>
        [JsonProperty("identity_verification", NullValueHandling = NullValueHandling.Ignore)]
        public Models.IdentityVerification IdentityVerification { get; set; }

        /// <summary>
        /// A valid Location Id associated with the Contact for this Token
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; set; }

        /// <summary>
        /// Can be used to pull payment info from a previous account vault api id.
        /// </summary>
        [JsonProperty("previous_account_vault_api_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PreviousAccountVaultApiId { get; set; }

        /// <summary>
        /// Can be used to pull payment info from a previous account vault.
        /// </summary>
        [JsonProperty("previous_account_vault_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PreviousAccountVaultId { get; set; }

        /// <summary>
        /// Can be used to pull payment info from a previous transaction.
        /// </summary>
        [JsonProperty("previous_transaction_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PreviousTransactionId { get; set; }

        /// <summary>
        /// Terms agreement.
        /// </summary>
        [JsonProperty("terms_agree", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TermsAgree { get; set; }

        /// <summary>
        /// The ip address of the client that agreed to terms.
        /// </summary>
        [JsonProperty("terms_agree_ip", NullValueHandling = NullValueHandling.Ignore)]
        public string TermsAgreeIp { get; set; }

        /// <summary>
        /// Used to describe the Token for easier identification within our UI.
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// A unique, system-generated identifier for the Token.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Account type
        /// </summary>
        [JsonProperty("account_type", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountType { get; set; }

        /// <summary>
        /// Register is Active
        /// </summary>
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Active { get; set; }

        /// <summary>
        /// CAU Summary Status ID.
        /// </summary>
        [JsonProperty("cau_summary_status_id", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CauSummaryStatusIdEnum? CauSummaryStatusId { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? CreatedTs { get; set; }

        /// <summary>
        /// E Serial Number
        /// </summary>
        [JsonProperty("e_serial_number", NullValueHandling = NullValueHandling.Ignore)]
        public string ESerialNumber { get; set; }

        /// <summary>
        /// E Track Data
        /// </summary>
        [JsonProperty("e_track_data", NullValueHandling = NullValueHandling.Ignore)]
        public string ETrackData { get; set; }

        /// <summary>
        /// E Format
        /// </summary>
        [JsonProperty("e_format", NullValueHandling = NullValueHandling.Ignore)]
        public string EFormat { get; set; }

        /// <summary>
        /// E Keyed Data
        /// </summary>
        [JsonProperty("e_keyed_data", NullValueHandling = NullValueHandling.Ignore)]
        public string EKeyedData { get; set; }

        /// <summary>
        /// Determined by API based on card exp_date.
        /// </summary>
        [JsonProperty("expiring_in_months", NullValueHandling = NullValueHandling.Ignore)]
        public int? ExpiringInMonths { get; set; }

        /// <summary>
        /// The first six numbers of an account number.  System will generate a value for this field automatically.
        /// </summary>
        [JsonProperty("first_six", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstSix { get; set; }

        /// <summary>
        /// True indicates that this account vault is tied to a Recurring Payment
        /// </summary>
        [JsonProperty("has_recurring", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasRecurring { get; set; }

        /// <summary>
        /// The last four numbers of an account number.  System will generate a value for this field automatically.
        /// </summary>
        [JsonProperty("last_four", NullValueHandling = NullValueHandling.Ignore)]
        public string LastFour { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? ModifiedTs { get; set; }

        /// <summary>
        /// Must be provided as either 'cc' or 'ach'.
        /// </summary>
        [JsonProperty("payment_method", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentMethod2Enum? PaymentMethod { get; set; }

        /// <summary>
        /// A valid ticket that was created to store the token.
        /// </summary>
        [JsonProperty("ticket", NullValueHandling = NullValueHandling.Ignore)]
        public string Ticket { get; set; }

        /// <summary>
        /// Track Data from a magnetic card swipe.
        /// </summary>
        [JsonProperty("track_data", NullValueHandling = NullValueHandling.Ignore)]
        public string TrackData { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Sort10 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Sort10 other &&
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
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.AccountType == null && other.AccountType == null) || (this.AccountType?.Equals(other.AccountType) == true)) &&
                ((this.Active == null && other.Active == null) || (this.Active?.Equals(other.Active) == true)) &&
                ((this.CauSummaryStatusId == null && other.CauSummaryStatusId == null) || (this.CauSummaryStatusId?.Equals(other.CauSummaryStatusId) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.ESerialNumber == null && other.ESerialNumber == null) || (this.ESerialNumber?.Equals(other.ESerialNumber) == true)) &&
                ((this.ETrackData == null && other.ETrackData == null) || (this.ETrackData?.Equals(other.ETrackData) == true)) &&
                ((this.EFormat == null && other.EFormat == null) || (this.EFormat?.Equals(other.EFormat) == true)) &&
                ((this.EKeyedData == null && other.EKeyedData == null) || (this.EKeyedData?.Equals(other.EKeyedData) == true)) &&
                ((this.ExpiringInMonths == null && other.ExpiringInMonths == null) || (this.ExpiringInMonths?.Equals(other.ExpiringInMonths) == true)) &&
                ((this.FirstSix == null && other.FirstSix == null) || (this.FirstSix?.Equals(other.FirstSix) == true)) &&
                ((this.HasRecurring == null && other.HasRecurring == null) || (this.HasRecurring?.Equals(other.HasRecurring) == true)) &&
                ((this.LastFour == null && other.LastFour == null) || (this.LastFour?.Equals(other.LastFour) == true)) &&
                ((this.ModifiedTs == null && other.ModifiedTs == null) || (this.ModifiedTs?.Equals(other.ModifiedTs) == true)) &&
                ((this.PaymentMethod == null && other.PaymentMethod == null) || (this.PaymentMethod?.Equals(other.PaymentMethod) == true)) &&
                ((this.Ticket == null && other.Ticket == null) || (this.Ticket?.Equals(other.Ticket) == true)) &&
                ((this.TrackData == null && other.TrackData == null) || (this.TrackData?.Equals(other.TrackData) == true));
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
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.AccountType = {(this.AccountType == null ? "null" : this.AccountType == string.Empty ? "" : this.AccountType)}");
            toStringOutput.Add($"this.Active = {(this.Active == null ? "null" : this.Active.ToString())}");
            toStringOutput.Add($"this.CauSummaryStatusId = {(this.CauSummaryStatusId == null ? "null" : this.CauSummaryStatusId.ToString())}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.ESerialNumber = {(this.ESerialNumber == null ? "null" : this.ESerialNumber == string.Empty ? "" : this.ESerialNumber)}");
            toStringOutput.Add($"this.ETrackData = {(this.ETrackData == null ? "null" : this.ETrackData == string.Empty ? "" : this.ETrackData)}");
            toStringOutput.Add($"this.EFormat = {(this.EFormat == null ? "null" : this.EFormat == string.Empty ? "" : this.EFormat)}");
            toStringOutput.Add($"this.EKeyedData = {(this.EKeyedData == null ? "null" : this.EKeyedData == string.Empty ? "" : this.EKeyedData)}");
            toStringOutput.Add($"this.ExpiringInMonths = {(this.ExpiringInMonths == null ? "null" : this.ExpiringInMonths.ToString())}");
            toStringOutput.Add($"this.FirstSix = {(this.FirstSix == null ? "null" : this.FirstSix == string.Empty ? "" : this.FirstSix)}");
            toStringOutput.Add($"this.HasRecurring = {(this.HasRecurring == null ? "null" : this.HasRecurring.ToString())}");
            toStringOutput.Add($"this.LastFour = {(this.LastFour == null ? "null" : this.LastFour == string.Empty ? "" : this.LastFour)}");
            toStringOutput.Add($"this.ModifiedTs = {(this.ModifiedTs == null ? "null" : this.ModifiedTs.ToString())}");
            toStringOutput.Add($"this.PaymentMethod = {(this.PaymentMethod == null ? "null" : this.PaymentMethod.ToString())}");
            toStringOutput.Add($"this.Ticket = {(this.Ticket == null ? "null" : this.Ticket == string.Empty ? "" : this.Ticket)}");
            toStringOutput.Add($"this.TrackData = {(this.TrackData == null ? "null" : this.TrackData == string.Empty ? "" : this.TrackData)}");
        }
    }
}