// <copyright file="PricingElement.cs" company="APIMatic">
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
    /// PricingElement.
    /// </summary>
    public class PricingElement : BaseModel
    {
        private string itemDescription;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "item_description", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="PricingElement"/> class.
        /// </summary>
        public PricingElement()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PricingElement"/> class.
        /// </summary>
        /// <param name="itemId">item_id.</param>
        /// <param name="itemValue">item_value.</param>
        /// <param name="itemTerm">item_term.</param>
        /// <param name="itemDescription">item_description.</param>
        public PricingElement(
            int itemId,
            double itemValue,
            int itemTerm,
            string itemDescription = null)
        {
            this.ItemId = itemId;
            this.ItemValue = itemValue;
            this.ItemTerm = itemTerm;
            if (itemDescription != null)
            {
                this.ItemDescription = itemDescription;
            }

        }

        /// <summary>
        /// Item ID.
        /// </summary>
        [JsonProperty("item_id")]
        public int ItemId { get; set; }

        /// <summary>
        /// Item value.
        /// </summary>
        [JsonProperty("item_value")]
        public double ItemValue { get; set; }

        /// <summary>
        /// Item term.
        /// </summary>
        [JsonProperty("item_term")]
        public int ItemTerm { get; set; }

        /// <summary>
        /// Item desciption.
        /// </summary>
        [JsonProperty("item_description")]
        public string ItemDescription
        {
            get
            {
                return this.itemDescription;
            }

            set
            {
                this.shouldSerialize["item_description"] = true;
                this.itemDescription = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PricingElement : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetItemDescription()
        {
            this.shouldSerialize["item_description"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeItemDescription()
        {
            return this.shouldSerialize["item_description"];
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
            return obj is PricingElement other &&                this.ItemId.Equals(other.ItemId) &&
                this.ItemValue.Equals(other.ItemValue) &&
                this.ItemTerm.Equals(other.ItemTerm) &&
                ((this.ItemDescription == null && other.ItemDescription == null) || (this.ItemDescription?.Equals(other.ItemDescription) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ItemId = {this.ItemId}");
            toStringOutput.Add($"this.ItemValue = {this.ItemValue}");
            toStringOutput.Add($"this.ItemTerm = {this.ItemTerm}");
            toStringOutput.Add($"this.ItemDescription = {(this.ItemDescription == null ? "null" : this.ItemDescription)}");

            base.ToString(toStringOutput);
        }
    }
}