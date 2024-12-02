// <copyright file="TerminalManufacturerCodeEnum.cs" company="APIMatic">
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
    /// TerminalManufacturerCodeEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TerminalManufacturerCodeEnum
    {
        /// <summary>
        /// Enum1.
        /// </summary>
        [EnumMember(Value = "1")]
        Enum1,

        /// <summary>
        /// Enum2.
        /// </summary>
        [EnumMember(Value = "2")]
        Enum2,

        /// <summary>
        /// Enum4.
        /// </summary>
        [EnumMember(Value = "4")]
        Enum4,

        /// <summary>
        /// Enum100.
        /// </summary>
        [EnumMember(Value = "100")]
        Enum100
    }
}