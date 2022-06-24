// <copyright file="BatchesControllerTest.cs" company="APIMatic">
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
    /// BatchesControllerTest.
    /// </summary>
    [TestFixture]
    public class BatchesControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private BatchesController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.BatchesController;
        }

        /// <summary>
        /// View Single Batch.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestViewSingleBatch()
        {
            // Parameters for the API call
            string batchId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseBatch result = null;
            try
            {
                result = await this.controller.ViewSingleBatchAsync(batchId);
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
                    "{\"type\":\"Batch\",\"data\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"processing_status_id\":2,\"batch_num\":4,\"is_open\":0,\"settlement_file_name\":\"settement_file.txt\",\"batch_close_ts\":1531423693,\"batch_close_detail\":\"BATCH_MISMATCH\",\"total_sale_amount\":2342.45,\"total_sale_count\":21,\"total_refund_amount\":2342.45,\"total_refund_count\":18,\"total_void_amount\":2342.45,\"total_void_count\":17}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// List All Batches.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListAllBatches()
        {
            // Parameters for the API call
            Standard.Models.Page page = null;
            Standard.Models.Sort sort = null;
            Standard.Models.Filter filter = null;
            List<string> expand = null;

            // Perform API call
            Standard.Models.ResponseBatchsCollection result = null;
            try
            {
                result = await this.controller.ListAllBatchesAsync(page, sort, filter, expand);
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
                    "{\"type\":\"BatchsCollection\",\"list\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"processing_status_id\":2,\"batch_num\":4,\"is_open\":0,\"settlement_file_name\":\"settement_file.txt\",\"batch_close_ts\":1531423693,\"batch_close_detail\":\"BATCH_MISMATCH\",\"total_sale_amount\":2342.45,\"total_sale_count\":21,\"total_refund_amount\":2342.45,\"total_refund_count\":18,\"total_void_amount\":2342.45,\"total_void_count\":17}]}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Settle a Batch.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestSettleABatch()
        {
            // Parameters for the API call
            string batchId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseAsyncProcessing result = null;
            try
            {
                result = await this.controller.SettleABatchAsync(batchId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(202, this.HttpCallBackHandler.Response.StatusCode, "Status should be 202");

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
                    "{\"type\":\"AsyncProcessing\",\"data\":{\"async\":{\"code\":\"406c66c3-21cb-47fb-80fc-843bc42507fb\",\"link\":\"/v1/async/status/406c66c3-21cb-47fb-80fc-843bc42507fb\"}}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}