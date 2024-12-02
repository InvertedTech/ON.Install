// <copyright file="Location.cs" company="APIMatic">
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
    using APIMatic.Core.Utilities.Converters;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Location.
    /// </summary>
    public class Location : BaseModel
    {
        private string accountNumber;
        private string brandingDomainId;
        private string defaultAch;
        private string defaultCc;
        private string emailReplyTo;
        private string fax;
        private string locationApiId;
        private string locationApiKey;
        private string locationC1;
        private string locationC2;
        private string locationC3;
        private string officePhone;
        private string officeExtPhone;
        private string tz;
        private string createdUserId;
        private Models.LocationTypeEnum? locationType;
        private string ticketHashKey;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "account_number", false },
            { "branding_domain_id", false },
            { "default_ach", false },
            { "default_cc", false },
            { "email_reply_to", false },
            { "fax", false },
            { "location_api_id", false },
            { "location_api_key", false },
            { "location_c1", false },
            { "location_c2", false },
            { "location_c3", false },
            { "office_phone", false },
            { "office_ext_phone", false },
            { "tz", false },
            { "created_user_id", false },
            { "location_type", false },
            { "ticket_hash_key", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        public Location()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="name">name.</param>
        /// <param name="parentId">parent_id.</param>
        /// <param name="accountNumber">account_number.</param>
        /// <param name="address">address.</param>
        /// <param name="brandingDomainId">branding_domain_id.</param>
        /// <param name="contactEmailTrxReceiptDefault">contact_email_trx_receipt_default.</param>
        /// <param name="defaultAch">default_ach.</param>
        /// <param name="defaultCc">default_cc.</param>
        /// <param name="emailReplyTo">email_reply_to.</param>
        /// <param name="fax">fax.</param>
        /// <param name="locationApiId">location_api_id.</param>
        /// <param name="locationApiKey">location_api_key.</param>
        /// <param name="locationC1">location_c1.</param>
        /// <param name="locationC2">location_c2.</param>
        /// <param name="locationC3">location_c3.</param>
        /// <param name="officePhone">office_phone.</param>
        /// <param name="officeExtPhone">office_ext_phone.</param>
        /// <param name="tz">tz.</param>
        /// <param name="showContactNotes">show_contact_notes.</param>
        /// <param name="showContactFiles">show_contact_files.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="locationType">location_type.</param>
        /// <param name="ticketHashKey">ticket_hash_key.</param>
        public Location(
            string id,
            int createdTs,
            int modifiedTs,
            string name,
            string parentId,
            string accountNumber = null,
            Models.Address1 address = null,
            string brandingDomainId = null,
            bool? contactEmailTrxReceiptDefault = null,
            string defaultAch = null,
            string defaultCc = null,
            string emailReplyTo = null,
            string fax = null,
            string locationApiId = null,
            string locationApiKey = null,
            string locationC1 = null,
            string locationC2 = null,
            string locationC3 = null,
            string officePhone = null,
            string officeExtPhone = null,
            string tz = null,
            bool? showContactNotes = null,
            bool? showContactFiles = null,
            string createdUserId = null,
            Models.LocationTypeEnum? locationType = null,
            string ticketHashKey = null)
        {
            this.Id = id;
            this.CreatedTs = createdTs;
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

            if (tz != null)
            {
                this.Tz = tz;
            }

            this.ParentId = parentId;
            this.ShowContactNotes = showContactNotes;
            this.ShowContactFiles = showContactFiles;
            if (createdUserId != null)
            {
                this.CreatedUserId = createdUserId;
            }

            if (locationType != null)
            {
                this.LocationType = locationType;
            }

            if (ticketHashKey != null)
            {
                this.TicketHashKey = ticketHashKey;
            }

        }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int CreatedTs { get; set; }

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
        public Models.Address1 Address { get; set; }

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
        /// Location GUID of the parent location
        /// </summary>
        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        /// <summary>
        /// If set to true will show 'Notes' tab on Contact
        /// </summary>
        [JsonProperty("show_contact_notes", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowContactNotes { get; set; }

        /// <summary>
        /// If set to true will show 'Files' tab on Contact
        /// </summary>
        [JsonProperty("show_contact_files", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowContactFiles { get; set; }

        /// <summary>
        /// User ID Created the register
        /// </summary>
        [JsonProperty("created_user_id")]
        public string CreatedUserId
        {
            get
            {
                return this.createdUserId;
            }

            set
            {
                this.shouldSerialize["created_user_id"] = true;
                this.createdUserId = value;
            }
        }

        /// <summary>
        /// Location Type
        /// </summary>
        [JsonProperty("location_type")]
        public Models.LocationTypeEnum? LocationType
        {
            get
            {
                return this.locationType;
            }

            set
            {
                this.shouldSerialize["location_type"] = true;
                this.locationType = value;
            }
        }

        /// <summary>
        /// Ticket Hash Key
        /// </summary>
        [JsonProperty("ticket_hash_key")]
        public string TicketHashKey
        {
            get
            {
                return this.ticketHashKey;
            }

            set
            {
                this.shouldSerialize["ticket_hash_key"] = true;
                this.ticketHashKey = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Location : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetTz()
        {
            this.shouldSerialize["tz"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCreatedUserId()
        {
            this.shouldSerialize["created_user_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocationType()
        {
            this.shouldSerialize["location_type"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTicketHashKey()
        {
            this.shouldSerialize["ticket_hash_key"] = false;
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
        public bool ShouldSerializeTz()
        {
            return this.shouldSerialize["tz"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCreatedUserId()
        {
            return this.shouldSerialize["created_user_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationType()
        {
            return this.shouldSerialize["location_type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTicketHashKey()
        {
            return this.shouldSerialize["ticket_hash_key"];
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
            return obj is Location other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                ((this.AccountNumber == null && other.AccountNumber == null) || (this.AccountNumber?.Equals(other.AccountNumber) == true)) &&
                ((this.Address == null && other.Address == null) || (this.Address?.Equals(other.Address) == true)) &&
                ((this.BrandingDomainId == null && other.BrandingDomainId == null) || (this.BrandingDomainId?.Equals(other.BrandingDomainId) == true)) &&
                ((this.ContactEmailTrxReceiptDefault == null && other.ContactEmailTrxReceiptDefault == null) || (this.ContactEmailTrxReceiptDefault?.Equals(other.ContactEmailTrxReceiptDefault) == true)) &&
                ((this.DefaultAch == null && other.DefaultAch == null) || (this.DefaultAch?.Equals(other.DefaultAch) == true)) &&
                ((this.DefaultCc == null && other.DefaultCc == null) || (this.DefaultCc?.Equals(other.DefaultCc) == true)) &&
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
                ((this.Tz == null && other.Tz == null) || (this.Tz?.Equals(other.Tz) == true)) &&
                ((this.ParentId == null && other.ParentId == null) || (this.ParentId?.Equals(other.ParentId) == true)) &&
                ((this.ShowContactNotes == null && other.ShowContactNotes == null) || (this.ShowContactNotes?.Equals(other.ShowContactNotes) == true)) &&
                ((this.ShowContactFiles == null && other.ShowContactFiles == null) || (this.ShowContactFiles?.Equals(other.ShowContactFiles) == true)) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true)) &&
                ((this.LocationType == null && other.LocationType == null) || (this.LocationType?.Equals(other.LocationType) == true)) &&
                ((this.TicketHashKey == null && other.TicketHashKey == null) || (this.TicketHashKey?.Equals(other.TicketHashKey) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.AccountNumber = {(this.AccountNumber == null ? "null" : this.AccountNumber)}");
            toStringOutput.Add($"this.Address = {(this.Address == null ? "null" : this.Address.ToString())}");
            toStringOutput.Add($"this.BrandingDomainId = {(this.BrandingDomainId == null ? "null" : this.BrandingDomainId)}");
            toStringOutput.Add($"this.ContactEmailTrxReceiptDefault = {(this.ContactEmailTrxReceiptDefault == null ? "null" : this.ContactEmailTrxReceiptDefault.ToString())}");
            toStringOutput.Add($"this.DefaultAch = {(this.DefaultAch == null ? "null" : this.DefaultAch)}");
            toStringOutput.Add($"this.DefaultCc = {(this.DefaultCc == null ? "null" : this.DefaultCc)}");
            toStringOutput.Add($"this.EmailReplyTo = {(this.EmailReplyTo == null ? "null" : this.EmailReplyTo)}");
            toStringOutput.Add($"this.Fax = {(this.Fax == null ? "null" : this.Fax)}");
            toStringOutput.Add($"this.LocationApiId = {(this.LocationApiId == null ? "null" : this.LocationApiId)}");
            toStringOutput.Add($"this.LocationApiKey = {(this.LocationApiKey == null ? "null" : this.LocationApiKey)}");
            toStringOutput.Add($"this.LocationC1 = {(this.LocationC1 == null ? "null" : this.LocationC1)}");
            toStringOutput.Add($"this.LocationC2 = {(this.LocationC2 == null ? "null" : this.LocationC2)}");
            toStringOutput.Add($"this.LocationC3 = {(this.LocationC3 == null ? "null" : this.LocationC3)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.OfficePhone = {(this.OfficePhone == null ? "null" : this.OfficePhone)}");
            toStringOutput.Add($"this.OfficeExtPhone = {(this.OfficeExtPhone == null ? "null" : this.OfficeExtPhone)}");
            toStringOutput.Add($"this.Tz = {(this.Tz == null ? "null" : this.Tz)}");
            toStringOutput.Add($"this.ParentId = {(this.ParentId == null ? "null" : this.ParentId)}");
            toStringOutput.Add($"this.ShowContactNotes = {(this.ShowContactNotes == null ? "null" : this.ShowContactNotes.ToString())}");
            toStringOutput.Add($"this.ShowContactFiles = {(this.ShowContactFiles == null ? "null" : this.ShowContactFiles.ToString())}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.LocationType = {(this.LocationType == null ? "null" : this.LocationType.ToString())}");
            toStringOutput.Add($"this.TicketHashKey = {(this.TicketHashKey == null ? "null" : this.TicketHashKey)}");

            base.ToString(toStringOutput);
        }
    }
}