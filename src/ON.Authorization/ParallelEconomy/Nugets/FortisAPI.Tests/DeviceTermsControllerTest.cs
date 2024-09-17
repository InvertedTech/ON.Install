// <copyright file="DeviceTermsControllerTest.cs" company="APIMatic">
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
    /// DeviceTermsControllerTest.
    /// </summary>
    [TestFixture]
    public class DeviceTermsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private DeviceTermsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.DeviceTermsController;
        }

        /// <summary>
        /// List all device terms related.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListAllDeviceTermsRelated()
        {
            // Parameters for the API call
            Standard.Models.Page page = null;
            List<Standard.Models.Order19> order = null;
            List<Standard.Models.FilterBy> filterBy = null;
            List<Standard.Models.Expand8Enum> expand = null;
            Standard.Models.Format1Enum? format = null;
            string typeahead = null;
            List<Standard.Models.Field29Enum> fields = null;

            // Perform API call
            Standard.Models.ResponseDeviceTermsCollection result = null;
            try
            {
                result = await this.controller.ListAllDeviceTermsRelatedAsync(page, order, filterBy, expand, format, typeahead, fields);
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
                    "{\"type\":\"DeviceTermsCollection\",\"list\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"require_signature\":true,\"device_term_api_id\":\"device_term134\",\"terms_conditions\":\"FUNgib0Vh0B9c0Wbttvr50vNtGLOkTdFL0eFmhN1RJpKhK14IENeDa8irp2dEk9thEcVHvVEyriQeZLs5NjNsCzqNj9JDA4RSJwK647IFtYjrNPN1nBb9bw6hoQ71oT5kpsiXGt8HcqBFVBVeDA7psIzKAyDveAw2o1hfjipkOtXrPgWun0rYwyyFuvqkT1egQYKfYDj\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"reason_code_id\":1000,\"signature\":{\"signature\":\"iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC\",\"resource\":\"Transaction\",\"resource_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992},\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_user\":{\"account_number\":\"5454545454545454\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"terms_condition_code\":\"20220308\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_code\":1,\"api_only\":false,\"is_invitation\":false,\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\",\"current_login\":1422040992,\"log_api_response_body_ts\":1422040992},\"location\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"ticket_hash_key\":\"A5F443CADF4AE34BBCAADF4\"},\"terminal\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"default_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_application_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_cvm_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_manufacturer_code\":\"1\",\"title\":\"My terminal\",\"mac_address\":\"3D:F2:C9:A6:B3:4F\",\"local_ip_address\":\"192.168.0.10\",\"port\":10009,\"serial_number\":\"1234567890\",\"terminal_number\":\"973456789012367\",\"terminal_timeouts\":{\"card_entry_timeout\":47,\"device_terms_prompt_timeout\":30,\"overall_timeout\":125,\"pin_entry_timeout\":40,\"signature_input_timeout\":35,\"signature_submit_timeout\":38,\"status_display_time\":12,\"tip_cashback_timeout\":25,\"transaction_timeout\":17},\"tip_percents\":{\"percent_1\":0,\"percent_2\":2,\"percent_3\":99},\"header_line_1\":\"line 1 sample\",\"header_line_2\":\"line 2 sample\",\"header_line_3\":\"line 3 sample\",\"header_line_4\":\"line 4 sample\",\"header_line_5\":\"line 5 sample\",\"trailer_line_1\":\"trailer 1 sample\",\"trailer_line_2\":\"trailer 2 sample\",\"trailer_line_3\":\"trailer 3 sample\",\"trailer_line_4\":\"trailer 4 sample\",\"trailer_line_5\":\"trailer 5 sample\",\"default_checkin\":\"2021-12-01\",\"default_checkout\":\"2021-12-01\",\"default_room_rate\":56,\"default_room_number\":\"303\",\"debit\":false,\"emv\":false,\"cashback_enable\":false,\"print_enable\":false,\"sig_capture_enable\":false,\"is_provisioned\":false,\"tip_enable\":false,\"validated_decryption\":false,\"communication_type\":\"http\",\"active\":true,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"last_registration_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"},\"changelogs\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"action\":\"CREATE\",\"model\":\"TransactionRequest\",\"model_id\":\"11ec829598f0d4008be9aba4\",\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_details\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"field\":\"next_run_ts\",\"old_value\":\"1643616000\"}],\"user\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"username\":\"email@domain.com\",\"first_name\":\"Bob\",\"last_name\":\"Fairview\"}}],\"reason_code\":{\"id\":50,\"title\":\"Sample Title\"}}],\"links\":{\"type\":\"Links\",\"first\":\"/v1/endpoint?page[size]=10&page[number]=1\",\"previous\":\"/v1/endpoint?page[size]=10&page[number]=5\",\"last\":\"/v1/endpoint?page[size]=10&page[number]=42\"},\"pagination\":{\"type\":\"Pagination\",\"total_count\":423,\"page_count\":42,\"page_number\":6,\"page_size\":10},\"sort\":{\"type\":\"Sorting\",\"fields\":[{\"field\":\"last_name\",\"order\":\"asc\"}]}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// View single device term record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestViewSingleDeviceTermRecord()
        {
            // Parameters for the API call
            string deviceTermsId = "11e95f8ec39de8fbdb0a4f1a";
            List<Standard.Models.Expand8Enum> expand = null;
            List<Standard.Models.Field29Enum> fields = null;

            // Perform API call
            Standard.Models.ResponseDeviceTerm result = null;
            try
            {
                result = await this.controller.ViewSingleDeviceTermRecordAsync(deviceTermsId, expand, fields);
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
                    "{\"type\":\"DeviceTerm\",\"data\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"require_signature\":true,\"device_term_api_id\":\"device_term134\",\"terms_conditions\":\"FUNgib0Vh0B9c0Wbttvr50vNtGLOkTdFL0eFmhN1RJpKhK14IENeDa8irp2dEk9thEcVHvVEyriQeZLs5NjNsCzqNj9JDA4RSJwK647IFtYjrNPN1nBb9bw6hoQ71oT5kpsiXGt8HcqBFVBVeDA7psIzKAyDveAw2o1hfjipkOtXrPgWun0rYwyyFuvqkT1egQYKfYDj\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"reason_code_id\":1000,\"signature\":{\"signature\":\"iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC\",\"resource\":\"Transaction\",\"resource_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992},\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_user\":{\"account_number\":\"5454545454545454\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"terms_condition_code\":\"20220308\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_code\":1,\"api_only\":false,\"is_invitation\":false,\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\",\"current_login\":1422040992,\"log_api_response_body_ts\":1422040992},\"location\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"ticket_hash_key\":\"A5F443CADF4AE34BBCAADF4\"},\"terminal\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"default_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_application_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_cvm_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_manufacturer_code\":\"1\",\"title\":\"My terminal\",\"mac_address\":\"3D:F2:C9:A6:B3:4F\",\"local_ip_address\":\"192.168.0.10\",\"port\":10009,\"serial_number\":\"1234567890\",\"terminal_number\":\"973456789012367\",\"terminal_timeouts\":{\"card_entry_timeout\":47,\"device_terms_prompt_timeout\":30,\"overall_timeout\":125,\"pin_entry_timeout\":40,\"signature_input_timeout\":35,\"signature_submit_timeout\":38,\"status_display_time\":12,\"tip_cashback_timeout\":25,\"transaction_timeout\":17},\"tip_percents\":{\"percent_1\":0,\"percent_2\":2,\"percent_3\":99},\"header_line_1\":\"line 1 sample\",\"header_line_2\":\"line 2 sample\",\"header_line_3\":\"line 3 sample\",\"header_line_4\":\"line 4 sample\",\"header_line_5\":\"line 5 sample\",\"trailer_line_1\":\"trailer 1 sample\",\"trailer_line_2\":\"trailer 2 sample\",\"trailer_line_3\":\"trailer 3 sample\",\"trailer_line_4\":\"trailer 4 sample\",\"trailer_line_5\":\"trailer 5 sample\",\"default_checkin\":\"2021-12-01\",\"default_checkout\":\"2021-12-01\",\"default_room_rate\":56,\"default_room_number\":\"303\",\"debit\":false,\"emv\":false,\"cashback_enable\":false,\"print_enable\":false,\"sig_capture_enable\":false,\"is_provisioned\":false,\"tip_enable\":false,\"validated_decryption\":false,\"communication_type\":\"http\",\"active\":true,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"last_registration_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"},\"changelogs\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"action\":\"CREATE\",\"model\":\"TransactionRequest\",\"model_id\":\"11ec829598f0d4008be9aba4\",\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_details\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"field\":\"next_run_ts\",\"old_value\":\"1643616000\"}],\"user\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"username\":\"email@domain.com\",\"first_name\":\"Bob\",\"last_name\":\"Fairview\"}}],\"reason_code\":{\"id\":50,\"title\":\"Sample Title\"}}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}