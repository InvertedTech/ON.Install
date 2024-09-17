// <copyright file="ReasonModelEnum.cs" company="APIMatic">
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
    /// ReasonModelEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReasonModelEnum
    {
        /// <summary>
        /// Contact.
        /// </summary>
        [EnumMember(Value = "Contact")]
        Contact,

        /// <summary>
        /// Transaction.
        /// </summary>
        [EnumMember(Value = "Transaction")]
        Transaction,

        /// <summary>
        /// Recurring.
        /// </summary>
        [EnumMember(Value = "Recurring")]
        Recurring,

        /// <summary>
        /// User.
        /// </summary>
        [EnumMember(Value = "User")]
        User,

        /// <summary>
        /// ProductTransaction.
        /// </summary>
        [EnumMember(Value = "ProductTransaction")]
        ProductTransaction,

        /// <summary>
        /// TransactionBatch.
        /// </summary>
        [EnumMember(Value = "TransactionBatch")]
        TransactionBatch,

        /// <summary>
        /// QuickInvoice.
        /// </summary>
        [EnumMember(Value = "QuickInvoice")]
        QuickInvoice,

        /// <summary>
        /// DataExport.
        /// </summary>
        [EnumMember(Value = "DataExport")]
        DataExport,

        /// <summary>
        /// UserReportSchedule.
        /// </summary>
        [EnumMember(Value = "UserReportSchedule")]
        UserReportSchedule,

        /// <summary>
        /// UserReport.
        /// </summary>
        [EnumMember(Value = "UserReport")]
        UserReport,

        /// <summary>
        /// Paylink.
        /// </summary>
        [EnumMember(Value = "Paylink")]
        Paylink
    }
}