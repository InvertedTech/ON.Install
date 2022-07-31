
# V1 Recurrings Request

## Structure

`V1RecurringsRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AccountVaultId` | `string` | Required | Token ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Active` | [`Models.ActiveEnum?`](../../doc/models/active-enum.md) | Optional | Active |
| `Description` | `string` | Optional | Description<br>**Constraints**: *Maximum Length*: `36` |
| `EndDate` | `string` | Optional | End date<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `InstallmentTotalCount` | `int?` | Optional | Installment Total Count<br>**Constraints**: `>= 1`, `<= 999` |
| `Interval` | `int` | Required | Interval<br>**Constraints**: `>= 0`, `<= 365` |
| `IntervalType` | [`Models.IntervalTypeEnum`](../../doc/models/interval-type-enum.md) | Required | Interval Type |
| `LocationId` | `string` | Required | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `NotificationDays` | `int?` | Optional | Notification Days<br>**Constraints**: `>= 0`, `<= 365` |
| `PaymentMethod` | [`Models.PaymentMethodEnum?`](../../doc/models/payment-method-enum.md) | Optional | Payment Method |
| `ProductTransactionId` | `string` | Optional | Product Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `RecurringId` | `string` | Optional | Recurring ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `RecurringApiId` | `string` | Optional | Recurring Api ID<br>**Constraints**: *Maximum Length*: `64` |
| `StartDate` | `string` | Required | Start date<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `Status` | [`Models.StatusEnum?`](../../doc/models/status-enum.md) | Optional | Status |
| `TransactionAmount` | `double` | Required | Transaction amount |
| `TermsAgree` | `bool?` | Optional | Terms Agree |
| `TermsAgreeIp` | `string` | Optional | Terms Agree Ip |
| `RecurringC1` | `string` | Optional | Custom field used for integrations<br>**Constraints**: *Maximum Length*: `128` |
| `RecurringC2` | `string` | Optional | Custom field used for integrations<br>**Constraints**: *Maximum Length*: `128` |
| `RecurringC3` | `string` | Optional | Custom field used for integrations<br>**Constraints**: *Maximum Length*: `128` |
| `SendToProcAsRecur` | `bool?` | Optional | Send To Proc As Recur |

## Example (as JSON)

```json
{
  "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
  "interval": 1,
  "interval_type": "d",
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "start_date": "2021-12-01",
  "transaction_amount": 3
}
```

