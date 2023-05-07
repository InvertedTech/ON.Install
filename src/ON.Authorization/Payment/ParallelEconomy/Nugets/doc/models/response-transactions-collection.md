
# Response Transactions Collection

## Structure

`ResponseTransactionsCollection`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"TransactionsCollection"` |
| `List` | [`List<Models.List11>`](../../doc/models/list-11.md) | Required | Resource Members |

## Example (as JSON)

```json
{
  "type": "TransactionsCollection",
  "list": {
    "transaction_amount": 2099,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "payment_method": "cc"
  }
}
```

