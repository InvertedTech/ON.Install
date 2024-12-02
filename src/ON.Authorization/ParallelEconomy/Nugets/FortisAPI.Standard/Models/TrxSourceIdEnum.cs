// <copyright file="TrxSourceIdEnum.cs" company="APIMatic">
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
    /// TrxSourceIdEnum.
    /// </summary>

    [JsonConverter(typeof(NumberEnumConverter))]
    public enum TrxSourceIdEnum
    {
        /// <summary>
        /// Enum1.
        /// </summary>
        Enum1 = 1,

        /// <summary>
        /// Enum2.
        /// </summary>
        Enum2 = 2,

        /// <summary>
        /// Enum3.
        /// </summary>
        Enum3 = 3,

        /// <summary>
        /// Enum4.
        /// </summary>
        Enum4 = 4,

        /// <summary>
        /// Enum5.
        /// </summary>
        Enum5 = 5,

        /// <summary>
        /// Enum6.
        /// </summary>
        Enum6 = 6,

        /// <summary>
        /// Enum7.
        /// </summary>
        Enum7 = 7,

        /// <summary>
        /// Enum8.
        /// </summary>
        Enum8 = 8,

        /// <summary>
        /// Enum9.
        /// </summary>
        Enum9 = 9,

        /// <summary>
        /// Enum10.
        /// </summary>
        Enum10 = 10,

        /// <summary>
        /// Enum11.
        /// </summary>
        Enum11 = 11,

        /// <summary>
        /// Enum12.
        /// </summary>
        Enum12 = 12,

        /// <summary>
        /// Enum13.
        /// </summary>
        Enum13 = 13,

        /// <summary>
        /// Enum14.
        /// </summary>
        Enum14 = 14,

        /// <summary>
        /// Enum15.
        /// </summary>
        Enum15 = 15,

        /// <summary>
        /// Enum16.
        /// </summary>
        Enum16 = 16,

        /// <summary>
        /// Enum17.
        /// </summary>
        Enum17 = 17,

        /// <summary>
        /// Enum18.
        /// </summary>
        Enum18 = 18
    }
}