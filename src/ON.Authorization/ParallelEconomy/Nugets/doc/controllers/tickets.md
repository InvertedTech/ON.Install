# Tickets

The tickets endpoint is used as a single use cc only token generation endpoint. If there is a need to store card numbers with cvv for a one time use, then this is the endpoint to perform that task.  Transactions run with the generated ticket_id can save card information for later with save_account.

```csharp
TicketsController ticketsController = client.TicketsController;
```

## Class Name

`TicketsController`

## Methods

* [Create a Ticket Record](../../doc/controllers/tickets.md#create-a-ticket-record)
* [List All Tickets Related](../../doc/controllers/tickets.md#list-all-tickets-related)
* [View Single Ticket Record](../../doc/controllers/tickets.md#view-single-ticket-record)


# Create a Ticket Record

```csharp
CreateATicketRecordAsync(
    Models.V1TicketsRequest body,
    List<Models.Expand41Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1TicketsRequest`](../../doc/models/v1-tickets-request.md) | Body, Required | - |
| `expand` | [`List<Expand41Enum>`](../../doc/models/expand-41-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseTicket>`](../../doc/models/response-ticket.md)

## Example Usage

```csharp
V1TicketsRequest body = new V1TicketsRequest
{
    ExpDate = "0722",
    AccountNumber = "545454545454545",
    AccountHolderName = "John Smith",
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
};

try
{
    ResponseTicket result = await ticketsController.CreateATicketRecordAsync(body);
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
  "type": "Ticket",
  "data": {
    "account_holder_name": "John Smith",
    "exp_date": "0722",
    "cvv": null,
    "account_number": "545454545454545",
    "billing_address": {
      "postal_code": "48375"
    },
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "location_api_id": null,
    "id": "11e95f8ec39de8fbdb0a4f1a",
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


# List All Tickets Related

```csharp
ListAllTicketsRelatedAsync(
    Models.Page page = null,
    List<Models.Order19> order = null,
    List<Models.FilterBy> filterBy = null,
    List<Models.Expand41Enum> expand = null,
    Models.Format1Enum? format = null,
    string typeahead = null,
    List<Models.Field47Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `order` | [`List<Order19>`](../../doc/models/order-19.md) | Query, Optional | Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json.<br><br>> /endpoint?order=[{ "key": "created_ts", "operator": "asc"}]<br>> <br>> /endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] |
| `filterBy` | [`List<FilterBy>`](../../doc/models/filter-by.md) | Query, Optional | Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.<br><br>> /endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }]<br>> <br>> /endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }]<br>> <br>> /endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }]<br>> <br>> /endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] |
| `expand` | [`List<Expand41Enum>`](../../doc/models/expand-41-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `format` | [`Format1Enum?`](../../doc/models/format-1-enum.md) | Query, Optional | Reporting format, valid values: csv, tsv |
| `typeahead` | `string` | Query, Optional | You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains. |
| `fields` | [`List<Field47Enum>`](../../doc/models/field-47-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseTicketsCollection>`](../../doc/models/response-tickets-collection.md)

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
    ResponseTicketsCollection result = await ticketsController.ListAllTicketsRelatedAsync(
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
  "type": "TicketsCollection",
  "list": [
    {
      "account_holder_name": "John Smith",
      "exp_date": "0722",
      "cvv": null,
      "account_number": "545454545454545",
      "billing_address": {
        "postal_code": "48375"
      },
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_api_id": null,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
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


# View Single Ticket Record

```csharp
ViewSingleTicketRecordAsync(
    string ticketId,
    List<Models.Expand41Enum> expand = null,
    List<Models.Field47Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ticketId` | `string` | Template, Required | A unique, system-generated identifier for the Ticket. |
| `expand` | [`List<Expand41Enum>`](../../doc/models/expand-41-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `fields` | [`List<Field47Enum>`](../../doc/models/field-47-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseTicket>`](../../doc/models/response-ticket.md)

## Example Usage

```csharp
string ticketId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseTicket result = await ticketsController.ViewSingleTicketRecordAsync(ticketId);
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
  "type": "Ticket",
  "data": {
    "account_holder_name": "John Smith",
    "exp_date": "0722",
    "cvv": null,
    "account_number": "545454545454545",
    "billing_address": {
      "postal_code": "48375"
    },
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "location_api_id": null,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |

