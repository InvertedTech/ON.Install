// <copyright file="StatusCode12Enum.cs" company="APIMatic">
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
    /// StatusCode12Enum.
    /// </summary>

    [JsonConverter(typeof(NumberEnumConverter))]
    public enum StatusCode12Enum
    {
        /// <summary>
        /// Enum0.
        /// </summary>
        Enum0 = 0,

        /// <summary>
        /// Enum1.
        /// </summary>
        Enum1 = 1
    }
}