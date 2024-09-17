
# Response Onboarding

## Structure

`ResponseOnboarding`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"Onboarding"` |
| `Data` | [`Data12`](../../doc/models/data-12.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "Onboarding",
  "data": {
    "parent_id": "parent_id6",
    "primary_principal": {
      "first_name": "first_name6",
      "last_name": "last_name4",
      "middle_name": "middle_name6",
      "title": "title2",
      "date_of_birth": "date_of_birth2",
      "address_line_1": "address_line_14",
      "address_line_2": "address_line_26"
    },
    "template_code": "template_code0",
    "email": "email6",
    "dba_name": "dba_name8",
    "location": {
      "address_line_1": "address_line_16",
      "address_line_2": "address_line_24",
      "city": "city6",
      "state_province": "state_province6",
      "postal_code": "postal_code6",
      "phone_number": "phone_number8"
    },
    "app_delivery": "app_delivery2",
    "business_category": "health_care_and_fitness",
    "business_type": "nanny_services",
    "business_description": "business_description8",
    "swiped_percent": 118,
    "bank_account": {
      "routing_number": "routing_number8",
      "account_number": "account_number4",
      "account_holder_name": "account_holder_name6"
    },
    "alt_bank_account": {
      "routing_number": "routing_number4",
      "account_number": "account_number0",
      "account_holder_name": "account_holder_name0",
      "deposit_type": "deposit_type4"
    },
    "contact": {
      "first_name": "first_name2",
      "last_name": "last_name0",
      "email": "email4",
      "phone_number": "phone_number0"
    },
    "client_app_id": "client_app_id6"
  }
}
```

