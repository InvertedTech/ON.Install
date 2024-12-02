// <copyright file="Field39Enum.cs" company="APIMatic">
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
    /// Field39Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Field39Enum
    {
        /// <summary>
        /// AccountVaultId.
        /// </summary>
        [EnumMember(Value = "account_vault_id")]
        AccountVaultId,

        /// <summary>
        /// TokenId.
        /// </summary>
        [EnumMember(Value = "token_id")]
        TokenId,

        /// <summary>
        /// ContactId.
        /// </summary>
        [EnumMember(Value = "contact_id")]
        ContactId,

        /// <summary>
        /// AccountVaultApiId.
        /// </summary>
        [EnumMember(Value = "account_vault_api_id")]
        AccountVaultApiId,

        /// <summary>
        /// TokenApiId.
        /// </summary>
        [EnumMember(Value = "token_api_id")]
        TokenApiId,

        /// <summary>
        /// Joi.
        /// </summary>
        [EnumMember(Value = "_joi")]
        Joi,

        /// <summary>
        /// Active.
        /// </summary>
        [EnumMember(Value = "active")]
        Active,

        /// <summary>
        /// Description.
        /// </summary>
        [EnumMember(Value = "description")]
        Description,

        /// <summary>
        /// EndDate.
        /// </summary>
        [EnumMember(Value = "end_date")]
        EndDate,

        /// <summary>
        /// InstallmentTotalCount.
        /// </summary>
        [EnumMember(Value = "installment_total_count")]
        InstallmentTotalCount,

        /// <summary>
        /// Interval.
        /// </summary>
        [EnumMember(Value = "interval")]
        Interval,

        /// <summary>
        /// IntervalType.
        /// </summary>
        [EnumMember(Value = "interval_type")]
        IntervalType,

        /// <summary>
        /// LocationId.
        /// </summary>
        [EnumMember(Value = "location_id")]
        LocationId,

        /// <summary>
        /// NotificationDays.
        /// </summary>
        [EnumMember(Value = "notification_days")]
        NotificationDays,

        /// <summary>
        /// PaymentMethod.
        /// </summary>
        [EnumMember(Value = "payment_method")]
        PaymentMethod,

        /// <summary>
        /// ProductTransactionId.
        /// </summary>
        [EnumMember(Value = "product_transaction_id")]
        ProductTransactionId,

        /// <summary>
        /// RecurringId.
        /// </summary>
        [EnumMember(Value = "recurring_id")]
        RecurringId,

        /// <summary>
        /// RecurringApiId.
        /// </summary>
        [EnumMember(Value = "recurring_api_id")]
        RecurringApiId,

        /// <summary>
        /// StartDate.
        /// </summary>
        [EnumMember(Value = "start_date")]
        StartDate,

        /// <summary>
        /// Status.
        /// </summary>
        [EnumMember(Value = "status")]
        Status,

        /// <summary>
        /// TransactionAmount.
        /// </summary>
        [EnumMember(Value = "transaction_amount")]
        TransactionAmount,

        /// <summary>
        /// TermsAgree.
        /// </summary>
        [EnumMember(Value = "terms_agree")]
        TermsAgree,

        /// <summary>
        /// TermsAgreeIp.
        /// </summary>
        [EnumMember(Value = "terms_agree_ip")]
        TermsAgreeIp,

        /// <summary>
        /// RecurringC1.
        /// </summary>
        [EnumMember(Value = "recurring_c1")]
        RecurringC1,

        /// <summary>
        /// RecurringC2.
        /// </summary>
        [EnumMember(Value = "recurring_c2")]
        RecurringC2,

        /// <summary>
        /// RecurringC3.
        /// </summary>
        [EnumMember(Value = "recurring_c3")]
        RecurringC3,

        /// <summary>
        /// SendToProcAsRecur.
        /// </summary>
        [EnumMember(Value = "send_to_proc_as_recur")]
        SendToProcAsRecur,

        /// <summary>
        /// Tags.
        /// </summary>
        [EnumMember(Value = "tags")]
        Tags,

        /// <summary>
        /// SecondaryAmount.
        /// </summary>
        [EnumMember(Value = "secondary_amount")]
        SecondaryAmount,

        /// <summary>
        /// Currency.
        /// </summary>
        [EnumMember(Value = "currency")]
        Currency,

        /// <summary>
        /// Id.
        /// </summary>
        [EnumMember(Value = "id")]
        Id,

        /// <summary>
        /// NextRunDate.
        /// </summary>
        [EnumMember(Value = "next_run_date")]
        NextRunDate,

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
        /// RecurringTypeId.
        /// </summary>
        [EnumMember(Value = "recurring_type_id")]
        RecurringTypeId,

        /// <summary>
        /// InstallmentAmountTotal.
        /// </summary>
        [EnumMember(Value = "installment_amount_total")]
        InstallmentAmountTotal,

        /// <summary>
        /// CreatedUserId.
        /// </summary>
        [EnumMember(Value = "created_user_id")]
        CreatedUserId,

        /// <summary>
        /// LogEmails.
        /// </summary>
        [EnumMember(Value = "log_emails")]
        LogEmails,

        /// <summary>
        /// Contact.
        /// </summary>
        [EnumMember(Value = "contact")]
        Contact,

        /// <summary>
        /// AccountVault.
        /// </summary>
        [EnumMember(Value = "account_vault")]
        AccountVault,

        /// <summary>
        /// CreatedUser.
        /// </summary>
        [EnumMember(Value = "created_user")]
        CreatedUser,

        /// <summary>
        /// Signature.
        /// </summary>
        [EnumMember(Value = "signature")]
        Signature,

        /// <summary>
        /// PaymentSchedule.
        /// </summary>
        [EnumMember(Value = "payment_schedule")]
        PaymentSchedule,

        /// <summary>
        /// Location.
        /// </summary>
        [EnumMember(Value = "location")]
        Location,

        /// <summary>
        /// ProductTransaction.
        /// </summary>
        [EnumMember(Value = "product_transaction")]
        ProductTransaction,

        /// <summary>
        /// NextRunDateMin.
        /// </summary>
        [EnumMember(Value = "next_run_date_min")]
        NextRunDateMin,

        /// <summary>
        /// NextRunDateMax.
        /// </summary>
        [EnumMember(Value = "next_run_date_max")]
        NextRunDateMax,

        /// <summary>
        /// AllTags.
        /// </summary>
        [EnumMember(Value = "all_tags")]
        AllTags,

        /// <summary>
        /// Changelogs.
        /// </summary>
        [EnumMember(Value = "changelogs")]
        Changelogs,

        /// <summary>
        /// Forecast.
        /// </summary>
        [EnumMember(Value = "forecast")]
        Forecast,

        /// <summary>
        /// RecurringSplits.
        /// </summary>
        [EnumMember(Value = "recurring_splits")]
        RecurringSplits,

        /// <summary>
        /// Transactions.
        /// </summary>
        [EnumMember(Value = "transactions")]
        Transactions
    }
}