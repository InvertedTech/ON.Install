// <copyright file="Expand37Enum.cs" company="APIMatic">
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
    /// Expand37Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Expand37Enum
    {
        /// <summary>
        /// Location.
        /// </summary>
        [EnumMember(Value = "location")]
        Location,

        /// <summary>
        /// CreatedUser.
        /// </summary>
        [EnumMember(Value = "created_user")]
        CreatedUser,

        /// <summary>
        /// TerminalApplication.
        /// </summary>
        [EnumMember(Value = "terminal_application")]
        TerminalApplication,

        /// <summary>
        /// Changelogs.
        /// </summary>
        [EnumMember(Value = "changelogs")]
        Changelogs,

        /// <summary>
        /// TerminalRouters.
        /// </summary>
        [EnumMember(Value = "terminal_routers")]
        TerminalRouters,

        /// <summary>
        /// HasTerminalRouters.
        /// </summary>
        [EnumMember(Value = "has_terminal_routers")]
        HasTerminalRouters,

        /// <summary>
        /// TerminalCvm.
        /// </summary>
        [EnumMember(Value = "terminal_cvm")]
        TerminalCvm,

        /// <summary>
        /// TerminalManufacturer.
        /// </summary>
        [EnumMember(Value = "terminal_manufacturer")]
        TerminalManufacturer
    }
}