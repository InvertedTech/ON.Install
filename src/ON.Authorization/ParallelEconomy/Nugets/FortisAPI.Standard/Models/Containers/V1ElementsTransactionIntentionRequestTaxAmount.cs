using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using System;

namespace FortisAPI.Standard.Models.Containers
{
    /// <summary>
    /// This is a container class for any-of types.
    /// </summary>
    [JsonConverter(
        typeof(UnionTypeConverter<V1ElementsTransactionIntentionRequestTaxAmount>),
        new Type[] {
            typeof(Case0)
        },
        false
    )]
    public abstract class V1ElementsTransactionIntentionRequestTaxAmount
    {
        /// <summary>
        /// This is V1ElementsTransactionIntentionRequestTaxAmountCase0 case.
        /// </summary>
        /// <returns>
        /// The V1ElementsTransactionIntentionRequestTaxAmount instance, wrapping the provided V1ElementsTransactionIntentionRequestTaxAmountCase0 value.
        /// </returns>
        public static V1ElementsTransactionIntentionRequestTaxAmount FromV1ElementsTransactionIntentionRequestTaxAmountCase0(V1ElementsTransactionIntentionRequestTaxAmountCase0 v1ElementsTransactionIntentionRequestTaxAmountCase0)
        {
            return new Case0().Set(v1ElementsTransactionIntentionRequestTaxAmountCase0);
        }

        /// <summary>
        /// Method to match from the provided any-of cases. Here parameters
        /// represents the callback functions for any-of type cases. All
        /// callback functions must have the same return type T. This typeparam T
        /// represents the type that will be returned after applying the selected
        /// callback function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract T Match<T>(Func<V1ElementsTransactionIntentionRequestTaxAmountCase0, T> v1ElementsTransactionIntentionRequestTaxAmountCase0);

        [JsonConverter(typeof(UnionTypeCaseConverter<Case0, V1ElementsTransactionIntentionRequestTaxAmountCase0>))]
        private sealed class Case0 : V1ElementsTransactionIntentionRequestTaxAmount, ICaseValue<Case0, V1ElementsTransactionIntentionRequestTaxAmountCase0>
        {
            public V1ElementsTransactionIntentionRequestTaxAmountCase0 _value;

            public override T Match<T>(Func<V1ElementsTransactionIntentionRequestTaxAmountCase0, T> v1ElementsTransactionIntentionRequestTaxAmountCase0)
            {
                return v1ElementsTransactionIntentionRequestTaxAmountCase0(_value);
            }

            public Case0 Set(V1ElementsTransactionIntentionRequestTaxAmountCase0 value)
            {
                _value = value;
                return this;
            }

            public V1ElementsTransactionIntentionRequestTaxAmountCase0 Get()
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