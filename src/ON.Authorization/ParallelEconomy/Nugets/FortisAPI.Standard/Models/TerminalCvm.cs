// <copyright file="TerminalCvm.cs" company="APIMatic">
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
    /// TerminalCvm.
    /// </summary>
    public class TerminalCvm : BaseModel
    {
        private string contactData;
        private string contactlessData;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "contact_data", false },
            { "contactless_data", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalCvm"/> class.
        /// </summary>
        public TerminalCvm()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalCvm"/> class.
        /// </summary>
        /// <param name="terminalManufacturerCode">terminal_manufacturer_code.</param>
        /// <param name="title">title.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="modifiedUserId">modified_user_id.</param>
        /// <param name="contactData">contact_data.</param>
        /// <param name="contactlessData">contactless_data.</param>
        public TerminalCvm(
            double terminalManufacturerCode,
            string title,
            string id,
            int createdTs,
            int modifiedTs,
            string createdUserId,
            string modifiedUserId,
            string contactData = null,
            string contactlessData = null)
        {
            this.TerminalManufacturerCode = terminalManufacturerCode;
            this.Title = title;
            if (contactData != null)
            {
                this.ContactData = contactData;
            }

            if (contactlessData != null)
            {
                this.ContactlessData = contactlessData;
            }

            this.Id = id;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            this.CreatedUserId = createdUserId;
            this.ModifiedUserId = modifiedUserId;
        }

        /// <summary>
        /// Terminal Manufacturer Code
        /// </summary>
        [JsonProperty("terminal_manufacturer_code")]
        public double TerminalManufacturerCode { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Contact Data
        /// </summary>
        [JsonProperty("contact_data")]
        public string ContactData
        {
            get
            {
                return this.contactData;
            }

            set
            {
                this.shouldSerialize["contact_data"] = true;
                this.contactData = value;
            }
        }

        /// <summary>
        /// Contactless Data
        /// </summary>
        [JsonProperty("contactless_data")]
        public string ContactlessData
        {
            get
            {
                return this.contactlessData;
            }

            set
            {
                this.shouldSerialize["contactless_data"] = true;
                this.contactlessData = value;
            }
        }

        /// <summary>
        /// Terminal Manufacturer Cvms Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int CreatedTs { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts")]
        public int ModifiedTs { get; set; }

        /// <summary>
        /// User ID Created the register
        /// </summary>
        [JsonProperty("created_user_id")]
        public string CreatedUserId { get; set; }

        /// <summary>
        /// Last User ID that updated the register
        /// </summary>
        [JsonProperty("modified_user_id")]
        public string ModifiedUserId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TerminalCvm : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetContactData()
        {
            this.shouldSerialize["contact_data"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetContactlessData()
        {
            this.shouldSerialize["contactless_data"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeContactData()
        {
            return this.shouldSerialize["contact_data"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeContactlessData()
        {
            return this.shouldSerialize["contactless_data"];
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
            return obj is TerminalCvm other &&                this.TerminalManufacturerCode.Equals(other.TerminalManufacturerCode) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.ContactData == null && other.ContactData == null) || (this.ContactData?.Equals(other.ContactData) == true)) &&
                ((this.ContactlessData == null && other.ContactlessData == null) || (this.ContactlessData?.Equals(other.ContactlessData) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true)) &&
                ((this.ModifiedUserId == null && other.ModifiedUserId == null) || (this.ModifiedUserId?.Equals(other.ModifiedUserId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TerminalManufacturerCode = {this.TerminalManufacturerCode}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
            toStringOutput.Add($"this.ContactData = {(this.ContactData == null ? "null" : this.ContactData)}");
            toStringOutput.Add($"this.ContactlessData = {(this.ContactlessData == null ? "null" : this.ContactlessData)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");
            toStringOutput.Add($"this.ModifiedUserId = {(this.ModifiedUserId == null ? "null" : this.ModifiedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}