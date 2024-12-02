// <copyright file="DeveloperIdManager.cs" company="APIMatic">
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
    /// DeveloperIdManager Class.
    /// </summary>
    internal class DeveloperIdManager : AuthManager, IDeveloperIdCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeveloperIdManager"/> class.
        /// </summary>
        /// <param name="developerId">DeveloperId.</param>
        public DeveloperIdManager(DeveloperIdModel developerIdModel)
        {
            DeveloperId = developerIdModel?.DeveloperId;
            Parameters(paramBuilder => paramBuilder
                .Header(header => header.Setup("developer-id", DeveloperId).Required())
            );
        }

        /// <summary>
        /// Gets string value for developerId.
        /// </summary>
        public string DeveloperId { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="developerId"> The string value for credentials.</param>
        /// <returns> True if credentials matched.</returns>
        public bool Equals(string developerId)
        {
            return developerId.Equals(this.DeveloperId);
        }
    }

    public sealed class DeveloperIdModel
    {
        internal DeveloperIdModel()
        {
        }

        internal string DeveloperId { get; set; }

        /// <summary>
        /// Creates an object of the DeveloperIdModel using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            return new Builder(DeveloperId);
        }

        /// <summary>
        /// Builder class for DeveloperIdModel.
        /// </summary>
        public class Builder
        {
            private string developerId;

            public Builder(string developerId)
            {
                this.developerId = developerId ?? throw new ArgumentNullException(nameof(developerId));
            }

            /// <summary>
            /// Sets DeveloperId.
            /// </summary>
            /// <param name="developerId">DeveloperId.</param>
            /// <returns>Builder.</returns>
            public Builder DeveloperId(string developerId)
            {
                this.developerId = developerId ?? throw new ArgumentNullException(nameof(developerId));
                return this;
            }


            /// <summary>
            /// Creates an object of the DeveloperIdModel using the values provided for the builder.
            /// </summary>
            /// <returns>DeveloperIdModel.</returns>
            public DeveloperIdModel Build()
            {
                return new DeveloperIdModel()
                {
                    DeveloperId = this.developerId
                };
            }
        }
    }
    
}