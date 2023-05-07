// <copyright file="UiPrefs.cs" company="APIMatic">
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
    /// UiPrefs.
    /// </summary>
    public class UiPrefs
    {
        private int? pageSize;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "page_size", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="UiPrefs"/> class.
        /// </summary>
        public UiPrefs()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UiPrefs"/> class.
        /// </summary>
        /// <param name="entryPage">entry_page.</param>
        /// <param name="pageSize">page_size.</param>
        /// <param name="reportExportType">report_export_type.</param>
        /// <param name="processMethod">process_method.</param>
        /// <param name="defaultTerminal">default_terminal.</param>
        public UiPrefs(
            string entryPage = null,
            int? pageSize = null,
            Models.ReportExportTypeEnum? reportExportType = null,
            Models.ProcessMethodEnum? processMethod = null,
            string defaultTerminal = null)
        {
            this.EntryPage = entryPage;
            if (pageSize != null)
            {
                this.PageSize = pageSize;
            }

            this.ReportExportType = reportExportType;
            this.ProcessMethod = processMethod;
            this.DefaultTerminal = defaultTerminal;
        }

        /// <summary>
        /// Ui Prefs Entry Page
        /// </summary>
        [JsonProperty("entry_page", NullValueHandling = NullValueHandling.Ignore)]
        public string EntryPage { get; set; }

        /// <summary>
        /// Ui Prefs Page Size
        /// </summary>
        [JsonProperty("page_size")]
        public int? PageSize
        {
            get
            {
                return this.pageSize;
            }

            set
            {
                this.shouldSerialize["page_size"] = true;
                this.pageSize = value;
            }
        }

        /// <summary>
        /// Ui Prefs Export Type
        /// </summary>
        [JsonProperty("report_export_type", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.ReportExportTypeEnum? ReportExportType { get; set; }

        /// <summary>
        /// Ui Prefs Process Method
        /// </summary>
        [JsonProperty("process_method", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.ProcessMethodEnum? ProcessMethod { get; set; }

        /// <summary>
        /// Ui Prefs Default Termianl
        /// </summary>
        [JsonProperty("default_terminal", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultTerminal { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UiPrefs : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPageSize()
        {
            this.shouldSerialize["page_size"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePageSize()
        {
            return this.shouldSerialize["page_size"];
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

            return obj is UiPrefs other &&
                ((this.EntryPage == null && other.EntryPage == null) || (this.EntryPage?.Equals(other.EntryPage) == true)) &&
                ((this.PageSize == null && other.PageSize == null) || (this.PageSize?.Equals(other.PageSize) == true)) &&
                ((this.ReportExportType == null && other.ReportExportType == null) || (this.ReportExportType?.Equals(other.ReportExportType) == true)) &&
                ((this.ProcessMethod == null && other.ProcessMethod == null) || (this.ProcessMethod?.Equals(other.ProcessMethod) == true)) &&
                ((this.DefaultTerminal == null && other.DefaultTerminal == null) || (this.DefaultTerminal?.Equals(other.DefaultTerminal) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EntryPage = {(this.EntryPage == null ? "null" : this.EntryPage == string.Empty ? "" : this.EntryPage)}");
            toStringOutput.Add($"this.PageSize = {(this.PageSize == null ? "null" : this.PageSize.ToString())}");
            toStringOutput.Add($"this.ReportExportType = {(this.ReportExportType == null ? "null" : this.ReportExportType.ToString())}");
            toStringOutput.Add($"this.ProcessMethod = {(this.ProcessMethod == null ? "null" : this.ProcessMethod.ToString())}");
            toStringOutput.Add($"this.DefaultTerminal = {(this.DefaultTerminal == null ? "null" : this.DefaultTerminal == string.Empty ? "" : this.DefaultTerminal)}");
        }
    }
}