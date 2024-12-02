// <copyright file="Field45Enum.cs" company="APIMatic">
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
    /// Field45Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Field45Enum
    {
        /// <summary>
        /// LocationId.
        /// </summary>
        [EnumMember(Value = "location_id")]
        LocationId,

        /// <summary>
        /// DefaultProductTransactionId.
        /// </summary>
        [EnumMember(Value = "default_product_transaction_id")]
        DefaultProductTransactionId,

        /// <summary>
        /// TerminalApplicationId.
        /// </summary>
        [EnumMember(Value = "terminal_application_id")]
        TerminalApplicationId,

        /// <summary>
        /// TerminalCvmId.
        /// </summary>
        [EnumMember(Value = "terminal_cvm_id")]
        TerminalCvmId,

        /// <summary>
        /// TerminalManufacturerCode.
        /// </summary>
        [EnumMember(Value = "terminal_manufacturer_code")]
        TerminalManufacturerCode,

        /// <summary>
        /// Title.
        /// </summary>
        [EnumMember(Value = "title")]
        Title,

        /// <summary>
        /// MacAddress.
        /// </summary>
        [EnumMember(Value = "mac_address")]
        MacAddress,

        /// <summary>
        /// LocalIpAddress.
        /// </summary>
        [EnumMember(Value = "local_ip_address")]
        LocalIpAddress,

        /// <summary>
        /// Port.
        /// </summary>
        [EnumMember(Value = "port")]
        Port,

        /// <summary>
        /// SerialNumber.
        /// </summary>
        [EnumMember(Value = "serial_number")]
        SerialNumber,

        /// <summary>
        /// TerminalNumber.
        /// </summary>
        [EnumMember(Value = "terminal_number")]
        TerminalNumber,

        /// <summary>
        /// TerminalTimeouts.
        /// </summary>
        [EnumMember(Value = "terminal_timeouts")]
        TerminalTimeouts,

        /// <summary>
        /// TipPercents.
        /// </summary>
        [EnumMember(Value = "tip_percents")]
        TipPercents,

        /// <summary>
        /// LocationApiId.
        /// </summary>
        [EnumMember(Value = "location_api_id")]
        LocationApiId,

        /// <summary>
        /// TerminalApiId.
        /// </summary>
        [EnumMember(Value = "terminal_api_id")]
        TerminalApiId,

        /// <summary>
        /// HeaderLine1.
        /// </summary>
        [EnumMember(Value = "header_line_1")]
        HeaderLine1,

        /// <summary>
        /// HeaderLine2.
        /// </summary>
        [EnumMember(Value = "header_line_2")]
        HeaderLine2,

        /// <summary>
        /// HeaderLine3.
        /// </summary>
        [EnumMember(Value = "header_line_3")]
        HeaderLine3,

        /// <summary>
        /// HeaderLine4.
        /// </summary>
        [EnumMember(Value = "header_line_4")]
        HeaderLine4,

        /// <summary>
        /// HeaderLine5.
        /// </summary>
        [EnumMember(Value = "header_line_5")]
        HeaderLine5,

        /// <summary>
        /// TrailerLine1.
        /// </summary>
        [EnumMember(Value = "trailer_line_1")]
        TrailerLine1,

        /// <summary>
        /// TrailerLine2.
        /// </summary>
        [EnumMember(Value = "trailer_line_2")]
        TrailerLine2,

        /// <summary>
        /// TrailerLine3.
        /// </summary>
        [EnumMember(Value = "trailer_line_3")]
        TrailerLine3,

        /// <summary>
        /// TrailerLine4.
        /// </summary>
        [EnumMember(Value = "trailer_line_4")]
        TrailerLine4,

        /// <summary>
        /// TrailerLine5.
        /// </summary>
        [EnumMember(Value = "trailer_line_5")]
        TrailerLine5,

        /// <summary>
        /// DefaultCheckin.
        /// </summary>
        [EnumMember(Value = "default_checkin")]
        DefaultCheckin,

        /// <summary>
        /// DefaultCheckout.
        /// </summary>
        [EnumMember(Value = "default_checkout")]
        DefaultCheckout,

        /// <summary>
        /// DefaultRoomRate.
        /// </summary>
        [EnumMember(Value = "default_room_rate")]
        DefaultRoomRate,

        /// <summary>
        /// DefaultRoomNumber.
        /// </summary>
        [EnumMember(Value = "default_room_number")]
        DefaultRoomNumber,

        /// <summary>
        /// Debit.
        /// </summary>
        [EnumMember(Value = "debit")]
        Debit,

        /// <summary>
        /// Emv.
        /// </summary>
        [EnumMember(Value = "emv")]
        Emv,

        /// <summary>
        /// CashbackEnable.
        /// </summary>
        [EnumMember(Value = "cashback_enable")]
        CashbackEnable,

        /// <summary>
        /// PrintEnable.
        /// </summary>
        [EnumMember(Value = "print_enable")]
        PrintEnable,

        /// <summary>
        /// SigCaptureEnable.
        /// </summary>
        [EnumMember(Value = "sig_capture_enable")]
        SigCaptureEnable,

        /// <summary>
        /// IsProvisioned.
        /// </summary>
        [EnumMember(Value = "is_provisioned")]
        IsProvisioned,

        /// <summary>
        /// TipEnable.
        /// </summary>
        [EnumMember(Value = "tip_enable")]
        TipEnable,

        /// <summary>
        /// ValidatedDecryption.
        /// </summary>
        [EnumMember(Value = "validated_decryption")]
        ValidatedDecryption,

        /// <summary>
        /// CommunicationType.
        /// </summary>
        [EnumMember(Value = "communication_type")]
        CommunicationType,

        /// <summary>
        /// Active.
        /// </summary>
        [EnumMember(Value = "active")]
        Active,

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
        /// ModifiedTs.
        /// </summary>
        [EnumMember(Value = "modified_ts")]
        ModifiedTs,

        /// <summary>
        /// LastRegistrationTs.
        /// </summary>
        [EnumMember(Value = "last_registration_ts")]
        LastRegistrationTs,

        /// <summary>
        /// CreatedUserId.
        /// </summary>
        [EnumMember(Value = "created_user_id")]
        CreatedUserId,

        /// <summary>
        /// ModifiedUserId.
        /// </summary>
        [EnumMember(Value = "modified_user_id")]
        ModifiedUserId,

        /// <summary>
        /// Location.
        /// </summary>
        [EnumMember(Value = "location")]
        Location,

        /// <summary>
        /// CreatedUser.
        /// </summary>
        [EnumMember(Value = "created_user")]
        CreatedUser,

        /// <summary>
        /// TerminalApplication.
        /// </summary>
        [EnumMember(Value = "terminal_application")]
        TerminalApplication,

        /// <summary>
        /// Changelogs.
        /// </summary>
        [EnumMember(Value = "changelogs")]
        Changelogs,

        /// <summary>
        /// TerminalRouters.
        /// </summary>
        [EnumMember(Value = "terminal_routers")]
        TerminalRouters,

        /// <summary>
        /// HasTerminalRouters.
        /// </summary>
        [EnumMember(Value = "has_terminal_routers")]
        HasTerminalRouters,

        /// <summary>
        /// TerminalCvm.
        /// </summary>
        [EnumMember(Value = "terminal_cvm")]
        TerminalCvm,

        /// <summary>
        /// TerminalManufacturer.
        /// </summary>
        [EnumMember(Value = "terminal_manufacturer")]
        TerminalManufacturer
    }
}