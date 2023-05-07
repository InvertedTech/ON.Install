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

Create a new terminal device

```csharp
CreateANewTerminalDeviceAsync(
    Models.V1TerminalsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TerminalsRequest`](../../doc/models/v1-terminals-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTerminal>`](../../doc/models/response-terminal.md)

## Example Usage

```csharp
var body = new V1TerminalsRequest();
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.TerminalApplicationId = "11e95f8ec39de8fbdb0a4f1a";
body.TerminalManufacturerCode = TerminalManufacturerCodeEnum.Enum1;
body.Title = "My terminal";
body.LocalIpAddress = "192.168.0.10";
body.Port = 10009;
body.SerialNumber = "1234567890";
body.TerminalNumber = "973456789012367";
body.Debit = false;
body.Emv = false;
body.CashbackEnable = false;
body.PrintEnable = false;
body.SigCaptureEnable = false;

try
{
    ResponseTerminal result = await terminalsController.CreateANewTerminalDeviceAsync(body);
}
catch (ApiException e){};
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
    "terminal_manufacturer_code": 1,
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
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "last_registration_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# List All Terminals Related

List all terminals related

```csharp
ListAllTerminalsRelatedAsync(
    Models.Page page = null,
    Models.Sort9 sort = null,
    Models.Filter9 filter = null,
    List<string> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Models.Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `sort` | [`Models.Sort9`](../../doc/models/sort-9.md) | Query, Optional | You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods:<br><br>> /endpoint?sort={ "field_name": "asc", "field_name2": "desc" }<br>> <br>> /endpoint?sort[field_name]=asc&sort[field_name2]=desc |
| `filter` | [`Models.Filter9`](../../doc/models/filter-9.md) | Query, Optional | You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods:<br><br>> /endpoint?filter={ "field_name": "Value" }<br>> <br>> /endpoint?filter[field_name]=Value |
| `expand` | `List<string>` | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request.<br>**Constraints**: *Unique Items Required*, *Pattern*: `^[\w]+$` |

## Response Type

[`Task<Models.ResponseTerminalsCollection>`](../../doc/models/response-terminals-collection.md)

## Example Usage

```csharp
try
{
    ResponseTerminalsCollection result = await terminalsController.ListAllTerminalsRelatedAsync(null, null, null, null);
}
catch (ApiException e){};
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
      "terminal_manufacturer_code": 1,
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
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "last_registration_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    }
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# View Single Terminals Record

View single terminals record

```csharp
ViewSingleTerminalsRecordAsync(
    string terminalId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `terminalId` | `string` | Template, Required | Terminal ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseTerminal>`](../../doc/models/response-terminal.md)

## Example Usage

```csharp
string terminalId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseTerminal result = await terminalsController.ViewSingleTerminalsRecordAsync(terminalId);
}
catch (ApiException e){};
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
    "terminal_manufacturer_code": 1,
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
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "last_registration_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Update Terminal Record

Update terminal record

```csharp
UpdateTerminalRecordAsync(
    string terminalId,
    Models.V1TerminalsRequest1 body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `terminalId` | `string` | Template, Required | Terminal ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1TerminalsRequest1`](../../doc/models/v1-terminals-request-1.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTerminal>`](../../doc/models/response-terminal.md)

## Example Usage

```csharp
string terminalId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1TerminalsRequest1();

try
{
    ResponseTerminal result = await terminalsController.UpdateTerminalRecordAsync(terminalId, body);
}
catch (ApiException e){};
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
    "terminal_manufacturer_code": 1,
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
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "last_registration_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |

