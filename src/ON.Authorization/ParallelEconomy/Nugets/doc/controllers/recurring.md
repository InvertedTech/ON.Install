# Recurring

The recurrings endpoint is used to run a recurring transaction one or more times. There are two different types of recurrings:

1. **ongoing** (recurring_type_id="o") - a recurring that runs until it is deleted or an end date has been set.
2. **installment** (recurring_type_id="i") - a recurring that runs a fixed number of times, regardless of approval or decline.

When setting up a reccuring, it isn't necessarily linked directly to a contact, it is linked to an token through the account_vault_id or account_vault_api_id field. The token is then in turn linked to a contact. So in order to create a recurring, you must first create a contact, then create an token for that contact. Then the id of the token can be used for the recurring as account_vault_id.

```csharp
RecurringController recurringController = client.RecurringController;
```

## Class Name

`RecurringController`

## Methods

* [Create a New Recurring Record](../../doc/controllers/recurring.md#create-a-new-recurring-record)
* [List All Recurring Record](../../doc/controllers/recurring.md#list-all-recurring-record)
* [Delete Recurring Record](../../doc/controllers/recurring.md#delete-recurring-record)
* [View Single Recurring Record](../../doc/controllers/recurring.md#view-single-recurring-record)
* [Update Recurring Payment](../../doc/controllers/recurring.md#update-recurring-payment)
* [Activate Recurring Payment](../../doc/controllers/recurring.md#activate-recurring-payment)
* [Defer Recurring Payment](../../doc/controllers/recurring.md#defer-recurring-payment)
* [Place on Hold Recurring Payment](../../doc/controllers/recurring.md#place-on-hold-recurring-payment)
* [Skip Recurring Payment](../../doc/controllers/recurring.md#skip-recurring-payment)


# Create a New Recurring Record

```csharp
CreateANewRecurringRecordAsync(
    Models.V1RecurringsRequest body,
    List<Models.Expand23Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1RecurringsRequest`](../../doc/models/v1-recurrings-request.md) | Body, Required | - |
| `expand` | [`List<Expand23Enum>`](../../doc/models/expand-23-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseRecurring>`](../../doc/models/response-recurring.md)

## Example Usage

```csharp
V1RecurringsRequest body = new V1RecurringsRequest
{
    Interval = 1,
    IntervalType = IntervalTypeEnum.D,
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    StartDate = "2021-12-01",
    TransactionAmount = 300,
    AccountVaultId = "11e95f8ec39de8fbdb0a4f1a",
    TokenId = "11e95f8ec39de8fbdb0a4f1a",
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    AccountVaultApiId = "token1234abcd",
    TokenApiId = "token1234abcd",
    Active = true,
    Description = "Description",
    EndDate = "2021-12-01",
    InstallmentTotalCount = 20,
    NotificationDays = 2,
    PaymentMethod = PaymentMethod1Enum.Cc,
    ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    RecurringId = "11e95f8ec39de8fbdb0a4f1a",
    RecurringApiId = "recurring1234abcd",
    Status = StatusEnum.Active,
    TermsAgree = true,
    TermsAgreeIp = "192.168.0.10",
    RecurringC1 = "recurring custom data 1",
    RecurringC2 = "recurring custom data 2",
    RecurringC3 = "recurring custom data 3",
    SendToProcAsRecur = true,
    SecondaryAmount = 100,
};

try
{
    ResponseRecurring result = await recurringController.CreateANewRecurringRecordAsync(body);
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
  "type": "Recurring",
  "data": {
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
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "secondary_amount": 100,
    "currency": "USD",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "next_run_date": "2021-12-01",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "recurring_type_id": "i",
    "installment_amount_total": 99999999,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
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
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "payment_schedule": [
      "2021-12-01"
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
    "next_run_date_min": "2021-12-01",
    "next_run_date_max": "2021-12-01",
    "all_tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
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
    "forecast": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_id": "Recurring ID",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "recurring_splits": [
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


# List All Recurring Record

```csharp
ListAllRecurringRecordAsync(
    Models.Page page = null,
    List<Models.Order19> order = null,
    List<Models.FilterBy> filterBy = null,
    List<Models.Expand23Enum> expand = null,
    Models.Format1Enum? format = null,
    string typeahead = null,
    List<Models.Field39Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `order` | [`List<Order19>`](../../doc/models/order-19.md) | Query, Optional | Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json.<br><br>> /endpoint?order=[{ "key": "created_ts", "operator": "asc"}]<br>> <br>> /endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] |
| `filterBy` | [`List<FilterBy>`](../../doc/models/filter-by.md) | Query, Optional | Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.<br><br>> /endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }]<br>> <br>> /endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }]<br>> <br>> /endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }]<br>> <br>> /endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] |
| `expand` | [`List<Expand23Enum>`](../../doc/models/expand-23-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `format` | [`Format1Enum?`](../../doc/models/format-1-enum.md) | Query, Optional | Reporting format, valid values: csv, tsv |
| `typeahead` | `string` | Query, Optional | You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains. |
| `fields` | [`List<Field39Enum>`](../../doc/models/field-39-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseRecurringsCollection>`](../../doc/models/response-recurrings-collection.md)

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
    ResponseRecurringsCollection result = await recurringController.ListAllRecurringRecordAsync(
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
  "type": "RecurringsCollection",
  "list": [
    {
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
        {
          "location_id": "11e95f8ec39de8fbdb0a4f1a",
          "title": "My terminal",
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "created_ts": 1422040992,
          "modified_ts": 1422040992
        }
      ],
      "secondary_amount": 100,
      "currency": "USD",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "next_run_date": "2021-12-01",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "recurring_type_id": "i",
      "installment_amount_total": 99999999,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
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
      "signature": {
        "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
        "resource": "Transaction",
        "resource_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      },
      "payment_schedule": [
        "2021-12-01"
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
      "next_run_date_min": "2021-12-01",
      "next_run_date_max": "2021-12-01",
      "all_tags": [
        {
          "location_id": "11e95f8ec39de8fbdb0a4f1a",
          "title": "My terminal",
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "created_ts": 1422040992,
          "modified_ts": 1422040992
        }
      ],
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
      "forecast": {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "recurring_id": "Recurring ID",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      },
      "recurring_splits": [
        {
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "created_ts": 1422040992,
          "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
        }
      ]
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


# Delete Recurring Record

```csharp
DeleteRecurringRecordAsync(
    string recurringId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `recurringId` | `string` | Template, Required | Recurring ID |

## Response Type

[`Task<Models.ResponseRecurring>`](../../doc/models/response-recurring.md)

## Example Usage

```csharp
string recurringId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseRecurring result = await recurringController.DeleteRecurringRecordAsync(recurringId);
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
  "type": "Recurring",
  "data": {
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
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "secondary_amount": 100,
    "currency": "USD",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "next_run_date": "2021-12-01",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "recurring_type_id": "i",
    "installment_amount_total": 99999999,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
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
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "payment_schedule": [
      "2021-12-01"
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
    "next_run_date_min": "2021-12-01",
    "next_run_date_max": "2021-12-01",
    "all_tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
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
    "forecast": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_id": "Recurring ID",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "recurring_splits": [
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


# View Single Recurring Record

```csharp
ViewSingleRecurringRecordAsync(
    string recurringId,
    List<Models.Expand23Enum> expand = null,
    List<Models.Field39Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `recurringId` | `string` | Template, Required | Recurring ID |
| `expand` | [`List<Expand23Enum>`](../../doc/models/expand-23-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `fields` | [`List<Field39Enum>`](../../doc/models/field-39-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseRecurring>`](../../doc/models/response-recurring.md)

## Example Usage

```csharp
string recurringId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseRecurring result = await recurringController.ViewSingleRecurringRecordAsync(recurringId);
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
  "type": "Recurring",
  "data": {
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
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "secondary_amount": 100,
    "currency": "USD",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "next_run_date": "2021-12-01",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "recurring_type_id": "i",
    "installment_amount_total": 99999999,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
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
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "payment_schedule": [
      "2021-12-01"
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
    "next_run_date_min": "2021-12-01",
    "next_run_date_max": "2021-12-01",
    "all_tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
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
    "forecast": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_id": "Recurring ID",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "recurring_splits": [
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


# Update Recurring Payment

```csharp
UpdateRecurringPaymentAsync(
    string recurringId,
    Models.V1RecurringsRequest1 body,
    List<Models.Expand23Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `recurringId` | `string` | Template, Required | Recurring ID |
| `body` | [`V1RecurringsRequest1`](../../doc/models/v1-recurrings-request-1.md) | Body, Required | - |
| `expand` | [`List<Expand23Enum>`](../../doc/models/expand-23-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseRecurring>`](../../doc/models/response-recurring.md)

## Example Usage

```csharp
string recurringId = "11e95f8ec39de8fbdb0a4f1a";
V1RecurringsRequest1 body = new V1RecurringsRequest1
{
    NextRunDate = "2021-12-01",
    AccountVaultId = "11e95f8ec39de8fbdb0a4f1a",
    TokenId = "11e95f8ec39de8fbdb0a4f1a",
    Active = true,
    Description = "Description",
    EndDate = "2021-12-01",
    InstallmentTotalCount = 20,
    Interval = 1,
    IntervalType = IntervalTypeEnum.D,
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    NotificationDays = 2,
    PaymentMethod = PaymentMethod1Enum.Cc,
    ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    RecurringId = "11e95f8ec39de8fbdb0a4f1a",
    RecurringApiId = "recurring1234abcd",
    StartDate = "2021-12-01",
    Status = StatusEnum.Active,
    TransactionAmount = 300,
    TermsAgree = true,
    TermsAgreeIp = "192.168.0.10",
    RecurringC1 = "recurring custom data 1",
    RecurringC2 = "recurring custom data 2",
    RecurringC3 = "recurring custom data 3",
    SendToProcAsRecur = true,
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
};

try
{
    ResponseRecurring result = await recurringController.UpdateRecurringPaymentAsync(
        recurringId,
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
  "type": "Recurring",
  "data": {
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
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "secondary_amount": 100,
    "currency": "USD",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "next_run_date": "2021-12-01",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "recurring_type_id": "i",
    "installment_amount_total": 99999999,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
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
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "payment_schedule": [
      "2021-12-01"
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
    "next_run_date_min": "2021-12-01",
    "next_run_date_max": "2021-12-01",
    "all_tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
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
    "forecast": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_id": "Recurring ID",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "recurring_splits": [
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


# Activate Recurring Payment

```csharp
ActivateRecurringPaymentAsync(
    string recurringId,
    List<Models.Expand23Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `recurringId` | `string` | Template, Required | Recurring ID |
| `expand` | [`List<Expand23Enum>`](../../doc/models/expand-23-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseRecurring>`](../../doc/models/response-recurring.md)

## Example Usage

```csharp
string recurringId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseRecurring result = await recurringController.ActivateRecurringPaymentAsync(recurringId);
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
  "type": "Recurring",
  "data": {
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
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "secondary_amount": 100,
    "currency": "USD",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "next_run_date": "2021-12-01",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "recurring_type_id": "i",
    "installment_amount_total": 99999999,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
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
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "payment_schedule": [
      "2021-12-01"
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
    "next_run_date_min": "2021-12-01",
    "next_run_date_max": "2021-12-01",
    "all_tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
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
    "forecast": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_id": "Recurring ID",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "recurring_splits": [
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


# Defer Recurring Payment

```csharp
DeferRecurringPaymentAsync(
    string recurringId,
    Models.V1RecurringsDeferPaymentRequest body,
    List<Models.Expand23Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `recurringId` | `string` | Template, Required | Recurring ID |
| `body` | [`V1RecurringsDeferPaymentRequest`](../../doc/models/v1-recurrings-defer-payment-request.md) | Body, Required | - |
| `expand` | [`List<Expand23Enum>`](../../doc/models/expand-23-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseRecurring>`](../../doc/models/response-recurring.md)

## Example Usage

```csharp
string recurringId = "11e95f8ec39de8fbdb0a4f1a";
V1RecurringsDeferPaymentRequest body = new V1RecurringsDeferPaymentRequest
{
    DeferCount = 5,
};

try
{
    ResponseRecurring result = await recurringController.DeferRecurringPaymentAsync(
        recurringId,
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
  "type": "Recurring",
  "data": {
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
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "secondary_amount": 100,
    "currency": "USD",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "next_run_date": "2021-12-01",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "recurring_type_id": "i",
    "installment_amount_total": 99999999,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
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
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "payment_schedule": [
      "2021-12-01"
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
    "next_run_date_min": "2021-12-01",
    "next_run_date_max": "2021-12-01",
    "all_tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
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
    "forecast": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_id": "Recurring ID",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "recurring_splits": [
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


# Place on Hold Recurring Payment

```csharp
PlaceOnHoldRecurringPaymentAsync(
    string recurringId,
    List<Models.Expand23Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `recurringId` | `string` | Template, Required | Recurring ID |
| `expand` | [`List<Expand23Enum>`](../../doc/models/expand-23-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseRecurring>`](../../doc/models/response-recurring.md)

## Example Usage

```csharp
string recurringId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseRecurring result = await recurringController.PlaceOnHoldRecurringPaymentAsync(recurringId);
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
  "type": "Recurring",
  "data": {
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
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "secondary_amount": 100,
    "currency": "USD",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "next_run_date": "2021-12-01",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "recurring_type_id": "i",
    "installment_amount_total": 99999999,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
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
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "payment_schedule": [
      "2021-12-01"
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
    "next_run_date_min": "2021-12-01",
    "next_run_date_max": "2021-12-01",
    "all_tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
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
    "forecast": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_id": "Recurring ID",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "recurring_splits": [
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


# Skip Recurring Payment

```csharp
SkipRecurringPaymentAsync(
    string recurringId,
    Models.V1RecurringsSkipPaymentRequest body,
    List<Models.Expand23Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `recurringId` | `string` | Template, Required | Recurring ID |
| `body` | [`V1RecurringsSkipPaymentRequest`](../../doc/models/v1-recurrings-skip-payment-request.md) | Body, Required | - |
| `expand` | [`List<Expand23Enum>`](../../doc/models/expand-23-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseRecurring>`](../../doc/models/response-recurring.md)

## Example Usage

```csharp
string recurringId = "11e95f8ec39de8fbdb0a4f1a";
V1RecurringsSkipPaymentRequest body = new V1RecurringsSkipPaymentRequest
{
    SkipCount = 7,
};

try
{
    ResponseRecurring result = await recurringController.SkipRecurringPaymentAsync(
        recurringId,
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
  "type": "Recurring",
  "data": {
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
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
    "secondary_amount": 100,
    "currency": "USD",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "next_run_date": "2021-12-01",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "recurring_type_id": "i",
    "installment_amount_total": 99999999,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
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
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "payment_schedule": [
      "2021-12-01"
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
    "next_run_date_min": "2021-12-01",
    "next_run_date_max": "2021-12-01",
    "all_tags": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "title": "My terminal",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      }
    ],
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
    "forecast": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "recurring_id": "Recurring ID",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "recurring_splits": [
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

