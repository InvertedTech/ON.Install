
# V1 Tags Request 1

## Structure

`V1TagsRequest1`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationId` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Title` | `string` | Optional | Tag Title<br>**Constraints**: *Maximum Length*: `64` |

## Example (as JSON)

```json
{
  "location_id": null,
  "title": null
}
```

