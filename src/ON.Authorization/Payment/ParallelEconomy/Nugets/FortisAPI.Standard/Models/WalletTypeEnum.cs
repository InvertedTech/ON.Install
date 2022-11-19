// <copyright file="WalletTypeEnum.cs" company="APIMatic">
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
    /// WalletTypeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WalletTypeEnum
    {
        /// <summary>
        /// Enum000.
        /// </summary>
        [EnumMember(Value = "000")]
        Enum000,

        /// <summary>
        /// Enum101.
        /// </summary>
        [EnumMember(Value = "101")]
        Enum101,

        /// <summary>
        /// Enum103.
        /// </summary>
        [EnumMember(Value = "103")]
        Enum103,

        /// <summary>
        /// Enum216.
        /// </summary>
        [EnumMember(Value = "216")]
        Enum216,

        /// <summary>
        /// Enum217.
        /// </summary>
        [EnumMember(Value = "217")]
        Enum217,

        /// <summary>
        /// Enum327.
        /// </summary>
        [EnumMember(Value = "327")]
        Enum327
    }
}