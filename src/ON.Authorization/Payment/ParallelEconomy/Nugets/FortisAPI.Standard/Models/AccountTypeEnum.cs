// <copyright file="AccountTypeEnum.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// AccountTypeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccountTypeEnum
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        [EnumMember(Value = "unknown")]
        Unknown,

        /// <summary>
        /// Checking.
        /// </summary>
        [EnumMember(Value = "checking")]
        Checking,

        /// <summary>
        /// Credit.
        /// </summary>
        [EnumMember(Value = "credit")]
        Credit,

        /// <summary>
        /// CashBenefit.
        /// </summary>
        [EnumMember(Value = "cash_benefit")]
        CashBenefit,

        /// <summary>
        /// Snap.
        /// </summary>
        [EnumMember(Value = "snap")]
        Snap,

        /// <summary>
        /// Prepaid.
        /// </summary>
        [EnumMember(Value = "prepaid")]
        Prepaid,

        /// <summary>
        /// Savings.
        /// </summary>
        [EnumMember(Value = "savings")]
        Savings,

        /// <summary>
        /// SpendingPower.
        /// </summary>
        [EnumMember(Value = "spending_power")]
        SpendingPower,

        /// <summary>
        /// Universal.
        /// </summary>
        [EnumMember(Value = "universal")]
        Universal
    }
}