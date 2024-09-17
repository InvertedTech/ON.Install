// <copyright file="BankAccount1.cs" company="APIMatic">
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
    /// BankAccount1.
    /// </summary>
    public class BankAccount1 : BaseModel
    {
        private string routingNumber;
        private string accountNumber;
        private string accountHolderName;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "routing_number", false },
            { "account_number", false },
            { "account_holder_name", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount1"/> class.
        /// </summary>
        public BankAccount1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount1"/> class.
        /// </summary>
        /// <param name="routingNumber">routing_number.</param>
        /// <param name="accountNumber">account_number.</param>
        /// <param name="accountHolderName">account_holder_name.</param>
        public BankAccount1(
            string routingNumber = null,
            string accountNumber = null,
            string accountHolderName = null)
        {
            if (routingNumber != null)
            {
                this.RoutingNumber = routingNumber;
            }

            if (accountNumber != null)
            {
                this.AccountNumber = accountNumber;
            }

            if (accountHolderName != null)
            {
                this.AccountHolderName = accountHolderName;
            }

        }

        /// <summary>
        /// Nine-digit Bank routing number.
        /// </summary>
        [JsonProperty("routing_number")]
        public string RoutingNumber
        {
            get
            {
                return this.routingNumber;
            }

            set
            {
                this.shouldSerialize["routing_number"] = true;
                this.routingNumber = value;
            }
        }

        /// <summary>
        /// Bank account number.
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber
        {
            get
            {
                return this.accountNumber;
            }

            set
            {
                this.shouldSerialize["account_number"] = true;
                this.accountNumber = value;
            }
        }

        /// <summary>
        /// Name on bank account.
        /// </summary>
        [JsonProperty("account_holder_name")]
        public string AccountHolderName
        {
            get
            {
                return this.accountHolderName;
            }

            set
            {
                this.shouldSerialize["account_holder_name"] = true;
                this.accountHolderName = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BankAccount1 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRoutingNumber()
        {
            this.shouldSerialize["routing_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAccountNumber()
        {
            this.shouldSerialize["account_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAccountHolderName()
        {
            this.shouldSerialize["account_holder_name"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRoutingNumber()
        {
            return this.shouldSerialize["routing_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountNumber()
        {
            return this.shouldSerialize["account_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountHolderName()
        {
            return this.shouldSerialize["account_holder_name"];
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
            return obj is BankAccount1 other &&                ((this.RoutingNumber == null && other.RoutingNumber == null) || (this.RoutingNumber?.Equals(other.RoutingNumber) == true)) &&
                ((this.AccountNumber == null && other.AccountNumber == null) || (this.AccountNumber?.Equals(other.AccountNumber) == true)) &&
                ((this.AccountHolderName == null && other.AccountHolderName == null) || (this.AccountHolderName?.Equals(other.AccountHolderName) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.RoutingNumber = {(this.RoutingNumber == null ? "null" : this.RoutingNumber)}");
            toStringOutput.Add($"this.AccountNumber = {(this.AccountNumber == null ? "null" : this.AccountNumber)}");
            toStringOutput.Add($"this.AccountHolderName = {(this.AccountHolderName == null ? "null" : this.AccountHolderName)}");

            base.ToString(toStringOutput);
        }
    }
}