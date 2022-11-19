// <copyright file="AchSecCode2Enum.cs" company="APIMatic">
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
    /// AchSecCode2Enum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AchSecCode2Enum
    {
        /// <summary>
        /// CCD.
        /// </summary>
        [EnumMember(Value = "CCD")]
        CCD,

        /// <summary>
        /// PPD.
        /// </summary>
        [EnumMember(Value = "PPD")]
        PPD,

        /// <summary>
        /// TEL.
        /// </summary>
        [EnumMember(Value = "TEL")]
        TEL,

        /// <summary>
        /// WEB.
        /// </summary>
        [EnumMember(Value = "WEB")]
        WEB,

        /// <summary>
        /// POP.
        /// </summary>
        [EnumMember(Value = "POP")]
        POP,

        /// <summary>
        /// C21.
        /// </summary>
        [EnumMember(Value = "C21")]
        C21
    }
}