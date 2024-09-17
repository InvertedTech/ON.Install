using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using System;

namespace FortisAPI.Standard.Models.Containers
{
    /// <summary>
    /// This is a container class for one-of types.
    /// </summary>
    [JsonConverter(
        typeof(UnionTypeConverter<FilterByValue>),
        new Type[] {
            typeof(Case0),
            typeof(Case1)
        },
        true
    )]
    public abstract class FilterByValue
    {
        /// <summary>
        /// This is FilterByValueCase0 case.
        /// </summary>
        /// <returns>
        /// The FilterByValue instance, wrapping the provided FilterByValueCase0 value.
        /// </returns>
        public static FilterByValue FromFilterByValueCase0(FilterByValueCase0 filterByValueCase0)
        {
            return new Case0().Set(filterByValueCase0);
        }

        /// <summary>
        /// This is FilterByValueCase1 case.
        /// </summary>
        /// <returns>
        /// The FilterByValue instance, wrapping the provided FilterByValueCase1 value.
        /// </returns>
        public static FilterByValue FromFilterByValueCase1(FilterByValueCase1 filterByValueCase1)
        {
            return new Case1().Set(filterByValueCase1);
        }

        /// <summary>
        /// Method to match from the provided one-of cases. Here parameters
        /// represents the callback functions for one-of type cases. All
        /// callback functions must have the same return type T. This typeparam T
        /// represents the type that will be returned after applying the selected
        /// callback function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract T Match<T>(Func<FilterByValueCase0, T> filterByValueCase0, Func<FilterByValueCase1, T> filterByValueCase1);

        [JsonConverter(typeof(UnionTypeCaseConverter<Case0, FilterByValueCase0>))]
        private sealed class Case0 : FilterByValue, ICaseValue<Case0, FilterByValueCase0>
        {
            public FilterByValueCase0 _value;

            public override T Match<T>(Func<FilterByValueCase0, T> filterByValueCase0, Func<FilterByValueCase1, T> filterByValueCase1)
            {
                return filterByValueCase0(_value);
            }

            public Case0 Set(FilterByValueCase0 value)
            {
                _value = value;
                return this;
            }

            public FilterByValueCase0 Get()
            {
                return _value;
            }

            public override string ToString()
            {
                return _value?.ToString();
            }
        }

        [JsonConverter(typeof(UnionTypeCaseConverter<Case1, FilterByValueCase1>))]
        private sealed class Case1 : FilterByValue, ICaseValue<Case1, FilterByValueCase1>
        {
            public FilterByValueCase1 _value;

            public override T Match<T>(Func<FilterByValueCase0, T> filterByValueCase0, Func<FilterByValueCase1, T> filterByValueCase1)
            {
                return filterByValueCase1(_value);
            }

            public Case1 Set(FilterByValueCase1 value)
            {
                _value = value;
                return this;
            }

            public FilterByValueCase1 Get()
            {
                return _value;
            }

            public override string ToString()
            {
                return _value?.ToString();
            }
        }
    }
}