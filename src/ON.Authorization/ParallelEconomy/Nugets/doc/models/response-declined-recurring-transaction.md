
# Response Declined Recurring Transaction

## Structure

`ResponseDeclinedRecurringTransaction`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"DeclinedRecurringTransaction"` |
| `Data` | [`Data3`](../../doc/models/data-3.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "DeclinedRecurringTransaction",
  "data": {
    "id": "id0",
    "declined_transaction_id": "declined_transaction_id6",
    "payment_transaction_id": "payment_transaction_id4",
    "status": "paid",
    "recurring_id": "recurring_id4"
  }
}
```

