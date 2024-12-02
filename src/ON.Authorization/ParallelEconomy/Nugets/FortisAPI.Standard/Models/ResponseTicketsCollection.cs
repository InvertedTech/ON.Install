// <copyright file="ResponseTicketsCollection.cs" company="APIMatic">
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
    /// ResponseTicketsCollection.
    /// </summary>
    public class ResponseTicketsCollection : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseTicketsCollection"/> class.
        /// </summary>
        public ResponseTicketsCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseTicketsCollection"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="list">list.</param>
        /// <param name="links">links.</param>
        /// <param name="pagination">pagination.</param>
        /// <param name="sort">sort.</param>
        public ResponseTicketsCollection(
            string type,
            List<Models.List14> list,
            Models.Links links = null,
            Models.Pagination pagination = null,
            Models.Sort sort = null)
        {
            this.Type = type;
            this.List = list;
            this.Links = links;
            this.Pagination = pagination;
            this.Sort = sort;
        }

        /// <summary>
        /// Resource Type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Resource Members
        /// </summary>
        [JsonProperty("list")]
        public List<Models.List14> List { get; set; }

        /// <summary>
        /// Pagination page links
        /// </summary>
        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Links Links { get; set; }

        /// <summary>
        /// Pagination info
        /// </summary>
        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Pagination Pagination { get; set; }

        /// <summary>
        /// Sort information used on the results
        /// </summary>
        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Sort Sort { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ResponseTicketsCollection : ({string.Join(", ", toStringOutput)})";
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
            return obj is ResponseTicketsCollection other &&                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.List == null && other.List == null) || (this.List?.Equals(other.List) == true)) &&
                ((this.Links == null && other.Links == null) || (this.Links?.Equals(other.Links) == true)) &&
                ((this.Pagination == null && other.Pagination == null) || (this.Pagination?.Equals(other.Pagination) == true)) &&
                ((this.Sort == null && other.Sort == null) || (this.Sort?.Equals(other.Sort) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type)}");
            toStringOutput.Add($"this.List = {(this.List == null ? "null" : $"[{string.Join(", ", this.List)} ]")}");
            toStringOutput.Add($"this.Links = {(this.Links == null ? "null" : this.Links.ToString())}");
            toStringOutput.Add($"this.Pagination = {(this.Pagination == null ? "null" : this.Pagination.ToString())}");
            toStringOutput.Add($"this.Sort = {(this.Sort == null ? "null" : this.Sort.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}