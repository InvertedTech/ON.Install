// <copyright file="OnBoardingController.cs" company="APIMatic">
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
    /// OnBoardingController.
    /// </summary>
    public class OnBoardingController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnBoardingController"/> class.
        /// </summary>
        internal OnBoardingController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// This method can be used to pre-populate data on the Merchant Processing Application (MPA), a form that prospective merchants must complete and sign prior to approval. Using this method will reduce the effort required by the merchant at boarding time, in scenarios where data about the prospective merchant has already been collected. This method will return an Application ID, which can be sent to a prospective merchant to obtain and complete the pre-filled application.
        /// Properties that are marked "Required" indicate the minimum required data for creating and saving an MPA. When using this method, you must provide data for each "Required" property, or you will not receive an Application ID. Properties that are marked "Required for completion" are those which need to be provided to Fortis before the Merchant Processing Application can be approved. These properties may be omitted or left blank when using this method, however, the merchant will be required to provide this data before the application can be submitted. Properties that are marked "Conditionally Required" may be required for completion of the Merchant Processing Application, depending on the values provided for other fields. See the description for each of these properties for more information about their requirement criteria.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ResponseOnboarding response from the API call.</returns>
        public Models.ResponseOnboarding MerchantBoarding(
                Models.V1OnboardingRequest body)
            => CoreHelper.RunTask(MerchantBoardingAsync(body));

        /// <summary>
        /// This method can be used to pre-populate data on the Merchant Processing Application (MPA), a form that prospective merchants must complete and sign prior to approval. Using this method will reduce the effort required by the merchant at boarding time, in scenarios where data about the prospective merchant has already been collected. This method will return an Application ID, which can be sent to a prospective merchant to obtain and complete the pre-filled application.
        /// Properties that are marked "Required" indicate the minimum required data for creating and saving an MPA. When using this method, you must provide data for each "Required" property, or you will not receive an Application ID. Properties that are marked "Required for completion" are those which need to be provided to Fortis before the Merchant Processing Application can be approved. These properties may be omitted or left blank when using this method, however, the merchant will be required to provide this data before the application can be submitted. Properties that are marked "Conditionally Required" may be required for completion of the Merchant Processing Application, depending on the values provided for other fields. See the description for each of these properties for more information about their requirement criteria.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResponseOnboarding response from the API call.</returns>
        public async Task<Models.ResponseOnboarding> MerchantBoardingAsync(
                Models.V1OnboardingRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResponseOnboarding>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v1/onboarding")
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