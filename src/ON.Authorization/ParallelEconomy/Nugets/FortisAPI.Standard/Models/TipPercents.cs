// <copyright file="TipPercents.cs" company="APIMatic">
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
    /// TipPercents.
    /// </summary>
    public class TipPercents : BaseModel
    {
        private int? percent1;
        private int? percent2;
        private int? percent3;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "percent_1", false },
            { "percent_2", false },
            { "percent_3", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="TipPercents"/> class.
        /// </summary>
        public TipPercents()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TipPercents"/> class.
        /// </summary>
        /// <param name="percent1">percent_1.</param>
        /// <param name="percent2">percent_2.</param>
        /// <param name="percent3">percent_3.</param>
        public TipPercents(
            int? percent1 = null,
            int? percent2 = null,
            int? percent3 = null)
        {
            if (percent1 != null)
            {
                this.Percent1 = percent1;
            }

            if (percent2 != null)
            {
                this.Percent2 = percent2;
            }

            if (percent3 != null)
            {
                this.Percent3 = percent3;
            }

        }

        /// <summary>
        /// field can only contain a value from 0 to 99, if 1 field is NULL, all fields must be null.
        /// </summary>
        [JsonProperty("percent_1")]
        public int? Percent1
        {
            get
            {
                return this.percent1;
            }

            set
            {
                this.shouldSerialize["percent_1"] = true;
                this.percent1 = value;
            }
        }

        /// <summary>
        /// field can only contain a value from 0 to 99, if 1 field is NULL, all fields must be null.
        /// </summary>
        [JsonProperty("percent_2")]
        public int? Percent2
        {
            get
            {
                return this.percent2;
            }

            set
            {
                this.shouldSerialize["percent_2"] = true;
                this.percent2 = value;
            }
        }

        /// <summary>
        /// field can only contain a value from 0 to 99, if 1 field is NULL, all fields must be null.
        /// </summary>
        [JsonProperty("percent_3")]
        public int? Percent3
        {
            get
            {
                return this.percent3;
            }

            set
            {
                this.shouldSerialize["percent_3"] = true;
                this.percent3 = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TipPercents : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPercent1()
        {
            this.shouldSerialize["percent_1"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPercent2()
        {
            this.shouldSerialize["percent_2"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPercent3()
        {
            this.shouldSerialize["percent_3"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePercent1()
        {
            return this.shouldSerialize["percent_1"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePercent2()
        {
            return this.shouldSerialize["percent_2"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePercent3()
        {
            return this.shouldSerialize["percent_3"];
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
            return obj is TipPercents other &&                ((this.Percent1 == null && other.Percent1 == null) || (this.Percent1?.Equals(other.Percent1) == true)) &&
                ((this.Percent2 == null && other.Percent2 == null) || (this.Percent2?.Equals(other.Percent2) == true)) &&
                ((this.Percent3 == null && other.Percent3 == null) || (this.Percent3?.Equals(other.Percent3) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Percent1 = {(this.Percent1 == null ? "null" : this.Percent1.ToString())}");
            toStringOutput.Add($"this.Percent2 = {(this.Percent2 == null ? "null" : this.Percent2.ToString())}");
            toStringOutput.Add($"this.Percent3 = {(this.Percent3 == null ? "null" : this.Percent3.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}