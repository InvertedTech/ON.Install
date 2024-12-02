
# List 4

## Structure

`List4`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationId` | `string` | Required | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `TerminalId` | `string` | Required | Terminal ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `RequireSignature` | `bool` | Required | Set to true or 1 to require a signature from the customer |
| `DeviceTermApiId` | `string` | Optional | Can be used for associating record to external systems. Must be unique per location.<br>**Constraints**: *Maximum Length*: `64` |
| `TermsConditions` | `string` | Required | This is the message that is displayed on the screen when prompting for a signature.<br>**Constraints**: *Maximum Length*: `4096` |
| `Id` | `string` | Required | Device term ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ReasonCodeId` | `int` | Required | Reason code ID |
| `Signature` | [`Signature`](../../doc/models/signature.md) | Optional | Signature Information on `expand` |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |
| `CreatedUserId` | `string` | Required | System generated id for user who created record<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedUser` | [`CreatedUser`](../../doc/models/created-user.md) | Optional | User Information on `expand` |
| `Location` | [`Location`](../../doc/models/location.md) | Optional | Location Information on `expand` |
| `Terminal` | [`Terminal`](../../doc/models/terminal.md) | Optional | Terminal Information on `expand` |
| `Changelogs` | [`List<Changelog>`](../../doc/models/changelog.md) | Optional | Changelog Information on `expand` |
| `ReasonCode` | [`ReasonCode`](../../doc/models/reason-code.md) | Optional | Reason Code Information on `expand` |

## Example (as JSON)

```json
{
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "terminal_id": "11e95f8ec39de8fbdb0a4f1a",
  "require_signature": true,
  "device_term_api_id": "device_term134",
  "terms_conditions": "FUNgib0Vh0B9c0Wbttvr50vNtGLOkTdFL0eFmhN1RJpKhK14IENeDa8irp2dEk9thEcVHvVEyriQeZLs5NjNsCzqNj9JDA4RSJwK647IFtYjrNPN1nBb9bw6hoQ71oT5kpsiXGt8HcqBFVBVeDA7psIzKAyDveAw2o1hfjipkOtXrPgWun0rYwyyFuvqkT1egQYKfYDj",
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "reason_code_id": 1000,
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "signature": {
    "signature": "signature6",
    "resource": "Recurring",
    "resource_id": "resource_id4",
    "id": "id8",
    "created_ts": 80,
    "modified_ts": 4
  },
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
```

