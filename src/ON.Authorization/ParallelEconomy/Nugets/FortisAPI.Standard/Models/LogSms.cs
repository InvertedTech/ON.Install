// <copyright file="LogSms.cs" company="APIMatic">
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
    /// LogSms.
    /// </summary>
    public class LogSms : BaseModel
    {
        private string body;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "body", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="LogSms"/> class.
        /// </summary>
        public LogSms()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogSms"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="reasonModel">reason_model.</param>
        /// <param name="reasonModelId">reason_model_id.</param>
        /// <param name="providerId">provider_id.</param>
        /// <param name="status">status.</param>
        /// <param name="sender">sender.</param>
        /// <param name="recipient">recipient.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="body">body.</param>
        public LogSms(
            string id,
            string reasonModel,
            string reasonModelId,
            string providerId,
            string status,
            string sender,
            string recipient,
            int createdTs,
            string createdUserId,
            string body = null)
        {
            this.Id = id;
            if (body != null)
            {
                this.Body = body;
            }

            this.ReasonModel = reasonModel;
            this.ReasonModelId = reasonModelId;
            this.ProviderId = providerId;
            this.Status = status;
            this.Sender = sender;
            this.Recipient = recipient;
            this.CreatedTs = createdTs;
            this.CreatedUserId = createdUserId;
        }

        /// <summary>
        /// Log Sms Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Body
        /// </summary>
        [JsonProperty("body")]
        public string Body
        {
            get
            {
                return this.body;
            }

            set
            {
                this.shouldSerialize["body"] = true;
                this.body = value;
            }
        }

        /// <summary>
        /// Reason Model
        /// </summary>
        [JsonProperty("reason_model")]
        public string ReasonModel { get; set; }

        /// <summary>
        /// Reason Model ID
        /// </summary>
        [JsonProperty("reason_model_id")]
        public string ReasonModelId { get; set; }

        /// <summary>
        /// Provider ID
        /// </summary>
        [JsonProperty("provider_id")]
        public string ProviderId { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        [JsonProperty("sender")]
        public string Sender { get; set; }

        /// <summary>
        /// Recipient
        /// </summary>
        [JsonProperty("recipient")]
        public string Recipient { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int CreatedTs { get; set; }

        /// <summary>
        /// User ID Created the register
        /// </summary>
        [JsonProperty("created_user_id")]
        public string CreatedUserId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LogSms : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetBody()
        {
            this.shouldSerialize["body"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBody()
        {
            return this.shouldSerialize["body"];
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
            return obj is LogSms other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Body == null && other.Body == null) || (this.Body?.Equals(other.Body) == true)) &&
                ((this.ReasonModel == null && other.ReasonModel == null) || (this.ReasonModel?.Equals(other.ReasonModel) == true)) &&
                ((this.ReasonModelId == null && other.ReasonModelId == null) || (this.ReasonModelId?.Equals(other.ReasonModelId) == true)) &&
                ((this.ProviderId == null && other.ProviderId == null) || (this.ProviderId?.Equals(other.ProviderId) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.Sender == null && other.Sender == null) || (this.Sender?.Equals(other.Sender) == true)) &&
                ((this.Recipient == null && other.Recipient == null) || (this.Recipient?.Equals(other.Recipient) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.Body = {(this.Body == null ? "null" : this.Body)}");
            toStringOutput.Add($"this.ReasonModel = {(this.ReasonModel == null ? "null" : this.ReasonModel)}");
            toStringOutput.Add($"this.ReasonModelId = {(this.ReasonModelId == null ? "null" : this.ReasonModelId)}");
            toStringOutput.Add($"this.ProviderId = {(this.ProviderId == null ? "null" : this.ProviderId)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status)}");
            toStringOutput.Add($"this.Sender = {(this.Sender == null ? "null" : this.Sender)}");
            toStringOutput.Add($"this.Recipient = {(this.Recipient == null ? "null" : this.Recipient)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}