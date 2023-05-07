
# Additional Amount

## Structure

`AdditionalAmount`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | [`Models.Type1Enum?`](../../doc/models/type-1-enum.md) | Optional | type of the amount [4S-Healthcare(Visa and MC Only), 4U-Prescription/Rx(Visa and MC Only), 4V-Vision/Optical(Visa Only), 4W-clinic/other qualified medical(Visa Only) ,4X-Dental(Visa Only)]. |
| `Amount` | `string` | Optional | The amount of additional amount.<br>**Constraints**: *Maximum Length*: `12` |
| `AccountType` | [`Models.AccountTypeEnum?`](../../doc/models/account-type-enum.md) | Optional | Account Type |
| `Currency` | `double?` | Optional | Currency Code |

## Example (as JSON)

```json
{
  "type": null,
  "amount": null,
  "account_type": null,
  "currency": null
}
```

