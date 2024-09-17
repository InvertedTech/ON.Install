// <copyright file="Format1Enum.cs" company="APIMatic">
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
    /// Format1Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Format1Enum
    {
        /// <summary>
        /// Csv.
        /// </summary>
        [EnumMember(Value = "csv")]
        Csv,

        /// <summary>
        /// Tsv.
        /// </summary>
        [EnumMember(Value = "tsv")]
        Tsv
    }
}