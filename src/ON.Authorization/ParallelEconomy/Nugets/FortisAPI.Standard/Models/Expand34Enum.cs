// <copyright file="Expand34Enum.cs" company="APIMatic">
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
    /// Expand34Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Expand34Enum
    {
        /// <summary>
        /// Location.
        /// </summary>
        [EnumMember(Value = "location")]
        Location
    }
}