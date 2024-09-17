// <copyright file="Expand31Enum.cs" company="APIMatic">
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
    /// Expand31Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Expand31Enum
    {
        /// <summary>
        /// RawSignature.
        /// </summary>
        [EnumMember(Value = "raw_signature")]
        RawSignature
    }
}