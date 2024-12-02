
# Changelog

## Structure

`Changelog`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Required | Change Log ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int?` | Optional | Created Time Stamp |
| `Action` | `string` | Optional | Action<br>**Constraints**: *Maximum Length*: `255` |
| `Model` | `string` | Optional | Model<br>**Constraints**: *Maximum Length*: `255` |
| `ModelId` | `string` | Optional | Model ID<br>**Constraints**: *Maximum Length*: `255` |
| `UserId` | `string` | Optional | User ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ChangelogDetails` | [`List<ChangelogDetail>`](../../doc/models/changelog-detail.md) | Optional | Change Log Details |
| `User` | [`User`](../../doc/models/user.md) | Optional | User |

## Example (as JSON)

```json
{
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "created_ts": 1422040992,
  "action": "CREATE",
  "model": "TransactionRequest",
  "model_id": "11ec829598f0d4008be9aba4",
  "user_id": "11e95f8ec39de8fbdb0a4f1a"
}
```

