// <copyright file="LocationsControllerTest.cs" company="APIMatic">
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
    /// LocationsControllerTest.
    /// </summary>
    [TestFixture]
    public class LocationsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private LocationsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.LocationsController;
        }

        /// <summary>
        /// Locations Search.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestLocationsSearch()
        {
            // Parameters for the API call
            Standard.Models.Page page = null;
            string keyword = null;

            // Perform API call
            Standard.Models.ResponseLocationSearchsCollection result = null;
            try
            {
                result = await this.controller.LocationsSearchAsync(page, keyword);
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
                    "{\"type\":\"LocationSearchsCollection\",\"list\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11ed3e73adb98c0282f3fa9b\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"branding_domain_url\":\"subdomain.sandbox.domain.com\",\"branding_domain\":{},\"product_transactions\":[null],\"product_file\":{},\"product_accountvault\":{},\"product_recurring\":{},\"tags\":[null],\"terminals\":[null]}],\"links\":{\"type\":\"Links\",\"first\":\"/v1/endpoint?page[size]=10&page[number]=1\",\"previous\":\"/v1/endpoint?page[size]=10&page[number]=5\",\"last\":\"/v1/endpoint?page[size]=10&page[number]=42\"},\"pagination\":{\"type\":\"Pagination\",\"total_count\":423,\"page_count\":42,\"page_number\":6,\"page_size\":10},\"sort\":{\"type\":\"Sorting\",\"fields\":[{\"field\":\"last_name\",\"order\":\"asc\"}]}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// List all locations.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListAllLocations()
        {
            // Parameters for the API call
            Standard.Models.Page page = null;
            List<Standard.Models.Order19> order = null;
            List<Standard.Models.FilterBy> filterBy = null;
            List<Standard.Models.Expand10Enum> expand = null;
            Standard.Models.Format1Enum? format = null;
            string typeahead = null;
            List<Standard.Models.Field31Enum> fields = null;

            // Perform API call
            Standard.Models.ResponseLocationsCollection result = null;
            try
            {
                result = await this.controller.ListAllLocationsAsync(page, order, filterBy, expand, format, typeahead, fields);
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
                    "{\"type\":\"LocationsCollection\",\"list\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"ticket_hash_key\":\"A5F443CADF4AE34BBCAADF4\",\"parent\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"ticket_hash_key\":\"A5F443CADF4AE34BBCAADF4\"},\"users\":[{\"account_number\":\"5454545454545454\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"terms_condition_code\":\"20220308\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_code\":1,\"api_only\":false,\"is_invitation\":false,\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\",\"current_login\":1422040992,\"log_api_response_body_ts\":1422040992}],\"is_deletable\":true,\"terminals\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"default_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_application_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_cvm_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_manufacturer_code\":\"1\",\"title\":\"My terminal\",\"mac_address\":\"3D:F2:C9:A6:B3:4F\",\"local_ip_address\":\"192.168.0.10\",\"port\":10009,\"serial_number\":\"1234567890\",\"terminal_number\":\"973456789012367\",\"terminal_timeouts\":{\"card_entry_timeout\":47,\"device_terms_prompt_timeout\":30,\"overall_timeout\":125,\"pin_entry_timeout\":40,\"signature_input_timeout\":35,\"signature_submit_timeout\":38,\"status_display_time\":12,\"tip_cashback_timeout\":25,\"transaction_timeout\":17},\"tip_percents\":{\"percent_1\":0,\"percent_2\":2,\"percent_3\":99},\"header_line_1\":\"line 1 sample\",\"header_line_2\":\"line 2 sample\",\"header_line_3\":\"line 3 sample\",\"header_line_4\":\"line 4 sample\",\"header_line_5\":\"line 5 sample\",\"trailer_line_1\":\"trailer 1 sample\",\"trailer_line_2\":\"trailer 2 sample\",\"trailer_line_3\":\"trailer 3 sample\",\"trailer_line_4\":\"trailer 4 sample\",\"trailer_line_5\":\"trailer 5 sample\",\"default_checkin\":\"2021-12-01\",\"default_checkout\":\"2021-12-01\",\"default_room_rate\":56,\"default_room_number\":\"303\",\"debit\":false,\"emv\":false,\"cashback_enable\":false,\"print_enable\":false,\"sig_capture_enable\":false,\"is_provisioned\":false,\"tip_enable\":false,\"validated_decryption\":false,\"communication_type\":\"http\",\"active\":true,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"last_registration_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"branding_domain\":{\"url\":\"fortispayrbyn9y.sandbox.zeamster.com\",\"title\":\"Test Brand Domain Title 2\",\"logo\":\"\",\"support_email\":\"email@domain.com\",\"allow_contact_signup\":true,\"allow_contact_registration\":true,\"allow_contact_login\":true,\"registration_fields\":[\"account_number\"],\"company_name\":null,\"nav_color\":null,\"button_primary_color\":null,\"logo_background_color\":null,\"icon_background_color\":null,\"menu_text_background_color\":null,\"menu_text_color\":null,\"right_menu_background_color\":null,\"right_menu_text_color\":null,\"button_primary_text_color\":null,\"nav_logo\":null,\"fav_icon\":null,\"aes_key\":null,\"help_text\":null,\"email_reply_to\":\"email@domain.com\",\"email\":\"email@domain.com\",\"custom_javascript\":null,\"custom_theme\":null,\"custom_css\":null,\"contact_user_default_entry_page\":\"dashboard\",\"contact_user_default_auth_roles\":[null],\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992},\"product_invoice\":{\"title\":\"Sample title\",\"quote_number_start\":1,\"quote_number_increment\":1,\"quote_number_current\":1,\"invoice_number_start\":1,\"invoice_number_increment\":1,\"invoice_number_current\":1,\"tax_rate\":0,\"tax_fee\":0,\"monthly_fee\":0,\"per_invoice_fee\":0,\"per_quote_fee\":0,\"require_pay_in_full\":true,\"selectable\":1,\"reportable\":1,\"portfolio_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"},\"product_files\":[{\"title\":\"My terminal\",\"product_file_credential_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"active\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"created_user\":{\"account_number\":\"5454545454545454\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"terms_condition_code\":\"20220308\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_code\":1,\"api_only\":false,\"is_invitation\":false,\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\",\"current_login\":1422040992,\"log_api_response_body_ts\":1422040992},\"changelogs\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"action\":\"CREATE\",\"model\":\"TransactionRequest\",\"model_id\":\"11ec829598f0d4008be9aba4\",\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_details\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"field\":\"next_run_ts\",\"old_value\":\"1643616000\"}],\"user\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"username\":\"email@domain.com\",\"first_name\":\"Bob\",\"last_name\":\"Fairview\"}}],\"product_transactions\":[{\"processor_version\":\"1_0_0\",\"title\":\"My terminal\",\"payment_method\":\"cc\",\"processor\":\"zgate\",\"mcc\":\"1111\",\"tax_surcharge_config\":2,\"partner\":\"standalone\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"surcharge\":{},\"processor_data\":{},\"vt_clerk_number\":true,\"vt_billing_phone\":true,\"vt_enable_tip\":true,\"ach_allow_debit\":true,\"ach_allow_credit\":true,\"ach_allow_refund\":true,\"vt_cvv\":true,\"vt_street\":true,\"vt_zip\":true,\"vt_order_num\":true,\"vt_enable\":true,\"receipt_show_contact_name\":true,\"display_avs\":true,\"card_type_visa\":true,\"card_type_mc\":true,\"card_type_disc\":true,\"card_type_amex\":true,\"card_type_diners\":true,\"card_type_jcb\":true,\"invoice_location\":true,\"allow_partial_authorization\":true,\"allow_recurring_partial_authorization\":true,\"auto_decline_cvv\":true,\"auto_decline_street\":true,\"auto_decline_zip\":true,\"split_payments_allow\":true,\"vt_show_custom_fields\":true,\"receipt_show_custom_fields\":true,\"vt_override_sales_tax_allowed\":true,\"vt_enable_sales_tax\":true,\"vt_require_zip\":true,\"vt_require_street\":true,\"auto_decline_cavv\":true,\"current_batch\":34,\"dup_check_per_batch\":null,\"paylink_allow\":false,\"quick_invoice_allow\":false,\"level3_allow\":false,\"payfac_enable\":false,\"sales_office_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"hosted_payment_page_allow\":false,\"surcharge_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"level3_default\":{},\"cau_subscribe_type_id\":0,\"location_billing_account_id\":\"11eb88b873980c64a21e5fd2\",\"product_billing_group_id\":\"nofees\",\"account_number\":\"12345678\",\"run_avs_on_accountvault_create\":false,\"accountvault_expire_notification_email_enable\":false,\"debit_allow_void\":false,\"quick_invoice_text_to_pay\":false,\"sms_enable\":false,\"vt_show_currency\":true,\"receipt_show_currency\":false,\"allow_blind_refund\":false,\"vt_show_company_name\":false,\"receipt_show_company_name\":false,\"bank_funded_only\":false,\"require_cvv_on_keyed_cnp\":true,\"require_cvv_on_tokenized_cnp\":true,\"show_secondary_amount\":false,\"allow_secondary_amount\":false,\"show_google_pay\":true,\"show_apple_pay\":true,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"active\":true,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"product_transaction_api_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"is_secondary_amount_allowed\":false,\"batch_risk_config\":{},\"fortis_id\":\"8149742\",\"product_billing_group_code\":\"nofees\",\"cau_subscribe_type_code\":0}],\"terminal_routers\":[{\"mac_address\":\"3D:F2:C9:A6:B3:4F\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"developer_company\":{\"title\":\"My terminal\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"active\":true,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"},\"developer_company_id\":\"sample developer company id\",\"helppages\":[{\"user_type_code\":100,\"body\":\"Sample Body\",\"title\":\"Sample Title\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"quick_invoice_setting\":{\"location_api_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"quick_invoice_template\":\"<html>Template<html>\",\"default_allow_partial_pay\":true,\"default_notification_on_due_date\":true,\"default_notification_days_after_due_date\":7,\"default_notification_days_before_due_date\":3,\"id\":\"11e95f8ec39de8fbdb0a4f1a\"},\"location_billing_accounts\":[{\"title\":\"Billing Acccount Title\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"ach_sec_code\":null,\"account_number\":null,\"routing\":null,\"exp_date\":\"0722\",\"billing_zip\":\"48375\",\"account_type\":null,\"account_holder_name\":\"John Smith\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"billing_descriptor\":null,\"payment_method\":null,\"portfolio_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"marketplaces\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"marketplace_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_api_id\":null,\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"locationmarketplaces\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"marketplace_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_api_id\":null,\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"addons\":[{\"title\":\" \",\"secret\":\" \",\"iframe_url\":\" \",\"location_setup_url\":\" \",\"user_setup_url\":\" \",\"encrypt_url_params\":true}]}],\"links\":{\"type\":\"Links\",\"first\":\"/v1/endpoint?page[size]=10&page[number]=1\",\"previous\":\"/v1/endpoint?page[size]=10&page[number]=5\",\"last\":\"/v1/endpoint?page[size]=10&page[number]=42\"},\"pagination\":{\"type\":\"Pagination\",\"total_count\":423,\"page_count\":42,\"page_number\":6,\"page_size\":10},\"sort\":{\"type\":\"Sorting\",\"fields\":[{\"field\":\"last_name\",\"order\":\"asc\"}]}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Locations Detail.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestLocationsDetail()
        {
            // Parameters for the API call
            Standard.Models.Page page = null;
            List<Standard.Models.Order19> order = null;
            List<Standard.Models.FilterBy> filterBy = null;
            List<Standard.Models.Expand10Enum> expand = null;
            Standard.Models.Format1Enum? format = null;
            string typeahead = null;
            List<Standard.Models.Field32Enum> fields = null;
            object productTransactionActive = null;
            object productFileActive = null;
            object productInvoiceActive = null;
            object productRecurringActive = null;
            object productAccountvaultActive = null;

            // Perform API call
            Standard.Models.ResponseLocationInfosCollection result = null;
            try
            {
                result = await this.controller.LocationsDetailAsync(page, order, filterBy, expand, format, typeahead, fields, productTransactionActive, productFileActive, productInvoiceActive, productRecurringActive, productAccountvaultActive);
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
                    "{\"type\":\"LocationInfosCollection\",\"list\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11ed3e73adb98c0282f3fa9b\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"branding_domain_url\":\"subdomain.sandbox.domain.com\",\"branding_domain\":{},\"product_transactions\":[null],\"product_file\":{},\"product_accountvault\":{},\"product_recurring\":{},\"tags\":[null],\"terminals\":[null]}],\"links\":{\"type\":\"Links\",\"first\":\"/v1/endpoint?page[size]=10&page[number]=1\",\"previous\":\"/v1/endpoint?page[size]=10&page[number]=5\",\"last\":\"/v1/endpoint?page[size]=10&page[number]=42\"},\"pagination\":{\"type\":\"Pagination\",\"total_count\":423,\"page_count\":42,\"page_number\":6,\"page_size\":10},\"sort\":{\"type\":\"Sorting\",\"fields\":[{\"field\":\"last_name\",\"order\":\"asc\"}]}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// View single location record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestViewSingleLocationRecord()
        {
            // Parameters for the API call
            string locationId = "11e95f8ec39de8fbdb0a4f1a";
            List<Standard.Models.Expand10Enum> expand = null;
            List<Standard.Models.Field33Enum> fields = null;

            // Perform API call
            Standard.Models.ResponseLocation result = null;
            try
            {
                result = await this.controller.ViewSingleLocationRecordAsync(locationId, expand, fields);
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
                    "{\"type\":\"Location\",\"data\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"ticket_hash_key\":\"A5F443CADF4AE34BBCAADF4\",\"parent\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"ticket_hash_key\":\"A5F443CADF4AE34BBCAADF4\"},\"users\":[{\"account_number\":\"5454545454545454\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"terms_condition_code\":\"20220308\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_code\":1,\"api_only\":false,\"is_invitation\":false,\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\",\"current_login\":1422040992,\"log_api_response_body_ts\":1422040992}],\"is_deletable\":true,\"terminals\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"default_product_transaction_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_application_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_cvm_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terminal_manufacturer_code\":\"1\",\"title\":\"My terminal\",\"mac_address\":\"3D:F2:C9:A6:B3:4F\",\"local_ip_address\":\"192.168.0.10\",\"port\":10009,\"serial_number\":\"1234567890\",\"terminal_number\":\"973456789012367\",\"terminal_timeouts\":{\"card_entry_timeout\":47,\"device_terms_prompt_timeout\":30,\"overall_timeout\":125,\"pin_entry_timeout\":40,\"signature_input_timeout\":35,\"signature_submit_timeout\":38,\"status_display_time\":12,\"tip_cashback_timeout\":25,\"transaction_timeout\":17},\"tip_percents\":{\"percent_1\":0,\"percent_2\":2,\"percent_3\":99},\"header_line_1\":\"line 1 sample\",\"header_line_2\":\"line 2 sample\",\"header_line_3\":\"line 3 sample\",\"header_line_4\":\"line 4 sample\",\"header_line_5\":\"line 5 sample\",\"trailer_line_1\":\"trailer 1 sample\",\"trailer_line_2\":\"trailer 2 sample\",\"trailer_line_3\":\"trailer 3 sample\",\"trailer_line_4\":\"trailer 4 sample\",\"trailer_line_5\":\"trailer 5 sample\",\"default_checkin\":\"2021-12-01\",\"default_checkout\":\"2021-12-01\",\"default_room_rate\":56,\"default_room_number\":\"303\",\"debit\":false,\"emv\":false,\"cashback_enable\":false,\"print_enable\":false,\"sig_capture_enable\":false,\"is_provisioned\":false,\"tip_enable\":false,\"validated_decryption\":false,\"communication_type\":\"http\",\"active\":true,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"last_registration_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"branding_domain\":{\"url\":\"fortispayrbyn9y.sandbox.zeamster.com\",\"title\":\"Test Brand Domain Title 2\",\"logo\":\"\",\"support_email\":\"email@domain.com\",\"allow_contact_signup\":true,\"allow_contact_registration\":true,\"allow_contact_login\":true,\"registration_fields\":[\"account_number\"],\"company_name\":null,\"nav_color\":null,\"button_primary_color\":null,\"logo_background_color\":null,\"icon_background_color\":null,\"menu_text_background_color\":null,\"menu_text_color\":null,\"right_menu_background_color\":null,\"right_menu_text_color\":null,\"button_primary_text_color\":null,\"nav_logo\":null,\"fav_icon\":null,\"aes_key\":null,\"help_text\":null,\"email_reply_to\":\"email@domain.com\",\"email\":\"email@domain.com\",\"custom_javascript\":null,\"custom_theme\":null,\"custom_css\":null,\"contact_user_default_entry_page\":\"dashboard\",\"contact_user_default_auth_roles\":[null],\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992},\"product_invoice\":{\"title\":\"Sample title\",\"quote_number_start\":1,\"quote_number_increment\":1,\"quote_number_current\":1,\"invoice_number_start\":1,\"invoice_number_increment\":1,\"invoice_number_current\":1,\"tax_rate\":0,\"tax_fee\":0,\"monthly_fee\":0,\"per_invoice_fee\":0,\"per_quote_fee\":0,\"require_pay_in_full\":true,\"selectable\":1,\"reportable\":1,\"portfolio_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"},\"product_files\":[{\"title\":\"My terminal\",\"product_file_credential_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"active\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"created_user\":{\"account_number\":\"5454545454545454\",\"branding_domain_url\":\"{branding_domain_url}\",\"cell_phone\":\"3339998822\",\"company_name\":\"Fortis Payment Systems, LLC\",\"contact_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"date_of_birth\":\"2021-12-01\",\"domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"email\":\"email@domain.com\",\"email_trx_receipt\":true,\"home_phone\":\"3339998822\",\"first_name\":\"John\",\"last_name\":\"Smith\",\"locale\":\"en-US\",\"office_phone\":\"3339998822\",\"office_ext_phone\":\"5\",\"primary_location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"requires_new_password\":null,\"terms_condition_code\":\"20220308\",\"tz\":\"America/New_York\",\"ui_prefs\":{\"entry_page\":\"dashboard\",\"page_size\":2,\"report_export_type\":\"csv\",\"process_method\":\"virtual_terminal\",\"default_terminal\":\"11e95f8ec39de8fbdb0a4f1a\"},\"username\":\"{user_name}\",\"user_api_key\":\"234bas8dfn8238f923w2\",\"user_hash_key\":null,\"user_type_code\":100,\"password\":null,\"zip\":\"48375\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status_code\":1,\"api_only\":false,\"is_invitation\":false,\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"status\":true,\"login_attempts\":0,\"last_login_ts\":1422040992,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"terms_accepted_ts\":1422040992,\"terms_agree_ip\":\"192.168.0.10\",\"current_date_time\":\"2019-03-11T10:38:26-0700\",\"current_login\":1422040992,\"log_api_response_body_ts\":1422040992},\"changelogs\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"action\":\"CREATE\",\"model\":\"TransactionRequest\",\"model_id\":\"11ec829598f0d4008be9aba4\",\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_details\":[{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"changelog_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"field\":\"next_run_ts\",\"old_value\":\"1643616000\"}],\"user\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"username\":\"email@domain.com\",\"first_name\":\"Bob\",\"last_name\":\"Fairview\"}}],\"product_transactions\":[{\"processor_version\":\"1_0_0\",\"title\":\"My terminal\",\"payment_method\":\"cc\",\"processor\":\"zgate\",\"mcc\":\"1111\",\"tax_surcharge_config\":2,\"partner\":\"standalone\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"surcharge\":{},\"processor_data\":{},\"vt_clerk_number\":true,\"vt_billing_phone\":true,\"vt_enable_tip\":true,\"ach_allow_debit\":true,\"ach_allow_credit\":true,\"ach_allow_refund\":true,\"vt_cvv\":true,\"vt_street\":true,\"vt_zip\":true,\"vt_order_num\":true,\"vt_enable\":true,\"receipt_show_contact_name\":true,\"display_avs\":true,\"card_type_visa\":true,\"card_type_mc\":true,\"card_type_disc\":true,\"card_type_amex\":true,\"card_type_diners\":true,\"card_type_jcb\":true,\"invoice_location\":true,\"allow_partial_authorization\":true,\"allow_recurring_partial_authorization\":true,\"auto_decline_cvv\":true,\"auto_decline_street\":true,\"auto_decline_zip\":true,\"split_payments_allow\":true,\"vt_show_custom_fields\":true,\"receipt_show_custom_fields\":true,\"vt_override_sales_tax_allowed\":true,\"vt_enable_sales_tax\":true,\"vt_require_zip\":true,\"vt_require_street\":true,\"auto_decline_cavv\":true,\"current_batch\":34,\"dup_check_per_batch\":null,\"paylink_allow\":false,\"quick_invoice_allow\":false,\"level3_allow\":false,\"payfac_enable\":false,\"sales_office_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"hosted_payment_page_allow\":false,\"surcharge_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"level3_default\":{},\"cau_subscribe_type_id\":0,\"location_billing_account_id\":\"11eb88b873980c64a21e5fd2\",\"product_billing_group_id\":\"nofees\",\"account_number\":\"12345678\",\"run_avs_on_accountvault_create\":false,\"accountvault_expire_notification_email_enable\":false,\"debit_allow_void\":false,\"quick_invoice_text_to_pay\":false,\"sms_enable\":false,\"vt_show_currency\":true,\"receipt_show_currency\":false,\"allow_blind_refund\":false,\"vt_show_company_name\":false,\"receipt_show_company_name\":false,\"bank_funded_only\":false,\"require_cvv_on_keyed_cnp\":true,\"require_cvv_on_tokenized_cnp\":true,\"show_secondary_amount\":false,\"allow_secondary_amount\":false,\"show_google_pay\":true,\"show_apple_pay\":true,\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"active\":true,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"product_transaction_api_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"is_secondary_amount_allowed\":false,\"batch_risk_config\":{},\"fortis_id\":\"8149742\",\"product_billing_group_code\":\"nofees\",\"cau_subscribe_type_code\":0}],\"terminal_routers\":[{\"mac_address\":\"3D:F2:C9:A6:B3:4F\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"developer_company\":{\"title\":\"My terminal\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"active\":true,\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"},\"developer_company_id\":\"sample developer company id\",\"helppages\":[{\"user_type_code\":100,\"body\":\"Sample Body\",\"title\":\"Sample Title\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"quick_invoice_setting\":{\"location_api_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"quick_invoice_template\":\"<html>Template<html>\",\"default_allow_partial_pay\":true,\"default_notification_on_due_date\":true,\"default_notification_days_after_due_date\":7,\"default_notification_days_before_due_date\":3,\"id\":\"11e95f8ec39de8fbdb0a4f1a\"},\"location_billing_accounts\":[{\"title\":\"Billing Acccount Title\",\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"ach_sec_code\":null,\"account_number\":null,\"routing\":null,\"exp_date\":\"0722\",\"billing_zip\":\"48375\",\"account_type\":null,\"account_holder_name\":\"John Smith\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"modified_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"billing_descriptor\":null,\"payment_method\":null,\"portfolio_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"marketplaces\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"marketplace_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_api_id\":null,\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"locationmarketplaces\":[{\"location_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"marketplace_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_api_id\":null,\"user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\"}],\"addons\":[{\"title\":\" \",\"secret\":\" \",\"iframe_url\":\" \",\"location_setup_url\":\" \",\"user_setup_url\":\" \",\"encrypt_url_params\":true}]}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Location Detail.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestLocationDetail()
        {
            // Parameters for the API call
            string locationId = "11e95f8ec39de8fbdb0a4f1a";
            List<Standard.Models.Expand10Enum> expand = null;
            List<Standard.Models.Field34Enum> fields = null;
            object productTransactionActive = null;
            object productFileActive = null;
            object productInvoiceActive = null;
            object productRecurringActive = null;
            object productAccountvaultActive = null;

            // Perform API call
            Standard.Models.ResponseLocationInfo result = null;
            try
            {
                result = await this.controller.LocationDetailAsync(locationId, expand, fields, productTransactionActive, productFileActive, productInvoiceActive, productRecurringActive, productAccountvaultActive);
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
                    "{\"type\":\"LocationInfo\",\"data\":{\"id\":\"11e95f8ec39de8fbdb0a4f1a\",\"created_ts\":1422040992,\"modified_ts\":1422040992,\"account_number\":\"5454545454545454\",\"address\":{\"city\":\"Novi\",\"state\":\"MI\",\"postal_code\":\"48375\",\"country\":\"US\"},\"branding_domain_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"contact_email_trx_receipt_default\":true,\"default_ach\":\"11e608a7d515f1e093242bb2\",\"default_cc\":\"11e608a442a5f1e092242dda\",\"email_reply_to\":\"email@domain.com\",\"fax\":\"3339998822\",\"location_api_id\":\"location-111111\",\"location_api_key\":\"AE34BBCAADF4AE34BBCAADF4\",\"location_c1\":\"custom 1\",\"location_c2\":\"custom 2\",\"location_c3\":\"custom data 3\",\"name\":\"Sample Company Headquarters\",\"office_phone\":\"2481234567\",\"office_ext_phone\":\"1021021209\",\"tz\":\"America/New_York\",\"parent_id\":\"11ed3e73adb98c0282f3fa9b\",\"show_contact_notes\":true,\"show_contact_files\":true,\"created_user_id\":\"11e95f8ec39de8fbdb0a4f1a\",\"location_type\":\"merchant\",\"branding_domain_url\":\"subdomain.sandbox.domain.com\",\"branding_domain\":{},\"product_transactions\":[null],\"product_file\":{},\"product_accountvault\":{},\"product_recurring\":{},\"tags\":[null],\"terminals\":[null]}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}