
# Response Transaction

## Structure

`ResponseTransaction`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"Transaction"` |
| `Data` | [`Data22`](../../doc/models/data-22.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": 6,
        "account_type": "cash_benefit",
        "currency": 154.64
      },
      {
        "type": "cashback",
        "amount": 6,
        "account_type": "cash_benefit",
        "currency": 154.64
      }
    ],
    "billing_address": {
      "postal_code": "postal_code0",
      "street": "street8",
      "city": "city2",
      "state": "state6",
      "phone": "phone2"
    },
    "checkin_date": "checkin_date2",
    "checkout_date": "checkout_date4",
    "clerk_number": "clerk_number4",
    "id": "id0",
    "created_ts": 114,
    "modified_ts": 190,
    "payment_method": "cc",
    "modified_user_id": "modified_user_id2",
    "hosted_payment_page_id": "hosted_payment_page_id2"
  }
}
```

