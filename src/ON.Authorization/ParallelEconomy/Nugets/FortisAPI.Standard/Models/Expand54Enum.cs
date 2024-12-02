// <copyright file="Expand54Enum.cs" company="APIMatic">
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
    /// Expand54Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Expand54Enum
    {
        /// <summary>
        /// LogEmails.
        /// </summary>
        [EnumMember(Value = "log_emails")]
        LogEmails,

        /// <summary>
        /// IsVoidable.
        /// </summary>
        [EnumMember(Value = "is_voidable")]
        IsVoidable,

        /// <summary>
        /// IsReversible.
        /// </summary>
        [EnumMember(Value = "is_reversible")]
        IsReversible,

        /// <summary>
        /// IsRefundable.
        /// </summary>
        [EnumMember(Value = "is_refundable")]
        IsRefundable,

        /// <summary>
        /// IsCompletable.
        /// </summary>
        [EnumMember(Value = "is_completable")]
        IsCompletable,

        /// <summary>
        /// IsSettled.
        /// </summary>
        [EnumMember(Value = "is_settled")]
        IsSettled,

        /// <summary>
        /// CreatedUser.
        /// </summary>
        [EnumMember(Value = "created_user")]
        CreatedUser,

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
        /// Changelogs.
        /// </summary>
        [EnumMember(Value = "changelogs")]
        Changelogs,

        /// <summary>
        /// ProductTransaction.
        /// </summary>
        [EnumMember(Value = "product_transaction")]
        ProductTransaction,

        /// <summary>
        /// Tags.
        /// </summary>
        [EnumMember(Value = "tags")]
        Tags,

        /// <summary>
        /// AllTags.
        /// </summary>
        [EnumMember(Value = "all_tags")]
        AllTags,

        /// <summary>
        /// Recurring.
        /// </summary>
        [EnumMember(Value = "recurring")]
        Recurring,

        /// <summary>
        /// TagTransactions.
        /// </summary>
        [EnumMember(Value = "tagTransactions")]
        TagTransactions,

        /// <summary>
        /// DeclinedRecurringNotification.
        /// </summary>
        [EnumMember(Value = "declined_recurring_notification")]
        DeclinedRecurringNotification,

        /// <summary>
        /// PaymentRecurringNotification.
        /// </summary>
        [EnumMember(Value = "payment_recurring_notification")]
        PaymentRecurringNotification,

        /// <summary>
        /// AccountVault.
        /// </summary>
        [EnumMember(Value = "account_vault")]
        AccountVault,

        /// <summary>
        /// QuickInvoice.
        /// </summary>
        [EnumMember(Value = "quick_invoice")]
        QuickInvoice,

        /// <summary>
        /// DeveloperCompany.
        /// </summary>
        [EnumMember(Value = "developer_company")]
        DeveloperCompany,

        /// <summary>
        /// Terminal.
        /// </summary>
        [EnumMember(Value = "terminal")]
        Terminal,

        /// <summary>
        /// HostedPaymentPage.
        /// </summary>
        [EnumMember(Value = "hosted_payment_page")]
        HostedPaymentPage,

        /// <summary>
        /// TransactionLevel3.
        /// </summary>
        [EnumMember(Value = "transaction_level3")]
        TransactionLevel3,

        /// <summary>
        /// DeveloperCompanyId.
        /// </summary>
        [EnumMember(Value = "developer_company_id")]
        DeveloperCompanyId,

        /// <summary>
        /// TransactionHistories.
        /// </summary>
        [EnumMember(Value = "transaction_histories")]
        TransactionHistories,

        /// <summary>
        /// SurchargeTransaction.
        /// </summary>
        [EnumMember(Value = "surcharge_transaction")]
        SurchargeTransaction,

        /// <summary>
        /// Surcharge.
        /// </summary>
        [EnumMember(Value = "surcharge")]
        Surcharge,

        /// <summary>
        /// Signature.
        /// </summary>
        [EnumMember(Value = "signature")]
        Signature,

        /// <summary>
        /// ReasonCode.
        /// </summary>
        [EnumMember(Value = "reason_code")]
        ReasonCode,

        /// <summary>
        /// Type.
        /// </summary>
        [EnumMember(Value = "type")]
        Type,

        /// <summary>
        /// Status.
        /// </summary>
        [EnumMember(Value = "status")]
        Status,

        /// <summary>
        /// TransactionBatch.
        /// </summary>
        [EnumMember(Value = "transaction_batch")]
        TransactionBatch,

        /// <summary>
        /// TransactionSplits.
        /// </summary>
        [EnumMember(Value = "transaction_splits")]
        TransactionSplits,

        /// <summary>
        /// PostbackLogs.
        /// </summary>
        [EnumMember(Value = "postback_logs")]
        PostbackLogs,

        /// <summary>
        /// CurrencyType.
        /// </summary>
        [EnumMember(Value = "currency_type")]
        CurrencyType,

        /// <summary>
        /// TransactionReferences.
        /// </summary>
        [EnumMember(Value = "transaction_references")]
        TransactionReferences,

        /// <summary>
        /// SavedAccount.
        /// </summary>
        [EnumMember(Value = "saved_account")]
        SavedAccount
    }
}