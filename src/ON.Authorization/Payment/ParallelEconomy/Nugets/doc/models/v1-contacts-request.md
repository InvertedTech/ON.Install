
# V1 Contacts Request

## Structure

`V1ContactsRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationId` | `string` | Required | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `AccountNumber` | `string` | Optional | Contact Account Number<br>**Constraints**: *Maximum Length*: `32` |
| `ContactApiId` | `string` | Optional | Contact API Id<br>**Constraints**: *Maximum Length*: `64`, *Pattern*: `^[a-zA-Z0-9]*$` |
| `FirstName` | `string` | Optional | First Name<br>**Constraints**: *Maximum Length*: `64` |
| `LastName` | `string` | Required | Last Name<br>**Constraints**: *Maximum Length*: `64` |
| `CellPhone` | `string` | Optional | Cell phone of contact<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `Balance` | `double?` | Optional | Balance<br>**Constraints**: `>= -99999999.99`, `<= 99999999.99` |
| `Address` | [`Models.Address`](../../doc/models/address.md) | Optional | Address of contact |
| `CompanyName` | `string` | Optional | Company Name<br>**Constraints**: *Maximum Length*: `64` |
| `HeaderMessage` | `string` | Optional | Header Message<br>**Constraints**: *Maximum Length*: `250` |
| `DateOfBirth` | `string` | Optional | Contacts DOB, Format: yyyy-MM-dd<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `EmailTrxReceipt` | `bool?` | Optional | Whether or not to email all transactions receipts to contact (1 or 0) |
| `HomePhone` | `string` | Optional | Contacts home phone<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `OfficePhone` | `string` | Optional | Contacts office phone<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `OfficePhoneExt` | `string` | Optional | Contacts office phone extension for office phone<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^\d{1,10}$` |
| `HeaderMessageType` | `int?` | Optional | Header Message Type<br>**Constraints**: `>= 0`, `<= 4` |
| `UpdateIfExists` | [`Models.UpdateIfExistsEnum?`](../../doc/models/update-if-exists-enum.md) | Optional | Update If Exists |
| `ContactC1` | `string` | Optional | Custom field 1 for api users to store custom data<br>**Constraints**: *Maximum Length*: `128` |
| `ContactC2` | `string` | Optional | Custom field 2 for api users to store custom data<br>**Constraints**: *Maximum Length*: `128` |
| `ContactC3` | `string` | Optional | Custom field 3 for api users to store custom data<br>**Constraints**: *Maximum Length*: `128` |
| `ParentId` | `string` | Optional | Parent Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Email` | `string` | Optional | Email of contact<br>**Constraints**: *Maximum Length*: `64` |

## Example (as JSON)

```json
{
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "last_name": "Smith"
}
```

