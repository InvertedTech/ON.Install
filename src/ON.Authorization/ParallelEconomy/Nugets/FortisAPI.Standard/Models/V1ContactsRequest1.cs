// <copyright file="V1ContactsRequest1.cs" company="APIMatic">
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
    /// V1ContactsRequest1.
    /// </summary>
    public class V1ContactsRequest1
    {
        private string locationId;
        private string accountNumber;
        private string contactApiId;
        private string firstName;
        private string lastName;
        private string cellPhone;
        private double? balance;
        private string companyName;
        private string headerMessage;
        private string dateOfBirth;
        private string homePhone;
        private string officePhone;
        private string officePhoneExt;
        private int? headerMessageType;
        private Models.UpdateIfExistsEnum? updateIfExists;
        private string contactC1;
        private string contactC2;
        private string contactC3;
        private string parentId;
        private string email;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "location_id", false },
            { "account_number", false },
            { "contact_api_id", false },
            { "first_name", false },
            { "last_name", false },
            { "cell_phone", false },
            { "balance", false },
            { "company_name", false },
            { "header_message", false },
            { "date_of_birth", false },
            { "home_phone", false },
            { "office_phone", false },
            { "office_phone_ext", false },
            { "header_message_type", false },
            { "update_if_exists", false },
            { "contact_c1", false },
            { "contact_c2", false },
            { "contact_c3", false },
            { "parent_id", false },
            { "email", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="V1ContactsRequest1"/> class.
        /// </summary>
        public V1ContactsRequest1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1ContactsRequest1"/> class.
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
        public V1ContactsRequest1(
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
            string email = null)
        {
            if (locationId != null)
            {
                this.LocationId = locationId;
            }

            if (accountNumber != null)
            {
                this.AccountNumber = accountNumber;
            }

            if (contactApiId != null)
            {
                this.ContactApiId = contactApiId;
            }

            if (firstName != null)
            {
                this.FirstName = firstName;
            }

            if (lastName != null)
            {
                this.LastName = lastName;
            }

            if (cellPhone != null)
            {
                this.CellPhone = cellPhone;
            }

            if (balance != null)
            {
                this.Balance = balance;
            }

            this.Address = address;
            if (companyName != null)
            {
                this.CompanyName = companyName;
            }

            if (headerMessage != null)
            {
                this.HeaderMessage = headerMessage;
            }

            if (dateOfBirth != null)
            {
                this.DateOfBirth = dateOfBirth;
            }

            this.EmailTrxReceipt = emailTrxReceipt;
            if (homePhone != null)
            {
                this.HomePhone = homePhone;
            }

            if (officePhone != null)
            {
                this.OfficePhone = officePhone;
            }

            if (officePhoneExt != null)
            {
                this.OfficePhoneExt = officePhoneExt;
            }

            if (headerMessageType != null)
            {
                this.HeaderMessageType = headerMessageType;
            }

            if (updateIfExists != null)
            {
                this.UpdateIfExists = updateIfExists;
            }

            if (contactC1 != null)
            {
                this.ContactC1 = contactC1;
            }

            if (contactC2 != null)
            {
                this.ContactC2 = contactC2;
            }

            if (contactC3 != null)
            {
                this.ContactC3 = contactC3;
            }

            if (parentId != null)
            {
                this.ParentId = parentId;
            }

            if (email != null)
            {
                this.Email = email;
            }

        }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId
        {
            get
            {
                return this.locationId;
            }

            set
            {
                this.shouldSerialize["location_id"] = true;
                this.locationId = value;
            }
        }

        /// <summary>
        /// Contact Account Number
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber
        {
            get
            {
                return this.accountNumber;
            }

            set
            {
                this.shouldSerialize["account_number"] = true;
                this.accountNumber = value;
            }
        }

        /// <summary>
        /// Contact API Id
        /// </summary>
        [JsonProperty("contact_api_id")]
        public string ContactApiId
        {
            get
            {
                return this.contactApiId;
            }

            set
            {
                this.shouldSerialize["contact_api_id"] = true;
                this.contactApiId = value;
            }
        }

        /// <summary>
        /// First Name
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.shouldSerialize["first_name"] = true;
                this.firstName = value;
            }
        }

        /// <summary>
        /// Last Name
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.shouldSerialize["last_name"] = true;
                this.lastName = value;
            }
        }

        /// <summary>
        /// Cell phone of contact
        /// </summary>
        [JsonProperty("cell_phone")]
        public string CellPhone
        {
            get
            {
                return this.cellPhone;
            }

            set
            {
                this.shouldSerialize["cell_phone"] = true;
                this.cellPhone = value;
            }
        }

        /// <summary>
        /// Balance
        /// </summary>
        [JsonProperty("balance")]
        public double? Balance
        {
            get
            {
                return this.balance;
            }

            set
            {
                this.shouldSerialize["balance"] = true;
                this.balance = value;
            }
        }

        /// <summary>
        /// Address of contact
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address Address { get; set; }

        /// <summary>
        /// Company Name
        /// </summary>
        [JsonProperty("company_name")]
        public string CompanyName
        {
            get
            {
                return this.companyName;
            }

            set
            {
                this.shouldSerialize["company_name"] = true;
                this.companyName = value;
            }
        }

        /// <summary>
        /// Header Message
        /// </summary>
        [JsonProperty("header_message")]
        public string HeaderMessage
        {
            get
            {
                return this.headerMessage;
            }

            set
            {
                this.shouldSerialize["header_message"] = true;
                this.headerMessage = value;
            }
        }

        /// <summary>
        /// Contacts DOB, Format: yyyy-MM-dd
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
        /// Whether or not to email all transactions receipts to contact (1 or 0)
        /// </summary>
        [JsonProperty("email_trx_receipt", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EmailTrxReceipt { get; set; }

        /// <summary>
        /// Contacts home phone
        /// </summary>
        [JsonProperty("home_phone")]
        public string HomePhone
        {
            get
            {
                return this.homePhone;
            }

            set
            {
                this.shouldSerialize["home_phone"] = true;
                this.homePhone = value;
            }
        }

        /// <summary>
        /// Contacts office phone
        /// </summary>
        [JsonProperty("office_phone")]
        public string OfficePhone
        {
            get
            {
                return this.officePhone;
            }

            set
            {
                this.shouldSerialize["office_phone"] = true;
                this.officePhone = value;
            }
        }

        /// <summary>
        /// Contacts office phone extension for office phone
        /// </summary>
        [JsonProperty("office_phone_ext")]
        public string OfficePhoneExt
        {
            get
            {
                return this.officePhoneExt;
            }

            set
            {
                this.shouldSerialize["office_phone_ext"] = true;
                this.officePhoneExt = value;
            }
        }

        /// <summary>
        /// Header Message Type
        /// </summary>
        [JsonProperty("header_message_type")]
        public int? HeaderMessageType
        {
            get
            {
                return this.headerMessageType;
            }

            set
            {
                this.shouldSerialize["header_message_type"] = true;
                this.headerMessageType = value;
            }
        }

        /// <summary>
        /// Update If Exists
        /// </summary>
        [JsonProperty("update_if_exists")]
        public Models.UpdateIfExistsEnum? UpdateIfExists
        {
            get
            {
                return this.updateIfExists;
            }

            set
            {
                this.shouldSerialize["update_if_exists"] = true;
                this.updateIfExists = value;
            }
        }

        /// <summary>
        /// Custom field 1 for api users to store custom data
        /// </summary>
        [JsonProperty("contact_c1")]
        public string ContactC1
        {
            get
            {
                return this.contactC1;
            }

            set
            {
                this.shouldSerialize["contact_c1"] = true;
                this.contactC1 = value;
            }
        }

        /// <summary>
        /// Custom field 2 for api users to store custom data
        /// </summary>
        [JsonProperty("contact_c2")]
        public string ContactC2
        {
            get
            {
                return this.contactC2;
            }

            set
            {
                this.shouldSerialize["contact_c2"] = true;
                this.contactC2 = value;
            }
        }

        /// <summary>
        /// Custom field 3 for api users to store custom data
        /// </summary>
        [JsonProperty("contact_c3")]
        public string ContactC3
        {
            get
            {
                return this.contactC3;
            }

            set
            {
                this.shouldSerialize["contact_c3"] = true;
                this.contactC3 = value;
            }
        }

        /// <summary>
        /// Parent Id
        /// </summary>
        [JsonProperty("parent_id")]
        public string ParentId
        {
            get
            {
                return this.parentId;
            }

            set
            {
                this.shouldSerialize["parent_id"] = true;
                this.parentId = value;
            }
        }

        /// <summary>
        /// Email of contact
        /// </summary>
        [JsonProperty("email")]
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.shouldSerialize["email"] = true;
                this.email = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1ContactsRequest1 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocationId()
        {
            this.shouldSerialize["location_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAccountNumber()
        {
            this.shouldSerialize["account_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetContactApiId()
        {
            this.shouldSerialize["contact_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFirstName()
        {
            this.shouldSerialize["first_name"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLastName()
        {
            this.shouldSerialize["last_name"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCellPhone()
        {
            this.shouldSerialize["cell_phone"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetBalance()
        {
            this.shouldSerialize["balance"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCompanyName()
        {
            this.shouldSerialize["company_name"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetHeaderMessage()
        {
            this.shouldSerialize["header_message"] = false;
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
        public void UnsetHomePhone()
        {
            this.shouldSerialize["home_phone"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetOfficePhone()
        {
            this.shouldSerialize["office_phone"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetOfficePhoneExt()
        {
            this.shouldSerialize["office_phone_ext"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetHeaderMessageType()
        {
            this.shouldSerialize["header_message_type"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetUpdateIfExists()
        {
            this.shouldSerialize["update_if_exists"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetContactC1()
        {
            this.shouldSerialize["contact_c1"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetContactC2()
        {
            this.shouldSerialize["contact_c2"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetContactC3()
        {
            this.shouldSerialize["contact_c3"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetParentId()
        {
            this.shouldSerialize["parent_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEmail()
        {
            this.shouldSerialize["email"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountNumber()
        {
            return this.shouldSerialize["account_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeContactApiId()
        {
            return this.shouldSerialize["contact_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFirstName()
        {
            return this.shouldSerialize["first_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLastName()
        {
            return this.shouldSerialize["last_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCellPhone()
        {
            return this.shouldSerialize["cell_phone"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBalance()
        {
            return this.shouldSerialize["balance"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCompanyName()
        {
            return this.shouldSerialize["company_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeHeaderMessage()
        {
            return this.shouldSerialize["header_message"];
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
        public bool ShouldSerializeHomePhone()
        {
            return this.shouldSerialize["home_phone"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOfficePhone()
        {
            return this.shouldSerialize["office_phone"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOfficePhoneExt()
        {
            return this.shouldSerialize["office_phone_ext"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeHeaderMessageType()
        {
            return this.shouldSerialize["header_message_type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUpdateIfExists()
        {
            return this.shouldSerialize["update_if_exists"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeContactC1()
        {
            return this.shouldSerialize["contact_c1"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeContactC2()
        {
            return this.shouldSerialize["contact_c2"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeContactC3()
        {
            return this.shouldSerialize["contact_c3"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeParentId()
        {
            return this.shouldSerialize["parent_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmail()
        {
            return this.shouldSerialize["email"];
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

            return obj is V1ContactsRequest1 other &&
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
                ((this.Email == null && other.Email == null) || (this.Email?.Equals(other.Email) == true));
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
        }
    }
}