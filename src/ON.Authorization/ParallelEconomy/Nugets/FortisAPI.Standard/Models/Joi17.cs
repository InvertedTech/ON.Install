// <copyright file="Joi17.cs" company="APIMatic">
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
    using FortisAPI.Standard.Models.Containers;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Joi17.
    /// </summary>
    public class Joi17 : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Joi17"/> class.
        /// </summary>
        public Joi17()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Joi17"/> class.
        /// </summary>
        /// <param name="conditions">conditions.</param>
        public Joi17(
            Joi17Conditions conditions = null)
        {
            this.Conditions = conditions;
        }

        /// <summary>
        /// Gets or sets Conditions.
        /// </summary>
        [JsonProperty("conditions", NullValueHandling = NullValueHandling.Ignore)]
        public Joi17Conditions Conditions { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Joi17 : ({string.Join(", ", toStringOutput)})";
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
            return obj is Joi17 other &&                ((this.Conditions == null && other.Conditions == null) || (this.Conditions?.Equals(other.Conditions) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Conditions = {(this.Conditions == null ? "null" : this.Conditions.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}