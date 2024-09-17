// <copyright file="UserApiKeyManager.cs" company="APIMatic">
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
    /// UserApiKeyManager Class.
    /// </summary>
    internal class UserApiKeyManager : AuthManager, IUserApiKeyCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserApiKeyManager"/> class.
        /// </summary>
        /// <param name="userApiKey">UserApiKey.</param>
        public UserApiKeyManager(UserApiKeyModel userApiKeyModel)
        {
            UserApiKey = userApiKeyModel?.UserApiKey;
            Parameters(paramBuilder => paramBuilder
                .Header(header => header.Setup("user-api-key", UserApiKey).Required())
            );
        }

        /// <summary>
        /// Gets string value for userApiKey.
        /// </summary>
        public string UserApiKey { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="userApiKey"> The string value for credentials.</param>
        /// <returns> True if credentials matched.</returns>
        public bool Equals(string userApiKey)
        {
            return userApiKey.Equals(this.UserApiKey);
        }
    }

    public sealed class UserApiKeyModel
    {
        internal UserApiKeyModel()
        {
        }

        internal string UserApiKey { get; set; }

        /// <summary>
        /// Creates an object of the UserApiKeyModel using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            return new Builder(UserApiKey);
        }

        /// <summary>
        /// Builder class for UserApiKeyModel.
        /// </summary>
        public class Builder
        {
            private string userApiKey;

            public Builder(string userApiKey)
            {
                this.userApiKey = userApiKey ?? throw new ArgumentNullException(nameof(userApiKey));
            }

            /// <summary>
            /// Sets UserApiKey.
            /// </summary>
            /// <param name="userApiKey">UserApiKey.</param>
            /// <returns>Builder.</returns>
            public Builder UserApiKey(string userApiKey)
            {
                this.userApiKey = userApiKey ?? throw new ArgumentNullException(nameof(userApiKey));
                return this;
            }


            /// <summary>
            /// Creates an object of the UserApiKeyModel using the values provided for the builder.
            /// </summary>
            /// <returns>UserApiKeyModel.</returns>
            public UserApiKeyModel Build()
            {
                return new UserApiKeyModel()
                {
                    UserApiKey = this.userApiKey
                };
            }
        }
    }
    
}