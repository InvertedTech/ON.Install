
# Identity Verification 2

Identity verification

## Structure

`IdentityVerification2`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `DlState` | `string` | Optional | Used for certain ACH transactions where Driver's License is required by the terminal being used.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `DlNumber` | `string` | Optional | Used for certain ACH transactions where Driver's License is required by the terminal being used.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `50` |
| `Ssn4` | `string` | Optional | The last four of the account_holder social security number.<br>**Constraints**: *Maximum Length*: `4` |
| `DobYear` | `string` | Optional | Used for certain ACH transactions where Identity Verification is enabled on the terminal being used.<br>**Constraints**: *Minimum Length*: `4`, *Maximum Length*: `4`, *Pattern*: `^(19\d{2})\|20\d{2}$` |

## Example (as JSON)

```json
{
  "dl_state": "MI",
  "dl_number": "1235567",
  "ssn4": "8527",
  "dob_year": "1980"
}
```

