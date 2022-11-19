// <copyright file="EFormatEnum.cs" company="APIMatic">
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
    /// EFormatEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EFormatEnum
    {
        /// <summary>
        /// Ksn.
        /// </summary>
        [EnumMember(Value = "ksn")]
        Ksn,

        /// <summary>
        /// Ksnpin.
        /// </summary>
        [EnumMember(Value = "ksnpin")]
        Ksnpin,

        /// <summary>
        /// Idtech.
        /// </summary>
        [EnumMember(Value = "idtech")]
        Idtech,

        /// <summary>
        /// Magnesafe.
        /// </summary>
        [EnumMember(Value = "magnesafe")]
        Magnesafe
    }
}