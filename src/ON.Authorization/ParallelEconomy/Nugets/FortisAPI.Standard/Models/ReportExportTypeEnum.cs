// <copyright file="ReportExportTypeEnum.cs" company="APIMatic">
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
    /// ReportExportTypeEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportExportTypeEnum
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
        Tsv,

        /// <summary>
        /// Xls.
        /// </summary>
        [EnumMember(Value = "xls")]
        Xls,

        /// <summary>
        /// Xlsx.
        /// </summary>
        [EnumMember(Value = "xlsx")]
        Xlsx
    }
}