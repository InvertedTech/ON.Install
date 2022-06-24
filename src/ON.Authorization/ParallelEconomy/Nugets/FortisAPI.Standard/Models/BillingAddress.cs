// <copyright file="BillingAddress.cs" company="APIMatic">
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
    /// BillingAddress.
    /// </summary>
    public class BillingAddress
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BillingAddress"/> class.
        /// </summary>
        public BillingAddress()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BillingAddress"/> class.
        /// </summary>
        /// <param name="city">city.</param>
        /// <param name="state">state.</param>
        /// <param name="postalCode">postal_code.</param>
        /// <param name="street">street.</param>
        /// <param name="phone">phone.</param>
        public BillingAddress(
            string city = null,
            string state = null,
            string postalCode = null,
            string street = null,
            string phone = null)
        {
            this.City = city;
            this.State = state;
            this.PostalCode = postalCode;
            this.Street = street;
            this.Phone = phone;
        }

        /// <summary>
        /// The City portion of the address associated with the Credit Card (CC) or Bank Account (ACH).
        /// </summary>
        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        /// <summary>
        /// The State portion of the address associated with the Credit Card (CC) or Bank Account (ACH).
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        /// <summary>
        /// The Zip or 'Postal Code' portion of the address associated with the Credit Card (CC) or Bank Account (ACH).
        /// </summary>
        [JsonProperty("postal_code", NullValueHandling = NullValueHandling.Ignore)]
        public string PostalCode { get; set; }

        /// <summary>
        /// The Street portion of the address associated with the Credit Card (CC) or Bank Account (ACH).
        /// </summary>
        [JsonProperty("street", NullValueHandling = NullValueHandling.Ignore)]
        public string Street { get; set; }

        /// <summary>
        /// The Phone # to be used to contact Payer if there are any issues processing a transaction.
        /// </summary>
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BillingAddress : ({string.Join(", ", toStringOutput)})";
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

            return obj is BillingAddress other &&
                ((this.City == null && other.City == null) || (this.City?.Equals(other.City) == true)) &&
                ((this.State == null && other.State == null) || (this.State?.Equals(other.State) == true)) &&
                ((this.PostalCode == null && other.PostalCode == null) || (this.PostalCode?.Equals(other.PostalCode) == true)) &&
                ((this.Street == null && other.Street == null) || (this.Street?.Equals(other.Street) == true)) &&
                ((this.Phone == null && other.Phone == null) || (this.Phone?.Equals(other.Phone) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.City = {(this.City == null ? "null" : this.City == string.Empty ? "" : this.City)}");
            toStringOutput.Add($"this.State = {(this.State == null ? "null" : this.State == string.Empty ? "" : this.State)}");
            toStringOutput.Add($"this.PostalCode = {(this.PostalCode == null ? "null" : this.PostalCode == string.Empty ? "" : this.PostalCode)}");
            toStringOutput.Add($"this.Street = {(this.Street == null ? "null" : this.Street == string.Empty ? "" : this.Street)}");
            toStringOutput.Add($"this.Phone = {(this.Phone == null ? "null" : this.Phone == string.Empty ? "" : this.Phone)}");
        }
    }
}