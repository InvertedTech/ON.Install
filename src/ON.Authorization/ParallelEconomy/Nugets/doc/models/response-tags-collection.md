
# Response Tags Collection

## Structure

`ResponseTagsCollection`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"TagsCollection"` |
| `List` | [`List<Models.List8>`](../../doc/models/list-8.md) | Required | Resource Members |

## Example (as JSON)

```json
{
  "type": "TagsCollection",
  "list": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "title": "My terminal",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992
  }
}
```

