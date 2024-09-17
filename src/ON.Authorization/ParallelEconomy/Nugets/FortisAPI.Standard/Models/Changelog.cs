// <copyright file="Changelog.cs" company="APIMatic">
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
    /// Changelog.
    /// </summary>
    public class Changelog : BaseModel
    {
        private int? createdTs;
        private string action;
        private string model;
        private string modelId;
        private string userId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "created_ts", false },
            { "action", false },
            { "model", false },
            { "model_id", false },
            { "user_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Changelog"/> class.
        /// </summary>
        public Changelog()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Changelog"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="action">action.</param>
        /// <param name="model">model.</param>
        /// <param name="modelId">model_id.</param>
        /// <param name="userId">user_id.</param>
        /// <param name="changelogDetails">changelog_details.</param>
        /// <param name="user">user.</param>
        public Changelog(
            string id,
            int? createdTs = null,
            string action = null,
            string model = null,
            string modelId = null,
            string userId = null,
            List<Models.ChangelogDetail> changelogDetails = null,
            Models.User user = null)
        {
            this.Id = id;
            if (createdTs != null)
            {
                this.CreatedTs = createdTs;
            }

            if (action != null)
            {
                this.Action = action;
            }

            if (model != null)
            {
                this.Model = model;
            }

            if (modelId != null)
            {
                this.ModelId = modelId;
            }

            if (userId != null)
            {
                this.UserId = userId;
            }

            this.ChangelogDetails = changelogDetails;
            this.User = user;
        }

        /// <summary>
        /// Change Log ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int? CreatedTs
        {
            get
            {
                return this.createdTs;
            }

            set
            {
                this.shouldSerialize["created_ts"] = true;
                this.createdTs = value;
            }
        }

        /// <summary>
        /// Action
        /// </summary>
        [JsonProperty("action")]
        public string Action
        {
            get
            {
                return this.action;
            }

            set
            {
                this.shouldSerialize["action"] = true;
                this.action = value;
            }
        }

        /// <summary>
        /// Model
        /// </summary>
        [JsonProperty("model")]
        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.shouldSerialize["model"] = true;
                this.model = value;
            }
        }

        /// <summary>
        /// Model ID
        /// </summary>
        [JsonProperty("model_id")]
        public string ModelId
        {
            get
            {
                return this.modelId;
            }

            set
            {
                this.shouldSerialize["model_id"] = true;
                this.modelId = value;
            }
        }

        /// <summary>
        /// User ID
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId
        {
            get
            {
                return this.userId;
            }

            set
            {
                this.shouldSerialize["user_id"] = true;
                this.userId = value;
            }
        }

        /// <summary>
        /// Change Log Details
        /// </summary>
        [JsonProperty("changelog_details", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.ChangelogDetail> ChangelogDetails { get; set; }

        /// <summary>
        /// User
        /// </summary>
        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public Models.User User { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Changelog : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCreatedTs()
        {
            this.shouldSerialize["created_ts"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAction()
        {
            this.shouldSerialize["action"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetModel()
        {
            this.shouldSerialize["model"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetModelId()
        {
            this.shouldSerialize["model_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetUserId()
        {
            this.shouldSerialize["user_id"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCreatedTs()
        {
            return this.shouldSerialize["created_ts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAction()
        {
            return this.shouldSerialize["action"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModel()
        {
            return this.shouldSerialize["model"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModelId()
        {
            return this.shouldSerialize["model_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUserId()
        {
            return this.shouldSerialize["user_id"];
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
            return obj is Changelog other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.Action == null && other.Action == null) || (this.Action?.Equals(other.Action) == true)) &&
                ((this.Model == null && other.Model == null) || (this.Model?.Equals(other.Model) == true)) &&
                ((this.ModelId == null && other.ModelId == null) || (this.ModelId?.Equals(other.ModelId) == true)) &&
                ((this.UserId == null && other.UserId == null) || (this.UserId?.Equals(other.UserId) == true)) &&
                ((this.ChangelogDetails == null && other.ChangelogDetails == null) || (this.ChangelogDetails?.Equals(other.ChangelogDetails) == true)) &&
                ((this.User == null && other.User == null) || (this.User?.Equals(other.User) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.Action = {(this.Action == null ? "null" : this.Action)}");
            toStringOutput.Add($"this.Model = {(this.Model == null ? "null" : this.Model)}");
            toStringOutput.Add($"this.ModelId = {(this.ModelId == null ? "null" : this.ModelId)}");
            toStringOutput.Add($"this.UserId = {(this.UserId == null ? "null" : this.UserId)}");
            toStringOutput.Add($"this.ChangelogDetails = {(this.ChangelogDetails == null ? "null" : $"[{string.Join(", ", this.ChangelogDetails)} ]")}");
            toStringOutput.Add($"this.User = {(this.User == null ? "null" : this.User.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}