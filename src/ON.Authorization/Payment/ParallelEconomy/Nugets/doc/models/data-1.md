
# Data 1

## Structure

`Data1`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Required | Batch ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |
| `ProductTransactionId` | `string` | Optional | Product Transaction Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ProcessingStatusId` | `double` | Required | Processing Status Id<br>**Constraints**: `>= 1`, `<= 5` |
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
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "processing_status_id": 2
}
```

