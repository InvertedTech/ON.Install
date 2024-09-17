
# V1 Declined Recurring Transaction Payments Request

## Structure

`V1DeclinedRecurringTransactionPaymentsRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `DeclinedRecurringTransactionId` | `string` | Required | Declined Recurring Transaction Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `AccountNumber` | `string` | Required | Account Number<br>**Constraints**: *Minimum Length*: `13`, *Maximum Length*: `19` |
| `AccountHolderName` | `string` | Optional | Account Holder Name |
| `ExpDate` | `string` | Required | Exp Date<br>**Constraints**: *Maximum Length*: `4` |
| `TransactionAmount` | `int` | Required | Transaction Amount<br>**Constraints**: `>= 0`, `<= 999999999` |
| `Description` | `string` | Optional | Description<br>**Constraints**: *Maximum Length*: `255` |
| `BillingAddress` | [`BillingAddress`](../../doc/models/billing-address.md) | Optional | Billing Address Object |
| `Tags` | `List<string>` | Optional | Tags |
| `ReplaceAccountVault` | `bool?` | Optional | Replace AccountVault |
| `SaveAccount` | `bool?` | Optional | Specifies to save account to contacts profile if account_number/track_data is present with either contact_id or contact_api_id in params. |
| `SaveAccountTitle` | `string` | Optional | If saving token while running a transaction, this will be the title of the token.<br>**Constraints**: *Maximum Length*: `16` |

## Example (as JSON)

```json
{
  "declined_recurring_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
  "account_number": "5454545454545454",
  "account_holder_name": "John Doe",
  "exp_date": "0722",
  "transaction_amount": 0,
  "description": "Description",
  "save_account_title": "John Account",
  "billing_address": {
    "postal_code": "postal_code0",
    "street": "street8",
    "city": "city2",
    "state": "state6",
    "phone": "phone2"
  },
  "tags": [
    "tags3"
  ],
  "replace_account_vault": false
}
```

