// <copyright file="PartnerEnum.cs" company="APIMatic">
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
    /// PartnerEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PartnerEnum
    {
        /// <summary>
        /// Standalone.
        /// </summary>
        [EnumMember(Value = "standalone")]
        Standalone,

        /// <summary>
        /// Verticle.
        /// </summary>
        [EnumMember(Value = "verticle")]
        Verticle,

        /// <summary>
        /// Vericle.
        /// </summary>
        [EnumMember(Value = "Vericle")]
        Vericle,

        /// <summary>
        /// AirVoice.
        /// </summary>
        [EnumMember(Value = "AirVoice")]
        AirVoice,

        /// <summary>
        /// Drchrono.
        /// </summary>
        [EnumMember(Value = "drchrono")]
        Drchrono,

        /// <summary>
        /// Schoolleader.
        /// </summary>
        [EnumMember(Value = "schoolleader")]
        Schoolleader,

        /// <summary>
        /// Frontier.
        /// </summary>
        [EnumMember(Value = "Frontier")]
        Frontier,

        /// <summary>
        /// ChiroTouch.
        /// </summary>
        [EnumMember(Value = "ChiroTouch")]
        ChiroTouch,

        /// <summary>
        /// Platinum.
        /// </summary>
        [EnumMember(Value = "Platinum")]
        Platinum,

        /// <summary>
        /// CentralProcessingService.
        /// </summary>
        [EnumMember(Value = "CentralProcessingService")]
        CentralProcessingService
    }
}