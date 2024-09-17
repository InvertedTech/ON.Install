// <copyright file="LogEmail.cs" company="APIMatic">
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
    /// LogEmail.
    /// </summary>
    public class LogEmail : BaseModel
    {
        private string providerId;
        private string domainId;
        private string reasonSent;
        private Models.ReasonModelEnum? reasonModel;
        private string reasonModelId;
        private string replyTo;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "provider_id", false },
            { "domain_id", false },
            { "reason_sent", false },
            { "reason_model", false },
            { "reason_model_id", false },
            { "reply_to", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEmail"/> class.
        /// </summary>
        public LogEmail()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEmail"/> class.
        /// </summary>
        /// <param name="subject">subject.</param>
        /// <param name="body">body.</param>
        /// <param name="sourceAddress">source_address.</param>
        /// <param name="returnPath">return_path.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="providerId">provider_id.</param>
        /// <param name="domainId">domain_id.</param>
        /// <param name="reasonSent">reason_sent.</param>
        /// <param name="reasonModel">reason_model.</param>
        /// <param name="reasonModelId">reason_model_id.</param>
        /// <param name="replyTo">reply_to.</param>
        public LogEmail(
            string subject,
            string body,
            string sourceAddress,
            string returnPath,
            string id,
            int createdTs,
            string providerId = null,
            string domainId = null,
            string reasonSent = null,
            Models.ReasonModelEnum? reasonModel = null,
            string reasonModelId = null,
            string replyTo = null)
        {
            this.Subject = subject;
            this.Body = body;
            this.SourceAddress = sourceAddress;
            this.ReturnPath = returnPath;
            if (providerId != null)
            {
                this.ProviderId = providerId;
            }

            if (domainId != null)
            {
                this.DomainId = domainId;
            }

            if (reasonSent != null)
            {
                this.ReasonSent = reasonSent;
            }

            if (reasonModel != null)
            {
                this.ReasonModel = reasonModel;
            }

            if (reasonModelId != null)
            {
                this.ReasonModelId = reasonModelId;
            }

            if (replyTo != null)
            {
                this.ReplyTo = replyTo;
            }

            this.Id = id;
            this.CreatedTs = createdTs;
        }

        /// <summary>
        /// Subject
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// Body
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// Source Address
        /// </summary>
        [JsonProperty("source_address")]
        public string SourceAddress { get; set; }

        /// <summary>
        /// Return Path
        /// </summary>
        [JsonProperty("return_path")]
        public string ReturnPath { get; set; }

        /// <summary>
        /// Provider
        /// </summary>
        [JsonProperty("provider_id")]
        public string ProviderId
        {
            get
            {
                return this.providerId;
            }

            set
            {
                this.shouldSerialize["provider_id"] = true;
                this.providerId = value;
            }
        }

        /// <summary>
        /// Domain
        /// </summary>
        [JsonProperty("domain_id")]
        public string DomainId
        {
            get
            {
                return this.domainId;
            }

            set
            {
                this.shouldSerialize["domain_id"] = true;
                this.domainId = value;
            }
        }

        /// <summary>
        /// Reason Sent
        /// </summary>
        [JsonProperty("reason_sent")]
        public string ReasonSent
        {
            get
            {
                return this.reasonSent;
            }

            set
            {
                this.shouldSerialize["reason_sent"] = true;
                this.reasonSent = value;
            }
        }

        /// <summary>
        /// Reason Model
        /// </summary>
        [JsonProperty("reason_model")]
        public Models.ReasonModelEnum? ReasonModel
        {
            get
            {
                return this.reasonModel;
            }

            set
            {
                this.shouldSerialize["reason_model"] = true;
                this.reasonModel = value;
            }
        }

        /// <summary>
        /// Reason Model
        /// </summary>
        [JsonProperty("reason_model_id")]
        public string ReasonModelId
        {
            get
            {
                return this.reasonModelId;
            }

            set
            {
                this.shouldSerialize["reason_model_id"] = true;
                this.reasonModelId = value;
            }
        }

        /// <summary>
        /// Reply To
        /// </summary>
        [JsonProperty("reply_to")]
        public string ReplyTo
        {
            get
            {
                return this.replyTo;
            }

            set
            {
                this.shouldSerialize["reply_to"] = true;
                this.replyTo = value;
            }
        }

        /// <summary>
        /// Log Email Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int CreatedTs { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LogEmail : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetProviderId()
        {
            this.shouldSerialize["provider_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDomainId()
        {
            this.shouldSerialize["domain_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReasonSent()
        {
            this.shouldSerialize["reason_sent"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReasonModel()
        {
            this.shouldSerialize["reason_model"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReasonModelId()
        {
            this.shouldSerialize["reason_model_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReplyTo()
        {
            this.shouldSerialize["reply_to"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeProviderId()
        {
            return this.shouldSerialize["provider_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDomainId()
        {
            return this.shouldSerialize["domain_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReasonSent()
        {
            return this.shouldSerialize["reason_sent"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReasonModel()
        {
            return this.shouldSerialize["reason_model"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReasonModelId()
        {
            return this.shouldSerialize["reason_model_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReplyTo()
        {
            return this.shouldSerialize["reply_to"];
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
            return obj is LogEmail other &&                ((this.Subject == null && other.Subject == null) || (this.Subject?.Equals(other.Subject) == true)) &&
                ((this.Body == null && other.Body == null) || (this.Body?.Equals(other.Body) == true)) &&
                ((this.SourceAddress == null && other.SourceAddress == null) || (this.SourceAddress?.Equals(other.SourceAddress) == true)) &&
                ((this.ReturnPath == null && other.ReturnPath == null) || (this.ReturnPath?.Equals(other.ReturnPath) == true)) &&
                ((this.ProviderId == null && other.ProviderId == null) || (this.ProviderId?.Equals(other.ProviderId) == true)) &&
                ((this.DomainId == null && other.DomainId == null) || (this.DomainId?.Equals(other.DomainId) == true)) &&
                ((this.ReasonSent == null && other.ReasonSent == null) || (this.ReasonSent?.Equals(other.ReasonSent) == true)) &&
                ((this.ReasonModel == null && other.ReasonModel == null) || (this.ReasonModel?.Equals(other.ReasonModel) == true)) &&
                ((this.ReasonModelId == null && other.ReasonModelId == null) || (this.ReasonModelId?.Equals(other.ReasonModelId) == true)) &&
                ((this.ReplyTo == null && other.ReplyTo == null) || (this.ReplyTo?.Equals(other.ReplyTo) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs);
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Subject = {(this.Subject == null ? "null" : this.Subject)}");
            toStringOutput.Add($"this.Body = {(this.Body == null ? "null" : this.Body)}");
            toStringOutput.Add($"this.SourceAddress = {(this.SourceAddress == null ? "null" : this.SourceAddress)}");
            toStringOutput.Add($"this.ReturnPath = {(this.ReturnPath == null ? "null" : this.ReturnPath)}");
            toStringOutput.Add($"this.ProviderId = {(this.ProviderId == null ? "null" : this.ProviderId)}");
            toStringOutput.Add($"this.DomainId = {(this.DomainId == null ? "null" : this.DomainId)}");
            toStringOutput.Add($"this.ReasonSent = {(this.ReasonSent == null ? "null" : this.ReasonSent)}");
            toStringOutput.Add($"this.ReasonModel = {(this.ReasonModel == null ? "null" : this.ReasonModel.ToString())}");
            toStringOutput.Add($"this.ReasonModelId = {(this.ReasonModelId == null ? "null" : this.ReasonModelId)}");
            toStringOutput.Add($"this.ReplyTo = {(this.ReplyTo == null ? "null" : this.ReplyTo)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");

            base.ToString(toStringOutput);
        }
    }
}