// <copyright file="Field54Enum.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using APIMatic.Core.Utilities.Converters;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;

    /// <summary>
    /// Field54Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Field54Enum
    {
        /// <summary>
        /// AccountNumber.
        /// </summary>
        [EnumMember(Value = "account_number")]
        AccountNumber,

        /// <summary>
        /// BrandingDomainUrl.
        /// </summary>
        [EnumMember(Value = "branding_domain_url")]
        BrandingDomainUrl,

        /// <summary>
        /// CellPhone.
        /// </summary>
        [EnumMember(Value = "cell_phone")]
        CellPhone,

        /// <summary>
        /// CompanyName.
        /// </summary>
        [EnumMember(Value = "company_name")]
        CompanyName,

        /// <summary>
        /// ContactId.
        /// </summary>
        [EnumMember(Value = "contact_id")]
        ContactId,

        /// <summary>
        /// DateOfBirth.
        /// </summary>
        [EnumMember(Value = "date_of_birth")]
        DateOfBirth,

        /// <summary>
        /// DomainId.
        /// </summary>
        [EnumMember(Value = "domain_id")]
        DomainId,

        /// <summary>
        /// Email.
        /// </summary>
        [EnumMember(Value = "email")]
        Email,

        /// <summary>
        /// EmailTrxReceipt.
        /// </summary>
        [EnumMember(Value = "email_trx_receipt")]
        EmailTrxReceipt,

        /// <summary>
        /// HomePhone.
        /// </summary>
        [EnumMember(Value = "home_phone")]
        HomePhone,

        /// <summary>
        /// FirstName.
        /// </summary>
        [EnumMember(Value = "first_name")]
        FirstName,

        /// <summary>
        /// LastName.
        /// </summary>
        [EnumMember(Value = "last_name")]
        LastName,

        /// <summary>
        /// Locale.
        /// </summary>
        [EnumMember(Value = "locale")]
        Locale,

        /// <summary>
        /// OfficePhone.
        /// </summary>
        [EnumMember(Value = "office_phone")]
        OfficePhone,

        /// <summary>
        /// OfficeExtPhone.
        /// </summary>
        [EnumMember(Value = "office_ext_phone")]
        OfficeExtPhone,

        /// <summary>
        /// PrimaryLocationId.
        /// </summary>
        [EnumMember(Value = "primary_location_id")]
        PrimaryLocationId,

        /// <summary>
        /// RequiresNewPassword.
        /// </summary>
        [EnumMember(Value = "requires_new_password")]
        RequiresNewPassword,

        /// <summary>
        /// TermsConditionCode.
        /// </summary>
        [EnumMember(Value = "terms_condition_code")]
        TermsConditionCode,

        /// <summary>
        /// Tz.
        /// </summary>
        [EnumMember(Value = "tz")]
        Tz,

        /// <summary>
        /// UiPrefs.
        /// </summary>
        [EnumMember(Value = "ui_prefs")]
        UiPrefs,

        /// <summary>
        /// Username.
        /// </summary>
        [EnumMember(Value = "username")]
        Username,

        /// <summary>
        /// UserApiKey.
        /// </summary>
        [EnumMember(Value = "user_api_key")]
        UserApiKey,

        /// <summary>
        /// UserHashKey.
        /// </summary>
        [EnumMember(Value = "user_hash_key")]
        UserHashKey,

        /// <summary>
        /// UserTypeCode.
        /// </summary>
        [EnumMember(Value = "user_type_code")]
        UserTypeCode,

        /// <summary>
        /// Password.
        /// </summary>
        [EnumMember(Value = "password")]
        Password,

        /// <summary>
        /// Zip.
        /// </summary>
        [EnumMember(Value = "zip")]
        Zip,

        /// <summary>
        /// LocationId.
        /// </summary>
        [EnumMember(Value = "location_id")]
        LocationId,

        /// <summary>
        /// ContactApiId.
        /// </summary>
        [EnumMember(Value = "contact_api_id")]
        ContactApiId,

        /// <summary>
        /// PrimaryLocationApiId.
        /// </summary>
        [EnumMember(Value = "primary_location_api_id")]
        PrimaryLocationApiId,

        /// <summary>
        /// StatusCode.
        /// </summary>
        [EnumMember(Value = "status_code")]
        StatusCode,

        /// <summary>
        /// ApiOnly.
        /// </summary>
        [EnumMember(Value = "api_only")]
        ApiOnly,

        /// <summary>
        /// IsInvitation.
        /// </summary>
        [EnumMember(Value = "is_invitation")]
        IsInvitation,

        /// <summary>
        /// Address.
        /// </summary>
        [EnumMember(Value = "address")]
        Address,

        /// <summary>
        /// Id.
        /// </summary>
        [EnumMember(Value = "id")]
        Id,

        /// <summary>
        /// Status.
        /// </summary>
        [EnumMember(Value = "status")]
        Status,

        /// <summary>
        /// LoginAttempts.
        /// </summary>
        [EnumMember(Value = "login_attempts")]
        LoginAttempts,

        /// <summary>
        /// LastLoginTs.
        /// </summary>
        [EnumMember(Value = "last_login_ts")]
        LastLoginTs,

        /// <summary>
        /// CreatedTs.
        /// </summary>
        [EnumMember(Value = "created_ts")]
        CreatedTs,

        /// <summary>
        /// ModifiedTs.
        /// </summary>
        [EnumMember(Value = "modified_ts")]
        ModifiedTs,

        /// <summary>
        /// CreatedUserId.
        /// </summary>
        [EnumMember(Value = "created_user_id")]
        CreatedUserId,

        /// <summary>
        /// TermsAcceptedTs.
        /// </summary>
        [EnumMember(Value = "terms_accepted_ts")]
        TermsAcceptedTs,

        /// <summary>
        /// TermsAgreeIp.
        /// </summary>
        [EnumMember(Value = "terms_agree_ip")]
        TermsAgreeIp,

        /// <summary>
        /// CurrentDateTime.
        /// </summary>
        [EnumMember(Value = "current_date_time")]
        CurrentDateTime,

        /// <summary>
        /// CurrentLoginIp.
        /// </summary>
        [EnumMember(Value = "current_login_ip")]
        CurrentLoginIp,

        /// <summary>
        /// CurrentLogin.
        /// </summary>
        [EnumMember(Value = "current_login")]
        CurrentLogin,

        /// <summary>
        /// SftpAccess.
        /// </summary>
        [EnumMember(Value = "sftp_access")]
        SftpAccess,

        /// <summary>
        /// LogApiResponseBodyTs.
        /// </summary>
        [EnumMember(Value = "log_api_response_body_ts")]
        LogApiResponseBodyTs,

        /// <summary>
        /// Locations.
        /// </summary>
        [EnumMember(Value = "locations")]
        Locations,

        /// <summary>
        /// PrimaryLocation.
        /// </summary>
        [EnumMember(Value = "primary_location")]
        PrimaryLocation,

        /// <summary>
        /// ReceivedEmails.
        /// </summary>
        [EnumMember(Value = "received_emails")]
        ReceivedEmails,

        /// <summary>
        /// Contact.
        /// </summary>
        [EnumMember(Value = "contact")]
        Contact,

        /// <summary>
        /// IsDeletable.
        /// </summary>
        [EnumMember(Value = "isDeletable")]
        IsDeletable,

        /// <summary>
        /// ActiveNotificationAlerts.
        /// </summary>
        [EnumMember(Value = "active_notification_alerts")]
        ActiveNotificationAlerts,

        /// <summary>
        /// LocationUsers.
        /// </summary>
        [EnumMember(Value = "location_users")]
        LocationUsers,

        /// <summary>
        /// AuthRoles.
        /// </summary>
        [EnumMember(Value = "auth_roles")]
        AuthRoles,

        /// <summary>
        /// Changelogs.
        /// </summary>
        [EnumMember(Value = "changelogs")]
        Changelogs,

        /// <summary>
        /// Resources.
        /// </summary>
        [EnumMember(Value = "resources")]
        Resources,

        /// <summary>
        /// Domain.
        /// </summary>
        [EnumMember(Value = "domain")]
        Domain,

        /// <summary>
        /// CreatedUser.
        /// </summary>
        [EnumMember(Value = "created_user")]
        CreatedUser,

        /// <summary>
        /// LocationMarketplaces.
        /// </summary>
        [EnumMember(Value = "location_marketplaces")]
        LocationMarketplaces,

        /// <summary>
        /// EmailBlacklist.
        /// </summary>
        [EnumMember(Value = "email_blacklist")]
        EmailBlacklist,

        /// <summary>
        /// Helppage.
        /// </summary>
        [EnumMember(Value = "helppage")]
        Helppage,

        /// <summary>
        /// FeatureFlags.
        /// </summary>
        [EnumMember(Value = "feature_flags")]
        FeatureFlags
    }
}