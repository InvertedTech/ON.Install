
# Data 32

## Structure

`Data32`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ResultCode` | `bool?` | Optional | 0 for success, 1 for error. More details on Message field. |
| `MerchantID` | `string` | Optional | string needed to set up a Google or Apple Pay button. |
| `ApplePay` | `bool?` | Optional | Boolean indicating if Apple Pay is enabled for this merchant. |
| `GooglePay` | `bool?` | Optional | Boolean indicating if Google Pay is enabled for this merchant. |
| `ApplePayDomains` | `object` | Optional | Array of the domains registered with apple for this domain.  For Apple Pay, each domain name a merchant uses used has to be registered with Apple before it can be used.  When calling Merchant Details the gateway first checks if the domain provided is already registered for that merchant. If it is, it will return applePay: true and resultCode: 0 and the domain will be listed in appleDomains array.  It will also list all verified domains for that merchant.  If the domain is not verified it will try to verify it and if successful will return applePay: true and the domain will be listed in applePayDomains.  If the domain is not verified successfully the response will return applePay: false and resultCode: 1. Merchant will not be able to process payment in that domain.  Apple verifies the domain by pulling down a verification text file that should be placed on http://domainname.well-known/apple-developer-merchantid-domain-association.  File name must be apple-developer-merchantid-domain-association without a file extension. The contents of the file may be served programmatically. The contents of this file will be the same for all merchants processing Apple Pay. |
| `Message` | `string` | Optional | Message with information about the results. |
| `GoogleJWT` | `string` | Optional | String needed in the Google Pay request. |

## Example (as JSON)

```json
{
  "resultCode": false,
  "merchantID": "abc1234",
  "applePay": true,
  "googlePay": true,
  "applePayDomains": [
    {
      "key1": "val1",
      "key2": "val2"
    },
    {
      "key1": "val1",
      "key2": "val2"
    }
  ],
  "message": "valid user",
  "googleJWT": "45r8v29bvj4gc904jfd932nm"
}
```

