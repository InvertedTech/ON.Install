// <copyright file="Location5.cs" company="APIMatic">
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
    /// Location5.
    /// </summary>
    public class Location5 : BaseModel
    {
        private string addressLine1;
        private string addressLine2;
        private string city;
        private string stateProvince;
        private string postalCode;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "address_line_1", false },
            { "address_line_2", false },
            { "city", false },
            { "state_province", false },
            { "postal_code", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Location5"/> class.
        /// </summary>
        public Location5()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location5"/> class.
        /// </summary>
        /// <param name="phoneNumber">phone_number.</param>
        /// <param name="addressLine1">address_line_1.</param>
        /// <param name="addressLine2">address_line_2.</param>
        /// <param name="city">city.</param>
        /// <param name="stateProvince">state_province.</param>
        /// <param name="postalCode">postal_code.</param>
        public Location5(
            string phoneNumber,
            string addressLine1 = null,
            string addressLine2 = null,
            string city = null,
            string stateProvince = null,
            string postalCode = null)
        {
            if (addressLine1 != null)
            {
                this.AddressLine1 = addressLine1;
            }

            if (addressLine2 != null)
            {
                this.AddressLine2 = addressLine2;
            }

            if (city != null)
            {
                this.City = city;
            }

            if (stateProvince != null)
            {
                this.StateProvince = stateProvince;
            }

            if (postalCode != null)
            {
                this.PostalCode = postalCode;
            }

            this.PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Merchant's business address line 1.
        /// </summary>
        [JsonProperty("address_line_1")]
        public string AddressLine1
        {
            get
            {
                return this.addressLine1;
            }

            set
            {
                this.shouldSerialize["address_line_1"] = true;
                this.addressLine1 = value;
            }
        }

        /// <summary>
        /// Merchant's business address line 2.
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
        /// Merchant's business city.
        /// </summary>
        [JsonProperty("city")]
        public string City
        {
            get
            {
                return this.city;
            }

            set
            {
                this.shouldSerialize["city"] = true;
                this.city = value;
            }
        }

        /// <summary>
        /// Merchant's business two-digit state or province code.
        /// </summary>
        [JsonProperty("state_province")]
        public string StateProvince
        {
            get
            {
                return this.stateProvince;
            }

            set
            {
                this.shouldSerialize["state_province"] = true;
                this.stateProvince = value;
            }
        }

        /// <summary>
        /// Merchant's business postal code.
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode
        {
            get
            {
                return this.postalCode;
            }

            set
            {
                this.shouldSerialize["postal_code"] = true;
                this.postalCode = value;
            }
        }

        /// <summary>
        /// Merchant's business phone number.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Location5 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAddressLine1()
        {
            this.shouldSerialize["address_line_1"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAddressLine2()
        {
            this.shouldSerialize["address_line_2"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCity()
        {
            this.shouldSerialize["city"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetStateProvince()
        {
            this.shouldSerialize["state_province"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPostalCode()
        {
            this.shouldSerialize["postal_code"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAddressLine1()
        {
            return this.shouldSerialize["address_line_1"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAddressLine2()
        {
            return this.shouldSerialize["address_line_2"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCity()
        {
            return this.shouldSerialize["city"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStateProvince()
        {
            return this.shouldSerialize["state_province"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePostalCode()
        {
            return this.shouldSerialize["postal_code"];
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
            return obj is Location5 other &&                ((this.AddressLine1 == null && other.AddressLine1 == null) || (this.AddressLine1?.Equals(other.AddressLine1) == true)) &&
                ((this.AddressLine2 == null && other.AddressLine2 == null) || (this.AddressLine2?.Equals(other.AddressLine2) == true)) &&
                ((this.City == null && other.City == null) || (this.City?.Equals(other.City) == true)) &&
                ((this.StateProvince == null && other.StateProvince == null) || (this.StateProvince?.Equals(other.StateProvince) == true)) &&
                ((this.PostalCode == null && other.PostalCode == null) || (this.PostalCode?.Equals(other.PostalCode) == true)) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true));
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
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber)}");

            base.ToString(toStringOutput);
        }
    }
}