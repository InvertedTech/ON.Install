// <copyright file="WalletProviderEnum.cs" company="APIMatic">
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
    /// WalletProviderEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum WalletProviderEnum
    {
        /// <summary>
        /// GooglePay.
        /// </summary>
        [EnumMember(Value = "GooglePay")]
        GooglePay,

        /// <summary>
        /// ApplePay.
        /// </summary>
        [EnumMember(Value = "ApplePay")]
        ApplePay
    }
}