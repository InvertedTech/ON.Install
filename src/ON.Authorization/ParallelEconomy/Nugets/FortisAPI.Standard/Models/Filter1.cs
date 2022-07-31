// <copyright file="Filter1.cs" company="APIMatic">
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
    /// Filter1.
    /// </summary>
    public class Filter1
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Filter1"/> class.
        /// </summary>
        public Filter1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Filter1"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="accountNumber">account_number.</param>
        /// <param name="contactApiId">contact_api_id.</param>
        /// <param name="firstName">first_name.</param>
        /// <param name="lastName">last_name.</param>
        /// <param name="cellPhone">cell_phone.</param>
        /// <param name="balance">balance.</param>
        /// <param name="address">address.</param>
        /// <param name="companyName">company_name.</param>
        /// <param name="headerMessage">header_message.</param>
        /// <param name="dateOfBirth">date_of_birth.</param>
        /// <param name="emailTrxReceipt">email_trx_receipt.</param>
        /// <param name="homePhone">home_phone.</param>
        /// <param name="officePhone">office_phone.</param>
        /// <param name="officePhoneExt">office_phone_ext.</param>
        /// <param name="headerMessageType">header_message_type.</param>
        /// <param name="updateIfExists">update_if_exists.</param>
        /// <param name="contactC1">contact_c1.</param>
        /// <param name="contactC2">contact_c2.</param>
        /// <param name="contactC3">contact_c3.</param>
        /// <param name="parentId">parent_id.</param>
        /// <param name="email">email.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="active">active.</param>
        public Filter1(
            string locationId = null,
            string accountNumber = null,
            string contactApiId = null,
            string firstName = null,
            string lastName = null,
            string cellPhone = null,
            double? balance = null,
            Models.Address address = null,
            string companyName = null,
            string headerMessage = null,
            string dateOfBirth = null,
            bool? emailTrxReceipt = null,
            string homePhone = null,
            string officePhone = null,
            string officePhoneExt = null,
            int? headerMessageType = null,
            Models.UpdateIfExistsEnum? updateIfExists = null,
            string contactC1 = null,
            string contactC2 = null,
            string contactC3 = null,
            string parentId = null,
            string email = null,
            string id = null,
            int? createdTs = null,
            int? modifiedTs = null,
            int? active = null)
        {
            this.LocationId = locationId;
            this.AccountNumber = accountNumber;
            this.ContactApiId = contactApiId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CellPhone = cellPhone;
            this.Balance = balance;
            this.Address = address;
            this.CompanyName = companyName;
            this.HeaderMessage = headerMessage;
            this.DateOfBirth = dateOfBirth;
            this.EmailTrxReceipt = emailTrxReceipt;
            this.HomePhone = homePhone;
            this.OfficePhone = officePhone;
            this.OfficePhoneExt = officePhoneExt;
            this.HeaderMessageType = headerMessageType;
            this.UpdateIfExists = updateIfExists;
            this.ContactC1 = contactC1;
            this.ContactC2 = contactC2;
            this.ContactC3 = contactC3;
            this.ParentId = parentId;
            this.Email = email;
            this.Id = id;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            this.Active = active;
        }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; set; }

        /// <summary>
        /// Contact Account Number
        /// </summary>
        [JsonProperty("account_number", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Contact API Id
        /// </summary>
        [JsonProperty("contact_api_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ContactApiId { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        /// <summary>
        /// Cell phone of contact
        /// </summary>
        [JsonProperty("cell_phone", NullValueHandling = NullValueHandling.Ignore)]
        public string CellPhone { get; set; }

        /// <summary>
        /// Balance
        /// </summary>
        [JsonProperty("balance", NullValueHandling = NullValueHandling.Ignore)]
        public double? Balance { get; set; }

        /// <summary>
        /// Address of contact
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address Address { get; set; }

        /// <summary>
        /// Company Name
        /// </summary>
        [JsonProperty("company_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Header Message
        /// </summary>
        [JsonProperty("header_message", NullValueHandling = NullValueHandling.Ignore)]
        public string HeaderMessage { get; set; }

        /// <summary>
        /// Contacts DOB, Format: yyyy-MM-dd
        /// </summary>
        [JsonProperty("date_of_birth", NullValueHandling = NullValueHandling.Ignore)]
        public string DateOfBirth { get; set; }

        /// <summary>
        /// Whether or not to email all transactions receipts to contact (1 or 0)
        /// </summary>
        [JsonProperty("email_trx_receipt", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EmailTrxReceipt { get; set; }

        /// <summary>
        /// Contacts home phone
        /// </summary>
        [JsonProperty("home_phone", NullValueHandling = NullValueHandling.Ignore)]
        public string HomePhone { get; set; }

        /// <summary>
        /// Contacts office phone
        /// </summary>
        [JsonProperty("office_phone", NullValueHandling = NullValueHandling.Ignore)]
        public string OfficePhone { get; set; }

        /// <summary>
        /// Contacts office phone extension for office phone
        /// </summary>
        [JsonProperty("office_phone_ext", NullValueHandling = NullValueHandling.Ignore)]
        public string OfficePhoneExt { get; set; }

        /// <summary>
        /// Header Message Type
        /// </summary>
        [JsonProperty("header_message_type", NullValueHandling = NullValueHandling.Ignore)]
        public int? HeaderMessageType { get; set; }

        /// <summary>
        /// Update If Exists
        /// </summary>
        [JsonProperty("update_if_exists", NullValueHandling = NullValueHandling.Ignore)]
        public Models.UpdateIfExistsEnum? UpdateIfExists { get; set; }

        /// <summary>
        /// Custom field 1 for api users to store custom data
        /// </summary>
        [JsonProperty("contact_c1", NullValueHandling = NullValueHandling.Ignore)]
        public string ContactC1 { get; set; }

        /// <summary>
        /// Custom field 2 for api users to store custom data
        /// </summary>
        [JsonProperty("contact_c2", NullValueHandling = NullValueHandling.Ignore)]
        public string ContactC2 { get; set; }

        /// <summary>
        /// Custom field 3 for api users to store custom data
        /// </summary>
        [JsonProperty("contact_c3", NullValueHandling = NullValueHandling.Ignore)]
        public string ContactC3 { get; set; }

        /// <summary>
        /// Parent Id
        /// </summary>
        [JsonProperty("parent_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ParentId { get; set; }

        /// <summary>
        /// Email of contact
        /// </summary>
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        /// <summary>
        /// Contact ID
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? CreatedTs { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? ModifiedTs { get; set; }

        /// <summary>
        /// Active
        /// </summary>
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public int? Active { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Filter1 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Filter1 other &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.AccountNumber == null && other.AccountNumber == null) || (this.AccountNumber?.Equals(other.AccountNumber) == true)) &&
                ((this.ContactApiId == null && other.ContactApiId == null) || (this.ContactApiId?.Equals(other.ContactApiId) == true)) &&
                ((this.FirstName == null && other.FirstName == null) || (this.FirstName?.Equals(other.FirstName) == true)) &&
                ((this.LastName == null && other.LastName == null) || (this.LastName?.Equals(other.LastName) == true)) &&
                ((this.CellPhone == null && other.CellPhone == null) || (this.CellPhone?.Equals(other.CellPhone) == true)) &&
                ((this.Balance == null && other.Balance == null) || (this.Balance?.Equals(other.Balance) == true)) &&
                ((this.Address == null && other.Address == null) || (this.Address?.Equals(other.Address) == true)) &&
                ((this.CompanyName == null && other.CompanyName == null) || (this.CompanyName?.Equals(other.CompanyName) == true)) &&
                ((this.HeaderMessage == null && other.HeaderMessage == null) || (this.HeaderMessage?.Equals(other.HeaderMessage) == true)) &&
                ((this.DateOfBirth == null && other.DateOfBirth == null) || (this.DateOfBirth?.Equals(other.DateOfBirth) == true)) &&
                ((this.EmailTrxReceipt == null && other.EmailTrxReceipt == null) || (this.EmailTrxReceipt?.Equals(other.EmailTrxReceipt) == true)) &&
                ((this.HomePhone == null && other.HomePhone == null) || (this.HomePhone?.Equals(other.HomePhone) == true)) &&
                ((this.OfficePhone == null && other.OfficePhone == null) || (this.OfficePhone?.Equals(other.OfficePhone) == true)) &&
                ((this.OfficePhoneExt == null && other.OfficePhoneExt == null) || (this.OfficePhoneExt?.Equals(other.OfficePhoneExt) == true)) &&
                ((this.HeaderMessageType == null && other.HeaderMessageType == null) || (this.HeaderMessageType?.Equals(other.HeaderMessageType) == true)) &&
                ((this.UpdateIfExists == null && other.UpdateIfExists == null) || (this.UpdateIfExists?.Equals(other.UpdateIfExists) == true)) &&
                ((this.ContactC1 == null && other.ContactC1 == null) || (this.ContactC1?.Equals(other.ContactC1) == true)) &&
                ((this.ContactC2 == null && other.ContactC2 == null) || (this.ContactC2?.Equals(other.ContactC2) == true)) &&
                ((this.ContactC3 == null && other.ContactC3 == null) || (this.ContactC3?.Equals(other.ContactC3) == true)) &&
                ((this.ParentId == null && other.ParentId == null) || (this.ParentId?.Equals(other.ParentId) == true)) &&
                ((this.Email == null && other.Email == null) || (this.Email?.Equals(other.Email) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.ModifiedTs == null && other.ModifiedTs == null) || (this.ModifiedTs?.Equals(other.ModifiedTs) == true)) &&
                ((this.Active == null && other.Active == null) || (this.Active?.Equals(other.Active) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.AccountNumber = {(this.AccountNumber == null ? "null" : this.AccountNumber == string.Empty ? "" : this.AccountNumber)}");
            toStringOutput.Add($"this.ContactApiId = {(this.ContactApiId == null ? "null" : this.ContactApiId == string.Empty ? "" : this.ContactApiId)}");
            toStringOutput.Add($"this.FirstName = {(this.FirstName == null ? "null" : this.FirstName == string.Empty ? "" : this.FirstName)}");
            toStringOutput.Add($"this.LastName = {(this.LastName == null ? "null" : this.LastName == string.Empty ? "" : this.LastName)}");
            toStringOutput.Add($"this.CellPhone = {(this.CellPhone == null ? "null" : this.CellPhone == string.Empty ? "" : this.CellPhone)}");
            toStringOutput.Add($"this.Balance = {(this.Balance == null ? "null" : this.Balance.ToString())}");
            toStringOutput.Add($"this.Address = {(this.Address == null ? "null" : this.Address.ToString())}");
            toStringOutput.Add($"this.CompanyName = {(this.CompanyName == null ? "null" : this.CompanyName == string.Empty ? "" : this.CompanyName)}");
            toStringOutput.Add($"this.HeaderMessage = {(this.HeaderMessage == null ? "null" : this.HeaderMessage == string.Empty ? "" : this.HeaderMessage)}");
            toStringOutput.Add($"this.DateOfBirth = {(this.DateOfBirth == null ? "null" : this.DateOfBirth == string.Empty ? "" : this.DateOfBirth)}");
            toStringOutput.Add($"this.EmailTrxReceipt = {(this.EmailTrxReceipt == null ? "null" : this.EmailTrxReceipt.ToString())}");
            toStringOutput.Add($"this.HomePhone = {(this.HomePhone == null ? "null" : this.HomePhone == string.Empty ? "" : this.HomePhone)}");
            toStringOutput.Add($"this.OfficePhone = {(this.OfficePhone == null ? "null" : this.OfficePhone == string.Empty ? "" : this.OfficePhone)}");
            toStringOutput.Add($"this.OfficePhoneExt = {(this.OfficePhoneExt == null ? "null" : this.OfficePhoneExt == string.Empty ? "" : this.OfficePhoneExt)}");
            toStringOutput.Add($"this.HeaderMessageType = {(this.HeaderMessageType == null ? "null" : this.HeaderMessageType.ToString())}");
            toStringOutput.Add($"this.UpdateIfExists = {(this.UpdateIfExists == null ? "null" : this.UpdateIfExists.ToString())}");
            toStringOutput.Add($"this.ContactC1 = {(this.ContactC1 == null ? "null" : this.ContactC1 == string.Empty ? "" : this.ContactC1)}");
            toStringOutput.Add($"this.ContactC2 = {(this.ContactC2 == null ? "null" : this.ContactC2 == string.Empty ? "" : this.ContactC2)}");
            toStringOutput.Add($"this.ContactC3 = {(this.ContactC3 == null ? "null" : this.ContactC3 == string.Empty ? "" : this.ContactC3)}");
            toStringOutput.Add($"this.ParentId = {(this.ParentId == null ? "null" : this.ParentId == string.Empty ? "" : this.ParentId)}");
            toStringOutput.Add($"this.Email = {(this.Email == null ? "null" : this.Email == string.Empty ? "" : this.Email)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.ModifiedTs = {(this.ModifiedTs == null ? "null" : this.ModifiedTs.ToString())}");
            toStringOutput.Add($"this.Active = {(this.Active == null ? "null" : this.Active.ToString())}");
        }
    }
}