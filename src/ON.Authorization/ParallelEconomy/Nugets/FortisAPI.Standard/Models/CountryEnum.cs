// <copyright file="CountryEnum.cs" company="APIMatic">
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
    /// CountryEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CountryEnum
    {
        /// <summary>
        /// US.
        /// </summary>
        [EnumMember(Value = "US")]
        US,

        /// <summary>
        /// CA.
        /// </summary>
        [EnumMember(Value = "CA")]
        CA
    }
}