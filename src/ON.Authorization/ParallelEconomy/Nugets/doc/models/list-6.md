
# List 6

## Structure

`List6`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AccountVaultId` | `string` | Required | Token ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Active` | [`Models.ActiveEnum`](../../doc/models/active-enum.md) | Required | Active |
| `Description` | `string` | Optional | Description<br>**Constraints**: *Maximum Length*: `36` |
| `EndDate` | `string` | Optional | End date<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `InstallmentTotalCount` | `int?` | Optional | Installment Total Count<br>**Constraints**: `>= 1`, `<= 999` |
| `Interval` | `int` | Required | Interval<br>**Constraints**: `>= 0`, `<= 365` |
| `IntervalType` | [`Models.IntervalTypeEnum`](../../doc/models/interval-type-enum.md) | Required | Interval Type |
| `LocationId` | `string` | Required | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `NotificationDays` | `int?` | Optional | Notification Days<br>**Constraints**: `>= 0`, `<= 365` |
| `PaymentMethod` | [`Models.PaymentMethodEnum`](../../doc/models/payment-method-enum.md) | Required | Payment Method |
| `ProductTransactionId` | `string` | Optional | Product Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `RecurringId` | `string` | Optional | Recurring ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `RecurringApiId` | `string` | Optional | Recurring Api ID<br>**Constraints**: *Maximum Length*: `64` |
| `StartDate` | `string` | Required | Start date<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `Status` | [`Models.StatusEnum`](../../doc/models/status-enum.md) | Required | Status |
| `TransactionAmount` | `double` | Required | Transaction amount |
| `TermsAgree` | `bool?` | Optional | Terms Agree |
| `TermsAgreeIp` | `string` | Optional | Terms Agree Ip |
| `RecurringC1` | `string` | Optional | Custom field used for integrations<br>**Constraints**: *Maximum Length*: `128` |
| `RecurringC2` | `string` | Optional | Custom field used for integrations<br>**Constraints**: *Maximum Length*: `128` |
| `RecurringC3` | `string` | Optional | Custom field used for integrations<br>**Constraints**: *Maximum Length*: `128` |
| `SendToProcAsRecur` | `bool?` | Optional | Send To Proc As Recur |
| `Id` | `string` | Required | Recurring ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `NextRunDate` | `string` | Required | Next Run Date<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |
| `RecurringTypeId` | [`Models.RecurringTypeIdEnum`](../../doc/models/recurring-type-id-enum.md) | Required | Recurring Type |

## Example (as JSON)

```json
{
  "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
  "active": 1,
  "interval": 1,
  "interval_type": "d",
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "payment_method": "cc",
  "start_date": "2021-12-01",
  "status": "active",
  "transaction_amount": 3,
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "next_run_date": "2021-12-01",
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "recurring_type_id": "i"
}
```

