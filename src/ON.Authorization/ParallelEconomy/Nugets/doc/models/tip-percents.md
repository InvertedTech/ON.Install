
# Tip Percents

A JSON of tip percents the JSON MUST contain only these three fields: percent_1, percent_2, percent_3

## Structure

`TipPercents`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Percent1` | `int?` | Optional | field can only contain a value from 0 to 99, if 1 field is NULL, all fields must be null.<br>**Constraints**: `>= 0`, `<= 99` |
| `Percent2` | `int?` | Optional | field can only contain a value from 0 to 99, if 1 field is NULL, all fields must be null.<br>**Constraints**: `>= 0`, `<= 99` |
| `Percent3` | `int?` | Optional | field can only contain a value from 0 to 99, if 1 field is NULL, all fields must be null.<br>**Constraints**: `>= 0`, `<= 99` |

## Example (as JSON)

```json
{
  "percent_1": 0,
  "percent_2": 2,
  "percent_3": 99
}
```

