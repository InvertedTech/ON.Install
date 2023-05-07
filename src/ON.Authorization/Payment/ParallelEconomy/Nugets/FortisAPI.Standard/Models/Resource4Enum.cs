// <copyright file="Resource4Enum.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Resource4Enum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Resource4Enum
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