// <copyright file="ResponseTokensCollection.cs" company="APIMatic">
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
    /// ResponseTokensCollection.
    /// </summary>
    public class ResponseTokensCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseTokensCollection"/> class.
        /// </summary>
        public ResponseTokensCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseTokensCollection"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="list">list.</param>
        public ResponseTokensCollection(
            string type,
            List<Models.List10> list)
        {
            this.Type = type;
            this.List = list;
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
        public List<Models.List10> List { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ResponseTokensCollection : ({string.Join(", ", toStringOutput)})";
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

            return obj is ResponseTokensCollection other &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.List == null && other.List == null) || (this.List?.Equals(other.List) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type == string.Empty ? "" : this.Type)}");
            toStringOutput.Add($"this.List = {(this.List == null ? "null" : $"[{string.Join(", ", this.List)} ]")}");
        }
    }
}