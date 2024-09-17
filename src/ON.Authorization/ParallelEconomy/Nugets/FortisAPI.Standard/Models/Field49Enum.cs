// <copyright file="Field49Enum.cs" company="APIMatic">
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
    /// Field49Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Field49Enum
    {
        /// <summary>
        /// AccountHolderName.
        /// </summary>
        [EnumMember(Value = "account_holder_name")]
        AccountHolderName,

        /// <summary>
        /// AccountNumber.
        /// </summary>
        [EnumMember(Value = "account_number")]
        AccountNumber,

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
        /// AccountvaultC1.
        /// </summary>
        [EnumMember(Value = "accountvault_c1")]
        AccountvaultC1,

        /// <summary>
        /// AccountvaultC2.
        /// </summary>
        [EnumMember(Value = "accountvault_c2")]
        AccountvaultC2,

        /// <summary>
        /// AccountvaultC3.
        /// </summary>
        [EnumMember(Value = "accountvault_c3")]
        AccountvaultC3,

        /// <summary>
        /// TokenC1.
        /// </summary>
        [EnumMember(Value = "token_c1")]
        TokenC1,

        /// <summary>
        /// TokenC2.
        /// </summary>
        [EnumMember(Value = "token_c2")]
        TokenC2,

        /// <summary>
        /// TokenC3.
        /// </summary>
        [EnumMember(Value = "token_c3")]
        TokenC3,

        /// <summary>
        /// AchSecCode.
        /// </summary>
        [EnumMember(Value = "ach_sec_code")]
        AchSecCode,

        /// <summary>
        /// BillingAddress.
        /// </summary>
        [EnumMember(Value = "billing_address")]
        BillingAddress,

        /// <summary>
        /// ContactId.
        /// </summary>
        [EnumMember(Value = "contact_id")]
        ContactId,

        /// <summary>
        /// CustomerId.
        /// </summary>
        [EnumMember(Value = "customer_id")]
        CustomerId,

        /// <summary>
        /// IdentityVerification.
        /// </summary>
        [EnumMember(Value = "identity_verification")]
        IdentityVerification,

        /// <summary>
        /// LocationId.
        /// </summary>
        [EnumMember(Value = "location_id")]
        LocationId,

        /// <summary>
        /// PreviousAccountVaultApiId.
        /// </summary>
        [EnumMember(Value = "previous_account_vault_api_id")]
        PreviousAccountVaultApiId,

        /// <summary>
        /// PreviousTokenApiId.
        /// </summary>
        [EnumMember(Value = "previous_token_api_id")]
        PreviousTokenApiId,

        /// <summary>
        /// PreviousAccountVaultId.
        /// </summary>
        [EnumMember(Value = "previous_account_vault_id")]
        PreviousAccountVaultId,

        /// <summary>
        /// PreviousTokenId.
        /// </summary>
        [EnumMember(Value = "previous_token_id")]
        PreviousTokenId,

        /// <summary>
        /// PreviousTransactionId.
        /// </summary>
        [EnumMember(Value = "previous_transaction_id")]
        PreviousTransactionId,

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
        /// Title.
        /// </summary>
        [EnumMember(Value = "title")]
        Title,

        /// <summary>
        /// Joi.
        /// </summary>
        [EnumMember(Value = "_joi")]
        Joi,

        /// <summary>
        /// Id.
        /// </summary>
        [EnumMember(Value = "id")]
        Id,

        /// <summary>
        /// AccountType.
        /// </summary>
        [EnumMember(Value = "account_type")]
        AccountType,

        /// <summary>
        /// Active.
        /// </summary>
        [EnumMember(Value = "active")]
        Active,

        /// <summary>
        /// CauSummaryStatusId.
        /// </summary>
        [EnumMember(Value = "cau_summary_status_id")]
        CauSummaryStatusId,

        /// <summary>
        /// CreatedTs.
        /// </summary>
        [EnumMember(Value = "created_ts")]
        CreatedTs,

        /// <summary>
        /// ESerialNumber.
        /// </summary>
        [EnumMember(Value = "e_serial_number")]
        ESerialNumber,

        /// <summary>
        /// ETrackData.
        /// </summary>
        [EnumMember(Value = "e_track_data")]
        ETrackData,

        /// <summary>
        /// EFormat.
        /// </summary>
        [EnumMember(Value = "e_format")]
        EFormat,

        /// <summary>
        /// EKeyedData.
        /// </summary>
        [EnumMember(Value = "e_keyed_data")]
        EKeyedData,

        /// <summary>
        /// ExpiringInMonths.
        /// </summary>
        [EnumMember(Value = "expiring_in_months")]
        ExpiringInMonths,

        /// <summary>
        /// ExpDate.
        /// </summary>
        [EnumMember(Value = "exp_date")]
        ExpDate,

        /// <summary>
        /// FirstSix.
        /// </summary>
        [EnumMember(Value = "first_six")]
        FirstSix,

        /// <summary>
        /// HasRecurring.
        /// </summary>
        [EnumMember(Value = "has_recurring")]
        HasRecurring,

        /// <summary>
        /// LastFour.
        /// </summary>
        [EnumMember(Value = "last_four")]
        LastFour,

        /// <summary>
        /// ModifiedTs.
        /// </summary>
        [EnumMember(Value = "modified_ts")]
        ModifiedTs,

        /// <summary>
        /// PaymentMethod.
        /// </summary>
        [EnumMember(Value = "payment_method")]
        PaymentMethod,

        /// <summary>
        /// Ticket.
        /// </summary>
        [EnumMember(Value = "ticket")]
        Ticket,

        /// <summary>
        /// TrackData.
        /// </summary>
        [EnumMember(Value = "track_data")]
        TrackData,

        /// <summary>
        /// CreatedUserId.
        /// </summary>
        [EnumMember(Value = "created_user_id")]
        CreatedUserId,

        /// <summary>
        /// CauLastUpdatedTs.
        /// </summary>
        [EnumMember(Value = "cau_last_updated_ts")]
        CauLastUpdatedTs,

        /// <summary>
        /// CardBin.
        /// </summary>
        [EnumMember(Value = "card_bin")]
        CardBin,

        /// <summary>
        /// RoutingNumber.
        /// </summary>
        [EnumMember(Value = "routing_number")]
        RoutingNumber,

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
        /// Transactions.
        /// </summary>
        [EnumMember(Value = "transactions")]
        Transactions,

        /// <summary>
        /// ActiveRecurrings.
        /// </summary>
        [EnumMember(Value = "activeRecurrings")]
        ActiveRecurrings,

        /// <summary>
        /// IsDeletable.
        /// </summary>
        [EnumMember(Value = "is_deletable")]
        IsDeletable,

        /// <summary>
        /// Signature.
        /// </summary>
        [EnumMember(Value = "signature")]
        Signature,

        /// <summary>
        /// CreatedUser.
        /// </summary>
        [EnumMember(Value = "created_user")]
        CreatedUser,

        /// <summary>
        /// Changelogs.
        /// </summary>
        [EnumMember(Value = "changelogs")]
        Changelogs,

        /// <summary>
        /// AccountVaultCauLogs.
        /// </summary>
        [EnumMember(Value = "account_vault_cau_logs")]
        AccountVaultCauLogs,

        /// <summary>
        /// AccountVaultCauProductTransactions.
        /// </summary>
        [EnumMember(Value = "account_vault_cau_product_transactions")]
        AccountVaultCauProductTransactions
    }
}