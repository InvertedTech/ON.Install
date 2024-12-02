
# Data 12

## Structure

`Data12`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ParentId` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `PrimaryPrincipal` | [`PrimaryPrincipal`](../../doc/models/primary-principal.md) | Required | The Primary Principal. |
| `TemplateCode` | `string` | Required | The ID of the template to be used - this value will be provided by Fortis.<br>**Constraints**: *Maximum Length*: `20`, *Pattern*: `^[a-zA-Z0-9]*$` |
| `Email` | `string` | Required | Merchant email address.<br>**Constraints**: *Maximum Length*: `100` |
| `DbaName` | `string` | Required | Merchant 'Doing Business As' name.<br>**Constraints**: *Maximum Length*: `100` |
| `Location` | [`Location5`](../../doc/models/location-5.md) | Required | The Location. |
| `AppDelivery` | `string` | Required | The delivery method of the app to the merchant.<br>**Constraints**: *Maximum Length*: `20` |
| `BusinessCategory` | [`BusinessCategoryEnum?`](../../doc/models/business-category-enum.md) | Optional | The Category of the merchant's business |
| `BusinessType` | [`BusinessTypeEnum?`](../../doc/models/business-type-enum.md) | Optional | The Type of a merchant's business. |
| `BusinessDescription` | `string` | Optional | Description of Goods or Services.<br>**Constraints**: *Maximum Length*: `200` |
| `SwipedPercent` | `int?` | Optional | Card present/swiped percentage<br>**Constraints**: `>= 0`, `<= 100` |
| `KeyedPercent` | `int?` | Optional | Card not present/keyed percentage<br>**Constraints**: `>= 0`, `<= 100` |
| `EcommercePercent` | `int?` | Optional | eCommerce percentage.<br>**Constraints**: `>= 0`, `<= 100` |
| `OwnershipType` | [`OwnershipTypeEnum?`](../../doc/models/ownership-type-enum.md) | Optional | The Ownership Type of the merchant's business.<br>**Constraints**: *Maximum Length*: `10` |
| `FedTaxId` | `string` | Optional | Federal Tax ID (EIN).<br>**Constraints**: *Maximum Length*: `10` |
| `CcAverageTicketRange` | `int?` | Optional | Average Transaction Amount Range<br>**Constraints**: `>= 1`, `<= 7` |
| `CcMonthlyVolumeRange` | `int?` | Optional | Monthly Processing Volume Range<br>**Constraints**: `>= 1`, `<= 7` |
| `CcHighTicket` | `int?` | Optional | Highest transaction amount rounded to the next dollar<br>**Constraints**: `>= 0`, `<= 30000` |
| `EcAverageTicketRange` | `int?` | Optional | Average Transaction Amount Range<br>**Constraints**: `>= 1`, `<= 7` |
| `EcMonthlyVolumeRange` | `int?` | Optional | Monthly Processing Volume Range<br>**Constraints**: `>= 1`, `<= 7` |
| `EcHighTicket` | `int?` | Optional | Highest transaction amount rounded to the next dollar<br>**Constraints**: `>= 0`, `<= 30000` |
| `Website` | `string` | Optional | Merchant's business website.<br>**Constraints**: *Maximum Length*: `100` |
| `BankAccount` | [`BankAccount1`](../../doc/models/bank-account-1.md) | Required | The Bank Account. |
| `AltBankAccount` | [`AltBankAccount`](../../doc/models/alt-bank-account.md) | Required | The Alternative Bank Account. |
| `LegalName` | `string` | Optional | Merchant legal name.<br>**Constraints**: *Maximum Length*: `100` |
| `Contact` | [`Contact`](../../doc/models/contact.md) | Required | The Contact. |
| `ClientAppId` | `string` | Required | Client Issues Id to track that can be used to track each submitted merchant application. This id should be generated and sent in the request payload, and will be returned in the response payload. If no id is submitted in the payload request, this field will be null in the response.<br>**Constraints**: *Maximum Length*: `20` |
| `AppLink` | `string` | Optional | A full page or iframeable link, set in the request app_delivery field, that can be used to retrieve and resume the generated merchant application. No link will be returned if app_delivery is direct<br>**Constraints**: *Maximum Length*: `400` |

## Example (as JSON)

```json
{
  "parent_id": "11e95f8ec39de8fbdb0a4f1a",
  "primary_principal": {
    "first_name": "Bob",
    "last_name": "Fairview",
    "middle_name": "Nathaniel",
    "title": "Dr",
    "date_of_birth": "2021-12-01",
    "address_line_1": "1354 Oak St.",
    "address_line_2": "Unit 203",
    "city": "Dover",
    "state_province": "DE",
    "postal_code": "55022",
    "ownership_percent": 100,
    "phone_number": "555-555-1234"
  },
  "template_code": "1234YourTemplateCode",
  "email": "jtodd@example.com",
  "dba_name": "Discount Home Goods",
  "location": {
    "address_line_1": "1200 West Hartford Pkwy",
    "address_line_2": "Suite 2000",
    "city": "Dover",
    "state_province": "DE",
    "postal_code": "55022",
    "phone_number": "555-555-1212"
  },
  "app_delivery": "link_full_page",
  "business_category": "education",
  "swiped_percent": 0,
  "keyed_percent": 0,
  "ecommerce_percent": 100,
  "ownership_type": "llp",
  "fed_tax_id": "0000000000",
  "cc_average_ticket_range": 5,
  "cc_monthly_volume_range": 1,
  "cc_high_ticket": 1500,
  "ec_average_ticket_range": 5,
  "ec_monthly_volume_range": 2,
  "ec_high_ticket": 1500,
  "website": "http://www.example.com",
  "bank_account": {
    "routing_number": "011103093",
    "account_number": "01234567890123",
    "account_holder_name": "Bob Fairview"
  },
  "alt_bank_account": {
    "routing_number": "011103093",
    "account_number": "01234567890123",
    "account_holder_name": "Bob Fairview",
    "deposit_type": "fees_adjustments"
  },
  "legal_name": "Total Home Goods, LLP",
  "contact": {
    "first_name": "Jeffery",
    "last_name": "Todd",
    "email": "jtodd@example.com",
    "phone_number": "555-555-3456"
  },
  "client_app_id": "ABC123",
  "app_link": "https://mpa.example.com/signup/123456788",
  "business_type": "painting",
  "business_description": "business_description6"
}
```

