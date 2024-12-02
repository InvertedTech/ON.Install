// <copyright file="Data15.cs" company="APIMatic">
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
    /// Data15.
    /// </summary>
    public class Data15 : BaseModel
    {
        private string emailLogId;
        private string smsLogId;
        private string email;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "email_log_id", false },
            { "sms_log_id", false },
            { "email", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Data15"/> class.
        /// </summary>
        public Data15()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data15"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="emailLogId">email_log_id.</param>
        /// <param name="smsLogId">sms_log_id.</param>
        /// <param name="success">success.</param>
        /// <param name="smsSuccess">sms_success.</param>
        /// <param name="email">email.</param>
        public Data15(
            string id,
            string emailLogId = null,
            string smsLogId = null,
            bool? success = null,
            bool? smsSuccess = null,
            string email = null)
        {
            this.Id = id;
            if (emailLogId != null)
            {
                this.EmailLogId = emailLogId;
            }

            if (smsLogId != null)
            {
                this.SmsLogId = smsLogId;
            }

            this.Success = success;
            this.SmsSuccess = smsSuccess;
            if (email != null)
            {
                this.Email = email;
            }

        }

        /// <summary>
        /// Quick Invoice ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Email Log Id
        /// </summary>
        [JsonProperty("email_log_id")]
        public string EmailLogId
        {
            get
            {
                return this.emailLogId;
            }

            set
            {
                this.shouldSerialize["email_log_id"] = true;
                this.emailLogId = value;
            }
        }

        /// <summary>
        /// SMS Log Id
        /// </summary>
        [JsonProperty("sms_log_id")]
        public string SmsLogId
        {
            get
            {
                return this.smsLogId;
            }

            set
            {
                this.shouldSerialize["sms_log_id"] = true;
                this.smsLogId = value;
            }
        }

        /// <summary>
        /// Success
        /// </summary>
        [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Success { get; set; }

        /// <summary>
        /// SMS Success
        /// </summary>
        [JsonProperty("sms_success", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SmsSuccess { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty("email")]
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.shouldSerialize["email"] = true;
                this.email = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data15 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEmailLogId()
        {
            this.shouldSerialize["email_log_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSmsLogId()
        {
            this.shouldSerialize["sms_log_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEmail()
        {
            this.shouldSerialize["email"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmailLogId()
        {
            return this.shouldSerialize["email_log_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSmsLogId()
        {
            return this.shouldSerialize["sms_log_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmail()
        {
            return this.shouldSerialize["email"];
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
            return obj is Data15 other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.EmailLogId == null && other.EmailLogId == null) || (this.EmailLogId?.Equals(other.EmailLogId) == true)) &&
                ((this.SmsLogId == null && other.SmsLogId == null) || (this.SmsLogId?.Equals(other.SmsLogId) == true)) &&
                ((this.Success == null && other.Success == null) || (this.Success?.Equals(other.Success) == true)) &&
                ((this.SmsSuccess == null && other.SmsSuccess == null) || (this.SmsSuccess?.Equals(other.SmsSuccess) == true)) &&
                ((this.Email == null && other.Email == null) || (this.Email?.Equals(other.Email) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.EmailLogId = {(this.EmailLogId == null ? "null" : this.EmailLogId)}");
            toStringOutput.Add($"this.SmsLogId = {(this.SmsLogId == null ? "null" : this.SmsLogId)}");
            toStringOutput.Add($"this.Success = {(this.Success == null ? "null" : this.Success.ToString())}");
            toStringOutput.Add($"this.SmsSuccess = {(this.SmsSuccess == null ? "null" : this.SmsSuccess.ToString())}");
            toStringOutput.Add($"this.Email = {(this.Email == null ? "null" : this.Email)}");

            base.ToString(toStringOutput);
        }
    }
}