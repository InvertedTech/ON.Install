
# Field 16

## Structure

`Field16`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Required | id |
| `Label` | `string` | Required | Label |
| `FieldType` | `string` | Required | Field Type |
| `Position` | `List<string>` | Required | Position<br>**Constraints**: *Minimum Items*: `1` |
| `Required` | `bool?` | Optional | Required |
| `Readonly` | `bool?` | Optional | Read Only |
| `Visible` | `bool?` | Optional | Visible |
| `MValue` | `string` | Optional | Value |

## Example (as JSON)

```json
{
  "id": "transaction_amount",
  "label": "Header",
  "field_type": "heading",
  "position": [
    "1",
    "0",
    "1",
    "1"
  ],
  "required": true,
  "readonly": true,
  "visible": true,
  "value": "value0"
}
```

