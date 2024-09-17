// <copyright file="ProcessorEnum.cs" company="APIMatic">
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
    /// ProcessorEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProcessorEnum
    {
        /// <summary>
        /// Zgate.
        /// </summary>
        [EnumMember(Value = "zgate")]
        Zgate,

        /// <summary>
        /// Zgate2.
        /// </summary>
        [EnumMember(Value = "zgate2")]
        Zgate2,

        /// <summary>
        /// Zach.
        /// </summary>
        [EnumMember(Value = "zach")]
        Zach,

        /// <summary>
        /// Ach.
        /// </summary>
        [EnumMember(Value = "ach")]
        Ach,

        /// <summary>
        /// Fortisach.
        /// </summary>
        [EnumMember(Value = "fortisach")]
        Fortisach,

        /// <summary>
        /// Cash.
        /// </summary>
        [EnumMember(Value = "cash")]
        Cash
    }
}