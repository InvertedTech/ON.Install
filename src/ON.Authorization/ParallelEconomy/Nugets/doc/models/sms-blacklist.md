
# Sms Blacklist

Sms Blacklist Information on `expand`

## Structure

`SmsBlacklist`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | Blacklist ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `IsBlacklisted` | `bool?` | Optional | isBlacklisted |
| `Detail` | `bool?` | Optional | Contact Id |
| `CreatedTs` | `int?` | Optional | Created Time Stamp |

## Example (as JSON)

```json
{
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "isBlacklisted": true,
  "detail": true,
  "created_ts": 1422040992
}
```

