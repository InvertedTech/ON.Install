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
    using APIMatic.Core.Utilities.Converters;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// IdentityVerification.
    /// </summary>
    public class IdentityVerification : BaseModel
    {
        private string dlState;
        private string dlNumber;
        private string dobYear;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "dl_state", false },
            { "dl_number", false },
            { "dob_year", false },
        };

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
        /// <param name="dobYear">dob_year.</param>
        public IdentityVerification(
            string dlState = null,
            string dlNumber = null,
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

            if (dobYear != null)
            {
                this.DobYear = dobYear;
            }

        }

        /// <summary>
        /// Required for ACH transactions when Driver's License Verification is enabled on the terminal.  Either dl_number + dl_state OR customer_id will need to be passed in this scenario.
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
        /// Required for ACH transactions when Driver's License Verification is enabled on the terminal.  Either dl_number + dl_state OR customer_id will need to be passed in this scenario.
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

            return $"IdentityVerification : ({string.Join(", ", toStringOutput)})";
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
            return obj is IdentityVerification other &&                ((this.DlState == null && other.DlState == null) || (this.DlState?.Equals(other.DlState) == true)) &&
                ((this.DlNumber == null && other.DlNumber == null) || (this.DlNumber?.Equals(other.DlNumber) == true)) &&
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
            toStringOutput.Add($"this.DobYear = {(this.DobYear == null ? "null" : this.DobYear)}");

            base.ToString(toStringOutput);
        }
    }
}