// <copyright file="IDeveloperIdCredentials.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Authentication
{
    using System;

    /// <summary>
    /// Authentication configuration interface for DeveloperId.
    /// </summary>
    public interface IDeveloperIdCredentials
    {
        /// <summary>
        /// Gets string value for developerId.
        /// </summary>
        string DeveloperId { get; }

        /// <summary>
        ///  Returns true if credentials matched.
        /// </summary>
        /// <param name="developerId"> The string value for credentials.</param>
        /// <returns>True if credentials matched.</returns>
        bool Equals(string developerId);
    }
}