// <copyright file="Level3DataControllerTest.cs" company="APIMatic">
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
    /// Level3DataControllerTest.
    /// </summary>
    [TestFixture]
    public class Level3DataControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private Level3DataController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.Level3DataController;
        }

        /// <summary>
        /// Delete a single level3 record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestDeleteASingleLevel3Record()
        {
            // Parameters for the API call
            string transactionId = null;
            string level3Id = null;

            // Perform API call
            Standard.Models.ResponseTransationLevel3 result = null;
            try
            {
                result = await this.controller.DeleteASingleLevel3RecordAsync(transactionId, level3Id);
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
                    "{\"type\":\"TransationLevel3\",\"data\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"level3_data\":{\"destination_country_code\":\"840\",\"duty_amount\":0,\"freight_amount\":0,\"national_tax\":2,\"sales_tax\":200,\"shipfrom_zip_code\":\"AZ1234\",\"shipto_zip_code\":\"FL1234\",\"tax_amount\":10,\"tax_exempt\":0,\"customer_vat_registration\":\"12345678\",\"merchant_vat_registration\":\"123456\",\"order_date\":\"171006\",\"summary_commodity_code\":\"C1K2\",\"tax_rate\":0,\"unique_vat_ref_number\":\"vat1234\",\"line_items\":[{\"description\":\"cool drink\",\"commodity_code\":\"cc123456\",\"discount_amount\":0,\"other_tax_amount\":0,\"product_code\":\"fanta123456\",\"quantity\":12,\"tax_amount\":4,\"tax_rate\":0,\"unit_code\":\"gll\",\"unit_cost\":3,\"alternate_tax_id\":\"1234\",\"debit_credit\":\"C\",\"discount_rate\":11,\"tax_type_applied\":\"22\",\"tax_type_id\":\"11\"}]}}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// View single level3 record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestViewSingleLevel3Record()
        {
            // Parameters for the API call
            string transactionId = null;
            string level3Id = null;

            // Perform API call
            Standard.Models.ResponseTransationLevel3 result = null;
            try
            {
                result = await this.controller.ViewSingleLevel3RecordAsync(transactionId, level3Id);
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
                    "{\"type\":\"TransationLevel3\",\"data\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"level3_data\":{\"destination_country_code\":\"840\",\"duty_amount\":0,\"freight_amount\":0,\"national_tax\":2,\"sales_tax\":200,\"shipfrom_zip_code\":\"AZ1234\",\"shipto_zip_code\":\"FL1234\",\"tax_amount\":10,\"tax_exempt\":0,\"customer_vat_registration\":\"12345678\",\"merchant_vat_registration\":\"123456\",\"order_date\":\"171006\",\"summary_commodity_code\":\"C1K2\",\"tax_rate\":0,\"unique_vat_ref_number\":\"vat1234\",\"line_items\":[{\"description\":\"cool drink\",\"commodity_code\":\"cc123456\",\"discount_amount\":0,\"other_tax_amount\":0,\"product_code\":\"fanta123456\",\"quantity\":12,\"tax_amount\":4,\"tax_rate\":0,\"unit_code\":\"gll\",\"unit_cost\":3,\"alternate_tax_id\":\"1234\",\"debit_credit\":\"C\",\"discount_rate\":11,\"tax_type_applied\":\"22\",\"tax_type_id\":\"11\"}]}}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}