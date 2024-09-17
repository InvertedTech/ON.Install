// <copyright file="Expand1Enum.cs" company="APIMatic">
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
    /// Expand1Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Expand1Enum
    {
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