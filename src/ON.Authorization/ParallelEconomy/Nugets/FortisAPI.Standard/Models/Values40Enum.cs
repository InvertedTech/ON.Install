// <copyright file="Values40Enum.cs" company="APIMatic">
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
    /// Values40Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Values40Enum
    {
        /// <summary>
        /// AccountNumber.
        /// </summary>
        [EnumMember(Value = "account_number")]
        AccountNumber,

        /// <summary>
        /// PreviousAccountVaultId.
        /// </summary>
        [EnumMember(Value = "previous_account_vault_id")]
        PreviousAccountVaultId
    }
}