
# Level 3 Data 4

Level 3 data object

## Structure

`Level3Data4`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `DestinationCountryCode` | `string` | Optional | Code of the country where the goods are being shipped.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |
| `DutyAmount` | `double?` | Optional | Fee amount associated with the import of the purchased goods ,Can accept Two (2) decimal places<br>**Constraints**: `>= 0`, `<= 999999999999` |
| `FreightAmount` | `double?` | Optional | Freight or shipping portion of the total transaction amount ,Can accept Two (2) decimal places.<br>**Constraints**: `>= 0`, `<= 999999999999` |
| `NationalTax` | `double?` | Optional | National tax for the transaction ,Can accept Two (2) decimal places.<br>**Constraints**: `<= 9999999999` |
| `SalesTax` | `double?` | Optional | Sales tax for the transaction ,Can accept Two (2) decimal places.<br>**Constraints**: `<= 9999999999` |
| `ShipfromZipCode` | `string` | Optional | Postal/ZIP code of the address from where the purchased goods are being shipped.<br>**Constraints**: *Maximum Length*: `10` |
| `ShiptoZipCode` | `string` | Optional | Postal/ZIP code of the address where purchased goods will be delivered.<br>**Constraints**: *Maximum Length*: `10` |
| `TaxAmount` | `double?` | Optional | Amount of any value added taxes ,Can accept Two (2) decimal places.<br>**Constraints**: `>= 0`, `<= 999999999` |
| `TaxExempt` | [`Models.TaxExemptEnum?`](../../doc/models/tax-exempt-enum.md) | Optional | Sales Tax Exempt. Allowed values: “1”, “0”. |
| `CustomerVatRegistration` | `string` | Optional | Customer VAT Registration<br>**Constraints**: *Maximum Length*: `13` |
| `MerchantVatRegistration` | `string` | Optional | Merchant VAT Registration<br>**Constraints**: *Maximum Length*: `20` |
| `OrderDate` | `string` | Optional | Order Date<br>**Constraints**: *Minimum Length*: `6`, *Maximum Length*: `6` |
| `SummaryCommodityCode` | `string` | Optional | Summary Commodity Code<br>**Constraints**: *Maximum Length*: `4` |
| `TaxRate` | `double?` | Optional | Tax rate used to calculate the sales tax amount, can accept 2 decimal places.<br>**Constraints**: `<= 9999` |
| `UniqueVatRefNumber` | `string` | Optional | Unique VAT Reference Number<br>**Constraints**: *Maximum Length*: `15` |
| `LineItems` | [`List<Models.LineItem4>`](../../doc/models/line-item-4.md) | Required | Array of line items in transaction |

## Example (as JSON)

```json
{
  "line_items": {
    "description": "cool drink",
    "commodity_code": "cc123456",
    "product_code": "fanta123456",
    "unit_code": "gll",
    "unit_cost": 3
  }
}
```

