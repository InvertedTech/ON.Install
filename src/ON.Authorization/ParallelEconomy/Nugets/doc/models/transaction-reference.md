
# Transaction Reference

## Structure

`TransactionReference`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `TransactionId` | `string` | Optional | Transaction ID |
| `PreviousTransactionId` | `string` | Optional | Previous Transaction ID |
| `TransactionAmount` | `int?` | Optional | Transaction Amount |
| `PreviousTransactionAmount` | `int?` | Optional | Previous Transaction Amount |
| `PreviousTransactionCreatedTs` | `double?` | Optional | Previous Transaction Created Timestamp |
| `ReferenceType` | `string` | Optional | Reference Type |
| `CreatedTs` | `int?` | Optional | Created Time Stamp |
| `CreatedUserId` | `string` | Optional | User ID Created the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "created_ts": 1422040992,
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "transaction_id": "transaction_id2",
  "previous_transaction_id": "previous_transaction_id8",
  "transaction_amount": 188,
  "previous_transaction_amount": 176
}
```

