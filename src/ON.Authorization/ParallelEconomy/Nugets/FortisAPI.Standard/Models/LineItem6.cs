// <copyright file="LineItem6.cs" company="APIMatic">
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
    /// LineItem6.
    /// </summary>
    public class LineItem6 : BaseModel
    {
        private int? discountAmount;
        private int? otherTaxAmount;
        private int? quantity;
        private int? taxAmount;
        private int? taxRate;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "discount_amount", false },
            { "other_tax_amount", false },
            { "quantity", false },
            { "tax_amount", false },
            { "tax_rate", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="LineItem6"/> class.
        /// </summary>
        public LineItem6()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineItem6"/> class.
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
        public LineItem6(
            string description,
            string commodityCode,
            string productCode,
            string unitCode,
            int unitCost,
            int? discountAmount = null,
            int? otherTaxAmount = null,
            int? quantity = null,
            int? taxAmount = null,
            int? taxRate = null)
        {
            this.Description = description;
            this.CommodityCode = commodityCode;
            if (discountAmount != null)
            {
                this.DiscountAmount = discountAmount;
            }

            if (otherTaxAmount != null)
            {
                this.OtherTaxAmount = otherTaxAmount;
            }

            this.ProductCode = productCode;
            if (quantity != null)
            {
                this.Quantity = quantity;
            }

            if (taxAmount != null)
            {
                this.TaxAmount = taxAmount;
            }

            if (taxRate != null)
            {
                this.TaxRate = taxRate;
            }

            this.UnitCode = unitCode;
            this.UnitCost = unitCost;
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
        [JsonProperty("discount_amount")]
        public int? DiscountAmount
        {
            get
            {
                return this.discountAmount;
            }

            set
            {
                this.shouldSerialize["discount_amount"] = true;
                this.discountAmount = value;
            }
        }

        /// <summary>
        /// Used if city or multiple county taxes need to be broken out separately ,Can accept Two (2) decimal places.
        /// </summary>
        [JsonProperty("other_tax_amount")]
        public int? OtherTaxAmount
        {
            get
            {
                return this.otherTaxAmount;
            }

            set
            {
                this.shouldSerialize["other_tax_amount"] = true;
                this.otherTaxAmount = value;
            }
        }

        /// <summary>
        /// Merchant-defined description code of the item.
        /// </summary>
        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        /// <summary>
        /// Quantity of the item, can accept Four (4) decimal places.
        /// </summary>
        [JsonProperty("quantity")]
        public int? Quantity
        {
            get
            {
                return this.quantity;
            }

            set
            {
                this.shouldSerialize["quantity"] = true;
                this.quantity = value;
            }
        }

        /// <summary>
        /// Amount of any value added taxes, can accept Two (2) decimal places.
        /// </summary>
        [JsonProperty("tax_amount")]
        public int? TaxAmount
        {
            get
            {
                return this.taxAmount;
            }

            set
            {
                this.shouldSerialize["tax_amount"] = true;
                this.taxAmount = value;
            }
        }

        /// <summary>
        /// Tax rate used to calculate the sales tax amount, can accept 2 decimal places.
        /// </summary>
        [JsonProperty("tax_rate")]
        public int? TaxRate
        {
            get
            {
                return this.taxRate;
            }

            set
            {
                this.shouldSerialize["tax_rate"] = true;
                this.taxRate = value;
            }
        }

        /// <summary>
        /// Units of measurement as used in international trade. (See Codes for Units of Measurement below for unit code abbreviations)
        /// </summary>
        [JsonProperty("unit_code")]
        public string UnitCode { get; set; }

        /// <summary>
        /// Unit cost of the item ,Can accept Four (4) decimal places.
        /// </summary>
        [JsonProperty("unit_cost")]
        public int UnitCost { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LineItem6 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDiscountAmount()
        {
            this.shouldSerialize["discount_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetOtherTaxAmount()
        {
            this.shouldSerialize["other_tax_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetQuantity()
        {
            this.shouldSerialize["quantity"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTaxAmount()
        {
            this.shouldSerialize["tax_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTaxRate()
        {
            this.shouldSerialize["tax_rate"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDiscountAmount()
        {
            return this.shouldSerialize["discount_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOtherTaxAmount()
        {
            return this.shouldSerialize["other_tax_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeQuantity()
        {
            return this.shouldSerialize["quantity"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTaxAmount()
        {
            return this.shouldSerialize["tax_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTaxRate()
        {
            return this.shouldSerialize["tax_rate"];
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
            return obj is LineItem6 other &&                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.CommodityCode == null && other.CommodityCode == null) || (this.CommodityCode?.Equals(other.CommodityCode) == true)) &&
                ((this.DiscountAmount == null && other.DiscountAmount == null) || (this.DiscountAmount?.Equals(other.DiscountAmount) == true)) &&
                ((this.OtherTaxAmount == null && other.OtherTaxAmount == null) || (this.OtherTaxAmount?.Equals(other.OtherTaxAmount) == true)) &&
                ((this.ProductCode == null && other.ProductCode == null) || (this.ProductCode?.Equals(other.ProductCode) == true)) &&
                ((this.Quantity == null && other.Quantity == null) || (this.Quantity?.Equals(other.Quantity) == true)) &&
                ((this.TaxAmount == null && other.TaxAmount == null) || (this.TaxAmount?.Equals(other.TaxAmount) == true)) &&
                ((this.TaxRate == null && other.TaxRate == null) || (this.TaxRate?.Equals(other.TaxRate) == true)) &&
                ((this.UnitCode == null && other.UnitCode == null) || (this.UnitCode?.Equals(other.UnitCode) == true)) &&
                this.UnitCost.Equals(other.UnitCost);
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description)}");
            toStringOutput.Add($"this.CommodityCode = {(this.CommodityCode == null ? "null" : this.CommodityCode)}");
            toStringOutput.Add($"this.DiscountAmount = {(this.DiscountAmount == null ? "null" : this.DiscountAmount.ToString())}");
            toStringOutput.Add($"this.OtherTaxAmount = {(this.OtherTaxAmount == null ? "null" : this.OtherTaxAmount.ToString())}");
            toStringOutput.Add($"this.ProductCode = {(this.ProductCode == null ? "null" : this.ProductCode)}");
            toStringOutput.Add($"this.Quantity = {(this.Quantity == null ? "null" : this.Quantity.ToString())}");
            toStringOutput.Add($"this.TaxAmount = {(this.TaxAmount == null ? "null" : this.TaxAmount.ToString())}");
            toStringOutput.Add($"this.TaxRate = {(this.TaxRate == null ? "null" : this.TaxRate.ToString())}");
            toStringOutput.Add($"this.UnitCode = {(this.UnitCode == null ? "null" : this.UnitCode)}");
            toStringOutput.Add($"this.UnitCost = {this.UnitCost}");

            base.ToString(toStringOutput);
        }
    }
}