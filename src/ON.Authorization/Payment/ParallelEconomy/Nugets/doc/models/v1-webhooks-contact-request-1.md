
# V1 Webhooks Contact Request 1

## Structure

`V1WebhooksContactRequest1`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AttemptInterval` | `int?` | Optional | Number of seconds before another retry is submitted<br>**Default**: `300`<br>**Constraints**: `>= 300`, `<= 86400` |
| `BasicAuthUsername` | `string` | Optional | The Basic authorization username for the URL, if not supplied, the postback will be submitted without Basic authorization headers<br>**Constraints**: *Maximum Length*: `512` |
| `BasicAuthPassword` | `string` | Optional | The basic authorization password<br>**Constraints**: *Maximum Length*: `512` |
| `Expands` | `string` | Optional | An option list of expanded data to send with base data. (i.e. set this field to “contact,account_vault” to get the contact an accountvault used to run a transaction.)<br>**Constraints**: *Maximum Length*: `512` |
| `Format` | [`Models.FormatEnum?`](../../doc/models/format-enum.md) | Optional | Options include: api-default |
| `IsActive` | `bool?` | Optional | Flag to indicate whether configuration is active (in effect). |
| `LocationId` | `string` | Optional | The location identifier of the resource you want to recieve postbacks from.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `LocationApiId` | `string` | Optional | Location Api ID |
| `OnCreate` | [`Models.OnCreateEnum?`](../../doc/models/on-create-enum.md) | Optional | To receive postbacks on the creation of a resource |
| `OnUpdate` | [`Models.OnUpdateEnum?`](../../doc/models/on-update-enum.md) | Optional | To receive postbacks on the updating of a resource |
| `OnDelete` | [`Models.OnDeleteEnum?`](../../doc/models/on-delete-enum.md) | Optional | To receive postbacks when the record is deleted |
| `PostbackConfigId` | `string` | Optional | Postback Config ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ProductTransactionId` | `string` | Optional | Required when using 'transaction' or 'transactionbatch' resource<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Resource` | [`Models.Resource4Enum?`](../../doc/models/resource-4-enum.md) | Optional | The resource you want to subscribe the postbacks to.<br>**Constraints**: *Maximum Length*: `128` |
| `NumberOfAttempts` | `int?` | Optional | Maximum number of attempts on failure<br>**Constraints**: `>= 1`, `<= 5` |
| `Url` | `string` | Optional | The URL where the postback will be submitted<br>**Constraints**: *Maximum Length*: `512` |

## Example (as JSON)

```json
{
  "attempt_interval": null,
  "basic_auth_username": null,
  "basic_auth_password": null,
  "expands": null,
  "format": null,
  "is_active": null,
  "location_id": null,
  "location_api_id": null,
  "on_create": null,
  "on_update": null,
  "on_delete": null,
  "postback_config_id": null,
  "product_transaction_id": null,
  "resource": null,
  "number_of_attempts": null,
  "url": null
}
```

