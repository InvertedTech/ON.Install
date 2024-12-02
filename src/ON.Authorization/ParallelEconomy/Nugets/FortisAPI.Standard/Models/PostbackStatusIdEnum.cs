// <copyright file="PostbackStatusIdEnum.cs" company="APIMatic">
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
    /// PostbackStatusIdEnum.
    /// </summary>

    [JsonConverter(typeof(NumberEnumConverter))]
    public enum PostbackStatusIdEnum
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
        Enum4 = 4
    }
}