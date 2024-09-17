// <copyright file="Address.cs" company="APIMatic">
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
    /// Address.
    /// </summary>
    public class Address : BaseModel
    {
        private string city;
        private string state;
        private string postalCode;
        private Models.CountryEnum? country;
        private string street;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "city", false },
            { "state", false },
            { "postal_code", false },
            { "country", false },
            { "street", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        public Address()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="city">city.</param>
        /// <param name="state">state.</param>
        /// <param name="postalCode">postal_code.</param>
        /// <param name="country">country.</param>
        /// <param name="street">street.</param>
        public Address(
            string city = null,
            string state = null,
            string postalCode = null,
            Models.CountryEnum? country = null,
            string street = null)
        {
            if (city != null)
            {
                this.City = city;
            }

            if (state != null)
            {
                this.State = state;
            }

            if (postalCode != null)
            {
                this.PostalCode = postalCode;
            }

            if (country != null)
            {
                this.Country = country;
            }

            if (street != null)
            {
                this.Street = street;
            }

        }

        /// <summary>
        /// City of contact
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
        /// State of contact
        /// </summary>
        [JsonProperty("state")]
        public string State
        {
            get
            {
                return this.state;
            }

            set
            {
                this.shouldSerialize["state"] = true;
                this.state = value;
            }
        }

        /// <summary>
        /// Postal code of contact
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
        /// An alpha 2 format country code of US or CA.
        /// </summary>
        [JsonProperty("country")]
        public Models.CountryEnum? Country
        {
            get
            {
                return this.country;
            }

            set
            {
                this.shouldSerialize["country"] = true;
                this.country = value;
            }
        }

        /// <summary>
        /// Street of contact
        /// </summary>
        [JsonProperty("street")]
        public string Street
        {
            get
            {
                return this.street;
            }

            set
            {
                this.shouldSerialize["street"] = true;
                this.street = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Address : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetState()
        {
            this.shouldSerialize["state"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPostalCode()
        {
            this.shouldSerialize["postal_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCountry()
        {
            this.shouldSerialize["country"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetStreet()
        {
            this.shouldSerialize["street"] = false;
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
        public bool ShouldSerializeState()
        {
            return this.shouldSerialize["state"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePostalCode()
        {
            return this.shouldSerialize["postal_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCountry()
        {
            return this.shouldSerialize["country"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStreet()
        {
            return this.shouldSerialize["street"];
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
            return obj is Address other &&                ((this.City == null && other.City == null) || (this.City?.Equals(other.City) == true)) &&
                ((this.State == null && other.State == null) || (this.State?.Equals(other.State) == true)) &&
                ((this.PostalCode == null && other.PostalCode == null) || (this.PostalCode?.Equals(other.PostalCode) == true)) &&
                ((this.Country == null && other.Country == null) || (this.Country?.Equals(other.Country) == true)) &&
                ((this.Street == null && other.Street == null) || (this.Street?.Equals(other.Street) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.City = {(this.City == null ? "null" : this.City)}");
            toStringOutput.Add($"this.State = {(this.State == null ? "null" : this.State)}");
            toStringOutput.Add($"this.PostalCode = {(this.PostalCode == null ? "null" : this.PostalCode)}");
            toStringOutput.Add($"this.Country = {(this.Country == null ? "null" : this.Country.ToString())}");
            toStringOutput.Add($"this.Street = {(this.Street == null ? "null" : this.Street)}");

            base.ToString(toStringOutput);
        }
    }
}