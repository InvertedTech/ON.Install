# Transactions - Updates

```csharp
TransactionsUpdatesController transactionsUpdatesController = client.TransactionsUpdatesController;
```

## Class Name

`TransactionsUpdatesController`

## Methods

* [Auth Complete](../../doc/controllers/transactions-updates.md#auth-complete)
* [Auth Increment](../../doc/controllers/transactions-updates.md#auth-increment)
* [Partial Reversal](../../doc/controllers/transactions-updates.md#partial-reversal)
* [Refund Transaction](../../doc/controllers/transactions-updates.md#refund-transaction)
* [Tip Adjustment](../../doc/controllers/transactions-updates.md#tip-adjustment)
* [Void](../../doc/controllers/transactions-updates.md#void)


# Auth Complete

Perform an auth complete transaction

```csharp
AuthCompleteAsync(
    string transactionId,
    Models.V1TransactionsAuthCompleteRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `transactionId` | `string` | Template, Required | Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1TransactionsAuthCompleteRequest`](../../doc/models/v1-transactions-auth-complete-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
string transactionId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1TransactionsAuthCompleteRequest();
body.TransactionAmount = 2099;

try
{
    ResponseTransaction result = await transactionsUpdatesController.AuthCompleteAsync(transactionId, body);
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


# Auth Increment

Perform an auth increment transaction

```csharp
AuthIncrementAsync(
    string transactionId,
    Models.V1TransactionsAuthIncrementRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `transactionId` | `string` | Template, Required | Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1TransactionsAuthIncrementRequest`](../../doc/models/v1-transactions-auth-increment-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
string transactionId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1TransactionsAuthIncrementRequest();
body.TransactionAmount = 2099;

try
{
    ResponseTransaction result = await transactionsUpdatesController.AuthIncrementAsync(transactionId, body);
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


# Partial Reversal

Perform a partial reversal

```csharp
PartialReversalAsync(
    string transactionId,
    Models.V1TransactionsPartialReversalRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `transactionId` | `string` | Template, Required | Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1TransactionsPartialReversalRequest`](../../doc/models/v1-transactions-partial-reversal-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
string transactionId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1TransactionsPartialReversalRequest();
body.TransactionAmount = 2099;

try
{
    ResponseTransaction result = await transactionsUpdatesController.PartialReversalAsync(transactionId, body);
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


# Refund Transaction

Perform a refund transaction

```csharp
RefundTransactionAsync(
    string transactionId,
    Models.V1TransactionsRefundRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `transactionId` | `string` | Template, Required | Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1TransactionsRefundRequest`](../../doc/models/v1-transactions-refund-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
string transactionId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1TransactionsRefundRequest();
body.TransactionAmount = 2099;

try
{
    ResponseTransaction result = await transactionsUpdatesController.RefundTransactionAsync(transactionId, body);
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


# Tip Adjustment

Increment the authorized transaction amount to include a tip

```csharp
TipAdjustmentAsync(
    string transactionId,
    Models.V1TransactionsTipAdjustRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `transactionId` | `string` | Template, Required | Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1TransactionsTipAdjustRequest`](../../doc/models/v1-transactions-tip-adjust-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
string transactionId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1TransactionsTipAdjustRequest();
body.TipAmount = 44.08;
body.TransactionAmount = 2099;

try
{
    ResponseTransaction result = await transactionsUpdatesController.TipAdjustmentAsync(transactionId, body);
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


# Void

Void a transaction

```csharp
VoidAsync(
    string transactionId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `transactionId` | `string` | Template, Required | Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
string transactionId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseTransaction result = await transactionsUpdatesController.VoidAsync(transactionId);
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

