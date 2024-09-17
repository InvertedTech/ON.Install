// <copyright file="ProductInvoice.cs" company="APIMatic">
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
    /// ProductInvoice.
    /// </summary>
    public class ProductInvoice : BaseModel
    {
        private string quoteNumberFormat;
        private double? quoteNumberStart;
        private double? quoteNumberIncrement;
        private double? quoteNumberCurrent;
        private string invoiceNumberFormat;
        private double? invoiceNumberStart;
        private double? invoiceNumberIncrement;
        private double? invoiceNumberCurrent;
        private int? taxFee;
        private int? monthlyFee;
        private double? selectable;
        private double? reportable;
        private string portfolioId;
        private string createdUserId;
        private string modifiedUserId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "quote_number_format", false },
            { "quote_number_start", false },
            { "quote_number_increment", false },
            { "quote_number_current", false },
            { "invoice_number_format", false },
            { "invoice_number_start", false },
            { "invoice_number_increment", false },
            { "invoice_number_current", false },
            { "tax_fee", false },
            { "monthly_fee", false },
            { "selectable", false },
            { "reportable", false },
            { "portfolio_id", false },
            { "created_user_id", false },
            { "modified_user_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductInvoice"/> class.
        /// </summary>
        public ProductInvoice()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductInvoice"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="taxRate">tax_rate.</param>
        /// <param name="perInvoiceFee">per_invoice_fee.</param>
        /// <param name="perQuoteFee">per_quote_fee.</param>
        /// <param name="requirePayInFull">require_pay_in_full.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="quoteNumberFormat">quote_number_format.</param>
        /// <param name="quoteNumberStart">quote_number_start.</param>
        /// <param name="quoteNumberIncrement">quote_number_increment.</param>
        /// <param name="quoteNumberCurrent">quote_number_current.</param>
        /// <param name="invoiceNumberFormat">invoice_number_format.</param>
        /// <param name="invoiceNumberStart">invoice_number_start.</param>
        /// <param name="invoiceNumberIncrement">invoice_number_increment.</param>
        /// <param name="invoiceNumberCurrent">invoice_number_current.</param>
        /// <param name="taxFee">tax_fee.</param>
        /// <param name="monthlyFee">monthly_fee.</param>
        /// <param name="selectable">selectable.</param>
        /// <param name="reportable">reportable.</param>
        /// <param name="portfolioId">portfolio_id.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="modifiedUserId">modified_user_id.</param>
        public ProductInvoice(
            string title,
            double taxRate,
            int perInvoiceFee,
            int perQuoteFee,
            bool requirePayInFull,
            string locationId,
            string id,
            int createdTs,
            int modifiedTs,
            string quoteNumberFormat = null,
            double? quoteNumberStart = null,
            double? quoteNumberIncrement = null,
            double? quoteNumberCurrent = null,
            string invoiceNumberFormat = null,
            double? invoiceNumberStart = null,
            double? invoiceNumberIncrement = null,
            double? invoiceNumberCurrent = null,
            int? taxFee = null,
            int? monthlyFee = null,
            double? selectable = null,
            double? reportable = null,
            string portfolioId = null,
            string createdUserId = null,
            string modifiedUserId = null)
        {
            this.Title = title;
            if (quoteNumberFormat != null)
            {
                this.QuoteNumberFormat = quoteNumberFormat;
            }

            if (quoteNumberStart != null)
            {
                this.QuoteNumberStart = quoteNumberStart;
            }

            if (quoteNumberIncrement != null)
            {
                this.QuoteNumberIncrement = quoteNumberIncrement;
            }

            if (quoteNumberCurrent != null)
            {
                this.QuoteNumberCurrent = quoteNumberCurrent;
            }

            if (invoiceNumberFormat != null)
            {
                this.InvoiceNumberFormat = invoiceNumberFormat;
            }

            if (invoiceNumberStart != null)
            {
                this.InvoiceNumberStart = invoiceNumberStart;
            }

            if (invoiceNumberIncrement != null)
            {
                this.InvoiceNumberIncrement = invoiceNumberIncrement;
            }

            if (invoiceNumberCurrent != null)
            {
                this.InvoiceNumberCurrent = invoiceNumberCurrent;
            }

            this.TaxRate = taxRate;
            if (taxFee != null)
            {
                this.TaxFee = taxFee;
            }

            if (monthlyFee != null)
            {
                this.MonthlyFee = monthlyFee;
            }

            this.PerInvoiceFee = perInvoiceFee;
            this.PerQuoteFee = perQuoteFee;
            this.RequirePayInFull = requirePayInFull;
            if (selectable != null)
            {
                this.Selectable = selectable;
            }

            if (reportable != null)
            {
                this.Reportable = reportable;
            }

            if (portfolioId != null)
            {
                this.PortfolioId = portfolioId;
            }

            this.LocationId = locationId;
            this.Id = id;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            if (createdUserId != null)
            {
                this.CreatedUserId = createdUserId;
            }

            if (modifiedUserId != null)
            {
                this.ModifiedUserId = modifiedUserId;
            }

        }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Quote Number Format
        /// </summary>
        [JsonProperty("quote_number_format")]
        public string QuoteNumberFormat
        {
            get
            {
                return this.quoteNumberFormat;
            }

            set
            {
                this.shouldSerialize["quote_number_format"] = true;
                this.quoteNumberFormat = value;
            }
        }

        /// <summary>
        /// Quote Number Start
        /// </summary>
        [JsonProperty("quote_number_start")]
        public double? QuoteNumberStart
        {
            get
            {
                return this.quoteNumberStart;
            }

            set
            {
                this.shouldSerialize["quote_number_start"] = true;
                this.quoteNumberStart = value;
            }
        }

        /// <summary>
        /// Quote Number Increment
        /// </summary>
        [JsonProperty("quote_number_increment")]
        public double? QuoteNumberIncrement
        {
            get
            {
                return this.quoteNumberIncrement;
            }

            set
            {
                this.shouldSerialize["quote_number_increment"] = true;
                this.quoteNumberIncrement = value;
            }
        }

        /// <summary>
        /// Quote Number Current
        /// </summary>
        [JsonProperty("quote_number_current")]
        public double? QuoteNumberCurrent
        {
            get
            {
                return this.quoteNumberCurrent;
            }

            set
            {
                this.shouldSerialize["quote_number_current"] = true;
                this.quoteNumberCurrent = value;
            }
        }

        /// <summary>
        /// Invoice Number Format
        /// </summary>
        [JsonProperty("invoice_number_format")]
        public string InvoiceNumberFormat
        {
            get
            {
                return this.invoiceNumberFormat;
            }

            set
            {
                this.shouldSerialize["invoice_number_format"] = true;
                this.invoiceNumberFormat = value;
            }
        }

        /// <summary>
        /// Invoice Number Start
        /// </summary>
        [JsonProperty("invoice_number_start")]
        public double? InvoiceNumberStart
        {
            get
            {
                return this.invoiceNumberStart;
            }

            set
            {
                this.shouldSerialize["invoice_number_start"] = true;
                this.invoiceNumberStart = value;
            }
        }

        /// <summary>
        /// Invoice Number Increment
        /// </summary>
        [JsonProperty("invoice_number_increment")]
        public double? InvoiceNumberIncrement
        {
            get
            {
                return this.invoiceNumberIncrement;
            }

            set
            {
                this.shouldSerialize["invoice_number_increment"] = true;
                this.invoiceNumberIncrement = value;
            }
        }

        /// <summary>
        /// Invoice Number Current
        /// </summary>
        [JsonProperty("invoice_number_current")]
        public double? InvoiceNumberCurrent
        {
            get
            {
                return this.invoiceNumberCurrent;
            }

            set
            {
                this.shouldSerialize["invoice_number_current"] = true;
                this.invoiceNumberCurrent = value;
            }
        }

        /// <summary>
        /// Tax Rate
        /// </summary>
        [JsonProperty("tax_rate")]
        public double TaxRate { get; set; }

        /// <summary>
        /// Tax Fee
        /// </summary>
        [JsonProperty("tax_fee")]
        public int? TaxFee
        {
            get
            {
                return this.taxFee;
            }

            set
            {
                this.shouldSerialize["tax_fee"] = true;
                this.taxFee = value;
            }
        }

        /// <summary>
        /// Monthly Fees
        /// </summary>
        [JsonProperty("monthly_fee")]
        public int? MonthlyFee
        {
            get
            {
                return this.monthlyFee;
            }

            set
            {
                this.shouldSerialize["monthly_fee"] = true;
                this.monthlyFee = value;
            }
        }

        /// <summary>
        /// Per Invoice Fee
        /// </summary>
        [JsonProperty("per_invoice_fee")]
        public int PerInvoiceFee { get; set; }

        /// <summary>
        /// Per Quote fee
        /// </summary>
        [JsonProperty("per_quote_fee")]
        public int PerQuoteFee { get; set; }

        /// <summary>
        /// Require Pay In Full
        /// </summary>
        [JsonProperty("require_pay_in_full")]
        public bool RequirePayInFull { get; set; }

        /// <summary>
        /// Selectable
        /// </summary>
        [JsonProperty("selectable")]
        public double? Selectable
        {
            get
            {
                return this.selectable;
            }

            set
            {
                this.shouldSerialize["selectable"] = true;
                this.selectable = value;
            }
        }

        /// <summary>
        /// Reportable
        /// </summary>
        [JsonProperty("reportable")]
        public double? Reportable
        {
            get
            {
                return this.reportable;
            }

            set
            {
                this.shouldSerialize["reportable"] = true;
                this.reportable = value;
            }
        }

        /// <summary>
        /// Portfolio Id
        /// </summary>
        [JsonProperty("portfolio_id")]
        public string PortfolioId
        {
            get
            {
                return this.portfolioId;
            }

            set
            {
                this.shouldSerialize["portfolio_id"] = true;
                this.portfolioId = value;
            }
        }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        /// <summary>
        /// Product Invoice Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int CreatedTs { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts")]
        public int ModifiedTs { get; set; }

        /// <summary>
        /// User ID Created the register
        /// </summary>
        [JsonProperty("created_user_id")]
        public string CreatedUserId
        {
            get
            {
                return this.createdUserId;
            }

            set
            {
                this.shouldSerialize["created_user_id"] = true;
                this.createdUserId = value;
            }
        }

        /// <summary>
        /// Last User ID that updated the register
        /// </summary>
        [JsonProperty("modified_user_id")]
        public string ModifiedUserId
        {
            get
            {
                return this.modifiedUserId;
            }

            set
            {
                this.shouldSerialize["modified_user_id"] = true;
                this.modifiedUserId = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ProductInvoice : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetQuoteNumberFormat()
        {
            this.shouldSerialize["quote_number_format"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetQuoteNumberStart()
        {
            this.shouldSerialize["quote_number_start"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetQuoteNumberIncrement()
        {
            this.shouldSerialize["quote_number_increment"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetQuoteNumberCurrent()
        {
            this.shouldSerialize["quote_number_current"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetInvoiceNumberFormat()
        {
            this.shouldSerialize["invoice_number_format"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetInvoiceNumberStart()
        {
            this.shouldSerialize["invoice_number_start"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetInvoiceNumberIncrement()
        {
            this.shouldSerialize["invoice_number_increment"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetInvoiceNumberCurrent()
        {
            this.shouldSerialize["invoice_number_current"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTaxFee()
        {
            this.shouldSerialize["tax_fee"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMonthlyFee()
        {
            this.shouldSerialize["monthly_fee"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSelectable()
        {
            this.shouldSerialize["selectable"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReportable()
        {
            this.shouldSerialize["reportable"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPortfolioId()
        {
            this.shouldSerialize["portfolio_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCreatedUserId()
        {
            this.shouldSerialize["created_user_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetModifiedUserId()
        {
            this.shouldSerialize["modified_user_id"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeQuoteNumberFormat()
        {
            return this.shouldSerialize["quote_number_format"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeQuoteNumberStart()
        {
            return this.shouldSerialize["quote_number_start"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeQuoteNumberIncrement()
        {
            return this.shouldSerialize["quote_number_increment"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeQuoteNumberCurrent()
        {
            return this.shouldSerialize["quote_number_current"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInvoiceNumberFormat()
        {
            return this.shouldSerialize["invoice_number_format"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInvoiceNumberStart()
        {
            return this.shouldSerialize["invoice_number_start"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInvoiceNumberIncrement()
        {
            return this.shouldSerialize["invoice_number_increment"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInvoiceNumberCurrent()
        {
            return this.shouldSerialize["invoice_number_current"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTaxFee()
        {
            return this.shouldSerialize["tax_fee"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMonthlyFee()
        {
            return this.shouldSerialize["monthly_fee"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSelectable()
        {
            return this.shouldSerialize["selectable"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReportable()
        {
            return this.shouldSerialize["reportable"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePortfolioId()
        {
            return this.shouldSerialize["portfolio_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCreatedUserId()
        {
            return this.shouldSerialize["created_user_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModifiedUserId()
        {
            return this.shouldSerialize["modified_user_id"];
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
            return obj is ProductInvoice other &&                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.QuoteNumberFormat == null && other.QuoteNumberFormat == null) || (this.QuoteNumberFormat?.Equals(other.QuoteNumberFormat) == true)) &&
                ((this.QuoteNumberStart == null && other.QuoteNumberStart == null) || (this.QuoteNumberStart?.Equals(other.QuoteNumberStart) == true)) &&
                ((this.QuoteNumberIncrement == null && other.QuoteNumberIncrement == null) || (this.QuoteNumberIncrement?.Equals(other.QuoteNumberIncrement) == true)) &&
                ((this.QuoteNumberCurrent == null && other.QuoteNumberCurrent == null) || (this.QuoteNumberCurrent?.Equals(other.QuoteNumberCurrent) == true)) &&
                ((this.InvoiceNumberFormat == null && other.InvoiceNumberFormat == null) || (this.InvoiceNumberFormat?.Equals(other.InvoiceNumberFormat) == true)) &&
                ((this.InvoiceNumberStart == null && other.InvoiceNumberStart == null) || (this.InvoiceNumberStart?.Equals(other.InvoiceNumberStart) == true)) &&
                ((this.InvoiceNumberIncrement == null && other.InvoiceNumberIncrement == null) || (this.InvoiceNumberIncrement?.Equals(other.InvoiceNumberIncrement) == true)) &&
                ((this.InvoiceNumberCurrent == null && other.InvoiceNumberCurrent == null) || (this.InvoiceNumberCurrent?.Equals(other.InvoiceNumberCurrent) == true)) &&
                this.TaxRate.Equals(other.TaxRate) &&
                ((this.TaxFee == null && other.TaxFee == null) || (this.TaxFee?.Equals(other.TaxFee) == true)) &&
                ((this.MonthlyFee == null && other.MonthlyFee == null) || (this.MonthlyFee?.Equals(other.MonthlyFee) == true)) &&
                this.PerInvoiceFee.Equals(other.PerInvoiceFee) &&
                this.PerQuoteFee.Equals(other.PerQuoteFee) &&
                this.RequirePayInFull.Equals(other.RequirePayInFull) &&
                ((this.Selectable == null && other.Selectable == null) || (this.Selectable?.Equals(other.Selectable) == true)) &&
                ((this.Reportable == null && other.Reportable == null) || (this.Reportable?.Equals(other.Reportable) == true)) &&
                ((this.PortfolioId == null && other.PortfolioId == null) || (this.PortfolioId?.Equals(other.PortfolioId) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true)) &&
                ((this.ModifiedUserId == null && other.ModifiedUserId == null) || (this.ModifiedUserId?.Equals(other.ModifiedUserId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
            toStringOutput.Add($"this.QuoteNumberFormat = {(this.QuoteNumberFormat == null ? "null" : this.QuoteNumberFormat)}");
            toStringOutput.Add($"this.QuoteNumberStart = {(this.QuoteNumberStart == null ? "null" : this.QuoteNumberStart.ToString())}");
            toStringOutput.Add($"this.QuoteNumberIncrement = {(this.QuoteNumberIncrement == null ? "null" : this.QuoteNumberIncrement.ToString())}");
            toStringOutput.Add($"this.QuoteNumberCurrent = {(this.QuoteNumberCurrent == null ? "null" : this.QuoteNumberCurrent.ToString())}");
            toStringOutput.Add($"this.InvoiceNumberFormat = {(this.InvoiceNumberFormat == null ? "null" : this.InvoiceNumberFormat)}");
            toStringOutput.Add($"this.InvoiceNumberStart = {(this.InvoiceNumberStart == null ? "null" : this.InvoiceNumberStart.ToString())}");
            toStringOutput.Add($"this.InvoiceNumberIncrement = {(this.InvoiceNumberIncrement == null ? "null" : this.InvoiceNumberIncrement.ToString())}");
            toStringOutput.Add($"this.InvoiceNumberCurrent = {(this.InvoiceNumberCurrent == null ? "null" : this.InvoiceNumberCurrent.ToString())}");
            toStringOutput.Add($"this.TaxRate = {this.TaxRate}");
            toStringOutput.Add($"this.TaxFee = {(this.TaxFee == null ? "null" : this.TaxFee.ToString())}");
            toStringOutput.Add($"this.MonthlyFee = {(this.MonthlyFee == null ? "null" : this.MonthlyFee.ToString())}");
            toStringOutput.Add($"this.PerInvoiceFee = {this.PerInvoiceFee}");
            toStringOutput.Add($"this.PerQuoteFee = {this.PerQuoteFee}");
            toStringOutput.Add($"this.RequirePayInFull = {this.RequirePayInFull}");
            toStringOutput.Add($"this.Selectable = {(this.Selectable == null ? "null" : this.Selectable.ToString())}");
            toStringOutput.Add($"this.Reportable = {(this.Reportable == null ? "null" : this.Reportable.ToString())}");
            toStringOutput.Add($"this.PortfolioId = {(this.PortfolioId == null ? "null" : this.PortfolioId)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.ModifiedUserId = {(this.ModifiedUserId == null ? "null" : this.ModifiedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}