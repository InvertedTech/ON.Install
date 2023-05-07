
# Response Tokens Collection

## Structure

`ResponseTokensCollection`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"TokensCollection"` |
| `List` | [`List<Models.List10>`](../../doc/models/list-10.md) | Required | Resource Members |

## Example (as JSON)

```json
{
  "type": "TokensCollection",
  "list": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "account_type": "checking",
    "cau_summary_status_id": 1,
    "created_ts": 1422040992,
    "first_six": "700953",
    "has_recurring": false,
    "last_four": "3657",
    "modified_ts": 1422040992,
    "payment_method": "cc"
  }
}
```

