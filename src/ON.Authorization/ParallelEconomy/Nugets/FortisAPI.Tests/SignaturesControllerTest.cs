// <copyright file="SignaturesControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Controllers;
    using FortisAPI.Standard.Exceptions;
    using FortisAPI.Standard.Http.Client;
    using FortisAPI.Standard.Http.Response;
    using FortisAPI.Standard.Utilities;
    using FortisAPI.Tests.Helpers;
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;

    /// <summary>
    /// SignaturesControllerTest.
    /// </summary>
    [TestFixture]
    public class SignaturesControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private SignaturesController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.SignaturesController;
        }

        /// <summary>
        /// List all signatures record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListAllSignaturesRecord()
        {
            // Parameters for the API call
            Standard.Models.Page page = null;
            Standard.Models.Sort7 sort = null;
            Standard.Models.Filter7 filter = null;
            List<string> expand = null;

            // Perform API call
            Standard.Models.ResponseSignaturesCollection result = null;
            try
            {
                result = await this.controller.ListAllSignaturesRecordAsync(page, sort, filter, expand);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsJsonObjectProperSubsetOf(
                    "{\"type\":\"SignaturesCollection\",\"list\":[{\"signature\":\"iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC\",\"resource\":\"Transaction\",\"resource_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992}]}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// View single signature record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestViewSingleSignatureRecord()
        {
            // Parameters for the API call
            string signatureId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseSignature result = null;
            try
            {
                result = await this.controller.ViewSingleSignatureRecordAsync(signatureId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsJsonObjectProperSubsetOf(
                    "{\"type\":\"Signature\",\"data\":{\"signature\":\"iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC\",\"resource\":\"Transaction\",\"resource_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}