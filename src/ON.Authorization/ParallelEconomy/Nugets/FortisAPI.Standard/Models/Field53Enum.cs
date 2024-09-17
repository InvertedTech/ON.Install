// <copyright file="Field53Enum.cs" company="APIMatic">
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
    /// Field53Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Field53Enum
    {
        /// <summary>
        /// UserId.
        /// </summary>
        [EnumMember(Value = "user_id")]
        UserId,

        /// <summary>
        /// Id.
        /// </summary>
        [EnumMember(Value = "id")]
        Id,

        /// <summary>
        /// CreatedTs.
        /// </summary>
        [EnumMember(Value = "created_ts")]
        CreatedTs
    }
}