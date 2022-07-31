
# V1 Tokens Ach Request 1

## Structure

`V1TokensAchRequest1`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AccountHolderName` | `string` | Optional | Account holder name<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `32` |
| `AccountNumber` | `string` | Optional | Account number<br>**Constraints**: *Minimum Length*: `4`, *Maximum Length*: `19` |
| `AccountVaultApiId` | `string` | Optional | This field can be used to correlate Account Vaults in our system to data within an outside software integration<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `36` |
| `AccountvaultC1` | `string` | Optional | Custom field 1 for API users to store custom data<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `128` |
| `AccountvaultC2` | `string` | Optional | Custom field 2 for API users to store custom data<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `128` |
| `AccountvaultC3` | `string` | Optional | Custom field 3 for API users to store custom data<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `128` |
| `AchSecCode` | [`Models.AchSecCodeEnum?`](../../doc/models/ach-sec-code-enum.md) | Optional | SEC code for the account |
| `BillingAddress` | [`Models.BillingAddress`](../../doc/models/billing-address.md) | Optional | The Street portion of the address associated with the Credit Card (CC) or Bank Account (ACH). |
| `ContactId` | `string` | Optional | Used to associate the Account Vault with a Contact.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CustomerId` | `string` | Optional | Used to store a customer identification number.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `50` |
| `IdentityVerification` | [`Models.IdentityVerification`](../../doc/models/identity-verification.md) | Optional | Identity verification |
| `LocationId` | `string` | Optional | A valid Location Id associated with the Contact for this Token<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `PreviousAccountVaultApiId` | `string` | Optional | Can be used to pull payment info from a previous account vault api id.<br>**Constraints**: *Maximum Length*: `64` |
| `PreviousAccountVaultId` | `string` | Optional | Can be used to pull payment info from a previous account vault.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `PreviousTransactionId` | `string` | Optional | Can be used to pull payment info from a previous transaction.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `TermsAgree` | `bool?` | Optional | Terms agreement. |
| `TermsAgreeIp` | `string` | Optional | The ip address of the client that agreed to terms. |
| `Title` | `string` | Optional | Used to describe the Token for easier identification within our UI.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `16` |
| `AccountType` | [`Models.AccountType2Enum?`](../../doc/models/account-type-2-enum.md) | Optional | Account type |
| `IsCompany` | `bool?` | Optional | This identifies whether the ACH account belongs to a company or individual. This can affect which SEC code is used when attempting to run a transaction. |
| `RoutingNumber` | `string` | Optional | Required for ACH. The Routing Number for the bank account being used.<br>**Constraints**: *Minimum Length*: `9`, *Maximum Length*: `9` |

## Example (as JSON)

```json
{
  "account_holder_name": null,
  "account_number": null,
  "account_vault_api_id": null,
  "accountvault_c1": null,
  "accountvault_c2": null,
  "accountvault_c3": null,
  "ach_sec_code": null,
  "billing_address": null,
  "contact_id": null,
  "customer_id": null,
  "identity_verification": null,
  "location_id": null,
  "previous_account_vault_api_id": null,
  "previous_account_vault_id": null,
  "previous_transaction_id": null,
  "terms_agree": null,
  "terms_agree_ip": null,
  "title": null,
  "account_type": null,
  "is_company": null,
  "routing_number": null
}
```

