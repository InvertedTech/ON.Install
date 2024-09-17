// <copyright file="TerminalRouter.cs" company="APIMatic">
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
    /// TerminalRouter.
    /// </summary>
    public class TerminalRouter : BaseModel
    {
        private string locationApiId;
        private string createdUserId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "location_api_id", false },
            { "created_user_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalRouter"/> class.
        /// </summary>
        public TerminalRouter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalRouter"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="macAddress">mac_address.</param>
        /// <param name="locationApiId">location_api_id.</param>
        /// <param name="createdUserId">created_user_id.</param>
        public TerminalRouter(
            string locationId,
            string id,
            int createdTs,
            int modifiedTs,
            string macAddress = null,
            string locationApiId = null,
            string createdUserId = null)
        {
            this.MacAddress = macAddress;
            this.LocationId = locationId;
            if (locationApiId != null)
            {
                this.LocationApiId = locationApiId;
            }

            this.Id = id;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            if (createdUserId != null)
            {
                this.CreatedUserId = createdUserId;
            }

        }

        /// <summary>
        /// Mac Address
        /// </summary>
        [JsonProperty("mac_address", NullValueHandling = NullValueHandling.Ignore)]
        public string MacAddress { get; set; }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; set; }

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
        /// Terminal Router ID
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

            return $"TerminalRouter : ({string.Join(", ", toStringOutput)})";
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
            return obj is TerminalRouter other &&                ((this.MacAddress == null && other.MacAddress == null) || (this.MacAddress?.Equals(other.MacAddress) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.LocationApiId == null && other.LocationApiId == null) || (this.LocationApiId?.Equals(other.LocationApiId) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MacAddress = {(this.MacAddress == null ? "null" : this.MacAddress)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.LocationApiId = {(this.LocationApiId == null ? "null" : this.LocationApiId)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}