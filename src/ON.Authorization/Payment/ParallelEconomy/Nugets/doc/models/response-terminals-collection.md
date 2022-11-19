
# Response Terminals Collection

## Structure

`ResponseTerminalsCollection`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"TerminalsCollection"` |
| `List` | [`List<Models.List9>`](../../doc/models/list-9.md) | Required | Resource Members |

## Example (as JSON)

```json
{
  "type": "TerminalsCollection",
  "list": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "terminal_application_id": "11e95f8ec39de8fbdb0a4f1a",
    "terminal_manufacturer_code": 1,
    "title": "My terminal",
    "local_ip_address": "192.168.0.10",
    "port": 10009,
    "serial_number": "1234567890",
    "terminal_number": "973456789012367",
    "debit": false,
    "emv": false,
    "cashback_enable": false,
    "print_enable": false,
    "sig_capture_enable": false,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "last_registration_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

