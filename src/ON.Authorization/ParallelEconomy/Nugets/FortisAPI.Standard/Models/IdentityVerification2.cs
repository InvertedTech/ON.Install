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
    using APIMatic.Core.Utilities.Converters;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// IdentityVerification2.
    /// </summary>
    public class IdentityVerification2 : BaseModel
    {
        private string dlState;
        private string dlNumber;
        private string ssn4;
        private string dobYear;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "dl_state", false },
            { "dl_number", false },
            { "ssn4", false },
            { "dob_year", false },
        };

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
        /// <param name="ssn4">ssn4.</param>
        /// <param name="dobYear">dob_year.</param>
        public IdentityVerification2(
            string dlState = null,
            string dlNumber = null,
            string ssn4 = null,
            string dobYear = null)
        {
            if (dlState != null)
            {
                this.DlState = dlState;
            }

            if (dlNumber != null)
            {
                this.DlNumber = dlNumber;
            }

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
        /// Used for certain ACH transactions where Driver's License is required by the terminal being used.
        /// </summary>
        [JsonProperty("dl_state")]
        public string DlState
        {
            get
            {
                return this.dlState;
            }

            set
            {
                this.shouldSerialize["dl_state"] = true;
                this.dlState = value;
            }
        }

        /// <summary>
        /// Used for certain ACH transactions where Driver's License is required by the terminal being used.
        /// </summary>
        [JsonProperty("dl_number")]
        public string DlNumber
        {
            get
            {
                return this.dlNumber;
            }

            set
            {
                this.shouldSerialize["dl_number"] = true;
                this.dlNumber = value;
            }
        }

        /// <summary>
        /// The last four of the account_holder social security number.
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
        /// Used for certain ACH transactions where Identity Verification is enabled on the terminal being used.
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

            return $"IdentityVerification2 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDlState()
        {
            this.shouldSerialize["dl_state"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDlNumber()
        {
            this.shouldSerialize["dl_number"] = false;
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
        public bool ShouldSerializeDlState()
        {
            return this.shouldSerialize["dl_state"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDlNumber()
        {
            return this.shouldSerialize["dl_number"];
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
            return obj is IdentityVerification2 other &&                ((this.DlState == null && other.DlState == null) || (this.DlState?.Equals(other.DlState) == true)) &&
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