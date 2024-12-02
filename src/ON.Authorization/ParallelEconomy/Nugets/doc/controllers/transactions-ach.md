# Transactions-ACH

```csharp
TransactionsACHController transactionsACHController = client.TransactionsACHController;
```

## Class Name

`TransactionsACHController`

## Methods

* [ACH Credit](../../doc/controllers/transactions-ach.md#ach-credit)
* [ACH Credit - Previous Transaction](../../doc/controllers/transactions-ach.md#ach-credit---previous-transaction)
* [ACH Credit - Tokenized](../../doc/controllers/transactions-ach.md#ach-credit---tokenized)
* [ACH Debit](../../doc/controllers/transactions-ach.md#ach-debit)
* [ACH Debit - Previous Transaction](../../doc/controllers/transactions-ach.md#ach-debit---previous-transaction)
* [ACH Debit - Tokenized](../../doc/controllers/transactions-ach.md#ach-debit---tokenized)
* [ACH Refund - Previous Transaction](../../doc/controllers/transactions-ach.md#ach-refund---previous-transaction)


# ACH Credit

Create a new keyed ACH credit transaction

```csharp
ACHCreditAsync(
    Models.V1TransactionsAchCreditKeyedRequest body,
    List<Models.Expand54Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1TransactionsAchCreditKeyedRequest`](../../doc/models/v1-transactions-ach-credit-keyed-request.md) | Body, Required | - |
| `expand` | [`List<Expand54Enum>`](../../doc/models/expand-54-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
V1TransactionsAchCreditKeyedRequest body = new V1TransactionsAchCreditKeyedRequest
{
    TransactionAmount = 1,
    AccountHolderName = "smith",
    AccountNumber = "24345",
    AccountType = AccountType11Enum.Checking,
    RoutingNumber = "051904524",
    CheckinDate = "2021-12-01",
    CheckoutDate = "2021-12-01",
    ClerkNumber = "AE1234",
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    CustomData = ApiHelper.JsonDeserialize<object>("{\"data1\":\"custom1\",\"data2\":\"custom2\"}"),
    CustomerId = "customerid",
    Description = "some description",
    IiasInd = IiasIndEnum.Enum1,
    ImageFront = "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    ImageBack = "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    Installment = true,
    InstallmentNumber = 1,
    InstallmentCount = 1,
    LocationApiId = "location-api-id-florida-2",
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    AdvanceDeposit = false,
    NoShow = false,
    NotificationEmailAddress = "johnsmith@smiths.com",
    OrderNumber = "433659378839",
    PoNumber = "555555553123",
    QuickInvoiceId = "11e95f8ec39de8fbdb0a4f1a",
    Recurring = false,
    RecurringNumber = 1,
    RoomNum = "303",
    RoomRate = 95,
    SaveAccount = false,
    SaveAccountTitle = "John Account",
    SubtotalAmount = 599,
    SurchargeAmount = 100,
    Tax = 0,
    TipAmount = 0,
    SecondaryAmount = 0,
    TransactionApiId = "transaction-payment-abcd123",
    TransactionC1 = "custom-data-1",
    TransactionC2 = "custom-data-2",
    TransactionC3 = "custom-data-3",
    BankFundedOnlyOverride = false,
    AllowPartialAuthorizationOverride = false,
    AutoDeclineCvvOverride = false,
    AutoDeclineStreetOverride = false,
    AutoDeclineZipOverride = false,
    AchIdentifier = "P",
    AchSecCode = AchSecCode1Enum.C21,
    EffectiveDate = "2021-12-01",
    CheckNumber = "8520748520963",
};

try
{
    ResponseTransaction result = await transactionsACHController.ACHCreditAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Example Response *(as JSON)*

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": 10,
        "account_type": "credit",
        "currency": 840
      }
    ],
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "phone": "3339998822",
      "country": "USA"
    },
    "checkin_date": "2021-12-01",
    "checkout_date": "2021-12-01",
    "clerk_number": "AE1234",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "custom_data": {},
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
    "recurring": {
      "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
      "token_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_vault_api_id": "token1234abcd",
      "token_api_id": "token1234abcd",
      "_joi": {
        "conditions": {}
      },
      "active": true,
      "description": "Description",
      "end_date": "2021-12-01",
      "installment_total_count": 20,
      "interval": 1,
      "interval_type": "d",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "notification_days": 2,
      "payment_method": "cc",
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_api_id": "recurring1234abcd",
      "start_date": "2021-12-01",
      "status": "active",
      "transaction_amount": 300,
      "terms_agree": true,
      "terms_agree_ip": "192.168.0.10",
      "recurring_c1": "recurring custom data 1",
      "recurring_c2": "recurring custom data 2",
      "recurring_c3": "recurring custom data 3",
      "send_to_proc_as_recur": true,
      "tags": [
        "Walk-in Customer"
      ],
      "secondary_amount": 100,
      "currency": "USD",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "next_run_date": "2021-12-01",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "recurring_type_id": "i",
      "installment_amount_total": 99999999,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "recurring_number": 1,
    "room_num": "303",
    "room_rate": 95,
    "save_account": false,
    "save_account_title": "John Account",
    "subtotal_amount": 599,
    "surcharge_amount": 100,
    "tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
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
    "emv_receipt_data": {
      "AID": "a0000000042203",
      "APPLAB": "US Maestro",
      "APPN": "US Maestro",
      "CVM": "Pin Verified",
      "TSI": "e800",
      "TVR": "0800008000"
    },
    "first_six": "545454",
    "last_four": "5454",
    "payment_method": "cc",
    "terminal_serial_number": "1234567890",
    "transaction_settlement_status": null,
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
    "response_message": null,
    "return_date": "2021-12-01",
    "trx_source_id": 8,
    "routing_number": "051904524",
    "trx_source_code": 8,
    "paylink_id": "11e95f8ec39de8fbdb0a4f1a",
    "is_accountvault": true,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "effective_date": "2021-12-01",
    "is_token": true,
    "installment_total": 1,
    "installment_counter": 1,
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "hosted_payment_page_id": "11e95f8ec39de8fbdb0a4f1a",
    "account_vault": {
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
      "billing_address": {
        "city": "Novi",
        "state": "Michigan",
        "postal_code": "48375",
        "phone": "3339998822",
        "country": "USA"
      },
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "customer_id": "123456",
      "identity_verification": {
        "dl_state": "MI",
        "dl_number": "1235567",
        "ssn4": "8527",
        "dob_year": "1980"
      },
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_account_vault_api_id": "previousaccountvault123456",
      "previous_token_api_id": "previousaccountvault123456",
      "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_token_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_number": "545454545454545",
      "terms_agree": true,
      "terms_agree_ip": "192.168.0.10",
      "title": "Test CC Account",
      "_joi": {},
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "account_type": "checking",
      "active": true,
      "cau_summary_status_id": 1,
      "created_ts": 1422040992,
      "e_serial_number": "1234567890",
      "e_track_data": null,
      "e_format": null,
      "e_keyed_data": null,
      "expiring_in_months": null,
      "exp_date": "0722",
      "first_six": "700953",
      "has_recurring": false,
      "last_four": "3657",
      "modified_ts": 1422040992,
      "payment_method": "cc",
      "ticket": null,
      "track_data": null,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "cau_last_updated_ts": 1422040992,
      "routing_number": "051904524"
    },
    "quick_invoice": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": "My terminal",
      "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "due_date": "2021-12-01",
      "item_list": [
        {
          "name": "Bread",
          "amount": 2015
        }
      ],
      "allow_overpayment": true,
      "bank_funded_only_override": true,
      "email": "email@domain.com",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_api_id": "contact12345",
      "quick_invoice_api_id": "quickinvoice12345",
      "customer_id": "11e95f8ec39de8fbdb0a4f1a",
      "expire_date": "2021-12-01",
      "allow_partial_pay": true,
      "attach_files_to_email": true,
      "send_email": true,
      "invoice_number": "invoice12345",
      "item_header": "Quick invoice header sample",
      "item_footer": "Thank you",
      "amount_due": 245.36,
      "notification_email": "email@domain.com",
      "status_id": 1,
      "status_code": 1,
      "note": "some note",
      "notification_days_before_due_date": 3,
      "notification_days_after_due_date": 7,
      "notification_on_due_date": true,
      "send_text_to_pay": true,
      "files": [
        null
      ],
      "remaining_balance": 245.36,
      "single_payment_min_amount": 500,
      "single_payment_max_amount": 500000,
      "cell_phone": "3339998822",
      "tags": [
        "Walk-in Customer"
      ],
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "payment_status_id": 1,
      "is_active": true
    },
    "log_emails": [
      {
        "subject": "Payment Receipt - 12skiestech",
        "body": "This email is being sent from a server.",
        "source_address": "\"12skiestech A7t3qi\" <noreply@zeamster.email>",
        "return_path": "\"12skiestech A7t3qi\" <noreply@zeamster.email>",
        "provider_id": "0100017e67bcc530-e1dd23b4-8a39-4a5b-8d5d-68d51c4c942f-000000",
        "domain_id": "11e95f8ec39de8fbdb0a4f1a",
        "reason_sent": "Contact Email",
        "reason_model": "Transaction",
        "reason_model_id": "11e95f8ec39de8fbdb0a4f1a",
        "reply_to": "\"Zeamster\" <emma.p@zeamster.com>",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992
      }
    ],
    "is_voidable": true,
    "is_reversible": true,
    "is_refundable": true,
    "is_completable": true,
    "is_settled": true,
    "created_user": {
      "account_number": "5454545454545454",
      "branding_domain_url": "{branding_domain_url}",
      "cell_phone": "3339998822",
      "company_name": "Fortis Payment Systems, LLC",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "date_of_birth": "2021-12-01",
      "domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "email": "email@domain.com",
      "email_trx_receipt": true,
      "home_phone": "3339998822",
      "first_name": "John",
      "last_name": "Smith",
      "locale": "en-US",
      "office_phone": "3339998822",
      "office_ext_phone": "5",
      "primary_location_id": "11e95f8ec39de8fbdb0a4f1a",
      "requires_new_password": null,
      "terms_condition_code": "20220308",
      "tz": "America/New_York",
      "ui_prefs": {
        "entry_page": "dashboard",
        "page_size": 2,
        "report_export_type": "csv",
        "process_method": "virtual_terminal",
        "default_terminal": "11e95f8ec39de8fbdb0a4f1a"
      },
      "username": "{user_name}",
      "user_api_key": "234bas8dfn8238f923w2",
      "user_hash_key": null,
      "user_type_code": 100,
      "password": null,
      "zip": "48375",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "status_code": 1,
      "api_only": false,
      "is_invitation": false,
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "status": true,
      "login_attempts": 0,
      "last_login_ts": 1422040992,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "terms_accepted_ts": 1422040992,
      "terms_agree_ip": "192.168.0.10",
      "current_date_time": "2019-03-11T10:38:26-0700",
      "current_login": 1422040992,
      "log_api_response_body_ts": 1422040992
    },
    "location": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "account_number": "5454545454545454",
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "branding_domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_email_trx_receipt_default": true,
      "default_ach": "11e608a7d515f1e093242bb2",
      "default_cc": "11e608a442a5f1e092242dda",
      "email_reply_to": "email@domain.com",
      "fax": "3339998822",
      "location_api_id": "location-111111",
      "location_api_key": "AE34BBCAADF4AE34BBCAADF4",
      "location_c1": "custom 1",
      "location_c2": "custom 2",
      "location_c3": "custom data 3",
      "name": "Sample Company Headquarters",
      "office_phone": "2481234567",
      "office_ext_phone": "1021021209",
      "tz": "America/New_York",
      "parent_id": "11e95f8ec39de8fbdb0a4f1a",
      "show_contact_notes": true,
      "show_contact_files": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_type": "merchant",
      "ticket_hash_key": "A5F443CADF4AE34BBCAADF4"
    },
    "contact": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_number": "54545433332",
      "contact_api_id": "137",
      "first_name": "John",
      "last_name": "Smith",
      "cell_phone": "3339998822",
      "balance": 245.36,
      "address": {
        "city": "Novi",
        "state": "Michigan",
        "postal_code": "48375",
        "country": "US"
      },
      "company_name": "Fortis Payment Systems, LLC",
      "header_message": "This is a sample message for you",
      "date_of_birth": "2021-12-01",
      "email_trx_receipt": true,
      "home_phone": "3339998822",
      "office_phone": "3339998822",
      "office_phone_ext": "5",
      "header_message_type": 0,
      "update_if_exists": 1,
      "contact_c1": "any",
      "contact_c2": "anything",
      "contact_c3": "something",
      "parent_id": "11e95f8ec39de8fbdb0a4f1a",
      "email": "email@domain.com",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "active": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "changelogs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "action": "CREATE",
        "model": "TransactionRequest",
        "model_id": "11ec829598f0d4008be9aba4",
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_details": [
          {
            "id": "11e95f8ec39de8fbdb0a4f1a",
            "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
            "field": "next_run_ts",
            "old_value": "1643616000"
          }
        ],
        "user": {
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "username": "email@domain.com",
          "first_name": "Bob",
          "last_name": "Fairview"
        }
      }
    ],
    "product_transaction": {
      "processor_version": "1_0_0",
      "title": "My terminal",
      "payment_method": "cc",
      "processor": "zgate",
      "mcc": "1111",
      "tax_surcharge_config": 2,
      "partner": "standalone",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "surcharge": {},
      "processor_data": {},
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
      "dup_check_per_batch": null,
      "paylink_allow": false,
      "quick_invoice_allow": false,
      "level3_allow": false,
      "payfac_enable": false,
      "sales_office_id": "11e95f8ec39de8fbdb0a4f1a",
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
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "product_transaction_api_id": "11e95f8ec39de8fbdb0a4f1a",
      "is_secondary_amount_allowed": false,
      "batch_risk_config": {},
      "fortis_id": "8149742",
      "product_billing_group_code": "nofees",
      "cau_subscribe_type_code": 0
    },
    "all_tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "tagTransactions": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "tag_id": "Tag ID",
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "declined_recurring_notification": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_ts": 1422040992,
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "payment_recurring_notification": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_ts": 1422040992,
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "developer_company": {
      "title": "My terminal",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "terminal": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "default_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_application_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_cvm_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_manufacturer_code": "1",
      "title": "My terminal",
      "mac_address": "3D:F2:C9:A6:B3:4F",
      "local_ip_address": "192.168.0.10",
      "port": 10009,
      "serial_number": "1234567890",
      "terminal_number": "973456789012367",
      "terminal_timeouts": {
        "card_entry_timeout": 47,
        "device_terms_prompt_timeout": 30,
        "overall_timeout": 125,
        "pin_entry_timeout": 40,
        "signature_input_timeout": 35,
        "signature_submit_timeout": 38,
        "status_display_time": 12,
        "tip_cashback_timeout": 25,
        "transaction_timeout": 17
      },
      "tip_percents": {
        "percent_1": 0,
        "percent_2": 2,
        "percent_3": 99
      },
      "header_line_1": "line 1 sample",
      "header_line_2": "line 2 sample",
      "header_line_3": "line 3 sample",
      "header_line_4": "line 4 sample",
      "header_line_5": "line 5 sample",
      "trailer_line_1": "trailer 1 sample",
      "trailer_line_2": "trailer 2 sample",
      "trailer_line_3": "trailer 3 sample",
      "trailer_line_4": "trailer 4 sample",
      "trailer_line_5": "trailer 5 sample",
      "default_checkin": "2021-12-01",
      "default_checkout": "2021-12-01",
      "default_room_rate": 56,
      "default_room_number": "303",
      "debit": false,
      "emv": false,
      "cashback_enable": false,
      "print_enable": false,
      "sig_capture_enable": false,
      "is_provisioned": false,
      "tip_enable": false,
      "validated_decryption": false,
      "communication_type": "http",
      "active": true,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "last_registration_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "hosted_payment_page": {
      "user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_api_id": null,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": "Sample title",
      "redirect_url_delay": 15,
      "min_payment_amount": 0,
      "max_payment_amount": 9999999999,
      "redirect_url_on_approve": null,
      "redirect_url_on_decline": null,
      "field_configuration": {
        "css_mini": true,
        "stack": "vertical",
        "header": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        },
        "body": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        },
        "footer": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        }
      },
      "encryption_key": null,
      "stylesheet_url": null,
      "parent_send_message": true,
      "hide_optional_fields": true,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "transaction_level3": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "level3_data": {
        "destination_country_code": "840",
        "duty_amount": 0,
        "freight_amount": 0,
        "national_tax": 2,
        "sales_tax": 200,
        "shipfrom_zip_code": "AZ1234",
        "shipto_zip_code": "FL1234",
        "tax_amount": 10,
        "tax_exempt": "0",
        "customer_vat_registration": "12345678",
        "merchant_vat_registration": "123456",
        "order_date": "171006",
        "summary_commodity_code": "C1K2",
        "tax_rate": 0,
        "unique_vat_ref_number": "vat1234",
        "line_items": [
          {
            "description": "cool drink",
            "commodity_code": "cc123456",
            "discount_amount": 0,
            "other_tax_amount": 0,
            "product_code": "fanta123456",
            "quantity": 12,
            "tax_amount": 4,
            "tax_rate": 0,
            "unit_code": "gll",
            "unit_cost": 3,
            "alternate_tax_id": "1234",
            "debit_credit": "C",
            "discount_rate": 11,
            "tax_type_applied": "22",
            "tax_type_id": "11"
          }
        ]
      }
    },
    "developer_company_id": "Sample Developer Company ID",
    "transaction_histories": [
      {
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "status_id": 101,
        "event_date_ts": 1422040992,
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "surcharge_transaction": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "model_name": "Model Name",
      "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "surcharge_fee": 0,
      "surcharge_rate": 0,
      "surcharge_amount": null,
      "surcharge_transaction_min": null,
      "surcharge_transaction_max": null,
      "created": 1422040992,
      "modified": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "surcharge": {
      "surcharge_fee": 10,
      "surcharge_rate": 1,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "apply_to_user_type_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": null,
      "surcharge_label": null,
      "surcharge_transaction_product_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "reason_code": {
      "id": 50,
      "title": "Sample Title"
    },
    "type": {
      "id": 50,
      "title": "Sample Title"
    },
    "status": {
      "id": 50,
      "title": "Sample Title"
    },
    "transaction_batch": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "processing_status_id": 2,
      "batch_num": 4,
      "is_open": 0,
      "settlement_file_name": "settement_file.txt",
      "batch_close_ts": 1531423693,
      "batch_close_detail": "BATCH_MISMATCH",
      "total_sale_amount": 2342,
      "total_sale_count": 21,
      "total_refund_amount": 2342,
      "total_refund_count": 18,
      "total_void_amount": 2342,
      "total_void_count": 17,
      "total_blind_refund_amount": 2342,
      "total_blind_refund_count": 16
    },
    "transaction_splits": [
      {
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "contact_id": "11e95f8ec39de8fbdb0a4f1a",
        "amount": 10,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "postback_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
        "next_run_ts": 1422040992,
        "created_ts": 1422040992,
        "model_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "currency_type": {
      "id": 50,
      "title": "Sample Title"
    },
    "transaction_references": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ]
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# ACH Credit - Previous Transaction

Create a new ACH credit transaction using previous transaction id

```csharp
ACHCreditPreviousTransactionAsync(
    Models.V1TransactionsAchCreditPrevTrxnRequest body,
    List<Models.Expand54Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1TransactionsAchCreditPrevTrxnRequest`](../../doc/models/v1-transactions-ach-credit-prev-trxn-request.md) | Body, Required | - |
| `expand` | [`List<Expand54Enum>`](../../doc/models/expand-54-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
V1TransactionsAchCreditPrevTrxnRequest body = new V1TransactionsAchCreditPrevTrxnRequest
{
    TransactionAmount = 1,
    PreviousTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    CheckinDate = "2021-12-01",
    CheckoutDate = "2021-12-01",
    ClerkNumber = "AE1234",
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    CustomData = ApiHelper.JsonDeserialize<object>("{\"data1\":\"custom1\",\"data2\":\"custom2\"}"),
    CustomerId = "customerid",
    Description = "some description",
    IiasInd = IiasIndEnum.Enum1,
    ImageFront = "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    ImageBack = "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    Installment = true,
    InstallmentNumber = 1,
    InstallmentCount = 1,
    LocationApiId = "location-api-id-florida-2",
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    AdvanceDeposit = false,
    NoShow = false,
    NotificationEmailAddress = "johnsmith@smiths.com",
    OrderNumber = "433659378839",
    PoNumber = "555555553123",
    QuickInvoiceId = "11e95f8ec39de8fbdb0a4f1a",
    Recurring = false,
    RecurringNumber = 1,
    RoomNum = "303",
    RoomRate = 95,
    SaveAccount = false,
    SaveAccountTitle = "John Account",
    SubtotalAmount = 599,
    SurchargeAmount = 100,
    Tax = 0,
    TipAmount = 0,
    SecondaryAmount = 0,
    TransactionApiId = "transaction-payment-abcd123",
    TransactionC1 = "custom-data-1",
    TransactionC2 = "custom-data-2",
    TransactionC3 = "custom-data-3",
    BankFundedOnlyOverride = false,
    AllowPartialAuthorizationOverride = false,
    AutoDeclineCvvOverride = false,
    AutoDeclineStreetOverride = false,
    AutoDeclineZipOverride = false,
    AchIdentifier = "P",
    AchSecCode = AchSecCode1Enum.C21,
    EffectiveDate = "2021-12-01",
};

try
{
    ResponseTransaction result = await transactionsACHController.ACHCreditPreviousTransactionAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Example Response *(as JSON)*

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": 10,
        "account_type": "credit",
        "currency": 840
      }
    ],
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "phone": "3339998822",
      "country": "USA"
    },
    "checkin_date": "2021-12-01",
    "checkout_date": "2021-12-01",
    "clerk_number": "AE1234",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "custom_data": {},
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
    "recurring": {
      "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
      "token_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_vault_api_id": "token1234abcd",
      "token_api_id": "token1234abcd",
      "_joi": {
        "conditions": {}
      },
      "active": true,
      "description": "Description",
      "end_date": "2021-12-01",
      "installment_total_count": 20,
      "interval": 1,
      "interval_type": "d",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "notification_days": 2,
      "payment_method": "cc",
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_api_id": "recurring1234abcd",
      "start_date": "2021-12-01",
      "status": "active",
      "transaction_amount": 300,
      "terms_agree": true,
      "terms_agree_ip": "192.168.0.10",
      "recurring_c1": "recurring custom data 1",
      "recurring_c2": "recurring custom data 2",
      "recurring_c3": "recurring custom data 3",
      "send_to_proc_as_recur": true,
      "tags": [
        "Walk-in Customer"
      ],
      "secondary_amount": 100,
      "currency": "USD",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "next_run_date": "2021-12-01",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "recurring_type_id": "i",
      "installment_amount_total": 99999999,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "recurring_number": 1,
    "room_num": "303",
    "room_rate": 95,
    "save_account": false,
    "save_account_title": "John Account",
    "subtotal_amount": 599,
    "surcharge_amount": 100,
    "tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
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
    "emv_receipt_data": {
      "AID": "a0000000042203",
      "APPLAB": "US Maestro",
      "APPN": "US Maestro",
      "CVM": "Pin Verified",
      "TSI": "e800",
      "TVR": "0800008000"
    },
    "first_six": "545454",
    "last_four": "5454",
    "payment_method": "cc",
    "terminal_serial_number": "1234567890",
    "transaction_settlement_status": null,
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
    "response_message": null,
    "return_date": "2021-12-01",
    "trx_source_id": 8,
    "routing_number": "051904524",
    "trx_source_code": 8,
    "paylink_id": "11e95f8ec39de8fbdb0a4f1a",
    "is_accountvault": true,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "effective_date": "2021-12-01",
    "is_token": true,
    "installment_total": 1,
    "installment_counter": 1,
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "hosted_payment_page_id": "11e95f8ec39de8fbdb0a4f1a",
    "account_vault": {
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
      "billing_address": {
        "city": "Novi",
        "state": "Michigan",
        "postal_code": "48375",
        "phone": "3339998822",
        "country": "USA"
      },
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "customer_id": "123456",
      "identity_verification": {
        "dl_state": "MI",
        "dl_number": "1235567",
        "ssn4": "8527",
        "dob_year": "1980"
      },
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_account_vault_api_id": "previousaccountvault123456",
      "previous_token_api_id": "previousaccountvault123456",
      "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_token_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_number": "545454545454545",
      "terms_agree": true,
      "terms_agree_ip": "192.168.0.10",
      "title": "Test CC Account",
      "_joi": {},
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "account_type": "checking",
      "active": true,
      "cau_summary_status_id": 1,
      "created_ts": 1422040992,
      "e_serial_number": "1234567890",
      "e_track_data": null,
      "e_format": null,
      "e_keyed_data": null,
      "expiring_in_months": null,
      "exp_date": "0722",
      "first_six": "700953",
      "has_recurring": false,
      "last_four": "3657",
      "modified_ts": 1422040992,
      "payment_method": "cc",
      "ticket": null,
      "track_data": null,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "cau_last_updated_ts": 1422040992,
      "routing_number": "051904524"
    },
    "quick_invoice": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": "My terminal",
      "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "due_date": "2021-12-01",
      "item_list": [
        {
          "name": "Bread",
          "amount": 2015
        }
      ],
      "allow_overpayment": true,
      "bank_funded_only_override": true,
      "email": "email@domain.com",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_api_id": "contact12345",
      "quick_invoice_api_id": "quickinvoice12345",
      "customer_id": "11e95f8ec39de8fbdb0a4f1a",
      "expire_date": "2021-12-01",
      "allow_partial_pay": true,
      "attach_files_to_email": true,
      "send_email": true,
      "invoice_number": "invoice12345",
      "item_header": "Quick invoice header sample",
      "item_footer": "Thank you",
      "amount_due": 245.36,
      "notification_email": "email@domain.com",
      "status_id": 1,
      "status_code": 1,
      "note": "some note",
      "notification_days_before_due_date": 3,
      "notification_days_after_due_date": 7,
      "notification_on_due_date": true,
      "send_text_to_pay": true,
      "files": [
        null
      ],
      "remaining_balance": 245.36,
      "single_payment_min_amount": 500,
      "single_payment_max_amount": 500000,
      "cell_phone": "3339998822",
      "tags": [
        "Walk-in Customer"
      ],
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "payment_status_id": 1,
      "is_active": true
    },
    "log_emails": [
      {
        "subject": "Payment Receipt - 12skiestech",
        "body": "This email is being sent from a server.",
        "source_address": "\"12skiestech A7t3qi\" <noreply@zeamster.email>",
        "return_path": "\"12skiestech A7t3qi\" <noreply@zeamster.email>",
        "provider_id": "0100017e67bcc530-e1dd23b4-8a39-4a5b-8d5d-68d51c4c942f-000000",
        "domain_id": "11e95f8ec39de8fbdb0a4f1a",
        "reason_sent": "Contact Email",
        "reason_model": "Transaction",
        "reason_model_id": "11e95f8ec39de8fbdb0a4f1a",
        "reply_to": "\"Zeamster\" <emma.p@zeamster.com>",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992
      }
    ],
    "is_voidable": true,
    "is_reversible": true,
    "is_refundable": true,
    "is_completable": true,
    "is_settled": true,
    "created_user": {
      "account_number": "5454545454545454",
      "branding_domain_url": "{branding_domain_url}",
      "cell_phone": "3339998822",
      "company_name": "Fortis Payment Systems, LLC",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "date_of_birth": "2021-12-01",
      "domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "email": "email@domain.com",
      "email_trx_receipt": true,
      "home_phone": "3339998822",
      "first_name": "John",
      "last_name": "Smith",
      "locale": "en-US",
      "office_phone": "3339998822",
      "office_ext_phone": "5",
      "primary_location_id": "11e95f8ec39de8fbdb0a4f1a",
      "requires_new_password": null,
      "terms_condition_code": "20220308",
      "tz": "America/New_York",
      "ui_prefs": {
        "entry_page": "dashboard",
        "page_size": 2,
        "report_export_type": "csv",
        "process_method": "virtual_terminal",
        "default_terminal": "11e95f8ec39de8fbdb0a4f1a"
      },
      "username": "{user_name}",
      "user_api_key": "234bas8dfn8238f923w2",
      "user_hash_key": null,
      "user_type_code": 100,
      "password": null,
      "zip": "48375",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "status_code": 1,
      "api_only": false,
      "is_invitation": false,
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "status": true,
      "login_attempts": 0,
      "last_login_ts": 1422040992,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "terms_accepted_ts": 1422040992,
      "terms_agree_ip": "192.168.0.10",
      "current_date_time": "2019-03-11T10:38:26-0700",
      "current_login": 1422040992,
      "log_api_response_body_ts": 1422040992
    },
    "location": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "account_number": "5454545454545454",
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "branding_domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_email_trx_receipt_default": true,
      "default_ach": "11e608a7d515f1e093242bb2",
      "default_cc": "11e608a442a5f1e092242dda",
      "email_reply_to": "email@domain.com",
      "fax": "3339998822",
      "location_api_id": "location-111111",
      "location_api_key": "AE34BBCAADF4AE34BBCAADF4",
      "location_c1": "custom 1",
      "location_c2": "custom 2",
      "location_c3": "custom data 3",
      "name": "Sample Company Headquarters",
      "office_phone": "2481234567",
      "office_ext_phone": "1021021209",
      "tz": "America/New_York",
      "parent_id": "11e95f8ec39de8fbdb0a4f1a",
      "show_contact_notes": true,
      "show_contact_files": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_type": "merchant",
      "ticket_hash_key": "A5F443CADF4AE34BBCAADF4"
    },
    "contact": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_number": "54545433332",
      "contact_api_id": "137",
      "first_name": "John",
      "last_name": "Smith",
      "cell_phone": "3339998822",
      "balance": 245.36,
      "address": {
        "city": "Novi",
        "state": "Michigan",
        "postal_code": "48375",
        "country": "US"
      },
      "company_name": "Fortis Payment Systems, LLC",
      "header_message": "This is a sample message for you",
      "date_of_birth": "2021-12-01",
      "email_trx_receipt": true,
      "home_phone": "3339998822",
      "office_phone": "3339998822",
      "office_phone_ext": "5",
      "header_message_type": 0,
      "update_if_exists": 1,
      "contact_c1": "any",
      "contact_c2": "anything",
      "contact_c3": "something",
      "parent_id": "11e95f8ec39de8fbdb0a4f1a",
      "email": "email@domain.com",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "active": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "changelogs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "action": "CREATE",
        "model": "TransactionRequest",
        "model_id": "11ec829598f0d4008be9aba4",
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_details": [
          {
            "id": "11e95f8ec39de8fbdb0a4f1a",
            "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
            "field": "next_run_ts",
            "old_value": "1643616000"
          }
        ],
        "user": {
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "username": "email@domain.com",
          "first_name": "Bob",
          "last_name": "Fairview"
        }
      }
    ],
    "product_transaction": {
      "processor_version": "1_0_0",
      "title": "My terminal",
      "payment_method": "cc",
      "processor": "zgate",
      "mcc": "1111",
      "tax_surcharge_config": 2,
      "partner": "standalone",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "surcharge": {},
      "processor_data": {},
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
      "dup_check_per_batch": null,
      "paylink_allow": false,
      "quick_invoice_allow": false,
      "level3_allow": false,
      "payfac_enable": false,
      "sales_office_id": "11e95f8ec39de8fbdb0a4f1a",
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
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "product_transaction_api_id": "11e95f8ec39de8fbdb0a4f1a",
      "is_secondary_amount_allowed": false,
      "batch_risk_config": {},
      "fortis_id": "8149742",
      "product_billing_group_code": "nofees",
      "cau_subscribe_type_code": 0
    },
    "all_tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "tagTransactions": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "tag_id": "Tag ID",
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "declined_recurring_notification": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_ts": 1422040992,
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "payment_recurring_notification": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_ts": 1422040992,
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "developer_company": {
      "title": "My terminal",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "terminal": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "default_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_application_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_cvm_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_manufacturer_code": "1",
      "title": "My terminal",
      "mac_address": "3D:F2:C9:A6:B3:4F",
      "local_ip_address": "192.168.0.10",
      "port": 10009,
      "serial_number": "1234567890",
      "terminal_number": "973456789012367",
      "terminal_timeouts": {
        "card_entry_timeout": 47,
        "device_terms_prompt_timeout": 30,
        "overall_timeout": 125,
        "pin_entry_timeout": 40,
        "signature_input_timeout": 35,
        "signature_submit_timeout": 38,
        "status_display_time": 12,
        "tip_cashback_timeout": 25,
        "transaction_timeout": 17
      },
      "tip_percents": {
        "percent_1": 0,
        "percent_2": 2,
        "percent_3": 99
      },
      "header_line_1": "line 1 sample",
      "header_line_2": "line 2 sample",
      "header_line_3": "line 3 sample",
      "header_line_4": "line 4 sample",
      "header_line_5": "line 5 sample",
      "trailer_line_1": "trailer 1 sample",
      "trailer_line_2": "trailer 2 sample",
      "trailer_line_3": "trailer 3 sample",
      "trailer_line_4": "trailer 4 sample",
      "trailer_line_5": "trailer 5 sample",
      "default_checkin": "2021-12-01",
      "default_checkout": "2021-12-01",
      "default_room_rate": 56,
      "default_room_number": "303",
      "debit": false,
      "emv": false,
      "cashback_enable": false,
      "print_enable": false,
      "sig_capture_enable": false,
      "is_provisioned": false,
      "tip_enable": false,
      "validated_decryption": false,
      "communication_type": "http",
      "active": true,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "last_registration_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "hosted_payment_page": {
      "user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_api_id": null,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": "Sample title",
      "redirect_url_delay": 15,
      "min_payment_amount": 0,
      "max_payment_amount": 9999999999,
      "redirect_url_on_approve": null,
      "redirect_url_on_decline": null,
      "field_configuration": {
        "css_mini": true,
        "stack": "vertical",
        "header": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        },
        "body": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        },
        "footer": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        }
      },
      "encryption_key": null,
      "stylesheet_url": null,
      "parent_send_message": true,
      "hide_optional_fields": true,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "transaction_level3": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "level3_data": {
        "destination_country_code": "840",
        "duty_amount": 0,
        "freight_amount": 0,
        "national_tax": 2,
        "sales_tax": 200,
        "shipfrom_zip_code": "AZ1234",
        "shipto_zip_code": "FL1234",
        "tax_amount": 10,
        "tax_exempt": "0",
        "customer_vat_registration": "12345678",
        "merchant_vat_registration": "123456",
        "order_date": "171006",
        "summary_commodity_code": "C1K2",
        "tax_rate": 0,
        "unique_vat_ref_number": "vat1234",
        "line_items": [
          {
            "description": "cool drink",
            "commodity_code": "cc123456",
            "discount_amount": 0,
            "other_tax_amount": 0,
            "product_code": "fanta123456",
            "quantity": 12,
            "tax_amount": 4,
            "tax_rate": 0,
            "unit_code": "gll",
            "unit_cost": 3,
            "alternate_tax_id": "1234",
            "debit_credit": "C",
            "discount_rate": 11,
            "tax_type_applied": "22",
            "tax_type_id": "11"
          }
        ]
      }
    },
    "developer_company_id": "Sample Developer Company ID",
    "transaction_histories": [
      {
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "status_id": 101,
        "event_date_ts": 1422040992,
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "surcharge_transaction": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "model_name": "Model Name",
      "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "surcharge_fee": 0,
      "surcharge_rate": 0,
      "surcharge_amount": null,
      "surcharge_transaction_min": null,
      "surcharge_transaction_max": null,
      "created": 1422040992,
      "modified": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "surcharge": {
      "surcharge_fee": 10,
      "surcharge_rate": 1,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "apply_to_user_type_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": null,
      "surcharge_label": null,
      "surcharge_transaction_product_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "reason_code": {
      "id": 50,
      "title": "Sample Title"
    },
    "type": {
      "id": 50,
      "title": "Sample Title"
    },
    "status": {
      "id": 50,
      "title": "Sample Title"
    },
    "transaction_batch": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "processing_status_id": 2,
      "batch_num": 4,
      "is_open": 0,
      "settlement_file_name": "settement_file.txt",
      "batch_close_ts": 1531423693,
      "batch_close_detail": "BATCH_MISMATCH",
      "total_sale_amount": 2342,
      "total_sale_count": 21,
      "total_refund_amount": 2342,
      "total_refund_count": 18,
      "total_void_amount": 2342,
      "total_void_count": 17,
      "total_blind_refund_amount": 2342,
      "total_blind_refund_count": 16
    },
    "transaction_splits": [
      {
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "contact_id": "11e95f8ec39de8fbdb0a4f1a",
        "amount": 10,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "postback_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
        "next_run_ts": 1422040992,
        "created_ts": 1422040992,
        "model_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "currency_type": {
      "id": 50,
      "title": "Sample Title"
    },
    "transaction_references": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ]
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# ACH Credit - Tokenized

Create a new tokenized ACH credit transaction

```csharp
ACHCreditTokenizedAsync(
    Models.V1TransactionsAchCreditTokenRequest body,
    List<Models.Expand54Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1TransactionsAchCreditTokenRequest`](../../doc/models/v1-transactions-ach-credit-token-request.md) | Body, Required | - |
| `expand` | [`List<Expand54Enum>`](../../doc/models/expand-54-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
V1TransactionsAchCreditTokenRequest body = new V1TransactionsAchCreditTokenRequest
{
    TransactionAmount = 1,
    CheckinDate = "2021-12-01",
    CheckoutDate = "2021-12-01",
    ClerkNumber = "AE1234",
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    CustomData = ApiHelper.JsonDeserialize<object>("{\"data1\":\"custom1\",\"data2\":\"custom2\"}"),
    CustomerId = "customerid",
    Description = "some description",
    IiasInd = IiasIndEnum.Enum1,
    ImageFront = "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    ImageBack = "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    Installment = true,
    InstallmentNumber = 1,
    InstallmentCount = 1,
    LocationApiId = "location-api-id-florida-2",
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    AdvanceDeposit = false,
    NoShow = false,
    NotificationEmailAddress = "johnsmith@smiths.com",
    OrderNumber = "433659378839",
    PoNumber = "555555553123",
    QuickInvoiceId = "11e95f8ec39de8fbdb0a4f1a",
    Recurring = false,
    RecurringNumber = 1,
    RoomNum = "303",
    RoomRate = 95,
    SaveAccount = false,
    SaveAccountTitle = "John Account",
    SubtotalAmount = 599,
    SurchargeAmount = 100,
    Tax = 0,
    TipAmount = 0,
    SecondaryAmount = 0,
    TransactionApiId = "transaction-payment-abcd123",
    TransactionC1 = "custom-data-1",
    TransactionC2 = "custom-data-2",
    TransactionC3 = "custom-data-3",
    BankFundedOnlyOverride = false,
    AllowPartialAuthorizationOverride = false,
    AutoDeclineCvvOverride = false,
    AutoDeclineStreetOverride = false,
    AutoDeclineZipOverride = false,
    AchIdentifier = "P",
    AchSecCode = AchSecCode1Enum.C21,
    EffectiveDate = "2021-12-01",
    AccountVaultId = "11e95f8ec39de8fbdb0a4f1a",
    TokenId = "11e95f8ec39de8fbdb0a4f1a",
};

try
{
    ResponseTransaction result = await transactionsACHController.ACHCreditTokenizedAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Example Response *(as JSON)*

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": 10,
        "account_type": "credit",
        "currency": 840
      }
    ],
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "phone": "3339998822",
      "country": "USA"
    },
    "checkin_date": "2021-12-01",
    "checkout_date": "2021-12-01",
    "clerk_number": "AE1234",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "custom_data": {},
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
    "recurring": {
      "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
      "token_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_vault_api_id": "token1234abcd",
      "token_api_id": "token1234abcd",
      "_joi": {
        "conditions": {}
      },
      "active": true,
      "description": "Description",
      "end_date": "2021-12-01",
      "installment_total_count": 20,
      "interval": 1,
      "interval_type": "d",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "notification_days": 2,
      "payment_method": "cc",
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_api_id": "recurring1234abcd",
      "start_date": "2021-12-01",
      "status": "active",
      "transaction_amount": 300,
      "terms_agree": true,
      "terms_agree_ip": "192.168.0.10",
      "recurring_c1": "recurring custom data 1",
      "recurring_c2": "recurring custom data 2",
      "recurring_c3": "recurring custom data 3",
      "send_to_proc_as_recur": true,
      "tags": [
        "Walk-in Customer"
      ],
      "secondary_amount": 100,
      "currency": "USD",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "next_run_date": "2021-12-01",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "recurring_type_id": "i",
      "installment_amount_total": 99999999,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "recurring_number": 1,
    "room_num": "303",
    "room_rate": 95,
    "save_account": false,
    "save_account_title": "John Account",
    "subtotal_amount": 599,
    "surcharge_amount": 100,
    "tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
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
    "emv_receipt_data": {
      "AID": "a0000000042203",
      "APPLAB": "US Maestro",
      "APPN": "US Maestro",
      "CVM": "Pin Verified",
      "TSI": "e800",
      "TVR": "0800008000"
    },
    "first_six": "545454",
    "last_four": "5454",
    "payment_method": "cc",
    "terminal_serial_number": "1234567890",
    "transaction_settlement_status": null,
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
    "response_message": null,
    "return_date": "2021-12-01",
    "trx_source_id": 8,
    "routing_number": "051904524",
    "trx_source_code": 8,
    "paylink_id": "11e95f8ec39de8fbdb0a4f1a",
    "is_accountvault": true,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "effective_date": "2021-12-01",
    "is_token": true,
    "installment_total": 1,
    "installment_counter": 1,
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "hosted_payment_page_id": "11e95f8ec39de8fbdb0a4f1a",
    "account_vault": {
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
      "billing_address": {
        "city": "Novi",
        "state": "Michigan",
        "postal_code": "48375",
        "phone": "3339998822",
        "country": "USA"
      },
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "customer_id": "123456",
      "identity_verification": {
        "dl_state": "MI",
        "dl_number": "1235567",
        "ssn4": "8527",
        "dob_year": "1980"
      },
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_account_vault_api_id": "previousaccountvault123456",
      "previous_token_api_id": "previousaccountvault123456",
      "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_token_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_number": "545454545454545",
      "terms_agree": true,
      "terms_agree_ip": "192.168.0.10",
      "title": "Test CC Account",
      "_joi": {},
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "account_type": "checking",
      "active": true,
      "cau_summary_status_id": 1,
      "created_ts": 1422040992,
      "e_serial_number": "1234567890",
      "e_track_data": null,
      "e_format": null,
      "e_keyed_data": null,
      "expiring_in_months": null,
      "exp_date": "0722",
      "first_six": "700953",
      "has_recurring": false,
      "last_four": "3657",
      "modified_ts": 1422040992,
      "payment_method": "cc",
      "ticket": null,
      "track_data": null,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "cau_last_updated_ts": 1422040992,
      "routing_number": "051904524"
    },
    "quick_invoice": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": "My terminal",
      "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "due_date": "2021-12-01",
      "item_list": [
        {
          "name": "Bread",
          "amount": 2015
        }
      ],
      "allow_overpayment": true,
      "bank_funded_only_override": true,
      "email": "email@domain.com",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_api_id": "contact12345",
      "quick_invoice_api_id": "quickinvoice12345",
      "customer_id": "11e95f8ec39de8fbdb0a4f1a",
      "expire_date": "2021-12-01",
      "allow_partial_pay": true,
      "attach_files_to_email": true,
      "send_email": true,
      "invoice_number": "invoice12345",
      "item_header": "Quick invoice header sample",
      "item_footer": "Thank you",
      "amount_due": 245.36,
      "notification_email": "email@domain.com",
      "status_id": 1,
      "status_code": 1,
      "note": "some note",
      "notification_days_before_due_date": 3,
      "notification_days_after_due_date": 7,
      "notification_on_due_date": true,
      "send_text_to_pay": true,
      "files": [
        null
      ],
      "remaining_balance": 245.36,
      "single_payment_min_amount": 500,
      "single_payment_max_amount": 500000,
      "cell_phone": "3339998822",
      "tags": [
        "Walk-in Customer"
      ],
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "payment_status_id": 1,
      "is_active": true
    },
    "log_emails": [
      {
        "subject": "Payment Receipt - 12skiestech",
        "body": "This email is being sent from a server.",
        "source_address": "\"12skiestech A7t3qi\" <noreply@zeamster.email>",
        "return_path": "\"12skiestech A7t3qi\" <noreply@zeamster.email>",
        "provider_id": "0100017e67bcc530-e1dd23b4-8a39-4a5b-8d5d-68d51c4c942f-000000",
        "domain_id": "11e95f8ec39de8fbdb0a4f1a",
        "reason_sent": "Contact Email",
        "reason_model": "Transaction",
        "reason_model_id": "11e95f8ec39de8fbdb0a4f1a",
        "reply_to": "\"Zeamster\" <emma.p@zeamster.com>",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992
      }
    ],
    "is_voidable": true,
    "is_reversible": true,
    "is_refundable": true,
    "is_completable": true,
    "is_settled": true,
    "created_user": {
      "account_number": "5454545454545454",
      "branding_domain_url": "{branding_domain_url}",
      "cell_phone": "3339998822",
      "company_name": "Fortis Payment Systems, LLC",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "date_of_birth": "2021-12-01",
      "domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "email": "email@domain.com",
      "email_trx_receipt": true,
      "home_phone": "3339998822",
      "first_name": "John",
      "last_name": "Smith",
      "locale": "en-US",
      "office_phone": "3339998822",
      "office_ext_phone": "5",
      "primary_location_id": "11e95f8ec39de8fbdb0a4f1a",
      "requires_new_password": null,
      "terms_condition_code": "20220308",
      "tz": "America/New_York",
      "ui_prefs": {
        "entry_page": "dashboard",
        "page_size": 2,
        "report_export_type": "csv",
        "process_method": "virtual_terminal",
        "default_terminal": "11e95f8ec39de8fbdb0a4f1a"
      },
      "username": "{user_name}",
      "user_api_key": "234bas8dfn8238f923w2",
      "user_hash_key": null,
      "user_type_code": 100,
      "password": null,
      "zip": "48375",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "status_code": 1,
      "api_only": false,
      "is_invitation": false,
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "status": true,
      "login_attempts": 0,
      "last_login_ts": 1422040992,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "terms_accepted_ts": 1422040992,
      "terms_agree_ip": "192.168.0.10",
      "current_date_time": "2019-03-11T10:38:26-0700",
      "current_login": 1422040992,
      "log_api_response_body_ts": 1422040992
    },
    "location": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "account_number": "5454545454545454",
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "branding_domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_email_trx_receipt_default": true,
      "default_ach": "11e608a7d515f1e093242bb2",
      "default_cc": "11e608a442a5f1e092242dda",
      "email_reply_to": "email@domain.com",
      "fax": "3339998822",
      "location_api_id": "location-111111",
      "location_api_key": "AE34BBCAADF4AE34BBCAADF4",
      "location_c1": "custom 1",
      "location_c2": "custom 2",
      "location_c3": "custom data 3",
      "name": "Sample Company Headquarters",
      "office_phone": "2481234567",
      "office_ext_phone": "1021021209",
      "tz": "America/New_York",
      "parent_id": "11e95f8ec39de8fbdb0a4f1a",
      "show_contact_notes": true,
      "show_contact_files": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_type": "merchant",
      "ticket_hash_key": "A5F443CADF4AE34BBCAADF4"
    },
    "contact": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_number": "54545433332",
      "contact_api_id": "137",
      "first_name": "John",
      "last_name": "Smith",
      "cell_phone": "3339998822",
      "balance": 245.36,
      "address": {
        "city": "Novi",
        "state": "Michigan",
        "postal_code": "48375",
        "country": "US"
      },
      "company_name": "Fortis Payment Systems, LLC",
      "header_message": "This is a sample message for you",
      "date_of_birth": "2021-12-01",
      "email_trx_receipt": true,
      "home_phone": "3339998822",
      "office_phone": "3339998822",
      "office_phone_ext": "5",
      "header_message_type": 0,
      "update_if_exists": 1,
      "contact_c1": "any",
      "contact_c2": "anything",
      "contact_c3": "something",
      "parent_id": "11e95f8ec39de8fbdb0a4f1a",
      "email": "email@domain.com",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "active": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "changelogs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "action": "CREATE",
        "model": "TransactionRequest",
        "model_id": "11ec829598f0d4008be9aba4",
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_details": [
          {
            "id": "11e95f8ec39de8fbdb0a4f1a",
            "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
            "field": "next_run_ts",
            "old_value": "1643616000"
          }
        ],
        "user": {
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "username": "email@domain.com",
          "first_name": "Bob",
          "last_name": "Fairview"
        }
      }
    ],
    "product_transaction": {
      "processor_version": "1_0_0",
      "title": "My terminal",
      "payment_method": "cc",
      "processor": "zgate",
      "mcc": "1111",
      "tax_surcharge_config": 2,
      "partner": "standalone",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "surcharge": {},
      "processor_data": {},
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
      "dup_check_per_batch": null,
      "paylink_allow": false,
      "quick_invoice_allow": false,
      "level3_allow": false,
      "payfac_enable": false,
      "sales_office_id": "11e95f8ec39de8fbdb0a4f1a",
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
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "product_transaction_api_id": "11e95f8ec39de8fbdb0a4f1a",
      "is_secondary_amount_allowed": false,
      "batch_risk_config": {},
      "fortis_id": "8149742",
      "product_billing_group_code": "nofees",
      "cau_subscribe_type_code": 0
    },
    "all_tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "tagTransactions": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "tag_id": "Tag ID",
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "declined_recurring_notification": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_ts": 1422040992,
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "payment_recurring_notification": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_ts": 1422040992,
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "developer_company": {
      "title": "My terminal",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "terminal": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "default_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_application_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_cvm_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_manufacturer_code": "1",
      "title": "My terminal",
      "mac_address": "3D:F2:C9:A6:B3:4F",
      "local_ip_address": "192.168.0.10",
      "port": 10009,
      "serial_number": "1234567890",
      "terminal_number": "973456789012367",
      "terminal_timeouts": {
        "card_entry_timeout": 47,
        "device_terms_prompt_timeout": 30,
        "overall_timeout": 125,
        "pin_entry_timeout": 40,
        "signature_input_timeout": 35,
        "signature_submit_timeout": 38,
        "status_display_time": 12,
        "tip_cashback_timeout": 25,
        "transaction_timeout": 17
      },
      "tip_percents": {
        "percent_1": 0,
        "percent_2": 2,
        "percent_3": 99
      },
      "header_line_1": "line 1 sample",
      "header_line_2": "line 2 sample",
      "header_line_3": "line 3 sample",
      "header_line_4": "line 4 sample",
      "header_line_5": "line 5 sample",
      "trailer_line_1": "trailer 1 sample",
      "trailer_line_2": "trailer 2 sample",
      "trailer_line_3": "trailer 3 sample",
      "trailer_line_4": "trailer 4 sample",
      "trailer_line_5": "trailer 5 sample",
      "default_checkin": "2021-12-01",
      "default_checkout": "2021-12-01",
      "default_room_rate": 56,
      "default_room_number": "303",
      "debit": false,
      "emv": false,
      "cashback_enable": false,
      "print_enable": false,
      "sig_capture_enable": false,
      "is_provisioned": false,
      "tip_enable": false,
      "validated_decryption": false,
      "communication_type": "http",
      "active": true,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "last_registration_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "hosted_payment_page": {
      "user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_api_id": null,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": "Sample title",
      "redirect_url_delay": 15,
      "min_payment_amount": 0,
      "max_payment_amount": 9999999999,
      "redirect_url_on_approve": null,
      "redirect_url_on_decline": null,
      "field_configuration": {
        "css_mini": true,
        "stack": "vertical",
        "header": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        },
        "body": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        },
        "footer": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        }
      },
      "encryption_key": null,
      "stylesheet_url": null,
      "parent_send_message": true,
      "hide_optional_fields": true,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "transaction_level3": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "level3_data": {
        "destination_country_code": "840",
        "duty_amount": 0,
        "freight_amount": 0,
        "national_tax": 2,
        "sales_tax": 200,
        "shipfrom_zip_code": "AZ1234",
        "shipto_zip_code": "FL1234",
        "tax_amount": 10,
        "tax_exempt": "0",
        "customer_vat_registration": "12345678",
        "merchant_vat_registration": "123456",
        "order_date": "171006",
        "summary_commodity_code": "C1K2",
        "tax_rate": 0,
        "unique_vat_ref_number": "vat1234",
        "line_items": [
          {
            "description": "cool drink",
            "commodity_code": "cc123456",
            "discount_amount": 0,
            "other_tax_amount": 0,
            "product_code": "fanta123456",
            "quantity": 12,
            "tax_amount": 4,
            "tax_rate": 0,
            "unit_code": "gll",
            "unit_cost": 3,
            "alternate_tax_id": "1234",
            "debit_credit": "C",
            "discount_rate": 11,
            "tax_type_applied": "22",
            "tax_type_id": "11"
          }
        ]
      }
    },
    "developer_company_id": "Sample Developer Company ID",
    "transaction_histories": [
      {
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "status_id": 101,
        "event_date_ts": 1422040992,
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "surcharge_transaction": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "model_name": "Model Name",
      "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "surcharge_fee": 0,
      "surcharge_rate": 0,
      "surcharge_amount": null,
      "surcharge_transaction_min": null,
      "surcharge_transaction_max": null,
      "created": 1422040992,
      "modified": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "surcharge": {
      "surcharge_fee": 10,
      "surcharge_rate": 1,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "apply_to_user_type_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": null,
      "surcharge_label": null,
      "surcharge_transaction_product_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "reason_code": {
      "id": 50,
      "title": "Sample Title"
    },
    "type": {
      "id": 50,
      "title": "Sample Title"
    },
    "status": {
      "id": 50,
      "title": "Sample Title"
    },
    "transaction_batch": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "processing_status_id": 2,
      "batch_num": 4,
      "is_open": 0,
      "settlement_file_name": "settement_file.txt",
      "batch_close_ts": 1531423693,
      "batch_close_detail": "BATCH_MISMATCH",
      "total_sale_amount": 2342,
      "total_sale_count": 21,
      "total_refund_amount": 2342,
      "total_refund_count": 18,
      "total_void_amount": 2342,
      "total_void_count": 17,
      "total_blind_refund_amount": 2342,
      "total_blind_refund_count": 16
    },
    "transaction_splits": [
      {
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "contact_id": "11e95f8ec39de8fbdb0a4f1a",
        "amount": 10,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "postback_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
        "next_run_ts": 1422040992,
        "created_ts": 1422040992,
        "model_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "currency_type": {
      "id": 50,
      "title": "Sample Title"
    },
    "transaction_references": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ]
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# ACH Debit

Create a new keyed ACH debit transaction

```csharp
ACHDebitAsync(
    Models.V1TransactionsAchDebitKeyedRequest body,
    List<Models.Expand54Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1TransactionsAchDebitKeyedRequest`](../../doc/models/v1-transactions-ach-debit-keyed-request.md) | Body, Required | - |
| `expand` | [`List<Expand54Enum>`](../../doc/models/expand-54-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
V1TransactionsAchDebitKeyedRequest body = new V1TransactionsAchDebitKeyedRequest
{
    TransactionAmount = 1,
    AccountHolderName = "smith",
    AccountNumber = "24345",
    AccountType = AccountType11Enum.Checking,
    RoutingNumber = "051904524",
    CheckinDate = "2021-12-01",
    CheckoutDate = "2021-12-01",
    ClerkNumber = "AE1234",
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    CustomData = ApiHelper.JsonDeserialize<object>("{\"data1\":\"custom1\",\"data2\":\"custom2\"}"),
    CustomerId = "customerid",
    Description = "some description",
    IiasInd = IiasIndEnum.Enum1,
    ImageFront = "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    ImageBack = "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    Installment = true,
    InstallmentNumber = 1,
    InstallmentCount = 1,
    LocationApiId = "location-api-id-florida-2",
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    AdvanceDeposit = false,
    NoShow = false,
    NotificationEmailAddress = "johnsmith@smiths.com",
    OrderNumber = "433659378839",
    PoNumber = "555555553123",
    QuickInvoiceId = "11e95f8ec39de8fbdb0a4f1a",
    Recurring = false,
    RecurringNumber = 1,
    RoomNum = "303",
    RoomRate = 95,
    SaveAccount = false,
    SaveAccountTitle = "John Account",
    SubtotalAmount = 599,
    SurchargeAmount = 100,
    Tax = 0,
    TipAmount = 0,
    SecondaryAmount = 0,
    TransactionApiId = "transaction-payment-abcd123",
    TransactionC1 = "custom-data-1",
    TransactionC2 = "custom-data-2",
    TransactionC3 = "custom-data-3",
    BankFundedOnlyOverride = false,
    AllowPartialAuthorizationOverride = false,
    AutoDeclineCvvOverride = false,
    AutoDeclineStreetOverride = false,
    AutoDeclineZipOverride = false,
    AchIdentifier = "P",
    AchSecCode = AchSecCode1Enum.C21,
    EffectiveDate = "2021-12-01",
    CheckNumber = "8520748520963",
};

try
{
    ResponseTransaction result = await transactionsACHController.ACHDebitAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Example Response *(as JSON)*

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": 10,
        "account_type": "credit",
        "currency": 840
      }
    ],
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "phone": "3339998822",
      "country": "USA"
    },
    "checkin_date": "2021-12-01",
    "checkout_date": "2021-12-01",
    "clerk_number": "AE1234",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "custom_data": {},
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
    "recurring": {
      "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
      "token_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_vault_api_id": "token1234abcd",
      "token_api_id": "token1234abcd",
      "_joi": {
        "conditions": {}
      },
      "active": true,
      "description": "Description",
      "end_date": "2021-12-01",
      "installment_total_count": 20,
      "interval": 1,
      "interval_type": "d",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "notification_days": 2,
      "payment_method": "cc",
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_api_id": "recurring1234abcd",
      "start_date": "2021-12-01",
      "status": "active",
      "transaction_amount": 300,
      "terms_agree": true,
      "terms_agree_ip": "192.168.0.10",
      "recurring_c1": "recurring custom data 1",
      "recurring_c2": "recurring custom data 2",
      "recurring_c3": "recurring custom data 3",
      "send_to_proc_as_recur": true,
      "tags": [
        "Walk-in Customer"
      ],
      "secondary_amount": 100,
      "currency": "USD",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "next_run_date": "2021-12-01",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "recurring_type_id": "i",
      "installment_amount_total": 99999999,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "recurring_number": 1,
    "room_num": "303",
    "room_rate": 95,
    "save_account": false,
    "save_account_title": "John Account",
    "subtotal_amount": 599,
    "surcharge_amount": 100,
    "tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
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
    "emv_receipt_data": {
      "AID": "a0000000042203",
      "APPLAB": "US Maestro",
      "APPN": "US Maestro",
      "CVM": "Pin Verified",
      "TSI": "e800",
      "TVR": "0800008000"
    },
    "first_six": "545454",
    "last_four": "5454",
    "payment_method": "cc",
    "terminal_serial_number": "1234567890",
    "transaction_settlement_status": null,
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
    "response_message": null,
    "return_date": "2021-12-01",
    "trx_source_id": 8,
    "routing_number": "051904524",
    "trx_source_code": 8,
    "paylink_id": "11e95f8ec39de8fbdb0a4f1a",
    "is_accountvault": true,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "effective_date": "2021-12-01",
    "is_token": true,
    "installment_total": 1,
    "installment_counter": 1,
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "hosted_payment_page_id": "11e95f8ec39de8fbdb0a4f1a",
    "account_vault": {
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
      "billing_address": {
        "city": "Novi",
        "state": "Michigan",
        "postal_code": "48375",
        "phone": "3339998822",
        "country": "USA"
      },
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "customer_id": "123456",
      "identity_verification": {
        "dl_state": "MI",
        "dl_number": "1235567",
        "ssn4": "8527",
        "dob_year": "1980"
      },
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_account_vault_api_id": "previousaccountvault123456",
      "previous_token_api_id": "previousaccountvault123456",
      "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_token_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_number": "545454545454545",
      "terms_agree": true,
      "terms_agree_ip": "192.168.0.10",
      "title": "Test CC Account",
      "_joi": {},
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "account_type": "checking",
      "active": true,
      "cau_summary_status_id": 1,
      "created_ts": 1422040992,
      "e_serial_number": "1234567890",
      "e_track_data": null,
      "e_format": null,
      "e_keyed_data": null,
      "expiring_in_months": null,
      "exp_date": "0722",
      "first_six": "700953",
      "has_recurring": false,
      "last_four": "3657",
      "modified_ts": 1422040992,
      "payment_method": "cc",
      "ticket": null,
      "track_data": null,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "cau_last_updated_ts": 1422040992,
      "routing_number": "051904524"
    },
    "quick_invoice": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": "My terminal",
      "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "due_date": "2021-12-01",
      "item_list": [
        {
          "name": "Bread",
          "amount": 2015
        }
      ],
      "allow_overpayment": true,
      "bank_funded_only_override": true,
      "email": "email@domain.com",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_api_id": "contact12345",
      "quick_invoice_api_id": "quickinvoice12345",
      "customer_id": "11e95f8ec39de8fbdb0a4f1a",
      "expire_date": "2021-12-01",
      "allow_partial_pay": true,
      "attach_files_to_email": true,
      "send_email": true,
      "invoice_number": "invoice12345",
      "item_header": "Quick invoice header sample",
      "item_footer": "Thank you",
      "amount_due": 245.36,
      "notification_email": "email@domain.com",
      "status_id": 1,
      "status_code": 1,
      "note": "some note",
      "notification_days_before_due_date": 3,
      "notification_days_after_due_date": 7,
      "notification_on_due_date": true,
      "send_text_to_pay": true,
      "files": [
        null
      ],
      "remaining_balance": 245.36,
      "single_payment_min_amount": 500,
      "single_payment_max_amount": 500000,
      "cell_phone": "3339998822",
      "tags": [
        "Walk-in Customer"
      ],
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "payment_status_id": 1,
      "is_active": true
    },
    "log_emails": [
      {
        "subject": "Payment Receipt - 12skiestech",
        "body": "This email is being sent from a server.",
        "source_address": "\"12skiestech A7t3qi\" <noreply@zeamster.email>",
        "return_path": "\"12skiestech A7t3qi\" <noreply@zeamster.email>",
        "provider_id": "0100017e67bcc530-e1dd23b4-8a39-4a5b-8d5d-68d51c4c942f-000000",
        "domain_id": "11e95f8ec39de8fbdb0a4f1a",
        "reason_sent": "Contact Email",
        "reason_model": "Transaction",
        "reason_model_id": "11e95f8ec39de8fbdb0a4f1a",
        "reply_to": "\"Zeamster\" <emma.p@zeamster.com>",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992
      }
    ],
    "is_voidable": true,
    "is_reversible": true,
    "is_refundable": true,
    "is_completable": true,
    "is_settled": true,
    "created_user": {
      "account_number": "5454545454545454",
      "branding_domain_url": "{branding_domain_url}",
      "cell_phone": "3339998822",
      "company_name": "Fortis Payment Systems, LLC",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "date_of_birth": "2021-12-01",
      "domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "email": "email@domain.com",
      "email_trx_receipt": true,
      "home_phone": "3339998822",
      "first_name": "John",
      "last_name": "Smith",
      "locale": "en-US",
      "office_phone": "3339998822",
      "office_ext_phone": "5",
      "primary_location_id": "11e95f8ec39de8fbdb0a4f1a",
      "requires_new_password": null,
      "terms_condition_code": "20220308",
      "tz": "America/New_York",
      "ui_prefs": {
        "entry_page": "dashboard",
        "page_size": 2,
        "report_export_type": "csv",
        "process_method": "virtual_terminal",
        "default_terminal": "11e95f8ec39de8fbdb0a4f1a"
      },
      "username": "{user_name}",
      "user_api_key": "234bas8dfn8238f923w2",
      "user_hash_key": null,
      "user_type_code": 100,
      "password": null,
      "zip": "48375",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "status_code": 1,
      "api_only": false,
      "is_invitation": false,
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "status": true,
      "login_attempts": 0,
      "last_login_ts": 1422040992,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "terms_accepted_ts": 1422040992,
      "terms_agree_ip": "192.168.0.10",
      "current_date_time": "2019-03-11T10:38:26-0700",
      "current_login": 1422040992,
      "log_api_response_body_ts": 1422040992
    },
    "location": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "account_number": "5454545454545454",
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "branding_domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_email_trx_receipt_default": true,
      "default_ach": "11e608a7d515f1e093242bb2",
      "default_cc": "11e608a442a5f1e092242dda",
      "email_reply_to": "email@domain.com",
      "fax": "3339998822",
      "location_api_id": "location-111111",
      "location_api_key": "AE34BBCAADF4AE34BBCAADF4",
      "location_c1": "custom 1",
      "location_c2": "custom 2",
      "location_c3": "custom data 3",
      "name": "Sample Company Headquarters",
      "office_phone": "2481234567",
      "office_ext_phone": "1021021209",
      "tz": "America/New_York",
      "parent_id": "11e95f8ec39de8fbdb0a4f1a",
      "show_contact_notes": true,
      "show_contact_files": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_type": "merchant",
      "ticket_hash_key": "A5F443CADF4AE34BBCAADF4"
    },
    "contact": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_number": "54545433332",
      "contact_api_id": "137",
      "first_name": "John",
      "last_name": "Smith",
      "cell_phone": "3339998822",
      "balance": 245.36,
      "address": {
        "city": "Novi",
        "state": "Michigan",
        "postal_code": "48375",
        "country": "US"
      },
      "company_name": "Fortis Payment Systems, LLC",
      "header_message": "This is a sample message for you",
      "date_of_birth": "2021-12-01",
      "email_trx_receipt": true,
      "home_phone": "3339998822",
      "office_phone": "3339998822",
      "office_phone_ext": "5",
      "header_message_type": 0,
      "update_if_exists": 1,
      "contact_c1": "any",
      "contact_c2": "anything",
      "contact_c3": "something",
      "parent_id": "11e95f8ec39de8fbdb0a4f1a",
      "email": "email@domain.com",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "active": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "changelogs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "action": "CREATE",
        "model": "TransactionRequest",
        "model_id": "11ec829598f0d4008be9aba4",
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_details": [
          {
            "id": "11e95f8ec39de8fbdb0a4f1a",
            "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
            "field": "next_run_ts",
            "old_value": "1643616000"
          }
        ],
        "user": {
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "username": "email@domain.com",
          "first_name": "Bob",
          "last_name": "Fairview"
        }
      }
    ],
    "product_transaction": {
      "processor_version": "1_0_0",
      "title": "My terminal",
      "payment_method": "cc",
      "processor": "zgate",
      "mcc": "1111",
      "tax_surcharge_config": 2,
      "partner": "standalone",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "surcharge": {},
      "processor_data": {},
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
      "dup_check_per_batch": null,
      "paylink_allow": false,
      "quick_invoice_allow": false,
      "level3_allow": false,
      "payfac_enable": false,
      "sales_office_id": "11e95f8ec39de8fbdb0a4f1a",
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
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "product_transaction_api_id": "11e95f8ec39de8fbdb0a4f1a",
      "is_secondary_amount_allowed": false,
      "batch_risk_config": {},
      "fortis_id": "8149742",
      "product_billing_group_code": "nofees",
      "cau_subscribe_type_code": 0
    },
    "all_tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "tagTransactions": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "tag_id": "Tag ID",
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "declined_recurring_notification": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_ts": 1422040992,
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "payment_recurring_notification": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_ts": 1422040992,
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "developer_company": {
      "title": "My terminal",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "terminal": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "default_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_application_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_cvm_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_manufacturer_code": "1",
      "title": "My terminal",
      "mac_address": "3D:F2:C9:A6:B3:4F",
      "local_ip_address": "192.168.0.10",
      "port": 10009,
      "serial_number": "1234567890",
      "terminal_number": "973456789012367",
      "terminal_timeouts": {
        "card_entry_timeout": 47,
        "device_terms_prompt_timeout": 30,
        "overall_timeout": 125,
        "pin_entry_timeout": 40,
        "signature_input_timeout": 35,
        "signature_submit_timeout": 38,
        "status_display_time": 12,
        "tip_cashback_timeout": 25,
        "transaction_timeout": 17
      },
      "tip_percents": {
        "percent_1": 0,
        "percent_2": 2,
        "percent_3": 99
      },
      "header_line_1": "line 1 sample",
      "header_line_2": "line 2 sample",
      "header_line_3": "line 3 sample",
      "header_line_4": "line 4 sample",
      "header_line_5": "line 5 sample",
      "trailer_line_1": "trailer 1 sample",
      "trailer_line_2": "trailer 2 sample",
      "trailer_line_3": "trailer 3 sample",
      "trailer_line_4": "trailer 4 sample",
      "trailer_line_5": "trailer 5 sample",
      "default_checkin": "2021-12-01",
      "default_checkout": "2021-12-01",
      "default_room_rate": 56,
      "default_room_number": "303",
      "debit": false,
      "emv": false,
      "cashback_enable": false,
      "print_enable": false,
      "sig_capture_enable": false,
      "is_provisioned": false,
      "tip_enable": false,
      "validated_decryption": false,
      "communication_type": "http",
      "active": true,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "last_registration_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "hosted_payment_page": {
      "user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_api_id": null,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": "Sample title",
      "redirect_url_delay": 15,
      "min_payment_amount": 0,
      "max_payment_amount": 9999999999,
      "redirect_url_on_approve": null,
      "redirect_url_on_decline": null,
      "field_configuration": {
        "css_mini": true,
        "stack": "vertical",
        "header": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        },
        "body": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        },
        "footer": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        }
      },
      "encryption_key": null,
      "stylesheet_url": null,
      "parent_send_message": true,
      "hide_optional_fields": true,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "transaction_level3": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "level3_data": {
        "destination_country_code": "840",
        "duty_amount": 0,
        "freight_amount": 0,
        "national_tax": 2,
        "sales_tax": 200,
        "shipfrom_zip_code": "AZ1234",
        "shipto_zip_code": "FL1234",
        "tax_amount": 10,
        "tax_exempt": "0",
        "customer_vat_registration": "12345678",
        "merchant_vat_registration": "123456",
        "order_date": "171006",
        "summary_commodity_code": "C1K2",
        "tax_rate": 0,
        "unique_vat_ref_number": "vat1234",
        "line_items": [
          {
            "description": "cool drink",
            "commodity_code": "cc123456",
            "discount_amount": 0,
            "other_tax_amount": 0,
            "product_code": "fanta123456",
            "quantity": 12,
            "tax_amount": 4,
            "tax_rate": 0,
            "unit_code": "gll",
            "unit_cost": 3,
            "alternate_tax_id": "1234",
            "debit_credit": "C",
            "discount_rate": 11,
            "tax_type_applied": "22",
            "tax_type_id": "11"
          }
        ]
      }
    },
    "developer_company_id": "Sample Developer Company ID",
    "transaction_histories": [
      {
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "status_id": 101,
        "event_date_ts": 1422040992,
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "surcharge_transaction": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "model_name": "Model Name",
      "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "surcharge_fee": 0,
      "surcharge_rate": 0,
      "surcharge_amount": null,
      "surcharge_transaction_min": null,
      "surcharge_transaction_max": null,
      "created": 1422040992,
      "modified": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "surcharge": {
      "surcharge_fee": 10,
      "surcharge_rate": 1,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "apply_to_user_type_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": null,
      "surcharge_label": null,
      "surcharge_transaction_product_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "reason_code": {
      "id": 50,
      "title": "Sample Title"
    },
    "type": {
      "id": 50,
      "title": "Sample Title"
    },
    "status": {
      "id": 50,
      "title": "Sample Title"
    },
    "transaction_batch": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "processing_status_id": 2,
      "batch_num": 4,
      "is_open": 0,
      "settlement_file_name": "settement_file.txt",
      "batch_close_ts": 1531423693,
      "batch_close_detail": "BATCH_MISMATCH",
      "total_sale_amount": 2342,
      "total_sale_count": 21,
      "total_refund_amount": 2342,
      "total_refund_count": 18,
      "total_void_amount": 2342,
      "total_void_count": 17,
      "total_blind_refund_amount": 2342,
      "total_blind_refund_count": 16
    },
    "transaction_splits": [
      {
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "contact_id": "11e95f8ec39de8fbdb0a4f1a",
        "amount": 10,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "postback_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
        "next_run_ts": 1422040992,
        "created_ts": 1422040992,
        "model_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "currency_type": {
      "id": 50,
      "title": "Sample Title"
    },
    "transaction_references": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ]
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# ACH Debit - Previous Transaction

Create a new ACH debit transaction using previous transaction id

```csharp
ACHDebitPreviousTransactionAsync(
    Models.V1TransactionsAchDebitPrevTrxnRequest body,
    List<Models.Expand54Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1TransactionsAchDebitPrevTrxnRequest`](../../doc/models/v1-transactions-ach-debit-prev-trxn-request.md) | Body, Required | - |
| `expand` | [`List<Expand54Enum>`](../../doc/models/expand-54-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
V1TransactionsAchDebitPrevTrxnRequest body = new V1TransactionsAchDebitPrevTrxnRequest
{
    TransactionAmount = 1,
    PreviousTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    CheckinDate = "2021-12-01",
    CheckoutDate = "2021-12-01",
    ClerkNumber = "AE1234",
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    CustomData = ApiHelper.JsonDeserialize<object>("{\"data1\":\"custom1\",\"data2\":\"custom2\"}"),
    CustomerId = "customerid",
    Description = "some description",
    IiasInd = IiasIndEnum.Enum1,
    ImageFront = "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    ImageBack = "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    Installment = true,
    InstallmentNumber = 1,
    InstallmentCount = 1,
    LocationApiId = "location-api-id-florida-2",
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    AdvanceDeposit = false,
    NoShow = false,
    NotificationEmailAddress = "johnsmith@smiths.com",
    OrderNumber = "433659378839",
    PoNumber = "555555553123",
    QuickInvoiceId = "11e95f8ec39de8fbdb0a4f1a",
    Recurring = false,
    RecurringNumber = 1,
    RoomNum = "303",
    RoomRate = 95,
    SaveAccount = false,
    SaveAccountTitle = "John Account",
    SubtotalAmount = 599,
    SurchargeAmount = 100,
    Tax = 0,
    TipAmount = 0,
    SecondaryAmount = 0,
    TransactionApiId = "transaction-payment-abcd123",
    TransactionC1 = "custom-data-1",
    TransactionC2 = "custom-data-2",
    TransactionC3 = "custom-data-3",
    BankFundedOnlyOverride = false,
    AllowPartialAuthorizationOverride = false,
    AutoDeclineCvvOverride = false,
    AutoDeclineStreetOverride = false,
    AutoDeclineZipOverride = false,
    AchIdentifier = "P",
    AchSecCode = AchSecCode1Enum.C21,
    EffectiveDate = "2021-12-01",
};

try
{
    ResponseTransaction result = await transactionsACHController.ACHDebitPreviousTransactionAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Example Response *(as JSON)*

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": 10,
        "account_type": "credit",
        "currency": 840
      }
    ],
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "phone": "3339998822",
      "country": "USA"
    },
    "checkin_date": "2021-12-01",
    "checkout_date": "2021-12-01",
    "clerk_number": "AE1234",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "custom_data": {},
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
    "recurring": {
      "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
      "token_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_vault_api_id": "token1234abcd",
      "token_api_id": "token1234abcd",
      "_joi": {
        "conditions": {}
      },
      "active": true,
      "description": "Description",
      "end_date": "2021-12-01",
      "installment_total_count": 20,
      "interval": 1,
      "interval_type": "d",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "notification_days": 2,
      "payment_method": "cc",
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_api_id": "recurring1234abcd",
      "start_date": "2021-12-01",
      "status": "active",
      "transaction_amount": 300,
      "terms_agree": true,
      "terms_agree_ip": "192.168.0.10",
      "recurring_c1": "recurring custom data 1",
      "recurring_c2": "recurring custom data 2",
      "recurring_c3": "recurring custom data 3",
      "send_to_proc_as_recur": true,
      "tags": [
        "Walk-in Customer"
      ],
      "secondary_amount": 100,
      "currency": "USD",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "next_run_date": "2021-12-01",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "recurring_type_id": "i",
      "installment_amount_total": 99999999,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "recurring_number": 1,
    "room_num": "303",
    "room_rate": 95,
    "save_account": false,
    "save_account_title": "John Account",
    "subtotal_amount": 599,
    "surcharge_amount": 100,
    "tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
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
    "emv_receipt_data": {
      "AID": "a0000000042203",
      "APPLAB": "US Maestro",
      "APPN": "US Maestro",
      "CVM": "Pin Verified",
      "TSI": "e800",
      "TVR": "0800008000"
    },
    "first_six": "545454",
    "last_four": "5454",
    "payment_method": "cc",
    "terminal_serial_number": "1234567890",
    "transaction_settlement_status": null,
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
    "response_message": null,
    "return_date": "2021-12-01",
    "trx_source_id": 8,
    "routing_number": "051904524",
    "trx_source_code": 8,
    "paylink_id": "11e95f8ec39de8fbdb0a4f1a",
    "is_accountvault": true,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "effective_date": "2021-12-01",
    "is_token": true,
    "installment_total": 1,
    "installment_counter": 1,
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "hosted_payment_page_id": "11e95f8ec39de8fbdb0a4f1a",
    "account_vault": {
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
      "billing_address": {
        "city": "Novi",
        "state": "Michigan",
        "postal_code": "48375",
        "phone": "3339998822",
        "country": "USA"
      },
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "customer_id": "123456",
      "identity_verification": {
        "dl_state": "MI",
        "dl_number": "1235567",
        "ssn4": "8527",
        "dob_year": "1980"
      },
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_account_vault_api_id": "previousaccountvault123456",
      "previous_token_api_id": "previousaccountvault123456",
      "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_token_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_number": "545454545454545",
      "terms_agree": true,
      "terms_agree_ip": "192.168.0.10",
      "title": "Test CC Account",
      "_joi": {},
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "account_type": "checking",
      "active": true,
      "cau_summary_status_id": 1,
      "created_ts": 1422040992,
      "e_serial_number": "1234567890",
      "e_track_data": null,
      "e_format": null,
      "e_keyed_data": null,
      "expiring_in_months": null,
      "exp_date": "0722",
      "first_six": "700953",
      "has_recurring": false,
      "last_four": "3657",
      "modified_ts": 1422040992,
      "payment_method": "cc",
      "ticket": null,
      "track_data": null,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "cau_last_updated_ts": 1422040992,
      "routing_number": "051904524"
    },
    "quick_invoice": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": "My terminal",
      "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "due_date": "2021-12-01",
      "item_list": [
        {
          "name": "Bread",
          "amount": 2015
        }
      ],
      "allow_overpayment": true,
      "bank_funded_only_override": true,
      "email": "email@domain.com",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_api_id": "contact12345",
      "quick_invoice_api_id": "quickinvoice12345",
      "customer_id": "11e95f8ec39de8fbdb0a4f1a",
      "expire_date": "2021-12-01",
      "allow_partial_pay": true,
      "attach_files_to_email": true,
      "send_email": true,
      "invoice_number": "invoice12345",
      "item_header": "Quick invoice header sample",
      "item_footer": "Thank you",
      "amount_due": 245.36,
      "notification_email": "email@domain.com",
      "status_id": 1,
      "status_code": 1,
      "note": "some note",
      "notification_days_before_due_date": 3,
      "notification_days_after_due_date": 7,
      "notification_on_due_date": true,
      "send_text_to_pay": true,
      "files": [
        null
      ],
      "remaining_balance": 245.36,
      "single_payment_min_amount": 500,
      "single_payment_max_amount": 500000,
      "cell_phone": "3339998822",
      "tags": [
        "Walk-in Customer"
      ],
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "payment_status_id": 1,
      "is_active": true
    },
    "log_emails": [
      {
        "subject": "Payment Receipt - 12skiestech",
        "body": "This email is being sent from a server.",
        "source_address": "\"12skiestech A7t3qi\" <noreply@zeamster.email>",
        "return_path": "\"12skiestech A7t3qi\" <noreply@zeamster.email>",
        "provider_id": "0100017e67bcc530-e1dd23b4-8a39-4a5b-8d5d-68d51c4c942f-000000",
        "domain_id": "11e95f8ec39de8fbdb0a4f1a",
        "reason_sent": "Contact Email",
        "reason_model": "Transaction",
        "reason_model_id": "11e95f8ec39de8fbdb0a4f1a",
        "reply_to": "\"Zeamster\" <emma.p@zeamster.com>",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992
      }
    ],
    "is_voidable": true,
    "is_reversible": true,
    "is_refundable": true,
    "is_completable": true,
    "is_settled": true,
    "created_user": {
      "account_number": "5454545454545454",
      "branding_domain_url": "{branding_domain_url}",
      "cell_phone": "3339998822",
      "company_name": "Fortis Payment Systems, LLC",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "date_of_birth": "2021-12-01",
      "domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "email": "email@domain.com",
      "email_trx_receipt": true,
      "home_phone": "3339998822",
      "first_name": "John",
      "last_name": "Smith",
      "locale": "en-US",
      "office_phone": "3339998822",
      "office_ext_phone": "5",
      "primary_location_id": "11e95f8ec39de8fbdb0a4f1a",
      "requires_new_password": null,
      "terms_condition_code": "20220308",
      "tz": "America/New_York",
      "ui_prefs": {
        "entry_page": "dashboard",
        "page_size": 2,
        "report_export_type": "csv",
        "process_method": "virtual_terminal",
        "default_terminal": "11e95f8ec39de8fbdb0a4f1a"
      },
      "username": "{user_name}",
      "user_api_key": "234bas8dfn8238f923w2",
      "user_hash_key": null,
      "user_type_code": 100,
      "password": null,
      "zip": "48375",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "status_code": 1,
      "api_only": false,
      "is_invitation": false,
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "status": true,
      "login_attempts": 0,
      "last_login_ts": 1422040992,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "terms_accepted_ts": 1422040992,
      "terms_agree_ip": "192.168.0.10",
      "current_date_time": "2019-03-11T10:38:26-0700",
      "current_login": 1422040992,
      "log_api_response_body_ts": 1422040992
    },
    "location": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "account_number": "5454545454545454",
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "branding_domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_email_trx_receipt_default": true,
      "default_ach": "11e608a7d515f1e093242bb2",
      "default_cc": "11e608a442a5f1e092242dda",
      "email_reply_to": "email@domain.com",
      "fax": "3339998822",
      "location_api_id": "location-111111",
      "location_api_key": "AE34BBCAADF4AE34BBCAADF4",
      "location_c1": "custom 1",
      "location_c2": "custom 2",
      "location_c3": "custom data 3",
      "name": "Sample Company Headquarters",
      "office_phone": "2481234567",
      "office_ext_phone": "1021021209",
      "tz": "America/New_York",
      "parent_id": "11e95f8ec39de8fbdb0a4f1a",
      "show_contact_notes": true,
      "show_contact_files": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_type": "merchant",
      "ticket_hash_key": "A5F443CADF4AE34BBCAADF4"
    },
    "contact": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_number": "54545433332",
      "contact_api_id": "137",
      "first_name": "John",
      "last_name": "Smith",
      "cell_phone": "3339998822",
      "balance": 245.36,
      "address": {
        "city": "Novi",
        "state": "Michigan",
        "postal_code": "48375",
        "country": "US"
      },
      "company_name": "Fortis Payment Systems, LLC",
      "header_message": "This is a sample message for you",
      "date_of_birth": "2021-12-01",
      "email_trx_receipt": true,
      "home_phone": "3339998822",
      "office_phone": "3339998822",
      "office_phone_ext": "5",
      "header_message_type": 0,
      "update_if_exists": 1,
      "contact_c1": "any",
      "contact_c2": "anything",
      "contact_c3": "something",
      "parent_id": "11e95f8ec39de8fbdb0a4f1a",
      "email": "email@domain.com",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "active": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "changelogs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "action": "CREATE",
        "model": "TransactionRequest",
        "model_id": "11ec829598f0d4008be9aba4",
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_details": [
          {
            "id": "11e95f8ec39de8fbdb0a4f1a",
            "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
            "field": "next_run_ts",
            "old_value": "1643616000"
          }
        ],
        "user": {
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "username": "email@domain.com",
          "first_name": "Bob",
          "last_name": "Fairview"
        }
      }
    ],
    "product_transaction": {
      "processor_version": "1_0_0",
      "title": "My terminal",
      "payment_method": "cc",
      "processor": "zgate",
      "mcc": "1111",
      "tax_surcharge_config": 2,
      "partner": "standalone",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "surcharge": {},
      "processor_data": {},
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
      "dup_check_per_batch": null,
      "paylink_allow": false,
      "quick_invoice_allow": false,
      "level3_allow": false,
      "payfac_enable": false,
      "sales_office_id": "11e95f8ec39de8fbdb0a4f1a",
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
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "product_transaction_api_id": "11e95f8ec39de8fbdb0a4f1a",
      "is_secondary_amount_allowed": false,
      "batch_risk_config": {},
      "fortis_id": "8149742",
      "product_billing_group_code": "nofees",
      "cau_subscribe_type_code": 0
    },
    "all_tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "tagTransactions": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "tag_id": "Tag ID",
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "declined_recurring_notification": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_ts": 1422040992,
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "payment_recurring_notification": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_ts": 1422040992,
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "developer_company": {
      "title": "My terminal",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "terminal": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "default_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_application_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_cvm_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_manufacturer_code": "1",
      "title": "My terminal",
      "mac_address": "3D:F2:C9:A6:B3:4F",
      "local_ip_address": "192.168.0.10",
      "port": 10009,
      "serial_number": "1234567890",
      "terminal_number": "973456789012367",
      "terminal_timeouts": {
        "card_entry_timeout": 47,
        "device_terms_prompt_timeout": 30,
        "overall_timeout": 125,
        "pin_entry_timeout": 40,
        "signature_input_timeout": 35,
        "signature_submit_timeout": 38,
        "status_display_time": 12,
        "tip_cashback_timeout": 25,
        "transaction_timeout": 17
      },
      "tip_percents": {
        "percent_1": 0,
        "percent_2": 2,
        "percent_3": 99
      },
      "header_line_1": "line 1 sample",
      "header_line_2": "line 2 sample",
      "header_line_3": "line 3 sample",
      "header_line_4": "line 4 sample",
      "header_line_5": "line 5 sample",
      "trailer_line_1": "trailer 1 sample",
      "trailer_line_2": "trailer 2 sample",
      "trailer_line_3": "trailer 3 sample",
      "trailer_line_4": "trailer 4 sample",
      "trailer_line_5": "trailer 5 sample",
      "default_checkin": "2021-12-01",
      "default_checkout": "2021-12-01",
      "default_room_rate": 56,
      "default_room_number": "303",
      "debit": false,
      "emv": false,
      "cashback_enable": false,
      "print_enable": false,
      "sig_capture_enable": false,
      "is_provisioned": false,
      "tip_enable": false,
      "validated_decryption": false,
      "communication_type": "http",
      "active": true,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "last_registration_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "hosted_payment_page": {
      "user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_api_id": null,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": "Sample title",
      "redirect_url_delay": 15,
      "min_payment_amount": 0,
      "max_payment_amount": 9999999999,
      "redirect_url_on_approve": null,
      "redirect_url_on_decline": null,
      "field_configuration": {
        "css_mini": true,
        "stack": "vertical",
        "header": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        },
        "body": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        },
        "footer": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        }
      },
      "encryption_key": null,
      "stylesheet_url": null,
      "parent_send_message": true,
      "hide_optional_fields": true,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "transaction_level3": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "level3_data": {
        "destination_country_code": "840",
        "duty_amount": 0,
        "freight_amount": 0,
        "national_tax": 2,
        "sales_tax": 200,
        "shipfrom_zip_code": "AZ1234",
        "shipto_zip_code": "FL1234",
        "tax_amount": 10,
        "tax_exempt": "0",
        "customer_vat_registration": "12345678",
        "merchant_vat_registration": "123456",
        "order_date": "171006",
        "summary_commodity_code": "C1K2",
        "tax_rate": 0,
        "unique_vat_ref_number": "vat1234",
        "line_items": [
          {
            "description": "cool drink",
            "commodity_code": "cc123456",
            "discount_amount": 0,
            "other_tax_amount": 0,
            "product_code": "fanta123456",
            "quantity": 12,
            "tax_amount": 4,
            "tax_rate": 0,
            "unit_code": "gll",
            "unit_cost": 3,
            "alternate_tax_id": "1234",
            "debit_credit": "C",
            "discount_rate": 11,
            "tax_type_applied": "22",
            "tax_type_id": "11"
          }
        ]
      }
    },
    "developer_company_id": "Sample Developer Company ID",
    "transaction_histories": [
      {
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "status_id": 101,
        "event_date_ts": 1422040992,
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "surcharge_transaction": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "model_name": "Model Name",
      "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "surcharge_fee": 0,
      "surcharge_rate": 0,
      "surcharge_amount": null,
      "surcharge_transaction_min": null,
      "surcharge_transaction_max": null,
      "created": 1422040992,
      "modified": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "surcharge": {
      "surcharge_fee": 10,
      "surcharge_rate": 1,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "apply_to_user_type_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": null,
      "surcharge_label": null,
      "surcharge_transaction_product_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "reason_code": {
      "id": 50,
      "title": "Sample Title"
    },
    "type": {
      "id": 50,
      "title": "Sample Title"
    },
    "status": {
      "id": 50,
      "title": "Sample Title"
    },
    "transaction_batch": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "processing_status_id": 2,
      "batch_num": 4,
      "is_open": 0,
      "settlement_file_name": "settement_file.txt",
      "batch_close_ts": 1531423693,
      "batch_close_detail": "BATCH_MISMATCH",
      "total_sale_amount": 2342,
      "total_sale_count": 21,
      "total_refund_amount": 2342,
      "total_refund_count": 18,
      "total_void_amount": 2342,
      "total_void_count": 17,
      "total_blind_refund_amount": 2342,
      "total_blind_refund_count": 16
    },
    "transaction_splits": [
      {
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "contact_id": "11e95f8ec39de8fbdb0a4f1a",
        "amount": 10,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "postback_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
        "next_run_ts": 1422040992,
        "created_ts": 1422040992,
        "model_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "currency_type": {
      "id": 50,
      "title": "Sample Title"
    },
    "transaction_references": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ]
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# ACH Debit - Tokenized

Create a new tokenized ACH debit transaction

```csharp
ACHDebitTokenizedAsync(
    Models.V1TransactionsAchDebitTokenRequest body,
    List<Models.Expand54Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1TransactionsAchDebitTokenRequest`](../../doc/models/v1-transactions-ach-debit-token-request.md) | Body, Required | - |
| `expand` | [`List<Expand54Enum>`](../../doc/models/expand-54-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
V1TransactionsAchDebitTokenRequest body = new V1TransactionsAchDebitTokenRequest
{
    TransactionAmount = 1,
    CheckinDate = "2021-12-01",
    CheckoutDate = "2021-12-01",
    ClerkNumber = "AE1234",
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    CustomData = ApiHelper.JsonDeserialize<object>("{\"data1\":\"custom1\",\"data2\":\"custom2\"}"),
    CustomerId = "customerid",
    Description = "some description",
    IiasInd = IiasIndEnum.Enum1,
    ImageFront = "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    ImageBack = "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    Installment = true,
    InstallmentNumber = 1,
    InstallmentCount = 1,
    LocationApiId = "location-api-id-florida-2",
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    AdvanceDeposit = false,
    NoShow = false,
    NotificationEmailAddress = "johnsmith@smiths.com",
    OrderNumber = "433659378839",
    PoNumber = "555555553123",
    QuickInvoiceId = "11e95f8ec39de8fbdb0a4f1a",
    Recurring = false,
    RecurringNumber = 1,
    RoomNum = "303",
    RoomRate = 95,
    SaveAccount = false,
    SaveAccountTitle = "John Account",
    SubtotalAmount = 599,
    SurchargeAmount = 100,
    Tax = 0,
    TipAmount = 0,
    SecondaryAmount = 0,
    TransactionApiId = "transaction-payment-abcd123",
    TransactionC1 = "custom-data-1",
    TransactionC2 = "custom-data-2",
    TransactionC3 = "custom-data-3",
    BankFundedOnlyOverride = false,
    AllowPartialAuthorizationOverride = false,
    AutoDeclineCvvOverride = false,
    AutoDeclineStreetOverride = false,
    AutoDeclineZipOverride = false,
    AchIdentifier = "P",
    AchSecCode = AchSecCode1Enum.C21,
    EffectiveDate = "2021-12-01",
    AccountVaultId = "11e95f8ec39de8fbdb0a4f1a",
    TokenId = "11e95f8ec39de8fbdb0a4f1a",
};

try
{
    ResponseTransaction result = await transactionsACHController.ACHDebitTokenizedAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Example Response *(as JSON)*

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": 10,
        "account_type": "credit",
        "currency": 840
      }
    ],
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "phone": "3339998822",
      "country": "USA"
    },
    "checkin_date": "2021-12-01",
    "checkout_date": "2021-12-01",
    "clerk_number": "AE1234",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "custom_data": {},
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
    "recurring": {
      "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
      "token_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_vault_api_id": "token1234abcd",
      "token_api_id": "token1234abcd",
      "_joi": {
        "conditions": {}
      },
      "active": true,
      "description": "Description",
      "end_date": "2021-12-01",
      "installment_total_count": 20,
      "interval": 1,
      "interval_type": "d",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "notification_days": 2,
      "payment_method": "cc",
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_api_id": "recurring1234abcd",
      "start_date": "2021-12-01",
      "status": "active",
      "transaction_amount": 300,
      "terms_agree": true,
      "terms_agree_ip": "192.168.0.10",
      "recurring_c1": "recurring custom data 1",
      "recurring_c2": "recurring custom data 2",
      "recurring_c3": "recurring custom data 3",
      "send_to_proc_as_recur": true,
      "tags": [
        "Walk-in Customer"
      ],
      "secondary_amount": 100,
      "currency": "USD",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "next_run_date": "2021-12-01",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "recurring_type_id": "i",
      "installment_amount_total": 99999999,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "recurring_number": 1,
    "room_num": "303",
    "room_rate": 95,
    "save_account": false,
    "save_account_title": "John Account",
    "subtotal_amount": 599,
    "surcharge_amount": 100,
    "tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
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
    "emv_receipt_data": {
      "AID": "a0000000042203",
      "APPLAB": "US Maestro",
      "APPN": "US Maestro",
      "CVM": "Pin Verified",
      "TSI": "e800",
      "TVR": "0800008000"
    },
    "first_six": "545454",
    "last_four": "5454",
    "payment_method": "cc",
    "terminal_serial_number": "1234567890",
    "transaction_settlement_status": null,
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
    "response_message": null,
    "return_date": "2021-12-01",
    "trx_source_id": 8,
    "routing_number": "051904524",
    "trx_source_code": 8,
    "paylink_id": "11e95f8ec39de8fbdb0a4f1a",
    "is_accountvault": true,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "effective_date": "2021-12-01",
    "is_token": true,
    "installment_total": 1,
    "installment_counter": 1,
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "hosted_payment_page_id": "11e95f8ec39de8fbdb0a4f1a",
    "account_vault": {
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
      "billing_address": {
        "city": "Novi",
        "state": "Michigan",
        "postal_code": "48375",
        "phone": "3339998822",
        "country": "USA"
      },
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "customer_id": "123456",
      "identity_verification": {
        "dl_state": "MI",
        "dl_number": "1235567",
        "ssn4": "8527",
        "dob_year": "1980"
      },
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_account_vault_api_id": "previousaccountvault123456",
      "previous_token_api_id": "previousaccountvault123456",
      "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_token_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_number": "545454545454545",
      "terms_agree": true,
      "terms_agree_ip": "192.168.0.10",
      "title": "Test CC Account",
      "_joi": {},
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "account_type": "checking",
      "active": true,
      "cau_summary_status_id": 1,
      "created_ts": 1422040992,
      "e_serial_number": "1234567890",
      "e_track_data": null,
      "e_format": null,
      "e_keyed_data": null,
      "expiring_in_months": null,
      "exp_date": "0722",
      "first_six": "700953",
      "has_recurring": false,
      "last_four": "3657",
      "modified_ts": 1422040992,
      "payment_method": "cc",
      "ticket": null,
      "track_data": null,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "cau_last_updated_ts": 1422040992,
      "routing_number": "051904524"
    },
    "quick_invoice": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": "My terminal",
      "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "due_date": "2021-12-01",
      "item_list": [
        {
          "name": "Bread",
          "amount": 2015
        }
      ],
      "allow_overpayment": true,
      "bank_funded_only_override": true,
      "email": "email@domain.com",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_api_id": "contact12345",
      "quick_invoice_api_id": "quickinvoice12345",
      "customer_id": "11e95f8ec39de8fbdb0a4f1a",
      "expire_date": "2021-12-01",
      "allow_partial_pay": true,
      "attach_files_to_email": true,
      "send_email": true,
      "invoice_number": "invoice12345",
      "item_header": "Quick invoice header sample",
      "item_footer": "Thank you",
      "amount_due": 245.36,
      "notification_email": "email@domain.com",
      "status_id": 1,
      "status_code": 1,
      "note": "some note",
      "notification_days_before_due_date": 3,
      "notification_days_after_due_date": 7,
      "notification_on_due_date": true,
      "send_text_to_pay": true,
      "files": [
        null
      ],
      "remaining_balance": 245.36,
      "single_payment_min_amount": 500,
      "single_payment_max_amount": 500000,
      "cell_phone": "3339998822",
      "tags": [
        "Walk-in Customer"
      ],
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "payment_status_id": 1,
      "is_active": true
    },
    "log_emails": [
      {
        "subject": "Payment Receipt - 12skiestech",
        "body": "This email is being sent from a server.",
        "source_address": "\"12skiestech A7t3qi\" <noreply@zeamster.email>",
        "return_path": "\"12skiestech A7t3qi\" <noreply@zeamster.email>",
        "provider_id": "0100017e67bcc530-e1dd23b4-8a39-4a5b-8d5d-68d51c4c942f-000000",
        "domain_id": "11e95f8ec39de8fbdb0a4f1a",
        "reason_sent": "Contact Email",
        "reason_model": "Transaction",
        "reason_model_id": "11e95f8ec39de8fbdb0a4f1a",
        "reply_to": "\"Zeamster\" <emma.p@zeamster.com>",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992
      }
    ],
    "is_voidable": true,
    "is_reversible": true,
    "is_refundable": true,
    "is_completable": true,
    "is_settled": true,
    "created_user": {
      "account_number": "5454545454545454",
      "branding_domain_url": "{branding_domain_url}",
      "cell_phone": "3339998822",
      "company_name": "Fortis Payment Systems, LLC",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "date_of_birth": "2021-12-01",
      "domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "email": "email@domain.com",
      "email_trx_receipt": true,
      "home_phone": "3339998822",
      "first_name": "John",
      "last_name": "Smith",
      "locale": "en-US",
      "office_phone": "3339998822",
      "office_ext_phone": "5",
      "primary_location_id": "11e95f8ec39de8fbdb0a4f1a",
      "requires_new_password": null,
      "terms_condition_code": "20220308",
      "tz": "America/New_York",
      "ui_prefs": {
        "entry_page": "dashboard",
        "page_size": 2,
        "report_export_type": "csv",
        "process_method": "virtual_terminal",
        "default_terminal": "11e95f8ec39de8fbdb0a4f1a"
      },
      "username": "{user_name}",
      "user_api_key": "234bas8dfn8238f923w2",
      "user_hash_key": null,
      "user_type_code": 100,
      "password": null,
      "zip": "48375",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "status_code": 1,
      "api_only": false,
      "is_invitation": false,
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "status": true,
      "login_attempts": 0,
      "last_login_ts": 1422040992,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "terms_accepted_ts": 1422040992,
      "terms_agree_ip": "192.168.0.10",
      "current_date_time": "2019-03-11T10:38:26-0700",
      "current_login": 1422040992,
      "log_api_response_body_ts": 1422040992
    },
    "location": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "account_number": "5454545454545454",
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "branding_domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_email_trx_receipt_default": true,
      "default_ach": "11e608a7d515f1e093242bb2",
      "default_cc": "11e608a442a5f1e092242dda",
      "email_reply_to": "email@domain.com",
      "fax": "3339998822",
      "location_api_id": "location-111111",
      "location_api_key": "AE34BBCAADF4AE34BBCAADF4",
      "location_c1": "custom 1",
      "location_c2": "custom 2",
      "location_c3": "custom data 3",
      "name": "Sample Company Headquarters",
      "office_phone": "2481234567",
      "office_ext_phone": "1021021209",
      "tz": "America/New_York",
      "parent_id": "11e95f8ec39de8fbdb0a4f1a",
      "show_contact_notes": true,
      "show_contact_files": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_type": "merchant",
      "ticket_hash_key": "A5F443CADF4AE34BBCAADF4"
    },
    "contact": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_number": "54545433332",
      "contact_api_id": "137",
      "first_name": "John",
      "last_name": "Smith",
      "cell_phone": "3339998822",
      "balance": 245.36,
      "address": {
        "city": "Novi",
        "state": "Michigan",
        "postal_code": "48375",
        "country": "US"
      },
      "company_name": "Fortis Payment Systems, LLC",
      "header_message": "This is a sample message for you",
      "date_of_birth": "2021-12-01",
      "email_trx_receipt": true,
      "home_phone": "3339998822",
      "office_phone": "3339998822",
      "office_phone_ext": "5",
      "header_message_type": 0,
      "update_if_exists": 1,
      "contact_c1": "any",
      "contact_c2": "anything",
      "contact_c3": "something",
      "parent_id": "11e95f8ec39de8fbdb0a4f1a",
      "email": "email@domain.com",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "active": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "changelogs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "action": "CREATE",
        "model": "TransactionRequest",
        "model_id": "11ec829598f0d4008be9aba4",
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_details": [
          {
            "id": "11e95f8ec39de8fbdb0a4f1a",
            "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
            "field": "next_run_ts",
            "old_value": "1643616000"
          }
        ],
        "user": {
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "username": "email@domain.com",
          "first_name": "Bob",
          "last_name": "Fairview"
        }
      }
    ],
    "product_transaction": {
      "processor_version": "1_0_0",
      "title": "My terminal",
      "payment_method": "cc",
      "processor": "zgate",
      "mcc": "1111",
      "tax_surcharge_config": 2,
      "partner": "standalone",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "surcharge": {},
      "processor_data": {},
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
      "dup_check_per_batch": null,
      "paylink_allow": false,
      "quick_invoice_allow": false,
      "level3_allow": false,
      "payfac_enable": false,
      "sales_office_id": "11e95f8ec39de8fbdb0a4f1a",
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
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "product_transaction_api_id": "11e95f8ec39de8fbdb0a4f1a",
      "is_secondary_amount_allowed": false,
      "batch_risk_config": {},
      "fortis_id": "8149742",
      "product_billing_group_code": "nofees",
      "cau_subscribe_type_code": 0
    },
    "all_tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "tagTransactions": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "tag_id": "Tag ID",
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "declined_recurring_notification": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_ts": 1422040992,
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "payment_recurring_notification": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_ts": 1422040992,
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "developer_company": {
      "title": "My terminal",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "terminal": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "default_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_application_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_cvm_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_manufacturer_code": "1",
      "title": "My terminal",
      "mac_address": "3D:F2:C9:A6:B3:4F",
      "local_ip_address": "192.168.0.10",
      "port": 10009,
      "serial_number": "1234567890",
      "terminal_number": "973456789012367",
      "terminal_timeouts": {
        "card_entry_timeout": 47,
        "device_terms_prompt_timeout": 30,
        "overall_timeout": 125,
        "pin_entry_timeout": 40,
        "signature_input_timeout": 35,
        "signature_submit_timeout": 38,
        "status_display_time": 12,
        "tip_cashback_timeout": 25,
        "transaction_timeout": 17
      },
      "tip_percents": {
        "percent_1": 0,
        "percent_2": 2,
        "percent_3": 99
      },
      "header_line_1": "line 1 sample",
      "header_line_2": "line 2 sample",
      "header_line_3": "line 3 sample",
      "header_line_4": "line 4 sample",
      "header_line_5": "line 5 sample",
      "trailer_line_1": "trailer 1 sample",
      "trailer_line_2": "trailer 2 sample",
      "trailer_line_3": "trailer 3 sample",
      "trailer_line_4": "trailer 4 sample",
      "trailer_line_5": "trailer 5 sample",
      "default_checkin": "2021-12-01",
      "default_checkout": "2021-12-01",
      "default_room_rate": 56,
      "default_room_number": "303",
      "debit": false,
      "emv": false,
      "cashback_enable": false,
      "print_enable": false,
      "sig_capture_enable": false,
      "is_provisioned": false,
      "tip_enable": false,
      "validated_decryption": false,
      "communication_type": "http",
      "active": true,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "last_registration_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "hosted_payment_page": {
      "user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_api_id": null,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": "Sample title",
      "redirect_url_delay": 15,
      "min_payment_amount": 0,
      "max_payment_amount": 9999999999,
      "redirect_url_on_approve": null,
      "redirect_url_on_decline": null,
      "field_configuration": {
        "css_mini": true,
        "stack": "vertical",
        "header": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        },
        "body": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        },
        "footer": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        }
      },
      "encryption_key": null,
      "stylesheet_url": null,
      "parent_send_message": true,
      "hide_optional_fields": true,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "transaction_level3": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "level3_data": {
        "destination_country_code": "840",
        "duty_amount": 0,
        "freight_amount": 0,
        "national_tax": 2,
        "sales_tax": 200,
        "shipfrom_zip_code": "AZ1234",
        "shipto_zip_code": "FL1234",
        "tax_amount": 10,
        "tax_exempt": "0",
        "customer_vat_registration": "12345678",
        "merchant_vat_registration": "123456",
        "order_date": "171006",
        "summary_commodity_code": "C1K2",
        "tax_rate": 0,
        "unique_vat_ref_number": "vat1234",
        "line_items": [
          {
            "description": "cool drink",
            "commodity_code": "cc123456",
            "discount_amount": 0,
            "other_tax_amount": 0,
            "product_code": "fanta123456",
            "quantity": 12,
            "tax_amount": 4,
            "tax_rate": 0,
            "unit_code": "gll",
            "unit_cost": 3,
            "alternate_tax_id": "1234",
            "debit_credit": "C",
            "discount_rate": 11,
            "tax_type_applied": "22",
            "tax_type_id": "11"
          }
        ]
      }
    },
    "developer_company_id": "Sample Developer Company ID",
    "transaction_histories": [
      {
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "status_id": 101,
        "event_date_ts": 1422040992,
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "surcharge_transaction": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "model_name": "Model Name",
      "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "surcharge_fee": 0,
      "surcharge_rate": 0,
      "surcharge_amount": null,
      "surcharge_transaction_min": null,
      "surcharge_transaction_max": null,
      "created": 1422040992,
      "modified": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "surcharge": {
      "surcharge_fee": 10,
      "surcharge_rate": 1,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "apply_to_user_type_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": null,
      "surcharge_label": null,
      "surcharge_transaction_product_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "reason_code": {
      "id": 50,
      "title": "Sample Title"
    },
    "type": {
      "id": 50,
      "title": "Sample Title"
    },
    "status": {
      "id": 50,
      "title": "Sample Title"
    },
    "transaction_batch": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "processing_status_id": 2,
      "batch_num": 4,
      "is_open": 0,
      "settlement_file_name": "settement_file.txt",
      "batch_close_ts": 1531423693,
      "batch_close_detail": "BATCH_MISMATCH",
      "total_sale_amount": 2342,
      "total_sale_count": 21,
      "total_refund_amount": 2342,
      "total_refund_count": 18,
      "total_void_amount": 2342,
      "total_void_count": 17,
      "total_blind_refund_amount": 2342,
      "total_blind_refund_count": 16
    },
    "transaction_splits": [
      {
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "contact_id": "11e95f8ec39de8fbdb0a4f1a",
        "amount": 10,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "postback_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
        "next_run_ts": 1422040992,
        "created_ts": 1422040992,
        "model_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "currency_type": {
      "id": 50,
      "title": "Sample Title"
    },
    "transaction_references": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ]
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# ACH Refund - Previous Transaction

Create a new ACH refund transaction using previous transaction id

```csharp
ACHRefundPreviousTransactionAsync(
    Models.V1TransactionsAchRefundPrevTrxnRequest body,
    List<Models.Expand54Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1TransactionsAchRefundPrevTrxnRequest`](../../doc/models/v1-transactions-ach-refund-prev-trxn-request.md) | Body, Required | - |
| `expand` | [`List<Expand54Enum>`](../../doc/models/expand-54-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseTransaction>`](../../doc/models/response-transaction.md)

## Example Usage

```csharp
V1TransactionsAchRefundPrevTrxnRequest body = new V1TransactionsAchRefundPrevTrxnRequest
{
    TransactionAmount = 1,
    PreviousTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    CheckinDate = "2021-12-01",
    CheckoutDate = "2021-12-01",
    ClerkNumber = "AE1234",
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    CustomData = ApiHelper.JsonDeserialize<object>("{\"data1\":\"custom1\",\"data2\":\"custom2\"}"),
    CustomerId = "customerid",
    Description = "some description",
    IiasInd = IiasIndEnum.Enum1,
    ImageFront = "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    ImageBack = "U29tZVN0cmluZ09idmlvdXNseU5vdEJhc2U2NEVuY29kZWQ=",
    Installment = true,
    InstallmentNumber = 1,
    InstallmentCount = 1,
    LocationApiId = "location-api-id-florida-2",
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    AdvanceDeposit = false,
    NoShow = false,
    NotificationEmailAddress = "johnsmith@smiths.com",
    OrderNumber = "433659378839",
    PoNumber = "555555553123",
    QuickInvoiceId = "11e95f8ec39de8fbdb0a4f1a",
    Recurring = false,
    RecurringNumber = 1,
    RoomNum = "303",
    RoomRate = 95,
    SaveAccount = false,
    SaveAccountTitle = "John Account",
    SubtotalAmount = 599,
    SurchargeAmount = 100,
    Tax = 0,
    TipAmount = 0,
    SecondaryAmount = 0,
    TransactionApiId = "transaction-payment-abcd123",
    TransactionC1 = "custom-data-1",
    TransactionC2 = "custom-data-2",
    TransactionC3 = "custom-data-3",
    BankFundedOnlyOverride = false,
    AllowPartialAuthorizationOverride = false,
    AutoDeclineCvvOverride = false,
    AutoDeclineStreetOverride = false,
    AutoDeclineZipOverride = false,
    AchIdentifier = "P",
    AchSecCode = AchSecCode1Enum.C21,
    EffectiveDate = "2021-12-01",
};

try
{
    ResponseTransaction result = await transactionsACHController.ACHRefundPreviousTransactionAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Example Response *(as JSON)*

```json
{
  "type": "Transaction",
  "data": {
    "additional_amounts": [
      {
        "type": "cashback",
        "amount": 10,
        "account_type": "credit",
        "currency": 840
      }
    ],
    "billing_address": {
      "city": "Novi",
      "state": "Michigan",
      "postal_code": "48375",
      "phone": "3339998822",
      "country": "USA"
    },
    "checkin_date": "2021-12-01",
    "checkout_date": "2021-12-01",
    "clerk_number": "AE1234",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "custom_data": {},
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
    "recurring": {
      "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
      "token_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_vault_api_id": "token1234abcd",
      "token_api_id": "token1234abcd",
      "_joi": {
        "conditions": {}
      },
      "active": true,
      "description": "Description",
      "end_date": "2021-12-01",
      "installment_total_count": 20,
      "interval": 1,
      "interval_type": "d",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "notification_days": 2,
      "payment_method": "cc",
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_api_id": "recurring1234abcd",
      "start_date": "2021-12-01",
      "status": "active",
      "transaction_amount": 300,
      "terms_agree": true,
      "terms_agree_ip": "192.168.0.10",
      "recurring_c1": "recurring custom data 1",
      "recurring_c2": "recurring custom data 2",
      "recurring_c3": "recurring custom data 3",
      "send_to_proc_as_recur": true,
      "tags": [
        "Walk-in Customer"
      ],
      "secondary_amount": 100,
      "currency": "USD",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "next_run_date": "2021-12-01",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "recurring_type_id": "i",
      "installment_amount_total": 99999999,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "recurring_number": 1,
    "room_num": "303",
    "room_rate": 95,
    "save_account": false,
    "save_account_title": "John Account",
    "subtotal_amount": 599,
    "surcharge_amount": 100,
    "tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
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
    "emv_receipt_data": {
      "AID": "a0000000042203",
      "APPLAB": "US Maestro",
      "APPN": "US Maestro",
      "CVM": "Pin Verified",
      "TSI": "e800",
      "TVR": "0800008000"
    },
    "first_six": "545454",
    "last_four": "5454",
    "payment_method": "cc",
    "terminal_serial_number": "1234567890",
    "transaction_settlement_status": null,
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
    "response_message": null,
    "return_date": "2021-12-01",
    "trx_source_id": 8,
    "routing_number": "051904524",
    "trx_source_code": 8,
    "paylink_id": "11e95f8ec39de8fbdb0a4f1a",
    "is_accountvault": true,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "effective_date": "2021-12-01",
    "is_token": true,
    "installment_total": 1,
    "installment_counter": 1,
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "hosted_payment_page_id": "11e95f8ec39de8fbdb0a4f1a",
    "account_vault": {
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
      "billing_address": {
        "city": "Novi",
        "state": "Michigan",
        "postal_code": "48375",
        "phone": "3339998822",
        "country": "USA"
      },
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "customer_id": "123456",
      "identity_verification": {
        "dl_state": "MI",
        "dl_number": "1235567",
        "ssn4": "8527",
        "dob_year": "1980"
      },
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_account_vault_api_id": "previousaccountvault123456",
      "previous_token_api_id": "previousaccountvault123456",
      "previous_account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_token_id": "11e95f8ec39de8fbdb0a4f1a",
      "previous_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_number": "545454545454545",
      "terms_agree": true,
      "terms_agree_ip": "192.168.0.10",
      "title": "Test CC Account",
      "_joi": {},
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "account_type": "checking",
      "active": true,
      "cau_summary_status_id": 1,
      "created_ts": 1422040992,
      "e_serial_number": "1234567890",
      "e_track_data": null,
      "e_format": null,
      "e_keyed_data": null,
      "expiring_in_months": null,
      "exp_date": "0722",
      "first_six": "700953",
      "has_recurring": false,
      "last_four": "3657",
      "modified_ts": 1422040992,
      "payment_method": "cc",
      "ticket": null,
      "track_data": null,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "cau_last_updated_ts": 1422040992,
      "routing_number": "051904524"
    },
    "quick_invoice": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": "My terminal",
      "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "due_date": "2021-12-01",
      "item_list": [
        {
          "name": "Bread",
          "amount": 2015
        }
      ],
      "allow_overpayment": true,
      "bank_funded_only_override": true,
      "email": "email@domain.com",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_api_id": "contact12345",
      "quick_invoice_api_id": "quickinvoice12345",
      "customer_id": "11e95f8ec39de8fbdb0a4f1a",
      "expire_date": "2021-12-01",
      "allow_partial_pay": true,
      "attach_files_to_email": true,
      "send_email": true,
      "invoice_number": "invoice12345",
      "item_header": "Quick invoice header sample",
      "item_footer": "Thank you",
      "amount_due": 245.36,
      "notification_email": "email@domain.com",
      "status_id": 1,
      "status_code": 1,
      "note": "some note",
      "notification_days_before_due_date": 3,
      "notification_days_after_due_date": 7,
      "notification_on_due_date": true,
      "send_text_to_pay": true,
      "files": [
        null
      ],
      "remaining_balance": 245.36,
      "single_payment_min_amount": 500,
      "single_payment_max_amount": 500000,
      "cell_phone": "3339998822",
      "tags": [
        "Walk-in Customer"
      ],
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "payment_status_id": 1,
      "is_active": true
    },
    "log_emails": [
      {
        "subject": "Payment Receipt - 12skiestech",
        "body": "This email is being sent from a server.",
        "source_address": "\"12skiestech A7t3qi\" <noreply@zeamster.email>",
        "return_path": "\"12skiestech A7t3qi\" <noreply@zeamster.email>",
        "provider_id": "0100017e67bcc530-e1dd23b4-8a39-4a5b-8d5d-68d51c4c942f-000000",
        "domain_id": "11e95f8ec39de8fbdb0a4f1a",
        "reason_sent": "Contact Email",
        "reason_model": "Transaction",
        "reason_model_id": "11e95f8ec39de8fbdb0a4f1a",
        "reply_to": "\"Zeamster\" <emma.p@zeamster.com>",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992
      }
    ],
    "is_voidable": true,
    "is_reversible": true,
    "is_refundable": true,
    "is_completable": true,
    "is_settled": true,
    "created_user": {
      "account_number": "5454545454545454",
      "branding_domain_url": "{branding_domain_url}",
      "cell_phone": "3339998822",
      "company_name": "Fortis Payment Systems, LLC",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "date_of_birth": "2021-12-01",
      "domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "email": "email@domain.com",
      "email_trx_receipt": true,
      "home_phone": "3339998822",
      "first_name": "John",
      "last_name": "Smith",
      "locale": "en-US",
      "office_phone": "3339998822",
      "office_ext_phone": "5",
      "primary_location_id": "11e95f8ec39de8fbdb0a4f1a",
      "requires_new_password": null,
      "terms_condition_code": "20220308",
      "tz": "America/New_York",
      "ui_prefs": {
        "entry_page": "dashboard",
        "page_size": 2,
        "report_export_type": "csv",
        "process_method": "virtual_terminal",
        "default_terminal": "11e95f8ec39de8fbdb0a4f1a"
      },
      "username": "{user_name}",
      "user_api_key": "234bas8dfn8238f923w2",
      "user_hash_key": null,
      "user_type_code": 100,
      "password": null,
      "zip": "48375",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "status_code": 1,
      "api_only": false,
      "is_invitation": false,
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "status": true,
      "login_attempts": 0,
      "last_login_ts": 1422040992,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "terms_accepted_ts": 1422040992,
      "terms_agree_ip": "192.168.0.10",
      "current_date_time": "2019-03-11T10:38:26-0700",
      "current_login": 1422040992,
      "log_api_response_body_ts": 1422040992
    },
    "location": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "account_number": "5454545454545454",
      "address": {
        "city": "Novi",
        "state": "MI",
        "postal_code": "48375",
        "country": "US"
      },
      "branding_domain_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_email_trx_receipt_default": true,
      "default_ach": "11e608a7d515f1e093242bb2",
      "default_cc": "11e608a442a5f1e092242dda",
      "email_reply_to": "email@domain.com",
      "fax": "3339998822",
      "location_api_id": "location-111111",
      "location_api_key": "AE34BBCAADF4AE34BBCAADF4",
      "location_c1": "custom 1",
      "location_c2": "custom 2",
      "location_c3": "custom data 3",
      "name": "Sample Company Headquarters",
      "office_phone": "2481234567",
      "office_ext_phone": "1021021209",
      "tz": "America/New_York",
      "parent_id": "11e95f8ec39de8fbdb0a4f1a",
      "show_contact_notes": true,
      "show_contact_files": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_type": "merchant",
      "ticket_hash_key": "A5F443CADF4AE34BBCAADF4"
    },
    "contact": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "account_number": "54545433332",
      "contact_api_id": "137",
      "first_name": "John",
      "last_name": "Smith",
      "cell_phone": "3339998822",
      "balance": 245.36,
      "address": {
        "city": "Novi",
        "state": "Michigan",
        "postal_code": "48375",
        "country": "US"
      },
      "company_name": "Fortis Payment Systems, LLC",
      "header_message": "This is a sample message for you",
      "date_of_birth": "2021-12-01",
      "email_trx_receipt": true,
      "home_phone": "3339998822",
      "office_phone": "3339998822",
      "office_phone_ext": "5",
      "header_message_type": 0,
      "update_if_exists": 1,
      "contact_c1": "any",
      "contact_c2": "anything",
      "contact_c3": "something",
      "parent_id": "11e95f8ec39de8fbdb0a4f1a",
      "email": "email@domain.com",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "active": true,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "changelogs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "action": "CREATE",
        "model": "TransactionRequest",
        "model_id": "11ec829598f0d4008be9aba4",
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_details": [
          {
            "id": "11e95f8ec39de8fbdb0a4f1a",
            "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
            "field": "next_run_ts",
            "old_value": "1643616000"
          }
        ],
        "user": {
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "username": "email@domain.com",
          "first_name": "Bob",
          "last_name": "Fairview"
        }
      }
    ],
    "product_transaction": {
      "processor_version": "1_0_0",
      "title": "My terminal",
      "payment_method": "cc",
      "processor": "zgate",
      "mcc": "1111",
      "tax_surcharge_config": 2,
      "partner": "standalone",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "surcharge": {},
      "processor_data": {},
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
      "dup_check_per_batch": null,
      "paylink_allow": false,
      "quick_invoice_allow": false,
      "level3_allow": false,
      "payfac_enable": false,
      "sales_office_id": "11e95f8ec39de8fbdb0a4f1a",
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
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "product_transaction_api_id": "11e95f8ec39de8fbdb0a4f1a",
      "is_secondary_amount_allowed": false,
      "batch_risk_config": {},
      "fortis_id": "8149742",
      "product_billing_group_code": "nofees",
      "cau_subscribe_type_code": 0
    },
    "all_tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "tagTransactions": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "tag_id": "Tag ID",
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "declined_recurring_notification": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_ts": 1422040992,
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "payment_recurring_notification": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_ts": 1422040992,
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "developer_company": {
      "title": "My terminal",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "terminal": {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "default_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_application_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_cvm_id": "11e95f8ec39de8fbdb0a4f1a",
      "terminal_manufacturer_code": "1",
      "title": "My terminal",
      "mac_address": "3D:F2:C9:A6:B3:4F",
      "local_ip_address": "192.168.0.10",
      "port": 10009,
      "serial_number": "1234567890",
      "terminal_number": "973456789012367",
      "terminal_timeouts": {
        "card_entry_timeout": 47,
        "device_terms_prompt_timeout": 30,
        "overall_timeout": 125,
        "pin_entry_timeout": 40,
        "signature_input_timeout": 35,
        "signature_submit_timeout": 38,
        "status_display_time": 12,
        "tip_cashback_timeout": 25,
        "transaction_timeout": 17
      },
      "tip_percents": {
        "percent_1": 0,
        "percent_2": 2,
        "percent_3": 99
      },
      "header_line_1": "line 1 sample",
      "header_line_2": "line 2 sample",
      "header_line_3": "line 3 sample",
      "header_line_4": "line 4 sample",
      "header_line_5": "line 5 sample",
      "trailer_line_1": "trailer 1 sample",
      "trailer_line_2": "trailer 2 sample",
      "trailer_line_3": "trailer 3 sample",
      "trailer_line_4": "trailer 4 sample",
      "trailer_line_5": "trailer 5 sample",
      "default_checkin": "2021-12-01",
      "default_checkout": "2021-12-01",
      "default_room_rate": 56,
      "default_room_number": "303",
      "debit": false,
      "emv": false,
      "cashback_enable": false,
      "print_enable": false,
      "sig_capture_enable": false,
      "is_provisioned": false,
      "tip_enable": false,
      "validated_decryption": false,
      "communication_type": "http",
      "active": true,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "last_registration_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "hosted_payment_page": {
      "user_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_api_id": null,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": "Sample title",
      "redirect_url_delay": 15,
      "min_payment_amount": 0,
      "max_payment_amount": 9999999999,
      "redirect_url_on_approve": null,
      "redirect_url_on_decline": null,
      "field_configuration": {
        "css_mini": true,
        "stack": "vertical",
        "header": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        },
        "body": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        },
        "footer": {
          "settings": {
            "enabled": true,
            "columns": 1,
            "rows": 1
          },
          "fields": [
            {
              "id": "transaction_amount",
              "label": "Header",
              "field_type": "heading",
              "position": [
                "1"
              ],
              "required": true,
              "readonly": true,
              "visible": true
            }
          ]
        }
      },
      "encryption_key": null,
      "stylesheet_url": null,
      "parent_send_message": true,
      "hide_optional_fields": true,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "transaction_level3": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "level3_data": {
        "destination_country_code": "840",
        "duty_amount": 0,
        "freight_amount": 0,
        "national_tax": 2,
        "sales_tax": 200,
        "shipfrom_zip_code": "AZ1234",
        "shipto_zip_code": "FL1234",
        "tax_amount": 10,
        "tax_exempt": "0",
        "customer_vat_registration": "12345678",
        "merchant_vat_registration": "123456",
        "order_date": "171006",
        "summary_commodity_code": "C1K2",
        "tax_rate": 0,
        "unique_vat_ref_number": "vat1234",
        "line_items": [
          {
            "description": "cool drink",
            "commodity_code": "cc123456",
            "discount_amount": 0,
            "other_tax_amount": 0,
            "product_code": "fanta123456",
            "quantity": 12,
            "tax_amount": 4,
            "tax_rate": 0,
            "unit_code": "gll",
            "unit_cost": 3,
            "alternate_tax_id": "1234",
            "debit_credit": "C",
            "discount_rate": 11,
            "tax_type_applied": "22",
            "tax_type_id": "11"
          }
        ]
      }
    },
    "developer_company_id": "Sample Developer Company ID",
    "transaction_histories": [
      {
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "status_id": 101,
        "event_date_ts": 1422040992,
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "surcharge_transaction": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "model_name": "Model Name",
      "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "surcharge_fee": 0,
      "surcharge_rate": 0,
      "surcharge_amount": null,
      "surcharge_transaction_min": null,
      "surcharge_transaction_max": null,
      "created": 1422040992,
      "modified": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "surcharge": {
      "surcharge_fee": 10,
      "surcharge_rate": 1,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "apply_to_user_type_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": null,
      "surcharge_label": null,
      "surcharge_transaction_product_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "reason_code": {
      "id": 50,
      "title": "Sample Title"
    },
    "type": {
      "id": 50,
      "title": "Sample Title"
    },
    "status": {
      "id": 50,
      "title": "Sample Title"
    },
    "transaction_batch": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "processing_status_id": 2,
      "batch_num": 4,
      "is_open": 0,
      "settlement_file_name": "settement_file.txt",
      "batch_close_ts": 1531423693,
      "batch_close_detail": "BATCH_MISMATCH",
      "total_sale_amount": 2342,
      "total_sale_count": 21,
      "total_refund_amount": 2342,
      "total_refund_count": 18,
      "total_void_amount": 2342,
      "total_void_count": 17,
      "total_blind_refund_amount": 2342,
      "total_blind_refund_count": 16
    },
    "transaction_splits": [
      {
        "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "contact_id": "11e95f8ec39de8fbdb0a4f1a",
        "amount": 10,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "postback_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
        "next_run_ts": 1422040992,
        "created_ts": 1422040992,
        "model_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "currency_type": {
      "id": 50,
      "title": "Sample Title"
    },
    "transaction_references": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ]
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |

