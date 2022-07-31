# Transactions - Read

```csharp
TransactionsReadController transactionsReadController = client.TransactionsReadController;
```

## Class Name

`TransactionsReadController`

## Methods

* [Get BIN Info](../../doc/controllers/transactions-read.md#get-bin-info)
* [Get Transaction](../../doc/controllers/transactions-read.md#get-transaction)
* [List Transactions](../../doc/controllers/transactions-read.md#list-transactions)


# Get BIN Info

Get BIN info record associated with a transaction

```csharp
GetBINInfoAsync(
    string transactionId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `transactionId` | `string` | Template, Required | - |

## Response Type

[`Task<Models.ResponseTransactionBinInfo>`](../../doc/models/response-transaction-bin-info.md)

## Example Usage

```csharp
string transactionId = "transaction_id8";

try
{
    ResponseTransactionBinInfo result = await transactionsReadController.GetBINInfoAsync(transactionId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "TransactionBinInfo",
  "data": {
    "issuer_bank_name": "Cartasi S.P.A.",
    "country_code": "US",
    "detail_card_product": "V",
    "detail_card_indicator": "X",
    "fsa_indicator": "F",
    "prepaid_indicator": "P",
    "product_id": "G",
    "regulator_indicator": "N",
    "visa_product_sub_type": null,
    "visa_large_ticket_indicator": null,
    "account_fund_source": "C",
    "card_class": "B",
    "token_ind": null,
    "issuing_network": null
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Get Transaction

Get single transaction record

```csharp
GetTransactionAsync(
    string transactionId,
    List<string> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `transactionId` | `string` | Template, Required | Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `expand` | `List<string>` | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request.<br>**Constraints**: *Unique Items Required*, *Pattern*: `^[\w]+$` |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
string transactionId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseTransaction result = await transactionsReadController.GetTransactionAsync(transactionId, null);
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


# List Transactions

List transactions

```csharp
ListTransactionsAsync(
    Models.Page page = null,
    Models.Sort11 sort = null,
    Models.Filter11 filter = null,
    List<string> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Models.Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `sort` | [`Models.Sort11`](../../doc/models/sort-11.md) | Query, Optional | You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods:<br><br>> /endpoint?sort={ "field_name": "asc", "field_name2": "desc" }<br>> <br>> /endpoint?sort[field_name]=asc&sort[field_name2]=desc |
| `filter` | [`Models.Filter11`](../../doc/models/filter-11.md) | Query, Optional | You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods:<br><br>> /endpoint?filter={ "field_name": "Value" }<br>> <br>> /endpoint?filter[field_name]=Value |
| `expand` | `List<string>` | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request.<br>**Constraints**: *Unique Items Required*, *Pattern*: `^[\w]+$` |

## Response Type

[`Task<Models.ResponseTransactionsCollection>`](../../doc/models/response-transactions-collection.md)

## Example Usage

```csharp
try
{
    ResponseTransactionsCollection result = await transactionsReadController.ListTransactionsAsync(null, null, null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "TransactionsCollection",
  "list": [
    {
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
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |

