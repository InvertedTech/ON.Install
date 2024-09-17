// <copyright file="User1.cs" company="APIMatic">
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
    /// User1.
    /// </summary>
    public class User1 : BaseModel
    {
        private string accountNumber;
        private string brandingDomainUrl;
        private string cellPhone;
        private string companyName;
        private string contactId;
        private string dateOfBirth;
        private string domainId;
        private string homePhone;
        private string firstName;
        private string locale;
        private string officePhone;
        private string officeExtPhone;
        private string requiresNewPassword;
        private string termsConditionCode;
        private string userApiKey;
        private string userHashKey;
        private string password;
        private string zip;
        private string locationId;
        private string contactApiId;
        private string primaryLocationApiId;
        private Models.StatusCodeEnum? statusCode;
        private int? termsAcceptedTs;
        private string termsAgreeIp;
        private string currentLoginIp;
        private int? currentLogin;
        private int? logApiResponseBodyTs;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "account_number", false },
            { "branding_domain_url", false },
            { "cell_phone", false },
            { "company_name", false },
            { "contact_id", false },
            { "date_of_birth", false },
            { "domain_id", false },
            { "home_phone", false },
            { "first_name", false },
            { "locale", false },
            { "office_phone", false },
            { "office_ext_phone", false },
            { "requires_new_password", false },
            { "terms_condition_code", false },
            { "user_api_key", false },
            { "user_hash_key", false },
            { "password", false },
            { "zip", false },
            { "location_id", false },
            { "contact_api_id", false },
            { "primary_location_api_id", false },
            { "status_code", false },
            { "terms_accepted_ts", false },
            { "terms_agree_ip", false },
            { "current_login_ip", false },
            { "current_login", false },
            { "log_api_response_body_ts", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="User1"/> class.
        /// </summary>
        public User1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User1"/> class.
        /// </summary>
        /// <param name="email">email.</param>
        /// <param name="lastName">last_name.</param>
        /// <param name="primaryLocationId">primary_location_id.</param>
        /// <param name="tz">tz.</param>
        /// <param name="username">username.</param>
        /// <param name="userTypeCode">user_type_code.</param>
        /// <param name="id">id.</param>
        /// <param name="status">status.</param>
        /// <param name="loginAttempts">login_attempts.</param>
        /// <param name="lastLoginTs">last_login_ts.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="currentDateTime">current_date_time.</param>
        /// <param name="accountNumber">account_number.</param>
        /// <param name="brandingDomainUrl">branding_domain_url.</param>
        /// <param name="cellPhone">cell_phone.</param>
        /// <param name="companyName">company_name.</param>
        /// <param name="contactId">contact_id.</param>
        /// <param name="dateOfBirth">date_of_birth.</param>
        /// <param name="domainId">domain_id.</param>
        /// <param name="emailTrxReceipt">email_trx_receipt.</param>
        /// <param name="homePhone">home_phone.</param>
        /// <param name="firstName">first_name.</param>
        /// <param name="locale">locale.</param>
        /// <param name="officePhone">office_phone.</param>
        /// <param name="officeExtPhone">office_ext_phone.</param>
        /// <param name="requiresNewPassword">requires_new_password.</param>
        /// <param name="termsConditionCode">terms_condition_code.</param>
        /// <param name="uiPrefs">ui_prefs.</param>
        /// <param name="userApiKey">user_api_key.</param>
        /// <param name="userHashKey">user_hash_key.</param>
        /// <param name="password">password.</param>
        /// <param name="zip">zip.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="contactApiId">contact_api_id.</param>
        /// <param name="primaryLocationApiId">primary_location_api_id.</param>
        /// <param name="statusCode">status_code.</param>
        /// <param name="apiOnly">api_only.</param>
        /// <param name="isInvitation">is_invitation.</param>
        /// <param name="address">address.</param>
        /// <param name="termsAcceptedTs">terms_accepted_ts.</param>
        /// <param name="termsAgreeIp">terms_agree_ip.</param>
        /// <param name="currentLoginIp">current_login_ip.</param>
        /// <param name="currentLogin">current_login.</param>
        /// <param name="sftpAccess">sftp_access.</param>
        /// <param name="logApiResponseBodyTs">log_api_response_body_ts.</param>
        public User1(
            string email,
            string lastName,
            string primaryLocationId,
            string tz,
            string username,
            Models.UserTypeCodeEnum userTypeCode,
            string id,
            bool status,
            int loginAttempts,
            int lastLoginTs,
            int createdTs,
            int modifiedTs,
            string createdUserId,
            string currentDateTime,
            string accountNumber = null,
            string brandingDomainUrl = null,
            string cellPhone = null,
            string companyName = null,
            string contactId = null,
            string dateOfBirth = null,
            string domainId = null,
            bool? emailTrxReceipt = null,
            string homePhone = null,
            string firstName = null,
            string locale = null,
            string officePhone = null,
            string officeExtPhone = null,
            string requiresNewPassword = null,
            string termsConditionCode = null,
            Models.UiPrefs uiPrefs = null,
            string userApiKey = null,
            string userHashKey = null,
            string password = null,
            string zip = null,
            string locationId = null,
            string contactApiId = null,
            string primaryLocationApiId = null,
            Models.StatusCodeEnum? statusCode = null,
            bool? apiOnly = null,
            bool? isInvitation = null,
            Models.Address2 address = null,
            int? termsAcceptedTs = null,
            string termsAgreeIp = null,
            string currentLoginIp = null,
            int? currentLogin = null,
            bool? sftpAccess = null,
            int? logApiResponseBodyTs = null)
        {
            if (accountNumber != null)
            {
                this.AccountNumber = accountNumber;
            }

            if (brandingDomainUrl != null)
            {
                this.BrandingDomainUrl = brandingDomainUrl;
            }

            if (cellPhone != null)
            {
                this.CellPhone = cellPhone;
            }

            if (companyName != null)
            {
                this.CompanyName = companyName;
            }

            if (contactId != null)
            {
                this.ContactId = contactId;
            }

            if (dateOfBirth != null)
            {
                this.DateOfBirth = dateOfBirth;
            }

            if (domainId != null)
            {
                this.DomainId = domainId;
            }

            this.Email = email;
            this.EmailTrxReceipt = emailTrxReceipt;
            if (homePhone != null)
            {
                this.HomePhone = homePhone;
            }

            if (firstName != null)
            {
                this.FirstName = firstName;
            }

            this.LastName = lastName;
            if (locale != null)
            {
                this.Locale = locale;
            }

            if (officePhone != null)
            {
                this.OfficePhone = officePhone;
            }

            if (officeExtPhone != null)
            {
                this.OfficeExtPhone = officeExtPhone;
            }

            this.PrimaryLocationId = primaryLocationId;
            if (requiresNewPassword != null)
            {
                this.RequiresNewPassword = requiresNewPassword;
            }

            if (termsConditionCode != null)
            {
                this.TermsConditionCode = termsConditionCode;
            }

            this.Tz = tz;
            this.UiPrefs = uiPrefs;
            this.Username = username;
            if (userApiKey != null)
            {
                this.UserApiKey = userApiKey;
            }

            if (userHashKey != null)
            {
                this.UserHashKey = userHashKey;
            }

            this.UserTypeCode = userTypeCode;
            if (password != null)
            {
                this.Password = password;
            }

            if (zip != null)
            {
                this.Zip = zip;
            }

            if (locationId != null)
            {
                this.LocationId = locationId;
            }

            if (contactApiId != null)
            {
                this.ContactApiId = contactApiId;
            }

            if (primaryLocationApiId != null)
            {
                this.PrimaryLocationApiId = primaryLocationApiId;
            }

            if (statusCode != null)
            {
                this.StatusCode = statusCode;
            }

            this.ApiOnly = apiOnly;
            this.IsInvitation = isInvitation;
            this.Address = address;
            this.Id = id;
            this.Status = status;
            this.LoginAttempts = loginAttempts;
            this.LastLoginTs = lastLoginTs;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            this.CreatedUserId = createdUserId;
            if (termsAcceptedTs != null)
            {
                this.TermsAcceptedTs = termsAcceptedTs;
            }

            if (termsAgreeIp != null)
            {
                this.TermsAgreeIp = termsAgreeIp;
            }

            this.CurrentDateTime = currentDateTime;
            if (currentLoginIp != null)
            {
                this.CurrentLoginIp = currentLoginIp;
            }

            if (currentLogin != null)
            {
                this.CurrentLogin = currentLogin;
            }

            this.SftpAccess = sftpAccess;
            if (logApiResponseBodyTs != null)
            {
                this.LogApiResponseBodyTs = logApiResponseBodyTs;
            }

        }

        /// <summary>
        /// Account Number
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
        /// Branding Domain Url
        /// </summary>
        [JsonProperty("branding_domain_url")]
        public string BrandingDomainUrl
        {
            get
            {
                return this.brandingDomainUrl;
            }

            set
            {
                this.shouldSerialize["branding_domain_url"] = true;
                this.brandingDomainUrl = value;
            }
        }

        /// <summary>
        /// Cell Phone
        /// </summary>
        [JsonProperty("cell_phone")]
        public string CellPhone
        {
            get
            {
                return this.cellPhone;
            }

            set
            {
                this.shouldSerialize["cell_phone"] = true;
                this.cellPhone = value;
            }
        }

        /// <summary>
        /// Company Name
        /// </summary>
        [JsonProperty("company_name")]
        public string CompanyName
        {
            get
            {
                return this.companyName;
            }

            set
            {
                this.shouldSerialize["company_name"] = true;
                this.companyName = value;
            }
        }

        /// <summary>
        /// Contact
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
        /// Date Of Birth
        /// </summary>
        [JsonProperty("date_of_birth")]
        public string DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }

            set
            {
                this.shouldSerialize["date_of_birth"] = true;
                this.dateOfBirth = value;
            }
        }

        /// <summary>
        /// Domain
        /// </summary>
        [JsonProperty("domain_id")]
        public string DomainId
        {
            get
            {
                return this.domainId;
            }

            set
            {
                this.shouldSerialize["domain_id"] = true;
                this.domainId = value;
            }
        }

        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Email Trx Receipt
        /// </summary>
        [JsonProperty("email_trx_receipt", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EmailTrxReceipt { get; set; }

        /// <summary>
        /// Home Phone
        /// </summary>
        [JsonProperty("home_phone")]
        public string HomePhone
        {
            get
            {
                return this.homePhone;
            }

            set
            {
                this.shouldSerialize["home_phone"] = true;
                this.homePhone = value;
            }
        }

        /// <summary>
        /// First Name
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.shouldSerialize["first_name"] = true;
                this.firstName = value;
            }
        }

        /// <summary>
        /// Last Name
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Locale
        /// </summary>
        [JsonProperty("locale")]
        public string Locale
        {
            get
            {
                return this.locale;
            }

            set
            {
                this.shouldSerialize["locale"] = true;
                this.locale = value;
            }
        }

        /// <summary>
        /// Office Phone
        /// </summary>
        [JsonProperty("office_phone")]
        public string OfficePhone
        {
            get
            {
                return this.officePhone;
            }

            set
            {
                this.shouldSerialize["office_phone"] = true;
                this.officePhone = value;
            }
        }

        /// <summary>
        /// Office Ext Phone
        /// </summary>
        [JsonProperty("office_ext_phone")]
        public string OfficeExtPhone
        {
            get
            {
                return this.officeExtPhone;
            }

            set
            {
                this.shouldSerialize["office_ext_phone"] = true;
                this.officeExtPhone = value;
            }
        }

        /// <summary>
        /// Primary Location ID
        /// </summary>
        [JsonProperty("primary_location_id")]
        public string PrimaryLocationId { get; set; }

        /// <summary>
        /// Requires New Password
        /// </summary>
        [JsonProperty("requires_new_password")]
        public string RequiresNewPassword
        {
            get
            {
                return this.requiresNewPassword;
            }

            set
            {
                this.shouldSerialize["requires_new_password"] = true;
                this.requiresNewPassword = value;
            }
        }

        /// <summary>
        /// Terms Condition (This field is required when updating your own password).
        /// </summary>
        [JsonProperty("terms_condition_code")]
        public string TermsConditionCode
        {
            get
            {
                return this.termsConditionCode;
            }

            set
            {
                this.shouldSerialize["terms_condition_code"] = true;
                this.termsConditionCode = value;
            }
        }

        /// <summary>
        /// Time zone
        /// </summary>
        [JsonProperty("tz")]
        public string Tz { get; set; }

        /// <summary>
        /// Ui Prefs
        /// </summary>
        [JsonProperty("ui_prefs", NullValueHandling = NullValueHandling.Ignore)]
        public Models.UiPrefs UiPrefs { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// User Api Key
        /// </summary>
        [JsonProperty("user_api_key")]
        public string UserApiKey
        {
            get
            {
                return this.userApiKey;
            }

            set
            {
                this.shouldSerialize["user_api_key"] = true;
                this.userApiKey = value;
            }
        }

        /// <summary>
        /// User Hash Key
        /// </summary>
        [JsonProperty("user_hash_key")]
        public string UserHashKey
        {
            get
            {
                return this.userHashKey;
            }

            set
            {
                this.shouldSerialize["user_hash_key"] = true;
                this.userHashKey = value;
            }
        }

        /// <summary>
        /// User Type
        /// </summary>
        [JsonProperty("user_type_code")]
        public Models.UserTypeCodeEnum UserTypeCode { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [JsonProperty("password")]
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.shouldSerialize["password"] = true;
                this.password = value;
            }
        }

        /// <summary>
        /// Zip
        /// </summary>
        [JsonProperty("zip")]
        public string Zip
        {
            get
            {
                return this.zip;
            }

            set
            {
                this.shouldSerialize["zip"] = true;
                this.zip = value;
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
        /// ContactApi Id
        /// </summary>
        [JsonProperty("contact_api_id")]
        public string ContactApiId
        {
            get
            {
                return this.contactApiId;
            }

            set
            {
                this.shouldSerialize["contact_api_id"] = true;
                this.contactApiId = value;
            }
        }

        /// <summary>
        /// Primary LocationApi ID
        /// </summary>
        [JsonProperty("primary_location_api_id")]
        public string PrimaryLocationApiId
        {
            get
            {
                return this.primaryLocationApiId;
            }

            set
            {
                this.shouldSerialize["primary_location_api_id"] = true;
                this.primaryLocationApiId = value;
            }
        }

        /// <summary>
        /// Status Code
        /// </summary>
        [JsonProperty("status_code")]
        public Models.StatusCodeEnum? StatusCode
        {
            get
            {
                return this.statusCode;
            }

            set
            {
                this.shouldSerialize["status_code"] = true;
                this.statusCode = value;
            }
        }

        /// <summary>
        /// API Only
        /// </summary>
        [JsonProperty("api_only", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ApiOnly { get; set; }

        /// <summary>
        /// Is Invitation
        /// </summary>
        [JsonProperty("is_invitation", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsInvitation { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address2 Address { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [JsonProperty("status")]
        public bool Status { get; set; }

        /// <summary>
        /// Login Attempts
        /// </summary>
        [JsonProperty("login_attempts")]
        public int LoginAttempts { get; set; }

        /// <summary>
        /// Last Login
        /// </summary>
        [JsonProperty("last_login_ts")]
        public int LastLoginTs { get; set; }

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
        /// Created User
        /// </summary>
        [JsonProperty("created_user_id")]
        public string CreatedUserId { get; set; }

        /// <summary>
        /// Terms Accepted
        /// </summary>
        [JsonProperty("terms_accepted_ts")]
        public int? TermsAcceptedTs
        {
            get
            {
                return this.termsAcceptedTs;
            }

            set
            {
                this.shouldSerialize["terms_accepted_ts"] = true;
                this.termsAcceptedTs = value;
            }
        }

        /// <summary>
        /// Terms Agree Ip
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
        /// Current Date Time
        /// </summary>
        [JsonProperty("current_date_time")]
        public string CurrentDateTime { get; set; }

        /// <summary>
        /// Current Login Ip
        /// </summary>
        [JsonProperty("current_login_ip")]
        public string CurrentLoginIp
        {
            get
            {
                return this.currentLoginIp;
            }

            set
            {
                this.shouldSerialize["current_login_ip"] = true;
                this.currentLoginIp = value;
            }
        }

        /// <summary>
        /// Current Login Timestamp
        /// </summary>
        [JsonProperty("current_login")]
        public int? CurrentLogin
        {
            get
            {
                return this.currentLogin;
            }

            set
            {
                this.shouldSerialize["current_login"] = true;
                this.currentLogin = value;
            }
        }

        /// <summary>
        /// SFTP Access
        /// </summary>
        [JsonProperty("sftp_access", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SftpAccess { get; set; }

        /// <summary>
        /// Log Api Response Body
        /// </summary>
        [JsonProperty("log_api_response_body_ts")]
        public int? LogApiResponseBodyTs
        {
            get
            {
                return this.logApiResponseBodyTs;
            }

            set
            {
                this.shouldSerialize["log_api_response_body_ts"] = true;
                this.logApiResponseBodyTs = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"User1 : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetBrandingDomainUrl()
        {
            this.shouldSerialize["branding_domain_url"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCellPhone()
        {
            this.shouldSerialize["cell_phone"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCompanyName()
        {
            this.shouldSerialize["company_name"] = false;
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
        public void UnsetDateOfBirth()
        {
            this.shouldSerialize["date_of_birth"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDomainId()
        {
            this.shouldSerialize["domain_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetHomePhone()
        {
            this.shouldSerialize["home_phone"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFirstName()
        {
            this.shouldSerialize["first_name"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocale()
        {
            this.shouldSerialize["locale"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetOfficePhone()
        {
            this.shouldSerialize["office_phone"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetOfficeExtPhone()
        {
            this.shouldSerialize["office_ext_phone"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRequiresNewPassword()
        {
            this.shouldSerialize["requires_new_password"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTermsConditionCode()
        {
            this.shouldSerialize["terms_condition_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetUserApiKey()
        {
            this.shouldSerialize["user_api_key"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetUserHashKey()
        {
            this.shouldSerialize["user_hash_key"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPassword()
        {
            this.shouldSerialize["password"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetZip()
        {
            this.shouldSerialize["zip"] = false;
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
        public void UnsetContactApiId()
        {
            this.shouldSerialize["contact_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPrimaryLocationApiId()
        {
            this.shouldSerialize["primary_location_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetStatusCode()
        {
            this.shouldSerialize["status_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTermsAcceptedTs()
        {
            this.shouldSerialize["terms_accepted_ts"] = false;
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
        public void UnsetCurrentLoginIp()
        {
            this.shouldSerialize["current_login_ip"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCurrentLogin()
        {
            this.shouldSerialize["current_login"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLogApiResponseBodyTs()
        {
            this.shouldSerialize["log_api_response_body_ts"] = false;
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
        public bool ShouldSerializeBrandingDomainUrl()
        {
            return this.shouldSerialize["branding_domain_url"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCellPhone()
        {
            return this.shouldSerialize["cell_phone"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCompanyName()
        {
            return this.shouldSerialize["company_name"];
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
        public bool ShouldSerializeDateOfBirth()
        {
            return this.shouldSerialize["date_of_birth"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDomainId()
        {
            return this.shouldSerialize["domain_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeHomePhone()
        {
            return this.shouldSerialize["home_phone"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFirstName()
        {
            return this.shouldSerialize["first_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocale()
        {
            return this.shouldSerialize["locale"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOfficePhone()
        {
            return this.shouldSerialize["office_phone"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOfficeExtPhone()
        {
            return this.shouldSerialize["office_ext_phone"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRequiresNewPassword()
        {
            return this.shouldSerialize["requires_new_password"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTermsConditionCode()
        {
            return this.shouldSerialize["terms_condition_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUserApiKey()
        {
            return this.shouldSerialize["user_api_key"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUserHashKey()
        {
            return this.shouldSerialize["user_hash_key"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePassword()
        {
            return this.shouldSerialize["password"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeZip()
        {
            return this.shouldSerialize["zip"];
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
        public bool ShouldSerializeContactApiId()
        {
            return this.shouldSerialize["contact_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePrimaryLocationApiId()
        {
            return this.shouldSerialize["primary_location_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStatusCode()
        {
            return this.shouldSerialize["status_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTermsAcceptedTs()
        {
            return this.shouldSerialize["terms_accepted_ts"];
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
        public bool ShouldSerializeCurrentLoginIp()
        {
            return this.shouldSerialize["current_login_ip"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCurrentLogin()
        {
            return this.shouldSerialize["current_login"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLogApiResponseBodyTs()
        {
            return this.shouldSerialize["log_api_response_body_ts"];
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
            return obj is User1 other &&                ((this.AccountNumber == null && other.AccountNumber == null) || (this.AccountNumber?.Equals(other.AccountNumber) == true)) &&
                ((this.BrandingDomainUrl == null && other.BrandingDomainUrl == null) || (this.BrandingDomainUrl?.Equals(other.BrandingDomainUrl) == true)) &&
                ((this.CellPhone == null && other.CellPhone == null) || (this.CellPhone?.Equals(other.CellPhone) == true)) &&
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
                ((this.TermsConditionCode == null && other.TermsConditionCode == null) || (this.TermsConditionCode?.Equals(other.TermsConditionCode) == true)) &&
                ((this.Tz == null && other.Tz == null) || (this.Tz?.Equals(other.Tz) == true)) &&
                ((this.UiPrefs == null && other.UiPrefs == null) || (this.UiPrefs?.Equals(other.UiPrefs) == true)) &&
                ((this.Username == null && other.Username == null) || (this.Username?.Equals(other.Username) == true)) &&
                ((this.UserApiKey == null && other.UserApiKey == null) || (this.UserApiKey?.Equals(other.UserApiKey) == true)) &&
                ((this.UserHashKey == null && other.UserHashKey == null) || (this.UserHashKey?.Equals(other.UserHashKey) == true)) &&
                this.UserTypeCode.Equals(other.UserTypeCode) &&
                ((this.Password == null && other.Password == null) || (this.Password?.Equals(other.Password) == true)) &&
                ((this.Zip == null && other.Zip == null) || (this.Zip?.Equals(other.Zip) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.ContactApiId == null && other.ContactApiId == null) || (this.ContactApiId?.Equals(other.ContactApiId) == true)) &&
                ((this.PrimaryLocationApiId == null && other.PrimaryLocationApiId == null) || (this.PrimaryLocationApiId?.Equals(other.PrimaryLocationApiId) == true)) &&
                ((this.StatusCode == null && other.StatusCode == null) || (this.StatusCode?.Equals(other.StatusCode) == true)) &&
                ((this.ApiOnly == null && other.ApiOnly == null) || (this.ApiOnly?.Equals(other.ApiOnly) == true)) &&
                ((this.IsInvitation == null && other.IsInvitation == null) || (this.IsInvitation?.Equals(other.IsInvitation) == true)) &&
                ((this.Address == null && other.Address == null) || (this.Address?.Equals(other.Address) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.Status.Equals(other.Status) &&
                this.LoginAttempts.Equals(other.LoginAttempts) &&
                this.LastLoginTs.Equals(other.LastLoginTs) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true)) &&
                ((this.TermsAcceptedTs == null && other.TermsAcceptedTs == null) || (this.TermsAcceptedTs?.Equals(other.TermsAcceptedTs) == true)) &&
                ((this.TermsAgreeIp == null && other.TermsAgreeIp == null) || (this.TermsAgreeIp?.Equals(other.TermsAgreeIp) == true)) &&
                ((this.CurrentDateTime == null && other.CurrentDateTime == null) || (this.CurrentDateTime?.Equals(other.CurrentDateTime) == true)) &&
                ((this.CurrentLoginIp == null && other.CurrentLoginIp == null) || (this.CurrentLoginIp?.Equals(other.CurrentLoginIp) == true)) &&
                ((this.CurrentLogin == null && other.CurrentLogin == null) || (this.CurrentLogin?.Equals(other.CurrentLogin) == true)) &&
                ((this.SftpAccess == null && other.SftpAccess == null) || (this.SftpAccess?.Equals(other.SftpAccess) == true)) &&
                ((this.LogApiResponseBodyTs == null && other.LogApiResponseBodyTs == null) || (this.LogApiResponseBodyTs?.Equals(other.LogApiResponseBodyTs) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AccountNumber = {(this.AccountNumber == null ? "null" : this.AccountNumber)}");
            toStringOutput.Add($"this.BrandingDomainUrl = {(this.BrandingDomainUrl == null ? "null" : this.BrandingDomainUrl)}");
            toStringOutput.Add($"this.CellPhone = {(this.CellPhone == null ? "null" : this.CellPhone)}");
            toStringOutput.Add($"this.CompanyName = {(this.CompanyName == null ? "null" : this.CompanyName)}");
            toStringOutput.Add($"this.ContactId = {(this.ContactId == null ? "null" : this.ContactId)}");
            toStringOutput.Add($"this.DateOfBirth = {(this.DateOfBirth == null ? "null" : this.DateOfBirth)}");
            toStringOutput.Add($"this.DomainId = {(this.DomainId == null ? "null" : this.DomainId)}");
            toStringOutput.Add($"this.Email = {(this.Email == null ? "null" : this.Email)}");
            toStringOutput.Add($"this.EmailTrxReceipt = {(this.EmailTrxReceipt == null ? "null" : this.EmailTrxReceipt.ToString())}");
            toStringOutput.Add($"this.HomePhone = {(this.HomePhone == null ? "null" : this.HomePhone)}");
            toStringOutput.Add($"this.FirstName = {(this.FirstName == null ? "null" : this.FirstName)}");
            toStringOutput.Add($"this.LastName = {(this.LastName == null ? "null" : this.LastName)}");
            toStringOutput.Add($"this.Locale = {(this.Locale == null ? "null" : this.Locale)}");
            toStringOutput.Add($"this.OfficePhone = {(this.OfficePhone == null ? "null" : this.OfficePhone)}");
            toStringOutput.Add($"this.OfficeExtPhone = {(this.OfficeExtPhone == null ? "null" : this.OfficeExtPhone)}");
            toStringOutput.Add($"this.PrimaryLocationId = {(this.PrimaryLocationId == null ? "null" : this.PrimaryLocationId)}");
            toStringOutput.Add($"this.RequiresNewPassword = {(this.RequiresNewPassword == null ? "null" : this.RequiresNewPassword)}");
            toStringOutput.Add($"this.TermsConditionCode = {(this.TermsConditionCode == null ? "null" : this.TermsConditionCode)}");
            toStringOutput.Add($"this.Tz = {(this.Tz == null ? "null" : this.Tz)}");
            toStringOutput.Add($"this.UiPrefs = {(this.UiPrefs == null ? "null" : this.UiPrefs.ToString())}");
            toStringOutput.Add($"this.Username = {(this.Username == null ? "null" : this.Username)}");
            toStringOutput.Add($"this.UserApiKey = {(this.UserApiKey == null ? "null" : this.UserApiKey)}");
            toStringOutput.Add($"this.UserHashKey = {(this.UserHashKey == null ? "null" : this.UserHashKey)}");
            toStringOutput.Add($"this.UserTypeCode = {this.UserTypeCode}");
            toStringOutput.Add($"this.Password = {(this.Password == null ? "null" : this.Password)}");
            toStringOutput.Add($"this.Zip = {(this.Zip == null ? "null" : this.Zip)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.ContactApiId = {(this.ContactApiId == null ? "null" : this.ContactApiId)}");
            toStringOutput.Add($"this.PrimaryLocationApiId = {(this.PrimaryLocationApiId == null ? "null" : this.PrimaryLocationApiId)}");
            toStringOutput.Add($"this.StatusCode = {(this.StatusCode == null ? "null" : this.StatusCode.ToString())}");
            toStringOutput.Add($"this.ApiOnly = {(this.ApiOnly == null ? "null" : this.ApiOnly.ToString())}");
            toStringOutput.Add($"this.IsInvitation = {(this.IsInvitation == null ? "null" : this.IsInvitation.ToString())}");
            toStringOutput.Add($"this.Address = {(this.Address == null ? "null" : this.Address.ToString())}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.Status = {this.Status}");
            toStringOutput.Add($"this.LoginAttempts = {this.LoginAttempts}");
            toStringOutput.Add($"this.LastLoginTs = {this.LastLoginTs}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.TermsAcceptedTs = {(this.TermsAcceptedTs == null ? "null" : this.TermsAcceptedTs.ToString())}");
            toStringOutput.Add($"this.TermsAgreeIp = {(this.TermsAgreeIp == null ? "null" : this.TermsAgreeIp)}");
            toStringOutput.Add($"this.CurrentDateTime = {(this.CurrentDateTime == null ? "null" : this.CurrentDateTime)}");
            toStringOutput.Add($"this.CurrentLoginIp = {(this.CurrentLoginIp == null ? "null" : this.CurrentLoginIp)}");
            toStringOutput.Add($"this.CurrentLogin = {(this.CurrentLogin == null ? "null" : this.CurrentLogin.ToString())}");
            toStringOutput.Add($"this.SftpAccess = {(this.SftpAccess == null ? "null" : this.SftpAccess.ToString())}");
            toStringOutput.Add($"this.LogApiResponseBodyTs = {(this.LogApiResponseBodyTs == null ? "null" : this.LogApiResponseBodyTs.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}