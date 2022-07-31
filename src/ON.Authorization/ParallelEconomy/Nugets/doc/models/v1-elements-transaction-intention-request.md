
# V1 Elements Transaction Intention Request

## Structure

`V1ElementsTransactionIntentionRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Action` | [`Models.ActionEnum?`](../../doc/models/action-enum.md) | Optional | The action to be performed<br>**Default**: `ActionEnum.sale` |
| `Methods` | [`List<Models.Method>`](../../doc/models/method.md) | Optional | Byt default the system will try to offer all the availables payment methods from your account. But if you like, you can specify exactly what services you want to use.<br>**Constraints**: *Minimum Items*: `1`, *Unique Items Required* |
| `Amount` | `int?` | Optional | **Constraints**: `>= 1`, `<= 999999999` |
| `TaxAmount` | `int?` | Optional | **Constraints**: `>= 1`, `<= 999999999` |
| `LocationId` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "action": null,
  "methods": null,
  "amount": null,
  "tax_amount": null,
  "location_id": null
}
```

