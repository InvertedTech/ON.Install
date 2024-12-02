// <copyright file="PreferredLanguageEnum.cs" company="APIMatic">
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
    /// PreferredLanguageEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PreferredLanguageEnum
    {
        /// <summary>
        /// EnUS.
        /// </summary>
        [EnumMember(Value = "en-US")]
        EnUS,

        /// <summary>
        /// FrCA.
        /// </summary>
        [EnumMember(Value = "fr-CA")]
        FrCA
    }
}