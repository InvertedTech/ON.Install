
# Sort

You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods:

> /endpoint?sort={ "field_name": "asc", "field_name2": "desc" }
> 
> /endpoint?sort[field_name]=asc&sort[field_name2]=desc

## Structure

`Sort`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | Batch ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int?` | Optional | Created Time Stamp |
| `ModifiedTs` | `int?` | Optional | Modified Time Stamp |
| `ProductTransactionId` | `string` | Optional | Product Transaction Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ProcessingStatusId` | `double?` | Optional | Processing Status Id<br>**Constraints**: `>= 1`, `<= 5` |
| `BatchNum` | `double?` | Optional | Batch Number |
| `IsOpen` | `double?` | Optional | Is Open<br>**Constraints**: `>= 0`, `<= 1` |
| `SettlementFileName` | `string` | Optional | Settlement File Name |
| `BatchCloseTs` | `double?` | Optional | Batch Close Ts |
| `BatchCloseDetail` | `string` | Optional | Batch Close Detail |
| `TotalSaleAmount` | `double?` | Optional | Total Sale Amount |
| `TotalSaleCount` | `double?` | Optional | Total Sale Count |
| `TotalRefundAmount` | `double?` | Optional | Total Refund Amount |
| `TotalRefundCount` | `double?` | Optional | Total Refund Count |
| `TotalVoidAmount` | `double?` | Optional | Total Void Amount |
| `TotalVoidCount` | `double?` | Optional | Total Void Count |

## Example (as JSON)

```json
{
  "id": null,
  "created_ts": null,
  "modified_ts": null,
  "product_transaction_id": null,
  "processing_status_id": null,
  "batch_num": null,
  "is_open": null,
  "settlement_file_name": null,
  "batch_close_ts": null,
  "batch_close_detail": null,
  "total_sale_amount": null,
  "total_sale_count": null,
  "total_refund_amount": null,
  "total_refund_count": null,
  "total_void_amount": null,
  "total_void_count": null
}
```

