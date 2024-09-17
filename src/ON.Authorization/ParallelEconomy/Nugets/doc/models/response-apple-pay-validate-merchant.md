
# Response Apple Pay Validate Merchant

## Structure

`ResponseApplePayValidateMerchant`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | Resource Type<br>**Default**: `"ApplePayValidateMerchant"` |
| `Data` | [`Data33`](../../doc/models/data-33.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "ApplePayValidateMerchant",
  "data": {
    "merchantSession": "merchantSession0"
  }
}
```

