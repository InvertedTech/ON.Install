// <copyright file="LocationTypeEnum.cs" company="APIMatic">
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
    /// LocationTypeEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum LocationTypeEnum
    {
        /// <summary>
        /// Hierarchy.
        /// </summary>
        [EnumMember(Value = "hierarchy")]
        Hierarchy,

        /// <summary>
        /// Agent.
        /// </summary>
        [EnumMember(Value = "agent")]
        Agent,

        /// <summary>
        /// Merchant.
        /// </summary>
        [EnumMember(Value = "merchant")]
        Merchant
    }
}