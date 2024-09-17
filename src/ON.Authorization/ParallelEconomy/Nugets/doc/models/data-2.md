
# Data 2

## Structure

`Data2`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationId` | `string` | Required | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `AccountNumber` | `string` | Optional | Contact Account Number<br>**Constraints**: *Maximum Length*: `32` |
| `ContactApiId` | `string` | Optional | Contact API Id<br>**Constraints**: *Maximum Length*: `64`, *Pattern*: `^[a-zA-Z0-9]*$` |
| `FirstName` | `string` | Optional | First Name<br>**Constraints**: *Maximum Length*: `64` |
| `LastName` | `string` | Required | Last Name<br>**Constraints**: *Maximum Length*: `64` |
| `CellPhone` | `string` | Optional | Cell phone of contact<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `Balance` | `double?` | Optional | Balance<br>**Constraints**: `>= -99999999.99`, `<= 99999999.99` |
| `Address` | [`Address`](../../doc/models/address.md) | Optional | Address of contact |
| `CompanyName` | `string` | Optional | Company Name<br>**Constraints**: *Maximum Length*: `64` |
| `HeaderMessage` | `string` | Optional | Header Message<br>**Constraints**: *Maximum Length*: `250` |
| `DateOfBirth` | `string` | Optional | Contacts DOB, Format: yyyy-MM-dd<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `EmailTrxReceipt` | `bool` | Required | Whether or not to email all transactions receipts to contact (1 or 0) |
| `HomePhone` | `string` | Optional | Contacts home phone<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `OfficePhone` | `string` | Optional | Contacts office phone<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `OfficePhoneExt` | `string` | Optional | Contacts office phone extension for office phone<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^\d{1,10}$` |
| `HeaderMessageType` | `int` | Required | Header Message Type<br>**Constraints**: `>= 0`, `<= 4` |
| `UpdateIfExists` | [`UpdateIfExistsEnum?`](../../doc/models/update-if-exists-enum.md) | Optional | Update If Exists |
| `ContactC1` | `string` | Optional | Custom field 1 for api users to store custom data<br>**Constraints**: *Maximum Length*: `128` |
| `ContactC2` | `string` | Optional | Custom field 2 for api users to store custom data<br>**Constraints**: *Maximum Length*: `128` |
| `ContactC3` | `string` | Optional | Custom field 3 for api users to store custom data<br>**Constraints**: *Maximum Length*: `128` |
| `ParentId` | `string` | Optional | Parent Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Email` | `string` | Optional | Email of contact<br>**Constraints**: *Maximum Length*: `64` |
| `Id` | `string` | Required | Contact ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |
| `Active` | `bool` | Required | Active |
| `CreatedUserId` | `string` | Optional | User ID Created the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ReceivedEmails` | [`List<ReceivedEmail>`](../../doc/models/received-email.md) | Optional | Received Email Information on `expand` |
| `IsDeletable` | `bool?` | Optional | Is Deletable Information on `expand` |
| `Location` | [`Location`](../../doc/models/location.md) | Optional | Location Information on `expand` |
| `User` | [`User1`](../../doc/models/user-1.md) | Optional | User Information on `expand` |
| `Recurrings` | [`List<Recurring>`](../../doc/models/recurring.md) | Optional | Recurring Information on `expand` |
| `EmailBlacklist` | [`EmailBlacklist`](../../doc/models/email-blacklist.md) | Optional | Email Blacklist Information on `expand` |
| `SmsBlacklist` | [`SmsBlacklist`](../../doc/models/sms-blacklist.md) | Optional | Sms Blacklist Information on `expand` |
| `Changelogs` | [`List<Changelog>`](../../doc/models/changelog.md) | Optional | Changelog Information on `expand` |
| `PostbackLogs` | [`List<PostbackLog>`](../../doc/models/postback-log.md) | Optional | Postback Log Information on `expand` |
| `CreatedUser` | [`CreatedUser`](../../doc/models/created-user.md) | Optional | User Information on `expand` |
| `Parent` | [`Parent`](../../doc/models/parent.md) | Optional | Parent Information on `expand` |
| `Children` | [`Children`](../../doc/models/children.md) | Optional | Children Information on `expand` |

## Example (as JSON)

```json
{
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "account_number": "54545433332",
  "contact_api_id": "137",
  "first_name": "John",
  "last_name": "Smith",
  "cell_phone": "3339998822",
  "balance": 245.36,
  "company_name": "Fortis Payment Systems, LLC",
  "header_message": "This is a sample message for you",
  "date_of_birth": "2021-12-01",
  "email_trx_receipt": true,
  "home_phone": "3339998822",
  "office_phone": "3339998822",
  "office_phone_ext": "5",
  "header_message_type": 0,
  "update_if_exists": 1,
  "contact_c1": "any",
  "contact_c2": "anything",
  "contact_c3": "something",
  "parent_id": "11e95f8ec39de8fbdb0a4f1a",
  "email": "email@domain.com",
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "active": true,
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "is_deletable": true
}
```

