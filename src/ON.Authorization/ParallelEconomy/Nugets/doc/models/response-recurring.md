
# Response Recurring

## Structure

`ResponseRecurring`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"Recurring"` |
| `Data` | [`Data16`](../../doc/models/data-16.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "Recurring",
  "data": {
    "account_vault_id": "account_vault_id6",
    "token_id": "token_id4",
    "contact_id": "contact_id4",
    "account_vault_api_id": "account_vault_api_id4",
    "token_api_id": "token_api_id6",
    "active": false,
    "interval": 190,
    "interval_type": "m",
    "location_id": "location_id4",
    "payment_method": "cc",
    "start_date": "start_date4",
    "status": "ended",
    "transaction_amount": 88,
    "id": "id0",
    "next_run_date": "next_run_date8",
    "created_ts": 114,
    "modified_ts": 190,
    "recurring_type_id": "o",
    "created_user_id": "created_user_id2"
  }
}
```

