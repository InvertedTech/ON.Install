// <copyright file="Data19.cs" company="APIMatic">
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
    /// Data19.
    /// </summary>
    public class Data19
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Data19"/> class.
        /// </summary>
        public Data19()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data19"/> class.
        /// </summary>
        /// <param name="userApiKey">user_api_key.</param>
        public Data19(
            string userApiKey)
        {
            this.UserApiKey = userApiKey;
        }

        /// <summary>
        /// User Api Key
        /// </summary>
        [JsonProperty("user_api_key")]
        public string UserApiKey { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data19 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Data19 other &&
                ((this.UserApiKey == null && other.UserApiKey == null) || (this.UserApiKey?.Equals(other.UserApiKey) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.UserApiKey = {(this.UserApiKey == null ? "null" : this.UserApiKey == string.Empty ? "" : this.UserApiKey)}");
        }
    }
}