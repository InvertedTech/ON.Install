
# List 5

## Structure

`List5`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationId` | `string` | Required | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Title` | `string` | Required | Title<br>**Constraints**: *Maximum Length*: `64` |
| `CcProductTransactionId` | `string` | Required | Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `AchProductTransactionId` | `string` | Optional | ACH Product Transaction Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `DueDate` | `string` | Required | Due Date, Format: Y-m-d<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `ItemList` | [`List<Models.ItemList>`](../../doc/models/item-list.md) | Required | Item List<br>**Constraints**: *Minimum Items*: `1`, *Maximum Items*: `99`, *Unique Items Required* |
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
| `Id` | `string` | Required | Quick Invoice ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |
| `CreatedUserId` | `string` | Optional | Created User Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ModifiedUserId` | `string` | Optional | Modified User Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Active` | `bool?` | Optional | Active status |
| `IsActive` | `bool?` | Optional | Register is active |

## Example (as JSON)

```json
{
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "title": "My terminal",
  "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
  "due_date": "2021-12-01",
  "item_list": {
    "name": "Bread",
    "amount": 20.15
  },
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "created_ts": 1422040992,
  "modified_ts": 1422040992
}
```

