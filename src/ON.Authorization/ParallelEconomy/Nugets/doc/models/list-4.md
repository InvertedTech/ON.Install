
# List 4

## Structure

`List4`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BrandingDomainUrl` | `string` | Optional | Branding domain URL |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `Id` | `string` | Required | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |
| `AccountNumber` | `string` | Optional | Account number<br>**Constraints**: *Maximum Length*: `32`, *Pattern*: `^[a-zA-Z0-9\-\_]+$` |
| `Address` | [`Models.Address2`](../../doc/models/address-2.md) | Optional | Address |
| `BrandingDomainId` | `string` | Optional | GUID for Branding Domain<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ContactEmailTrxReceiptDefault` | `bool?` | Optional | If true, will email contact receipt for any transaction |
| `DefaultAch` | `string` | Optional | GUID for Location's default ACH Product Transaction<br>**Constraints**: *Minimum Length*: `24`, *Maximum Length*: `36` |
| `DefaultCc` | `string` | Optional | GUID for Location's default CC Product Transaction<br>**Constraints**: *Minimum Length*: `24`, *Maximum Length*: `36` |
| `DeveloperCompanyId` | `string` | Optional | GUID for Developer Company<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `EmailReplyTo` | `string` | Optional | Used as from email address when sending various notifications<br>**Constraints**: *Maximum Length*: `64` |
| `Fax` | `string` | Optional | Fax number<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |
| `LocationApiId` | `string` | Optional | Location api ID<br>**Constraints**: *Maximum Length*: `36` |
| `LocationApiKey` | `string` | Optional | Location api key<br>**Constraints**: *Maximum Length*: `36` |
| `LocationC1` | `string` | Optional | Can be used to store custom information for location.<br>**Constraints**: *Maximum Length*: `128` |
| `LocationC2` | `string` | Optional | Can be used to store custom information for location.<br>**Constraints**: *Maximum Length*: `128` |
| `LocationC3` | `string` | Optional | Can be used to store custom information for location.<br>**Constraints**: *Maximum Length*: `128` |
| `Name` | `string` | Required | Name of the company<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `64` |
| `OfficePhone` | `string` | Optional | Office phone number<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10` |
| `OfficeExtPhone` | `string` | Optional | Office phone extension number<br>**Constraints**: *Maximum Length*: `10` |
| `ParentId` | `string` | Required | Location GUID of the parent location<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `RecurringNotificationDaysDefault` | `int?` | Optional | Number of days prior to a Recurring running that a notification should be sent<br>**Constraints**: `>= 0`, `<= 365` |
| `Tz` | `string` | Optional | Time zone<br>**Constraints**: *Maximum Length*: `30` |

## Example (as JSON)

```json
{
  "created_ts": 1422040992,
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "modified_ts": 1422040992,
  "name": "Sample Company Headquarters",
  "parent_id": "11e95f8ec39de8fbdb0a4f1a"
}
```

