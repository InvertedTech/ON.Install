// <copyright file="V1SignaturesRequest.cs" company="APIMatic">
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
    /// V1SignaturesRequest.
    /// </summary>
    public class V1SignaturesRequest : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1SignaturesRequest"/> class.
        /// </summary>
        public V1SignaturesRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1SignaturesRequest"/> class.
        /// </summary>
        /// <param name="signature">signature.</param>
        /// <param name="resource">resource.</param>
        /// <param name="resourceId">resource_id.</param>
        public V1SignaturesRequest(
            string signature,
            Models.ResourceEnum resource,
            string resourceId)
        {
            this.Signature = signature;
            this.Resource = resource;
            this.ResourceId = resourceId;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1SignaturesRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is V1SignaturesRequest other &&                ((this.Signature == null && other.Signature == null) || (this.Signature?.Equals(other.Signature) == true)) &&
                this.Resource.Equals(other.Resource) &&
                ((this.ResourceId == null && other.ResourceId == null) || (this.ResourceId?.Equals(other.ResourceId) == true));
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

            base.ToString(toStringOutput);
        }
    }
}