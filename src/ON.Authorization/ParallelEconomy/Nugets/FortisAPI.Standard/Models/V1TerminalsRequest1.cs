// <copyright file="V1TerminalsRequest1.cs" company="APIMatic">
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
    /// V1TerminalsRequest1.
    /// </summary>
    public class V1TerminalsRequest1 : BaseModel
    {
        private string locationId;
        private string defaultProductTransactionId;
        private string terminalApplicationId;
        private string terminalCvmId;
        private Models.TerminalManufacturerCodeEnum? terminalManufacturerCode;
        private string title;
        private string macAddress;
        private string localIpAddress;
        private int? port;
        private string serialNumber;
        private string terminalNumber;
        private string locationApiId;
        private string terminalApiId;
        private string headerLine1;
        private string headerLine2;
        private string headerLine3;
        private string headerLine4;
        private string headerLine5;
        private string trailerLine1;
        private string trailerLine2;
        private string trailerLine3;
        private string trailerLine4;
        private string trailerLine5;
        private string defaultCheckin;
        private string defaultCheckout;
        private int? defaultRoomRate;
        private string defaultRoomNumber;
        private Models.CommunicationTypeEnum? communicationType;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "location_id", false },
            { "default_product_transaction_id", false },
            { "terminal_application_id", false },
            { "terminal_cvm_id", false },
            { "terminal_manufacturer_code", false },
            { "title", false },
            { "mac_address", false },
            { "local_ip_address", false },
            { "port", true },
            { "serial_number", false },
            { "terminal_number", false },
            { "location_api_id", false },
            { "terminal_api_id", false },
            { "header_line_1", false },
            { "header_line_2", false },
            { "header_line_3", false },
            { "header_line_4", false },
            { "header_line_5", false },
            { "trailer_line_1", false },
            { "trailer_line_2", false },
            { "trailer_line_3", false },
            { "trailer_line_4", false },
            { "trailer_line_5", false },
            { "default_checkin", false },
            { "default_checkout", false },
            { "default_room_rate", false },
            { "default_room_number", false },
            { "communication_type", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="V1TerminalsRequest1"/> class.
        /// </summary>
        public V1TerminalsRequest1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1TerminalsRequest1"/> class.
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
        /// <param name="active">active.</param>
        public V1TerminalsRequest1(
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
            int? defaultRoomRate = null,
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
            bool? active = null)
        {
            if (locationId != null)
            {
                this.LocationId = locationId;
            }

            if (defaultProductTransactionId != null)
            {
                this.DefaultProductTransactionId = defaultProductTransactionId;
            }

            if (terminalApplicationId != null)
            {
                this.TerminalApplicationId = terminalApplicationId;
            }

            if (terminalCvmId != null)
            {
                this.TerminalCvmId = terminalCvmId;
            }

            if (terminalManufacturerCode != null)
            {
                this.TerminalManufacturerCode = terminalManufacturerCode;
            }

            if (title != null)
            {
                this.Title = title;
            }

            if (macAddress != null)
            {
                this.MacAddress = macAddress;
            }

            if (localIpAddress != null)
            {
                this.LocalIpAddress = localIpAddress;
            }

            this.Port = port;
            if (serialNumber != null)
            {
                this.SerialNumber = serialNumber;
            }

            if (terminalNumber != null)
            {
                this.TerminalNumber = terminalNumber;
            }

            this.TerminalTimeouts = terminalTimeouts;
            this.TipPercents = tipPercents;
            if (locationApiId != null)
            {
                this.LocationApiId = locationApiId;
            }

            if (terminalApiId != null)
            {
                this.TerminalApiId = terminalApiId;
            }

            if (headerLine1 != null)
            {
                this.HeaderLine1 = headerLine1;
            }

            if (headerLine2 != null)
            {
                this.HeaderLine2 = headerLine2;
            }

            if (headerLine3 != null)
            {
                this.HeaderLine3 = headerLine3;
            }

            if (headerLine4 != null)
            {
                this.HeaderLine4 = headerLine4;
            }

            if (headerLine5 != null)
            {
                this.HeaderLine5 = headerLine5;
            }

            if (trailerLine1 != null)
            {
                this.TrailerLine1 = trailerLine1;
            }

            if (trailerLine2 != null)
            {
                this.TrailerLine2 = trailerLine2;
            }

            if (trailerLine3 != null)
            {
                this.TrailerLine3 = trailerLine3;
            }

            if (trailerLine4 != null)
            {
                this.TrailerLine4 = trailerLine4;
            }

            if (trailerLine5 != null)
            {
                this.TrailerLine5 = trailerLine5;
            }

            if (defaultCheckin != null)
            {
                this.DefaultCheckin = defaultCheckin;
            }

            if (defaultCheckout != null)
            {
                this.DefaultCheckout = defaultCheckout;
            }

            if (defaultRoomRate != null)
            {
                this.DefaultRoomRate = defaultRoomRate;
            }

            if (defaultRoomNumber != null)
            {
                this.DefaultRoomNumber = defaultRoomNumber;
            }

            this.Debit = debit;
            this.Emv = emv;
            this.CashbackEnable = cashbackEnable;
            this.PrintEnable = printEnable;
            this.SigCaptureEnable = sigCaptureEnable;
            this.IsProvisioned = isProvisioned;
            this.TipEnable = tipEnable;
            this.ValidatedDecryption = validatedDecryption;
            if (communicationType != null)
            {
                this.CommunicationType = communicationType;
            }

            this.Active = active;
        }

        /// <summary>
        /// Location ID
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId
        {
            get
            {
                return this.locationId;
            }

            set
            {
                this.shouldSerialize["location_id"] = true;
                this.locationId = value;
            }
        }

        /// <summary>
        /// Product Transaction ID
        /// </summary>
        [JsonProperty("default_product_transaction_id")]
        public string DefaultProductTransactionId
        {
            get
            {
                return this.defaultProductTransactionId;
            }

            set
            {
                this.shouldSerialize["default_product_transaction_id"] = true;
                this.defaultProductTransactionId = value;
            }
        }

        /// <summary>
        /// Terminal Application ID
        /// </summary>
        [JsonProperty("terminal_application_id")]
        public string TerminalApplicationId
        {
            get
            {
                return this.terminalApplicationId;
            }

            set
            {
                this.shouldSerialize["terminal_application_id"] = true;
                this.terminalApplicationId = value;
            }
        }

        /// <summary>
        /// Terminal CVM ID
        /// </summary>
        [JsonProperty("terminal_cvm_id")]
        public string TerminalCvmId
        {
            get
            {
                return this.terminalCvmId;
            }

            set
            {
                this.shouldSerialize["terminal_cvm_id"] = true;
                this.terminalCvmId = value;
            }
        }

        /// <summary>
        /// Terminal Manufacturer Code
        /// </summary>
        [JsonProperty("terminal_manufacturer_code")]
        public Models.TerminalManufacturerCodeEnum? TerminalManufacturerCode
        {
            get
            {
                return this.terminalManufacturerCode;
            }

            set
            {
                this.shouldSerialize["terminal_manufacturer_code"] = true;
                this.terminalManufacturerCode = value;
            }
        }

        /// <summary>
        /// Terminal Name
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
        /// Terminal MAC Address
        /// </summary>
        [JsonProperty("mac_address")]
        public string MacAddress
        {
            get
            {
                return this.macAddress;
            }

            set
            {
                this.shouldSerialize["mac_address"] = true;
                this.macAddress = value;
            }
        }

        /// <summary>
        /// Terminal Local IP Address
        /// </summary>
        [JsonProperty("local_ip_address")]
        public string LocalIpAddress
        {
            get
            {
                return this.localIpAddress;
            }

            set
            {
                this.shouldSerialize["local_ip_address"] = true;
                this.localIpAddress = value;
            }
        }

        /// <summary>
        /// Terminal Port
        /// </summary>
        [JsonProperty("port")]
        public int? Port
        {
            get
            {
                return this.port;
            }

            set
            {
                this.shouldSerialize["port"] = true;
                this.port = value;
            }
        }

        /// <summary>
        /// Terminal Serial Number
        /// </summary>
        [JsonProperty("serial_number")]
        public string SerialNumber
        {
            get
            {
                return this.serialNumber;
            }

            set
            {
                this.shouldSerialize["serial_number"] = true;
                this.serialNumber = value;
            }
        }

        /// <summary>
        /// Terminal Number
        /// </summary>
        [JsonProperty("terminal_number")]
        public string TerminalNumber
        {
            get
            {
                return this.terminalNumber;
            }

            set
            {
                this.shouldSerialize["terminal_number"] = true;
                this.terminalNumber = value;
            }
        }

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
        [JsonProperty("location_api_id")]
        public string LocationApiId
        {
            get
            {
                return this.locationApiId;
            }

            set
            {
                this.shouldSerialize["location_api_id"] = true;
                this.locationApiId = value;
            }
        }

        /// <summary>
        /// Terminal Api ID
        /// </summary>
        [JsonProperty("terminal_api_id")]
        public string TerminalApiId
        {
            get
            {
                return this.terminalApiId;
            }

            set
            {
                this.shouldSerialize["terminal_api_id"] = true;
                this.terminalApiId = value;
            }
        }

        /// <summary>
        /// Header Line 1
        /// </summary>
        [JsonProperty("header_line_1")]
        public string HeaderLine1
        {
            get
            {
                return this.headerLine1;
            }

            set
            {
                this.shouldSerialize["header_line_1"] = true;
                this.headerLine1 = value;
            }
        }

        /// <summary>
        /// Header Line 2
        /// </summary>
        [JsonProperty("header_line_2")]
        public string HeaderLine2
        {
            get
            {
                return this.headerLine2;
            }

            set
            {
                this.shouldSerialize["header_line_2"] = true;
                this.headerLine2 = value;
            }
        }

        /// <summary>
        /// Header Line 3
        /// </summary>
        [JsonProperty("header_line_3")]
        public string HeaderLine3
        {
            get
            {
                return this.headerLine3;
            }

            set
            {
                this.shouldSerialize["header_line_3"] = true;
                this.headerLine3 = value;
            }
        }

        /// <summary>
        /// Header Line 4
        /// </summary>
        [JsonProperty("header_line_4")]
        public string HeaderLine4
        {
            get
            {
                return this.headerLine4;
            }

            set
            {
                this.shouldSerialize["header_line_4"] = true;
                this.headerLine4 = value;
            }
        }

        /// <summary>
        /// Header Line 5
        /// </summary>
        [JsonProperty("header_line_5")]
        public string HeaderLine5
        {
            get
            {
                return this.headerLine5;
            }

            set
            {
                this.shouldSerialize["header_line_5"] = true;
                this.headerLine5 = value;
            }
        }

        /// <summary>
        /// Trailer Line 1
        /// </summary>
        [JsonProperty("trailer_line_1")]
        public string TrailerLine1
        {
            get
            {
                return this.trailerLine1;
            }

            set
            {
                this.shouldSerialize["trailer_line_1"] = true;
                this.trailerLine1 = value;
            }
        }

        /// <summary>
        /// Trailer Line 2
        /// </summary>
        [JsonProperty("trailer_line_2")]
        public string TrailerLine2
        {
            get
            {
                return this.trailerLine2;
            }

            set
            {
                this.shouldSerialize["trailer_line_2"] = true;
                this.trailerLine2 = value;
            }
        }

        /// <summary>
        /// Trailer Line 3
        /// </summary>
        [JsonProperty("trailer_line_3")]
        public string TrailerLine3
        {
            get
            {
                return this.trailerLine3;
            }

            set
            {
                this.shouldSerialize["trailer_line_3"] = true;
                this.trailerLine3 = value;
            }
        }

        /// <summary>
        /// Trailer Line 4
        /// </summary>
        [JsonProperty("trailer_line_4")]
        public string TrailerLine4
        {
            get
            {
                return this.trailerLine4;
            }

            set
            {
                this.shouldSerialize["trailer_line_4"] = true;
                this.trailerLine4 = value;
            }
        }

        /// <summary>
        /// Trailer Line 5
        /// </summary>
        [JsonProperty("trailer_line_5")]
        public string TrailerLine5
        {
            get
            {
                return this.trailerLine5;
            }

            set
            {
                this.shouldSerialize["trailer_line_5"] = true;
                this.trailerLine5 = value;
            }
        }

        /// <summary>
        /// Default Checkin
        /// </summary>
        [JsonProperty("default_checkin")]
        public string DefaultCheckin
        {
            get
            {
                return this.defaultCheckin;
            }

            set
            {
                this.shouldSerialize["default_checkin"] = true;
                this.defaultCheckin = value;
            }
        }

        /// <summary>
        /// Default Checkout
        /// </summary>
        [JsonProperty("default_checkout")]
        public string DefaultCheckout
        {
            get
            {
                return this.defaultCheckout;
            }

            set
            {
                this.shouldSerialize["default_checkout"] = true;
                this.defaultCheckout = value;
            }
        }

        /// <summary>
        /// Default Room Rate
        /// </summary>
        [JsonProperty("default_room_rate")]
        public int? DefaultRoomRate
        {
            get
            {
                return this.defaultRoomRate;
            }

            set
            {
                this.shouldSerialize["default_room_rate"] = true;
                this.defaultRoomRate = value;
            }
        }

        /// <summary>
        /// Default Room Number
        /// </summary>
        [JsonProperty("default_room_number")]
        public string DefaultRoomNumber
        {
            get
            {
                return this.defaultRoomNumber;
            }

            set
            {
                this.shouldSerialize["default_room_number"] = true;
                this.defaultRoomNumber = value;
            }
        }

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
        [JsonProperty("communication_type")]
        public Models.CommunicationTypeEnum? CommunicationType
        {
            get
            {
                return this.communicationType;
            }

            set
            {
                this.shouldSerialize["communication_type"] = true;
                this.communicationType = value;
            }
        }

        /// <summary>
        /// Active
        /// </summary>
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Active { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1TerminalsRequest1 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocationId()
        {
            this.shouldSerialize["location_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDefaultProductTransactionId()
        {
            this.shouldSerialize["default_product_transaction_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTerminalApplicationId()
        {
            this.shouldSerialize["terminal_application_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTerminalCvmId()
        {
            this.shouldSerialize["terminal_cvm_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTerminalManufacturerCode()
        {
            this.shouldSerialize["terminal_manufacturer_code"] = false;
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
        public void UnsetMacAddress()
        {
            this.shouldSerialize["mac_address"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocalIpAddress()
        {
            this.shouldSerialize["local_ip_address"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPort()
        {
            this.shouldSerialize["port"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSerialNumber()
        {
            this.shouldSerialize["serial_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTerminalNumber()
        {
            this.shouldSerialize["terminal_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLocationApiId()
        {
            this.shouldSerialize["location_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTerminalApiId()
        {
            this.shouldSerialize["terminal_api_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetHeaderLine1()
        {
            this.shouldSerialize["header_line_1"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetHeaderLine2()
        {
            this.shouldSerialize["header_line_2"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetHeaderLine3()
        {
            this.shouldSerialize["header_line_3"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetHeaderLine4()
        {
            this.shouldSerialize["header_line_4"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetHeaderLine5()
        {
            this.shouldSerialize["header_line_5"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTrailerLine1()
        {
            this.shouldSerialize["trailer_line_1"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTrailerLine2()
        {
            this.shouldSerialize["trailer_line_2"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTrailerLine3()
        {
            this.shouldSerialize["trailer_line_3"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTrailerLine4()
        {
            this.shouldSerialize["trailer_line_4"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTrailerLine5()
        {
            this.shouldSerialize["trailer_line_5"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDefaultCheckin()
        {
            this.shouldSerialize["default_checkin"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDefaultCheckout()
        {
            this.shouldSerialize["default_checkout"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDefaultRoomRate()
        {
            this.shouldSerialize["default_room_rate"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDefaultRoomNumber()
        {
            this.shouldSerialize["default_room_number"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCommunicationType()
        {
            this.shouldSerialize["communication_type"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDefaultProductTransactionId()
        {
            return this.shouldSerialize["default_product_transaction_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTerminalApplicationId()
        {
            return this.shouldSerialize["terminal_application_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTerminalCvmId()
        {
            return this.shouldSerialize["terminal_cvm_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTerminalManufacturerCode()
        {
            return this.shouldSerialize["terminal_manufacturer_code"];
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
        public bool ShouldSerializeMacAddress()
        {
            return this.shouldSerialize["mac_address"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocalIpAddress()
        {
            return this.shouldSerialize["local_ip_address"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePort()
        {
            return this.shouldSerialize["port"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSerialNumber()
        {
            return this.shouldSerialize["serial_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTerminalNumber()
        {
            return this.shouldSerialize["terminal_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationApiId()
        {
            return this.shouldSerialize["location_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTerminalApiId()
        {
            return this.shouldSerialize["terminal_api_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeHeaderLine1()
        {
            return this.shouldSerialize["header_line_1"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeHeaderLine2()
        {
            return this.shouldSerialize["header_line_2"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeHeaderLine3()
        {
            return this.shouldSerialize["header_line_3"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeHeaderLine4()
        {
            return this.shouldSerialize["header_line_4"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeHeaderLine5()
        {
            return this.shouldSerialize["header_line_5"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTrailerLine1()
        {
            return this.shouldSerialize["trailer_line_1"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTrailerLine2()
        {
            return this.shouldSerialize["trailer_line_2"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTrailerLine3()
        {
            return this.shouldSerialize["trailer_line_3"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTrailerLine4()
        {
            return this.shouldSerialize["trailer_line_4"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTrailerLine5()
        {
            return this.shouldSerialize["trailer_line_5"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDefaultCheckin()
        {
            return this.shouldSerialize["default_checkin"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDefaultCheckout()
        {
            return this.shouldSerialize["default_checkout"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDefaultRoomRate()
        {
            return this.shouldSerialize["default_room_rate"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDefaultRoomNumber()
        {
            return this.shouldSerialize["default_room_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCommunicationType()
        {
            return this.shouldSerialize["communication_type"];
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
            return obj is V1TerminalsRequest1 other &&                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
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
                ((this.Active == null && other.Active == null) || (this.Active?.Equals(other.Active) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.DefaultProductTransactionId = {(this.DefaultProductTransactionId == null ? "null" : this.DefaultProductTransactionId)}");
            toStringOutput.Add($"this.TerminalApplicationId = {(this.TerminalApplicationId == null ? "null" : this.TerminalApplicationId)}");
            toStringOutput.Add($"this.TerminalCvmId = {(this.TerminalCvmId == null ? "null" : this.TerminalCvmId)}");
            toStringOutput.Add($"this.TerminalManufacturerCode = {(this.TerminalManufacturerCode == null ? "null" : this.TerminalManufacturerCode.ToString())}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
            toStringOutput.Add($"this.MacAddress = {(this.MacAddress == null ? "null" : this.MacAddress)}");
            toStringOutput.Add($"this.LocalIpAddress = {(this.LocalIpAddress == null ? "null" : this.LocalIpAddress)}");
            toStringOutput.Add($"this.Port = {(this.Port == null ? "null" : this.Port.ToString())}");
            toStringOutput.Add($"this.SerialNumber = {(this.SerialNumber == null ? "null" : this.SerialNumber)}");
            toStringOutput.Add($"this.TerminalNumber = {(this.TerminalNumber == null ? "null" : this.TerminalNumber)}");
            toStringOutput.Add($"this.TerminalTimeouts = {(this.TerminalTimeouts == null ? "null" : this.TerminalTimeouts.ToString())}");
            toStringOutput.Add($"this.TipPercents = {(this.TipPercents == null ? "null" : this.TipPercents.ToString())}");
            toStringOutput.Add($"this.LocationApiId = {(this.LocationApiId == null ? "null" : this.LocationApiId)}");
            toStringOutput.Add($"this.TerminalApiId = {(this.TerminalApiId == null ? "null" : this.TerminalApiId)}");
            toStringOutput.Add($"this.HeaderLine1 = {(this.HeaderLine1 == null ? "null" : this.HeaderLine1)}");
            toStringOutput.Add($"this.HeaderLine2 = {(this.HeaderLine2 == null ? "null" : this.HeaderLine2)}");
            toStringOutput.Add($"this.HeaderLine3 = {(this.HeaderLine3 == null ? "null" : this.HeaderLine3)}");
            toStringOutput.Add($"this.HeaderLine4 = {(this.HeaderLine4 == null ? "null" : this.HeaderLine4)}");
            toStringOutput.Add($"this.HeaderLine5 = {(this.HeaderLine5 == null ? "null" : this.HeaderLine5)}");
            toStringOutput.Add($"this.TrailerLine1 = {(this.TrailerLine1 == null ? "null" : this.TrailerLine1)}");
            toStringOutput.Add($"this.TrailerLine2 = {(this.TrailerLine2 == null ? "null" : this.TrailerLine2)}");
            toStringOutput.Add($"this.TrailerLine3 = {(this.TrailerLine3 == null ? "null" : this.TrailerLine3)}");
            toStringOutput.Add($"this.TrailerLine4 = {(this.TrailerLine4 == null ? "null" : this.TrailerLine4)}");
            toStringOutput.Add($"this.TrailerLine5 = {(this.TrailerLine5 == null ? "null" : this.TrailerLine5)}");
            toStringOutput.Add($"this.DefaultCheckin = {(this.DefaultCheckin == null ? "null" : this.DefaultCheckin)}");
            toStringOutput.Add($"this.DefaultCheckout = {(this.DefaultCheckout == null ? "null" : this.DefaultCheckout)}");
            toStringOutput.Add($"this.DefaultRoomRate = {(this.DefaultRoomRate == null ? "null" : this.DefaultRoomRate.ToString())}");
            toStringOutput.Add($"this.DefaultRoomNumber = {(this.DefaultRoomNumber == null ? "null" : this.DefaultRoomNumber)}");
            toStringOutput.Add($"this.Debit = {(this.Debit == null ? "null" : this.Debit.ToString())}");
            toStringOutput.Add($"this.Emv = {(this.Emv == null ? "null" : this.Emv.ToString())}");
            toStringOutput.Add($"this.CashbackEnable = {(this.CashbackEnable == null ? "null" : this.CashbackEnable.ToString())}");
            toStringOutput.Add($"this.PrintEnable = {(this.PrintEnable == null ? "null" : this.PrintEnable.ToString())}");
            toStringOutput.Add($"this.SigCaptureEnable = {(this.SigCaptureEnable == null ? "null" : this.SigCaptureEnable.ToString())}");
            toStringOutput.Add($"this.IsProvisioned = {(this.IsProvisioned == null ? "null" : this.IsProvisioned.ToString())}");
            toStringOutput.Add($"this.TipEnable = {(this.TipEnable == null ? "null" : this.TipEnable.ToString())}");
            toStringOutput.Add($"this.ValidatedDecryption = {(this.ValidatedDecryption == null ? "null" : this.ValidatedDecryption.ToString())}");
            toStringOutput.Add($"this.CommunicationType = {(this.CommunicationType == null ? "null" : this.CommunicationType.ToString())}");
            toStringOutput.Add($"this.Active = {(this.Active == null ? "null" : this.Active.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}