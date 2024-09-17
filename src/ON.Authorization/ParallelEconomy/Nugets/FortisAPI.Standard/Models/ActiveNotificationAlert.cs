// <copyright file="ActiveNotificationAlert.cs" company="APIMatic">
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
    /// ActiveNotificationAlert.
    /// </summary>
    public class ActiveNotificationAlert : BaseModel
    {
        private string locationId;
        private string locationApiId;
        private Models.AlertTypeEnum? alertType;
        private Models.AlertTypeIdEnum? alertTypeId;
        private string description;
        private string alertMessage;
        private string createdUserId;
        private string modifiedUserId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "location_id", false },
            { "location_api_id", false },
            { "alert_type", false },
            { "alert_type_id", false },
            { "description", false },
            { "alert_message", false },
            { "created_user_id", false },
            { "modified_user_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveNotificationAlert"/> class.
        /// </summary>
        public ActiveNotificationAlert()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveNotificationAlert"/> class.
        /// </summary>
        /// <param name="dateStart">date_start.</param>
        /// <param name="dateEnd">date_end.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="locationApiId">location_api_id.</param>
        /// <param name="userLocation">user_location.</param>
        /// <param name="userContact">user_contact.</param>
        /// <param name="includeChildren">include_children.</param>
        /// <param name="alertType">alert_type.</param>
        /// <param name="alertTypeId">alert_type_id.</param>
        /// <param name="description">description.</param>
        /// <param name="alertMessage">alert_message.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="modifiedUserId">modified_user_id.</param>
        public ActiveNotificationAlert(
            string dateStart,
            string dateEnd,
            string id,
            int createdTs,
            int modifiedTs,
            string locationId = null,
            string locationApiId = null,
            bool? userLocation = null,
            bool? userContact = null,
            bool? includeChildren = null,
            Models.AlertTypeEnum? alertType = null,
            Models.AlertTypeIdEnum? alertTypeId = null,
            string description = null,
            string alertMessage = null,
            string createdUserId = null,
            string modifiedUserId = null)
        {
            if (locationId != null)
            {
                this.LocationId = locationId;
            }

            if (locationApiId != null)
            {
                this.LocationApiId = locationApiId;
            }

            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
            this.UserLocation = userLocation;
            this.UserContact = userContact;
            this.IncludeChildren = includeChildren;
            if (alertType != null)
            {
                this.AlertType = alertType;
            }

            if (alertTypeId != null)
            {
                this.AlertTypeId = alertTypeId;
            }

            if (description != null)
            {
                this.Description = description;
            }

            if (alertMessage != null)
            {
                this.AlertMessage = alertMessage;
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
        /// Location Api ID
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
        /// Date Start
        /// </summary>
        [JsonProperty("date_start")]
        public string DateStart { get; set; }

        /// <summary>
        /// Date End
        /// </summary>
        [JsonProperty("date_end")]
        public string DateEnd { get; set; }

        /// <summary>
        /// User Location
        /// </summary>
        [JsonProperty("user_location", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UserLocation { get; set; }

        /// <summary>
        /// User Contact
        /// </summary>
        [JsonProperty("user_contact", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UserContact { get; set; }

        /// <summary>
        /// Include Children
        /// </summary>
        [JsonProperty("include_children", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeChildren { get; set; }

        /// <summary>
        /// Alert Type
        /// </summary>
        [JsonProperty("alert_type")]
        public Models.AlertTypeEnum? AlertType
        {
            get
            {
                return this.alertType;
            }

            set
            {
                this.shouldSerialize["alert_type"] = true;
                this.alertType = value;
            }
        }

        /// <summary>
        /// Alert Type ID
        /// </summary>
        [JsonProperty("alert_type_id")]
        public Models.AlertTypeIdEnum? AlertTypeId
        {
            get
            {
                return this.alertTypeId;
            }

            set
            {
                this.shouldSerialize["alert_type_id"] = true;
                this.alertTypeId = value;
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
        /// Alert Message
        /// </summary>
        [JsonProperty("alert_message")]
        public string AlertMessage
        {
            get
            {
                return this.alertMessage;
            }

            set
            {
                this.shouldSerialize["alert_message"] = true;
                this.alertMessage = value;
            }
        }

        /// <summary>
        /// Notification Alert ID
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

            return $"ActiveNotificationAlert : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetAlertType()
        {
            this.shouldSerialize["alert_type"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAlertTypeId()
        {
            this.shouldSerialize["alert_type_id"] = false;
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
        public void UnsetAlertMessage()
        {
            this.shouldSerialize["alert_message"] = false;
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
        public bool ShouldSerializeLocationApiId()
        {
            return this.shouldSerialize["location_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAlertType()
        {
            return this.shouldSerialize["alert_type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAlertTypeId()
        {
            return this.shouldSerialize["alert_type_id"];
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
        public bool ShouldSerializeAlertMessage()
        {
            return this.shouldSerialize["alert_message"];
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
            return obj is ActiveNotificationAlert other &&                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.LocationApiId == null && other.LocationApiId == null) || (this.LocationApiId?.Equals(other.LocationApiId) == true)) &&
                ((this.DateStart == null && other.DateStart == null) || (this.DateStart?.Equals(other.DateStart) == true)) &&
                ((this.DateEnd == null && other.DateEnd == null) || (this.DateEnd?.Equals(other.DateEnd) == true)) &&
                ((this.UserLocation == null && other.UserLocation == null) || (this.UserLocation?.Equals(other.UserLocation) == true)) &&
                ((this.UserContact == null && other.UserContact == null) || (this.UserContact?.Equals(other.UserContact) == true)) &&
                ((this.IncludeChildren == null && other.IncludeChildren == null) || (this.IncludeChildren?.Equals(other.IncludeChildren) == true)) &&
                ((this.AlertType == null && other.AlertType == null) || (this.AlertType?.Equals(other.AlertType) == true)) &&
                ((this.AlertTypeId == null && other.AlertTypeId == null) || (this.AlertTypeId?.Equals(other.AlertTypeId) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.AlertMessage == null && other.AlertMessage == null) || (this.AlertMessage?.Equals(other.AlertMessage) == true)) &&
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
            toStringOutput.Add($"this.LocationApiId = {(this.LocationApiId == null ? "null" : this.LocationApiId)}");
            toStringOutput.Add($"this.DateStart = {(this.DateStart == null ? "null" : this.DateStart)}");
            toStringOutput.Add($"this.DateEnd = {(this.DateEnd == null ? "null" : this.DateEnd)}");
            toStringOutput.Add($"this.UserLocation = {(this.UserLocation == null ? "null" : this.UserLocation.ToString())}");
            toStringOutput.Add($"this.UserContact = {(this.UserContact == null ? "null" : this.UserContact.ToString())}");
            toStringOutput.Add($"this.IncludeChildren = {(this.IncludeChildren == null ? "null" : this.IncludeChildren.ToString())}");
            toStringOutput.Add($"this.AlertType = {(this.AlertType == null ? "null" : this.AlertType.ToString())}");
            toStringOutput.Add($"this.AlertTypeId = {(this.AlertTypeId == null ? "null" : this.AlertTypeId.ToString())}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description)}");
            toStringOutput.Add($"this.AlertMessage = {(this.AlertMessage == null ? "null" : this.AlertMessage)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.ModifiedUserId = {(this.ModifiedUserId == null ? "null" : this.ModifiedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}