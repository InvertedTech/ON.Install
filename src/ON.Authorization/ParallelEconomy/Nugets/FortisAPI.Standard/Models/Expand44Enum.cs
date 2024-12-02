// <copyright file="Expand44Enum.cs" company="APIMatic">
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
    /// Expand44Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Expand44Enum
    {
        /// <summary>
        /// Location.
        /// </summary>
        [EnumMember(Value = "location")]
        Location,

        /// <summary>
        /// Contact.
        /// </summary>
        [EnumMember(Value = "contact")]
        Contact,

        /// <summary>
        /// Transactions.
        /// </summary>
        [EnumMember(Value = "transactions")]
        Transactions,

        /// <summary>
        /// ActiveRecurrings.
        /// </summary>
        [EnumMember(Value = "activeRecurrings")]
        ActiveRecurrings,

        /// <summary>
        /// IsDeletable.
        /// </summary>
        [EnumMember(Value = "is_deletable")]
        IsDeletable,

        /// <summary>
        /// Signature.
        /// </summary>
        [EnumMember(Value = "signature")]
        Signature,

        /// <summary>
        /// CreatedUser.
        /// </summary>
        [EnumMember(Value = "created_user")]
        CreatedUser,

        /// <summary>
        /// Changelogs.
        /// </summary>
        [EnumMember(Value = "changelogs")]
        Changelogs,

        /// <summary>
        /// AccountVaultCauLogs.
        /// </summary>
        [EnumMember(Value = "account_vault_cau_logs")]
        AccountVaultCauLogs,

        /// <summary>
        /// AccountVaultCauProductTransactions.
        /// </summary>
        [EnumMember(Value = "account_vault_cau_product_transactions")]
        AccountVaultCauProductTransactions
    }
}