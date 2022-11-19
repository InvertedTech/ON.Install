
# Filter 7

You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods:

> /endpoint?filter={ "field_name": "Value" }
> 
> /endpoint?filter[field_name]=Value

## Structure

`Filter7`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Signature` | `string` | Optional | Signature |
| `Resource` | [`Models.ResourceEnum?`](../../doc/models/resource-enum.md) | Optional | Resource |
| `ResourceId` | `string` | Optional | Resource ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Id` | `string` | Optional | Signature ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int?` | Optional | Created Time Stamp |
| `ModifiedTs` | `int?` | Optional | Modified Time Stamp |

## Example (as JSON)

```json
{
  "signature": null,
  "resource": null,
  "resource_id": null,
  "id": null,
  "created_ts": null,
  "modified_ts": null
}
```

