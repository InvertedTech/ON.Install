
# Level 3 Data 5

Level 3 data object

## Structure

`Level3Data5`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `DestinationCountryCode` | `string` | Optional | Code of the country where the goods are being shipped.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |
| `DutyAmount` | `int?` | Optional | Fee amount associated with the import of the purchased goods ,Can accept Two (2) decimal places<br>**Constraints**: `>= 0`, `<= 99999999999999` |
| `FreightAmount` | `int?` | Optional | Freight or shipping portion of the total transaction amount ,Can accept Two (2) decimal places.<br>**Constraints**: `>= 0`, `<= 99999999999999` |
| `NationalTax` | `int?` | Optional | National tax for the transaction ,Can accept Two (2) decimal places.<br>**Constraints**: `<= 999999999999` |
| `SalesTax` | `int?` | Optional | Sales tax for the transaction ,Can accept Two (2) decimal places.<br>**Constraints**: `<= 999999999999` |
| `ShipfromZipCode` | `string` | Optional | Postal/ZIP code of the address from where the purchased goods are being shipped.<br>**Constraints**: *Maximum Length*: `10` |
| `ShiptoZipCode` | `string` | Optional | Postal/ZIP code of the address where purchased goods will be delivered.<br>**Constraints**: *Maximum Length*: `10` |
| `TaxAmount` | `int?` | Optional | Amount of any value added taxes ,Can accept Two (2) decimal places.<br>**Constraints**: `>= 0`, `<= 99999999999` |
| `TaxExempt` | [`TaxExemptEnum?`](../../doc/models/tax-exempt-enum.md) | Optional | Sales Tax Exempt. Allowed values: “1”, “0”. |
| `LineItems` | [`List<LineItem5>`](../../doc/models/line-item-5.md) | Required | Array of line items in transaction |

## Example (as JSON)

```json
{
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
```

