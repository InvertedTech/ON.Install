// <copyright file="Data5.cs" company="APIMatic">
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
    /// Data5.
    /// </summary>
    public class Data5 : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Data5"/> class.
        /// </summary>
        public Data5()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data5"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="emailLogId">email_log_id.</param>
        /// <param name="success">success.</param>
        /// <param name="email">email.</param>
        public Data5(
            string id = null,
            string emailLogId = null,
            bool? success = null,
            string email = null)
        {
            this.Id = id;
            this.EmailLogId = emailLogId;
            this.Success = success;
            this.Email = email;
        }

        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Email Log Id
        /// </summary>
        [JsonProperty("email_log_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailLogId { get; set; }

        /// <summary>
        /// Success
        /// </summary>
        [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Success { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data5 : ({string.Join(", ", toStringOutput)})";
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
            return obj is Data5 other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.EmailLogId == null && other.EmailLogId == null) || (this.EmailLogId?.Equals(other.EmailLogId) == true)) &&
                ((this.Success == null && other.Success == null) || (this.Success?.Equals(other.Success) == true)) &&
                ((this.Email == null && other.Email == null) || (this.Email?.Equals(other.Email) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.EmailLogId = {(this.EmailLogId == null ? "null" : this.EmailLogId)}");
            toStringOutput.Add($"this.Success = {(this.Success == null ? "null" : this.Success.ToString())}");
            toStringOutput.Add($"this.Email = {(this.Email == null ? "null" : this.Email)}");

            base.ToString(toStringOutput);
        }
    }
}