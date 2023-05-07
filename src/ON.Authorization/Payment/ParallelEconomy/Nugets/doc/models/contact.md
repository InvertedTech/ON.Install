
# Contact

The Contact.

## Structure

`Contact`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `FirstName` | `string` | Optional | Contact's first name.<br>**Constraints**: *Maximum Length*: `20` |
| `LastName` | `string` | Optional | Contact's last name.<br>**Constraints**: *Maximum Length*: `20` |
| `Email` | `string` | Optional | Contact's email address.<br>**Constraints**: *Maximum Length*: `20` |
| `PhoneNumber` | `string` | Required | Contact's phone.<br>**Constraints**: *Maximum Length*: `20` |

## Example (as JSON)

```json
{
  "phone_number": "555-555-3456"
}
```

