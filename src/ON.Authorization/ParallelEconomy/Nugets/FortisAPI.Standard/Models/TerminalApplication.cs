// <copyright file="TerminalApplication.cs" company="APIMatic">
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
    /// TerminalApplication.
    /// </summary>
    public class TerminalApplication : BaseModel
    {
        private string title;
        private string description;
        private int? createdTs;
        private int? modifiedTs;
        private string createdUserId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "title", false },
            { "description", false },
            { "created_ts", false },
            { "modified_ts", false },
            { "created_user_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalApplication"/> class.
        /// </summary>
        public TerminalApplication()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalApplication"/> class.
        /// </summary>
        /// <param name="standalone">standalone.</param>
        /// <param name="emvCapable">emv_capable.</param>
        /// <param name="nfcCapable">nfc_capable.</param>
        /// <param name="pinCapable">pin_capable.</param>
        /// <param name="printCapable">print_capable.</param>
        /// <param name="msrCapable">msr_capable.</param>
        /// <param name="sigCaptureCapable">sig_capture_capable.</param>
        /// <param name="mposTerminal">mpos_terminal.</param>
        /// <param name="id">id.</param>
        /// <param name="title">title.</param>
        /// <param name="description">description.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="createdUserId">created_user_id.</param>
        public TerminalApplication(
            bool standalone,
            bool emvCapable,
            bool nfcCapable,
            bool pinCapable,
            bool printCapable,
            bool msrCapable,
            bool sigCaptureCapable,
            bool mposTerminal,
            string id,
            string title = null,
            string description = null,
            int? createdTs = null,
            int? modifiedTs = null,
            string createdUserId = null)
        {
            this.Standalone = standalone;
            this.EmvCapable = emvCapable;
            this.NfcCapable = nfcCapable;
            this.PinCapable = pinCapable;
            this.PrintCapable = printCapable;
            this.MsrCapable = msrCapable;
            this.SigCaptureCapable = sigCaptureCapable;
            this.MposTerminal = mposTerminal;
            if (title != null)
            {
                this.Title = title;
            }

            if (description != null)
            {
                this.Description = description;
            }

            this.Id = id;
            if (createdTs != null)
            {
                this.CreatedTs = createdTs;
            }

            if (modifiedTs != null)
            {
                this.ModifiedTs = modifiedTs;
            }

            if (createdUserId != null)
            {
                this.CreatedUserId = createdUserId;
            }

        }

        /// <summary>
        /// Standalone
        /// </summary>
        [JsonProperty("standalone")]
        public bool Standalone { get; set; }

        /// <summary>
        /// Emv Capable
        /// </summary>
        [JsonProperty("emv_capable")]
        public bool EmvCapable { get; set; }

        /// <summary>
        /// Nfc Capable
        /// </summary>
        [JsonProperty("nfc_capable")]
        public bool NfcCapable { get; set; }

        /// <summary>
        /// Pin Capable
        /// </summary>
        [JsonProperty("pin_capable")]
        public bool PinCapable { get; set; }

        /// <summary>
        /// Print Capable
        /// </summary>
        [JsonProperty("print_capable")]
        public bool PrintCapable { get; set; }

        /// <summary>
        /// Msr Capable
        /// </summary>
        [JsonProperty("msr_capable")]
        public bool MsrCapable { get; set; }

        /// <summary>
        /// Sig Capture Capable
        /// </summary>
        [JsonProperty("sig_capture_capable")]
        public bool SigCaptureCapable { get; set; }

        /// <summary>
        /// Mpos Terminal
        /// </summary>
        [JsonProperty("mpos_terminal")]
        public bool MposTerminal { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.shouldSerialize["title"] = true;
                this.title = value;
            }
        }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("description")]
        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                this.shouldSerialize["description"] = true;
                this.description = value;
            }
        }

        /// <summary>
        /// Terminal Application Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int? CreatedTs
        {
            get
            {
                return this.createdTs;
            }

            set
            {
                this.shouldSerialize["created_ts"] = true;
                this.createdTs = value;
            }
        }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts")]
        public int? ModifiedTs
        {
            get
            {
                return this.modifiedTs;
            }

            set
            {
                this.shouldSerialize["modified_ts"] = true;
                this.modifiedTs = value;
            }
        }

        /// <summary>
        /// User ID Created the register
        /// </summary>
        [JsonProperty("created_user_id")]
        public string CreatedUserId
        {
            get
            {
                return this.createdUserId;
            }

            set
            {
                this.shouldSerialize["created_user_id"] = true;
                this.createdUserId = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TerminalApplication : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTitle()
        {
            this.shouldSerialize["title"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDescription()
        {
            this.shouldSerialize["description"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCreatedTs()
        {
            this.shouldSerialize["created_ts"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetModifiedTs()
        {
            this.shouldSerialize["modified_ts"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCreatedUserId()
        {
            this.shouldSerialize["created_user_id"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTitle()
        {
            return this.shouldSerialize["title"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDescription()
        {
            return this.shouldSerialize["description"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCreatedTs()
        {
            return this.shouldSerialize["created_ts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModifiedTs()
        {
            return this.shouldSerialize["modified_ts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCreatedUserId()
        {
            return this.shouldSerialize["created_user_id"];
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
            return obj is TerminalApplication other &&                this.Standalone.Equals(other.Standalone) &&
                this.EmvCapable.Equals(other.EmvCapable) &&
                this.NfcCapable.Equals(other.NfcCapable) &&
                this.PinCapable.Equals(other.PinCapable) &&
                this.PrintCapable.Equals(other.PrintCapable) &&
                this.MsrCapable.Equals(other.MsrCapable) &&
                this.SigCaptureCapable.Equals(other.SigCaptureCapable) &&
                this.MposTerminal.Equals(other.MposTerminal) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.ModifiedTs == null && other.ModifiedTs == null) || (this.ModifiedTs?.Equals(other.ModifiedTs) == true)) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Standalone = {this.Standalone}");
            toStringOutput.Add($"this.EmvCapable = {this.EmvCapable}");
            toStringOutput.Add($"this.NfcCapable = {this.NfcCapable}");
            toStringOutput.Add($"this.PinCapable = {this.PinCapable}");
            toStringOutput.Add($"this.PrintCapable = {this.PrintCapable}");
            toStringOutput.Add($"this.MsrCapable = {this.MsrCapable}");
            toStringOutput.Add($"this.SigCaptureCapable = {this.SigCaptureCapable}");
            toStringOutput.Add($"this.MposTerminal = {this.MposTerminal}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.ModifiedTs = {(this.ModifiedTs == null ? "null" : this.ModifiedTs.ToString())}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}