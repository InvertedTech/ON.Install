
# V1 Transactions Level 3 Master Card Request

## Structure

`V1TransactionsLevel3MasterCardRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Level3Data` | [`Models.Level3Data3`](../../doc/models/level-3-data-3.md) | Required | Level 3 data object |

## Example (as JSON)

```json
{
  "level3_data": {
    "line_items": {
      "description": "cool drink",
      "product_code": "coke12345678",
      "unit_code": "gll",
      "unit_cost": 10
    }
  }
}
```

