// <copyright file="Country2Enum.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Country2Enum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Country2Enum
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