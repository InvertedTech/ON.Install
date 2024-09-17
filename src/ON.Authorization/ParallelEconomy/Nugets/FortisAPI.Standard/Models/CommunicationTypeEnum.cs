// <copyright file="CommunicationTypeEnum.cs" company="APIMatic">
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
    /// CommunicationTypeEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CommunicationTypeEnum
    {
        /// <summary>
        /// Http.
        /// </summary>
        [EnumMember(Value = "http")]
        Http,

        /// <summary>
        /// EnumTcpip.
        /// </summary>
        [EnumMember(Value = "tcp/ip")]
        EnumTcpip,

        /// <summary>
        /// EnumUsbserial.
        /// </summary>
        [EnumMember(Value = "usb/serial")]
        EnumUsbserial
    }
}