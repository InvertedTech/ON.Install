
# Product Transaction

Product Transaction Information on `expand`

## Structure

`ProductTransaction`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ProcessorVersion` | `string` | Optional | Processor Version |
| `IndustryType` | [`IndustryTypeEnum?`](../../doc/models/industry-type-enum.md) | Optional | Industry Type<br>**Constraints**: *Maximum Length*: `45` |
| `Title` | `string` | Required | Title<br>**Constraints**: *Maximum Length*: `64` |
| `PaymentMethod` | [`PaymentMethodEnum`](../../doc/models/payment-method-enum.md) | Required | Payment method |
| `Processor` | [`ProcessorEnum?`](../../doc/models/processor-enum.md) | Optional | Processor |
| `Mcc` | `string` | Optional | MCC<br>**Constraints**: *Maximum Length*: `4`, *Pattern*: `^\d+$` |
| `TaxSurchargeConfig` | [`TaxSurchargeConfigEnum?`](../../doc/models/tax-surcharge-config-enum.md) | Optional | Tax Surcharge Config<br>**Default**: `TaxSurchargeConfigEnum.Enum_2` |
| `TerminalId` | `string` | Optional | Terminal ID<br>**Constraints**: *Maximum Length*: `24` |
| `Partner` | [`PartnerEnum?`](../../doc/models/partner-enum.md) | Optional | Partner<br>**Constraints**: *Maximum Length*: `24` |
| `ProductAchPvStoreId` | `string` | Optional | Product Ach Pv Store ID |
| `InvoiceAdjustmentTitle` | `string` | Optional | Invoice Adjustment Title |
| `LocationId` | `string` | Required | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `LocationApiId` | `string` | Optional | Location Api ID |
| `BillingLocationApiId` | `string` | Optional | Billing Location API ID |
| `PortfolioId` | `string` | Optional | Portfolio ID |
| `PortfolioValidationRule` | `string` | Optional | Product Validation Rule |
| `SubProcessor` | `string` | Optional | Sub Processor<br>**Constraints**: *Maximum Length*: `48` |
| `Surcharge` | `object` | Optional | Surcharge |
| `ProcessorData` | `object` | Optional | - |
| `VtClerkNumber` | `bool?` | Optional | Vt Clerk Number |
| `VtBillingPhone` | `bool?` | Optional | Card Type JCB |
| `VtEnableTip` | `bool?` | Optional | VT Enable Tip |
| `AchAllowDebit` | `bool?` | Optional | Ach Allow Debit |
| `AchAllowCredit` | `bool?` | Optional | Ach Allow Credit |
| `AchAllowRefund` | `bool?` | Optional | Ach Allow Refund |
| `VtCvv` | `bool?` | Optional | VT CVV |
| `VtStreet` | `bool?` | Optional | VT Street |
| `VtZip` | `bool?` | Optional | VT Zip |
| `VtOrderNum` | `bool?` | Optional | VT Order Num |
| `VtEnable` | `bool?` | Optional | VT Enable |
| `ReceiptShowContactName` | `bool?` | Optional | Receipt Show Contact Name |
| `DisplayAvs` | `bool?` | Optional | Display Avs |
| `CardTypeVisa` | `bool?` | Optional | Card Type Visa |
| `CardTypeMc` | `bool?` | Optional | Card Type Mc |
| `CardTypeDisc` | `bool?` | Optional | Card Type Disc |
| `CardTypeAmex` | `bool?` | Optional | Card Type Amex |
| `CardTypeDiners` | `bool?` | Optional | Card Type Dinners |
| `CardTypeJcb` | `bool?` | Optional | - |
| `InvoiceLocation` | `bool?` | Optional | Invoice Location |
| `AllowPartialAuthorization` | `bool?` | Optional | Allow Partial Authorization |
| `AllowRecurringPartialAuthorization` | `bool?` | Optional | Allow Recurring Partial Authorization |
| `AutoDeclineCvv` | `bool?` | Optional | Auto Decline Cvv |
| `AutoDeclineStreet` | `bool?` | Optional | Auto Decline Street |
| `AutoDeclineZip` | `bool?` | Optional | Auto Decline ZIP |
| `SplitPaymentsAllow` | `bool?` | Optional | Split Payments Allow |
| `VtShowCustomFields` | `bool?` | Optional | Vt Show Custom Fields |
| `ReceiptShowCustomFields` | `bool?` | Optional | Receipt Show Custom Fields |
| `VtOverrideSalesTaxAllowed` | `bool?` | Optional | Vt Override Sales Tax Allowed |
| `VtEnableSalesTax` | `bool?` | Optional | Vt Enable Sales Tax |
| `VtRequireZip` | `bool?` | Optional | Vt Require ZIP |
| `VtRequireStreet` | `bool?` | Optional | Vt Require Street |
| `AutoDeclineCavv` | `bool?` | Optional | Auto Decline Cavv |
| `MerchantId` | `string` | Optional | Merchant ID<br>**Constraints**: *Maximum Length*: `24` |
| `ReceiptHeader` | `string` | Optional | Receipt Header<br>**Constraints**: *Maximum Length*: `255` |
| `ReceiptFooter` | `string` | Optional | Receipt Footer<br>**Constraints**: *Maximum Length*: `255` |
| `ReceiptAddAccountAboveSignature` | `string` | Optional | Receipt Add Account Above Signature<br>**Constraints**: *Maximum Length*: `1032` |
| `ReceiptAddRecurringAboveSignature` | `string` | Optional | Receipt Add Recurring Above Signature<br>**Constraints**: *Maximum Length*: `1032` |
| `ReceiptVtAboveSignature` | `string` | Optional | Receipt VT Above Signature<br>**Constraints**: *Maximum Length*: `1032` |
| `DefaultTransactionType` | [`DefaultTransactionTypeEnum?`](../../doc/models/default-transaction-type-enum.md) | Optional | Default Transaction Type |
| `Username` | `string` | Optional | Username<br>**Constraints**: *Maximum Length*: `512` |
| `Password` | `string` | Optional | Passowrd<br>**Constraints**: *Maximum Length*: `512` |
| `CurrentBatch` | `double?` | Optional | Current Batch<br>**Default**: `1`<br>**Constraints**: `>= 1`, `<= 9999` |
| `DupCheckPerBatch` | `string` | Optional | Dup Check Per Batch<br>**Constraints**: *Maximum Length*: `500` |
| `AgentCode` | `string` | Optional | Agent Code<br>**Constraints**: *Maximum Length*: `16`, *Pattern*: `^[\w\-]+$` |
| `PaylinkAllow` | `bool?` | Optional | Paylink Allow |
| `QuickInvoiceAllow` | `bool?` | Optional | Quick Invoice Allow |
| `Level3Allow` | `bool?` | Optional | Level3 Allow |
| `PayfacEnable` | `bool?` | Optional | Payfac Enable |
| `SalesOfficeId` | `string` | Optional | Sales Office ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `HostedPaymentPageMaxAllowed` | `double?` | Optional | Hosted Payment Page Max Allowed<br>**Default**: `5`<br>**Constraints**: `>= 1`, `<= 999` |
| `HostedPaymentPageAllow` | `bool?` | Optional | Hosted Payment Page Allow |
| `SurchargeId` | `string` | Optional | Surcharge ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Level3Default` | `object` | Optional | Level3 Default |
| `CauSubscribeTypeId` | [`CauSubscribeTypeIdEnum?`](../../doc/models/cau-subscribe-type-id-enum.md) | Optional | Cau Subscribe Type ID |
| `CauAccountNumber` | `string` | Optional | Cau Account Number<br>**Constraints**: *Minimum Length*: `32`, *Maximum Length*: `32`, *Pattern*: `^[a-zA-Z0-9\-]+$` |
| `LocationBillingAccountId` | `string` | Optional | Location Billing Account ID |
| `ProductBillingGroupId` | `string` | Optional | Product Billing Group ID |
| `AccountNumber` | `string` | Optional | Account number<br>**Constraints**: *Maximum Length*: `32`, *Pattern*: `^[a-zA-Z0-9\-_]+$` |
| `RunAvsOnAccountvaultCreate` | `bool?` | Optional | Run Avs On Accountvault Create |
| `AccountvaultExpireNotificationEmailEnable` | `bool?` | Optional | Accountvault Expire Notification Email Enable |
| `DebitAllowVoid` | `bool?` | Optional | Debit Allow Void |
| `QuickInvoiceTextToPay` | `bool?` | Optional | Quick Invoice Text To Pay |
| `AuthenticationCode` | `string` | Optional | Authentication Code |
| `SmsEnable` | `bool?` | Optional | SMS Enable |
| `VtShowCurrency` | `bool?` | Optional | Vt Show Currency |
| `ReceiptShowCurrency` | `bool?` | Optional | Receipt Show Currency |
| `AllowBlindRefund` | `bool?` | Optional | Allow Blind Refund |
| `VtShowCompanyName` | `bool?` | Optional | Vt Show Company Name |
| `ReceiptShowCompanyName` | `bool?` | Optional | Receipt Show Company Name |
| `BankFundedOnly` | `bool?` | Optional | Bank Funded Only |
| `RequireCvvOnKeyedCnp` | `bool?` | Optional | Require CVV on keyed CNP |
| `RequireCvvOnTokenizedCnp` | `bool?` | Optional | Require CVV on tokenized CNP |
| `ShowSecondaryAmount` | `bool?` | Optional | Show Retained Amount |
| `AllowSecondaryAmount` | `bool?` | Optional | Allow Retained Amount |
| `ShowGooglePay` | `bool?` | Optional | Vt Require Street |
| `ShowApplePay` | `bool?` | Optional | Vt Require Street |
| `Id` | `string` | Required | User Reports ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ReceiptLogo` | `string` | Optional | Receipt Logo |
| `Active` | `bool?` | Optional | Active |
| `Tz` | `string` | Optional | TZ |
| `CurrencyCode` | `double?` | Optional | Currency Code<br>**Default**: `840` |
| `CurrentStan` | `double?` | Optional | Current Stan<br>**Default**: `1` |
| `CreatedTs` | `int?` | Optional | Created Time Stamp |
| `ModifiedTs` | `int?` | Optional | Modified Time Stamp |
| `CreatedUserId` | `string` | Optional | User ID Created the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ModifiedUserId` | `string` | Optional | Last User ID that updated the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ProductTransactionApiId` | `string` | Optional | Product Transaction API ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `TransactionAmountNotificationThreshold` | `int?` | Optional | Transaction Amount Notification Treshold |
| `IsSecondaryAmountAllowed` | `bool?` | Optional | Allow Retained Amount |
| `BatchRiskConfig` | `object` | Optional | Batch Risk Config |
| `FortisId` | `string` | Optional | - |
| `ProductBillingGroupCode` | `string` | Optional | Product Billing Group Code |
| `CauSubscribeTypeCode` | [`CauSubscribeTypeCodeEnum?`](../../doc/models/cau-subscribe-type-code-enum.md) | Optional | Cau Subscribe Type Code |
| `MerchantCode` | `string` | Optional | Merchant Code<br>**Constraints**: *Maximum Length*: `24` |

## Example (as JSON)

```json
{
  "processor_version": "1_0_0",
  "title": "My terminal",
  "payment_method": "cc",
  "processor": "zgate",
  "mcc": "1111",
  "tax_surcharge_config": 2,
  "partner": "standalone",
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "vt_clerk_number": true,
  "vt_billing_phone": true,
  "vt_enable_tip": true,
  "ach_allow_debit": true,
  "ach_allow_credit": true,
  "ach_allow_refund": true,
  "vt_cvv": true,
  "vt_street": true,
  "vt_zip": true,
  "vt_order_num": true,
  "vt_enable": true,
  "receipt_show_contact_name": true,
  "display_avs": true,
  "card_type_visa": true,
  "card_type_mc": true,
  "card_type_disc": true,
  "card_type_amex": true,
  "card_type_diners": true,
  "card_type_jcb": true,
  "invoice_location": true,
  "allow_partial_authorization": true,
  "allow_recurring_partial_authorization": true,
  "auto_decline_cvv": true,
  "auto_decline_street": true,
  "auto_decline_zip": true,
  "split_payments_allow": true,
  "vt_show_custom_fields": true,
  "receipt_show_custom_fields": true,
  "vt_override_sales_tax_allowed": true,
  "vt_enable_sales_tax": true,
  "vt_require_zip": true,
  "vt_require_street": true,
  "auto_decline_cavv": true,
  "current_batch": 34,
  "paylink_allow": false,
  "quick_invoice_allow": false,
  "level3_allow": false,
  "payfac_enable": false,
  "sales_office_id": "11e95f8ec39de8fbdb0a4f1a",
  "hosted_payment_page_max_allowed": 5,
  "hosted_payment_page_allow": false,
  "surcharge_id": "11e95f8ec39de8fbdb0a4f1a",
  "level3_default": {},
  "cau_subscribe_type_id": 0,
  "location_billing_account_id": "11eb88b873980c64a21e5fd2",
  "product_billing_group_id": "nofees",
  "account_number": "12345678",
  "run_avs_on_accountvault_create": false,
  "accountvault_expire_notification_email_enable": false,
  "debit_allow_void": false,
  "quick_invoice_text_to_pay": false,
  "sms_enable": false,
  "vt_show_currency": true,
  "receipt_show_currency": false,
  "allow_blind_refund": false,
  "vt_show_company_name": false,
  "receipt_show_company_name": false,
  "bank_funded_only": false,
  "require_cvv_on_keyed_cnp": true,
  "require_cvv_on_tokenized_cnp": true,
  "show_secondary_amount": false,
  "allow_secondary_amount": false,
  "show_google_pay": true,
  "show_apple_pay": true,
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "active": true,
  "currency_code": 840,
  "current_stan": 1,
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "product_transaction_api_id": "11e95f8ec39de8fbdb0a4f1a",
  "is_secondary_amount_allowed": false,
  "fortis_id": "8149742",
  "product_billing_group_code": "nofees",
  "cau_subscribe_type_code": 0,
  "industry_type": "retail"
}
```

