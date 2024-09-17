// <copyright file="Header.cs" company="APIMatic">
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
    /// Header.
    /// </summary>
    public class Header : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Header"/> class.
        /// </summary>
        public Header()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Header"/> class.
        /// </summary>
        /// <param name="settings">settings.</param>
        /// <param name="fields">fields.</param>
        public Header(
            Models.Settings settings,
            List<Models.Field16> fields)
        {
            this.Settings = settings;
            this.Fields = fields;
        }

        /// <summary>
        /// Gets or sets Settings.
        /// </summary>
        [JsonProperty("settings")]
        public Models.Settings Settings { get; set; }

        /// <summary>
        /// Gets or sets Fields.
        /// </summary>
        [JsonProperty("fields")]
        public List<Models.Field16> Fields { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Header : ({string.Join(", ", toStringOutput)})";
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
            return obj is Header other &&                ((this.Settings == null && other.Settings == null) || (this.Settings?.Equals(other.Settings) == true)) &&
                ((this.Fields == null && other.Fields == null) || (this.Fields?.Equals(other.Fields) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Settings = {(this.Settings == null ? "null" : this.Settings.ToString())}");
            toStringOutput.Add($"this.Fields = {(this.Fields == null ? "null" : $"[{string.Join(", ", this.Fields)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}