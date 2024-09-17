using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using System;

namespace FortisAPI.Standard.Models.Containers
{
    /// <summary>
    /// This is a container class for any-of types.
    /// </summary>
    [JsonConverter(
        typeof(UnionTypeConverter<Data8TaxAmount>),
        new Type[] {
            typeof(Case0)
        },
        false
    )]
    public abstract class Data8TaxAmount
    {
        /// <summary>
        /// This is Data8TaxAmountCase0 case.
        /// </summary>
        /// <returns>
        /// The Data8TaxAmount instance, wrapping the provided Data8TaxAmountCase0 value.
        /// </returns>
        public static Data8TaxAmount FromData8TaxAmountCase0(Data8TaxAmountCase0 data8TaxAmountCase0)
        {
            return new Case0().Set(data8TaxAmountCase0);
        }

        /// <summary>
        /// Method to match from the provided any-of cases. Here parameters
        /// represents the callback functions for any-of type cases. All
        /// callback functions must have the same return type T. This typeparam T
        /// represents the type that will be returned after applying the selected
        /// callback function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract T Match<T>(Func<Data8TaxAmountCase0, T> data8TaxAmountCase0);

        [JsonConverter(typeof(UnionTypeCaseConverter<Case0, Data8TaxAmountCase0>))]
        private sealed class Case0 : Data8TaxAmount, ICaseValue<Case0, Data8TaxAmountCase0>
        {
            public Data8TaxAmountCase0 _value;

            public override T Match<T>(Func<Data8TaxAmountCase0, T> data8TaxAmountCase0)
            {
                return data8TaxAmountCase0(_value);
            }

            public Case0 Set(Data8TaxAmountCase0 value)
            {
                _value = value;
                return this;
            }

            public Data8TaxAmountCase0 Get()
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