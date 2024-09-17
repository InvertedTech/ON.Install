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
    using APIMatic.Core.Utilities.Converters;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// BillingAddress.
    /// </summary>
    public class BillingAddress : BaseModel
    {
        private string postalCode;
        private string street;
        private string city;
        private string state;
        private string phone;
        private string country;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "postal_code", false },
            { "street", false },
            { "city", false },
            { "state", false },
            { "phone", false },
            { "country", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="BillingAddress"/> class.
        /// </summary>
        public BillingAddress()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BillingAddress"/> class.
        /// </summary>
        /// <param name="postalCode">postal_code.</param>
        /// <param name="street">street.</param>
        /// <param name="city">city.</param>
        /// <param name="state">state.</param>
        /// <param name="phone">phone.</param>
        /// <param name="country">country.</param>
        public BillingAddress(
            string postalCode = null,
            string street = null,
            string city = null,
            string state = null,
            string phone = null,
            string country = null)
        {
            if (postalCode != null)
            {
                this.PostalCode = postalCode;
            }

            if (street != null)
            {
                this.Street = street;
            }

            if (city != null)
            {
                this.City = city;
            }

            if (state != null)
            {
                this.State = state;
            }

            if (phone != null)
            {
                this.Phone = phone;
            }

            if (country != null)
            {
                this.Country = country;
            }

        }

        /// <summary>
        /// The Zip or 'Postal Code' portion of the address associated with the Credit Card (CC) or Bank Account (ACH).
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
        /// The Street portion of the address associated with the Credit Card (CC) or Bank Account (ACH).
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

        /// <summary>
        /// The City portion of the address associated with the Credit Card (CC) or Bank Account (ACH).
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
        /// The State portion of the address associated with the Credit Card (CC) or Bank Account (ACH).
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
        /// The Phone # to be used to contact Payer if there are any issues processing a transaction.
        /// </summary>
        [JsonProperty("phone")]
        public string Phone
        {
            get
            {
                return this.phone;
            }

            set
            {
                this.shouldSerialize["phone"] = true;
                this.phone = value;
            }
        }

        /// <summary>
        /// The alpha 3 format country code.
        /// </summary>
        [JsonProperty("country")]
        public string Country
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BillingAddress : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetStreet()
        {
            this.shouldSerialize["street"] = false;
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
        public void UnsetPhone()
        {
            this.shouldSerialize["phone"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCountry()
        {
            this.shouldSerialize["country"] = false;
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
        public bool ShouldSerializeStreet()
        {
            return this.shouldSerialize["street"];
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
        public bool ShouldSerializePhone()
        {
            return this.shouldSerialize["phone"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCountry()
        {
            return this.shouldSerialize["country"];
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
            return obj is BillingAddress other &&                ((this.PostalCode == null && other.PostalCode == null) || (this.PostalCode?.Equals(other.PostalCode) == true)) &&
                ((this.Street == null && other.Street == null) || (this.Street?.Equals(other.Street) == true)) &&
                ((this.City == null && other.City == null) || (this.City?.Equals(other.City) == true)) &&
                ((this.State == null && other.State == null) || (this.State?.Equals(other.State) == true)) &&
                ((this.Phone == null && other.Phone == null) || (this.Phone?.Equals(other.Phone) == true)) &&
                ((this.Country == null && other.Country == null) || (this.Country?.Equals(other.Country) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PostalCode = {(this.PostalCode == null ? "null" : this.PostalCode)}");
            toStringOutput.Add($"this.Street = {(this.Street == null ? "null" : this.Street)}");
            toStringOutput.Add($"this.City = {(this.City == null ? "null" : this.City)}");
            toStringOutput.Add($"this.State = {(this.State == null ? "null" : this.State)}");
            toStringOutput.Add($"this.Phone = {(this.Phone == null ? "null" : this.Phone)}");
            toStringOutput.Add($"this.Country = {(this.Country == null ? "null" : this.Country)}");

            base.ToString(toStringOutput);
        }
    }
}