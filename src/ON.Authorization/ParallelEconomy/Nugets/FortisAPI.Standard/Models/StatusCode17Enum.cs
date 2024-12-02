// <copyright file="StatusCode17Enum.cs" company="APIMatic">
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
    /// StatusCode17Enum.
    /// </summary>

    [JsonConverter(typeof(NumberEnumConverter))]
    public enum StatusCode17Enum
    {
        /// <summary>
        /// Enum101.
        /// </summary>
        Enum101 = 101,

        /// <summary>
        /// Enum102.
        /// </summary>
        Enum102 = 102,

        /// <summary>
        /// Enum111.
        /// </summary>
        Enum111 = 111,

        /// <summary>
        /// Enum121.
        /// </summary>
        Enum121 = 121,

        /// <summary>
        /// Enum131.
        /// </summary>
        Enum131 = 131,

        /// <summary>
        /// Enum132.
        /// </summary>
        Enum132 = 132,

        /// <summary>
        /// Enum133.
        /// </summary>
        Enum133 = 133,

        /// <summary>
        /// Enum134.
        /// </summary>
        Enum134 = 134,

        /// <summary>
        /// Enum191.
        /// </summary>
        Enum191 = 191,

        /// <summary>
        /// Enum201.
        /// </summary>
        Enum201 = 201,

        /// <summary>
        /// Enum301.
        /// </summary>
        Enum301 = 301,

        /// <summary>
        /// Enum331.
        /// </summary>
        Enum331 = 331
    }
}