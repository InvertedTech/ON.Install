// <copyright file="TerminalsController.cs" company="APIMatic">
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
    /// TerminalsController.
    /// </summary>
    public class TerminalsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalsController"/> class.
        /// </summary>
        internal TerminalsController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Create a new terminal device EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseTerminal response from the API call.</returns>
        public Models.ResponseTerminal CreateANewTerminalDevice(
                Models.V1TerminalsRequest body,
                List<Models.Expand37Enum> expand = null)
            => CoreHelper.RunTask(CreateANewTerminalDeviceAsync(body, expand));

        /// <summary>
        /// Create a new terminal device EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseTerminal response from the API call.</returns>
        public async Task<Models.ResponseTerminal> CreateANewTerminalDeviceAsync(
                Models.V1TerminalsRequest body,
                List<Models.Expand37Enum> expand = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseTerminal>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v1/terminals")
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
        /// List all terminals related EndPoint.
        /// </summary>
        /// <param name="page"><![CDATA[Optional parameter: Use this field to specify paginate your results, by using page size and number. You can use one of the following methods: >/endpoint?page={ "number": 1, "size": 50 } > >/endpoint?page[number]=1&page[size]=50 >.]]></param>
        /// <param name="order">Optional parameter: Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json. >/endpoint?order=[{ "key": "created_ts", "operator": "asc"}] > >/endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] >.</param>
        /// <param name="filterBy"><![CDATA[Optional parameter: Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`. >/endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }] > >/endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }] > >/endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }] > >/endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] >.]]></param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="format">Optional parameter: Reporting format, valid values: csv, tsv.</param>
        /// <param name="typeahead">Optional parameter: You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <returns>Returns the Models.ResponseTerminalsCollection response from the API call.</returns>
        public Models.ResponseTerminalsCollection ListAllTerminalsRelated(
                Models.Page page = null,
                List<Models.Order19> order = null,
                List<Models.FilterBy> filterBy = null,
                List<Models.Expand37Enum> expand = null,
                Models.Format1Enum? format = null,
                string typeahead = null,
                List<Models.Field45Enum> fields = null)
            => CoreHelper.RunTask(ListAllTerminalsRelatedAsync(page, order, filterBy, expand, format, typeahead, fields));

        /// <summary>
        /// List all terminals related EndPoint.
        /// </summary>
        /// <param name="page"><![CDATA[Optional parameter: Use this field to specify paginate your results, by using page size and number. You can use one of the following methods: >/endpoint?page={ "number": 1, "size": 50 } > >/endpoint?page[number]=1&page[size]=50 >.]]></param>
        /// <param name="order">Optional parameter: Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json. >/endpoint?order=[{ "key": "created_ts", "operator": "asc"}] > >/endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] >.</param>
        /// <param name="filterBy"><![CDATA[Optional parameter: Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`. >/endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }] > >/endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }] > >/endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }] > >/endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] >.]]></param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="format">Optional parameter: Reporting format, valid values: csv, tsv.</param>
        /// <param name="typeahead">Optional parameter: You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseTerminalsCollection response from the API call.</returns>
        public async Task<Models.ResponseTerminalsCollection> ListAllTerminalsRelatedAsync(
                Models.Page page = null,
                List<Models.Order19> order = null,
                List<Models.FilterBy> filterBy = null,
                List<Models.Expand37Enum> expand = null,
                Models.Format1Enum? format = null,
                string typeahead = null,
                List<Models.Field45Enum> fields = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseTerminalsCollection>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/terminals")
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
        /// View single terminals record EndPoint.
        /// </summary>
        /// <param name="terminalId">Required parameter: Terminal ID.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <returns>Returns the Models.ResponseTerminal response from the API call.</returns>
        public Models.ResponseTerminal ViewSingleTerminalsRecord(
                string terminalId,
                List<Models.Expand37Enum> expand = null,
                List<Models.Field45Enum> fields = null)
            => CoreHelper.RunTask(ViewSingleTerminalsRecordAsync(terminalId, expand, fields));

        /// <summary>
        /// View single terminals record EndPoint.
        /// </summary>
        /// <param name="terminalId">Required parameter: Terminal ID.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseTerminal response from the API call.</returns>
        public async Task<Models.ResponseTerminal> ViewSingleTerminalsRecordAsync(
                string terminalId,
                List<Models.Expand37Enum> expand = null,
                List<Models.Field45Enum> fields = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseTerminal>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/terminals/{terminal_id}")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("terminal_id", terminalId))
                      .Query(_query => _query.Setup("expand", expand?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))
                      .Query(_query => _query.Setup("fields", fields?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Update terminal record EndPoint.
        /// </summary>
        /// <param name="terminalId">Required parameter: Terminal ID.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseTerminal response from the API call.</returns>
        public Models.ResponseTerminal UpdateTerminalRecord(
                string terminalId,
                Models.V1TerminalsRequest1 body,
                List<Models.Expand37Enum> expand = null)
            => CoreHelper.RunTask(UpdateTerminalRecordAsync(terminalId, body, expand));

        /// <summary>
        /// Update terminal record EndPoint.
        /// </summary>
        /// <param name="terminalId">Required parameter: Terminal ID.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseTerminal response from the API call.</returns>
        public async Task<Models.ResponseTerminal> UpdateTerminalRecordAsync(
                string terminalId,
                Models.V1TerminalsRequest1 body,
                List<Models.Expand37Enum> expand = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseTerminal>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(new HttpMethod("PATCH"), "/v1/terminals/{terminal_id}")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("terminal_id", terminalId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))
                      .Query(_query => _query.Setup("expand", expand?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context)))
                  .ErrorCase("412", CreateErrorCase("Precondition Failed", (_reason, _context) => new Response412Exception(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}