// <copyright file="AltBankAccount.cs" company="APIMatic">
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
    /// AltBankAccount.
    /// </summary>
    public class AltBankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AltBankAccount"/> class.
        /// </summary>
        public AltBankAccount()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AltBankAccount"/> class.
        /// </summary>
        /// <param name="routingNumber">routing_number.</param>
        /// <param name="accountNumber">account_number.</param>
        /// <param name="accountHolderName">account_holder_name.</param>
        /// <param name="depositType">deposit_type.</param>
        public AltBankAccount(
            string routingNumber = null,
            string accountNumber = null,
            string accountHolderName = null,
            string depositType = null)
        {
            this.RoutingNumber = routingNumber;
            this.AccountNumber = accountNumber;
            this.AccountHolderName = accountHolderName;
            this.DepositType = depositType;
        }

        /// <summary>
        /// Nine-digit Bank routing number.
        /// </summary>
        [JsonProperty("routing_number", NullValueHandling = NullValueHandling.Ignore)]
        public string RoutingNumber { get; set; }

        /// <summary>
        /// Bank account number.
        /// </summary>
        [JsonProperty("account_number", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Name on bank account.
        /// </summary>
        [JsonProperty("account_holder_name", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountHolderName { get; set; }

        /// <summary>
        /// Deposit type.
        /// </summary>
        [JsonProperty("deposit_type", NullValueHandling = NullValueHandling.Ignore)]
        public string DepositType { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AltBankAccount : ({string.Join(", ", toStringOutput)})";
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

            return obj is AltBankAccount other &&
                ((this.RoutingNumber == null && other.RoutingNumber == null) || (this.RoutingNumber?.Equals(other.RoutingNumber) == true)) &&
                ((this.AccountNumber == null && other.AccountNumber == null) || (this.AccountNumber?.Equals(other.AccountNumber) == true)) &&
                ((this.AccountHolderName == null && other.AccountHolderName == null) || (this.AccountHolderName?.Equals(other.AccountHolderName) == true)) &&
                ((this.DepositType == null && other.DepositType == null) || (this.DepositType?.Equals(other.DepositType) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.RoutingNumber = {(this.RoutingNumber == null ? "null" : this.RoutingNumber == string.Empty ? "" : this.RoutingNumber)}");
            toStringOutput.Add($"this.AccountNumber = {(this.AccountNumber == null ? "null" : this.AccountNumber == string.Empty ? "" : this.AccountNumber)}");
            toStringOutput.Add($"this.AccountHolderName = {(this.AccountHolderName == null ? "null" : this.AccountHolderName == string.Empty ? "" : this.AccountHolderName)}");
            toStringOutput.Add($"this.DepositType = {(this.DepositType == null ? "null" : this.DepositType == string.Empty ? "" : this.DepositType)}");
        }
    }
}