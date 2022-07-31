
# Filter 5

You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods:

> /endpoint?filter={ "field_name": "Value" }
> 
> /endpoint?filter[field_name]=Value

## Structure

`Filter5`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationId` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Title` | `string` | Optional | Title<br>**Constraints**: *Maximum Length*: `64` |
| `CcProductTransactionId` | `string` | Optional | Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `AchProductTransactionId` | `string` | Optional | ACH Product Transaction Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `DueDate` | `string` | Optional | Due Date, Format: Y-m-d<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `ItemList` | [`List<Models.ItemList>`](../../doc/models/item-list.md) | Optional | Item List<br>**Constraints**: *Minimum Items*: `1`, *Maximum Items*: `99`, *Unique Items Required* |
| `AllowOverpayment` | `bool?` | Optional | Allow Overpayment. |
| `Email` | `string` | Optional | Email<br>**Constraints**: *Maximum Length*: `128` |
| `ContactId` | `string` | Optional | Contact ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ContactApiId` | `string` | Optional | Contact API Id<br>**Constraints**: *Maximum Length*: `64` |
| `CustomerId` | `string` | Optional | Customer Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ExpireDate` | `string` | Optional | Expire Date.<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `AllowPartialPay` | `bool?` | Optional | Allow partial pay |
| `AttachFilesToEmail` | `bool?` | Optional | Attach Files to Email |
| `SendEmail` | `bool?` | Optional | Send Email |
| `InvoiceNumber` | `string` | Optional | Invoice number<br>**Constraints**: *Maximum Length*: `64` |
| `ItemHeader` | `string` | Optional | Item Header<br>**Constraints**: *Maximum Length*: `250` |
| `ItemFooter` | `string` | Optional | Item footer<br>**Constraints**: *Maximum Length*: `250` |
| `AmountDue` | `double?` | Optional | Amount Due |
| `NotificationEmail` | `string` | Optional | Notification email<br>**Constraints**: *Maximum Length*: `640` |
| `PaymentStatusId` | `double?` | Optional | Payment Status Id<br>**Constraints**: `>= 1`, `<= 3` |
| `StatusId` | [`Models.StatusIdEnum?`](../../doc/models/status-id-enum.md) | Optional | Status Id |
| `Note` | `string` | Optional | Note<br>**Constraints**: *Maximum Length*: `200` |
| `NotificationDaysBeforeDueDate` | `int?` | Optional | Notification days before due date<br>**Constraints**: `>= 0`, `<= 99` |
| `NotificationDaysAfterDueDate` | `int?` | Optional | Notification days after due date<br>**Constraints**: `>= 0`, `<= 99` |
| `NotificationOnDueDate` | `bool?` | Optional | Notification on due date |
| `SendTextToPay` | `bool?` | Optional | Send Text To Pay |
| `Files` | `object` | Optional | Files |
| `RemainingBalance` | `double?` | Optional | Remaining Balance |
| `SinglePaymentMinAmount` | `double?` | Optional | Single Payment Min Amount |
| `SinglePaymentMaxAmount` | `double?` | Optional | Single Payment Max Amount<br>**Default**: `9999999.99` |
| `CellPhone` | `string` | Optional | Cell Phone<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `Id` | `string` | Optional | Quick Invoice ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int?` | Optional | Created Time Stamp |
| `ModifiedTs` | `int?` | Optional | Modified Time Stamp |
| `CreatedUserId` | `string` | Optional | Created User Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ModifiedUserId` | `string` | Optional | Modified User Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Active` | `bool?` | Optional | Active status |
| `IsActive` | `bool?` | Optional | Register is active |

## Example (as JSON)

```json
{
  "location_id": null,
  "title": null,
  "cc_product_transaction_id": null,
  "ach_product_transaction_id": null,
  "due_date": null,
  "item_list": null,
  "allow_overpayment": null,
  "email": null,
  "contact_id": null,
  "contact_api_id": null,
  "customer_id": null,
  "expire_date": null,
  "allow_partial_pay": null,
  "attach_files_to_email": null,
  "send_email": null,
  "invoice_number": null,
  "item_header": null,
  "item_footer": null,
  "amount_due": null,
  "notification_email": null,
  "payment_status_id": null,
  "status_id": null,
  "note": null,
  "notification_days_before_due_date": null,
  "notification_days_after_due_date": null,
  "notification_on_due_date": null,
  "send_text_to_pay": null,
  "files": null,
  "remaining_balance": null,
  "single_payment_min_amount": null,
  "single_payment_max_amount": null,
  "cell_phone": null,
  "id": null,
  "created_ts": null,
  "modified_ts": null,
  "created_user_id": null,
  "modified_user_id": null,
  "active": null,
  "is_active": null
}
```

