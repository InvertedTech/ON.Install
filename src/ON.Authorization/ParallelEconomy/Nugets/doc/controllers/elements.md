# Elements

Accept payment methods from around the globe with a single secure, embeddable UI component. For more information, please read the [Elements Documentation](page:elements/overview)

```csharp
ElementsController elementsController = client.ElementsController;
```

## Class Name

`ElementsController`

## Methods

* [Ticket Intention](../../doc/controllers/elements.md#ticket-intention)
* [Transaction Intention](../../doc/controllers/elements.md#transaction-intention)


# Ticket Intention

Elements uses a `TicketIntention` object to represent your intent to tokenize credit card information from a customer.

```csharp
TicketIntentionAsync(
    Models.V1ElementsTicketIntentionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1ElementsTicketIntentionRequest`](../../doc/models/v1-elements-ticket-intention-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTicketIntention>`](../../doc/models/response-ticket-intention.md)

## Example Usage

```csharp
V1ElementsTicketIntentionRequest body = new V1ElementsTicketIntentionRequest
{
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
};

try
{
    ResponseTicketIntention result = await elementsController.TicketIntentionAsync(body);
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
  "type": "TicketIntention",
  "data": {
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "client_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Transaction Intention

Elements uses a `TransactionIntention` object to represent your intent to collect payment from a customer, tracking charge attempts and payment state changes throughout the process.

```csharp
TransactionIntentionAsync(
    Models.V1ElementsTransactionIntentionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1ElementsTransactionIntentionRequest`](../../doc/models/v1-elements-transaction-intention-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransactionIntention>`](../../doc/models/response-transaction-intention.md)

## Example Usage

```csharp
V1ElementsTransactionIntentionRequest body = new V1ElementsTransactionIntentionRequest
{
    Action = ActionEnum.Sale,
    DigitalWalletsOnly = false,
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    AchSecCode = AchSecCodeEnum.WEB,
};

try
{
    ResponseTransactionIntention result = await elementsController.TransactionIntentionAsync(body);
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
  "type": "TransactionIntention",
  "data": {
    "action": "sale",
    "methods": [
      {
        "type": "cc",
        "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_sec_code": "WEB",
    "client_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |

