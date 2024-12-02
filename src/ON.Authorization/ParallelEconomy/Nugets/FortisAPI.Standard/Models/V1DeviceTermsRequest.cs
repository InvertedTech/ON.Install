// <copyright file="V1DeviceTermsRequest.cs" company="APIMatic">
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
    /// V1DeviceTermsRequest.
    /// </summary>
    public class V1DeviceTermsRequest : BaseModel
    {
        private string deviceTermApiId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "device_term_api_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="V1DeviceTermsRequest"/> class.
        /// </summary>
        public V1DeviceTermsRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1DeviceTermsRequest"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="terminalId">terminal_id.</param>
        /// <param name="requireSignature">require_signature.</param>
        /// <param name="termsConditions">terms_conditions.</param>
        /// <param name="deviceTermApiId">device_term_api_id.</param>
        public V1DeviceTermsRequest(
            string locationId,
            string terminalId,
            bool requireSignature,
            string termsConditions,
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1DeviceTermsRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is V1DeviceTermsRequest other &&                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.TerminalId == null && other.TerminalId == null) || (this.TerminalId?.Equals(other.TerminalId) == true)) &&
                this.RequireSignature.Equals(other.RequireSignature) &&
                ((this.DeviceTermApiId == null && other.DeviceTermApiId == null) || (this.DeviceTermApiId?.Equals(other.DeviceTermApiId) == true)) &&
                ((this.TermsConditions == null && other.TermsConditions == null) || (this.TermsConditions?.Equals(other.TermsConditions) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.TerminalId = {(this.TerminalId == null ? "null" : this.TerminalId)}");
            toStringOutput.Add($"this.RequireSignature = {this.RequireSignature}");
            toStringOutput.Add($"this.DeviceTermApiId = {(this.DeviceTermApiId == null ? "null" : this.DeviceTermApiId)}");
            toStringOutput.Add($"this.TermsConditions = {(this.TermsConditions == null ? "null" : this.TermsConditions)}");

            base.ToString(toStringOutput);
        }
    }
}