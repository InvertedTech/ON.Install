
# Data 20

## Structure

`Data20`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AttemptInterval` | `int?` | Optional | Number of seconds before another retry is submitted<br>**Default**: `300`<br>**Constraints**: `>= 300`, `<= 86400` |
| `BasicAuthUsername` | `string` | Optional | The Basic authorization username for the URL, if not supplied, the postback will be submitted without Basic authorization headers<br>**Constraints**: *Maximum Length*: `512` |
| `BasicAuthPassword` | `string` | Optional | The basic authorization password<br>**Constraints**: *Maximum Length*: `512` |
| `Expands` | `string` | Optional | An option list of expanded data to send with base data. (i.e. set this field to “contact,account_vault” to get the contact an accountvault used to run a transaction.)<br>**Constraints**: *Maximum Length*: `512` |
| `Format` | [`Models.FormatEnum?`](../../doc/models/format-enum.md) | Optional | Options include: api-default |
| `IsActive` | `bool` | Required | Flag to indicate whether configuration is active (in effect). |
| `LocationId` | `string` | Required | The location identifier of the resource you want to recieve postbacks from.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `LocationApiId` | `string` | Optional | Location Api ID |
| `OnCreate` | [`Models.OnCreateEnum`](../../doc/models/on-create-enum.md) | Required | To receive postbacks on the creation of a resource |
| `OnUpdate` | [`Models.OnUpdateEnum`](../../doc/models/on-update-enum.md) | Required | To receive postbacks on the updating of a resource |
| `OnDelete` | [`Models.OnDeleteEnum`](../../doc/models/on-delete-enum.md) | Required | To receive postbacks when the record is deleted |
| `PostbackConfigId` | `string` | Optional | Postback Config ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ProductTransactionId` | `string` | Optional | Required when using 'transaction' or 'transactionbatch' resource<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Resource` | [`Models.Resource4Enum`](../../doc/models/resource-4-enum.md) | Required | The resource you want to subscribe the postbacks to.<br>**Constraints**: *Maximum Length*: `128` |
| `NumberOfAttempts` | `int` | Required | Maximum number of attempts on failure<br>**Constraints**: `>= 1`, `<= 5` |
| `Url` | `string` | Required | The URL where the postback will be submitted<br>**Constraints**: *Maximum Length*: `512` |
| `Id` | `string` | Required | Postback Config ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "is_active": true,
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "on_create": 1,
  "on_update": 1,
  "on_delete": 1,
  "resource": "contact",
  "number_of_attempts": 1,
  "url": "https://127.0.0.1/receiver",
  "id": "11e95f8ec39de8fbdb0a4f1a"
}
```

