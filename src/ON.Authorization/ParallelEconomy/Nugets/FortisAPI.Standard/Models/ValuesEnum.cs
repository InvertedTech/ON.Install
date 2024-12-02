// <copyright file="ValuesEnum.cs" company="APIMatic">
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
    /// ValuesEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ValuesEnum
    {
        /// <summary>
        /// AccountVaultId.
        /// </summary>
        [EnumMember(Value = "account_vault_id")]
        AccountVaultId,

        /// <summary>
        /// TokenId.
        /// </summary>
        [EnumMember(Value = "token_id")]
        TokenId,

        /// <summary>
        /// AccountVaultApiId.
        /// </summary>
        [EnumMember(Value = "account_vault_api_id")]
        AccountVaultApiId,

        /// <summary>
        /// TokenApiId.
        /// </summary>
        [EnumMember(Value = "token_api_id")]
        TokenApiId
    }
}