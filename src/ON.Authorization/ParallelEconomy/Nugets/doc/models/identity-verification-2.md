
# Identity Verification 2

Identity Verification

## Structure

`IdentityVerification2`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `DlState` | `string` | Optional | Required for ACH transactions when Driver's License Verification is enabled on the terminal.  Either dl_number + dl_state OR customer_id will need to be passed in this scenario.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `DlNumber` | `string` | Optional | Required for ACH transactions when Driver's License Verification is enabled on the terminal.  Either dl_number + dl_state OR customer_id will need to be passed in this scenario.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `50` |
| `DobYear` | `string` | Optional | Required for certain ACH transactions where Identity Verification has been enabled for the terminal.  Either ssn4 or dob_year will need to be passed in this scenario but NOT BOTH.<br>**Constraints**: *Minimum Length*: `4`, *Maximum Length*: `4`, *Pattern*: `^(19\d{2})\|20\d{2}$` |

## Example (as JSON)

```json
{
  "dl_state": null,
  "dl_number": null,
  "dob_year": null
}
```

