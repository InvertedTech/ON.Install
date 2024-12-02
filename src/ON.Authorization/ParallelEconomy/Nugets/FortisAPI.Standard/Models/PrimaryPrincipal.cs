// <copyright file="PrimaryPrincipal.cs" company="APIMatic">
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
    /// PrimaryPrincipal.
    /// </summary>
    public class PrimaryPrincipal : BaseModel
    {
        private string middleName;
        private string title;
        private string dateOfBirth;
        private string addressLine1;
        private string addressLine2;
        private string city;
        private string stateProvince;
        private string postalCode;
        private string ssn;
        private int? ownershipPercent;
        private string phoneNumber;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "middle_name", false },
            { "title", false },
            { "date_of_birth", false },
            { "address_line_1", false },
            { "address_line_2", false },
            { "city", false },
            { "state_province", false },
            { "postal_code", false },
            { "ssn", false },
            { "ownership_percent", false },
            { "phone_number", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="PrimaryPrincipal"/> class.
        /// </summary>
        public PrimaryPrincipal()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrimaryPrincipal"/> class.
        /// </summary>
        /// <param name="firstName">first_name.</param>
        /// <param name="lastName">last_name.</param>
        /// <param name="middleName">middle_name.</param>
        /// <param name="title">title.</param>
        /// <param name="dateOfBirth">date_of_birth.</param>
        /// <param name="addressLine1">address_line_1.</param>
        /// <param name="addressLine2">address_line_2.</param>
        /// <param name="city">city.</param>
        /// <param name="stateProvince">state_province.</param>
        /// <param name="postalCode">postal_code.</param>
        /// <param name="ssn">ssn.</param>
        /// <param name="ownershipPercent">ownership_percent.</param>
        /// <param name="phoneNumber">phone_number.</param>
        public PrimaryPrincipal(
            string firstName,
            string lastName,
            string middleName = null,
            string title = null,
            string dateOfBirth = null,
            string addressLine1 = null,
            string addressLine2 = null,
            string city = null,
            string stateProvince = null,
            string postalCode = null,
            string ssn = null,
            int? ownershipPercent = null,
            string phoneNumber = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            if (middleName != null)
            {
                this.MiddleName = middleName;
            }

            if (title != null)
            {
                this.Title = title;
            }

            if (dateOfBirth != null)
            {
                this.DateOfBirth = dateOfBirth;
            }

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

            if (ssn != null)
            {
                this.Ssn = ssn;
            }

            if (ownershipPercent != null)
            {
                this.OwnershipPercent = ownershipPercent;
            }

            if (phoneNumber != null)
            {
                this.PhoneNumber = phoneNumber;
            }

        }

        /// <summary>
        /// Signer's first name
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Signer's last name
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Signer's middle name
        /// </summary>
        [JsonProperty("middle_name")]
        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            set
            {
                this.shouldSerialize["middle_name"] = true;
                this.middleName = value;
            }
        }

        /// <summary>
        /// Signer's title
        /// </summary>
        [JsonProperty("title")]
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.shouldSerialize["title"] = true;
                this.title = value;
            }
        }

        /// <summary>
        /// Signer's date of birth
        /// </summary>
        [JsonProperty("date_of_birth")]
        public string DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }

            set
            {
                this.shouldSerialize["date_of_birth"] = true;
                this.dateOfBirth = value;
            }
        }

        /// <summary>
        /// Signer's residential address line 1
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
        /// Signer's residential address line 2
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
        /// Signer's city
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
        /// Signer's two-digit state code
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
        /// Signer's postal code
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
        /// Last four digits of the primary principal or Signer's social security number
        /// </summary>
        [JsonProperty("ssn")]
        public string Ssn
        {
            get
            {
                return this.ssn;
            }

            set
            {
                this.shouldSerialize["ssn"] = true;
                this.ssn = value;
            }
        }

        /// <summary>
        /// Percentage of business owned by primary principal or signer
        /// </summary>
        [JsonProperty("ownership_percent")]
        public int? OwnershipPercent
        {
            get
            {
                return this.ownershipPercent;
            }

            set
            {
                this.shouldSerialize["ownership_percent"] = true;
                this.ownershipPercent = value;
            }
        }

        /// <summary>
        /// Signer's phone number
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            set
            {
                this.shouldSerialize["phone_number"] = true;
                this.phoneNumber = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PrimaryPrincipal : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMiddleName()
        {
            this.shouldSerialize["middle_name"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTitle()
        {
            this.shouldSerialize["title"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDateOfBirth()
        {
            this.shouldSerialize["date_of_birth"] = false;
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
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSsn()
        {
            this.shouldSerialize["ssn"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetOwnershipPercent()
        {
            this.shouldSerialize["ownership_percent"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPhoneNumber()
        {
            this.shouldSerialize["phone_number"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMiddleName()
        {
            return this.shouldSerialize["middle_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTitle()
        {
            return this.shouldSerialize["title"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDateOfBirth()
        {
            return this.shouldSerialize["date_of_birth"];
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

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSsn()
        {
            return this.shouldSerialize["ssn"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOwnershipPercent()
        {
            return this.shouldSerialize["ownership_percent"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePhoneNumber()
        {
            return this.shouldSerialize["phone_number"];
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
            return obj is PrimaryPrincipal other &&                ((this.FirstName == null && other.FirstName == null) || (this.FirstName?.Equals(other.FirstName) == true)) &&
                ((this.LastName == null && other.LastName == null) || (this.LastName?.Equals(other.LastName) == true)) &&
                ((this.MiddleName == null && other.MiddleName == null) || (this.MiddleName?.Equals(other.MiddleName) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.DateOfBirth == null && other.DateOfBirth == null) || (this.DateOfBirth?.Equals(other.DateOfBirth) == true)) &&
                ((this.AddressLine1 == null && other.AddressLine1 == null) || (this.AddressLine1?.Equals(other.AddressLine1) == true)) &&
                ((this.AddressLine2 == null && other.AddressLine2 == null) || (this.AddressLine2?.Equals(other.AddressLine2) == true)) &&
                ((this.City == null && other.City == null) || (this.City?.Equals(other.City) == true)) &&
                ((this.StateProvince == null && other.StateProvince == null) || (this.StateProvince?.Equals(other.StateProvince) == true)) &&
                ((this.PostalCode == null && other.PostalCode == null) || (this.PostalCode?.Equals(other.PostalCode) == true)) &&
                ((this.Ssn == null && other.Ssn == null) || (this.Ssn?.Equals(other.Ssn) == true)) &&
                ((this.OwnershipPercent == null && other.OwnershipPercent == null) || (this.OwnershipPercent?.Equals(other.OwnershipPercent) == true)) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.FirstName = {(this.FirstName == null ? "null" : this.FirstName)}");
            toStringOutput.Add($"this.LastName = {(this.LastName == null ? "null" : this.LastName)}");
            toStringOutput.Add($"this.MiddleName = {(this.MiddleName == null ? "null" : this.MiddleName)}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
            toStringOutput.Add($"this.DateOfBirth = {(this.DateOfBirth == null ? "null" : this.DateOfBirth)}");
            toStringOutput.Add($"this.AddressLine1 = {(this.AddressLine1 == null ? "null" : this.AddressLine1)}");
            toStringOutput.Add($"this.AddressLine2 = {(this.AddressLine2 == null ? "null" : this.AddressLine2)}");
            toStringOutput.Add($"this.City = {(this.City == null ? "null" : this.City)}");
            toStringOutput.Add($"this.StateProvince = {(this.StateProvince == null ? "null" : this.StateProvince)}");
            toStringOutput.Add($"this.PostalCode = {(this.PostalCode == null ? "null" : this.PostalCode)}");
            toStringOutput.Add($"this.Ssn = {(this.Ssn == null ? "null" : this.Ssn)}");
            toStringOutput.Add($"this.OwnershipPercent = {(this.OwnershipPercent == null ? "null" : this.OwnershipPercent.ToString())}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber)}");

            base.ToString(toStringOutput);
        }
    }
}