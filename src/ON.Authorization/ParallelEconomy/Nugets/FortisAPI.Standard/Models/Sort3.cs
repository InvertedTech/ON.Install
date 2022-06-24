// <copyright file="Sort3.cs" company="APIMatic">
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
    /// Sort3.
    /// </summary>
    public class Sort3
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sort3"/> class.
        /// </summary>
        public Sort3()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sort3"/> class.
        /// </summary>
        /// <param name="brandingDomainUrl">branding_domain_url.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="id">id.</param>
        /// <param name="modifiedTs">modified_ts.</param>
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
        /// <param name="name">name.</param>
        /// <param name="officePhone">office_phone.</param>
        /// <param name="officeExtPhone">office_ext_phone.</param>
        /// <param name="parentId">parent_id.</param>
        /// <param name="recurringNotificationDaysDefault">recurring_notification_days_default.</param>
        /// <param name="tz">tz.</param>
        /// <param name="brandingDomain">branding_domain.</param>
        /// <param name="productTransactions">product_transactions.</param>
        /// <param name="productFile">product_file.</param>
        /// <param name="productAccountvault">product_accountvault.</param>
        /// <param name="productRecurring">product_recurring.</param>
        /// <param name="tags">tags.</param>
        /// <param name="terminals">terminals.</param>
        public Sort3(
            string brandingDomainUrl = null,
            int? createdTs = null,
            string id = null,
            int? modifiedTs = null,
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
            string name = null,
            string officePhone = null,
            string officeExtPhone = null,
            string parentId = null,
            int? recurringNotificationDaysDefault = null,
            string tz = null,
            object brandingDomain = null,
            object productTransactions = null,
            object productFile = null,
            object productAccountvault = null,
            object productRecurring = null,
            object tags = null,
            object terminals = null)
        {
            this.BrandingDomainUrl = brandingDomainUrl;
            this.CreatedTs = createdTs;
            this.Id = id;
            this.ModifiedTs = modifiedTs;
            this.AccountNumber = accountNumber;
            this.Address = address;
            this.BrandingDomainId = brandingDomainId;
            this.ContactEmailTrxReceiptDefault = contactEmailTrxReceiptDefault;
            this.DefaultAch = defaultAch;
            this.DefaultCc = defaultCc;
            this.DeveloperCompanyId = developerCompanyId;
            this.EmailReplyTo = emailReplyTo;
            this.Fax = fax;
            this.LocationApiId = locationApiId;
            this.LocationApiKey = locationApiKey;
            this.LocationC1 = locationC1;
            this.LocationC2 = locationC2;
            this.LocationC3 = locationC3;
            this.Name = name;
            this.OfficePhone = officePhone;
            this.OfficeExtPhone = officeExtPhone;
            this.ParentId = parentId;
            this.RecurringNotificationDaysDefault = recurringNotificationDaysDefault;
            this.Tz = tz;
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
        [JsonProperty("branding_domain_url", NullValueHandling = NullValueHandling.Ignore)]
        public string BrandingDomainUrl { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? CreatedTs { get; set; }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? ModifiedTs { get; set; }

        /// <summary>
        /// Account number
        /// </summary>
        [JsonProperty("account_number", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address2 Address { get; set; }

        /// <summary>
        /// GUID for Branding Domain
        /// </summary>
        [JsonProperty("branding_domain_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BrandingDomainId { get; set; }

        /// <summary>
        /// If true, will email contact receipt for any transaction
        /// </summary>
        [JsonProperty("contact_email_trx_receipt_default", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ContactEmailTrxReceiptDefault { get; set; }

        /// <summary>
        /// GUID for Location's default ACH Product Transaction
        /// </summary>
        [JsonProperty("default_ach", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultAch { get; set; }

        /// <summary>
        /// GUID for Location's default CC Product Transaction
        /// </summary>
        [JsonProperty("default_cc", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultCc { get; set; }

        /// <summary>
        /// GUID for Developer Company
        /// </summary>
        [JsonProperty("developer_company_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DeveloperCompanyId { get; set; }

        /// <summary>
        /// Used as from email address when sending various notifications
        /// </summary>
        [JsonProperty("email_reply_to", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailReplyTo { get; set; }

        /// <summary>
        /// Fax number
        /// </summary>
        [JsonProperty("fax", NullValueHandling = NullValueHandling.Ignore)]
        public string Fax { get; set; }

        /// <summary>
        /// Location api ID
        /// </summary>
        [JsonProperty("location_api_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationApiId { get; set; }

        /// <summary>
        /// Location api key
        /// </summary>
        [JsonProperty("location_api_key", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationApiKey { get; set; }

        /// <summary>
        /// Can be used to store custom information for location.
        /// </summary>
        [JsonProperty("location_c1", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationC1 { get; set; }

        /// <summary>
        /// Can be used to store custom information for location.
        /// </summary>
        [JsonProperty("location_c2", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationC2 { get; set; }

        /// <summary>
        /// Can be used to store custom information for location.
        /// </summary>
        [JsonProperty("location_c3", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationC3 { get; set; }

        /// <summary>
        /// Name of the company
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Office phone number
        /// </summary>
        [JsonProperty("office_phone", NullValueHandling = NullValueHandling.Ignore)]
        public string OfficePhone { get; set; }

        /// <summary>
        /// Office phone extension number
        /// </summary>
        [JsonProperty("office_ext_phone", NullValueHandling = NullValueHandling.Ignore)]
        public string OfficeExtPhone { get; set; }

        /// <summary>
        /// Location GUID of the parent location
        /// </summary>
        [JsonProperty("parent_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ParentId { get; set; }

        /// <summary>
        /// Number of days prior to a Recurring running that a notification should be sent
        /// </summary>
        [JsonProperty("recurring_notification_days_default", NullValueHandling = NullValueHandling.Ignore)]
        public int? RecurringNotificationDaysDefault { get; set; }

        /// <summary>
        /// Time zone
        /// </summary>
        [JsonProperty("tz", NullValueHandling = NullValueHandling.Ignore)]
        public string Tz { get; set; }

        /// <summary>
        /// Branding domain array
        /// </summary>
        [JsonProperty("branding_domain", NullValueHandling = NullValueHandling.Ignore)]
        public object BrandingDomain { get; set; }

        /// <summary>
        /// Product Transactions array
        /// </summary>
        [JsonProperty("product_transactions", NullValueHandling = NullValueHandling.Ignore)]
        public object ProductTransactions { get; set; }

        /// <summary>
        /// Product file array
        /// </summary>
        [JsonProperty("product_file", NullValueHandling = NullValueHandling.Ignore)]
        public object ProductFile { get; set; }

        /// <summary>
        /// Product account vault array
        /// </summary>
        [JsonProperty("product_accountvault", NullValueHandling = NullValueHandling.Ignore)]
        public object ProductAccountvault { get; set; }

        /// <summary>
        /// Product recurring array
        /// </summary>
        [JsonProperty("product_recurring", NullValueHandling = NullValueHandling.Ignore)]
        public object ProductRecurring { get; set; }

        /// <summary>
        /// Tags array
        /// </summary>
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public object Tags { get; set; }

        /// <summary>
        /// Terminals array
        /// </summary>
        [JsonProperty("terminals", NullValueHandling = NullValueHandling.Ignore)]
        public object Terminals { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Sort3 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Sort3 other &&
                ((this.BrandingDomainUrl == null && other.BrandingDomainUrl == null) || (this.BrandingDomainUrl?.Equals(other.BrandingDomainUrl) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.ModifiedTs == null && other.ModifiedTs == null) || (this.ModifiedTs?.Equals(other.ModifiedTs) == true)) &&
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
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.ModifiedTs = {(this.ModifiedTs == null ? "null" : this.ModifiedTs.ToString())}");
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