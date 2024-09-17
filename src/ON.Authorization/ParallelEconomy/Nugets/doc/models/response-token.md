
# Response Token

## Structure

`ResponseToken`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"Token"` |
| `Data` | [`Data21`](../../doc/models/data-21.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "Token",
  "data": {
    "account_holder_name": "account_holder_name0",
    "account_vault_api_id": "account_vault_api_id4",
    "token_api_id": "token_api_id6",
    "accountvault_c1": "accountvault_c14",
    "accountvault_c2": "accountvault_c28",
    "location_id": "location_id4",
    "id": "id0",
    "account_type": "account_type6",
    "cau_summary_status_id": 2,
    "created_ts": 114,
    "first_six": "first_six4",
    "has_recurring": false,
    "last_four": "last_four4",
    "modified_ts": 190,
    "payment_method": "cc"
  }
}
```

