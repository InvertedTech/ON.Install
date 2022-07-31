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
    /// Level3DataController.
    /// </summary>
    public class Level3DataController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Level3DataController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal Level3DataController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Create a new Level3 entry for a MasterCard.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="transactionId">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseTransationLevel3Master response from the API call.</returns>
        public Models.ResponseTransationLevel3Master CreateANewLevel3EntryForAMasterCard(
                Models.V1TransactionsLevel3MasterCardRequest body,
                string transactionId)
        {
            Task<Models.ResponseTransationLevel3Master> t = this.CreateANewLevel3EntryForAMasterCardAsync(body, transactionId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Create a new Level3 entry for a MasterCard.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="transactionId">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseTransationLevel3Master response from the API call.</returns>
        public async Task<Models.ResponseTransationLevel3Master> CreateANewLevel3EntryForAMasterCardAsync(
                Models.V1TransactionsLevel3MasterCardRequest body,
                string transactionId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/transactions/{transaction_id}/level3/master-card");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "transaction_id", transactionId },
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

            return ApiHelper.JsonDeserialize<Models.ResponseTransationLevel3Master>(response.Body);
        }

        /// <summary>
        /// Create a new Level3 entry for a Visa.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="transactionId">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseTransationLevel3Visa response from the API call.</returns>
        public Models.ResponseTransationLevel3Visa CreateANewLevel3EntryForAVisa(
                Models.V1TransactionsLevel3VisaRequest body,
                string transactionId)
        {
            Task<Models.ResponseTransationLevel3Visa> t = this.CreateANewLevel3EntryForAVisaAsync(body, transactionId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Create a new Level3 entry for a Visa.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="transactionId">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseTransationLevel3Visa response from the API call.</returns>
        public async Task<Models.ResponseTransationLevel3Visa> CreateANewLevel3EntryForAVisaAsync(
                Models.V1TransactionsLevel3VisaRequest body,
                string transactionId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/transactions/{transaction_id}/level3/visa");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "transaction_id", transactionId },
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

            return ApiHelper.JsonDeserialize<Models.ResponseTransationLevel3Visa>(response.Body);
        }

        /// <summary>
        /// Delete a single level3 record.
        /// </summary>
        /// <param name="transactionId">Required parameter: Example: .</param>
        /// <param name="level3Id">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseTransationLevel3 response from the API call.</returns>
        public Models.ResponseTransationLevel3 DeleteASingleLevel3Record(
                string transactionId,
                string level3Id)
        {
            Task<Models.ResponseTransationLevel3> t = this.DeleteASingleLevel3RecordAsync(transactionId, level3Id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Delete a single level3 record.
        /// </summary>
        /// <param name="transactionId">Required parameter: Example: .</param>
        /// <param name="level3Id">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseTransationLevel3 response from the API call.</returns>
        public async Task<Models.ResponseTransationLevel3> DeleteASingleLevel3RecordAsync(
                string transactionId,
                string level3Id,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/transactions/{transaction_id}/level3/{level3_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "transaction_id", transactionId },
                { "level3_id", level3Id },
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

            return ApiHelper.JsonDeserialize<Models.ResponseTransationLevel3>(response.Body);
        }

        /// <summary>
        /// View single level3 record.
        /// </summary>
        /// <param name="transactionId">Required parameter: Example: .</param>
        /// <param name="level3Id">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseTransationLevel3 response from the API call.</returns>
        public Models.ResponseTransationLevel3 ViewSingleLevel3Record(
                string transactionId,
                string level3Id)
        {
            Task<Models.ResponseTransationLevel3> t = this.ViewSingleLevel3RecordAsync(transactionId, level3Id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// View single level3 record.
        /// </summary>
        /// <param name="transactionId">Required parameter: Example: .</param>
        /// <param name="level3Id">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseTransationLevel3 response from the API call.</returns>
        public async Task<Models.ResponseTransationLevel3> ViewSingleLevel3RecordAsync(
                string transactionId,
                string level3Id,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/transactions/{transaction_id}/level3/{level3_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "transaction_id", transactionId },
                { "level3_id", level3Id },
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

            return ApiHelper.JsonDeserialize<Models.ResponseTransationLevel3>(response.Body);
        }
    }
}