// <copyright file="ProcessMethodEnum.cs" company="APIMatic">
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
    /// ProcessMethodEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProcessMethodEnum
    {
        /// <summary>
        /// VirtualTerminal.
        /// </summary>
        [EnumMember(Value = "virtual_terminal")]
        VirtualTerminal,

        /// <summary>
        /// PhysicalTerminal.
        /// </summary>
        [EnumMember(Value = "physical_terminal")]
        PhysicalTerminal
    }
}