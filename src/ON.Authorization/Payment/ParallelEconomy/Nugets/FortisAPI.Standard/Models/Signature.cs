// <copyright file="Signature.cs" company="APIMatic">
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
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Signature.
    /// </summary>
    public class Signature
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Signature"/> class.
        /// </summary>
        public Signature()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Signature"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="signatureProp">signature.</param>
        /// <param name="resource">resource.</param>
        /// <param name="resourceId">resource_id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        public Signature(
            string id,
            string signatureProp,
            Models.ResourceEnum resource,
            string resourceId,
            int createdTs,
            int modifiedTs)
        {
            this.Id = id;
            this.SignatureProp = signatureProp;
            this.Resource = resource;
            this.ResourceId = resourceId;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
        }

        /// <summary>
        /// Signature ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Signature
        /// </summary>
        [JsonProperty("signature")]
        public string SignatureProp { get; set; }

        /// <summary>
        /// Resource
        /// </summary>
        [JsonProperty("resource", ItemConverterType = typeof(StringEnumConverter))]
        public Models.ResourceEnum Resource { get; set; }

        /// <summary>
        /// Resource ID
        /// </summary>
        [JsonProperty("resource_id")]
        public string ResourceId { get; set; }

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

            return $"Signature : ({string.Join(", ", toStringOutput)})";
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

            return obj is Signature other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.SignatureProp == null && other.SignatureProp == null) || (this.SignatureProp?.Equals(other.SignatureProp) == true)) &&
                this.Resource.Equals(other.Resource) &&
                ((this.ResourceId == null && other.ResourceId == null) || (this.ResourceId?.Equals(other.ResourceId) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.SignatureProp = {(this.SignatureProp == null ? "null" : this.SignatureProp == string.Empty ? "" : this.SignatureProp)}");
            toStringOutput.Add($"this.Resource = {this.Resource}");
            toStringOutput.Add($"this.ResourceId = {(this.ResourceId == null ? "null" : this.ResourceId == string.Empty ? "" : this.ResourceId)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
        }
    }
}