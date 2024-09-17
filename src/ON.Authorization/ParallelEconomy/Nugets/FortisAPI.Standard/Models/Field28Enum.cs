// <copyright file="Field28Enum.cs" company="APIMatic">
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
    /// Field28Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Field28Enum
    {
        /// <summary>
        /// Id.
        /// </summary>
        [EnumMember(Value = "id")]
        Id,

        /// <summary>
        /// DeclinedTransactionId.
        /// </summary>
        [EnumMember(Value = "declined_transaction_id")]
        DeclinedTransactionId,

        /// <summary>
        /// PaymentTransactionId.
        /// </summary>
        [EnumMember(Value = "payment_transaction_id")]
        PaymentTransactionId,

        /// <summary>
        /// Status.
        /// </summary>
        [EnumMember(Value = "status")]
        Status,

        /// <summary>
        /// RecurringId.
        /// </summary>
        [EnumMember(Value = "recurring_id")]
        RecurringId,

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
        /// ModifiedTs.
        /// </summary>
        [EnumMember(Value = "modified_ts")]
        ModifiedTs,

        /// <summary>
        /// ModifiedUserId.
        /// </summary>
        [EnumMember(Value = "modified_user_id")]
        ModifiedUserId,

        /// <summary>
        /// Recurring.
        /// </summary>
        [EnumMember(Value = "recurring")]
        Recurring,

        /// <summary>
        /// PaymentTransaction.
        /// </summary>
        [EnumMember(Value = "payment_transaction")]
        PaymentTransaction,

        /// <summary>
        /// DeclinedTransaction.
        /// </summary>
        [EnumMember(Value = "declined_transaction")]
        DeclinedTransaction
    }
}