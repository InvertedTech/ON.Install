
# Response Fullboarding

## Structure

`ResponseFullboarding`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"Fullboarding"` |
| `Data` | [`Data9`](../../doc/models/data-9.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "Fullboarding",
  "data": {
    "parent_id": "parent_id6",
    "template_id": "template_id0",
    "client_app_id": "client_app_id6",
    "email": "email6",
    "dba_name": "dba_name8",
    "legal_name": "legal_name8",
    "website": "website6",
    "phone_number": "phone_number8",
    "ownership_type": "sp",
    "fed_tax_id": "fed_tax_id2",
    "average_ticket": 54,
    "high_ticket": 2,
    "cc_monthly_volume": 88,
    "mcc_code": "mcc_code2",
    "business_description": "business_description8",
    "swiped_percent": 118,
    "keyed_percent": 42,
    "ecommerce_percent": 46,
    "is_foreign_entity": false,
    "personally_guaranteed": false,
    "addresses": [
      {
        "address_line_1": "address_line_16",
        "address_line_2": "address_line_24",
        "city": "city4",
        "state_province": "state_province6",
        "postal_code": "postal_code6",
        "country_code": "country_code4",
        "address_type": "corporate"
      },
      {
        "address_line_1": "address_line_16",
        "address_line_2": "address_line_24",
        "city": "city4",
        "state_province": "state_province6",
        "postal_code": "postal_code6",
        "country_code": "country_code4",
        "address_type": "corporate"
      },
      {
        "address_line_1": "address_line_16",
        "address_line_2": "address_line_24",
        "city": "city4",
        "state_province": "state_province6",
        "postal_code": "postal_code6",
        "country_code": "country_code4",
        "address_type": "corporate"
      }
    ],
    "owners": [
      {
        "first_name": "first_name4",
        "last_name": "last_name2",
        "middle_name": "middle_name4",
        "title": "title0",
        "date_of_birth": "date_of_birth4",
        "address_line_1": "address_line_16",
        "address_line_2": "address_line_24",
        "city": "city4",
        "state_province": "state_province6",
        "postal_code": "postal_code6",
        "country_code": "country_code4",
        "ssn": "ssn0",
        "ownership_percent": 134,
        "phone_number": "phone_number8",
        "email_address": "email_address2",
        "is_controller": false,
        "is_signer": false
      },
      {
        "first_name": "first_name4",
        "last_name": "last_name2",
        "middle_name": "middle_name4",
        "title": "title0",
        "date_of_birth": "date_of_birth4",
        "address_line_1": "address_line_16",
        "address_line_2": "address_line_24",
        "city": "city4",
        "state_province": "state_province6",
        "postal_code": "postal_code6",
        "country_code": "country_code4",
        "ssn": "ssn0",
        "ownership_percent": 134,
        "phone_number": "phone_number8",
        "email_address": "email_address2",
        "is_controller": false,
        "is_signer": false
      },
      {
        "first_name": "first_name4",
        "last_name": "last_name2",
        "middle_name": "middle_name4",
        "title": "title0",
        "date_of_birth": "date_of_birth4",
        "address_line_1": "address_line_16",
        "address_line_2": "address_line_24",
        "city": "city4",
        "state_province": "state_province6",
        "postal_code": "postal_code6",
        "country_code": "country_code4",
        "ssn": "ssn0",
        "ownership_percent": 134,
        "phone_number": "phone_number8",
        "email_address": "email_address2",
        "is_controller": false,
        "is_signer": false
      }
    ],
    "bank_accounts": [
      {
        "account_holder_name": "account_holder_name0",
        "routing_number": "routing_number4",
        "account_number": "account_number0",
        "is_primary": false,
        "account_type": "checking",
        "alt_deposit_types": [
          "alt_deposit_types0"
        ]
      },
      {
        "account_holder_name": "account_holder_name0",
        "routing_number": "routing_number4",
        "account_number": "account_number0",
        "is_primary": false,
        "account_type": "checking",
        "alt_deposit_types": [
          "alt_deposit_types0"
        ]
      },
      {
        "account_holder_name": "account_holder_name0",
        "routing_number": "routing_number4",
        "account_number": "account_number0",
        "is_primary": false,
        "account_type": "checking",
        "alt_deposit_types": [
          "alt_deposit_types0"
        ]
      }
    ]
  }
}
```

