// <copyright file="Values7Enum.cs" company="APIMatic">
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
    /// Values7Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Values7Enum
    {
        /// <summary>
        /// AccountvaultC3.
        /// </summary>
        [EnumMember(Value = "accountvault_c3")]
        AccountvaultC3,

        /// <summary>
        /// TokenC3.
        /// </summary>
        [EnumMember(Value = "token_c3")]
        TokenC3
    }
}