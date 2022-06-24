
# Billing Address

The Street portion of the address associated with the Credit Card (CC) or Bank Account (ACH).

## Structure

`BillingAddress`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `City` | `string` | Optional | The City portion of the address associated with the Credit Card (CC) or Bank Account (ACH).<br>**Constraints**: *Maximum Length*: `36`, *Pattern*: `^[\w\#\,\.\-\'\&\s\/]+$` |
| `State` | `string` | Optional | The State portion of the address associated with the Credit Card (CC) or Bank Account (ACH).<br>**Constraints**: *Maximum Length*: `24` |
| `PostalCode` | `string` | Optional | The Zip or 'Postal Code' portion of the address associated with the Credit Card (CC) or Bank Account (ACH).<br>**Constraints**: *Minimum Length*: `5`, *Maximum Length*: `10`, *Pattern*: `^\d{5,10}$` |
| `Street` | `string` | Optional | The Street portion of the address associated with the Credit Card (CC) or Bank Account (ACH).<br>**Constraints**: *Maximum Length*: `255`, *Pattern*: `^[\w\#\,\.\-\'\&\s\/]+$` |
| `Phone` | `string` | Optional | The Phone # to be used to contact Payer if there are any issues processing a transaction.<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `10`, *Pattern*: `^\d{10}$` |

## Example (as JSON)

```json
{
  "city": null,
  "state": null,
  "postal_code": null,
  "street": null,
  "phone": null
}
```

