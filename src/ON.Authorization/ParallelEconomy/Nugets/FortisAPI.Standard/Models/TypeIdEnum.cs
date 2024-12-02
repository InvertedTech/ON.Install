// <copyright file="TypeIdEnum.cs" company="APIMatic">
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
    /// TypeIdEnum.
    /// </summary>

    [JsonConverter(typeof(NumberEnumConverter))]
    public enum TypeIdEnum
    {
        /// <summary>
        /// Enum20.
        /// </summary>
        Enum20 = 20,

        /// <summary>
        /// Enum21.
        /// </summary>
        Enum21 = 21,

        /// <summary>
        /// Enum22.
        /// </summary>
        Enum22 = 22,

        /// <summary>
        /// Enum30.
        /// </summary>
        Enum30 = 30,

        /// <summary>
        /// Enum40.
        /// </summary>
        Enum40 = 40,

        /// <summary>
        /// Enum50.
        /// </summary>
        Enum50 = 50
    }
}