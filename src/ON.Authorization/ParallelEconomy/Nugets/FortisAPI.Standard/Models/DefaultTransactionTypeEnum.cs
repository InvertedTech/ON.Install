// <copyright file="DefaultTransactionTypeEnum.cs" company="APIMatic">
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
    /// DefaultTransactionTypeEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum DefaultTransactionTypeEnum
    {
        /// <summary>
        /// Debit.
        /// </summary>
        [EnumMember(Value = "debit")]
        Debit,

        /// <summary>
        /// Sale.
        /// </summary>
        [EnumMember(Value = "sale")]
        Sale,

        /// <summary>
        /// Authonly.
        /// </summary>
        [EnumMember(Value = "authonly")]
        Authonly
    }
}