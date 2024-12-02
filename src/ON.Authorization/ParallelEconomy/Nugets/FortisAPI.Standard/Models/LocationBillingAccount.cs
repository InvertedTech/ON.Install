// <copyright file="LocationBillingAccount.cs" company="APIMatic">
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
    /// LocationBillingAccount.
    /// </summary>
    public class LocationBillingAccount : BaseModel
    {
        private string locationId;
        private string locationApiId;
        private string achSecCode;
        private string accountNumber;
        private string routing;
        private string expDate;
        private string billingZip;
        private string accountType;
        private string accountHolderName;
        private string createdUserId;
        private string modifiedUserId;
        private string billingDescriptor;
        private string paymentMethod;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "location_id", false },
            { "location_api_id", false },
            { "ach_sec_code", false },
            { "account_number", false },
            { "routing", false },
            { "exp_date", false },
            { "billing_zip", false },
            { "account_type", false },
            { "account_holder_name", false },
            { "created_user_id", false },
            { "modified_user_id", false },
            { "billing_descriptor", false },
            { "payment_method", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationBillingAccount"/> class.
        /// </summary>
        public LocationBillingAccount()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationBillingAccount"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="portfolioId">portfolio_id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="locationApiId">location_api_id.</param>
        /// <param name="achSecCode">ach_sec_code.</param>
        /// <param name="accountNumber">account_number.</param>
        /// <param name="routing">routing.</param>
        /// <param name="expDate">exp_date.</param>
        /// <param name="billingZip">billing_zip.</param>
        /// <param name="accountType">account_type.</param>
        /// <param name="accountHolderName">account_holder_name.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="modifiedUserId">modified_user_id.</param>
        /// <param name="billingDescriptor">billing_descriptor.</param>
        /// <param name="paymentMethod">payment_method.</param>
        public LocationBillingAccount(
            string title,
            string id,
            int createdTs,
            int modifiedTs,
            string portfolioId,
            string locationId = null,
            string locationApiId = null,
            string achSecCode = null,
            string accountNumber = null,
            string routing = null,
            string expDate = null,
            string billingZip = null,
            string accountType = null,
            string accountHolderName = null,
            string createdUserId = null,
            string modifiedUserId = null,
            string billingDescriptor = null,
            string paymentMethod = null)
        {
            this.Title = title;
            if (locationId != null)
            {
                this.LocationId = locationId;
            }

            if (locationApiId != null)
            {
                this.LocationApiId = locationApiId;
            }

            if (achSecCode != null)
            {
                this.AchSecCode = achSecCode;
            }

            if (accountNumber != null)
            {
                this.AccountNumber = accountNumber;
            }

            if (routing != null)
            {
                this.Routing = routing;
            }

            if (expDate != null)
            {
                this.ExpDate = expDate;
            }

            if (billingZip != null)
            {
                this.BillingZip = billingZip;
            }

            if (accountType != null)
            {
                this.AccountType = accountType;
            }

            if (accountHolderName != null)
            {
                this.AccountHolderName = accountHolderName;
            }

            this.Id = id;
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

            if (billingDescriptor != null)
            {
                this.BillingDescriptor = billingDescriptor;
            }

            if (paymentMethod != null)
            {
                this.PaymentMethod = paymentMethod;
            }

            this.PortfolioId = portfolioId;
        }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

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
        /// Ach Sec Code
        /// </summary>
        [JsonProperty("ach_sec_code")]
        public string AchSecCode
        {
            get
            {
                return this.achSecCode;
            }

            set
            {
                this.shouldSerialize["ach_sec_code"] = true;
                this.achSecCode = value;
            }
        }

        /// <summary>
        /// Account number
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
        /// Routing
        /// </summary>
        [JsonProperty("routing")]
        public string Routing
        {
            get
            {
                return this.routing;
            }

            set
            {
                this.shouldSerialize["routing"] = true;
                this.routing = value;
            }
        }

        /// <summary>
        /// Exp Date
        /// </summary>
        [JsonProperty("exp_date")]
        public string ExpDate
        {
            get
            {
                return this.expDate;
            }

            set
            {
                this.shouldSerialize["exp_date"] = true;
                this.expDate = value;
            }
        }

        /// <summary>
        /// Billing Zip
        /// </summary>
        [JsonProperty("billing_zip")]
        public string BillingZip
        {
            get
            {
                return this.billingZip;
            }

            set
            {
                this.shouldSerialize["billing_zip"] = true;
                this.billingZip = value;
            }
        }

        /// <summary>
        /// Account Type
        /// </summary>
        [JsonProperty("account_type")]
        public string AccountType
        {
            get
            {
                return this.accountType;
            }

            set
            {
                this.shouldSerialize["account_type"] = true;
                this.accountType = value;
            }
        }

        /// <summary>
        /// Account Holder Name
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
        /// Location Billing Account Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

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
        /// Created User Id
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
        /// Modified User Id
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

        /// <summary>
        /// Billing Descriptor
        /// </summary>
        [JsonProperty("billing_descriptor")]
        public string BillingDescriptor
        {
            get
            {
                return this.billingDescriptor;
            }

            set
            {
                this.shouldSerialize["billing_descriptor"] = true;
                this.billingDescriptor = value;
            }
        }

        /// <summary>
        /// Billing Descriptor
        /// </summary>
        [JsonProperty("payment_method")]
        public string PaymentMethod
        {
            get
            {
                return this.paymentMethod;
            }

            set
            {
                this.shouldSerialize["payment_method"] = true;
                this.paymentMethod = value;
            }
        }

        /// <summary>
        /// Portfolio Id
        /// </summary>
        [JsonProperty("portfolio_id")]
        public string PortfolioId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LocationBillingAccount : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetLocationApiId()
        {
            this.shouldSerialize["location_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAchSecCode()
        {
            this.shouldSerialize["ach_sec_code"] = false;
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
        public void UnsetRouting()
        {
            this.shouldSerialize["routing"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetExpDate()
        {
            this.shouldSerialize["exp_date"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetBillingZip()
        {
            this.shouldSerialize["billing_zip"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAccountType()
        {
            this.shouldSerialize["account_type"] = false;
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
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetBillingDescriptor()
        {
            this.shouldSerialize["billing_descriptor"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPaymentMethod()
        {
            this.shouldSerialize["payment_method"] = false;
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
        public bool ShouldSerializeLocationApiId()
        {
            return this.shouldSerialize["location_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAchSecCode()
        {
            return this.shouldSerialize["ach_sec_code"];
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
        public bool ShouldSerializeRouting()
        {
            return this.shouldSerialize["routing"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeExpDate()
        {
            return this.shouldSerialize["exp_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBillingZip()
        {
            return this.shouldSerialize["billing_zip"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountType()
        {
            return this.shouldSerialize["account_type"];
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

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBillingDescriptor()
        {
            return this.shouldSerialize["billing_descriptor"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentMethod()
        {
            return this.shouldSerialize["payment_method"];
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
            return obj is LocationBillingAccount other &&                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.LocationApiId == null && other.LocationApiId == null) || (this.LocationApiId?.Equals(other.LocationApiId) == true)) &&
                ((this.AchSecCode == null && other.AchSecCode == null) || (this.AchSecCode?.Equals(other.AchSecCode) == true)) &&
                ((this.AccountNumber == null && other.AccountNumber == null) || (this.AccountNumber?.Equals(other.AccountNumber) == true)) &&
                ((this.Routing == null && other.Routing == null) || (this.Routing?.Equals(other.Routing) == true)) &&
                ((this.ExpDate == null && other.ExpDate == null) || (this.ExpDate?.Equals(other.ExpDate) == true)) &&
                ((this.BillingZip == null && other.BillingZip == null) || (this.BillingZip?.Equals(other.BillingZip) == true)) &&
                ((this.AccountType == null && other.AccountType == null) || (this.AccountType?.Equals(other.AccountType) == true)) &&
                ((this.AccountHolderName == null && other.AccountHolderName == null) || (this.AccountHolderName?.Equals(other.AccountHolderName) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true)) &&
                ((this.ModifiedUserId == null && other.ModifiedUserId == null) || (this.ModifiedUserId?.Equals(other.ModifiedUserId) == true)) &&
                ((this.BillingDescriptor == null && other.BillingDescriptor == null) || (this.BillingDescriptor?.Equals(other.BillingDescriptor) == true)) &&
                ((this.PaymentMethod == null && other.PaymentMethod == null) || (this.PaymentMethod?.Equals(other.PaymentMethod) == true)) &&
                ((this.PortfolioId == null && other.PortfolioId == null) || (this.PortfolioId?.Equals(other.PortfolioId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.LocationApiId = {(this.LocationApiId == null ? "null" : this.LocationApiId)}");
            toStringOutput.Add($"this.AchSecCode = {(this.AchSecCode == null ? "null" : this.AchSecCode)}");
            toStringOutput.Add($"this.AccountNumber = {(this.AccountNumber == null ? "null" : this.AccountNumber)}");
            toStringOutput.Add($"this.Routing = {(this.Routing == null ? "null" : this.Routing)}");
            toStringOutput.Add($"this.ExpDate = {(this.ExpDate == null ? "null" : this.ExpDate)}");
            toStringOutput.Add($"this.BillingZip = {(this.BillingZip == null ? "null" : this.BillingZip)}");
            toStringOutput.Add($"this.AccountType = {(this.AccountType == null ? "null" : this.AccountType)}");
            toStringOutput.Add($"this.AccountHolderName = {(this.AccountHolderName == null ? "null" : this.AccountHolderName)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.ModifiedUserId = {(this.ModifiedUserId == null ? "null" : this.ModifiedUserId)}");
            toStringOutput.Add($"this.BillingDescriptor = {(this.BillingDescriptor == null ? "null" : this.BillingDescriptor)}");
            toStringOutput.Add($"this.PaymentMethod = {(this.PaymentMethod == null ? "null" : this.PaymentMethod)}");
            toStringOutput.Add($"this.PortfolioId = {(this.PortfolioId == null ? "null" : this.PortfolioId)}");

            base.ToString(toStringOutput);
        }
    }
}