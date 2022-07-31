// <copyright file="Data4.cs" company="APIMatic">
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
    /// Data4.
    /// </summary>
    public class Data4
    {
        private string deviceTermApiId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "device_term_api_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Data4"/> class.
        /// </summary>
        public Data4()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data4"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="terminalId">terminal_id.</param>
        /// <param name="requireSignature">require_signature.</param>
        /// <param name="termsConditions">terms_conditions.</param>
        /// <param name="id">id.</param>
        /// <param name="reasonCodeId">reason_code_id.</param>
        /// <param name="signature">signature.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="deviceTermApiId">device_term_api_id.</param>
        public Data4(
            string locationId,
            string terminalId,
            bool requireSignature,
            string termsConditions,
            string id,
            int reasonCodeId,
            Models.Signature signature,
            int createdTs,
            int modifiedTs,
            string createdUserId,
            string deviceTermApiId = null)
        {
            this.LocationId = locationId;
            this.TerminalId = terminalId;
            this.RequireSignature = requireSignature;
            if (deviceTermApiId != null)
            {
                this.DeviceTermApiId = deviceTermApiId;
            }

            this.TermsConditions = termsConditions;
            this.Id = id;
            this.ReasonCodeId = reasonCodeId;
            this.Signature = signature;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            this.CreatedUserId = createdUserId;
        }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        /// <summary>
        /// Terminal ID
        /// </summary>
        [JsonProperty("terminal_id")]
        public string TerminalId { get; set; }

        /// <summary>
        /// Set to true or 1 to require a signature from the customer
        /// </summary>
        [JsonProperty("require_signature")]
        public bool RequireSignature { get; set; }

        /// <summary>
        /// Can be used for associating record to external systems. Must be unique per location.
        /// </summary>
        [JsonProperty("device_term_api_id")]
        public string DeviceTermApiId
        {
            get
            {
                return this.deviceTermApiId;
            }

            set
            {
                this.shouldSerialize["device_term_api_id"] = true;
                this.deviceTermApiId = value;
            }
        }

        /// <summary>
        /// This is the message that is displayed on the screen when prompting for a signature.
        /// </summary>
        [JsonProperty("terms_conditions")]
        public string TermsConditions { get; set; }

        /// <summary>
        /// Device term ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Reason code ID
        /// </summary>
        [JsonProperty("reason_code_id")]
        public int ReasonCodeId { get; set; }

        /// <summary>
        /// A JSON object containing all the info about and including the signature blob (base64).
        /// </summary>
        [JsonProperty("signature")]
        public Models.Signature Signature { get; set; }

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
        /// System generated id for user who created record
        /// </summary>
        [JsonProperty("created_user_id")]
        public string CreatedUserId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data4 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDeviceTermApiId()
        {
            this.shouldSerialize["device_term_api_id"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDeviceTermApiId()
        {
            return this.shouldSerialize["device_term_api_id"];
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

            return obj is Data4 other &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.TerminalId == null && other.TerminalId == null) || (this.TerminalId?.Equals(other.TerminalId) == true)) &&
                this.RequireSignature.Equals(other.RequireSignature) &&
                ((this.DeviceTermApiId == null && other.DeviceTermApiId == null) || (this.DeviceTermApiId?.Equals(other.DeviceTermApiId) == true)) &&
                ((this.TermsConditions == null && other.TermsConditions == null) || (this.TermsConditions?.Equals(other.TermsConditions) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.ReasonCodeId.Equals(other.ReasonCodeId) &&
                ((this.Signature == null && other.Signature == null) || (this.Signature?.Equals(other.Signature) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.TerminalId = {(this.TerminalId == null ? "null" : this.TerminalId == string.Empty ? "" : this.TerminalId)}");
            toStringOutput.Add($"this.RequireSignature = {this.RequireSignature}");
            toStringOutput.Add($"this.DeviceTermApiId = {(this.DeviceTermApiId == null ? "null" : this.DeviceTermApiId == string.Empty ? "" : this.DeviceTermApiId)}");
            toStringOutput.Add($"this.TermsConditions = {(this.TermsConditions == null ? "null" : this.TermsConditions == string.Empty ? "" : this.TermsConditions)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.ReasonCodeId = {this.ReasonCodeId}");
            toStringOutput.Add($"this.Signature = {(this.Signature == null ? "null" : this.Signature.ToString())}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId == string.Empty ? "" : this.CreatedUserId)}");
        }
    }
}