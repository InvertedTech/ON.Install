// <copyright file="ContactUserDefaultEntryPageEnum.cs" company="APIMatic">
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
    /// ContactUserDefaultEntryPageEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContactUserDefaultEntryPageEnum
    {
        /// <summary>
        /// Dashboard.
        /// </summary>
        [EnumMember(Value = "dashboard")]
        Dashboard,

        /// <summary>
        /// Makepayment.
        /// </summary>
        [EnumMember(Value = "makepayment")]
        Makepayment,

        /// <summary>
        /// Paymenthistory.
        /// </summary>
        [EnumMember(Value = "paymenthistory")]
        Paymenthistory,

        /// <summary>
        /// Accounts.
        /// </summary>
        [EnumMember(Value = "accounts")]
        Accounts,

        /// <summary>
        /// Recurrings.
        /// </summary>
        [EnumMember(Value = "recurrings")]
        Recurrings,

        /// <summary>
        /// Invoices.
        /// </summary>
        [EnumMember(Value = "invoices")]
        Invoices
    }
}