// <copyright file="Resource2Enum.cs" company="APIMatic">
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
    /// Resource2Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Resource2Enum
    {
        /// <summary>
        /// Contact.
        /// </summary>
        [EnumMember(Value = "Contact")]
        Contact,

        /// <summary>
        /// Location.
        /// </summary>
        [EnumMember(Value = "Location")]
        Location,

        /// <summary>
        /// QuickInvoice.
        /// </summary>
        [EnumMember(Value = "QuickInvoice")]
        QuickInvoice
    }
}