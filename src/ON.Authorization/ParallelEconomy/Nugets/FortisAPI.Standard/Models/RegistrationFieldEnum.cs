// <copyright file="RegistrationFieldEnum.cs" company="APIMatic">
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
    /// RegistrationFieldEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RegistrationFieldEnum
    {
        /// <summary>
        /// Id.
        /// </summary>
        [EnumMember(Value = "id")]
        Id,

        /// <summary>
        /// FirstName.
        /// </summary>
        [EnumMember(Value = "first_name")]
        FirstName,

        /// <summary>
        /// LastName.
        /// </summary>
        [EnumMember(Value = "last_name")]
        LastName,

        /// <summary>
        /// AccountNumber.
        /// </summary>
        [EnumMember(Value = "account_number")]
        AccountNumber,

        /// <summary>
        /// Email.
        /// </summary>
        [EnumMember(Value = "email")]
        Email,

        /// <summary>
        /// CompanyName.
        /// </summary>
        [EnumMember(Value = "company_name")]
        CompanyName,

        /// <summary>
        /// Address.
        /// </summary>
        [EnumMember(Value = "address")]
        Address,

        /// <summary>
        /// City.
        /// </summary>
        [EnumMember(Value = "city")]
        City,

        /// <summary>
        /// State.
        /// </summary>
        [EnumMember(Value = "state")]
        State,

        /// <summary>
        /// Zip.
        /// </summary>
        [EnumMember(Value = "zip")]
        Zip,

        /// <summary>
        /// HomePhone.
        /// </summary>
        [EnumMember(Value = "home_phone")]
        HomePhone,

        /// <summary>
        /// OfficePhone.
        /// </summary>
        [EnumMember(Value = "office_phone")]
        OfficePhone,

        /// <summary>
        /// OfficeExtPhone.
        /// </summary>
        [EnumMember(Value = "office_ext_phone")]
        OfficeExtPhone,

        /// <summary>
        /// CellPhone.
        /// </summary>
        [EnumMember(Value = "cell_phone")]
        CellPhone,

        /// <summary>
        /// ContactApiId.
        /// </summary>
        [EnumMember(Value = "contact_api_id")]
        ContactApiId,

        /// <summary>
        /// DateOfBirth.
        /// </summary>
        [EnumMember(Value = "date_of_birth")]
        DateOfBirth
    }
}