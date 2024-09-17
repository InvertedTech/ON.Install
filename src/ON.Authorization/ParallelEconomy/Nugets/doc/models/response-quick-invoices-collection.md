
# Response Quick Invoices Collection

## Structure

`ResponseQuickInvoicesCollection`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"QuickInvoicesCollection"` |
| `List` | [`List<List9>`](../../doc/models/list-9.md) | Required | Resource Members |
| `Links` | [`Links`](../../doc/models/links.md) | Optional | Pagination page links |
| `Pagination` | [`Pagination`](../../doc/models/pagination.md) | Optional | Pagination info |
| `Sort` | [`Sort`](../../doc/models/sort.md) | Optional | Sort information used on the results |

## Example (as JSON)

```json
{
  "type": "QuickInvoicesCollection",
  "list": [
    {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": "My terminal",
      "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "due_date": "2021-12-01",
      "item_list": [
        {
          "name": "Bread",
          "amount": 2015
        }
      ],
      "allow_overpayment": true,
      "bank_funded_only_override": true,
      "email": "email@domain.com",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_api_id": "contact12345",
      "quick_invoice_api_id": "quickinvoice12345",
      "customer_id": "11e95f8ec39de8fbdb0a4f1a",
      "expire_date": "2021-12-01",
      "allow_partial_pay": true,
      "attach_files_to_email": true,
      "send_email": true,
      "invoice_number": "invoice12345",
      "item_header": "Quick invoice header sample",
      "item_footer": "Thank you",
      "amount_due": 245.36,
      "notification_email": "email@domain.com",
      "status_id": 1,
      "status_code": 1,
      "note": "some note",
      "notification_days_before_due_date": 3,
      "notification_days_after_due_date": 7,
      "notification_on_due_date": true,
      "send_text_to_pay": true,
      "remaining_balance": 245.36,
      "single_payment_min_amount": 500,
      "single_payment_max_amount": 500000,
      "cell_phone": "3339998822",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "payment_status_id": 1,
      "is_active": true
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

