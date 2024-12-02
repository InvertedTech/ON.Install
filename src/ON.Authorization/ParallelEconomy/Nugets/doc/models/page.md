
# Page

Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:

> /endpoint?page={ "number": 1, "size": 50 }
> 
> /endpoint?page[number]=1&page[size]=50

## Structure

`Page`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Number` | `int?` | Optional | The current page number of the page to be retrieved.<br>**Constraints**: `>= 1` |
| `Size` | `int?` | Optional | The maximum number of records ta will be returned per page.<br>**Constraints**: `>= 1`, `<= 5000` |

## Example (as JSON)

```json
{
  "number": 1,
  "size": 50
}
```

