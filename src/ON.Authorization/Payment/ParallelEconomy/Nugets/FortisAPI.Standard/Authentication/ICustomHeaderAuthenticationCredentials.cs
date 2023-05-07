// <copyright file="ICustomHeaderAuthenticationCredentials.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Authentication
{
    using System;

    public interface ICustomHeaderAuthenticationCredentials
    {
        /// <summary>
        /// Gets userId.
        /// </summary>
        string UserId { get; }

        /// <summary>
        /// Gets userApiKey.
        /// </summary>
        string UserApiKey { get; }

        /// <summary>
        /// Gets developerId.
        /// </summary>
        string DeveloperId { get; }

        /// <summary>
        ///  Returns true if credentials matched.
        /// </summary>
        bool Equals(string userId, string userApiKey, string developerId);
    }
}