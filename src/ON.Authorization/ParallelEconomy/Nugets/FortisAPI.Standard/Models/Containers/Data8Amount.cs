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
        typeof(UnionTypeConverter<Data8Amount>),
        new Type[] {
            typeof(NumberCase),
            typeof(Case1)
        },
        false
    )]
    public abstract class Data8Amount
    {
        /// <summary>
        /// This is Number case.
        /// </summary>
        /// <returns>
        /// The Data8Amount instance, wrapping the provided int value.
        /// </returns>
        public static Data8Amount FromNumber(int number)
        {
            return new NumberCase().Set(number);
        }

        /// <summary>
        /// This is Data8AmountCase1 case.
        /// </summary>
        /// <returns>
        /// The Data8Amount instance, wrapping the provided Data8AmountCase1 value.
        /// </returns>
        public static Data8Amount FromData8AmountCase1(Data8AmountCase1 data8AmountCase1)
        {
            return new Case1().Set(data8AmountCase1);
        }

        /// <summary>
        /// Method to match from the provided any-of cases. Here parameters
        /// represents the callback functions for any-of type cases. All
        /// callback functions must have the same return type T. This typeparam T
        /// represents the type that will be returned after applying the selected
        /// callback function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract T Match<T>(Func<int, T> number, Func<Data8AmountCase1, T> data8AmountCase1);

        [JsonConverter(typeof(UnionTypeCaseConverter<NumberCase, int>), JTokenType.Integer)]
        private sealed class NumberCase : Data8Amount, ICaseValue<NumberCase, int>
        {
            public int _value;

            public override T Match<T>(Func<int, T> number, Func<Data8AmountCase1, T> data8AmountCase1)
            {
                return number(_value);
            }

            public NumberCase Set(int value)
            {
                _value = value;
                return this;
            }

            public int Get()
            {
                return _value;
            }

            public override string ToString()
            {
                return _value.ToString();
            }
        }

        [JsonConverter(typeof(UnionTypeCaseConverter<Case1, Data8AmountCase1>))]
        private sealed class Case1 : Data8Amount, ICaseValue<Case1, Data8AmountCase1>
        {
            public Data8AmountCase1 _value;

            public override T Match<T>(Func<int, T> number, Func<Data8AmountCase1, T> data8AmountCase1)
            {
                return data8AmountCase1(_value);
            }

            public Case1 Set(Data8AmountCase1 value)
            {
                _value = value;
                return this;
            }

            public Data8AmountCase1 Get()
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