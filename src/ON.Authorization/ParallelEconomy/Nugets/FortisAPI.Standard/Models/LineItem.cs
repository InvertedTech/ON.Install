// <copyright file="LineItem.cs" company="APIMatic">
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
    /// LineItem.
    /// </summary>
    public class LineItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LineItem"/> class.
        /// </summary>
        public LineItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineItem"/> class.
        /// </summary>
        /// <param name="description">description.</param>
        /// <param name="commodityCode">commodity_code.</param>
        /// <param name="productCode">product_code.</param>
        /// <param name="unitCode">unit_code.</param>
        /// <param name="unitCost">unit_cost.</param>
        /// <param name="discountAmount">discount_amount.</param>
        /// <param name="otherTaxAmount">other_tax_amount.</param>
        /// <param name="quantity">quantity.</param>
        /// <param name="taxAmount">tax_amount.</param>
        /// <param name="taxRate">tax_rate.</param>
        /// <param name="alternateTaxId">alternate_tax_id.</param>
        /// <param name="debitCredit">debit_credit.</param>
        /// <param name="discountRate">discount_rate.</param>
        /// <param name="taxTypeApplied">tax_type_applied.</param>
        /// <param name="taxTypeId">tax_type_id.</param>
        public LineItem(
            string description,
            string commodityCode,
            string productCode,
            string unitCode,
            double unitCost,
            double? discountAmount = null,
            double? otherTaxAmount = null,
            double? quantity = null,
            double? taxAmount = null,
            double? taxRate = null,
            string alternateTaxId = null,
            Models.DebitCreditEnum? debitCredit = null,
            double? discountRate = null,
            string taxTypeApplied = null,
            string taxTypeId = null)
        {
            this.Description = description;
            this.CommodityCode = commodityCode;
            this.DiscountAmount = discountAmount;
            this.OtherTaxAmount = otherTaxAmount;
            this.ProductCode = productCode;
            this.Quantity = quantity;
            this.TaxAmount = taxAmount;
            this.TaxRate = taxRate;
            this.UnitCode = unitCode;
            this.UnitCost = unitCost;
            this.AlternateTaxId = alternateTaxId;
            this.DebitCredit = debitCredit;
            this.DiscountRate = discountRate;
            this.TaxTypeApplied = taxTypeApplied;
            this.TaxTypeId = taxTypeId;
        }

        /// <summary>
        /// Description of the item.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// An international description code of the individual good or service being supplied.
        /// </summary>
        [JsonProperty("commodity_code")]
        public string CommodityCode { get; set; }

        /// <summary>
        /// Total discount amount applied against the line item total ,Can accept Two (2) decimal places.
        /// </summary>
        [JsonProperty("discount_amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? DiscountAmount { get; set; }

        /// <summary>
        /// Used if city or multiple county taxes need to be broken out separately ,Can accept Two (2) decimal places.
        /// </summary>
        [JsonProperty("other_tax_amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? OtherTaxAmount { get; set; }

        /// <summary>
        /// Merchant-defined description code of the item.
        /// </summary>
        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        /// <summary>
        /// Quantity of the item, can accept Four (4) decimal places.
        /// </summary>
        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public double? Quantity { get; set; }

        /// <summary>
        /// Amount of any value added taxes, can accept Two (2) decimal places.
        /// </summary>
        [JsonProperty("tax_amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? TaxAmount { get; set; }

        /// <summary>
        /// Tax rate used to calculate the sales tax amount, can accept 2 decimal places.
        /// </summary>
        [JsonProperty("tax_rate", NullValueHandling = NullValueHandling.Ignore)]
        public double? TaxRate { get; set; }

        /// <summary>
        /// Units of measurement as used in international trade. (See Codes for Units of Measurement below for unit code abbreviations)
        /// </summary>
        [JsonProperty("unit_code")]
        public string UnitCode { get; set; }

        /// <summary>
        /// Unit cost of the item ,Can accept Four (4) decimal places.
        /// </summary>
        [JsonProperty("unit_cost")]
        public double UnitCost { get; set; }

        /// <summary>
        /// Tax identification number of the merchant that reported the alternate tax amount.
        /// </summary>
        [JsonProperty("alternate_tax_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AlternateTaxId { get; set; }

        /// <summary>
        /// Indicator used to reflect debit (D) or credit (C) transaction. Allowed values: “D”, “C”.
        /// </summary>
        [JsonProperty("debit_credit", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.DebitCreditEnum? DebitCredit { get; set; }

        /// <summary>
        /// Discount rate for the line item ,Can accept Two (2) decimal places.
        /// </summary>
        [JsonProperty("discount_rate", NullValueHandling = NullValueHandling.Ignore)]
        public double? DiscountRate { get; set; }

        /// <summary>
        /// Type of value-added taxes that are being used (Conditional If tax amount is supplied)
        /// </summary>
        [JsonProperty("tax_type_applied", NullValueHandling = NullValueHandling.Ignore)]
        public string TaxTypeApplied { get; set; }

        /// <summary>
        /// Indicates the type of tax collected in relationship to a specific tax amount (Conditional If tax amount is supplied)
        /// </summary>
        [JsonProperty("tax_type_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TaxTypeId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LineItem : ({string.Join(", ", toStringOutput)})";
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

            return obj is LineItem other &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.CommodityCode == null && other.CommodityCode == null) || (this.CommodityCode?.Equals(other.CommodityCode) == true)) &&
                ((this.DiscountAmount == null && other.DiscountAmount == null) || (this.DiscountAmount?.Equals(other.DiscountAmount) == true)) &&
                ((this.OtherTaxAmount == null && other.OtherTaxAmount == null) || (this.OtherTaxAmount?.Equals(other.OtherTaxAmount) == true)) &&
                ((this.ProductCode == null && other.ProductCode == null) || (this.ProductCode?.Equals(other.ProductCode) == true)) &&
                ((this.Quantity == null && other.Quantity == null) || (this.Quantity?.Equals(other.Quantity) == true)) &&
                ((this.TaxAmount == null && other.TaxAmount == null) || (this.TaxAmount?.Equals(other.TaxAmount) == true)) &&
                ((this.TaxRate == null && other.TaxRate == null) || (this.TaxRate?.Equals(other.TaxRate) == true)) &&
                ((this.UnitCode == null && other.UnitCode == null) || (this.UnitCode?.Equals(other.UnitCode) == true)) &&
                this.UnitCost.Equals(other.UnitCost) &&
                ((this.AlternateTaxId == null && other.AlternateTaxId == null) || (this.AlternateTaxId?.Equals(other.AlternateTaxId) == true)) &&
                ((this.DebitCredit == null && other.DebitCredit == null) || (this.DebitCredit?.Equals(other.DebitCredit) == true)) &&
                ((this.DiscountRate == null && other.DiscountRate == null) || (this.DiscountRate?.Equals(other.DiscountRate) == true)) &&
                ((this.TaxTypeApplied == null && other.TaxTypeApplied == null) || (this.TaxTypeApplied?.Equals(other.TaxTypeApplied) == true)) &&
                ((this.TaxTypeId == null && other.TaxTypeId == null) || (this.TaxTypeId?.Equals(other.TaxTypeId) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.CommodityCode = {(this.CommodityCode == null ? "null" : this.CommodityCode == string.Empty ? "" : this.CommodityCode)}");
            toStringOutput.Add($"this.DiscountAmount = {(this.DiscountAmount == null ? "null" : this.DiscountAmount.ToString())}");
            toStringOutput.Add($"this.OtherTaxAmount = {(this.OtherTaxAmount == null ? "null" : this.OtherTaxAmount.ToString())}");
            toStringOutput.Add($"this.ProductCode = {(this.ProductCode == null ? "null" : this.ProductCode == string.Empty ? "" : this.ProductCode)}");
            toStringOutput.Add($"this.Quantity = {(this.Quantity == null ? "null" : this.Quantity.ToString())}");
            toStringOutput.Add($"this.TaxAmount = {(this.TaxAmount == null ? "null" : this.TaxAmount.ToString())}");
            toStringOutput.Add($"this.TaxRate = {(this.TaxRate == null ? "null" : this.TaxRate.ToString())}");
            toStringOutput.Add($"this.UnitCode = {(this.UnitCode == null ? "null" : this.UnitCode == string.Empty ? "" : this.UnitCode)}");
            toStringOutput.Add($"this.UnitCost = {this.UnitCost}");
            toStringOutput.Add($"this.AlternateTaxId = {(this.AlternateTaxId == null ? "null" : this.AlternateTaxId == string.Empty ? "" : this.AlternateTaxId)}");
            toStringOutput.Add($"this.DebitCredit = {(this.DebitCredit == null ? "null" : this.DebitCredit.ToString())}");
            toStringOutput.Add($"this.DiscountRate = {(this.DiscountRate == null ? "null" : this.DiscountRate.ToString())}");
            toStringOutput.Add($"this.TaxTypeApplied = {(this.TaxTypeApplied == null ? "null" : this.TaxTypeApplied == string.Empty ? "" : this.TaxTypeApplied)}");
            toStringOutput.Add($"this.TaxTypeId = {(this.TaxTypeId == null ? "null" : this.TaxTypeId == string.Empty ? "" : this.TaxTypeId)}");
        }
    }
}