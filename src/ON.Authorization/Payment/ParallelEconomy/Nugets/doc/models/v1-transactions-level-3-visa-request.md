
# V1 Transactions Level 3 Visa Request

## Structure

`V1TransactionsLevel3VisaRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Level3Data` | [`Models.Level3Data4`](../../doc/models/level-3-data-4.md) | Required | Level 3 data object |

## Example (as JSON)

```json
{
  "level3_data": {
    "line_items": {
      "description": "cool drink",
      "commodity_code": "cc123456",
      "product_code": "fanta123456",
      "unit_code": "gll",
      "unit_cost": 3
    }
  }
}
```

