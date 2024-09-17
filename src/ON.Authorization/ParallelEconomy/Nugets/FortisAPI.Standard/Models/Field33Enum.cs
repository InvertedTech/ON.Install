// <copyright file="Field33Enum.cs" company="APIMatic">
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
    /// Field33Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Field33Enum
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
        /// ModifiedTs.
        /// </summary>
        [EnumMember(Value = "modified_ts")]
        ModifiedTs,

        /// <summary>
        /// AccountNumber.
        /// </summary>
        [EnumMember(Value = "account_number")]
        AccountNumber,

        /// <summary>
        /// Address.
        /// </summary>
        [EnumMember(Value = "address")]
        Address,

        /// <summary>
        /// BrandingDomainId.
        /// </summary>
        [EnumMember(Value = "branding_domain_id")]
        BrandingDomainId,

        /// <summary>
        /// ContactEmailTrxReceiptDefault.
        /// </summary>
        [EnumMember(Value = "contact_email_trx_receipt_default")]
        ContactEmailTrxReceiptDefault,

        /// <summary>
        /// DefaultAch.
        /// </summary>
        [EnumMember(Value = "default_ach")]
        DefaultAch,

        /// <summary>
        /// DefaultCc.
        /// </summary>
        [EnumMember(Value = "default_cc")]
        DefaultCc,

        /// <summary>
        /// EmailReplyTo.
        /// </summary>
        [EnumMember(Value = "email_reply_to")]
        EmailReplyTo,

        /// <summary>
        /// Fax.
        /// </summary>
        [EnumMember(Value = "fax")]
        Fax,

        /// <summary>
        /// LocationApiId.
        /// </summary>
        [EnumMember(Value = "location_api_id")]
        LocationApiId,

        /// <summary>
        /// LocationApiKey.
        /// </summary>
        [EnumMember(Value = "location_api_key")]
        LocationApiKey,

        /// <summary>
        /// LocationC1.
        /// </summary>
        [EnumMember(Value = "location_c1")]
        LocationC1,

        /// <summary>
        /// LocationC2.
        /// </summary>
        [EnumMember(Value = "location_c2")]
        LocationC2,

        /// <summary>
        /// LocationC3.
        /// </summary>
        [EnumMember(Value = "location_c3")]
        LocationC3,

        /// <summary>
        /// Name.
        /// </summary>
        [EnumMember(Value = "name")]
        Name,

        /// <summary>
        /// OfficePhone.
        /// </summary>
        [EnumMember(Value = "office_phone")]
        OfficePhone,

        /// <summary>
        /// OfficeExtPhone.
        /// </summary>
        [EnumMember(Value = "office_ext_phone")]
        OfficeExtPhone,

        /// <summary>
        /// Tz.
        /// </summary>
        [EnumMember(Value = "tz")]
        Tz,

        /// <summary>
        /// ParentId.
        /// </summary>
        [EnumMember(Value = "parent_id")]
        ParentId,

        /// <summary>
        /// ShowContactNotes.
        /// </summary>
        [EnumMember(Value = "show_contact_notes")]
        ShowContactNotes,

        /// <summary>
        /// ShowContactFiles.
        /// </summary>
        [EnumMember(Value = "show_contact_files")]
        ShowContactFiles,

        /// <summary>
        /// CreatedUserId.
        /// </summary>
        [EnumMember(Value = "created_user_id")]
        CreatedUserId,

        /// <summary>
        /// LocationType.
        /// </summary>
        [EnumMember(Value = "location_type")]
        LocationType,

        /// <summary>
        /// TicketHashKey.
        /// </summary>
        [EnumMember(Value = "ticket_hash_key")]
        TicketHashKey,

        /// <summary>
        /// Parent.
        /// </summary>
        [EnumMember(Value = "parent")]
        Parent,

        /// <summary>
        /// Users.
        /// </summary>
        [EnumMember(Value = "users")]
        Users,

        /// <summary>
        /// IsDeletable.
        /// </summary>
        [EnumMember(Value = "is_deletable")]
        IsDeletable,

        /// <summary>
        /// Terminals.
        /// </summary>
        [EnumMember(Value = "terminals")]
        Terminals,

        /// <summary>
        /// BrandingDomain.
        /// </summary>
        [EnumMember(Value = "branding_domain")]
        BrandingDomain,

        /// <summary>
        /// ProductInvoice.
        /// </summary>
        [EnumMember(Value = "product_invoice")]
        ProductInvoice,

        /// <summary>
        /// ProductFiles.
        /// </summary>
        [EnumMember(Value = "product_files")]
        ProductFiles,

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
        /// ProductTransactions.
        /// </summary>
        [EnumMember(Value = "product_transactions")]
        ProductTransactions,

        /// <summary>
        /// TerminalRouters.
        /// </summary>
        [EnumMember(Value = "terminal_routers")]
        TerminalRouters,

        /// <summary>
        /// DeveloperCompany.
        /// </summary>
        [EnumMember(Value = "developer_company")]
        DeveloperCompany,

        /// <summary>
        /// DeveloperCompanyId.
        /// </summary>
        [EnumMember(Value = "developer_company_id")]
        DeveloperCompanyId,

        /// <summary>
        /// Helppages.
        /// </summary>
        [EnumMember(Value = "helppages")]
        Helppages,

        /// <summary>
        /// QuickInvoiceSetting.
        /// </summary>
        [EnumMember(Value = "quick_invoice_setting")]
        QuickInvoiceSetting,

        /// <summary>
        /// LocationBillingAccounts.
        /// </summary>
        [EnumMember(Value = "location_billing_accounts")]
        LocationBillingAccounts,

        /// <summary>
        /// Marketplaces.
        /// </summary>
        [EnumMember(Value = "marketplaces")]
        Marketplaces,

        /// <summary>
        /// Locationmarketplaces.
        /// </summary>
        [EnumMember(Value = "locationmarketplaces")]
        Locationmarketplaces,

        /// <summary>
        /// Addons.
        /// </summary>
        [EnumMember(Value = "addons")]
        Addons
    }
}