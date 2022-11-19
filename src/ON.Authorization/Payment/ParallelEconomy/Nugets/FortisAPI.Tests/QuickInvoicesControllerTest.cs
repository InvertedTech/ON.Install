// <copyright file="QuickInvoicesControllerTest.cs" company="APIMatic">
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
    /// QuickInvoicesControllerTest.
    /// </summary>
    [TestFixture]
    public class QuickInvoicesControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private QuickInvoicesController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.QuickInvoicesController;
        }

        /// <summary>
        /// List all quick invoices related.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListAllQuickInvoicesRelated()
        {
            // Parameters for the API call
            Standard.Models.Page page = null;
            Standard.Models.Sort5 sort = null;
            Standard.Models.Filter5 filter = null;
            List<string> expand = null;

            // Perform API call
            Standard.Models.ResponseQuickInvoicesCollection result = null;
            try
            {
                result = await this.controller.ListAllQuickInvoicesRelatedAsync(page, sort, filter, expand);
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
                    "{\"type\":\"QuickInvoicesCollection\",\"list\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"title\":\"My terminal\",\"cc_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"ach_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"due_date\":\"2021-12-01\",\"item_list\":[{\"name\":\"Bread\",\"amount\":20.15}],\"allow_overpayment\":true,\"email\":\"email@domain.com\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_api_id\":\"contact12345\",\"customer_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"expire_date\":\"2021-12-01\",\"allow_partial_pay\":true,\"attach_files_to_email\":true,\"send_email\":true,\"invoice_number\":\"invoice12345\",\"item_header\":\"Quick invoice header sample\",\"item_footer\":\"Thank you\",\"amount_due\":245.36,\"notification_email\":\"email@domain.com\",\"payment_status_id\":1,\"status_id\":1,\"note\":\"some note\",\"notification_days_before_due_date\":3,\"notification_days_after_due_date\":7,\"notification_on_due_date\":true,\"send_text_to_pay\":true,\"files\":[null],\"remaining_balance\":245.36,\"single_payment_min_amount\":5,\"single_payment_max_amount\":5000,\"cell_phone\":\"3339998822\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"active\":true,\"is_active\":true}]}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Resend Notification Email.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestResendNotificationEmail()
        {
            // Parameters for the API call
            string quickInvoiceId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseQuickInvoice result = null;
            try
            {
                result = await this.controller.ResendNotificationEmailAsync(quickInvoiceId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(201, this.HttpCallBackHandler.Response.StatusCode, "Status should be 201");

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
                    "{\"type\":\"QuickInvoice\",\"data\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"title\":\"My terminal\",\"cc_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"ach_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"due_date\":\"2021-12-01\",\"item_list\":[{\"name\":\"Bread\",\"amount\":20.15}],\"allow_overpayment\":true,\"email\":\"email@domain.com\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_api_id\":\"contact12345\",\"customer_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"expire_date\":\"2021-12-01\",\"allow_partial_pay\":true,\"attach_files_to_email\":true,\"send_email\":true,\"invoice_number\":\"invoice12345\",\"item_header\":\"Quick invoice header sample\",\"item_footer\":\"Thank you\",\"amount_due\":245.36,\"notification_email\":\"email@domain.com\",\"payment_status_id\":1,\"status_id\":1,\"note\":\"some note\",\"notification_days_before_due_date\":3,\"notification_days_after_due_date\":7,\"notification_on_due_date\":true,\"send_text_to_pay\":true,\"files\":[null],\"remaining_balance\":245.36,\"single_payment_min_amount\":5,\"single_payment_max_amount\":5000,\"cell_phone\":\"3339998822\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"active\":true,\"is_active\":true}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Delete quick Invoice.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestDeleteQuickInvoice()
        {
            // Parameters for the API call
            string quickInvoiceId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseQuickInvoice result = null;
            try
            {
                result = await this.controller.DeleteQuickInvoiceAsync(quickInvoiceId);
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
                    "{\"type\":\"QuickInvoice\",\"data\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"title\":\"My terminal\",\"cc_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"ach_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"due_date\":\"2021-12-01\",\"item_list\":[{\"name\":\"Bread\",\"amount\":20.15}],\"allow_overpayment\":true,\"email\":\"email@domain.com\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_api_id\":\"contact12345\",\"customer_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"expire_date\":\"2021-12-01\",\"allow_partial_pay\":true,\"attach_files_to_email\":true,\"send_email\":true,\"invoice_number\":\"invoice12345\",\"item_header\":\"Quick invoice header sample\",\"item_footer\":\"Thank you\",\"amount_due\":245.36,\"notification_email\":\"email@domain.com\",\"payment_status_id\":1,\"status_id\":1,\"note\":\"some note\",\"notification_days_before_due_date\":3,\"notification_days_after_due_date\":7,\"notification_on_due_date\":true,\"send_text_to_pay\":true,\"files\":[null],\"remaining_balance\":245.36,\"single_payment_min_amount\":5,\"single_payment_max_amount\":5000,\"cell_phone\":\"3339998822\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"active\":true,\"is_active\":true}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// View single quick invoice record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestViewSingleQuickInvoiceRecord()
        {
            // Parameters for the API call
            string quickInvoiceId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseQuickInvoice result = null;
            try
            {
                result = await this.controller.ViewSingleQuickInvoiceRecordAsync(quickInvoiceId);
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
                    "{\"type\":\"QuickInvoice\",\"data\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"title\":\"My terminal\",\"cc_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"ach_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"due_date\":\"2021-12-01\",\"item_list\":[{\"name\":\"Bread\",\"amount\":20.15}],\"allow_overpayment\":true,\"email\":\"email@domain.com\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_api_id\":\"contact12345\",\"customer_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"expire_date\":\"2021-12-01\",\"allow_partial_pay\":true,\"attach_files_to_email\":true,\"send_email\":true,\"invoice_number\":\"invoice12345\",\"item_header\":\"Quick invoice header sample\",\"item_footer\":\"Thank you\",\"amount_due\":245.36,\"notification_email\":\"email@domain.com\",\"payment_status_id\":1,\"status_id\":1,\"note\":\"some note\",\"notification_days_before_due_date\":3,\"notification_days_after_due_date\":7,\"notification_on_due_date\":true,\"send_text_to_pay\":true,\"files\":[null],\"remaining_balance\":245.36,\"single_payment_min_amount\":5,\"single_payment_max_amount\":5000,\"cell_phone\":\"3339998822\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"active\":true,\"is_active\":true}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}