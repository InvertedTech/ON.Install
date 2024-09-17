
# Surcharge

Surcharge Information on `expand`

## Structure

`Surcharge`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `SurchargeFee` | `int` | Required | Surcharge Fee |
| `SurchargeRate` | `int` | Required | Surcharge Rate |
| `MaxTransactionAmount` | `int?` | Optional | Max Transaction Amount |
| `MinFeeAmount` | `int?` | Optional | Min Fee Amount |
| `MaxFeeAmount` | `int?` | Optional | Max Fee Amount |
| `SurchargeOnRecurring` | `bool?` | Optional | Surcharge On Recurring |
| `RefundSurcharges` | `bool?` | Optional | Refund Surcharges |
| `ProductTransactionId` | `string` | Required | Product Transaction Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `RunAsSeparateTransaction` | `bool?` | Optional | Run As Separate Transaction |
| `ApplyToUserTypeId` | `string` | Optional | Apply To User Type Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Title` | `string` | Optional | Title<br>**Constraints**: *Maximum Length*: `256` |
| `SurchargeLabel` | `string` | Optional | Surcharge Label<br>**Constraints**: *Maximum Length*: `64` |
| `SurchargeTransactionProductId` | `string` | Optional | Surcharge Transaction Product Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Id` | `string` | Required | Surcharge Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedUserId` | `string` | Required | User ID Created the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ModifiedUserId` | `string` | Required | Last User ID that updated the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |

## Example (as JSON)

```json
{
  "surcharge_fee": 10,
  "surcharge_rate": 1,
  "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
  "apply_to_user_type_id": "11e95f8ec39de8fbdb0a4f1a",
  "surcharge_transaction_product_id": "11e95f8ec39de8fbdb0a4f1a",
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "max_transaction_amount": 252,
  "min_fee_amount": 198,
  "max_fee_amount": 172,
  "surcharge_on_recurring": false,
  "refund_surcharges": false
}
```

