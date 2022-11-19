# Batches

Any user with the available permissions can perform a request to manually settle a transaction batch. This is done by using the transactionbatches endpoint with an action of "settle".

```csharp
BatchesController batchesController = client.BatchesController;
```

## Class Name

`BatchesController`

## Methods

* [View Single Batch](../../doc/controllers/batches.md#view-single-batch)
* [List All Batches](../../doc/controllers/batches.md#list-all-batches)
* [Settle a Batch](../../doc/controllers/batches.md#settle-a-batch)


# View Single Batch

View Single Batch

```csharp
ViewSingleBatchAsync(
    string batchId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `batchId` | `string` | Template, Required | Batch ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseBatch>`](../../doc/models/response-batch.md)

## Example Usage

```csharp
string batchId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseBatch result = await batchesController.ViewSingleBatchAsync(batchId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Batch",
  "data": {
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "processing_status_id": 2,
    "batch_num": 4,
    "is_open": 0,
    "settlement_file_name": "settement_file.txt",
    "batch_close_ts": 1531423693,
    "batch_close_detail": "BATCH_MISMATCH",
    "total_sale_amount": 2342.45,
    "total_sale_count": 21,
    "total_refund_amount": 2342.45,
    "total_refund_count": 18,
    "total_void_amount": 2342.45,
    "total_void_count": 17
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# List All Batches

List All Batches

```csharp
ListAllBatchesAsync(
    Models.Page page = null,
    Models.Sort sort = null,
    Models.Filter filter = null,
    List<string> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Models.Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `sort` | [`Models.Sort`](../../doc/models/sort.md) | Query, Optional | You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods:<br><br>> /endpoint?sort={ "field_name": "asc", "field_name2": "desc" }<br>> <br>> /endpoint?sort[field_name]=asc&sort[field_name2]=desc |
| `filter` | [`Models.Filter`](../../doc/models/filter.md) | Query, Optional | You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods:<br><br>> /endpoint?filter={ "field_name": "Value" }<br>> <br>> /endpoint?filter[field_name]=Value |
| `expand` | `List<string>` | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request.<br>**Constraints**: *Unique Items Required*, *Pattern*: `^[\w]+$` |

## Response Type

[`Task<Models.ResponseBatchsCollection>`](../../doc/models/response-batchs-collection.md)

## Example Usage

```csharp
try
{
    ResponseBatchsCollection result = await batchesController.ListAllBatchesAsync(null, null, null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "BatchsCollection",
  "list": [
    {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "processing_status_id": 2,
      "batch_num": 4,
      "is_open": 0,
      "settlement_file_name": "settement_file.txt",
      "batch_close_ts": 1531423693,
      "batch_close_detail": "BATCH_MISMATCH",
      "total_sale_amount": 2342.45,
      "total_sale_count": 21,
      "total_refund_amount": 2342.45,
      "total_refund_count": 18,
      "total_void_amount": 2342.45,
      "total_void_count": 17
    }
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Settle a Batch

Settle a Batch

```csharp
SettleABatchAsync(
    string batchId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `batchId` | `string` | Template, Required | Batch ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseAsyncProcessing>`](../../doc/models/response-async-processing.md)

## Example Usage

```csharp
string batchId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseAsyncProcessing result = await batchesController.SettleABatchAsync(batchId);
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

