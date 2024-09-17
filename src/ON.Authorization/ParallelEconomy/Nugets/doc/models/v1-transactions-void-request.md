
# V1 Transactions Void Request

## Structure

`V1TransactionsVoidRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Tags` | `List<string>` | Optional | Tags |
| `Description` | `string` | Optional | Description<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `64` |

## Example (as JSON)

```json
{
  "description": "some description",
  "tags": [
    "tags7"
  ]
}
```

