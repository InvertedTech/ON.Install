// <copyright file="ContactsControllerTest.cs" company="APIMatic">
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
    /// ContactsControllerTest.
    /// </summary>
    [TestFixture]
    public class ContactsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private ContactsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.ContactsController;
        }

        /// <summary>
        /// List all Contacts.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListAllContacts()
        {
            // Parameters for the API call
            Standard.Models.Page page = null;
            Standard.Models.Sort1 sort = null;
            Standard.Models.Filter1 filter = null;
            List<Standard.Models.ExpandEnum> expand = null;

            // Perform API call
            Standard.Models.ResponseContactsCollection result = null;
            try
            {
                result = await this.controller.ListAllContactsAsync(page, sort, filter, expand);
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
                    "{\"type\":\"ContactsCollection\",\"list\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"account_number\":\"54545433332\",\"contact_api_id\":\"137\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"cell_phone\":\"3339998822\",\"balance\":245.36,\"address\":{\"city\":\"Novi\",\"state\":\"Michigan\",\"postal_code\":\"48375\",\"country\":\"US\",\"street\":\"43155 Main Street STE 2310-C\"},\"company_name\":\"Fortis Payment Systems, LLC\",\"header_message\":\"This is a sample message for you\",\"date_of_birth\":\"2021-12-01\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"office_phone\":\"3339998822\",\"office_phone_ext\":\"5\",\"header_message_type\":0,\"update_if_exists\":1,\"contact_c1\":\"any\",\"contact_c2\":\"anything\",\"contact_c3\":\"something\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"active\":1}]}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Delete Contact.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestDeleteContact()
        {
            // Parameters for the API call
            string contactId = "11e95f8ec39de8fbdb0a4f1a";

            // Perform API call
            Standard.Models.ResponseContact result = null;
            try
            {
                result = await this.controller.DeleteContactAsync(contactId);
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
                    "{\"type\":\"Contact\",\"data\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"account_number\":\"54545433332\",\"contact_api_id\":\"137\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"cell_phone\":\"3339998822\",\"balance\":245.36,\"address\":{\"city\":\"Novi\",\"state\":\"Michigan\",\"postal_code\":\"48375\",\"country\":\"US\",\"street\":\"43155 Main Street STE 2310-C\"},\"company_name\":\"Fortis Payment Systems, LLC\",\"header_message\":\"This is a sample message for you\",\"date_of_birth\":\"2021-12-01\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"office_phone\":\"3339998822\",\"office_phone_ext\":\"5\",\"header_message_type\":0,\"update_if_exists\":1,\"contact_c1\":\"any\",\"contact_c2\":\"anything\",\"contact_c3\":\"something\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"active\":1}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// View Single Contact .
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestViewSingleContact()
        {
            // Parameters for the API call
            string contactId = "11e95f8ec39de8fbdb0a4f1a";
            List<Standard.Models.ExpandEnum> expand = null;

            // Perform API call
            Standard.Models.ResponseContact result = null;
            try
            {
                result = await this.controller.ViewSingleContactAsync(contactId, expand);
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
                    "{\"type\":\"Contact\",\"data\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"account_number\":\"54545433332\",\"contact_api_id\":\"137\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"cell_phone\":\"3339998822\",\"balance\":245.36,\"address\":{\"city\":\"Novi\",\"state\":\"Michigan\",\"postal_code\":\"48375\",\"country\":\"US\",\"street\":\"43155 Main Street STE 2310-C\"},\"company_name\":\"Fortis Payment Systems, LLC\",\"header_message\":\"This is a sample message for you\",\"date_of_birth\":\"2021-12-01\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"office_phone\":\"3339998822\",\"office_phone_ext\":\"5\",\"header_message_type\":0,\"update_if_exists\":1,\"contact_c1\":\"any\",\"contact_c2\":\"anything\",\"contact_c3\":\"something\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"active\":1}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}