// <copyright file="ChangelogDetail.cs" company="APIMatic">
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
    /// ChangelogDetail.
    /// </summary>
    public class ChangelogDetail : BaseModel
    {
        private string id;
        private string changelogId;
        private string field;
        private string oldValue;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "id", false },
            { "changelog_id", false },
            { "field", false },
            { "old_value", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangelogDetail"/> class.
        /// </summary>
        public ChangelogDetail()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangelogDetail"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="changelogId">changelog_id.</param>
        /// <param name="field">field.</param>
        /// <param name="oldValue">old_value.</param>
        public ChangelogDetail(
            string id = null,
            string changelogId = null,
            string field = null,
            string oldValue = null)
        {
            if (id != null)
            {
                this.Id = id;
            }

            if (changelogId != null)
            {
                this.ChangelogId = changelogId;
            }

            if (field != null)
            {
                this.Field = field;
            }

            if (oldValue != null)
            {
                this.OldValue = oldValue;
            }

        }

        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id")]
        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.shouldSerialize["id"] = true;
                this.id = value;
            }
        }

        /// <summary>
        /// Changelog ID
        /// </summary>
        [JsonProperty("changelog_id")]
        public string ChangelogId
        {
            get
            {
                return this.changelogId;
            }

            set
            {
                this.shouldSerialize["changelog_id"] = true;
                this.changelogId = value;
            }
        }

        /// <summary>
        /// Field
        /// </summary>
        [JsonProperty("field")]
        public string Field
        {
            get
            {
                return this.field;
            }

            set
            {
                this.shouldSerialize["field"] = true;
                this.field = value;
            }
        }

        /// <summary>
        /// Old Value
        /// </summary>
        [JsonProperty("old_value")]
        public string OldValue
        {
            get
            {
                return this.oldValue;
            }

            set
            {
                this.shouldSerialize["old_value"] = true;
                this.oldValue = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ChangelogDetail : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetId()
        {
            this.shouldSerialize["id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetChangelogId()
        {
            this.shouldSerialize["changelog_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetField()
        {
            this.shouldSerialize["field"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetOldValue()
        {
            this.shouldSerialize["old_value"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeId()
        {
            return this.shouldSerialize["id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeChangelogId()
        {
            return this.shouldSerialize["changelog_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeField()
        {
            return this.shouldSerialize["field"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOldValue()
        {
            return this.shouldSerialize["old_value"];
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
            return obj is ChangelogDetail other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.ChangelogId == null && other.ChangelogId == null) || (this.ChangelogId?.Equals(other.ChangelogId) == true)) &&
                ((this.Field == null && other.Field == null) || (this.Field?.Equals(other.Field) == true)) &&
                ((this.OldValue == null && other.OldValue == null) || (this.OldValue?.Equals(other.OldValue) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.ChangelogId = {(this.ChangelogId == null ? "null" : this.ChangelogId)}");
            toStringOutput.Add($"this.Field = {(this.Field == null ? "null" : this.Field)}");
            toStringOutput.Add($"this.OldValue = {(this.OldValue == null ? "null" : this.OldValue)}");

            base.ToString(toStringOutput);
        }
    }
}