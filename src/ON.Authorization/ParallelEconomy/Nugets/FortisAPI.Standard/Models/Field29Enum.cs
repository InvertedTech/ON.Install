// <copyright file="Field29Enum.cs" company="APIMatic">
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
    /// Field29Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Field29Enum
    {
        /// <summary>
        /// LocationId.
        /// </summary>
        [EnumMember(Value = "location_id")]
        LocationId,

        /// <summary>
        /// TerminalId.
        /// </summary>
        [EnumMember(Value = "terminal_id")]
        TerminalId,

        /// <summary>
        /// RequireSignature.
        /// </summary>
        [EnumMember(Value = "require_signature")]
        RequireSignature,

        /// <summary>
        /// DeviceTermApiId.
        /// </summary>
        [EnumMember(Value = "device_term_api_id")]
        DeviceTermApiId,

        /// <summary>
        /// TermsConditions.
        /// </summary>
        [EnumMember(Value = "terms_conditions")]
        TermsConditions,

        /// <summary>
        /// Id.
        /// </summary>
        [EnumMember(Value = "id")]
        Id,

        /// <summary>
        /// ReasonCodeId.
        /// </summary>
        [EnumMember(Value = "reason_code_id")]
        ReasonCodeId,

        /// <summary>
        /// Signature.
        /// </summary>
        [EnumMember(Value = "signature")]
        Signature,

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
        /// CreatedUserId.
        /// </summary>
        [EnumMember(Value = "created_user_id")]
        CreatedUserId,

        /// <summary>
        /// CreatedUser.
        /// </summary>
        [EnumMember(Value = "created_user")]
        CreatedUser,

        /// <summary>
        /// Location.
        /// </summary>
        [EnumMember(Value = "location")]
        Location,

        /// <summary>
        /// Terminal.
        /// </summary>
        [EnumMember(Value = "terminal")]
        Terminal,

        /// <summary>
        /// Changelogs.
        /// </summary>
        [EnumMember(Value = "changelogs")]
        Changelogs,

        /// <summary>
        /// ReasonCode.
        /// </summary>
        [EnumMember(Value = "reason_code")]
        ReasonCode
    }
}