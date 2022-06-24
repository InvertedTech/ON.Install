
# Response Location Infos Collection

## Structure

`ResponseLocationInfosCollection`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"LocationInfosCollection"` |
| `List` | [`List<Models.List3>`](../../doc/models/list-3.md) | Required | Resource Members |

## Example (as JSON)

```json
{
  "type": "LocationInfosCollection",
  "list": {
    "created_ts": 1422040992,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_ts": 1422040992,
    "name": "Sample Company Headquarters",
    "parent_id": "11e95f8ec39de8fbdb0a4f1a",
    "branding_domain": null,
    "product_transactions": null,
    "product_file": null,
    "product_accountvault": null,
    "product_recurring": null,
    "tags": null,
    "terminals": null
  }
}
```

