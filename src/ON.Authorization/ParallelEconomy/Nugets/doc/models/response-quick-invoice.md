
# Response Quick Invoice

## Structure

`ResponseQuickInvoice`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"QuickInvoice"` |
| `Data` | [`Data14`](../../doc/models/data-14.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "QuickInvoice",
  "data": {
    "location_id": "location_id4",
    "title": "title6",
    "cc_product_transaction_id": "cc_product_transaction_id2",
    "ach_product_transaction_id": "ach_product_transaction_id2",
    "due_date": "due_date8",
    "item_list": [
      {
        "name": "name4",
        "amount": 36
      },
      {
        "name": "name4",
        "amount": 36
      }
    ],
    "allow_overpayment": false,
    "bank_funded_only_override": false,
    "id": "id0",
    "created_ts": 114,
    "modified_ts": 190
  }
}
```

