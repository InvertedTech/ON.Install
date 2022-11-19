
# Response Batchs Collection

## Structure

`ResponseBatchsCollection`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"BatchsCollection"` |
| `List` | [`List<Models.List>`](../../doc/models/list.md) | Required | Resource Members |

## Example (as JSON)

```json
{
  "type": "BatchsCollection",
  "list": {
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "processing_status_id": 2
  }
}
```

