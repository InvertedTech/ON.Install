
# Response Terminals Collection

## Structure

`ResponseTerminalsCollection`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"TerminalsCollection"` |
| `List` | [`List<List13>`](../../doc/models/list-13.md) | Required | Resource Members |
| `Links` | [`Links`](../../doc/models/links.md) | Optional | Pagination page links |
| `Pagination` | [`Pagination`](../../doc/models/pagination.md) | Optional | Pagination info |
| `Sort` | [`Sort`](../../doc/models/sort.md) | Optional | Sort information used on the results |

## Example (as JSON)

```json
{
  "type": "TerminalsCollection",
  "list": [
    {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "default_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_application_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_cvm_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_manufacturer_code": "1",
      "title": "My terminal",
      "mac_address": "3D:F2:C9:A6:B3:4F",
      "local_ip_address": "192.168.0.10",
      "port": 10009,
      "serial_number": "1234567890",
      "terminal_number": "973456789012367",
      "header_line_1": "line 1 sample",
      "header_line_2": "line 2 sample",
      "header_line_3": "line 3 sample",
      "header_line_4": "line 4 sample",
      "header_line_5": "line 5 sample",
      "trailer_line_1": "trailer 1 sample",
      "trailer_line_2": "trailer 2 sample",
      "trailer_line_3": "trailer 3 sample",
      "trailer_line_4": "trailer 4 sample",
      "trailer_line_5": "trailer 5 sample",
      "default_checkin": "2021-12-01",
      "default_checkout": "2021-12-01",
      "default_room_rate": 56,
      "default_room_number": "303",
      "debit": false,
      "emv": false,
      "cashback_enable": false,
      "print_enable": false,
      "sig_capture_enable": false,
      "is_provisioned": false,
      "tip_enable": false,
      "validated_decryption": false,
      "communication_type": "http",
      "active": true,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "last_registration_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "has_terminal_routers": true
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

