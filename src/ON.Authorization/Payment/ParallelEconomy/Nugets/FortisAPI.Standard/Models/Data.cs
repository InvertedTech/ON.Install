// <copyright file="Data.cs" company="APIMatic">
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
    /// Data.
    /// </summary>
    public class Data
    {
        private string error;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "error", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Data"/> class.
        /// </summary>
        public Data()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data"/> class.
        /// </summary>
        /// <param name="code">code.</param>
        /// <param name="type">type.</param>
        /// <param name="id">id.</param>
        /// <param name="progress">progress.</param>
        /// <param name="ttl">ttl.</param>
        /// <param name="error">error.</param>
        public Data(
            Guid code,
            string type,
            string id,
            int progress,
            long ttl,
            string error = null)
        {
            this.Code = code;
            this.Type = type;
            this.Id = id;
            this.Progress = progress;
            if (error != null)
            {
                this.Error = error;
            }

            this.Ttl = ttl;
        }

        /// <summary>
        /// A [UUID v4](https://datatracker.ietf.org/doc/html/rfc4122) that's unique for the Async Request
        /// </summary>
        [JsonProperty("code")]
        public Guid Code { get; set; }

        /// <summary>
        /// The @type from the original request.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// After a sucessfully processing, the system will fill with the final ID for the document
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The current percentage progress
        /// </summary>
        [JsonProperty("progress")]
        public int Progress { get; set; }

        /// <summary>
        /// In case of error processing, it will contain the error details
        /// </summary>
        [JsonProperty("error")]
        public string Error
        {
            get
            {
                return this.error;
            }

            set
            {
                this.shouldSerialize["error"] = true;
                this.error = value;
            }
        }

        /// <summary>
        /// The date (in [Epoch Time](https://en.wikipedia.org/wiki/Unix_time)) this status register is set to expire. Usually 30 days after the request.
        /// </summary>
        [JsonProperty("ttl")]
        public long Ttl { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetError()
        {
            this.shouldSerialize["error"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeError()
        {
            return this.shouldSerialize["error"];
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

            return obj is Data other &&
                this.Code.Equals(other.Code) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.Progress.Equals(other.Progress) &&
                ((this.Error == null && other.Error == null) || (this.Error?.Equals(other.Error) == true)) &&
                this.Ttl.Equals(other.Ttl);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Code = {this.Code}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type == string.Empty ? "" : this.Type)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.Progress = {this.Progress}");
            toStringOutput.Add($"this.Error = {(this.Error == null ? "null" : this.Error == string.Empty ? "" : this.Error)}");
            toStringOutput.Add($"this.Ttl = {this.Ttl}");
        }
    }
}