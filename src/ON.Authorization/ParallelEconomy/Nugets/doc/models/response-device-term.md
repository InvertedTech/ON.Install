
# Response Device Term

## Structure

`ResponseDeviceTerm`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"DeviceTerm"` |
| `Data` | [`Data6`](../../doc/models/data-6.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "DeviceTerm",
  "data": {
    "location_id": "location_id4",
    "terminal_id": "terminal_id6",
    "require_signature": false,
    "device_term_api_id": "device_term_api_id0",
    "terms_conditions": "terms_conditions0",
    "id": "id0",
    "reason_code_id": 250,
    "signature": {
      "signature": "signature6",
      "resource": "Recurring",
      "resource_id": "resource_id4",
      "id": "id8",
      "created_ts": 80,
      "modified_ts": 4
    },
    "created_ts": 114,
    "modified_ts": 190,
    "created_user_id": "created_user_id2",
    "created_user": {
      "account_number": "account_number6",
      "branding_domain_url": "branding_domain_url4",
      "cell_phone": "cell_phone2",
      "company_name": "company_name2",
      "contact_id": "contact_id8",
      "email": "email0",
      "last_name": "last_name4",
      "primary_location_id": "primary_location_id6",
      "tz": "tz8",
      "username": "username6",
      "user_type_code": 300,
      "id": "id6",
      "status": false,
      "login_attempts": 52,
      "last_login_ts": 162,
      "created_ts": 232,
      "modified_ts": 52,
      "created_user_id": "created_user_id8",
      "current_date_time": "current_date_time6"
    },
    "location": {
      "id": "id4",
      "created_ts": 254,
      "modified_ts": 178,
      "account_number": "account_number6",
      "address": {
        "city": "city6",
        "state": "state2",
        "postal_code": "postal_code8",
        "country": "US",
        "street": "street6"
      },
      "branding_domain_id": "branding_domain_id8",
      "contact_email_trx_receipt_default": false,
      "default_ach": "default_ach8",
      "name": "name4",
      "parent_id": "parent_id0"
    },
    "terminal": {
      "location_id": "location_id6",
      "default_product_transaction_id": "default_product_transaction_id8",
      "terminal_application_id": "terminal_application_id2",
      "terminal_cvm_id": "terminal_cvm_id8",
      "terminal_manufacturer_code": "1",
      "title": "title2",
      "mac_address": "mac_address0",
      "local_ip_address": "local_ip_address4",
      "port": 70,
      "serial_number": "serial_number4",
      "debit": false,
      "emv": false,
      "cashback_enable": false,
      "print_enable": false,
      "sig_capture_enable": false,
      "id": "id2",
      "created_ts": 130,
      "modified_ts": 54,
      "last_registration_ts": 10,
      "created_user_id": "created_user_id6",
      "modified_user_id": "modified_user_id6"
    }
  }
}
```

