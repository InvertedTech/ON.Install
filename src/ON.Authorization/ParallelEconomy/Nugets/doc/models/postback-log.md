
# Postback Log

## Structure

`PostbackLog`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `PostbackStatusId` | [`PostbackStatusIdEnum?`](../../doc/models/postback-status-id-enum.md) | Optional | Postback Status Id |
| `Id` | `string` | Required | Postback Log Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `PostbackConfigId` | `string` | Required | Postback Config Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ChangelogId` | `string` | Required | Changelog Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `HttpVerb` | `string` | Optional | Http Verb |
| `NextRunTs` | `int?` | Optional | Next Run |
| `CreatedTs` | `int?` | Optional | Created Time Stamp |
| `Model` | `string` | Optional | MOdel |
| `ModelId` | `string` | Optional | Model Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
  "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
  "next_run_ts": 1422040992,
  "created_ts": 1422040992,
  "model_id": "11e95f8ec39de8fbdb0a4f1a",
  "postback_status_id": 3,
  "http_verb": "http_verb8",
  "model": "model6"
}
```

