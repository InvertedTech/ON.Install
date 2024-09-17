// <copyright file="Expand101Enum.cs" company="APIMatic">
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
    /// Expand101Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Expand101Enum
    {
        /// <summary>
        /// Postbacklogs.
        /// </summary>
        [EnumMember(Value = "postbacklogs")]
        Postbacklogs,

        /// <summary>
        /// BasicAuthUsername.
        /// </summary>
        [EnumMember(Value = "basic_auth_username")]
        BasicAuthUsername,

        /// <summary>
        /// BasicAuthPassword.
        /// </summary>
        [EnumMember(Value = "basic_auth_password")]
        BasicAuthPassword
    }
}