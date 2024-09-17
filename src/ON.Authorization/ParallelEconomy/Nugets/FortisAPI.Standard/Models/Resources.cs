// <copyright file="Resources.cs" company="APIMatic">
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
    /// Resources.
    /// </summary>
    public class Resources : BaseModel
    {
        private string priv;
        private int? lastUsedDate;
        private int? createdTs;
        private int? modifiedTs;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "priv", false },
            { "last_used_date", false },
            { "created_ts", false },
            { "modified_ts", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Resources"/> class.
        /// </summary>
        public Resources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Resources"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="resourceName">resource_name.</param>
        /// <param name="id">id.</param>
        /// <param name="priv">priv.</param>
        /// <param name="lastUsedDate">last_used_date.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        public Resources(
            string title,
            string resourceName,
            int id,
            string priv = null,
            int? lastUsedDate = null,
            int? createdTs = null,
            int? modifiedTs = null)
        {
            this.Title = title;
            if (priv != null)
            {
                this.Priv = priv;
            }

            this.ResourceName = resourceName;
            this.Id = id;
            if (lastUsedDate != null)
            {
                this.LastUsedDate = lastUsedDate;
            }

            if (createdTs != null)
            {
                this.CreatedTs = createdTs;
            }

            if (modifiedTs != null)
            {
                this.ModifiedTs = modifiedTs;
            }

        }

        /// <summary>
        /// Resource Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Priv
        /// </summary>
        [JsonProperty("priv")]
        public string Priv
        {
            get
            {
                return this.priv;
            }

            set
            {
                this.shouldSerialize["priv"] = true;
                this.priv = value;
            }
        }

        /// <summary>
        /// Resource Name
        /// </summary>
        [JsonProperty("resource_name")]
        public string ResourceName { get; set; }

        /// <summary>
        /// Resource ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Last Used Date
        /// </summary>
        [JsonProperty("last_used_date")]
        public int? LastUsedDate
        {
            get
            {
                return this.lastUsedDate;
            }

            set
            {
                this.shouldSerialize["last_used_date"] = true;
                this.lastUsedDate = value;
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
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts")]
        public int? ModifiedTs
        {
            get
            {
                return this.modifiedTs;
            }

            set
            {
                this.shouldSerialize["modified_ts"] = true;
                this.modifiedTs = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Resources : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPriv()
        {
            this.shouldSerialize["priv"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLastUsedDate()
        {
            this.shouldSerialize["last_used_date"] = false;
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
        public void UnsetModifiedTs()
        {
            this.shouldSerialize["modified_ts"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePriv()
        {
            return this.shouldSerialize["priv"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLastUsedDate()
        {
            return this.shouldSerialize["last_used_date"];
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
        public bool ShouldSerializeModifiedTs()
        {
            return this.shouldSerialize["modified_ts"];
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
            return obj is Resources other &&                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.Priv == null && other.Priv == null) || (this.Priv?.Equals(other.Priv) == true)) &&
                ((this.ResourceName == null && other.ResourceName == null) || (this.ResourceName?.Equals(other.ResourceName) == true)) &&
                this.Id.Equals(other.Id) &&
                ((this.LastUsedDate == null && other.LastUsedDate == null) || (this.LastUsedDate?.Equals(other.LastUsedDate) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.ModifiedTs == null && other.ModifiedTs == null) || (this.ModifiedTs?.Equals(other.ModifiedTs) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
            toStringOutput.Add($"this.Priv = {(this.Priv == null ? "null" : this.Priv)}");
            toStringOutput.Add($"this.ResourceName = {(this.ResourceName == null ? "null" : this.ResourceName)}");
            toStringOutput.Add($"this.Id = {this.Id}");
            toStringOutput.Add($"this.LastUsedDate = {(this.LastUsedDate == null ? "null" : this.LastUsedDate.ToString())}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.ModifiedTs = {(this.ModifiedTs == null ? "null" : this.ModifiedTs.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}