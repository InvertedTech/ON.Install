
# List 9

## Structure

`List9`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationId` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Title` | `string` | Required | Title<br>**Constraints**: *Maximum Length*: `64` |
| `CcProductTransactionId` | `string` | Optional | Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `AchProductTransactionId` | `string` | Optional | ACH Product Transaction Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `DueDate` | `string` | Required | Due Date, Format: Y-m-d<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `ItemList` | [`List<ItemList>`](../../doc/models/item-list.md) | Required | Item List<br>**Constraints**: *Minimum Items*: `1`, *Maximum Items*: `99`, *Unique Items Required* |
| `AllowOverpayment` | `bool?` | Optional | Allow Overpayment. |
| `BankFundedOnlyOverride` | `bool?` | Optional | Bank Funded Only override |
| `Email` | `string` | Optional | Email<br>**Constraints**: *Maximum Length*: `128` |
| `ContactId` | `string` | Optional | Contact ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ContactApiId` | `string` | Optional | Contact API Id<br>**Constraints**: *Maximum Length*: `64` |
| `QuickInvoiceApiId` | `string` | Optional | Quick Invoice API Id<br>**Constraints**: *Maximum Length*: `64` |
| `CustomerId` | `string` | Optional | Customer Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ExpireDate` | `string` | Optional | Expire Date.<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `AllowPartialPay` | `bool?` | Optional | Allow partial pay |
| `AttachFilesToEmail` | `bool?` | Optional | Attach Files to Email |
| `SendEmail` | `bool?` | Optional | Send Email |
| `InvoiceNumber` | `string` | Optional | Invoice number<br>**Constraints**: *Maximum Length*: `64` |
| `ItemHeader` | `string` | Optional | Item Header<br>**Constraints**: *Maximum Length*: `250` |
| `ItemFooter` | `string` | Optional | Item footer<br>**Constraints**: *Maximum Length*: `250` |
| `AmountDue` | `double?` | Optional | Amount Due |
| `NotificationEmail` | `string` | Optional | Notification email<br>**Constraints**: *Maximum Length*: `640` |
| `StatusId` | [`StatusIdEnum?`](../../doc/models/status-id-enum.md) | Optional | (DEPRECATED) Status Id |
| `StatusCode` | [`StatusCode12Enum?`](../../doc/models/status-code-12-enum.md) | Optional | Status Code |
| `Note` | `string` | Optional | Note<br>**Constraints**: *Maximum Length*: `200` |
| `NotificationDaysBeforeDueDate` | `int?` | Optional | Notification days before due date<br>**Constraints**: `>= 0`, `<= 99` |
| `NotificationDaysAfterDueDate` | `int?` | Optional | Notification days after due date<br>**Constraints**: `>= 0`, `<= 99` |
| `NotificationOnDueDate` | `bool?` | Optional | Notification on due date |
| `SendTextToPay` | `bool?` | Optional | Send Text To Pay |
| `Files` | [`List<File>`](../../doc/models/file.md) | Optional | File Information on `expand` |
| `RemainingBalance` | `double?` | Optional | Remaining Balance |
| `SinglePaymentMinAmount` | `int?` | Optional | Single Payment Min Amount |
| `SinglePaymentMaxAmount` | `int?` | Optional | Single Payment Max Amount<br>**Default**: `999999999` |
| `CellPhone` | `string` | Optional | Cell Phone<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `Tags` | [`List<Tag>`](../../doc/models/tag.md) | Optional | Tag Information on `expand` |
| `Id` | `string` | Required | Quick Invoice ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |
| `CreatedUserId` | `string` | Optional | Created User Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ModifiedUserId` | `string` | Optional | Modified User Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Active` | `bool?` | Optional | Active status |
| `PaymentStatusId` | `int?` | Optional | Payment Status Id<br>**Constraints**: `>= 1`, `<= 3` |
| `IsActive` | `bool?` | Optional | Register is active |
| `QuickInvoiceSetting` | [`QuickInvoiceSetting`](../../doc/models/quick-invoice-setting.md) | Optional | Quick Invoice Setting Information on `expand` |
| `QuickInvoiceViews` | [`List<QuickInvoiceView>`](../../doc/models/quick-invoice-view.md) | Optional | Quick Invoice View Information on `expand` |
| `Location` | [`Location`](../../doc/models/location.md) | Optional | Location Information on `expand` |
| `CreatedUser` | [`CreatedUser`](../../doc/models/created-user.md) | Optional | User Information on `expand` |
| `ModifiedUser` | [`ModifiedUser`](../../doc/models/modified-user.md) | Optional | Modified User Information on `expand` |
| `Changelogs` | [`List<Changelog>`](../../doc/models/changelog.md) | Optional | Changelog Information on `expand` |
| `Contact` | [`Contact1`](../../doc/models/contact-1.md) | Optional | Contact Information on `expand` |
| `LogEmails` | [`List<LogEmail>`](../../doc/models/log-email.md) | Optional | Log Email Information on `expand` |
| `LogSms` | [`LogSms`](../../doc/models/log-sms.md) | Optional | Log Sms Information on `expand` |
| `Transactions` | [`List<Transaction>`](../../doc/models/transaction.md) | Optional | Transaction Information on `expand` |
| `CcProductTransaction` | [`CcProductTransaction`](../../doc/models/cc-product-transaction.md) | Optional | Cc Product Transaction Information on `expand` |
| `AchProductTransaction` | [`AchProductTransaction`](../../doc/models/ach-product-transaction.md) | Optional | Ach Product Transaction Information on `expand` |
| `EmailBlacklist` | [`EmailBlacklist`](../../doc/models/email-blacklist.md) | Optional | Email Blacklist Information on `expand` |
| `SmsBlacklist` | [`SmsBlacklist`](../../doc/models/sms-blacklist.md) | Optional | Sms Blacklist Information on `expand` |
| `PaymentUrl` | `string` | Optional | Payment Url Information on `expand` |

## Example (as JSON)

```json
{
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "title": "My terminal",
  "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
  "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
  "due_date": "2021-12-01",
  "item_list": [
    {
      "name": "Bread",
      "amount": 2015
    }
  ],
  "allow_overpayment": true,
  "bank_funded_only_override": true,
  "email": "email@domain.com",
  "contact_id": "11e95f8ec39de8fbdb0a4f1a",
  "contact_api_id": "contact12345",
  "quick_invoice_api_id": "quickinvoice12345",
  "customer_id": "11e95f8ec39de8fbdb0a4f1a",
  "expire_date": "2021-12-01",
  "allow_partial_pay": true,
  "attach_files_to_email": true,
  "send_email": true,
  "invoice_number": "invoice12345",
  "item_header": "Quick invoice header sample",
  "item_footer": "Thank you",
  "amount_due": 245.36,
  "notification_email": "email@domain.com",
  "status_id": 1,
  "status_code": 1,
  "note": "some note",
  "notification_days_before_due_date": 3,
  "notification_days_after_due_date": 7,
  "notification_on_due_date": true,
  "send_text_to_pay": true,
  "remaining_balance": 245.36,
  "single_payment_min_amount": 500,
  "single_payment_max_amount": 500000,
  "cell_phone": "3339998822",
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "active": true,
  "payment_status_id": 1,
  "is_active": true
}
```

