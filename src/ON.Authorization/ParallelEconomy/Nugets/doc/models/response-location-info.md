
# Response Location Info

## Structure

`ResponseLocationInfo`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"LocationInfo"` |
| `Data` | [`Data11`](../../doc/models/data-11.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "LocationInfo",
  "data": {
    "id": "id0",
    "created_ts": 114,
    "modified_ts": 190,
    "account_number": "account_number0",
    "address": {
      "city": "city6",
      "state": "state2",
      "postal_code": "postal_code8",
      "country": "US",
      "street": "street6"
    },
    "branding_domain_id": "branding_domain_id4",
    "contact_email_trx_receipt_default": false,
    "default_ach": "default_ach4",
    "name": "name0",
    "branding_domain": {
      "key1": "val1",
      "key2": "val2"
    },
    "product_transactions": [
      {
        "key1": "val1",
        "key2": "val2"
      },
      {
        "key1": "val1",
        "key2": "val2"
      }
    ],
    "product_file": {
      "key1": "val1",
      "key2": "val2"
    },
    "product_accountvault": {
      "key1": "val1",
      "key2": "val2"
    },
    "product_recurring": {
      "key1": "val1",
      "key2": "val2"
    },
    "tags": [
      {
        "key1": "val1",
        "key2": "val2"
      },
      {
        "key1": "val1",
        "key2": "val2"
      },
      {
        "key1": "val1",
        "key2": "val2"
      }
    ],
    "terminals": [
      {
        "key1": "val1",
        "key2": "val2"
      },
      {
        "key1": "val1",
        "key2": "val2"
      }
    ]
  }
}
```

