// <copyright file="V1TagsRequest.cs" company="APIMatic">
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
    /// V1TagsRequest.
    /// </summary>
    public class V1TagsRequest : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1TagsRequest"/> class.
        /// </summary>
        public V1TagsRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1TagsRequest"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="title">title.</param>
        public V1TagsRequest(
            string locationId,
            string title)
        {
            this.LocationId = locationId;
            this.Title = title;
        }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        /// <summary>
        /// Tag Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1TagsRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is V1TagsRequest other &&                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");

            base.ToString(toStringOutput);
        }
    }
}