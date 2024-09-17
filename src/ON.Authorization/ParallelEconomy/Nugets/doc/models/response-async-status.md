
# Response Async Status

## Structure

`ResponseAsyncStatus`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"AsyncStatus"` |
| `Data` | [`Data`](../../doc/models/data.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "AsyncStatus",
  "data": {
    "code": "00001e1c-0000-0000-0000-000000000000",
    "type": "type0",
    "id": "id0",
    "progress": 146,
    "error": "error4",
    "ttl": 162
  }
}
```

