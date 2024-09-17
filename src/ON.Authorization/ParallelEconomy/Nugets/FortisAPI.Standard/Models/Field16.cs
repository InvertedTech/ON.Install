// <copyright file="Field16.cs" company="APIMatic">
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
    /// Field16.
    /// </summary>
    public class Field16 : BaseModel
    {
        private string mValue;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "value", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Field16"/> class.
        /// </summary>
        public Field16()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Field16"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="label">label.</param>
        /// <param name="fieldType">field_type.</param>
        /// <param name="position">position.</param>
        /// <param name="required">required.</param>
        /// <param name="mReadonly">readonly.</param>
        /// <param name="visible">visible.</param>
        /// <param name="mValue">value.</param>
        public Field16(
            string id,
            string label,
            string fieldType,
            List<string> position,
            bool? required = null,
            bool? mReadonly = null,
            bool? visible = null,
            string mValue = null)
        {
            this.Id = id;
            this.Label = label;
            this.FieldType = fieldType;
            this.Position = position;
            this.Required = required;
            this.MReadonly = mReadonly;
            this.Visible = visible;
            if (mValue != null)
            {
                this.MValue = mValue;
            }

        }

        /// <summary>
        /// id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Label
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// Field Type
        /// </summary>
        [JsonProperty("field_type")]
        public string FieldType { get; set; }

        /// <summary>
        /// Position
        /// </summary>
        [JsonProperty("position")]
        public List<string> Position { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("required", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Required { get; set; }

        /// <summary>
        /// Read Only
        /// </summary>
        [JsonProperty("readonly", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MReadonly { get; set; }

        /// <summary>
        /// Visible
        /// </summary>
        [JsonProperty("visible", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Visible { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        [JsonProperty("value")]
        public string MValue
        {
            get
            {
                return this.mValue;
            }

            set
            {
                this.shouldSerialize["value"] = true;
                this.mValue = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Field16 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMValue()
        {
            this.shouldSerialize["value"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMValue()
        {
            return this.shouldSerialize["value"];
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
            return obj is Field16 other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Label == null && other.Label == null) || (this.Label?.Equals(other.Label) == true)) &&
                ((this.FieldType == null && other.FieldType == null) || (this.FieldType?.Equals(other.FieldType) == true)) &&
                ((this.Position == null && other.Position == null) || (this.Position?.Equals(other.Position) == true)) &&
                ((this.Required == null && other.Required == null) || (this.Required?.Equals(other.Required) == true)) &&
                ((this.MReadonly == null && other.MReadonly == null) || (this.MReadonly?.Equals(other.MReadonly) == true)) &&
                ((this.Visible == null && other.Visible == null) || (this.Visible?.Equals(other.Visible) == true)) &&
                ((this.MValue == null && other.MValue == null) || (this.MValue?.Equals(other.MValue) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.Label = {(this.Label == null ? "null" : this.Label)}");
            toStringOutput.Add($"this.FieldType = {(this.FieldType == null ? "null" : this.FieldType)}");
            toStringOutput.Add($"this.Position = {(this.Position == null ? "null" : $"[{string.Join(", ", this.Position)} ]")}");
            toStringOutput.Add($"this.Required = {(this.Required == null ? "null" : this.Required.ToString())}");
            toStringOutput.Add($"this.MReadonly = {(this.MReadonly == null ? "null" : this.MReadonly.ToString())}");
            toStringOutput.Add($"this.Visible = {(this.Visible == null ? "null" : this.Visible.ToString())}");
            toStringOutput.Add($"this.MValue = {(this.MValue == null ? "null" : this.MValue)}");

            base.ToString(toStringOutput);
        }
    }
}