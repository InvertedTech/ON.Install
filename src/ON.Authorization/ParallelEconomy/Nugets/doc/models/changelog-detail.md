
# Changelog Detail

## Structure

`ChangelogDetail`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ChangelogId` | `string` | Optional | Changelog ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Field` | `string` | Optional | Field |
| `OldValue` | `string` | Optional | Old Value |

## Example (as JSON)

```json
{
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
  "field": "next_run_ts",
  "old_value": "1643616000"
}
```

