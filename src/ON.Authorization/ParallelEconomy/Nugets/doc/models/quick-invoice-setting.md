
# Quick Invoice Setting

Quick Invoice Setting Information on `expand`

## Structure

`QuickInvoiceSetting`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationApiId` | `string` | Optional | Location API ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `LocationId` | `string` | Required | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `QuickInvoiceTemplate` | `string` | Required | Quick Invoice Template<br>**Constraints**: *Maximum Length*: `5000` |
| `DefaultAllowPartialPay` | `bool` | Required | Default Quick Invoice Allow Partial Pay |
| `DefaultNotificationOnDueDate` | `bool` | Required | Default Quick Invoice Notification On Due Date |
| `DefaultNotificationDaysAfterDueDate` | `double` | Required | Default Quick Invoice Notification Days After Due Date<br>**Constraints**: `>= 0`, `<= 60` |
| `DefaultNotificationDaysBeforeDueDate` | `double` | Required | Default Quick Invoice Notification Days Before Due Date<br>**Constraints**: `>= 0`, `<= 60` |
| `Id` | `string` | Required | Quick Invoice Settings ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "location_api_id": "11e95f8ec39de8fbdb0a4f1a",
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "quick_invoice_template": "<html>Template<html>",
  "default_allow_partial_pay": true,
  "default_notification_on_due_date": true,
  "default_notification_days_after_due_date": 7.0,
  "default_notification_days_before_due_date": 3.0,
  "id": "11e95f8ec39de8fbdb0a4f1a"
}
```

