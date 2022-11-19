
# V1 Recurrings Request 1

## Structure

`V1RecurringsRequest1`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `NextRunDate` | `string` | Optional | Next Run Date<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `AccountVaultId` | `string` | Optional | Token ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Active` | [`Models.ActiveEnum?`](../../doc/models/active-enum.md) | Optional | Active |
| `Description` | `string` | Optional | Description<br>**Constraints**: *Maximum Length*: `36` |
| `EndDate` | `string` | Optional | End date<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `InstallmentTotalCount` | `int?` | Optional | Installment Total Count<br>**Constraints**: `>= 1`, `<= 999` |
| `Interval` | `int?` | Optional | Interval<br>**Constraints**: `>= 0`, `<= 365` |
| `IntervalType` | [`Models.IntervalTypeEnum?`](../../doc/models/interval-type-enum.md) | Optional | Interval Type |
| `LocationId` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `NotificationDays` | `int?` | Optional | Notification Days<br>**Constraints**: `>= 0`, `<= 365` |
| `PaymentMethod` | [`Models.PaymentMethodEnum?`](../../doc/models/payment-method-enum.md) | Optional | Payment Method |
| `ProductTransactionId` | `string` | Optional | Product Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `RecurringId` | `string` | Optional | Recurring ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `RecurringApiId` | `string` | Optional | Recurring Api ID<br>**Constraints**: *Maximum Length*: `64` |
| `StartDate` | `string` | Optional | Start date<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `Status` | [`Models.StatusEnum?`](../../doc/models/status-enum.md) | Optional | Status |
| `TransactionAmount` | `double?` | Optional | Transaction amount |
| `TermsAgree` | `bool?` | Optional | Terms Agree |
| `TermsAgreeIp` | `string` | Optional | Terms Agree Ip |
| `RecurringC1` | `string` | Optional | Custom field used for integrations<br>**Constraints**: *Maximum Length*: `128` |
| `RecurringC2` | `string` | Optional | Custom field used for integrations<br>**Constraints**: *Maximum Length*: `128` |
| `RecurringC3` | `string` | Optional | Custom field used for integrations<br>**Constraints**: *Maximum Length*: `128` |
| `SendToProcAsRecur` | `bool?` | Optional | Send To Proc As Recur |

## Example (as JSON)

```json
{
  "next_run_date": null,
  "account_vault_id": null,
  "active": null,
  "description": null,
  "end_date": null,
  "installment_total_count": null,
  "interval": null,
  "interval_type": null,
  "location_id": null,
  "notification_days": null,
  "payment_method": null,
  "product_transaction_id": null,
  "recurring_id": null,
  "recurring_api_id": null,
  "start_date": null,
  "status": null,
  "transaction_amount": null,
  "terms_agree": null,
  "terms_agree_ip": null,
  "recurring_c1": null,
  "recurring_c2": null,
  "recurring_c3": null,
  "send_to_proc_as_recur": null
}
```

