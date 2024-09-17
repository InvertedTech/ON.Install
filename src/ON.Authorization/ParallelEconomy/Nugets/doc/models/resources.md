
# Resources

Resource Information on `expand`

## Structure

`Resources`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Title` | `string` | Required | Resource Title<br>**Constraints**: *Maximum Length*: `64` |
| `Priv` | `string` | Optional | Priv<br>**Constraints**: *Maximum Length*: `64` |
| `ResourceName` | `string` | Required | Resource Name<br>**Constraints**: *Maximum Length*: `64` |
| `Id` | `int` | Required | Resource ID |
| `LastUsedDate` | `int?` | Optional | Last Used Date |
| `CreatedTs` | `int?` | Optional | Created Time Stamp |
| `ModifiedTs` | `int?` | Optional | Modified Time Stamp |

## Example (as JSON)

```json
{
  "title": "My terminal",
  "resource_name": "v2.addons.iframe.get",
  "id": 5693,
  "last_used_date": 1422040992,
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "priv": "priv0"
}
```

