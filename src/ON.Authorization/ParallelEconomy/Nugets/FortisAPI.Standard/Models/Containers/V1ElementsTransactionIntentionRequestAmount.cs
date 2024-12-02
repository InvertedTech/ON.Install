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
        typeof(UnionTypeConverter<V1ElementsTransactionIntentionRequestAmount>),
        new Type[] {
            typeof(NumberCase),
            typeof(Case1)
        },
        false
    )]
    public abstract class V1ElementsTransactionIntentionRequestAmount
    {
        /// <summary>
        /// This is Number case.
        /// </summary>
        /// <returns>
        /// The V1ElementsTransactionIntentionRequestAmount instance, wrapping the provided int value.
        /// </returns>
        public static V1ElementsTransactionIntentionRequestAmount FromNumber(int number)
        {
            return new NumberCase().Set(number);
        }

        /// <summary>
        /// This is V1ElementsTransactionIntentionRequestAmountCase1 case.
        /// </summary>
        /// <returns>
        /// The V1ElementsTransactionIntentionRequestAmount instance, wrapping the provided V1ElementsTransactionIntentionRequestAmountCase1 value.
        /// </returns>
        public static V1ElementsTransactionIntentionRequestAmount FromV1ElementsTransactionIntentionRequestAmountCase1(V1ElementsTransactionIntentionRequestAmountCase1 v1ElementsTransactionIntentionRequestAmountCase1)
        {
            return new Case1().Set(v1ElementsTransactionIntentionRequestAmountCase1);
        }

        /// <summary>
        /// Method to match from the provided any-of cases. Here parameters
        /// represents the callback functions for any-of type cases. All
        /// callback functions must have the same return type T. This typeparam T
        /// represents the type that will be returned after applying the selected
        /// callback function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract T Match<T>(Func<int, T> number, Func<V1ElementsTransactionIntentionRequestAmountCase1, T> v1ElementsTransactionIntentionRequestAmountCase1);

        [JsonConverter(typeof(UnionTypeCaseConverter<NumberCase, int>), JTokenType.Integer)]
        private sealed class NumberCase : V1ElementsTransactionIntentionRequestAmount, ICaseValue<NumberCase, int>
        {
            public int _value;

            public override T Match<T>(Func<int, T> number, Func<V1ElementsTransactionIntentionRequestAmountCase1, T> v1ElementsTransactionIntentionRequestAmountCase1)
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

        [JsonConverter(typeof(UnionTypeCaseConverter<Case1, V1ElementsTransactionIntentionRequestAmountCase1>))]
        private sealed class Case1 : V1ElementsTransactionIntentionRequestAmount, ICaseValue<Case1, V1ElementsTransactionIntentionRequestAmountCase1>
        {
            public V1ElementsTransactionIntentionRequestAmountCase1 _value;

            public override T Match<T>(Func<int, T> number, Func<V1ElementsTransactionIntentionRequestAmountCase1, T> v1ElementsTransactionIntentionRequestAmountCase1)
            {
                return v1ElementsTransactionIntentionRequestAmountCase1(_value);
            }

            public Case1 Set(V1ElementsTransactionIntentionRequestAmountCase1 value)
            {
                _value = value;
                return this;
            }

            public V1ElementsTransactionIntentionRequestAmountCase1 Get()
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