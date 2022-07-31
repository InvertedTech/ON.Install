
# Filter 12

You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods:

> /endpoint?filter={ "field_name": "Value" }
> 
> /endpoint?filter[field_name]=Value

## Structure

`Filter12`

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
| `Email` | `string` | Optional | Email<br>**Constraints**: *Maximum Length*: `128` |
| `EmailTrxReceipt` | `bool?` | Optional | Email Trx Receipt |
| `HomePhone` | `string` | Optional | Home Phone<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `FirstName` | `string` | Optional | First Name<br>**Constraints**: *Maximum Length*: `64` |
| `LastName` | `string` | Optional | Last Name<br>**Constraints**: *Maximum Length*: `64` |
| `Locale` | `string` | Optional | Locale<br>**Constraints**: *Maximum Length*: `8` |
| `OfficePhone` | `string` | Optional | Office Phone<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `OfficeExtPhone` | `string` | Optional | Office Ext Phone<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^\d{1,10}$` |
| `PrimaryLocationId` | `string` | Optional | Primary Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `RequiresNewPassword` | `string` | Optional | Requires New Password<br>**Constraints**: *Maximum Length*: `1` |
| `State` | `string` | Optional | State<br>**Constraints**: *Maximum Length*: `24` |
| `TermsConditionId` | `string` | Optional | Terms Condition<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Tz` | `string` | Optional | Time zone<br>**Constraints**: *Maximum Length*: `30` |
| `UiPrefs` | [`Models.UiPrefs`](../../doc/models/ui-prefs.md) | Optional | Ui Prefs |
| `Username` | `string` | Optional | Username<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `64` |
| `UserApiKey` | `string` | Optional | User Api Key<br>**Constraints**: *Minimum Length*: `16`, *Maximum Length*: `64` |
| `UserHashKey` | `string` | Optional | User Hash Key<br>**Constraints**: *Minimum Length*: `24`, *Maximum Length*: `36` |
| `UserTypeCode` | [`Models.UserTypeCodeEnum?`](../../doc/models/user-type-code-enum.md) | Optional | User Type |
| `Password` | `string` | Optional | Password<br>**Constraints**: *Minimum Length*: `8`, *Maximum Length*: `128`, *Pattern*: `^(?=.*[`!@#$%^&*()_+\-=\[\]{};':"\\\|,.<>\/?~])(?=.*[0-9])(?=.*[a-zA-Z]).*$` |
| `Zip` | `string` | Optional | Zip<br>**Constraints**: *Minimum Length*: `5`, *Maximum Length*: `10`, *Pattern*: `^\d{5,10}$` |
| `LocationId` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ContactApiId` | `string` | Optional | ContactApi Id |
| `PrimaryLocationApiId` | `string` | Optional | Primary LocationApi ID |
| `StatusId` | `bool?` | Optional | Status |
| `Id` | `string` | Optional | User ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Status` | `bool?` | Optional | Status |
| `LoginAttempts` | `double?` | Optional | Login Attempts |
| `LastLoginTs` | `int?` | Optional | Last Login |
| `CreatedTs` | `int?` | Optional | Created Time Stamp |
| `ModifiedTs` | `int?` | Optional | Modified Time Stamp |
| `CreatedUserId` | `string` | Optional | Created User<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `TermsAcceptedTs` | `int?` | Optional | Terms Accepted |
| `TermsAgreeIp` | `string` | Optional | Terms Agree Ip<br>**Constraints**: *Maximum Length*: `16` |
| `CurrentDateTime` | `string` | Optional | Current Date Time<br>**Constraints**: *Maximum Length*: `24` |

## Example (as JSON)

```json
{
  "account_number": null,
  "address": null,
  "branding_domain_url": null,
  "cell_phone": null,
  "city": null,
  "company_name": null,
  "contact_id": null,
  "date_of_birth": null,
  "domain_id": null,
  "email": null,
  "email_trx_receipt": null,
  "home_phone": null,
  "first_name": null,
  "last_name": null,
  "locale": null,
  "office_phone": null,
  "office_ext_phone": null,
  "primary_location_id": null,
  "requires_new_password": null,
  "state": null,
  "terms_condition_id": null,
  "tz": null,
  "ui_prefs": null,
  "username": null,
  "user_api_key": null,
  "user_hash_key": null,
  "user_type_code": null,
  "password": null,
  "zip": null,
  "location_id": null,
  "contact_api_id": null,
  "primary_location_api_id": null,
  "status_id": null,
  "id": null,
  "status": null,
  "login_attempts": null,
  "last_login_ts": null,
  "created_ts": null,
  "modified_ts": null,
  "created_user_id": null,
  "terms_accepted_ts": null,
  "terms_agree_ip": null,
  "current_date_time": null
}
```

