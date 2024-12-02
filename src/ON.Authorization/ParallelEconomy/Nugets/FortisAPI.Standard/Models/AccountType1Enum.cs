// <copyright file="AccountType1Enum.cs" company="APIMatic">
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
    /// AccountType1Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccountType1Enum
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