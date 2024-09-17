
# Location Billing Account

## Structure

`LocationBillingAccount`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Title` | `string` | Required | Title<br>**Constraints**: *Maximum Length*: `64` |
| `LocationId` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `LocationApiId` | `string` | Optional | Location Api Id |
| `AchSecCode` | `string` | Optional | Ach Sec Code |
| `AccountNumber` | `string` | Optional | Account number |
| `Routing` | `string` | Optional | Routing |
| `ExpDate` | `string` | Optional | Exp Date |
| `BillingZip` | `string` | Optional | Billing Zip<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `10`, *Pattern*: `^[a-zA-Z0-9\-\s]+$` |
| `AccountType` | `string` | Optional | Account Type |
| `AccountHolderName` | `string` | Optional | Account Holder Name |
| `Id` | `string` | Required | Location Billing Account Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |
| `CreatedUserId` | `string` | Optional | Created User Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ModifiedUserId` | `string` | Optional | Modified User Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `BillingDescriptor` | `string` | Optional | Billing Descriptor |
| `PaymentMethod` | `string` | Optional | Billing Descriptor |
| `PortfolioId` | `string` | Required | Portfolio Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "title": "Billing Acccount Title",
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "exp_date": "0722",
  "billing_zip": "48375",
  "account_holder_name": "John Smith",
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "portfolio_id": "11e95f8ec39de8fbdb0a4f1a",
  "location_api_id": "location_api_id4",
  "ach_sec_code": "ach_sec_code6",
  "account_number": "account_number4",
  "routing": "routing0"
}
```

