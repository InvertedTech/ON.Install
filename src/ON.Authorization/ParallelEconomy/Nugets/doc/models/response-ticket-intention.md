
# Response Ticket Intention

## Structure

`ResponseTicketIntention`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"TicketIntention"` |
| `Data` | [`Data7`](../../doc/models/data-7.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "TicketIntention",
  "data": {
    "contact_id": "contact_id4",
    "contact_api_id": "contact_api_id4",
    "location_id": "location_id4",
    "product_transaction_id": "product_transaction_id4",
    "message": "message0",
    "client_token": "client_token0"
  }
}
```

