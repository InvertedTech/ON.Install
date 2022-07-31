// <copyright file="UsersControllerTest.cs" company="APIMatic">
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
    /// UsersControllerTest.
    /// </summary>
    [TestFixture]
    public class UsersControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private UsersController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.UsersController;
        }

        /// <summary>
        /// Create a new API key.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCreateANewAPIKey()
        {
            // Parameters for the API call
            string userId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseUser result = null;
            try
            {
                result = await this.controller.CreateANewAPIKeyAsync(userId);
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
                    "{\"type\":\"User\",\"data\":{\"user_api_key\":\"234bas8dfn8238f923w2\"}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// List all user related.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListAllUserRelated()
        {
            // Parameters for the API call
            Standard.Models.Page page = null;
            Standard.Models.Sort12 sort = null;
            Standard.Models.Filter12 filter = null;
            List<string> expand = null;

            // Perform API call
            Standard.Models.ResponseUsersCollection result = null;
            try
            {
                result = await this.controller.ListAllUserRelatedAsync(page, sort, filter, expand);
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
                    "{\"type\":\"UsersCollection\",\"list\":[{\"account_number\":\"5454545454545454\",\"address\":\"43155 Main Street STE 2310-C\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"city\":\"Novi\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"state\":\"Michigan\",\"terms_condition_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_id\":true,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\"}]}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Delete a user record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestDeleteAUserRecord()
        {
            // Parameters for the API call
            string userId = null;

            // Perform API call
            Standard.Models.ResponseUser result = null;
            try
            {
                result = await this.controller.DeleteAUserRecordAsync(userId);
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
                    "{\"type\":\"User\",\"data\":{\"account_number\":\"5454545454545454\",\"address\":\"43155 Main Street STE 2310-C\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"city\":\"Novi\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"state\":\"Michigan\",\"terms_condition_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_id\":true,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\"}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// View single user record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestViewSingleUserRecord()
        {
            // Parameters for the API call
            string userId = "11e95f8ec39de8fbdb0a4f1a";
            List<string> expand = null;

            // Perform API call
            Standard.Models.ResponseUser result = null;
            try
            {
                result = await this.controller.ViewSingleUserRecordAsync(userId, expand);
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
                    "{\"type\":\"User\",\"data\":{\"account_number\":\"5454545454545454\",\"address\":\"43155 Main Street STE 2310-C\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"city\":\"Novi\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"state\":\"Michigan\",\"terms_condition_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_id\":true,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\"}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// View self record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestViewSelfRecord()
        {
            // Parameters for the API call
            List<string> expand = null;

            // Perform API call
            Standard.Models.ResponseUser result = null;
            try
            {
                result = await this.controller.ViewSelfRecordAsync(expand);
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
                    "{\"type\":\"User\",\"data\":{\"account_number\":\"5454545454545454\",\"address\":\"43155 Main Street STE 2310-C\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"city\":\"Novi\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"state\":\"Michigan\",\"terms_condition_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_id\":true,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\"}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}