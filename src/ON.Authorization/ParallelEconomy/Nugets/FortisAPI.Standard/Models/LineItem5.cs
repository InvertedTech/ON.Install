// <copyright file="LineItem5.cs" company="APIMatic">
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
    /// LineItem5.
    /// </summary>
    public class LineItem5 : BaseModel
    {
        private string alternateTaxId;
        private Models.DebitCreditEnum? debitCredit;
        private int? discountAmount;
        private int? discountRate;
        private int? quantity;
        private int? taxAmount;
        private int? taxRate;
        private string taxTypeApplied;
        private string taxTypeId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "alternate_tax_id", false },
            { "debit_credit", false },
            { "discount_amount", false },
            { "discount_rate", false },
            { "quantity", false },
            { "tax_amount", false },
            { "tax_rate", false },
            { "tax_type_applied", false },
            { "tax_type_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="LineItem5"/> class.
        /// </summary>
        public LineItem5()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineItem5"/> class.
        /// </summary>
        /// <param name="description">description.</param>
        /// <param name="productCode">product_code.</param>
        /// <param name="unitCode">unit_code.</param>
        /// <param name="unitCost">unit_cost.</param>
        /// <param name="alternateTaxId">alternate_tax_id.</param>
        /// <param name="debitCredit">debit_credit.</param>
        /// <param name="discountAmount">discount_amount.</param>
        /// <param name="discountRate">discount_rate.</param>
        /// <param name="quantity">quantity.</param>
        /// <param name="taxAmount">tax_amount.</param>
        /// <param name="taxRate">tax_rate.</param>
        /// <param name="taxTypeApplied">tax_type_applied.</param>
        /// <param name="taxTypeId">tax_type_id.</param>
        public LineItem5(
            string description,
            string productCode,
            string unitCode,
            int unitCost,
            string alternateTaxId = null,
            Models.DebitCreditEnum? debitCredit = null,
            int? discountAmount = null,
            int? discountRate = null,
            int? quantity = null,
            int? taxAmount = null,
            int? taxRate = null,
            string taxTypeApplied = null,
            string taxTypeId = null)
        {
            if (alternateTaxId != null)
            {
                this.AlternateTaxId = alternateTaxId;
            }

            if (debitCredit != null)
            {
                this.DebitCredit = debitCredit;
            }

            this.Description = description;
            if (discountAmount != null)
            {
                this.DiscountAmount = discountAmount;
            }

            if (discountRate != null)
            {
                this.DiscountRate = discountRate;
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

            if (taxTypeApplied != null)
            {
                this.TaxTypeApplied = taxTypeApplied;
            }

            if (taxTypeId != null)
            {
                this.TaxTypeId = taxTypeId;
            }

            this.UnitCode = unitCode;
            this.UnitCost = unitCost;
        }

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
        /// Description of the item.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

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

            return $"LineItem5 : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetDiscountAmount()
        {
            this.shouldSerialize["discount_amount"] = false;
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
        public bool ShouldSerializeDiscountAmount()
        {
            return this.shouldSerialize["discount_amount"];
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
            return obj is LineItem5 other &&                ((this.AlternateTaxId == null && other.AlternateTaxId == null) || (this.AlternateTaxId?.Equals(other.AlternateTaxId) == true)) &&
                ((this.DebitCredit == null && other.DebitCredit == null) || (this.DebitCredit?.Equals(other.DebitCredit) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.DiscountAmount == null && other.DiscountAmount == null) || (this.DiscountAmount?.Equals(other.DiscountAmount) == true)) &&
                ((this.DiscountRate == null && other.DiscountRate == null) || (this.DiscountRate?.Equals(other.DiscountRate) == true)) &&
                ((this.ProductCode == null && other.ProductCode == null) || (this.ProductCode?.Equals(other.ProductCode) == true)) &&
                ((this.Quantity == null && other.Quantity == null) || (this.Quantity?.Equals(other.Quantity) == true)) &&
                ((this.TaxAmount == null && other.TaxAmount == null) || (this.TaxAmount?.Equals(other.TaxAmount) == true)) &&
                ((this.TaxRate == null && other.TaxRate == null) || (this.TaxRate?.Equals(other.TaxRate) == true)) &&
                ((this.TaxTypeApplied == null && other.TaxTypeApplied == null) || (this.TaxTypeApplied?.Equals(other.TaxTypeApplied) == true)) &&
                ((this.TaxTypeId == null && other.TaxTypeId == null) || (this.TaxTypeId?.Equals(other.TaxTypeId) == true)) &&
                ((this.UnitCode == null && other.UnitCode == null) || (this.UnitCode?.Equals(other.UnitCode) == true)) &&
                this.UnitCost.Equals(other.UnitCost);
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AlternateTaxId = {(this.AlternateTaxId == null ? "null" : this.AlternateTaxId)}");
            toStringOutput.Add($"this.DebitCredit = {(this.DebitCredit == null ? "null" : this.DebitCredit.ToString())}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description)}");
            toStringOutput.Add($"this.DiscountAmount = {(this.DiscountAmount == null ? "null" : this.DiscountAmount.ToString())}");
            toStringOutput.Add($"this.DiscountRate = {(this.DiscountRate == null ? "null" : this.DiscountRate.ToString())}");
            toStringOutput.Add($"this.ProductCode = {(this.ProductCode == null ? "null" : this.ProductCode)}");
            toStringOutput.Add($"this.Quantity = {(this.Quantity == null ? "null" : this.Quantity.ToString())}");
            toStringOutput.Add($"this.TaxAmount = {(this.TaxAmount == null ? "null" : this.TaxAmount.ToString())}");
            toStringOutput.Add($"this.TaxRate = {(this.TaxRate == null ? "null" : this.TaxRate.ToString())}");
            toStringOutput.Add($"this.TaxTypeApplied = {(this.TaxTypeApplied == null ? "null" : this.TaxTypeApplied)}");
            toStringOutput.Add($"this.TaxTypeId = {(this.TaxTypeId == null ? "null" : this.TaxTypeId)}");
            toStringOutput.Add($"this.UnitCode = {(this.UnitCode == null ? "null" : this.UnitCode)}");
            toStringOutput.Add($"this.UnitCost = {this.UnitCost}");

            base.ToString(toStringOutput);
        }
    }
}