
# Data 9

## Structure

`Data9`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ParentId` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `TemplateId` | `string` | Optional | The ID of the template to be used - this value will be provided by Fortis.<br>**Constraints**: *Maximum Length*: `20`, *Pattern*: `^[a-zA-Z0-9]*$` |
| `ClientAppId` | `string` | Optional | Client Issues Id to track that can be used to track each submitted merchant application. This id should be generated and sent in the request payload, and will be returned in the response payload. If no id is submitted in the payload request, this field will be null in the response.<br>**Constraints**: *Maximum Length*: `50` |
| `Email` | `string` | Required | Merchant email address.<br>**Constraints**: *Maximum Length*: `100` |
| `DbaName` | `string` | Required | Merchant 'Doing Business As' name.<br>**Constraints**: *Maximum Length*: `100` |
| `LegalName` | `string` | Optional | Merchant legal name.<br>**Constraints**: *Maximum Length*: `100` |
| `Website` | `string` | Optional | Merchant's business website.<br>**Constraints**: *Maximum Length*: `100` |
| `PhoneNumber` | `string` | Required | Merchant's phone number.<br>**Constraints**: *Maximum Length*: `10` |
| `OwnershipType` | [`OwnershipTypeEnum`](../../doc/models/ownership-type-enum.md) | Required | The Ownership Type of the merchant's business.<br>**Constraints**: *Maximum Length*: `10` |
| `FedTaxId` | `string` | Required | Federal Tax ID (EIN).<br>**Constraints**: *Maximum Length*: `10` |
| `AverageTicket` | `int` | Required | Average Transaction Amount.<br>**Constraints**: `>= 1`, `<= 99999` |
| `HighTicket` | `int` | Required | Highest transaction amount rounded to the next dollar<br>**Constraints**: `>= 1`, `<= 30000` |
| `CcMonthlyVolume` | `int` | Required | Average monthly credit card volume rounded to the next dollar.<br>**Constraints**: `>= 1` |
| `EcMonthlyVolume` | `int?` | Optional | Average monthly echeck volume rounded to the next dollar.<br>**Constraints**: `>= 1` |
| `MccCode` | `string` | Required | Merchant's MCC code.<br>**Constraints**: *Maximum Length*: `10` |
| `BusinessDescription` | `string` | Required | Description of Goods or Services.<br>**Constraints**: *Maximum Length*: `200` |
| `SwipedPercent` | `int` | Required | Card present/swiped percentage<br>**Constraints**: `>= 0`, `<= 100` |
| `KeyedPercent` | `int` | Required | Card not present/keyed percentage<br>**Constraints**: `>= 0`, `<= 100` |
| `EcommercePercent` | `int` | Required | eCommerce percentage.<br>**Constraints**: `>= 0`, `<= 100` |
| `IsForeignEntity` | `bool` | Required | Indicates whether or not the merchant is a foreign entity. |
| `PersonallyGuaranteed` | `bool` | Required | Indicates whether or not the merchant is personally guaranteed. |
| `PreferredLanguage` | [`PreferredLanguageEnum?`](../../doc/models/preferred-language-enum.md) | Optional | Merchant preferred language. English(“en-US”) will be used if no value is supplied. |
| `Addresses` | [`List<Address22>`](../../doc/models/address-22.md) | Required | - |
| `Owners` | [`List<Owner>`](../../doc/models/owner.md) | Required | - |
| `BankAccounts` | [`List<BankAccount>`](../../doc/models/bank-account.md) | Required | - |
| `Documents` | [`List<Document>`](../../doc/models/document.md) | Optional | - |
| `PricingElements` | [`List<PricingElement>`](../../doc/models/pricing-element.md) | Optional | - |
| `KycResponseObjects` | [`List<KycResponseObject>`](../../doc/models/kyc-response-object.md) | Optional | - |
| `Metadata` | `object` | Optional | Valid JSON of metadata related to merchant. |
| `Result` | [`Result`](../../doc/models/result.md) | Optional | - |
| `Status` | [`Status5`](../../doc/models/status-5.md) | Optional | - |

## Example (as JSON)

```json
{
  "parent_id": "11e95f8ec39de8fbdb0a4f1a",
  "template_id": "1234YourTemplateCode",
  "client_app_id": "ABC123",
  "email": "email@domain.com",
  "dba_name": "Discount Home Goods",
  "legal_name": "Total Home Goods, LLP",
  "website": "http://www.example.com",
  "phone_number": "5555551234",
  "ownership_type": "llp",
  "fed_tax_id": "0000000000",
  "average_ticket": 15,
  "high_ticket": 150,
  "cc_monthly_volume": 100,
  "ec_monthly_volume": 22,
  "mcc_code": "7629",
  "business_description": "Yard services.",
  "swiped_percent": 0,
  "keyed_percent": 0,
  "ecommerce_percent": 100,
  "is_foreign_entity": true,
  "personally_guaranteed": false,
  "preferred_language": "fr-CA",
  "addresses": [
    {
      "address_line_1": "121 E Main",
      "address_line_2": "Apt 707",
      "city": "Dallas",
      "state_province": "TX",
      "postal_code": "75087",
      "country_code": "US",
      "address_type": "location"
    }
  ],
  "owners": [
    {
      "first_name": "James",
      "last_name": "Bond",
      "middle_name": "Tyler",
      "title": "CEO",
      "date_of_birth": "2021-12-01",
      "address_line_1": "133 S Goliad St",
      "address_line_2": "Suite 120",
      "city": "Rockwall",
      "state_province": "TX",
      "postal_code": "75429",
      "country_code": "US",
      "ssn": "000000000",
      "ownership_percent": 100,
      "phone_number": "9042142323",
      "email_address": "james@example.com",
      "is_controller": true,
      "is_signer": true
    }
  ],
  "bank_accounts": [
    {
      "account_holder_name": "James Bond",
      "routing_number": "111111111",
      "account_number": "1234567",
      "is_primary": true,
      "account_type": "checking",
      "alt_deposit_types": [
        "alt_deposit_types0"
      ]
    }
  ]
}
```

