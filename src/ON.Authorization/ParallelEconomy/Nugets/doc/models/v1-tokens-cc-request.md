
# V1 Tokens Cc Request

## Structure

`V1TokensCcRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AccountHolderName` | `string` | Optional | Account holder name<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `32` |
| `AccountNumber` | `string` | Optional | Account number |
| `AccountVaultApiId` | `string` | Optional | This field can be used to correlate Tokens in our system to data within an outside software integration<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `64` |
| `TokenApiId` | `string` | Optional | This field can be used to correlate Tokens in our system to data within an outside software integration<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `64` |
| `AccountvaultC1` | `string` | Optional | DEPRECATED (Use token_c1 instead)<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `128` |
| `AccountvaultC2` | `string` | Optional | DEPRECATED (Use token_c2 instead)<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `128` |
| `AccountvaultC3` | `string` | Optional | DEPRECATED (Use token_c3 instead)<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `128` |
| `TokenC1` | `string` | Optional | Custom field 1 for API users to store custom data<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `128` |
| `TokenC2` | `string` | Optional | Custom field 2 for API users to store custom data<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `128` |
| `TokenC3` | `string` | Optional | Custom field 3 for API users to store custom data<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `128` |
| `AchSecCode` | [`AchSecCode3Enum?`](../../doc/models/ach-sec-code-3-enum.md) | Optional | SEC code for the account |
| `BillingAddress` | [`BillingAddress`](../../doc/models/billing-address.md) | Optional | Billing Address Object |
| `ContactId` | `string` | Optional | Used to associate the Token with a Contact.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CustomerId` | `string` | Optional | Used to store a customer identification number.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `50` |
| `IdentityVerification` | [`IdentityVerification2`](../../doc/models/identity-verification-2.md) | Optional | Identity verification |
| `LocationId` | `string` | Required | A valid Location Id associated with the Contact for this Token<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `PreviousAccountVaultApiId` | `string` | Optional | Can be used to pull payment info from a previous token api id.<br>**Constraints**: *Maximum Length*: `64` |
| `PreviousTokenApiId` | `string` | Optional | Can be used to pull payment info from a previous token api id.<br>**Constraints**: *Maximum Length*: `64` |
| `PreviousAccountVaultId` | `string` | Optional | Can be used to pull payment info from a previous token.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `PreviousTokenId` | `string` | Optional | Can be used to pull payment info from a previous token.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `PreviousTransactionId` | `string` | Optional | Can be used to pull payment info from a previous transaction.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `TermsAgree` | `bool?` | Optional | Terms agreement. |
| `TermsAgreeIp` | `string` | Optional | The ip address of the client that agreed to terms. |
| `Title` | `string` | Optional | Used to describe the Token for easier identification within our UI.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `16` |
| `Joi` | [`Joi17`](../../doc/models/joi-17.md) | Optional | - |
| `ExpDate` | `string` | Optional | Required for CC. The Expiration Date for the credit card. (MMYY format).<br>**Constraints**: *Pattern*: `^(0[1-9]\|1[0-2])[0-9]{2}$` |
| `ESerialNumber` | `string` | Optional | E Serial Number<br>**Constraints**: *Maximum Length*: `36`, *Pattern*: `^[a-zA-Z0-9]*$` |
| `ETrackData` | `string` | Optional | E Track Data |
| `EFormat` | `string` | Optional | E Format |
| `EKeyedData` | `string` | Optional | E Keyed Data |
| `RunAvs` | `bool?` | Optional | A flag that will override a product transactions run_avs_on_accountvault_create setting to determine if an avsonly transaction should be run prior to storing the token. When storing an token with tha run_avs flag, if the avsonly check fails account verification with the processor, the token will not be stored in the system. The meaning of the AVS response codes can be found here on this page.This is the new preferred method of validating a credit card and can be used instead of the legacy $1 auth only transaction.Using this flag overrides the default setting for the locations product transactions. |
| `TrackData` | `string` | Optional | Track Data from a magnetic card swipe.<br>**Constraints**: *Maximum Length*: `256` |
| `Ticket` | `string` | Optional | A valid ticket that was created to store the token.<br>**Constraints**: *Maximum Length*: `36` |

## Example (as JSON)

```json
{
  "account_holder_name": "John Smith",
  "account_number": "5454545454545454",
  "account_vault_api_id": "accountvaultabcd",
  "token_api_id": "tokenabcd",
  "accountvault_c1": "accountvault custom 1",
  "accountvault_c2": "accountvault custom 2",
  "accountvault_c3": "accountvault custom 3",
  "token_c1": "token custom 1",
  "token_c2": "token custom 2",
  "token_c3": "token custom 3",
  "ach_sec_code": "WEB",
  "contact_id": "11e95f8ec39de8fbdb0a4f1a",
  "customer_id": "123456",
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "previous_account_vault_api_id": "previousaccountvault123456",
  "previous_token_api_id": "previousaccountvault123456",
  "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
  "previous_token_id": "11e95f8ec39de8fbdb0a4f1a",
  "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
  "terms_agree": true,
  "terms_agree_ip": "192.168.0.10",
  "title": "Test CC Account",
  "exp_date": "0929",
  "e_serial_number": "1234567890",
  "e_track_data": "%B5454545454545454^account holder^17041010001111A123456789012?250112000000153000000?;5454545454545454=25011011000012345678?00|DC7AB845EFA793FB3C89C5D347D36ED11CAAED0C33E150437893996BA75EB8A0F334D0DAA1B874B6C677A4EF6984B089F891D8E434ACD867B616F4D815E63DA6A86B2AF927E9919B0CFC1DA3FD276D9382672EF8AA256329|32EA4D785CA3398882AABC405017EF9C2BDA666FA007A76538DE10878601EEC36EFE1F185BB8B1C8",
  "e_format": "ksn",
  "e_keyed_data": "236D530E098D48DB3F1AA367882CC1A7D475EFCACEFF1E965F17EC1E2D42CBF611C9EB0F80F4255784BA06951BD6092AB6CD3369D3D7E022E74DDCB16F9C40599FA03355E37E6ABB06B717B207709ED8C6BC5C7B6E32BB2B2F5046551A1C88D6",
  "run_avs": false,
  "track_data": "%B5424181111112228^FDCS TEST CARD /MASTERCARD^18121010001111123456789012?;5424181111112228=1812101100000123456?",
  "ticket": "12345678"
}
```

