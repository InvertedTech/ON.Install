// <copyright file="Expand23Enum.cs" company="APIMatic">
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
    /// Expand23Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Expand23Enum
    {
        /// <summary>
        /// LogEmails.
        /// </summary>
        [EnumMember(Value = "log_emails")]
        LogEmails,

        /// <summary>
        /// Contact.
        /// </summary>
        [EnumMember(Value = "contact")]
        Contact,

        /// <summary>
        /// AccountVault.
        /// </summary>
        [EnumMember(Value = "account_vault")]
        AccountVault,

        /// <summary>
        /// CreatedUser.
        /// </summary>
        [EnumMember(Value = "created_user")]
        CreatedUser,

        /// <summary>
        /// Transactions.
        /// </summary>
        [EnumMember(Value = "transactions")]
        Transactions,

        /// <summary>
        /// Signature.
        /// </summary>
        [EnumMember(Value = "signature")]
        Signature,

        /// <summary>
        /// PaymentSchedule.
        /// </summary>
        [EnumMember(Value = "payment_schedule")]
        PaymentSchedule,

        /// <summary>
        /// Location.
        /// </summary>
        [EnumMember(Value = "location")]
        Location,

        /// <summary>
        /// ProductTransaction.
        /// </summary>
        [EnumMember(Value = "product_transaction")]
        ProductTransaction,

        /// <summary>
        /// NextRunDateMin.
        /// </summary>
        [EnumMember(Value = "next_run_date_min")]
        NextRunDateMin,

        /// <summary>
        /// NextRunDateMax.
        /// </summary>
        [EnumMember(Value = "next_run_date_max")]
        NextRunDateMax,

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
        /// Changelogs.
        /// </summary>
        [EnumMember(Value = "changelogs")]
        Changelogs,

        /// <summary>
        /// Forecast.
        /// </summary>
        [EnumMember(Value = "forecast")]
        Forecast,

        /// <summary>
        /// RecurringSplits.
        /// </summary>
        [EnumMember(Value = "recurring_splits")]
        RecurringSplits
    }
}