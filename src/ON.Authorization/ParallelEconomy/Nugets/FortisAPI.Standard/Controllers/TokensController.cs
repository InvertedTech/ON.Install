// <copyright file="TokensController.cs" company="APIMatic">
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
    /// TokensController.
    /// </summary>
    public class TokensController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokensController"/> class.
        /// </summary>
        internal TokensController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Create a new ACH Token EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken CreateANewACHToken(
                Models.V1TokensAchRequest body,
                List<Models.Expand44Enum> expand = null)
            => CoreHelper.RunTask(CreateANewACHTokenAsync(body, expand));

        /// <summary>
        /// Create a new ACH Token EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> CreateANewACHTokenAsync(
                Models.V1TokensAchRequest body,
                List<Models.Expand44Enum> expand = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseToken>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v1/tokens/ach")
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
        /// Create a new Credit Card Token EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken CreateANewCreditCardToken(
                Models.V1TokensCcRequest body,
                List<Models.Expand44Enum> expand = null)
            => CoreHelper.RunTask(CreateANewCreditCardTokenAsync(body, expand));

        /// <summary>
        /// Create a new Credit Card Token EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> CreateANewCreditCardTokenAsync(
                Models.V1TokensCcRequest body,
                List<Models.Expand44Enum> expand = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseToken>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v1/tokens/cc")
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
        /// Create a new Previous Transaction Token EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken CreateANewPreviousTransactionToken(
                Models.V1TokensPreviousTransactionRequest body,
                List<Models.Expand44Enum> expand = null)
            => CoreHelper.RunTask(CreateANewPreviousTransactionTokenAsync(body, expand));

        /// <summary>
        /// Create a new Previous Transaction Token EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> CreateANewPreviousTransactionTokenAsync(
                Models.V1TokensPreviousTransactionRequest body,
                List<Models.Expand44Enum> expand = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseToken>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v1/tokens/previous-transaction")
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
        /// Create a new Terminal Token EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken CreateANewTerminalToken(
                Models.V1TokensTerminalRequest body,
                List<Models.Expand44Enum> expand = null)
            => CoreHelper.RunTask(CreateANewTerminalTokenAsync(body, expand));

        /// <summary>
        /// Create a new Terminal Token EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> CreateANewTerminalTokenAsync(
                Models.V1TokensTerminalRequest body,
                List<Models.Expand44Enum> expand = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseToken>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v1/tokens/terminal")
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
        /// Create a new Ticket Token EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken CreateANewTicketToken(
                Models.V1TokensTicketRequest body,
                List<Models.Expand44Enum> expand = null)
            => CoreHelper.RunTask(CreateANewTicketTokenAsync(body, expand));

        /// <summary>
        /// Create a new Ticket Token EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> CreateANewTicketTokenAsync(
                Models.V1TokensTicketRequest body,
                List<Models.Expand44Enum> expand = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseToken>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v1/tokens/ticket")
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
        /// Create a new Wallet Token EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken CreateANewWalletToken(
                Models.V1TokensWalletRequest body,
                List<Models.Expand44Enum> expand = null)
            => CoreHelper.RunTask(CreateANewWalletTokenAsync(body, expand));

        /// <summary>
        /// Create a new Wallet Token EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> CreateANewWalletTokenAsync(
                Models.V1TokensWalletRequest body,
                List<Models.Expand44Enum> expand = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseToken>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v1/tokens/wallet")
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
        /// Delete a single token record EndPoint.
        /// </summary>
        /// <param name="tokenId">Required parameter: A unique, system-generated identifier for the Token..</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken DeleteASingleTokenRecord(
                string tokenId)
            => CoreHelper.RunTask(DeleteASingleTokenRecordAsync(tokenId));

        /// <summary>
        /// Delete a single token record EndPoint.
        /// </summary>
        /// <param name="tokenId">Required parameter: A unique, system-generated identifier for the Token..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> DeleteASingleTokenRecordAsync(
                string tokenId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseToken>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v1/tokens/{token_id}")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("token_id", tokenId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// View single token record EndPoint.
        /// </summary>
        /// <param name="tokenId">Required parameter: A unique, system-generated identifier for the Token..</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken ViewSingleTokenRecord(
                string tokenId,
                List<Models.Expand44Enum> expand = null,
                List<Models.Field49Enum> fields = null)
            => CoreHelper.RunTask(ViewSingleTokenRecordAsync(tokenId, expand, fields));

        /// <summary>
        /// View single token record EndPoint.
        /// </summary>
        /// <param name="tokenId">Required parameter: A unique, system-generated identifier for the Token..</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> ViewSingleTokenRecordAsync(
                string tokenId,
                List<Models.Expand44Enum> expand = null,
                List<Models.Field49Enum> fields = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseToken>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/tokens/{token_id}")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("token_id", tokenId))
                      .Query(_query => _query.Setup("expand", expand?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))
                      .Query(_query => _query.Setup("fields", fields?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// List all tokens related EndPoint.
        /// </summary>
        /// <param name="page"><![CDATA[Optional parameter: Use this field to specify paginate your results, by using page size and number. You can use one of the following methods: >/endpoint?page={ "number": 1, "size": 50 } > >/endpoint?page[number]=1&page[size]=50 >.]]></param>
        /// <param name="order">Optional parameter: Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json. >/endpoint?order=[{ "key": "created_ts", "operator": "asc"}] > >/endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] >.</param>
        /// <param name="filterBy"><![CDATA[Optional parameter: Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`. >/endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }] > >/endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }] > >/endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }] > >/endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] >.]]></param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="format">Optional parameter: Reporting format, valid values: csv, tsv.</param>
        /// <param name="typeahead">Optional parameter: You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <returns>Returns the Models.ResponseTokensCollection response from the API call.</returns>
        public Models.ResponseTokensCollection ListAllTokensRelated(
                Models.Page page = null,
                List<Models.Order19> order = null,
                List<Models.FilterBy> filterBy = null,
                List<Models.Expand44Enum> expand = null,
                Models.Format1Enum? format = null,
                string typeahead = null,
                List<Models.Field49Enum> fields = null)
            => CoreHelper.RunTask(ListAllTokensRelatedAsync(page, order, filterBy, expand, format, typeahead, fields));

        /// <summary>
        /// List all tokens related EndPoint.
        /// </summary>
        /// <param name="page"><![CDATA[Optional parameter: Use this field to specify paginate your results, by using page size and number. You can use one of the following methods: >/endpoint?page={ "number": 1, "size": 50 } > >/endpoint?page[number]=1&page[size]=50 >.]]></param>
        /// <param name="order">Optional parameter: Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json. >/endpoint?order=[{ "key": "created_ts", "operator": "asc"}] > >/endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] >.</param>
        /// <param name="filterBy"><![CDATA[Optional parameter: Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`. >/endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }] > >/endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }] > >/endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }] > >/endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] >.]]></param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="format">Optional parameter: Reporting format, valid values: csv, tsv.</param>
        /// <param name="typeahead">Optional parameter: You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseTokensCollection response from the API call.</returns>
        public async Task<Models.ResponseTokensCollection> ListAllTokensRelatedAsync(
                Models.Page page = null,
                List<Models.Order19> order = null,
                List<Models.FilterBy> filterBy = null,
                List<Models.Expand44Enum> expand = null,
                Models.Format1Enum? format = null,
                string typeahead = null,
                List<Models.Field49Enum> fields = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseTokensCollection>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/tokens")
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
        /// Update ACH Token EndPoint.
        /// </summary>
        /// <param name="tokenId">Required parameter: A unique, system-generated identifier for the Token..</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken UpdateACHToken(
                string tokenId,
                Models.V1TokensAchRequest1 body,
                List<Models.Expand44Enum> expand = null)
            => CoreHelper.RunTask(UpdateACHTokenAsync(tokenId, body, expand));

        /// <summary>
        /// Update ACH Token EndPoint.
        /// </summary>
        /// <param name="tokenId">Required parameter: A unique, system-generated identifier for the Token..</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> UpdateACHTokenAsync(
                string tokenId,
                Models.V1TokensAchRequest1 body,
                List<Models.Expand44Enum> expand = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseToken>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(new HttpMethod("PATCH"), "/v1/tokens/{token_id}/ach")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("token_id", tokenId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))
                      .Query(_query => _query.Setup("expand", expand?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context)))
                  .ErrorCase("412", CreateErrorCase("Precondition Failed", (_reason, _context) => new Response412Exception(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Update CC Token EndPoint.
        /// </summary>
        /// <param name="tokenId">Required parameter: A unique, system-generated identifier for the Token..</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken UpdateCCToken(
                string tokenId,
                Models.V1TokensCcRequest1 body,
                List<Models.Expand44Enum> expand = null)
            => CoreHelper.RunTask(UpdateCCTokenAsync(tokenId, body, expand));

        /// <summary>
        /// Update CC Token EndPoint.
        /// </summary>
        /// <param name="tokenId">Required parameter: A unique, system-generated identifier for the Token..</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> UpdateCCTokenAsync(
                string tokenId,
                Models.V1TokensCcRequest1 body,
                List<Models.Expand44Enum> expand = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseToken>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(new HttpMethod("PATCH"), "/v1/tokens/{token_id}/cc")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("token_id", tokenId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))
                      .Query(_query => _query.Setup("expand", expand?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context)))
                  .ErrorCase("412", CreateErrorCase("Precondition Failed", (_reason, _context) => new Response412Exception(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}