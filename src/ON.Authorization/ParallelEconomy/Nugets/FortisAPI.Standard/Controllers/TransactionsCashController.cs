// <copyright file="TransactionsCashController.cs" company="APIMatic">
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
    /// TransactionsCashController.
    /// </summary>
    public class TransactionsCashController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsCashController"/> class.
        /// </summary>
        internal TransactionsCashController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Create a new cash refund transaction.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseTransaction response from the API call.</returns>
        public Models.ResponseTransaction CashRefund(
                Models.V1TransactionsCashRefundRequest body)
            => CoreHelper.RunTask(CashRefundAsync(body));

        /// <summary>
        /// Create a new cash refund transaction.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseTransaction response from the API call.</returns>
        public async Task<Models.ResponseTransaction> CashRefundAsync(
                Models.V1TransactionsCashRefundRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseTransaction>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v1/transactions/cash/refund")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context)))
                  .ErrorCase("412", CreateErrorCase("Precondition Failed", (_reason, _context) => new Response412Exception(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Create a new cash sale transaction.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseTransaction response from the API call.</returns>
        public Models.ResponseTransaction CashSale(
                Models.V1TransactionsCashSaleRequest body)
            => CoreHelper.RunTask(CashSaleAsync(body));

        /// <summary>
        /// Create a new cash sale transaction.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseTransaction response from the API call.</returns>
        public async Task<Models.ResponseTransaction> CashSaleAsync(
                Models.V1TransactionsCashSaleRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseTransaction>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v1/transactions/cash/sale")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context)))
                  .ErrorCase("412", CreateErrorCase("Precondition Failed", (_reason, _context) => new Response412Exception(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}