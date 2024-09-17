
# V1 Tokens Terminal Request

## Structure

`V1TokensTerminalRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AccountHolderName` | `string` | Optional | Account holder name<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `32` |
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
| `AccountNumber` | [`V1TokensTerminalRequestAccountNumber`](../../doc/models/containers/v1-tokens-terminal-request-account-number.md) | Optional | This is a container for one-of cases.<br>**Constraints**: *Minimum Length*: `4`, *Maximum Length*: `19`, *Pattern*: `^[\d]+$` |
| `TermsAgree` | `bool?` | Optional | Terms agreement. |
| `TermsAgreeIp` | `string` | Optional | The ip address of the client that agreed to terms. |
| `Title` | `string` | Optional | Used to describe the Token for easier identification within our UI.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `16` |
| `Joi` | [`Joi4`](../../doc/models/joi-4.md) | Optional | - |
| `Action` | `string` | Required, Constant | Used for the Create Terminal endpoint. Valid value 'store'<br>**Default**: `"store"` |
| `TerminalId` | `string` | Required | Terminal ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "account_holder_name": "John Smith",
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
  "account_number": 545454545454545,
  "terms_agree": true,
  "terms_agree_ip": "192.168.0.10",
  "title": "Test CC Account",
  "action": "store",
  "terminal_id": "11e95f8ec39de8fbdb0a4f1a"
}
```

