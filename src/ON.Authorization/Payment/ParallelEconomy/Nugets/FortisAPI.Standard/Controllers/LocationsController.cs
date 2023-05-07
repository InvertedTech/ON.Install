// <copyright file="LocationsController.cs" company="APIMatic">
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
    using FortisAPI.Standard;
    using FortisAPI.Standard.Authentication;
    using FortisAPI.Standard.Exceptions;
    using FortisAPI.Standard.Http.Client;
    using FortisAPI.Standard.Http.Request;
    using FortisAPI.Standard.Http.Request.Configuration;
    using FortisAPI.Standard.Http.Response;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// LocationsController.
    /// </summary>
    public class LocationsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal LocationsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Locations Detail.
        /// </summary>
        /// <param name="page">Optional parameter: Use this field to specify paginate your results, by using page size and number. You can use one of the following methods: >/endpoint?page={ "number": 1, "size": 50 } > >/endpoint?page[number]=1&page[size]=50.</param>
        /// <param name="sort">Optional parameter: You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods: >/endpoint?sort={ "field_name": "asc", "field_name2": "desc" } > >/endpoint?sort[field_name]=asc&sort[field_name2]=desc.</param>
        /// <param name="filter">Optional parameter: You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods: >/endpoint?filter={ "field_name": "Value" } > >/endpoint?filter[field_name]=Value.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseLocationInfosCollection response from the API call.</returns>
        public Models.ResponseLocationInfosCollection LocationsDetail(
                Models.Page page = null,
                Models.Sort3 sort = null,
                Models.Filter3 filter = null,
                List<string> expand = null)
        {
            Task<Models.ResponseLocationInfosCollection> t = this.LocationsDetailAsync(page, sort, filter, expand);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Locations Detail.
        /// </summary>
        /// <param name="page">Optional parameter: Use this field to specify paginate your results, by using page size and number. You can use one of the following methods: >/endpoint?page={ "number": 1, "size": 50 } > >/endpoint?page[number]=1&page[size]=50.</param>
        /// <param name="sort">Optional parameter: You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods: >/endpoint?sort={ "field_name": "asc", "field_name2": "desc" } > >/endpoint?sort[field_name]=asc&sort[field_name2]=desc.</param>
        /// <param name="filter">Optional parameter: You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods: >/endpoint?filter={ "field_name": "Value" } > >/endpoint?filter[field_name]=Value.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseLocationInfosCollection response from the API call.</returns>
        public async Task<Models.ResponseLocationInfosCollection> LocationsDetailAsync(
                Models.Page page = null,
                Models.Sort3 sort = null,
                Models.Filter3 filter = null,
                List<string> expand = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/locations/info");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "page", page },
                { "sort", sort },
                { "filter", filter },
                { "expand", expand },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 401)
            {
                throw new Response401tokenException("Unauthorized", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.ResponseLocationInfosCollection>(response.Body);
        }

        /// <summary>
        /// View single location record.
        /// </summary>
        /// <param name="locationId">Required parameter: Location ID.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseLocation response from the API call.</returns>
        public Models.ResponseLocation ViewSingleLocationRecord(
                string locationId,
                List<string> expand = null)
        {
            Task<Models.ResponseLocation> t = this.ViewSingleLocationRecordAsync(locationId, expand);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// View single location record.
        /// </summary>
        /// <param name="locationId">Required parameter: Location ID.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseLocation response from the API call.</returns>
        public async Task<Models.ResponseLocation> ViewSingleLocationRecordAsync(
                string locationId,
                List<string> expand = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/locations/{location_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "expand", expand },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 401)
            {
                throw new Response401tokenException("Unauthorized", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.ResponseLocation>(response.Body);
        }

        /// <summary>
        /// List all locations.
        /// </summary>
        /// <param name="page">Optional parameter: Use this field to specify paginate your results, by using page size and number. You can use one of the following methods: >/endpoint?page={ "number": 1, "size": 50 } > >/endpoint?page[number]=1&page[size]=50.</param>
        /// <param name="sort">Optional parameter: You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods: >/endpoint?sort={ "field_name": "asc", "field_name2": "desc" } > >/endpoint?sort[field_name]=asc&sort[field_name2]=desc.</param>
        /// <param name="filter">Optional parameter: You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods: >/endpoint?filter={ "field_name": "Value" } > >/endpoint?filter[field_name]=Value.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseLocationsCollection response from the API call.</returns>
        public Models.ResponseLocationsCollection ListAllLocations(
                Models.Page page = null,
                Models.Sort4 sort = null,
                Models.Filter4 filter = null,
                List<string> expand = null)
        {
            Task<Models.ResponseLocationsCollection> t = this.ListAllLocationsAsync(page, sort, filter, expand);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// List all locations.
        /// </summary>
        /// <param name="page">Optional parameter: Use this field to specify paginate your results, by using page size and number. You can use one of the following methods: >/endpoint?page={ "number": 1, "size": 50 } > >/endpoint?page[number]=1&page[size]=50.</param>
        /// <param name="sort">Optional parameter: You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods: >/endpoint?sort={ "field_name": "asc", "field_name2": "desc" } > >/endpoint?sort[field_name]=asc&sort[field_name2]=desc.</param>
        /// <param name="filter">Optional parameter: You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods: >/endpoint?filter={ "field_name": "Value" } > >/endpoint?filter[field_name]=Value.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseLocationsCollection response from the API call.</returns>
        public async Task<Models.ResponseLocationsCollection> ListAllLocationsAsync(
                Models.Page page = null,
                Models.Sort4 sort = null,
                Models.Filter4 filter = null,
                List<string> expand = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/locations");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "page", page },
                { "sort", sort },
                { "filter", filter },
                { "expand", expand },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 401)
            {
                throw new Response401tokenException("Unauthorized", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.ResponseLocationsCollection>(response.Body);
        }
    }
}