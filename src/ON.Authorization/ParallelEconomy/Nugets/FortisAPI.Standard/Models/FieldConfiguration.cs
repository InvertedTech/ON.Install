// <copyright file="FieldConfiguration.cs" company="APIMatic">
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
    /// FieldConfiguration.
    /// </summary>
    public class FieldConfiguration : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldConfiguration"/> class.
        /// </summary>
        public FieldConfiguration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldConfiguration"/> class.
        /// </summary>
        /// <param name="cssMini">css_mini.</param>
        /// <param name="stack">stack.</param>
        /// <param name="body">body.</param>
        /// <param name="footer">footer.</param>
        /// <param name="header">header.</param>
        public FieldConfiguration(
            bool cssMini,
            Models.StackEnum stack,
            Models.Body body,
            Models.Footer footer,
            Models.Header header = null)
        {
            this.CssMini = cssMini;
            this.Stack = stack;
            this.Header = header;
            this.Body = body;
            this.Footer = footer;
        }

        /// <summary>
        /// CSS Mini
        /// </summary>
        [JsonProperty("css_mini")]
        public bool CssMini { get; set; }

        /// <summary>
        /// Stack
        /// </summary>
        [JsonProperty("stack")]
        public Models.StackEnum Stack { get; set; }

        /// <summary>
        /// Header
        /// </summary>
        [JsonProperty("header", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Header Header { get; set; }

        /// <summary>
        /// Body
        /// </summary>
        [JsonProperty("body")]
        public Models.Body Body { get; set; }

        /// <summary>
        /// Footer
        /// </summary>
        [JsonProperty("footer")]
        public Models.Footer Footer { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FieldConfiguration : ({string.Join(", ", toStringOutput)})";
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
            return obj is FieldConfiguration other &&                this.CssMini.Equals(other.CssMini) &&
                this.Stack.Equals(other.Stack) &&
                ((this.Header == null && other.Header == null) || (this.Header?.Equals(other.Header) == true)) &&
                ((this.Body == null && other.Body == null) || (this.Body?.Equals(other.Body) == true)) &&
                ((this.Footer == null && other.Footer == null) || (this.Footer?.Equals(other.Footer) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CssMini = {this.CssMini}");
            toStringOutput.Add($"this.Stack = {this.Stack}");
            toStringOutput.Add($"this.Header = {(this.Header == null ? "null" : this.Header.ToString())}");
            toStringOutput.Add($"this.Body = {(this.Body == null ? "null" : this.Body.ToString())}");
            toStringOutput.Add($"this.Footer = {(this.Footer == null ? "null" : this.Footer.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}