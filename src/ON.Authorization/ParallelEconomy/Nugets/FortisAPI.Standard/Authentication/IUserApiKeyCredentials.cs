// <copyright file="IUserApiKeyCredentials.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Authentication
{
    using System;

    /// <summary>
    /// Authentication configuration interface for UserApiKey.
    /// </summary>
    public interface IUserApiKeyCredentials
    {
        /// <summary>
        /// Gets string value for userApiKey.
        /// </summary>
        string UserApiKey { get; }

        /// <summary>
        ///  Returns true if credentials matched.
        /// </summary>
        /// <param name="userApiKey"> The string value for credentials.</param>
        /// <returns>True if credentials matched.</returns>
        bool Equals(string userApiKey);
    }
}