// <copyright file="Data17.cs" company="APIMatic">
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
    /// Data17.
    /// </summary>
    public class Data17 : BaseModel
    {
        private string rawSignature;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "raw_signature", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Data17"/> class.
        /// </summary>
        public Data17()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data17"/> class.
        /// </summary>
        /// <param name="signature">signature.</param>
        /// <param name="resource">resource.</param>
        /// <param name="resourceId">resource_id.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="rawSignature">raw_signature.</param>
        public Data17(
            string signature,
            Models.ResourceEnum resource,
            string resourceId,
            string id,
            int createdTs,
            int modifiedTs,
            string rawSignature = null)
        {
            this.Signature = signature;
            this.Resource = resource;
            this.ResourceId = resourceId;
            this.Id = id;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            if (rawSignature != null)
            {
                this.RawSignature = rawSignature;
            }

        }

        /// <summary>
        /// Signature
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; set; }

        /// <summary>
        /// Resource
        /// </summary>
        [JsonProperty("resource")]
        public Models.ResourceEnum Resource { get; set; }

        /// <summary>
        /// Resource ID
        /// </summary>
        [JsonProperty("resource_id")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Signature ID
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
        /// Raw Signature Information on `expand`
        /// </summary>
        [JsonProperty("raw_signature")]
        public string RawSignature
        {
            get
            {
                return this.rawSignature;
            }

            set
            {
                this.shouldSerialize["raw_signature"] = true;
                this.rawSignature = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data17 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRawSignature()
        {
            this.shouldSerialize["raw_signature"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRawSignature()
        {
            return this.shouldSerialize["raw_signature"];
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
            return obj is Data17 other &&                ((this.Signature == null && other.Signature == null) || (this.Signature?.Equals(other.Signature) == true)) &&
                this.Resource.Equals(other.Resource) &&
                ((this.ResourceId == null && other.ResourceId == null) || (this.ResourceId?.Equals(other.ResourceId) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                ((this.RawSignature == null && other.RawSignature == null) || (this.RawSignature?.Equals(other.RawSignature) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Signature = {(this.Signature == null ? "null" : this.Signature)}");
            toStringOutput.Add($"this.Resource = {this.Resource}");
            toStringOutput.Add($"this.ResourceId = {(this.ResourceId == null ? "null" : this.ResourceId)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.RawSignature = {(this.RawSignature == null ? "null" : this.RawSignature)}");

            base.ToString(toStringOutput);
        }
    }
}