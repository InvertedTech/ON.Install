// <copyright file="AchSecCodeEnum.cs" company="APIMatic">
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
    /// AchSecCodeEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AchSecCodeEnum
    {
        /// <summary>
        /// WEB.
        /// </summary>
        [EnumMember(Value = "WEB")]
        WEB,

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
        TEL
    }
}