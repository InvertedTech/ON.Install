// <copyright file="Links.cs" company="APIMatic">
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
    /// Links.
    /// </summary>
    public class Links : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Links"/> class.
        /// </summary>
        public Links()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Links"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="first">first.</param>
        /// <param name="previous">previous.</param>
        /// <param name="last">last.</param>
        public Links(
            string type,
            string first,
            string previous,
            string last)
        {
            this.Type = type;
            this.First = first;
            this.Previous = previous;
            this.Last = last;
        }

        /// <summary>
        /// Object type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Link to the first page
        /// </summary>
        [JsonProperty("first")]
        public string First { get; set; }

        /// <summary>
        /// Link to the previous page
        /// </summary>
        [JsonProperty("previous")]
        public string Previous { get; set; }

        /// <summary>
        /// Link to the last page
        /// </summary>
        [JsonProperty("last")]
        public string Last { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Links : ({string.Join(", ", toStringOutput)})";
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
            return obj is Links other &&                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.First == null && other.First == null) || (this.First?.Equals(other.First) == true)) &&
                ((this.Previous == null && other.Previous == null) || (this.Previous?.Equals(other.Previous) == true)) &&
                ((this.Last == null && other.Last == null) || (this.Last?.Equals(other.Last) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type)}");
            toStringOutput.Add($"this.First = {(this.First == null ? "null" : this.First)}");
            toStringOutput.Add($"this.Previous = {(this.Previous == null ? "null" : this.Previous)}");
            toStringOutput.Add($"this.Last = {(this.Last == null ? "null" : this.Last)}");

            base.ToString(toStringOutput);
        }
    }
}