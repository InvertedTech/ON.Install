// <copyright file="Expand95Enum.cs" company="APIMatic">
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
    /// Expand95Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Expand95Enum
    {
        /// <summary>
        /// ReceivedEmails.
        /// </summary>
        [EnumMember(Value = "received_emails")]
        ReceivedEmails,

        /// <summary>
        /// FeatureFlags.
        /// </summary>
        [EnumMember(Value = "feature_flags")]
        FeatureFlags,

        /// <summary>
        /// PrimaryLocation.
        /// </summary>
        [EnumMember(Value = "primary_location")]
        PrimaryLocation,

        /// <summary>
        /// Locations.
        /// </summary>
        [EnumMember(Value = "locations")]
        Locations,

        /// <summary>
        /// Contact.
        /// </summary>
        [EnumMember(Value = "contact")]
        Contact,

        /// <summary>
        /// IsDeletable.
        /// </summary>
        [EnumMember(Value = "isDeletable")]
        IsDeletable,

        /// <summary>
        /// ActiveNotificationAlerts.
        /// </summary>
        [EnumMember(Value = "active_notification_alerts")]
        ActiveNotificationAlerts,

        /// <summary>
        /// LocationUsers.
        /// </summary>
        [EnumMember(Value = "location_users")]
        LocationUsers,

        /// <summary>
        /// AuthRoles.
        /// </summary>
        [EnumMember(Value = "auth_roles")]
        AuthRoles,

        /// <summary>
        /// ContactId.
        /// </summary>
        [EnumMember(Value = "contact_id")]
        ContactId,

        /// <summary>
        /// Changelogs.
        /// </summary>
        [EnumMember(Value = "changelogs")]
        Changelogs,

        /// <summary>
        /// Resources.
        /// </summary>
        [EnumMember(Value = "resources")]
        Resources,

        /// <summary>
        /// Domain.
        /// </summary>
        [EnumMember(Value = "domain")]
        Domain,

        /// <summary>
        /// CreatedUser.
        /// </summary>
        [EnumMember(Value = "created_user")]
        CreatedUser,

        /// <summary>
        /// LocationMarketplaces.
        /// </summary>
        [EnumMember(Value = "location_marketplaces")]
        LocationMarketplaces,

        /// <summary>
        /// EmailBlacklist.
        /// </summary>
        [EnumMember(Value = "email_blacklist")]
        EmailBlacklist,

        /// <summary>
        /// Helppage.
        /// </summary>
        [EnumMember(Value = "helppage")]
        Helppage
    }
}