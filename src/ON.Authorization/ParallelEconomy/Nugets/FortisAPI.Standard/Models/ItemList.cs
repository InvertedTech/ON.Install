// <copyright file="ItemList.cs" company="APIMatic">
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
    /// ItemList.
    /// </summary>
    public class ItemList : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemList"/> class.
        /// </summary>
        public ItemList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemList"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="amount">amount.</param>
        public ItemList(
            string name,
            int amount)
        {
            this.Name = name;
            this.Amount = amount;
        }

        /// <summary>
        /// Item's Name, must be unique on the list
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Item's Amount
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ItemList : ({string.Join(", ", toStringOutput)})";
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
            return obj is ItemList other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                this.Amount.Equals(other.Amount);
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.Amount = {this.Amount}");

            base.ToString(toStringOutput);
        }
    }
}