
# Response Tag

## Structure

`ResponseTag`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"Tag"` |
| `Data` | [`Data18`](../../doc/models/data-18.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "Tag",
  "data": {
    "location_id": "location_id4",
    "title": "title6",
    "id": "id0",
    "created_ts": 114,
    "modified_ts": 190,
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
    }
  }
}
```

