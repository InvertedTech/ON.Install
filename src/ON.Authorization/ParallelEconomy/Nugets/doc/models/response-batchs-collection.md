
# Response Batchs Collection

## Structure

`ResponseBatchsCollection`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"BatchsCollection"` |
| `List` | [`List<List>`](../../doc/models/list.md) | Required | Resource Members |
| `Links` | [`Links`](../../doc/models/links.md) | Optional | Pagination page links |
| `Pagination` | [`Pagination`](../../doc/models/pagination.md) | Optional | Pagination info |
| `Sort` | [`Sort`](../../doc/models/sort.md) | Optional | Sort information used on the results |

## Example (as JSON)

```json
{
  "type": "BatchsCollection",
  "list": [
    {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "processing_status_id": 2,
      "batch_num": 4,
      "is_open": 0.0,
      "settlement_file_name": "settement_file.txt",
      "batch_close_ts": 1531423693.0,
      "batch_close_detail": "BATCH_MISMATCH",
      "total_sale_amount": 2342,
      "total_sale_count": 21,
      "total_refund_amount": 2342,
      "total_refund_count": 18,
      "total_void_amount": 2342,
      "total_void_count": 17,
      "total_blind_refund_amount": 2342,
      "total_blind_refund_count": 16
    }
  ],
  "links": {
    "type": "type4",
    "first": "first0",
    "previous": "previous2",
    "last": "last4"
  },
  "pagination": {
    "type": "type6",
    "total_count": 100,
    "page_count": 212,
    "page_number": 28,
    "page_size": 6
  },
  "sort": {
    "type": "type2",
    "fields": [
      {
        "field": "field2",
        "order": "asc"
      },
      {
        "field": "field2",
        "order": "asc"
      },
      {
        "field": "field2",
        "order": "asc"
      }
    ]
  }
}
```

