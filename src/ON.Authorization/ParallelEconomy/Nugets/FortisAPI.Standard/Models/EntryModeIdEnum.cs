// <copyright file="EntryModeIdEnum.cs" company="APIMatic">
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
    /// EntryModeIdEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EntryModeIdEnum
    {
        /// <summary>
        /// B.
        /// </summary>
        [EnumMember(Value = "B")]
        B,

        /// <summary>
        /// S.
        /// </summary>
        [EnumMember(Value = "S")]
        S,

        /// <summary>
        /// K.
        /// </summary>
        [EnumMember(Value = "K")]
        K,

        /// <summary>
        /// C.
        /// </summary>
        [EnumMember(Value = "C")]
        C,

        /// <summary>
        /// P.
        /// </summary>
        [EnumMember(Value = "P")]
        P,

        /// <summary>
        /// F.
        /// </summary>
        [EnumMember(Value = "F")]
        F
    }
}