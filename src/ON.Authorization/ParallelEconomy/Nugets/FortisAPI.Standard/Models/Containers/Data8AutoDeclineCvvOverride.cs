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
        typeof(UnionTypeConverter<Data8AutoDeclineCvvOverride>),
        new Type[] {
            typeof(BooleanCase)
        },
        false
    )]
    public abstract class Data8AutoDeclineCvvOverride
    {
        /// <summary>
        /// This is Boolean case.
        /// </summary>
        /// <returns>
        /// The Data8AutoDeclineCvvOverride instance, wrapping the provided bool value.
        /// </returns>
        public static Data8AutoDeclineCvvOverride FromBoolean(bool boolean)
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
        public abstract T Match<T>(Func<bool, T> boolean);

        [JsonConverter(typeof(UnionTypeCaseConverter<BooleanCase, bool>), JTokenType.Boolean)]
        private sealed class BooleanCase : Data8AutoDeclineCvvOverride, ICaseValue<BooleanCase, bool>
        {
            public bool _value;

            public override T Match<T>(Func<bool, T> boolean)
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