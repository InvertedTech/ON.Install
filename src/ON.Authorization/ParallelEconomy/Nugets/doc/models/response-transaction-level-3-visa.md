
# Response Transaction Level 3 Visa

## Structure

`ResponseTransactionLevel3Visa`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"TransactionLevel3Visa"` |
| `Data` | [`Data24`](../../doc/models/data-24.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "TransactionLevel3Visa",
  "data": {
    "id": "id0",
    "transaction_id": "transaction_id8",
    "level3_data": {
      "destination_country_code": "destination_country_code4",
      "duty_amount": 182,
      "freight_amount": 60,
      "national_tax": 50,
      "sales_tax": 222,
      "line_items": [
        {
          "description": "description8",
          "commodity_code": "commodity_code0",
          "discount_amount": 10,
          "other_tax_amount": 76,
          "product_code": "product_code4",
          "quantity": 102,
          "tax_amount": 30,
          "tax_rate": 168,
          "unit_code": "unit_code8",
          "unit_cost": 88
        },
        {
          "description": "description8",
          "commodity_code": "commodity_code0",
          "discount_amount": 10,
          "other_tax_amount": 76,
          "product_code": "product_code4",
          "quantity": 102,
          "tax_amount": 30,
          "tax_rate": 168,
          "unit_code": "unit_code8",
          "unit_cost": 88
        },
        {
          "description": "description8",
          "commodity_code": "commodity_code0",
          "discount_amount": 10,
          "other_tax_amount": 76,
          "product_code": "product_code4",
          "quantity": 102,
          "tax_amount": 30,
          "tax_rate": 168,
          "unit_code": "unit_code8",
          "unit_cost": 88
        }
      ]
    }
  }
}
```

