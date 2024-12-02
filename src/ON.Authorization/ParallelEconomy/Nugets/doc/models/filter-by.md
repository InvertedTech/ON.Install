
# Filter By

## Structure

`FilterBy`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Key` | `string` | Required | Resource key to filter by |
| `Operator` | [`FilterByOperator`](../../doc/models/containers/filter-by-operator.md) | Required | This is a container for one-of cases. |
| `MValue` | [`FilterByValue`](../../doc/models/containers/filter-by-value.md) | Required | This is a container for one-of cases. |

## Example (as JSON)

```json
{
  "key": "first_name",
  "operator": "<=",
  "value": "Fred"
}
```

