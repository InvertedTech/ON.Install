// <copyright file="IdtypeEnum.cs" company="APIMatic">
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
    /// IdtypeEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum IdtypeEnum
    {
        /// <summary>
        /// Mac.
        /// </summary>
        [EnumMember(Value = "mac")]
        Mac,

        /// <summary>
        /// Sn.
        /// </summary>
        [EnumMember(Value = "sn")]
        Sn
    }
}