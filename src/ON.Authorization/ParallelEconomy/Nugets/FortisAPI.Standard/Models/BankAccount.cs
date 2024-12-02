// <copyright file="BankAccount.cs" company="APIMatic">
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
    /// BankAccount.
    /// </summary>
    public class BankAccount : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        public BankAccount()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="accountHolderName">account_holder_name.</param>
        /// <param name="routingNumber">routing_number.</param>
        /// <param name="accountNumber">account_number.</param>
        /// <param name="accountType">account_type.</param>
        /// <param name="isPrimary">is_primary.</param>
        /// <param name="altDepositTypes">alt_deposit_types.</param>
        public BankAccount(
            string accountHolderName,
            string routingNumber,
            string accountNumber,
            Models.AccountTypeEnum accountType,
            bool? isPrimary = null,
            List<string> altDepositTypes = null)
        {
            this.AccountHolderName = accountHolderName;
            this.RoutingNumber = routingNumber;
            this.AccountNumber = accountNumber;
            this.IsPrimary = isPrimary;
            this.AccountType = accountType;
            this.AltDepositTypes = altDepositTypes;
        }

        /// <summary>
        /// Account holder name.
        /// </summary>
        [JsonProperty("account_holder_name")]
        public string AccountHolderName { get; set; }

        /// <summary>
        /// Nine-digit Bank routing number.
        /// </summary>
        [JsonProperty("routing_number")]
        public string RoutingNumber { get; set; }

        /// <summary>
        /// Account number.
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Flag indicating whether or not the account is the primary account. Only one account can be marked as primary.
        /// </summary>
        [JsonProperty("is_primary", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPrimary { get; set; }

        /// <summary>
        /// Account type. Either "checking" or "savings"
        /// </summary>
        [JsonProperty("account_type")]
        public Models.AccountTypeEnum AccountType { get; set; }

        /// <summary>
        /// Array of deposit types. ('fees', 'adjustments', 'returns')
        /// </summary>
        [JsonProperty("alt_deposit_types", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> AltDepositTypes { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BankAccount : ({string.Join(", ", toStringOutput)})";
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
            return obj is BankAccount other &&                ((this.AccountHolderName == null && other.AccountHolderName == null) || (this.AccountHolderName?.Equals(other.AccountHolderName) == true)) &&
                ((this.RoutingNumber == null && other.RoutingNumber == null) || (this.RoutingNumber?.Equals(other.RoutingNumber) == true)) &&
                ((this.AccountNumber == null && other.AccountNumber == null) || (this.AccountNumber?.Equals(other.AccountNumber) == true)) &&
                ((this.IsPrimary == null && other.IsPrimary == null) || (this.IsPrimary?.Equals(other.IsPrimary) == true)) &&
                this.AccountType.Equals(other.AccountType) &&
                ((this.AltDepositTypes == null && other.AltDepositTypes == null) || (this.AltDepositTypes?.Equals(other.AltDepositTypes) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AccountHolderName = {(this.AccountHolderName == null ? "null" : this.AccountHolderName)}");
            toStringOutput.Add($"this.RoutingNumber = {(this.RoutingNumber == null ? "null" : this.RoutingNumber)}");
            toStringOutput.Add($"this.AccountNumber = {(this.AccountNumber == null ? "null" : this.AccountNumber)}");
            toStringOutput.Add($"this.IsPrimary = {(this.IsPrimary == null ? "null" : this.IsPrimary.ToString())}");
            toStringOutput.Add($"this.AccountType = {this.AccountType}");
            toStringOutput.Add($"this.AltDepositTypes = {(this.AltDepositTypes == null ? "null" : $"[{string.Join(", ", this.AltDepositTypes)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}