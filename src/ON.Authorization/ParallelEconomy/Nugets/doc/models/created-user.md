
# Created User

User Information on `expand`

## Structure

`CreatedUser`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AccountNumber` | `string` | Optional | Account Number |
| `BrandingDomainUrl` | `string` | Optional | Branding Domain Url<br>**Constraints**: *Maximum Length*: `64` |
| `CellPhone` | `string` | Optional | Cell Phone<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `CompanyName` | `string` | Optional | Company Name<br>**Constraints**: *Maximum Length*: `64` |
| `ContactId` | `string` | Optional | Contact<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `DateOfBirth` | `string` | Optional | Date Of Birth<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `DomainId` | `string` | Optional | Domain<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Email` | `string` | Required | Email<br>**Constraints**: *Maximum Length*: `128` |
| `EmailTrxReceipt` | `bool?` | Optional | Email Trx Receipt |
| `HomePhone` | `string` | Optional | Home Phone<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `FirstName` | `string` | Optional | First Name<br>**Constraints**: *Maximum Length*: `64` |
| `LastName` | `string` | Required | Last Name<br>**Constraints**: *Maximum Length*: `64` |
| `Locale` | `string` | Optional | Locale<br>**Constraints**: *Maximum Length*: `8` |
| `OfficePhone` | `string` | Optional | Office Phone<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `OfficeExtPhone` | `string` | Optional | Office Ext Phone<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^\d{1,10}$` |
| `PrimaryLocationId` | `string` | Required | Primary Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `RequiresNewPassword` | `string` | Optional | Requires New Password<br>**Constraints**: *Maximum Length*: `1` |
| `TermsConditionCode` | `string` | Optional | Terms Condition (This field is required when updating your own password). |
| `Tz` | `string` | Required | Time zone<br>**Constraints**: *Maximum Length*: `30` |
| `UiPrefs` | [`UiPrefs`](../../doc/models/ui-prefs.md) | Optional | Ui Prefs |
| `Username` | `string` | Required | Username<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `64` |
| `UserApiKey` | `string` | Optional | User Api Key<br>**Constraints**: *Minimum Length*: `16`, *Maximum Length*: `64` |
| `UserHashKey` | `string` | Optional | User Hash Key<br>**Constraints**: *Minimum Length*: `24`, *Maximum Length*: `36` |
| `UserTypeCode` | [`UserTypeCodeEnum`](../../doc/models/user-type-code-enum.md) | Required | User Type |
| `Password` | `string` | Optional | Password<br>**Constraints**: *Minimum Length*: `8`, *Maximum Length*: `128`, *Pattern*: `^(?=.*[`!@#$%^&*()_+\-=\[\]{};':"\\\|,.<>\/?~])(?=.*[0-9])(?=.*[a-zA-Z]).*$` |
| `Zip` | `string` | Optional | Zip<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `10`, *Pattern*: `^[a-zA-Z0-9\-\s]+$` |
| `LocationId` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ContactApiId` | `string` | Optional | ContactApi Id |
| `PrimaryLocationApiId` | `string` | Optional | Primary LocationApi ID |
| `StatusCode` | [`StatusCodeEnum?`](../../doc/models/status-code-enum.md) | Optional | Status Code |
| `ApiOnly` | `bool?` | Optional | API Only |
| `IsInvitation` | `bool?` | Optional | Is Invitation |
| `Address` | [`Address2`](../../doc/models/address-2.md) | Optional | Address |
| `Id` | `string` | Required | User ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Status` | `bool` | Required | Status |
| `LoginAttempts` | `int` | Required | Login Attempts |
| `LastLoginTs` | `int` | Required | Last Login |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |
| `CreatedUserId` | `string` | Required | Created User<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `TermsAcceptedTs` | `int?` | Optional | Terms Accepted |
| `TermsAgreeIp` | `string` | Optional | Terms Agree Ip<br>**Constraints**: *Maximum Length*: `16` |
| `CurrentDateTime` | `string` | Required | Current Date Time<br>**Constraints**: *Maximum Length*: `24` |
| `CurrentLoginIp` | `string` | Optional | Current Login Ip |
| `CurrentLogin` | `int?` | Optional | Current Login Timestamp |
| `SftpAccess` | `bool?` | Optional | SFTP Access |
| `LogApiResponseBodyTs` | `int?` | Optional | Log Api Response Body |

## Example (as JSON)

```json
{
  "account_number": "5454545454545454",
  "branding_domain_url": "{branding_domain_url}",
  "cell_phone": "3339998822",
  "company_name": "Fortis Payment Systems, LLC",
  "contact_id": "11e95f8ec39de8fbdb0a4f1a",
  "date_of_birth": "2021-12-01",
  "domain_id": "11e95f8ec39de8fbdb0a4f1a",
  "email": "email@domain.com",
  "email_trx_receipt": true,
  "home_phone": "3339998822",
  "first_name": "John",
  "last_name": "Smith",
  "locale": "en-US",
  "office_phone": "3339998822",
  "office_ext_phone": "5",
  "primary_location_id": "11e95f8ec39de8fbdb0a4f1a",
  "terms_condition_code": "20220308",
  "tz": "America/New_York",
  "username": "{user_name}",
  "user_api_key": "234bas8dfn8238f923w2",
  "user_type_code": 100,
  "zip": "48375",
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "status_code": 1,
  "api_only": false,
  "is_invitation": false,
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "status": true,
  "login_attempts": 0,
  "last_login_ts": 1422040992,
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "terms_accepted_ts": 1422040992,
  "terms_agree_ip": "192.168.0.10",
  "current_date_time": "03/11/2019 17:38:26",
  "current_login": 1422040992,
  "log_api_response_body_ts": 1422040992
}
```

