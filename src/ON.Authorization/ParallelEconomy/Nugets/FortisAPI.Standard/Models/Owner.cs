// <copyright file="Owner.cs" company="APIMatic">
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
    /// Owner.
    /// </summary>
    public class Owner : BaseModel
    {
        private string middleName;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "middle_name", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Owner"/> class.
        /// </summary>
        public Owner()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Owner"/> class.
        /// </summary>
        /// <param name="firstName">first_name.</param>
        /// <param name="lastName">last_name.</param>
        /// <param name="title">title.</param>
        /// <param name="dateOfBirth">date_of_birth.</param>
        /// <param name="addressLine1">address_line_1.</param>
        /// <param name="addressLine2">address_line_2.</param>
        /// <param name="city">city.</param>
        /// <param name="stateProvince">state_province.</param>
        /// <param name="postalCode">postal_code.</param>
        /// <param name="countryCode">country_code.</param>
        /// <param name="ssn">ssn.</param>
        /// <param name="ownershipPercent">ownership_percent.</param>
        /// <param name="phoneNumber">phone_number.</param>
        /// <param name="emailAddress">email_address.</param>
        /// <param name="isController">is_controller.</param>
        /// <param name="isSigner">is_signer.</param>
        /// <param name="middleName">middle_name.</param>
        public Owner(
            string firstName,
            string lastName,
            string title,
            string dateOfBirth,
            string addressLine1,
            string addressLine2,
            string city,
            string stateProvince,
            string postalCode,
            string countryCode,
            string ssn,
            int ownershipPercent,
            string phoneNumber,
            string emailAddress,
            bool isController,
            bool isSigner,
            string middleName = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            if (middleName != null)
            {
                this.MiddleName = middleName;
            }

            this.Title = title;
            this.DateOfBirth = dateOfBirth;
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.City = city;
            this.StateProvince = stateProvince;
            this.PostalCode = postalCode;
            this.CountryCode = countryCode;
            this.Ssn = ssn;
            this.OwnershipPercent = ownershipPercent;
            this.PhoneNumber = phoneNumber;
            this.EmailAddress = emailAddress;
            this.IsController = isController;
            this.IsSigner = isSigner;
        }

        /// <summary>
        /// Owner's first name.
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Owner's last name.
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Owner's middle name.
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
        /// Owner's title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Owner's date of birth.
        /// </summary>
        [JsonProperty("date_of_birth")]
        public string DateOfBirth { get; set; }

        /// <summary>
        /// Owner's street address.
        /// </summary>
        [JsonProperty("address_line_1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Line 2 of owner's address.
        /// </summary>
        [JsonProperty("address_line_2")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Owner's address city.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Owner's address state/province.
        /// </summary>
        [JsonProperty("state_province")]
        public string StateProvince { get; set; }

        /// <summary>
        /// Owner's address postal code.
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Owner's address country.
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Owner's full SSN.
        /// </summary>
        [JsonProperty("ssn")]
        public string Ssn { get; set; }

        /// <summary>
        /// Owner's ownership percent.
        /// </summary>
        [JsonProperty("ownership_percent")]
        public int OwnershipPercent { get; set; }

        /// <summary>
        /// Owner's phone number.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Owner's email address.
        /// </summary>
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Flag indicating whether this owner is the control owner. Maximum of 1 owner can be marked as control..
        /// </summary>
        [JsonProperty("is_controller")]
        public bool IsController { get; set; }

        /// <summary>
        /// Flag indicating whether or not the owner is a signer for the business. Maximum of 1 owner can be marked as signer.
        /// </summary>
        [JsonProperty("is_signer")]
        public bool IsSigner { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Owner : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMiddleName()
        {
            this.shouldSerialize["middle_name"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMiddleName()
        {
            return this.shouldSerialize["middle_name"];
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
            return obj is Owner other &&                ((this.FirstName == null && other.FirstName == null) || (this.FirstName?.Equals(other.FirstName) == true)) &&
                ((this.LastName == null && other.LastName == null) || (this.LastName?.Equals(other.LastName) == true)) &&
                ((this.MiddleName == null && other.MiddleName == null) || (this.MiddleName?.Equals(other.MiddleName) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.DateOfBirth == null && other.DateOfBirth == null) || (this.DateOfBirth?.Equals(other.DateOfBirth) == true)) &&
                ((this.AddressLine1 == null && other.AddressLine1 == null) || (this.AddressLine1?.Equals(other.AddressLine1) == true)) &&
                ((this.AddressLine2 == null && other.AddressLine2 == null) || (this.AddressLine2?.Equals(other.AddressLine2) == true)) &&
                ((this.City == null && other.City == null) || (this.City?.Equals(other.City) == true)) &&
                ((this.StateProvince == null && other.StateProvince == null) || (this.StateProvince?.Equals(other.StateProvince) == true)) &&
                ((this.PostalCode == null && other.PostalCode == null) || (this.PostalCode?.Equals(other.PostalCode) == true)) &&
                ((this.CountryCode == null && other.CountryCode == null) || (this.CountryCode?.Equals(other.CountryCode) == true)) &&
                ((this.Ssn == null && other.Ssn == null) || (this.Ssn?.Equals(other.Ssn) == true)) &&
                this.OwnershipPercent.Equals(other.OwnershipPercent) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((this.EmailAddress == null && other.EmailAddress == null) || (this.EmailAddress?.Equals(other.EmailAddress) == true)) &&
                this.IsController.Equals(other.IsController) &&
                this.IsSigner.Equals(other.IsSigner);
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
            toStringOutput.Add($"this.CountryCode = {(this.CountryCode == null ? "null" : this.CountryCode)}");
            toStringOutput.Add($"this.Ssn = {(this.Ssn == null ? "null" : this.Ssn)}");
            toStringOutput.Add($"this.OwnershipPercent = {this.OwnershipPercent}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber)}");
            toStringOutput.Add($"this.EmailAddress = {(this.EmailAddress == null ? "null" : this.EmailAddress)}");
            toStringOutput.Add($"this.IsController = {this.IsController}");
            toStringOutput.Add($"this.IsSigner = {this.IsSigner}");

            base.ToString(toStringOutput);
        }
    }
}