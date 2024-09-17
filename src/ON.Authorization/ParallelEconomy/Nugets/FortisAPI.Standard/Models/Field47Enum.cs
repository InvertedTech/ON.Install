// <copyright file="Field47Enum.cs" company="APIMatic">
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
    /// Field47Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Field47Enum
    {
        /// <summary>
        /// AccountHolderName.
        /// </summary>
        [EnumMember(Value = "account_holder_name")]
        AccountHolderName,

        /// <summary>
        /// ExpDate.
        /// </summary>
        [EnumMember(Value = "exp_date")]
        ExpDate,

        /// <summary>
        /// Cvv.
        /// </summary>
        [EnumMember(Value = "cvv")]
        Cvv,

        /// <summary>
        /// AccountNumber.
        /// </summary>
        [EnumMember(Value = "account_number")]
        AccountNumber,

        /// <summary>
        /// BillingAddress.
        /// </summary>
        [EnumMember(Value = "billing_address")]
        BillingAddress,

        /// <summary>
        /// ContactId.
        /// </summary>
        [EnumMember(Value = "contact_id")]
        ContactId,

        /// <summary>
        /// ContactApiId.
        /// </summary>
        [EnumMember(Value = "contact_api_id")]
        ContactApiId,

        /// <summary>
        /// LocationId.
        /// </summary>
        [EnumMember(Value = "location_id")]
        LocationId,

        /// <summary>
        /// LocationApiId.
        /// </summary>
        [EnumMember(Value = "location_api_id")]
        LocationApiId,

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
        /// CreatedUserId.
        /// </summary>
        [EnumMember(Value = "created_user_id")]
        CreatedUserId,

        /// <summary>
        /// Location.
        /// </summary>
        [EnumMember(Value = "location")]
        Location,

        /// <summary>
        /// Contact.
        /// </summary>
        [EnumMember(Value = "contact")]
        Contact,

        /// <summary>
        /// CreatedUser.
        /// </summary>
        [EnumMember(Value = "created_user")]
        CreatedUser
    }
}