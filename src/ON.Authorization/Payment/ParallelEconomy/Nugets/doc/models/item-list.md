
# Item List

## Structure

`ItemList`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Name` | `string` | Required | Item's Name, must be unique on the list<br>**Constraints**: *Maximum Length*: `100` |
| `Amount` | `double` | Required | Item's Amount<br>**Constraints**: `>= 0`, `<= 9999999.99` |

## Example (as JSON)

```json
{
  "name": "Bread",
  "amount": 20.15
}
```

