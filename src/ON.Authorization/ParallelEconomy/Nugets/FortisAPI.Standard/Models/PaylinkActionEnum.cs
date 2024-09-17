// <copyright file="PaylinkActionEnum.cs" company="APIMatic">
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
    /// PaylinkActionEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaylinkActionEnum
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
        Authonly
    }
}