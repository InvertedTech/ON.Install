using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using System;

namespace FortisAPI.Standard.Models.Containers
{
    /// <summary>
    /// This is a container class for one-of types.
    /// </summary>
    [JsonConverter(
        typeof(UnionTypeConverter<FilterByOperator>),
        new Type[] {
            typeof(Operator1Case)
        },
        true
    )]
    public abstract class FilterByOperator
    {
        /// <summary>
        /// This is Operator1 case.
        /// </summary>
        /// <returns>
        /// The FilterByOperator instance, wrapping the provided Operator1Enum value.
        /// </returns>
        public static FilterByOperator FromOperator1(Operator1Enum operator1)
        {
            return new Operator1Case().Set(operator1);
        }

        /// <summary>
        /// Method to match from the provided one-of cases. Here parameters
        /// represents the callback functions for one-of type cases. All
        /// callback functions must have the same return type T. This typeparam T
        /// represents the type that will be returned after applying the selected
        /// callback function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract T Match<T>(Func<Operator1Enum, T> operator1);

        [JsonConverter(typeof(UnionTypeCaseConverter<Operator1Case, Operator1Enum>))]
        private sealed class Operator1Case : FilterByOperator, ICaseValue<Operator1Case, Operator1Enum>
        {
            public Operator1Enum _value;

            public override T Match<T>(Func<Operator1Enum, T> operator1)
            {
                return operator1(_value);
            }

            public Operator1Case Set(Operator1Enum value)
            {
                _value = value;
                return this;
            }

            public Operator1Enum Get()
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