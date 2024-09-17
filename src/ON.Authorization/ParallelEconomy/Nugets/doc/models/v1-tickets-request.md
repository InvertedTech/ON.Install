
# V1 Tickets Request

## Structure

`V1TicketsRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AccountHolderName` | `string` | Optional | Account holder name<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `32` |
| `ExpDate` | `string` | Required | The Expiration Date for the credit card. |
| `Cvv` | `string` | Optional | CVV<br>**Constraints**: *Maximum Length*: `4` |
| `AccountNumber` | `string` | Required | Account number<br>**Constraints**: *Minimum Length*: `4`, *Maximum Length*: `19`, *Pattern*: `^[\d]+$` |
| `BillingAddress` | [`BillingAddress5`](../../doc/models/billing-address-5.md) | Optional | Billing Address Object |
| `ContactId` | `string` | Optional | Used to associate the Ticket with a Contact.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ContactApiId` | `string` | Optional | Used to associate the Ticket with a Contact. |
| `LocationId` | [`V1TicketsRequestLocationId`](../../doc/models/containers/v1-tickets-request-location-id.md) | Optional | This is a container for any-of cases. |
| `LocationApiId` | `string` | Optional | Location Api Id |

## Example (as JSON)

```json
{
  "account_holder_name": "John Smith",
  "exp_date": "0722",
  "account_number": "545454545454545",
  "contact_id": "11e95f8ec39de8fbdb0a4f1a",
  "cvv": "cvv6",
  "billing_address": {
    "postal_code": "postal_code0",
    "street": "street8"
  },
  "contact_api_id": "contact_api_id6"
}
```

