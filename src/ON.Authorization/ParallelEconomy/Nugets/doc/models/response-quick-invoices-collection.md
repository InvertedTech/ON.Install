
# Response Quick Invoices Collection

## Structure

`ResponseQuickInvoicesCollection`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"QuickInvoicesCollection"` |
| `List` | [`List<Models.List5>`](../../doc/models/list-5.md) | Required | Resource Members |

## Example (as JSON)

```json
{
  "type": "QuickInvoicesCollection",
  "list": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "title": "My terminal",
    "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "due_date": "2021-12-01",
    "item_list": {
      "name": "Bread",
      "amount": 20.15
    },
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992
  }
}
```

