// <copyright file="Field26Enum.cs" company="APIMatic">
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
    /// Field26Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Field26Enum
    {
        /// <summary>
        /// LocationId.
        /// </summary>
        [EnumMember(Value = "location_id")]
        LocationId,

        /// <summary>
        /// AccountNumber.
        /// </summary>
        [EnumMember(Value = "account_number")]
        AccountNumber,

        /// <summary>
        /// ContactApiId.
        /// </summary>
        [EnumMember(Value = "contact_api_id")]
        ContactApiId,

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
        /// CellPhone.
        /// </summary>
        [EnumMember(Value = "cell_phone")]
        CellPhone,

        /// <summary>
        /// Balance.
        /// </summary>
        [EnumMember(Value = "balance")]
        Balance,

        /// <summary>
        /// Address.
        /// </summary>
        [EnumMember(Value = "address")]
        Address,

        /// <summary>
        /// CompanyName.
        /// </summary>
        [EnumMember(Value = "company_name")]
        CompanyName,

        /// <summary>
        /// HeaderMessage.
        /// </summary>
        [EnumMember(Value = "header_message")]
        HeaderMessage,

        /// <summary>
        /// DateOfBirth.
        /// </summary>
        [EnumMember(Value = "date_of_birth")]
        DateOfBirth,

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
        /// OfficePhone.
        /// </summary>
        [EnumMember(Value = "office_phone")]
        OfficePhone,

        /// <summary>
        /// OfficePhoneExt.
        /// </summary>
        [EnumMember(Value = "office_phone_ext")]
        OfficePhoneExt,

        /// <summary>
        /// HeaderMessageType.
        /// </summary>
        [EnumMember(Value = "header_message_type")]
        HeaderMessageType,

        /// <summary>
        /// UpdateIfExists.
        /// </summary>
        [EnumMember(Value = "update_if_exists")]
        UpdateIfExists,

        /// <summary>
        /// ContactC1.
        /// </summary>
        [EnumMember(Value = "contact_c1")]
        ContactC1,

        /// <summary>
        /// ContactC2.
        /// </summary>
        [EnumMember(Value = "contact_c2")]
        ContactC2,

        /// <summary>
        /// ContactC3.
        /// </summary>
        [EnumMember(Value = "contact_c3")]
        ContactC3,

        /// <summary>
        /// ParentId.
        /// </summary>
        [EnumMember(Value = "parent_id")]
        ParentId,

        /// <summary>
        /// Email.
        /// </summary>
        [EnumMember(Value = "email")]
        Email,

        /// <summary>
        /// Id.
        /// </summary>
        [EnumMember(Value = "id")]
        Id,

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
        /// Active.
        /// </summary>
        [EnumMember(Value = "active")]
        Active,

        /// <summary>
        /// CreatedUserId.
        /// </summary>
        [EnumMember(Value = "created_user_id")]
        CreatedUserId,

        /// <summary>
        /// ReceivedEmails.
        /// </summary>
        [EnumMember(Value = "received_emails")]
        ReceivedEmails,

        /// <summary>
        /// IsDeletable.
        /// </summary>
        [EnumMember(Value = "is_deletable")]
        IsDeletable,

        /// <summary>
        /// Location.
        /// </summary>
        [EnumMember(Value = "location")]
        Location,

        /// <summary>
        /// User.
        /// </summary>
        [EnumMember(Value = "user")]
        User,

        /// <summary>
        /// Recurrings.
        /// </summary>
        [EnumMember(Value = "recurrings")]
        Recurrings,

        /// <summary>
        /// EmailBlacklist.
        /// </summary>
        [EnumMember(Value = "email_blacklist")]
        EmailBlacklist,

        /// <summary>
        /// SmsBlacklist.
        /// </summary>
        [EnumMember(Value = "sms_blacklist")]
        SmsBlacklist,

        /// <summary>
        /// Changelogs.
        /// </summary>
        [EnumMember(Value = "changelogs")]
        Changelogs,

        /// <summary>
        /// PostbackLogs.
        /// </summary>
        [EnumMember(Value = "postback_logs")]
        PostbackLogs,

        /// <summary>
        /// CreatedUser.
        /// </summary>
        [EnumMember(Value = "created_user")]
        CreatedUser,

        /// <summary>
        /// Parent.
        /// </summary>
        [EnumMember(Value = "parent")]
        Parent,

        /// <summary>
        /// Children.
        /// </summary>
        [EnumMember(Value = "children")]
        Children
    }
}