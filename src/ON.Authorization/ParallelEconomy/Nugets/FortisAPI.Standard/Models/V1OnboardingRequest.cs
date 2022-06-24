// <copyright file="V1OnboardingRequest.cs" company="APIMatic">
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
    /// V1OnboardingRequest.
    /// </summary>
    public class V1OnboardingRequest
    {
        private string parentId;
        private Models.BusinessCategoryEnum? businessCategory;
        private Models.BusinessTypeEnum? businessType;
        private string businessDescription;
        private int? swipedPercent;
        private int? keyedPercent;
        private int? ecommercePercent;
        private Models.OwnershipTypeEnum? ownershipType;
        private string fedTaxId;
        private int? ccAverageTicketRange;
        private int? ccMonthlyVolumeRange;
        private int? ccHighTicket;
        private int? ecAverageTicketRange;
        private int? ecMonthlyVolumeRange;
        private int? ecHighTicket;
        private string website;
        private string legalName;
        private string clientAppId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "parent_id", false },
            { "business_category", false },
            { "business_type", false },
            { "business_description", false },
            { "swiped_percent", false },
            { "keyed_percent", false },
            { "ecommerce_percent", false },
            { "ownership_type", false },
            { "fed_tax_id", false },
            { "cc_average_ticket_range", false },
            { "cc_monthly_volume_range", false },
            { "cc_high_ticket", false },
            { "ec_average_ticket_range", false },
            { "ec_monthly_volume_range", false },
            { "ec_high_ticket", false },
            { "website", false },
            { "legal_name", false },
            { "client_app_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="V1OnboardingRequest"/> class.
        /// </summary>
        public V1OnboardingRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1OnboardingRequest"/> class.
        /// </summary>
        /// <param name="primaryPrincipal">primary_principal.</param>
        /// <param name="templateCode">template_code.</param>
        /// <param name="email">email.</param>
        /// <param name="dbaName">dba_name.</param>
        /// <param name="location">location.</param>
        /// <param name="appDelivery">app_delivery.</param>
        /// <param name="bankAccount">bank_account.</param>
        /// <param name="altBankAccount">alt_bank_account.</param>
        /// <param name="contact">contact.</param>
        /// <param name="parentId">parent_id.</param>
        /// <param name="businessCategory">business_category.</param>
        /// <param name="businessType">business_type.</param>
        /// <param name="businessDescription">business_description.</param>
        /// <param name="swipedPercent">swiped_percent.</param>
        /// <param name="keyedPercent">keyed_percent.</param>
        /// <param name="ecommercePercent">ecommerce_percent.</param>
        /// <param name="ownershipType">ownership_type.</param>
        /// <param name="fedTaxId">fed_tax_id.</param>
        /// <param name="ccAverageTicketRange">cc_average_ticket_range.</param>
        /// <param name="ccMonthlyVolumeRange">cc_monthly_volume_range.</param>
        /// <param name="ccHighTicket">cc_high_ticket.</param>
        /// <param name="ecAverageTicketRange">ec_average_ticket_range.</param>
        /// <param name="ecMonthlyVolumeRange">ec_monthly_volume_range.</param>
        /// <param name="ecHighTicket">ec_high_ticket.</param>
        /// <param name="website">website.</param>
        /// <param name="legalName">legal_name.</param>
        /// <param name="clientAppId">client_app_id.</param>
        public V1OnboardingRequest(
            Models.PrimaryPrincipal primaryPrincipal,
            string templateCode,
            string email,
            string dbaName,
            Models.Location location,
            Models.AppDeliveryEnum appDelivery,
            Models.BankAccount bankAccount,
            Models.AltBankAccount altBankAccount,
            Models.Contact contact,
            string parentId = null,
            Models.BusinessCategoryEnum? businessCategory = null,
            Models.BusinessTypeEnum? businessType = null,
            string businessDescription = null,
            int? swipedPercent = null,
            int? keyedPercent = null,
            int? ecommercePercent = null,
            Models.OwnershipTypeEnum? ownershipType = null,
            string fedTaxId = null,
            int? ccAverageTicketRange = null,
            int? ccMonthlyVolumeRange = null,
            int? ccHighTicket = null,
            int? ecAverageTicketRange = null,
            int? ecMonthlyVolumeRange = null,
            int? ecHighTicket = null,
            string website = null,
            string legalName = null,
            string clientAppId = null)
        {
            if (parentId != null)
            {
                this.ParentId = parentId;
            }

            this.PrimaryPrincipal = primaryPrincipal;
            this.TemplateCode = templateCode;
            this.Email = email;
            this.DbaName = dbaName;
            this.Location = location;
            this.AppDelivery = appDelivery;
            if (businessCategory != null)
            {
                this.BusinessCategory = businessCategory;
            }

            if (businessType != null)
            {
                this.BusinessType = businessType;
            }

            if (businessDescription != null)
            {
                this.BusinessDescription = businessDescription;
            }

            if (swipedPercent != null)
            {
                this.SwipedPercent = swipedPercent;
            }

            if (keyedPercent != null)
            {
                this.KeyedPercent = keyedPercent;
            }

            if (ecommercePercent != null)
            {
                this.EcommercePercent = ecommercePercent;
            }

            if (ownershipType != null)
            {
                this.OwnershipType = ownershipType;
            }

            if (fedTaxId != null)
            {
                this.FedTaxId = fedTaxId;
            }

            if (ccAverageTicketRange != null)
            {
                this.CcAverageTicketRange = ccAverageTicketRange;
            }

            if (ccMonthlyVolumeRange != null)
            {
                this.CcMonthlyVolumeRange = ccMonthlyVolumeRange;
            }

            if (ccHighTicket != null)
            {
                this.CcHighTicket = ccHighTicket;
            }

            if (ecAverageTicketRange != null)
            {
                this.EcAverageTicketRange = ecAverageTicketRange;
            }

            if (ecMonthlyVolumeRange != null)
            {
                this.EcMonthlyVolumeRange = ecMonthlyVolumeRange;
            }

            if (ecHighTicket != null)
            {
                this.EcHighTicket = ecHighTicket;
            }

            if (website != null)
            {
                this.Website = website;
            }

            this.BankAccount = bankAccount;
            this.AltBankAccount = altBankAccount;
            if (legalName != null)
            {
                this.LegalName = legalName;
            }

            this.Contact = contact;
            if (clientAppId != null)
            {
                this.ClientAppId = clientAppId;
            }

        }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("parent_id")]
        public string ParentId
        {
            get
            {
                return this.parentId;
            }

            set
            {
                this.shouldSerialize["parent_id"] = true;
                this.parentId = value;
            }
        }

        /// <summary>
        /// The Primary Principal.
        /// </summary>
        [JsonProperty("primary_principal")]
        public Models.PrimaryPrincipal PrimaryPrincipal { get; set; }

        /// <summary>
        /// The ID of the template to be used - this value will be provided by Fortis.
        /// </summary>
        [JsonProperty("template_code")]
        public string TemplateCode { get; set; }

        /// <summary>
        /// Merchant email address.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Merchant 'Doing Business As' name.
        /// </summary>
        [JsonProperty("dba_name")]
        public string DbaName { get; set; }

        /// <summary>
        /// The Location.
        /// </summary>
        [JsonProperty("location")]
        public Models.Location Location { get; set; }

        /// <summary>
        /// The delivery method of the app to the merchant.
        /// </summary>
        [JsonProperty("app_delivery", ItemConverterType = typeof(StringEnumConverter))]
        public Models.AppDeliveryEnum AppDelivery { get; set; }

        /// <summary>
        /// The Category of the merchant's business
        /// </summary>
        [JsonProperty("business_category", ItemConverterType = typeof(StringEnumConverter))]
        public Models.BusinessCategoryEnum? BusinessCategory
        {
            get
            {
                return this.businessCategory;
            }

            set
            {
                this.shouldSerialize["business_category"] = true;
                this.businessCategory = value;
            }
        }

        /// <summary>
        /// The Type of a merchant's business.
        /// </summary>
        [JsonProperty("business_type", ItemConverterType = typeof(StringEnumConverter))]
        public Models.BusinessTypeEnum? BusinessType
        {
            get
            {
                return this.businessType;
            }

            set
            {
                this.shouldSerialize["business_type"] = true;
                this.businessType = value;
            }
        }

        /// <summary>
        /// Description of Goods or Services.
        /// </summary>
        [JsonProperty("business_description")]
        public string BusinessDescription
        {
            get
            {
                return this.businessDescription;
            }

            set
            {
                this.shouldSerialize["business_description"] = true;
                this.businessDescription = value;
            }
        }

        /// <summary>
        /// Card present/swiped percentage
        /// </summary>
        [JsonProperty("swiped_percent")]
        public int? SwipedPercent
        {
            get
            {
                return this.swipedPercent;
            }

            set
            {
                this.shouldSerialize["swiped_percent"] = true;
                this.swipedPercent = value;
            }
        }

        /// <summary>
        /// Card not present/keyed percentage
        /// </summary>
        [JsonProperty("keyed_percent")]
        public int? KeyedPercent
        {
            get
            {
                return this.keyedPercent;
            }

            set
            {
                this.shouldSerialize["keyed_percent"] = true;
                this.keyedPercent = value;
            }
        }

        /// <summary>
        /// eCommerce percentage.
        /// </summary>
        [JsonProperty("ecommerce_percent")]
        public int? EcommercePercent
        {
            get
            {
                return this.ecommercePercent;
            }

            set
            {
                this.shouldSerialize["ecommerce_percent"] = true;
                this.ecommercePercent = value;
            }
        }

        /// <summary>
        /// The Ownership Type of the merchant's business.
        /// </summary>
        [JsonProperty("ownership_type", ItemConverterType = typeof(StringEnumConverter))]
        public Models.OwnershipTypeEnum? OwnershipType
        {
            get
            {
                return this.ownershipType;
            }

            set
            {
                this.shouldSerialize["ownership_type"] = true;
                this.ownershipType = value;
            }
        }

        /// <summary>
        /// Federal Tax ID (EIN).
        /// </summary>
        [JsonProperty("fed_tax_id")]
        public string FedTaxId
        {
            get
            {
                return this.fedTaxId;
            }

            set
            {
                this.shouldSerialize["fed_tax_id"] = true;
                this.fedTaxId = value;
            }
        }

        /// <summary>
        /// Average Transaction Amount Range
        /// </summary>
        [JsonProperty("cc_average_ticket_range")]
        public int? CcAverageTicketRange
        {
            get
            {
                return this.ccAverageTicketRange;
            }

            set
            {
                this.shouldSerialize["cc_average_ticket_range"] = true;
                this.ccAverageTicketRange = value;
            }
        }

        /// <summary>
        /// Monthly Processing Volume Range
        /// </summary>
        [JsonProperty("cc_monthly_volume_range")]
        public int? CcMonthlyVolumeRange
        {
            get
            {
                return this.ccMonthlyVolumeRange;
            }

            set
            {
                this.shouldSerialize["cc_monthly_volume_range"] = true;
                this.ccMonthlyVolumeRange = value;
            }
        }

        /// <summary>
        /// Highest transaction amount rounded to the next dollar
        /// </summary>
        [JsonProperty("cc_high_ticket")]
        public int? CcHighTicket
        {
            get
            {
                return this.ccHighTicket;
            }

            set
            {
                this.shouldSerialize["cc_high_ticket"] = true;
                this.ccHighTicket = value;
            }
        }

        /// <summary>
        /// Average Transaction Amount Range
        /// </summary>
        [JsonProperty("ec_average_ticket_range")]
        public int? EcAverageTicketRange
        {
            get
            {
                return this.ecAverageTicketRange;
            }

            set
            {
                this.shouldSerialize["ec_average_ticket_range"] = true;
                this.ecAverageTicketRange = value;
            }
        }

        /// <summary>
        /// Monthly Processing Volume Range
        /// </summary>
        [JsonProperty("ec_monthly_volume_range")]
        public int? EcMonthlyVolumeRange
        {
            get
            {
                return this.ecMonthlyVolumeRange;
            }

            set
            {
                this.shouldSerialize["ec_monthly_volume_range"] = true;
                this.ecMonthlyVolumeRange = value;
            }
        }

        /// <summary>
        /// Highest transaction amount rounded to the next dollar
        /// </summary>
        [JsonProperty("ec_high_ticket")]
        public int? EcHighTicket
        {
            get
            {
                return this.ecHighTicket;
            }

            set
            {
                this.shouldSerialize["ec_high_ticket"] = true;
                this.ecHighTicket = value;
            }
        }

        /// <summary>
        /// Merchant's business website.
        /// </summary>
        [JsonProperty("website")]
        public string Website
        {
            get
            {
                return this.website;
            }

            set
            {
                this.shouldSerialize["website"] = true;
                this.website = value;
            }
        }

        /// <summary>
        /// The Bank Account.
        /// </summary>
        [JsonProperty("bank_account")]
        public Models.BankAccount BankAccount { get; set; }

        /// <summary>
        /// The Alternative Bank Account.
        /// </summary>
        [JsonProperty("alt_bank_account")]
        public Models.AltBankAccount AltBankAccount { get; set; }

        /// <summary>
        /// Merchant legal name.
        /// </summary>
        [JsonProperty("legal_name")]
        public string LegalName
        {
            get
            {
                return this.legalName;
            }

            set
            {
                this.shouldSerialize["legal_name"] = true;
                this.legalName = value;
            }
        }

        /// <summary>
        /// The Contact.
        /// </summary>
        [JsonProperty("contact")]
        public Models.Contact Contact { get; set; }

        /// <summary>
        /// Client-Issued ID to uniquely identify the merchant (Returned unmodified).
        /// </summary>
        [JsonProperty("client_app_id")]
        public string ClientAppId
        {
            get
            {
                return this.clientAppId;
            }

            set
            {
                this.shouldSerialize["client_app_id"] = true;
                this.clientAppId = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1OnboardingRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetParentId()
        {
            this.shouldSerialize["parent_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetBusinessCategory()
        {
            this.shouldSerialize["business_category"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetBusinessType()
        {
            this.shouldSerialize["business_type"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetBusinessDescription()
        {
            this.shouldSerialize["business_description"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSwipedPercent()
        {
            this.shouldSerialize["swiped_percent"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetKeyedPercent()
        {
            this.shouldSerialize["keyed_percent"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEcommercePercent()
        {
            this.shouldSerialize["ecommerce_percent"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetOwnershipType()
        {
            this.shouldSerialize["ownership_type"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFedTaxId()
        {
            this.shouldSerialize["fed_tax_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCcAverageTicketRange()
        {
            this.shouldSerialize["cc_average_ticket_range"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCcMonthlyVolumeRange()
        {
            this.shouldSerialize["cc_monthly_volume_range"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCcHighTicket()
        {
            this.shouldSerialize["cc_high_ticket"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEcAverageTicketRange()
        {
            this.shouldSerialize["ec_average_ticket_range"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEcMonthlyVolumeRange()
        {
            this.shouldSerialize["ec_monthly_volume_range"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEcHighTicket()
        {
            this.shouldSerialize["ec_high_ticket"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetWebsite()
        {
            this.shouldSerialize["website"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLegalName()
        {
            this.shouldSerialize["legal_name"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetClientAppId()
        {
            this.shouldSerialize["client_app_id"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeParentId()
        {
            return this.shouldSerialize["parent_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBusinessCategory()
        {
            return this.shouldSerialize["business_category"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBusinessType()
        {
            return this.shouldSerialize["business_type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBusinessDescription()
        {
            return this.shouldSerialize["business_description"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSwipedPercent()
        {
            return this.shouldSerialize["swiped_percent"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeKeyedPercent()
        {
            return this.shouldSerialize["keyed_percent"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEcommercePercent()
        {
            return this.shouldSerialize["ecommerce_percent"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOwnershipType()
        {
            return this.shouldSerialize["ownership_type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFedTaxId()
        {
            return this.shouldSerialize["fed_tax_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCcAverageTicketRange()
        {
            return this.shouldSerialize["cc_average_ticket_range"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCcMonthlyVolumeRange()
        {
            return this.shouldSerialize["cc_monthly_volume_range"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCcHighTicket()
        {
            return this.shouldSerialize["cc_high_ticket"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEcAverageTicketRange()
        {
            return this.shouldSerialize["ec_average_ticket_range"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEcMonthlyVolumeRange()
        {
            return this.shouldSerialize["ec_monthly_volume_range"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEcHighTicket()
        {
            return this.shouldSerialize["ec_high_ticket"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeWebsite()
        {
            return this.shouldSerialize["website"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLegalName()
        {
            return this.shouldSerialize["legal_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeClientAppId()
        {
            return this.shouldSerialize["client_app_id"];
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

            return obj is V1OnboardingRequest other &&
                ((this.ParentId == null && other.ParentId == null) || (this.ParentId?.Equals(other.ParentId) == true)) &&
                ((this.PrimaryPrincipal == null && other.PrimaryPrincipal == null) || (this.PrimaryPrincipal?.Equals(other.PrimaryPrincipal) == true)) &&
                ((this.TemplateCode == null && other.TemplateCode == null) || (this.TemplateCode?.Equals(other.TemplateCode) == true)) &&
                ((this.Email == null && other.Email == null) || (this.Email?.Equals(other.Email) == true)) &&
                ((this.DbaName == null && other.DbaName == null) || (this.DbaName?.Equals(other.DbaName) == true)) &&
                ((this.Location == null && other.Location == null) || (this.Location?.Equals(other.Location) == true)) &&
                this.AppDelivery.Equals(other.AppDelivery) &&
                ((this.BusinessCategory == null && other.BusinessCategory == null) || (this.BusinessCategory?.Equals(other.BusinessCategory) == true)) &&
                ((this.BusinessType == null && other.BusinessType == null) || (this.BusinessType?.Equals(other.BusinessType) == true)) &&
                ((this.BusinessDescription == null && other.BusinessDescription == null) || (this.BusinessDescription?.Equals(other.BusinessDescription) == true)) &&
                ((this.SwipedPercent == null && other.SwipedPercent == null) || (this.SwipedPercent?.Equals(other.SwipedPercent) == true)) &&
                ((this.KeyedPercent == null && other.KeyedPercent == null) || (this.KeyedPercent?.Equals(other.KeyedPercent) == true)) &&
                ((this.EcommercePercent == null && other.EcommercePercent == null) || (this.EcommercePercent?.Equals(other.EcommercePercent) == true)) &&
                ((this.OwnershipType == null && other.OwnershipType == null) || (this.OwnershipType?.Equals(other.OwnershipType) == true)) &&
                ((this.FedTaxId == null && other.FedTaxId == null) || (this.FedTaxId?.Equals(other.FedTaxId) == true)) &&
                ((this.CcAverageTicketRange == null && other.CcAverageTicketRange == null) || (this.CcAverageTicketRange?.Equals(other.CcAverageTicketRange) == true)) &&
                ((this.CcMonthlyVolumeRange == null && other.CcMonthlyVolumeRange == null) || (this.CcMonthlyVolumeRange?.Equals(other.CcMonthlyVolumeRange) == true)) &&
                ((this.CcHighTicket == null && other.CcHighTicket == null) || (this.CcHighTicket?.Equals(other.CcHighTicket) == true)) &&
                ((this.EcAverageTicketRange == null && other.EcAverageTicketRange == null) || (this.EcAverageTicketRange?.Equals(other.EcAverageTicketRange) == true)) &&
                ((this.EcMonthlyVolumeRange == null && other.EcMonthlyVolumeRange == null) || (this.EcMonthlyVolumeRange?.Equals(other.EcMonthlyVolumeRange) == true)) &&
                ((this.EcHighTicket == null && other.EcHighTicket == null) || (this.EcHighTicket?.Equals(other.EcHighTicket) == true)) &&
                ((this.Website == null && other.Website == null) || (this.Website?.Equals(other.Website) == true)) &&
                ((this.BankAccount == null && other.BankAccount == null) || (this.BankAccount?.Equals(other.BankAccount) == true)) &&
                ((this.AltBankAccount == null && other.AltBankAccount == null) || (this.AltBankAccount?.Equals(other.AltBankAccount) == true)) &&
                ((this.LegalName == null && other.LegalName == null) || (this.LegalName?.Equals(other.LegalName) == true)) &&
                ((this.Contact == null && other.Contact == null) || (this.Contact?.Equals(other.Contact) == true)) &&
                ((this.ClientAppId == null && other.ClientAppId == null) || (this.ClientAppId?.Equals(other.ClientAppId) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ParentId = {(this.ParentId == null ? "null" : this.ParentId == string.Empty ? "" : this.ParentId)}");
            toStringOutput.Add($"this.PrimaryPrincipal = {(this.PrimaryPrincipal == null ? "null" : this.PrimaryPrincipal.ToString())}");
            toStringOutput.Add($"this.TemplateCode = {(this.TemplateCode == null ? "null" : this.TemplateCode == string.Empty ? "" : this.TemplateCode)}");
            toStringOutput.Add($"this.Email = {(this.Email == null ? "null" : this.Email == string.Empty ? "" : this.Email)}");
            toStringOutput.Add($"this.DbaName = {(this.DbaName == null ? "null" : this.DbaName == string.Empty ? "" : this.DbaName)}");
            toStringOutput.Add($"this.Location = {(this.Location == null ? "null" : this.Location.ToString())}");
            toStringOutput.Add($"this.AppDelivery = {this.AppDelivery}");
            toStringOutput.Add($"this.BusinessCategory = {(this.BusinessCategory == null ? "null" : this.BusinessCategory.ToString())}");
            toStringOutput.Add($"this.BusinessType = {(this.BusinessType == null ? "null" : this.BusinessType.ToString())}");
            toStringOutput.Add($"this.BusinessDescription = {(this.BusinessDescription == null ? "null" : this.BusinessDescription == string.Empty ? "" : this.BusinessDescription)}");
            toStringOutput.Add($"this.SwipedPercent = {(this.SwipedPercent == null ? "null" : this.SwipedPercent.ToString())}");
            toStringOutput.Add($"this.KeyedPercent = {(this.KeyedPercent == null ? "null" : this.KeyedPercent.ToString())}");
            toStringOutput.Add($"this.EcommercePercent = {(this.EcommercePercent == null ? "null" : this.EcommercePercent.ToString())}");
            toStringOutput.Add($"this.OwnershipType = {(this.OwnershipType == null ? "null" : this.OwnershipType.ToString())}");
            toStringOutput.Add($"this.FedTaxId = {(this.FedTaxId == null ? "null" : this.FedTaxId == string.Empty ? "" : this.FedTaxId)}");
            toStringOutput.Add($"this.CcAverageTicketRange = {(this.CcAverageTicketRange == null ? "null" : this.CcAverageTicketRange.ToString())}");
            toStringOutput.Add($"this.CcMonthlyVolumeRange = {(this.CcMonthlyVolumeRange == null ? "null" : this.CcMonthlyVolumeRange.ToString())}");
            toStringOutput.Add($"this.CcHighTicket = {(this.CcHighTicket == null ? "null" : this.CcHighTicket.ToString())}");
            toStringOutput.Add($"this.EcAverageTicketRange = {(this.EcAverageTicketRange == null ? "null" : this.EcAverageTicketRange.ToString())}");
            toStringOutput.Add($"this.EcMonthlyVolumeRange = {(this.EcMonthlyVolumeRange == null ? "null" : this.EcMonthlyVolumeRange.ToString())}");
            toStringOutput.Add($"this.EcHighTicket = {(this.EcHighTicket == null ? "null" : this.EcHighTicket.ToString())}");
            toStringOutput.Add($"this.Website = {(this.Website == null ? "null" : this.Website == string.Empty ? "" : this.Website)}");
            toStringOutput.Add($"this.BankAccount = {(this.BankAccount == null ? "null" : this.BankAccount.ToString())}");
            toStringOutput.Add($"this.AltBankAccount = {(this.AltBankAccount == null ? "null" : this.AltBankAccount.ToString())}");
            toStringOutput.Add($"this.LegalName = {(this.LegalName == null ? "null" : this.LegalName == string.Empty ? "" : this.LegalName)}");
            toStringOutput.Add($"this.Contact = {(this.Contact == null ? "null" : this.Contact.ToString())}");
            toStringOutput.Add($"this.ClientAppId = {(this.ClientAppId == null ? "null" : this.ClientAppId == string.Empty ? "" : this.ClientAppId)}");
        }
    }
}