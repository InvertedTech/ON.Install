// <copyright file="BillingAddress5.cs" company="APIMatic">
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
    /// BillingAddress5.
    /// </summary>
    public class BillingAddress5 : BaseModel
    {
        private string postalCode;
        private string street;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "postal_code", false },
            { "street", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="BillingAddress5"/> class.
        /// </summary>
        public BillingAddress5()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BillingAddress5"/> class.
        /// </summary>
        /// <param name="postalCode">postal_code.</param>
        /// <param name="street">street.</param>
        public BillingAddress5(
            string postalCode = null,
            string street = null)
        {
            if (postalCode != null)
            {
                this.PostalCode = postalCode;
            }

            if (street != null)
            {
                this.Street = street;
            }

        }

        /// <summary>
        /// The Zip or 'Postal Code' portion of the address associated with the Credit Card.
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
        /// The Street portion of the address associated with the Credit Card.
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

            return $"BillingAddress5 : ({string.Join(", ", toStringOutput)})";
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
            return obj is BillingAddress5 other &&                ((this.PostalCode == null && other.PostalCode == null) || (this.PostalCode?.Equals(other.PostalCode) == true)) &&
                ((this.Street == null && other.Street == null) || (this.Street?.Equals(other.Street) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PostalCode = {(this.PostalCode == null ? "null" : this.PostalCode)}");
            toStringOutput.Add($"this.Street = {(this.Street == null ? "null" : this.Street)}");

            base.ToString(toStringOutput);
        }
    }
}