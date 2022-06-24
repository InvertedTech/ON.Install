// <copyright file="RecurringController.cs" company="APIMatic">
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
    /// RecurringController.
    /// </summary>
    public class RecurringController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecurringController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal RecurringController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Create a new recurring record.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseRecurring response from the API call.</returns>
        public Models.ResponseRecurring CreateANewRecurringRecord(
                Models.V1RecurringsRequest body)
        {
            Task<Models.ResponseRecurring> t = this.CreateANewRecurringRecordAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Create a new recurring record.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseRecurring response from the API call.</returns>
        public async Task<Models.ResponseRecurring> CreateANewRecurringRecordAsync(
                Models.V1RecurringsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/recurrings");

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

            return ApiHelper.JsonDeserialize<Models.ResponseRecurring>(response.Body);
        }

        /// <summary>
        /// List all recurring record.
        /// </summary>
        /// <param name="page">Optional parameter: Use this field to specify paginate your results, by using page size and number. You can use one of the following methods: >/endpoint?page={ "number": 1, "size": 50 } > >/endpoint?page[number]=1&page[size]=50.</param>
        /// <param name="sort">Optional parameter: You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods: >/endpoint?sort={ "field_name": "asc", "field_name2": "desc" } > >/endpoint?sort[field_name]=asc&sort[field_name2]=desc.</param>
        /// <param name="filter">Optional parameter: You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods: >/endpoint?filter={ "field_name": "Value" } > >/endpoint?filter[field_name]=Value.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <returns>Returns the Models.ResponseRecurringsCollection response from the API call.</returns>
        public Models.ResponseRecurringsCollection ListAllRecurringRecord(
                Models.Page page = null,
                Models.Sort6 sort = null,
                Models.Filter6 filter = null,
                List<string> expand = null)
        {
            Task<Models.ResponseRecurringsCollection> t = this.ListAllRecurringRecordAsync(page, sort, filter, expand);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// List all recurring record.
        /// </summary>
        /// <param name="page">Optional parameter: Use this field to specify paginate your results, by using page size and number. You can use one of the following methods: >/endpoint?page={ "number": 1, "size": 50 } > >/endpoint?page[number]=1&page[size]=50.</param>
        /// <param name="sort">Optional parameter: You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods: >/endpoint?sort={ "field_name": "asc", "field_name2": "desc" } > >/endpoint?sort[field_name]=asc&sort[field_name2]=desc.</param>
        /// <param name="filter">Optional parameter: You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods: >/endpoint?filter={ "field_name": "Value" } > >/endpoint?filter[field_name]=Value.</param>
        /// <param name="expand">Optional parameter: Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseRecurringsCollection response from the API call.</returns>
        public async Task<Models.ResponseRecurringsCollection> ListAllRecurringRecordAsync(
                Models.Page page = null,
                Models.Sort6 sort = null,
                Models.Filter6 filter = null,
                List<string> expand = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/recurrings");

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

            return ApiHelper.JsonDeserialize<Models.ResponseRecurringsCollection>(response.Body);
        }

        /// <summary>
        /// Delete recurring record.
        /// </summary>
        /// <param name="recurringId">Required parameter: Recurring ID.</param>
        /// <returns>Returns the Models.ResponseRecurring response from the API call.</returns>
        public Models.ResponseRecurring DeleteRecurringRecord(
                string recurringId)
        {
            Task<Models.ResponseRecurring> t = this.DeleteRecurringRecordAsync(recurringId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Delete recurring record.
        /// </summary>
        /// <param name="recurringId">Required parameter: Recurring ID.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseRecurring response from the API call.</returns>
        public async Task<Models.ResponseRecurring> DeleteRecurringRecordAsync(
                string recurringId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/recurrings/{recurring_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "recurring_id", recurringId },
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

            return ApiHelper.JsonDeserialize<Models.ResponseRecurring>(response.Body);
        }

        /// <summary>
        /// View single recurring record.
        /// </summary>
        /// <param name="recurringId">Required parameter: Recurring ID.</param>
        /// <returns>Returns the Models.ResponseRecurring response from the API call.</returns>
        public Models.ResponseRecurring ViewSingleRecurringRecord(
                string recurringId)
        {
            Task<Models.ResponseRecurring> t = this.ViewSingleRecurringRecordAsync(recurringId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// View single recurring record.
        /// </summary>
        /// <param name="recurringId">Required parameter: Recurring ID.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseRecurring response from the API call.</returns>
        public async Task<Models.ResponseRecurring> ViewSingleRecurringRecordAsync(
                string recurringId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/recurrings/{recurring_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "recurring_id", recurringId },
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

            return ApiHelper.JsonDeserialize<Models.ResponseRecurring>(response.Body);
        }

        /// <summary>
        /// Update recurring payment.
        /// </summary>
        /// <param name="recurringId">Required parameter: Recurring ID.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseRecurring response from the API call.</returns>
        public Models.ResponseRecurring UpdateRecurringPayment(
                string recurringId,
                Models.V1RecurringsRequest1 body)
        {
            Task<Models.ResponseRecurring> t = this.UpdateRecurringPaymentAsync(recurringId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Update recurring payment.
        /// </summary>
        /// <param name="recurringId">Required parameter: Recurring ID.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseRecurring response from the API call.</returns>
        public async Task<Models.ResponseRecurring> UpdateRecurringPaymentAsync(
                string recurringId,
                Models.V1RecurringsRequest1 body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/recurrings/{recurring_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "recurring_id", recurringId },
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

            return ApiHelper.JsonDeserialize<Models.ResponseRecurring>(response.Body);
        }

        /// <summary>
        /// Activate recurring payment.
        /// </summary>
        /// <param name="recurringId">Required parameter: Recurring ID.</param>
        /// <returns>Returns the Models.ResponseRecurring response from the API call.</returns>
        public Models.ResponseRecurring ActivateRecurringPayment(
                string recurringId)
        {
            Task<Models.ResponseRecurring> t = this.ActivateRecurringPaymentAsync(recurringId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Activate recurring payment.
        /// </summary>
        /// <param name="recurringId">Required parameter: Recurring ID.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseRecurring response from the API call.</returns>
        public async Task<Models.ResponseRecurring> ActivateRecurringPaymentAsync(
                string recurringId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/recurrings/{recurring_id}/activate");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "recurring_id", recurringId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Put(queryBuilder.ToString(), headers, null);

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

            return ApiHelper.JsonDeserialize<Models.ResponseRecurring>(response.Body);
        }

        /// <summary>
        /// Defer recurring payment.
        /// </summary>
        /// <param name="recurringId">Required parameter: Recurring ID.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseRecurring response from the API call.</returns>
        public Models.ResponseRecurring DeferRecurringPayment(
                string recurringId,
                Models.V1RecurringsDeferPaymentRequest body)
        {
            Task<Models.ResponseRecurring> t = this.DeferRecurringPaymentAsync(recurringId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Defer recurring payment.
        /// </summary>
        /// <param name="recurringId">Required parameter: Recurring ID.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseRecurring response from the API call.</returns>
        public async Task<Models.ResponseRecurring> DeferRecurringPaymentAsync(
                string recurringId,
                Models.V1RecurringsDeferPaymentRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/recurrings/{recurring_id}/defer-payment");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "recurring_id", recurringId },
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
            HttpRequest httpRequest = this.GetClientInstance().PutBody(queryBuilder.ToString(), headers, bodyText);

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

            return ApiHelper.JsonDeserialize<Models.ResponseRecurring>(response.Body);
        }

        /// <summary>
        /// Place on hold recurring payment.
        /// </summary>
        /// <param name="recurringId">Required parameter: Recurring ID.</param>
        /// <returns>Returns the Models.ResponseRecurring response from the API call.</returns>
        public Models.ResponseRecurring PlaceOnHoldRecurringPayment(
                string recurringId)
        {
            Task<Models.ResponseRecurring> t = this.PlaceOnHoldRecurringPaymentAsync(recurringId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Place on hold recurring payment.
        /// </summary>
        /// <param name="recurringId">Required parameter: Recurring ID.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseRecurring response from the API call.</returns>
        public async Task<Models.ResponseRecurring> PlaceOnHoldRecurringPaymentAsync(
                string recurringId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/recurrings/{recurring_id}/place-on-hold");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "recurring_id", recurringId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Put(queryBuilder.ToString(), headers, null);

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

            return ApiHelper.JsonDeserialize<Models.ResponseRecurring>(response.Body);
        }

        /// <summary>
        /// Skip recurring payment.
        /// </summary>
        /// <param name="recurringId">Required parameter: Recurring ID.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseRecurring response from the API call.</returns>
        public Models.ResponseRecurring SkipRecurringPayment(
                string recurringId,
                Models.V1RecurringsSkipPaymentRequest body)
        {
            Task<Models.ResponseRecurring> t = this.SkipRecurringPaymentAsync(recurringId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Skip recurring payment.
        /// </summary>
        /// <param name="recurringId">Required parameter: Recurring ID.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseRecurring response from the API call.</returns>
        public async Task<Models.ResponseRecurring> SkipRecurringPaymentAsync(
                string recurringId,
                Models.V1RecurringsSkipPaymentRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/recurrings/{recurring_id}/skip-payment");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "recurring_id", recurringId },
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
            HttpRequest httpRequest = this.GetClientInstance().PutBody(queryBuilder.ToString(), headers, bodyText);

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

            return ApiHelper.JsonDeserialize<Models.ResponseRecurring>(response.Body);
        }
    }
}