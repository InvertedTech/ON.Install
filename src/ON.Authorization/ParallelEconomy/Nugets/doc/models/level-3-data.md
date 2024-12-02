
# Level 3 Data

Level 3 data object

## Structure

`Level3Data`

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
| `CustomerVatRegistration` | `string` | Optional | Customer VAT Registration<br>**Constraints**: *Maximum Length*: `13` |
| `MerchantVatRegistration` | `string` | Optional | Merchant VAT Registration<br>**Constraints**: *Maximum Length*: `20` |
| `OrderDate` | `string` | Optional | Order Date<br>**Constraints**: *Minimum Length*: `6`, *Maximum Length*: `6` |
| `SummaryCommodityCode` | `string` | Optional | Summary Commodity Code<br>**Constraints**: *Maximum Length*: `4` |
| `TaxRate` | `int?` | Optional | Tax rate used to calculate the sales tax amount, can accept 2 decimal places.<br>**Constraints**: `<= 999999` |
| `UniqueVatRefNumber` | `string` | Optional | Unique VAT Reference Number<br>**Constraints**: *Maximum Length*: `15` |
| `LineItems` | [`List<LineItem>`](../../doc/models/line-item.md) | Required | Array of line items in transaction |

## Example (as JSON)

```json
{
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
```

