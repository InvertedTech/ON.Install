
# Data 4

## Structure

`Data4`

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
| `Id` | `string` | Optional | Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `FirstSix` | `string` | Required | First Six<br>**Constraints**: *Maximum Length*: `6` |
| `LastFour` | `string` | Required | Last Four<br>**Constraints**: *Maximum Length*: `4` |
| `Routing` | `string` | Optional | Routing |
| `StatusId` | `double?` | Optional | Status Id |
| `ReasonCodeId` | [`ReasonCodeIdEnum?`](../../doc/models/reason-code-id-enum.md) | Optional | Reason Code Id |
| `TypeId` | `double?` | Optional | Type Id |
| `CreatedTs` | `int?` | Optional | Created Time Stamp |
| `CreatedUserId` | `string` | Optional | User ID Created the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "declined_recurring_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
  "account_number": "5454545454545454",
  "account_holder_name": "John Doe",
  "exp_date": "0722",
  "transaction_amount": 0,
  "description": "Description",
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "first_six": "700953",
  "last_four": "3657",
  "reason_code_id": 1000,
  "created_ts": 1422040992,
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "billing_address": {
    "postal_code": "postal_code0",
    "street": "street8",
    "city": "city2",
    "state": "state6",
    "phone": "phone2"
  },
  "tags": [
    "tags5",
    "tags6"
  ]
}
```

