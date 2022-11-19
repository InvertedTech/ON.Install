// <copyright file="TerminalsControllerTest.cs" company="APIMatic">
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
    /// TerminalsControllerTest.
    /// </summary>
    [TestFixture]
    public class TerminalsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private TerminalsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.TerminalsController;
        }

        /// <summary>
        /// List all terminals related.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListAllTerminalsRelated()
        {
            // Parameters for the API call
            Standard.Models.Page page = null;
            Standard.Models.Sort9 sort = null;
            Standard.Models.Filter9 filter = null;
            List<string> expand = null;

            // Perform API call
            Standard.Models.ResponseTerminalsCollection result = null;
            try
            {
                result = await this.controller.ListAllTerminalsRelatedAsync(page, sort, filter, expand);
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
                    "{\"type\":\"TerminalsCollection\",\"list\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"default_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_application_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_cvm_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_manufacturer_code\":1,\"title\":\"My terminal\",\"mac_address\":\"3D:F2:C9:A6:B3:4F\",\"local_ip_address\":\"192.168.0.10\",\"port\":10009,\"serial_number\":\"1234567890\",\"terminal_number\":\"973456789012367\",\"terminal_timeouts\":{\"card_entry_timeout\":47,\"device_terms_prompt_timeout\":30,\"overall_timeout\":125,\"pin_entry_timeout\":40,\"signature_input_timeout\":35,\"signature_submit_timeout\":38,\"status_display_time\":12,\"tip_cashback_timeout\":25,\"transaction_timeout\":17},\"tip_percents\":{\"percent_1\":0,\"percent_2\":2,\"percent_3\":99},\"header_line_1\":\"line 1 sample\",\"header_line_2\":\"line 2 sample\",\"header_line_3\":\"line 3 sample\",\"header_line_4\":\"line 4 sample\",\"header_line_5\":\"line 5 sample\",\"trailer_line_1\":\"trailer 1 sample\",\"trailer_line_2\":\"trailer 2 sample\",\"trailer_line_3\":\"trailer 3 sample\",\"trailer_line_4\":\"trailer 4 sample\",\"trailer_line_5\":\"trailer 5 sample\",\"default_checkin\":\"2021-12-01\",\"default_checkout\":\"2021-12-01\",\"default_room_rate\":56,\"default_room_number\":\"303\",\"debit\":false,\"emv\":false,\"cashback_enable\":false,\"print_enable\":false,\"sig_capture_enable\":false,\"is_provisioned\":false,\"tip_enable\":false,\"validated_decryption\":false,\"communication_type\":\"http\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"last_registration_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}]}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// View single terminals record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestViewSingleTerminalsRecord()
        {
            // Parameters for the API call
            string terminalId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseTerminal result = null;
            try
            {
                result = await this.controller.ViewSingleTerminalsRecordAsync(terminalId);
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
                    "{\"type\":\"Terminal\",\"data\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"default_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_application_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_cvm_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_manufacturer_code\":1,\"title\":\"My terminal\",\"mac_address\":\"3D:F2:C9:A6:B3:4F\",\"local_ip_address\":\"192.168.0.10\",\"port\":10009,\"serial_number\":\"1234567890\",\"terminal_number\":\"973456789012367\",\"terminal_timeouts\":{\"card_entry_timeout\":47,\"device_terms_prompt_timeout\":30,\"overall_timeout\":125,\"pin_entry_timeout\":40,\"signature_input_timeout\":35,\"signature_submit_timeout\":38,\"status_display_time\":12,\"tip_cashback_timeout\":25,\"transaction_timeout\":17},\"tip_percents\":{\"percent_1\":0,\"percent_2\":2,\"percent_3\":99},\"header_line_1\":\"line 1 sample\",\"header_line_2\":\"line 2 sample\",\"header_line_3\":\"line 3 sample\",\"header_line_4\":\"line 4 sample\",\"header_line_5\":\"line 5 sample\",\"trailer_line_1\":\"trailer 1 sample\",\"trailer_line_2\":\"trailer 2 sample\",\"trailer_line_3\":\"trailer 3 sample\",\"trailer_line_4\":\"trailer 4 sample\",\"trailer_line_5\":\"trailer 5 sample\",\"default_checkin\":\"2021-12-01\",\"default_checkout\":\"2021-12-01\",\"default_room_rate\":56,\"default_room_number\":\"303\",\"debit\":false,\"emv\":false,\"cashback_enable\":false,\"print_enable\":false,\"sig_capture_enable\":false,\"is_provisioned\":false,\"tip_enable\":false,\"validated_decryption\":false,\"communication_type\":\"http\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"last_registration_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}