// <copyright file="V1TransactionsLevel3MasterCardRequest.cs" company="APIMatic">
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
    /// V1TransactionsLevel3MasterCardRequest.
    /// </summary>
    public class V1TransactionsLevel3MasterCardRequest : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1TransactionsLevel3MasterCardRequest"/> class.
        /// </summary>
        public V1TransactionsLevel3MasterCardRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="V1TransactionsLevel3MasterCardRequest"/> class.
        /// </summary>
        /// <param name="level3Data">level3_data.</param>
        public V1TransactionsLevel3MasterCardRequest(
            Models.Level3Data5 level3Data)
        {
            this.Level3Data = level3Data;
        }

        /// <summary>
        /// Level 3 data object
        /// </summary>
        [JsonProperty("level3_data")]
        public Models.Level3Data5 Level3Data { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1TransactionsLevel3MasterCardRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is V1TransactionsLevel3MasterCardRequest other &&                ((this.Level3Data == null && other.Level3Data == null) || (this.Level3Data?.Equals(other.Level3Data) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Level3Data = {(this.Level3Data == null ? "null" : this.Level3Data.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}