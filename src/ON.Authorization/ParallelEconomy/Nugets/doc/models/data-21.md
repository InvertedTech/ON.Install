
# Data 21

## Structure

`Data21`

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
| `AccountNumber` | [`Data21AccountNumber`](../../doc/models/containers/data-21-account-number.md) | Optional | This is a container for one-of cases.<br>**Constraints**: *Minimum Length*: `4`, *Maximum Length*: `19`, *Pattern*: `^[\d]+$` |
| `TermsAgree` | `bool?` | Optional | Terms agreement. |
| `TermsAgreeIp` | `string` | Optional | The ip address of the client that agreed to terms. |
| `Title` | `string` | Optional | Used to describe the Token for easier identification within our UI.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `16` |
| `Joi` | [`Joi4`](../../doc/models/joi-4.md) | Optional | - |
| `Id` | `string` | Required | A unique, system-generated identifier for the Token.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `AccountType` | `string` | Required | Account type<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `32` |
| `Active` | `bool?` | Optional | Register is Active |
| `CauSummaryStatusId` | [`CauSummaryStatusIdEnum`](../../doc/models/cau-summary-status-id-enum.md) | Required | CAU Summary Status ID. |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `ESerialNumber` | `string` | Optional | E Serial Number<br>**Constraints**: *Maximum Length*: `36`, *Pattern*: `^[a-zA-Z0-9]*$` |
| `ETrackData` | `string` | Optional | E Track Data |
| `EFormat` | `string` | Optional | E Format |
| `EKeyedData` | `string` | Optional | E Keyed Data |
| `ExpiringInMonths` | `int?` | Optional | Determined by API based on card exp_date. |
| `ExpDate` | `string` | Optional | Required for CC. The Expiration Date for the credit card. (MMYY format).<br>**Constraints**: *Maximum Length*: `4` |
| `FirstSix` | `string` | Required | The first six numbers of an account number.  System will generate a value for this field automatically.<br>**Constraints**: *Maximum Length*: `6` |
| `HasRecurring` | `bool` | Required | True indicates that this token is tied to a Recurring Payment |
| `LastFour` | `string` | Required | The last four numbers of an account number.  System will generate a value for this field automatically.<br>**Constraints**: *Maximum Length*: `4` |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |
| `PaymentMethod` | [`PaymentMethod13Enum`](../../doc/models/payment-method-13-enum.md) | Required | Must be provided as either 'cc' or 'ach'. |
| `Ticket` | `string` | Optional | A valid ticket that was created to store the token.<br>**Constraints**: *Maximum Length*: `36` |
| `TrackData` | `string` | Optional | Track Data from a magnetic card swipe.<br>**Constraints**: *Maximum Length*: `256` |
| `CreatedUserId` | `string` | Optional | User ID Created the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CauLastUpdatedTs` | `int?` | Optional | CAU Last Updated Timestamp |
| `CardBin` | `string` | Optional | Card bin |
| `RoutingNumber` | `string` | Optional | Required for ACH. The Routing Number for the bank account being used. |
| `Location` | [`Location`](../../doc/models/location.md) | Optional | Location Information on `expand` |
| `Contact` | [`Contact1`](../../doc/models/contact-1.md) | Optional | Contact Information on `expand` |
| `Transactions` | [`List<Transaction>`](../../doc/models/transaction.md) | Optional | Transaction Information on `expand` |
| `ActiveRecurrings` | [`List<ActiveRecurring>`](../../doc/models/active-recurring.md) | Optional | ActiveRecurring Information on `expand` |
| `IsDeletable` | `bool?` | Optional | Is Deletable Information on `expand` |
| `Signature` | [`Signature`](../../doc/models/signature.md) | Optional | Signature Information on `expand` |
| `CreatedUser` | [`CreatedUser`](../../doc/models/created-user.md) | Optional | User Information on `expand` |
| `Changelogs` | [`List<Changelog>`](../../doc/models/changelog.md) | Optional | Changelog Information on `expand` |
| `AccountVaultCauLogs` | [`List<AccountVaultCauLog>`](../../doc/models/account-vault-cau-log.md) | Optional | Token Cau Log Information on `expand` |
| `AccountVaultCauProductTransactions` | [`List<AccountVaultCauProductTransaction>`](../../doc/models/account-vault-cau-product-transaction.md) | Optional | Token Cau Product Transaction Information on `expand` |

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
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "account_type": "checking",
  "active": true,
  "cau_summary_status_id": 1,
  "created_ts": 1422040992,
  "e_serial_number": "1234567890",
  "exp_date": "0722",
  "first_six": "700953",
  "has_recurring": false,
  "last_four": "3657",
  "modified_ts": 1422040992,
  "payment_method": "cc",
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "cau_last_updated_ts": 1422040992,
  "routing_number": "051904524",
  "is_deletable": true
}
```

