// <copyright file="Values41Enum.cs" company="APIMatic">
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
    /// Values41Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Values41Enum
    {
        /// <summary>
        /// AccountNumber.
        /// </summary>
        [EnumMember(Value = "account_number")]
        AccountNumber,

        /// <summary>
        /// AccountHolderName.
        /// </summary>
        [EnumMember(Value = "account_holder_name")]
        AccountHolderName,

        /// <summary>
        /// RoutingNumber.
        /// </summary>
        [EnumMember(Value = "routing_number")]
        RoutingNumber
    }
}