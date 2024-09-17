// <copyright file="Values5Enum.cs" company="APIMatic">
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
    /// Values5Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Values5Enum
    {
        /// <summary>
        /// AccountvaultC1.
        /// </summary>
        [EnumMember(Value = "accountvault_c1")]
        AccountvaultC1,

        /// <summary>
        /// TokenC1.
        /// </summary>
        [EnumMember(Value = "token_c1")]
        TokenC1
    }
}