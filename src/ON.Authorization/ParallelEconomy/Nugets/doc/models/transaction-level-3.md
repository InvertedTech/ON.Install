
# Transaction Level 3

Transaction Level3 Information on `expand`

## Structure

`TransactionLevel3`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Required | Level 3 ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `TransactionId` | `string` | Required | Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Level3Data` | [`Level3Data`](../../doc/models/level-3-data.md) | Required | Level 3 data object |

## Example (as JSON)

```json
{
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
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
        "unit_cost": 3,
        "alternate_tax_id": "1234",
        "debit_credit": "C",
        "discount_rate": 11,
        "tax_type_applied": "22",
        "tax_type_id": "11"
      }
    ]
  }
}
```

