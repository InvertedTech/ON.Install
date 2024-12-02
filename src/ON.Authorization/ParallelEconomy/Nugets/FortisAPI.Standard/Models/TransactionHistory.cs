// <copyright file="TransactionHistory.cs" company="APIMatic">
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
    /// TransactionHistory.
    /// </summary>
    public class TransactionHistory : BaseModel
    {
        private int? statusId;
        private int? eventDateTs;
        private string locationId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "status_id", false },
            { "event_date_ts", false },
            { "location_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionHistory"/> class.
        /// </summary>
        public TransactionHistory()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionHistory"/> class.
        /// </summary>
        /// <param name="transactionId">transaction_id.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="statusId">status_id.</param>
        /// <param name="eventDateTs">event_date_ts.</param>
        /// <param name="locationId">location_id.</param>
        public TransactionHistory(
            string transactionId,
            string id,
            int createdTs,
            int modifiedTs,
            int? statusId = null,
            int? eventDateTs = null,
            string locationId = null)
        {
            this.TransactionId = transactionId;
            this.Id = id;
            if (statusId != null)
            {
                this.StatusId = statusId;
            }

            if (eventDateTs != null)
            {
                this.EventDateTs = eventDateTs;
            }

            if (locationId != null)
            {
                this.LocationId = locationId;
            }

            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
        }

        /// <summary>
        /// Transaction ID
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Transaction Histories ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Status ID
        /// </summary>
        [JsonProperty("status_id")]
        public int? StatusId
        {
            get
            {
                return this.statusId;
            }

            set
            {
                this.shouldSerialize["status_id"] = true;
                this.statusId = value;
            }
        }

        /// <summary>
        /// Event Date TS
        /// </summary>
        [JsonProperty("event_date_ts")]
        public int? EventDateTs
        {
            get
            {
                return this.eventDateTs;
            }

            set
            {
                this.shouldSerialize["event_date_ts"] = true;
                this.eventDateTs = value;
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
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int CreatedTs { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts")]
        public int ModifiedTs { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TransactionHistory : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetStatusId()
        {
            this.shouldSerialize["status_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEventDateTs()
        {
            this.shouldSerialize["event_date_ts"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocationId()
        {
            this.shouldSerialize["location_id"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStatusId()
        {
            return this.shouldSerialize["status_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEventDateTs()
        {
            return this.shouldSerialize["event_date_ts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
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
            return obj is TransactionHistory other &&                ((this.TransactionId == null && other.TransactionId == null) || (this.TransactionId?.Equals(other.TransactionId) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.StatusId == null && other.StatusId == null) || (this.StatusId?.Equals(other.StatusId) == true)) &&
                ((this.EventDateTs == null && other.EventDateTs == null) || (this.EventDateTs?.Equals(other.EventDateTs) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs);
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TransactionId = {(this.TransactionId == null ? "null" : this.TransactionId)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.StatusId = {(this.StatusId == null ? "null" : this.StatusId.ToString())}");
            toStringOutput.Add($"this.EventDateTs = {(this.EventDateTs == null ? "null" : this.EventDateTs.ToString())}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");

            base.ToString(toStringOutput);
        }
    }
}