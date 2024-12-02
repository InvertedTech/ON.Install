// <copyright file="QuickInvoiceSetting.cs" company="APIMatic">
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
    /// QuickInvoiceSetting.
    /// </summary>
    public class QuickInvoiceSetting : BaseModel
    {
        private string locationApiId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "location_api_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="QuickInvoiceSetting"/> class.
        /// </summary>
        public QuickInvoiceSetting()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuickInvoiceSetting"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="quickInvoiceTemplate">quick_invoice_template.</param>
        /// <param name="defaultAllowPartialPay">default_allow_partial_pay.</param>
        /// <param name="defaultNotificationOnDueDate">default_notification_on_due_date.</param>
        /// <param name="defaultNotificationDaysAfterDueDate">default_notification_days_after_due_date.</param>
        /// <param name="defaultNotificationDaysBeforeDueDate">default_notification_days_before_due_date.</param>
        /// <param name="id">id.</param>
        /// <param name="locationApiId">location_api_id.</param>
        public QuickInvoiceSetting(
            string locationId,
            string quickInvoiceTemplate,
            bool defaultAllowPartialPay,
            bool defaultNotificationOnDueDate,
            double defaultNotificationDaysAfterDueDate,
            double defaultNotificationDaysBeforeDueDate,
            string id,
            string locationApiId = null)
        {
            if (locationApiId != null)
            {
                this.LocationApiId = locationApiId;
            }

            this.LocationId = locationId;
            this.QuickInvoiceTemplate = quickInvoiceTemplate;
            this.DefaultAllowPartialPay = defaultAllowPartialPay;
            this.DefaultNotificationOnDueDate = defaultNotificationOnDueDate;
            this.DefaultNotificationDaysAfterDueDate = defaultNotificationDaysAfterDueDate;
            this.DefaultNotificationDaysBeforeDueDate = defaultNotificationDaysBeforeDueDate;
            this.Id = id;
        }

        /// <summary>
        /// Location API ID
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
        /// Location ID
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        /// <summary>
        /// Quick Invoice Template
        /// </summary>
        [JsonProperty("quick_invoice_template")]
        public string QuickInvoiceTemplate { get; set; }

        /// <summary>
        /// Default Quick Invoice Allow Partial Pay
        /// </summary>
        [JsonProperty("default_allow_partial_pay")]
        public bool DefaultAllowPartialPay { get; set; }

        /// <summary>
        /// Default Quick Invoice Notification On Due Date
        /// </summary>
        [JsonProperty("default_notification_on_due_date")]
        public bool DefaultNotificationOnDueDate { get; set; }

        /// <summary>
        /// Default Quick Invoice Notification Days After Due Date
        /// </summary>
        [JsonProperty("default_notification_days_after_due_date")]
        public double DefaultNotificationDaysAfterDueDate { get; set; }

        /// <summary>
        /// Default Quick Invoice Notification Days Before Due Date
        /// </summary>
        [JsonProperty("default_notification_days_before_due_date")]
        public double DefaultNotificationDaysBeforeDueDate { get; set; }

        /// <summary>
        /// Quick Invoice Settings ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"QuickInvoiceSetting : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocationApiId()
        {
            this.shouldSerialize["location_api_id"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationApiId()
        {
            return this.shouldSerialize["location_api_id"];
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
            return obj is QuickInvoiceSetting other &&                ((this.LocationApiId == null && other.LocationApiId == null) || (this.LocationApiId?.Equals(other.LocationApiId) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.QuickInvoiceTemplate == null && other.QuickInvoiceTemplate == null) || (this.QuickInvoiceTemplate?.Equals(other.QuickInvoiceTemplate) == true)) &&
                this.DefaultAllowPartialPay.Equals(other.DefaultAllowPartialPay) &&
                this.DefaultNotificationOnDueDate.Equals(other.DefaultNotificationOnDueDate) &&
                this.DefaultNotificationDaysAfterDueDate.Equals(other.DefaultNotificationDaysAfterDueDate) &&
                this.DefaultNotificationDaysBeforeDueDate.Equals(other.DefaultNotificationDaysBeforeDueDate) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationApiId = {(this.LocationApiId == null ? "null" : this.LocationApiId)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.QuickInvoiceTemplate = {(this.QuickInvoiceTemplate == null ? "null" : this.QuickInvoiceTemplate)}");
            toStringOutput.Add($"this.DefaultAllowPartialPay = {this.DefaultAllowPartialPay}");
            toStringOutput.Add($"this.DefaultNotificationOnDueDate = {this.DefaultNotificationOnDueDate}");
            toStringOutput.Add($"this.DefaultNotificationDaysAfterDueDate = {this.DefaultNotificationDaysAfterDueDate}");
            toStringOutput.Add($"this.DefaultNotificationDaysBeforeDueDate = {this.DefaultNotificationDaysBeforeDueDate}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");

            base.ToString(toStringOutput);
        }
    }
}