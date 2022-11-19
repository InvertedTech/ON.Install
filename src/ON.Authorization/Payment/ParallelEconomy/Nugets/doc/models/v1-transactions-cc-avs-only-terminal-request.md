
# V1 Transactions Cc Avs Only Terminal Request

## Structure

`V1TransactionsCcAvsOnlyTerminalRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AdditionalAmounts` | [`List<Models.AdditionalAmount>`](../../doc/models/additional-amount.md) | Optional | Additional amounts |
| `BillingAddress` | [`Models.BillingAddress2`](../../doc/models/billing-address-2.md) | Optional | The City portion of the address associated with the Credit Card (CC) or Bank Account (ACH). |
| `CheckinDate` | `string` | Optional | Checkin Date - The time difference between checkin_date and checkout_date must be less than or equal to 99 days.<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `CheckoutDate` | `string` | Optional | Checkout Date - The time difference between checkin_date and checkout_date must be less than or equal to 99 days.<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `ClerkNumber` | `string` | Optional | Clerk or Employee Identifier<br>**Constraints**: *Maximum Length*: `16` |
| `ContactApiId` | `string` | Optional | This can be supplied in place of contact_id if you would like to use a contact for the transaction and are using your own custom api_id's to track contacts in the system.<br>**Constraints**: *Maximum Length*: `36` |
| `ContactId` | `string` | Optional | If contact_id is provided, ensure it belongs to the same location as the transaction. You cannot move transaction across locations.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CustomData` | `string` | Optional | A field that allows custom JSON to be entered to store extra data.<br>**Constraints**: *Maximum Length*: `512` |
| `CustomerId` | `string` | Optional | Can be used by Merchants to identify Contacts in our system by an ID from another system.<br>**Constraints**: *Maximum Length*: `64` |
| `Description` | `string` | Optional | Description<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `64` |
| `IdentityVerification` | [`Models.IdentityVerification2`](../../doc/models/identity-verification-2.md) | Optional | Identity Verification |
| `IiasInd` | [`Models.IiasIndEnum?`](../../doc/models/iias-ind-enum.md) | Optional | Possible values are '0', '1','2' |
| `ImageFront` | `string` | Optional | A base64 encoded string for the image.  Used with Check21 ACH transactions. |
| `ImageBack` | `string` | Optional | A base64 encoded string for the image.  Used with Check21 ACH transactions. |
| `Installment` | `bool?` | Optional | Flag that is allowed to be passed on card not present industries to signify the transaction is a fixed installment plan transaction. |
| `InstallmentNumber` | `double?` | Optional | If this is a fixed installment plan and installment field is being passed as 1, then this field must have a vlue of 1-999 specifying the current installment number that is running.<br>**Constraints**: `>= 1`, `<= 999` |
| `InstallmentCount` | `double?` | Optional | If this is a fixed installment plan and installment field is being passed as 1, then this field must have a vlue of 1-999 specifying the total number of installments on the plan. This number must be grater than or equal to installment_number.<br>**Constraints**: `>= 1`, `<= 999` |
| `LocationApiId` | `string` | Optional | This can be supplied in place of location_id for the transaction if you are using your own custom api_id's for your locations.<br>**Constraints**: *Maximum Length*: `36` |
| `LocationId` | `string` | Required | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `NoShow` | `bool?` | Optional | Used in Lodging |
| `NotificationEmailAddress` | `string` | Optional | If email is supplied then receipt will be emailed |
| `OrderNumber` | `string` | Optional | Required for CC transactions , if merchant's deposit account's duplicate check per batch has 'order_number' field<br>**Constraints**: *Maximum Length*: `32` |
| `PoNumber` | `string` | Optional | Purchase Order number<br>**Constraints**: *Maximum Length*: `36` |
| `PreviousTransactionId` | `string` | Optional | previous_transaction_id is used as token to run transaction. Account details OR previous_transaction_id should be passed to run transaction.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ProductTransactionId` | `string` | Optional | The Product's method (cc/ach) has to match the action. If not provided, the API will use the default configured for the Location.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `QuickInvoiceId` | `string` | Optional | Can be used to associate a transaction to a Quick Invoice.  Quick Invoice transactions will have a value for this field automatically.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Recurring` | `bool?` | Optional | Flag that is allowed to be passed on card not present industries to signify the transaction is an ongoing recurring transaction. Possible values to send are 0 or 1. This field must be 0 or not present if installment is sent as 1. |
| `RecurringNumber` | `double?` | Optional | If this is an ongoing recurring and recurring field is being passed as 1, then this field must have a vlue of 1-999 specifying the current recurring number that is running.<br>**Constraints**: `>= 1`, `<= 999` |
| `RoomNum` | `string` | Optional | Used in Lodging<br>**Constraints**: *Maximum Length*: `12` |
| `RoomRate` | `double?` | Optional | Required if merchant industry type is lodging. |
| `SaveAccount` | `bool?` | Optional | Specifies to save account to contacts profile if account_number/track_data is present with either contact_id or contact_api_id in params. |
| `SaveAccountTitle` | `string` | Optional | If saving account vault while running a transaction, this will be the title of the account vault.<br>**Constraints**: *Maximum Length*: `16` |
| `SubtotalAmount` | `int?` | Optional | This field is allowed and required for transactions that have a product where surcharge is configured. Use only integer numbers, so $10.99 will be 1099.<br>**Constraints**: `>= 0`, `<= 9999999999` |
| `SurchargeAmount` | `int?` | Optional | This field is allowed and required for transactions that have a product where surcharge is configured. Use only integer numbers, so $10.99 will be 1099.<br>**Constraints**: `>= 0`, `<= 9999999999` |
| `Tags` | [`List<Models.Tag>`](../../doc/models/tag.md) | Optional | Tags |
| `Tax` | `int?` | Optional | Amount of Sales tax - If supplied, this amount should be included in the total transaction_amount field. Use only integer numbers, so $10.99 will be 1099.<br>**Constraints**: `>= 0`, `<= 9999999999` |
| `TipAmount` | `int?` | Optional | Optional tip amount. Tip is not supported for lodging and ecommerce merchants. Use only integer numbers, so $10.99 will be 1099.<br>**Constraints**: `>= 0`, `<= 9999999999` |
| `TransactionAmount` | `int` | Required | Amount of the transaction. This should always be the desired settle amount of the transaction. Use only integer numbers, so $10.99 will be 1099.<br>**Constraints**: `>= 0`, `<= 9999999999` |
| `TransactionApiId` | `string` | Optional | See api_id page for more details<br>**Constraints**: *Maximum Length*: `64` |
| `TransactionC1` | `string` | Optional | Custom field 1 for api users to store custom data<br>**Constraints**: *Maximum Length*: `128` |
| `TransactionC2` | `string` | Optional | Custom field 2 for api users to store custom data<br>**Constraints**: *Maximum Length*: `128` |
| `TransactionC3` | `string` | Optional | Custom field 3 for api users to store custom data<br>**Constraints**: *Maximum Length*: `128` |
| `TransactionC4` | `string` | Optional | Custom field 4 for api users to store custom data<br>**Constraints**: *Maximum Length*: `128` |
| `AdvanceDeposit` | `bool?` | Optional | Advance Deposit |
| `CardholderPresent` | `bool?` | Optional | If the cardholder is present at the point of service |
| `CardPresent` | `bool?` | Optional | A POST only field to specify whether or not the card is present. |
| `SecureAuthData` | `string` | Optional | (ECOMM) The token authentication value associated with 3D secure transactions (Such as CAVV, UCAF auth data) |
| `SecureProtocolVersion` | `int?` | Optional | (ECOMM)  Secure Program Protocol Version |
| `SecureCollectionIndicator` | `int?` | Optional | (ECOMM) Used for UCAF collection indicator or Discover Autentication type |
| `SecureCrytogram` | `string` | Optional | (ECOMM) Used to supply the Digital Payment Cryptogram obtained from a Digital Secure Remote Payment (DSRP) transaction |
| `SecureDirectoryServerTransactionId` | `string` | Optional | (ECOMM) Directory Server Transaction ID (Such as XID, TAVV) |
| `SecureEcommUrl` | `string` | Optional | (ECOMM) This field is used to enter a merchant identifier such as the Merchant URL or reverse domain name as presented to the consumer during the checkout process for a Digital Secure Remote payment transaction |
| `TerminalSerialNumber` | `string` | Optional | If transaction was processed using a terminal, this field would contain the terminal's serial number<br>**Constraints**: *Maximum Length*: `36`, *Pattern*: `^[a-zA-Z0-9]*$` |
| `Threedsecure` | `bool?` | Optional | Specifies to save account to contacts profile if account_number/track_data is present with either contact_id or contact_api_id in params. |
| `WalletType` | [`Models.WalletTypeEnum?`](../../doc/models/wallet-type-enum.md) | Optional | This value provides information from where the transaction was initialized (Such as In-App provider)<br><br>> 000 - Unknown wallet type (i.e., Discover PayButton)<br>> <br>> 101 - MasterPass by MasterCard<br>> <br>> 103 - Apple Pay<br>> <br>> 216 - Google Pay<br>> <br>> 217 - Samsung Pay<br>> <br>> 327 - Merchant tokenization program |
| `TerminalId` | `string` | Required | Terminal ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "transaction_amount": 2099,
  "terminal_id": "11e95f8ec39de8fbdb0a4f1a"
}
```

