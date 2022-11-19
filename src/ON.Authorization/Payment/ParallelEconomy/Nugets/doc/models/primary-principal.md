
# Primary Principal

The Primary Principal.

## Structure

`PrimaryPrincipal`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `FirstName` | `string` | Required | Signer's first name<br>**Constraints**: *Maximum Length*: `20` |
| `LastName` | `string` | Required | Signer's last name<br>**Constraints**: *Maximum Length*: `20` |
| `MiddleName` | `string` | Optional | Signer's middle name<br>**Constraints**: *Maximum Length*: `20` |
| `Title` | `string` | Optional | Signer's title<br>**Constraints**: *Maximum Length*: `20` |
| `DateOfBirth` | `string` | Optional | Signer's date of birth<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `AddressLine1` | `string` | Optional | Signer's residential address line 1<br>**Constraints**: *Maximum Length*: `100` |
| `AddressLine2` | `string` | Optional | Signer's residential address line 2<br>**Constraints**: *Maximum Length*: `20` |
| `City` | `string` | Optional | Signer's city<br>**Constraints**: *Maximum Length*: `50` |
| `StateProvince` | `string` | Optional | Signer's two-digit state code<br>**Constraints**: *Maximum Length*: `2` |
| `PostalCode` | `string` | Optional | Signer's postal code<br>**Constraints**: *Maximum Length*: `10` |
| `Ssn` | `string` | Optional | Last four digits of the primary principal or Signer's social security number<br>**Constraints**: *Maximum Length*: `4` |
| `OwnershipPercent` | `int?` | Optional | Percentage of business owned by primary principal or signer<br>**Constraints**: `>= 0`, `<= 100` |
| `PhoneNumber` | `string` | Optional | Signer's phone number<br>**Constraints**: *Maximum Length*: `20` |

## Example (as JSON)

```json
{
  "first_name": "Bob",
  "last_name": "Fairview"
}
```

