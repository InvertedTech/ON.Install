// <copyright file="Level3DataController.cs" company="APIMatic">
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
    /// Level3DataController.
    /// </summary>
    public class Level3DataController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Level3DataController"/> class.
        /// </summary>
        internal Level3DataController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Create a new Level3 entry for a MasterCard EndPoint.
        /// </summary>
        /// <param name="transactionId">Required parameter: Transaction ID.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseTransactionLevel3Master response from the API call.</returns>
        public Models.ResponseTransactionLevel3Master CreateANewLevel3EntryForAMasterCard(
                string transactionId,
                Models.V1TransactionsLevel3MasterCardRequest body)
            => CoreHelper.RunTask(CreateANewLevel3EntryForAMasterCardAsync(transactionId, body));

        /// <summary>
        /// Create a new Level3 entry for a MasterCard EndPoint.
        /// </summary>
        /// <param name="transactionId">Required parameter: Transaction ID.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseTransactionLevel3Master response from the API call.</returns>
        public async Task<Models.ResponseTransactionLevel3Master> CreateANewLevel3EntryForAMasterCardAsync(
                string transactionId,
                Models.V1TransactionsLevel3MasterCardRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseTransactionLevel3Master>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v1/transactions/{transaction_id}/level3/master-card")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("transaction_id", transactionId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context)))
                  .ErrorCase("412", CreateErrorCase("Precondition Failed", (_reason, _context) => new Response412Exception(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Create a new Level3 entry for a Visa EndPoint.
        /// </summary>
        /// <param name="transactionId">Required parameter: Transaction ID.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseTransactionLevel3Visa response from the API call.</returns>
        public Models.ResponseTransactionLevel3Visa CreateANewLevel3EntryForAVisa(
                string transactionId,
                Models.V1TransactionsLevel3VisaRequest body)
            => CoreHelper.RunTask(CreateANewLevel3EntryForAVisaAsync(transactionId, body));

        /// <summary>
        /// Create a new Level3 entry for a Visa EndPoint.
        /// </summary>
        /// <param name="transactionId">Required parameter: Transaction ID.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseTransactionLevel3Visa response from the API call.</returns>
        public async Task<Models.ResponseTransactionLevel3Visa> CreateANewLevel3EntryForAVisaAsync(
                string transactionId,
                Models.V1TransactionsLevel3VisaRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseTransactionLevel3Visa>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v1/transactions/{transaction_id}/level3/visa")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("transaction_id", transactionId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context)))
                  .ErrorCase("412", CreateErrorCase("Precondition Failed", (_reason, _context) => new Response412Exception(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Delete a single level3 record EndPoint.
        /// </summary>
        /// <param name="transactionId">Required parameter: Transaction ID.</param>
        /// <param name="level3Id">Required parameter: Level 3 ID.</param>
        /// <returns>Returns the Models.ResponseTransactionLevel3 response from the API call.</returns>
        public Models.ResponseTransactionLevel3 DeleteASingleLevel3Record(
                string transactionId,
                string level3Id)
            => CoreHelper.RunTask(DeleteASingleLevel3RecordAsync(transactionId, level3Id));

        /// <summary>
        /// Delete a single level3 record EndPoint.
        /// </summary>
        /// <param name="transactionId">Required parameter: Transaction ID.</param>
        /// <param name="level3Id">Required parameter: Level 3 ID.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseTransactionLevel3 response from the API call.</returns>
        public async Task<Models.ResponseTransactionLevel3> DeleteASingleLevel3RecordAsync(
                string transactionId,
                string level3Id,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseTransactionLevel3>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v1/transactions/{transaction_id}/level3/{level3_id}")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("transaction_id", transactionId))
                      .Template(_template => _template.Setup("level3_id", level3Id))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// View single level3 record EndPoint.
        /// </summary>
        /// <param name="transactionId">Required parameter: Transaction ID.</param>
        /// <param name="level3Id">Required parameter: Level 3 ID.</param>
        /// <returns>Returns the Models.ResponseTransactionLevel3 response from the API call.</returns>
        public Models.ResponseTransactionLevel3 ViewSingleLevel3Record(
                string transactionId,
                string level3Id)
            => CoreHelper.RunTask(ViewSingleLevel3RecordAsync(transactionId, level3Id));

        /// <summary>
        /// View single level3 record EndPoint.
        /// </summary>
        /// <param name="transactionId">Required parameter: Transaction ID.</param>
        /// <param name="level3Id">Required parameter: Level 3 ID.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseTransactionLevel3 response from the API call.</returns>
        public async Task<Models.ResponseTransactionLevel3> ViewSingleLevel3RecordAsync(
                string transactionId,
                string level3Id,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseTransactionLevel3>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/transactions/{transaction_id}/level3/{level3_id}")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("transaction_id", transactionId))
                      .Template(_template => _template.Setup("level3_id", level3Id))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}