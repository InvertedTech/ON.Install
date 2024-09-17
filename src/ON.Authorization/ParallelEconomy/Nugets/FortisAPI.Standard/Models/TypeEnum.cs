// <copyright file="TypeEnum.cs" company="APIMatic">
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
    /// TypeEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeEnum
    {
        /// <summary>
        /// Ach.
        /// </summary>
        [EnumMember(Value = "ach")]
        Ach,

        /// <summary>
        /// Cc.
        /// </summary>
        [EnumMember(Value = "cc")]
        Cc
    }
}