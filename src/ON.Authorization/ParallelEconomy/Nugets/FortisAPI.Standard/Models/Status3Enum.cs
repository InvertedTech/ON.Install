// <copyright file="Status3Enum.cs" company="APIMatic">
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
    /// Status3Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Status3Enum
    {
        /// <summary>
        /// Paid.
        /// </summary>
        [EnumMember(Value = "paid")]
        Paid,

        /// <summary>
        /// Unpaid.
        /// </summary>
        [EnumMember(Value = "unpaid")]
        Unpaid
    }
}