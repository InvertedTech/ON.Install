// <copyright file="UserIdManager.cs" company="APIMatic">
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
    /// UserIdManager Class.
    /// </summary>
    internal class UserIdManager : AuthManager, IUserIdCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserIdManager"/> class.
        /// </summary>
        /// <param name="userId">UserId.</param>
        public UserIdManager(UserIdModel userIdModel)
        {
            UserId = userIdModel?.UserId;
            Parameters(paramBuilder => paramBuilder
                .Header(header => header.Setup("user-id", UserId).Required())
            );
        }

        /// <summary>
        /// Gets string value for userId.
        /// </summary>
        public string UserId { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="userId"> The string value for credentials.</param>
        /// <returns> True if credentials matched.</returns>
        public bool Equals(string userId)
        {
            return userId.Equals(this.UserId);
        }
    }

    public sealed class UserIdModel
    {
        internal UserIdModel()
        {
        }

        internal string UserId { get; set; }

        /// <summary>
        /// Creates an object of the UserIdModel using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            return new Builder(UserId);
        }

        /// <summary>
        /// Builder class for UserIdModel.
        /// </summary>
        public class Builder
        {
            private string userId;

            public Builder(string userId)
            {
                this.userId = userId ?? throw new ArgumentNullException(nameof(userId));
            }

            /// <summary>
            /// Sets UserId.
            /// </summary>
            /// <param name="userId">UserId.</param>
            /// <returns>Builder.</returns>
            public Builder UserId(string userId)
            {
                this.userId = userId ?? throw new ArgumentNullException(nameof(userId));
                return this;
            }


            /// <summary>
            /// Creates an object of the UserIdModel using the values provided for the builder.
            /// </summary>
            /// <returns>UserIdModel.</returns>
            public UserIdModel Build()
            {
                return new UserIdModel()
                {
                    UserId = this.userId
                };
            }
        }
    }
    
}