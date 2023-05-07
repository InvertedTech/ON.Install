// <copyright file="OwnershipTypeEnum.cs" company="APIMatic">
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
    /// OwnershipTypeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OwnershipTypeEnum
    {
        /// <summary>
        /// C.
        /// </summary>
        [EnumMember(Value = "c")]
        C,

        /// <summary>
        /// Gov.
        /// </summary>
        [EnumMember(Value = "gov")]
        Gov,

        /// <summary>
        /// Llc.
        /// </summary>
        [EnumMember(Value = "llc")]
        Llc,

        /// <summary>
        /// Llp.
        /// </summary>
        [EnumMember(Value = "llp")]
        Llp,

        /// <summary>
        /// Np.
        /// </summary>
        [EnumMember(Value = "np")]
        Np,

        /// <summary>
        /// P.
        /// </summary>
        [EnumMember(Value = "p")]
        P,

        /// <summary>
        /// Po.
        /// </summary>
        [EnumMember(Value = "po")]
        Po,

        /// <summary>
        /// S.
        /// </summary>
        [EnumMember(Value = "s")]
        S,

        /// <summary>
        /// Sp.
        /// </summary>
        [EnumMember(Value = "sp")]
        Sp,

        /// <summary>
        /// Te.
        /// </summary>
        [EnumMember(Value = "te")]
        Te
    }
}