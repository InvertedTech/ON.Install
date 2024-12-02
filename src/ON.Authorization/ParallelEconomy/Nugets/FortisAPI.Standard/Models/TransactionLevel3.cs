// <copyright file="TransactionLevel3.cs" company="APIMatic">
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
    /// TransactionLevel3.
    /// </summary>
    public class TransactionLevel3 : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionLevel3"/> class.
        /// </summary>
        public TransactionLevel3()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionLevel3"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="transactionId">transaction_id.</param>
        /// <param name="level3Data">level3_data.</param>
        public TransactionLevel3(
            string id,
            string transactionId,
            Models.Level3Data level3Data)
        {
            this.Id = id;
            this.TransactionId = transactionId;
            this.Level3Data = level3Data;
        }

        /// <summary>
        /// Level 3 ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Transaction ID
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Level 3 data object
        /// </summary>
        [JsonProperty("level3_data")]
        public Models.Level3Data Level3Data { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TransactionLevel3 : ({string.Join(", ", toStringOutput)})";
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
            return obj is TransactionLevel3 other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.TransactionId == null && other.TransactionId == null) || (this.TransactionId?.Equals(other.TransactionId) == true)) &&
                ((this.Level3Data == null && other.Level3Data == null) || (this.Level3Data?.Equals(other.Level3Data) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.TransactionId = {(this.TransactionId == null ? "null" : this.TransactionId)}");
            toStringOutput.Add($"this.Level3Data = {(this.Level3Data == null ? "null" : this.Level3Data.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}