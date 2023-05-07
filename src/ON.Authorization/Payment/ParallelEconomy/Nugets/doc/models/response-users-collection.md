
# Response Users Collection

## Structure

`ResponseUsersCollection`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"UsersCollection"` |
| `List` | [`List<Models.List12>`](../../doc/models/list-12.md) | Required | Resource Members |

## Example (as JSON)

```json
{
  "type": "UsersCollection",
  "list": {
    "email": "email@domain.com",
    "last_name": "Smith",
    "primary_location_id": "11e95f8ec39de8fbdb0a4f1a",
    "tz": "America/New_York",
    "username": "{user_name}",
    "user_type_code": 100,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "status": true,
    "login_attempts": 0,
    "last_login_ts": 1422040992,
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "current_date_time": "03/11/2019 17:38:26"
  }
}
```

