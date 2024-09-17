
# Response Location

## Structure

`ResponseLocation`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"Location"` |
| `Data` | [`Data10`](../../doc/models/data-10.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "Location",
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
    "parent_id": "parent_id6"
  }
}
```

