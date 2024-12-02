// <copyright file="Data13.cs" company="APIMatic">
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
    /// Data13.
    /// </summary>
    public class Data13 : BaseModel
    {
        private string locationId;
        private string ccProductTransactionId;
        private string email;
        private string locationApiId;
        private string contactId;
        private string contactApiId;
        private string paylinkApiId;
        private string achProductTransactionId;
        private string expireDate;
        private Models.DeliveryMethodEnum? deliveryMethod;
        private string cellPhone;
        private string description;
        private string storeTokenTitle;
        private Models.PaylinkActionEnum? paylinkAction;
        private List<string> tags;
        private Models.StatusCode12Enum? statusCode;
        private string createdUserId;
        private string modifiedUserId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "location_id", false },
            { "cc_product_transaction_id", false },
            { "email", false },
            { "location_api_id", false },
            { "contact_id", false },
            { "contact_api_id", false },
            { "paylink_api_id", false },
            { "ach_product_transaction_id", false },
            { "expire_date", false },
            { "delivery_method", false },
            { "cell_phone", false },
            { "description", false },
            { "store_token_title", false },
            { "paylink_action", false },
            { "tags", false },
            { "status_code", false },
            { "created_user_id", false },
            { "modified_user_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Data13"/> class.
        /// </summary>
        public Data13()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data13"/> class.
        /// </summary>
        /// <param name="amountDue">amount_due.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="ccProductTransactionId">cc_product_transaction_id.</param>
        /// <param name="email">email.</param>
        /// <param name="locationApiId">location_api_id.</param>
        /// <param name="contactId">contact_id.</param>
        /// <param name="contactApiId">contact_api_id.</param>
        /// <param name="paylinkApiId">paylink_api_id.</param>
        /// <param name="achProductTransactionId">ach_product_transaction_id.</param>
        /// <param name="expireDate">expire_date.</param>
        /// <param name="displayProductTransactionReceiptDetails">display_product_transaction_receipt_details.</param>
        /// <param name="displayBillingFields">display_billing_fields.</param>
        /// <param name="deliveryMethod">delivery_method.</param>
        /// <param name="cellPhone">cell_phone.</param>
        /// <param name="description">description.</param>
        /// <param name="storeToken">store_token.</param>
        /// <param name="storeTokenTitle">store_token_title.</param>
        /// <param name="paylinkAction">paylink_action.</param>
        /// <param name="bankFundedOnlyOverride">bank_funded_only_override.</param>
        /// <param name="tags">tags.</param>
        /// <param name="statusId">status_id.</param>
        /// <param name="statusCode">status_code.</param>
        /// <param name="active">active.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="modifiedUserId">modified_user_id.</param>
        public Data13(
            int amountDue,
            string id,
            int createdTs,
            int modifiedTs,
            string locationId = null,
            string ccProductTransactionId = null,
            string email = null,
            string locationApiId = null,
            string contactId = null,
            string contactApiId = null,
            string paylinkApiId = null,
            string achProductTransactionId = null,
            string expireDate = null,
            bool? displayProductTransactionReceiptDetails = null,
            bool? displayBillingFields = null,
            Models.DeliveryMethodEnum? deliveryMethod = null,
            string cellPhone = null,
            string description = null,
            bool? storeToken = null,
            string storeTokenTitle = null,
            Models.PaylinkActionEnum? paylinkAction = null,
            bool? bankFundedOnlyOverride = null,
            List<string> tags = null,
            bool? statusId = null,
            Models.StatusCode12Enum? statusCode = null,
            bool? active = null,
            string createdUserId = null,
            string modifiedUserId = null)
        {
            if (locationId != null)
            {
                this.LocationId = locationId;
            }

            if (ccProductTransactionId != null)
            {
                this.CcProductTransactionId = ccProductTransactionId;
            }

            if (email != null)
            {
                this.Email = email;
            }

            this.AmountDue = amountDue;
            if (locationApiId != null)
            {
                this.LocationApiId = locationApiId;
            }

            if (contactId != null)
            {
                this.ContactId = contactId;
            }

            if (contactApiId != null)
            {
                this.ContactApiId = contactApiId;
            }

            if (paylinkApiId != null)
            {
                this.PaylinkApiId = paylinkApiId;
            }

            if (achProductTransactionId != null)
            {
                this.AchProductTransactionId = achProductTransactionId;
            }

            if (expireDate != null)
            {
                this.ExpireDate = expireDate;
            }

            this.DisplayProductTransactionReceiptDetails = displayProductTransactionReceiptDetails;
            this.DisplayBillingFields = displayBillingFields;
            if (deliveryMethod != null)
            {
                this.DeliveryMethod = deliveryMethod;
            }

            if (cellPhone != null)
            {
                this.CellPhone = cellPhone;
            }

            if (description != null)
            {
                this.Description = description;
            }

            this.StoreToken = storeToken;
            if (storeTokenTitle != null)
            {
                this.StoreTokenTitle = storeTokenTitle;
            }

            if (paylinkAction != null)
            {
                this.PaylinkAction = paylinkAction;
            }

            this.BankFundedOnlyOverride = bankFundedOnlyOverride;
            if (tags != null)
            {
                this.Tags = tags;
            }

            this.Id = id;
            this.StatusId = statusId;
            if (statusCode != null)
            {
                this.StatusCode = statusCode;
            }

            this.Active = active;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            if (createdUserId != null)
            {
                this.CreatedUserId = createdUserId;
            }

            if (modifiedUserId != null)
            {
                this.ModifiedUserId = modifiedUserId;
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
        /// cc_product_transaction_id
        /// </summary>
        [JsonProperty("cc_product_transaction_id")]
        public string CcProductTransactionId
        {
            get
            {
                return this.ccProductTransactionId;
            }

            set
            {
                this.shouldSerialize["cc_product_transaction_id"] = true;
                this.ccProductTransactionId = value;
            }
        }

        /// <summary>
        /// Email
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

        /// <summary>
        /// Amount Due
        /// </summary>
        [JsonProperty("amount_due")]
        public int AmountDue { get; set; }

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
        /// Contact Id
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
        /// Contact Api Id
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
        /// Paylinke Api Id
        /// </summary>
        [JsonProperty("paylink_api_id")]
        public string PaylinkApiId
        {
            get
            {
                return this.paylinkApiId;
            }

            set
            {
                this.shouldSerialize["paylink_api_id"] = true;
                this.paylinkApiId = value;
            }
        }

        /// <summary>
        /// Ach Product Transaction Id
        /// </summary>
        [JsonProperty("ach_product_transaction_id")]
        public string AchProductTransactionId
        {
            get
            {
                return this.achProductTransactionId;
            }

            set
            {
                this.shouldSerialize["ach_product_transaction_id"] = true;
                this.achProductTransactionId = value;
            }
        }

        /// <summary>
        /// Expire Date
        /// </summary>
        [JsonProperty("expire_date")]
        public string ExpireDate
        {
            get
            {
                return this.expireDate;
            }

            set
            {
                this.shouldSerialize["expire_date"] = true;
                this.expireDate = value;
            }
        }

        /// <summary>
        /// Display Product Transaction Receipt Details
        /// </summary>
        [JsonProperty("display_product_transaction_receipt_details", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DisplayProductTransactionReceiptDetails { get; set; }

        /// <summary>
        /// Display Billing Fields
        /// </summary>
        [JsonProperty("display_billing_fields", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DisplayBillingFields { get; set; }

        /// <summary>
        /// Delivery Method
        /// >0 - Do not send
        /// >
        /// >1 - Email
        /// >
        /// >2 - SMS
        /// >
        /// >3 - Both
        /// >
        /// </summary>
        [JsonProperty("delivery_method")]
        public Models.DeliveryMethodEnum? DeliveryMethod
        {
            get
            {
                return this.deliveryMethod;
            }

            set
            {
                this.shouldSerialize["delivery_method"] = true;
                this.deliveryMethod = value;
            }
        }

        /// <summary>
        /// Cell Phone
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
        /// Description
        /// </summary>
        [JsonProperty("description")]
        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                this.shouldSerialize["description"] = true;
                this.description = value;
            }
        }

        /// <summary>
        /// Store Token
        /// </summary>
        [JsonProperty("store_token", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StoreToken { get; set; }

        /// <summary>
        /// Store Token Title
        /// </summary>
        [JsonProperty("store_token_title")]
        public string StoreTokenTitle
        {
            get
            {
                return this.storeTokenTitle;
            }

            set
            {
                this.shouldSerialize["store_token_title"] = true;
                this.storeTokenTitle = value;
            }
        }

        /// <summary>
        /// Paylink Action
        /// </summary>
        [JsonProperty("paylink_action")]
        public Models.PaylinkActionEnum? PaylinkAction
        {
            get
            {
                return this.paylinkAction;
            }

            set
            {
                this.shouldSerialize["paylink_action"] = true;
                this.paylinkAction = value;
            }
        }

        /// <summary>
        /// Bank Funded Only Override
        /// </summary>
        [JsonProperty("bank_funded_only_override", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BankFundedOnlyOverride { get; set; }

        /// <summary>
        /// Used to apply tags to a paylink.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags
        {
            get
            {
                return this.tags;
            }

            set
            {
                this.shouldSerialize["tags"] = true;
                this.tags = value;
            }
        }

        /// <summary>
        /// Paylink Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// (DEPRECATED) Status Id
        /// </summary>
        [JsonProperty("status_id", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StatusId { get; set; }

        /// <summary>
        /// Status Code
        /// </summary>
        [JsonProperty("status_code")]
        public Models.StatusCode12Enum? StatusCode
        {
            get
            {
                return this.statusCode;
            }

            set
            {
                this.shouldSerialize["status_code"] = true;
                this.statusCode = value;
            }
        }

        /// <summary>
        /// Active
        /// </summary>
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Active { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int CreatedTs { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts")]
        public int ModifiedTs { get; set; }

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

        /// <summary>
        /// Last User ID that updated the register
        /// </summary>
        [JsonProperty("modified_user_id")]
        public string ModifiedUserId
        {
            get
            {
                return this.modifiedUserId;
            }

            set
            {
                this.shouldSerialize["modified_user_id"] = true;
                this.modifiedUserId = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data13 : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetCcProductTransactionId()
        {
            this.shouldSerialize["cc_product_transaction_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEmail()
        {
            this.shouldSerialize["email"] = false;
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
        public void UnsetPaylinkApiId()
        {
            this.shouldSerialize["paylink_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAchProductTransactionId()
        {
            this.shouldSerialize["ach_product_transaction_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetExpireDate()
        {
            this.shouldSerialize["expire_date"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDeliveryMethod()
        {
            this.shouldSerialize["delivery_method"] = false;
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
        public void UnsetDescription()
        {
            this.shouldSerialize["description"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetStoreTokenTitle()
        {
            this.shouldSerialize["store_token_title"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPaylinkAction()
        {
            this.shouldSerialize["paylink_action"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTags()
        {
            this.shouldSerialize["tags"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetStatusCode()
        {
            this.shouldSerialize["status_code"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCreatedUserId()
        {
            this.shouldSerialize["created_user_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetModifiedUserId()
        {
            this.shouldSerialize["modified_user_id"] = false;
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
        public bool ShouldSerializeCcProductTransactionId()
        {
            return this.shouldSerialize["cc_product_transaction_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmail()
        {
            return this.shouldSerialize["email"];
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
        public bool ShouldSerializePaylinkApiId()
        {
            return this.shouldSerialize["paylink_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAchProductTransactionId()
        {
            return this.shouldSerialize["ach_product_transaction_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeExpireDate()
        {
            return this.shouldSerialize["expire_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDeliveryMethod()
        {
            return this.shouldSerialize["delivery_method"];
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
        public bool ShouldSerializeDescription()
        {
            return this.shouldSerialize["description"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStoreTokenTitle()
        {
            return this.shouldSerialize["store_token_title"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaylinkAction()
        {
            return this.shouldSerialize["paylink_action"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTags()
        {
            return this.shouldSerialize["tags"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStatusCode()
        {
            return this.shouldSerialize["status_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCreatedUserId()
        {
            return this.shouldSerialize["created_user_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModifiedUserId()
        {
            return this.shouldSerialize["modified_user_id"];
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
            return obj is Data13 other &&                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.CcProductTransactionId == null && other.CcProductTransactionId == null) || (this.CcProductTransactionId?.Equals(other.CcProductTransactionId) == true)) &&
                ((this.Email == null && other.Email == null) || (this.Email?.Equals(other.Email) == true)) &&
                this.AmountDue.Equals(other.AmountDue) &&
                ((this.LocationApiId == null && other.LocationApiId == null) || (this.LocationApiId?.Equals(other.LocationApiId) == true)) &&
                ((this.ContactId == null && other.ContactId == null) || (this.ContactId?.Equals(other.ContactId) == true)) &&
                ((this.ContactApiId == null && other.ContactApiId == null) || (this.ContactApiId?.Equals(other.ContactApiId) == true)) &&
                ((this.PaylinkApiId == null && other.PaylinkApiId == null) || (this.PaylinkApiId?.Equals(other.PaylinkApiId) == true)) &&
                ((this.AchProductTransactionId == null && other.AchProductTransactionId == null) || (this.AchProductTransactionId?.Equals(other.AchProductTransactionId) == true)) &&
                ((this.ExpireDate == null && other.ExpireDate == null) || (this.ExpireDate?.Equals(other.ExpireDate) == true)) &&
                ((this.DisplayProductTransactionReceiptDetails == null && other.DisplayProductTransactionReceiptDetails == null) || (this.DisplayProductTransactionReceiptDetails?.Equals(other.DisplayProductTransactionReceiptDetails) == true)) &&
                ((this.DisplayBillingFields == null && other.DisplayBillingFields == null) || (this.DisplayBillingFields?.Equals(other.DisplayBillingFields) == true)) &&
                ((this.DeliveryMethod == null && other.DeliveryMethod == null) || (this.DeliveryMethod?.Equals(other.DeliveryMethod) == true)) &&
                ((this.CellPhone == null && other.CellPhone == null) || (this.CellPhone?.Equals(other.CellPhone) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.StoreToken == null && other.StoreToken == null) || (this.StoreToken?.Equals(other.StoreToken) == true)) &&
                ((this.StoreTokenTitle == null && other.StoreTokenTitle == null) || (this.StoreTokenTitle?.Equals(other.StoreTokenTitle) == true)) &&
                ((this.PaylinkAction == null && other.PaylinkAction == null) || (this.PaylinkAction?.Equals(other.PaylinkAction) == true)) &&
                ((this.BankFundedOnlyOverride == null && other.BankFundedOnlyOverride == null) || (this.BankFundedOnlyOverride?.Equals(other.BankFundedOnlyOverride) == true)) &&
                ((this.Tags == null && other.Tags == null) || (this.Tags?.Equals(other.Tags) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.StatusId == null && other.StatusId == null) || (this.StatusId?.Equals(other.StatusId) == true)) &&
                ((this.StatusCode == null && other.StatusCode == null) || (this.StatusCode?.Equals(other.StatusCode) == true)) &&
                ((this.Active == null && other.Active == null) || (this.Active?.Equals(other.Active) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true)) &&
                ((this.ModifiedUserId == null && other.ModifiedUserId == null) || (this.ModifiedUserId?.Equals(other.ModifiedUserId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.CcProductTransactionId = {(this.CcProductTransactionId == null ? "null" : this.CcProductTransactionId)}");
            toStringOutput.Add($"this.Email = {(this.Email == null ? "null" : this.Email)}");
            toStringOutput.Add($"this.AmountDue = {this.AmountDue}");
            toStringOutput.Add($"this.LocationApiId = {(this.LocationApiId == null ? "null" : this.LocationApiId)}");
            toStringOutput.Add($"this.ContactId = {(this.ContactId == null ? "null" : this.ContactId)}");
            toStringOutput.Add($"this.ContactApiId = {(this.ContactApiId == null ? "null" : this.ContactApiId)}");
            toStringOutput.Add($"this.PaylinkApiId = {(this.PaylinkApiId == null ? "null" : this.PaylinkApiId)}");
            toStringOutput.Add($"this.AchProductTransactionId = {(this.AchProductTransactionId == null ? "null" : this.AchProductTransactionId)}");
            toStringOutput.Add($"this.ExpireDate = {(this.ExpireDate == null ? "null" : this.ExpireDate)}");
            toStringOutput.Add($"this.DisplayProductTransactionReceiptDetails = {(this.DisplayProductTransactionReceiptDetails == null ? "null" : this.DisplayProductTransactionReceiptDetails.ToString())}");
            toStringOutput.Add($"this.DisplayBillingFields = {(this.DisplayBillingFields == null ? "null" : this.DisplayBillingFields.ToString())}");
            toStringOutput.Add($"this.DeliveryMethod = {(this.DeliveryMethod == null ? "null" : this.DeliveryMethod.ToString())}");
            toStringOutput.Add($"this.CellPhone = {(this.CellPhone == null ? "null" : this.CellPhone)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description)}");
            toStringOutput.Add($"this.StoreToken = {(this.StoreToken == null ? "null" : this.StoreToken.ToString())}");
            toStringOutput.Add($"this.StoreTokenTitle = {(this.StoreTokenTitle == null ? "null" : this.StoreTokenTitle)}");
            toStringOutput.Add($"this.PaylinkAction = {(this.PaylinkAction == null ? "null" : this.PaylinkAction.ToString())}");
            toStringOutput.Add($"this.BankFundedOnlyOverride = {(this.BankFundedOnlyOverride == null ? "null" : this.BankFundedOnlyOverride.ToString())}");
            toStringOutput.Add($"this.Tags = {(this.Tags == null ? "null" : $"[{string.Join(", ", this.Tags)} ]")}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.StatusId = {(this.StatusId == null ? "null" : this.StatusId.ToString())}");
            toStringOutput.Add($"this.StatusCode = {(this.StatusCode == null ? "null" : this.StatusCode.ToString())}");
            toStringOutput.Add($"this.Active = {(this.Active == null ? "null" : this.Active.ToString())}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.ModifiedUserId = {(this.ModifiedUserId == null ? "null" : this.ModifiedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}