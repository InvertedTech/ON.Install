# Transactions - Credit Card

```csharp
TransactionsCreditCardController transactionsCreditCardController = client.TransactionsCreditCardController;
```

## Class Name

`TransactionsCreditCardController`

## Methods

* [CC Auth Only](../../doc/controllers/transactions-credit-card.md#cc-auth-only)
* [CC Auth Only - Terminal](../../doc/controllers/transactions-credit-card.md#cc-auth-only---terminal)
* [CC Auth Only - Tokenized](../../doc/controllers/transactions-credit-card.md#cc-auth-only---tokenized)
* [CC AVS](../../doc/controllers/transactions-credit-card.md#cc-avs)
* [CC AVS - Terminal](../../doc/controllers/transactions-credit-card.md#cc-avs---terminal)
* [CC AVS - Tokenized](../../doc/controllers/transactions-credit-card.md#cc-avs---tokenized)
* [CC Force](../../doc/controllers/transactions-credit-card.md#cc-force)
* [CC Force - Terminal](../../doc/controllers/transactions-credit-card.md#cc-force---terminal)
* [CC Force - Tokenized](../../doc/controllers/transactions-credit-card.md#cc-force---tokenized)
* [CC Refund](../../doc/controllers/transactions-credit-card.md#cc-refund)
* [CC Refund - Terminal](../../doc/controllers/transactions-credit-card.md#cc-refund---terminal)
* [CC Refund - Tokenized](../../doc/controllers/transactions-credit-card.md#cc-refund---tokenized)
* [CC Sale](../../doc/controllers/transactions-credit-card.md#cc-sale)
* [CC Sale - Terminal](../../doc/controllers/transactions-credit-card.md#cc-sale---terminal)
* [CC Sale - Tokenized](../../doc/controllers/transactions-credit-card.md#cc-sale---tokenized)


# CC Auth Only

Create a new keyed Credit Card authorization only transaction

```csharp
CCAuthOnlyAsync(
    Models.V1TransactionsCcAuthOnlyKeyedRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TransactionsCcAuthOnlyKeyedRequest`](../../doc/models/v1-transactions-cc-auth-only-keyed-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
var body = new V1TransactionsCcAuthOnlyKeyedRequest();
body.TransactionAmount = 2099;
body.AccountNumber = "account_number4";
body.ExpDate = "0722";

try
{
    ResponseTransaction result = await transactionsCreditCardController.CCAuthOnlyAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": "10",
        "account_type": "credit",
        "currency": 840
      }
    ],
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "checkin_date": "2021-12-01",
    "checkout_date": "2021-12-01",
    "clerk_number": "AE1234",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "custom_data": "custom data string",
    "customer_id": "customerid",
    "description": "some description",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "dob_year": "1980"
    },
    "iias_ind": 1,
    "image_front": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "image_back": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "installment": true,
    "installment_number": 1,
    "installment_count": 1,
    "location_api_id": "location-api-id-florida-2",
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "no_show": false,
    "notification_email_address": "johnsmith@smiths.com",
    "order_number": "433659378839",
    "po_number": "555555553123",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "quick_invoice_id": "11e95f8ec39de8fbdb0a4f1a",
    "recurring": false,
    "recurring_number": 1,
    "room_num": "303",
    "room_rate": 95.3,
    "save_account": false,
    "save_account_title": "John Account",
    "subtotal_amount": 599,
    "surcharge_amount": 0,
    "tags": [
      {
        "title": "Walk-in Customer"
      }
    ],
    "tax": 0,
    "tip_amount": 0,
    "transaction_amount": 2099,
    "transaction_api_id": "transaction-payment-abcd123",
    "transaction_c1": "custom-data-1",
    "transaction_c2": "custom-data-2",
    "transaction_c3": "custom-data-3",
    "transaction_c4": "custom-data-4",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "account_holder_name": "smith",
    "account_type": "checking",
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_identifier": "P",
    "ach_sec_code": "C21",
    "advance_deposit": true,
    "auth_amount": 1,
    "auth_code": "BR349K",
    "avs": "BAD",
    "avs_enhanced": "N",
    "cardholder_present": true,
    "card_present": true,
    "check_number": "8520748520963",
    "customer_ip": "192.168.0.10",
    "cvv_response": "N",
    "entry_mode_id": "C",
    "emv_receipt_data": {
      "AID": "a0000000042203",
      "APPLAB": "US Maestro",
      "APPN": "US Maestro",
      "CVM": "Pin Verified",
      "TSI": "e800",
      "TVR": "0800008000"
    },
    "first_six": "545454",
    "last_four": "5454",
    "payment_method": "cc",
    "terminal_serial_number": "1234567890",
    "transaction_settlement_status": null,
    "charge_back_date": "2021-12-01",
    "is_recurring": true,
    "notification_email_sent": "true",
    "par": "Q1J4Z28RKA1EBL470G9XYG90R5D3E",
    "reason_code_id": 1000,
    "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
    "settle_date": "2021-12-01",
    "status_id": 101,
    "transaction_batch_id": "11e95f8ec39de8fbdb0a4f1a",
    "verbiage": "APPROVED",
    "void_date": "2021-12-01",
    "batch": "2",
    "terms_agree": true,
    "response_message": null,
    "return_date": "2021-12-01",
    "trx_source_id": 8
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# CC Auth Only - Terminal

Create a new terminal Credit Card authorization only transaction

```csharp
CCAuthOnlyTerminalAsync(
    Models.V1TransactionsCcAuthOnlyTerminalRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TransactionsCcAuthOnlyTerminalRequest`](../../doc/models/v1-transactions-cc-auth-only-terminal-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseAsyncProcessing>`](../../doc/models/response-async-processing.md)

## Example Usage

```csharp
var body = new V1TransactionsCcAuthOnlyTerminalRequest();
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.TransactionAmount = 2099;
body.TerminalId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseAsyncProcessing result = await transactionsCreditCardController.CCAuthOnlyTerminalAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "AsyncProcessing",
  "data": {
    "async": {
      "code": "406c66c3-21cb-47fb-80fc-843bc42507fb",
      "link": "/v1/async/status/406c66c3-21cb-47fb-80fc-843bc42507fb"
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# CC Auth Only - Tokenized

Create a new tokenized Credit Card authorization only transaction

```csharp
CCAuthOnlyTokenizedAsync(
    Models.V1TransactionsCcAuthOnlyTokenRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TransactionsCcAuthOnlyTokenRequest`](../../doc/models/v1-transactions-cc-auth-only-token-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
var body = new V1TransactionsCcAuthOnlyTokenRequest();
body.TransactionAmount = 2099;
body.AccountVaultId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseTransaction result = await transactionsCreditCardController.CCAuthOnlyTokenizedAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": "10",
        "account_type": "credit",
        "currency": 840
      }
    ],
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "checkin_date": "2021-12-01",
    "checkout_date": "2021-12-01",
    "clerk_number": "AE1234",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "custom_data": "custom data string",
    "customer_id": "customerid",
    "description": "some description",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "dob_year": "1980"
    },
    "iias_ind": 1,
    "image_front": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "image_back": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "installment": true,
    "installment_number": 1,
    "installment_count": 1,
    "location_api_id": "location-api-id-florida-2",
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "no_show": false,
    "notification_email_address": "johnsmith@smiths.com",
    "order_number": "433659378839",
    "po_number": "555555553123",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "quick_invoice_id": "11e95f8ec39de8fbdb0a4f1a",
    "recurring": false,
    "recurring_number": 1,
    "room_num": "303",
    "room_rate": 95.3,
    "save_account": false,
    "save_account_title": "John Account",
    "subtotal_amount": 599,
    "surcharge_amount": 0,
    "tags": [
      {
        "title": "Walk-in Customer"
      }
    ],
    "tax": 0,
    "tip_amount": 0,
    "transaction_amount": 2099,
    "transaction_api_id": "transaction-payment-abcd123",
    "transaction_c1": "custom-data-1",
    "transaction_c2": "custom-data-2",
    "transaction_c3": "custom-data-3",
    "transaction_c4": "custom-data-4",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "account_holder_name": "smith",
    "account_type": "checking",
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_identifier": "P",
    "ach_sec_code": "C21",
    "advance_deposit": true,
    "auth_amount": 1,
    "auth_code": "BR349K",
    "avs": "BAD",
    "avs_enhanced": "N",
    "cardholder_present": true,
    "card_present": true,
    "check_number": "8520748520963",
    "customer_ip": "192.168.0.10",
    "cvv_response": "N",
    "entry_mode_id": "C",
    "emv_receipt_data": {
      "AID": "a0000000042203",
      "APPLAB": "US Maestro",
      "APPN": "US Maestro",
      "CVM": "Pin Verified",
      "TSI": "e800",
      "TVR": "0800008000"
    },
    "first_six": "545454",
    "last_four": "5454",
    "payment_method": "cc",
    "terminal_serial_number": "1234567890",
    "transaction_settlement_status": null,
    "charge_back_date": "2021-12-01",
    "is_recurring": true,
    "notification_email_sent": "true",
    "par": "Q1J4Z28RKA1EBL470G9XYG90R5D3E",
    "reason_code_id": 1000,
    "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
    "settle_date": "2021-12-01",
    "status_id": 101,
    "transaction_batch_id": "11e95f8ec39de8fbdb0a4f1a",
    "verbiage": "APPROVED",
    "void_date": "2021-12-01",
    "batch": "2",
    "terms_agree": true,
    "response_message": null,
    "return_date": "2021-12-01",
    "trx_source_id": 8
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# CC AVS

Create a new keyed Credit Card AVS only transaction

```csharp
CCAVSAsync(
    Models.V1TransactionsCcAvsOnlyKeyedRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TransactionsCcAvsOnlyKeyedRequest`](../../doc/models/v1-transactions-cc-avs-only-keyed-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
var body = new V1TransactionsCcAvsOnlyKeyedRequest();
body.TransactionAmount = 2099;
body.AccountNumber = "account_number4";
body.ExpDate = "0722";

try
{
    ResponseTransaction result = await transactionsCreditCardController.CCAVSAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": "10",
        "account_type": "credit",
        "currency": 840
      }
    ],
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "checkin_date": "2021-12-01",
    "checkout_date": "2021-12-01",
    "clerk_number": "AE1234",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "custom_data": "custom data string",
    "customer_id": "customerid",
    "description": "some description",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "dob_year": "1980"
    },
    "iias_ind": 1,
    "image_front": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "image_back": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "installment": true,
    "installment_number": 1,
    "installment_count": 1,
    "location_api_id": "location-api-id-florida-2",
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "no_show": false,
    "notification_email_address": "johnsmith@smiths.com",
    "order_number": "433659378839",
    "po_number": "555555553123",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "quick_invoice_id": "11e95f8ec39de8fbdb0a4f1a",
    "recurring": false,
    "recurring_number": 1,
    "room_num": "303",
    "room_rate": 95.3,
    "save_account": false,
    "save_account_title": "John Account",
    "subtotal_amount": 599,
    "surcharge_amount": 0,
    "tags": [
      {
        "title": "Walk-in Customer"
      }
    ],
    "tax": 0,
    "tip_amount": 0,
    "transaction_amount": 2099,
    "transaction_api_id": "transaction-payment-abcd123",
    "transaction_c1": "custom-data-1",
    "transaction_c2": "custom-data-2",
    "transaction_c3": "custom-data-3",
    "transaction_c4": "custom-data-4",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "account_holder_name": "smith",
    "account_type": "checking",
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_identifier": "P",
    "ach_sec_code": "C21",
    "advance_deposit": true,
    "auth_amount": 1,
    "auth_code": "BR349K",
    "avs": "BAD",
    "avs_enhanced": "N",
    "cardholder_present": true,
    "card_present": true,
    "check_number": "8520748520963",
    "customer_ip": "192.168.0.10",
    "cvv_response": "N",
    "entry_mode_id": "C",
    "emv_receipt_data": {
      "AID": "a0000000042203",
      "APPLAB": "US Maestro",
      "APPN": "US Maestro",
      "CVM": "Pin Verified",
      "TSI": "e800",
      "TVR": "0800008000"
    },
    "first_six": "545454",
    "last_four": "5454",
    "payment_method": "cc",
    "terminal_serial_number": "1234567890",
    "transaction_settlement_status": null,
    "charge_back_date": "2021-12-01",
    "is_recurring": true,
    "notification_email_sent": "true",
    "par": "Q1J4Z28RKA1EBL470G9XYG90R5D3E",
    "reason_code_id": 1000,
    "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
    "settle_date": "2021-12-01",
    "status_id": 101,
    "transaction_batch_id": "11e95f8ec39de8fbdb0a4f1a",
    "verbiage": "APPROVED",
    "void_date": "2021-12-01",
    "batch": "2",
    "terms_agree": true,
    "response_message": null,
    "return_date": "2021-12-01",
    "trx_source_id": 8
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# CC AVS - Terminal

Create a new terminal Credit Card AVS only transaction

```csharp
CCAVSTerminalAsync(
    Models.V1TransactionsCcAvsOnlyTerminalRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TransactionsCcAvsOnlyTerminalRequest`](../../doc/models/v1-transactions-cc-avs-only-terminal-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseAsyncProcessing>`](../../doc/models/response-async-processing.md)

## Example Usage

```csharp
var body = new V1TransactionsCcAvsOnlyTerminalRequest();
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.TransactionAmount = 2099;
body.TerminalId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseAsyncProcessing result = await transactionsCreditCardController.CCAVSTerminalAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "AsyncProcessing",
  "data": {
    "async": {
      "code": "406c66c3-21cb-47fb-80fc-843bc42507fb",
      "link": "/v1/async/status/406c66c3-21cb-47fb-80fc-843bc42507fb"
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# CC AVS - Tokenized

Create a new tokenized Credit Card AVS only transaction

```csharp
CCAVSTokenizedAsync(
    Models.V1TransactionsCcAvsOnlyTokenRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TransactionsCcAvsOnlyTokenRequest`](../../doc/models/v1-transactions-cc-avs-only-token-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
var body = new V1TransactionsCcAvsOnlyTokenRequest();
body.TransactionAmount = 2099;
body.AccountVaultId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseTransaction result = await transactionsCreditCardController.CCAVSTokenizedAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": "10",
        "account_type": "credit",
        "currency": 840
      }
    ],
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "checkin_date": "2021-12-01",
    "checkout_date": "2021-12-01",
    "clerk_number": "AE1234",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "custom_data": "custom data string",
    "customer_id": "customerid",
    "description": "some description",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "dob_year": "1980"
    },
    "iias_ind": 1,
    "image_front": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "image_back": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "installment": true,
    "installment_number": 1,
    "installment_count": 1,
    "location_api_id": "location-api-id-florida-2",
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "no_show": false,
    "notification_email_address": "johnsmith@smiths.com",
    "order_number": "433659378839",
    "po_number": "555555553123",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "quick_invoice_id": "11e95f8ec39de8fbdb0a4f1a",
    "recurring": false,
    "recurring_number": 1,
    "room_num": "303",
    "room_rate": 95.3,
    "save_account": false,
    "save_account_title": "John Account",
    "subtotal_amount": 599,
    "surcharge_amount": 0,
    "tags": [
      {
        "title": "Walk-in Customer"
      }
    ],
    "tax": 0,
    "tip_amount": 0,
    "transaction_amount": 2099,
    "transaction_api_id": "transaction-payment-abcd123",
    "transaction_c1": "custom-data-1",
    "transaction_c2": "custom-data-2",
    "transaction_c3": "custom-data-3",
    "transaction_c4": "custom-data-4",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "account_holder_name": "smith",
    "account_type": "checking",
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_identifier": "P",
    "ach_sec_code": "C21",
    "advance_deposit": true,
    "auth_amount": 1,
    "auth_code": "BR349K",
    "avs": "BAD",
    "avs_enhanced": "N",
    "cardholder_present": true,
    "card_present": true,
    "check_number": "8520748520963",
    "customer_ip": "192.168.0.10",
    "cvv_response": "N",
    "entry_mode_id": "C",
    "emv_receipt_data": {
      "AID": "a0000000042203",
      "APPLAB": "US Maestro",
      "APPN": "US Maestro",
      "CVM": "Pin Verified",
      "TSI": "e800",
      "TVR": "0800008000"
    },
    "first_six": "545454",
    "last_four": "5454",
    "payment_method": "cc",
    "terminal_serial_number": "1234567890",
    "transaction_settlement_status": null,
    "charge_back_date": "2021-12-01",
    "is_recurring": true,
    "notification_email_sent": "true",
    "par": "Q1J4Z28RKA1EBL470G9XYG90R5D3E",
    "reason_code_id": 1000,
    "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
    "settle_date": "2021-12-01",
    "status_id": 101,
    "transaction_batch_id": "11e95f8ec39de8fbdb0a4f1a",
    "verbiage": "APPROVED",
    "void_date": "2021-12-01",
    "batch": "2",
    "terms_agree": true,
    "response_message": null,
    "return_date": "2021-12-01",
    "trx_source_id": 8
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# CC Force

Create a new keyed Credit Card force transaction

```csharp
CCForceAsync(
    Models.V1TransactionsCcForceKeyedRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TransactionsCcForceKeyedRequest`](../../doc/models/v1-transactions-cc-force-keyed-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
var body = new V1TransactionsCcForceKeyedRequest();
body.TransactionAmount = 2099;
body.AccountNumber = "account_number4";
body.ExpDate = "0722";
body.AuthCode = "abc123";

try
{
    ResponseTransaction result = await transactionsCreditCardController.CCForceAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": "10",
        "account_type": "credit",
        "currency": 840
      }
    ],
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "checkin_date": "2021-12-01",
    "checkout_date": "2021-12-01",
    "clerk_number": "AE1234",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "custom_data": "custom data string",
    "customer_id": "customerid",
    "description": "some description",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "dob_year": "1980"
    },
    "iias_ind": 1,
    "image_front": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "image_back": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "installment": true,
    "installment_number": 1,
    "installment_count": 1,
    "location_api_id": "location-api-id-florida-2",
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "no_show": false,
    "notification_email_address": "johnsmith@smiths.com",
    "order_number": "433659378839",
    "po_number": "555555553123",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "quick_invoice_id": "11e95f8ec39de8fbdb0a4f1a",
    "recurring": false,
    "recurring_number": 1,
    "room_num": "303",
    "room_rate": 95.3,
    "save_account": false,
    "save_account_title": "John Account",
    "subtotal_amount": 599,
    "surcharge_amount": 0,
    "tags": [
      {
        "title": "Walk-in Customer"
      }
    ],
    "tax": 0,
    "tip_amount": 0,
    "transaction_amount": 2099,
    "transaction_api_id": "transaction-payment-abcd123",
    "transaction_c1": "custom-data-1",
    "transaction_c2": "custom-data-2",
    "transaction_c3": "custom-data-3",
    "transaction_c4": "custom-data-4",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "account_holder_name": "smith",
    "account_type": "checking",
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_identifier": "P",
    "ach_sec_code": "C21",
    "advance_deposit": true,
    "auth_amount": 1,
    "auth_code": "BR349K",
    "avs": "BAD",
    "avs_enhanced": "N",
    "cardholder_present": true,
    "card_present": true,
    "check_number": "8520748520963",
    "customer_ip": "192.168.0.10",
    "cvv_response": "N",
    "entry_mode_id": "C",
    "emv_receipt_data": {
      "AID": "a0000000042203",
      "APPLAB": "US Maestro",
      "APPN": "US Maestro",
      "CVM": "Pin Verified",
      "TSI": "e800",
      "TVR": "0800008000"
    },
    "first_six": "545454",
    "last_four": "5454",
    "payment_method": "cc",
    "terminal_serial_number": "1234567890",
    "transaction_settlement_status": null,
    "charge_back_date": "2021-12-01",
    "is_recurring": true,
    "notification_email_sent": "true",
    "par": "Q1J4Z28RKA1EBL470G9XYG90R5D3E",
    "reason_code_id": 1000,
    "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
    "settle_date": "2021-12-01",
    "status_id": 101,
    "transaction_batch_id": "11e95f8ec39de8fbdb0a4f1a",
    "verbiage": "APPROVED",
    "void_date": "2021-12-01",
    "batch": "2",
    "terms_agree": true,
    "response_message": null,
    "return_date": "2021-12-01",
    "trx_source_id": 8
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# CC Force - Terminal

Create a new terminal Credit Card force transaction

```csharp
CCForceTerminalAsync(
    Models.V1TransactionsCcForceTerminalRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TransactionsCcForceTerminalRequest`](../../doc/models/v1-transactions-cc-force-terminal-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseAsyncProcessing>`](../../doc/models/response-async-processing.md)

## Example Usage

```csharp
var body = new V1TransactionsCcForceTerminalRequest();
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.TransactionAmount = 2099;
body.TerminalId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseAsyncProcessing result = await transactionsCreditCardController.CCForceTerminalAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "AsyncProcessing",
  "data": {
    "async": {
      "code": "406c66c3-21cb-47fb-80fc-843bc42507fb",
      "link": "/v1/async/status/406c66c3-21cb-47fb-80fc-843bc42507fb"
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# CC Force - Tokenized

Create a new tokenized Credit Card force transaction

```csharp
CCForceTokenizedAsync(
    Models.V1TransactionsCcForceTokenRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TransactionsCcForceTokenRequest`](../../doc/models/v1-transactions-cc-force-token-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
var body = new V1TransactionsCcForceTokenRequest();
body.TransactionAmount = 2099;
body.AccountVaultId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseTransaction result = await transactionsCreditCardController.CCForceTokenizedAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": "10",
        "account_type": "credit",
        "currency": 840
      }
    ],
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "checkin_date": "2021-12-01",
    "checkout_date": "2021-12-01",
    "clerk_number": "AE1234",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "custom_data": "custom data string",
    "customer_id": "customerid",
    "description": "some description",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "dob_year": "1980"
    },
    "iias_ind": 1,
    "image_front": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "image_back": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "installment": true,
    "installment_number": 1,
    "installment_count": 1,
    "location_api_id": "location-api-id-florida-2",
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "no_show": false,
    "notification_email_address": "johnsmith@smiths.com",
    "order_number": "433659378839",
    "po_number": "555555553123",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "quick_invoice_id": "11e95f8ec39de8fbdb0a4f1a",
    "recurring": false,
    "recurring_number": 1,
    "room_num": "303",
    "room_rate": 95.3,
    "save_account": false,
    "save_account_title": "John Account",
    "subtotal_amount": 599,
    "surcharge_amount": 0,
    "tags": [
      {
        "title": "Walk-in Customer"
      }
    ],
    "tax": 0,
    "tip_amount": 0,
    "transaction_amount": 2099,
    "transaction_api_id": "transaction-payment-abcd123",
    "transaction_c1": "custom-data-1",
    "transaction_c2": "custom-data-2",
    "transaction_c3": "custom-data-3",
    "transaction_c4": "custom-data-4",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "account_holder_name": "smith",
    "account_type": "checking",
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_identifier": "P",
    "ach_sec_code": "C21",
    "advance_deposit": true,
    "auth_amount": 1,
    "auth_code": "BR349K",
    "avs": "BAD",
    "avs_enhanced": "N",
    "cardholder_present": true,
    "card_present": true,
    "check_number": "8520748520963",
    "customer_ip": "192.168.0.10",
    "cvv_response": "N",
    "entry_mode_id": "C",
    "emv_receipt_data": {
      "AID": "a0000000042203",
      "APPLAB": "US Maestro",
      "APPN": "US Maestro",
      "CVM": "Pin Verified",
      "TSI": "e800",
      "TVR": "0800008000"
    },
    "first_six": "545454",
    "last_four": "5454",
    "payment_method": "cc",
    "terminal_serial_number": "1234567890",
    "transaction_settlement_status": null,
    "charge_back_date": "2021-12-01",
    "is_recurring": true,
    "notification_email_sent": "true",
    "par": "Q1J4Z28RKA1EBL470G9XYG90R5D3E",
    "reason_code_id": 1000,
    "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
    "settle_date": "2021-12-01",
    "status_id": 101,
    "transaction_batch_id": "11e95f8ec39de8fbdb0a4f1a",
    "verbiage": "APPROVED",
    "void_date": "2021-12-01",
    "batch": "2",
    "terms_agree": true,
    "response_message": null,
    "return_date": "2021-12-01",
    "trx_source_id": 8
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# CC Refund

Create a new keyed Credit Card refund transaction

```csharp
CCRefundAsync(
    Models.V1TransactionsCcRefundKeyedRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TransactionsCcRefundKeyedRequest`](../../doc/models/v1-transactions-cc-refund-keyed-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
var body = new V1TransactionsCcRefundKeyedRequest();
body.TransactionAmount = 2099;
body.AccountNumber = "account_number4";
body.ExpDate = "0722";

try
{
    ResponseTransaction result = await transactionsCreditCardController.CCRefundAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": "10",
        "account_type": "credit",
        "currency": 840
      }
    ],
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "checkin_date": "2021-12-01",
    "checkout_date": "2021-12-01",
    "clerk_number": "AE1234",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "custom_data": "custom data string",
    "customer_id": "customerid",
    "description": "some description",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "dob_year": "1980"
    },
    "iias_ind": 1,
    "image_front": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "image_back": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "installment": true,
    "installment_number": 1,
    "installment_count": 1,
    "location_api_id": "location-api-id-florida-2",
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "no_show": false,
    "notification_email_address": "johnsmith@smiths.com",
    "order_number": "433659378839",
    "po_number": "555555553123",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "quick_invoice_id": "11e95f8ec39de8fbdb0a4f1a",
    "recurring": false,
    "recurring_number": 1,
    "room_num": "303",
    "room_rate": 95.3,
    "save_account": false,
    "save_account_title": "John Account",
    "subtotal_amount": 599,
    "surcharge_amount": 0,
    "tags": [
      {
        "title": "Walk-in Customer"
      }
    ],
    "tax": 0,
    "tip_amount": 0,
    "transaction_amount": 2099,
    "transaction_api_id": "transaction-payment-abcd123",
    "transaction_c1": "custom-data-1",
    "transaction_c2": "custom-data-2",
    "transaction_c3": "custom-data-3",
    "transaction_c4": "custom-data-4",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "account_holder_name": "smith",
    "account_type": "checking",
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_identifier": "P",
    "ach_sec_code": "C21",
    "advance_deposit": true,
    "auth_amount": 1,
    "auth_code": "BR349K",
    "avs": "BAD",
    "avs_enhanced": "N",
    "cardholder_present": true,
    "card_present": true,
    "check_number": "8520748520963",
    "customer_ip": "192.168.0.10",
    "cvv_response": "N",
    "entry_mode_id": "C",
    "emv_receipt_data": {
      "AID": "a0000000042203",
      "APPLAB": "US Maestro",
      "APPN": "US Maestro",
      "CVM": "Pin Verified",
      "TSI": "e800",
      "TVR": "0800008000"
    },
    "first_six": "545454",
    "last_four": "5454",
    "payment_method": "cc",
    "terminal_serial_number": "1234567890",
    "transaction_settlement_status": null,
    "charge_back_date": "2021-12-01",
    "is_recurring": true,
    "notification_email_sent": "true",
    "par": "Q1J4Z28RKA1EBL470G9XYG90R5D3E",
    "reason_code_id": 1000,
    "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
    "settle_date": "2021-12-01",
    "status_id": 101,
    "transaction_batch_id": "11e95f8ec39de8fbdb0a4f1a",
    "verbiage": "APPROVED",
    "void_date": "2021-12-01",
    "batch": "2",
    "terms_agree": true,
    "response_message": null,
    "return_date": "2021-12-01",
    "trx_source_id": 8
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# CC Refund - Terminal

Create a new terminal Credit Card refund transaction

```csharp
CCRefundTerminalAsync(
    Models.V1TransactionsCcRefundTerminalRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TransactionsCcRefundTerminalRequest`](../../doc/models/v1-transactions-cc-refund-terminal-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseAsyncProcessing>`](../../doc/models/response-async-processing.md)

## Example Usage

```csharp
var body = new V1TransactionsCcRefundTerminalRequest();
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.TransactionAmount = 2099;
body.TerminalId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseAsyncProcessing result = await transactionsCreditCardController.CCRefundTerminalAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "AsyncProcessing",
  "data": {
    "async": {
      "code": "406c66c3-21cb-47fb-80fc-843bc42507fb",
      "link": "/v1/async/status/406c66c3-21cb-47fb-80fc-843bc42507fb"
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# CC Refund - Tokenized

Create a new tokenized Credit Card refund transaction

```csharp
CCRefundTokenizedAsync(
    Models.V1TransactionsCcRefundTokenRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TransactionsCcRefundTokenRequest`](../../doc/models/v1-transactions-cc-refund-token-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
var body = new V1TransactionsCcRefundTokenRequest();
body.TransactionAmount = 2099;
body.AccountVaultId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseTransaction result = await transactionsCreditCardController.CCRefundTokenizedAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": "10",
        "account_type": "credit",
        "currency": 840
      }
    ],
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "checkin_date": "2021-12-01",
    "checkout_date": "2021-12-01",
    "clerk_number": "AE1234",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "custom_data": "custom data string",
    "customer_id": "customerid",
    "description": "some description",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "dob_year": "1980"
    },
    "iias_ind": 1,
    "image_front": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "image_back": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "installment": true,
    "installment_number": 1,
    "installment_count": 1,
    "location_api_id": "location-api-id-florida-2",
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "no_show": false,
    "notification_email_address": "johnsmith@smiths.com",
    "order_number": "433659378839",
    "po_number": "555555553123",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "quick_invoice_id": "11e95f8ec39de8fbdb0a4f1a",
    "recurring": false,
    "recurring_number": 1,
    "room_num": "303",
    "room_rate": 95.3,
    "save_account": false,
    "save_account_title": "John Account",
    "subtotal_amount": 599,
    "surcharge_amount": 0,
    "tags": [
      {
        "title": "Walk-in Customer"
      }
    ],
    "tax": 0,
    "tip_amount": 0,
    "transaction_amount": 2099,
    "transaction_api_id": "transaction-payment-abcd123",
    "transaction_c1": "custom-data-1",
    "transaction_c2": "custom-data-2",
    "transaction_c3": "custom-data-3",
    "transaction_c4": "custom-data-4",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "account_holder_name": "smith",
    "account_type": "checking",
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_identifier": "P",
    "ach_sec_code": "C21",
    "advance_deposit": true,
    "auth_amount": 1,
    "auth_code": "BR349K",
    "avs": "BAD",
    "avs_enhanced": "N",
    "cardholder_present": true,
    "card_present": true,
    "check_number": "8520748520963",
    "customer_ip": "192.168.0.10",
    "cvv_response": "N",
    "entry_mode_id": "C",
    "emv_receipt_data": {
      "AID": "a0000000042203",
      "APPLAB": "US Maestro",
      "APPN": "US Maestro",
      "CVM": "Pin Verified",
      "TSI": "e800",
      "TVR": "0800008000"
    },
    "first_six": "545454",
    "last_four": "5454",
    "payment_method": "cc",
    "terminal_serial_number": "1234567890",
    "transaction_settlement_status": null,
    "charge_back_date": "2021-12-01",
    "is_recurring": true,
    "notification_email_sent": "true",
    "par": "Q1J4Z28RKA1EBL470G9XYG90R5D3E",
    "reason_code_id": 1000,
    "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
    "settle_date": "2021-12-01",
    "status_id": 101,
    "transaction_batch_id": "11e95f8ec39de8fbdb0a4f1a",
    "verbiage": "APPROVED",
    "void_date": "2021-12-01",
    "batch": "2",
    "terms_agree": true,
    "response_message": null,
    "return_date": "2021-12-01",
    "trx_source_id": 8
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# CC Sale

Create a new keyed Credit Card sale transaction

```csharp
CCSaleAsync(
    Models.V1TransactionsCcSaleKeyedRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TransactionsCcSaleKeyedRequest`](../../doc/models/v1-transactions-cc-sale-keyed-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
var body = new V1TransactionsCcSaleKeyedRequest();
body.TransactionAmount = 2099;
body.AccountNumber = "account_number4";
body.ExpDate = "0722";

try
{
    ResponseTransaction result = await transactionsCreditCardController.CCSaleAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": "10",
        "account_type": "credit",
        "currency": 840
      }
    ],
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "checkin_date": "2021-12-01",
    "checkout_date": "2021-12-01",
    "clerk_number": "AE1234",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "custom_data": "custom data string",
    "customer_id": "customerid",
    "description": "some description",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "dob_year": "1980"
    },
    "iias_ind": 1,
    "image_front": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "image_back": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "installment": true,
    "installment_number": 1,
    "installment_count": 1,
    "location_api_id": "location-api-id-florida-2",
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "no_show": false,
    "notification_email_address": "johnsmith@smiths.com",
    "order_number": "433659378839",
    "po_number": "555555553123",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "quick_invoice_id": "11e95f8ec39de8fbdb0a4f1a",
    "recurring": false,
    "recurring_number": 1,
    "room_num": "303",
    "room_rate": 95.3,
    "save_account": false,
    "save_account_title": "John Account",
    "subtotal_amount": 599,
    "surcharge_amount": 0,
    "tags": [
      {
        "title": "Walk-in Customer"
      }
    ],
    "tax": 0,
    "tip_amount": 0,
    "transaction_amount": 2099,
    "transaction_api_id": "transaction-payment-abcd123",
    "transaction_c1": "custom-data-1",
    "transaction_c2": "custom-data-2",
    "transaction_c3": "custom-data-3",
    "transaction_c4": "custom-data-4",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "account_holder_name": "smith",
    "account_type": "checking",
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_identifier": "P",
    "ach_sec_code": "C21",
    "advance_deposit": true,
    "auth_amount": 1,
    "auth_code": "BR349K",
    "avs": "BAD",
    "avs_enhanced": "N",
    "cardholder_present": true,
    "card_present": true,
    "check_number": "8520748520963",
    "customer_ip": "192.168.0.10",
    "cvv_response": "N",
    "entry_mode_id": "C",
    "emv_receipt_data": {
      "AID": "a0000000042203",
      "APPLAB": "US Maestro",
      "APPN": "US Maestro",
      "CVM": "Pin Verified",
      "TSI": "e800",
      "TVR": "0800008000"
    },
    "first_six": "545454",
    "last_four": "5454",
    "payment_method": "cc",
    "terminal_serial_number": "1234567890",
    "transaction_settlement_status": null,
    "charge_back_date": "2021-12-01",
    "is_recurring": true,
    "notification_email_sent": "true",
    "par": "Q1J4Z28RKA1EBL470G9XYG90R5D3E",
    "reason_code_id": 1000,
    "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
    "settle_date": "2021-12-01",
    "status_id": 101,
    "transaction_batch_id": "11e95f8ec39de8fbdb0a4f1a",
    "verbiage": "APPROVED",
    "void_date": "2021-12-01",
    "batch": "2",
    "terms_agree": true,
    "response_message": null,
    "return_date": "2021-12-01",
    "trx_source_id": 8
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# CC Sale - Terminal

Create a new terminal Credit Card sale transaction

```csharp
CCSaleTerminalAsync(
    Models.V1TransactionsCcSaleTerminalRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TransactionsCcSaleTerminalRequest`](../../doc/models/v1-transactions-cc-sale-terminal-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseAsyncProcessing>`](../../doc/models/response-async-processing.md)

## Example Usage

```csharp
var body = new V1TransactionsCcSaleTerminalRequest();
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.TransactionAmount = 2099;
body.TerminalId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseAsyncProcessing result = await transactionsCreditCardController.CCSaleTerminalAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "AsyncProcessing",
  "data": {
    "async": {
      "code": "406c66c3-21cb-47fb-80fc-843bc42507fb",
      "link": "/v1/async/status/406c66c3-21cb-47fb-80fc-843bc42507fb"
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# CC Sale - Tokenized

Create a new tokenized Credit Card sale transaction

```csharp
CCSaleTokenizedAsync(
    Models.V1TransactionsCcSaleTokenRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TransactionsCcSaleTokenRequest`](../../doc/models/v1-transactions-cc-sale-token-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
var body = new V1TransactionsCcSaleTokenRequest();
body.TransactionAmount = 2099;
body.AccountVaultId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseTransaction result = await transactionsCreditCardController.CCSaleTokenizedAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": "10",
        "account_type": "credit",
        "currency": 840
      }
    ],
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "street": "43155 Main Street STE 2310-C",
      "phone": "3339998822"
    },
    "checkin_date": "2021-12-01",
    "checkout_date": "2021-12-01",
    "clerk_number": "AE1234",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "custom_data": "custom data string",
    "customer_id": "customerid",
    "description": "some description",
    "identity_verification": {
      "dl_state": "MI",
      "dl_number": "1235567",
      "dob_year": "1980"
    },
    "iias_ind": 1,
    "image_front": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "image_back": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    "installment": true,
    "installment_number": 1,
    "installment_count": 1,
    "location_api_id": "location-api-id-florida-2",
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "no_show": false,
    "notification_email_address": "johnsmith@smiths.com",
    "order_number": "433659378839",
    "po_number": "555555553123",
    "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "quick_invoice_id": "11e95f8ec39de8fbdb0a4f1a",
    "recurring": false,
    "recurring_number": 1,
    "room_num": "303",
    "room_rate": 95.3,
    "save_account": false,
    "save_account_title": "John Account",
    "subtotal_amount": 599,
    "surcharge_amount": 0,
    "tags": [
      {
        "title": "Walk-in Customer"
      }
    ],
    "tax": 0,
    "tip_amount": 0,
    "transaction_amount": 2099,
    "transaction_api_id": "transaction-payment-abcd123",
    "transaction_c1": "custom-data-1",
    "transaction_c2": "custom-data-2",
    "transaction_c3": "custom-data-3",
    "transaction_c4": "custom-data-4",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "account_holder_name": "smith",
    "account_type": "checking",
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_identifier": "P",
    "ach_sec_code": "C21",
    "advance_deposit": true,
    "auth_amount": 1,
    "auth_code": "BR349K",
    "avs": "BAD",
    "avs_enhanced": "N",
    "cardholder_present": true,
    "card_present": true,
    "check_number": "8520748520963",
    "customer_ip": "192.168.0.10",
    "cvv_response": "N",
    "entry_mode_id": "C",
    "emv_receipt_data": {
      "AID": "a0000000042203",
      "APPLAB": "US Maestro",
      "APPN": "US Maestro",
      "CVM": "Pin Verified",
      "TSI": "e800",
      "TVR": "0800008000"
    },
    "first_six": "545454",
    "last_four": "5454",
    "payment_method": "cc",
    "terminal_serial_number": "1234567890",
    "transaction_settlement_status": null,
    "charge_back_date": "2021-12-01",
    "is_recurring": true,
    "notification_email_sent": "true",
    "par": "Q1J4Z28RKA1EBL470G9XYG90R5D3E",
    "reason_code_id": 1000,
    "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
    "settle_date": "2021-12-01",
    "status_id": 101,
    "transaction_batch_id": "11e95f8ec39de8fbdb0a4f1a",
    "verbiage": "APPROVED",
    "void_date": "2021-12-01",
    "batch": "2",
    "terms_agree": true,
    "response_message": null,
    "return_date": "2021-12-01",
    "trx_source_id": 8
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |

