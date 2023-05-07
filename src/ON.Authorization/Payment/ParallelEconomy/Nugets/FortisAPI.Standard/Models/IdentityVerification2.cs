// <copyright file="IdentityVerification2.cs" company="APIMatic">
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
    /// IdentityVerification2.
    /// </summary>
    public class IdentityVerification2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityVerification2"/> class.
        /// </summary>
        public IdentityVerification2()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityVerification2"/> class.
        /// </summary>
        /// <param name="dlState">dl_state.</param>
        /// <param name="dlNumber">dl_number.</param>
        /// <param name="dobYear">dob_year.</param>
        public IdentityVerification2(
            string dlState = null,
            string dlNumber = null,
            string dobYear = null)
        {
            this.DlState = dlState;
            this.DlNumber = dlNumber;
            this.DobYear = dobYear;
        }

        /// <summary>
        /// Required for ACH transactions when Driver's License Verification is enabled on the terminal.  Either dl_number + dl_state OR customer_id will need to be passed in this scenario.
        /// </summary>
        [JsonProperty("dl_state", NullValueHandling = NullValueHandling.Ignore)]
        public string DlState { get; set; }

        /// <summary>
        /// Required for ACH transactions when Driver's License Verification is enabled on the terminal.  Either dl_number + dl_state OR customer_id will need to be passed in this scenario.
        /// </summary>
        [JsonProperty("dl_number", NullValueHandling = NullValueHandling.Ignore)]
        public string DlNumber { get; set; }

        /// <summary>
        /// Required for certain ACH transactions where Identity Verification has been enabled for the terminal.  Either ssn4 or dob_year will need to be passed in this scenario but NOT BOTH.
        /// </summary>
        [JsonProperty("dob_year", NullValueHandling = NullValueHandling.Ignore)]
        public string DobYear { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"IdentityVerification2 : ({string.Join(", ", toStringOutput)})";
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

            return obj is IdentityVerification2 other &&
                ((this.DlState == null && other.DlState == null) || (this.DlState?.Equals(other.DlState) == true)) &&
                ((this.DlNumber == null && other.DlNumber == null) || (this.DlNumber?.Equals(other.DlNumber) == true)) &&
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
            toStringOutput.Add($"this.DobYear = {(this.DobYear == null ? "null" : this.DobYear == string.Empty ? "" : this.DobYear)}");
        }
    }
}