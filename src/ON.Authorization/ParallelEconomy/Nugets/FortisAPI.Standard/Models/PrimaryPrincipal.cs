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
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// PrimaryPrincipal.
    /// </summary>
    public class PrimaryPrincipal
    {
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
            this.MiddleName = middleName;
            this.Title = title;
            this.DateOfBirth = dateOfBirth;
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.City = city;
            this.StateProvince = stateProvince;
            this.PostalCode = postalCode;
            this.Ssn = ssn;
            this.OwnershipPercent = ownershipPercent;
            this.PhoneNumber = phoneNumber;
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
        [JsonProperty("middle_name", NullValueHandling = NullValueHandling.Ignore)]
        public string MiddleName { get; set; }

        /// <summary>
        /// Signer's title
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// Signer's date of birth
        /// </summary>
        [JsonProperty("date_of_birth", NullValueHandling = NullValueHandling.Ignore)]
        public string DateOfBirth { get; set; }

        /// <summary>
        /// Signer's residential address line 1
        /// </summary>
        [JsonProperty("address_line_1", NullValueHandling = NullValueHandling.Ignore)]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Signer's residential address line 2
        /// </summary>
        [JsonProperty("address_line_2", NullValueHandling = NullValueHandling.Ignore)]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Signer's city
        /// </summary>
        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        /// <summary>
        /// Signer's two-digit state code
        /// </summary>
        [JsonProperty("state_province", NullValueHandling = NullValueHandling.Ignore)]
        public string StateProvince { get; set; }

        /// <summary>
        /// Signer's postal code
        /// </summary>
        [JsonProperty("postal_code", NullValueHandling = NullValueHandling.Ignore)]
        public string PostalCode { get; set; }

        /// <summary>
        /// Last four digits of the primary principal or Signer's social security number
        /// </summary>
        [JsonProperty("ssn", NullValueHandling = NullValueHandling.Ignore)]
        public string Ssn { get; set; }

        /// <summary>
        /// Percentage of business owned by primary principal or signer
        /// </summary>
        [JsonProperty("ownership_percent", NullValueHandling = NullValueHandling.Ignore)]
        public int? OwnershipPercent { get; set; }

        /// <summary>
        /// Signer's phone number
        /// </summary>
        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PrimaryPrincipal : ({string.Join(", ", toStringOutput)})";
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

            return obj is PrimaryPrincipal other &&
                ((this.FirstName == null && other.FirstName == null) || (this.FirstName?.Equals(other.FirstName) == true)) &&
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
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.FirstName = {(this.FirstName == null ? "null" : this.FirstName == string.Empty ? "" : this.FirstName)}");
            toStringOutput.Add($"this.LastName = {(this.LastName == null ? "null" : this.LastName == string.Empty ? "" : this.LastName)}");
            toStringOutput.Add($"this.MiddleName = {(this.MiddleName == null ? "null" : this.MiddleName == string.Empty ? "" : this.MiddleName)}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title == string.Empty ? "" : this.Title)}");
            toStringOutput.Add($"this.DateOfBirth = {(this.DateOfBirth == null ? "null" : this.DateOfBirth == string.Empty ? "" : this.DateOfBirth)}");
            toStringOutput.Add($"this.AddressLine1 = {(this.AddressLine1 == null ? "null" : this.AddressLine1 == string.Empty ? "" : this.AddressLine1)}");
            toStringOutput.Add($"this.AddressLine2 = {(this.AddressLine2 == null ? "null" : this.AddressLine2 == string.Empty ? "" : this.AddressLine2)}");
            toStringOutput.Add($"this.City = {(this.City == null ? "null" : this.City == string.Empty ? "" : this.City)}");
            toStringOutput.Add($"this.StateProvince = {(this.StateProvince == null ? "null" : this.StateProvince == string.Empty ? "" : this.StateProvince)}");
            toStringOutput.Add($"this.PostalCode = {(this.PostalCode == null ? "null" : this.PostalCode == string.Empty ? "" : this.PostalCode)}");
            toStringOutput.Add($"this.Ssn = {(this.Ssn == null ? "null" : this.Ssn == string.Empty ? "" : this.Ssn)}");
            toStringOutput.Add($"this.OwnershipPercent = {(this.OwnershipPercent == null ? "null" : this.OwnershipPercent.ToString())}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber == string.Empty ? "" : this.PhoneNumber)}");
        }
    }
}