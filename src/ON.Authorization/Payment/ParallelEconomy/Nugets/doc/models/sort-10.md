
# Sort 10

You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods:

> /endpoint?sort={ "field_name": "asc", "field_name2": "desc" }
> 
> /endpoint?sort[field_name]=asc&sort[field_name2]=desc

## Structure

`Sort10`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AccountHolderName` | `string` | Optional | Account holder name<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `32` |
| `AccountNumber` | `string` | Optional | Account number<br>**Constraints**: *Minimum Length*: `4`, *Maximum Length*: `19`, *Pattern*: `^[\d]+$` |
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
| `Id` | `string` | Optional | A unique, system-generated identifier for the Token.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `AccountType` | `string` | Optional | Account type<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `32` |
| `Active` | `bool?` | Optional | Register is Active |
| `CauSummaryStatusId` | [`Models.CauSummaryStatusIdEnum?`](../../doc/models/cau-summary-status-id-enum.md) | Optional | CAU Summary Status ID. |
| `CreatedTs` | `int?` | Optional | Created Time Stamp |
| `ESerialNumber` | `string` | Optional | E Serial Number<br>**Constraints**: *Maximum Length*: `36`, *Pattern*: `^[a-zA-Z0-9]*$` |
| `ETrackData` | `string` | Optional | E Track Data |
| `EFormat` | `string` | Optional | E Format |
| `EKeyedData` | `string` | Optional | E Keyed Data |
| `ExpiringInMonths` | `int?` | Optional | Determined by API based on card exp_date. |
| `FirstSix` | `string` | Optional | The first six numbers of an account number.  System will generate a value for this field automatically.<br>**Constraints**: *Maximum Length*: `6` |
| `HasRecurring` | `bool?` | Optional | True indicates that this account vault is tied to a Recurring Payment |
| `LastFour` | `string` | Optional | The last four numbers of an account number.  System will generate a value for this field automatically.<br>**Constraints**: *Maximum Length*: `4` |
| `ModifiedTs` | `int?` | Optional | Modified Time Stamp |
| `PaymentMethod` | [`Models.PaymentMethod2Enum?`](../../doc/models/payment-method-2-enum.md) | Optional | Must be provided as either 'cc' or 'ach'. |
| `Ticket` | `string` | Optional | A valid ticket that was created to store the token.<br>**Constraints**: *Maximum Length*: `36` |
| `TrackData` | `string` | Optional | Track Data from a magnetic card swipe.<br>**Constraints**: *Maximum Length*: `256` |

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
  "id": null,
  "account_type": null,
  "active": null,
  "cau_summary_status_id": null,
  "created_ts": null,
  "e_serial_number": null,
  "e_track_data": null,
  "e_format": null,
  "e_keyed_data": null,
  "expiring_in_months": null,
  "first_six": null,
  "has_recurring": null,
  "last_four": null,
  "modified_ts": null,
  "payment_method": null,
  "ticket": null,
  "track_data": null
}
```

