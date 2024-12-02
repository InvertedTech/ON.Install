// <copyright file="Values4Enum.cs" company="APIMatic">
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
    /// Values4Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Values4Enum
    {
        /// <summary>
        /// TokenApiId.
        /// </summary>
        [EnumMember(Value = "token_api_id")]
        TokenApiId,

        /// <summary>
        /// AccountVaultApiId.
        /// </summary>
        [EnumMember(Value = "account_vault_api_id")]
        AccountVaultApiId
    }
}