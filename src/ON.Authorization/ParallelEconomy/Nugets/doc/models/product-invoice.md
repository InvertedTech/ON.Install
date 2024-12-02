
# Product Invoice

Product Invoice Information on `expand`

## Structure

`ProductInvoice`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Title` | `string` | Required | Title<br>**Constraints**: *Maximum Length*: `36` |
| `QuoteNumberFormat` | `string` | Optional | Quote Number Format<br>**Constraints**: *Maximum Length*: `36` |
| `QuoteNumberStart` | `double?` | Optional | Quote Number Start<br>**Constraints**: `>= 1`, `<= 999999999` |
| `QuoteNumberIncrement` | `double?` | Optional | Quote Number Increment<br>**Constraints**: `>= 1`, `<= 999999999` |
| `QuoteNumberCurrent` | `double?` | Optional | Quote Number Current |
| `InvoiceNumberFormat` | `string` | Optional | Invoice Number Format<br>**Constraints**: *Maximum Length*: `36` |
| `InvoiceNumberStart` | `double?` | Optional | Invoice Number Start<br>**Constraints**: `>= 1`, `<= 999999999` |
| `InvoiceNumberIncrement` | `double?` | Optional | Invoice Number Increment<br>**Constraints**: `>= 1`, `<= 999999999` |
| `InvoiceNumberCurrent` | `double?` | Optional | Invoice Number Current |
| `TaxRate` | `double` | Required | Tax Rate<br>**Constraints**: `>= 0`, `<= 99.99` |
| `TaxFee` | `int?` | Optional | Tax Fee<br>**Constraints**: `<= 999999999999` |
| `MonthlyFee` | `int?` | Optional | Monthly Fees<br>**Constraints**: `>= 0`, `<= 99999` |
| `PerInvoiceFee` | `int` | Required | Per Invoice Fee<br>**Constraints**: `>= 0`, `<= 99999` |
| `PerQuoteFee` | `int` | Required | Per Quote fee<br>**Constraints**: `>= 0`, `<= 99999` |
| `RequirePayInFull` | `bool` | Required | Require Pay In Full |
| `Selectable` | `double?` | Optional | Selectable |
| `Reportable` | `double?` | Optional | Reportable |
| `PortfolioId` | `string` | Optional | Portfolio Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `LocationId` | `string` | Required | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Id` | `string` | Required | Product Invoice Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |
| `CreatedUserId` | `string` | Optional | User ID Created the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ModifiedUserId` | `string` | Optional | Last User ID that updated the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "title": "Sample title",
  "quote_number_start": 1.0,
  "quote_number_increment": 1.0,
  "quote_number_current": 1.0,
  "invoice_number_start": 1,
  "invoice_number_increment": 1,
  "invoice_number_current": 1,
  "tax_rate": 0.0,
  "tax_fee": 0,
  "monthly_fee": 0,
  "per_invoice_fee": 0,
  "per_quote_fee": 0,
  "require_pay_in_full": true,
  "selectable": 1,
  "reportable": 1,
  "portfolio_id": "11e95f8ec39de8fbdb0a4f1a",
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "quote_number_format": "quote_number_format6",
  "invoice_number_format": "invoice_number_format8"
}
```

