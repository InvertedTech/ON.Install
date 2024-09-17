# Locations

```csharp
LocationsController locationsController = client.LocationsController;
```

## Class Name

`LocationsController`

## Methods

* [Locations Search](../../doc/controllers/locations.md#locations-search)
* [List All Locations](../../doc/controllers/locations.md#list-all-locations)
* [Locations Detail](../../doc/controllers/locations.md#locations-detail)
* [View Single Location Record](../../doc/controllers/locations.md#view-single-location-record)
* [Location Detail](../../doc/controllers/locations.md#location-detail)


# Locations Search

```csharp
LocationsSearchAsync(
    Models.Page page = null,
    string keyword = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `keyword` | `string` | Query, Optional | You can use any value to search on specific fields of this endpoint results. You can not specify the fields that are used. |

## Response Type

[`Task<Models.ResponseLocationSearchsCollection>`](../../doc/models/response-location-searchs-collection.md)

## Example Usage

```csharp
Page page = new Page
{
    Number = 1,
    Size = 50,
};

try
{
    ResponseLocationSearchsCollection result = await locationsController.LocationsSearchAsync(page);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Example Response *(as JSON)*

```json
{
  "type": "LocationSearchsCollection",
  "list": [
    {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "account_number": "5454545454545454",
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "branding_domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_email_trx_receipt_default": true,
      "default_ach": "11e608a7d515f1e093242bb2",
      "default_cc": "11e608a442a5f1e092242dda",
      "email_reply_to": "email@domain.com",
      "fax": "3339998822",
      "location_api_id": "location-111111",
      "location_api_key": "AE34BBCAADF4AE34BBCAADF4",
      "location_c1": "custom 1",
      "location_c2": "custom 2",
      "location_c3": "custom data 3",
      "name": "Sample Company Headquarters",
      "office_phone": "2481234567",
      "office_ext_phone": "1021021209",
      "tz": "America/New_York",
      "parent_id": "11ed3e73adb98c0282f3fa9b",
      "show_contact_notes": true,
      "show_contact_files": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_type": "merchant",
      "branding_domain_url": "subdomain.sandbox.domain.com",
      "branding_domain": {},
      "product_transactions": [
        null
      ],
      "product_file": {},
      "product_accountvault": {},
      "product_recurring": {},
      "tags": [
        null
      ],
      "terminals": [
        null
      ]
    }
  ],
  "links": {
    "type": "Links",
    "first": "/v1/endpoint?page[size]=10&page[number]=1",
    "previous": "/v1/endpoint?page[size]=10&page[number]=5",
    "last": "/v1/endpoint?page[size]=10&page[number]=42"
  },
  "pagination": {
    "type": "Pagination",
    "total_count": 423,
    "page_count": 42,
    "page_number": 6,
    "page_size": 10
  },
  "sort": {
    "type": "Sorting",
    "fields": [
      {
        "field": "last_name",
        "order": "asc"
      }
    ]
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# List All Locations

```csharp
ListAllLocationsAsync(
    Models.Page page = null,
    List<Models.Order19> order = null,
    List<Models.FilterBy> filterBy = null,
    List<Models.Expand10Enum> expand = null,
    Models.Format1Enum? format = null,
    string typeahead = null,
    List<Models.Field31Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `order` | [`List<Order19>`](../../doc/models/order-19.md) | Query, Optional | Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json.<br><br>> /endpoint?order=[{ "key": "created_ts", "operator": "asc"}]<br>> <br>> /endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] |
| `filterBy` | [`List<FilterBy>`](../../doc/models/filter-by.md) | Query, Optional | Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.<br><br>> /endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }]<br>> <br>> /endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }]<br>> <br>> /endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }]<br>> <br>> /endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] |
| `expand` | [`List<Expand10Enum>`](../../doc/models/expand-10-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `format` | [`Format1Enum?`](../../doc/models/format-1-enum.md) | Query, Optional | Reporting format, valid values: csv, tsv |
| `typeahead` | `string` | Query, Optional | You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains. |
| `fields` | [`List<Field31Enum>`](../../doc/models/field-31-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseLocationsCollection>`](../../doc/models/response-locations-collection.md)

## Example Usage

```csharp
Page page = new Page
{
    Number = 1,
    Size = 50,
};

List<Models.Order19> order = new List<Models.Order19>
{
    new Order19
    {
        Key = "first_name",
        MOperator = OperatorEnum.Asc,
    },
};

List<Models.FilterBy> filterBy = new List<Models.FilterBy>
{
    new FilterBy
    {
        Key = "first_name",
        MOperator = FilterByOperator.FromOperator1(Operator1Enum.Enum1),
        MValue = FilterByValue.FromFilterByValueCase1(
            FilterByValueCase1.FromString("Fred")
        ),
    },
};

try
{
    ResponseLocationsCollection result = await locationsController.ListAllLocationsAsync(
        page,
        order,
        filterBy
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Example Response *(as JSON)*

```json
{
  "type": "LocationsCollection",
  "list": [
    {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "account_number": "5454545454545454",
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "branding_domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_email_trx_receipt_default": true,
      "default_ach": "11e608a7d515f1e093242bb2",
      "default_cc": "11e608a442a5f1e092242dda",
      "email_reply_to": "email@domain.com",
      "fax": "3339998822",
      "location_api_id": "location-111111",
      "location_api_key": "AE34BBCAADF4AE34BBCAADF4",
      "location_c1": "custom 1",
      "location_c2": "custom 2",
      "location_c3": "custom data 3",
      "name": "Sample Company Headquarters",
      "office_phone": "2481234567",
      "office_ext_phone": "1021021209",
      "tz": "America/New_York",
      "parent_id": "11e95f8ec39de8fbdb0a4f1a",
      "show_contact_notes": true,
      "show_contact_files": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_type": "merchant",
      "ticket_hash_key": "A5F443CADF4AE34BBCAADF4",
      "parent": {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "account_number": "5454545454545454",
        "address": {
          "city": "Novi",
          "state": "MI",
          "postal_code": "48375",
          "country": "US"
        },
        "branding_domain_id": "11e95f8ec39de8fbdb0a4f1a",
        "contact_email_trx_receipt_default": true,
        "default_ach": "11e608a7d515f1e093242bb2",
        "default_cc": "11e608a442a5f1e092242dda",
        "email_reply_to": "email@domain.com",
        "fax": "3339998822",
        "location_api_id": "location-111111",
        "location_api_key": "AE34BBCAADF4AE34BBCAADF4",
        "location_c1": "custom 1",
        "location_c2": "custom 2",
        "location_c3": "custom data 3",
        "name": "Sample Company Headquarters",
        "office_phone": "2481234567",
        "office_ext_phone": "1021021209",
        "tz": "America/New_York",
        "parent_id": "11e95f8ec39de8fbdb0a4f1a",
        "show_contact_notes": true,
        "show_contact_files": true,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "location_type": "merchant",
        "ticket_hash_key": "A5F443CADF4AE34BBCAADF4"
      },
      "users": [
        {
          "account_number": "5454545454545454",
          "branding_domain_url": "{branding_domain_url}",
          "cell_phone": "3339998822",
          "company_name": "Fortis Payment Systems, LLC",
          "contact_id": "11e95f8ec39de8fbdb0a4f1a",
          "date_of_birth": "2021-12-01",
          "domain_id": "11e95f8ec39de8fbdb0a4f1a",
          "email": "email@domain.com",
          "email_trx_receipt": true,
          "home_phone": "3339998822",
          "first_name": "John",
          "last_name": "Smith",
          "locale": "en-US",
          "office_phone": "3339998822",
          "office_ext_phone": "5",
          "primary_location_id": "11e95f8ec39de8fbdb0a4f1a",
          "requires_new_password": null,
          "terms_condition_code": "20220308",
          "tz": "America/New_York",
          "ui_prefs": {
            "entry_page": "dashboard",
            "page_size": 2,
            "report_export_type": "csv",
            "process_method": "virtual_terminal",
            "default_terminal": "11e95f8ec39de8fbdb0a4f1a"
          },
          "username": "{user_name}",
          "user_api_key": "234bas8dfn8238f923w2",
          "user_hash_key": null,
          "user_type_code": 100,
          "password": null,
          "zip": "48375",
          "location_id": "11e95f8ec39de8fbdb0a4f1a",
          "status_code": 1,
          "api_only": false,
          "is_invitation": false,
          "address": {
            "city": "Novi",
            "state": "MI",
            "postal_code": "48375",
            "country": "US"
          },
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "status": true,
          "login_attempts": 0,
          "last_login_ts": 1422040992,
          "created_ts": 1422040992,
          "modified_ts": 1422040992,
          "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
          "terms_accepted_ts": 1422040992,
          "terms_agree_ip": "192.168.0.10",
          "current_date_time": "2019-03-11T10:38:26-0700",
          "current_login": 1422040992,
          "log_api_response_body_ts": 1422040992
        }
      ],
      "is_deletable": true,
      "terminals": [
        {
          "location_id": "11e95f8ec39de8fbdb0a4f1a",
          "default_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
          "terminal_application_id": "11e95f8ec39de8fbdb0a4f1a",
          "terminal_cvm_id": "11e95f8ec39de8fbdb0a4f1a",
          "terminal_manufacturer_code": "1",
          "title": "My terminal",
          "mac_address": "3D:F2:C9:A6:B3:4F",
          "local_ip_address": "192.168.0.10",
          "port": 10009,
          "serial_number": "1234567890",
          "terminal_number": "973456789012367",
          "terminal_timeouts": {
            "card_entry_timeout": 47,
            "device_terms_prompt_timeout": 30,
            "overall_timeout": 125,
            "pin_entry_timeout": 40,
            "signature_input_timeout": 35,
            "signature_submit_timeout": 38,
            "status_display_time": 12,
            "tip_cashback_timeout": 25,
            "transaction_timeout": 17
          },
          "tip_percents": {
            "percent_1": 0,
            "percent_2": 2,
            "percent_3": 99
          },
          "header_line_1": "line 1 sample",
          "header_line_2": "line 2 sample",
          "header_line_3": "line 3 sample",
          "header_line_4": "line 4 sample",
          "header_line_5": "line 5 sample",
          "trailer_line_1": "trailer 1 sample",
          "trailer_line_2": "trailer 2 sample",
          "trailer_line_3": "trailer 3 sample",
          "trailer_line_4": "trailer 4 sample",
          "trailer_line_5": "trailer 5 sample",
          "default_checkin": "2021-12-01",
          "default_checkout": "2021-12-01",
          "default_room_rate": 56,
          "default_room_number": "303",
          "debit": false,
          "emv": false,
          "cashback_enable": false,
          "print_enable": false,
          "sig_capture_enable": false,
          "is_provisioned": false,
          "tip_enable": false,
          "validated_decryption": false,
          "communication_type": "http",
          "active": true,
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "created_ts": 1422040992,
          "modified_ts": 1422040992,
          "last_registration_ts": 1422040992,
          "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
          "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
        }
      ],
      "branding_domain": {
        "url": "fortispayrbyn9y.sandbox.zeamster.com",
        "title": "Test Brand Domain Title 2",
        "logo": "",
        "support_email": "email@domain.com",
        "allow_contact_signup": true,
        "allow_contact_registration": true,
        "allow_contact_login": true,
        "registration_fields": [
          "account_number"
        ],
        "company_name": null,
        "nav_color": null,
        "button_primary_color": null,
        "logo_background_color": null,
        "icon_background_color": null,
        "menu_text_background_color": null,
        "menu_text_color": null,
        "right_menu_background_color": null,
        "right_menu_text_color": null,
        "button_primary_text_color": null,
        "nav_logo": null,
        "fav_icon": null,
        "aes_key": null,
        "help_text": null,
        "email_reply_to": "email@domain.com",
        "email": "email@domain.com",
        "custom_javascript": null,
        "custom_theme": null,
        "custom_css": null,
        "contact_user_default_entry_page": "dashboard",
        "contact_user_default_auth_roles": [
          null
        ],
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      },
      "product_invoice": {
        "title": "Sample title",
        "quote_number_start": 1,
        "quote_number_increment": 1,
        "quote_number_current": 1,
        "invoice_number_start": 1,
        "invoice_number_increment": 1,
        "invoice_number_current": 1,
        "tax_rate": 0,
        "tax_fee": 0,
        "monthly_fee": 0,
        "per_invoice_fee": 0,
        "per_quote_fee": 0,
        "require_pay_in_full": true,
        "selectable": 1,
        "reportable": 1,
        "portfolio_id": "11e95f8ec39de8fbdb0a4f1a",
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      },
      "product_files": [
        {
          "title": "My terminal",
          "product_file_credential_id": "11e95f8ec39de8fbdb0a4f1a",
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "created_ts": 1422040992,
          "modified_ts": 1422040992,
          "active": true,
          "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
        }
      ],
      "created_user": {
        "account_number": "5454545454545454",
        "branding_domain_url": "{branding_domain_url}",
        "cell_phone": "3339998822",
        "company_name": "Fortis Payment Systems, LLC",
        "contact_id": "11e95f8ec39de8fbdb0a4f1a",
        "date_of_birth": "2021-12-01",
        "domain_id": "11e95f8ec39de8fbdb0a4f1a",
        "email": "email@domain.com",
        "email_trx_receipt": true,
        "home_phone": "3339998822",
        "first_name": "John",
        "last_name": "Smith",
        "locale": "en-US",
        "office_phone": "3339998822",
        "office_ext_phone": "5",
        "primary_location_id": "11e95f8ec39de8fbdb0a4f1a",
        "requires_new_password": null,
        "terms_condition_code": "20220308",
        "tz": "America/New_York",
        "ui_prefs": {
          "entry_page": "dashboard",
          "page_size": 2,
          "report_export_type": "csv",
          "process_method": "virtual_terminal",
          "default_terminal": "11e95f8ec39de8fbdb0a4f1a"
        },
        "username": "{user_name}",
        "user_api_key": "234bas8dfn8238f923w2",
        "user_hash_key": null,
        "user_type_code": 100,
        "password": null,
        "zip": "48375",
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "status_code": 1,
        "api_only": false,
        "is_invitation": false,
        "address": {
          "city": "Novi",
          "state": "MI",
          "postal_code": "48375",
          "country": "US"
        },
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "status": true,
        "login_attempts": 0,
        "last_login_ts": 1422040992,
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "terms_accepted_ts": 1422040992,
        "terms_agree_ip": "192.168.0.10",
        "current_date_time": "2019-03-11T10:38:26-0700",
        "current_login": 1422040992,
        "log_api_response_body_ts": 1422040992
      },
      "changelogs": [
        {
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "created_ts": 1422040992,
          "action": "CREATE",
          "model": "TransactionRequest",
          "model_id": "11ec829598f0d4008be9aba4",
          "user_id": "11e95f8ec39de8fbdb0a4f1a",
          "changelog_details": [
            {
              "id": "11e95f8ec39de8fbdb0a4f1a",
              "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
              "field": "next_run_ts",
              "old_value": "1643616000"
            }
          ],
          "user": {
            "id": "11e95f8ec39de8fbdb0a4f1a",
            "username": "email@domain.com",
            "first_name": "Bob",
            "last_name": "Fairview"
          }
        }
      ],
      "product_transactions": [
        {
          "processor_version": "1_0_0",
          "title": "My terminal",
          "payment_method": "cc",
          "processor": "zgate",
          "mcc": "1111",
          "tax_surcharge_config": 2,
          "partner": "standalone",
          "location_id": "11e95f8ec39de8fbdb0a4f1a",
          "surcharge": {},
          "processor_data": {},
          "vt_clerk_number": true,
          "vt_billing_phone": true,
          "vt_enable_tip": true,
          "ach_allow_debit": true,
          "ach_allow_credit": true,
          "ach_allow_refund": true,
          "vt_cvv": true,
          "vt_street": true,
          "vt_zip": true,
          "vt_order_num": true,
          "vt_enable": true,
          "receipt_show_contact_name": true,
          "display_avs": true,
          "card_type_visa": true,
          "card_type_mc": true,
          "card_type_disc": true,
          "card_type_amex": true,
          "card_type_diners": true,
          "card_type_jcb": true,
          "invoice_location": true,
          "allow_partial_authorization": true,
          "allow_recurring_partial_authorization": true,
          "auto_decline_cvv": true,
          "auto_decline_street": true,
          "auto_decline_zip": true,
          "split_payments_allow": true,
          "vt_show_custom_fields": true,
          "receipt_show_custom_fields": true,
          "vt_override_sales_tax_allowed": true,
          "vt_enable_sales_tax": true,
          "vt_require_zip": true,
          "vt_require_street": true,
          "auto_decline_cavv": true,
          "current_batch": 34,
          "dup_check_per_batch": null,
          "paylink_allow": false,
          "quick_invoice_allow": false,
          "level3_allow": false,
          "payfac_enable": false,
          "sales_office_id": "11e95f8ec39de8fbdb0a4f1a",
          "hosted_payment_page_allow": false,
          "surcharge_id": "11e95f8ec39de8fbdb0a4f1a",
          "level3_default": {},
          "cau_subscribe_type_id": 0,
          "location_billing_account_id": "11eb88b873980c64a21e5fd2",
          "product_billing_group_id": "nofees",
          "account_number": "12345678",
          "run_avs_on_accountvault_create": false,
          "accountvault_expire_notification_email_enable": false,
          "debit_allow_void": false,
          "quick_invoice_text_to_pay": false,
          "sms_enable": false,
          "vt_show_currency": true,
          "receipt_show_currency": false,
          "allow_blind_refund": false,
          "vt_show_company_name": false,
          "receipt_show_company_name": false,
          "bank_funded_only": false,
          "require_cvv_on_keyed_cnp": true,
          "require_cvv_on_tokenized_cnp": true,
          "show_secondary_amount": false,
          "allow_secondary_amount": false,
          "show_google_pay": true,
          "show_apple_pay": true,
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "active": true,
          "created_ts": 1422040992,
          "modified_ts": 1422040992,
          "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
          "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
          "product_transaction_api_id": "11e95f8ec39de8fbdb0a4f1a",
          "is_secondary_amount_allowed": false,
          "batch_risk_config": {},
          "fortis_id": "8149742",
          "product_billing_group_code": "nofees",
          "cau_subscribe_type_code": 0
        }
      ],
      "terminal_routers": [
        {
          "mac_address": "3D:F2:C9:A6:B3:4F",
          "location_id": "11e95f8ec39de8fbdb0a4f1a",
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "created_ts": 1422040992,
          "modified_ts": 1422040992,
          "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
        }
      ],
      "developer_company": {
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "active": true,
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      },
      "developer_company_id": "sample developer company id",
      "helppages": [
        {
          "user_type_code": 100,
          "body": "Sample Body",
          "title": "Sample Title",
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "created_ts": 1422040992,
          "modified_ts": 1422040992,
          "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
          "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
        }
      ],
      "quick_invoice_setting": {
        "location_api_id": "11e95f8ec39de8fbdb0a4f1a",
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "quick_invoice_template": "<html>Template<html>",
        "default_allow_partial_pay": true,
        "default_notification_on_due_date": true,
        "default_notification_days_after_due_date": 7,
        "default_notification_days_before_due_date": 3,
        "id": "11e95f8ec39de8fbdb0a4f1a"
      },
      "location_billing_accounts": [
        {
          "title": "Billing Acccount Title",
          "location_id": "11e95f8ec39de8fbdb0a4f1a",
          "ach_sec_code": null,
          "account_number": null,
          "routing": null,
          "exp_date": "0722",
          "billing_zip": "48375",
          "account_type": null,
          "account_holder_name": "John Smith",
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "created_ts": 1422040992,
          "modified_ts": 1422040992,
          "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
          "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
          "billing_descriptor": null,
          "payment_method": null,
          "portfolio_id": "11e95f8ec39de8fbdb0a4f1a"
        }
      ],
      "marketplaces": [
        {
          "location_id": "11e95f8ec39de8fbdb0a4f1a",
          "marketplace_id": "11e95f8ec39de8fbdb0a4f1a",
          "location_api_id": null,
          "user_id": "11e95f8ec39de8fbdb0a4f1a",
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "created_ts": 1422040992,
          "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
        }
      ],
      "locationmarketplaces": [
        {
          "location_id": "11e95f8ec39de8fbdb0a4f1a",
          "marketplace_id": "11e95f8ec39de8fbdb0a4f1a",
          "location_api_id": null,
          "user_id": "11e95f8ec39de8fbdb0a4f1a",
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "created_ts": 1422040992,
          "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
        }
      ],
      "addons": [
        {
          "title": " ",
          "secret": " ",
          "iframe_url": " ",
          "location_setup_url": " ",
          "user_setup_url": " ",
          "encrypt_url_params": true
        }
      ]
    }
  ],
  "links": {
    "type": "Links",
    "first": "/v1/endpoint?page[size]=10&page[number]=1",
    "previous": "/v1/endpoint?page[size]=10&page[number]=5",
    "last": "/v1/endpoint?page[size]=10&page[number]=42"
  },
  "pagination": {
    "type": "Pagination",
    "total_count": 423,
    "page_count": 42,
    "page_number": 6,
    "page_size": 10
  },
  "sort": {
    "type": "Sorting",
    "fields": [
      {
        "field": "last_name",
        "order": "asc"
      }
    ]
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Locations Detail

```csharp
LocationsDetailAsync(
    Models.Page page = null,
    List<Models.Order19> order = null,
    List<Models.FilterBy> filterBy = null,
    List<Models.Expand10Enum> expand = null,
    Models.Format1Enum? format = null,
    string typeahead = null,
    List<Models.Field32Enum> fields = null,
    object productTransactionActive = null,
    object productFileActive = null,
    object productInvoiceActive = null,
    object productRecurringActive = null,
    object productAccountvaultActive = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `order` | [`List<Order19>`](../../doc/models/order-19.md) | Query, Optional | Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json.<br><br>> /endpoint?order=[{ "key": "created_ts", "operator": "asc"}]<br>> <br>> /endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] |
| `filterBy` | [`List<FilterBy>`](../../doc/models/filter-by.md) | Query, Optional | Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.<br><br>> /endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }]<br>> <br>> /endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }]<br>> <br>> /endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }]<br>> <br>> /endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] |
| `expand` | [`List<Expand10Enum>`](../../doc/models/expand-10-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `format` | [`Format1Enum?`](../../doc/models/format-1-enum.md) | Query, Optional | Reporting format, valid values: csv, tsv |
| `typeahead` | `string` | Query, Optional | You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains. |
| `fields` | [`List<Field32Enum>`](../../doc/models/field-32-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |
| `productTransactionActive` | `object` | Query, Optional | Product Transaction Active |
| `productFileActive` | `object` | Query, Optional | Product File Active |
| `productInvoiceActive` | `object` | Query, Optional | Product Invoice Active |
| `productRecurringActive` | `object` | Query, Optional | Product Recurring Active |
| `productAccountvaultActive` | `object` | Query, Optional | Product Accountvault Active |

## Response Type

[`Task<Models.ResponseLocationInfosCollection>`](../../doc/models/response-location-infos-collection.md)

## Example Usage

```csharp
Page page = new Page
{
    Number = 1,
    Size = 50,
};

List<Models.Order19> order = new List<Models.Order19>
{
    new Order19
    {
        Key = "first_name",
        MOperator = OperatorEnum.Asc,
    },
};

List<Models.FilterBy> filterBy = new List<Models.FilterBy>
{
    new FilterBy
    {
        Key = "first_name",
        MOperator = FilterByOperator.FromOperator1(Operator1Enum.Enum1),
        MValue = FilterByValue.FromFilterByValueCase1(
            FilterByValueCase1.FromString("Fred")
        ),
    },
};

try
{
    ResponseLocationInfosCollection result = await locationsController.LocationsDetailAsync(
        page,
        order,
        filterBy
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Example Response *(as JSON)*

```json
{
  "type": "LocationInfosCollection",
  "list": [
    {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "account_number": "5454545454545454",
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "branding_domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_email_trx_receipt_default": true,
      "default_ach": "11e608a7d515f1e093242bb2",
      "default_cc": "11e608a442a5f1e092242dda",
      "email_reply_to": "email@domain.com",
      "fax": "3339998822",
      "location_api_id": "location-111111",
      "location_api_key": "AE34BBCAADF4AE34BBCAADF4",
      "location_c1": "custom 1",
      "location_c2": "custom 2",
      "location_c3": "custom data 3",
      "name": "Sample Company Headquarters",
      "office_phone": "2481234567",
      "office_ext_phone": "1021021209",
      "tz": "America/New_York",
      "parent_id": "11ed3e73adb98c0282f3fa9b",
      "show_contact_notes": true,
      "show_contact_files": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_type": "merchant",
      "branding_domain_url": "subdomain.sandbox.domain.com",
      "branding_domain": {},
      "product_transactions": [
        null
      ],
      "product_file": {},
      "product_accountvault": {},
      "product_recurring": {},
      "tags": [
        null
      ],
      "terminals": [
        null
      ]
    }
  ],
  "links": {
    "type": "Links",
    "first": "/v1/endpoint?page[size]=10&page[number]=1",
    "previous": "/v1/endpoint?page[size]=10&page[number]=5",
    "last": "/v1/endpoint?page[size]=10&page[number]=42"
  },
  "pagination": {
    "type": "Pagination",
    "total_count": 423,
    "page_count": 42,
    "page_number": 6,
    "page_size": 10
  },
  "sort": {
    "type": "Sorting",
    "fields": [
      {
        "field": "last_name",
        "order": "asc"
      }
    ]
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# View Single Location Record

```csharp
ViewSingleLocationRecordAsync(
    string locationId,
    List<Models.Expand10Enum> expand = null,
    List<Models.Field33Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | Location ID |
| `expand` | [`List<Expand10Enum>`](../../doc/models/expand-10-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `fields` | [`List<Field33Enum>`](../../doc/models/field-33-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseLocation>`](../../doc/models/response-location.md)

## Example Usage

```csharp
string locationId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseLocation result = await locationsController.ViewSingleLocationRecordAsync(locationId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Example Response *(as JSON)*

```json
{
  "type": "Location",
  "data": {
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "account_number": "5454545454545454",
    "address": {
      "city": "Novi",
      "state": "MI",
      "postal_code": "48375",
      "country": "US"
    },
    "branding_domain_id": "11e95f8ec39de8fbdb0a4f1a",
    "contact_email_trx_receipt_default": true,
    "default_ach": "11e608a7d515f1e093242bb2",
    "default_cc": "11e608a442a5f1e092242dda",
    "email_reply_to": "email@domain.com",
    "fax": "3339998822",
    "location_api_id": "location-111111",
    "location_api_key": "AE34BBCAADF4AE34BBCAADF4",
    "location_c1": "custom 1",
    "location_c2": "custom 2",
    "location_c3": "custom data 3",
    "name": "Sample Company Headquarters",
    "office_phone": "2481234567",
    "office_ext_phone": "1021021209",
    "tz": "America/New_York",
    "parent_id": "11e95f8ec39de8fbdb0a4f1a",
    "show_contact_notes": true,
    "show_contact_files": true,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "location_type": "merchant",
    "ticket_hash_key": "A5F443CADF4AE34BBCAADF4",
    "parent": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "account_number": "5454545454545454",
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "branding_domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_email_trx_receipt_default": true,
      "default_ach": "11e608a7d515f1e093242bb2",
      "default_cc": "11e608a442a5f1e092242dda",
      "email_reply_to": "email@domain.com",
      "fax": "3339998822",
      "location_api_id": "location-111111",
      "location_api_key": "AE34BBCAADF4AE34BBCAADF4",
      "location_c1": "custom 1",
      "location_c2": "custom 2",
      "location_c3": "custom data 3",
      "name": "Sample Company Headquarters",
      "office_phone": "2481234567",
      "office_ext_phone": "1021021209",
      "tz": "America/New_York",
      "parent_id": "11e95f8ec39de8fbdb0a4f1a",
      "show_contact_notes": true,
      "show_contact_files": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_type": "merchant",
      "ticket_hash_key": "A5F443CADF4AE34BBCAADF4"
    },
    "users": [
      {
        "account_number": "5454545454545454",
        "branding_domain_url": "{branding_domain_url}",
        "cell_phone": "3339998822",
        "company_name": "Fortis Payment Systems, LLC",
        "contact_id": "11e95f8ec39de8fbdb0a4f1a",
        "date_of_birth": "2021-12-01",
        "domain_id": "11e95f8ec39de8fbdb0a4f1a",
        "email": "email@domain.com",
        "email_trx_receipt": true,
        "home_phone": "3339998822",
        "first_name": "John",
        "last_name": "Smith",
        "locale": "en-US",
        "office_phone": "3339998822",
        "office_ext_phone": "5",
        "primary_location_id": "11e95f8ec39de8fbdb0a4f1a",
        "requires_new_password": null,
        "terms_condition_code": "20220308",
        "tz": "America/New_York",
        "ui_prefs": {
          "entry_page": "dashboard",
          "page_size": 2,
          "report_export_type": "csv",
          "process_method": "virtual_terminal",
          "default_terminal": "11e95f8ec39de8fbdb0a4f1a"
        },
        "username": "{user_name}",
        "user_api_key": "234bas8dfn8238f923w2",
        "user_hash_key": null,
        "user_type_code": 100,
        "password": null,
        "zip": "48375",
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "status_code": 1,
        "api_only": false,
        "is_invitation": false,
        "address": {
          "city": "Novi",
          "state": "MI",
          "postal_code": "48375",
          "country": "US"
        },
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "status": true,
        "login_attempts": 0,
        "last_login_ts": 1422040992,
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "terms_accepted_ts": 1422040992,
        "terms_agree_ip": "192.168.0.10",
        "current_date_time": "2019-03-11T10:38:26-0700",
        "current_login": 1422040992,
        "log_api_response_body_ts": 1422040992
      }
    ],
    "is_deletable": true,
    "terminals": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "default_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "terminal_application_id": "11e95f8ec39de8fbdb0a4f1a",
        "terminal_cvm_id": "11e95f8ec39de8fbdb0a4f1a",
        "terminal_manufacturer_code": "1",
        "title": "My terminal",
        "mac_address": "3D:F2:C9:A6:B3:4F",
        "local_ip_address": "192.168.0.10",
        "port": 10009,
        "serial_number": "1234567890",
        "terminal_number": "973456789012367",
        "terminal_timeouts": {
          "card_entry_timeout": 47,
          "device_terms_prompt_timeout": 30,
          "overall_timeout": 125,
          "pin_entry_timeout": 40,
          "signature_input_timeout": 35,
          "signature_submit_timeout": 38,
          "status_display_time": 12,
          "tip_cashback_timeout": 25,
          "transaction_timeout": 17
        },
        "tip_percents": {
          "percent_1": 0,
          "percent_2": 2,
          "percent_3": 99
        },
        "header_line_1": "line 1 sample",
        "header_line_2": "line 2 sample",
        "header_line_3": "line 3 sample",
        "header_line_4": "line 4 sample",
        "header_line_5": "line 5 sample",
        "trailer_line_1": "trailer 1 sample",
        "trailer_line_2": "trailer 2 sample",
        "trailer_line_3": "trailer 3 sample",
        "trailer_line_4": "trailer 4 sample",
        "trailer_line_5": "trailer 5 sample",
        "default_checkin": "2021-12-01",
        "default_checkout": "2021-12-01",
        "default_room_rate": 56,
        "default_room_number": "303",
        "debit": false,
        "emv": false,
        "cashback_enable": false,
        "print_enable": false,
        "sig_capture_enable": false,
        "is_provisioned": false,
        "tip_enable": false,
        "validated_decryption": false,
        "communication_type": "http",
        "active": true,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "last_registration_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "branding_domain": {
      "url": "fortispayrbyn9y.sandbox.zeamster.com",
      "title": "Test Brand Domain Title 2",
      "logo": "",
      "support_email": "email@domain.com",
      "allow_contact_signup": true,
      "allow_contact_registration": true,
      "allow_contact_login": true,
      "registration_fields": [
        "account_number"
      ],
      "company_name": null,
      "nav_color": null,
      "button_primary_color": null,
      "logo_background_color": null,
      "icon_background_color": null,
      "menu_text_background_color": null,
      "menu_text_color": null,
      "right_menu_background_color": null,
      "right_menu_text_color": null,
      "button_primary_text_color": null,
      "nav_logo": null,
      "fav_icon": null,
      "aes_key": null,
      "help_text": null,
      "email_reply_to": "email@domain.com",
      "email": "email@domain.com",
      "custom_javascript": null,
      "custom_theme": null,
      "custom_css": null,
      "contact_user_default_entry_page": "dashboard",
      "contact_user_default_auth_roles": [
        null
      ],
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "product_invoice": {
      "title": "Sample title",
      "quote_number_start": 1,
      "quote_number_increment": 1,
      "quote_number_current": 1,
      "invoice_number_start": 1,
      "invoice_number_increment": 1,
      "invoice_number_current": 1,
      "tax_rate": 0,
      "tax_fee": 0,
      "monthly_fee": 0,
      "per_invoice_fee": 0,
      "per_quote_fee": 0,
      "require_pay_in_full": true,
      "selectable": 1,
      "reportable": 1,
      "portfolio_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "product_files": [
      {
        "title": "My terminal",
        "product_file_credential_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "active": true,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "created_user": {
      "account_number": "5454545454545454",
      "branding_domain_url": "{branding_domain_url}",
      "cell_phone": "3339998822",
      "company_name": "Fortis Payment Systems, LLC",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "date_of_birth": "2021-12-01",
      "domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "email": "email@domain.com",
      "email_trx_receipt": true,
      "home_phone": "3339998822",
      "first_name": "John",
      "last_name": "Smith",
      "locale": "en-US",
      "office_phone": "3339998822",
      "office_ext_phone": "5",
      "primary_location_id": "11e95f8ec39de8fbdb0a4f1a",
      "requires_new_password": null,
      "terms_condition_code": "20220308",
      "tz": "America/New_York",
      "ui_prefs": {
        "entry_page": "dashboard",
        "page_size": 2,
        "report_export_type": "csv",
        "process_method": "virtual_terminal",
        "default_terminal": "11e95f8ec39de8fbdb0a4f1a"
      },
      "username": "{user_name}",
      "user_api_key": "234bas8dfn8238f923w2",
      "user_hash_key": null,
      "user_type_code": 100,
      "password": null,
      "zip": "48375",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "status_code": 1,
      "api_only": false,
      "is_invitation": false,
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "status": true,
      "login_attempts": 0,
      "last_login_ts": 1422040992,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "terms_accepted_ts": 1422040992,
      "terms_agree_ip": "192.168.0.10",
      "current_date_time": "2019-03-11T10:38:26-0700",
      "current_login": 1422040992,
      "log_api_response_body_ts": 1422040992
    },
    "changelogs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "action": "CREATE",
        "model": "TransactionRequest",
        "model_id": "11ec829598f0d4008be9aba4",
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_details": [
          {
            "id": "11e95f8ec39de8fbdb0a4f1a",
            "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
            "field": "next_run_ts",
            "old_value": "1643616000"
          }
        ],
        "user": {
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "username": "email@domain.com",
          "first_name": "Bob",
          "last_name": "Fairview"
        }
      }
    ],
    "product_transactions": [
      {
        "processor_version": "1_0_0",
        "title": "My terminal",
        "payment_method": "cc",
        "processor": "zgate",
        "mcc": "1111",
        "tax_surcharge_config": 2,
        "partner": "standalone",
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "surcharge": {},
        "processor_data": {},
        "vt_clerk_number": true,
        "vt_billing_phone": true,
        "vt_enable_tip": true,
        "ach_allow_debit": true,
        "ach_allow_credit": true,
        "ach_allow_refund": true,
        "vt_cvv": true,
        "vt_street": true,
        "vt_zip": true,
        "vt_order_num": true,
        "vt_enable": true,
        "receipt_show_contact_name": true,
        "display_avs": true,
        "card_type_visa": true,
        "card_type_mc": true,
        "card_type_disc": true,
        "card_type_amex": true,
        "card_type_diners": true,
        "card_type_jcb": true,
        "invoice_location": true,
        "allow_partial_authorization": true,
        "allow_recurring_partial_authorization": true,
        "auto_decline_cvv": true,
        "auto_decline_street": true,
        "auto_decline_zip": true,
        "split_payments_allow": true,
        "vt_show_custom_fields": true,
        "receipt_show_custom_fields": true,
        "vt_override_sales_tax_allowed": true,
        "vt_enable_sales_tax": true,
        "vt_require_zip": true,
        "vt_require_street": true,
        "auto_decline_cavv": true,
        "current_batch": 34,
        "dup_check_per_batch": null,
        "paylink_allow": false,
        "quick_invoice_allow": false,
        "level3_allow": false,
        "payfac_enable": false,
        "sales_office_id": "11e95f8ec39de8fbdb0a4f1a",
        "hosted_payment_page_allow": false,
        "surcharge_id": "11e95f8ec39de8fbdb0a4f1a",
        "level3_default": {},
        "cau_subscribe_type_id": 0,
        "location_billing_account_id": "11eb88b873980c64a21e5fd2",
        "product_billing_group_id": "nofees",
        "account_number": "12345678",
        "run_avs_on_accountvault_create": false,
        "accountvault_expire_notification_email_enable": false,
        "debit_allow_void": false,
        "quick_invoice_text_to_pay": false,
        "sms_enable": false,
        "vt_show_currency": true,
        "receipt_show_currency": false,
        "allow_blind_refund": false,
        "vt_show_company_name": false,
        "receipt_show_company_name": false,
        "bank_funded_only": false,
        "require_cvv_on_keyed_cnp": true,
        "require_cvv_on_tokenized_cnp": true,
        "show_secondary_amount": false,
        "allow_secondary_amount": false,
        "show_google_pay": true,
        "show_apple_pay": true,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "active": true,
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "product_transaction_api_id": "11e95f8ec39de8fbdb0a4f1a",
        "is_secondary_amount_allowed": false,
        "batch_risk_config": {},
        "fortis_id": "8149742",
        "product_billing_group_code": "nofees",
        "cau_subscribe_type_code": 0
      }
    ],
    "terminal_routers": [
      {
        "mac_address": "3D:F2:C9:A6:B3:4F",
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "developer_company": {
      "title": "My terminal",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "developer_company_id": "sample developer company id",
    "helppages": [
      {
        "user_type_code": 100,
        "body": "Sample Body",
        "title": "Sample Title",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "quick_invoice_setting": {
      "location_api_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "quick_invoice_template": "<html>Template<html>",
      "default_allow_partial_pay": true,
      "default_notification_on_due_date": true,
      "default_notification_days_after_due_date": 7,
      "default_notification_days_before_due_date": 3,
      "id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "location_billing_accounts": [
      {
        "title": "Billing Acccount Title",
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "ach_sec_code": null,
        "account_number": null,
        "routing": null,
        "exp_date": "0722",
        "billing_zip": "48375",
        "account_type": null,
        "account_holder_name": "John Smith",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "billing_descriptor": null,
        "payment_method": null,
        "portfolio_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "marketplaces": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "marketplace_id": "11e95f8ec39de8fbdb0a4f1a",
        "location_api_id": null,
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "locationmarketplaces": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "marketplace_id": "11e95f8ec39de8fbdb0a4f1a",
        "location_api_id": null,
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "addons": [
      {
        "title": " ",
        "secret": " ",
        "iframe_url": " ",
        "location_setup_url": " ",
        "user_setup_url": " ",
        "encrypt_url_params": true
      }
    ]
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Location Detail

```csharp
LocationDetailAsync(
    string locationId,
    List<Models.Expand10Enum> expand = null,
    List<Models.Field34Enum> fields = null,
    object productTransactionActive = null,
    object productFileActive = null,
    object productInvoiceActive = null,
    object productRecurringActive = null,
    object productAccountvaultActive = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | Location ID |
| `expand` | [`List<Expand10Enum>`](../../doc/models/expand-10-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `fields` | [`List<Field34Enum>`](../../doc/models/field-34-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |
| `productTransactionActive` | `object` | Query, Optional | Product Transaction Active |
| `productFileActive` | `object` | Query, Optional | Product File Active |
| `productInvoiceActive` | `object` | Query, Optional | Product Invoice Active |
| `productRecurringActive` | `object` | Query, Optional | Product Recurring Active |
| `productAccountvaultActive` | `object` | Query, Optional | Product Accountvault Active |

## Response Type

[`Task<Models.ResponseLocationInfo>`](../../doc/models/response-location-info.md)

## Example Usage

```csharp
string locationId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseLocationInfo result = await locationsController.LocationDetailAsync(locationId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Example Response *(as JSON)*

```json
{
  "type": "LocationInfo",
  "data": {
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "account_number": "5454545454545454",
    "address": {
      "city": "Novi",
      "state": "MI",
      "postal_code": "48375",
      "country": "US"
    },
    "branding_domain_id": "11e95f8ec39de8fbdb0a4f1a",
    "contact_email_trx_receipt_default": true,
    "default_ach": "11e608a7d515f1e093242bb2",
    "default_cc": "11e608a442a5f1e092242dda",
    "email_reply_to": "email@domain.com",
    "fax": "3339998822",
    "location_api_id": "location-111111",
    "location_api_key": "AE34BBCAADF4AE34BBCAADF4",
    "location_c1": "custom 1",
    "location_c2": "custom 2",
    "location_c3": "custom data 3",
    "name": "Sample Company Headquarters",
    "office_phone": "2481234567",
    "office_ext_phone": "1021021209",
    "tz": "America/New_York",
    "parent_id": "11ed3e73adb98c0282f3fa9b",
    "show_contact_notes": true,
    "show_contact_files": true,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "location_type": "merchant",
    "branding_domain_url": "subdomain.sandbox.domain.com",
    "branding_domain": {},
    "product_transactions": [
      null
    ],
    "product_file": {},
    "product_accountvault": {},
    "product_recurring": {},
    "tags": [
      null
    ],
    "terminals": [
      null
    ]
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |

