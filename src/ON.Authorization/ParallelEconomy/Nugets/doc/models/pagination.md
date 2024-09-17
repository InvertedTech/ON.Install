
# Pagination

Pagination info

## Structure

`Pagination`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Object type<br>**Default**: `"Pagination"` |
| `TotalCount` | `int?` | Optional | Total records count |
| `PageCount` | `int?` | Optional | Total page count |
| `PageNumber` | `int?` | Optional | Current page |
| `PageSize` | `int?` | Optional | Page size |

## Example (as JSON)

```json
{
  "type": "Pagination",
  "total_count": 423,
  "page_count": 42,
  "page_number": 6,
  "page_size": 10
}
```

