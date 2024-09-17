// <copyright file="Level3Data5.cs" company="APIMatic">
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
    /// Level3Data5.
    /// </summary>
    public class Level3Data5 : BaseModel
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
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Level3Data5"/> class.
        /// </summary>
        public Level3Data5()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Level3Data5"/> class.
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
        public Level3Data5(
            List<Models.LineItem5> lineItems,
            string destinationCountryCode = null,
            int? dutyAmount = null,
            int? freightAmount = null,
            int? nationalTax = null,
            int? salesTax = null,
            string shipfromZipCode = null,
            string shiptoZipCode = null,
            int? taxAmount = null,
            Models.TaxExemptEnum? taxExempt = null)
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
        /// Array of line items in transaction
        /// </summary>
        [JsonProperty("line_items")]
        public List<Models.LineItem5> LineItems { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Level3Data5 : ({string.Join(", ", toStringOutput)})";
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
            return obj is Level3Data5 other &&                ((this.DestinationCountryCode == null && other.DestinationCountryCode == null) || (this.DestinationCountryCode?.Equals(other.DestinationCountryCode) == true)) &&
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
            toStringOutput.Add($"this.LineItems = {(this.LineItems == null ? "null" : $"[{string.Join(", ", this.LineItems)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}