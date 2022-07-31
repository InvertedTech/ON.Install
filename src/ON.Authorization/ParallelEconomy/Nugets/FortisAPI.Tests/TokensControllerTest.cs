// <copyright file="TokensControllerTest.cs" company="APIMatic">
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
    /// TokensControllerTest.
    /// </summary>
    [TestFixture]
    public class TokensControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private TokensController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.TokensController;
        }

        /// <summary>
        /// Delete a single token record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestDeleteASingleTokenRecord()
        {
            // Parameters for the API call
            string tokenId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseToken result = null;
            try
            {
                result = await this.controller.DeleteASingleTokenRecordAsync(tokenId);
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
                    "{\"type\":\"Token\",\"data\":{\"account_holder_name\":\"John Smith\",\"account_number\":\"545454545454545\",\"account_vault_api_id\":\"accountvaultabcd\",\"accountvault_c1\":\"accountvault custom 1\",\"accountvault_c2\":\"accountvault custom 2\",\"accountvault_c3\":\"accountvault custom 3\",\"ach_sec_code\":\"WEB\",\"billing_address\":{\"city\":\"Novi\",\"state\":\"Michigan\",\"postal_code\":\"48375\",\"street\":\"43155 Main Street STE 2310-C\",\"phone\":\"3339998822\"},\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"customer_id\":\"123456\",\"identity_verification\":{\"dl_state\":\"MI\",\"dl_number\":\"1235567\",\"ssn4\":\"8527\",\"dob_year\":\"1980\"},\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"previous_account_vault_api_id\":\"previousaccountvault123456\",\"previous_account_vault_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"previous_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_agree\":true,\"terms_agree_ip\":\"192.168.0.10\",\"title\":\"Test CC Account\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"account_type\":\"checking\",\"active\":true,\"cau_summary_status_id\":1,\"created_ts\":1422040992,\"e_serial_number\":\"1234567890\",\"e_track_data\":null,\"e_format\":null,\"e_keyed_data\":null,\"expiring_in_months\":null,\"first_six\":\"700953\",\"has_recurring\":false,\"last_four\":\"3657\",\"modified_ts\":1422040992,\"payment_method\":\"cc\",\"ticket\":null,\"track_data\":null}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// View single token record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestViewSingleTokenRecord()
        {
            // Parameters for the API call
            string tokenId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseToken result = null;
            try
            {
                result = await this.controller.ViewSingleTokenRecordAsync(tokenId);
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
                    "{\"type\":\"Token\",\"data\":{\"account_holder_name\":\"John Smith\",\"account_number\":\"545454545454545\",\"account_vault_api_id\":\"accountvaultabcd\",\"accountvault_c1\":\"accountvault custom 1\",\"accountvault_c2\":\"accountvault custom 2\",\"accountvault_c3\":\"accountvault custom 3\",\"ach_sec_code\":\"WEB\",\"billing_address\":{\"city\":\"Novi\",\"state\":\"Michigan\",\"postal_code\":\"48375\",\"street\":\"43155 Main Street STE 2310-C\",\"phone\":\"3339998822\"},\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"customer_id\":\"123456\",\"identity_verification\":{\"dl_state\":\"MI\",\"dl_number\":\"1235567\",\"ssn4\":\"8527\",\"dob_year\":\"1980\"},\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"previous_account_vault_api_id\":\"previousaccountvault123456\",\"previous_account_vault_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"previous_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_agree\":true,\"terms_agree_ip\":\"192.168.0.10\",\"title\":\"Test CC Account\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"account_type\":\"checking\",\"active\":true,\"cau_summary_status_id\":1,\"created_ts\":1422040992,\"e_serial_number\":\"1234567890\",\"e_track_data\":null,\"e_format\":null,\"e_keyed_data\":null,\"expiring_in_months\":null,\"first_six\":\"700953\",\"has_recurring\":false,\"last_four\":\"3657\",\"modified_ts\":1422040992,\"payment_method\":\"cc\",\"ticket\":null,\"track_data\":null}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// List all tokens related.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListAllTokensRelated()
        {
            // Parameters for the API call
            Standard.Models.Page page = null;
            Standard.Models.Sort10 sort = null;
            Standard.Models.Filter10 filter = null;
            List<string> expand = null;

            // Perform API call
            Standard.Models.ResponseTokensCollection result = null;
            try
            {
                result = await this.controller.ListAllTokensRelatedAsync(page, sort, filter, expand);
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
                    "{\"type\":\"TokensCollection\",\"list\":[{\"account_holder_name\":\"John Smith\",\"account_number\":\"545454545454545\",\"account_vault_api_id\":\"accountvaultabcd\",\"accountvault_c1\":\"accountvault custom 1\",\"accountvault_c2\":\"accountvault custom 2\",\"accountvault_c3\":\"accountvault custom 3\",\"ach_sec_code\":\"WEB\",\"billing_address\":{\"city\":\"Novi\",\"state\":\"Michigan\",\"postal_code\":\"48375\",\"street\":\"43155 Main Street STE 2310-C\",\"phone\":\"3339998822\"},\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"customer_id\":\"123456\",\"identity_verification\":{\"dl_state\":\"MI\",\"dl_number\":\"1235567\",\"ssn4\":\"8527\",\"dob_year\":\"1980\"},\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"previous_account_vault_api_id\":\"previousaccountvault123456\",\"previous_account_vault_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"previous_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_agree\":true,\"terms_agree_ip\":\"192.168.0.10\",\"title\":\"Test CC Account\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"account_type\":\"checking\",\"active\":true,\"cau_summary_status_id\":1,\"created_ts\":1422040992,\"e_serial_number\":\"1234567890\",\"e_track_data\":null,\"e_format\":null,\"e_keyed_data\":null,\"expiring_in_months\":null,\"first_six\":\"700953\",\"has_recurring\":false,\"last_four\":\"3657\",\"modified_ts\":1422040992,\"payment_method\":\"cc\",\"ticket\":null,\"track_data\":null}]}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}