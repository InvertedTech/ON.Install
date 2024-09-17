// <copyright file="Expand10Enum.cs" company="APIMatic">
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
    /// Expand10Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Expand10Enum
    {
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
        /// Parent.
        /// </summary>
        [EnumMember(Value = "parent")]
        Parent,

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
        /// Terminals.
        /// </summary>
        [EnumMember(Value = "terminals")]
        Terminals,

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