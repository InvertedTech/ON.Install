// <copyright file="Sort12.cs" company="APIMatic">
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
    /// Sort12.
    /// </summary>
    public class Sort12
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sort12"/> class.
        /// </summary>
        public Sort12()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sort12"/> class.
        /// </summary>
        /// <param name="accountNumber">account_number.</param>
        /// <param name="address">address.</param>
        /// <param name="brandingDomainUrl">branding_domain_url.</param>
        /// <param name="cellPhone">cell_phone.</param>
        /// <param name="city">city.</param>
        /// <param name="companyName">company_name.</param>
        /// <param name="contactId">contact_id.</param>
        /// <param name="dateOfBirth">date_of_birth.</param>
        /// <param name="domainId">domain_id.</param>
        /// <param name="email">email.</param>
        /// <param name="emailTrxReceipt">email_trx_receipt.</param>
        /// <param name="homePhone">home_phone.</param>
        /// <param name="firstName">first_name.</param>
        /// <param name="lastName">last_name.</param>
        /// <param name="locale">locale.</param>
        /// <param name="officePhone">office_phone.</param>
        /// <param name="officeExtPhone">office_ext_phone.</param>
        /// <param name="primaryLocationId">primary_location_id.</param>
        /// <param name="requiresNewPassword">requires_new_password.</param>
        /// <param name="state">state.</param>
        /// <param name="termsConditionId">terms_condition_id.</param>
        /// <param name="tz">tz.</param>
        /// <param name="uiPrefs">ui_prefs.</param>
        /// <param name="username">username.</param>
        /// <param name="userApiKey">user_api_key.</param>
        /// <param name="userHashKey">user_hash_key.</param>
        /// <param name="userTypeCode">user_type_code.</param>
        /// <param name="password">password.</param>
        /// <param name="zip">zip.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="contactApiId">contact_api_id.</param>
        /// <param name="primaryLocationApiId">primary_location_api_id.</param>
        /// <param name="statusId">status_id.</param>
        /// <param name="id">id.</param>
        /// <param name="status">status.</param>
        /// <param name="loginAttempts">login_attempts.</param>
        /// <param name="lastLoginTs">last_login_ts.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="termsAcceptedTs">terms_accepted_ts.</param>
        /// <param name="termsAgreeIp">terms_agree_ip.</param>
        /// <param name="currentDateTime">current_date_time.</param>
        public Sort12(
            string accountNumber = null,
            string address = null,
            string brandingDomainUrl = null,
            string cellPhone = null,
            string city = null,
            string companyName = null,
            string contactId = null,
            string dateOfBirth = null,
            string domainId = null,
            string email = null,
            bool? emailTrxReceipt = null,
            string homePhone = null,
            string firstName = null,
            string lastName = null,
            string locale = null,
            string officePhone = null,
            string officeExtPhone = null,
            string primaryLocationId = null,
            string requiresNewPassword = null,
            string state = null,
            string termsConditionId = null,
            string tz = null,
            Models.UiPrefs uiPrefs = null,
            string username = null,
            string userApiKey = null,
            string userHashKey = null,
            Models.UserTypeCodeEnum? userTypeCode = null,
            string password = null,
            string zip = null,
            string locationId = null,
            string contactApiId = null,
            string primaryLocationApiId = null,
            bool? statusId = null,
            string id = null,
            bool? status = null,
            double? loginAttempts = null,
            int? lastLoginTs = null,
            int? createdTs = null,
            int? modifiedTs = null,
            string createdUserId = null,
            int? termsAcceptedTs = null,
            string termsAgreeIp = null,
            string currentDateTime = null)
        {
            this.AccountNumber = accountNumber;
            this.Address = address;
            this.BrandingDomainUrl = brandingDomainUrl;
            this.CellPhone = cellPhone;
            this.City = city;
            this.CompanyName = companyName;
            this.ContactId = contactId;
            this.DateOfBirth = dateOfBirth;
            this.DomainId = domainId;
            this.Email = email;
            this.EmailTrxReceipt = emailTrxReceipt;
            this.HomePhone = homePhone;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Locale = locale;
            this.OfficePhone = officePhone;
            this.OfficeExtPhone = officeExtPhone;
            this.PrimaryLocationId = primaryLocationId;
            this.RequiresNewPassword = requiresNewPassword;
            this.State = state;
            this.TermsConditionId = termsConditionId;
            this.Tz = tz;
            this.UiPrefs = uiPrefs;
            this.Username = username;
            this.UserApiKey = userApiKey;
            this.UserHashKey = userHashKey;
            this.UserTypeCode = userTypeCode;
            this.Password = password;
            this.Zip = zip;
            this.LocationId = locationId;
            this.ContactApiId = contactApiId;
            this.PrimaryLocationApiId = primaryLocationApiId;
            this.StatusId = statusId;
            this.Id = id;
            this.Status = status;
            this.LoginAttempts = loginAttempts;
            this.LastLoginTs = lastLoginTs;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            this.CreatedUserId = createdUserId;
            this.TermsAcceptedTs = termsAcceptedTs;
            this.TermsAgreeIp = termsAgreeIp;
            this.CurrentDateTime = currentDateTime;
        }

        /// <summary>
        /// Account Number
        /// </summary>
        [JsonProperty("account_number", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }

        /// <summary>
        /// Branding Domain Url
        /// </summary>
        [JsonProperty("branding_domain_url", NullValueHandling = NullValueHandling.Ignore)]
        public string BrandingDomainUrl { get; set; }

        /// <summary>
        /// Cell Phone
        /// </summary>
        [JsonProperty("cell_phone", NullValueHandling = NullValueHandling.Ignore)]
        public string CellPhone { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        /// <summary>
        /// Company Name
        /// </summary>
        [JsonProperty("company_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Contact
        /// </summary>
        [JsonProperty("contact_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ContactId { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        [JsonProperty("date_of_birth", NullValueHandling = NullValueHandling.Ignore)]
        public string DateOfBirth { get; set; }

        /// <summary>
        /// Domain
        /// </summary>
        [JsonProperty("domain_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DomainId { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        /// <summary>
        /// Email Trx Receipt
        /// </summary>
        [JsonProperty("email_trx_receipt", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EmailTrxReceipt { get; set; }

        /// <summary>
        /// Home Phone
        /// </summary>
        [JsonProperty("home_phone", NullValueHandling = NullValueHandling.Ignore)]
        public string HomePhone { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        /// <summary>
        /// Locale
        /// </summary>
        [JsonProperty("locale", NullValueHandling = NullValueHandling.Ignore)]
        public string Locale { get; set; }

        /// <summary>
        /// Office Phone
        /// </summary>
        [JsonProperty("office_phone", NullValueHandling = NullValueHandling.Ignore)]
        public string OfficePhone { get; set; }

        /// <summary>
        /// Office Ext Phone
        /// </summary>
        [JsonProperty("office_ext_phone", NullValueHandling = NullValueHandling.Ignore)]
        public string OfficeExtPhone { get; set; }

        /// <summary>
        /// Primary Location ID
        /// </summary>
        [JsonProperty("primary_location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PrimaryLocationId { get; set; }

        /// <summary>
        /// Requires New Password
        /// </summary>
        [JsonProperty("requires_new_password", NullValueHandling = NullValueHandling.Ignore)]
        public string RequiresNewPassword { get; set; }

        /// <summary>
        /// State
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        /// <summary>
        /// Terms Condition
        /// </summary>
        [JsonProperty("terms_condition_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TermsConditionId { get; set; }

        /// <summary>
        /// Time zone
        /// </summary>
        [JsonProperty("tz", NullValueHandling = NullValueHandling.Ignore)]
        public string Tz { get; set; }

        /// <summary>
        /// Ui Prefs
        /// </summary>
        [JsonProperty("ui_prefs", NullValueHandling = NullValueHandling.Ignore)]
        public Models.UiPrefs UiPrefs { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        /// <summary>
        /// User Api Key
        /// </summary>
        [JsonProperty("user_api_key", NullValueHandling = NullValueHandling.Ignore)]
        public string UserApiKey { get; set; }

        /// <summary>
        /// User Hash Key
        /// </summary>
        [JsonProperty("user_hash_key", NullValueHandling = NullValueHandling.Ignore)]
        public string UserHashKey { get; set; }

        /// <summary>
        /// User Type
        /// </summary>
        [JsonProperty("user_type_code", NullValueHandling = NullValueHandling.Ignore)]
        public Models.UserTypeCodeEnum? UserTypeCode { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }

        /// <summary>
        /// Zip
        /// </summary>
        [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
        public string Zip { get; set; }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; set; }

        /// <summary>
        /// ContactApi Id
        /// </summary>
        [JsonProperty("contact_api_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ContactApiId { get; set; }

        /// <summary>
        /// Primary LocationApi ID
        /// </summary>
        [JsonProperty("primary_location_api_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PrimaryLocationApiId { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [JsonProperty("status_id", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StatusId { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Status { get; set; }

        /// <summary>
        /// Login Attempts
        /// </summary>
        [JsonProperty("login_attempts", NullValueHandling = NullValueHandling.Ignore)]
        public double? LoginAttempts { get; set; }

        /// <summary>
        /// Last Login
        /// </summary>
        [JsonProperty("last_login_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? LastLoginTs { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? CreatedTs { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? ModifiedTs { get; set; }

        /// <summary>
        /// Created User
        /// </summary>
        [JsonProperty("created_user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedUserId { get; set; }

        /// <summary>
        /// Terms Accepted
        /// </summary>
        [JsonProperty("terms_accepted_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? TermsAcceptedTs { get; set; }

        /// <summary>
        /// Terms Agree Ip
        /// </summary>
        [JsonProperty("terms_agree_ip", NullValueHandling = NullValueHandling.Ignore)]
        public string TermsAgreeIp { get; set; }

        /// <summary>
        /// Current Date Time
        /// </summary>
        [JsonProperty("current_date_time", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrentDateTime { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Sort12 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Sort12 other &&
                ((this.AccountNumber == null && other.AccountNumber == null) || (this.AccountNumber?.Equals(other.AccountNumber) == true)) &&
                ((this.Address == null && other.Address == null) || (this.Address?.Equals(other.Address) == true)) &&
                ((this.BrandingDomainUrl == null && other.BrandingDomainUrl == null) || (this.BrandingDomainUrl?.Equals(other.BrandingDomainUrl) == true)) &&
                ((this.CellPhone == null && other.CellPhone == null) || (this.CellPhone?.Equals(other.CellPhone) == true)) &&
                ((this.City == null && other.City == null) || (this.City?.Equals(other.City) == true)) &&
                ((this.CompanyName == null && other.CompanyName == null) || (this.CompanyName?.Equals(other.CompanyName) == true)) &&
                ((this.ContactId == null && other.ContactId == null) || (this.ContactId?.Equals(other.ContactId) == true)) &&
                ((this.DateOfBirth == null && other.DateOfBirth == null) || (this.DateOfBirth?.Equals(other.DateOfBirth) == true)) &&
                ((this.DomainId == null && other.DomainId == null) || (this.DomainId?.Equals(other.DomainId) == true)) &&
                ((this.Email == null && other.Email == null) || (this.Email?.Equals(other.Email) == true)) &&
                ((this.EmailTrxReceipt == null && other.EmailTrxReceipt == null) || (this.EmailTrxReceipt?.Equals(other.EmailTrxReceipt) == true)) &&
                ((this.HomePhone == null && other.HomePhone == null) || (this.HomePhone?.Equals(other.HomePhone) == true)) &&
                ((this.FirstName == null && other.FirstName == null) || (this.FirstName?.Equals(other.FirstName) == true)) &&
                ((this.LastName == null && other.LastName == null) || (this.LastName?.Equals(other.LastName) == true)) &&
                ((this.Locale == null && other.Locale == null) || (this.Locale?.Equals(other.Locale) == true)) &&
                ((this.OfficePhone == null && other.OfficePhone == null) || (this.OfficePhone?.Equals(other.OfficePhone) == true)) &&
                ((this.OfficeExtPhone == null && other.OfficeExtPhone == null) || (this.OfficeExtPhone?.Equals(other.OfficeExtPhone) == true)) &&
                ((this.PrimaryLocationId == null && other.PrimaryLocationId == null) || (this.PrimaryLocationId?.Equals(other.PrimaryLocationId) == true)) &&
                ((this.RequiresNewPassword == null && other.RequiresNewPassword == null) || (this.RequiresNewPassword?.Equals(other.RequiresNewPassword) == true)) &&
                ((this.State == null && other.State == null) || (this.State?.Equals(other.State) == true)) &&
                ((this.TermsConditionId == null && other.TermsConditionId == null) || (this.TermsConditionId?.Equals(other.TermsConditionId) == true)) &&
                ((this.Tz == null && other.Tz == null) || (this.Tz?.Equals(other.Tz) == true)) &&
                ((this.UiPrefs == null && other.UiPrefs == null) || (this.UiPrefs?.Equals(other.UiPrefs) == true)) &&
                ((this.Username == null && other.Username == null) || (this.Username?.Equals(other.Username) == true)) &&
                ((this.UserApiKey == null && other.UserApiKey == null) || (this.UserApiKey?.Equals(other.UserApiKey) == true)) &&
                ((this.UserHashKey == null && other.UserHashKey == null) || (this.UserHashKey?.Equals(other.UserHashKey) == true)) &&
                ((this.UserTypeCode == null && other.UserTypeCode == null) || (this.UserTypeCode?.Equals(other.UserTypeCode) == true)) &&
                ((this.Password == null && other.Password == null) || (this.Password?.Equals(other.Password) == true)) &&
                ((this.Zip == null && other.Zip == null) || (this.Zip?.Equals(other.Zip) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.ContactApiId == null && other.ContactApiId == null) || (this.ContactApiId?.Equals(other.ContactApiId) == true)) &&
                ((this.PrimaryLocationApiId == null && other.PrimaryLocationApiId == null) || (this.PrimaryLocationApiId?.Equals(other.PrimaryLocationApiId) == true)) &&
                ((this.StatusId == null && other.StatusId == null) || (this.StatusId?.Equals(other.StatusId) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.LoginAttempts == null && other.LoginAttempts == null) || (this.LoginAttempts?.Equals(other.LoginAttempts) == true)) &&
                ((this.LastLoginTs == null && other.LastLoginTs == null) || (this.LastLoginTs?.Equals(other.LastLoginTs) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.ModifiedTs == null && other.ModifiedTs == null) || (this.ModifiedTs?.Equals(other.ModifiedTs) == true)) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true)) &&
                ((this.TermsAcceptedTs == null && other.TermsAcceptedTs == null) || (this.TermsAcceptedTs?.Equals(other.TermsAcceptedTs) == true)) &&
                ((this.TermsAgreeIp == null && other.TermsAgreeIp == null) || (this.TermsAgreeIp?.Equals(other.TermsAgreeIp) == true)) &&
                ((this.CurrentDateTime == null && other.CurrentDateTime == null) || (this.CurrentDateTime?.Equals(other.CurrentDateTime) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AccountNumber = {(this.AccountNumber == null ? "null" : this.AccountNumber == string.Empty ? "" : this.AccountNumber)}");
            toStringOutput.Add($"this.Address = {(this.Address == null ? "null" : this.Address == string.Empty ? "" : this.Address)}");
            toStringOutput.Add($"this.BrandingDomainUrl = {(this.BrandingDomainUrl == null ? "null" : this.BrandingDomainUrl == string.Empty ? "" : this.BrandingDomainUrl)}");
            toStringOutput.Add($"this.CellPhone = {(this.CellPhone == null ? "null" : this.CellPhone == string.Empty ? "" : this.CellPhone)}");
            toStringOutput.Add($"this.City = {(this.City == null ? "null" : this.City == string.Empty ? "" : this.City)}");
            toStringOutput.Add($"this.CompanyName = {(this.CompanyName == null ? "null" : this.CompanyName == string.Empty ? "" : this.CompanyName)}");
            toStringOutput.Add($"this.ContactId = {(this.ContactId == null ? "null" : this.ContactId == string.Empty ? "" : this.ContactId)}");
            toStringOutput.Add($"this.DateOfBirth = {(this.DateOfBirth == null ? "null" : this.DateOfBirth == string.Empty ? "" : this.DateOfBirth)}");
            toStringOutput.Add($"this.DomainId = {(this.DomainId == null ? "null" : this.DomainId == string.Empty ? "" : this.DomainId)}");
            toStringOutput.Add($"this.Email = {(this.Email == null ? "null" : this.Email == string.Empty ? "" : this.Email)}");
            toStringOutput.Add($"this.EmailTrxReceipt = {(this.EmailTrxReceipt == null ? "null" : this.EmailTrxReceipt.ToString())}");
            toStringOutput.Add($"this.HomePhone = {(this.HomePhone == null ? "null" : this.HomePhone == string.Empty ? "" : this.HomePhone)}");
            toStringOutput.Add($"this.FirstName = {(this.FirstName == null ? "null" : this.FirstName == string.Empty ? "" : this.FirstName)}");
            toStringOutput.Add($"this.LastName = {(this.LastName == null ? "null" : this.LastName == string.Empty ? "" : this.LastName)}");
            toStringOutput.Add($"this.Locale = {(this.Locale == null ? "null" : this.Locale == string.Empty ? "" : this.Locale)}");
            toStringOutput.Add($"this.OfficePhone = {(this.OfficePhone == null ? "null" : this.OfficePhone == string.Empty ? "" : this.OfficePhone)}");
            toStringOutput.Add($"this.OfficeExtPhone = {(this.OfficeExtPhone == null ? "null" : this.OfficeExtPhone == string.Empty ? "" : this.OfficeExtPhone)}");
            toStringOutput.Add($"this.PrimaryLocationId = {(this.PrimaryLocationId == null ? "null" : this.PrimaryLocationId == string.Empty ? "" : this.PrimaryLocationId)}");
            toStringOutput.Add($"this.RequiresNewPassword = {(this.RequiresNewPassword == null ? "null" : this.RequiresNewPassword == string.Empty ? "" : this.RequiresNewPassword)}");
            toStringOutput.Add($"this.State = {(this.State == null ? "null" : this.State == string.Empty ? "" : this.State)}");
            toStringOutput.Add($"this.TermsConditionId = {(this.TermsConditionId == null ? "null" : this.TermsConditionId == string.Empty ? "" : this.TermsConditionId)}");
            toStringOutput.Add($"this.Tz = {(this.Tz == null ? "null" : this.Tz == string.Empty ? "" : this.Tz)}");
            toStringOutput.Add($"this.UiPrefs = {(this.UiPrefs == null ? "null" : this.UiPrefs.ToString())}");
            toStringOutput.Add($"this.Username = {(this.Username == null ? "null" : this.Username == string.Empty ? "" : this.Username)}");
            toStringOutput.Add($"this.UserApiKey = {(this.UserApiKey == null ? "null" : this.UserApiKey == string.Empty ? "" : this.UserApiKey)}");
            toStringOutput.Add($"this.UserHashKey = {(this.UserHashKey == null ? "null" : this.UserHashKey == string.Empty ? "" : this.UserHashKey)}");
            toStringOutput.Add($"this.UserTypeCode = {(this.UserTypeCode == null ? "null" : this.UserTypeCode.ToString())}");
            toStringOutput.Add($"this.Password = {(this.Password == null ? "null" : this.Password == string.Empty ? "" : this.Password)}");
            toStringOutput.Add($"this.Zip = {(this.Zip == null ? "null" : this.Zip == string.Empty ? "" : this.Zip)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.ContactApiId = {(this.ContactApiId == null ? "null" : this.ContactApiId == string.Empty ? "" : this.ContactApiId)}");
            toStringOutput.Add($"this.PrimaryLocationApiId = {(this.PrimaryLocationApiId == null ? "null" : this.PrimaryLocationApiId == string.Empty ? "" : this.PrimaryLocationApiId)}");
            toStringOutput.Add($"this.StatusId = {(this.StatusId == null ? "null" : this.StatusId.ToString())}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.LoginAttempts = {(this.LoginAttempts == null ? "null" : this.LoginAttempts.ToString())}");
            toStringOutput.Add($"this.LastLoginTs = {(this.LastLoginTs == null ? "null" : this.LastLoginTs.ToString())}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.ModifiedTs = {(this.ModifiedTs == null ? "null" : this.ModifiedTs.ToString())}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId == string.Empty ? "" : this.CreatedUserId)}");
            toStringOutput.Add($"this.TermsAcceptedTs = {(this.TermsAcceptedTs == null ? "null" : this.TermsAcceptedTs.ToString())}");
            toStringOutput.Add($"this.TermsAgreeIp = {(this.TermsAgreeIp == null ? "null" : this.TermsAgreeIp == string.Empty ? "" : this.TermsAgreeIp)}");
            toStringOutput.Add($"this.CurrentDateTime = {(this.CurrentDateTime == null ? "null" : this.CurrentDateTime == string.Empty ? "" : this.CurrentDateTime)}");
        }
    }
}