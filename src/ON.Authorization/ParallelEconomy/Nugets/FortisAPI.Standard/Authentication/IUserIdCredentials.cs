// <copyright file="IUserIdCredentials.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Authentication
{
    using System;

    /// <summary>
    /// Authentication configuration interface for UserId.
    /// </summary>
    public interface IUserIdCredentials
    {
        /// <summary>
        /// Gets string value for userId.
        /// </summary>
        string UserId { get; }

        /// <summary>
        ///  Returns true if credentials matched.
        /// </summary>
        /// <param name="userId"> The string value for credentials.</param>
        /// <returns>True if credentials matched.</returns>
        bool Equals(string userId);
    }
}