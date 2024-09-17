
# Response Transaction Intention

## Structure

`ResponseTransactionIntention`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"TransactionIntention"` |
| `Data` | [`Data8`](../../doc/models/data-8.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "TransactionIntention",
  "data": {
    "action": "refund",
    "digitalWalletsOnly": false,
    "methods": [
      {
        "type": "ach",
        "product_transaction_id": "product_transaction_id4"
      }
    ],
    "amount": 158,
    "tax_amount": 62,
    "client_token": "client_token0"
  }
}
```

