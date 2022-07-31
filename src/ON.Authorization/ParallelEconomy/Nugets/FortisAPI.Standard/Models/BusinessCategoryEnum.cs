// <copyright file="BusinessCategoryEnum.cs" company="APIMatic">
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
    /// BusinessCategoryEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BusinessCategoryEnum
    {
        /// <summary>
        /// BeautyAndPersonalCare.
        /// </summary>
        [EnumMember(Value = "beauty_and_personal_care")]
        BeautyAndPersonalCare,

        /// <summary>
        /// CasualUse.
        /// </summary>
        [EnumMember(Value = "casual_use")]
        CasualUse,

        /// <summary>
        /// Education.
        /// </summary>
        [EnumMember(Value = "education")]
        Education,

        /// <summary>
        /// FoodAndDrink.
        /// </summary>
        [EnumMember(Value = "food_and_drink")]
        FoodAndDrink,

        /// <summary>
        /// HealthCareAndFitness.
        /// </summary>
        [EnumMember(Value = "health_care_and_fitness")]
        HealthCareAndFitness,

        /// <summary>
        /// HomeAndRepair.
        /// </summary>
        [EnumMember(Value = "home_and_repair")]
        HomeAndRepair,

        /// <summary>
        /// LeisureAndEntertainment.
        /// </summary>
        [EnumMember(Value = "leisure_and_entertainment")]
        LeisureAndEntertainment,

        /// <summary>
        /// NonProfit.
        /// </summary>
        [EnumMember(Value = "non_profit")]
        NonProfit,

        /// <summary>
        /// ProfessionalServices.
        /// </summary>
        [EnumMember(Value = "professional_services")]
        ProfessionalServices,

        /// <summary>
        /// Retail.
        /// </summary>
        [EnumMember(Value = "retail")]
        Retail,

        /// <summary>
        /// Transportation.
        /// </summary>
        [EnumMember(Value = "transportation")]
        Transportation
    }
}