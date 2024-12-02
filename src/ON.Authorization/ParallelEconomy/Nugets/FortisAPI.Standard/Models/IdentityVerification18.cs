// <copyright file="IdentityVerification18.cs" company="APIMatic">
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
    /// IdentityVerification18.
    /// </summary>
    public class IdentityVerification18 : BaseModel
    {
        private string ssn4;
        private string dobYear;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "ssn4", false },
            { "dob_year", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityVerification18"/> class.
        /// </summary>
        public IdentityVerification18()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityVerification18"/> class.
        /// </summary>
        /// <param name="dlState">dl_state.</param>
        /// <param name="dlNumber">dl_number.</param>
        /// <param name="ssn4">ssn4.</param>
        /// <param name="dobYear">dob_year.</param>
        public IdentityVerification18(
            string dlState,
            string dlNumber,
            string ssn4 = null,
            string dobYear = null)
        {
            this.DlState = dlState;
            this.DlNumber = dlNumber;
            if (ssn4 != null)
            {
                this.Ssn4 = ssn4;
            }

            if (dobYear != null)
            {
                this.DobYear = dobYear;
            }

        }

        /// <summary>
        /// Required for ACH transactions when Driver's License Verification is enabled on the terminal.  Either dl_number + dl_state OR customer_id will need to be passed in this scenario.
        /// </summary>
        [JsonProperty("dl_state")]
        public string DlState { get; set; }

        /// <summary>
        /// Required for ACH transactions when Driver's License Verification is enabled on the terminal.  Either dl_number + dl_state OR customer_id will need to be passed in this scenario.
        /// </summary>
        [JsonProperty("dl_number")]
        public string DlNumber { get; set; }

        /// <summary>
        /// For ACH transactions where Identity Verification is enabled for terminal. Only ssn4 or dob_year should be passed. not both.
        /// </summary>
        [JsonProperty("ssn4")]
        public string Ssn4
        {
            get
            {
                return this.ssn4;
            }

            set
            {
                this.shouldSerialize["ssn4"] = true;
                this.ssn4 = value;
            }
        }

        /// <summary>
        /// Required for certain ACH transactions where Identity Verification has been enabled for the terminal.  Either ssn4 or dob_year will need to be passed in this scenario but NOT BOTH.
        /// </summary>
        [JsonProperty("dob_year")]
        public string DobYear
        {
            get
            {
                return this.dobYear;
            }

            set
            {
                this.shouldSerialize["dob_year"] = true;
                this.dobYear = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"IdentityVerification18 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSsn4()
        {
            this.shouldSerialize["ssn4"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDobYear()
        {
            this.shouldSerialize["dob_year"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSsn4()
        {
            return this.shouldSerialize["ssn4"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDobYear()
        {
            return this.shouldSerialize["dob_year"];
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
            return obj is IdentityVerification18 other &&                ((this.DlState == null && other.DlState == null) || (this.DlState?.Equals(other.DlState) == true)) &&
                ((this.DlNumber == null && other.DlNumber == null) || (this.DlNumber?.Equals(other.DlNumber) == true)) &&
                ((this.Ssn4 == null && other.Ssn4 == null) || (this.Ssn4?.Equals(other.Ssn4) == true)) &&
                ((this.DobYear == null && other.DobYear == null) || (this.DobYear?.Equals(other.DobYear) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DlState = {(this.DlState == null ? "null" : this.DlState)}");
            toStringOutput.Add($"this.DlNumber = {(this.DlNumber == null ? "null" : this.DlNumber)}");
            toStringOutput.Add($"this.Ssn4 = {(this.Ssn4 == null ? "null" : this.Ssn4)}");
            toStringOutput.Add($"this.DobYear = {(this.DobYear == null ? "null" : this.DobYear)}");

            base.ToString(toStringOutput);
        }
    }
}