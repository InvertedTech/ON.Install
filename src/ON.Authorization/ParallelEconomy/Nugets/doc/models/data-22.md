
# Data 22

## Structure

`Data22`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AdditionalAmounts` | [`List<AdditionalAmount>`](../../doc/models/additional-amount.md) | Optional | Additional amounts |
| `BillingAddress` | [`BillingAddress`](../../doc/models/billing-address.md) | Optional | Billing Address Object |
| `CheckinDate` | `string` | Optional | Checkin Date - The time difference between checkin_date and checkout_date must be less than or equal to 99 days.<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `CheckoutDate` | `string` | Optional | Checkout Date - The time difference between checkin_date and checkout_date must be less than or equal to 99 days.<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `ClerkNumber` | `string` | Optional | Clerk or Employee Identifier<br>**Constraints**: *Maximum Length*: `16` |
| `ContactApiId` | `string` | Optional | This can be supplied in place of contact_id if you would like to use a contact for the transaction and are using your own custom api_id's to track contacts in the system.<br>**Constraints**: *Maximum Length*: `36` |
| `ContactId` | `string` | Optional | If contact_id is provided, ensure it belongs to the same location as the transaction. You cannot move transaction across locations.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CustomData` | `object` | Optional | A field that allows custom JSON to be entered to store extra data. |
| `CustomerId` | `string` | Optional | Can be used by Merchants to identify Contacts in our system by an ID from another system.<br>**Constraints**: *Maximum Length*: `64` |
| `Description` | `string` | Optional | Description<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `64` |
| `IiasInd` | [`IiasIndEnum?`](../../doc/models/iias-ind-enum.md) | Optional | Possible values are '0', '1','2' |
| `ImageFront` | `string` | Optional | A base64 encoded string for the image.  Used with Check21 ACH transactions. |
| `ImageBack` | `string` | Optional | A base64 encoded string for the image.  Used with Check21 ACH transactions. |
| `Installment` | `bool?` | Optional | Flag that is allowed to be passed on card not present industries to signify the transaction is a fixed installment plan transaction. |
| `InstallmentNumber` | `int?` | Optional | If this is a fixed installment plan and installment field is being passed as 1, then this field must have a vlue of 1-999 specifying the current installment number that is running.<br>**Constraints**: `>= 1`, `<= 999` |
| `InstallmentCount` | `int?` | Optional | If this is a fixed installment plan and installment field is being passed as 1, then this field must have a vlue of 1-999 specifying the total number of installments on the plan. This number must be grater than or equal to installment_number.<br>**Constraints**: `>= 1`, `<= 999` |
| `LocationApiId` | `string` | Optional | This can be supplied in place of location_id for the transaction if you are using your own custom api_id's for your locations.<br>**Constraints**: *Maximum Length*: `36` |
| `LocationId` | `string` | Optional | A valid Location Id to associate the transaction with.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ProductTransactionId` | `string` | Optional | The Product's method (cc/ach) has to match the action. If not provided, the API will use the default configured for the Location.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `AdvanceDeposit` | `bool?` | Optional | Advance Deposit |
| `NoShow` | `bool?` | Optional | Used in Lodging |
| `NotificationEmailAddress` | `string` | Optional | If email is supplied then receipt will be emailed |
| `OrderNumber` | `string` | Optional | Required for CC transactions , if merchant's deposit account's duplicate check per batch has 'order_number' field<br>**Constraints**: *Maximum Length*: `32` |
| `PoNumber` | `string` | Optional | Purchase Order number<br>**Constraints**: *Maximum Length*: `36` |
| `QuickInvoiceId` | `string` | Optional | Can be used to associate a transaction to a Quick Invoice.  Quick Invoice transactions will have a value for this field automatically.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Recurring` | [`Recurring3`](../../doc/models/recurring-3.md) | Optional | Recurring Information on `expand` |
| `RecurringNumber` | `int?` | Optional | If this is an ongoing recurring and recurring field is being passed as 1, then this field must have a vlue of 1-999 specifying the current recurring number that is running.<br>**Constraints**: `>= 1`, `<= 999` |
| `RoomNum` | `string` | Optional | Used in Lodging<br>**Constraints**: *Maximum Length*: `12` |
| `RoomRate` | `int?` | Optional | Required if merchant industry type is lodging. |
| `SaveAccount` | `bool?` | Optional | Specifies to save account to contacts profile if account_number/track_data is present with either contact_id or contact_api_id in params. |
| `SaveAccountTitle` | `string` | Optional | If saving token while running a transaction, this will be the title of the token.<br>**Constraints**: *Maximum Length*: `16` |
| `SubtotalAmount` | `int?` | Optional | This field is allowed and required for transactions that have a product where surcharge is configured. Use only integer numbers, so $10.99 will be 1099.<br>**Constraints**: `>= 0`, `<= 999999999` |
| `SurchargeAmount` | `int?` | Optional | This field is allowed and required for transactions that have a product where surcharge is configured. Use only integer numbers, so $10.99 will be 1099.<br>**Constraints**: `>= 0`, `<= 999999999` |
| `Tags` | [`List<Tag>`](../../doc/models/tag.md) | Optional | Tag Information on `expand` |
| `Tax` | `int?` | Optional | Amount of Sales tax - If supplied, this amount should be included in the total transaction_amount field. Use only integer numbers, so $10.99 will be 1099.<br>**Constraints**: `>= 0`, `<= 999999999` |
| `TipAmount` | `int?` | Optional | Optional tip amount. Tip is not supported for lodging and ecommerce merchants. Use only integer numbers, so $10.99 will be 1099.<br>**Constraints**: `>= 0`, `<= 999999999` |
| `TransactionAmount` | `int?` | Optional | Amount of the transaction. This should always be the desired settle amount of the transaction. Use only integer numbers, so $10.99 will be 1099.<br>**Constraints**: `>= 0`, `<= 999999999` |
| `SecondaryAmount` | `int?` | Optional | Retained Amount of the transaction. This should always be less than transaction amount. Use only integer numbers, so $10.99 will be 1099<br>**Constraints**: `>= 0`, `<= 999999999` |
| `TransactionApiId` | `string` | Optional | See api_id page for more details<br>**Constraints**: *Maximum Length*: `64` |
| `TransactionC1` | `string` | Optional | Custom field 1 for api users to store custom data<br>**Constraints**: *Maximum Length*: `128` |
| `TransactionC2` | `string` | Optional | Custom field 2 for api users to store custom data<br>**Constraints**: *Maximum Length*: `128` |
| `TransactionC3` | `string` | Optional | Custom field 3 for api users to store custom data<br>**Constraints**: *Maximum Length*: `128` |
| `BankFundedOnlyOverride` | `bool?` | Optional | Bank Funded Only Override |
| `AllowPartialAuthorizationOverride` | `bool?` | Optional | Allow Partial Authorization Override |
| `AutoDeclineCvvOverride` | `bool?` | Optional | Auto Decline CVV Override |
| `AutoDeclineStreetOverride` | `bool?` | Optional | Auto Decline Street Override |
| `AutoDeclineZipOverride` | `bool?` | Optional | Auto Decline Zip Override |
| `Id` | `string` | Required | Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |
| `TerminalId` | `string` | Optional | Terminal ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `AccountHolderName` | `string` | Optional | For CC, this is the 'Name (as it appears) on Card'. For ACH, this is the 'Name on Account'.<br>**Constraints**: *Maximum Length*: `32` |
| `AccountType` | `string` | Optional | Required for ACH transactions if account_vault_id is not provided.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `32` |
| `TokenApiId` | `string` | Optional | This can be supplied in place of account_vault_id if you would like to use an token for the transaction and are using your own custom api_id's to track accountvaults in the system.<br>**Constraints**: *Maximum Length*: `36` |
| `TokenId` | `string` | Optional | Required if account_number,  track_data, micr_data is not provided.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `AchIdentifier` | `string` | Optional | Required for ACH transactions in certain scenarios.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `1` |
| `AchSecCode` | [`AchSecCode1Enum?`](../../doc/models/ach-sec-code-1-enum.md) | Optional | Required for ACH transactions if account_vault_id is not provided. |
| `AuthAmount` | `int?` | Optional | Authorization Amount<br>**Constraints**: `<= 999999999` |
| `AuthCode` | `string` | Optional | Required on force transactions. Ignored for all other actions.<br>**Constraints**: *Minimum Length*: `6`, *Maximum Length*: `6` |
| `Avs` | [`AvsEnum?`](../../doc/models/avs-enum.md) | Optional | AVS |
| `AvsEnhanced` | `string` | Optional | AVS Enhanced<br>**Constraints**: *Minimum Length*: `1` |
| `CardholderPresent` | `bool?` | Optional | If the cardholder is present at the point of service |
| `CardPresent` | `bool?` | Optional | A POST only field to specify whether or not the card is present. |
| `CheckNumber` | `string` | Optional | Required for transactions using TEL SEC code.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `15` |
| `CustomerIp` | `string` | Optional | Can be used to store customer IP Address |
| `CvvResponse` | `string` | Optional | Obfuscated CVV<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `1` |
| `EntryModeId` | [`EntryModeIdEnum?`](../../doc/models/entry-mode-id-enum.md) | Optional | Entry Mode - See entry mode section for more detail |
| `EmvReceiptData` | [`EmvReceiptData`](../../doc/models/emv-receipt-data.md) | Optional | This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM |
| `FirstSix` | `string` | Optional | First six numbers of account_number.  Automatically generated by system.<br>**Constraints**: *Minimum Length*: `6`, *Maximum Length*: `6` |
| `LastFour` | `string` | Optional | Last four numbers of account_number.  Automatically generated by the system.<br>**Constraints**: *Minimum Length*: `4`, *Maximum Length*: `4` |
| `PaymentMethod` | [`PaymentMethod6Enum`](../../doc/models/payment-method-6-enum.md) | Required | 'cc' or 'ach' |
| `TerminalSerialNumber` | `string` | Optional | If transaction was processed using a terminal, this field would contain the terminal's serial number<br>**Constraints**: *Maximum Length*: `36`, *Pattern*: `^[a-zA-Z0-9]*$` |
| `TransactionSettlementStatus` | `string` | Optional | (Deprecated field)<br>**Constraints**: *Maximum Length*: `32` |
| `ChargeBackDate` | `string` | Optional | Charge Back Date (ACH Trxs)<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `IsRecurring` | `bool?` | Optional | Flag that is allowed to be passed on card not present industries to signify the transaction is a fixed installment plan transaction. |
| `NotificationEmailSent` | `bool?` | Optional | Indicates if email receipt has been sent |
| `Par` | `string` | Optional | A field usually returned form the processor to uniquely identifier a specific cardholder's credit card.<br>**Constraints**: *Maximum Length*: `36` |
| `ReasonCodeId` | [`ReasonCodeId1Enum?`](../../doc/models/reason-code-id-1-enum.md) | Optional | Response reason code that provides more detail as to the result of the transaction. The reason code list can be found here: Response Reason Codes<br><br>> 0 - N/A<br>> <br>> 1000 - CC - Approved / ACH - Accepted<br>> <br>> 1000 - CC - Approved / ACH - Accepted<br>> <br>> 1001 - AuthCompleted<br>> <br>> 1002 - Forced<br>> <br>> 1003 - AuthOnly Declined<br>> <br>> 1004 - Validation Failure (System Run Trx)<br>> <br>> 1005 - Processor Response Invalid<br>> <br>> 1200 - Voided<br>> <br>> 1201 - Partial Approval<br>> <br>> 1240 - Approved, optional fields are missing (Paya ACH only)<br>> <br>> 1301 - Account Deactivated for Fraud<br>> <br>> 1302-1399 - Reserved for Future Fraud Reason Codes<br>> <br>> 1500 - Generic Decline<br>> <br>> 1510 - Call<br>> <br>> 1518 - Transaction Not Permitted - Terminal<br>> <br>> 1520 - Pickup Card<br>> <br>> 1530 - Retry Trx<br>> <br>> 1531 - Communication Error<br>> <br>> 1540 - Setup Issue, contact Support<br>> <br>> 1541 - Device is not signature capable<br>> <br>> 1588 - Data could not be de-tokenized<br>> <br>> 1599 - Other Reason<br>> <br>> 1601 - Generic Decline<br>> <br>> 1602 - Call<br>> <br>> 1603 - No Reply<br>> <br>> 1604 - Pickup Card - No Fraud<br>> <br>> 1605 - Pickup Card - Fraud<br>> <br>> 1606 - Pickup Card - Lost<br>> <br>> 1607 - Pickup Card - Stolen<br>> <br>> 1608 - Account Error<br>> <br>> 1609 - Already Reversed<br>> <br>> 1610 - Bad PIN<br>> <br>> 1611 - Cashback Exceeded<br>> <br>> 1612 - Cashback Not Available<br>> <br>> 1613 - CID Error<br>> <br>> 1614 - Date Error<br>> <br>> 1615 - Do Not Honor<br>> <br>> 1616 - NSF<br>> <br>> 1618 - Invalid Service Code<br>> <br>> 1619 - Exceeded activity limit<br>> <br>> 1620 - Violation<br>> <br>> 1621 - Encryption Error<br>> <br>> 1622 - Card Expired<br>> <br>> 1623 - Renter<br>> <br>> 1624 - Security Violation<br>> <br>> 1625 - Card Not Permitted<br>> <br>> 1626 - Trans Not Permitted<br>> <br>> 1627 - System Error<br>> <br>> 1628 - Bad Merchant ID<br>> <br>> 1629 - Duplicate Batch (Already Closed)<br>> <br>> 1630 - Batch Rejected<br>> <br>> 1631 - Account Closed<br>> <br>> 1632 - PIN tries exceeded<br>> <br>> 1640 - Required fields are missing (ACH only)<br>> <br>> 1641 - Previously declined transaction (1640)<br>> <br>> 1650 - Contact Support<br>> <br>> 1651 - Max Sending - Throttle Limit Hit (ACH only)<br>> <br>> 1652 - Max Attempts Exceeded<br>> <br>> 1653 - Contact Support<br>> <br>> 1654 - Voided - Online Reversal Failed<br>> <br>> 1655 - Decline (AVS Auto Reversal)<br>> <br>> 1656 - Decline (CVV Auto Reversal)<br>> <br>> 1657 - Decline (Partial Auth Auto Reversal)<br>> <br>> 1658 - Expired Authorization<br>> <br>> 1659 - Declined - Partial Approval not Supported<br>> <br>> 1660 - Bank Account Error, please delete and re-add Token<br>> <br>> 1661 - Declined AuthIncrement<br>> <br>> 1662 - Auto Reversal - Processor can't settle<br>> <br>> 1663 - Manager Needed (Needs override transaction)<br>> <br>> 1664 - Token Not Found: Sharing Group Unavailable<br>> <br>> 1665 - Contact Not Found: Sharing Group Unavailable<br>> <br>> 1666 - Amount Error<br>> <br>> 1667 - Action Not Allowed in Current State<br>> <br>> 1668 - Original Authorization Not Valid<br>> <br>> 1701 - Chip Reject<br>> <br>> 1800 - Incorrect CVV<br>> <br>> 1801 - Duplicate Transaction<br>> <br>> 1802 - MID/TID Not Registered<br>> <br>> 1803 - Stop Recurring<br>> <br>> 1804 - No Transactions in Batch<br>> <br>> 1805 - Batch Does Not Exist<br><br>**ACH Reject Reason Codes**<br>\| Code \| E-Code \| Verbiage \| Short Description \| Long Description \|<br>\| ----------- \| ----------- \| ----------- \| ----------- \| ----------- \|<br>\| 2101 \| Rejected-R01 \|  \| Insufficient funds \| Available balance is not sufficient to cover the amount of the debit entry \|<br>\| 2102 \| Rejected-R02  \| E02 \| Bank account closed \| Previously active amount has been closed by the customer of RDFI \|<br>\| 2103 \| Rejected-R03 \| E03 \| No bank account/unable to locate account \| Account number does not correspond to the individual identified in the entry, or the account number designated is not an open account \|<br>\| 2104 \| Rejected-R04  \| E04 \| Invalid bank account number \| Account number structure is not valid \|<br>\| 2105 \| Rejected-R05  \| E05 \| Reserved \| Currently not in use \|<br>\| 2106 \| Rejected-R06 \|  \| Returned per ODFI request \| ODFI requested the RDFI to return the entry \|<br>\| 2107 \| Rejected-R07 \| E07 \| Authorization revoked by customer \| Receiver has revoked authorization \|<br>\| 2108 \| Rejected-R08 \| E08 \| Payment stopped \| Receiver of a recurring debit has stopped payment of an entry \|<br>\| 2109 \| Rejected-R09 \|  \| Uncollected funds \| Collected funds are not sufficient for payment of the debit entry \|<br>\| 2110 \| Rejected-R10 \| E10 \| Customer Advises Originator is Not Known to Receiver and/or Is Not Authorized by Receiver to Debit Receiver’s Account \| Receiver has advised RDFI that originator is not authorized to debit his bank account \|<br>\| 2111 \| Rejected-R11 \|  \| Customer Advises Entry Not In Accordance with the Terms of the Authorization \| To be used when there is an error in the authorization \|<br>\| 2112 \| Rejected-R12 \|  \| Branch sold to another RDFI \| RDFI unable to post entry destined for a bank account maintained at a branch sold to another financial institution \|<br>\| 2113 \| Rejected-R13 \|  \| RDFI not qualified to participate \| Financial institution does not receive commercial ACH entries \|<br>\| 2114 \| Rejected-R14 \| E14 \| Representative payee deceased or unable to continue in that capacity \| The representative payee authorized to accept entries on behalf of a beneficiary is either deceased or unable to continue in that capacity \|<br>\| 2115 \| Rejected-R15 \| E15 \| Beneficiary or bank account holder deceased \| (Other than representative payee) deceased* - (1) the beneficiary entitled to payments is deceased or (2) the bank account holder other than a representative payee is deceased \|<br>\| 2116 \| Rejected-R16 \| E16 \| Bank account frozen \| Funds in bank account are unavailable due to action by RDFI or legal order \|<br>\| 2117 \| Rejected-R17 \|  \| File record edit criteria \| Entry with Invalid Account Number Initiated Under Questionable Circumstances \|<br>\| 2118 \| Rejected-R18 \|  \| Improper effective entry date \| Entries have been presented prior to the first available processing window for the effective date. \|<br>\| 2119 \| Rejected-R19 \|  \| Amount field error \| Improper formatting of the amount field \|<br>\| 2120 \| Rejected-R20 \|  \| Non-payment bank account \| Entry destined for non-payment bank account defined by reg. \|<br>\| 2121 \| Rejected-R21 \|  \| Invalid company Identification \| The company ID information not valid (normally CIE entries) \|<br>\| 2122 \| Rejected-R22 \|  \| Invalid individual ID number \| Individual id used by receiver is incorrect (CIE entries) \|<br>\| 2123 \| Rejected-R23 \|  \| Credit entry refused by receiver \| Receiver returned entry because minimum or exact amount not remitted, bank account is subject to litigation, or payment represents an overpayment, originator is not known to receiver or receiver has not authorized this credit entry to this bank account \|<br>\| 2124 \| Rejected-R24 \|  \| Duplicate entry \| RDFI has received a duplicate entry \|<br>\| 2125 \| Rejected-R25 \|  \| Addenda error \| Improper formatting of the addenda record information \|<br>\| 2126 \| Rejected-R26 \|  \| Mandatory field error \| Improper information in one of the mandatory fields \|<br>\| 2127 \| Rejected-R27 \|  \| Trace number error \| Original entry trace number is not valid for return entry; or addenda trace numbers do not correspond with entry detail record \|<br>\| 2128 \| Rejected-R28 \|  \| Transit routing number check digit error \| Check digit for the transit routing number is incorrect \|<br>\| 2129 \| Rejected-R29 \| E29 \| Corporate customer advises not authorized \| RDFI has been notified by corporate receiver that debit entry of originator is not authorized \|<br>\| 2130 \| Rejected-R30 \|  \| RDFI not participant in check truncation program \| Financial institution not participating in automated check safekeeping application \|<br>\| 2131 \| Rejected-R31 \|  \| Permissible return entry (CCD and CTX only) \| RDFI has been notified by the ODFI that it agrees to accept a CCD or CTX return entry \|<br>\| 2132 \| Rejected-R32 \|  \| RDFI non-settlement \| RDFI is not able to settle the entry \|<br>\| 2133 \| Rejected-R33 \|  \| Return of XCK entry \| RDFI determines at its sole discretion to return an XCK entry; an XCK return entry may be initiated by midnight of the sixtieth day following the settlement date if the XCK entry \|<br>\| 2134 \| Rejected-R34 \|  \| Limited participation RDFI \| RDFI participation has been limited by a federal or state supervisor \|<br>\| 2135 \| Rejected-R35 \|  \| Return of improper debit entry \| ACH debit not permitted for use with the CIE standard entry class code (except for reversals) \|<br>\| 2136 \| Rejected-R36 \|  \| Return of Improper Credit Entry \|  \|<br>\| 2137 \| Rejected-R37 \|  \| Source Document Presented for Payment \|  \|<br>\| 2138 \| Rejected-R38 \|  \| Stop Payment on Source Document \|  \|<br>\| 2139 \| Rejected-R39 \|  \| Improper Source Document \|  \|<br>\| 2140 \| Rejected-R40 \|  \| Return of ENR Entry by Federal Government Agency \|  \|<br>\| 2141 \| Rejected-R41 \|  \| Invalid Transaction Code \|  \|<br>\| 2142 \| Rejected-R42 \|  \| Routing Number/Check Digit Error \|  \|<br>\| 2143 \| Rejected-R43 \|  \| Invalid DFI Account Number \|  \|<br>\| 2144 \| Rejected-R44 \|  \| Invalid Individual ID Number/Identification \|  \|<br>\| 2145 \| Rejected-R45 \|  \| Invalid Individual Name/Company Name \|  \|<br>\| 2146 \| Rejected-R46 \|  \| Invalid Representative Payee Indicator \|  \|<br>\| 2147 \| Rejected-R47 \|  \| Duplicate Enrollment \|  \|<br>\| 2150 \| Rejected-R50 \|  \| State Law Affecting RCK Acceptance \|  \|<br>\| 2151 \| Rejected-R51 \|  \| Item is Ineligible, Notice Not Provided, etc. \|  \|<br>\| 2152 \| Rejected-R52 \|  \| Stop Payment on Item (adjustment entries) \|  \|<br>\| 2153 \| Rejected-R53 \|  \| Item and ACH Entry Presented for Payment \|  \|<br>\| 2161 \| Rejected-R61 \|  \| Misrouted Return \|  \|<br>\| 2162 \| Rejected-R62 \|  \| Incorrect Trace Number \|  \|<br>\| 2163 \| Rejected-R63 \|  \| Incorrect Dollar Amount \|  \|<br>\| 2164 \| Rejected-R64 \|  \| Incorrect Individual Identification \|  \|<br>\| 2165 \| Rejected-R65 \|  \| Incorrect Transaction Code \|  \|<br>\| 2166 \| Rejected-R66 \|  \| Incorrect Company Identification \|  \|<br>\| 2167 \| Rejected-R67 \|  \| Duplicate Return \|  \|<br>\| 2168 \| Rejected-R68 \|  \| Untimely Return \|  \|<br>\| 2169 \| Rejected-R69 \|  \| Multiple Errors \|  \|<br>\| 2170 \| Rejected-R70 \|  \| Permissible Return Entry Not Accepted \|  \|<br>\| 2171 \| Rejected-R71 \|  \| Misrouted Dishonored Return \|  \|<br>\| 2172 \| Rejected-R72 \|  \| Untimely Dishonored Return \|  \|<br>\| 2173 \| Rejected-R73 \|  \| Timely Original Return \|  \|<br>\| 2174 \| Rejected-R74 \|  \| Corrected Return \|  \|<br>\| 2180 \| Rejected-R80 \|  \| Cross-Border Payment Coding Error \|  \|<br>\| 2181 \| Rejected-R81 \|  \| Non-Participant in Cross-Border Program \|  \|<br>\| 2182 \| Rejected-R82 \|  \| Invalid Foreign Receiving DFI Identification \|  \|<br>\| 2183 \| Rejected-R83 \|  \| Foreign Receiving DFI Unable to Settle \|  \|<br>\| 2200 \| Voided \|  \| Processor Void \| The transaction was voided by the processor before being sent to the bank \|<br>\| 2201 \| Rejected-C01 \|  \|  \|  \|<br>\| 2202 \| Rejected-C02 \|  \|  \|  \|<br>\| 2203 \| Rejected-C03 \|  \|  \|  \|<br>\| 2204 \| Rejected-C04 \|  \|  \|  \|<br>\| 2205 \| Rejected-C05 \|  \|  \|  \|<br>\| 2206 \| Rejected-C06 \|  \|  \|  \|<br>\| 2207 \| Rejected-C07 \|  \|  \|  \|<br>\| 2208 \| Rejected-C08 \|  \|  \|  \|<br>\| 2209 \| Rejected-C09 \|  \|  \|  \|<br>\| 2210 \| Rejected-C10 \|  \|  \|  \|<br>\| 2211 \| Rejected-C11 \|  \|  \|  \|<br>\| 2212 \| Rejected-C12 \|  \|  \|  \|<br>\| 2213 \| Rejected-C13 \|  \|  \|  \|<br>\| 2261 \| Rejected-C61 \|  \|  \|  \|<br>\| 2262 \| Rejected-C62 \|  \|  \|  \|<br>\| 2263 \| Rejected-C63 \|  \|  \|  \|<br>\| 2264 \| Rejected-C64 \|  \|  \|  \|<br>\| 2265 \| Rejected-C65 \|  \|  \|  \|<br>\| 2266 \| Rejected-C66 \|  \|  \|  \|<br>\| 2267 \| Rejected-C67 \|  \|  \|  \|<br>\| 2268 \| Rejected-C68 \|  \|  \|  \|<br>\| 2269 \| Rejected-C69 \|  \|  \|  \|<br>\| 2301 \| Rejected-X01 \|  \| Misc Check 21 Return \|  \|<br>\| 2304 \| Rejected-X04 \|  \| Invalid Image \|  \|<br>\| 2305 \| Rejected-X05 \| E95 \| Breach of Warranty \|  \|<br>\| 2306 \| Rejected-X06 \| E96 \| Counterfeit / Forgery \|  \|<br>\| 2307 \| Rejected-X07 \| E97 \| Refer to Maker \|  \|<br>\| 2308 \| Rejected-X08 \|  \| Maximum Payment Attempts \|  \|<br>\| 2309 \| Rejected-X09 \|  \| Item Cannot be Re-presented \|  \|<br>\| 2310 \| Rejected-X10 \|  \| Not Our Item \|  \|<br>\| 2321 \| Rejected-X21 \|  \| Pay None \|  \|<br>\| 2322 \| Rejected-X22 \|  \| Pay All \|  \|<br>\| 2323 \| Rejected-X23 \| E93 \| Non-Negotiable \|  \|<br>\| 2329 \| Rejected-X29 \|  \| Stale Dated \|  \|<br>\| 2345 \| Rejected-X45 \|  \| Misc Return \|  \|<br>\| 2371 \| Rejected-X71 \|  \| RCK - 2nd Time \|  \|<br>\| 2372 \| Rejected-X72 \|  \| RCK Reject - ACH \|  \|<br>\| 2373 \| Rejected-X73 \|  \| RCK Reject - Payer \|  \| |
| `RecurringId` | `string` | Optional | A unique identifer used to associate a transaction with a Recurring.<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `SettleDate` | `string` | Optional | Settle date<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `StatusCode` | [`StatusCode17Enum?`](../../doc/models/status-code-17-enum.md) | Optional | Status ID - See status id section for more detail<br><br>> 101 - Sale cc Approved<br>> <br>> 102 - Sale cc AuthOnly<br>> <br>> 111 - Refund cc Refunded<br>> <br>> 121 - Credit/Debit/Refund cc AvsOnly<br>> <br>> 131 - Credit/Debit/Refund ach Pending Origination<br>> <br>> 132 - Credit/Debit/Refund ach Originating<br>> <br>> 133 - Credit/Debit/Refund ach Originated<br>> <br>> 134 - Credit/Debit/Refund ach Settled<br>> <br>> 191 - Settled (depracated - batches are now settled on the /v2/transactionbatches endpoint)<br>> <br>> 201 - All cc/ach Voided<br>> <br>> 301 - All cc/ach Declined<br>> <br>> 331 - Credit/Debit/Refund ach Charged Back |
| `TransactionBatchId` | `string` | Optional | For cc transactions, this is the id of the batch the transaction belongs to (not to be confused with batch number). This will be null for transactions that do not settle (void and authonly).<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `TypeId` | [`TypeIdEnum?`](../../doc/models/type-id-enum.md) | Optional | Type ID - See type id section for more detail |
| `Verbiage` | `string` | Optional | Verbiage -Do not use verbiage to see if the transaction was approved, use status_id |
| `VoidDate` | `string` | Optional | void date<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `Batch` | `string` | Optional | Batch |
| `TermsAgree` | `bool?` | Optional | Terms Agreement |
| `ResponseMessage` | `string` | Optional | Response Message<br>**Constraints**: *Maximum Length*: `255` |
| `ReturnDate` | `string` | Optional | Return Date<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `TrxSourceId` | [`TrxSourceIdEnum?`](../../doc/models/trx-source-id-enum.md) | Optional | How the transaction was obtained by the API.<br><br>> 1 - Unknown - The origination of this transaction could not be determined.<br>> <br>> 2 - Mobile - The origination of this transaction is through the mobile application. This is always a merchant submitted payment.<br>> <br>> 3 - Web - The origination of this transaction is through a web browser. This is always a merchant submitted payment. Examples include Virtual Terminal, Contact Charge, and Transaction Details - Run Again pages.<br>> <br>> 4 - IVR Transaction - The origination of this transaction is over the phone. This payment is submitted by an automated system initiated by the cardholder.<br>> <br>> 5 - Contact Statement - The orignation of this transaction is through a Vericle statement.<br>> <br>> 6 - Contact Payment Mobile - The origination of this transaction is through the mobile application. This is always submitted by a contact user.<br>> <br>> 7 - Contact Payment - The origination of this transaction is through a web browser. This is always submitted by a contact user.<br>> <br>> 8 - Quick Invoice - The orignation of this transaction is through a Quick Invoice. This is typically submitted by a contact user, however the transaction can also be submitted by a merchant.<br>> <br>> 9 - Payform - The origination of this transaction is through a Payform. This is typically a merchant submitted transaction, and is always from an internal developer.<br>> <br>> 10 - Hosted Payment Page - The orignation of this transaction is through a Hosted Payment Page. This is typically a cardholder submitted transaction.<br>> <br>> 11 - Emulator -  The origination of this transaction is through Auth.Net emulator. This is typically submitted through an integration to a website or a shopping cart.<br>> <br>> 12 - Integration - The orignation of this transaction is through an integrated solution. This will always be from an external developer.<br>> <br>> 13 - Recurring Billing - The orignation of this transaction is through a scheduled recurring payment. This payment is system-initiated based on a payment schedule that has been configured.<br>> <br>> 14 - Recurring Secondary - This feature has not been implented yet.<br>> <br>> 15 - Declined Recurring Email - The orignation of this transaction is through the email notification sent when a recurring payment has been declined. This is typically submitted by a cardholder.<br>> <br>> 16 - Paylink - The orignation of this transaction is through a Paylink. This is typically submitted by a contact user, however the transaction can also be submitted by a merchant.<br>> <br>> 17 - Elements - The origination of this transaction is through the Elements payments page. This can be a cardholder submitted or a merchant submitted transaction.<br>> <br>> 18 - ACH Import - The origination of this transaction is through an ACH file import. This is a merchant initiated process. |
| `RoutingNumber` | `string` | Optional | This field is read only for ach on transactions. Must be supplied if account_vault_id is not provided. |
| `TrxSourceCode` | [`TrxSourceCodeEnum?`](../../doc/models/trx-source-code-enum.md) | Optional | How the transaction was obtained by the API.<br><br>> 1 - Unknown - The origination of this transaction could not be determined.<br>> <br>> 2 - Mobile - The origination of this transaction is through the mobile application. This is always a merchant submitted payment.<br>> <br>> 3 - Web - The origination of this transaction is through a web browser. This is always a merchant submitted payment. Examples include Virtual Terminal, Contact Charge, and Transaction Details - Run Again pages.<br>> <br>> 4 - IVR Transaction - The origination of this transaction is over the phone. This payment is submitted by an automated system initiated by the cardholder.<br>> <br>> 5 - Contact Statement - The orignation of this transaction is through a Vericle statement.<br>> <br>> 6 - Contact Payment Mobile - The origination of this transaction is through the mobile application. This is always submitted by a contact user.<br>> <br>> 7 - Contact Payment - The origination of this transaction is through a web browser. This is always submitted by a contact user.<br>> <br>> 8 - Quick Invoice - The orignation of this transaction is through a Quick Invoice. This is typically submitted by a contact user, however the transaction can also be submitted by a merchant.<br>> <br>> 9 - Payform - The origination of this transaction is through a Payform. This is typically a merchant submitted transaction, and is always from an internal developer.<br>> <br>> 10 - Hosted Payment Page - The orignation of this transaction is through a Hosted Payment Page. This is typically a cardholder submitted transaction.<br>> <br>> 11 - Emulator -  The origination of this transaction is through Auth.Net emulator. This is typically submitted through an integration to a website or a shopping cart.<br>> <br>> 12 - Integration - The orignation of this transaction is through an integrated solution. This will always be from an external developer.<br>> <br>> 13 - Recurring Billing - The orignation of this transaction is through a scheduled recurring payment. This payment is system-initiated based on a payment schedule that has been configured.<br>> <br>> 14 - Recurring Secondary - This feature has not been implented yet.<br>> <br>> 15 - Declined Recurring Email - The orignation of this transaction is through the email notification sent when a recurring payment has been declined. This is typically submitted by a cardholder.<br>> <br>> 16 - Paylink - The orignation of this transaction is through a Paylink. This is typically submitted by a contact user, however the transaction can also be submitted by a merchant.<br>> <br>> 17 - Elements - The origination of this transaction is through the Elements payments page. This can be a cardholder submitted or a merchant submitted transaction.<br>> <br>> 18 - ACH Import - The origination of this transaction is through an ACH file import. This is a merchant initiated process. |
| `PaylinkId` | `string` | Optional | Paylink Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CurrencyCode` | `double?` | Optional | Currency Code<br>**Default**: `840` |
| `IsAccountvault` | `bool?` | Optional | Is Token Transaction |
| `CreatedUserId` | `string` | Optional | User ID Created the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ModifiedUserId` | `string` | Required | Last User ID that updated the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `TransactionCode` | `string` | Optional | Transaction Code |
| `EffectiveDate` | `string` | Optional | For ACH only, this is optional and defaults to current day.<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `NotificationPhone` | `string` | Optional | Notification Phone |
| `CavvResult` | `string` | Optional | Cavv Result |
| `RecurringFlag` | `string` | Optional | Recurring Flag |
| `IsToken` | `bool?` | Optional | Is Token Transaction |
| `InstallmentTotal` | `int?` | Optional | Installment Total<br>**Constraints**: `>= 1`, `<= 999` |
| `InstallmentCounter` | `int?` | Optional | Installment Counter<br>**Constraints**: `>= 1`, `<= 999` |
| `AccountVaultId` | `string` | Optional | Token ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `HostedPaymentPageId` | `string` | Required | Hosted Payment Page Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Stan` | `string` | Optional | - |
| `Currency` | `string` | Optional | Currency |
| `CardBin` | `string` | Optional | Card Bin |
| `AccountVault` | [`AccountVault`](../../doc/models/account-vault.md) | Optional | Token Information on `expand` |
| `QuickInvoice` | [`QuickInvoice`](../../doc/models/quick-invoice.md) | Optional | Quick Invoice Information on `expand` |
| `LogEmails` | [`List<LogEmail>`](../../doc/models/log-email.md) | Optional | Log Email Information on `expand` |
| `IsVoidable` | `bool?` | Optional | Is Voidable Information on `expand` |
| `IsReversible` | `bool?` | Optional | Is Reversible Information on `expand` |
| `IsRefundable` | `bool?` | Optional | Is Refundable Information on `expand` |
| `IsCompletable` | `bool?` | Optional | Is Competable Information on `expand` |
| `IsSettled` | `bool?` | Optional | Is Settled Information on `expand` |
| `CreatedUser` | [`CreatedUser`](../../doc/models/created-user.md) | Optional | User Information on `expand` |
| `Location` | [`Location`](../../doc/models/location.md) | Optional | Location Information on `expand` |
| `Contact` | [`Contact1`](../../doc/models/contact-1.md) | Optional | Contact Information on `expand` |
| `Changelogs` | [`List<Changelog>`](../../doc/models/changelog.md) | Optional | Changelog Information on `expand` |
| `ProductTransaction` | [`ProductTransaction`](../../doc/models/product-transaction.md) | Optional | Product Transaction Information on `expand` |
| `AllTags` | [`List<AllTag>`](../../doc/models/all-tag.md) | Optional | All Tag Information on `expand` |
| `TagTransactions` | [`List<TagTransaction>`](../../doc/models/tag-transaction.md) | Optional | TagTransaction Information on `expand` |
| `DeclinedRecurringNotification` | [`DeclinedRecurringNotification`](../../doc/models/declined-recurring-notification.md) | Optional | Declined Recurring Notification Information on `expand` |
| `PaymentRecurringNotification` | [`PaymentRecurringNotification`](../../doc/models/payment-recurring-notification.md) | Optional | Payment Recurring Notification Information on `expand` |
| `DeveloperCompany` | [`DeveloperCompany`](../../doc/models/developer-company.md) | Optional | Developer Company Information on `expand` |
| `Terminal` | [`Terminal`](../../doc/models/terminal.md) | Optional | Terminal Information on `expand` |
| `HostedPaymentPage` | [`HostedPaymentPage`](../../doc/models/hosted-payment-page.md) | Optional | Hosted Payment Page Information on `expand` |
| `TransactionLevel3` | [`TransactionLevel3`](../../doc/models/transaction-level-3.md) | Optional | Transaction Level3 Information on `expand` |
| `DeveloperCompanyId` | `string` | Optional | Developer Company Id Information on `expand` |
| `TransactionHistories` | [`List<TransactionHistory>`](../../doc/models/transaction-history.md) | Optional | Transaction History Information on `expand` |
| `SurchargeTransaction` | [`SurchargeTransaction`](../../doc/models/surcharge-transaction.md) | Optional | Surcharge Transaction Information on `expand` |
| `Surcharge` | [`Surcharge`](../../doc/models/surcharge.md) | Optional | Surcharge Information on `expand` |
| `Signature` | [`Signature`](../../doc/models/signature.md) | Optional | Signature Information on `expand` |
| `ReasonCode` | [`ReasonCode`](../../doc/models/reason-code.md) | Optional | Reason Code Information on `expand` |
| `Type` | [`Type6`](../../doc/models/type-6.md) | Optional | Type Information on `expand` |
| `Status` | [`Status11`](../../doc/models/status-11.md) | Optional | Status Information on `expand` |
| `TransactionBatch` | [`TransactionBatch`](../../doc/models/transaction-batch.md) | Optional | Transaction Batch Information on `expand` |
| `TransactionSplits` | [`List<TransactionSplit>`](../../doc/models/transaction-split.md) | Optional | Transaction Split Information on `expand` |
| `PostbackLogs` | [`List<PostbackLog>`](../../doc/models/postback-log.md) | Optional | Postback Log Information on `expand` |
| `CurrencyType` | [`CurrencyType`](../../doc/models/currency-type.md) | Optional | Currency Type Information on `expand` |
| `TransactionReferences` | [`List<TransactionReference>`](../../doc/models/transaction-reference.md) | Optional | Transaction Reference Information on `expand` |

## Example (as JSON)

```json
{
  "checkin_date": "2021-12-01",
  "checkout_date": "2021-12-01",
  "clerk_number": "AE1234",
  "contact_id": "11e95f8ec39de8fbdb0a4f1a",
  "custom_data": {
    "data1": "custom1",
    "data2": "custom2"
  },
  "customer_id": "customerid",
  "description": "some description",
  "iias_ind": 1,
  "image_front": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
  "image_back": "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
  "installment": true,
  "installment_number": 1,
  "installment_count": 1,
  "location_api_id": "location-api-id-florida-2",
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
  "advance_deposit": false,
  "no_show": false,
  "notification_email_address": "johnsmith@smiths.com",
  "order_number": "433659378839",
  "po_number": "555555553123",
  "quick_invoice_id": "11e95f8ec39de8fbdb0a4f1a",
  "recurring_number": 1,
  "room_num": "303",
  "room_rate": 95,
  "save_account": false,
  "save_account_title": "John Account",
  "subtotal_amount": 599,
  "surcharge_amount": 100,
  "tax": 0,
  "tip_amount": 0,
  "transaction_amount": 0,
  "secondary_amount": 0,
  "transaction_api_id": "transaction-payment-abcd123",
  "transaction_c1": "custom-data-1",
  "transaction_c2": "custom-data-2",
  "transaction_c3": "custom-data-3",
  "bank_funded_only_override": false,
  "allow_partial_authorization_override": false,
  "auto_decline_cvv_override": false,
  "auto_decline_street_override": false,
  "auto_decline_zip_override": false,
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "terminal_id": "11e95f8ec39de8fbdb0a4f1a",
  "account_holder_name": "smith",
  "account_type": "checking",
  "token_id": "11e95f8ec39de8fbdb0a4f1a",
  "ach_identifier": "P",
  "ach_sec_code": "C21",
  "auth_amount": 1,
  "auth_code": "BR349K",
  "avs": "BAD",
  "avs_enhanced": "N",
  "cardholder_present": true,
  "card_present": true,
  "check_number": "8520748520963",
  "customer_ip": "192.168.0.10",
  "cvv_response": "N",
  "entry_mode_id": "C",
  "first_six": "545454",
  "last_four": "5454",
  "payment_method": "cc",
  "terminal_serial_number": "1234567890",
  "charge_back_date": "2021-12-01",
  "is_recurring": true,
  "notification_email_sent": true,
  "par": "Q1J4Z28RKA1EBL470G9XYG90R5D3E",
  "reason_code_id": 1000,
  "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
  "settle_date": "2021-12-01",
  "status_code": 101,
  "transaction_batch_id": "11e95f8ec39de8fbdb0a4f1a",
  "verbiage": "APPROVED",
  "void_date": "2021-12-01",
  "batch": "2",
  "terms_agree": true,
  "return_date": "2021-12-01",
  "trx_source_id": 8,
  "routing_number": "051904524",
  "trx_source_code": 8,
  "paylink_id": "11e95f8ec39de8fbdb0a4f1a",
  "currency_code": 840,
  "is_accountvault": true,
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "effective_date": "2021-12-01",
  "is_token": true,
  "installment_total": 1,
  "installment_counter": 1,
  "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
  "hosted_payment_page_id": "11e95f8ec39de8fbdb0a4f1a",
  "is_voidable": true,
  "is_reversible": true,
  "is_refundable": true,
  "is_completable": true,
  "is_settled": true,
  "developer_company_id": "Sample Developer Company ID",
  "additional_amounts": [
    {
      "type": "cashback",
      "amount": 6,
      "account_type": "cash_benefit",
      "currency": 154.64
    },
    {
      "type": "cashback",
      "amount": 6,
      "account_type": "cash_benefit",
      "currency": 154.64
    }
  ],
  "billing_address": {
    "postal_code": "postal_code0",
    "street": "street8",
    "city": "city2",
    "state": "state6",
    "phone": "phone2"
  }
}
```

