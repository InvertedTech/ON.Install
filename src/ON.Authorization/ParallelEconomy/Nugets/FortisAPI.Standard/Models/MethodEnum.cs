// <copyright file="MethodEnum.cs" company="APIMatic">
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
    /// MethodEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MethodEnum
    {
        /// <summary>
        /// Xor.
        /// </summary>
        [EnumMember(Value = "xor")]
        Xor
    }
}