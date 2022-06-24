// <copyright file="AdditionalAmount.cs" company="APIMatic">
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
    /// AdditionalAmount.
    /// </summary>
    public class AdditionalAmount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionalAmount"/> class.
        /// </summary>
        public AdditionalAmount()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionalAmount"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="amount">amount.</param>
        /// <param name="accountType">account_type.</param>
        /// <param name="currency">currency.</param>
        public AdditionalAmount(
            Models.Type1Enum? type = null,
            string amount = null,
            Models.AccountTypeEnum? accountType = null,
            double? currency = null)
        {
            this.Type = type;
            this.Amount = amount;
            this.AccountType = accountType;
            this.Currency = currency;
        }

        /// <summary>
        /// type of the amount [4S-Healthcare(Visa and MC Only), 4U-Prescription/Rx(Visa and MC Only), 4V-Vision/Optical(Visa Only), 4W-clinic/other qualified medical(Visa Only) ,4X-Dental(Visa Only)].
        /// </summary>
        [JsonProperty("type", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.Type1Enum? Type { get; set; }

        /// <summary>
        /// The amount of additional amount.
        /// </summary>
        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public string Amount { get; set; }

        /// <summary>
        /// Account Type
        /// </summary>
        [JsonProperty("account_type", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.AccountTypeEnum? AccountType { get; set; }

        /// <summary>
        /// Currency Code
        /// </summary>
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public double? Currency { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AdditionalAmount : ({string.Join(", ", toStringOutput)})";
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

            return obj is AdditionalAmount other &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Amount == null && other.Amount == null) || (this.Amount?.Equals(other.Amount) == true)) &&
                ((this.AccountType == null && other.AccountType == null) || (this.AccountType?.Equals(other.AccountType) == true)) &&
                ((this.Currency == null && other.Currency == null) || (this.Currency?.Equals(other.Currency) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.Amount = {(this.Amount == null ? "null" : this.Amount == string.Empty ? "" : this.Amount)}");
            toStringOutput.Add($"this.AccountType = {(this.AccountType == null ? "null" : this.AccountType.ToString())}");
            toStringOutput.Add($"this.Currency = {(this.Currency == null ? "null" : this.Currency.ToString())}");
        }
    }
}