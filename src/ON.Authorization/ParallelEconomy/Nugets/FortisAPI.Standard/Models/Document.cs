// <copyright file="Document.cs" company="APIMatic">
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
    /// Document.
    /// </summary>
    public class Document : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Document"/> class.
        /// </summary>
        public Document()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Document"/> class.
        /// </summary>
        /// <param name="documentName">document_name.</param>
        /// <param name="documentData">document_data.</param>
        /// <param name="mimeType">mime_type.</param>
        public Document(
            string documentName,
            string documentData,
            string mimeType)
        {
            this.DocumentName = documentName;
            this.DocumentData = documentData;
            this.MimeType = mimeType;
        }

        /// <summary>
        /// Array of bank account objects.
        /// </summary>
        [JsonProperty("document_name")]
        public string DocumentName { get; set; }

        /// <summary>
        /// Base64 encoded document content.
        /// </summary>
        [JsonProperty("document_data")]
        public string DocumentData { get; set; }

        /// <summary>
        /// Mime type of document.
        /// </summary>
        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Document : ({string.Join(", ", toStringOutput)})";
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
            return obj is Document other &&                ((this.DocumentName == null && other.DocumentName == null) || (this.DocumentName?.Equals(other.DocumentName) == true)) &&
                ((this.DocumentData == null && other.DocumentData == null) || (this.DocumentData?.Equals(other.DocumentData) == true)) &&
                ((this.MimeType == null && other.MimeType == null) || (this.MimeType?.Equals(other.MimeType) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DocumentName = {(this.DocumentName == null ? "null" : this.DocumentName)}");
            toStringOutput.Add($"this.DocumentData = {(this.DocumentData == null ? "null" : this.DocumentData)}");
            toStringOutput.Add($"this.MimeType = {(this.MimeType == null ? "null" : this.MimeType)}");

            base.ToString(toStringOutput);
        }
    }
}