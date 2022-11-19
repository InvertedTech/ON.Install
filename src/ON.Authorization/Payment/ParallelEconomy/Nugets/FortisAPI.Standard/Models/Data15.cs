// <copyright file="Data15.cs" company="APIMatic">
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
    /// Data15.
    /// </summary>
    public class Data15
    {
        private string visaProductSubType;
        private string visaLargeTicketIndicator;
        private string cardClass;
        private string tokenInd;
        private string issuingNetwork;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "visa_product_sub_type", false },
            { "visa_large_ticket_indicator", false },
            { "card_class", false },
            { "token_ind", false },
            { "issuing_network", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Data15"/> class.
        /// </summary>
        public Data15()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data15"/> class.
        /// </summary>
        /// <param name="issuerBankName">issuer_bank_name.</param>
        /// <param name="countryCode">country_code.</param>
        /// <param name="detailCardProduct">detail_card_product.</param>
        /// <param name="detailCardIndicator">detail_card_indicator.</param>
        /// <param name="fsaIndicator">fsa_indicator.</param>
        /// <param name="prepaidIndicator">prepaid_indicator.</param>
        /// <param name="productId">product_id.</param>
        /// <param name="regulatorIndicator">regulator_indicator.</param>
        /// <param name="accountFundSource">account_fund_source.</param>
        /// <param name="visaProductSubType">visa_product_sub_type.</param>
        /// <param name="visaLargeTicketIndicator">visa_large_ticket_indicator.</param>
        /// <param name="cardClass">card_class.</param>
        /// <param name="tokenInd">token_ind.</param>
        /// <param name="issuingNetwork">issuing_network.</param>
        public Data15(
            string issuerBankName,
            string countryCode,
            string detailCardProduct,
            string detailCardIndicator,
            string fsaIndicator,
            string prepaidIndicator,
            string productId,
            string regulatorIndicator,
            string accountFundSource,
            string visaProductSubType = null,
            string visaLargeTicketIndicator = null,
            string cardClass = null,
            string tokenInd = null,
            string issuingNetwork = null)
        {
            this.IssuerBankName = issuerBankName;
            this.CountryCode = countryCode;
            this.DetailCardProduct = detailCardProduct;
            this.DetailCardIndicator = detailCardIndicator;
            this.FsaIndicator = fsaIndicator;
            this.PrepaidIndicator = prepaidIndicator;
            this.ProductId = productId;
            this.RegulatorIndicator = regulatorIndicator;
            if (visaProductSubType != null)
            {
                this.VisaProductSubType = visaProductSubType;
            }

            if (visaLargeTicketIndicator != null)
            {
                this.VisaLargeTicketIndicator = visaLargeTicketIndicator;
            }

            this.AccountFundSource = accountFundSource;
            if (cardClass != null)
            {
                this.CardClass = cardClass;
            }

            if (tokenInd != null)
            {
                this.TokenInd = tokenInd;
            }

            if (issuingNetwork != null)
            {
                this.IssuingNetwork = issuingNetwork;
            }

        }

        /// <summary>
        /// The Issuer Bank name for the BIN
        /// </summary>
        [JsonProperty("issuer_bank_name")]
        public string IssuerBankName { get; set; }

        /// <summary>
        /// VISA - Three character alpha country code
        /// MC - Three character alpha country code
        /// Maestro - Three character alpha country code
        /// Amex - Space Filled
        /// Discover - Three character alpha country code or spaces when Discover doesn't share issuer country.
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// V - Visa
        /// M - MasterCard
        /// A - American Express
        /// D - Discover
        /// N - PIN Only (Non-Visa/MasterCard/AMEX/Discover
        /// </summary>
        [JsonProperty("detail_card_product")]
        public string DetailCardProduct { get; set; }

        /// <summary>
        /// Left justified, Space filled
        /// </summary>
        [JsonProperty("detail_card_indicator")]
        public string DetailCardIndicator { get; set; }

        /// <summary>
        /// Left justified, Space filled
        /// </summary>
        [JsonProperty("fsa_indicator")]
        public string FsaIndicator { get; set; }

        /// <summary>
        /// P = Prepaid Card
        /// Default: Space filled
        /// </summary>
        [JsonProperty("prepaid_indicator")]
        public string PrepaidIndicator { get; set; }

        /// <summary>
        /// P = Prepaid Card
        /// Default: Space filled
        /// </summary>
        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// P = Prepaid Card
        /// Default: Space filled
        /// </summary>
        [JsonProperty("regulator_indicator")]
        public string RegulatorIndicator { get; set; }

        /// <summary>
        /// This is used to identify product sub-types, i.e. further classification of product.
        /// </summary>
        [JsonProperty("visa_product_sub_type")]
        public string VisaProductSubType
        {
            get
            {
                return this.visaProductSubType;
            }

            set
            {
                this.shouldSerialize["visa_product_sub_type"] = true;
                this.visaProductSubType = value;
            }
        }

        /// <summary>
        /// L = Visa Large Ticket.
        /// Default: Space filled
        /// </summary>
        [JsonProperty("visa_large_ticket_indicator")]
        public string VisaLargeTicketIndicator
        {
            get
            {
                return this.visaLargeTicketIndicator;
            }

            set
            {
                this.shouldSerialize["visa_large_ticket_indicator"] = true;
                this.visaLargeTicketIndicator = value;
            }
        }

        /// <summary>
        /// For Visa, MasterCard, and Discover.  Identifies the source of the funds associated with the primary account for the card.
        /// </summary>
        [JsonProperty("account_fund_source")]
        public string AccountFundSource { get; set; }

        /// <summary>
        /// Categorizes the BIN as a Business card, Corporate T&E card, Purchase card or Consumer card. Assists the POS device with prompting decisions – to collect addenda or not.  Visa, MasterCard and Discover only.
        /// </summary>
        [JsonProperty("card_class")]
        public string CardClass
        {
            get
            {
                return this.cardClass;
            }

            set
            {
                this.shouldSerialize["card_class"] = true;
                this.cardClass = value;
            }
        }

        /// <summary>
        /// Token Indicator values:
        /// Y = Token BIN
        /// Default: Space filled
        /// VISA, MC, and Discover Only
        /// </summary>
        [JsonProperty("token_ind")]
        public string TokenInd
        {
            get
            {
                return this.tokenInd;
            }

            set
            {
                this.shouldSerialize["token_ind"] = true;
                this.tokenInd = value;
            }
        }

        /// <summary>
        /// For Discover card types
        /// 00 - Discover
        /// 01 - Diners
        /// 02 - JCB (Japanese Credit Bank)
        /// 03 - CUP (China Union Pay)
        /// 04 PayPal
        /// </summary>
        [JsonProperty("issuing_network")]
        public string IssuingNetwork
        {
            get
            {
                return this.issuingNetwork;
            }

            set
            {
                this.shouldSerialize["issuing_network"] = true;
                this.issuingNetwork = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data15 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetVisaProductSubType()
        {
            this.shouldSerialize["visa_product_sub_type"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetVisaLargeTicketIndicator()
        {
            this.shouldSerialize["visa_large_ticket_indicator"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCardClass()
        {
            this.shouldSerialize["card_class"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTokenInd()
        {
            this.shouldSerialize["token_ind"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetIssuingNetwork()
        {
            this.shouldSerialize["issuing_network"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeVisaProductSubType()
        {
            return this.shouldSerialize["visa_product_sub_type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeVisaLargeTicketIndicator()
        {
            return this.shouldSerialize["visa_large_ticket_indicator"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCardClass()
        {
            return this.shouldSerialize["card_class"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTokenInd()
        {
            return this.shouldSerialize["token_ind"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIssuingNetwork()
        {
            return this.shouldSerialize["issuing_network"];
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

            return obj is Data15 other &&
                ((this.IssuerBankName == null && other.IssuerBankName == null) || (this.IssuerBankName?.Equals(other.IssuerBankName) == true)) &&
                ((this.CountryCode == null && other.CountryCode == null) || (this.CountryCode?.Equals(other.CountryCode) == true)) &&
                ((this.DetailCardProduct == null && other.DetailCardProduct == null) || (this.DetailCardProduct?.Equals(other.DetailCardProduct) == true)) &&
                ((this.DetailCardIndicator == null && other.DetailCardIndicator == null) || (this.DetailCardIndicator?.Equals(other.DetailCardIndicator) == true)) &&
                ((this.FsaIndicator == null && other.FsaIndicator == null) || (this.FsaIndicator?.Equals(other.FsaIndicator) == true)) &&
                ((this.PrepaidIndicator == null && other.PrepaidIndicator == null) || (this.PrepaidIndicator?.Equals(other.PrepaidIndicator) == true)) &&
                ((this.ProductId == null && other.ProductId == null) || (this.ProductId?.Equals(other.ProductId) == true)) &&
                ((this.RegulatorIndicator == null && other.RegulatorIndicator == null) || (this.RegulatorIndicator?.Equals(other.RegulatorIndicator) == true)) &&
                ((this.VisaProductSubType == null && other.VisaProductSubType == null) || (this.VisaProductSubType?.Equals(other.VisaProductSubType) == true)) &&
                ((this.VisaLargeTicketIndicator == null && other.VisaLargeTicketIndicator == null) || (this.VisaLargeTicketIndicator?.Equals(other.VisaLargeTicketIndicator) == true)) &&
                ((this.AccountFundSource == null && other.AccountFundSource == null) || (this.AccountFundSource?.Equals(other.AccountFundSource) == true)) &&
                ((this.CardClass == null && other.CardClass == null) || (this.CardClass?.Equals(other.CardClass) == true)) &&
                ((this.TokenInd == null && other.TokenInd == null) || (this.TokenInd?.Equals(other.TokenInd) == true)) &&
                ((this.IssuingNetwork == null && other.IssuingNetwork == null) || (this.IssuingNetwork?.Equals(other.IssuingNetwork) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IssuerBankName = {(this.IssuerBankName == null ? "null" : this.IssuerBankName == string.Empty ? "" : this.IssuerBankName)}");
            toStringOutput.Add($"this.CountryCode = {(this.CountryCode == null ? "null" : this.CountryCode == string.Empty ? "" : this.CountryCode)}");
            toStringOutput.Add($"this.DetailCardProduct = {(this.DetailCardProduct == null ? "null" : this.DetailCardProduct == string.Empty ? "" : this.DetailCardProduct)}");
            toStringOutput.Add($"this.DetailCardIndicator = {(this.DetailCardIndicator == null ? "null" : this.DetailCardIndicator == string.Empty ? "" : this.DetailCardIndicator)}");
            toStringOutput.Add($"this.FsaIndicator = {(this.FsaIndicator == null ? "null" : this.FsaIndicator == string.Empty ? "" : this.FsaIndicator)}");
            toStringOutput.Add($"this.PrepaidIndicator = {(this.PrepaidIndicator == null ? "null" : this.PrepaidIndicator == string.Empty ? "" : this.PrepaidIndicator)}");
            toStringOutput.Add($"this.ProductId = {(this.ProductId == null ? "null" : this.ProductId == string.Empty ? "" : this.ProductId)}");
            toStringOutput.Add($"this.RegulatorIndicator = {(this.RegulatorIndicator == null ? "null" : this.RegulatorIndicator == string.Empty ? "" : this.RegulatorIndicator)}");
            toStringOutput.Add($"this.VisaProductSubType = {(this.VisaProductSubType == null ? "null" : this.VisaProductSubType == string.Empty ? "" : this.VisaProductSubType)}");
            toStringOutput.Add($"this.VisaLargeTicketIndicator = {(this.VisaLargeTicketIndicator == null ? "null" : this.VisaLargeTicketIndicator == string.Empty ? "" : this.VisaLargeTicketIndicator)}");
            toStringOutput.Add($"this.AccountFundSource = {(this.AccountFundSource == null ? "null" : this.AccountFundSource == string.Empty ? "" : this.AccountFundSource)}");
            toStringOutput.Add($"this.CardClass = {(this.CardClass == null ? "null" : this.CardClass == string.Empty ? "" : this.CardClass)}");
            toStringOutput.Add($"this.TokenInd = {(this.TokenInd == null ? "null" : this.TokenInd == string.Empty ? "" : this.TokenInd)}");
            toStringOutput.Add($"this.IssuingNetwork = {(this.IssuingNetwork == null ? "null" : this.IssuingNetwork == string.Empty ? "" : this.IssuingNetwork)}");
        }
    }
}