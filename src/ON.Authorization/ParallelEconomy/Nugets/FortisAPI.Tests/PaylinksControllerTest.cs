// <copyright file="PaylinksControllerTest.cs" company="APIMatic">
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
    /// PaylinksControllerTest.
    /// </summary>
    [TestFixture]
    public class PaylinksControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private PaylinksController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.PaylinksController;
        }

        /// <summary>
        /// List all Paylinks.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListAllPaylinks()
        {
            // Parameters for the API call
            Standard.Models.Page page = null;
            List<Standard.Models.Order19> order = null;
            List<Standard.Models.FilterBy> filterBy = null;
            List<Standard.Models.Expand15Enum> expand = null;
            Standard.Models.Format1Enum? format = null;
            string typeahead = null;
            List<Standard.Models.Field35Enum> fields = null;

            // Perform API call
            Standard.Models.ResponsePaylinksCollection result = null;
            try
            {
                result = await this.controller.ListAllPaylinksAsync(page, order, filterBy, expand, format, typeahead, fields);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

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
                    "{\"type\":\"PaylinksCollection\",\"list\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"cc_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"amount_due\":1,\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"ach_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"expire_date\":\"2021-12-01\",\"display_product_transaction_receipt_details\":true,\"display_billing_fields\":true,\"delivery_method\":0,\"cell_phone\":\"3339998822\",\"description\":\"Description\",\"store_token\":false,\"store_token_title\":\"John Account\",\"bank_funded_only_override\":false,\"tags\":[\"Tag 1\"],\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_id\":true,\"status_code\":1,\"active\":true,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"links\":{\"type\":\"Links\",\"first\":\"/v1/endpoint?page[size]=10&page[number]=1\",\"previous\":\"/v1/endpoint?page[size]=10&page[number]=5\",\"last\":\"/v1/endpoint?page[size]=10&page[number]=42\"},\"pagination\":{\"type\":\"Pagination\",\"total_count\":423,\"page_count\":42,\"page_number\":6,\"page_size\":10},\"sort\":{\"type\":\"Sorting\",\"fields\":[{\"field\":\"last_name\",\"order\":\"asc\"}]}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Delete Paylink.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestDeletePaylink()
        {
            // Parameters for the API call
            string paylinkId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponsePaylink result = null;
            try
            {
                result = await this.controller.DeletePaylinkAsync(paylinkId);
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
                    "{\"type\":\"Paylink\",\"data\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"cc_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"amount_due\":1,\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"ach_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"expire_date\":\"2021-12-01\",\"display_product_transaction_receipt_details\":true,\"display_billing_fields\":true,\"delivery_method\":0,\"cell_phone\":\"3339998822\",\"description\":\"Description\",\"store_token\":false,\"store_token_title\":\"John Account\",\"bank_funded_only_override\":false,\"tags\":[\"Tag 1\"],\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_id\":true,\"status_code\":1,\"active\":true,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// View Single Paylink.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestViewSinglePaylink()
        {
            // Parameters for the API call
            string paylinkId = "11e95f8ec39de8fbdb0a4f1a";
            List<Standard.Models.Expand15Enum> expand = null;
            List<Standard.Models.Field35Enum> fields = null;

            // Perform API call
            Standard.Models.ResponsePaylink result = null;
            try
            {
                result = await this.controller.ViewSinglePaylinkAsync(paylinkId, expand, fields);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

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
                    "{\"type\":\"Paylink\",\"data\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"cc_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"amount_due\":1,\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"ach_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"expire_date\":\"2021-12-01\",\"display_product_transaction_receipt_details\":true,\"display_billing_fields\":true,\"delivery_method\":0,\"cell_phone\":\"3339998822\",\"description\":\"Description\",\"store_token\":false,\"store_token_title\":\"John Account\",\"bank_funded_only_override\":false,\"tags\":[\"Tag 1\"],\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_id\":true,\"status_code\":1,\"active\":true,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Resend Paylink.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestResendPaylink()
        {
            // Parameters for the API call
            string paylinkId = "11e95f8ec39de8fbdb0a4f1a";
            List<Standard.Models.Expand14Enum> expand = null;
            Standard.Models.EmailEnum? email = null;
            Standard.Models.SmsEnum? sms = null;

            // Perform API call
            Standard.Models.ResponsePaylink result = null;
            try
            {
                result = await this.controller.ResendPaylinkAsync(paylinkId, expand, email, sms);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

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
                    "{\"type\":\"Paylink\",\"data\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"cc_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"amount_due\":1,\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"ach_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"expire_date\":\"2021-12-01\",\"display_product_transaction_receipt_details\":true,\"display_billing_fields\":true,\"delivery_method\":0,\"cell_phone\":\"3339998822\",\"description\":\"Description\",\"store_token\":false,\"store_token_title\":\"John Account\",\"bank_funded_only_override\":false,\"tags\":[\"Tag 1\"],\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_id\":true,\"status_code\":1,\"active\":true,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}