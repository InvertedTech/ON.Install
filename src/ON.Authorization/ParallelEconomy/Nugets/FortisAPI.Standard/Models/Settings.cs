// <copyright file="Settings.cs" company="APIMatic">
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
    /// Settings.
    /// </summary>
    public class Settings : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class.
        /// </summary>
        public Settings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class.
        /// </summary>
        /// <param name="enabled">enabled.</param>
        /// <param name="columns">columns.</param>
        /// <param name="rows">rows.</param>
        public Settings(
            bool enabled,
            double columns,
            double rows)
        {
            this.Enabled = enabled;
            this.Columns = columns;
            this.Rows = rows;
        }

        /// <summary>
        /// Enabled
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Columns
        /// </summary>
        [JsonProperty("columns")]
        public double Columns { get; set; }

        /// <summary>
        /// Rows
        /// </summary>
        [JsonProperty("rows")]
        public double Rows { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Settings : ({string.Join(", ", toStringOutput)})";
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
            return obj is Settings other &&                this.Enabled.Equals(other.Enabled) &&
                this.Columns.Equals(other.Columns) &&
                this.Rows.Equals(other.Rows);
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Enabled = {this.Enabled}");
            toStringOutput.Add($"this.Columns = {this.Columns}");
            toStringOutput.Add($"this.Rows = {this.Rows}");

            base.ToString(toStringOutput);
        }
    }
}