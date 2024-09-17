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
    using APIMatic.Core.Utilities.Converters;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// LineItem.
    /// </summary>
    public class LineItem : BaseModel
    {
        private int? discountAmount;
        private int? otherTaxAmount;
        private int? quantity;
        private int? taxAmount;
        private int? taxRate;
        private string alternateTaxId;
        private Models.DebitCreditEnum? debitCredit;
        private int? discountRate;
        private string taxTypeApplied;
        private string taxTypeId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "discount_amount", false },
            { "other_tax_amount", false },
            { "quantity", false },
            { "tax_amount", false },
            { "tax_rate", false },
            { "alternate_tax_id", false },
            { "debit_credit", false },
            { "discount_rate", false },
            { "tax_type_applied", false },
            { "tax_type_id", false },
        };

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
            int unitCost,
            int? discountAmount = null,
            int? otherTaxAmount = null,
            int? quantity = null,
            int? taxAmount = null,
            int? taxRate = null,
            string alternateTaxId = null,
            Models.DebitCreditEnum? debitCredit = null,
            int? discountRate = null,
            string taxTypeApplied = null,
            string taxTypeId = null)
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
            if (alternateTaxId != null)
            {
                this.AlternateTaxId = alternateTaxId;
            }

            if (debitCredit != null)
            {
                this.DebitCredit = debitCredit;
            }

            if (discountRate != null)
            {
                this.DiscountRate = discountRate;
            }

            if (taxTypeApplied != null)
            {
                this.TaxTypeApplied = taxTypeApplied;
            }

            if (taxTypeId != null)
            {
                this.TaxTypeId = taxTypeId;
            }

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

        /// <summary>
        /// Tax identification number of the merchant that reported the alternate tax amount.
        /// </summary>
        [JsonProperty("alternate_tax_id")]
        public string AlternateTaxId
        {
            get
            {
                return this.alternateTaxId;
            }

            set
            {
                this.shouldSerialize["alternate_tax_id"] = true;
                this.alternateTaxId = value;
            }
        }

        /// <summary>
        /// Indicator used to reflect debit (D) or credit (C) transaction. Allowed values: “D”, “C”.
        /// </summary>
        [JsonProperty("debit_credit")]
        public Models.DebitCreditEnum? DebitCredit
        {
            get
            {
                return this.debitCredit;
            }

            set
            {
                this.shouldSerialize["debit_credit"] = true;
                this.debitCredit = value;
            }
        }

        /// <summary>
        /// Discount rate for the line item ,Can accept Two (2) decimal places.
        /// </summary>
        [JsonProperty("discount_rate")]
        public int? DiscountRate
        {
            get
            {
                return this.discountRate;
            }

            set
            {
                this.shouldSerialize["discount_rate"] = true;
                this.discountRate = value;
            }
        }

        /// <summary>
        /// Type of value-added taxes that are being used (Conditional If tax amount is supplied)
        /// </summary>
        [JsonProperty("tax_type_applied")]
        public string TaxTypeApplied
        {
            get
            {
                return this.taxTypeApplied;
            }

            set
            {
                this.shouldSerialize["tax_type_applied"] = true;
                this.taxTypeApplied = value;
            }
        }

        /// <summary>
        /// Indicates the type of tax collected in relationship to a specific tax amount (Conditional If tax amount is supplied)
        /// </summary>
        [JsonProperty("tax_type_id")]
        public string TaxTypeId
        {
            get
            {
                return this.taxTypeId;
            }

            set
            {
                this.shouldSerialize["tax_type_id"] = true;
                this.taxTypeId = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LineItem : ({string.Join(", ", toStringOutput)})";
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
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAlternateTaxId()
        {
            this.shouldSerialize["alternate_tax_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDebitCredit()
        {
            this.shouldSerialize["debit_credit"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDiscountRate()
        {
            this.shouldSerialize["discount_rate"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTaxTypeApplied()
        {
            this.shouldSerialize["tax_type_applied"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTaxTypeId()
        {
            this.shouldSerialize["tax_type_id"] = false;
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

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAlternateTaxId()
        {
            return this.shouldSerialize["alternate_tax_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDebitCredit()
        {
            return this.shouldSerialize["debit_credit"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDiscountRate()
        {
            return this.shouldSerialize["discount_rate"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTaxTypeApplied()
        {
            return this.shouldSerialize["tax_type_applied"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTaxTypeId()
        {
            return this.shouldSerialize["tax_type_id"];
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
            return obj is LineItem other &&                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
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
            toStringOutput.Add($"this.AlternateTaxId = {(this.AlternateTaxId == null ? "null" : this.AlternateTaxId)}");
            toStringOutput.Add($"this.DebitCredit = {(this.DebitCredit == null ? "null" : this.DebitCredit.ToString())}");
            toStringOutput.Add($"this.DiscountRate = {(this.DiscountRate == null ? "null" : this.DiscountRate.ToString())}");
            toStringOutput.Add($"this.TaxTypeApplied = {(this.TaxTypeApplied == null ? "null" : this.TaxTypeApplied)}");
            toStringOutput.Add($"this.TaxTypeId = {(this.TaxTypeId == null ? "null" : this.TaxTypeId)}");

            base.ToString(toStringOutput);
        }
    }
}