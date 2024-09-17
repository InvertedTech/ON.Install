// <copyright file="User.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// User.
    /// </summary>
    public class User : BaseModel
    {
        private string id;
        private string username;
        private string firstName;
        private string lastName;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "id", false },
            { "username", false },
            { "first_name", false },
            { "last_name", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="username">username.</param>
        /// <param name="firstName">first_name.</param>
        /// <param name="lastName">last_name.</param>
        public User(
            string id = null,
            string username = null,
            string firstName = null,
            string lastName = null)
        {
            if (id != null)
            {
                this.Id = id;
            }

            if (username != null)
            {
                this.Username = username;
            }

            if (firstName != null)
            {
                this.FirstName = firstName;
            }

            if (lastName != null)
            {
                this.LastName = lastName;
            }

        }

        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id")]
        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.shouldSerialize["id"] = true;
                this.id = value;
            }
        }

        /// <summary>
        /// Username
        /// </summary>
        [JsonProperty("username")]
        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                this.shouldSerialize["username"] = true;
                this.username = value;
            }
        }

        /// <summary>
        /// First Name
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.shouldSerialize["first_name"] = true;
                this.firstName = value;
            }
        }

        /// <summary>
        /// Last Name
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.shouldSerialize["last_name"] = true;
                this.lastName = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"User : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetId()
        {
            this.shouldSerialize["id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetUsername()
        {
            this.shouldSerialize["username"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFirstName()
        {
            this.shouldSerialize["first_name"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLastName()
        {
            this.shouldSerialize["last_name"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeId()
        {
            return this.shouldSerialize["id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUsername()
        {
            return this.shouldSerialize["username"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFirstName()
        {
            return this.shouldSerialize["first_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLastName()
        {
            return this.shouldSerialize["last_name"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is User other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Username == null && other.Username == null) || (this.Username?.Equals(other.Username) == true)) &&
                ((this.FirstName == null && other.FirstName == null) || (this.FirstName?.Equals(other.FirstName) == true)) &&
                ((this.LastName == null && other.LastName == null) || (this.LastName?.Equals(other.LastName) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.Username = {(this.Username == null ? "null" : this.Username)}");
            toStringOutput.Add($"this.FirstName = {(this.FirstName == null ? "null" : this.FirstName)}");
            toStringOutput.Add($"this.LastName = {(this.LastName == null ? "null" : this.LastName)}");

            base.ToString(toStringOutput);
        }
    }
}