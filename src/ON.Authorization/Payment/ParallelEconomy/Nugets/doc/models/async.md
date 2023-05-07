
# Async

Do not store the Async Code for long term use, it expires after 30 days.

## Structure

`Async`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Code` | `Guid` | Required | A [UUID v4](https://datatracker.ietf.org/doc/html/rfc4122) that's unique for the Async Request |
| `Link` | `string` | Required | Link to the status check endpoint |

## Example (as JSON)

```json
{
  "code": "406c66c3-21cb-47fb-80fc-843bc42507fb",
  "link": "/v1/async/status/406c66c3-21cb-47fb-80fc-843bc42507fb"
}
```

