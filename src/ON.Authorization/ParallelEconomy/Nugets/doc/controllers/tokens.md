# Tokens

The tokens endpoint is used as a tokenization endpoint to store account vault records. If there is a need to store accountvaults (tokens) for account numbers and card numbers for later use, then this is the endpoint to perform that task.

The account_vault_id field can be used in place of the account_number and exp_date fields on most endpoints in the system. So storing an accountvault on this endpoint will allow for the reuse of the account at a later time.

```csharp
TokensController tokensController = client.TokensController;
```

## Class Name

`TokensController`

## Methods

* [Create a New ACH Token](../../doc/controllers/tokens.md#create-a-new-ach-token)
* [Create a New Credit Card Token](../../doc/controllers/tokens.md#create-a-new-credit-card-token)
* [Create a New Previous Transaction Token](../../doc/controllers/tokens.md#create-a-new-previous-transaction-token)
* [Create a New Terminal Token](../../doc/controllers/tokens.md#create-a-new-terminal-token)
* [Create a New Ticket Token](../../doc/controllers/tokens.md#create-a-new-ticket-token)
* [Delete a Single Token Record](../../doc/controllers/tokens.md#delete-a-single-token-record)
* [View Single Token Record](../../doc/controllers/tokens.md#view-single-token-record)
* [List All Tokens Related](../../doc/controllers/tokens.md#list-all-tokens-related)
* [Update ACH Token](../../doc/controllers/tokens.md#update-ach-token)
* [Update CC Token](../../doc/controllers/tokens.md#update-cc-token)


# Create a New ACH Token

Create a new ACH Token

```csharp
CreateANewACHTokenAsync(
    Models.V1TokensAchRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TokensAchRequest`](../../doc/models/v1-tokens-ach-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
var body = new V1TokensAchRequest();
body.AccountHolderName = "John Smith";
body.AccountNumber = "545454545454545";
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.AccountType = AccountType2Enum.Savings;
body.IsCompany = false;
body.RoutingNumber = "100020200";

try
{
    ResponseToken result = await tokensController.CreateANewACHTokenAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Token",
  "data": {
    "account_holder_name": "John Smith",
    "account_number": "545454545454545",
    "account_vault_api_id": "accountvaultabcd",
    "accountvault_c1": "accountvault custom 1",
    "accountvault_c2": "accountvault custom 2",
    "accountvault_c3": "accountvault custom 3",
    "ach_sec_code": "WEB",
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "customer_id": "123456",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "ssn4": "8527",
      "dob_year": "1980"
    },
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_account_vault_api_id": "previousaccountvault123456",
    "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "terms_agree": true,
    "terms_agree_ip": "192.168.0.10",
    "title": "Test CC Account",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "account_type": "checking",
    "active": true,
    "cau_summary_status_id": 1,
    "created_ts": 1422040992,
    "e_serial_number": "1234567890",
    "e_track_data": null,
    "e_format": null,
    "e_keyed_data": null,
    "expiring_in_months": null,
    "first_six": "700953",
    "has_recurring": false,
    "last_four": "3657",
    "modified_ts": 1422040992,
    "payment_method": "cc",
    "ticket": null,
    "track_data": null
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Create a New Credit Card Token

Create a new Credit Card Token

```csharp
CreateANewCreditCardTokenAsync(
    Models.V1TokensCcRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TokensCcRequest`](../../doc/models/v1-tokens-cc-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
var body = new V1TokensCcRequest();
body.AccountNumber = "5454545454545454";
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.ExpDate = "0929";

try
{
    ResponseToken result = await tokensController.CreateANewCreditCardTokenAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Token",
  "data": {
    "account_holder_name": "John Smith",
    "account_number": "545454545454545",
    "account_vault_api_id": "accountvaultabcd",
    "accountvault_c1": "accountvault custom 1",
    "accountvault_c2": "accountvault custom 2",
    "accountvault_c3": "accountvault custom 3",
    "ach_sec_code": "WEB",
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "customer_id": "123456",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "ssn4": "8527",
      "dob_year": "1980"
    },
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_account_vault_api_id": "previousaccountvault123456",
    "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "terms_agree": true,
    "terms_agree_ip": "192.168.0.10",
    "title": "Test CC Account",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "account_type": "checking",
    "active": true,
    "cau_summary_status_id": 1,
    "created_ts": 1422040992,
    "e_serial_number": "1234567890",
    "e_track_data": null,
    "e_format": null,
    "e_keyed_data": null,
    "expiring_in_months": null,
    "first_six": "700953",
    "has_recurring": false,
    "last_four": "3657",
    "modified_ts": 1422040992,
    "payment_method": "cc",
    "ticket": null,
    "track_data": null
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Create a New Previous Transaction Token

Create a new Previous Transaction Token

```csharp
CreateANewPreviousTransactionTokenAsync(
    Models.V1TokensPreviousTransactionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TokensPreviousTransactionRequest`](../../doc/models/v1-tokens-previous-transaction-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
var body = new V1TokensPreviousTransactionRequest();
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.PreviousTransactionId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseToken result = await tokensController.CreateANewPreviousTransactionTokenAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Token",
  "data": {
    "account_holder_name": "John Smith",
    "account_number": "545454545454545",
    "account_vault_api_id": "accountvaultabcd",
    "accountvault_c1": "accountvault custom 1",
    "accountvault_c2": "accountvault custom 2",
    "accountvault_c3": "accountvault custom 3",
    "ach_sec_code": "WEB",
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "customer_id": "123456",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "ssn4": "8527",
      "dob_year": "1980"
    },
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_account_vault_api_id": "previousaccountvault123456",
    "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "terms_agree": true,
    "terms_agree_ip": "192.168.0.10",
    "title": "Test CC Account",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "account_type": "checking",
    "active": true,
    "cau_summary_status_id": 1,
    "created_ts": 1422040992,
    "e_serial_number": "1234567890",
    "e_track_data": null,
    "e_format": null,
    "e_keyed_data": null,
    "expiring_in_months": null,
    "first_six": "700953",
    "has_recurring": false,
    "last_four": "3657",
    "modified_ts": 1422040992,
    "payment_method": "cc",
    "ticket": null,
    "track_data": null
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Create a New Terminal Token

Create a new Terminal Token

```csharp
CreateANewTerminalTokenAsync(
    Models.V1TokensTerminalRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TokensTerminalRequest`](../../doc/models/v1-tokens-terminal-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
var body = new V1TokensTerminalRequest();
body.ContactId = "11e95f8ec39de8fbdb0a4f1a";
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.TerminalId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseToken result = await tokensController.CreateANewTerminalTokenAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Token",
  "data": {
    "account_holder_name": "John Smith",
    "account_number": "545454545454545",
    "account_vault_api_id": "accountvaultabcd",
    "accountvault_c1": "accountvault custom 1",
    "accountvault_c2": "accountvault custom 2",
    "accountvault_c3": "accountvault custom 3",
    "ach_sec_code": "WEB",
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "customer_id": "123456",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "ssn4": "8527",
      "dob_year": "1980"
    },
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_account_vault_api_id": "previousaccountvault123456",
    "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "terms_agree": true,
    "terms_agree_ip": "192.168.0.10",
    "title": "Test CC Account",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "account_type": "checking",
    "active": true,
    "cau_summary_status_id": 1,
    "created_ts": 1422040992,
    "e_serial_number": "1234567890",
    "e_track_data": null,
    "e_format": null,
    "e_keyed_data": null,
    "expiring_in_months": null,
    "first_six": "700953",
    "has_recurring": false,
    "last_four": "3657",
    "modified_ts": 1422040992,
    "payment_method": "cc",
    "ticket": null,
    "track_data": null
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Create a New Ticket Token

Create a new Ticket Token

```csharp
CreateANewTicketTokenAsync(
    Models.V1TokensTicketRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TokensTicketRequest`](../../doc/models/v1-tokens-ticket-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
var body = new V1TokensTicketRequest();
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.Ticket = "12345678";

try
{
    ResponseToken result = await tokensController.CreateANewTicketTokenAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Token",
  "data": {
    "account_holder_name": "John Smith",
    "account_number": "545454545454545",
    "account_vault_api_id": "accountvaultabcd",
    "accountvault_c1": "accountvault custom 1",
    "accountvault_c2": "accountvault custom 2",
    "accountvault_c3": "accountvault custom 3",
    "ach_sec_code": "WEB",
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "customer_id": "123456",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "ssn4": "8527",
      "dob_year": "1980"
    },
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_account_vault_api_id": "previousaccountvault123456",
    "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "terms_agree": true,
    "terms_agree_ip": "192.168.0.10",
    "title": "Test CC Account",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "account_type": "checking",
    "active": true,
    "cau_summary_status_id": 1,
    "created_ts": 1422040992,
    "e_serial_number": "1234567890",
    "e_track_data": null,
    "e_format": null,
    "e_keyed_data": null,
    "expiring_in_months": null,
    "first_six": "700953",
    "has_recurring": false,
    "last_four": "3657",
    "modified_ts": 1422040992,
    "payment_method": "cc",
    "ticket": null,
    "track_data": null
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Delete a Single Token Record

Delete a single token record

```csharp
DeleteASingleTokenRecordAsync(
    string tokenId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tokenId` | `string` | Template, Required | A unique, system-generated identifier for the Token.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
string tokenId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseToken result = await tokensController.DeleteASingleTokenRecordAsync(tokenId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Token",
  "data": {
    "account_holder_name": "John Smith",
    "account_number": "545454545454545",
    "account_vault_api_id": "accountvaultabcd",
    "accountvault_c1": "accountvault custom 1",
    "accountvault_c2": "accountvault custom 2",
    "accountvault_c3": "accountvault custom 3",
    "ach_sec_code": "WEB",
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "customer_id": "123456",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "ssn4": "8527",
      "dob_year": "1980"
    },
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_account_vault_api_id": "previousaccountvault123456",
    "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "terms_agree": true,
    "terms_agree_ip": "192.168.0.10",
    "title": "Test CC Account",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "account_type": "checking",
    "active": true,
    "cau_summary_status_id": 1,
    "created_ts": 1422040992,
    "e_serial_number": "1234567890",
    "e_track_data": null,
    "e_format": null,
    "e_keyed_data": null,
    "expiring_in_months": null,
    "first_six": "700953",
    "has_recurring": false,
    "last_four": "3657",
    "modified_ts": 1422040992,
    "payment_method": "cc",
    "ticket": null,
    "track_data": null
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# View Single Token Record

View single token record

```csharp
ViewSingleTokenRecordAsync(
    string tokenId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tokenId` | `string` | Template, Required | A unique, system-generated identifier for the Token.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
string tokenId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseToken result = await tokensController.ViewSingleTokenRecordAsync(tokenId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Token",
  "data": {
    "account_holder_name": "John Smith",
    "account_number": "545454545454545",
    "account_vault_api_id": "accountvaultabcd",
    "accountvault_c1": "accountvault custom 1",
    "accountvault_c2": "accountvault custom 2",
    "accountvault_c3": "accountvault custom 3",
    "ach_sec_code": "WEB",
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "customer_id": "123456",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "ssn4": "8527",
      "dob_year": "1980"
    },
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_account_vault_api_id": "previousaccountvault123456",
    "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "terms_agree": true,
    "terms_agree_ip": "192.168.0.10",
    "title": "Test CC Account",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "account_type": "checking",
    "active": true,
    "cau_summary_status_id": 1,
    "created_ts": 1422040992,
    "e_serial_number": "1234567890",
    "e_track_data": null,
    "e_format": null,
    "e_keyed_data": null,
    "expiring_in_months": null,
    "first_six": "700953",
    "has_recurring": false,
    "last_four": "3657",
    "modified_ts": 1422040992,
    "payment_method": "cc",
    "ticket": null,
    "track_data": null
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# List All Tokens Related

List all tokens related

```csharp
ListAllTokensRelatedAsync(
    Models.Page page = null,
    Models.Sort10 sort = null,
    Models.Filter10 filter = null,
    List<string> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Models.Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `sort` | [`Models.Sort10`](../../doc/models/sort-10.md) | Query, Optional | You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods:<br><br>> /endpoint?sort={ "field_name": "asc", "field_name2": "desc" }<br>> <br>> /endpoint?sort[field_name]=asc&sort[field_name2]=desc |
| `filter` | [`Models.Filter10`](../../doc/models/filter-10.md) | Query, Optional | You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods:<br><br>> /endpoint?filter={ "field_name": "Value" }<br>> <br>> /endpoint?filter[field_name]=Value |
| `expand` | `List<string>` | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request.<br>**Constraints**: *Unique Items Required*, *Pattern*: `^[\w]+$` |

## Response Type

[`Task<Models.ResponseTokensCollection>`](../../doc/models/response-tokens-collection.md)

## Example Usage

```csharp
try
{
    ResponseTokensCollection result = await tokensController.ListAllTokensRelatedAsync(null, null, null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "TokensCollection",
  "list": [
    {
      "account_holder_name": "John Smith",
      "account_number": "545454545454545",
      "account_vault_api_id": "accountvaultabcd",
      "accountvault_c1": "accountvault custom 1",
      "accountvault_c2": "accountvault custom 2",
      "accountvault_c3": "accountvault custom 3",
      "ach_sec_code": "WEB",
      "billing_address": {
        "city": "Novi",
        "state": "Michigan",
        "postal_code": "48375",
        "street": "43155 Main Street STE 2310-C",
        "phone": "3339998822"
      },
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "customer_id": "123456",
      "identity_verification": {
        "dl_state": "MI",
        "dl_number": "1235567",
        "ssn4": "8527",
        "dob_year": "1980"
      },
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_account_vault_api_id": "previousaccountvault123456",
      "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "terms_agree": true,
      "terms_agree_ip": "192.168.0.10",
      "title": "Test CC Account",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "account_type": "checking",
      "active": true,
      "cau_summary_status_id": 1,
      "created_ts": 1422040992,
      "e_serial_number": "1234567890",
      "e_track_data": null,
      "e_format": null,
      "e_keyed_data": null,
      "expiring_in_months": null,
      "first_six": "700953",
      "has_recurring": false,
      "last_four": "3657",
      "modified_ts": 1422040992,
      "payment_method": "cc",
      "ticket": null,
      "track_data": null
    }
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Update ACH Token

Update ACH Token

```csharp
UpdateACHTokenAsync(
    string tokenId,
    Models.V1TokensAchRequest1 body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tokenId` | `string` | Template, Required | A unique, system-generated identifier for the Token.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1TokensAchRequest1`](../../doc/models/v1-tokens-ach-request-1.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
string tokenId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1TokensAchRequest1();

try
{
    ResponseToken result = await tokensController.UpdateACHTokenAsync(tokenId, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Token",
  "data": {
    "account_holder_name": "John Smith",
    "account_number": "545454545454545",
    "account_vault_api_id": "accountvaultabcd",
    "accountvault_c1": "accountvault custom 1",
    "accountvault_c2": "accountvault custom 2",
    "accountvault_c3": "accountvault custom 3",
    "ach_sec_code": "WEB",
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "customer_id": "123456",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "ssn4": "8527",
      "dob_year": "1980"
    },
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_account_vault_api_id": "previousaccountvault123456",
    "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "terms_agree": true,
    "terms_agree_ip": "192.168.0.10",
    "title": "Test CC Account",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "account_type": "checking",
    "active": true,
    "cau_summary_status_id": 1,
    "created_ts": 1422040992,
    "e_serial_number": "1234567890",
    "e_track_data": null,
    "e_format": null,
    "e_keyed_data": null,
    "expiring_in_months": null,
    "first_six": "700953",
    "has_recurring": false,
    "last_four": "3657",
    "modified_ts": 1422040992,
    "payment_method": "cc",
    "ticket": null,
    "track_data": null
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Update CC Token

Update CC Token

```csharp
UpdateCCTokenAsync(
    string tokenId,
    Models.V1TokensCcRequest1 body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tokenId` | `string` | Template, Required | A unique, system-generated identifier for the Token.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1TokensCcRequest1`](../../doc/models/v1-tokens-cc-request-1.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
string tokenId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1TokensCcRequest1();

try
{
    ResponseToken result = await tokensController.UpdateCCTokenAsync(tokenId, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Token",
  "data": {
    "account_holder_name": "John Smith",
    "account_number": "545454545454545",
    "account_vault_api_id": "accountvaultabcd",
    "accountvault_c1": "accountvault custom 1",
    "accountvault_c2": "accountvault custom 2",
    "accountvault_c3": "accountvault custom 3",
    "ach_sec_code": "WEB",
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "customer_id": "123456",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "ssn4": "8527",
      "dob_year": "1980"
    },
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_account_vault_api_id": "previousaccountvault123456",
    "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "terms_agree": true,
    "terms_agree_ip": "192.168.0.10",
    "title": "Test CC Account",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "account_type": "checking",
    "active": true,
    "cau_summary_status_id": 1,
    "created_ts": 1422040992,
    "e_serial_number": "1234567890",
    "e_track_data": null,
    "e_format": null,
    "e_keyed_data": null,
    "expiring_in_months": null,
    "first_six": "700953",
    "has_recurring": false,
    "last_four": "3657",
    "modified_ts": 1422040992,
    "payment_method": "cc",
    "ticket": null,
    "track_data": null
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |

