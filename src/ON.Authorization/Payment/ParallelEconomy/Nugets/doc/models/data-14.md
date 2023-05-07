
# Data 14

## Structure

`Data14`

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
| `LocationId` | `string` | Optional | A valid Location Id to associate the transaction with.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
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
| `Id` | `string` | Required | Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |
| `AccountHolderName` | `string` | Optional | For CC, this is the 'Name (as it appears) on Card'. For ACH, this is the 'Name on Account'.<br>**Constraints**: *Maximum Length*: `32` |
| `AccountType` | `string` | Optional | Required for ACH transactions if account_vault_id is not provided.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `32` |
| `AccountVaultApiId` | `string` | Optional | This can be supplied in place of account_vault_id if you would like to use an account vault for the transaction and are using your own custom api_id's to track accountvaults in the system.<br>**Constraints**: *Maximum Length*: `36` |
| `AccountVaultId` | `string` | Optional | Required if account_number,  track_data, micr_data is not provided.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `AchIdentifier` | `string` | Optional | Required for ACH transactions in certain scenarios.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `1` |
| `AchSecCode` | [`Models.AchSecCode2Enum?`](../../doc/models/ach-sec-code-2-enum.md) | Optional | Required for ACH transactions if account_vault_id is not provided. |
| `AdvanceDeposit` | `bool?` | Optional | Advance Deposit |
| `AuthAmount` | `double?` | Optional | Authorization Amount<br>**Constraints**: `<= 9999999999` |
| `AuthCode` | `string` | Optional | Required on force transactions. Ignored for all other actions.<br>**Constraints**: *Minimum Length*: `6`, *Maximum Length*: `6` |
| `Avs` | [`Models.AvsEnum?`](../../doc/models/avs-enum.md) | Optional | AVS |
| `AvsEnhanced` | `string` | Optional | AVS Enhanced<br>**Constraints**: *Minimum Length*: `1` |
| `CardholderPresent` | `bool?` | Optional | If the cardholder is present at the point of service |
| `CardPresent` | `bool?` | Optional | A POST only field to specify whether or not the card is present. |
| `CheckNumber` | `string` | Optional | Required for transactions using TEL SEC code.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `15` |
| `CustomerIp` | `string` | Optional | Can be used to store customer IP Address |
| `CvvResponse` | `string` | Optional | Obfuscated CVV<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `1` |
| `EntryModeId` | [`Models.EntryModeIdEnum?`](../../doc/models/entry-mode-id-enum.md) | Optional | Entry Mode - See entry mode section for more detail |
| `EmvReceiptData` | [`Models.EmvReceiptData`](../../doc/models/emv-receipt-data.md) | Optional | This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM |
| `FirstSix` | `string` | Optional | First six numbers of account_number.  Automatically generated by system.<br>**Constraints**: *Minimum Length*: `6`, *Maximum Length*: `6` |
| `LastFour` | `string` | Optional | Last four numbers of account_number.  Automatically generated by the system.<br>**Constraints**: *Minimum Length*: `4`, *Maximum Length*: `4` |
| `PaymentMethod` | [`Models.PaymentMethod4Enum`](../../doc/models/payment-method-4-enum.md) | Required | 'cc' or 'ach' |
| `TerminalSerialNumber` | `string` | Optional | If transaction was processed using a terminal, this field would contain the terminal's serial number<br>**Constraints**: *Maximum Length*: `36`, *Pattern*: `^[a-zA-Z0-9]*$` |
| `TransactionSettlementStatus` | `string` | Optional | (Deprecated field)<br>**Constraints**: *Maximum Length*: `32` |
| `ChargeBackDate` | `string` | Optional | Charge Back Date (ACH Trxs)<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `IsRecurring` | `bool?` | Optional | Flag that is allowed to be passed on card not present industries to signify the transaction is a fixed installment plan transaction. |
| `NotificationEmailSent` | `string` | Optional | Indicates if email receipt has been sent |
| `Par` | `string` | Optional | A field usually returned form the processor to uniquely identifier a specific cardholder's credit card.<br>**Constraints**: *Maximum Length*: `36` |
| `ReasonCodeId` | `double?` | Optional | Response reason code that provides more detail as to the result of the transaction. The reason code list can be found here: Response Reason Codes<br>**Constraints**: `<= 9999` |
| `RecurringId` | `string` | Optional | A unique identifer used to associate a transaction with a Recurring.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `SettleDate` | `string` | Optional | Settle date<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `StatusId` | [`Models.StatusId2Enum?`](../../doc/models/status-id-2-enum.md) | Optional | Status ID - See status id section for more detail<br><br>> 101 - Sale cc Approved<br>> <br>> 102 - Sale cc AuthOnly<br>> <br>> 111 - Refund cc Refunded<br>> <br>> 121 - Credit/Debit/Refund cc AvsOnly<br>> <br>> 131 - Credit/Debit/Refund ach Pending Origination<br>> <br>> 132 - Credit/Debit/Refund ach Originating<br>> <br>> 133 - Credit/Debit/Refund ach Originated<br>> <br>> 134 - Credit/Debit/Refund ach Settled<br>> <br>> 191 - Settled (depracated - batches are now settled on the /v2/transactionbatches endpoint)<br>> <br>> 201 - All cc/ach Voided<br>> <br>> 301 - All cc/ach Declined<br>> <br>> 331 - Credit/Debit/Refund ach Charged Back |
| `TransactionBatchId` | `string` | Optional | For cc transactions, this is the id of the batch the transaction belongs to (not to be confused with batch number). This will be null for transactions that do not settle (void and authonly).<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `TypeId` | [`Models.TypeIdEnum?`](../../doc/models/type-id-enum.md) | Optional | Type ID - See type id section for more detail |
| `Verbiage` | `string` | Optional | Verbiage -Do not use verbiage to see if the transaction was approved, use status_id |
| `VoidDate` | `string` | Optional | void date<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `Batch` | `string` | Optional | Batch |
| `TermsAgree` | `bool?` | Optional | Terms Agreement |
| `ResponseMessage` | `string` | Optional | Response Message<br>**Constraints**: *Maximum Length*: `255` |
| `ReturnDate` | `string` | Optional | Return Date<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `TrxSourceId` | `int?` | Optional | How the transaction was obtained by the API.<br>**Constraints**: `<= 99` |

## Example (as JSON)

```json
{
  "transaction_amount": 2099,
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "payment_method": "cc"
}
```

