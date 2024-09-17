// <copyright file="ExpandEnum.cs" company="APIMatic">
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
    /// ExpandEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ExpandEnum
    {
        /// <summary>
        /// Changelogs.
        /// </summary>
        [EnumMember(Value = "changelogs")]
        Changelogs,

        /// <summary>
        /// PostbackLogs.
        /// </summary>
        [EnumMember(Value = "postback_logs")]
        PostbackLogs,

        /// <summary>
        /// ProductTransaction.
        /// </summary>
        [EnumMember(Value = "product_transaction")]
        ProductTransaction
    }
}