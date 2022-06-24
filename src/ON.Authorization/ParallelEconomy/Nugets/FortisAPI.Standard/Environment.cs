// <copyright file="Environment.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    /// <summary>
    /// Available environments.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Environment
    {
        /// <summary>
        /// Sandbox.
        /// </summary>
        [EnumMember(Value = "sandbox")]
        Sandbox,

        /// <summary>
        /// Production.
        /// </summary>
        [EnumMember(Value = "production")]
        Production,
    }
}
