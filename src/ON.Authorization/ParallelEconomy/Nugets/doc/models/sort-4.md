
# Sort 4

You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods:

> /endpoint?sort={ "field_name": "asc", "field_name2": "desc" }
> 
> /endpoint?sort[field_name]=asc&sort[field_name2]=desc

## Structure

`Sort4`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BrandingDomainUrl` | `string` | Optional | Branding domain URL |
| `CreatedTs` | `int?` | Optional | Created Time Stamp |
| `Id` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ModifiedTs` | `int?` | Optional | Modified Time Stamp |
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
| `Name` | `string` | Optional | Name of the company<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `64` |
| `OfficePhone` | `string` | Optional | Office phone number<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10` |
| `OfficeExtPhone` | `string` | Optional | Office phone extension number<br>**Constraints**: *Maximum Length*: `10` |
| `ParentId` | `string` | Optional | Location GUID of the parent location<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `RecurringNotificationDaysDefault` | `int?` | Optional | Number of days prior to a Recurring running that a notification should be sent<br>**Constraints**: `>= 0`, `<= 365` |
| `Tz` | `string` | Optional | Time zone<br>**Constraints**: *Maximum Length*: `30` |

## Example (as JSON)

```json
{
  "branding_domain_url": null,
  "created_ts": null,
  "id": null,
  "modified_ts": null,
  "account_number": null,
  "address": null,
  "branding_domain_id": null,
  "contact_email_trx_receipt_default": null,
  "default_ach": null,
  "default_cc": null,
  "developer_company_id": null,
  "email_reply_to": null,
  "fax": null,
  "location_api_id": null,
  "location_api_key": null,
  "location_c1": null,
  "location_c2": null,
  "location_c3": null,
  "name": null,
  "office_phone": null,
  "office_ext_phone": null,
  "parent_id": null,
  "recurring_notification_days_default": null,
  "tz": null
}
```

