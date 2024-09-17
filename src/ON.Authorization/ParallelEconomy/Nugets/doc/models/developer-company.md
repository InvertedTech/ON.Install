
# Developer Company

Developer Company Information on `expand`

## Structure

`DeveloperCompany`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Title` | `string` | Required | Title<br>**Constraints**: *Maximum Length*: `64` |
| `Description` | `string` | Optional | Description<br>**Constraints**: *Maximum Length*: `64` |
| `Id` | `string` | Required | Developer Company Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Active` | `bool` | Required | Active |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |
| `CreatedUserId` | `string` | Optional | User ID Created the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ModifiedUserId` | `string` | Optional | Last User ID that updated the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "title": "My terminal",
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "active": true,
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "description": "description2"
}
```

