// <copyright file="Level3Data3.cs" company="APIMatic">
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
    /// Level3Data3.
    /// </summary>
    public class Level3Data3
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Level3Data3"/> class.
        /// </summary>
        public Level3Data3()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Level3Data3"/> class.
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
        public Level3Data3(
            List<Models.LineItem3> lineItems,
            string destinationCountryCode = null,
            double? dutyAmount = null,
            double? freightAmount = null,
            double? nationalTax = null,
            double? salesTax = null,
            string shipfromZipCode = null,
            string shiptoZipCode = null,
            double? taxAmount = null,
            Models.TaxExemptEnum? taxExempt = null)
        {
            this.DestinationCountryCode = destinationCountryCode;
            this.DutyAmount = dutyAmount;
            this.FreightAmount = freightAmount;
            this.NationalTax = nationalTax;
            this.SalesTax = salesTax;
            this.ShipfromZipCode = shipfromZipCode;
            this.ShiptoZipCode = shiptoZipCode;
            this.TaxAmount = taxAmount;
            this.TaxExempt = taxExempt;
            this.LineItems = lineItems;
        }

        /// <summary>
        /// Code of the country where the goods are being shipped.
        /// </summary>
        [JsonProperty("destination_country_code", NullValueHandling = NullValueHandling.Ignore)]
        public string DestinationCountryCode { get; set; }

        /// <summary>
        /// Fee amount associated with the import of the purchased goods ,Can accept Two (2) decimal places
        /// </summary>
        [JsonProperty("duty_amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? DutyAmount { get; set; }

        /// <summary>
        /// Freight or shipping portion of the total transaction amount ,Can accept Two (2) decimal places.
        /// </summary>
        [JsonProperty("freight_amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? FreightAmount { get; set; }

        /// <summary>
        /// National tax for the transaction ,Can accept Two (2) decimal places.
        /// </summary>
        [JsonProperty("national_tax", NullValueHandling = NullValueHandling.Ignore)]
        public double? NationalTax { get; set; }

        /// <summary>
        /// Sales tax for the transaction ,Can accept Two (2) decimal places.
        /// </summary>
        [JsonProperty("sales_tax", NullValueHandling = NullValueHandling.Ignore)]
        public double? SalesTax { get; set; }

        /// <summary>
        /// Postal/ZIP code of the address from where the purchased goods are being shipped.
        /// </summary>
        [JsonProperty("shipfrom_zip_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ShipfromZipCode { get; set; }

        /// <summary>
        /// Postal/ZIP code of the address where purchased goods will be delivered.
        /// </summary>
        [JsonProperty("shipto_zip_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ShiptoZipCode { get; set; }

        /// <summary>
        /// Amount of any value added taxes ,Can accept Two (2) decimal places.
        /// </summary>
        [JsonProperty("tax_amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? TaxAmount { get; set; }

        /// <summary>
        /// Sales Tax Exempt. Allowed values: “1”, “0”.
        /// </summary>
        [JsonProperty("tax_exempt", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TaxExemptEnum? TaxExempt { get; set; }

        /// <summary>
        /// Array of line items in transaction
        /// </summary>
        [JsonProperty("line_items")]
        public List<Models.LineItem3> LineItems { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Level3Data3 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Level3Data3 other &&
                ((this.DestinationCountryCode == null && other.DestinationCountryCode == null) || (this.DestinationCountryCode?.Equals(other.DestinationCountryCode) == true)) &&
                ((this.DutyAmount == null && other.DutyAmount == null) || (this.DutyAmount?.Equals(other.DutyAmount) == true)) &&
                ((this.FreightAmount == null && other.FreightAmount == null) || (this.FreightAmount?.Equals(other.FreightAmount) == true)) &&
                ((this.NationalTax == null && other.NationalTax == null) || (this.NationalTax?.Equals(other.NationalTax) == true)) &&
                ((this.SalesTax == null && other.SalesTax == null) || (this.SalesTax?.Equals(other.SalesTax) == true)) &&
                ((this.ShipfromZipCode == null && other.ShipfromZipCode == null) || (this.ShipfromZipCode?.Equals(other.ShipfromZipCode) == true)) &&
                ((this.ShiptoZipCode == null && other.ShiptoZipCode == null) || (this.ShiptoZipCode?.Equals(other.ShiptoZipCode) == true)) &&
                ((this.TaxAmount == null && other.TaxAmount == null) || (this.TaxAmount?.Equals(other.TaxAmount) == true)) &&
                ((this.TaxExempt == null && other.TaxExempt == null) || (this.TaxExempt?.Equals(other.TaxExempt) == true)) &&
                ((this.LineItems == null && other.LineItems == null) || (this.LineItems?.Equals(other.LineItems) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DestinationCountryCode = {(this.DestinationCountryCode == null ? "null" : this.DestinationCountryCode == string.Empty ? "" : this.DestinationCountryCode)}");
            toStringOutput.Add($"this.DutyAmount = {(this.DutyAmount == null ? "null" : this.DutyAmount.ToString())}");
            toStringOutput.Add($"this.FreightAmount = {(this.FreightAmount == null ? "null" : this.FreightAmount.ToString())}");
            toStringOutput.Add($"this.NationalTax = {(this.NationalTax == null ? "null" : this.NationalTax.ToString())}");
            toStringOutput.Add($"this.SalesTax = {(this.SalesTax == null ? "null" : this.SalesTax.ToString())}");
            toStringOutput.Add($"this.ShipfromZipCode = {(this.ShipfromZipCode == null ? "null" : this.ShipfromZipCode == string.Empty ? "" : this.ShipfromZipCode)}");
            toStringOutput.Add($"this.ShiptoZipCode = {(this.ShiptoZipCode == null ? "null" : this.ShiptoZipCode == string.Empty ? "" : this.ShiptoZipCode)}");
            toStringOutput.Add($"this.TaxAmount = {(this.TaxAmount == null ? "null" : this.TaxAmount.ToString())}");
            toStringOutput.Add($"this.TaxExempt = {(this.TaxExempt == null ? "null" : this.TaxExempt.ToString())}");
            toStringOutput.Add($"this.LineItems = {(this.LineItems == null ? "null" : $"[{string.Join(", ", this.LineItems)} ]")}");
        }
    }
}