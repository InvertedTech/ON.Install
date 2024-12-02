using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using System;

namespace FortisAPI.Standard.Models.Containers
{
    /// <summary>
    /// This is a container class for any-of types.
    /// </summary>
    [JsonConverter(
        typeof(UnionTypeConverter<V1ElementsTransactionIntentionRequestSecondaryAmount>),
        new Type[] {
            typeof(Case0)
        },
        false
    )]
    public abstract class V1ElementsTransactionIntentionRequestSecondaryAmount
    {
        /// <summary>
        /// This is V1ElementsTransactionIntentionRequestSecondaryAmountCase0 case.
        /// </summary>
        /// <returns>
        /// The V1ElementsTransactionIntentionRequestSecondaryAmount instance, wrapping the provided V1ElementsTransactionIntentionRequestSecondaryAmountCase0 value.
        /// </returns>
        public static V1ElementsTransactionIntentionRequestSecondaryAmount FromV1ElementsTransactionIntentionRequestSecondaryAmountCase0(V1ElementsTransactionIntentionRequestSecondaryAmountCase0 v1ElementsTransactionIntentionRequestSecondaryAmountCase0)
        {
            return new Case0().Set(v1ElementsTransactionIntentionRequestSecondaryAmountCase0);
        }

        /// <summary>
        /// Method to match from the provided any-of cases. Here parameters
        /// represents the callback functions for any-of type cases. All
        /// callback functions must have the same return type T. This typeparam T
        /// represents the type that will be returned after applying the selected
        /// callback function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract T Match<T>(Func<V1ElementsTransactionIntentionRequestSecondaryAmountCase0, T> v1ElementsTransactionIntentionRequestSecondaryAmountCase0);

        [JsonConverter(typeof(UnionTypeCaseConverter<Case0, V1ElementsTransactionIntentionRequestSecondaryAmountCase0>))]
        private sealed class Case0 : V1ElementsTransactionIntentionRequestSecondaryAmount, ICaseValue<Case0, V1ElementsTransactionIntentionRequestSecondaryAmountCase0>
        {
            public V1ElementsTransactionIntentionRequestSecondaryAmountCase0 _value;

            public override T Match<T>(Func<V1ElementsTransactionIntentionRequestSecondaryAmountCase0, T> v1ElementsTransactionIntentionRequestSecondaryAmountCase0)
            {
                return v1ElementsTransactionIntentionRequestSecondaryAmountCase0(_value);
            }

            public Case0 Set(V1ElementsTransactionIntentionRequestSecondaryAmountCase0 value)
            {
                _value = value;
                return this;
            }

            public V1ElementsTransactionIntentionRequestSecondaryAmountCase0 Get()
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