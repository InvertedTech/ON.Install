// <copyright file="QuickInvoiceView.cs" company="APIMatic">
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
    /// QuickInvoiceView.
    /// </summary>
    public class QuickInvoiceView : BaseModel
    {
        private string remoteIp;
        private int? createdTs;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "remote_ip", false },
            { "created_ts", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="QuickInvoiceView"/> class.
        /// </summary>
        public QuickInvoiceView()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuickInvoiceView"/> class.
        /// </summary>
        /// <param name="quickInvoiceId">quick_invoice_id.</param>
        /// <param name="id">id.</param>
        /// <param name="remoteIp">remote_ip.</param>
        /// <param name="createdTs">created_ts.</param>
        public QuickInvoiceView(
            string quickInvoiceId,
            string id = null,
            string remoteIp = null,
            int? createdTs = null)
        {
            this.Id = id;
            this.QuickInvoiceId = quickInvoiceId;
            if (remoteIp != null)
            {
                this.RemoteIp = remoteIp;
            }

            if (createdTs != null)
            {
                this.CreatedTs = createdTs;
            }

        }

        /// <summary>
        /// Quick Invoice Views Id
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Quick Invoice ID
        /// </summary>
        [JsonProperty("quick_invoice_id")]
        public string QuickInvoiceId { get; set; }

        /// <summary>
        /// Remote Ip
        /// </summary>
        [JsonProperty("remote_ip")]
        public string RemoteIp
        {
            get
            {
                return this.remoteIp;
            }

            set
            {
                this.shouldSerialize["remote_ip"] = true;
                this.remoteIp = value;
            }
        }

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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"QuickInvoiceView : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRemoteIp()
        {
            this.shouldSerialize["remote_ip"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCreatedTs()
        {
            this.shouldSerialize["created_ts"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRemoteIp()
        {
            return this.shouldSerialize["remote_ip"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCreatedTs()
        {
            return this.shouldSerialize["created_ts"];
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
            return obj is QuickInvoiceView other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.QuickInvoiceId == null && other.QuickInvoiceId == null) || (this.QuickInvoiceId?.Equals(other.QuickInvoiceId) == true)) &&
                ((this.RemoteIp == null && other.RemoteIp == null) || (this.RemoteIp?.Equals(other.RemoteIp) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.QuickInvoiceId = {(this.QuickInvoiceId == null ? "null" : this.QuickInvoiceId)}");
            toStringOutput.Add($"this.RemoteIp = {(this.RemoteIp == null ? "null" : this.RemoteIp)}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}