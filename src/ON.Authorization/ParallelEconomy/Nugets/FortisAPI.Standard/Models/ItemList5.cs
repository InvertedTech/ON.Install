// <copyright file="ItemList5.cs" company="APIMatic">
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
    /// ItemList5.
    /// </summary>
    public class ItemList5 : BaseModel
    {
        private string name;
        private int? amount;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "name", false },
            { "amount", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemList5"/> class.
        /// </summary>
        public ItemList5()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemList5"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="amount">amount.</param>
        public ItemList5(
            string name = null,
            int? amount = null)
        {
            if (name != null)
            {
                this.Name = name;
            }

            if (amount != null)
            {
                this.Amount = amount;
            }

        }

        /// <summary>
        /// Item's Name, must be unique on the list
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.shouldSerialize["name"] = true;
                this.name = value;
            }
        }

        /// <summary>
        /// Item's Amount
        /// </summary>
        [JsonProperty("amount")]
        public int? Amount
        {
            get
            {
                return this.amount;
            }

            set
            {
                this.shouldSerialize["amount"] = true;
                this.amount = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ItemList5 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetName()
        {
            this.shouldSerialize["name"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAmount()
        {
            this.shouldSerialize["amount"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAmount()
        {
            return this.shouldSerialize["amount"];
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
            return obj is ItemList5 other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Amount == null && other.Amount == null) || (this.Amount?.Equals(other.Amount) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.Amount = {(this.Amount == null ? "null" : this.Amount.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}