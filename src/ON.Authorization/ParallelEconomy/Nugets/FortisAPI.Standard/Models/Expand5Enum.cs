// <copyright file="Expand5Enum.cs" company="APIMatic">
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
    /// Expand5Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Expand5Enum
    {
        /// <summary>
        /// Recurring.
        /// </summary>
        [EnumMember(Value = "recurring")]
        Recurring,

        /// <summary>
        /// PaymentTransaction.
        /// </summary>
        [EnumMember(Value = "payment_transaction")]
        PaymentTransaction,

        /// <summary>
        /// DeclinedTransaction.
        /// </summary>
        [EnumMember(Value = "declined_transaction")]
        DeclinedTransaction
    }
}