// <copyright file="Joi.cs" company="APIMatic">
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
    /// Joi.
    /// </summary>
    public class Joi : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Joi"/> class.
        /// </summary>
        public Joi()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Joi"/> class.
        /// </summary>
        /// <param name="conditions">conditions.</param>
        public Joi(
            Models.Conditions conditions = null)
        {
            this.Conditions = conditions;
        }

        /// <summary>
        /// Gets or sets Conditions.
        /// </summary>
        [JsonProperty("conditions", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Conditions Conditions { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Joi : ({string.Join(", ", toStringOutput)})";
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
            return obj is Joi other &&                ((this.Conditions == null && other.Conditions == null) || (this.Conditions?.Equals(other.Conditions) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Conditions = {(this.Conditions == null ? "null" : this.Conditions.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}