
# Response 417 Filter Channels

## Structure

`Response417filterChannels`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `StatusCode` | `int?` | Optional | Response code |
| `Error` | `string` | Optional | Expectation Failed |
| `Message` | `string` | Optional | Channel filters are not set for this project |

## Example (as JSON)

```json
{
  "statusCode": 417,
  "error": "Expectation Failed",
  "message": "Channel filters are not set for this project"
}
```

