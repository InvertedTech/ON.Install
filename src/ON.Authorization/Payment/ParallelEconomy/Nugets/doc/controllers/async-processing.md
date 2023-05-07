# Async Processing

Used for endpoints that can take more than 20 seconds to process.

```csharp
AsyncProcessingController asyncProcessingController = client.AsyncProcessingController;
```

## Class Name

`AsyncProcessingController`


# Status Check

Retrieve the current status for a particular code.

```csharp
StatusCheckAsync(
    Guid statusCode)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `statusCode` | `Guid` | Template, Required | A [UUID v4](https://datatracker.ietf.org/doc/html/rfc4122) that's unique for the Async Request |

## Response Type

[`Task<Models.ResponseAsyncStatus>`](../../doc/models/response-async-status.md)

## Example Usage

```csharp
Guid statusCode = new Guid("406c66c3-21cb-47fb-80fc-843bc42507fb");

try
{
    ResponseAsyncStatus result = await asyncProcessingController.StatusCheckAsync(statusCode);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "AsyncStatus",
  "data": {
    "code": "406c66c3-21cb-47fb-80fc-843bc42507fb",
    "type": "Transaction",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "progress": 100,
    "error": null,
    "ttl": 7956886942
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |

