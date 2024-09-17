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
            List<Standard.Models.Expand95Enum> expand = null;

            // Perform API call
            Standard.Models.ResponseUserApiKey result = null;
            try
            {
                result = await this.controller.CreateANewAPIKeyAsync(userId, expand);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(201, HttpCallBack.Response.StatusCode, "Status should be 201");

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
                    "{\"type\":\"UserApiKey\",\"data\":{\"user_api_key\":\"234bas8dfn8238f923w2\"}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// List all User.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListAllUser()
        {
            // Parameters for the API call
            Standard.Models.Page page = null;
            List<Standard.Models.Order19> order = null;
            List<Standard.Models.FilterBy> filterBy = null;
            List<Standard.Models.Expand95Enum> expand = null;
            Standard.Models.Format1Enum? format = null;
            string typeahead = null;
            List<Standard.Models.Field54Enum> fields = null;

            // Perform API call
            Standard.Models.ResponseUsersCollection result = null;
            try
            {
                result = await this.controller.ListAllUserAsync(page, order, filterBy, expand, format, typeahead, fields);
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
                    "{\"type\":\"UsersCollection\",\"list\":[{\"account_number\":\"5454545454545454\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"Sample contact ID\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"terms_condition_code\":\"20220308\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_code\":1,\"api_only\":false,\"is_invitation\":false,\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\",\"current_login\":1422040992,\"log_api_response_body_ts\":1422040992,\"locations\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"ticket_hash_key\":\"A5F443CADF4AE34BBCAADF4\"}],\"primary_location\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"ticket_hash_key\":\"A5F443CADF4AE34BBCAADF4\"},\"received_emails\":[{\"subject\":\"Payment Receipt - 12skiestech\",\"body\":\"This email is being sent from a server.\",\"source_address\":\"\\\"12skiestech A7t3qi\\\" <noreply@zeamster.email>\",\"return_path\":\"\\\"12skiestech A7t3qi\\\" <noreply@zeamster.email>\",\"provider_id\":\"0100017e67bcc530-e1dd23b4-8a39-4a5b-8d5d-68d51c4c942f-000000\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"reason_sent\":\"Contact Email\",\"reason_model\":\"Transaction\",\"reason_model_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"reply_to\":\"\\\"Zeamster\\\" <emma.p@zeamster.com>\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992}],\"contact\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"account_number\":\"54545433332\",\"contact_api_id\":\"137\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"cell_phone\":\"3339998822\",\"balance\":245.36,\"address\":{\"city\":\"Novi\",\"state\":\"Michigan\",\"postal_code\":\"48375\",\"country\":\"US\"},\"company_name\":\"Fortis Payment Systems, LLC\",\"header_message\":\"This is a sample message for you\",\"date_of_birth\":\"2021-12-01\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"office_phone\":\"3339998822\",\"office_phone_ext\":\"5\",\"header_message_type\":0,\"update_if_exists\":1,\"contact_c1\":\"any\",\"contact_c2\":\"anything\",\"contact_c3\":\"something\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"active\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"},\"isDeletable\":true,\"active_notification_alerts\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_start\":\"2021-12-01 10:10:00\",\"date_end\":\"2021-12-01 10:10:00\",\"user_location\":true,\"user_contact\":true,\"include_children\":true,\"alert_type\":1,\"alert_type_id\":1,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"location_users\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_api_id\":null,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"auth_roles\":[{\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"auth_role_code\":110,\"code\":83931,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"changelogs\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"action\":\"CREATE\",\"model\":\"TransactionRequest\",\"model_id\":\"11ec829598f0d4008be9aba4\",\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_details\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"field\":\"next_run_ts\",\"old_value\":\"1643616000\"}],\"user\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"username\":\"email@domain.com\",\"first_name\":\"Bob\",\"last_name\":\"Fairview\"}}],\"resources\":{\"title\":\"My terminal\",\"priv\":null,\"resource_name\":\"v2.addons.iframe.get\",\"id\":5693,\"last_used_date\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992},\"domain\":{\"url\":\"fortispayrbyn9y.sandbox.zeamster.com\",\"title\":\"Test Brand Domain Title 2\",\"logo\":\"\",\"support_email\":\"email@domain.com\",\"allow_contact_signup\":true,\"allow_contact_registration\":true,\"allow_contact_login\":true,\"registration_fields\":[\"account_number\"],\"company_name\":null,\"nav_color\":null,\"button_primary_color\":null,\"logo_background_color\":null,\"icon_background_color\":null,\"menu_text_background_color\":null,\"menu_text_color\":null,\"right_menu_background_color\":null,\"right_menu_text_color\":null,\"button_primary_text_color\":null,\"nav_logo\":null,\"fav_icon\":null,\"aes_key\":null,\"help_text\":null,\"email_reply_to\":\"email@domain.com\",\"email\":\"email@domain.com\",\"custom_javascript\":null,\"custom_theme\":null,\"custom_css\":null,\"contact_user_default_entry_page\":\"dashboard\",\"contact_user_default_auth_roles\":[null],\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992},\"created_user\":{\"account_number\":\"5454545454545454\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"terms_condition_code\":\"20220308\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_code\":1,\"api_only\":false,\"is_invitation\":false,\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\",\"current_login\":1422040992,\"log_api_response_body_ts\":1422040992},\"location_marketplaces\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"marketplace_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_api_id\":null,\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"email_blacklist\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"isBlacklisted\":true,\"detail\":true,\"created_ts\":1422040992},\"helppage\":{\"user_type_code\":100,\"body\":\"Sample Body\",\"title\":\"Sample Title\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}}],\"links\":{\"type\":\"Links\",\"first\":\"/v1/endpoint?page[size]=10&page[number]=1\",\"previous\":\"/v1/endpoint?page[size]=10&page[number]=5\",\"last\":\"/v1/endpoint?page[size]=10&page[number]=42\"},\"pagination\":{\"type\":\"Pagination\",\"total_count\":423,\"page_count\":42,\"page_number\":6,\"page_size\":10},\"sort\":{\"type\":\"Sorting\",\"fields\":[{\"field\":\"last_name\",\"order\":\"asc\"}]}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
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
            string userId = "11e95f8ec39de8fbdb0a4f1a";

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
                    "{\"type\":\"User\",\"data\":{\"account_number\":\"5454545454545454\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"Sample contact ID\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"terms_condition_code\":\"20220308\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_code\":1,\"api_only\":false,\"is_invitation\":false,\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\",\"current_login\":1422040992,\"log_api_response_body_ts\":1422040992,\"locations\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"ticket_hash_key\":\"A5F443CADF4AE34BBCAADF4\"}],\"primary_location\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"ticket_hash_key\":\"A5F443CADF4AE34BBCAADF4\"},\"received_emails\":[{\"subject\":\"Payment Receipt - 12skiestech\",\"body\":\"This email is being sent from a server.\",\"source_address\":\"\\\"12skiestech A7t3qi\\\" <noreply@zeamster.email>\",\"return_path\":\"\\\"12skiestech A7t3qi\\\" <noreply@zeamster.email>\",\"provider_id\":\"0100017e67bcc530-e1dd23b4-8a39-4a5b-8d5d-68d51c4c942f-000000\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"reason_sent\":\"Contact Email\",\"reason_model\":\"Transaction\",\"reason_model_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"reply_to\":\"\\\"Zeamster\\\" <emma.p@zeamster.com>\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992}],\"contact\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"account_number\":\"54545433332\",\"contact_api_id\":\"137\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"cell_phone\":\"3339998822\",\"balance\":245.36,\"address\":{\"city\":\"Novi\",\"state\":\"Michigan\",\"postal_code\":\"48375\",\"country\":\"US\"},\"company_name\":\"Fortis Payment Systems, LLC\",\"header_message\":\"This is a sample message for you\",\"date_of_birth\":\"2021-12-01\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"office_phone\":\"3339998822\",\"office_phone_ext\":\"5\",\"header_message_type\":0,\"update_if_exists\":1,\"contact_c1\":\"any\",\"contact_c2\":\"anything\",\"contact_c3\":\"something\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"active\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"},\"isDeletable\":true,\"active_notification_alerts\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_start\":\"2021-12-01 10:10:00\",\"date_end\":\"2021-12-01 10:10:00\",\"user_location\":true,\"user_contact\":true,\"include_children\":true,\"alert_type\":1,\"alert_type_id\":1,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"location_users\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_api_id\":null,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"auth_roles\":[{\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"auth_role_code\":110,\"code\":83931,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"changelogs\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"action\":\"CREATE\",\"model\":\"TransactionRequest\",\"model_id\":\"11ec829598f0d4008be9aba4\",\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_details\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"field\":\"next_run_ts\",\"old_value\":\"1643616000\"}],\"user\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"username\":\"email@domain.com\",\"first_name\":\"Bob\",\"last_name\":\"Fairview\"}}],\"resources\":{\"title\":\"My terminal\",\"priv\":null,\"resource_name\":\"v2.addons.iframe.get\",\"id\":5693,\"last_used_date\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992},\"domain\":{\"url\":\"fortispayrbyn9y.sandbox.zeamster.com\",\"title\":\"Test Brand Domain Title 2\",\"logo\":\"\",\"support_email\":\"email@domain.com\",\"allow_contact_signup\":true,\"allow_contact_registration\":true,\"allow_contact_login\":true,\"registration_fields\":[\"account_number\"],\"company_name\":null,\"nav_color\":null,\"button_primary_color\":null,\"logo_background_color\":null,\"icon_background_color\":null,\"menu_text_background_color\":null,\"menu_text_color\":null,\"right_menu_background_color\":null,\"right_menu_text_color\":null,\"button_primary_text_color\":null,\"nav_logo\":null,\"fav_icon\":null,\"aes_key\":null,\"help_text\":null,\"email_reply_to\":\"email@domain.com\",\"email\":\"email@domain.com\",\"custom_javascript\":null,\"custom_theme\":null,\"custom_css\":null,\"contact_user_default_entry_page\":\"dashboard\",\"contact_user_default_auth_roles\":[null],\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992},\"created_user\":{\"account_number\":\"5454545454545454\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"terms_condition_code\":\"20220308\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_code\":1,\"api_only\":false,\"is_invitation\":false,\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\",\"current_login\":1422040992,\"log_api_response_body_ts\":1422040992},\"location_marketplaces\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"marketplace_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_api_id\":null,\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"email_blacklist\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"isBlacklisted\":true,\"detail\":true,\"created_ts\":1422040992},\"helppage\":{\"user_type_code\":100,\"body\":\"Sample Body\",\"title\":\"Sample Title\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
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
            List<Standard.Models.Expand95Enum> expand = null;
            List<Standard.Models.Field54Enum> fields = null;

            // Perform API call
            Standard.Models.ResponseUser result = null;
            try
            {
                result = await this.controller.ViewSingleUserRecordAsync(userId, expand, fields);
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
                    "{\"type\":\"User\",\"data\":{\"account_number\":\"5454545454545454\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"Sample contact ID\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"terms_condition_code\":\"20220308\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_code\":1,\"api_only\":false,\"is_invitation\":false,\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\",\"current_login\":1422040992,\"log_api_response_body_ts\":1422040992,\"locations\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"ticket_hash_key\":\"A5F443CADF4AE34BBCAADF4\"}],\"primary_location\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"ticket_hash_key\":\"A5F443CADF4AE34BBCAADF4\"},\"received_emails\":[{\"subject\":\"Payment Receipt - 12skiestech\",\"body\":\"This email is being sent from a server.\",\"source_address\":\"\\\"12skiestech A7t3qi\\\" <noreply@zeamster.email>\",\"return_path\":\"\\\"12skiestech A7t3qi\\\" <noreply@zeamster.email>\",\"provider_id\":\"0100017e67bcc530-e1dd23b4-8a39-4a5b-8d5d-68d51c4c942f-000000\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"reason_sent\":\"Contact Email\",\"reason_model\":\"Transaction\",\"reason_model_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"reply_to\":\"\\\"Zeamster\\\" <emma.p@zeamster.com>\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992}],\"contact\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"account_number\":\"54545433332\",\"contact_api_id\":\"137\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"cell_phone\":\"3339998822\",\"balance\":245.36,\"address\":{\"city\":\"Novi\",\"state\":\"Michigan\",\"postal_code\":\"48375\",\"country\":\"US\"},\"company_name\":\"Fortis Payment Systems, LLC\",\"header_message\":\"This is a sample message for you\",\"date_of_birth\":\"2021-12-01\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"office_phone\":\"3339998822\",\"office_phone_ext\":\"5\",\"header_message_type\":0,\"update_if_exists\":1,\"contact_c1\":\"any\",\"contact_c2\":\"anything\",\"contact_c3\":\"something\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"active\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"},\"isDeletable\":true,\"active_notification_alerts\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_start\":\"2021-12-01 10:10:00\",\"date_end\":\"2021-12-01 10:10:00\",\"user_location\":true,\"user_contact\":true,\"include_children\":true,\"alert_type\":1,\"alert_type_id\":1,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"location_users\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_api_id\":null,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"auth_roles\":[{\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"auth_role_code\":110,\"code\":83931,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"changelogs\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"action\":\"CREATE\",\"model\":\"TransactionRequest\",\"model_id\":\"11ec829598f0d4008be9aba4\",\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_details\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"field\":\"next_run_ts\",\"old_value\":\"1643616000\"}],\"user\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"username\":\"email@domain.com\",\"first_name\":\"Bob\",\"last_name\":\"Fairview\"}}],\"resources\":{\"title\":\"My terminal\",\"priv\":null,\"resource_name\":\"v2.addons.iframe.get\",\"id\":5693,\"last_used_date\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992},\"domain\":{\"url\":\"fortispayrbyn9y.sandbox.zeamster.com\",\"title\":\"Test Brand Domain Title 2\",\"logo\":\"\",\"support_email\":\"email@domain.com\",\"allow_contact_signup\":true,\"allow_contact_registration\":true,\"allow_contact_login\":true,\"registration_fields\":[\"account_number\"],\"company_name\":null,\"nav_color\":null,\"button_primary_color\":null,\"logo_background_color\":null,\"icon_background_color\":null,\"menu_text_background_color\":null,\"menu_text_color\":null,\"right_menu_background_color\":null,\"right_menu_text_color\":null,\"button_primary_text_color\":null,\"nav_logo\":null,\"fav_icon\":null,\"aes_key\":null,\"help_text\":null,\"email_reply_to\":\"email@domain.com\",\"email\":\"email@domain.com\",\"custom_javascript\":null,\"custom_theme\":null,\"custom_css\":null,\"contact_user_default_entry_page\":\"dashboard\",\"contact_user_default_auth_roles\":[null],\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992},\"created_user\":{\"account_number\":\"5454545454545454\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"terms_condition_code\":\"20220308\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_code\":1,\"api_only\":false,\"is_invitation\":false,\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\",\"current_login\":1422040992,\"log_api_response_body_ts\":1422040992},\"location_marketplaces\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"marketplace_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_api_id\":null,\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"email_blacklist\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"isBlacklisted\":true,\"detail\":true,\"created_ts\":1422040992},\"helppage\":{\"user_type_code\":100,\"body\":\"Sample Body\",\"title\":\"Sample Title\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
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
            List<Standard.Models.Expand95Enum> expand = null;
            List<Standard.Models.Field54Enum> fields = null;

            // Perform API call
            Standard.Models.ResponseUser result = null;
            try
            {
                result = await this.controller.ViewSelfRecordAsync(expand, fields);
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
                    "{\"type\":\"User\",\"data\":{\"account_number\":\"5454545454545454\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"Sample contact ID\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"terms_condition_code\":\"20220308\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_code\":1,\"api_only\":false,\"is_invitation\":false,\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\",\"current_login\":1422040992,\"log_api_response_body_ts\":1422040992,\"locations\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"ticket_hash_key\":\"A5F443CADF4AE34BBCAADF4\"}],\"primary_location\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"ticket_hash_key\":\"A5F443CADF4AE34BBCAADF4\"},\"received_emails\":[{\"subject\":\"Payment Receipt - 12skiestech\",\"body\":\"This email is being sent from a server.\",\"source_address\":\"\\\"12skiestech A7t3qi\\\" <noreply@zeamster.email>\",\"return_path\":\"\\\"12skiestech A7t3qi\\\" <noreply@zeamster.email>\",\"provider_id\":\"0100017e67bcc530-e1dd23b4-8a39-4a5b-8d5d-68d51c4c942f-000000\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"reason_sent\":\"Contact Email\",\"reason_model\":\"Transaction\",\"reason_model_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"reply_to\":\"\\\"Zeamster\\\" <emma.p@zeamster.com>\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992}],\"contact\":{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"account_number\":\"54545433332\",\"contact_api_id\":\"137\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"cell_phone\":\"3339998822\",\"balance\":245.36,\"address\":{\"city\":\"Novi\",\"state\":\"Michigan\",\"postal_code\":\"48375\",\"country\":\"US\"},\"company_name\":\"Fortis Payment Systems, LLC\",\"header_message\":\"This is a sample message for you\",\"date_of_birth\":\"2021-12-01\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"office_phone\":\"3339998822\",\"office_phone_ext\":\"5\",\"header_message_type\":0,\"update_if_exists\":1,\"contact_c1\":\"any\",\"contact_c2\":\"anything\",\"contact_c3\":\"something\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"active\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"},\"isDeletable\":true,\"active_notification_alerts\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_start\":\"2021-12-01 10:10:00\",\"date_end\":\"2021-12-01 10:10:00\",\"user_location\":true,\"user_contact\":true,\"include_children\":true,\"alert_type\":1,\"alert_type_id\":1,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"location_users\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_api_id\":null,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"auth_roles\":[{\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"auth_role_code\":110,\"code\":83931,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"changelogs\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"action\":\"CREATE\",\"model\":\"TransactionRequest\",\"model_id\":\"11ec829598f0d4008be9aba4\",\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_details\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"field\":\"next_run_ts\",\"old_value\":\"1643616000\"}],\"user\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"username\":\"email@domain.com\",\"first_name\":\"Bob\",\"last_name\":\"Fairview\"}}],\"resources\":{\"title\":\"My terminal\",\"priv\":null,\"resource_name\":\"v2.addons.iframe.get\",\"id\":5693,\"last_used_date\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992},\"domain\":{\"url\":\"fortispayrbyn9y.sandbox.zeamster.com\",\"title\":\"Test Brand Domain Title 2\",\"logo\":\"\",\"support_email\":\"email@domain.com\",\"allow_contact_signup\":true,\"allow_contact_registration\":true,\"allow_contact_login\":true,\"registration_fields\":[\"account_number\"],\"company_name\":null,\"nav_color\":null,\"button_primary_color\":null,\"logo_background_color\":null,\"icon_background_color\":null,\"menu_text_background_color\":null,\"menu_text_color\":null,\"right_menu_background_color\":null,\"right_menu_text_color\":null,\"button_primary_text_color\":null,\"nav_logo\":null,\"fav_icon\":null,\"aes_key\":null,\"help_text\":null,\"email_reply_to\":\"email@domain.com\",\"email\":\"email@domain.com\",\"custom_javascript\":null,\"custom_theme\":null,\"custom_css\":null,\"contact_user_default_entry_page\":\"dashboard\",\"contact_user_default_auth_roles\":[null],\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992},\"created_user\":{\"account_number\":\"5454545454545454\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"terms_condition_code\":\"20220308\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_code\":1,\"api_only\":false,\"is_invitation\":false,\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\",\"current_login\":1422040992,\"log_api_response_body_ts\":1422040992},\"location_marketplaces\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"marketplace_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_api_id\":null,\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"email_blacklist\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"isBlacklisted\":true,\"detail\":true,\"created_ts\":1422040992},\"helppage\":{\"user_type_code\":100,\"body\":\"Sample Body\",\"title\":\"Sample Title\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Remove the pending user.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestRemoveVerification()
        {
            // Parameters for the API call
            string userId = null;

            // Perform API call
            Standard.Models.ResponseRemoveVerification result = null;
            try
            {
                result = await this.controller.RemoveVerificationAsync(userId);
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
                    "{\"type\":\"RemoveVerification\",\"data\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"hash\":\"123456781234567812345678\",\"created_ts\":1422040992}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Send an verification email to the pending user.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestSendVerification()
        {
            // Parameters for the API call
            string userId = null;

            // Perform API call
            Standard.Models.ResponseSendVerification result = null;
            try
            {
                result = await this.controller.SendVerificationAsync(userId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(201, HttpCallBack.Response.StatusCode, "Status should be 201");

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
                    "{\"type\":\"SendVerification\",\"data\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"hash\":\"123456781234567812345678\",\"created_ts\":1422040992}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}