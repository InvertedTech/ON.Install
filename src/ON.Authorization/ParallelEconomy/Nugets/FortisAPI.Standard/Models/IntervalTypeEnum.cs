// <copyright file="IntervalTypeEnum.cs" company="APIMatic">
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
    /// IntervalTypeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IntervalTypeEnum
    {
        /// <summary>
        /// D.
        /// </summary>
        [EnumMember(Value = "d")]
        D,

        /// <summary>
        /// W.
        /// </summary>
        [EnumMember(Value = "w")]
        W,

        /// <summary>
        /// M.
        /// </summary>
        [EnumMember(Value = "m")]
        M
    }
}