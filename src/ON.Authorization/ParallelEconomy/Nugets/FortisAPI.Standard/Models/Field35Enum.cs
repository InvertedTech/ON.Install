// <copyright file="Field35Enum.cs" company="APIMatic">
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
    /// Field35Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Field35Enum
    {
        /// <summary>
        /// LocationId.
        /// </summary>
        [EnumMember(Value = "location_id")]
        LocationId,

        /// <summary>
        /// CcProductTransactionId.
        /// </summary>
        [EnumMember(Value = "cc_product_transaction_id")]
        CcProductTransactionId,

        /// <summary>
        /// Email.
        /// </summary>
        [EnumMember(Value = "email")]
        Email,

        /// <summary>
        /// AmountDue.
        /// </summary>
        [EnumMember(Value = "amount_due")]
        AmountDue,

        /// <summary>
        /// LocationApiId.
        /// </summary>
        [EnumMember(Value = "location_api_id")]
        LocationApiId,

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
        /// PaylinkApiId.
        /// </summary>
        [EnumMember(Value = "paylink_api_id")]
        PaylinkApiId,

        /// <summary>
        /// AchProductTransactionId.
        /// </summary>
        [EnumMember(Value = "ach_product_transaction_id")]
        AchProductTransactionId,

        /// <summary>
        /// ExpireDate.
        /// </summary>
        [EnumMember(Value = "expire_date")]
        ExpireDate,

        /// <summary>
        /// DisplayProductTransactionReceiptDetails.
        /// </summary>
        [EnumMember(Value = "display_product_transaction_receipt_details")]
        DisplayProductTransactionReceiptDetails,

        /// <summary>
        /// DisplayBillingFields.
        /// </summary>
        [EnumMember(Value = "display_billing_fields")]
        DisplayBillingFields,

        /// <summary>
        /// DeliveryMethod.
        /// </summary>
        [EnumMember(Value = "delivery_method")]
        DeliveryMethod,

        /// <summary>
        /// CellPhone.
        /// </summary>
        [EnumMember(Value = "cell_phone")]
        CellPhone,

        /// <summary>
        /// Description.
        /// </summary>
        [EnumMember(Value = "description")]
        Description,

        /// <summary>
        /// StoreToken.
        /// </summary>
        [EnumMember(Value = "store_token")]
        StoreToken,

        /// <summary>
        /// StoreTokenTitle.
        /// </summary>
        [EnumMember(Value = "store_token_title")]
        StoreTokenTitle,

        /// <summary>
        /// PaylinkAction.
        /// </summary>
        [EnumMember(Value = "paylink_action")]
        PaylinkAction,

        /// <summary>
        /// BankFundedOnlyOverride.
        /// </summary>
        [EnumMember(Value = "bank_funded_only_override")]
        BankFundedOnlyOverride,

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
        /// Active.
        /// </summary>
        [EnumMember(Value = "active")]
        Active,

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
        /// AllTags.
        /// </summary>
        [EnumMember(Value = "all_tags")]
        AllTags,

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
        PaymentUrl
    }
}