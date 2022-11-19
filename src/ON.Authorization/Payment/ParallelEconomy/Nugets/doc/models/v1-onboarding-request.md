
# V1 Onboarding Request

## Structure

`V1OnboardingRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ParentId` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `PrimaryPrincipal` | [`Models.PrimaryPrincipal`](../../doc/models/primary-principal.md) | Required | The Primary Principal. |
| `TemplateCode` | `string` | Required | The ID of the template to be used - this value will be provided by Fortis.<br>**Constraints**: *Maximum Length*: `20`, *Pattern*: `^[a-zA-Z0-9]*$` |
| `Email` | `string` | Required | Merchant email address.<br>**Constraints**: *Maximum Length*: `100` |
| `DbaName` | `string` | Required | Merchant 'Doing Business As' name.<br>**Constraints**: *Maximum Length*: `100` |
| `Location` | [`Models.Location`](../../doc/models/location.md) | Required | The Location. |
| `AppDelivery` | [`Models.AppDeliveryEnum`](../../doc/models/app-delivery-enum.md) | Required | The delivery method of the app to the merchant.<br>**Constraints**: *Maximum Length*: `12` |
| `BusinessCategory` | [`Models.BusinessCategoryEnum?`](../../doc/models/business-category-enum.md) | Optional | The Category of the merchant's business |
| `BusinessType` | [`Models.BusinessTypeEnum?`](../../doc/models/business-type-enum.md) | Optional | The Type of a merchant's business. |
| `BusinessDescription` | `string` | Optional | Description of Goods or Services.<br>**Constraints**: *Maximum Length*: `200` |
| `SwipedPercent` | `int?` | Optional | Card present/swiped percentage<br>**Constraints**: `>= 0`, `<= 100` |
| `KeyedPercent` | `int?` | Optional | Card not present/keyed percentage<br>**Constraints**: `>= 0`, `<= 100` |
| `EcommercePercent` | `int?` | Optional | eCommerce percentage.<br>**Constraints**: `>= 0`, `<= 100` |
| `OwnershipType` | [`Models.OwnershipTypeEnum?`](../../doc/models/ownership-type-enum.md) | Optional | The Ownership Type of the merchant's business.<br>**Constraints**: *Maximum Length*: `10` |
| `FedTaxId` | `string` | Optional | Federal Tax ID (EIN).<br>**Constraints**: *Maximum Length*: `10` |
| `CcAverageTicketRange` | `int?` | Optional | Average Transaction Amount Range<br>**Constraints**: `>= 1`, `<= 7` |
| `CcMonthlyVolumeRange` | `int?` | Optional | Monthly Processing Volume Range<br>**Constraints**: `>= 1`, `<= 7` |
| `CcHighTicket` | `int?` | Optional | Highest transaction amount rounded to the next dollar<br>**Constraints**: `>= 0`, `<= 30000` |
| `EcAverageTicketRange` | `int?` | Optional | Average Transaction Amount Range<br>**Constraints**: `>= 1`, `<= 7` |
| `EcMonthlyVolumeRange` | `int?` | Optional | Monthly Processing Volume Range<br>**Constraints**: `>= 1`, `<= 7` |
| `EcHighTicket` | `int?` | Optional | Highest transaction amount rounded to the next dollar<br>**Constraints**: `>= 0`, `<= 30000` |
| `Website` | `string` | Optional | Merchant's business website.<br>**Constraints**: *Maximum Length*: `100` |
| `BankAccount` | [`Models.BankAccount`](../../doc/models/bank-account.md) | Required | The Bank Account. |
| `AltBankAccount` | [`Models.AltBankAccount`](../../doc/models/alt-bank-account.md) | Required | The Alternative Bank Account. |
| `LegalName` | `string` | Optional | Merchant legal name.<br>**Constraints**: *Maximum Length*: `100` |
| `Contact` | [`Models.Contact`](../../doc/models/contact.md) | Required | The Contact. |
| `ClientAppId` | `string` | Optional | Client-Issued ID to uniquely identify the merchant (Returned unmodified).<br>**Constraints**: *Maximum Length*: `50` |

## Example (as JSON)

```json
{
  "primary_principal": {
    "first_name": "Bob",
    "last_name": "Fairview"
  },
  "template_code": "1234YourTemplateCode",
  "email": "email@domain.com",
  "dba_name": "Discount Home Goods",
  "location": {
    "phone_number": "555-555-1212"
  },
  "app_delivery": null,
  "bank_account": null,
  "alt_bank_account": null,
  "contact": {
    "phone_number": "555-555-3456"
  }
}
```

