
# Response Recurrings Collection

## Structure

`ResponseRecurringsCollection`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"RecurringsCollection"` |
| `List` | [`List<Models.List6>`](../../doc/models/list-6.md) | Required | Resource Members |

## Example (as JSON)

```json
{
  "type": "RecurringsCollection",
  "list": {
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": 1,
    "interval": 1,
    "interval_type": "d",
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "payment_method": "cc",
    "start_date": "2021-12-01",
    "status": "active",
    "transaction_amount": 3,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "next_run_date": "2021-12-01",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "recurring_type_id": "i"
  }
}
```

