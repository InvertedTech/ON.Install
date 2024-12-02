// <copyright file="IndustryTypeEnum.cs" company="APIMatic">
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
    /// IndustryTypeEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum IndustryTypeEnum
    {
        /// <summary>
        /// Ecommerce.
        /// </summary>
        [EnumMember(Value = "ecommerce")]
        Ecommerce,

        /// <summary>
        /// Restaurant.
        /// </summary>
        [EnumMember(Value = "restaurant")]
        Restaurant,

        /// <summary>
        /// Lodging.
        /// </summary>
        [EnumMember(Value = "lodging")]
        Lodging,

        /// <summary>
        /// Moto.
        /// </summary>
        [EnumMember(Value = "moto")]
        Moto,

        /// <summary>
        /// Retail.
        /// </summary>
        [EnumMember(Value = "retail")]
        Retail,

        /// <summary>
        /// EnumRetailSelfServe.
        /// </summary>
        [EnumMember(Value = "retail self serve")]
        EnumRetailSelfServe
    }
}