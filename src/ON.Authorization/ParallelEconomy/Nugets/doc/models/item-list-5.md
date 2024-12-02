
# Item List 5

## Structure

`ItemList5`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Name` | `string` | Optional | Item's Name, must be unique on the list<br>**Constraints**: *Maximum Length*: `100` |
| `Amount` | `int?` | Optional | Item's Amount<br>**Constraints**: `>= -999999999`, `<= 999999999` |

## Example (as JSON)

```json
{
  "name": "Bread",
  "amount": 2015
}
```

