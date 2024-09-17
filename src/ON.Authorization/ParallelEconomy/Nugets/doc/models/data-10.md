
# Data 10

## Structure

`Data10`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Required | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |
| `AccountNumber` | `string` | Optional | Account number<br>**Constraints**: *Maximum Length*: `32`, *Pattern*: `^[a-zA-Z0-9\-_]+$` |
| `Address` | [`Address1`](../../doc/models/address-1.md) | Optional | Address |
| `BrandingDomainId` | `string` | Optional | GUID for Branding Domain<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ContactEmailTrxReceiptDefault` | `bool?` | Optional | If true, will email contact receipt for any transaction |
| `DefaultAch` | `string` | Optional | GUID for Location's default ACH Product Transaction<br>**Constraints**: *Minimum Length*: `24`, *Maximum Length*: `36` |
| `DefaultCc` | `string` | Optional | GUID for Location's default CC Product Transaction<br>**Constraints**: *Minimum Length*: `24`, *Maximum Length*: `36` |
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
| `Tz` | `string` | Optional | Time zone<br>**Constraints**: *Maximum Length*: `30` |
| `ParentId` | `string` | Required | Location GUID of the parent location<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ShowContactNotes` | `bool?` | Optional | If set to true will show 'Notes' tab on Contact |
| `ShowContactFiles` | `bool?` | Optional | If set to true will show 'Files' tab on Contact |
| `CreatedUserId` | `string` | Optional | User ID Created the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `LocationType` | [`LocationTypeEnum?`](../../doc/models/location-type-enum.md) | Optional | Location Type |
| `TicketHashKey` | `string` | Optional | Ticket Hash Key<br>**Constraints**: *Maximum Length*: `36` |
| `Parent` | [`Parent3`](../../doc/models/parent-3.md) | Optional | Parent Information on `expand` |
| `Users` | [`List<User9>`](../../doc/models/user-9.md) | Optional | User Information on `expand` |
| `IsDeletable` | `bool?` | Optional | Is Deletable Information on `expand` |
| `Terminals` | [`List<Terminal2>`](../../doc/models/terminal-2.md) | Optional | Terminal Information on `expand` |
| `BrandingDomain` | [`BrandingDomain`](../../doc/models/branding-domain.md) | Optional | Branding Domain Information on `expand` |
| `ProductInvoice` | [`ProductInvoice`](../../doc/models/product-invoice.md) | Optional | Product Invoice Information on `expand` |
| `ProductFiles` | [`List<ProductFile>`](../../doc/models/product-file.md) | Optional | Product File Information on `expand` |
| `CreatedUser` | [`CreatedUser`](../../doc/models/created-user.md) | Optional | User Information on `expand` |
| `Changelogs` | [`List<Changelog>`](../../doc/models/changelog.md) | Optional | Changelog Information on `expand` |
| `ProductTransactions` | [`List<ProductTransaction1>`](../../doc/models/product-transaction-1.md) | Optional | Product Transaction Information on `expand` |
| `TerminalRouters` | [`List<TerminalRouter>`](../../doc/models/terminal-router.md) | Optional | Terminal Router Information on `expand` |
| `DeveloperCompany` | [`DeveloperCompany`](../../doc/models/developer-company.md) | Optional | Developer Company Information on `expand` |
| `DeveloperCompanyId` | `string` | Optional | Developer Company Id Information on `expand` |
| `Helppages` | [`List<Helppage>`](../../doc/models/helppage.md) | Optional | Helppage Information on `expand` |
| `QuickInvoiceSetting` | [`QuickInvoiceSetting`](../../doc/models/quick-invoice-setting.md) | Optional | Quick Invoice Setting Information on `expand` |
| `LocationBillingAccounts` | [`List<LocationBillingAccount>`](../../doc/models/location-billing-account.md) | Optional | Location Billing Account Information on `expand` |
| `Marketplaces` | [`List<Marketplace>`](../../doc/models/marketplace.md) | Optional | Marketplace Information on `expand` |
| `Locationmarketplaces` | [`List<Locationmarketplace>`](../../doc/models/locationmarketplace.md) | Optional | Locationmarketplaces Information on `expand` |
| `Addons` | [`List<Addon>`](../../doc/models/addon.md) | Optional | Addons Information on `expand` |

## Example (as JSON)

```json
{
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "account_number": "5454545454545454",
  "branding_domain_id": "11e95f8ec39de8fbdb0a4f1a",
  "contact_email_trx_receipt_default": true,
  "default_ach": "11e608a7d515f1e093242bb2",
  "default_cc": "11e608a442a5f1e092242dda",
  "email_reply_to": "email@domain.com",
  "fax": "3339998822",
  "location_api_id": "location-111111",
  "location_api_key": "AE34BBCAADF4AE34BBCAADF4",
  "location_c1": "custom 1",
  "location_c2": "custom 2",
  "location_c3": "custom data 3",
  "name": "Sample Company Headquarters",
  "office_phone": "2481234567",
  "office_ext_phone": "1021021209",
  "tz": "America/New_York",
  "parent_id": "11e95f8ec39de8fbdb0a4f1a",
  "show_contact_notes": true,
  "show_contact_files": true,
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "location_type": "merchant",
  "ticket_hash_key": "A5F443CADF4AE34BBCAADF4",
  "is_deletable": true,
  "developer_company_id": "sample developer company id",
  "address": {
    "city": "city6",
    "state": "state2",
    "postal_code": "postal_code8",
    "country": "US",
    "street": "street6"
  }
}
```

