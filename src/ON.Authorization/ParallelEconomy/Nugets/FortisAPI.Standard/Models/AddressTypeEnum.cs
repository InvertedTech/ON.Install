// <copyright file="AddressTypeEnum.cs" company="APIMatic">
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
    /// AddressTypeEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AddressTypeEnum
    {
        /// <summary>
        /// Location.
        /// </summary>
        [EnumMember(Value = "location")]
        Location,

        /// <summary>
        /// Mailing.
        /// </summary>
        [EnumMember(Value = "mailing")]
        Mailing,

        /// <summary>
        /// Corporate.
        /// </summary>
        [EnumMember(Value = "corporate")]
        Corporate
    }
}