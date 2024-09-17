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
    using APIMatic.Core.Utilities.Converters;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// EmvReceiptData.
    /// </summary>
    public class EmvReceiptData : BaseModel
    {
        private string aID;
        private string aPPLAB;
        private string aPPN;
        private string cVM;
        private string tSI;
        private string tVR;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "AID", false },
            { "APPLAB", false },
            { "APPN", false },
            { "CVM", false },
            { "TSI", false },
            { "TVR", false },
        };

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
            if (aID != null)
            {
                this.AID = aID;
            }

            if (aPPLAB != null)
            {
                this.APPLAB = aPPLAB;
            }

            if (aPPN != null)
            {
                this.APPN = aPPN;
            }

            if (cVM != null)
            {
                this.CVM = cVM;
            }

            if (tSI != null)
            {
                this.TSI = tSI;
            }

            if (tVR != null)
            {
                this.TVR = tVR;
            }

        }

        /// <summary>
        /// This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM
        /// </summary>
        [JsonProperty("AID")]
        public string AID
        {
            get
            {
                return this.aID;
            }

            set
            {
                this.shouldSerialize["AID"] = true;
                this.aID = value;
            }
        }

        /// <summary>
        /// This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM
        /// </summary>
        [JsonProperty("APPLAB")]
        public string APPLAB
        {
            get
            {
                return this.aPPLAB;
            }

            set
            {
                this.shouldSerialize["APPLAB"] = true;
                this.aPPLAB = value;
            }
        }

        /// <summary>
        /// This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM
        /// </summary>
        [JsonProperty("APPN")]
        public string APPN
        {
            get
            {
                return this.aPPN;
            }

            set
            {
                this.shouldSerialize["APPN"] = true;
                this.aPPN = value;
            }
        }

        /// <summary>
        /// This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM
        /// </summary>
        [JsonProperty("CVM")]
        public string CVM
        {
            get
            {
                return this.cVM;
            }

            set
            {
                this.shouldSerialize["CVM"] = true;
                this.cVM = value;
            }
        }

        /// <summary>
        /// This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM
        /// </summary>
        [JsonProperty("TSI")]
        public string TSI
        {
            get
            {
                return this.tSI;
            }

            set
            {
                this.shouldSerialize["TSI"] = true;
                this.tSI = value;
            }
        }

        /// <summary>
        /// This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM
        /// </summary>
        [JsonProperty("TVR")]
        public string TVR
        {
            get
            {
                return this.tVR;
            }

            set
            {
                this.shouldSerialize["TVR"] = true;
                this.tVR = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"EmvReceiptData : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAID()
        {
            this.shouldSerialize["AID"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAPPLAB()
        {
            this.shouldSerialize["APPLAB"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAPPN()
        {
            this.shouldSerialize["APPN"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCVM()
        {
            this.shouldSerialize["CVM"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTSI()
        {
            this.shouldSerialize["TSI"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTVR()
        {
            this.shouldSerialize["TVR"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAID()
        {
            return this.shouldSerialize["AID"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAPPLAB()
        {
            return this.shouldSerialize["APPLAB"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAPPN()
        {
            return this.shouldSerialize["APPN"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCVM()
        {
            return this.shouldSerialize["CVM"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTSI()
        {
            return this.shouldSerialize["TSI"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTVR()
        {
            return this.shouldSerialize["TVR"];
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
            return obj is EmvReceiptData other &&                ((this.AID == null && other.AID == null) || (this.AID?.Equals(other.AID) == true)) &&
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
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AID = {(this.AID == null ? "null" : this.AID)}");
            toStringOutput.Add($"this.APPLAB = {(this.APPLAB == null ? "null" : this.APPLAB)}");
            toStringOutput.Add($"this.APPN = {(this.APPN == null ? "null" : this.APPN)}");
            toStringOutput.Add($"this.CVM = {(this.CVM == null ? "null" : this.CVM)}");
            toStringOutput.Add($"this.TSI = {(this.TSI == null ? "null" : this.TSI)}");
            toStringOutput.Add($"this.TVR = {(this.TVR == null ? "null" : this.TVR)}");

            base.ToString(toStringOutput);
        }
    }
}