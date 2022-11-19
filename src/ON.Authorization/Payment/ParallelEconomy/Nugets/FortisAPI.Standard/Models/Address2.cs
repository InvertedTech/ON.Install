// <copyright file="Address2.cs" company="APIMatic">
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
    /// Address2.
    /// </summary>
    public class Address2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Address2"/> class.
        /// </summary>
        public Address2()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address2"/> class.
        /// </summary>
        /// <param name="city">city.</param>
        /// <param name="state">state.</param>
        /// <param name="postalCode">postal_code.</param>
        /// <param name="country">country.</param>
        /// <param name="street">street.</param>
        /// <param name="street2">street2.</param>
        public Address2(
            string city = null,
            string state = null,
            string postalCode = null,
            Models.Country2Enum? country = null,
            string street = null,
            string street2 = null)
        {
            this.City = city;
            this.State = state;
            this.PostalCode = postalCode;
            this.Country = country;
            this.Street = street;
            this.Street2 = street2;
        }

        /// <summary>
        /// City name
        /// </summary>
        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        /// <summary>
        /// State name
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        /// <summary>
        /// Postal code
        /// </summary>
        [JsonProperty("postal_code", NullValueHandling = NullValueHandling.Ignore)]
        public string PostalCode { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [JsonProperty("country", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.Country2Enum? Country { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        [JsonProperty("street", NullValueHandling = NullValueHandling.Ignore)]
        public string Street { get; set; }

        /// <summary>
        /// Street 2
        /// </summary>
        [JsonProperty("street2", NullValueHandling = NullValueHandling.Ignore)]
        public string Street2 { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Address2 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Address2 other &&
                ((this.City == null && other.City == null) || (this.City?.Equals(other.City) == true)) &&
                ((this.State == null && other.State == null) || (this.State?.Equals(other.State) == true)) &&
                ((this.PostalCode == null && other.PostalCode == null) || (this.PostalCode?.Equals(other.PostalCode) == true)) &&
                ((this.Country == null && other.Country == null) || (this.Country?.Equals(other.Country) == true)) &&
                ((this.Street == null && other.Street == null) || (this.Street?.Equals(other.Street) == true)) &&
                ((this.Street2 == null && other.Street2 == null) || (this.Street2?.Equals(other.Street2) == true));
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
            toStringOutput.Add($"this.Country = {(this.Country == null ? "null" : this.Country.ToString())}");
            toStringOutput.Add($"this.Street = {(this.Street == null ? "null" : this.Street == string.Empty ? "" : this.Street)}");
            toStringOutput.Add($"this.Street2 = {(this.Street2 == null ? "null" : this.Street2 == string.Empty ? "" : this.Street2)}");
        }
    }
}