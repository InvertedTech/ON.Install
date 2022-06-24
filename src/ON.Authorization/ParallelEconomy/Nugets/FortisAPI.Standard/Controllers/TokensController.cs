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
    /// TokensController.
    /// </summary>
    public class TokensController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokensController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal TokensController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Create a new ACH Token.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken CreateANewACHToken(
                Models.V1TokensAchRequest body)
        {
            Task<Models.ResponseToken> t = this.CreateANewACHTokenAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Create a new ACH Token.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> CreateANewACHTokenAsync(
                Models.V1TokensAchRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/tokens/ach");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

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

            if (response.StatusCode == 412)
            {
                throw new Response412Exception("Precondition Failed", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.ResponseToken>(response.Body);
        }

        /// <summary>
        /// Create a new Credit Card Token.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken CreateANewCreditCardToken(
                Models.V1TokensCcRequest body)
        {
            Task<Models.ResponseToken> t = this.CreateANewCreditCardTokenAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Create a new Credit Card Token.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> CreateANewCreditCardTokenAsync(
                Models.V1TokensCcRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/tokens/cc");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

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

            if (response.StatusCode == 412)
            {
                throw new Response412Exception("Precondition Failed", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.ResponseToken>(response.Body);
        }

        /// <summary>
        /// Create a new Previous Transaction Token.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken CreateANewPreviousTransactionToken(
                Models.V1TokensPreviousTransactionRequest body)
        {
            Task<Models.ResponseToken> t = this.CreateANewPreviousTransactionTokenAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Create a new Previous Transaction Token.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> CreateANewPreviousTransactionTokenAsync(
                Models.V1TokensPreviousTransactionRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/tokens/previous-transaction");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

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

            if (response.StatusCode == 412)
            {
                throw new Response412Exception("Precondition Failed", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.ResponseToken>(response.Body);
        }

        /// <summary>
        /// Create a new Terminal Token.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken CreateANewTerminalToken(
                Models.V1TokensTerminalRequest body)
        {
            Task<Models.ResponseToken> t = this.CreateANewTerminalTokenAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Create a new Terminal Token.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> CreateANewTerminalTokenAsync(
                Models.V1TokensTerminalRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/tokens/terminal");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

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

            if (response.StatusCode == 412)
            {
                throw new Response412Exception("Precondition Failed", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.ResponseToken>(response.Body);
        }

        /// <summary>
        /// Create a new Ticket Token.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken CreateANewTicketToken(
                Models.V1TokensTicketRequest body)
        {
            Task<Models.ResponseToken> t = this.CreateANewTicketTokenAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Create a new Ticket Token.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> CreateANewTicketTokenAsync(
                Models.V1TokensTicketRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/tokens/ticket");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

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

            if (response.StatusCode == 412)
            {
                throw new Response412Exception("Precondition Failed", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.ResponseToken>(response.Body);
        }

        /// <summary>
        /// Delete a single token record.
        /// </summary>
        /// <param name="tokenId">Required parameter: A unique, system-generated identifier for the Token..</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken DeleteASingleTokenRecord(
                string tokenId)
        {
            Task<Models.ResponseToken> t = this.DeleteASingleTokenRecordAsync(tokenId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Delete a single token record.
        /// </summary>
        /// <param name="tokenId">Required parameter: A unique, system-generated identifier for the Token..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> DeleteASingleTokenRecordAsync(
                string tokenId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/tokens/{token_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "token_id", tokenId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null);

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

            return ApiHelper.JsonDeserialize<Models.ResponseToken>(response.Body);
        }

        /// <summary>
        /// View single token record.
        /// </summary>
        /// <param name="tokenId">Required parameter: A unique, system-generated identifier for the Token..</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken ViewSingleTokenRecord(
                string tokenId)
        {
            Task<Models.ResponseToken> t = this.ViewSingleTokenRecordAsync(tokenId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// View single token record.
        /// </summary>
        /// <param name="tokenId">Required parameter: A unique, system-generated identifier for the Token..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> ViewSingleTokenRecordAsync(
                string tokenId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/tokens/{token_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "token_id", tokenId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

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

            return ApiHelper.JsonDeserialize<Models.ResponseToken>(response.Body);
        }

        /// <summary>
        /// List all tokens related.
        /// </summary>
        /// <param name="page">Optional parameter: Use this field to specify paginate your results, by using page size and number. You can use one of the following methods: >/endpoint?page={ "number": 1, "size": 50 } > >/endpoint?page[number]=1&page[size]=50.</param>
        /// <param name="sort">Optional parameter: You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods: >/endpoint?sort={ "field_name": "asc", "field_name2": "desc" } > >/endpoint?sort[field_name]=asc&sort[field_name2]=desc.</param>
        /// <param name="filter">Optional parameter: You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods: >/endpoint?filter={ "field_name": "Value" } > >/endpoint?filter[field_name]=Value.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseTokensCollection response from the API call.</returns>
        public Models.ResponseTokensCollection ListAllTokensRelated(
                Models.Page page = null,
                Models.Sort10 sort = null,
                Models.Filter10 filter = null,
                List<string> expand = null)
        {
            Task<Models.ResponseTokensCollection> t = this.ListAllTokensRelatedAsync(page, sort, filter, expand);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// List all tokens related.
        /// </summary>
        /// <param name="page">Optional parameter: Use this field to specify paginate your results, by using page size and number. You can use one of the following methods: >/endpoint?page={ "number": 1, "size": 50 } > >/endpoint?page[number]=1&page[size]=50.</param>
        /// <param name="sort">Optional parameter: You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods: >/endpoint?sort={ "field_name": "asc", "field_name2": "desc" } > >/endpoint?sort[field_name]=asc&sort[field_name2]=desc.</param>
        /// <param name="filter">Optional parameter: You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods: >/endpoint?filter={ "field_name": "Value" } > >/endpoint?filter[field_name]=Value.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseTokensCollection response from the API call.</returns>
        public async Task<Models.ResponseTokensCollection> ListAllTokensRelatedAsync(
                Models.Page page = null,
                Models.Sort10 sort = null,
                Models.Filter10 filter = null,
                List<string> expand = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/tokens");

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

            return ApiHelper.JsonDeserialize<Models.ResponseTokensCollection>(response.Body);
        }

        /// <summary>
        /// Update ACH Token.
        /// </summary>
        /// <param name="tokenId">Required parameter: A unique, system-generated identifier for the Token..</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken UpdateACHToken(
                string tokenId,
                Models.V1TokensAchRequest1 body)
        {
            Task<Models.ResponseToken> t = this.UpdateACHTokenAsync(tokenId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Update ACH Token.
        /// </summary>
        /// <param name="tokenId">Required parameter: A unique, system-generated identifier for the Token..</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> UpdateACHTokenAsync(
                string tokenId,
                Models.V1TokensAchRequest1 body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/tokens/{token_id}/ach");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "token_id", tokenId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PatchBody(queryBuilder.ToString(), headers, bodyText);

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

            if (response.StatusCode == 412)
            {
                throw new Response412Exception("Precondition Failed", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.ResponseToken>(response.Body);
        }

        /// <summary>
        /// Update CC Token.
        /// </summary>
        /// <param name="tokenId">Required parameter: A unique, system-generated identifier for the Token..</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public Models.ResponseToken UpdateCCToken(
                string tokenId,
                Models.V1TokensCcRequest1 body)
        {
            Task<Models.ResponseToken> t = this.UpdateCCTokenAsync(tokenId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Update CC Token.
        /// </summary>
        /// <param name="tokenId">Required parameter: A unique, system-generated identifier for the Token..</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseToken response from the API call.</returns>
        public async Task<Models.ResponseToken> UpdateCCTokenAsync(
                string tokenId,
                Models.V1TokensCcRequest1 body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/tokens/{token_id}/cc");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "token_id", tokenId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PatchBody(queryBuilder.ToString(), headers, bodyText);

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

            if (response.StatusCode == 412)
            {
                throw new Response412Exception("Precondition Failed", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.ResponseToken>(response.Body);
        }
    }
}