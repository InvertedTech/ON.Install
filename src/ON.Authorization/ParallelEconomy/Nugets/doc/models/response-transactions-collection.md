
# Response Transactions Collection

## Structure

`ResponseTransactionsCollection`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"TransactionsCollection"` |
| `List` | [`List<List16>`](../../doc/models/list-16.md) | Required | Resource Members |
| `Links` | [`Links`](../../doc/models/links.md) | Optional | Pagination page links |
| `Pagination` | [`Pagination`](../../doc/models/pagination.md) | Optional | Pagination info |
| `Sort` | [`Sort`](../../doc/models/sort.md) | Optional | Sort information used on the results |

## Example (as JSON)

```json
{
  "type": "TransactionsCollection",
  "list": [
    {
      "checkin_date": "2021-12-01",
      "checkout_date": "2021-12-01",
      "clerk_number": "AE1234",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "custom_data": {
        "data1": "custom1",
        "data2": "custom2"
      },
      "customer_id": "customerid",
      "description": "some description",
      "iias_ind": 1,
      "image_front": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
      "image_back": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
      "installment": true,
      "installment_number": 1,
      "installment_count": 1,
      "location_api_id": "location-api-id-florida-2",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "advance_deposit": false,
      "no_show": false,
      "notification_email_address": "johnsmith@smiths.com",
      "order_number": "433659378839",
      "po_number": "555555553123",
      "quick_invoice_id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_number": 1,
      "room_num": "303",
      "room_rate": 95,
      "save_account": false,
      "save_account_title": "John Account",
      "subtotal_amount": 599,
      "surcharge_amount": 100,
      "tax": 0,
      "tip_amount": 0,
      "transaction_amount": 0,
      "secondary_amount": 0,
      "transaction_api_id": "transaction-payment-abcd123",
      "transaction_c1": "custom-data-1",
      "transaction_c2": "custom-data-2",
      "transaction_c3": "custom-data-3",
      "bank_funded_only_override": false,
      "allow_partial_authorization_override": false,
      "auto_decline_cvv_override": false,
      "auto_decline_street_override": false,
      "auto_decline_zip_override": false,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "terminal_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_holder_name": "smith",
      "account_type": "checking",
      "token_id": "11e95f8ec39de8fbdb0a4f1a",
      "ach_identifier": "P",
      "ach_sec_code": "C21",
      "auth_amount": 1,
      "auth_code": "BR349K",
      "avs": "BAD",
      "avs_enhanced": "N",
      "cardholder_present": true,
      "card_present": true,
      "check_number": "8520748520963",
      "customer_ip": "192.168.0.10",
      "cvv_response": "N",
      "entry_mode_id": "C",
      "first_six": "545454",
      "last_four": "5454",
      "payment_method": "cc",
      "terminal_serial_number": "1234567890",
      "charge_back_date": "2021-12-01",
      "is_recurring": true,
      "notification_email_sent": true,
      "par": "Q1J4Z28RKA1EBL470G9XYG90R5D3E",
      "reason_code_id": 1000,
      "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
      "settle_date": "2021-12-01",
      "status_code": 101,
      "transaction_batch_id": "11e95f8ec39de8fbdb0a4f1a",
      "verbiage": "APPROVED",
      "void_date": "2021-12-01",
      "batch": "2",
      "terms_agree": true,
      "return_date": "2021-12-01",
      "trx_source_id": 8,
      "routing_number": "051904524",
      "trx_source_code": 8,
      "paylink_id": "11e95f8ec39de8fbdb0a4f1a",
      "currency_code": 840,
      "is_accountvault": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "effective_date": "2021-12-01",
      "is_token": true,
      "installment_total": 1,
      "installment_counter": 1,
      "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
      "hosted_payment_page_id": "11e95f8ec39de8fbdb0a4f1a",
      "is_voidable": true,
      "is_reversible": true,
      "is_refundable": true,
      "is_completable": true,
      "is_settled": true,
      "developer_company_id": "Sample Developer Company ID",
      "additional_amounts": [
        {
          "type": "cashback",
          "amount": 6,
          "account_type": "cash_benefit",
          "currency": 154.64
        }
      ],
      "billing_address": {
        "postal_code": "postal_code0",
        "street": "street8",
        "city": "city2",
        "state": "state6",
        "phone": "phone2"
      }
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

