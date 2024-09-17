// <copyright file="Level3Data6.cs" company="APIMatic">
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
    /// Level3Data6.
    /// </summary>
    public class Level3Data6 : BaseModel
    {
        private string destinationCountryCode;
        private int? dutyAmount;
        private int? freightAmount;
        private int? nationalTax;
        private int? salesTax;
        private string shipfromZipCode;
        private string shiptoZipCode;
        private int? taxAmount;
        private Models.TaxExemptEnum? taxExempt;
        private string customerVatRegistration;
        private string merchantVatRegistration;
        private string orderDate;
        private string summaryCommodityCode;
        private int? taxRate;
        private string uniqueVatRefNumber;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "destination_country_code", false },
            { "duty_amount", false },
            { "freight_amount", false },
            { "national_tax", false },
            { "sales_tax", false },
            { "shipfrom_zip_code", false },
            { "shipto_zip_code", false },
            { "tax_amount", false },
            { "tax_exempt", false },
            { "customer_vat_registration", false },
            { "merchant_vat_registration", false },
            { "order_date", false },
            { "summary_commodity_code", false },
            { "tax_rate", false },
            { "unique_vat_ref_number", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Level3Data6"/> class.
        /// </summary>
        public Level3Data6()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Level3Data6"/> class.
        /// </summary>
        /// <param name="lineItems">line_items.</param>
        /// <param name="destinationCountryCode">destination_country_code.</param>
        /// <param name="dutyAmount">duty_amount.</param>
        /// <param name="freightAmount">freight_amount.</param>
        /// <param name="nationalTax">national_tax.</param>
        /// <param name="salesTax">sales_tax.</param>
        /// <param name="shipfromZipCode">shipfrom_zip_code.</param>
        /// <param name="shiptoZipCode">shipto_zip_code.</param>
        /// <param name="taxAmount">tax_amount.</param>
        /// <param name="taxExempt">tax_exempt.</param>
        /// <param name="customerVatRegistration">customer_vat_registration.</param>
        /// <param name="merchantVatRegistration">merchant_vat_registration.</param>
        /// <param name="orderDate">order_date.</param>
        /// <param name="summaryCommodityCode">summary_commodity_code.</param>
        /// <param name="taxRate">tax_rate.</param>
        /// <param name="uniqueVatRefNumber">unique_vat_ref_number.</param>
        public Level3Data6(
            List<Models.LineItem6> lineItems,
            string destinationCountryCode = null,
            int? dutyAmount = null,
            int? freightAmount = null,
            int? nationalTax = null,
            int? salesTax = null,
            string shipfromZipCode = null,
            string shiptoZipCode = null,
            int? taxAmount = null,
            Models.TaxExemptEnum? taxExempt = null,
            string customerVatRegistration = null,
            string merchantVatRegistration = null,
            string orderDate = null,
            string summaryCommodityCode = null,
            int? taxRate = null,
            string uniqueVatRefNumber = null)
        {
            if (destinationCountryCode != null)
            {
                this.DestinationCountryCode = destinationCountryCode;
            }

            if (dutyAmount != null)
            {
                this.DutyAmount = dutyAmount;
            }

            if (freightAmount != null)
            {
                this.FreightAmount = freightAmount;
            }

            if (nationalTax != null)
            {
                this.NationalTax = nationalTax;
            }

            if (salesTax != null)
            {
                this.SalesTax = salesTax;
            }

            if (shipfromZipCode != null)
            {
                this.ShipfromZipCode = shipfromZipCode;
            }

            if (shiptoZipCode != null)
            {
                this.ShiptoZipCode = shiptoZipCode;
            }

            if (taxAmount != null)
            {
                this.TaxAmount = taxAmount;
            }

            if (taxExempt != null)
            {
                this.TaxExempt = taxExempt;
            }

            if (customerVatRegistration != null)
            {
                this.CustomerVatRegistration = customerVatRegistration;
            }

            if (merchantVatRegistration != null)
            {
                this.MerchantVatRegistration = merchantVatRegistration;
            }

            if (orderDate != null)
            {
                this.OrderDate = orderDate;
            }

            if (summaryCommodityCode != null)
            {
                this.SummaryCommodityCode = summaryCommodityCode;
            }

            if (taxRate != null)
            {
                this.TaxRate = taxRate;
            }

            if (uniqueVatRefNumber != null)
            {
                this.UniqueVatRefNumber = uniqueVatRefNumber;
            }

            this.LineItems = lineItems;
        }

        /// <summary>
        /// Code of the country where the goods are being shipped.
        /// </summary>
        [JsonProperty("destination_country_code")]
        public string DestinationCountryCode
        {
            get
            {
                return this.destinationCountryCode;
            }

            set
            {
                this.shouldSerialize["destination_country_code"] = true;
                this.destinationCountryCode = value;
            }
        }

        /// <summary>
        /// Fee amount associated with the import of the purchased goods ,Can accept Two (2) decimal places
        /// </summary>
        [JsonProperty("duty_amount")]
        public int? DutyAmount
        {
            get
            {
                return this.dutyAmount;
            }

            set
            {
                this.shouldSerialize["duty_amount"] = true;
                this.dutyAmount = value;
            }
        }

        /// <summary>
        /// Freight or shipping portion of the total transaction amount ,Can accept Two (2) decimal places.
        /// </summary>
        [JsonProperty("freight_amount")]
        public int? FreightAmount
        {
            get
            {
                return this.freightAmount;
            }

            set
            {
                this.shouldSerialize["freight_amount"] = true;
                this.freightAmount = value;
            }
        }

        /// <summary>
        /// National tax for the transaction ,Can accept Two (2) decimal places.
        /// </summary>
        [JsonProperty("national_tax")]
        public int? NationalTax
        {
            get
            {
                return this.nationalTax;
            }

            set
            {
                this.shouldSerialize["national_tax"] = true;
                this.nationalTax = value;
            }
        }

        /// <summary>
        /// Sales tax for the transaction ,Can accept Two (2) decimal places.
        /// </summary>
        [JsonProperty("sales_tax")]
        public int? SalesTax
        {
            get
            {
                return this.salesTax;
            }

            set
            {
                this.shouldSerialize["sales_tax"] = true;
                this.salesTax = value;
            }
        }

        /// <summary>
        /// Postal/ZIP code of the address from where the purchased goods are being shipped.
        /// </summary>
        [JsonProperty("shipfrom_zip_code")]
        public string ShipfromZipCode
        {
            get
            {
                return this.shipfromZipCode;
            }

            set
            {
                this.shouldSerialize["shipfrom_zip_code"] = true;
                this.shipfromZipCode = value;
            }
        }

        /// <summary>
        /// Postal/ZIP code of the address where purchased goods will be delivered.
        /// </summary>
        [JsonProperty("shipto_zip_code")]
        public string ShiptoZipCode
        {
            get
            {
                return this.shiptoZipCode;
            }

            set
            {
                this.shouldSerialize["shipto_zip_code"] = true;
                this.shiptoZipCode = value;
            }
        }

        /// <summary>
        /// Amount of any value added taxes ,Can accept Two (2) decimal places.
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
        /// Sales Tax Exempt. Allowed values: “1”, “0”.
        /// </summary>
        [JsonProperty("tax_exempt")]
        public Models.TaxExemptEnum? TaxExempt
        {
            get
            {
                return this.taxExempt;
            }

            set
            {
                this.shouldSerialize["tax_exempt"] = true;
                this.taxExempt = value;
            }
        }

        /// <summary>
        /// Customer VAT Registration
        /// </summary>
        [JsonProperty("customer_vat_registration")]
        public string CustomerVatRegistration
        {
            get
            {
                return this.customerVatRegistration;
            }

            set
            {
                this.shouldSerialize["customer_vat_registration"] = true;
                this.customerVatRegistration = value;
            }
        }

        /// <summary>
        /// Merchant VAT Registration
        /// </summary>
        [JsonProperty("merchant_vat_registration")]
        public string MerchantVatRegistration
        {
            get
            {
                return this.merchantVatRegistration;
            }

            set
            {
                this.shouldSerialize["merchant_vat_registration"] = true;
                this.merchantVatRegistration = value;
            }
        }

        /// <summary>
        /// Order Date
        /// </summary>
        [JsonProperty("order_date")]
        public string OrderDate
        {
            get
            {
                return this.orderDate;
            }

            set
            {
                this.shouldSerialize["order_date"] = true;
                this.orderDate = value;
            }
        }

        /// <summary>
        /// Summary Commodity Code
        /// </summary>
        [JsonProperty("summary_commodity_code")]
        public string SummaryCommodityCode
        {
            get
            {
                return this.summaryCommodityCode;
            }

            set
            {
                this.shouldSerialize["summary_commodity_code"] = true;
                this.summaryCommodityCode = value;
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
        /// Unique VAT Reference Number
        /// </summary>
        [JsonProperty("unique_vat_ref_number")]
        public string UniqueVatRefNumber
        {
            get
            {
                return this.uniqueVatRefNumber;
            }

            set
            {
                this.shouldSerialize["unique_vat_ref_number"] = true;
                this.uniqueVatRefNumber = value;
            }
        }

        /// <summary>
        /// Array of line items in transaction
        /// </summary>
        [JsonProperty("line_items")]
        public List<Models.LineItem6> LineItems { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Level3Data6 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDestinationCountryCode()
        {
            this.shouldSerialize["destination_country_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDutyAmount()
        {
            this.shouldSerialize["duty_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFreightAmount()
        {
            this.shouldSerialize["freight_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetNationalTax()
        {
            this.shouldSerialize["national_tax"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSalesTax()
        {
            this.shouldSerialize["sales_tax"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetShipfromZipCode()
        {
            this.shouldSerialize["shipfrom_zip_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetShiptoZipCode()
        {
            this.shouldSerialize["shipto_zip_code"] = false;
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
        public void UnsetTaxExempt()
        {
            this.shouldSerialize["tax_exempt"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCustomerVatRegistration()
        {
            this.shouldSerialize["customer_vat_registration"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMerchantVatRegistration()
        {
            this.shouldSerialize["merchant_vat_registration"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetOrderDate()
        {
            this.shouldSerialize["order_date"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSummaryCommodityCode()
        {
            this.shouldSerialize["summary_commodity_code"] = false;
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
        public void UnsetUniqueVatRefNumber()
        {
            this.shouldSerialize["unique_vat_ref_number"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDestinationCountryCode()
        {
            return this.shouldSerialize["destination_country_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDutyAmount()
        {
            return this.shouldSerialize["duty_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFreightAmount()
        {
            return this.shouldSerialize["freight_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNationalTax()
        {
            return this.shouldSerialize["national_tax"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSalesTax()
        {
            return this.shouldSerialize["sales_tax"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeShipfromZipCode()
        {
            return this.shouldSerialize["shipfrom_zip_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeShiptoZipCode()
        {
            return this.shouldSerialize["shipto_zip_code"];
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
        public bool ShouldSerializeTaxExempt()
        {
            return this.shouldSerialize["tax_exempt"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerVatRegistration()
        {
            return this.shouldSerialize["customer_vat_registration"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMerchantVatRegistration()
        {
            return this.shouldSerialize["merchant_vat_registration"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrderDate()
        {
            return this.shouldSerialize["order_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSummaryCommodityCode()
        {
            return this.shouldSerialize["summary_commodity_code"];
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
        public bool ShouldSerializeUniqueVatRefNumber()
        {
            return this.shouldSerialize["unique_vat_ref_number"];
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
            return obj is Level3Data6 other &&                ((this.DestinationCountryCode == null && other.DestinationCountryCode == null) || (this.DestinationCountryCode?.Equals(other.DestinationCountryCode) == true)) &&
                ((this.DutyAmount == null && other.DutyAmount == null) || (this.DutyAmount?.Equals(other.DutyAmount) == true)) &&
                ((this.FreightAmount == null && other.FreightAmount == null) || (this.FreightAmount?.Equals(other.FreightAmount) == true)) &&
                ((this.NationalTax == null && other.NationalTax == null) || (this.NationalTax?.Equals(other.NationalTax) == true)) &&
                ((this.SalesTax == null && other.SalesTax == null) || (this.SalesTax?.Equals(other.SalesTax) == true)) &&
                ((this.ShipfromZipCode == null && other.ShipfromZipCode == null) || (this.ShipfromZipCode?.Equals(other.ShipfromZipCode) == true)) &&
                ((this.ShiptoZipCode == null && other.ShiptoZipCode == null) || (this.ShiptoZipCode?.Equals(other.ShiptoZipCode) == true)) &&
                ((this.TaxAmount == null && other.TaxAmount == null) || (this.TaxAmount?.Equals(other.TaxAmount) == true)) &&
                ((this.TaxExempt == null && other.TaxExempt == null) || (this.TaxExempt?.Equals(other.TaxExempt) == true)) &&
                ((this.CustomerVatRegistration == null && other.CustomerVatRegistration == null) || (this.CustomerVatRegistration?.Equals(other.CustomerVatRegistration) == true)) &&
                ((this.MerchantVatRegistration == null && other.MerchantVatRegistration == null) || (this.MerchantVatRegistration?.Equals(other.MerchantVatRegistration) == true)) &&
                ((this.OrderDate == null && other.OrderDate == null) || (this.OrderDate?.Equals(other.OrderDate) == true)) &&
                ((this.SummaryCommodityCode == null && other.SummaryCommodityCode == null) || (this.SummaryCommodityCode?.Equals(other.SummaryCommodityCode) == true)) &&
                ((this.TaxRate == null && other.TaxRate == null) || (this.TaxRate?.Equals(other.TaxRate) == true)) &&
                ((this.UniqueVatRefNumber == null && other.UniqueVatRefNumber == null) || (this.UniqueVatRefNumber?.Equals(other.UniqueVatRefNumber) == true)) &&
                ((this.LineItems == null && other.LineItems == null) || (this.LineItems?.Equals(other.LineItems) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DestinationCountryCode = {(this.DestinationCountryCode == null ? "null" : this.DestinationCountryCode)}");
            toStringOutput.Add($"this.DutyAmount = {(this.DutyAmount == null ? "null" : this.DutyAmount.ToString())}");
            toStringOutput.Add($"this.FreightAmount = {(this.FreightAmount == null ? "null" : this.FreightAmount.ToString())}");
            toStringOutput.Add($"this.NationalTax = {(this.NationalTax == null ? "null" : this.NationalTax.ToString())}");
            toStringOutput.Add($"this.SalesTax = {(this.SalesTax == null ? "null" : this.SalesTax.ToString())}");
            toStringOutput.Add($"this.ShipfromZipCode = {(this.ShipfromZipCode == null ? "null" : this.ShipfromZipCode)}");
            toStringOutput.Add($"this.ShiptoZipCode = {(this.ShiptoZipCode == null ? "null" : this.ShiptoZipCode)}");
            toStringOutput.Add($"this.TaxAmount = {(this.TaxAmount == null ? "null" : this.TaxAmount.ToString())}");
            toStringOutput.Add($"this.TaxExempt = {(this.TaxExempt == null ? "null" : this.TaxExempt.ToString())}");
            toStringOutput.Add($"this.CustomerVatRegistration = {(this.CustomerVatRegistration == null ? "null" : this.CustomerVatRegistration)}");
            toStringOutput.Add($"this.MerchantVatRegistration = {(this.MerchantVatRegistration == null ? "null" : this.MerchantVatRegistration)}");
            toStringOutput.Add($"this.OrderDate = {(this.OrderDate == null ? "null" : this.OrderDate)}");
            toStringOutput.Add($"this.SummaryCommodityCode = {(this.SummaryCommodityCode == null ? "null" : this.SummaryCommodityCode)}");
            toStringOutput.Add($"this.TaxRate = {(this.TaxRate == null ? "null" : this.TaxRate.ToString())}");
            toStringOutput.Add($"this.UniqueVatRefNumber = {(this.UniqueVatRefNumber == null ? "null" : this.UniqueVatRefNumber)}");
            toStringOutput.Add($"this.LineItems = {(this.LineItems == null ? "null" : $"[{string.Join(", ", this.LineItems)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}