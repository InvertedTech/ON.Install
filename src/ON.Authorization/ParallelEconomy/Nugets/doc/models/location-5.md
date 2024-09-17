
# Location 5

The Location.

## Structure

`Location5`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AddressLine1` | `string` | Optional | Merchant's business address line 1.<br>**Constraints**: *Maximum Length*: `100` |
| `AddressLine2` | `string` | Optional | Merchant's business address line 2.<br>**Constraints**: *Maximum Length*: `20` |
| `City` | `string` | Optional | Merchant's business city.<br>**Constraints**: *Maximum Length*: `50` |
| `StateProvince` | `string` | Optional | Merchant's business two-digit state or province code.<br>**Constraints**: *Maximum Length*: `2` |
| `PostalCode` | `string` | Optional | Merchant's business postal code.<br>**Constraints**: *Maximum Length*: `10` |
| `PhoneNumber` | `string` | Required | Merchant's business phone number.<br>**Constraints**: *Maximum Length*: `20` |

## Example (as JSON)

```json
{
  "address_line_1": "1200 West Hartford Pkwy",
  "address_line_2": "Suite 2000",
  "city": "Dover",
  "state_province": "DE",
  "postal_code": "55022",
  "phone_number": "555-555-1212"
}
```

