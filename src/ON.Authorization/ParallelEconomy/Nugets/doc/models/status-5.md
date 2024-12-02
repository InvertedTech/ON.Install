
# Status 5

## Structure

`Status5`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ResponseCode` | `string` | Optional | Response code for API response.<br>**Constraints**: *Maximum Length*: `20` |
| `ReasonCode` | `string` | Optional | Reason code for API response.<br>**Constraints**: *Maximum Length*: `10` |
| `ReasonText` | `string` | Optional | Reason text returned for any errors from API call.<br>**Constraints**: *Maximum Length*: `100` |

## Example (as JSON)

```json
{
  "response_code": "Received",
  "reason_code": "reason_code6",
  "reason_text": "reason_text4"
}
```

