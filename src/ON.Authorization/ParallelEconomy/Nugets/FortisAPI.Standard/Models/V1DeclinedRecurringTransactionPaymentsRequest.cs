// <copyright file="V1DeclinedRecurringTransactionPaymentsRequest.cs" company="APIMatic">
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
    /// V1DeclinedRecurringTransactionPaymentsRequest.
    /// </summary>
    public class V1DeclinedRecurringTransactionPaymentsRequest : BaseModel
    {
        private string accountHolderName;
        private List<string> tags;
        private string saveAccountTitle;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "account_holder_name", false },
            { "tags", false },
            { "save_account_title", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="V1DeclinedRecurringTransactionPaymentsRequest"/> class.
        /// </summary>
        public V1DeclinedRecurringTransactionPaymentsRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1DeclinedRecurringTransactionPaymentsRequest"/> class.
        /// </summary>
        /// <param name="declinedRecurringTransactionId">declined_recurring_transaction_id.</param>
        /// <param name="accountNumber">account_number.</param>
        /// <param name="expDate">exp_date.</param>
        /// <param name="transactionAmount">transaction_amount.</param>
        /// <param name="accountHolderName">account_holder_name.</param>
        /// <param name="description">description.</param>
        /// <param name="billingAddress">billing_address.</param>
        /// <param name="tags">tags.</param>
        /// <param name="replaceAccountVault">replace_account_vault.</param>
        /// <param name="saveAccount">save_account.</param>
        /// <param name="saveAccountTitle">save_account_title.</param>
        public V1DeclinedRecurringTransactionPaymentsRequest(
            string declinedRecurringTransactionId,
            string accountNumber,
            string expDate,
            int transactionAmount,
            string accountHolderName = null,
            string description = null,
            Models.BillingAddress billingAddress = null,
            List<string> tags = null,
            bool? replaceAccountVault = null,
            bool? saveAccount = null,
            string saveAccountTitle = null)
        {
            this.DeclinedRecurringTransactionId = declinedRecurringTransactionId;
            this.AccountNumber = accountNumber;
            if (accountHolderName != null)
            {
                this.AccountHolderName = accountHolderName;
            }

            this.ExpDate = expDate;
            this.TransactionAmount = transactionAmount;
            this.Description = description;
            this.BillingAddress = billingAddress;
            if (tags != null)
            {
                this.Tags = tags;
            }

            this.ReplaceAccountVault = replaceAccountVault;
            this.SaveAccount = saveAccount;
            if (saveAccountTitle != null)
            {
                this.SaveAccountTitle = saveAccountTitle;
            }

        }

        /// <summary>
        /// Declined Recurring Transaction Id
        /// </summary>
        [JsonProperty("declined_recurring_transaction_id")]
        public string DeclinedRecurringTransactionId { get; set; }

        /// <summary>
        /// Account Number
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

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
        /// Exp Date
        /// </summary>
        [JsonProperty("exp_date")]
        public string ExpDate { get; set; }

        /// <summary>
        /// Transaction Amount
        /// </summary>
        [JsonProperty("transaction_amount")]
        public int TransactionAmount { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Billing Address Object
        /// </summary>
        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BillingAddress BillingAddress { get; set; }

        /// <summary>
        /// Tags
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
        /// Replace AccountVault
        /// </summary>
        [JsonProperty("replace_account_vault", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReplaceAccountVault { get; set; }

        /// <summary>
        /// Specifies to save account to contacts profile if account_number/track_data is present with either contact_id or contact_api_id in params.
        /// </summary>
        [JsonProperty("save_account", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SaveAccount { get; set; }

        /// <summary>
        /// If saving token while running a transaction, this will be the title of the token.
        /// </summary>
        [JsonProperty("save_account_title")]
        public string SaveAccountTitle
        {
            get
            {
                return this.saveAccountTitle;
            }

            set
            {
                this.shouldSerialize["save_account_title"] = true;
                this.saveAccountTitle = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1DeclinedRecurringTransactionPaymentsRequest : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetTags()
        {
            this.shouldSerialize["tags"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSaveAccountTitle()
        {
            this.shouldSerialize["save_account_title"] = false;
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
        public bool ShouldSerializeTags()
        {
            return this.shouldSerialize["tags"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSaveAccountTitle()
        {
            return this.shouldSerialize["save_account_title"];
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
            return obj is V1DeclinedRecurringTransactionPaymentsRequest other &&                ((this.DeclinedRecurringTransactionId == null && other.DeclinedRecurringTransactionId == null) || (this.DeclinedRecurringTransactionId?.Equals(other.DeclinedRecurringTransactionId) == true)) &&
                ((this.AccountNumber == null && other.AccountNumber == null) || (this.AccountNumber?.Equals(other.AccountNumber) == true)) &&
                ((this.AccountHolderName == null && other.AccountHolderName == null) || (this.AccountHolderName?.Equals(other.AccountHolderName) == true)) &&
                ((this.ExpDate == null && other.ExpDate == null) || (this.ExpDate?.Equals(other.ExpDate) == true)) &&
                this.TransactionAmount.Equals(other.TransactionAmount) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.BillingAddress == null && other.BillingAddress == null) || (this.BillingAddress?.Equals(other.BillingAddress) == true)) &&
                ((this.Tags == null && other.Tags == null) || (this.Tags?.Equals(other.Tags) == true)) &&
                ((this.ReplaceAccountVault == null && other.ReplaceAccountVault == null) || (this.ReplaceAccountVault?.Equals(other.ReplaceAccountVault) == true)) &&
                ((this.SaveAccount == null && other.SaveAccount == null) || (this.SaveAccount?.Equals(other.SaveAccount) == true)) &&
                ((this.SaveAccountTitle == null && other.SaveAccountTitle == null) || (this.SaveAccountTitle?.Equals(other.SaveAccountTitle) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DeclinedRecurringTransactionId = {(this.DeclinedRecurringTransactionId == null ? "null" : this.DeclinedRecurringTransactionId)}");
            toStringOutput.Add($"this.AccountNumber = {(this.AccountNumber == null ? "null" : this.AccountNumber)}");
            toStringOutput.Add($"this.AccountHolderName = {(this.AccountHolderName == null ? "null" : this.AccountHolderName)}");
            toStringOutput.Add($"this.ExpDate = {(this.ExpDate == null ? "null" : this.ExpDate)}");
            toStringOutput.Add($"this.TransactionAmount = {this.TransactionAmount}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description)}");
            toStringOutput.Add($"this.BillingAddress = {(this.BillingAddress == null ? "null" : this.BillingAddress.ToString())}");
            toStringOutput.Add($"this.Tags = {(this.Tags == null ? "null" : $"[{string.Join(", ", this.Tags)} ]")}");
            toStringOutput.Add($"this.ReplaceAccountVault = {(this.ReplaceAccountVault == null ? "null" : this.ReplaceAccountVault.ToString())}");
            toStringOutput.Add($"this.SaveAccount = {(this.SaveAccount == null ? "null" : this.SaveAccount.ToString())}");
            toStringOutput.Add($"this.SaveAccountTitle = {(this.SaveAccountTitle == null ? "null" : this.SaveAccountTitle)}");

            base.ToString(toStringOutput);
        }
    }
}