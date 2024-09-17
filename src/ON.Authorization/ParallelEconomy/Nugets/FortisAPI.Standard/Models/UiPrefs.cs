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
    using APIMatic.Core.Utilities.Converters;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// UiPrefs.
    /// </summary>
    public class UiPrefs : BaseModel
    {
        private string entryPage;
        private int? pageSize;
        private Models.ReportExportTypeEnum? reportExportType;
        private Models.ProcessMethodEnum? processMethod;
        private string defaultTerminal;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "entry_page", false },
            { "page_size", false },
            { "report_export_type", false },
            { "process_method", false },
            { "default_terminal", false },
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
            if (entryPage != null)
            {
                this.EntryPage = entryPage;
            }

            if (pageSize != null)
            {
                this.PageSize = pageSize;
            }

            if (reportExportType != null)
            {
                this.ReportExportType = reportExportType;
            }

            if (processMethod != null)
            {
                this.ProcessMethod = processMethod;
            }

            if (defaultTerminal != null)
            {
                this.DefaultTerminal = defaultTerminal;
            }

        }

        /// <summary>
        /// Ui Prefs Entry Page
        /// </summary>
        [JsonProperty("entry_page")]
        public string EntryPage
        {
            get
            {
                return this.entryPage;
            }

            set
            {
                this.shouldSerialize["entry_page"] = true;
                this.entryPage = value;
            }
        }

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
        [JsonProperty("report_export_type")]
        public Models.ReportExportTypeEnum? ReportExportType
        {
            get
            {
                return this.reportExportType;
            }

            set
            {
                this.shouldSerialize["report_export_type"] = true;
                this.reportExportType = value;
            }
        }

        /// <summary>
        /// Ui Prefs Process Method
        /// </summary>
        [JsonProperty("process_method")]
        public Models.ProcessMethodEnum? ProcessMethod
        {
            get
            {
                return this.processMethod;
            }

            set
            {
                this.shouldSerialize["process_method"] = true;
                this.processMethod = value;
            }
        }

        /// <summary>
        /// Ui Prefs Default Termianl
        /// </summary>
        [JsonProperty("default_terminal")]
        public string DefaultTerminal
        {
            get
            {
                return this.defaultTerminal;
            }

            set
            {
                this.shouldSerialize["default_terminal"] = true;
                this.defaultTerminal = value;
            }
        }

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
        public void UnsetEntryPage()
        {
            this.shouldSerialize["entry_page"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPageSize()
        {
            this.shouldSerialize["page_size"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReportExportType()
        {
            this.shouldSerialize["report_export_type"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetProcessMethod()
        {
            this.shouldSerialize["process_method"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDefaultTerminal()
        {
            this.shouldSerialize["default_terminal"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEntryPage()
        {
            return this.shouldSerialize["entry_page"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePageSize()
        {
            return this.shouldSerialize["page_size"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReportExportType()
        {
            return this.shouldSerialize["report_export_type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeProcessMethod()
        {
            return this.shouldSerialize["process_method"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDefaultTerminal()
        {
            return this.shouldSerialize["default_terminal"];
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
            return obj is UiPrefs other &&                ((this.EntryPage == null && other.EntryPage == null) || (this.EntryPage?.Equals(other.EntryPage) == true)) &&
                ((this.PageSize == null && other.PageSize == null) || (this.PageSize?.Equals(other.PageSize) == true)) &&
                ((this.ReportExportType == null && other.ReportExportType == null) || (this.ReportExportType?.Equals(other.ReportExportType) == true)) &&
                ((this.ProcessMethod == null && other.ProcessMethod == null) || (this.ProcessMethod?.Equals(other.ProcessMethod) == true)) &&
                ((this.DefaultTerminal == null && other.DefaultTerminal == null) || (this.DefaultTerminal?.Equals(other.DefaultTerminal) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EntryPage = {(this.EntryPage == null ? "null" : this.EntryPage)}");
            toStringOutput.Add($"this.PageSize = {(this.PageSize == null ? "null" : this.PageSize.ToString())}");
            toStringOutput.Add($"this.ReportExportType = {(this.ReportExportType == null ? "null" : this.ReportExportType.ToString())}");
            toStringOutput.Add($"this.ProcessMethod = {(this.ProcessMethod == null ? "null" : this.ProcessMethod.ToString())}");
            toStringOutput.Add($"this.DefaultTerminal = {(this.DefaultTerminal == null ? "null" : this.DefaultTerminal)}");

            base.ToString(toStringOutput);
        }
    }
}