
# Address

Address of contact

## Structure

`Address`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `City` | `string` | Optional | City of contact<br>**Constraints**: *Maximum Length*: `36`, *Pattern*: `^[\w\#\,\.\-\'\&\s\/]+$` |
| `State` | `string` | Optional | State of contact<br>**Constraints**: *Maximum Length*: `24` |
| `PostalCode` | `string` | Optional | Postal code of contact<br>**Constraints**: *Minimum Length*: `5`, *Maximum Length*: `10`, *Pattern*: `^\d{5,10}$` |
| `Country` | [`Models.CountryEnum?`](../../doc/models/country-enum.md) | Optional | Country of contact |
| `Street` | `string` | Optional | Street of contact<br>**Constraints**: *Maximum Length*: `255`, *Pattern*: `^[\w\#\,\.\-\'\&\s\/]+$` |

## Example (as JSON)

```json
{
  "city": null,
  "state": null,
  "postal_code": null,
  "country": null,
  "street": null
}
```

