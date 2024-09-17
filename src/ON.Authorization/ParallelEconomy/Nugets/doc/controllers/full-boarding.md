# Full Boarding

```csharp
FullBoardingController fullBoardingController = client.FullBoardingController;
```

## Class Name

`FullBoardingController`


# Merchant Boarding Full

This method is used to fully board a merchant to the platform. When using this method, you must provide data for each "Required" property. See the description for each of these properties for more information about their requirement criteria.

```csharp
MerchantBoardingFullAsync(
    Models.V1FullboardingRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1FullboardingRequest`](../../doc/models/v1-fullboarding-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseFullboarding>`](../../doc/models/response-fullboarding.md)

## Example Usage

```csharp
V1FullboardingRequest body = new V1FullboardingRequest
{
    Email = "email@domain.com",
    DbaName = "Discount Home Goods",
    PhoneNumber = "5555551234",
    OwnershipType = OwnershipTypeEnum.Llp,
    FedTaxId = "0000000000",
    AverageTicket = 15,
    HighTicket = 150,
    CcMonthlyVolume = 100,
    MccCode = "7629",
    BusinessDescription = "Yard services.",
    SwipedPercent = 0,
    KeyedPercent = 0,
    EcommercePercent = 100,
    IsForeignEntity = true,
    PersonallyGuaranteed = false,
    Addresses = new List<Models.Address22>
    {
        new Address22
        {
            AddressLine1 = "121 E Main",
            City = "Dallas",
            StateProvince = "TX",
            PostalCode = "75087",
            CountryCode = "US",
            AddressType = AddressTypeEnum.Location,
            AddressLine2 = "Apt 707",
        },
    },
    Owners = new List<Models.Owner>
    {
        new Owner
        {
            FirstName = "James",
            LastName = "Bond",
            Title = "CEO",
            DateOfBirth = "2021-12-01",
            AddressLine1 = "133 S Goliad St",
            AddressLine2 = "Suite 120",
            City = "Rockwall",
            StateProvince = "TX",
            PostalCode = "75429",
            CountryCode = "US",
            Ssn = "000000000",
            OwnershipPercent = 100,
            PhoneNumber = "9042142323",
            EmailAddress = "james@example.com",
            IsController = true,
            IsSigner = true,
            MiddleName = "Tyler",
        },
    },
    BankAccounts = new List<Models.BankAccount>
    {
        new BankAccount
        {
            AccountHolderName = "James Bond",
            RoutingNumber = "111111111",
            AccountNumber = "1234567",
            AccountType = AccountTypeEnum.Checking,
            IsPrimary = true,
        },
    },
    ParentId = "11e95f8ec39de8fbdb0a4f1a",
    TemplateId = "1234YourTemplateCode",
    ClientAppId = "ABC123",
    LegalName = "Total Home Goods, LLP",
    Website = "http://www.example.com",
    EcMonthlyVolume = 22,
    PreferredLanguage = PreferredLanguageEnum.FrCA,
};

try
{
    ResponseFullboarding result = await fullBoardingController.MerchantBoardingFullAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Example Response *(as JSON)*

```json
{
  "type": "Fullboarding",
  "data": {
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
          "fees"
        ]
      }
    ],
    "documents": [
      {
        "document_name": "ImportantDoc.txt",
        "document_data": "alskj;asijia;eiom;weirj;iomj",
        "mime_type": "application/json"
      }
    ],
    "pricing_elements": [
      {
        "item_id": 5,
        "item_value": 1.5,
        "item_term": 2,
        "item_description": "AVS fee."
      }
    ],
    "kyc_response_objects": [
      {
        "value": "KYC value.",
        "type": "KYC type"
      }
    ],
    "metadata": {},
    "result": {
      "client_app_id": "ABC123",
      "epic_app_id": "4477",
      "dba_name": "Discount Home Goods",
      "email": "jtodd@example.com"
    },
    "status": {
      "response_code": "Received"
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |

