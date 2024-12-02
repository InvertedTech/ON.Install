
# Pricing Element

Array of pricing items from template to be changed.

## Structure

`PricingElement`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ItemId` | `int` | Required | Item ID.<br>**Constraints**: `>= 0` |
| `ItemValue` | `double` | Required | Item value.<br>**Constraints**: `>= 0` |
| `ItemTerm` | `int` | Required | Item term.<br>**Constraints**: `>= 0` |
| `ItemDescription` | `string` | Optional | Item desciption.<br>**Constraints**: *Maximum Length*: `100` |

## Example (as JSON)

```json
{
  "item_id": 5,
  "item_value": 1.5,
  "item_term": 2,
  "item_description": "AVS fee."
}
```

