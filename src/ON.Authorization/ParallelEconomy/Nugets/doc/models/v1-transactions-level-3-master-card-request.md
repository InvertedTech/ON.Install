
# V1 Transactions Level 3 Master Card Request

## Structure

`V1TransactionsLevel3MasterCardRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Level3Data` | [`Level3Data5`](../../doc/models/level-3-data-5.md) | Required | Level 3 data object |

## Example (as JSON)

```json
{
  "level3_data": {
    "destination_country_code": "840",
    "duty_amount": 0,
    "freight_amount": 0,
    "national_tax": 2,
    "sales_tax": 200,
    "shipfrom_zip_code": "AZ12345",
    "shipto_zip_code": "MI48335",
    "tax_amount": 0,
    "tax_exempt": "0",
    "line_items": [
      {
        "alternate_tax_id": "1234",
        "debit_credit": "C",
        "description": "cool drink",
        "discount_amount": 10,
        "discount_rate": 11,
        "product_code": "coke12345678",
        "quantity": 5,
        "tax_amount": 3,
        "tax_rate": 0,
        "tax_type_applied": "22",
        "tax_type_id": "11",
        "unit_code": "gll",
        "unit_cost": 10
      }
    ]
  }
}
```

