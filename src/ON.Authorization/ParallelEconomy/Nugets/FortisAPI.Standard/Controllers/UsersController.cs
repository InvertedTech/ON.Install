// <copyright file="UsersController.cs" company="APIMatic">
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
    /// UsersController.
    /// </summary>
    public class UsersController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        internal UsersController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Create a new API key EndPoint.
        /// </summary>
        /// <param name="userId">Required parameter: User ID.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseUserApiKey response from the API call.</returns>
        public Models.ResponseUserApiKey CreateANewAPIKey(
                string userId,
                List<Models.Expand95Enum> expand = null)
            => CoreHelper.RunTask(CreateANewAPIKeyAsync(userId, expand));

        /// <summary>
        /// Create a new API key EndPoint.
        /// </summary>
        /// <param name="userId">Required parameter: User ID.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseUserApiKey response from the API call.</returns>
        public async Task<Models.ResponseUserApiKey> CreateANewAPIKeyAsync(
                string userId,
                List<Models.Expand95Enum> expand = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseUserApiKey>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v1/users/{user_id}/api-key")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("user_id", userId))
                      .Query(_query => _query.Setup("expand", expand?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Create a new user EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseUser response from the API call.</returns>
        public Models.ResponseUser CreateANewUser(
                Models.V1UsersRequest body,
                List<Models.Expand95Enum> expand = null)
            => CoreHelper.RunTask(CreateANewUserAsync(body, expand));

        /// <summary>
        /// Create a new user EndPoint.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseUser response from the API call.</returns>
        public async Task<Models.ResponseUser> CreateANewUserAsync(
                Models.V1UsersRequest body,
                List<Models.Expand95Enum> expand = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseUser>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v1/users")
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
        /// List all User EndPoint.
        /// </summary>
        /// <param name="page"><![CDATA[Optional parameter: Use this field to specify paginate your results, by using page size and number. You can use one of the following methods: >/endpoint?page={ "number": 1, "size": 50 } > >/endpoint?page[number]=1&page[size]=50 >.]]></param>
        /// <param name="order">Optional parameter: Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json. >/endpoint?order=[{ "key": "created_ts", "operator": "asc"}] > >/endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] >.</param>
        /// <param name="filterBy"><![CDATA[Optional parameter: Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`. >/endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }] > >/endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }] > >/endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }] > >/endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] >.]]></param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="format">Optional parameter: Reporting format, valid values: csv, tsv.</param>
        /// <param name="typeahead">Optional parameter: You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <returns>Returns the Models.ResponseUsersCollection response from the API call.</returns>
        public Models.ResponseUsersCollection ListAllUser(
                Models.Page page = null,
                List<Models.Order19> order = null,
                List<Models.FilterBy> filterBy = null,
                List<Models.Expand95Enum> expand = null,
                Models.Format1Enum? format = null,
                string typeahead = null,
                List<Models.Field54Enum> fields = null)
            => CoreHelper.RunTask(ListAllUserAsync(page, order, filterBy, expand, format, typeahead, fields));

        /// <summary>
        /// List all User EndPoint.
        /// </summary>
        /// <param name="page"><![CDATA[Optional parameter: Use this field to specify paginate your results, by using page size and number. You can use one of the following methods: >/endpoint?page={ "number": 1, "size": 50 } > >/endpoint?page[number]=1&page[size]=50 >.]]></param>
        /// <param name="order">Optional parameter: Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json. >/endpoint?order=[{ "key": "created_ts", "operator": "asc"}] > >/endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] >.</param>
        /// <param name="filterBy"><![CDATA[Optional parameter: Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`. >/endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }] > >/endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }] > >/endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }] > >/endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] >.]]></param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="format">Optional parameter: Reporting format, valid values: csv, tsv.</param>
        /// <param name="typeahead">Optional parameter: You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseUsersCollection response from the API call.</returns>
        public async Task<Models.ResponseUsersCollection> ListAllUserAsync(
                Models.Page page = null,
                List<Models.Order19> order = null,
                List<Models.FilterBy> filterBy = null,
                List<Models.Expand95Enum> expand = null,
                Models.Format1Enum? format = null,
                string typeahead = null,
                List<Models.Field54Enum> fields = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseUsersCollection>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/users")
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
        /// Delete a user record EndPoint.
        /// </summary>
        /// <param name="userId">Required parameter: User ID.</param>
        /// <returns>Returns the Models.ResponseUser response from the API call.</returns>
        public Models.ResponseUser DeleteAUserRecord(
                string userId)
            => CoreHelper.RunTask(DeleteAUserRecordAsync(userId));

        /// <summary>
        /// Delete a user record EndPoint.
        /// </summary>
        /// <param name="userId">Required parameter: User ID.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseUser response from the API call.</returns>
        public async Task<Models.ResponseUser> DeleteAUserRecordAsync(
                string userId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseUser>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v1/users/{user_id}")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("user_id", userId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// View single user record EndPoint.
        /// </summary>
        /// <param name="userId">Required parameter: User ID.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <returns>Returns the Models.ResponseUser response from the API call.</returns>
        public Models.ResponseUser ViewSingleUserRecord(
                string userId,
                List<Models.Expand95Enum> expand = null,
                List<Models.Field54Enum> fields = null)
            => CoreHelper.RunTask(ViewSingleUserRecordAsync(userId, expand, fields));

        /// <summary>
        /// View single user record EndPoint.
        /// </summary>
        /// <param name="userId">Required parameter: User ID.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseUser response from the API call.</returns>
        public async Task<Models.ResponseUser> ViewSingleUserRecordAsync(
                string userId,
                List<Models.Expand95Enum> expand = null,
                List<Models.Field54Enum> fields = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseUser>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/users/{user_id}")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("user_id", userId))
                      .Query(_query => _query.Setup("expand", expand?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))
                      .Query(_query => _query.Setup("fields", fields?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Update a user record EndPoint.
        /// </summary>
        /// <param name="userId">Required parameter: User ID.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseUser response from the API call.</returns>
        public Models.ResponseUser UpdateAUserRecord(
                string userId,
                Models.V1UsersRequest1 body,
                List<Models.Expand95Enum> expand = null)
            => CoreHelper.RunTask(UpdateAUserRecordAsync(userId, body, expand));

        /// <summary>
        /// Update a user record EndPoint.
        /// </summary>
        /// <param name="userId">Required parameter: User ID.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseUser response from the API call.</returns>
        public async Task<Models.ResponseUser> UpdateAUserRecordAsync(
                string userId,
                Models.V1UsersRequest1 body,
                List<Models.Expand95Enum> expand = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseUser>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(new HttpMethod("PATCH"), "/v1/users/{user_id}")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("user_id", userId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))
                      .Query(_query => _query.Setup("expand", expand?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context)))
                  .ErrorCase("412", CreateErrorCase("Precondition Failed", (_reason, _context) => new Response412Exception(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// View self record EndPoint.
        /// </summary>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <returns>Returns the Models.ResponseUser response from the API call.</returns>
        public Models.ResponseUser ViewSelfRecord(
                List<Models.Expand95Enum> expand = null,
                List<Models.Field54Enum> fields = null)
            => CoreHelper.RunTask(ViewSelfRecordAsync(expand, fields));

        /// <summary>
        /// View self record EndPoint.
        /// </summary>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="fields">Optional parameter: You can use any `field_name` from this endpoint results to filter the list of fields returned on the response..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseUser response from the API call.</returns>
        public async Task<Models.ResponseUser> ViewSelfRecordAsync(
                List<Models.Expand95Enum> expand = null,
                List<Models.Field54Enum> fields = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseUser>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/users/me")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("expand", expand?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))
                      .Query(_query => _query.Setup("fields", fields?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Remove the pending user.
        /// </summary>
        /// <param name="userId">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseRemoveVerification response from the API call.</returns>
        public Models.ResponseRemoveVerification RemoveVerification(
                string userId)
            => CoreHelper.RunTask(RemoveVerificationAsync(userId));

        /// <summary>
        /// Remove the pending user.
        /// </summary>
        /// <param name="userId">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseRemoveVerification response from the API call.</returns>
        public async Task<Models.ResponseRemoveVerification> RemoveVerificationAsync(
                string userId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseRemoveVerification>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v1/users/{user_id}/remove-verification")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("user_id", userId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Send an verification email to the pending user.
        /// </summary>
        /// <param name="userId">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseSendVerification response from the API call.</returns>
        public Models.ResponseSendVerification SendVerification(
                string userId)
            => CoreHelper.RunTask(SendVerificationAsync(userId));

        /// <summary>
        /// Send an verification email to the pending user.
        /// </summary>
        /// <param name="userId">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseSendVerification response from the API call.</returns>
        public async Task<Models.ResponseSendVerification> SendVerificationAsync(
                string userId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseSendVerification>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v1/users/{user_id}/send-verification")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("user-id")
                      .Add("user-api-key")
                      .Add("developer-id")
                  )
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("user_id", userId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new Response401tokenException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}