// <copyright file="Method5Enum.cs" company="APIMatic">
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
    /// Method5Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Method5Enum
    {
        /// <summary>
        /// Oxor.
        /// </summary>
        [EnumMember(Value = "oxor")]
        Oxor
    }
}