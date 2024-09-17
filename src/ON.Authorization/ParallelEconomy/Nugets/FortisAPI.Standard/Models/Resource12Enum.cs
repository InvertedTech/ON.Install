// <copyright file="Resource12Enum.cs" company="APIMatic">
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
    /// Resource12Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Resource12Enum
    {
        /// <summary>
        /// Contact.
        /// </summary>
        [EnumMember(Value = "contact")]
        Contact,

        /// <summary>
        /// Transaction.
        /// </summary>
        [EnumMember(Value = "transaction")]
        Transaction,

        /// <summary>
        /// Transactionbatch.
        /// </summary>
        [EnumMember(Value = "transactionbatch")]
        Transactionbatch
    }
}