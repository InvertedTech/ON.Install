// <copyright file="Sort9.cs" company="APIMatic">
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
    /// Sort9.
    /// </summary>
    public class Sort9
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sort9"/> class.
        /// </summary>
        public Sort9()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sort9"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="defaultProductTransactionId">default_product_transaction_id.</param>
        /// <param name="terminalApplicationId">terminal_application_id.</param>
        /// <param name="terminalCvmId">terminal_cvm_id.</param>
        /// <param name="terminalManufacturerCode">terminal_manufacturer_code.</param>
        /// <param name="title">title.</param>
        /// <param name="macAddress">mac_address.</param>
        /// <param name="localIpAddress">local_ip_address.</param>
        /// <param name="port">port.</param>
        /// <param name="serialNumber">serial_number.</param>
        /// <param name="terminalNumber">terminal_number.</param>
        /// <param name="terminalTimeouts">terminal_timeouts.</param>
        /// <param name="tipPercents">tip_percents.</param>
        /// <param name="locationApiId">location_api_id.</param>
        /// <param name="terminalApiId">terminal_api_id.</param>
        /// <param name="headerLine1">header_line_1.</param>
        /// <param name="headerLine2">header_line_2.</param>
        /// <param name="headerLine3">header_line_3.</param>
        /// <param name="headerLine4">header_line_4.</param>
        /// <param name="headerLine5">header_line_5.</param>
        /// <param name="trailerLine1">trailer_line_1.</param>
        /// <param name="trailerLine2">trailer_line_2.</param>
        /// <param name="trailerLine3">trailer_line_3.</param>
        /// <param name="trailerLine4">trailer_line_4.</param>
        /// <param name="trailerLine5">trailer_line_5.</param>
        /// <param name="defaultCheckin">default_checkin.</param>
        /// <param name="defaultCheckout">default_checkout.</param>
        /// <param name="defaultRoomRate">default_room_rate.</param>
        /// <param name="defaultRoomNumber">default_room_number.</param>
        /// <param name="debit">debit.</param>
        /// <param name="emv">emv.</param>
        /// <param name="cashbackEnable">cashback_enable.</param>
        /// <param name="printEnable">print_enable.</param>
        /// <param name="sigCaptureEnable">sig_capture_enable.</param>
        /// <param name="isProvisioned">is_provisioned.</param>
        /// <param name="tipEnable">tip_enable.</param>
        /// <param name="validatedDecryption">validated_decryption.</param>
        /// <param name="communicationType">communication_type.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="lastRegistrationTs">last_registration_ts.</param>
        /// <param name="createdUserId">created_user_id.</param>
        /// <param name="modifiedUserId">modified_user_id.</param>
        public Sort9(
            string locationId = null,
            string defaultProductTransactionId = null,
            string terminalApplicationId = null,
            string terminalCvmId = null,
            Models.TerminalManufacturerCodeEnum? terminalManufacturerCode = null,
            string title = null,
            string macAddress = null,
            string localIpAddress = null,
            int? port = 10009,
            string serialNumber = null,
            string terminalNumber = null,
            Models.TerminalTimeouts terminalTimeouts = null,
            Models.TipPercents tipPercents = null,
            string locationApiId = null,
            string terminalApiId = null,
            string headerLine1 = null,
            string headerLine2 = null,
            string headerLine3 = null,
            string headerLine4 = null,
            string headerLine5 = null,
            string trailerLine1 = null,
            string trailerLine2 = null,
            string trailerLine3 = null,
            string trailerLine4 = null,
            string trailerLine5 = null,
            string defaultCheckin = null,
            string defaultCheckout = null,
            double? defaultRoomRate = null,
            string defaultRoomNumber = null,
            bool? debit = null,
            bool? emv = null,
            bool? cashbackEnable = null,
            bool? printEnable = null,
            bool? sigCaptureEnable = null,
            bool? isProvisioned = null,
            bool? tipEnable = null,
            bool? validatedDecryption = null,
            Models.CommunicationTypeEnum? communicationType = null,
            string id = null,
            int? createdTs = null,
            int? modifiedTs = null,
            int? lastRegistrationTs = null,
            string createdUserId = null,
            string modifiedUserId = null)
        {
            this.LocationId = locationId;
            this.DefaultProductTransactionId = defaultProductTransactionId;
            this.TerminalApplicationId = terminalApplicationId;
            this.TerminalCvmId = terminalCvmId;
            this.TerminalManufacturerCode = terminalManufacturerCode;
            this.Title = title;
            this.MacAddress = macAddress;
            this.LocalIpAddress = localIpAddress;
            this.Port = port;
            this.SerialNumber = serialNumber;
            this.TerminalNumber = terminalNumber;
            this.TerminalTimeouts = terminalTimeouts;
            this.TipPercents = tipPercents;
            this.LocationApiId = locationApiId;
            this.TerminalApiId = terminalApiId;
            this.HeaderLine1 = headerLine1;
            this.HeaderLine2 = headerLine2;
            this.HeaderLine3 = headerLine3;
            this.HeaderLine4 = headerLine4;
            this.HeaderLine5 = headerLine5;
            this.TrailerLine1 = trailerLine1;
            this.TrailerLine2 = trailerLine2;
            this.TrailerLine3 = trailerLine3;
            this.TrailerLine4 = trailerLine4;
            this.TrailerLine5 = trailerLine5;
            this.DefaultCheckin = defaultCheckin;
            this.DefaultCheckout = defaultCheckout;
            this.DefaultRoomRate = defaultRoomRate;
            this.DefaultRoomNumber = defaultRoomNumber;
            this.Debit = debit;
            this.Emv = emv;
            this.CashbackEnable = cashbackEnable;
            this.PrintEnable = printEnable;
            this.SigCaptureEnable = sigCaptureEnable;
            this.IsProvisioned = isProvisioned;
            this.TipEnable = tipEnable;
            this.ValidatedDecryption = validatedDecryption;
            this.CommunicationType = communicationType;
            this.Id = id;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            this.LastRegistrationTs = lastRegistrationTs;
            this.CreatedUserId = createdUserId;
            this.ModifiedUserId = modifiedUserId;
        }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; set; }

        /// <summary>
        /// Product Transaction ID
        /// </summary>
        [JsonProperty("default_product_transaction_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultProductTransactionId { get; set; }

        /// <summary>
        /// Terminal Application ID
        /// </summary>
        [JsonProperty("terminal_application_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TerminalApplicationId { get; set; }

        /// <summary>
        /// Terminal CVM ID
        /// </summary>
        [JsonProperty("terminal_cvm_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TerminalCvmId { get; set; }

        /// <summary>
        /// Terminal Manufacturer Code
        /// </summary>
        [JsonProperty("terminal_manufacturer_code", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalManufacturerCodeEnum? TerminalManufacturerCode { get; set; }

        /// <summary>
        /// Terminal Name
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// Terminal MAC Address
        /// </summary>
        [JsonProperty("mac_address", NullValueHandling = NullValueHandling.Ignore)]
        public string MacAddress { get; set; }

        /// <summary>
        /// Terminal Local IP Address
        /// </summary>
        [JsonProperty("local_ip_address", NullValueHandling = NullValueHandling.Ignore)]
        public string LocalIpAddress { get; set; }

        /// <summary>
        /// Terminal Port
        /// </summary>
        [JsonProperty("port", NullValueHandling = NullValueHandling.Ignore)]
        public int? Port { get; set; }

        /// <summary>
        /// Terminal Serial Number
        /// </summary>
        [JsonProperty("serial_number", NullValueHandling = NullValueHandling.Ignore)]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Terminal Number
        /// </summary>
        [JsonProperty("terminal_number", NullValueHandling = NullValueHandling.Ignore)]
        public string TerminalNumber { get; set; }

        /// <summary>
        /// The following options outlines some configurable timeout values that can be used to customize the experience at the terminal for the cardholder.
        /// </summary>
        [JsonProperty("terminal_timeouts", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalTimeouts TerminalTimeouts { get; set; }

        /// <summary>
        /// A JSON of tip percents the JSON MUST contain only these three fields: percent_1, percent_2, percent_3
        /// </summary>
        [JsonProperty("tip_percents", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TipPercents TipPercents { get; set; }

        /// <summary>
        /// Location Api ID
        /// </summary>
        [JsonProperty("location_api_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationApiId { get; set; }

        /// <summary>
        /// Terminal Api ID
        /// </summary>
        [JsonProperty("terminal_api_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TerminalApiId { get; set; }

        /// <summary>
        /// Header Line 1
        /// </summary>
        [JsonProperty("header_line_1", NullValueHandling = NullValueHandling.Ignore)]
        public string HeaderLine1 { get; set; }

        /// <summary>
        /// Header Line 2
        /// </summary>
        [JsonProperty("header_line_2", NullValueHandling = NullValueHandling.Ignore)]
        public string HeaderLine2 { get; set; }

        /// <summary>
        /// Header Line 3
        /// </summary>
        [JsonProperty("header_line_3", NullValueHandling = NullValueHandling.Ignore)]
        public string HeaderLine3 { get; set; }

        /// <summary>
        /// Header Line 4
        /// </summary>
        [JsonProperty("header_line_4", NullValueHandling = NullValueHandling.Ignore)]
        public string HeaderLine4 { get; set; }

        /// <summary>
        /// Header Line 5
        /// </summary>
        [JsonProperty("header_line_5", NullValueHandling = NullValueHandling.Ignore)]
        public string HeaderLine5 { get; set; }

        /// <summary>
        /// Trailer Line 1
        /// </summary>
        [JsonProperty("trailer_line_1", NullValueHandling = NullValueHandling.Ignore)]
        public string TrailerLine1 { get; set; }

        /// <summary>
        /// Trailer Line 2
        /// </summary>
        [JsonProperty("trailer_line_2", NullValueHandling = NullValueHandling.Ignore)]
        public string TrailerLine2 { get; set; }

        /// <summary>
        /// Trailer Line 3
        /// </summary>
        [JsonProperty("trailer_line_3", NullValueHandling = NullValueHandling.Ignore)]
        public string TrailerLine3 { get; set; }

        /// <summary>
        /// Trailer Line 4
        /// </summary>
        [JsonProperty("trailer_line_4", NullValueHandling = NullValueHandling.Ignore)]
        public string TrailerLine4 { get; set; }

        /// <summary>
        /// Trailer Line 5
        /// </summary>
        [JsonProperty("trailer_line_5", NullValueHandling = NullValueHandling.Ignore)]
        public string TrailerLine5 { get; set; }

        /// <summary>
        /// Default Checkin
        /// </summary>
        [JsonProperty("default_checkin", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultCheckin { get; set; }

        /// <summary>
        /// Default Checkout
        /// </summary>
        [JsonProperty("default_checkout", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultCheckout { get; set; }

        /// <summary>
        /// Default Room Rate
        /// </summary>
        [JsonProperty("default_room_rate", NullValueHandling = NullValueHandling.Ignore)]
        public double? DefaultRoomRate { get; set; }

        /// <summary>
        /// Default Room Number
        /// </summary>
        [JsonProperty("default_room_number", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultRoomNumber { get; set; }

        /// <summary>
        /// Debit
        /// </summary>
        [JsonProperty("debit", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Debit { get; set; }

        /// <summary>
        /// EMV
        /// </summary>
        [JsonProperty("emv", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Emv { get; set; }

        /// <summary>
        /// Cashback Enable
        /// </summary>
        [JsonProperty("cashback_enable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CashbackEnable { get; set; }

        /// <summary>
        /// Print Enable
        /// </summary>
        [JsonProperty("print_enable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PrintEnable { get; set; }

        /// <summary>
        /// Sig Capture Enable
        /// </summary>
        [JsonProperty("sig_capture_enable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SigCaptureEnable { get; set; }

        /// <summary>
        /// Is Provisioned
        /// </summary>
        [JsonProperty("is_provisioned", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsProvisioned { get; set; }

        /// <summary>
        /// Tip Enable
        /// </summary>
        [JsonProperty("tip_enable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TipEnable { get; set; }

        /// <summary>
        /// Validated Decryption
        /// </summary>
        [JsonProperty("validated_decryption", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ValidatedDecryption { get; set; }

        /// <summary>
        /// Communication Type
        /// </summary>
        [JsonProperty("communication_type", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.CommunicationTypeEnum? CommunicationType { get; set; }

        /// <summary>
        /// Terminal ID
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? CreatedTs { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? ModifiedTs { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("last_registration_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? LastRegistrationTs { get; set; }

        /// <summary>
        /// User ID Created the register
        /// </summary>
        [JsonProperty("created_user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedUserId { get; set; }

        /// <summary>
        /// Last User ID that updated the register
        /// </summary>
        [JsonProperty("modified_user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ModifiedUserId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Sort9 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Sort9 other &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.DefaultProductTransactionId == null && other.DefaultProductTransactionId == null) || (this.DefaultProductTransactionId?.Equals(other.DefaultProductTransactionId) == true)) &&
                ((this.TerminalApplicationId == null && other.TerminalApplicationId == null) || (this.TerminalApplicationId?.Equals(other.TerminalApplicationId) == true)) &&
                ((this.TerminalCvmId == null && other.TerminalCvmId == null) || (this.TerminalCvmId?.Equals(other.TerminalCvmId) == true)) &&
                ((this.TerminalManufacturerCode == null && other.TerminalManufacturerCode == null) || (this.TerminalManufacturerCode?.Equals(other.TerminalManufacturerCode) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.MacAddress == null && other.MacAddress == null) || (this.MacAddress?.Equals(other.MacAddress) == true)) &&
                ((this.LocalIpAddress == null && other.LocalIpAddress == null) || (this.LocalIpAddress?.Equals(other.LocalIpAddress) == true)) &&
                ((this.Port == null && other.Port == null) || (this.Port?.Equals(other.Port) == true)) &&
                ((this.SerialNumber == null && other.SerialNumber == null) || (this.SerialNumber?.Equals(other.SerialNumber) == true)) &&
                ((this.TerminalNumber == null && other.TerminalNumber == null) || (this.TerminalNumber?.Equals(other.TerminalNumber) == true)) &&
                ((this.TerminalTimeouts == null && other.TerminalTimeouts == null) || (this.TerminalTimeouts?.Equals(other.TerminalTimeouts) == true)) &&
                ((this.TipPercents == null && other.TipPercents == null) || (this.TipPercents?.Equals(other.TipPercents) == true)) &&
                ((this.LocationApiId == null && other.LocationApiId == null) || (this.LocationApiId?.Equals(other.LocationApiId) == true)) &&
                ((this.TerminalApiId == null && other.TerminalApiId == null) || (this.TerminalApiId?.Equals(other.TerminalApiId) == true)) &&
                ((this.HeaderLine1 == null && other.HeaderLine1 == null) || (this.HeaderLine1?.Equals(other.HeaderLine1) == true)) &&
                ((this.HeaderLine2 == null && other.HeaderLine2 == null) || (this.HeaderLine2?.Equals(other.HeaderLine2) == true)) &&
                ((this.HeaderLine3 == null && other.HeaderLine3 == null) || (this.HeaderLine3?.Equals(other.HeaderLine3) == true)) &&
                ((this.HeaderLine4 == null && other.HeaderLine4 == null) || (this.HeaderLine4?.Equals(other.HeaderLine4) == true)) &&
                ((this.HeaderLine5 == null && other.HeaderLine5 == null) || (this.HeaderLine5?.Equals(other.HeaderLine5) == true)) &&
                ((this.TrailerLine1 == null && other.TrailerLine1 == null) || (this.TrailerLine1?.Equals(other.TrailerLine1) == true)) &&
                ((this.TrailerLine2 == null && other.TrailerLine2 == null) || (this.TrailerLine2?.Equals(other.TrailerLine2) == true)) &&
                ((this.TrailerLine3 == null && other.TrailerLine3 == null) || (this.TrailerLine3?.Equals(other.TrailerLine3) == true)) &&
                ((this.TrailerLine4 == null && other.TrailerLine4 == null) || (this.TrailerLine4?.Equals(other.TrailerLine4) == true)) &&
                ((this.TrailerLine5 == null && other.TrailerLine5 == null) || (this.TrailerLine5?.Equals(other.TrailerLine5) == true)) &&
                ((this.DefaultCheckin == null && other.DefaultCheckin == null) || (this.DefaultCheckin?.Equals(other.DefaultCheckin) == true)) &&
                ((this.DefaultCheckout == null && other.DefaultCheckout == null) || (this.DefaultCheckout?.Equals(other.DefaultCheckout) == true)) &&
                ((this.DefaultRoomRate == null && other.DefaultRoomRate == null) || (this.DefaultRoomRate?.Equals(other.DefaultRoomRate) == true)) &&
                ((this.DefaultRoomNumber == null && other.DefaultRoomNumber == null) || (this.DefaultRoomNumber?.Equals(other.DefaultRoomNumber) == true)) &&
                ((this.Debit == null && other.Debit == null) || (this.Debit?.Equals(other.Debit) == true)) &&
                ((this.Emv == null && other.Emv == null) || (this.Emv?.Equals(other.Emv) == true)) &&
                ((this.CashbackEnable == null && other.CashbackEnable == null) || (this.CashbackEnable?.Equals(other.CashbackEnable) == true)) &&
                ((this.PrintEnable == null && other.PrintEnable == null) || (this.PrintEnable?.Equals(other.PrintEnable) == true)) &&
                ((this.SigCaptureEnable == null && other.SigCaptureEnable == null) || (this.SigCaptureEnable?.Equals(other.SigCaptureEnable) == true)) &&
                ((this.IsProvisioned == null && other.IsProvisioned == null) || (this.IsProvisioned?.Equals(other.IsProvisioned) == true)) &&
                ((this.TipEnable == null && other.TipEnable == null) || (this.TipEnable?.Equals(other.TipEnable) == true)) &&
                ((this.ValidatedDecryption == null && other.ValidatedDecryption == null) || (this.ValidatedDecryption?.Equals(other.ValidatedDecryption) == true)) &&
                ((this.CommunicationType == null && other.CommunicationType == null) || (this.CommunicationType?.Equals(other.CommunicationType) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.ModifiedTs == null && other.ModifiedTs == null) || (this.ModifiedTs?.Equals(other.ModifiedTs) == true)) &&
                ((this.LastRegistrationTs == null && other.LastRegistrationTs == null) || (this.LastRegistrationTs?.Equals(other.LastRegistrationTs) == true)) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true)) &&
                ((this.ModifiedUserId == null && other.ModifiedUserId == null) || (this.ModifiedUserId?.Equals(other.ModifiedUserId) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.DefaultProductTransactionId = {(this.DefaultProductTransactionId == null ? "null" : this.DefaultProductTransactionId == string.Empty ? "" : this.DefaultProductTransactionId)}");
            toStringOutput.Add($"this.TerminalApplicationId = {(this.TerminalApplicationId == null ? "null" : this.TerminalApplicationId == string.Empty ? "" : this.TerminalApplicationId)}");
            toStringOutput.Add($"this.TerminalCvmId = {(this.TerminalCvmId == null ? "null" : this.TerminalCvmId == string.Empty ? "" : this.TerminalCvmId)}");
            toStringOutput.Add($"this.TerminalManufacturerCode = {(this.TerminalManufacturerCode == null ? "null" : this.TerminalManufacturerCode.ToString())}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title == string.Empty ? "" : this.Title)}");
            toStringOutput.Add($"this.MacAddress = {(this.MacAddress == null ? "null" : this.MacAddress == string.Empty ? "" : this.MacAddress)}");
            toStringOutput.Add($"this.LocalIpAddress = {(this.LocalIpAddress == null ? "null" : this.LocalIpAddress == string.Empty ? "" : this.LocalIpAddress)}");
            toStringOutput.Add($"this.Port = {(this.Port == null ? "null" : this.Port.ToString())}");
            toStringOutput.Add($"this.SerialNumber = {(this.SerialNumber == null ? "null" : this.SerialNumber == string.Empty ? "" : this.SerialNumber)}");
            toStringOutput.Add($"this.TerminalNumber = {(this.TerminalNumber == null ? "null" : this.TerminalNumber == string.Empty ? "" : this.TerminalNumber)}");
            toStringOutput.Add($"this.TerminalTimeouts = {(this.TerminalTimeouts == null ? "null" : this.TerminalTimeouts.ToString())}");
            toStringOutput.Add($"this.TipPercents = {(this.TipPercents == null ? "null" : this.TipPercents.ToString())}");
            toStringOutput.Add($"this.LocationApiId = {(this.LocationApiId == null ? "null" : this.LocationApiId == string.Empty ? "" : this.LocationApiId)}");
            toStringOutput.Add($"this.TerminalApiId = {(this.TerminalApiId == null ? "null" : this.TerminalApiId == string.Empty ? "" : this.TerminalApiId)}");
            toStringOutput.Add($"this.HeaderLine1 = {(this.HeaderLine1 == null ? "null" : this.HeaderLine1 == string.Empty ? "" : this.HeaderLine1)}");
            toStringOutput.Add($"this.HeaderLine2 = {(this.HeaderLine2 == null ? "null" : this.HeaderLine2 == string.Empty ? "" : this.HeaderLine2)}");
            toStringOutput.Add($"this.HeaderLine3 = {(this.HeaderLine3 == null ? "null" : this.HeaderLine3 == string.Empty ? "" : this.HeaderLine3)}");
            toStringOutput.Add($"this.HeaderLine4 = {(this.HeaderLine4 == null ? "null" : this.HeaderLine4 == string.Empty ? "" : this.HeaderLine4)}");
            toStringOutput.Add($"this.HeaderLine5 = {(this.HeaderLine5 == null ? "null" : this.HeaderLine5 == string.Empty ? "" : this.HeaderLine5)}");
            toStringOutput.Add($"this.TrailerLine1 = {(this.TrailerLine1 == null ? "null" : this.TrailerLine1 == string.Empty ? "" : this.TrailerLine1)}");
            toStringOutput.Add($"this.TrailerLine2 = {(this.TrailerLine2 == null ? "null" : this.TrailerLine2 == string.Empty ? "" : this.TrailerLine2)}");
            toStringOutput.Add($"this.TrailerLine3 = {(this.TrailerLine3 == null ? "null" : this.TrailerLine3 == string.Empty ? "" : this.TrailerLine3)}");
            toStringOutput.Add($"this.TrailerLine4 = {(this.TrailerLine4 == null ? "null" : this.TrailerLine4 == string.Empty ? "" : this.TrailerLine4)}");
            toStringOutput.Add($"this.TrailerLine5 = {(this.TrailerLine5 == null ? "null" : this.TrailerLine5 == string.Empty ? "" : this.TrailerLine5)}");
            toStringOutput.Add($"this.DefaultCheckin = {(this.DefaultCheckin == null ? "null" : this.DefaultCheckin == string.Empty ? "" : this.DefaultCheckin)}");
            toStringOutput.Add($"this.DefaultCheckout = {(this.DefaultCheckout == null ? "null" : this.DefaultCheckout == string.Empty ? "" : this.DefaultCheckout)}");
            toStringOutput.Add($"this.DefaultRoomRate = {(this.DefaultRoomRate == null ? "null" : this.DefaultRoomRate.ToString())}");
            toStringOutput.Add($"this.DefaultRoomNumber = {(this.DefaultRoomNumber == null ? "null" : this.DefaultRoomNumber == string.Empty ? "" : this.DefaultRoomNumber)}");
            toStringOutput.Add($"this.Debit = {(this.Debit == null ? "null" : this.Debit.ToString())}");
            toStringOutput.Add($"this.Emv = {(this.Emv == null ? "null" : this.Emv.ToString())}");
            toStringOutput.Add($"this.CashbackEnable = {(this.CashbackEnable == null ? "null" : this.CashbackEnable.ToString())}");
            toStringOutput.Add($"this.PrintEnable = {(this.PrintEnable == null ? "null" : this.PrintEnable.ToString())}");
            toStringOutput.Add($"this.SigCaptureEnable = {(this.SigCaptureEnable == null ? "null" : this.SigCaptureEnable.ToString())}");
            toStringOutput.Add($"this.IsProvisioned = {(this.IsProvisioned == null ? "null" : this.IsProvisioned.ToString())}");
            toStringOutput.Add($"this.TipEnable = {(this.TipEnable == null ? "null" : this.TipEnable.ToString())}");
            toStringOutput.Add($"this.ValidatedDecryption = {(this.ValidatedDecryption == null ? "null" : this.ValidatedDecryption.ToString())}");
            toStringOutput.Add($"this.CommunicationType = {(this.CommunicationType == null ? "null" : this.CommunicationType.ToString())}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.ModifiedTs = {(this.ModifiedTs == null ? "null" : this.ModifiedTs.ToString())}");
            toStringOutput.Add($"this.LastRegistrationTs = {(this.LastRegistrationTs == null ? "null" : this.LastRegistrationTs.ToString())}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId == string.Empty ? "" : this.CreatedUserId)}");
            toStringOutput.Add($"this.ModifiedUserId = {(this.ModifiedUserId == null ? "null" : this.ModifiedUserId == string.Empty ? "" : this.ModifiedUserId)}");
        }
    }
}