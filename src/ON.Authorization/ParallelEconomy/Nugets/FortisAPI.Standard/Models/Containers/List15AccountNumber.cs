using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace FortisAPI.Standard.Models.Containers
{
    /// <summary>
    /// This is a container class for one-of types.
    /// </summary>
    [JsonConverter(
        typeof(UnionTypeConverter<List15AccountNumber>),
        new Type[] {
            typeof(MStringCase)
        },
        true
    )]
    public abstract class List15AccountNumber
    {
        /// <summary>
        /// This is String case.
        /// </summary>
        /// <returns>
        /// The List15AccountNumber instance, wrapping the provided string value.
        /// </returns>
        public static List15AccountNumber FromString(string mString)
        {
            return new MStringCase().Set(mString);
        }

        /// <summary>
        /// Method to match from the provided one-of cases. Here parameters
        /// represents the callback functions for one-of type cases. All
        /// callback functions must have the same return type T. This typeparam T
        /// represents the type that will be returned after applying the selected
        /// callback function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract T Match<T>(Func<string, T> mString);

        [JsonConverter(typeof(UnionTypeCaseConverter<MStringCase, string>), JTokenType.String, JTokenType.Null)]
        private sealed class MStringCase : List15AccountNumber, ICaseValue<MStringCase, string>
        {
            public string _value;

            public override T Match<T>(Func<string, T> mString)
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
    }
}