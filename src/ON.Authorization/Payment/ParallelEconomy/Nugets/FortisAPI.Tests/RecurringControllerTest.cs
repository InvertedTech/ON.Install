// <copyright file="RecurringControllerTest.cs" company="APIMatic">
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
    /// RecurringControllerTest.
    /// </summary>
    [TestFixture]
    public class RecurringControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private RecurringController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.RecurringController;
        }

        /// <summary>
        /// List all recurring record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListAllRecurringRecord()
        {
            // Parameters for the API call
            Standard.Models.Page page = null;
            Standard.Models.Sort6 sort = null;
            Standard.Models.Filter6 filter = null;
            List<string> expand = null;

            // Perform API call
            Standard.Models.ResponseRecurringsCollection result = null;
            try
            {
                result = await this.controller.ListAllRecurringRecordAsync(page, sort, filter, expand);
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
                    "{\"type\":\"RecurringsCollection\",\"list\":[{\"account_vault_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"active\":1,\"description\":\"Description\",\"end_date\":\"2021-12-01\",\"installment_total_count\":20,\"interval\":1,\"interval_type\":\"d\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"notification_days\":2,\"payment_method\":\"cc\",\"product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"recurring_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"recurring_api_id\":\"recurring1234abcd\",\"start_date\":\"2021-12-01\",\"status\":\"active\",\"transaction_amount\":3,\"terms_agree\":true,\"terms_agree_ip\":\"192.168.0.10\",\"recurring_c1\":\"recurring custom data 1\",\"recurring_c2\":\"recurring custom data 2\",\"recurring_c3\":\"recurring custom data 3\",\"send_to_proc_as_recur\":true,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"next_run_date\":\"2021-12-01\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"recurring_type_id\":\"i\"}]}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Delete recurring record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestDeleteRecurringRecord()
        {
            // Parameters for the API call
            string recurringId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseRecurring result = null;
            try
            {
                result = await this.controller.DeleteRecurringRecordAsync(recurringId);
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
                    "{\"type\":\"Recurring\",\"data\":{\"account_vault_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"active\":1,\"description\":\"Description\",\"end_date\":\"2021-12-01\",\"installment_total_count\":20,\"interval\":1,\"interval_type\":\"d\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"notification_days\":2,\"payment_method\":\"cc\",\"product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"recurring_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"recurring_api_id\":\"recurring1234abcd\",\"start_date\":\"2021-12-01\",\"status\":\"active\",\"transaction_amount\":3,\"terms_agree\":true,\"terms_agree_ip\":\"192.168.0.10\",\"recurring_c1\":\"recurring custom data 1\",\"recurring_c2\":\"recurring custom data 2\",\"recurring_c3\":\"recurring custom data 3\",\"send_to_proc_as_recur\":true,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"next_run_date\":\"2021-12-01\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"recurring_type_id\":\"i\"}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// View single recurring record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestViewSingleRecurringRecord()
        {
            // Parameters for the API call
            string recurringId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseRecurring result = null;
            try
            {
                result = await this.controller.ViewSingleRecurringRecordAsync(recurringId);
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
                    "{\"type\":\"Recurring\",\"data\":{\"account_vault_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"active\":1,\"description\":\"Description\",\"end_date\":\"2021-12-01\",\"installment_total_count\":20,\"interval\":1,\"interval_type\":\"d\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"notification_days\":2,\"payment_method\":\"cc\",\"product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"recurring_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"recurring_api_id\":\"recurring1234abcd\",\"start_date\":\"2021-12-01\",\"status\":\"active\",\"transaction_amount\":3,\"terms_agree\":true,\"terms_agree_ip\":\"192.168.0.10\",\"recurring_c1\":\"recurring custom data 1\",\"recurring_c2\":\"recurring custom data 2\",\"recurring_c3\":\"recurring custom data 3\",\"send_to_proc_as_recur\":true,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"next_run_date\":\"2021-12-01\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"recurring_type_id\":\"i\"}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Activate recurring payment.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestActivateRecurringPayment()
        {
            // Parameters for the API call
            string recurringId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseRecurring result = null;
            try
            {
                result = await this.controller.ActivateRecurringPaymentAsync(recurringId);
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
                    "{\"type\":\"Recurring\",\"data\":{\"account_vault_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"active\":1,\"description\":\"Description\",\"end_date\":\"2021-12-01\",\"installment_total_count\":20,\"interval\":1,\"interval_type\":\"d\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"notification_days\":2,\"payment_method\":\"cc\",\"product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"recurring_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"recurring_api_id\":\"recurring1234abcd\",\"start_date\":\"2021-12-01\",\"status\":\"active\",\"transaction_amount\":3,\"terms_agree\":true,\"terms_agree_ip\":\"192.168.0.10\",\"recurring_c1\":\"recurring custom data 1\",\"recurring_c2\":\"recurring custom data 2\",\"recurring_c3\":\"recurring custom data 3\",\"send_to_proc_as_recur\":true,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"next_run_date\":\"2021-12-01\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"recurring_type_id\":\"i\"}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Place on hold recurring payment.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestPlaceOnHoldRecurringPayment()
        {
            // Parameters for the API call
            string recurringId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseRecurring result = null;
            try
            {
                result = await this.controller.PlaceOnHoldRecurringPaymentAsync(recurringId);
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
                    "{\"type\":\"Recurring\",\"data\":{\"account_vault_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"active\":1,\"description\":\"Description\",\"end_date\":\"2021-12-01\",\"installment_total_count\":20,\"interval\":1,\"interval_type\":\"d\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"notification_days\":2,\"payment_method\":\"cc\",\"product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"recurring_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"recurring_api_id\":\"recurring1234abcd\",\"start_date\":\"2021-12-01\",\"status\":\"active\",\"transaction_amount\":3,\"terms_agree\":true,\"terms_agree_ip\":\"192.168.0.10\",\"recurring_c1\":\"recurring custom data 1\",\"recurring_c2\":\"recurring custom data 2\",\"recurring_c3\":\"recurring custom data 3\",\"send_to_proc_as_recur\":true,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"next_run_date\":\"2021-12-01\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"recurring_type_id\":\"i\"}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}