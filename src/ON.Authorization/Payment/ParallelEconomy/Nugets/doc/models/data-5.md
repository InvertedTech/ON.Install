
# Data 5

## Structure

`Data5`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Action` | [`Models.ActionEnum?`](../../doc/models/action-enum.md) | Optional | The action to be performed<br>**Default**: `ActionEnum.sale` |
| `Methods` | [`List<Models.Method>`](../../doc/models/method.md) | Optional | Byt default the system will try to offer all the availables payment methods from your account. But if you like, you can specify exactly what services you want to use.<br>**Constraints**: *Minimum Items*: `1`, *Unique Items Required* |
| `Amount` | `int?` | Optional | **Constraints**: `>= 1`, `<= 999999999` |
| `TaxAmount` | `int?` | Optional | **Constraints**: `>= 1`, `<= 999999999` |
| `LocationId` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ClientToken` | `string` | Required | A JWT to be used to create the elements.<br><br>> This is a one-time only use token.<br>> Do not store for long term use, it expires after 48 hours. |

## Example (as JSON)

```json
{
  "client_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
}
```

