// <copyright file="Values48Enum.cs" company="APIMatic">
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
    /// Values48Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Values48Enum
    {
        /// <summary>
        /// AccountNumber.
        /// </summary>
        [EnumMember(Value = "account_number")]
        AccountNumber,

        /// <summary>
        /// ExpDate.
        /// </summary>
        [EnumMember(Value = "exp_date")]
        ExpDate
    }
}