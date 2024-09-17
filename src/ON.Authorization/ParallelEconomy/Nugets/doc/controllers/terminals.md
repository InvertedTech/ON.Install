# Terminals

```csharp
TerminalsController terminalsController = client.TerminalsController;
```

## Class Name

`TerminalsController`

## Methods

* [Create a New Terminal Device](../../doc/controllers/terminals.md#create-a-new-terminal-device)
* [List All Terminals Related](../../doc/controllers/terminals.md#list-all-terminals-related)
* [View Single Terminals Record](../../doc/controllers/terminals.md#view-single-terminals-record)
* [Update Terminal Record](../../doc/controllers/terminals.md#update-terminal-record)


# Create a New Terminal Device

```csharp
CreateANewTerminalDeviceAsync(
    Models.V1TerminalsRequest body,
    List<Models.Expand37Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1TerminalsRequest`](../../doc/models/v1-terminals-request.md) | Body, Required | - |
| `expand` | [`List<Expand37Enum>`](../../doc/models/expand-37-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseTerminal>`](../../doc/models/response-terminal.md)

## Example Usage

```csharp
V1TerminalsRequest body = new V1TerminalsRequest
{
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    TerminalApplicationId = "11e95f8ec39de8fbdb0a4f1a",
    TerminalManufacturerCode = TerminalManufacturerCodeEnum.Enum1,
    Title = "My terminal",
    SerialNumber = "1234567890",
    Debit = false,
    Emv = false,
    CashbackEnable = false,
    PrintEnable = false,
    SigCaptureEnable = false,
    DefaultProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    TerminalCvmId = "11e95f8ec39de8fbdb0a4f1a",
    MacAddress = "3D:F2:C9:A6:B3:4F",
    LocalIpAddress = "192.168.0.10",
    Port = 10009,
    TerminalNumber = "973456789012367",
    HeaderLine1 = "line 1 sample",
    HeaderLine2 = "line 2 sample",
    HeaderLine3 = "line 3 sample",
    HeaderLine4 = "line 4 sample",
    HeaderLine5 = "line 5 sample",
    TrailerLine1 = "trailer 1 sample",
    TrailerLine2 = "trailer 2 sample",
    TrailerLine3 = "trailer 3 sample",
    TrailerLine4 = "trailer 4 sample",
    TrailerLine5 = "trailer 5 sample",
    DefaultCheckin = "2021-12-01",
    DefaultCheckout = "2021-12-01",
    DefaultRoomRate = 56,
    DefaultRoomNumber = "303",
    IsProvisioned = false,
    TipEnable = false,
    ValidatedDecryption = false,
    CommunicationType = CommunicationTypeEnum.Http,
    Active = true,
};

try
{
    ResponseTerminal result = await terminalsController.CreateANewTerminalDeviceAsync(body);
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
  "type": "Terminal",
  "data": {
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
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "location": {
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
    "terminal_application": {
      "standalone": true,
      "emv_capable": true,
      "nfc_capable": false,
      "pin_capable": true,
      "print_capable": false,
      "msr_capable": true,
      "sig_capture_capable": false,
      "mpos_terminal": false,
      "title": "Ingenico Link2500",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
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
    "has_terminal_routers": true,
    "terminal_cvm": {
      "terminal_manufacturer_code": 4,
      "title": "CVM One",
      "contact_data": null,
      "contactless_data": null,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "terminal_manufacturer": {
      "title": "My terminal",
      "idtype": "mac",
      "code": "4",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# List All Terminals Related

```csharp
ListAllTerminalsRelatedAsync(
    Models.Page page = null,
    List<Models.Order19> order = null,
    List<Models.FilterBy> filterBy = null,
    List<Models.Expand37Enum> expand = null,
    Models.Format1Enum? format = null,
    string typeahead = null,
    List<Models.Field45Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `order` | [`List<Order19>`](../../doc/models/order-19.md) | Query, Optional | Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json.<br><br>> /endpoint?order=[{ "key": "created_ts", "operator": "asc"}]<br>> <br>> /endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] |
| `filterBy` | [`List<FilterBy>`](../../doc/models/filter-by.md) | Query, Optional | Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.<br><br>> /endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }]<br>> <br>> /endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }]<br>> <br>> /endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }]<br>> <br>> /endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] |
| `expand` | [`List<Expand37Enum>`](../../doc/models/expand-37-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `format` | [`Format1Enum?`](../../doc/models/format-1-enum.md) | Query, Optional | Reporting format, valid values: csv, tsv |
| `typeahead` | `string` | Query, Optional | You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains. |
| `fields` | [`List<Field45Enum>`](../../doc/models/field-45-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseTerminalsCollection>`](../../doc/models/response-terminals-collection.md)

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
    ResponseTerminalsCollection result = await terminalsController.ListAllTerminalsRelatedAsync(
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
  "type": "TerminalsCollection",
  "list": [
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
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location": {
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
      "terminal_application": {
        "standalone": true,
        "emv_capable": true,
        "nfc_capable": false,
        "pin_capable": true,
        "print_capable": false,
        "msr_capable": true,
        "sig_capture_capable": false,
        "mpos_terminal": false,
        "title": "Ingenico Link2500",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
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
      "has_terminal_routers": true,
      "terminal_cvm": {
        "terminal_manufacturer_code": 4,
        "title": "CVM One",
        "contact_data": null,
        "contactless_data": null,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      },
      "terminal_manufacturer": {
        "title": "My terminal",
        "idtype": "mac",
        "code": "4",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
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


# View Single Terminals Record

```csharp
ViewSingleTerminalsRecordAsync(
    string terminalId,
    List<Models.Expand37Enum> expand = null,
    List<Models.Field45Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `terminalId` | `string` | Template, Required | Terminal ID |
| `expand` | [`List<Expand37Enum>`](../../doc/models/expand-37-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `fields` | [`List<Field45Enum>`](../../doc/models/field-45-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseTerminal>`](../../doc/models/response-terminal.md)

## Example Usage

```csharp
string terminalId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseTerminal result = await terminalsController.ViewSingleTerminalsRecordAsync(terminalId);
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
  "type": "Terminal",
  "data": {
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
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "location": {
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
    "terminal_application": {
      "standalone": true,
      "emv_capable": true,
      "nfc_capable": false,
      "pin_capable": true,
      "print_capable": false,
      "msr_capable": true,
      "sig_capture_capable": false,
      "mpos_terminal": false,
      "title": "Ingenico Link2500",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
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
    "has_terminal_routers": true,
    "terminal_cvm": {
      "terminal_manufacturer_code": 4,
      "title": "CVM One",
      "contact_data": null,
      "contactless_data": null,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "terminal_manufacturer": {
      "title": "My terminal",
      "idtype": "mac",
      "code": "4",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Update Terminal Record

```csharp
UpdateTerminalRecordAsync(
    string terminalId,
    Models.V1TerminalsRequest1 body,
    List<Models.Expand37Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `terminalId` | `string` | Template, Required | Terminal ID |
| `body` | [`V1TerminalsRequest1`](../../doc/models/v1-terminals-request-1.md) | Body, Required | - |
| `expand` | [`List<Expand37Enum>`](../../doc/models/expand-37-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseTerminal>`](../../doc/models/response-terminal.md)

## Example Usage

```csharp
string terminalId = "11e95f8ec39de8fbdb0a4f1a";
V1TerminalsRequest1 body = new V1TerminalsRequest1
{
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    DefaultProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    TerminalApplicationId = "11e95f8ec39de8fbdb0a4f1a",
    TerminalCvmId = "11e95f8ec39de8fbdb0a4f1a",
    TerminalManufacturerCode = TerminalManufacturerCodeEnum.Enum1,
    Title = "My terminal",
    MacAddress = "3D:F2:C9:A6:B3:4F",
    LocalIpAddress = "192.168.0.10",
    Port = 10009,
    SerialNumber = "1234567890",
    TerminalNumber = "973456789012367",
    HeaderLine1 = "line 1 sample",
    HeaderLine2 = "line 2 sample",
    HeaderLine3 = "line 3 sample",
    HeaderLine4 = "line 4 sample",
    HeaderLine5 = "line 5 sample",
    TrailerLine1 = "trailer 1 sample",
    TrailerLine2 = "trailer 2 sample",
    TrailerLine3 = "trailer 3 sample",
    TrailerLine4 = "trailer 4 sample",
    TrailerLine5 = "trailer 5 sample",
    DefaultCheckin = "2021-12-01",
    DefaultCheckout = "2021-12-01",
    DefaultRoomRate = 56,
    DefaultRoomNumber = "303",
    Debit = false,
    Emv = false,
    CashbackEnable = false,
    PrintEnable = false,
    SigCaptureEnable = false,
    IsProvisioned = false,
    TipEnable = false,
    ValidatedDecryption = false,
    CommunicationType = CommunicationTypeEnum.Http,
    Active = true,
};

try
{
    ResponseTerminal result = await terminalsController.UpdateTerminalRecordAsync(
        terminalId,
        body
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
  "type": "Terminal",
  "data": {
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
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "location": {
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
    "terminal_application": {
      "standalone": true,
      "emv_capable": true,
      "nfc_capable": false,
      "pin_capable": true,
      "print_capable": false,
      "msr_capable": true,
      "sig_capture_capable": false,
      "mpos_terminal": false,
      "title": "Ingenico Link2500",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
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
    "has_terminal_routers": true,
    "terminal_cvm": {
      "terminal_manufacturer_code": 4,
      "title": "CVM One",
      "contact_data": null,
      "contactless_data": null,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "terminal_manufacturer": {
      "title": "My terminal",
      "idtype": "mac",
      "code": "4",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |

