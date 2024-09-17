using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using System;

namespace FortisAPI.Standard.Models.Containers
{
    /// <summary>
    /// This is a container class for any-of types.
    /// </summary>
    [JsonConverter(
        typeof(UnionTypeConverter<Joi4Conditions>),
        new Type[] {
            typeof(Conditions4Case),
            typeof(Conditions41Case),
            typeof(Conditions42Case),
            typeof(Conditions43Case)
        },
        false
    )]
    public abstract class Joi4Conditions
    {
        /// <summary>
        /// This is Conditions4 case.
        /// </summary>
        /// <returns>
        /// The Joi4Conditions instance, wrapping the provided Conditions4 value.
        /// </returns>
        public static Joi4Conditions FromConditions4(Conditions4 conditions4)
        {
            return new Conditions4Case().Set(conditions4);
        }

        /// <summary>
        /// This is Conditions41 case.
        /// </summary>
        /// <returns>
        /// The Joi4Conditions instance, wrapping the provided Conditions41 value.
        /// </returns>
        public static Joi4Conditions FromConditions41(Conditions41 conditions41)
        {
            return new Conditions41Case().Set(conditions41);
        }

        /// <summary>
        /// This is Conditions42 case.
        /// </summary>
        /// <returns>
        /// The Joi4Conditions instance, wrapping the provided Conditions42 value.
        /// </returns>
        public static Joi4Conditions FromConditions42(Conditions42 conditions42)
        {
            return new Conditions42Case().Set(conditions42);
        }

        /// <summary>
        /// This is Conditions43 case.
        /// </summary>
        /// <returns>
        /// The Joi4Conditions instance, wrapping the provided Conditions43 value.
        /// </returns>
        public static Joi4Conditions FromConditions43(Conditions43 conditions43)
        {
            return new Conditions43Case().Set(conditions43);
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
            Func<Conditions4, T> conditions4,
            Func<Conditions41, T> conditions41,
            Func<Conditions42, T> conditions42,
            Func<Conditions43, T> conditions43);

        [JsonConverter(typeof(UnionTypeCaseConverter<Conditions4Case, Conditions4>))]
        private sealed class Conditions4Case : Joi4Conditions, ICaseValue<Conditions4Case, Conditions4>
        {
            public Conditions4 _value;

            public override T Match<T>(
                Func<Conditions4, T> conditions4,
                Func<Conditions41, T> conditions41,
                Func<Conditions42, T> conditions42,
                Func<Conditions43, T> conditions43)
            {
                return conditions4(_value);
            }

            public Conditions4Case Set(Conditions4 value)
            {
                _value = value;
                return this;
            }

            public Conditions4 Get()
            {
                return _value;
            }

            public override string ToString()
            {
                return _value?.ToString();
            }
        }

        [JsonConverter(typeof(UnionTypeCaseConverter<Conditions41Case, Conditions41>))]
        private sealed class Conditions41Case : Joi4Conditions, ICaseValue<Conditions41Case, Conditions41>
        {
            public Conditions41 _value;

            public override T Match<T>(
                Func<Conditions4, T> conditions4,
                Func<Conditions41, T> conditions41,
                Func<Conditions42, T> conditions42,
                Func<Conditions43, T> conditions43)
            {
                return conditions41(_value);
            }

            public Conditions41Case Set(Conditions41 value)
            {
                _value = value;
                return this;
            }

            public Conditions41 Get()
            {
                return _value;
            }

            public override string ToString()
            {
                return _value?.ToString();
            }
        }

        [JsonConverter(typeof(UnionTypeCaseConverter<Conditions42Case, Conditions42>))]
        private sealed class Conditions42Case : Joi4Conditions, ICaseValue<Conditions42Case, Conditions42>
        {
            public Conditions42 _value;

            public override T Match<T>(
                Func<Conditions4, T> conditions4,
                Func<Conditions41, T> conditions41,
                Func<Conditions42, T> conditions42,
                Func<Conditions43, T> conditions43)
            {
                return conditions42(_value);
            }

            public Conditions42Case Set(Conditions42 value)
            {
                _value = value;
                return this;
            }

            public Conditions42 Get()
            {
                return _value;
            }

            public override string ToString()
            {
                return _value?.ToString();
            }
        }

        [JsonConverter(typeof(UnionTypeCaseConverter<Conditions43Case, Conditions43>))]
        private sealed class Conditions43Case : Joi4Conditions, ICaseValue<Conditions43Case, Conditions43>
        {
            public Conditions43 _value;

            public override T Match<T>(
                Func<Conditions4, T> conditions4,
                Func<Conditions41, T> conditions41,
                Func<Conditions42, T> conditions42,
                Func<Conditions43, T> conditions43)
            {
                return conditions43(_value);
            }

            public Conditions43Case Set(Conditions43 value)
            {
                _value = value;
                return this;
            }

            public Conditions43 Get()
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