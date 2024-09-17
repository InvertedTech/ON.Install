// <copyright file="AccessTokenManager.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FortisAPI.Standard.Http.Request;
    using APIMatic.Core.Authentication;

    /// <summary>
    /// AccessTokenManager Class.
    /// </summary>
    internal class AccessTokenManager : AuthManager, IAccessTokenCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessTokenManager"/> class.
        /// </summary>
        /// <param name="accessToken">AccessToken.</param>
        public AccessTokenManager(AccessTokenModel accessTokenModel)
        {
            AccessToken = accessTokenModel?.AccessToken;
            Parameters(paramBuilder => paramBuilder
                .Header(header => header.Setup("access-token", AccessToken).Required())
            );
        }

        /// <summary>
        /// Gets string value for accessToken.
        /// </summary>
        public string AccessToken { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="accessToken"> The string value for credentials.</param>
        /// <returns> True if credentials matched.</returns>
        public bool Equals(string accessToken)
        {
            return accessToken.Equals(this.AccessToken);
        }
    }

    public sealed class AccessTokenModel
    {
        internal AccessTokenModel()
        {
        }

        internal string AccessToken { get; set; }

        /// <summary>
        /// Creates an object of the AccessTokenModel using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            return new Builder(AccessToken);
        }

        /// <summary>
        /// Builder class for AccessTokenModel.
        /// </summary>
        public class Builder
        {
            private string accessToken;

            public Builder(string accessToken)
            {
                this.accessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
            }

            /// <summary>
            /// Sets AccessToken.
            /// </summary>
            /// <param name="accessToken">AccessToken.</param>
            /// <returns>Builder.</returns>
            public Builder AccessToken(string accessToken)
            {
                this.accessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
                return this;
            }


            /// <summary>
            /// Creates an object of the AccessTokenModel using the values provided for the builder.
            /// </summary>
            /// <returns>AccessTokenModel.</returns>
            public AccessTokenModel Build()
            {
                return new AccessTokenModel()
                {
                    AccessToken = this.accessToken
                };
            }
        }
    }
    
}