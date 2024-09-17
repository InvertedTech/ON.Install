
# Data 7

## Structure

`Data7`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ContactId` | `string` | Optional | Used to associate the Ticket with a Contact.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ContactApiId` | `string` | Optional | Used to associate the Ticket with a Contact. |
| `LocationId` | `string` | Required | A valid Location Id associated with the Contact for this Ticket<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ProductTransactionId` | `string` | Optional | Include a product_transaction_id to respect it's cvv and address field settings when creating a ticket.  These settings are enforced at the ticket creation level only.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Message` | `string` | Optional | A custom text message that displays after the ticket is created.<br>**Constraints**: *Maximum Length*: `120` |
| `ClientToken` | `string` | Required | A JWT to be used to create the elements.<br><br>> This is a one-time only use token.<br>> Do not store for long term use, it expires after 48 hours. |

## Example (as JSON)

```json
{
  "contact_id": "11e95f8ec39de8fbdb0a4f1a",
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
  "client_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",
  "contact_api_id": "contact_api_id0",
  "message": "message4"
}
```

