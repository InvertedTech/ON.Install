// <copyright file="TerminalTimeouts.cs" company="APIMatic">
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
    /// TerminalTimeouts.
    /// </summary>
    public class TerminalTimeouts : BaseModel
    {
        private int? cardEntryTimeout;
        private int? deviceTermsPromptTimeout;
        private int? overallTimeout;
        private int? pinEntryTimeout;
        private int? signatureInputTimeout;
        private int? signatureSubmitTimeout;
        private int? statusDisplayTime;
        private int? tipCashbackTimeout;
        private int? transactionTimeout;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "card_entry_timeout", true },
            { "device_terms_prompt_timeout", true },
            { "overall_timeout", true },
            { "pin_entry_timeout", true },
            { "signature_input_timeout", true },
            { "signature_submit_timeout", true },
            { "status_display_time", true },
            { "tip_cashback_timeout", true },
            { "transaction_timeout", true },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalTimeouts"/> class.
        /// </summary>
        public TerminalTimeouts()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalTimeouts"/> class.
        /// </summary>
        /// <param name="cardEntryTimeout">card_entry_timeout.</param>
        /// <param name="deviceTermsPromptTimeout">device_terms_prompt_timeout.</param>
        /// <param name="overallTimeout">overall_timeout.</param>
        /// <param name="pinEntryTimeout">pin_entry_timeout.</param>
        /// <param name="signatureInputTimeout">signature_input_timeout.</param>
        /// <param name="signatureSubmitTimeout">signature_submit_timeout.</param>
        /// <param name="statusDisplayTime">status_display_time.</param>
        /// <param name="tipCashbackTimeout">tip_cashback_timeout.</param>
        /// <param name="transactionTimeout">transaction_timeout.</param>
        public TerminalTimeouts(
            int? cardEntryTimeout = 120,
            int? deviceTermsPromptTimeout = 60,
            int? overallTimeout = 300,
            int? pinEntryTimeout = 30,
            int? signatureInputTimeout = 10,
            int? signatureSubmitTimeout = 30,
            int? statusDisplayTime = 7,
            int? tipCashbackTimeout = 30,
            int? transactionTimeout = 10)
        {
            this.CardEntryTimeout = cardEntryTimeout;
            this.DeviceTermsPromptTimeout = deviceTermsPromptTimeout;
            this.OverallTimeout = overallTimeout;
            this.PinEntryTimeout = pinEntryTimeout;
            this.SignatureInputTimeout = signatureInputTimeout;
            this.SignatureSubmitTimeout = signatureSubmitTimeout;
            this.StatusDisplayTime = statusDisplayTime;
            this.TipCashbackTimeout = tipCashbackTimeout;
            this.TransactionTimeout = transactionTimeout;
        }

        /// <summary>
        /// How long to wait for input from cardholder.
        /// </summary>
        [JsonProperty("card_entry_timeout")]
        public int? CardEntryTimeout
        {
            get
            {
                return this.cardEntryTimeout;
            }

            set
            {
                this.shouldSerialize["card_entry_timeout"] = true;
                this.cardEntryTimeout = value;
            }
        }

        /// <summary>
        /// How long the terms will be displayed on the device.
        /// </summary>
        [JsonProperty("device_terms_prompt_timeout")]
        public int? DeviceTermsPromptTimeout
        {
            get
            {
                return this.deviceTermsPromptTimeout;
            }

            set
            {
                this.shouldSerialize["device_terms_prompt_timeout"] = true;
                this.deviceTermsPromptTimeout = value;
            }
        }

        /// <summary>
        /// How long to wait for response from /v2/routertransactions endpoint.
        /// </summary>
        [JsonProperty("overall_timeout")]
        public int? OverallTimeout
        {
            get
            {
                return this.overallTimeout;
            }

            set
            {
                this.shouldSerialize["overall_timeout"] = true;
                this.overallTimeout = value;
            }
        }

        /// <summary>
        /// How long to wait for pin entry by cardholder.
        /// </summary>
        [JsonProperty("pin_entry_timeout")]
        public int? PinEntryTimeout
        {
            get
            {
                return this.pinEntryTimeout;
            }

            set
            {
                this.shouldSerialize["pin_entry_timeout"] = true;
                this.pinEntryTimeout = value;
            }
        }

        /// <summary>
        /// How long to wait for first "touch" to signature.
        /// </summary>
        [JsonProperty("signature_input_timeout")]
        public int? SignatureInputTimeout
        {
            get
            {
                return this.signatureInputTimeout;
            }

            set
            {
                this.shouldSerialize["signature_input_timeout"] = true;
                this.signatureInputTimeout = value;
            }
        }

        /// <summary>
        /// How long to wait for signature to be submitted.
        /// </summary>
        [JsonProperty("signature_submit_timeout")]
        public int? SignatureSubmitTimeout
        {
            get
            {
                return this.signatureSubmitTimeout;
            }

            set
            {
                this.shouldSerialize["signature_submit_timeout"] = true;
                this.signatureSubmitTimeout = value;
            }
        }

        /// <summary>
        /// How long the approve/decline status message stays on screen.
        /// </summary>
        [JsonProperty("status_display_time")]
        public int? StatusDisplayTime
        {
            get
            {
                return this.statusDisplayTime;
            }

            set
            {
                this.shouldSerialize["status_display_time"] = true;
                this.statusDisplayTime = value;
            }
        }

        /// <summary>
        /// How long to wait for input on a tip or cashback screen.
        /// </summary>
        [JsonProperty("tip_cashback_timeout")]
        public int? TipCashbackTimeout
        {
            get
            {
                return this.tipCashbackTimeout;
            }

            set
            {
                this.shouldSerialize["tip_cashback_timeout"] = true;
                this.tipCashbackTimeout = value;
            }
        }

        /// <summary>
        /// How long to wait for response from the processor.
        /// </summary>
        [JsonProperty("transaction_timeout")]
        public int? TransactionTimeout
        {
            get
            {
                return this.transactionTimeout;
            }

            set
            {
                this.shouldSerialize["transaction_timeout"] = true;
                this.transactionTimeout = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TerminalTimeouts : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCardEntryTimeout()
        {
            this.shouldSerialize["card_entry_timeout"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDeviceTermsPromptTimeout()
        {
            this.shouldSerialize["device_terms_prompt_timeout"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetOverallTimeout()
        {
            this.shouldSerialize["overall_timeout"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPinEntryTimeout()
        {
            this.shouldSerialize["pin_entry_timeout"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSignatureInputTimeout()
        {
            this.shouldSerialize["signature_input_timeout"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSignatureSubmitTimeout()
        {
            this.shouldSerialize["signature_submit_timeout"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetStatusDisplayTime()
        {
            this.shouldSerialize["status_display_time"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTipCashbackTimeout()
        {
            this.shouldSerialize["tip_cashback_timeout"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTransactionTimeout()
        {
            this.shouldSerialize["transaction_timeout"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCardEntryTimeout()
        {
            return this.shouldSerialize["card_entry_timeout"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDeviceTermsPromptTimeout()
        {
            return this.shouldSerialize["device_terms_prompt_timeout"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOverallTimeout()
        {
            return this.shouldSerialize["overall_timeout"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePinEntryTimeout()
        {
            return this.shouldSerialize["pin_entry_timeout"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSignatureInputTimeout()
        {
            return this.shouldSerialize["signature_input_timeout"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSignatureSubmitTimeout()
        {
            return this.shouldSerialize["signature_submit_timeout"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStatusDisplayTime()
        {
            return this.shouldSerialize["status_display_time"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTipCashbackTimeout()
        {
            return this.shouldSerialize["tip_cashback_timeout"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTransactionTimeout()
        {
            return this.shouldSerialize["transaction_timeout"];
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
            return obj is TerminalTimeouts other &&                ((this.CardEntryTimeout == null && other.CardEntryTimeout == null) || (this.CardEntryTimeout?.Equals(other.CardEntryTimeout) == true)) &&
                ((this.DeviceTermsPromptTimeout == null && other.DeviceTermsPromptTimeout == null) || (this.DeviceTermsPromptTimeout?.Equals(other.DeviceTermsPromptTimeout) == true)) &&
                ((this.OverallTimeout == null && other.OverallTimeout == null) || (this.OverallTimeout?.Equals(other.OverallTimeout) == true)) &&
                ((this.PinEntryTimeout == null && other.PinEntryTimeout == null) || (this.PinEntryTimeout?.Equals(other.PinEntryTimeout) == true)) &&
                ((this.SignatureInputTimeout == null && other.SignatureInputTimeout == null) || (this.SignatureInputTimeout?.Equals(other.SignatureInputTimeout) == true)) &&
                ((this.SignatureSubmitTimeout == null && other.SignatureSubmitTimeout == null) || (this.SignatureSubmitTimeout?.Equals(other.SignatureSubmitTimeout) == true)) &&
                ((this.StatusDisplayTime == null && other.StatusDisplayTime == null) || (this.StatusDisplayTime?.Equals(other.StatusDisplayTime) == true)) &&
                ((this.TipCashbackTimeout == null && other.TipCashbackTimeout == null) || (this.TipCashbackTimeout?.Equals(other.TipCashbackTimeout) == true)) &&
                ((this.TransactionTimeout == null && other.TransactionTimeout == null) || (this.TransactionTimeout?.Equals(other.TransactionTimeout) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CardEntryTimeout = {(this.CardEntryTimeout == null ? "null" : this.CardEntryTimeout.ToString())}");
            toStringOutput.Add($"this.DeviceTermsPromptTimeout = {(this.DeviceTermsPromptTimeout == null ? "null" : this.DeviceTermsPromptTimeout.ToString())}");
            toStringOutput.Add($"this.OverallTimeout = {(this.OverallTimeout == null ? "null" : this.OverallTimeout.ToString())}");
            toStringOutput.Add($"this.PinEntryTimeout = {(this.PinEntryTimeout == null ? "null" : this.PinEntryTimeout.ToString())}");
            toStringOutput.Add($"this.SignatureInputTimeout = {(this.SignatureInputTimeout == null ? "null" : this.SignatureInputTimeout.ToString())}");
            toStringOutput.Add($"this.SignatureSubmitTimeout = {(this.SignatureSubmitTimeout == null ? "null" : this.SignatureSubmitTimeout.ToString())}");
            toStringOutput.Add($"this.StatusDisplayTime = {(this.StatusDisplayTime == null ? "null" : this.StatusDisplayTime.ToString())}");
            toStringOutput.Add($"this.TipCashbackTimeout = {(this.TipCashbackTimeout == null ? "null" : this.TipCashbackTimeout.ToString())}");
            toStringOutput.Add($"this.TransactionTimeout = {(this.TransactionTimeout == null ? "null" : this.TransactionTimeout.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}