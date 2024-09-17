// <copyright file="Type1Enum.cs" company="APIMatic">
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
    /// Type1Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Type1Enum
    {
        /// <summary>
        /// Cashback.
        /// </summary>
        [EnumMember(Value = "cashback")]
        Cashback,

        /// <summary>
        /// Surcharge.
        /// </summary>
        [EnumMember(Value = "surcharge")]
        Surcharge,

        /// <summary>
        /// Healthcare.
        /// </summary>
        [EnumMember(Value = "healthcare")]
        Healthcare,

        /// <summary>
        /// Transit.
        /// </summary>
        [EnumMember(Value = "transit")]
        Transit,

        /// <summary>
        /// RX.
        /// </summary>
        [EnumMember(Value = "RX")]
        RX,

        /// <summary>
        /// Vision.
        /// </summary>
        [EnumMember(Value = "vision")]
        Vision,

        /// <summary>
        /// Clinical.
        /// </summary>
        [EnumMember(Value = "clinical")]
        Clinical,

        /// <summary>
        /// Copay.
        /// </summary>
        [EnumMember(Value = "copay")]
        Copay,

        /// <summary>
        /// Dental.
        /// </summary>
        [EnumMember(Value = "dental")]
        Dental,

        /// <summary>
        /// Tax.
        /// </summary>
        [EnumMember(Value = "tax")]
        Tax,

        /// <summary>
        /// Fee.
        /// </summary>
        [EnumMember(Value = "fee")]
        Fee
    }
}