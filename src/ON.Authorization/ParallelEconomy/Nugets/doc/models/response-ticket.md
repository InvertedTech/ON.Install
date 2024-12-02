
# Response Ticket

## Structure

`ResponseTicket`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"Ticket"` |
| `Data` | [`Data20`](../../doc/models/data-20.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "Ticket",
  "data": {
    "account_holder_name": "account_holder_name0",
    "exp_date": "exp_date8",
    "cvv": "cvv8",
    "account_number": "account_number0",
    "billing_address": {
      "postal_code": "postal_code0",
      "street": "street8"
    },
    "contact_id": "contact_id4",
    "contact_api_id": "contact_api_id4",
    "id": "id0",
    "created_ts": 114
  }
}
```

