// <copyright file="ActionEnum.cs" company="APIMatic">
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
    /// ActionEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActionEnum
    {
        /// <summary>
        /// Sale.
        /// </summary>
        [EnumMember(Value = "sale")]
        Sale,

        /// <summary>
        /// Authonly.
        /// </summary>
        [EnumMember(Value = "auth-only")]
        Authonly,

        /// <summary>
        /// Avsonly.
        /// </summary>
        [EnumMember(Value = "avs-only")]
        Avsonly,

        /// <summary>
        /// Refund.
        /// </summary>
        [EnumMember(Value = "refund")]
        Refund,

        /// <summary>
        /// Tokenization.
        /// </summary>
        [EnumMember(Value = "tokenization")]
        Tokenization
    }
}