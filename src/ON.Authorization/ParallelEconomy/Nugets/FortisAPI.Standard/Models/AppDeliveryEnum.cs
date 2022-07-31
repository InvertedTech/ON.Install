// <copyright file="AppDeliveryEnum.cs" company="APIMatic">
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
    /// AppDeliveryEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AppDeliveryEnum
    {
        /// <summary>
        /// Direct.
        /// </summary>
        [EnumMember(Value = "direct")]
        Direct,

        /// <summary>
        /// LinkFullPage.
        /// </summary>
        [EnumMember(Value = "link_full_page")]
        LinkFullPage,

        /// <summary>
        /// LinkIframe.
        /// </summary>
        [EnumMember(Value = "link_iframe")]
        LinkIframe
    }
}