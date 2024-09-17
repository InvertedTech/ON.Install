// <copyright file="Pagination.cs" company="APIMatic">
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
    /// Pagination.
    /// </summary>
    public class Pagination : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pagination"/> class.
        /// </summary>
        public Pagination()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pagination"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="totalCount">total_count.</param>
        /// <param name="pageCount">page_count.</param>
        /// <param name="pageNumber">page_number.</param>
        /// <param name="pageSize">page_size.</param>
        public Pagination(
            string type,
            int? totalCount = null,
            int? pageCount = null,
            int? pageNumber = null,
            int? pageSize = null)
        {
            this.Type = type;
            this.TotalCount = totalCount;
            this.PageCount = pageCount;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }

        /// <summary>
        /// Object type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Total records count
        /// </summary>
        [JsonProperty("total_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? TotalCount { get; set; }

        /// <summary>
        /// Total page count
        /// </summary>
        [JsonProperty("page_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? PageCount { get; set; }

        /// <summary>
        /// Current page
        /// </summary>
        [JsonProperty("page_number", NullValueHandling = NullValueHandling.Ignore)]
        public int? PageNumber { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        [JsonProperty("page_size", NullValueHandling = NullValueHandling.Ignore)]
        public int? PageSize { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Pagination : ({string.Join(", ", toStringOutput)})";
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
            return obj is Pagination other &&                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.TotalCount == null && other.TotalCount == null) || (this.TotalCount?.Equals(other.TotalCount) == true)) &&
                ((this.PageCount == null && other.PageCount == null) || (this.PageCount?.Equals(other.PageCount) == true)) &&
                ((this.PageNumber == null && other.PageNumber == null) || (this.PageNumber?.Equals(other.PageNumber) == true)) &&
                ((this.PageSize == null && other.PageSize == null) || (this.PageSize?.Equals(other.PageSize) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type)}");
            toStringOutput.Add($"this.TotalCount = {(this.TotalCount == null ? "null" : this.TotalCount.ToString())}");
            toStringOutput.Add($"this.PageCount = {(this.PageCount == null ? "null" : this.PageCount.ToString())}");
            toStringOutput.Add($"this.PageNumber = {(this.PageNumber == null ? "null" : this.PageNumber.ToString())}");
            toStringOutput.Add($"this.PageSize = {(this.PageSize == null ? "null" : this.PageSize.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}