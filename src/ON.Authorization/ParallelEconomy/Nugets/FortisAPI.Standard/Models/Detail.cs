// <copyright file="Detail.cs" company="APIMatic">
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
    /// Detail.
    /// </summary>
    public class Detail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Detail"/> class.
        /// </summary>
        public Detail()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Detail"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="path">path.</param>
        /// <param name="type">type.</param>
        /// <param name="context">context.</param>
        public Detail(
            string message = null,
            List<string> path = null,
            string type = null,
            Models.Context context = null)
        {
            this.Message = message;
            this.Path = path;
            this.Type = type;
            this.Context = context;
        }

        /// <summary>
        /// Gets or sets Message.
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets Path.
        /// </summary>
        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Path { get; set; }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Context.
        /// </summary>
        [JsonProperty("context", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Context Context { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Detail : ({string.Join(", ", toStringOutput)})";
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

            return obj is Detail other &&
                ((this.Message == null && other.Message == null) || (this.Message?.Equals(other.Message) == true)) &&
                ((this.Path == null && other.Path == null) || (this.Path?.Equals(other.Path) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Message = {(this.Message == null ? "null" : this.Message == string.Empty ? "" : this.Message)}");
            toStringOutput.Add($"this.Path = {(this.Path == null ? "null" : $"[{string.Join(", ", this.Path)} ]")}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type == string.Empty ? "" : this.Type)}");
            toStringOutput.Add($"this.Context = {(this.Context == null ? "null" : this.Context.ToString())}");
        }
    }
}