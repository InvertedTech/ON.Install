
# V1 Wallet Provider Merchant Details Request

## Structure

`V1WalletProviderMerchantDetailsRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `MerchantOrigin` | `string` | Required | Domain name where the Apple or Google pay button is or will be displayed. Full domain name including subdomain. |

## Example (as JSON)

```json
{
  "merchantOrigin": "dev.pay.site"
}
```

