
# V1 Transactions Level 3 Visa Request

## Structure

`V1TransactionsLevel3VisaRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Level3Data` | [`Level3Data6`](../../doc/models/level-3-data-6.md) | Required | Level 3 data object |

## Example (as JSON)

```json
{
  "level3_data": {
    "destination_country_code": "840",
    "duty_amount": 0,
    "freight_amount": 0,
    "national_tax": 2,
    "sales_tax": 200,
    "shipfrom_zip_code": "AZ1234",
    "shipto_zip_code": "FL1234",
    "tax_amount": 10,
    "tax_exempt": "0",
    "customer_vat_registration": "12345678",
    "merchant_vat_registration": "123456",
    "order_date": "171006",
    "summary_commodity_code": "C1K2",
    "tax_rate": 0,
    "unique_vat_ref_number": "vat1234",
    "line_items": [
      {
        "description": "cool drink",
        "commodity_code": "cc123456",
        "discount_amount": 0,
        "other_tax_amount": 0,
        "product_code": "fanta123456",
        "quantity": 12,
        "tax_amount": 4,
        "tax_rate": 0,
        "unit_code": "gll",
        "unit_cost": 3
      }
    ]
  }
}
```

