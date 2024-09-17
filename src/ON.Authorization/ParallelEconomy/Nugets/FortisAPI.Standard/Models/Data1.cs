// <copyright file="Data1.cs" company="APIMatic">
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
    /// Data1.
    /// </summary>
    public class Data1 : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Data1"/> class.
        /// </summary>
        public Data1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data1"/> class.
        /// </summary>
        /// <param name="mAsync">async.</param>
        public Data1(
            Models.Async mAsync)
        {
            this.MAsync = mAsync;
        }

        /// <summary>
        /// Do not store the Async Code for long term use, it expires after 30 days.
        /// </summary>
        [JsonProperty("async")]
        public Models.Async MAsync { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data1 : ({string.Join(", ", toStringOutput)})";
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
            return obj is Data1 other &&                ((this.MAsync == null && other.MAsync == null) || (this.MAsync?.Equals(other.MAsync) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MAsync = {(this.MAsync == null ? "null" : this.MAsync.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}