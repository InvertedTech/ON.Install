# Paylinks

```csharp
PaylinksController paylinksController = client.PaylinksController;
```

## Class Name

`PaylinksController`

## Methods

* [Create a New Paylink](../../doc/controllers/paylinks.md#create-a-new-paylink)
* [List All Paylinks](../../doc/controllers/paylinks.md#list-all-paylinks)
* [Delete Paylink](../../doc/controllers/paylinks.md#delete-paylink)
* [View Single Paylink](../../doc/controllers/paylinks.md#view-single-paylink)
* [Update Paylink](../../doc/controllers/paylinks.md#update-paylink)
* [Resend Paylink](../../doc/controllers/paylinks.md#resend-paylink)


# Create a New Paylink

```csharp
CreateANewPaylinkAsync(
    Models.V1PaylinksRequest body,
    List<Models.Expand14Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1PaylinksRequest`](../../doc/models/v1-paylinks-request.md) | Body, Required | - |
| `expand` | [`List<Expand14Enum>`](../../doc/models/expand-14-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponsePaylink>`](../../doc/models/response-paylink.md)

## Example Usage

```csharp
V1PaylinksRequest body = new V1PaylinksRequest
{
    AmountDue = 1,
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    CcProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    Email = "email@domain.com",
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    AchProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    ExpireDate = "2021-12-01",
    DisplayProductTransactionReceiptDetails = true,
    DisplayBillingFields = true,
    DeliveryMethod = DeliveryMethodEnum.Enum0,
    CellPhone = "3339998822",
    Description = "Description",
    StoreToken = false,
    StoreTokenTitle = "John Account",
    BankFundedOnlyOverride = false,
};

try
{
    ResponsePaylink result = await paylinksController.CreateANewPaylinkAsync(body);
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
  "type": "Paylink",
  "data": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "email": "email@domain.com",
    "amount_due": 1,
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "expire_date": "2021-12-01",
    "display_product_transaction_receipt_details": true,
    "display_billing_fields": true,
    "delivery_method": 0,
    "cell_phone": "3339998822",
    "description": "Description",
    "store_token": false,
    "store_token_title": "John Account",
    "bank_funded_only_override": false,
    "tags": [
      "Tag 1"
    ],
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "status_id": true,
    "status_code": 1,
    "active": true,
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
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


# List All Paylinks

```csharp
ListAllPaylinksAsync(
    Models.Page page = null,
    List<Models.Order19> order = null,
    List<Models.FilterBy> filterBy = null,
    List<Models.Expand15Enum> expand = null,
    Models.Format1Enum? format = null,
    string typeahead = null,
    List<Models.Field35Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `order` | [`List<Order19>`](../../doc/models/order-19.md) | Query, Optional | Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json.<br><br>> /endpoint?order=[{ "key": "created_ts", "operator": "asc"}]<br>> <br>> /endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] |
| `filterBy` | [`List<FilterBy>`](../../doc/models/filter-by.md) | Query, Optional | Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.<br><br>> /endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }]<br>> <br>> /endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }]<br>> <br>> /endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }]<br>> <br>> /endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] |
| `expand` | [`List<Expand15Enum>`](../../doc/models/expand-15-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `format` | [`Format1Enum?`](../../doc/models/format-1-enum.md) | Query, Optional | Reporting format, valid values: csv, tsv |
| `typeahead` | `string` | Query, Optional | You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains. |
| `fields` | [`List<Field35Enum>`](../../doc/models/field-35-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponsePaylinksCollection>`](../../doc/models/response-paylinks-collection.md)

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
    ResponsePaylinksCollection result = await paylinksController.ListAllPaylinksAsync(
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
  "type": "PaylinksCollection",
  "list": [
    {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "email": "email@domain.com",
      "amount_due": 1,
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "expire_date": "2021-12-01",
      "display_product_transaction_receipt_details": true,
      "display_billing_fields": true,
      "delivery_method": 0,
      "cell_phone": "3339998822",
      "description": "Description",
      "store_token": false,
      "store_token_title": "John Account",
      "bank_funded_only_override": false,
      "tags": [
        "Tag 1"
      ],
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "status_id": true,
      "status_code": 1,
      "active": true,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
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


# Delete Paylink

```csharp
DeletePaylinkAsync(
    string paylinkId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `paylinkId` | `string` | Template, Required | Paylink Id |

## Response Type

[`Task<Models.ResponsePaylink>`](../../doc/models/response-paylink.md)

## Example Usage

```csharp
string paylinkId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponsePaylink result = await paylinksController.DeletePaylinkAsync(paylinkId);
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
  "type": "Paylink",
  "data": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "email": "email@domain.com",
    "amount_due": 1,
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "expire_date": "2021-12-01",
    "display_product_transaction_receipt_details": true,
    "display_billing_fields": true,
    "delivery_method": 0,
    "cell_phone": "3339998822",
    "description": "Description",
    "store_token": false,
    "store_token_title": "John Account",
    "bank_funded_only_override": false,
    "tags": [
      "Tag 1"
    ],
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "status_id": true,
    "status_code": 1,
    "active": true,
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# View Single Paylink

```csharp
ViewSinglePaylinkAsync(
    string paylinkId,
    List<Models.Expand15Enum> expand = null,
    List<Models.Field35Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `paylinkId` | `string` | Template, Required | Paylink Id |
| `expand` | [`List<Expand15Enum>`](../../doc/models/expand-15-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `fields` | [`List<Field35Enum>`](../../doc/models/field-35-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponsePaylink>`](../../doc/models/response-paylink.md)

## Example Usage

```csharp
string paylinkId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponsePaylink result = await paylinksController.ViewSinglePaylinkAsync(paylinkId);
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
  "type": "Paylink",
  "data": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "email": "email@domain.com",
    "amount_due": 1,
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "expire_date": "2021-12-01",
    "display_product_transaction_receipt_details": true,
    "display_billing_fields": true,
    "delivery_method": 0,
    "cell_phone": "3339998822",
    "description": "Description",
    "store_token": false,
    "store_token_title": "John Account",
    "bank_funded_only_override": false,
    "tags": [
      "Tag 1"
    ],
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "status_id": true,
    "status_code": 1,
    "active": true,
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Update Paylink

```csharp
UpdatePaylinkAsync(
    string paylinkId,
    Models.V1PaylinksRequest1 body,
    List<Models.Expand14Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `paylinkId` | `string` | Template, Required | Paylink Id |
| `body` | [`V1PaylinksRequest1`](../../doc/models/v1-paylinks-request-1.md) | Body, Required | - |
| `expand` | [`List<Expand14Enum>`](../../doc/models/expand-14-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponsePaylink>`](../../doc/models/response-paylink.md)

## Example Usage

```csharp
string paylinkId = "11e95f8ec39de8fbdb0a4f1a";
V1PaylinksRequest1 body = new V1PaylinksRequest1
{
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    CcProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    Email = "email@domain.com",
    AmountDue = 1,
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    AchProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    ExpireDate = "2021-12-01",
    DisplayProductTransactionReceiptDetails = true,
    DisplayBillingFields = true,
    DeliveryMethod = DeliveryMethodEnum.Enum0,
    CellPhone = "3339998822",
    Description = "Description",
    StoreToken = false,
    StoreTokenTitle = "John Account",
    BankFundedOnlyOverride = false,
};

try
{
    ResponsePaylink result = await paylinksController.UpdatePaylinkAsync(
        paylinkId,
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
  "type": "Paylink",
  "data": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "email": "email@domain.com",
    "amount_due": 1,
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "expire_date": "2021-12-01",
    "display_product_transaction_receipt_details": true,
    "display_billing_fields": true,
    "delivery_method": 0,
    "cell_phone": "3339998822",
    "description": "Description",
    "store_token": false,
    "store_token_title": "John Account",
    "bank_funded_only_override": false,
    "tags": [
      "Tag 1"
    ],
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "status_id": true,
    "status_code": 1,
    "active": true,
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
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


# Resend Paylink

```csharp
ResendPaylinkAsync(
    string paylinkId,
    List<Models.Expand14Enum> expand = null,
    Models.EmailEnum? email = null,
    Models.SmsEnum? sms = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `paylinkId` | `string` | Template, Required | Paylink Id |
| `expand` | [`List<Expand14Enum>`](../../doc/models/expand-14-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `email` | [`EmailEnum?`](../../doc/models/email-enum.md) | Query, Optional | Resend Email |
| `sms` | [`SmsEnum?`](../../doc/models/sms-enum.md) | Query, Optional | Resend SMS |

## Response Type

[`Task<Models.ResponsePaylink>`](../../doc/models/response-paylink.md)

## Example Usage

```csharp
string paylinkId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponsePaylink result = await paylinksController.ResendPaylinkAsync(paylinkId);
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
  "type": "Paylink",
  "data": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "email": "email@domain.com",
    "amount_due": 1,
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "expire_date": "2021-12-01",
    "display_product_transaction_receipt_details": true,
    "display_billing_fields": true,
    "delivery_method": 0,
    "cell_phone": "3339998822",
    "description": "Description",
    "store_token": false,
    "store_token_title": "John Account",
    "bank_funded_only_override": false,
    "tags": [
      "Tag 1"
    ],
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "status_id": true,
    "status_code": 1,
    "active": true,
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |

