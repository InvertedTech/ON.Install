// <copyright file="WebhooksControllerTest.cs" company="APIMatic">
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
    /// WebhooksControllerTest.
    /// </summary>
    [TestFixture]
    public class WebhooksControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private WebhooksController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.WebhooksController;
        }

        /// <summary>
        /// Delete a postback config.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestDeleteAPostbackConfig()
        {
            // Parameters for the API call
            string webhookId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseWebhook result = null;
            try
            {
                result = await this.controller.DeleteAPostbackConfigAsync(webhookId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, this.HttpCallBackHandler.Response.StatusCode, "Status should be 204");

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
                    "{\"type\":\"Webhook\",\"data\":{\"attempt_interval\":300,\"basic_auth_username\":\"tester\",\"basic_auth_password\":\"Test@522\",\"expands\":\"changelogs,tags\",\"format\":\"api-default\",\"is_active\":true,\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"on_create\":1,\"on_update\":1,\"on_delete\":1,\"postback_config_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"resource\":\"contact\",\"number_of_attempts\":1,\"url\":\"https://127.0.0.1/receiver\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\"}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}