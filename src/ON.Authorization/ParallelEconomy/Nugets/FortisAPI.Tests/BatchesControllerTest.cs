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
        /// List All Batches.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListAllBatches()
        {
            // Parameters for the API call
            Standard.Models.Page page = null;
            List<Standard.Models.Order19> order = null;
            List<Standard.Models.FilterBy> filterBy = null;
            List<Standard.Models.ExpandEnum> expand = null;
            Standard.Models.Format1Enum? format = null;
            string typeahead = null;
            List<Standard.Models.Field25Enum> fields = null;

            // Perform API call
            Standard.Models.ResponseBatchsCollection result = null;
            try
            {
                result = await this.controller.ListAllBatchesAsync(page, order, filterBy, expand, format, typeahead, fields);
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
                    "{\"type\":\"BatchsCollection\",\"list\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"processing_status_id\":2,\"batch_num\":4,\"is_open\":0,\"settlement_file_name\":\"settement_file.txt\",\"batch_close_ts\":1531423693,\"batch_close_detail\":\"BATCH_MISMATCH\",\"total_sale_amount\":2342,\"total_sale_count\":21,\"total_refund_amount\":2342,\"total_refund_count\":18,\"total_void_amount\":2342,\"total_void_count\":17,\"total_blind_refund_amount\":2342,\"total_blind_refund_count\":16,\"changelogs\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"action\":\"CREATE\",\"model\":\"TransactionRequest\",\"model_id\":\"11ec829598f0d4008be9aba4\",\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_details\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"field\":\"next_run_ts\",\"old_value\":\"1643616000\"}],\"user\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"username\":\"email@domain.com\",\"first_name\":\"Bob\",\"last_name\":\"Fairview\"}}],\"postback_logs\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"postback_config_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"next_run_ts\":1422040992,\"created_ts\":1422040992,\"model_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"product_transaction\":{\"processor_version\":\"1_0_0\",\"title\":\"My terminal\",\"payment_method\":\"cc\",\"processor\":\"zgate\",\"mcc\":\"1111\",\"tax_surcharge_config\":2,\"partner\":\"standalone\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"surcharge\":{},\"processor_data\":{},\"vt_clerk_number\":true,\"vt_billing_phone\":true,\"vt_enable_tip\":true,\"ach_allow_debit\":true,\"ach_allow_credit\":true,\"ach_allow_refund\":true,\"vt_cvv\":true,\"vt_street\":true,\"vt_zip\":true,\"vt_order_num\":true,\"vt_enable\":true,\"receipt_show_contact_name\":true,\"display_avs\":true,\"card_type_visa\":true,\"card_type_mc\":true,\"card_type_disc\":true,\"card_type_amex\":true,\"card_type_diners\":true,\"card_type_jcb\":true,\"invoice_location\":true,\"allow_partial_authorization\":true,\"allow_recurring_partial_authorization\":true,\"auto_decline_cvv\":true,\"auto_decline_street\":true,\"auto_decline_zip\":true,\"split_payments_allow\":true,\"vt_show_custom_fields\":true,\"receipt_show_custom_fields\":true,\"vt_override_sales_tax_allowed\":true,\"vt_enable_sales_tax\":true,\"vt_require_zip\":true,\"vt_require_street\":true,\"auto_decline_cavv\":true,\"current_batch\":34,\"dup_check_per_batch\":null,\"paylink_allow\":false,\"quick_invoice_allow\":false,\"level3_allow\":false,\"payfac_enable\":false,\"sales_office_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"hosted_payment_page_allow\":false,\"surcharge_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"level3_default\":{},\"cau_subscribe_type_id\":0,\"location_billing_account_id\":\"11eb88b873980c64a21e5fd2\",\"product_billing_group_id\":\"nofees\",\"account_number\":\"12345678\",\"run_avs_on_accountvault_create\":false,\"accountvault_expire_notification_email_enable\":false,\"debit_allow_void\":false,\"quick_invoice_text_to_pay\":false,\"sms_enable\":false,\"vt_show_currency\":true,\"receipt_show_currency\":false,\"allow_blind_refund\":false,\"vt_show_company_name\":false,\"receipt_show_company_name\":false,\"bank_funded_only\":false,\"require_cvv_on_keyed_cnp\":true,\"require_cvv_on_tokenized_cnp\":true,\"show_secondary_amount\":false,\"allow_secondary_amount\":false,\"show_google_pay\":true,\"show_apple_pay\":true,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"active\":true,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"product_transaction_api_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"is_secondary_amount_allowed\":false,\"batch_risk_config\":{},\"fortis_id\":\"8149742\",\"product_billing_group_code\":\"nofees\",\"cau_subscribe_type_code\":0}}],\"links\":{\"type\":\"Links\",\"first\":\"/v1/endpoint?page[size]=10&page[number]=1\",\"previous\":\"/v1/endpoint?page[size]=10&page[number]=5\",\"last\":\"/v1/endpoint?page[size]=10&page[number]=42\"},\"pagination\":{\"type\":\"Pagination\",\"total_count\":423,\"page_count\":42,\"page_number\":6,\"page_size\":10},\"sort\":{\"type\":\"Sorting\",\"fields\":[{\"field\":\"last_name\",\"order\":\"asc\"}]}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
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
            Assert.AreEqual(202, HttpCallBack.Response.StatusCode, "Status should be 202");

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
                    "{\"type\":\"AsyncProcessing\",\"data\":{\"async\":{\"code\":\"406c66c3-21cb-47fb-80fc-843bc42507fb\",\"link\":\"/v1/async/status/406c66c3-21cb-47fb-80fc-843bc42507fb\"}}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}