
# Identity Verification 13

Identity Verification

## Structure

`IdentityVerification13`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `DlState` | `string` | Required | Required for ACH transactions when Driver's License Verification is enabled on the terminal.  Either dl_number + dl_state OR customer_id will need to be passed in this scenario.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `DlNumber` | `string` | Required | Required for ACH transactions when Driver's License Verification is enabled on the terminal.  Either dl_number + dl_state OR customer_id will need to be passed in this scenario.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `50` |
| `Ssn4` | `string` | Optional | For ACH transactions where Identity Verification is enabled for terminal. Only ssn4 or dob_year should be passed. not both.<br>**Constraints**: *Maximum Length*: `4` |
| `DobYear` | `string` | Optional | Required for certain ACH transactions where Identity Verification has been enabled for the terminal.  Either ssn4 or dob_year will need to be passed in this scenario but NOT BOTH.<br>**Constraints**: *Minimum Length*: `4`, *Maximum Length*: `4`, *Pattern*: `^(19\d{2})\|20\d{2}$` |

## Example (as JSON)

```json
{
  "dl_state": "MI",
  "dl_number": "1235567"
}
```

