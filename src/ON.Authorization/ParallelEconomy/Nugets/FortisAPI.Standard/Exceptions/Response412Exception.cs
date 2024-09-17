// <copyright file="Response412Exception.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Exceptions
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
    using FortisAPI.Standard.Http.Client;
    using FortisAPI.Standard.Models;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Response412Exception.
    /// </summary>
    public class Response412Exception : ApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Response412Exception"/> class.
        /// </summary>
        /// <param name="reason"> The reason for throwing exception.</param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects.</param>
        public Response412Exception(string reason, HttpContext context)
            : base(reason, context)
        {
        }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Response code
        /// </summary>
        [JsonProperty("statusCode", NullValueHandling = NullValueHandling.Ignore)]
        public int? StatusCode { get; set; }

        /// <summary>
        /// Error description
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// Error details
        /// </summary>
        [JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
        public string Detail { get; set; }

        /// <summary>
        /// Gets or sets Meta.
        /// </summary>
        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Meta Meta { get; set; }
    }
}