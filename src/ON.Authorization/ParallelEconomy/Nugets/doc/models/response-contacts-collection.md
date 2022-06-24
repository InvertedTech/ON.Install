
# Response Contacts Collection

## Structure

`ResponseContactsCollection`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"ContactsCollection"` |
| `List` | [`List<Models.List1>`](../../doc/models/list-1.md) | Required | Resource Members |

## Example (as JSON)

```json
{
  "type": "ContactsCollection",
  "list": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "last_name": "Smith",
    "email_trx_receipt": true,
    "header_message_type": 0,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "active": 1
  }
}
```

