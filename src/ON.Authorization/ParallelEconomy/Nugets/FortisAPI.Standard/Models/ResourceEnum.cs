// <copyright file="ResourceEnum.cs" company="APIMatic">
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
    /// ResourceEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ResourceEnum
    {
        /// <summary>
        /// Recurring.
        /// </summary>
        [EnumMember(Value = "Recurring")]
        Recurring,

        /// <summary>
        /// Transaction.
        /// </summary>
        [EnumMember(Value = "Transaction")]
        Transaction,

        /// <summary>
        /// AccountVault.
        /// </summary>
        [EnumMember(Value = "AccountVault")]
        AccountVault,

        /// <summary>
        /// DeviceTerm.
        /// </summary>
        [EnumMember(Value = "DeviceTerm")]
        DeviceTerm
    }
}