// <copyright file="AchSecCode1Enum.cs" company="APIMatic">
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
    /// AchSecCode1Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AchSecCode1Enum
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