// <copyright file="Values6Enum.cs" company="APIMatic">
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
    /// Values6Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Values6Enum
    {
        /// <summary>
        /// AccountvaultC2.
        /// </summary>
        [EnumMember(Value = "accountvault_c2")]
        AccountvaultC2,

        /// <summary>
        /// TokenC2.
        /// </summary>
        [EnumMember(Value = "token_c2")]
        TokenC2
    }
}