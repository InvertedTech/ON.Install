// <copyright file="Operator1Enum.cs" company="APIMatic">
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
    /// Operator1Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Operator1Enum
    {
        /// <summary>
        /// Enum0.
        /// </summary>
        [EnumMember(Value = ">=")]
        Enum0,

        /// <summary>
        /// Enum1.
        /// </summary>
        [EnumMember(Value = "<=")]
        Enum1
    }
}