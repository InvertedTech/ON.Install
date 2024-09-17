// <copyright file="AsyncProcessingController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Exceptions;
    using FortisAPI.Standard.Http.Client;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json.Converters;
    using System.Net.Http;

    /// <summary>
    /// AsyncProcessingController.
    /// </summary>
    public class AsyncProcessingController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncProcessingController"/> class.
        /// </summary>
        internal AsyncProcessingController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Retrieve the current status for a particular code.
        /// </summary>
        /// <param name="statusCode">Required parameter: A [UUID v4](https://datatracker.ietf.org/doc/html/rfc4122) that's unique for the Async Request.</param>
        /// <returns>Returns the Models.ResponseAsyncStatus response from the API call.</returns>
        public Models.ResponseAsyncStatus StatusCheck(
                Guid statusCode)
            => CoreHelper.RunTask(StatusCheckAsync(statusCode));

        /// <summary>
        /// Retrieve the current status for a particular code.
        /// </summary>
        /// <param name="statusCode">Required parameter: A [UUID v4](https://datatracker.ietf.org/doc/html/rfc4122) that's unique for the Async Request.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseAsyncStatus response from the API call.</returns>
        public async Task<Models.ResponseAsyncStatus> StatusCheckAsync(
                Guid statusCode,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseAsyncStatus>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/async/status/{status_code}")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("status_code", statusCode))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}