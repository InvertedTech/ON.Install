// <copyright file="UserVerificationsControllerTest.cs" company="APIMatic">
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
    /// UserVerificationsControllerTest.
    /// </summary>
    [TestFixture]
    public class UserVerificationsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private UserVerificationsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.UserVerificationsController;
        }

        /// <summary>
        /// Get user verification.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetUserVerification()
        {
            // Parameters for the API call
            string userVerificationId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseUserVerification result = null;
            try
            {
                result = await this.controller.GetUserVerificationAsync(userVerificationId);
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
                    "{\"type\":\"UserVerification\",\"data\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"hash\":\"123456781234567812345678\",\"created_ts\":1422040992}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// List user verifications.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListUserVerifications()
        {
            // Parameters for the API call
            Standard.Models.Page page = null;
            List<Standard.Models.Order19> order = null;
            List<Standard.Models.FilterBy> filterBy = null;
            List<string> expand = null;
            Standard.Models.Format1Enum? format = null;
            string typeahead = null;
            List<Standard.Models.Field53Enum> fields = null;

            // Perform API call
            Standard.Models.ResponseUserVerificationsCollection result = null;
            try
            {
                result = await this.controller.ListUserVerificationsAsync(page, order, filterBy, expand, format, typeahead, fields);
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
                    "{\"type\":\"UserVerificationsCollection\",\"list\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"hash\":\"123456781234567812345678\",\"created_ts\":1422040992}],\"links\":{\"type\":\"Links\",\"first\":\"/v1/endpoint?page[size]=10&page[number]=1\",\"previous\":\"/v1/endpoint?page[size]=10&page[number]=5\",\"last\":\"/v1/endpoint?page[size]=10&page[number]=42\"},\"pagination\":{\"type\":\"Pagination\",\"total_count\":423,\"page_count\":42,\"page_number\":6,\"page_size\":10},\"sort\":{\"type\":\"Sorting\",\"fields\":[{\"field\":\"last_name\",\"order\":\"asc\"}]}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}