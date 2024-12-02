// <copyright file="Address22.cs" company="APIMatic">
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
    /// Address22.
    /// </summary>
    public class Address22 : BaseModel
    {
        private string addressLine2;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "address_line_2", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Address22"/> class.
        /// </summary>
        public Address22()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address22"/> class.
        /// </summary>
        /// <param name="addressLine1">address_line_1.</param>
        /// <param name="city">city.</param>
        /// <param name="stateProvince">state_province.</param>
        /// <param name="postalCode">postal_code.</param>
        /// <param name="countryCode">country_code.</param>
        /// <param name="addressType">address_type.</param>
        /// <param name="addressLine2">address_line_2.</param>
        public Address22(
            string addressLine1,
            string city,
            string stateProvince,
            string postalCode,
            string countryCode,
            Models.AddressTypeEnum addressType,
            string addressLine2 = null)
        {
            this.AddressLine1 = addressLine1;
            if (addressLine2 != null)
            {
                this.AddressLine2 = addressLine2;
            }

            this.City = city;
            this.StateProvince = stateProvince;
            this.PostalCode = postalCode;
            this.CountryCode = countryCode;
            this.AddressType = addressType;
        }

        /// <summary>
        /// Line 1 of address.
        /// </summary>
        [JsonProperty("address_line_1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Line 2 of address.
        /// </summary>
        [JsonProperty("address_line_2")]
        public string AddressLine2
        {
            get
            {
                return this.addressLine2;
            }

            set
            {
                this.shouldSerialize["address_line_2"] = true;
                this.addressLine2 = value;
            }
        }

        /// <summary>
        /// City of address.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// State or province of address.
        /// </summary>
        [JsonProperty("state_province")]
        public string StateProvince { get; set; }

        /// <summary>
        /// Postal code of address.
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Country of address.
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Address type of address.
        /// </summary>
        [JsonProperty("address_type")]
        public Models.AddressTypeEnum AddressType { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Address22 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAddressLine2()
        {
            this.shouldSerialize["address_line_2"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAddressLine2()
        {
            return this.shouldSerialize["address_line_2"];
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
            return obj is Address22 other &&                ((this.AddressLine1 == null && other.AddressLine1 == null) || (this.AddressLine1?.Equals(other.AddressLine1) == true)) &&
                ((this.AddressLine2 == null && other.AddressLine2 == null) || (this.AddressLine2?.Equals(other.AddressLine2) == true)) &&
                ((this.City == null && other.City == null) || (this.City?.Equals(other.City) == true)) &&
                ((this.StateProvince == null && other.StateProvince == null) || (this.StateProvince?.Equals(other.StateProvince) == true)) &&
                ((this.PostalCode == null && other.PostalCode == null) || (this.PostalCode?.Equals(other.PostalCode) == true)) &&
                ((this.CountryCode == null && other.CountryCode == null) || (this.CountryCode?.Equals(other.CountryCode) == true)) &&
                this.AddressType.Equals(other.AddressType);
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AddressLine1 = {(this.AddressLine1 == null ? "null" : this.AddressLine1)}");
            toStringOutput.Add($"this.AddressLine2 = {(this.AddressLine2 == null ? "null" : this.AddressLine2)}");
            toStringOutput.Add($"this.City = {(this.City == null ? "null" : this.City)}");
            toStringOutput.Add($"this.StateProvince = {(this.StateProvince == null ? "null" : this.StateProvince)}");
            toStringOutput.Add($"this.PostalCode = {(this.PostalCode == null ? "null" : this.PostalCode)}");
            toStringOutput.Add($"this.CountryCode = {(this.CountryCode == null ? "null" : this.CountryCode)}");
            toStringOutput.Add($"this.AddressType = {this.AddressType}");

            base.ToString(toStringOutput);
        }
    }
}