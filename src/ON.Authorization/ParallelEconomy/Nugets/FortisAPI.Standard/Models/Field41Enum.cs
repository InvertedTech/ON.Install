// <copyright file="Field41Enum.cs" company="APIMatic">
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
    /// Field41Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Field41Enum
    {
        /// <summary>
        /// Signature.
        /// </summary>
        [EnumMember(Value = "signature")]
        Signature,

        /// <summary>
        /// Resource.
        /// </summary>
        [EnumMember(Value = "resource")]
        Resource,

        /// <summary>
        /// ResourceId.
        /// </summary>
        [EnumMember(Value = "resource_id")]
        ResourceId,

        /// <summary>
        /// Id.
        /// </summary>
        [EnumMember(Value = "id")]
        Id,

        /// <summary>
        /// CreatedTs.
        /// </summary>
        [EnumMember(Value = "created_ts")]
        CreatedTs,

        /// <summary>
        /// ModifiedTs.
        /// </summary>
        [EnumMember(Value = "modified_ts")]
        ModifiedTs,

        /// <summary>
        /// RawSignature.
        /// </summary>
        [EnumMember(Value = "raw_signature")]
        RawSignature
    }
}