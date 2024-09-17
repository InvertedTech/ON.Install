// <copyright file="Field37Enum.cs" company="APIMatic">
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
    /// Field37Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Field37Enum
    {
        /// <summary>
        /// LocationId.
        /// </summary>
        [EnumMember(Value = "location_id")]
        LocationId,

        /// <summary>
        /// Title.
        /// </summary>
        [EnumMember(Value = "title")]
        Title,

        /// <summary>
        /// CcProductTransactionId.
        /// </summary>
        [EnumMember(Value = "cc_product_transaction_id")]
        CcProductTransactionId,

        /// <summary>
        /// AchProductTransactionId.
        /// </summary>
        [EnumMember(Value = "ach_product_transaction_id")]
        AchProductTransactionId,

        /// <summary>
        /// DueDate.
        /// </summary>
        [EnumMember(Value = "due_date")]
        DueDate,

        /// <summary>
        /// ItemList.
        /// </summary>
        [EnumMember(Value = "item_list")]
        ItemList,

        /// <summary>
        /// AllowOverpayment.
        /// </summary>
        [EnumMember(Value = "allow_overpayment")]
        AllowOverpayment,

        /// <summary>
        /// BankFundedOnlyOverride.
        /// </summary>
        [EnumMember(Value = "bank_funded_only_override")]
        BankFundedOnlyOverride,

        /// <summary>
        /// Email.
        /// </summary>
        [EnumMember(Value = "email")]
        Email,

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
        /// QuickInvoiceApiId.
        /// </summary>
        [EnumMember(Value = "quick_invoice_api_id")]
        QuickInvoiceApiId,

        /// <summary>
        /// CustomerId.
        /// </summary>
        [EnumMember(Value = "customer_id")]
        CustomerId,

        /// <summary>
        /// ExpireDate.
        /// </summary>
        [EnumMember(Value = "expire_date")]
        ExpireDate,

        /// <summary>
        /// AllowPartialPay.
        /// </summary>
        [EnumMember(Value = "allow_partial_pay")]
        AllowPartialPay,

        /// <summary>
        /// AttachFilesToEmail.
        /// </summary>
        [EnumMember(Value = "attach_files_to_email")]
        AttachFilesToEmail,

        /// <summary>
        /// SendEmail.
        /// </summary>
        [EnumMember(Value = "send_email")]
        SendEmail,

        /// <summary>
        /// InvoiceNumber.
        /// </summary>
        [EnumMember(Value = "invoice_number")]
        InvoiceNumber,

        /// <summary>
        /// ItemHeader.
        /// </summary>
        [EnumMember(Value = "item_header")]
        ItemHeader,

        /// <summary>
        /// ItemFooter.
        /// </summary>
        [EnumMember(Value = "item_footer")]
        ItemFooter,

        /// <summary>
        /// AmountDue.
        /// </summary>
        [EnumMember(Value = "amount_due")]
        AmountDue,

        /// <summary>
        /// NotificationEmail.
        /// </summary>
        [EnumMember(Value = "notification_email")]
        NotificationEmail,

        /// <summary>
        /// StatusId.
        /// </summary>
        [EnumMember(Value = "status_id")]
        StatusId,

        /// <summary>
        /// StatusCode.
        /// </summary>
        [EnumMember(Value = "status_code")]
        StatusCode,

        /// <summary>
        /// Note.
        /// </summary>
        [EnumMember(Value = "note")]
        Note,

        /// <summary>
        /// NotificationDaysBeforeDueDate.
        /// </summary>
        [EnumMember(Value = "notification_days_before_due_date")]
        NotificationDaysBeforeDueDate,

        /// <summary>
        /// NotificationDaysAfterDueDate.
        /// </summary>
        [EnumMember(Value = "notification_days_after_due_date")]
        NotificationDaysAfterDueDate,

        /// <summary>
        /// NotificationOnDueDate.
        /// </summary>
        [EnumMember(Value = "notification_on_due_date")]
        NotificationOnDueDate,

        /// <summary>
        /// SendTextToPay.
        /// </summary>
        [EnumMember(Value = "send_text_to_pay")]
        SendTextToPay,

        /// <summary>
        /// Files.
        /// </summary>
        [EnumMember(Value = "files")]
        Files,

        /// <summary>
        /// RemainingBalance.
        /// </summary>
        [EnumMember(Value = "remaining_balance")]
        RemainingBalance,

        /// <summary>
        /// SinglePaymentMinAmount.
        /// </summary>
        [EnumMember(Value = "single_payment_min_amount")]
        SinglePaymentMinAmount,

        /// <summary>
        /// SinglePaymentMaxAmount.
        /// </summary>
        [EnumMember(Value = "single_payment_max_amount")]
        SinglePaymentMaxAmount,

        /// <summary>
        /// CellPhone.
        /// </summary>
        [EnumMember(Value = "cell_phone")]
        CellPhone,

        /// <summary>
        /// Tags.
        /// </summary>
        [EnumMember(Value = "tags")]
        Tags,

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
        /// Active.
        /// </summary>
        [EnumMember(Value = "active")]
        Active,

        /// <summary>
        /// PaymentStatusId.
        /// </summary>
        [EnumMember(Value = "payment_status_id")]
        PaymentStatusId,

        /// <summary>
        /// IsActive.
        /// </summary>
        [EnumMember(Value = "is_active")]
        IsActive,

        /// <summary>
        /// QuickInvoiceSetting.
        /// </summary>
        [EnumMember(Value = "quick_invoice_setting")]
        QuickInvoiceSetting,

        /// <summary>
        /// QuickInvoiceViews.
        /// </summary>
        [EnumMember(Value = "quick_invoice_views")]
        QuickInvoiceViews,

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
        /// ModifiedUser.
        /// </summary>
        [EnumMember(Value = "modified_user")]
        ModifiedUser,

        /// <summary>
        /// Changelogs.
        /// </summary>
        [EnumMember(Value = "changelogs")]
        Changelogs,

        /// <summary>
        /// Contact.
        /// </summary>
        [EnumMember(Value = "contact")]
        Contact,

        /// <summary>
        /// LogEmails.
        /// </summary>
        [EnumMember(Value = "log_emails")]
        LogEmails,

        /// <summary>
        /// LogSms.
        /// </summary>
        [EnumMember(Value = "log_sms")]
        LogSms,

        /// <summary>
        /// Transactions.
        /// </summary>
        [EnumMember(Value = "transactions")]
        Transactions,

        /// <summary>
        /// CcProductTransaction.
        /// </summary>
        [EnumMember(Value = "cc_product_transaction")]
        CcProductTransaction,

        /// <summary>
        /// AchProductTransaction.
        /// </summary>
        [EnumMember(Value = "ach_product_transaction")]
        AchProductTransaction,

        /// <summary>
        /// EmailBlacklist.
        /// </summary>
        [EnumMember(Value = "email_blacklist")]
        EmailBlacklist,

        /// <summary>
        /// SmsBlacklist.
        /// </summary>
        [EnumMember(Value = "sms_blacklist")]
        SmsBlacklist,

        /// <summary>
        /// PaymentUrl.
        /// </summary>
        [EnumMember(Value = "payment_url")]
        PaymentUrl,

        /// <summary>
        /// AllTags.
        /// </summary>
        [EnumMember(Value = "all_tags")]
        AllTags
    }
}