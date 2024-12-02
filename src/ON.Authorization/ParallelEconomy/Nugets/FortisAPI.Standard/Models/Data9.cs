// <copyright file="Data9.cs" company="APIMatic">
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
    /// Data9.
    /// </summary>
    public class Data9 : BaseModel
    {
        private string parentId;
        private string clientAppId;
        private string legalName;
        private string website;
        private int? ecMonthlyVolume;
        private Models.PreferredLanguageEnum? preferredLanguage;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "parent_id", false },
            { "client_app_id", false },
            { "legal_name", false },
            { "website", false },
            { "ec_monthly_volume", false },
            { "preferred_language", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Data9"/> class.
        /// </summary>
        public Data9()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data9"/> class.
        /// </summary>
        /// <param name="email">email.</param>
        /// <param name="dbaName">dba_name.</param>
        /// <param name="phoneNumber">phone_number.</param>
        /// <param name="ownershipType">ownership_type.</param>
        /// <param name="fedTaxId">fed_tax_id.</param>
        /// <param name="averageTicket">average_ticket.</param>
        /// <param name="highTicket">high_ticket.</param>
        /// <param name="ccMonthlyVolume">cc_monthly_volume.</param>
        /// <param name="mccCode">mcc_code.</param>
        /// <param name="businessDescription">business_description.</param>
        /// <param name="swipedPercent">swiped_percent.</param>
        /// <param name="keyedPercent">keyed_percent.</param>
        /// <param name="ecommercePercent">ecommerce_percent.</param>
        /// <param name="isForeignEntity">is_foreign_entity.</param>
        /// <param name="personallyGuaranteed">personally_guaranteed.</param>
        /// <param name="addresses">addresses.</param>
        /// <param name="owners">owners.</param>
        /// <param name="bankAccounts">bank_accounts.</param>
        /// <param name="parentId">parent_id.</param>
        /// <param name="templateId">template_id.</param>
        /// <param name="clientAppId">client_app_id.</param>
        /// <param name="legalName">legal_name.</param>
        /// <param name="website">website.</param>
        /// <param name="ecMonthlyVolume">ec_monthly_volume.</param>
        /// <param name="preferredLanguage">preferred_language.</param>
        /// <param name="documents">documents.</param>
        /// <param name="pricingElements">pricing_elements.</param>
        /// <param name="kycResponseObjects">kyc_response_objects.</param>
        /// <param name="metadata">metadata.</param>
        /// <param name="result">result.</param>
        /// <param name="status">status.</param>
        public Data9(
            string email,
            string dbaName,
            string phoneNumber,
            Models.OwnershipTypeEnum ownershipType,
            string fedTaxId,
            int averageTicket,
            int highTicket,
            int ccMonthlyVolume,
            string mccCode,
            string businessDescription,
            int swipedPercent,
            int keyedPercent,
            int ecommercePercent,
            bool isForeignEntity,
            bool personallyGuaranteed,
            List<Models.Address22> addresses,
            List<Models.Owner> owners,
            List<Models.BankAccount> bankAccounts,
            string parentId = null,
            string templateId = null,
            string clientAppId = null,
            string legalName = null,
            string website = null,
            int? ecMonthlyVolume = null,
            Models.PreferredLanguageEnum? preferredLanguage = null,
            List<Models.Document> documents = null,
            List<Models.PricingElement> pricingElements = null,
            List<Models.KycResponseObject> kycResponseObjects = null,
            object metadata = null,
            Models.Result result = null,
            Models.Status5 status = null)
        {
            if (parentId != null)
            {
                this.ParentId = parentId;
            }

            this.TemplateId = templateId;
            if (clientAppId != null)
            {
                this.ClientAppId = clientAppId;
            }

            this.Email = email;
            this.DbaName = dbaName;
            if (legalName != null)
            {
                this.LegalName = legalName;
            }

            if (website != null)
            {
                this.Website = website;
            }

            this.PhoneNumber = phoneNumber;
            this.OwnershipType = ownershipType;
            this.FedTaxId = fedTaxId;
            this.AverageTicket = averageTicket;
            this.HighTicket = highTicket;
            this.CcMonthlyVolume = ccMonthlyVolume;
            if (ecMonthlyVolume != null)
            {
                this.EcMonthlyVolume = ecMonthlyVolume;
            }

            this.MccCode = mccCode;
            this.BusinessDescription = businessDescription;
            this.SwipedPercent = swipedPercent;
            this.KeyedPercent = keyedPercent;
            this.EcommercePercent = ecommercePercent;
            this.IsForeignEntity = isForeignEntity;
            this.PersonallyGuaranteed = personallyGuaranteed;
            if (preferredLanguage != null)
            {
                this.PreferredLanguage = preferredLanguage;
            }

            this.Addresses = addresses;
            this.Owners = owners;
            this.BankAccounts = bankAccounts;
            this.Documents = documents;
            this.PricingElements = pricingElements;
            this.KycResponseObjects = kycResponseObjects;
            this.Metadata = metadata;
            this.Result = result;
            this.Status = status;
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
        /// The ID of the template to be used - this value will be provided by Fortis.
        /// </summary>
        [JsonProperty("template_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TemplateId { get; set; }

        /// <summary>
        /// Client Issues Id to track that can be used to track each submitted merchant application. This id should be generated and sent in the request payload, and will be returned in the response payload. If no id is submitted in the payload request, this field will be null in the response.
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
        /// Merchant's phone number.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The Ownership Type of the merchant's business.
        /// </summary>
        [JsonProperty("ownership_type")]
        public Models.OwnershipTypeEnum OwnershipType { get; set; }

        /// <summary>
        /// Federal Tax ID (EIN).
        /// </summary>
        [JsonProperty("fed_tax_id")]
        public string FedTaxId { get; set; }

        /// <summary>
        /// Average Transaction Amount.
        /// </summary>
        [JsonProperty("average_ticket")]
        public int AverageTicket { get; set; }

        /// <summary>
        /// Highest transaction amount rounded to the next dollar
        /// </summary>
        [JsonProperty("high_ticket")]
        public int HighTicket { get; set; }

        /// <summary>
        /// Average monthly credit card volume rounded to the next dollar.
        /// </summary>
        [JsonProperty("cc_monthly_volume")]
        public int CcMonthlyVolume { get; set; }

        /// <summary>
        /// Average monthly echeck volume rounded to the next dollar.
        /// </summary>
        [JsonProperty("ec_monthly_volume")]
        public int? EcMonthlyVolume
        {
            get
            {
                return this.ecMonthlyVolume;
            }

            set
            {
                this.shouldSerialize["ec_monthly_volume"] = true;
                this.ecMonthlyVolume = value;
            }
        }

        /// <summary>
        /// Merchant's MCC code.
        /// </summary>
        [JsonProperty("mcc_code")]
        public string MccCode { get; set; }

        /// <summary>
        /// Description of Goods or Services.
        /// </summary>
        [JsonProperty("business_description")]
        public string BusinessDescription { get; set; }

        /// <summary>
        /// Card present/swiped percentage
        /// </summary>
        [JsonProperty("swiped_percent")]
        public int SwipedPercent { get; set; }

        /// <summary>
        /// Card not present/keyed percentage
        /// </summary>
        [JsonProperty("keyed_percent")]
        public int KeyedPercent { get; set; }

        /// <summary>
        /// eCommerce percentage.
        /// </summary>
        [JsonProperty("ecommerce_percent")]
        public int EcommercePercent { get; set; }

        /// <summary>
        /// Indicates whether or not the merchant is a foreign entity.
        /// </summary>
        [JsonProperty("is_foreign_entity")]
        public bool IsForeignEntity { get; set; }

        /// <summary>
        /// Indicates whether or not the merchant is personally guaranteed.
        /// </summary>
        [JsonProperty("personally_guaranteed")]
        public bool PersonallyGuaranteed { get; set; }

        /// <summary>
        /// Merchant preferred language. English(“en-US”) will be used if no value is supplied.
        /// </summary>
        [JsonProperty("preferred_language")]
        public Models.PreferredLanguageEnum? PreferredLanguage
        {
            get
            {
                return this.preferredLanguage;
            }

            set
            {
                this.shouldSerialize["preferred_language"] = true;
                this.preferredLanguage = value;
            }
        }

        /// <summary>
        /// Gets or sets Addresses.
        /// </summary>
        [JsonProperty("addresses")]
        public List<Models.Address22> Addresses { get; set; }

        /// <summary>
        /// Gets or sets Owners.
        /// </summary>
        [JsonProperty("owners")]
        public List<Models.Owner> Owners { get; set; }

        /// <summary>
        /// Gets or sets BankAccounts.
        /// </summary>
        [JsonProperty("bank_accounts")]
        public List<Models.BankAccount> BankAccounts { get; set; }

        /// <summary>
        /// Gets or sets Documents.
        /// </summary>
        [JsonProperty("documents", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.Document> Documents { get; set; }

        /// <summary>
        /// Gets or sets PricingElements.
        /// </summary>
        [JsonProperty("pricing_elements", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.PricingElement> PricingElements { get; set; }

        /// <summary>
        /// Gets or sets KycResponseObjects.
        /// </summary>
        [JsonProperty("kyc_response_objects", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.KycResponseObject> KycResponseObjects { get; set; }

        /// <summary>
        /// Valid JSON of metadata related to merchant.
        /// </summary>
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public object Metadata { get; set; }

        /// <summary>
        /// Gets or sets Result.
        /// </summary>
        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Result Result { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Status5 Status { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data9 : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetClientAppId()
        {
            this.shouldSerialize["client_app_id"] = false;
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
        public void UnsetWebsite()
        {
            this.shouldSerialize["website"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEcMonthlyVolume()
        {
            this.shouldSerialize["ec_monthly_volume"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPreferredLanguage()
        {
            this.shouldSerialize["preferred_language"] = false;
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
        public bool ShouldSerializeClientAppId()
        {
            return this.shouldSerialize["client_app_id"];
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
        public bool ShouldSerializeWebsite()
        {
            return this.shouldSerialize["website"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEcMonthlyVolume()
        {
            return this.shouldSerialize["ec_monthly_volume"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePreferredLanguage()
        {
            return this.shouldSerialize["preferred_language"];
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
            return obj is Data9 other &&                ((this.ParentId == null && other.ParentId == null) || (this.ParentId?.Equals(other.ParentId) == true)) &&
                ((this.TemplateId == null && other.TemplateId == null) || (this.TemplateId?.Equals(other.TemplateId) == true)) &&
                ((this.ClientAppId == null && other.ClientAppId == null) || (this.ClientAppId?.Equals(other.ClientAppId) == true)) &&
                ((this.Email == null && other.Email == null) || (this.Email?.Equals(other.Email) == true)) &&
                ((this.DbaName == null && other.DbaName == null) || (this.DbaName?.Equals(other.DbaName) == true)) &&
                ((this.LegalName == null && other.LegalName == null) || (this.LegalName?.Equals(other.LegalName) == true)) &&
                ((this.Website == null && other.Website == null) || (this.Website?.Equals(other.Website) == true)) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                this.OwnershipType.Equals(other.OwnershipType) &&
                ((this.FedTaxId == null && other.FedTaxId == null) || (this.FedTaxId?.Equals(other.FedTaxId) == true)) &&
                this.AverageTicket.Equals(other.AverageTicket) &&
                this.HighTicket.Equals(other.HighTicket) &&
                this.CcMonthlyVolume.Equals(other.CcMonthlyVolume) &&
                ((this.EcMonthlyVolume == null && other.EcMonthlyVolume == null) || (this.EcMonthlyVolume?.Equals(other.EcMonthlyVolume) == true)) &&
                ((this.MccCode == null && other.MccCode == null) || (this.MccCode?.Equals(other.MccCode) == true)) &&
                ((this.BusinessDescription == null && other.BusinessDescription == null) || (this.BusinessDescription?.Equals(other.BusinessDescription) == true)) &&
                this.SwipedPercent.Equals(other.SwipedPercent) &&
                this.KeyedPercent.Equals(other.KeyedPercent) &&
                this.EcommercePercent.Equals(other.EcommercePercent) &&
                this.IsForeignEntity.Equals(other.IsForeignEntity) &&
                this.PersonallyGuaranteed.Equals(other.PersonallyGuaranteed) &&
                ((this.PreferredLanguage == null && other.PreferredLanguage == null) || (this.PreferredLanguage?.Equals(other.PreferredLanguage) == true)) &&
                ((this.Addresses == null && other.Addresses == null) || (this.Addresses?.Equals(other.Addresses) == true)) &&
                ((this.Owners == null && other.Owners == null) || (this.Owners?.Equals(other.Owners) == true)) &&
                ((this.BankAccounts == null && other.BankAccounts == null) || (this.BankAccounts?.Equals(other.BankAccounts) == true)) &&
                ((this.Documents == null && other.Documents == null) || (this.Documents?.Equals(other.Documents) == true)) &&
                ((this.PricingElements == null && other.PricingElements == null) || (this.PricingElements?.Equals(other.PricingElements) == true)) &&
                ((this.KycResponseObjects == null && other.KycResponseObjects == null) || (this.KycResponseObjects?.Equals(other.KycResponseObjects) == true)) &&
                ((this.Metadata == null && other.Metadata == null) || (this.Metadata?.Equals(other.Metadata) == true)) &&
                ((this.Result == null && other.Result == null) || (this.Result?.Equals(other.Result) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ParentId = {(this.ParentId == null ? "null" : this.ParentId)}");
            toStringOutput.Add($"this.TemplateId = {(this.TemplateId == null ? "null" : this.TemplateId)}");
            toStringOutput.Add($"this.ClientAppId = {(this.ClientAppId == null ? "null" : this.ClientAppId)}");
            toStringOutput.Add($"this.Email = {(this.Email == null ? "null" : this.Email)}");
            toStringOutput.Add($"this.DbaName = {(this.DbaName == null ? "null" : this.DbaName)}");
            toStringOutput.Add($"this.LegalName = {(this.LegalName == null ? "null" : this.LegalName)}");
            toStringOutput.Add($"this.Website = {(this.Website == null ? "null" : this.Website)}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber)}");
            toStringOutput.Add($"this.OwnershipType = {this.OwnershipType}");
            toStringOutput.Add($"this.FedTaxId = {(this.FedTaxId == null ? "null" : this.FedTaxId)}");
            toStringOutput.Add($"this.AverageTicket = {this.AverageTicket}");
            toStringOutput.Add($"this.HighTicket = {this.HighTicket}");
            toStringOutput.Add($"this.CcMonthlyVolume = {this.CcMonthlyVolume}");
            toStringOutput.Add($"this.EcMonthlyVolume = {(this.EcMonthlyVolume == null ? "null" : this.EcMonthlyVolume.ToString())}");
            toStringOutput.Add($"this.MccCode = {(this.MccCode == null ? "null" : this.MccCode)}");
            toStringOutput.Add($"this.BusinessDescription = {(this.BusinessDescription == null ? "null" : this.BusinessDescription)}");
            toStringOutput.Add($"this.SwipedPercent = {this.SwipedPercent}");
            toStringOutput.Add($"this.KeyedPercent = {this.KeyedPercent}");
            toStringOutput.Add($"this.EcommercePercent = {this.EcommercePercent}");
            toStringOutput.Add($"this.IsForeignEntity = {this.IsForeignEntity}");
            toStringOutput.Add($"this.PersonallyGuaranteed = {this.PersonallyGuaranteed}");
            toStringOutput.Add($"this.PreferredLanguage = {(this.PreferredLanguage == null ? "null" : this.PreferredLanguage.ToString())}");
            toStringOutput.Add($"this.Addresses = {(this.Addresses == null ? "null" : $"[{string.Join(", ", this.Addresses)} ]")}");
            toStringOutput.Add($"this.Owners = {(this.Owners == null ? "null" : $"[{string.Join(", ", this.Owners)} ]")}");
            toStringOutput.Add($"this.BankAccounts = {(this.BankAccounts == null ? "null" : $"[{string.Join(", ", this.BankAccounts)} ]")}");
            toStringOutput.Add($"this.Documents = {(this.Documents == null ? "null" : $"[{string.Join(", ", this.Documents)} ]")}");
            toStringOutput.Add($"this.PricingElements = {(this.PricingElements == null ? "null" : $"[{string.Join(", ", this.PricingElements)} ]")}");
            toStringOutput.Add($"this.KycResponseObjects = {(this.KycResponseObjects == null ? "null" : $"[{string.Join(", ", this.KycResponseObjects)} ]")}");
            toStringOutput.Add($"Metadata = {(this.Metadata == null ? "null" : this.Metadata.ToString())}");
            toStringOutput.Add($"this.Result = {(this.Result == null ? "null" : this.Result.ToString())}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}