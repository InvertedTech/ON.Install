
# Log Email

## Structure

`LogEmail`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Subject` | `string` | Required | Subject<br>**Constraints**: *Maximum Length*: `256` |
| `Body` | `string` | Required | Body |
| `SourceAddress` | `string` | Required | Source Address<br>**Constraints**: *Maximum Length*: `64` |
| `ReturnPath` | `string` | Required | Return Path<br>**Constraints**: *Maximum Length*: `64` |
| `ProviderId` | `string` | Optional | Provider<br>**Constraints**: *Maximum Length*: `60` |
| `DomainId` | `string` | Optional | Domain<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ReasonSent` | `string` | Optional | Reason Sent<br>**Constraints**: *Maximum Length*: `36` |
| `ReasonModel` | [`ReasonModelEnum?`](../../doc/models/reason-model-enum.md) | Optional | Reason Model<br>**Constraints**: *Maximum Length*: `64` |
| `ReasonModelId` | `string` | Optional | Reason Model<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ReplyTo` | `string` | Optional | Reply To<br>**Constraints**: *Maximum Length*: `520` |
| `Id` | `string` | Required | Log Email Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int` | Required | Created Time Stamp |

## Example (as JSON)

```json
{
  "subject": "Payment Receipt - 12skiestech",
  "body": "This email is being sent from a server.",
  "source_address": "\"12skiestech A7t3qi\" <noreply@zeamster.email>",
  "return_path": "\"12skiestech A7t3qi\" <noreply@zeamster.email>",
  "provider_id": "0100017e67bcc530-e1dd23b4-8a39-4a5b-8d5d-68d51c4c942f-000000",
  "domain_id": "11e95f8ec39de8fbdb0a4f1a",
  "reason_sent": "Contact Email",
  "reason_model": "Transaction",
  "reason_model_id": "11e95f8ec39de8fbdb0a4f1a",
  "reply_to": "\"Zeamster\" <emma.p@zeamster.com>",
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "created_ts": 1422040992
}
```

