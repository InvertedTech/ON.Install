// <copyright file="List3.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// List3.
    /// </summary>
    public class List3
    {
        private string brandingDomainUrl;
        private string accountNumber;
        private string brandingDomainId;
        private string defaultAch;
        private string defaultCc;
        private string developerCompanyId;
        private string emailReplyTo;
        private string fax;
        private string locationApiId;
        private string locationApiKey;
        private string locationC1;
        private string locationC2;
        private string locationC3;
        private string officePhone;
        private string officeExtPhone;
        private int? recurringNotificationDaysDefault;
        private string tz;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "branding_domain_url", false },
            { "account_number", false },
            { "branding_domain_id", false },
            { "default_ach", false },
            { "default_cc", false },
            { "developer_company_id", false },
            { "email_reply_to", false },
            { "fax", false },
            { "location_api_id", false },
            { "location_api_key", false },
            { "location_c1", false },
            { "location_c2", false },
            { "location_c3", false },
            { "office_phone", false },
            { "office_ext_phone", false },
            { "recurring_notification_days_default", false },
            { "tz", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="List3"/> class.
        /// </summary>
        public List3()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="List3"/> class.
        /// </summary>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="id">id.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="name">name.</param>
        /// <param name="parentId">parent_id.</param>
        /// <param name="brandingDomain">branding_domain.</param>
        /// <param name="productTransactions">product_transactions.</param>
        /// <param name="productFile">product_file.</param>
        /// <param name="productAccountvault">product_accountvault.</param>
        /// <param name="productRecurring">product_recurring.</param>
        /// <param name="tags">tags.</param>
        /// <param name="terminals">terminals.</param>
        /// <param name="brandingDomainUrl">branding_domain_url.</param>
        /// <param name="accountNumber">account_number.</param>
        /// <param name="address">address.</param>
        /// <param name="brandingDomainId">branding_domain_id.</param>
        /// <param name="contactEmailTrxReceiptDefault">contact_email_trx_receipt_default.</param>
        /// <param name="defaultAch">default_ach.</param>
        /// <param name="defaultCc">default_cc.</param>
        /// <param name="developerCompanyId">developer_company_id.</param>
        /// <param name="emailReplyTo">email_reply_to.</param>
        /// <param name="fax">fax.</param>
        /// <param name="locationApiId">location_api_id.</param>
        /// <param name="locationApiKey">location_api_key.</param>
        /// <param name="locationC1">location_c1.</param>
        /// <param name="locationC2">location_c2.</param>
        /// <param name="locationC3">location_c3.</param>
        /// <param name="officePhone">office_phone.</param>
        /// <param name="officeExtPhone">office_ext_phone.</param>
        /// <param name="recurringNotificationDaysDefault">recurring_notification_days_default.</param>
        /// <param name="tz">tz.</param>
        public List3(
            int createdTs,
            string id,
            int modifiedTs,
            string name,
            string parentId,
            object brandingDomain,
            object productTransactions,
            object productFile,
            object productAccountvault,
            object productRecurring,
            object tags,
            object terminals,
            string brandingDomainUrl = null,
            string accountNumber = null,
            Models.Address2 address = null,
            string brandingDomainId = null,
            bool? contactEmailTrxReceiptDefault = null,
            string defaultAch = null,
            string defaultCc = null,
            string developerCompanyId = null,
            string emailReplyTo = null,
            string fax = null,
            string locationApiId = null,
            string locationApiKey = null,
            string locationC1 = null,
            string locationC2 = null,
            string locationC3 = null,
            string officePhone = null,
            string officeExtPhone = null,
            int? recurringNotificationDaysDefault = null,
            string tz = null)
        {
            if (brandingDomainUrl != null)
            {
                this.BrandingDomainUrl = brandingDomainUrl;
            }

            this.CreatedTs = createdTs;
            this.Id = id;
            this.ModifiedTs = modifiedTs;
            if (accountNumber != null)
            {
                this.AccountNumber = accountNumber;
            }

            this.Address = address;
            if (brandingDomainId != null)
            {
                this.BrandingDomainId = brandingDomainId;
            }

            this.ContactEmailTrxReceiptDefault = contactEmailTrxReceiptDefault;
            if (defaultAch != null)
            {
                this.DefaultAch = defaultAch;
            }

            if (defaultCc != null)
            {
                this.DefaultCc = defaultCc;
            }

            if (developerCompanyId != null)
            {
                this.DeveloperCompanyId = developerCompanyId;
            }

            if (emailReplyTo != null)
            {
                this.EmailReplyTo = emailReplyTo;
            }

            if (fax != null)
            {
                this.Fax = fax;
            }

            if (locationApiId != null)
            {
                this.LocationApiId = locationApiId;
            }

            if (locationApiKey != null)
            {
                this.LocationApiKey = locationApiKey;
            }

            if (locationC1 != null)
            {
                this.LocationC1 = locationC1;
            }

            if (locationC2 != null)
            {
                this.LocationC2 = locationC2;
            }

            if (locationC3 != null)
            {
                this.LocationC3 = locationC3;
            }

            this.Name = name;
            if (officePhone != null)
            {
                this.OfficePhone = officePhone;
            }

            if (officeExtPhone != null)
            {
                this.OfficeExtPhone = officeExtPhone;
            }

            this.ParentId = parentId;
            if (recurringNotificationDaysDefault != null)
            {
                this.RecurringNotificationDaysDefault = recurringNotificationDaysDefault;
            }

            if (tz != null)
            {
                this.Tz = tz;
            }

            this.BrandingDomain = brandingDomain;
            this.ProductTransactions = productTransactions;
            this.ProductFile = productFile;
            this.ProductAccountvault = productAccountvault;
            this.ProductRecurring = productRecurring;
            this.Tags = tags;
            this.Terminals = terminals;
        }

        /// <summary>
        /// Branding domain URL
        /// </summary>
        [JsonProperty("branding_domain_url")]
        public string BrandingDomainUrl
        {
            get
            {
                return this.brandingDomainUrl;
            }

            set
            {
                this.shouldSerialize["branding_domain_url"] = true;
                this.brandingDomainUrl = value;
            }
        }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int CreatedTs { get; set; }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts")]
        public int ModifiedTs { get; set; }

        /// <summary>
        /// Account number
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber
        {
            get
            {
                return this.accountNumber;
            }

            set
            {
                this.shouldSerialize["account_number"] = true;
                this.accountNumber = value;
            }
        }

        /// <summary>
        /// Address
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address2 Address { get; set; }

        /// <summary>
        /// GUID for Branding Domain
        /// </summary>
        [JsonProperty("branding_domain_id")]
        public string BrandingDomainId
        {
            get
            {
                return this.brandingDomainId;
            }

            set
            {
                this.shouldSerialize["branding_domain_id"] = true;
                this.brandingDomainId = value;
            }
        }

        /// <summary>
        /// If true, will email contact receipt for any transaction
        /// </summary>
        [JsonProperty("contact_email_trx_receipt_default", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ContactEmailTrxReceiptDefault { get; set; }

        /// <summary>
        /// GUID for Location's default ACH Product Transaction
        /// </summary>
        [JsonProperty("default_ach")]
        public string DefaultAch
        {
            get
            {
                return this.defaultAch;
            }

            set
            {
                this.shouldSerialize["default_ach"] = true;
                this.defaultAch = value;
            }
        }

        /// <summary>
        /// GUID for Location's default CC Product Transaction
        /// </summary>
        [JsonProperty("default_cc")]
        public string DefaultCc
        {
            get
            {
                return this.defaultCc;
            }

            set
            {
                this.shouldSerialize["default_cc"] = true;
                this.defaultCc = value;
            }
        }

        /// <summary>
        /// GUID for Developer Company
        /// </summary>
        [JsonProperty("developer_company_id")]
        public string DeveloperCompanyId
        {
            get
            {
                return this.developerCompanyId;
            }

            set
            {
                this.shouldSerialize["developer_company_id"] = true;
                this.developerCompanyId = value;
            }
        }

        /// <summary>
        /// Used as from email address when sending various notifications
        /// </summary>
        [JsonProperty("email_reply_to")]
        public string EmailReplyTo
        {
            get
            {
                return this.emailReplyTo;
            }

            set
            {
                this.shouldSerialize["email_reply_to"] = true;
                this.emailReplyTo = value;
            }
        }

        /// <summary>
        /// Fax number
        /// </summary>
        [JsonProperty("fax")]
        public string Fax
        {
            get
            {
                return this.fax;
            }

            set
            {
                this.shouldSerialize["fax"] = true;
                this.fax = value;
            }
        }

        /// <summary>
        /// Location api ID
        /// </summary>
        [JsonProperty("location_api_id")]
        public string LocationApiId
        {
            get
            {
                return this.locationApiId;
            }

            set
            {
                this.shouldSerialize["location_api_id"] = true;
                this.locationApiId = value;
            }
        }

        /// <summary>
        /// Location api key
        /// </summary>
        [JsonProperty("location_api_key")]
        public string LocationApiKey
        {
            get
            {
                return this.locationApiKey;
            }

            set
            {
                this.shouldSerialize["location_api_key"] = true;
                this.locationApiKey = value;
            }
        }

        /// <summary>
        /// Can be used to store custom information for location.
        /// </summary>
        [JsonProperty("location_c1")]
        public string LocationC1
        {
            get
            {
                return this.locationC1;
            }

            set
            {
                this.shouldSerialize["location_c1"] = true;
                this.locationC1 = value;
            }
        }

        /// <summary>
        /// Can be used to store custom information for location.
        /// </summary>
        [JsonProperty("location_c2")]
        public string LocationC2
        {
            get
            {
                return this.locationC2;
            }

            set
            {
                this.shouldSerialize["location_c2"] = true;
                this.locationC2 = value;
            }
        }

        /// <summary>
        /// Can be used to store custom information for location.
        /// </summary>
        [JsonProperty("location_c3")]
        public string LocationC3
        {
            get
            {
                return this.locationC3;
            }

            set
            {
                this.shouldSerialize["location_c3"] = true;
                this.locationC3 = value;
            }
        }

        /// <summary>
        /// Name of the company
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Office phone number
        /// </summary>
        [JsonProperty("office_phone")]
        public string OfficePhone
        {
            get
            {
                return this.officePhone;
            }

            set
            {
                this.shouldSerialize["office_phone"] = true;
                this.officePhone = value;
            }
        }

        /// <summary>
        /// Office phone extension number
        /// </summary>
        [JsonProperty("office_ext_phone")]
        public string OfficeExtPhone
        {
            get
            {
                return this.officeExtPhone;
            }

            set
            {
                this.shouldSerialize["office_ext_phone"] = true;
                this.officeExtPhone = value;
            }
        }

        /// <summary>
        /// Location GUID of the parent location
        /// </summary>
        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        /// <summary>
        /// Number of days prior to a Recurring running that a notification should be sent
        /// </summary>
        [JsonProperty("recurring_notification_days_default")]
        public int? RecurringNotificationDaysDefault
        {
            get
            {
                return this.recurringNotificationDaysDefault;
            }

            set
            {
                this.shouldSerialize["recurring_notification_days_default"] = true;
                this.recurringNotificationDaysDefault = value;
            }
        }

        /// <summary>
        /// Time zone
        /// </summary>
        [JsonProperty("tz")]
        public string Tz
        {
            get
            {
                return this.tz;
            }

            set
            {
                this.shouldSerialize["tz"] = true;
                this.tz = value;
            }
        }

        /// <summary>
        /// Branding domain array
        /// </summary>
        [JsonProperty("branding_domain")]
        public object BrandingDomain { get; set; }

        /// <summary>
        /// Product Transactions array
        /// </summary>
        [JsonProperty("product_transactions")]
        public object ProductTransactions { get; set; }

        /// <summary>
        /// Product file array
        /// </summary>
        [JsonProperty("product_file")]
        public object ProductFile { get; set; }

        /// <summary>
        /// Product account vault array
        /// </summary>
        [JsonProperty("product_accountvault")]
        public object ProductAccountvault { get; set; }

        /// <summary>
        /// Product recurring array
        /// </summary>
        [JsonProperty("product_recurring")]
        public object ProductRecurring { get; set; }

        /// <summary>
        /// Tags array
        /// </summary>
        [JsonProperty("tags")]
        public object Tags { get; set; }

        /// <summary>
        /// Terminals array
        /// </summary>
        [JsonProperty("terminals")]
        public object Terminals { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"List3 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetBrandingDomainUrl()
        {
            this.shouldSerialize["branding_domain_url"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAccountNumber()
        {
            this.shouldSerialize["account_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetBrandingDomainId()
        {
            this.shouldSerialize["branding_domain_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDefaultAch()
        {
            this.shouldSerialize["default_ach"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDefaultCc()
        {
            this.shouldSerialize["default_cc"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDeveloperCompanyId()
        {
            this.shouldSerialize["developer_company_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEmailReplyTo()
        {
            this.shouldSerialize["email_reply_to"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFax()
        {
            this.shouldSerialize["fax"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocationApiId()
        {
            this.shouldSerialize["location_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocationApiKey()
        {
            this.shouldSerialize["location_api_key"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocationC1()
        {
            this.shouldSerialize["location_c1"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocationC2()
        {
            this.shouldSerialize["location_c2"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocationC3()
        {
            this.shouldSerialize["location_c3"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetOfficePhone()
        {
            this.shouldSerialize["office_phone"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetOfficeExtPhone()
        {
            this.shouldSerialize["office_ext_phone"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRecurringNotificationDaysDefault()
        {
            this.shouldSerialize["recurring_notification_days_default"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTz()
        {
            this.shouldSerialize["tz"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBrandingDomainUrl()
        {
            return this.shouldSerialize["branding_domain_url"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountNumber()
        {
            return this.shouldSerialize["account_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBrandingDomainId()
        {
            return this.shouldSerialize["branding_domain_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDefaultAch()
        {
            return this.shouldSerialize["default_ach"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDefaultCc()
        {
            return this.shouldSerialize["default_cc"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDeveloperCompanyId()
        {
            return this.shouldSerialize["developer_company_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmailReplyTo()
        {
            return this.shouldSerialize["email_reply_to"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFax()
        {
            return this.shouldSerialize["fax"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationApiId()
        {
            return this.shouldSerialize["location_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationApiKey()
        {
            return this.shouldSerialize["location_api_key"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationC1()
        {
            return this.shouldSerialize["location_c1"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationC2()
        {
            return this.shouldSerialize["location_c2"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationC3()
        {
            return this.shouldSerialize["location_c3"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOfficePhone()
        {
            return this.shouldSerialize["office_phone"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOfficeExtPhone()
        {
            return this.shouldSerialize["office_ext_phone"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRecurringNotificationDaysDefault()
        {
            return this.shouldSerialize["recurring_notification_days_default"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTz()
        {
            return this.shouldSerialize["tz"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is List3 other &&
                ((this.BrandingDomainUrl == null && other.BrandingDomainUrl == null) || (this.BrandingDomainUrl?.Equals(other.BrandingDomainUrl) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                ((this.AccountNumber == null && other.AccountNumber == null) || (this.AccountNumber?.Equals(other.AccountNumber) == true)) &&
                ((this.Address == null && other.Address == null) || (this.Address?.Equals(other.Address) == true)) &&
                ((this.BrandingDomainId == null && other.BrandingDomainId == null) || (this.BrandingDomainId?.Equals(other.BrandingDomainId) == true)) &&
                ((this.ContactEmailTrxReceiptDefault == null && other.ContactEmailTrxReceiptDefault == null) || (this.ContactEmailTrxReceiptDefault?.Equals(other.ContactEmailTrxReceiptDefault) == true)) &&
                ((this.DefaultAch == null && other.DefaultAch == null) || (this.DefaultAch?.Equals(other.DefaultAch) == true)) &&
                ((this.DefaultCc == null && other.DefaultCc == null) || (this.DefaultCc?.Equals(other.DefaultCc) == true)) &&
                ((this.DeveloperCompanyId == null && other.DeveloperCompanyId == null) || (this.DeveloperCompanyId?.Equals(other.DeveloperCompanyId) == true)) &&
                ((this.EmailReplyTo == null && other.EmailReplyTo == null) || (this.EmailReplyTo?.Equals(other.EmailReplyTo) == true)) &&
                ((this.Fax == null && other.Fax == null) || (this.Fax?.Equals(other.Fax) == true)) &&
                ((this.LocationApiId == null && other.LocationApiId == null) || (this.LocationApiId?.Equals(other.LocationApiId) == true)) &&
                ((this.LocationApiKey == null && other.LocationApiKey == null) || (this.LocationApiKey?.Equals(other.LocationApiKey) == true)) &&
                ((this.LocationC1 == null && other.LocationC1 == null) || (this.LocationC1?.Equals(other.LocationC1) == true)) &&
                ((this.LocationC2 == null && other.LocationC2 == null) || (this.LocationC2?.Equals(other.LocationC2) == true)) &&
                ((this.LocationC3 == null && other.LocationC3 == null) || (this.LocationC3?.Equals(other.LocationC3) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.OfficePhone == null && other.OfficePhone == null) || (this.OfficePhone?.Equals(other.OfficePhone) == true)) &&
                ((this.OfficeExtPhone == null && other.OfficeExtPhone == null) || (this.OfficeExtPhone?.Equals(other.OfficeExtPhone) == true)) &&
                ((this.ParentId == null && other.ParentId == null) || (this.ParentId?.Equals(other.ParentId) == true)) &&
                ((this.RecurringNotificationDaysDefault == null && other.RecurringNotificationDaysDefault == null) || (this.RecurringNotificationDaysDefault?.Equals(other.RecurringNotificationDaysDefault) == true)) &&
                ((this.Tz == null && other.Tz == null) || (this.Tz?.Equals(other.Tz) == true)) &&
                ((this.BrandingDomain == null && other.BrandingDomain == null) || (this.BrandingDomain?.Equals(other.BrandingDomain) == true)) &&
                ((this.ProductTransactions == null && other.ProductTransactions == null) || (this.ProductTransactions?.Equals(other.ProductTransactions) == true)) &&
                ((this.ProductFile == null && other.ProductFile == null) || (this.ProductFile?.Equals(other.ProductFile) == true)) &&
                ((this.ProductAccountvault == null && other.ProductAccountvault == null) || (this.ProductAccountvault?.Equals(other.ProductAccountvault) == true)) &&
                ((this.ProductRecurring == null && other.ProductRecurring == null) || (this.ProductRecurring?.Equals(other.ProductRecurring) == true)) &&
                ((this.Tags == null && other.Tags == null) || (this.Tags?.Equals(other.Tags) == true)) &&
                ((this.Terminals == null && other.Terminals == null) || (this.Terminals?.Equals(other.Terminals) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BrandingDomainUrl = {(this.BrandingDomainUrl == null ? "null" : this.BrandingDomainUrl == string.Empty ? "" : this.BrandingDomainUrl)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.AccountNumber = {(this.AccountNumber == null ? "null" : this.AccountNumber == string.Empty ? "" : this.AccountNumber)}");
            toStringOutput.Add($"this.Address = {(this.Address == null ? "null" : this.Address.ToString())}");
            toStringOutput.Add($"this.BrandingDomainId = {(this.BrandingDomainId == null ? "null" : this.BrandingDomainId == string.Empty ? "" : this.BrandingDomainId)}");
            toStringOutput.Add($"this.ContactEmailTrxReceiptDefault = {(this.ContactEmailTrxReceiptDefault == null ? "null" : this.ContactEmailTrxReceiptDefault.ToString())}");
            toStringOutput.Add($"this.DefaultAch = {(this.DefaultAch == null ? "null" : this.DefaultAch == string.Empty ? "" : this.DefaultAch)}");
            toStringOutput.Add($"this.DefaultCc = {(this.DefaultCc == null ? "null" : this.DefaultCc == string.Empty ? "" : this.DefaultCc)}");
            toStringOutput.Add($"this.DeveloperCompanyId = {(this.DeveloperCompanyId == null ? "null" : this.DeveloperCompanyId == string.Empty ? "" : this.DeveloperCompanyId)}");
            toStringOutput.Add($"this.EmailReplyTo = {(this.EmailReplyTo == null ? "null" : this.EmailReplyTo == string.Empty ? "" : this.EmailReplyTo)}");
            toStringOutput.Add($"this.Fax = {(this.Fax == null ? "null" : this.Fax == string.Empty ? "" : this.Fax)}");
            toStringOutput.Add($"this.LocationApiId = {(this.LocationApiId == null ? "null" : this.LocationApiId == string.Empty ? "" : this.LocationApiId)}");
            toStringOutput.Add($"this.LocationApiKey = {(this.LocationApiKey == null ? "null" : this.LocationApiKey == string.Empty ? "" : this.LocationApiKey)}");
            toStringOutput.Add($"this.LocationC1 = {(this.LocationC1 == null ? "null" : this.LocationC1 == string.Empty ? "" : this.LocationC1)}");
            toStringOutput.Add($"this.LocationC2 = {(this.LocationC2 == null ? "null" : this.LocationC2 == string.Empty ? "" : this.LocationC2)}");
            toStringOutput.Add($"this.LocationC3 = {(this.LocationC3 == null ? "null" : this.LocationC3 == string.Empty ? "" : this.LocationC3)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.OfficePhone = {(this.OfficePhone == null ? "null" : this.OfficePhone == string.Empty ? "" : this.OfficePhone)}");
            toStringOutput.Add($"this.OfficeExtPhone = {(this.OfficeExtPhone == null ? "null" : this.OfficeExtPhone == string.Empty ? "" : this.OfficeExtPhone)}");
            toStringOutput.Add($"this.ParentId = {(this.ParentId == null ? "null" : this.ParentId == string.Empty ? "" : this.ParentId)}");
            toStringOutput.Add($"this.RecurringNotificationDaysDefault = {(this.RecurringNotificationDaysDefault == null ? "null" : this.RecurringNotificationDaysDefault.ToString())}");
            toStringOutput.Add($"this.Tz = {(this.Tz == null ? "null" : this.Tz == string.Empty ? "" : this.Tz)}");
            toStringOutput.Add($"BrandingDomain = {(this.BrandingDomain == null ? "null" : this.BrandingDomain.ToString())}");
            toStringOutput.Add($"ProductTransactions = {(this.ProductTransactions == null ? "null" : this.ProductTransactions.ToString())}");
            toStringOutput.Add($"ProductFile = {(this.ProductFile == null ? "null" : this.ProductFile.ToString())}");
            toStringOutput.Add($"ProductAccountvault = {(this.ProductAccountvault == null ? "null" : this.ProductAccountvault.ToString())}");
            toStringOutput.Add($"ProductRecurring = {(this.ProductRecurring == null ? "null" : this.ProductRecurring.ToString())}");
            toStringOutput.Add($"Tags = {(this.Tags == null ? "null" : this.Tags.ToString())}");
            toStringOutput.Add($"Terminals = {(this.Terminals == null ? "null" : this.Terminals.ToString())}");
        }
    }
}