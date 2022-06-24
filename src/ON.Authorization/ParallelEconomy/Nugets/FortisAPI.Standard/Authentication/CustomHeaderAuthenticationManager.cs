// <copyright file="CustomHeaderAuthenticationManager.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FortisAPI.Standard.Http.Request;

    /// <summary>
    /// CustomHeaderAuthenticationManager Class.
    /// </summary>
    internal class CustomHeaderAuthenticationManager : ICustomHeaderAuthenticationCredentials, IAuthManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomHeaderAuthenticationManager"/> class.
        /// </summary>
        /// <param name="userId">user-id.</param>
        /// <param name="userApiKey">user-api-key.</param>
        /// <param name="developerId">developer-id.</param>
        public CustomHeaderAuthenticationManager(string userId, string userApiKey, string developerId)
        {
            this.UserId = userId;
            this.UserApiKey = userApiKey;
            this.DeveloperId = developerId;
        }

        /// <summary>
        /// Gets userId.
        /// </summary>
        public string UserId { get; }

        /// <summary>
        /// Gets userApiKey.
        /// </summary>
        public string UserApiKey { get; }

        /// <summary>
        /// Gets developerId.
        /// </summary>
        public string DeveloperId { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="userId"> user-id.</param>
        /// <param name="userApiKey"> user-api-key.</param>
        /// <param name="developerId"> developer-id.</param>
        /// <returns> The boolean value.</returns>
        public bool Equals(string userId, string userApiKey, string developerId)
        {
            return userId.Equals(this.UserId)
                    && userApiKey.Equals(this.UserApiKey)
                    && developerId.Equals(this.DeveloperId);
        }

        /// <summary>
        /// Adds authentication to the given HttpRequest.
        /// </summary>
        /// <param name="httpRequest">Http Request.</param>
        /// <returns>Returns the httpRequest after adding authentication.</returns>
        public HttpRequest Apply(HttpRequest httpRequest)
        {
            httpRequest.AddHeaders(new Dictionary<string, string>
            {
                { "user-id", this.UserId },
                { "user-api-key", this.UserApiKey },
                { "developer-id", this.DeveloperId },
            });
            return httpRequest;
        }

        /// <summary>
        /// Adds authentication to the given HttpRequest.
        /// </summary>
        /// <param name="httpRequest">Http Request.</param>
        /// <returns>Returns the httpRequest after adding authentication.</returns>
        public Task<HttpRequest> ApplyAsync(HttpRequest httpRequest)
        {
            return Task.FromResult(this.Apply(httpRequest));
        }
    }
}