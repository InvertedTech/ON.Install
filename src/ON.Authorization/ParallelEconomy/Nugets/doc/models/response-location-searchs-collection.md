
# Response Location Searchs Collection

## Structure

`ResponseLocationSearchsCollection`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"LocationSearchsCollection"` |
| `List` | [`List<List5>`](../../doc/models/list-5.md) | Required | Resource Members |
| `Links` | [`Links`](../../doc/models/links.md) | Optional | Pagination page links |
| `Pagination` | [`Pagination`](../../doc/models/pagination.md) | Optional | Pagination info |
| `Sort` | [`Sort`](../../doc/models/sort.md) | Optional | Sort information used on the results |

## Example (as JSON)

```json
{
  "type": "LocationSearchsCollection",
  "list": [
    {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "account_number": "5454545454545454",
      "branding_domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_email_trx_receipt_default": true,
      "default_ach": "11e608a7d515f1e093242bb2",
      "default_cc": "11e608a442a5f1e092242dda",
      "email_reply_to": "email@domain.com",
      "fax": "3339998822",
      "location_api_id": "location-111111",
      "location_api_key": "AE34BBCAADF4AE34BBCAADF4",
      "location_c1": "custom 1",
      "location_c2": "custom 2",
      "location_c3": "custom data 3",
      "name": "Sample Company Headquarters",
      "office_phone": "2481234567",
      "office_ext_phone": "1021021209",
      "tz": "America/New_York",
      "parent_id": "11ed3e73adb98c0282f3fa9b",
      "show_contact_notes": true,
      "show_contact_files": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_type": "merchant",
      "branding_domain_url": "subdomain.sandbox.domain.com",
      "branding_domain": {
        "key1": "val1",
        "key2": "val2"
      },
      "product_transactions": [
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
        }
      ],
      "terminals": [
        {
          "key1": "val1",
          "key2": "val2"
        }
      ],
      "address": {
        "city": "city6",
        "state": "state2",
        "postal_code": "postal_code8",
        "country": "US",
        "street": "street6"
      }
    }
  ],
  "links": {
    "type": "type4",
    "first": "first0",
    "previous": "previous2",
    "last": "last4"
  },
  "pagination": {
    "type": "type6",
    "total_count": 100,
    "page_count": 212,
    "page_number": 28,
    "page_size": 6
  },
  "sort": {
    "type": "type2",
    "fields": [
      {
        "field": "field2",
        "order": "asc"
      },
      {
        "field": "field2",
        "order": "asc"
      },
      {
        "field": "field2",
        "order": "asc"
      }
    ]
  }
}
```

