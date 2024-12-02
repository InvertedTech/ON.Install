// <copyright file="Async.cs" company="APIMatic">
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
    /// Async.
    /// </summary>
    public class Async : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Async"/> class.
        /// </summary>
        public Async()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Async"/> class.
        /// </summary>
        /// <param name="code">code.</param>
        /// <param name="link">link.</param>
        public Async(
            Guid code,
            string link)
        {
            this.Code = code;
            this.Link = link;
        }

        /// <summary>
        /// A [UUID v4](https://datatracker.ietf.org/doc/html/rfc4122) that's unique for the Async Request
        /// </summary>
        [JsonProperty("code")]
        public Guid Code { get; set; }

        /// <summary>
        /// Link to the status check endpoint
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Async : ({string.Join(", ", toStringOutput)})";
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
            return obj is Async other &&                this.Code.Equals(other.Code) &&
                ((this.Link == null && other.Link == null) || (this.Link?.Equals(other.Link) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Code = {this.Code}");
            toStringOutput.Add($"this.Link = {(this.Link == null ? "null" : this.Link)}");

            base.ToString(toStringOutput);
        }
    }
}