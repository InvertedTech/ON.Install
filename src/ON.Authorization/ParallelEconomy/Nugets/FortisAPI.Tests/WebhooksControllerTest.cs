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
    using APIMatic.Core.Utilities;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Controllers;
    using FortisAPI.Standard.Exceptions;
    using FortisAPI.Standard.Http.Client;
    using FortisAPI.Standard.Http.Response;
    using FortisAPI.Standard.Models.Containers;
    using FortisAPI.Standard.Utilities;
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
            Assert.AreEqual(204, HttpCallBack.Response.StatusCode, "Status should be 204");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    HttpCallBack.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsProperSubsetOf(
                    "{\"type\":\"Webhook\",\"data\":{\"attempt_interval\":300,\"basic_auth_username\":\"username\",\"basic_auth_password\":\"password\",\"expands\":\"changelogs,tags\",\"format\":\"api-default\",\"is_active\":true,\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"on_create\":true,\"on_update\":true,\"on_delete\":true,\"postback_config_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"resource\":\"contact\",\"number_of_attempts\":1,\"url\":\"https://127.0.0.1/receiver\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"postback_logs\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"postback_config_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"next_run_ts\":1422040992,\"created_ts\":1422040992,\"model_id\":\"11e95f8ec39de8fbdb0a4f1a\"}]}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}