// <copyright file="Field25Enum.cs" company="APIMatic">
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
    /// Field25Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Field25Enum
    {
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
        /// ProductTransactionId.
        /// </summary>
        [EnumMember(Value = "product_transaction_id")]
        ProductTransactionId,

        /// <summary>
        /// ProcessingStatusId.
        /// </summary>
        [EnumMember(Value = "processing_status_id")]
        ProcessingStatusId,

        /// <summary>
        /// BatchNum.
        /// </summary>
        [EnumMember(Value = "batch_num")]
        BatchNum,

        /// <summary>
        /// IsOpen.
        /// </summary>
        [EnumMember(Value = "is_open")]
        IsOpen,

        /// <summary>
        /// SettlementFileName.
        /// </summary>
        [EnumMember(Value = "settlement_file_name")]
        SettlementFileName,

        /// <summary>
        /// BatchCloseTs.
        /// </summary>
        [EnumMember(Value = "batch_close_ts")]
        BatchCloseTs,

        /// <summary>
        /// BatchCloseDetail.
        /// </summary>
        [EnumMember(Value = "batch_close_detail")]
        BatchCloseDetail,

        /// <summary>
        /// TotalSaleAmount.
        /// </summary>
        [EnumMember(Value = "total_sale_amount")]
        TotalSaleAmount,

        /// <summary>
        /// TotalSaleCount.
        /// </summary>
        [EnumMember(Value = "total_sale_count")]
        TotalSaleCount,

        /// <summary>
        /// TotalRefundAmount.
        /// </summary>
        [EnumMember(Value = "total_refund_amount")]
        TotalRefundAmount,

        /// <summary>
        /// TotalRefundCount.
        /// </summary>
        [EnumMember(Value = "total_refund_count")]
        TotalRefundCount,

        /// <summary>
        /// TotalVoidAmount.
        /// </summary>
        [EnumMember(Value = "total_void_amount")]
        TotalVoidAmount,

        /// <summary>
        /// TotalVoidCount.
        /// </summary>
        [EnumMember(Value = "total_void_count")]
        TotalVoidCount,

        /// <summary>
        /// TotalBlindRefundAmount.
        /// </summary>
        [EnumMember(Value = "total_blind_refund_amount")]
        TotalBlindRefundAmount,

        /// <summary>
        /// TotalBlindRefundCount.
        /// </summary>
        [EnumMember(Value = "total_blind_refund_count")]
        TotalBlindRefundCount,

        /// <summary>
        /// Changelogs.
        /// </summary>
        [EnumMember(Value = "changelogs")]
        Changelogs,

        /// <summary>
        /// PostbackLogs.
        /// </summary>
        [EnumMember(Value = "postback_logs")]
        PostbackLogs,

        /// <summary>
        /// ProductTransaction.
        /// </summary>
        [EnumMember(Value = "product_transaction")]
        ProductTransaction
    }
}