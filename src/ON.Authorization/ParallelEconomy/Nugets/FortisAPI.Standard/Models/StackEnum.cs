// <copyright file="StackEnum.cs" company="APIMatic">
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
    /// StackEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum StackEnum
    {
        /// <summary>
        /// Horizontal.
        /// </summary>
        [EnumMember(Value = "horizontal")]
        Horizontal,

        /// <summary>
        /// Vertical.
        /// </summary>
        [EnumMember(Value = "vertical")]
        Vertical
    }
}