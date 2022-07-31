
# Response Locations Collection

## Structure

`ResponseLocationsCollection`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"LocationsCollection"` |
| `List` | [`List<Models.List4>`](../../doc/models/list-4.md) | Required | Resource Members |

## Example (as JSON)

```json
{
  "type": "LocationsCollection",
  "list": {
    "created_ts": 1422040992,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_ts": 1422040992,
    "name": "Sample Company Headquarters",
    "parent_id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

