using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace FortisAPI.Standard.Models.Containers
{
    /// <summary>
    /// This is a container class for any-of types.
    /// </summary>
    [JsonConverter(
        typeof(UnionTypeConverter<FilterByValueCase0>),
        new Type[] {
            typeof(PrecisionCase)
        },
        false
    )]
    public abstract class FilterByValueCase0
    {
        /// <summary>
        /// This is Precision case.
        /// </summary>
        /// <returns>
        /// The FilterByValueCase0 instance, wrapping the provided double value.
        /// </returns>
        public static FilterByValueCase0 FromPrecision(double precision)
        {
            return new PrecisionCase().Set(precision);
        }

        /// <summary>
        /// Method to match from the provided any-of cases. Here parameters
        /// represents the callback functions for any-of type cases. All
        /// callback functions must have the same return type T. This typeparam T
        /// represents the type that will be returned after applying the selected
        /// callback function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract T Match<T>(Func<double, T> precision);

        [JsonConverter(typeof(UnionTypeCaseConverter<PrecisionCase, double>), JTokenType.Float)]
        private sealed class PrecisionCase : FilterByValueCase0, ICaseValue<PrecisionCase, double>
        {
            public double _value;

            public override T Match<T>(Func<double, T> precision)
            {
                return precision(_value);
            }

            public PrecisionCase Set(double value)
            {
                _value = value;
                return this;
            }

            public double Get()
            {
                return _value;
            }

            public override string ToString()
            {
                return _value.ToString();
            }
        }
    }
}