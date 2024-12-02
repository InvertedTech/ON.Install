
# Surcharge Transaction

Surcharge Transaction Information on `expand`

## Structure

`SurchargeTransaction`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ModelName` | `string` | Required | Model Name |
| `TransactionId` | `string` | Required | Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `SurchargeFee` | `int` | Required | Surcharge Fee<br>**Constraints**: `>= 0` |
| `SurchargeRate` | `int` | Required | Surcharge Rate<br>**Constraints**: `>= 0` |
| `SurchargeAmount` | `int?` | Optional | Surcharge Amount<br>**Constraints**: `>= 0` |
| `SurchargeTransactionMin` | `int?` | Optional | Surcharge Transaction Minimum<br>**Constraints**: `>= 0` |
| `SurchargeTransactionMax` | `int?` | Optional | Surcharge Transaction Maximum<br>**Constraints**: `>= 0` |
| `Created` | `int?` | Optional | Created |
| `Modified` | `int?` | Optional | Modified |
| `CreatedUserId` | `string` | Optional | User ID Created the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ModifiedUserId` | `string` | Optional | Last User ID that updated the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "model_name": "Model Name",
  "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
  "surcharge_fee": 0,
  "surcharge_rate": 0,
  "created": 1422040992,
  "modified": 1422040992,
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "surcharge_amount": 176,
  "surcharge_transaction_min": 192,
  "surcharge_transaction_max": 32
}
```

