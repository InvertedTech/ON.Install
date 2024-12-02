
# Response Declined Recurring Transaction Payment

## Structure

`ResponseDeclinedRecurringTransactionPayment`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"DeclinedRecurringTransactionPayment"` |
| `Data` | [`Data4`](../../doc/models/data-4.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "DeclinedRecurringTransactionPayment",
  "data": {
    "declined_recurring_transaction_id": "declined_recurring_transaction_id6",
    "account_number": "account_number0",
    "account_holder_name": "account_holder_name0",
    "exp_date": "exp_date8",
    "transaction_amount": 88,
    "description": "description0",
    "billing_address": {
      "postal_code": "postal_code0",
      "street": "street8",
      "city": "city2",
      "state": "state6",
      "phone": "phone2"
    },
    "tags": [
      "tags5",
      "tags6",
      "tags7"
    ],
    "id": "id0",
    "first_six": "first_six4",
    "last_four": "last_four4"
  }
}
```

