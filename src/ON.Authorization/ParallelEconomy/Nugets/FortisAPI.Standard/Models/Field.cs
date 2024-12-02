// <copyright file="Field.cs" company="APIMatic">
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
    /// Field.
    /// </summary>
    public class Field : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Field"/> class.
        /// </summary>
        public Field()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Field"/> class.
        /// </summary>
        /// <param name="fieldProp">field.</param>
        /// <param name="order">order.</param>
        public Field(
            string fieldProp,
            Models.OrderEnum order)
        {
            this.FieldProp = fieldProp;
            this.Order = order;
        }

        /// <summary>
        /// Field name used on the sort
        /// </summary>
        [JsonProperty("field")]
        public string FieldProp { get; set; }

        /// <summary>
        /// Sort direction ASC/DESC
        /// </summary>
        [JsonProperty("order")]
        public Models.OrderEnum Order { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Field : ({string.Join(", ", toStringOutput)})";
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
            return obj is Field other &&                ((this.FieldProp == null && other.FieldProp == null) || (this.FieldProp?.Equals(other.FieldProp) == true)) &&
                this.Order.Equals(other.Order);
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.FieldProp = {(this.FieldProp == null ? "null" : this.FieldProp)}");
            toStringOutput.Add($"this.Order = {this.Order}");

            base.ToString(toStringOutput);
        }
    }
}