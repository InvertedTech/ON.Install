// <copyright file="LocationUser.cs" company="APIMatic">
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
    /// LocationUser.
    /// </summary>
    public class LocationUser : BaseModel
    {
        private string locationApiId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "location_api_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationUser"/> class.
        /// </summary>
        public LocationUser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationUser"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="userId">user_id.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="modifiedUserId">modified_user_id.</param>
        /// <param name="locationApiId">location_api_id.</param>
        public LocationUser(
            string locationId,
            string userId,
            string id,
            int createdTs,
            int modifiedTs,
            string createdUserId,
            string modifiedUserId,
            string locationApiId = null)
        {
            this.LocationId = locationId;
            this.UserId = userId;
            if (locationApiId != null)
            {
                this.LocationApiId = locationApiId;
            }

            this.Id = id;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            this.CreatedUserId = createdUserId;
            this.ModifiedUserId = modifiedUserId;
        }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets LocationApiId.
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
        /// Gets or sets Id.
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
        public string CreatedUserId { get; set; }

        /// <summary>
        /// Last User ID that updated the register
        /// </summary>
        [JsonProperty("modified_user_id")]
        public string ModifiedUserId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LocationUser : ({string.Join(", ", toStringOutput)})";
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
            return obj is LocationUser other &&                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.UserId == null && other.UserId == null) || (this.UserId?.Equals(other.UserId) == true)) &&
                ((this.LocationApiId == null && other.LocationApiId == null) || (this.LocationApiId?.Equals(other.LocationApiId) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
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
            toStringOutput.Add($"this.UserId = {(this.UserId == null ? "null" : this.UserId)}");
            toStringOutput.Add($"this.LocationApiId = {(this.LocationApiId == null ? "null" : this.LocationApiId)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.ModifiedUserId = {(this.ModifiedUserId == null ? "null" : this.ModifiedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}