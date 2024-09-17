# Quick Invoices

```csharp
QuickInvoicesController quickInvoicesController = client.QuickInvoicesController;
```

## Class Name

`QuickInvoicesController`

## Methods

* [Create a New Quick Invoice](../../doc/controllers/quick-invoices.md#create-a-new-quick-invoice)
* [List All Quick Invoices Related](../../doc/controllers/quick-invoices.md#list-all-quick-invoices-related)
* [Resend](../../doc/controllers/quick-invoices.md#resend)
* [Associate Transaction With Ouick Invoice](../../doc/controllers/quick-invoices.md#associate-transaction-with-ouick-invoice)
* [Remove Transaction From Quick Invoice](../../doc/controllers/quick-invoices.md#remove-transaction-from-quick-invoice)
* [Delete Quick Invoice](../../doc/controllers/quick-invoices.md#delete-quick-invoice)
* [View Single Quick Invoice Record](../../doc/controllers/quick-invoices.md#view-single-quick-invoice-record)
* [Update Quick Invoice](../../doc/controllers/quick-invoices.md#update-quick-invoice)
* [Reopen Quick Invoice](../../doc/controllers/quick-invoices.md#reopen-quick-invoice)


# Create a New Quick Invoice

```csharp
CreateANewQuickInvoiceAsync(
    Models.V1QuickInvoicesRequest body,
    List<Models.Expand14Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1QuickInvoicesRequest`](../../doc/models/v1-quick-invoices-request.md) | Body, Required | - |
| `expand` | [`List<Expand14Enum>`](../../doc/models/expand-14-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseQuickInvoice>`](../../doc/models/response-quick-invoice.md)

## Example Usage

```csharp
V1QuickInvoicesRequest body = new V1QuickInvoicesRequest
{
    Title = "My terminal",
    DueDate = "2021-12-01",
    ItemList = new List<Models.ItemList>
    {
        new ItemList
        {
            Name = "Bread",
            Amount = 2015,
        },
    },
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    CcProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    AchProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    AllowOverpayment = true,
    BankFundedOnlyOverride = true,
    Email = "email@domain.com",
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    ContactApiId = "contact12345",
    QuickInvoiceApiId = "quickinvoice12345",
    CustomerId = "11e95f8ec39de8fbdb0a4f1a",
    ExpireDate = "2021-12-01",
    AllowPartialPay = true,
    AttachFilesToEmail = true,
    SendEmail = true,
    InvoiceNumber = "invoice12345",
    ItemHeader = "Quick invoice header sample",
    ItemFooter = "Thank you",
    AmountDue = 24536,
    NotificationEmail = "email@domain.com",
    StatusId = 1,
    StatusCode = 1,
    Note = "some note",
    NotificationDaysBeforeDueDate = 3,
    NotificationDaysAfterDueDate = 7,
    NotificationOnDueDate = true,
    SendTextToPay = true,
    RemainingBalance = 24536,
    SinglePaymentMinAmount = 500,
    SinglePaymentMaxAmount = 500000,
    CellPhone = "3339998822",
};

try
{
    ResponseQuickInvoice result = await quickInvoicesController.CreateANewQuickInvoiceAsync(body);
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
  "type": "QuickInvoice",
  "data": {
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
      {
        "file": {},
        "resource_id": "11e95f8ec39de8fbdb0a4f1a",
        "resource": "Contact",
        "product_file_id": "11e95f8ec39de8fbdb0a4f1a",
        "file_category_id": "11e95f8ec39de8fbdb0a4f1a",
        "visibility_group_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "remaining_balance": 245.36,
    "single_payment_min_amount": 500,
    "single_payment_max_amount": 500000,
    "cell_phone": "3339998822",
    "tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": true,
    "payment_status_id": 1,
    "is_active": true,
    "quick_invoice_setting": {
      "location_api_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "quick_invoice_template": "<html>Template<html>",
      "default_allow_partial_pay": true,
      "default_notification_on_due_date": true,
      "default_notification_days_after_due_date": 7,
      "default_notification_days_before_due_date": 3,
      "id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "quick_invoice_views": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "quick_invoice_id": "Quick Invoice ID",
        "created_ts": 1422040992
      }
    ],
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
    "modified_user": {
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
    "log_sms": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "body": " ",
      "reason_model": " ",
      "reason_model_id": " ",
      "provider_id": " ",
      "status": " ",
      "sender": " ",
      "recipient": " ",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "transactions": [
      {
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
        "identity_verification": {
          "dl_state": "MI",
          "dl_number": "1235567",
          "dob_year": "1980"
        },
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
        "recurring": false,
        "recurring_number": 1,
        "room_num": "303",
        "room_rate": 95,
        "save_account": false,
        "save_account_title": "John Account",
        "subtotal_amount": 599,
        "surcharge_amount": 100,
        "tags": [
          "Walk-in Customer"
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
        "hosted_payment_page_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "cc_product_transaction": {
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
    "ach_product_transaction": {
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
    "email_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    },
    "sms_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# List All Quick Invoices Related

```csharp
ListAllQuickInvoicesRelatedAsync(
    Models.Page page = null,
    List<Models.Order19> order = null,
    List<Models.FilterBy> filterBy = null,
    List<Models.Expand14Enum> expand = null,
    Models.Format1Enum? format = null,
    string typeahead = null,
    List<Models.Field37Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `order` | [`List<Order19>`](../../doc/models/order-19.md) | Query, Optional | Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json.<br><br>> /endpoint?order=[{ "key": "created_ts", "operator": "asc"}]<br>> <br>> /endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] |
| `filterBy` | [`List<FilterBy>`](../../doc/models/filter-by.md) | Query, Optional | Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.<br><br>> /endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }]<br>> <br>> /endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }]<br>> <br>> /endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }]<br>> <br>> /endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] |
| `expand` | [`List<Expand14Enum>`](../../doc/models/expand-14-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `format` | [`Format1Enum?`](../../doc/models/format-1-enum.md) | Query, Optional | Reporting format, valid values: csv, tsv |
| `typeahead` | `string` | Query, Optional | You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains. |
| `fields` | [`List<Field37Enum>`](../../doc/models/field-37-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseQuickInvoicesCollection>`](../../doc/models/response-quick-invoices-collection.md)

## Example Usage

```csharp
Page page = new Page
{
    Number = 1,
    Size = 50,
};

List<Models.Order19> order = new List<Models.Order19>
{
    new Order19
    {
        Key = "first_name",
        MOperator = OperatorEnum.Asc,
    },
};

List<Models.FilterBy> filterBy = new List<Models.FilterBy>
{
    new FilterBy
    {
        Key = "first_name",
        MOperator = FilterByOperator.FromOperator1(Operator1Enum.Enum1),
        MValue = FilterByValue.FromFilterByValueCase1(
            FilterByValueCase1.FromString("Fred")
        ),
    },
};

try
{
    ResponseQuickInvoicesCollection result = await quickInvoicesController.ListAllQuickInvoicesRelatedAsync(
        page,
        order,
        filterBy
    );
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
  "type": "QuickInvoicesCollection",
  "list": [
    {
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
        {
          "file": {},
          "resource_id": "11e95f8ec39de8fbdb0a4f1a",
          "resource": "Contact",
          "product_file_id": "11e95f8ec39de8fbdb0a4f1a",
          "file_category_id": "11e95f8ec39de8fbdb0a4f1a",
          "visibility_group_id": "11e95f8ec39de8fbdb0a4f1a",
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "created_ts": 1422040992,
          "modified_ts": 1422040992,
          "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
        }
      ],
      "remaining_balance": 245.36,
      "single_payment_min_amount": 500,
      "single_payment_max_amount": 500000,
      "cell_phone": "3339998822",
      "tags": [
        {
          "location_id": "11e95f8ec39de8fbdb0a4f1a",
          "title": "My terminal",
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "created_ts": 1422040992,
          "modified_ts": 1422040992
        }
      ],
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "payment_status_id": 1,
      "is_active": true,
      "quick_invoice_setting": {
        "location_api_id": "11e95f8ec39de8fbdb0a4f1a",
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "quick_invoice_template": "<html>Template<html>",
        "default_allow_partial_pay": true,
        "default_notification_on_due_date": true,
        "default_notification_days_after_due_date": 7,
        "default_notification_days_before_due_date": 3,
        "id": "11e95f8ec39de8fbdb0a4f1a"
      },
      "quick_invoice_views": [
        {
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "quick_invoice_id": "Quick Invoice ID",
          "created_ts": 1422040992
        }
      ],
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
      "modified_user": {
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
      "log_sms": {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "body": " ",
        "reason_model": " ",
        "reason_model_id": " ",
        "provider_id": " ",
        "status": " ",
        "sender": " ",
        "recipient": " ",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      },
      "transactions": [
        {
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
          "identity_verification": {
            "dl_state": "MI",
            "dl_number": "1235567",
            "dob_year": "1980"
          },
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
          "recurring": false,
          "recurring_number": 1,
          "room_num": "303",
          "room_rate": 95,
          "save_account": false,
          "save_account_title": "John Account",
          "subtotal_amount": 599,
          "surcharge_amount": 100,
          "tags": [
            "Walk-in Customer"
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
          "hosted_payment_page_id": "11e95f8ec39de8fbdb0a4f1a"
        }
      ],
      "cc_product_transaction": {
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
      "ach_product_transaction": {
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
      "email_blacklist": {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "isBlacklisted": true,
        "detail": true,
        "created_ts": 1422040992
      },
      "sms_blacklist": {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "isBlacklisted": true,
        "detail": true,
        "created_ts": 1422040992
      }
    }
  ],
  "links": {
    "type": "Links",
    "first": "/v1/endpoint?page[size]=10&page[number]=1",
    "previous": "/v1/endpoint?page[size]=10&page[number]=5",
    "last": "/v1/endpoint?page[size]=10&page[number]=42"
  },
  "pagination": {
    "type": "Pagination",
    "total_count": 423,
    "page_count": 42,
    "page_number": 6,
    "page_size": 10
  },
  "sort": {
    "type": "Sorting",
    "fields": [
      {
        "field": "last_name",
        "order": "asc"
      }
    ]
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Resend

```csharp
ResendAsync(
    string quickInvoiceId,
    List<string> expand = null,
    Models.EmailEnum? email = null,
    Models.SmsEnum? sms = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `quickInvoiceId` | `string` | Template, Required | Quick Invoice ID |
| `expand` | `List<string>` | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `email` | [`EmailEnum?`](../../doc/models/email-enum.md) | Query, Optional | Resend Email |
| `sms` | [`SmsEnum?`](../../doc/models/sms-enum.md) | Query, Optional | Resend SMS |

## Response Type

[`Task<Models.ResponseQuickInvoiceResend>`](../../doc/models/response-quick-invoice-resend.md)

## Example Usage

```csharp
string quickInvoiceId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseQuickInvoiceResend result = await quickInvoicesController.ResendAsync(quickInvoiceId);
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
  "type": "QuickInvoiceResend",
  "data": {
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "email_log_id": "11e95f8ec39de8fbdb0a4f1a",
    "sms_log_id": "11e95f8ec39de8fbdb0a4f1a",
    "success": true,
    "sms_success": true,
    "email": "email@domain.com"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Associate Transaction With Ouick Invoice

```csharp
AssociateTransactionWithOuickInvoiceAsync(
    string quickInvoiceId,
    Models.V1QuickInvoicesTransactionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `quickInvoiceId` | `string` | Template, Required | Quick Invoice ID |
| `body` | [`V1QuickInvoicesTransactionRequest`](../../doc/models/v1-quick-invoices-transaction-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseQuickInvoice>`](../../doc/models/response-quick-invoice.md)

## Example Usage

```csharp
string quickInvoiceId = "11e95f8ec39de8fbdb0a4f1a";
V1QuickInvoicesTransactionRequest body = new V1QuickInvoicesTransactionRequest
{
    TransactionId = "11e95f8ec39de8fbdb0a4f1a",
};

try
{
    ResponseQuickInvoice result = await quickInvoicesController.AssociateTransactionWithOuickInvoiceAsync(
        quickInvoiceId,
        body
    );
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
  "type": "QuickInvoice",
  "data": {
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
      {
        "file": {},
        "resource_id": "11e95f8ec39de8fbdb0a4f1a",
        "resource": "Contact",
        "product_file_id": "11e95f8ec39de8fbdb0a4f1a",
        "file_category_id": "11e95f8ec39de8fbdb0a4f1a",
        "visibility_group_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "remaining_balance": 245.36,
    "single_payment_min_amount": 500,
    "single_payment_max_amount": 500000,
    "cell_phone": "3339998822",
    "tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": true,
    "payment_status_id": 1,
    "is_active": true,
    "quick_invoice_setting": {
      "location_api_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "quick_invoice_template": "<html>Template<html>",
      "default_allow_partial_pay": true,
      "default_notification_on_due_date": true,
      "default_notification_days_after_due_date": 7,
      "default_notification_days_before_due_date": 3,
      "id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "quick_invoice_views": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "quick_invoice_id": "Quick Invoice ID",
        "created_ts": 1422040992
      }
    ],
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
    "modified_user": {
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
    "log_sms": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "body": " ",
      "reason_model": " ",
      "reason_model_id": " ",
      "provider_id": " ",
      "status": " ",
      "sender": " ",
      "recipient": " ",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "transactions": [
      {
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
        "identity_verification": {
          "dl_state": "MI",
          "dl_number": "1235567",
          "dob_year": "1980"
        },
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
        "recurring": false,
        "recurring_number": 1,
        "room_num": "303",
        "room_rate": 95,
        "save_account": false,
        "save_account_title": "John Account",
        "subtotal_amount": 599,
        "surcharge_amount": 100,
        "tags": [
          "Walk-in Customer"
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
        "hosted_payment_page_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "cc_product_transaction": {
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
    "ach_product_transaction": {
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
    "email_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    },
    "sms_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Remove Transaction From Quick Invoice

```csharp
RemoveTransactionFromQuickInvoiceAsync(
    string quickInvoiceId,
    Models.V1QuickInvoicesTransactionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `quickInvoiceId` | `string` | Template, Required | Quick Invoice ID |
| `body` | [`V1QuickInvoicesTransactionRequest`](../../doc/models/v1-quick-invoices-transaction-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseQuickInvoice>`](../../doc/models/response-quick-invoice.md)

## Example Usage

```csharp
string quickInvoiceId = "11e95f8ec39de8fbdb0a4f1a";
V1QuickInvoicesTransactionRequest body = new V1QuickInvoicesTransactionRequest
{
    TransactionId = "11e95f8ec39de8fbdb0a4f1a",
};

try
{
    ResponseQuickInvoice result = await quickInvoicesController.RemoveTransactionFromQuickInvoiceAsync(
        quickInvoiceId,
        body
    );
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
  "type": "QuickInvoice",
  "data": {
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
      {
        "file": {},
        "resource_id": "11e95f8ec39de8fbdb0a4f1a",
        "resource": "Contact",
        "product_file_id": "11e95f8ec39de8fbdb0a4f1a",
        "file_category_id": "11e95f8ec39de8fbdb0a4f1a",
        "visibility_group_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "remaining_balance": 245.36,
    "single_payment_min_amount": 500,
    "single_payment_max_amount": 500000,
    "cell_phone": "3339998822",
    "tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": true,
    "payment_status_id": 1,
    "is_active": true,
    "quick_invoice_setting": {
      "location_api_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "quick_invoice_template": "<html>Template<html>",
      "default_allow_partial_pay": true,
      "default_notification_on_due_date": true,
      "default_notification_days_after_due_date": 7,
      "default_notification_days_before_due_date": 3,
      "id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "quick_invoice_views": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "quick_invoice_id": "Quick Invoice ID",
        "created_ts": 1422040992
      }
    ],
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
    "modified_user": {
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
    "log_sms": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "body": " ",
      "reason_model": " ",
      "reason_model_id": " ",
      "provider_id": " ",
      "status": " ",
      "sender": " ",
      "recipient": " ",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "transactions": [
      {
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
        "identity_verification": {
          "dl_state": "MI",
          "dl_number": "1235567",
          "dob_year": "1980"
        },
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
        "recurring": false,
        "recurring_number": 1,
        "room_num": "303",
        "room_rate": 95,
        "save_account": false,
        "save_account_title": "John Account",
        "subtotal_amount": 599,
        "surcharge_amount": 100,
        "tags": [
          "Walk-in Customer"
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
        "hosted_payment_page_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "cc_product_transaction": {
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
    "ach_product_transaction": {
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
    "email_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    },
    "sms_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Delete Quick Invoice

```csharp
DeleteQuickInvoiceAsync(
    string quickInvoiceId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `quickInvoiceId` | `string` | Template, Required | Quick Invoice ID |

## Response Type

[`Task<Models.ResponseQuickInvoice>`](../../doc/models/response-quick-invoice.md)

## Example Usage

```csharp
string quickInvoiceId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseQuickInvoice result = await quickInvoicesController.DeleteQuickInvoiceAsync(quickInvoiceId);
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
  "type": "QuickInvoice",
  "data": {
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
      {
        "file": {},
        "resource_id": "11e95f8ec39de8fbdb0a4f1a",
        "resource": "Contact",
        "product_file_id": "11e95f8ec39de8fbdb0a4f1a",
        "file_category_id": "11e95f8ec39de8fbdb0a4f1a",
        "visibility_group_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "remaining_balance": 245.36,
    "single_payment_min_amount": 500,
    "single_payment_max_amount": 500000,
    "cell_phone": "3339998822",
    "tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": true,
    "payment_status_id": 1,
    "is_active": true,
    "quick_invoice_setting": {
      "location_api_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "quick_invoice_template": "<html>Template<html>",
      "default_allow_partial_pay": true,
      "default_notification_on_due_date": true,
      "default_notification_days_after_due_date": 7,
      "default_notification_days_before_due_date": 3,
      "id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "quick_invoice_views": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "quick_invoice_id": "Quick Invoice ID",
        "created_ts": 1422040992
      }
    ],
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
    "modified_user": {
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
    "log_sms": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "body": " ",
      "reason_model": " ",
      "reason_model_id": " ",
      "provider_id": " ",
      "status": " ",
      "sender": " ",
      "recipient": " ",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "transactions": [
      {
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
        "identity_verification": {
          "dl_state": "MI",
          "dl_number": "1235567",
          "dob_year": "1980"
        },
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
        "recurring": false,
        "recurring_number": 1,
        "room_num": "303",
        "room_rate": 95,
        "save_account": false,
        "save_account_title": "John Account",
        "subtotal_amount": 599,
        "surcharge_amount": 100,
        "tags": [
          "Walk-in Customer"
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
        "hosted_payment_page_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "cc_product_transaction": {
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
    "ach_product_transaction": {
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
    "email_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    },
    "sms_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# View Single Quick Invoice Record

```csharp
ViewSingleQuickInvoiceRecordAsync(
    string quickInvoiceId,
    List<Models.Expand14Enum> expand = null,
    List<Models.Field37Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `quickInvoiceId` | `string` | Template, Required | Quick Invoice ID |
| `expand` | [`List<Expand14Enum>`](../../doc/models/expand-14-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `fields` | [`List<Field37Enum>`](../../doc/models/field-37-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseQuickInvoice>`](../../doc/models/response-quick-invoice.md)

## Example Usage

```csharp
string quickInvoiceId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseQuickInvoice result = await quickInvoicesController.ViewSingleQuickInvoiceRecordAsync(quickInvoiceId);
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
  "type": "QuickInvoice",
  "data": {
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
      {
        "file": {},
        "resource_id": "11e95f8ec39de8fbdb0a4f1a",
        "resource": "Contact",
        "product_file_id": "11e95f8ec39de8fbdb0a4f1a",
        "file_category_id": "11e95f8ec39de8fbdb0a4f1a",
        "visibility_group_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "remaining_balance": 245.36,
    "single_payment_min_amount": 500,
    "single_payment_max_amount": 500000,
    "cell_phone": "3339998822",
    "tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": true,
    "payment_status_id": 1,
    "is_active": true,
    "quick_invoice_setting": {
      "location_api_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "quick_invoice_template": "<html>Template<html>",
      "default_allow_partial_pay": true,
      "default_notification_on_due_date": true,
      "default_notification_days_after_due_date": 7,
      "default_notification_days_before_due_date": 3,
      "id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "quick_invoice_views": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "quick_invoice_id": "Quick Invoice ID",
        "created_ts": 1422040992
      }
    ],
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
    "modified_user": {
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
    "log_sms": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "body": " ",
      "reason_model": " ",
      "reason_model_id": " ",
      "provider_id": " ",
      "status": " ",
      "sender": " ",
      "recipient": " ",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "transactions": [
      {
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
        "identity_verification": {
          "dl_state": "MI",
          "dl_number": "1235567",
          "dob_year": "1980"
        },
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
        "recurring": false,
        "recurring_number": 1,
        "room_num": "303",
        "room_rate": 95,
        "save_account": false,
        "save_account_title": "John Account",
        "subtotal_amount": 599,
        "surcharge_amount": 100,
        "tags": [
          "Walk-in Customer"
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
        "hosted_payment_page_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "cc_product_transaction": {
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
    "ach_product_transaction": {
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
    "email_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    },
    "sms_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Update Quick Invoice

NOTE: A quick invoice can not be updated if it is already closed.
Once a partial payment is made, the item list should not be editable.

```csharp
UpdateQuickInvoiceAsync(
    string quickInvoiceId,
    Models.V1QuickInvoicesRequest1 body,
    List<Models.Expand14Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `quickInvoiceId` | `string` | Template, Required | Quick Invoice ID |
| `body` | [`V1QuickInvoicesRequest1`](../../doc/models/v1-quick-invoices-request-1.md) | Body, Required | - |
| `expand` | [`List<Expand14Enum>`](../../doc/models/expand-14-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseQuickInvoice>`](../../doc/models/response-quick-invoice.md)

## Example Usage

```csharp
string quickInvoiceId = "11e95f8ec39de8fbdb0a4f1a";
V1QuickInvoicesRequest1 body = new V1QuickInvoicesRequest1
{
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    Title = "My terminal",
    CcProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    AchProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    DueDate = "2021-12-01",
    AllowOverpayment = true,
    BankFundedOnlyOverride = true,
    Email = "email@domain.com",
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    ContactApiId = "contact12345",
    QuickInvoiceApiId = "quickinvoice12345",
    CustomerId = "11e95f8ec39de8fbdb0a4f1a",
    ExpireDate = "2021-12-01",
    AllowPartialPay = true,
    AttachFilesToEmail = true,
    SendEmail = true,
    InvoiceNumber = "invoice12345",
    ItemHeader = "Quick invoice header sample",
    ItemFooter = "Thank you",
    AmountDue = 24536,
    NotificationEmail = "email@domain.com",
    StatusId = 1,
    StatusCode = 1,
    Note = "some note",
    NotificationDaysBeforeDueDate = 3,
    NotificationDaysAfterDueDate = 7,
    NotificationOnDueDate = true,
    SendTextToPay = true,
    RemainingBalance = 24536,
    SinglePaymentMinAmount = 500,
    SinglePaymentMaxAmount = 500000,
    CellPhone = "3339998822",
};

try
{
    ResponseQuickInvoice result = await quickInvoicesController.UpdateQuickInvoiceAsync(
        quickInvoiceId,
        body
    );
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
  "type": "QuickInvoice",
  "data": {
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
      {
        "file": {},
        "resource_id": "11e95f8ec39de8fbdb0a4f1a",
        "resource": "Contact",
        "product_file_id": "11e95f8ec39de8fbdb0a4f1a",
        "file_category_id": "11e95f8ec39de8fbdb0a4f1a",
        "visibility_group_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "remaining_balance": 245.36,
    "single_payment_min_amount": 500,
    "single_payment_max_amount": 500000,
    "cell_phone": "3339998822",
    "tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": true,
    "payment_status_id": 1,
    "is_active": true,
    "quick_invoice_setting": {
      "location_api_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "quick_invoice_template": "<html>Template<html>",
      "default_allow_partial_pay": true,
      "default_notification_on_due_date": true,
      "default_notification_days_after_due_date": 7,
      "default_notification_days_before_due_date": 3,
      "id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "quick_invoice_views": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "quick_invoice_id": "Quick Invoice ID",
        "created_ts": 1422040992
      }
    ],
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
    "modified_user": {
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
    "log_sms": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "body": " ",
      "reason_model": " ",
      "reason_model_id": " ",
      "provider_id": " ",
      "status": " ",
      "sender": " ",
      "recipient": " ",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "transactions": [
      {
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
        "identity_verification": {
          "dl_state": "MI",
          "dl_number": "1235567",
          "dob_year": "1980"
        },
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
        "recurring": false,
        "recurring_number": 1,
        "room_num": "303",
        "room_rate": 95,
        "save_account": false,
        "save_account_title": "John Account",
        "subtotal_amount": 599,
        "surcharge_amount": 100,
        "tags": [
          "Walk-in Customer"
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
        "hosted_payment_page_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "cc_product_transaction": {
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
    "ach_product_transaction": {
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
    "email_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    },
    "sms_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Reopen Quick Invoice

```csharp
ReopenQuickInvoiceAsync(
    string quickInvoiceId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `quickInvoiceId` | `string` | Template, Required | Quick Invoice ID |

## Response Type

[`Task<Models.ResponseQuickInvoice>`](../../doc/models/response-quick-invoice.md)

## Example Usage

```csharp
string quickInvoiceId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseQuickInvoice result = await quickInvoicesController.ReopenQuickInvoiceAsync(quickInvoiceId);
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
  "type": "QuickInvoice",
  "data": {
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
      {
        "file": {},
        "resource_id": "11e95f8ec39de8fbdb0a4f1a",
        "resource": "Contact",
        "product_file_id": "11e95f8ec39de8fbdb0a4f1a",
        "file_category_id": "11e95f8ec39de8fbdb0a4f1a",
        "visibility_group_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "remaining_balance": 245.36,
    "single_payment_min_amount": 500,
    "single_payment_max_amount": 500000,
    "cell_phone": "3339998822",
    "tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": true,
    "payment_status_id": 1,
    "is_active": true,
    "quick_invoice_setting": {
      "location_api_id": "11e95f8ec39de8fbdb0a4f1a",
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "quick_invoice_template": "<html>Template<html>",
      "default_allow_partial_pay": true,
      "default_notification_on_due_date": true,
      "default_notification_days_after_due_date": 7,
      "default_notification_days_before_due_date": 3,
      "id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "quick_invoice_views": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "quick_invoice_id": "Quick Invoice ID",
        "created_ts": 1422040992
      }
    ],
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
    "modified_user": {
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
    "log_sms": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "body": " ",
      "reason_model": " ",
      "reason_model_id": " ",
      "provider_id": " ",
      "status": " ",
      "sender": " ",
      "recipient": " ",
      "created_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
    },
    "transactions": [
      {
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
        "identity_verification": {
          "dl_state": "MI",
          "dl_number": "1235567",
          "dob_year": "1980"
        },
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
        "recurring": false,
        "recurring_number": 1,
        "room_num": "303",
        "room_rate": 95,
        "save_account": false,
        "save_account_title": "John Account",
        "subtotal_amount": 599,
        "surcharge_amount": 100,
        "tags": [
          "Walk-in Customer"
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
        "hosted_payment_page_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "cc_product_transaction": {
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
    "ach_product_transaction": {
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
    "email_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    },
    "sms_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |

