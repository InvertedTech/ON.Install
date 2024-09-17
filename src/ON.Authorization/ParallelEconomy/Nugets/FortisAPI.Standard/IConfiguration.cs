// <copyright file="IConfiguration.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard
{
    using System;
    using System.Net;
    using FortisAPI.Standard.Authentication;
    using FortisAPI.Standard.Models;

    /// <summary>
    /// IConfiguration.
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        /// Gets Current API environment.
        /// </summary>
        Environment Environment { get; }

        /// <summary>
        /// Gets the credentials to use with UserId.
        /// </summary>
        IUserIdCredentials UserIdCredentials { get; }

        /// <summary>
        /// Gets the credentials model to use with UserId.
        /// </summary>
        UserIdModel UserIdModel { get; }

        /// <summary>
        /// Gets the credentials to use with UserApiKey.
        /// </summary>
        IUserApiKeyCredentials UserApiKeyCredentials { get; }

        /// <summary>
        /// Gets the credentials model to use with UserApiKey.
        /// </summary>
        UserApiKeyModel UserApiKeyModel { get; }

        /// <summary>
        /// Gets the credentials to use with DeveloperId.
        /// </summary>
        IDeveloperIdCredentials DeveloperIdCredentials { get; }

        /// <summary>
        /// Gets the credentials model to use with DeveloperId.
        /// </summary>
        DeveloperIdModel DeveloperIdModel { get; }

        /// <summary>
        /// Gets the credentials to use with AccessToken.
        /// </summary>
        IAccessTokenCredentials AccessTokenCredentials { get; }

        /// <summary>
        /// Gets the credentials model to use with AccessToken.
        /// </summary>
        AccessTokenModel AccessTokenModel { get; }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        string GetBaseUri(Server alias = Server.Default);
    }
}