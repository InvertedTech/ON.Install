
# Response Transaction Bin Info

## Structure

`ResponseTransactionBinInfo`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"TransactionBinInfo"` |
| `Data` | [`Data23`](../../doc/models/data-23.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "TransactionBinInfo",
  "data": {
    "issuer_bank_name": "issuer_bank_name6",
    "country_code": "country_code0",
    "detail_card_product": "detail_card_product2",
    "detail_card_indicator": "detail_card_indicator2",
    "fsa_indicator": "fsa_indicator8",
    "prepaid_indicator": "prepaid_indicator8",
    "product_id": "product_id6",
    "regulator_indicator": "regulator_indicator0",
    "visa_product_sub_type": "visa_product_sub_type4",
    "visa_large_ticket_indicator": "visa_large_ticket_indicator4",
    "account_fund_source": "account_fund_source4",
    "card_class": "card_class6",
    "token_ind": "token_ind0",
    "issuing_network": "issuing_network8"
  }
}
```

