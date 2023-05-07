
# List 12

## Structure

`List12`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AccountNumber` | `string` | Optional | Account Number |
| `Address` | `string` | Optional | Address<br>**Constraints**: *Maximum Length*: `255`, *Pattern*: `^[\w\#\,\.\-\'\&\s\/]+$` |
| `BrandingDomainUrl` | `string` | Optional | Branding Domain Url<br>**Constraints**: *Maximum Length*: `64` |
| `CellPhone` | `string` | Optional | Cell Phone<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `City` | `string` | Optional | City<br>**Constraints**: *Maximum Length*: `36`, *Pattern*: `^[\w\#\,\.\-\'\&\s\/]+$` |
| `CompanyName` | `string` | Optional | Company Name<br>**Constraints**: *Maximum Length*: `64` |
| `ContactId` | `string` | Optional | Contact<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `DateOfBirth` | `string` | Optional | Date Of Birth<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `DomainId` | `string` | Optional | Domain<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Email` | `string` | Required | Email<br>**Constraints**: *Maximum Length*: `128` |
| `EmailTrxReceipt` | `bool?` | Optional | Email Trx Receipt |
| `HomePhone` | `string` | Optional | Home Phone<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `FirstName` | `string` | Optional | First Name<br>**Constraints**: *Maximum Length*: `64` |
| `LastName` | `string` | Required | Last Name<br>**Constraints**: *Maximum Length*: `64` |
| `Locale` | `string` | Optional | Locale<br>**Constraints**: *Maximum Length*: `8` |
| `OfficePhone` | `string` | Optional | Office Phone<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `OfficeExtPhone` | `string` | Optional | Office Ext Phone<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^\d{1,10}$` |
| `PrimaryLocationId` | `string` | Required | Primary Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `RequiresNewPassword` | `string` | Optional | Requires New Password<br>**Constraints**: *Maximum Length*: `1` |
| `State` | `string` | Optional | State<br>**Constraints**: *Maximum Length*: `24` |
| `TermsConditionId` | `string` | Optional | Terms Condition<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Tz` | `string` | Required | Time zone<br>**Constraints**: *Maximum Length*: `30` |
| `UiPrefs` | [`Models.UiPrefs`](../../doc/models/ui-prefs.md) | Optional | Ui Prefs |
| `Username` | `string` | Required | Username<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `64` |
| `UserApiKey` | `string` | Optional | User Api Key<br>**Constraints**: *Minimum Length*: `16`, *Maximum Length*: `64` |
| `UserHashKey` | `string` | Optional | User Hash Key<br>**Constraints**: *Minimum Length*: `24`, *Maximum Length*: `36` |
| `UserTypeCode` | [`Models.UserTypeCodeEnum`](../../doc/models/user-type-code-enum.md) | Required | User Type |
| `Password` | `string` | Optional | Password<br>**Constraints**: *Minimum Length*: `8`, *Maximum Length*: `128`, *Pattern*: `^(?=.*[`!@#$%^&*()_+\-=\[\]{};':"\\\|,.<>\/?~])(?=.*[0-9])(?=.*[a-zA-Z]).*$` |
| `Zip` | `string` | Optional | Zip<br>**Constraints**: *Minimum Length*: `5`, *Maximum Length*: `10`, *Pattern*: `^\d{5,10}$` |
| `LocationId` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ContactApiId` | `string` | Optional | ContactApi Id |
| `PrimaryLocationApiId` | `string` | Optional | Primary LocationApi ID |
| `StatusId` | `bool?` | Optional | Status |
| `Id` | `string` | Required | User ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Status` | `bool` | Required | Status |
| `LoginAttempts` | `double` | Required | Login Attempts |
| `LastLoginTs` | `int` | Required | Last Login |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |
| `CreatedUserId` | `string` | Required | Created User<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `TermsAcceptedTs` | `int?` | Optional | Terms Accepted |
| `TermsAgreeIp` | `string` | Optional | Terms Agree Ip<br>**Constraints**: *Maximum Length*: `16` |
| `CurrentDateTime` | `string` | Required | Current Date Time<br>**Constraints**: *Maximum Length*: `24` |

## Example (as JSON)

```json
{
  "email": "email@domain.com",
  "last_name": "Smith",
  "primary_location_id": "11e95f8ec39de8fbdb0a4f1a",
  "tz": "America/New_York",
  "username": "{user_name}",
  "user_type_code": 100,
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "status": true,
  "login_attempts": 0,
  "last_login_ts": 1422040992,
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "current_date_time": "03/11/2019 17:38:26"
}
```

