# Declined Recurring Transactions

```csharp
DeclinedRecurringTransactionsController declinedRecurringTransactionsController = client.DeclinedRecurringTransactionsController;
```

## Class Name

`DeclinedRecurringTransactionsController`

## Methods

* [Get One Declined Recurring Transaction](../../doc/controllers/declined-recurring-transactions.md#get-one-declined-recurring-transaction)
* [List All Declined Recurring Transactions](../../doc/controllers/declined-recurring-transactions.md#list-all-declined-recurring-transactions)
* [Create a Payment](../../doc/controllers/declined-recurring-transactions.md#create-a-payment)
* [Rerun the Transaction](../../doc/controllers/declined-recurring-transactions.md#rerun-the-transaction)
* [Resend the Transaction](../../doc/controllers/declined-recurring-transactions.md#resend-the-transaction)


# Get One Declined Recurring Transaction

```csharp
GetOneDeclinedRecurringTransactionAsync(
    string declinedRecurringTransactionId,
    List<Models.Expand5Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `declinedRecurringTransactionId` | `string` | Template, Required | Id |
| `expand` | [`List<Expand5Enum>`](../../doc/models/expand-5-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseDeclinedRecurringTransaction>`](../../doc/models/response-declined-recurring-transaction.md)

## Example Usage

```csharp
string declinedRecurringTransactionId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseDeclinedRecurringTransaction result = await declinedRecurringTransactionsController.GetOneDeclinedRecurringTransactionAsync(declinedRecurringTransactionId);
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
  "type": "DeclinedRecurringTransaction",
  "data": {
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "status": "paid",
    "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_ts": 1422040992,
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# List All Declined Recurring Transactions

```csharp
ListAllDeclinedRecurringTransactionsAsync(
    Models.Page page = null,
    List<Models.Order19> order = null,
    List<Models.FilterBy> filterBy = null,
    List<Models.Expand5Enum> expand = null,
    Models.Format1Enum? format = null,
    string typeahead = null,
    List<Models.Field28Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `order` | [`List<Order19>`](../../doc/models/order-19.md) | Query, Optional | Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json.<br><br>> /endpoint?order=[{ "key": "created_ts", "operator": "asc"}]<br>> <br>> /endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] |
| `filterBy` | [`List<FilterBy>`](../../doc/models/filter-by.md) | Query, Optional | Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.<br><br>> /endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }]<br>> <br>> /endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }]<br>> <br>> /endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }]<br>> <br>> /endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] |
| `expand` | [`List<Expand5Enum>`](../../doc/models/expand-5-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `format` | [`Format1Enum?`](../../doc/models/format-1-enum.md) | Query, Optional | Reporting format, valid values: csv, tsv |
| `typeahead` | `string` | Query, Optional | You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains. |
| `fields` | [`List<Field28Enum>`](../../doc/models/field-28-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseDeclinedRecurringTransactionsCollection>`](../../doc/models/response-declined-recurring-transactions-collection.md)

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
    ResponseDeclinedRecurringTransactionsCollection result = await declinedRecurringTransactionsController.ListAllDeclinedRecurringTransactionsAsync(
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
  "type": "DeclinedRecurringTransactionsCollection",
  "list": [
    {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "status": "paid",
      "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_ts": 1422040992,
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


# Create a Payment

```csharp
CreateAPaymentAsync(
    Models.V1DeclinedRecurringTransactionPaymentsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1DeclinedRecurringTransactionPaymentsRequest`](../../doc/models/v1-declined-recurring-transaction-payments-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseDeclinedRecurringTransactionPayment>`](../../doc/models/response-declined-recurring-transaction-payment.md)

## Example Usage

```csharp
V1DeclinedRecurringTransactionPaymentsRequest body = new V1DeclinedRecurringTransactionPaymentsRequest
{
    DeclinedRecurringTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    AccountNumber = "5454545454545454",
    ExpDate = "0722",
    TransactionAmount = 0,
    AccountHolderName = "John Doe",
    Description = "Description",
    SaveAccountTitle = "John Account",
};

try
{
    ResponseDeclinedRecurringTransactionPayment result = await declinedRecurringTransactionsController.CreateAPaymentAsync(body);
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
  "type": "DeclinedRecurringTransactionPayment",
  "data": {
    "declined_recurring_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "account_number": "5454545454545454",
    "account_holder_name": "John Doe",
    "exp_date": "0722",
    "transaction_amount": 0,
    "description": "Description",
    "billing_address": {
      "postal_code": "48375",
      "city": "Novi",
      "state": "Michigan",
      "phone": "3339998822",
      "country": "USA"
    },
    "tags": [
      "Walk-in Customer"
    ],
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "first_six": "700953",
    "last_four": "3657",
    "routing": null,
    "reason_code_id": 1000,
    "created_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Rerun the Transaction

```csharp
RerunTheTransactionAsync(
    string declinedRecurringTransactionId,
    List<Models.Expand5Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `declinedRecurringTransactionId` | `string` | Template, Required | Id |
| `expand` | [`List<Expand5Enum>`](../../doc/models/expand-5-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseDeclinedRecurringTransaction>`](../../doc/models/response-declined-recurring-transaction.md)

## Example Usage

```csharp
string declinedRecurringTransactionId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseDeclinedRecurringTransaction result = await declinedRecurringTransactionsController.RerunTheTransactionAsync(declinedRecurringTransactionId);
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
  "type": "DeclinedRecurringTransaction",
  "data": {
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "status": "paid",
    "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_ts": 1422040992,
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Resend the Transaction

```csharp
ResendTheTransactionAsync(
    string declinedRecurringTransactionId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `declinedRecurringTransactionId` | `string` | Template, Required | Id |

## Response Type

[`Task<Models.ResponseDeclinedRecurringTransactionResend>`](../../doc/models/response-declined-recurring-transaction-resend.md)

## Example Usage

```csharp
string declinedRecurringTransactionId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseDeclinedRecurringTransactionResend result = await declinedRecurringTransactionsController.ResendTheTransactionAsync(declinedRecurringTransactionId);
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
  "type": "DeclinedRecurringTransactionResend",
  "data": {
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "email_log_id": "11e95f8ec39de8fbdb0a4f1a",
    "email": "email@domain.com"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |

