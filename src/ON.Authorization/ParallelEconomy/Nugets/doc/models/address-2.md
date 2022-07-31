
# Address 2

Address

## Structure

`Address2`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `City` | `string` | Optional | City name<br>**Constraints**: *Maximum Length*: `36`, *Pattern*: `^[\w\#\,\.\-\'\&\s\/]+$` |
| `State` | `string` | Optional | State name<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `PostalCode` | `string` | Optional | Postal code<br>**Constraints**: *Minimum Length*: `5`, *Maximum Length*: `10`, *Pattern*: `^\d{5,10}$` |
| `Country` | [`Models.Country2Enum?`](../../doc/models/country-2-enum.md) | Optional | Country |
| `Street` | `string` | Optional | Street<br>**Constraints**: *Maximum Length*: `255`, *Pattern*: `^[\w\#\,\.\-\'\&\s\/]+$` |
| `Street2` | `string` | Optional | Street 2<br>**Constraints**: *Maximum Length*: `255`, *Pattern*: `^[\w\#\,\.\-\'\&\s\/]+$` |

## Example (as JSON)

```json
{
  "city": null,
  "state": null,
  "postal_code": null,
  "country": null,
  "street": null,
  "street2": null
}
```

