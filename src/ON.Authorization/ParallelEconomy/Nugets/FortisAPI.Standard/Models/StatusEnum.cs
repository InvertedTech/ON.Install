// <copyright file="StatusEnum.cs" company="APIMatic">
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
    /// StatusEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusEnum
    {
        /// <summary>
        /// Active.
        /// </summary>
        [EnumMember(Value = "active")]
        Active,

        /// <summary>
        /// EnumOnHold.
        /// </summary>
        [EnumMember(Value = "on hold")]
        EnumOnHold,

        /// <summary>
        /// Ended.
        /// </summary>
        [EnumMember(Value = "ended")]
        Ended
    }
}