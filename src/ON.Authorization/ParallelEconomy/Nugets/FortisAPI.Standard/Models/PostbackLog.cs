// <copyright file="PostbackLog.cs" company="APIMatic">
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
    /// PostbackLog.
    /// </summary>
    public class PostbackLog : BaseModel
    {
        private Models.PostbackStatusIdEnum? postbackStatusId;
        private string httpVerb;
        private int? nextRunTs;
        private int? createdTs;
        private string model;
        private string modelId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "postback_status_id", false },
            { "http_verb", false },
            { "next_run_ts", false },
            { "created_ts", false },
            { "model", false },
            { "model_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="PostbackLog"/> class.
        /// </summary>
        public PostbackLog()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostbackLog"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="postbackConfigId">postback_config_id.</param>
        /// <param name="changelogId">changelog_id.</param>
        /// <param name="postbackStatusId">postback_status_id.</param>
        /// <param name="httpVerb">http_verb.</param>
        /// <param name="nextRunTs">next_run_ts.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="model">model.</param>
        /// <param name="modelId">model_id.</param>
        public PostbackLog(
            string id,
            string postbackConfigId,
            string changelogId,
            Models.PostbackStatusIdEnum? postbackStatusId = null,
            string httpVerb = null,
            int? nextRunTs = null,
            int? createdTs = null,
            string model = null,
            string modelId = null)
        {
            if (postbackStatusId != null)
            {
                this.PostbackStatusId = postbackStatusId;
            }

            this.Id = id;
            this.PostbackConfigId = postbackConfigId;
            this.ChangelogId = changelogId;
            if (httpVerb != null)
            {
                this.HttpVerb = httpVerb;
            }

            if (nextRunTs != null)
            {
                this.NextRunTs = nextRunTs;
            }

            if (createdTs != null)
            {
                this.CreatedTs = createdTs;
            }

            if (model != null)
            {
                this.Model = model;
            }

            if (modelId != null)
            {
                this.ModelId = modelId;
            }

        }

        /// <summary>
        /// Postback Status Id
        /// </summary>
        [JsonProperty("postback_status_id")]
        public Models.PostbackStatusIdEnum? PostbackStatusId
        {
            get
            {
                return this.postbackStatusId;
            }

            set
            {
                this.shouldSerialize["postback_status_id"] = true;
                this.postbackStatusId = value;
            }
        }

        /// <summary>
        /// Postback Log Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Postback Config Id
        /// </summary>
        [JsonProperty("postback_config_id")]
        public string PostbackConfigId { get; set; }

        /// <summary>
        /// Changelog Id
        /// </summary>
        [JsonProperty("changelog_id")]
        public string ChangelogId { get; set; }

        /// <summary>
        /// Http Verb
        /// </summary>
        [JsonProperty("http_verb")]
        public string HttpVerb
        {
            get
            {
                return this.httpVerb;
            }

            set
            {
                this.shouldSerialize["http_verb"] = true;
                this.httpVerb = value;
            }
        }

        /// <summary>
        /// Next Run
        /// </summary>
        [JsonProperty("next_run_ts")]
        public int? NextRunTs
        {
            get
            {
                return this.nextRunTs;
            }

            set
            {
                this.shouldSerialize["next_run_ts"] = true;
                this.nextRunTs = value;
            }
        }

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
        /// MOdel
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
        /// Model Id
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PostbackLog : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPostbackStatusId()
        {
            this.shouldSerialize["postback_status_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetHttpVerb()
        {
            this.shouldSerialize["http_verb"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetNextRunTs()
        {
            this.shouldSerialize["next_run_ts"] = false;
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
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePostbackStatusId()
        {
            return this.shouldSerialize["postback_status_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeHttpVerb()
        {
            return this.shouldSerialize["http_verb"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNextRunTs()
        {
            return this.shouldSerialize["next_run_ts"];
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
            return obj is PostbackLog other &&                ((this.PostbackStatusId == null && other.PostbackStatusId == null) || (this.PostbackStatusId?.Equals(other.PostbackStatusId) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.PostbackConfigId == null && other.PostbackConfigId == null) || (this.PostbackConfigId?.Equals(other.PostbackConfigId) == true)) &&
                ((this.ChangelogId == null && other.ChangelogId == null) || (this.ChangelogId?.Equals(other.ChangelogId) == true)) &&
                ((this.HttpVerb == null && other.HttpVerb == null) || (this.HttpVerb?.Equals(other.HttpVerb) == true)) &&
                ((this.NextRunTs == null && other.NextRunTs == null) || (this.NextRunTs?.Equals(other.NextRunTs) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.Model == null && other.Model == null) || (this.Model?.Equals(other.Model) == true)) &&
                ((this.ModelId == null && other.ModelId == null) || (this.ModelId?.Equals(other.ModelId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PostbackStatusId = {(this.PostbackStatusId == null ? "null" : this.PostbackStatusId.ToString())}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.PostbackConfigId = {(this.PostbackConfigId == null ? "null" : this.PostbackConfigId)}");
            toStringOutput.Add($"this.ChangelogId = {(this.ChangelogId == null ? "null" : this.ChangelogId)}");
            toStringOutput.Add($"this.HttpVerb = {(this.HttpVerb == null ? "null" : this.HttpVerb)}");
            toStringOutput.Add($"this.NextRunTs = {(this.NextRunTs == null ? "null" : this.NextRunTs.ToString())}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.Model = {(this.Model == null ? "null" : this.Model)}");
            toStringOutput.Add($"this.ModelId = {(this.ModelId == null ? "null" : this.ModelId)}");

            base.ToString(toStringOutput);
        }
    }
}