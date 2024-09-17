// <copyright file="UpdateIfExistsEnum.cs" company="APIMatic">
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
    /// UpdateIfExistsEnum.
    /// </summary>

    [JsonConverter(typeof(NumberEnumConverter))]
    public enum UpdateIfExistsEnum
    {
        /// <summary>
        /// Enum1.
        /// </summary>
        Enum1 = 1
    }
}