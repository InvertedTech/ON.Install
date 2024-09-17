// <copyright file="PaymentMethod6Enum.cs" company="APIMatic">
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
    /// PaymentMethod6Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentMethod6Enum
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