
# Log Sms

Log Sms Information on `expand`

## Structure

`LogSms`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Required | Log Sms Id<br>**Constraints**: *Maximum Length*: `24`, *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Body` | `string` | Optional | Body |
| `ReasonModel` | `string` | Required | Reason Model<br>**Constraints**: *Maximum Length*: `24` |
| `ReasonModelId` | `string` | Required | Reason Model ID<br>**Constraints**: *Maximum Length*: `36` |
| `ProviderId` | `string` | Required | Provider ID<br>**Constraints**: *Maximum Length*: `60` |
| `Status` | `string` | Required | Status<br>**Constraints**: *Maximum Length*: `10` |
| `Sender` | `string` | Required | Sender<br>**Constraints**: *Maximum Length*: `10` |
| `Recipient` | `string` | Required | Recipient<br>**Constraints**: *Maximum Length*: `10` |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `CreatedUserId` | `string` | Required | User ID Created the register<br>**Constraints**: *Maximum Length*: `36`, *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "reason_model": " ",
  "reason_model_id": " ",
  "provider_id": " ",
  "status": " ",
  "sender": " ",
  "recipient": " ",
  "created_ts": 1422040992,
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "body": "body2"
}
```

