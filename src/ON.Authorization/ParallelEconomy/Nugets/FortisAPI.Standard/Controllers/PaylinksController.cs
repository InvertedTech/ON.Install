// <copyright file="PaylinksController.cs" company="APIMatic">
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
    /// PaylinksController.
    /// </summary>
    public class PaylinksController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaylinksController"/> class.
        /// </summary>
        internal PaylinksController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Create a new Paylink EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponsePaylink response from the API call.</returns>
        public Models.ResponsePaylink CreateANewPaylink(
                Models.V1PaylinksRequest body,
                List<Models.Expand14Enum> expand = null)
            => CoreHelper.RunTask(CreateANewPaylinkAsync(body, expand));

        /// <summary>
        /// Create a new Paylink EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponsePaylink response from the API call.</returns>
        public async Task<Models.ResponsePaylink> CreateANewPaylinkAsync(
                Models.V1PaylinksRequest body,
                List<Models.Expand14Enum> expand = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponsePaylink>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v1/paylinks")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))
                      .Query(_query => _query.Setup("expand", expand?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context)))
                  .ErrorCase("412", CreateErrorCase("Precondition Failed", (_reason, _context) => new Response412Exception(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// List all Paylinks EndPoint.
        /// </summary>
        /// <param name="page"><![CDATA[Optional parameter: Use this field to specify paginate your results, by using page size and number. You can use one of the following methods: >/endpoint?page={ "number": 1, "size": 50 } > >/endpoint?page[number]=1&page[size]=50 >.]]></param>
        /// <param name="order">Optional parameter: Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json. >/endpoint?order=[{ "key": "created_ts", "operator": "asc"}] > >/endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] >.</param>
        /// <param name="filterBy"><![CDATA[Optional parameter: Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`. >/endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }] > >/endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }] > >/endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }] > >/endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] >.]]></param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="format">Optional parameter: Reporting format, valid values: csv, tsv.</param>
        /// <param name="typeahead">Optional parameter: You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <returns>Returns the Models.ResponsePaylinksCollection response from the API call.</returns>
        public Models.ResponsePaylinksCollection ListAllPaylinks(
                Models.Page page = null,
                List<Models.Order19> order = null,
                List<Models.FilterBy> filterBy = null,
                List<Models.Expand15Enum> expand = null,
                Models.Format1Enum? format = null,
                string typeahead = null,
                List<Models.Field35Enum> fields = null)
            => CoreHelper.RunTask(ListAllPaylinksAsync(page, order, filterBy, expand, format, typeahead, fields));

        /// <summary>
        /// List all Paylinks EndPoint.
        /// </summary>
        /// <param name="page"><![CDATA[Optional parameter: Use this field to specify paginate your results, by using page size and number. You can use one of the following methods: >/endpoint?page={ "number": 1, "size": 50 } > >/endpoint?page[number]=1&page[size]=50 >.]]></param>
        /// <param name="order">Optional parameter: Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json. >/endpoint?order=[{ "key": "created_ts", "operator": "asc"}] > >/endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] >.</param>
        /// <param name="filterBy"><![CDATA[Optional parameter: Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`. >/endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }] > >/endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }] > >/endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }] > >/endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] >.]]></param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="format">Optional parameter: Reporting format, valid values: csv, tsv.</param>
        /// <param name="typeahead">Optional parameter: You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponsePaylinksCollection response from the API call.</returns>
        public async Task<Models.ResponsePaylinksCollection> ListAllPaylinksAsync(
                Models.Page page = null,
                List<Models.Order19> order = null,
                List<Models.FilterBy> filterBy = null,
                List<Models.Expand15Enum> expand = null,
                Models.Format1Enum? format = null,
                string typeahead = null,
                List<Models.Field35Enum> fields = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponsePaylinksCollection>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/paylinks")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("page", page))
                      .Query(_query => _query.Setup("order", order))
                      .Query(_query => _query.Setup("filter_by", filterBy))
                      .Query(_query => _query.Setup("expand", expand?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))
                      .Query(_query => _query.Setup("_format", (format.HasValue) ? ApiHelper.JsonSerialize(format.Value).Trim('\"') : null))
                      .Query(_query => _query.Setup("_typeahead", typeahead))
                      .Query(_query => _query.Setup("fields", fields?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Delete Paylink EndPoint.
        /// </summary>
        /// <param name="paylinkId">Required parameter: Paylink Id.</param>
        /// <returns>Returns the Models.ResponsePaylink response from the API call.</returns>
        public Models.ResponsePaylink DeletePaylink(
                string paylinkId)
            => CoreHelper.RunTask(DeletePaylinkAsync(paylinkId));

        /// <summary>
        /// Delete Paylink EndPoint.
        /// </summary>
        /// <param name="paylinkId">Required parameter: Paylink Id.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponsePaylink response from the API call.</returns>
        public async Task<Models.ResponsePaylink> DeletePaylinkAsync(
                string paylinkId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponsePaylink>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v1/paylinks/{paylink_id}")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("paylink_id", paylinkId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// View Single Paylink EndPoint.
        /// </summary>
        /// <param name="paylinkId">Required parameter: Paylink Id.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <returns>Returns the Models.ResponsePaylink response from the API call.</returns>
        public Models.ResponsePaylink ViewSinglePaylink(
                string paylinkId,
                List<Models.Expand15Enum> expand = null,
                List<Models.Field35Enum> fields = null)
            => CoreHelper.RunTask(ViewSinglePaylinkAsync(paylinkId, expand, fields));

        /// <summary>
        /// View Single Paylink EndPoint.
        /// </summary>
        /// <param name="paylinkId">Required parameter: Paylink Id.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponsePaylink response from the API call.</returns>
        public async Task<Models.ResponsePaylink> ViewSinglePaylinkAsync(
                string paylinkId,
                List<Models.Expand15Enum> expand = null,
                List<Models.Field35Enum> fields = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponsePaylink>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/paylinks/{paylink_id}")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("paylink_id", paylinkId))
                      .Query(_query => _query.Setup("expand", expand?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))
                      .Query(_query => _query.Setup("fields", fields?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Update Paylink EndPoint.
        /// </summary>
        /// <param name="paylinkId">Required parameter: Paylink Id.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponsePaylink response from the API call.</returns>
        public Models.ResponsePaylink UpdatePaylink(
                string paylinkId,
                Models.V1PaylinksRequest1 body,
                List<Models.Expand14Enum> expand = null)
            => CoreHelper.RunTask(UpdatePaylinkAsync(paylinkId, body, expand));

        /// <summary>
        /// Update Paylink EndPoint.
        /// </summary>
        /// <param name="paylinkId">Required parameter: Paylink Id.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponsePaylink response from the API call.</returns>
        public async Task<Models.ResponsePaylink> UpdatePaylinkAsync(
                string paylinkId,
                Models.V1PaylinksRequest1 body,
                List<Models.Expand14Enum> expand = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponsePaylink>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(new HttpMethod("PATCH"), "/v1/paylinks/{paylink_id}")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("paylink_id", paylinkId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))
                      .Query(_query => _query.Setup("expand", expand?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context)))
                  .ErrorCase("412", CreateErrorCase("Precondition Failed", (_reason, _context) => new Response412Exception(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Resend Paylink EndPoint.
        /// </summary>
        /// <param name="paylinkId">Required parameter: Paylink Id.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="email">Optional parameter: Resend Email.</param>
        /// <param name="sms">Optional parameter: Resend SMS.</param>
        /// <returns>Returns the Models.ResponsePaylink response from the API call.</returns>
        public Models.ResponsePaylink ResendPaylink(
                string paylinkId,
                List<Models.Expand14Enum> expand = null,
                Models.EmailEnum? email = null,
                Models.SmsEnum? sms = null)
            => CoreHelper.RunTask(ResendPaylinkAsync(paylinkId, expand, email, sms));

        /// <summary>
        /// Resend Paylink EndPoint.
        /// </summary>
        /// <param name="paylinkId">Required parameter: Paylink Id.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="email">Optional parameter: Resend Email.</param>
        /// <param name="sms">Optional parameter: Resend SMS.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponsePaylink response from the API call.</returns>
        public async Task<Models.ResponsePaylink> ResendPaylinkAsync(
                string paylinkId,
                List<Models.Expand14Enum> expand = null,
                Models.EmailEnum? email = null,
                Models.SmsEnum? sms = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponsePaylink>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v1/paylinks/{paylink_id}/resend")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("paylink_id", paylinkId))
                      .Query(_query => _query.Setup("expand", expand?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))
                      .Query(_query => _query.Setup("email", (email.HasValue) ? (int?)email.Value : null))
                      .Query(_query => _query.Setup("sms", (sms.HasValue) ? (int?)sms.Value : null))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}