// <copyright file="EmailBlacklist.cs" company="APIMatic">
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
    /// EmailBlacklist.
    /// </summary>
    public class EmailBlacklist : BaseModel
    {
        private string id;
        private int? createdTs;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "id", false },
            { "created_ts", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailBlacklist"/> class.
        /// </summary>
        public EmailBlacklist()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailBlacklist"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="isBlacklisted">isBlacklisted.</param>
        /// <param name="detail">detail.</param>
        /// <param name="createdTs">created_ts.</param>
        public EmailBlacklist(
            string id = null,
            bool? isBlacklisted = null,
            bool? detail = null,
            int? createdTs = null)
        {
            if (id != null)
            {
                this.Id = id;
            }

            this.IsBlacklisted = isBlacklisted;
            this.Detail = detail;
            if (createdTs != null)
            {
                this.CreatedTs = createdTs;
            }

        }

        /// <summary>
        /// Blacklist ID
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
        /// isBlacklisted
        /// </summary>
        [JsonProperty("isBlacklisted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsBlacklisted { get; set; }

        /// <summary>
        /// Contact Id
        /// </summary>
        [JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Detail { get; set; }

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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"EmailBlacklist : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetCreatedTs()
        {
            this.shouldSerialize["created_ts"] = false;
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
        public bool ShouldSerializeCreatedTs()
        {
            return this.shouldSerialize["created_ts"];
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
            return obj is EmailBlacklist other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.IsBlacklisted == null && other.IsBlacklisted == null) || (this.IsBlacklisted?.Equals(other.IsBlacklisted) == true)) &&
                ((this.Detail == null && other.Detail == null) || (this.Detail?.Equals(other.Detail) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.IsBlacklisted = {(this.IsBlacklisted == null ? "null" : this.IsBlacklisted.ToString())}");
            toStringOutput.Add($"this.Detail = {(this.Detail == null ? "null" : this.Detail.ToString())}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}