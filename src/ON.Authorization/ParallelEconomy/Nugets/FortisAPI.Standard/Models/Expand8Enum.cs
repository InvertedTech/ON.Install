// <copyright file="Expand8Enum.cs" company="APIMatic">
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
    /// Expand8Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Expand8Enum
    {
        /// <summary>
        /// CreatedUser.
        /// </summary>
        [EnumMember(Value = "created_user")]
        CreatedUser,

        /// <summary>
        /// Location.
        /// </summary>
        [EnumMember(Value = "location")]
        Location,

        /// <summary>
        /// Terminal.
        /// </summary>
        [EnumMember(Value = "terminal")]
        Terminal,

        /// <summary>
        /// Changelogs.
        /// </summary>
        [EnumMember(Value = "changelogs")]
        Changelogs,

        /// <summary>
        /// Signature.
        /// </summary>
        [EnumMember(Value = "signature")]
        Signature,

        /// <summary>
        /// ReasonCode.
        /// </summary>
        [EnumMember(Value = "reason_code")]
        ReasonCode
    }
}