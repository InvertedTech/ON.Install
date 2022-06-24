// <copyright file="PaymentMethod2Enum.cs" company="APIMatic">
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
    /// PaymentMethod2Enum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentMethod2Enum
    {
        /// <summary>
        /// Cc.
        /// </summary>
        [EnumMember(Value = "cc")]
        Cc,

        /// <summary>
        /// Ach.
        /// </summary>
        [EnumMember(Value = "ach")]
        Ach
    }
}