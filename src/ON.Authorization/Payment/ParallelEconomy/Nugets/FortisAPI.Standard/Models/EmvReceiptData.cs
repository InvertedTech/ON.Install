// <copyright file="EmvReceiptData.cs" company="APIMatic">
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
    /// EmvReceiptData.
    /// </summary>
    public class EmvReceiptData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmvReceiptData"/> class.
        /// </summary>
        public EmvReceiptData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmvReceiptData"/> class.
        /// </summary>
        /// <param name="aID">AID.</param>
        /// <param name="aPPLAB">APPLAB.</param>
        /// <param name="aPPN">APPN.</param>
        /// <param name="cVM">CVM.</param>
        /// <param name="tSI">TSI.</param>
        /// <param name="tVR">TVR.</param>
        public EmvReceiptData(
            string aID = null,
            string aPPLAB = null,
            string aPPN = null,
            string cVM = null,
            string tSI = null,
            string tVR = null)
        {
            this.AID = aID;
            this.APPLAB = aPPLAB;
            this.APPN = aPPN;
            this.CVM = cVM;
            this.TSI = tSI;
            this.TVR = tVR;
        }

        /// <summary>
        /// This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM
        /// </summary>
        [JsonProperty("AID", NullValueHandling = NullValueHandling.Ignore)]
        public string AID { get; set; }

        /// <summary>
        /// This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM
        /// </summary>
        [JsonProperty("APPLAB", NullValueHandling = NullValueHandling.Ignore)]
        public string APPLAB { get; set; }

        /// <summary>
        /// This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM
        /// </summary>
        [JsonProperty("APPN", NullValueHandling = NullValueHandling.Ignore)]
        public string APPN { get; set; }

        /// <summary>
        /// This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM
        /// </summary>
        [JsonProperty("CVM", NullValueHandling = NullValueHandling.Ignore)]
        public string CVM { get; set; }

        /// <summary>
        /// This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM
        /// </summary>
        [JsonProperty("TSI", NullValueHandling = NullValueHandling.Ignore)]
        public string TSI { get; set; }

        /// <summary>
        /// This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM
        /// </summary>
        [JsonProperty("TVR", NullValueHandling = NullValueHandling.Ignore)]
        public string TVR { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"EmvReceiptData : ({string.Join(", ", toStringOutput)})";
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

            return obj is EmvReceiptData other &&
                ((this.AID == null && other.AID == null) || (this.AID?.Equals(other.AID) == true)) &&
                ((this.APPLAB == null && other.APPLAB == null) || (this.APPLAB?.Equals(other.APPLAB) == true)) &&
                ((this.APPN == null && other.APPN == null) || (this.APPN?.Equals(other.APPN) == true)) &&
                ((this.CVM == null && other.CVM == null) || (this.CVM?.Equals(other.CVM) == true)) &&
                ((this.TSI == null && other.TSI == null) || (this.TSI?.Equals(other.TSI) == true)) &&
                ((this.TVR == null && other.TVR == null) || (this.TVR?.Equals(other.TVR) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AID = {(this.AID == null ? "null" : this.AID == string.Empty ? "" : this.AID)}");
            toStringOutput.Add($"this.APPLAB = {(this.APPLAB == null ? "null" : this.APPLAB == string.Empty ? "" : this.APPLAB)}");
            toStringOutput.Add($"this.APPN = {(this.APPN == null ? "null" : this.APPN == string.Empty ? "" : this.APPN)}");
            toStringOutput.Add($"this.CVM = {(this.CVM == null ? "null" : this.CVM == string.Empty ? "" : this.CVM)}");
            toStringOutput.Add($"this.TSI = {(this.TSI == null ? "null" : this.TSI == string.Empty ? "" : this.TSI)}");
            toStringOutput.Add($"this.TVR = {(this.TVR == null ? "null" : this.TVR == string.Empty ? "" : this.TVR)}");
        }
    }
}