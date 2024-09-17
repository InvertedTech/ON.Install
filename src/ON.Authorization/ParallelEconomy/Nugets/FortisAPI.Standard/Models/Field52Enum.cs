// <copyright file="Field52Enum.cs" company="APIMatic">
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
    /// Field52Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Field52Enum
    {
        /// <summary>
        /// AdditionalAmounts.
        /// </summary>
        [EnumMember(Value = "additional_amounts")]
        AdditionalAmounts,

        /// <summary>
        /// BillingAddress.
        /// </summary>
        [EnumMember(Value = "billing_address")]
        BillingAddress,

        /// <summary>
        /// CheckinDate.
        /// </summary>
        [EnumMember(Value = "checkin_date")]
        CheckinDate,

        /// <summary>
        /// CheckoutDate.
        /// </summary>
        [EnumMember(Value = "checkout_date")]
        CheckoutDate,

        /// <summary>
        /// ClerkNumber.
        /// </summary>
        [EnumMember(Value = "clerk_number")]
        ClerkNumber,

        /// <summary>
        /// ContactApiId.
        /// </summary>
        [EnumMember(Value = "contact_api_id")]
        ContactApiId,

        /// <summary>
        /// ContactId.
        /// </summary>
        [EnumMember(Value = "contact_id")]
        ContactId,

        /// <summary>
        /// CustomData.
        /// </summary>
        [EnumMember(Value = "custom_data")]
        CustomData,

        /// <summary>
        /// CustomerId.
        /// </summary>
        [EnumMember(Value = "customer_id")]
        CustomerId,

        /// <summary>
        /// Description.
        /// </summary>
        [EnumMember(Value = "description")]
        Description,

        /// <summary>
        /// IdentityVerification.
        /// </summary>
        [EnumMember(Value = "identity_verification")]
        IdentityVerification,

        /// <summary>
        /// IiasInd.
        /// </summary>
        [EnumMember(Value = "iias_ind")]
        IiasInd,

        /// <summary>
        /// ImageFront.
        /// </summary>
        [EnumMember(Value = "image_front")]
        ImageFront,

        /// <summary>
        /// ImageBack.
        /// </summary>
        [EnumMember(Value = "image_back")]
        ImageBack,

        /// <summary>
        /// Installment.
        /// </summary>
        [EnumMember(Value = "installment")]
        Installment,

        /// <summary>
        /// InstallmentNumber.
        /// </summary>
        [EnumMember(Value = "installment_number")]
        InstallmentNumber,

        /// <summary>
        /// InstallmentCount.
        /// </summary>
        [EnumMember(Value = "installment_count")]
        InstallmentCount,

        /// <summary>
        /// LocationApiId.
        /// </summary>
        [EnumMember(Value = "location_api_id")]
        LocationApiId,

        /// <summary>
        /// LocationId.
        /// </summary>
        [EnumMember(Value = "location_id")]
        LocationId,

        /// <summary>
        /// ProductTransactionId.
        /// </summary>
        [EnumMember(Value = "product_transaction_id")]
        ProductTransactionId,

        /// <summary>
        /// AdvanceDeposit.
        /// </summary>
        [EnumMember(Value = "advance_deposit")]
        AdvanceDeposit,

        /// <summary>
        /// NoShow.
        /// </summary>
        [EnumMember(Value = "no_show")]
        NoShow,

        /// <summary>
        /// NotificationEmailAddress.
        /// </summary>
        [EnumMember(Value = "notification_email_address")]
        NotificationEmailAddress,

        /// <summary>
        /// OrderNumber.
        /// </summary>
        [EnumMember(Value = "order_number")]
        OrderNumber,

        /// <summary>
        /// PoNumber.
        /// </summary>
        [EnumMember(Value = "po_number")]
        PoNumber,

        /// <summary>
        /// QuickInvoiceId.
        /// </summary>
        [EnumMember(Value = "quick_invoice_id")]
        QuickInvoiceId,

        /// <summary>
        /// Recurring.
        /// </summary>
        [EnumMember(Value = "recurring")]
        Recurring,

        /// <summary>
        /// RecurringNumber.
        /// </summary>
        [EnumMember(Value = "recurring_number")]
        RecurringNumber,

        /// <summary>
        /// RoomNum.
        /// </summary>
        [EnumMember(Value = "room_num")]
        RoomNum,

        /// <summary>
        /// RoomRate.
        /// </summary>
        [EnumMember(Value = "room_rate")]
        RoomRate,

        /// <summary>
        /// SaveAccount.
        /// </summary>
        [EnumMember(Value = "save_account")]
        SaveAccount,

        /// <summary>
        /// SaveAccountTitle.
        /// </summary>
        [EnumMember(Value = "save_account_title")]
        SaveAccountTitle,

        /// <summary>
        /// SubtotalAmount.
        /// </summary>
        [EnumMember(Value = "subtotal_amount")]
        SubtotalAmount,

        /// <summary>
        /// SurchargeAmount.
        /// </summary>
        [EnumMember(Value = "surcharge_amount")]
        SurchargeAmount,

        /// <summary>
        /// Tags.
        /// </summary>
        [EnumMember(Value = "tags")]
        Tags,

        /// <summary>
        /// Tax.
        /// </summary>
        [EnumMember(Value = "tax")]
        Tax,

        /// <summary>
        /// TipAmount.
        /// </summary>
        [EnumMember(Value = "tip_amount")]
        TipAmount,

        /// <summary>
        /// TransactionAmount.
        /// </summary>
        [EnumMember(Value = "transaction_amount")]
        TransactionAmount,

        /// <summary>
        /// SecondaryAmount.
        /// </summary>
        [EnumMember(Value = "secondary_amount")]
        SecondaryAmount,

        /// <summary>
        /// TransactionApiId.
        /// </summary>
        [EnumMember(Value = "transaction_api_id")]
        TransactionApiId,

        /// <summary>
        /// TransactionC1.
        /// </summary>
        [EnumMember(Value = "transaction_c1")]
        TransactionC1,

        /// <summary>
        /// TransactionC2.
        /// </summary>
        [EnumMember(Value = "transaction_c2")]
        TransactionC2,

        /// <summary>
        /// TransactionC3.
        /// </summary>
        [EnumMember(Value = "transaction_c3")]
        TransactionC3,

        /// <summary>
        /// BankFundedOnlyOverride.
        /// </summary>
        [EnumMember(Value = "bank_funded_only_override")]
        BankFundedOnlyOverride,

        /// <summary>
        /// AllowPartialAuthorizationOverride.
        /// </summary>
        [EnumMember(Value = "allow_partial_authorization_override")]
        AllowPartialAuthorizationOverride,

        /// <summary>
        /// AutoDeclineCvvOverride.
        /// </summary>
        [EnumMember(Value = "auto_decline_cvv_override")]
        AutoDeclineCvvOverride,

        /// <summary>
        /// AutoDeclineStreetOverride.
        /// </summary>
        [EnumMember(Value = "auto_decline_street_override")]
        AutoDeclineStreetOverride,

        /// <summary>
        /// AutoDeclineZipOverride.
        /// </summary>
        [EnumMember(Value = "auto_decline_zip_override")]
        AutoDeclineZipOverride,

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
        /// TerminalId.
        /// </summary>
        [EnumMember(Value = "terminal_id")]
        TerminalId,

        /// <summary>
        /// AccountHolderName.
        /// </summary>
        [EnumMember(Value = "account_holder_name")]
        AccountHolderName,

        /// <summary>
        /// AccountType.
        /// </summary>
        [EnumMember(Value = "account_type")]
        AccountType,

        /// <summary>
        /// TokenApiId.
        /// </summary>
        [EnumMember(Value = "token_api_id")]
        TokenApiId,

        /// <summary>
        /// TokenId.
        /// </summary>
        [EnumMember(Value = "token_id")]
        TokenId,

        /// <summary>
        /// AchIdentifier.
        /// </summary>
        [EnumMember(Value = "ach_identifier")]
        AchIdentifier,

        /// <summary>
        /// AchSecCode.
        /// </summary>
        [EnumMember(Value = "ach_sec_code")]
        AchSecCode,

        /// <summary>
        /// AuthAmount.
        /// </summary>
        [EnumMember(Value = "auth_amount")]
        AuthAmount,

        /// <summary>
        /// AuthCode.
        /// </summary>
        [EnumMember(Value = "auth_code")]
        AuthCode,

        /// <summary>
        /// Avs.
        /// </summary>
        [EnumMember(Value = "avs")]
        Avs,

        /// <summary>
        /// AvsEnhanced.
        /// </summary>
        [EnumMember(Value = "avs_enhanced")]
        AvsEnhanced,

        /// <summary>
        /// CardholderPresent.
        /// </summary>
        [EnumMember(Value = "cardholder_present")]
        CardholderPresent,

        /// <summary>
        /// CardPresent.
        /// </summary>
        [EnumMember(Value = "card_present")]
        CardPresent,

        /// <summary>
        /// CheckNumber.
        /// </summary>
        [EnumMember(Value = "check_number")]
        CheckNumber,

        /// <summary>
        /// CustomerIp.
        /// </summary>
        [EnumMember(Value = "customer_ip")]
        CustomerIp,

        /// <summary>
        /// CvvResponse.
        /// </summary>
        [EnumMember(Value = "cvv_response")]
        CvvResponse,

        /// <summary>
        /// EntryModeId.
        /// </summary>
        [EnumMember(Value = "entry_mode_id")]
        EntryModeId,

        /// <summary>
        /// EmvReceiptData.
        /// </summary>
        [EnumMember(Value = "emv_receipt_data")]
        EmvReceiptData,

        /// <summary>
        /// FirstSix.
        /// </summary>
        [EnumMember(Value = "first_six")]
        FirstSix,

        /// <summary>
        /// LastFour.
        /// </summary>
        [EnumMember(Value = "last_four")]
        LastFour,

        /// <summary>
        /// PaymentMethod.
        /// </summary>
        [EnumMember(Value = "payment_method")]
        PaymentMethod,

        /// <summary>
        /// TerminalSerialNumber.
        /// </summary>
        [EnumMember(Value = "terminal_serial_number")]
        TerminalSerialNumber,

        /// <summary>
        /// TransactionSettlementStatus.
        /// </summary>
        [EnumMember(Value = "transaction_settlement_status")]
        TransactionSettlementStatus,

        /// <summary>
        /// ChargeBackDate.
        /// </summary>
        [EnumMember(Value = "charge_back_date")]
        ChargeBackDate,

        /// <summary>
        /// IsRecurring.
        /// </summary>
        [EnumMember(Value = "is_recurring")]
        IsRecurring,

        /// <summary>
        /// NotificationEmailSent.
        /// </summary>
        [EnumMember(Value = "notification_email_sent")]
        NotificationEmailSent,

        /// <summary>
        /// Par.
        /// </summary>
        [EnumMember(Value = "par")]
        Par,

        /// <summary>
        /// ReasonCodeId.
        /// </summary>
        [EnumMember(Value = "reason_code_id")]
        ReasonCodeId,

        /// <summary>
        /// RecurringId.
        /// </summary>
        [EnumMember(Value = "recurring_id")]
        RecurringId,

        /// <summary>
        /// SettleDate.
        /// </summary>
        [EnumMember(Value = "settle_date")]
        SettleDate,

        /// <summary>
        /// StatusCode.
        /// </summary>
        [EnumMember(Value = "status_code")]
        StatusCode,

        /// <summary>
        /// TransactionBatchId.
        /// </summary>
        [EnumMember(Value = "transaction_batch_id")]
        TransactionBatchId,

        /// <summary>
        /// TypeId.
        /// </summary>
        [EnumMember(Value = "type_id")]
        TypeId,

        /// <summary>
        /// Verbiage.
        /// </summary>
        [EnumMember(Value = "verbiage")]
        Verbiage,

        /// <summary>
        /// VoidDate.
        /// </summary>
        [EnumMember(Value = "void_date")]
        VoidDate,

        /// <summary>
        /// Batch.
        /// </summary>
        [EnumMember(Value = "batch")]
        Batch,

        /// <summary>
        /// TermsAgree.
        /// </summary>
        [EnumMember(Value = "terms_agree")]
        TermsAgree,

        /// <summary>
        /// ResponseMessage.
        /// </summary>
        [EnumMember(Value = "response_message")]
        ResponseMessage,

        /// <summary>
        /// ReturnDate.
        /// </summary>
        [EnumMember(Value = "return_date")]
        ReturnDate,

        /// <summary>
        /// TrxSourceId.
        /// </summary>
        [EnumMember(Value = "trx_source_id")]
        TrxSourceId,

        /// <summary>
        /// RoutingNumber.
        /// </summary>
        [EnumMember(Value = "routing_number")]
        RoutingNumber,

        /// <summary>
        /// TrxSourceCode.
        /// </summary>
        [EnumMember(Value = "trx_source_code")]
        TrxSourceCode,

        /// <summary>
        /// PaylinkId.
        /// </summary>
        [EnumMember(Value = "paylink_id")]
        PaylinkId,

        /// <summary>
        /// CurrencyCode.
        /// </summary>
        [EnumMember(Value = "currency_code")]
        CurrencyCode,

        /// <summary>
        /// IsAccountvault.
        /// </summary>
        [EnumMember(Value = "is_accountvault")]
        IsAccountvault,

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
        /// TransactionCode.
        /// </summary>
        [EnumMember(Value = "transaction_code")]
        TransactionCode,

        /// <summary>
        /// EffectiveDate.
        /// </summary>
        [EnumMember(Value = "effective_date")]
        EffectiveDate,

        /// <summary>
        /// NotificationPhone.
        /// </summary>
        [EnumMember(Value = "notification_phone")]
        NotificationPhone,

        /// <summary>
        /// CavvResult.
        /// </summary>
        [EnumMember(Value = "cavv_result")]
        CavvResult,

        /// <summary>
        /// RecurringFlag.
        /// </summary>
        [EnumMember(Value = "recurring_flag")]
        RecurringFlag,

        /// <summary>
        /// IsToken.
        /// </summary>
        [EnumMember(Value = "is_token")]
        IsToken,

        /// <summary>
        /// InstallmentTotal.
        /// </summary>
        [EnumMember(Value = "installment_total")]
        InstallmentTotal,

        /// <summary>
        /// InstallmentCounter.
        /// </summary>
        [EnumMember(Value = "installment_counter")]
        InstallmentCounter,

        /// <summary>
        /// AccountVaultId.
        /// </summary>
        [EnumMember(Value = "account_vault_id")]
        AccountVaultId,

        /// <summary>
        /// HostedPaymentPageId.
        /// </summary>
        [EnumMember(Value = "hosted_payment_page_id")]
        HostedPaymentPageId,

        /// <summary>
        /// Stan.
        /// </summary>
        [EnumMember(Value = "stan")]
        Stan,

        /// <summary>
        /// Currency.
        /// </summary>
        [EnumMember(Value = "currency")]
        Currency,

        /// <summary>
        /// CardBin.
        /// </summary>
        [EnumMember(Value = "card_bin")]
        CardBin,

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
        /// AllTags.
        /// </summary>
        [EnumMember(Value = "all_tags")]
        AllTags,

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