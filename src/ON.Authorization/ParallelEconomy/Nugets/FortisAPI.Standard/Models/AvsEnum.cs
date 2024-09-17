// <copyright file="AvsEnum.cs" company="APIMatic">
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
    /// AvsEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AvsEnum
    {
        /// <summary>
        /// BAD.
        /// </summary>
        [EnumMember(Value = "BAD")]
        BAD,

        /// <summary>
        /// ZIP.
        /// </summary>
        [EnumMember(Value = "ZIP")]
        ZIP,

        /// <summary>
        /// STREET.
        /// </summary>
        [EnumMember(Value = "STREET")]
        STREET,

        /// <summary>
        /// GOOD.
        /// </summary>
        [EnumMember(Value = "GOOD")]
        GOOD,

        /// <summary>
        /// UNKNOWN.
        /// </summary>
        [EnumMember(Value = "UNKNOWN")]
        UNKNOWN
    }
}