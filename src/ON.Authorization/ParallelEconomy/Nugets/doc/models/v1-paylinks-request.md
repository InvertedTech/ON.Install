
# V1 Paylinks Request

## Structure

`V1PaylinksRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationId` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CcProductTransactionId` | `string` | Optional | cc_product_transaction_id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Email` | `string` | Optional | Email<br>**Constraints**: *Maximum Length*: `128` |
| `AmountDue` | `int` | Required | Amount Due<br>**Constraints**: `>= 1`, `<= 999999999` |
| `LocationApiId` | `string` | Optional | Location Api Id |
| `ContactId` | `string` | Optional | Contact Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ContactApiId` | `string` | Optional | Contact Api Id |
| `PaylinkApiId` | `string` | Optional | Paylinke Api Id<br>**Constraints**: *Maximum Length*: `64` |
| `AchProductTransactionId` | `string` | Optional | Ach Product Transaction Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ExpireDate` | `string` | Optional | Expire Date<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `DisplayProductTransactionReceiptDetails` | `bool?` | Optional | Display Product Transaction Receipt Details |
| `DisplayBillingFields` | `bool?` | Optional | Display Billing Fields |
| `DeliveryMethod` | [`DeliveryMethodEnum?`](../../doc/models/delivery-method-enum.md) | Optional | Delivery Method<br><br>> 0 - Do not send<br>> <br>> 1 - Email<br>> <br>> 2 - SMS<br>> <br>> 3 - Both |
| `CellPhone` | `string` | Optional | Cell Phone<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `Description` | `string` | Optional | Description<br>**Constraints**: *Maximum Length*: `64` |
| `StoreToken` | `bool?` | Optional | Store Token |
| `StoreTokenTitle` | `string` | Optional | Store Token Title<br>**Constraints**: *Maximum Length*: `16` |
| `PaylinkAction` | [`PaylinkActionEnum?`](../../doc/models/paylink-action-enum.md) | Optional | Paylink Action |
| `BankFundedOnlyOverride` | `bool?` | Optional | Bank Funded Only Override |
| `Tags` | `List<string>` | Optional | Used to apply tags to a paylink. |

## Example (as JSON)

```json
{
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
  "email": "email@domain.com",
  "amount_due": 1,
  "contact_id": "11e95f8ec39de8fbdb0a4f1a",
  "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
  "expire_date": "2021-12-01",
  "display_product_transaction_receipt_details": true,
  "display_billing_fields": true,
  "delivery_method": 0,
  "cell_phone": "3339998822",
  "description": "Description",
  "store_token": false,
  "store_token_title": "John Account",
  "bank_funded_only_override": false,
  "location_api_id": "location_api_id4"
}
```

