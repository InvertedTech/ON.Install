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
    using APIMatic.Core.Utilities.Converters;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Signature.
    /// </summary>
    public class Signature : BaseModel
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
        /// <param name="signatureProp">signature.</param>
        /// <param name="resource">resource.</param>
        /// <param name="resourceId">resource_id.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        public Signature(
            string signatureProp,
            Models.ResourceEnum resource,
            string resourceId,
            string id,
            int createdTs,
            int modifiedTs)
        {
            this.SignatureProp = signatureProp;
            this.Resource = resource;
            this.ResourceId = resourceId;
            this.Id = id;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
        }

        /// <summary>
        /// Signature
        /// </summary>
        [JsonProperty("signature")]
        public string SignatureProp { get; set; }

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
            return obj is Signature other &&                ((this.SignatureProp == null && other.SignatureProp == null) || (this.SignatureProp?.Equals(other.SignatureProp) == true)) &&
                this.Resource.Equals(other.Resource) &&
                ((this.ResourceId == null && other.ResourceId == null) || (this.ResourceId?.Equals(other.ResourceId) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs);
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SignatureProp = {(this.SignatureProp == null ? "null" : this.SignatureProp)}");
            toStringOutput.Add($"this.Resource = {this.Resource}");
            toStringOutput.Add($"this.ResourceId = {(this.ResourceId == null ? "null" : this.ResourceId)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");

            base.ToString(toStringOutput);
        }
    }
}