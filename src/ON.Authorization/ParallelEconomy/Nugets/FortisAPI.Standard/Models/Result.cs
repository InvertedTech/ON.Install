// <copyright file="Result.cs" company="APIMatic">
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
    /// Result.
    /// </summary>
    public class Result : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        public Result()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="clientAppId">client_app_id.</param>
        /// <param name="epicAppId">epic_app_id.</param>
        /// <param name="dbaName">dba_name.</param>
        /// <param name="email">email.</param>
        public Result(
            string clientAppId = null,
            string epicAppId = null,
            string dbaName = null,
            string email = null)
        {
            this.ClientAppId = clientAppId;
            this.EpicAppId = epicAppId;
            this.DbaName = dbaName;
            this.Email = email;
        }

        /// <summary>
        /// Client Issues Id to track that can be used to track each submitted merchant application. This id should be generated and sent in the request payload, and will be returned in the response payload. If no id is submitted in the payload request, this field will be null in the response.
        /// </summary>
        [JsonProperty("client_app_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientAppId { get; set; }

        /// <summary>
        /// Internal application ID returned from a successful request.
        /// </summary>
        [JsonProperty("epic_app_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EpicAppId { get; set; }

        /// <summary>
        /// Merchant 'Doing Business As' name.
        /// </summary>
        [JsonProperty("dba_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DbaName { get; set; }

        /// <summary>
        /// Merchant email address.
        /// </summary>
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Result : ({string.Join(", ", toStringOutput)})";
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
            return obj is Result other &&                ((this.ClientAppId == null && other.ClientAppId == null) || (this.ClientAppId?.Equals(other.ClientAppId) == true)) &&
                ((this.EpicAppId == null && other.EpicAppId == null) || (this.EpicAppId?.Equals(other.EpicAppId) == true)) &&
                ((this.DbaName == null && other.DbaName == null) || (this.DbaName?.Equals(other.DbaName) == true)) &&
                ((this.Email == null && other.Email == null) || (this.Email?.Equals(other.Email) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ClientAppId = {(this.ClientAppId == null ? "null" : this.ClientAppId)}");
            toStringOutput.Add($"this.EpicAppId = {(this.EpicAppId == null ? "null" : this.EpicAppId)}");
            toStringOutput.Add($"this.DbaName = {(this.DbaName == null ? "null" : this.DbaName)}");
            toStringOutput.Add($"this.Email = {(this.Email == null ? "null" : this.Email)}");

            base.ToString(toStringOutput);
        }
    }
}