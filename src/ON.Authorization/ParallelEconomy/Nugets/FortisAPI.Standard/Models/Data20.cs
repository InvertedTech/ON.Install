// <copyright file="Data20.cs" company="APIMatic">
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
    using FortisAPI.Standard.Models.Containers;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Data20.
    /// </summary>
    public class Data20 : BaseModel
    {
        private string accountHolderName;
        private string cvv;
        private string contactId;
        private string contactApiId;
        private string locationApiId;
        private string createdUserId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "account_holder_name", false },
            { "cvv", false },
            { "contact_id", false },
            { "contact_api_id", false },
            { "location_api_id", false },
            { "created_user_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Data20"/> class.
        /// </summary>
        public Data20()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data20"/> class.
        /// </summary>
        /// <param name="expDate">exp_date.</param>
        /// <param name="accountNumber">account_number.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="accountHolderName">account_holder_name.</param>
        /// <param name="cvv">cvv.</param>
        /// <param name="billingAddress">billing_address.</param>
        /// <param name="contactId">contact_id.</param>
        /// <param name="contactApiId">contact_api_id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="locationApiId">location_api_id.</param>
        /// <param name="createdUserId">created_user_id.</param>
        public Data20(
            string expDate,
            string accountNumber,
            string id,
            int createdTs,
            string accountHolderName = null,
            string cvv = null,
            Models.BillingAddress5 billingAddress = null,
            string contactId = null,
            string contactApiId = null,
            Data20LocationId locationId = null,
            string locationApiId = null,
            string createdUserId = null)
        {
            if (accountHolderName != null)
            {
                this.AccountHolderName = accountHolderName;
            }

            this.ExpDate = expDate;
            if (cvv != null)
            {
                this.Cvv = cvv;
            }

            this.AccountNumber = accountNumber;
            this.BillingAddress = billingAddress;
            if (contactId != null)
            {
                this.ContactId = contactId;
            }

            if (contactApiId != null)
            {
                this.ContactApiId = contactApiId;
            }

            this.LocationId = locationId;
            if (locationApiId != null)
            {
                this.LocationApiId = locationApiId;
            }

            this.Id = id;
            this.CreatedTs = createdTs;
            if (createdUserId != null)
            {
                this.CreatedUserId = createdUserId;
            }

        }

        /// <summary>
        /// Account holder name
        /// </summary>
        [JsonProperty("account_holder_name")]
        public string AccountHolderName
        {
            get
            {
                return this.accountHolderName;
            }

            set
            {
                this.shouldSerialize["account_holder_name"] = true;
                this.accountHolderName = value;
            }
        }

        /// <summary>
        /// The Expiration Date for the credit card.
        /// </summary>
        [JsonProperty("exp_date")]
        public string ExpDate { get; set; }

        /// <summary>
        /// CVV
        /// </summary>
        [JsonProperty("cvv")]
        public string Cvv
        {
            get
            {
                return this.cvv;
            }

            set
            {
                this.shouldSerialize["cvv"] = true;
                this.cvv = value;
            }
        }

        /// <summary>
        /// Account number
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Billing Address Object
        /// </summary>
        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BillingAddress5 BillingAddress { get; set; }

        /// <summary>
        /// Used to associate the Ticket with a Contact.
        /// </summary>
        [JsonProperty("contact_id")]
        public string ContactId
        {
            get
            {
                return this.contactId;
            }

            set
            {
                this.shouldSerialize["contact_id"] = true;
                this.contactId = value;
            }
        }

        /// <summary>
        /// Used to associate the Ticket with a Contact.
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
        /// A valid Location Id associated with the Contact for this Ticket
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public Data20LocationId LocationId { get; set; }

        /// <summary>
        /// Location Api Id
        /// </summary>
        [JsonProperty("location_api_id")]
        public string LocationApiId
        {
            get
            {
                return this.locationApiId;
            }

            set
            {
                this.shouldSerialize["location_api_id"] = true;
                this.locationApiId = value;
            }
        }

        /// <summary>
        /// A unique, system-generated identifier for the Ticket.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int CreatedTs { get; set; }

        /// <summary>
        /// User ID Created the register
        /// </summary>
        [JsonProperty("created_user_id")]
        public string CreatedUserId
        {
            get
            {
                return this.createdUserId;
            }

            set
            {
                this.shouldSerialize["created_user_id"] = true;
                this.createdUserId = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data20 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAccountHolderName()
        {
            this.shouldSerialize["account_holder_name"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCvv()
        {
            this.shouldSerialize["cvv"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetContactId()
        {
            this.shouldSerialize["contact_id"] = false;
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
        public void UnsetLocationApiId()
        {
            this.shouldSerialize["location_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCreatedUserId()
        {
            this.shouldSerialize["created_user_id"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountHolderName()
        {
            return this.shouldSerialize["account_holder_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCvv()
        {
            return this.shouldSerialize["cvv"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeContactId()
        {
            return this.shouldSerialize["contact_id"];
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
        public bool ShouldSerializeLocationApiId()
        {
            return this.shouldSerialize["location_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCreatedUserId()
        {
            return this.shouldSerialize["created_user_id"];
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
            return obj is Data20 other &&                ((this.AccountHolderName == null && other.AccountHolderName == null) || (this.AccountHolderName?.Equals(other.AccountHolderName) == true)) &&
                ((this.ExpDate == null && other.ExpDate == null) || (this.ExpDate?.Equals(other.ExpDate) == true)) &&
                ((this.Cvv == null && other.Cvv == null) || (this.Cvv?.Equals(other.Cvv) == true)) &&
                ((this.AccountNumber == null && other.AccountNumber == null) || (this.AccountNumber?.Equals(other.AccountNumber) == true)) &&
                ((this.BillingAddress == null && other.BillingAddress == null) || (this.BillingAddress?.Equals(other.BillingAddress) == true)) &&
                ((this.ContactId == null && other.ContactId == null) || (this.ContactId?.Equals(other.ContactId) == true)) &&
                ((this.ContactApiId == null && other.ContactApiId == null) || (this.ContactApiId?.Equals(other.ContactApiId) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.LocationApiId == null && other.LocationApiId == null) || (this.LocationApiId?.Equals(other.LocationApiId) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AccountHolderName = {(this.AccountHolderName == null ? "null" : this.AccountHolderName)}");
            toStringOutput.Add($"this.ExpDate = {(this.ExpDate == null ? "null" : this.ExpDate)}");
            toStringOutput.Add($"this.Cvv = {(this.Cvv == null ? "null" : this.Cvv)}");
            toStringOutput.Add($"this.AccountNumber = {(this.AccountNumber == null ? "null" : this.AccountNumber)}");
            toStringOutput.Add($"this.BillingAddress = {(this.BillingAddress == null ? "null" : this.BillingAddress.ToString())}");
            toStringOutput.Add($"this.ContactId = {(this.ContactId == null ? "null" : this.ContactId)}");
            toStringOutput.Add($"this.ContactApiId = {(this.ContactApiId == null ? "null" : this.ContactApiId)}");
            toStringOutput.Add($"LocationId = {(this.LocationId == null ? "null" : this.LocationId.ToString())}");
            toStringOutput.Add($"this.LocationApiId = {(this.LocationApiId == null ? "null" : this.LocationApiId)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}