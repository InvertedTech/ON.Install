// <copyright file="IdentityVerification.cs" company="APIMatic">
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
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// IdentityVerification.
    /// </summary>
    public class IdentityVerification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityVerification"/> class.
        /// </summary>
        public IdentityVerification()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityVerification"/> class.
        /// </summary>
        /// <param name="dlState">dl_state.</param>
        /// <param name="dlNumber">dl_number.</param>
        /// <param name="ssn4">ssn4.</param>
        /// <param name="dobYear">dob_year.</param>
        public IdentityVerification(
            string dlState = null,
            string dlNumber = null,
            string ssn4 = null,
            string dobYear = null)
        {
            this.DlState = dlState;
            this.DlNumber = dlNumber;
            this.Ssn4 = ssn4;
            this.DobYear = dobYear;
        }

        /// <summary>
        /// Used for certain ACH transactions where Driver's License is required by the terminal being used.
        /// </summary>
        [JsonProperty("dl_state", NullValueHandling = NullValueHandling.Ignore)]
        public string DlState { get; set; }

        /// <summary>
        /// Used for certain ACH transactions where Driver's License is required by the terminal being used.
        /// </summary>
        [JsonProperty("dl_number", NullValueHandling = NullValueHandling.Ignore)]
        public string DlNumber { get; set; }

        /// <summary>
        /// The last four of the account_holder social security number.
        /// </summary>
        [JsonProperty("ssn4", NullValueHandling = NullValueHandling.Ignore)]
        public string Ssn4 { get; set; }

        /// <summary>
        /// Used for certain ACH transactions where Identity Verification is enabled on the terminal being used.
        /// </summary>
        [JsonProperty("dob_year", NullValueHandling = NullValueHandling.Ignore)]
        public string DobYear { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"IdentityVerification : ({string.Join(", ", toStringOutput)})";
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

            return obj is IdentityVerification other &&
                ((this.DlState == null && other.DlState == null) || (this.DlState?.Equals(other.DlState) == true)) &&
                ((this.DlNumber == null && other.DlNumber == null) || (this.DlNumber?.Equals(other.DlNumber) == true)) &&
                ((this.Ssn4 == null && other.Ssn4 == null) || (this.Ssn4?.Equals(other.Ssn4) == true)) &&
                ((this.DobYear == null && other.DobYear == null) || (this.DobYear?.Equals(other.DobYear) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DlState = {(this.DlState == null ? "null" : this.DlState == string.Empty ? "" : this.DlState)}");
            toStringOutput.Add($"this.DlNumber = {(this.DlNumber == null ? "null" : this.DlNumber == string.Empty ? "" : this.DlNumber)}");
            toStringOutput.Add($"this.Ssn4 = {(this.Ssn4 == null ? "null" : this.Ssn4 == string.Empty ? "" : this.Ssn4)}");
            toStringOutput.Add($"this.DobYear = {(this.DobYear == null ? "null" : this.DobYear == string.Empty ? "" : this.DobYear)}");
        }
    }
}