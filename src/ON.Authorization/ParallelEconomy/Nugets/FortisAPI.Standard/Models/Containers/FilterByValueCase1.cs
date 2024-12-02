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
        typeof(UnionTypeConverter<FilterByValueCase1>),
        new Type[] {
            typeof(PrecisionCase),
            typeof(MStringCase),
            typeof(BooleanCase)
        },
        false
    )]
    public abstract class FilterByValueCase1
    {
        /// <summary>
        /// This is Precision case.
        /// </summary>
        /// <returns>
        /// The FilterByValueCase1 instance, wrapping the provided double value.
        /// </returns>
        public static FilterByValueCase1 FromPrecision(double precision)
        {
            return new PrecisionCase().Set(precision);
        }

        /// <summary>
        /// This is String case.
        /// </summary>
        /// <returns>
        /// The FilterByValueCase1 instance, wrapping the provided string value.
        /// </returns>
        public static FilterByValueCase1 FromString(string mString)
        {
            return new MStringCase().Set(mString);
        }

        /// <summary>
        /// This is Boolean case.
        /// </summary>
        /// <returns>
        /// The FilterByValueCase1 instance, wrapping the provided bool value.
        /// </returns>
        public static FilterByValueCase1 FromBoolean(bool boolean)
        {
            return new BooleanCase().Set(boolean);
        }

        /// <summary>
        /// Method to match from the provided any-of cases. Here parameters
        /// represents the callback functions for any-of type cases. All
        /// callback functions must have the same return type T. This typeparam T
        /// represents the type that will be returned after applying the selected
        /// callback function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract T Match<T>(
            Func<double, T> precision,
            Func<string, T> mString,
            Func<bool, T> boolean);

        [JsonConverter(typeof(UnionTypeCaseConverter<PrecisionCase, double>), JTokenType.Float)]
        private sealed class PrecisionCase : FilterByValueCase1, ICaseValue<PrecisionCase, double>
        {
            public double _value;

            public override T Match<T>(
                Func<double, T> precision,
                Func<string, T> mString,
                Func<bool, T> boolean)
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

        [JsonConverter(typeof(UnionTypeCaseConverter<MStringCase, string>), JTokenType.String, JTokenType.Null)]
        private sealed class MStringCase : FilterByValueCase1, ICaseValue<MStringCase, string>
        {
            public string _value;

            public override T Match<T>(
                Func<double, T> precision,
                Func<string, T> mString,
                Func<bool, T> boolean)
            {
                return mString(_value);
            }

            public MStringCase Set(string value)
            {
                _value = value;
                return this;
            }

            public string Get()
            {
                return _value;
            }

            public override string ToString()
            {
                return _value?.ToString();
            }
        }

        [JsonConverter(typeof(UnionTypeCaseConverter<BooleanCase, bool>), JTokenType.Boolean)]
        private sealed class BooleanCase : FilterByValueCase1, ICaseValue<BooleanCase, bool>
        {
            public bool _value;

            public override T Match<T>(
                Func<double, T> precision,
                Func<string, T> mString,
                Func<bool, T> boolean)
            {
                return boolean(_value);
            }

            public BooleanCase Set(bool value)
            {
                _value = value;
                return this;
            }

            public bool Get()
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