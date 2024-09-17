// <copyright file="Expand15Enum.cs" company="APIMatic">
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
    /// Expand15Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Expand15Enum
    {
        /// <summary>
        /// Tags.
        /// </summary>
        [EnumMember(Value = "tags")]
        Tags,

        /// <summary>
        /// AllTags.
        /// </summary>
        [EnumMember(Value = "all_tags")]
        AllTags,

        /// <summary>
        /// Location.
        /// </summary>
        [EnumMember(Value = "location")]
        Location,

        /// <summary>
        /// CreatedUser.
        /// </summary>
        [EnumMember(Value = "created_user")]
        CreatedUser,

        /// <summary>
        /// ModifiedUser.
        /// </summary>
        [EnumMember(Value = "modified_user")]
        ModifiedUser,

        /// <summary>
        /// Changelogs.
        /// </summary>
        [EnumMember(Value = "changelogs")]
        Changelogs,

        /// <summary>
        /// Contact.
        /// </summary>
        [EnumMember(Value = "contact")]
        Contact,

        /// <summary>
        /// LogEmails.
        /// </summary>
        [EnumMember(Value = "log_emails")]
        LogEmails,

        /// <summary>
        /// LogSms.
        /// </summary>
        [EnumMember(Value = "log_sms")]
        LogSms,

        /// <summary>
        /// Transactions.
        /// </summary>
        [EnumMember(Value = "transactions")]
        Transactions,

        /// <summary>
        /// CcProductTransaction.
        /// </summary>
        [EnumMember(Value = "cc_product_transaction")]
        CcProductTransaction,

        /// <summary>
        /// AchProductTransaction.
        /// </summary>
        [EnumMember(Value = "ach_product_transaction")]
        AchProductTransaction,

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
        /// PaymentUrl.
        /// </summary>
        [EnumMember(Value = "payment_url")]
        PaymentUrl
    }
}