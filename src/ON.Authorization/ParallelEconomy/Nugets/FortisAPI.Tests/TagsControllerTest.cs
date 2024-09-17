// <copyright file="TagsControllerTest.cs" company="APIMatic">
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
    /// TagsControllerTest.
    /// </summary>
    [TestFixture]
    public class TagsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private TagsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.TagsController;
        }

        /// <summary>
        /// List all tags related.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListAllTagsRelated()
        {
            // Parameters for the API call
            Standard.Models.Page page = null;
            List<Standard.Models.Order19> order = null;
            List<Standard.Models.FilterBy> filterBy = null;
            List<Standard.Models.Expand34Enum> expand = null;
            Standard.Models.Format1Enum? format = null;
            string typeahead = null;
            List<Standard.Models.Field43Enum> fields = null;

            // Perform API call
            Standard.Models.ResponseTagsCollection result = null;
            try
            {
                result = await this.controller.ListAllTagsRelatedAsync(page, order, filterBy, expand, format, typeahead, fields);
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
                    "{\"type\":\"TagsCollection\",\"list\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"title\":\"My terminal\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"location\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"ticket_hash_key\":\"A5F443CADF4AE34BBCAADF4\"}}],\"links\":{\"type\":\"Links\",\"first\":\"/v1/endpoint?page[size]=10&page[number]=1\",\"previous\":\"/v1/endpoint?page[size]=10&page[number]=5\",\"last\":\"/v1/endpoint?page[size]=10&page[number]=42\"},\"pagination\":{\"type\":\"Pagination\",\"total_count\":423,\"page_count\":42,\"page_number\":6,\"page_size\":10},\"sort\":{\"type\":\"Sorting\",\"fields\":[{\"field\":\"last_name\",\"order\":\"asc\"}]}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Delete tag record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestDeleteTagRecord()
        {
            // Parameters for the API call
            string tagId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseTag result = null;
            try
            {
                result = await this.controller.DeleteTagRecordAsync(tagId);
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
                    "{\"type\":\"Tag\",\"data\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"title\":\"My terminal\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"location\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"ticket_hash_key\":\"A5F443CADF4AE34BBCAADF4\"}}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// View single tags record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestViewSingleTagsRecord()
        {
            // Parameters for the API call
            string tagId = "11e95f8ec39de8fbdb0a4f1a";
            List<Standard.Models.Expand34Enum> expand = null;
            List<Standard.Models.Field43Enum> fields = null;

            // Perform API call
            Standard.Models.ResponseTag result = null;
            try
            {
                result = await this.controller.ViewSingleTagsRecordAsync(tagId, expand, fields);
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
                    "{\"type\":\"Tag\",\"data\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"title\":\"My terminal\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"location\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"ticket_hash_key\":\"A5F443CADF4AE34BBCAADF4\"}}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}