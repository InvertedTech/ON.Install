# Tokens

The tokens endpoint is used as a tokenization endpoint to store token records. If there is a need to store accountvaults (tokens) for account numbers and card numbers for later use, then this is the endpoint to perform that task.

The account_vault_id field can be used in place of the account_number and exp_date fields on most endpoints in the system. So storing an accountvault on this endpoint will allow for the reuse of the account at a later time.

```csharp
TokensController tokensController = client.TokensController;
```

## Class Name

`TokensController`

## Methods

* [Create a New ACH Token](../../doc/controllers/tokens.md#create-a-new-ach-token)
* [Create a New Credit Card Token](../../doc/controllers/tokens.md#create-a-new-credit-card-token)
* [Create a New Previous Transaction Token](../../doc/controllers/tokens.md#create-a-new-previous-transaction-token)
* [Create a New Terminal Token](../../doc/controllers/tokens.md#create-a-new-terminal-token)
* [Create a New Ticket Token](../../doc/controllers/tokens.md#create-a-new-ticket-token)
* [Create a New Wallet Token](../../doc/controllers/tokens.md#create-a-new-wallet-token)
* [Delete a Single Token Record](../../doc/controllers/tokens.md#delete-a-single-token-record)
* [View Single Token Record](../../doc/controllers/tokens.md#view-single-token-record)
* [List All Tokens Related](../../doc/controllers/tokens.md#list-all-tokens-related)
* [Update ACH Token](../../doc/controllers/tokens.md#update-ach-token)
* [Update CC Token](../../doc/controllers/tokens.md#update-cc-token)


# Create a New ACH Token

```csharp
CreateANewACHTokenAsync(
    Models.V1TokensAchRequest body,
    List<Models.Expand44Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1TokensAchRequest`](../../doc/models/v1-tokens-ach-request.md) | Body, Required | - |
| `expand` | [`List<Expand44Enum>`](../../doc/models/expand-44-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
V1TokensAchRequest body = new V1TokensAchRequest
{
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    AccountHolderName = "John Smith",
    AccountNumber = "545454545454545",
    AccountVaultApiId = "accountvaultabcd",
    TokenApiId = "tokenabcd",
    AccountvaultC1 = "accountvault custom 1",
    AccountvaultC2 = "accountvault custom 2",
    AccountvaultC3 = "accountvault custom 3",
    TokenC1 = "token custom 1",
    TokenC2 = "token custom 2",
    TokenC3 = "token custom 3",
    AchSecCode = AchSecCode3Enum.WEB,
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    CustomerId = "123456",
    PreviousAccountVaultApiId = "previousaccountvault123456",
    PreviousTokenApiId = "previousaccountvault123456",
    PreviousAccountVaultId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousTokenId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    TermsAgree = true,
    TermsAgreeIp = "192.168.0.10",
    Title = "Test CC Account",
    AccountType = AccountType8Enum.Savings,
    IsCompany = false,
    RoutingNumber = "100020200",
};

try
{
    ResponseToken result = await tokensController.CreateANewACHTokenAsync(body);
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
  "type": "Token",
  "data": {
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
    "routing_number": "051904524",
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
    "activeRecurrings": [
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
      }
    ],
    "is_deletable": true,
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
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
    "account_vault_cau_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "account_vault_cau_product_transactions": [
      {
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


# Create a New Credit Card Token

```csharp
CreateANewCreditCardTokenAsync(
    Models.V1TokensCcRequest body,
    List<Models.Expand44Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1TokensCcRequest`](../../doc/models/v1-tokens-cc-request.md) | Body, Required | - |
| `expand` | [`List<Expand44Enum>`](../../doc/models/expand-44-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
V1TokensCcRequest body = new V1TokensCcRequest
{
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    AccountHolderName = "John Smith",
    AccountNumber = "5454545454545454",
    AccountVaultApiId = "accountvaultabcd",
    TokenApiId = "tokenabcd",
    AccountvaultC1 = "accountvault custom 1",
    AccountvaultC2 = "accountvault custom 2",
    AccountvaultC3 = "accountvault custom 3",
    TokenC1 = "token custom 1",
    TokenC2 = "token custom 2",
    TokenC3 = "token custom 3",
    AchSecCode = AchSecCode3Enum.WEB,
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    CustomerId = "123456",
    PreviousAccountVaultApiId = "previousaccountvault123456",
    PreviousTokenApiId = "previousaccountvault123456",
    PreviousAccountVaultId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousTokenId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    TermsAgree = true,
    TermsAgreeIp = "192.168.0.10",
    Title = "Test CC Account",
    ExpDate = "0929",
    ESerialNumber = "1234567890",
    ETrackData = "%B5454545454545454^account holder^17041010001111A123456789012?250112000000153000000?;5454545454545454=25011011000012345678?00|DC7AB845EFA793FB3C89C5D347D36ED11CAAED0C33E150437893996BA75EB8A0F334D0DAA1B874B6C677A4EF6984B089F891D8E434ACD867B616F4D815E63DA6A86B2AF927E9919B0CFC1DA3FD276D9382672EF8AA256329|32EA4D785CA3398882AABC405017EF9C2BDA666FA007A76538DE10878601EEC36EFE1F185BB8B1C8",
    EFormat = "ksn",
    EKeyedData = "236D530E098D48DB3F1AA367882CC1A7D475EFCACEFF1E965F17EC1E2D42CBF611C9EB0F80F4255784BA06951BD6092AB6CD3369D3D7E022E74DDCB16F9C40599FA03355E37E6ABB06B717B207709ED8C6BC5C7B6E32BB2B2F5046551A1C88D6",
    RunAvs = false,
    TrackData = "%B5424181111112228^FDCS TEST CARD /MASTERCARD^18121010001111123456789012?;5424181111112228=1812101100000123456?",
    Ticket = "12345678",
};

try
{
    ResponseToken result = await tokensController.CreateANewCreditCardTokenAsync(body);
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
  "type": "Token",
  "data": {
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
    "routing_number": "051904524",
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
    "activeRecurrings": [
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
      }
    ],
    "is_deletable": true,
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
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
    "account_vault_cau_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "account_vault_cau_product_transactions": [
      {
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


# Create a New Previous Transaction Token

```csharp
CreateANewPreviousTransactionTokenAsync(
    Models.V1TokensPreviousTransactionRequest body,
    List<Models.Expand44Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1TokensPreviousTransactionRequest`](../../doc/models/v1-tokens-previous-transaction-request.md) | Body, Required | - |
| `expand` | [`List<Expand44Enum>`](../../doc/models/expand-44-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
V1TokensPreviousTransactionRequest body = new V1TokensPreviousTransactionRequest
{
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    AccountHolderName = "John Smith",
    AccountVaultApiId = "accountvaultabcd",
    TokenApiId = "tokenabcd",
    AccountvaultC1 = "accountvault custom 1",
    AccountvaultC2 = "accountvault custom 2",
    AccountvaultC3 = "accountvault custom 3",
    TokenC1 = "token custom 1",
    TokenC2 = "token custom 2",
    TokenC3 = "token custom 3",
    AchSecCode = AchSecCode3Enum.WEB,
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    CustomerId = "123456",
    PreviousAccountVaultApiId = "previousaccountvault123456",
    PreviousTokenApiId = "previousaccountvault123456",
    PreviousAccountVaultId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousTokenId = "11e95f8ec39de8fbdb0a4f1a",
    AccountNumber = V1TokensPreviousTransactionRequestAccountNumber.FromString("String1"),
    TermsAgree = true,
    TermsAgreeIp = "192.168.0.10",
    Title = "Test CC Account",
};

try
{
    ResponseToken result = await tokensController.CreateANewPreviousTransactionTokenAsync(body);
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
  "type": "Token",
  "data": {
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
    "routing_number": "051904524",
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
    "activeRecurrings": [
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
      }
    ],
    "is_deletable": true,
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
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
    "account_vault_cau_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "account_vault_cau_product_transactions": [
      {
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


# Create a New Terminal Token

```csharp
CreateANewTerminalTokenAsync(
    Models.V1TokensTerminalRequest body,
    List<Models.Expand44Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1TokensTerminalRequest`](../../doc/models/v1-tokens-terminal-request.md) | Body, Required | - |
| `expand` | [`List<Expand44Enum>`](../../doc/models/expand-44-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
V1TokensTerminalRequest body = new V1TokensTerminalRequest
{
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    Action = "store",
    TerminalId = "11e95f8ec39de8fbdb0a4f1a",
    AccountHolderName = "John Smith",
    AccountVaultApiId = "accountvaultabcd",
    TokenApiId = "tokenabcd",
    AccountvaultC1 = "accountvault custom 1",
    AccountvaultC2 = "accountvault custom 2",
    AccountvaultC3 = "accountvault custom 3",
    TokenC1 = "token custom 1",
    TokenC2 = "token custom 2",
    TokenC3 = "token custom 3",
    AchSecCode = AchSecCode3Enum.WEB,
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    CustomerId = "123456",
    PreviousAccountVaultApiId = "previousaccountvault123456",
    PreviousTokenApiId = "previousaccountvault123456",
    PreviousAccountVaultId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousTokenId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    AccountNumber = V1TokensTerminalRequestAccountNumber.FromString("String1"),
    TermsAgree = true,
    TermsAgreeIp = "192.168.0.10",
    Title = "Test CC Account",
};

try
{
    ResponseToken result = await tokensController.CreateANewTerminalTokenAsync(body);
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
  "type": "Token",
  "data": {
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
    "routing_number": "051904524",
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
    "activeRecurrings": [
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
      }
    ],
    "is_deletable": true,
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
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
    "account_vault_cau_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "account_vault_cau_product_transactions": [
      {
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


# Create a New Ticket Token

```csharp
CreateANewTicketTokenAsync(
    Models.V1TokensTicketRequest body,
    List<Models.Expand44Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1TokensTicketRequest`](../../doc/models/v1-tokens-ticket-request.md) | Body, Required | - |
| `expand` | [`List<Expand44Enum>`](../../doc/models/expand-44-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
V1TokensTicketRequest body = new V1TokensTicketRequest
{
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    Ticket = "12345678",
    AccountHolderName = "John Smith",
    AccountVaultApiId = "accountvaultabcd",
    TokenApiId = "tokenabcd",
    AccountvaultC1 = "accountvault custom 1",
    AccountvaultC2 = "accountvault custom 2",
    AccountvaultC3 = "accountvault custom 3",
    TokenC1 = "token custom 1",
    TokenC2 = "token custom 2",
    TokenC3 = "token custom 3",
    AchSecCode = AchSecCode3Enum.WEB,
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    CustomerId = "123456",
    PreviousAccountVaultApiId = "previousaccountvault123456",
    PreviousTokenApiId = "previousaccountvault123456",
    PreviousAccountVaultId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousTokenId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    AccountNumber = V1TokensTicketRequestAccountNumber.FromString("String1"),
    TermsAgree = true,
    TermsAgreeIp = "192.168.0.10",
    Title = "Test CC Account",
};

try
{
    ResponseToken result = await tokensController.CreateANewTicketTokenAsync(body);
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
  "type": "Token",
  "data": {
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
    "routing_number": "051904524",
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
    "activeRecurrings": [
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
      }
    ],
    "is_deletable": true,
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
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
    "account_vault_cau_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "account_vault_cau_product_transactions": [
      {
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


# Create a New Wallet Token

```csharp
CreateANewWalletTokenAsync(
    Models.V1TokensWalletRequest body,
    List<Models.Expand44Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1TokensWalletRequest`](../../doc/models/v1-tokens-wallet-request.md) | Body, Required | - |
| `expand` | [`List<Expand44Enum>`](../../doc/models/expand-44-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
V1TokensWalletRequest body = new V1TokensWalletRequest
{
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    WalletData = "wallet_data2",
    WalletProvider = WalletProviderEnum.GooglePay,
    AccountHolderName = "John Smith",
    AccountVaultApiId = "accountvaultabcd",
    TokenApiId = "tokenabcd",
    AccountvaultC1 = "accountvault custom 1",
    AccountvaultC2 = "accountvault custom 2",
    AccountvaultC3 = "accountvault custom 3",
    TokenC1 = "token custom 1",
    TokenC2 = "token custom 2",
    TokenC3 = "token custom 3",
    AchSecCode = AchSecCode3Enum.WEB,
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    CustomerId = "123456",
    PreviousAccountVaultApiId = "previousaccountvault123456",
    PreviousTokenApiId = "previousaccountvault123456",
    PreviousAccountVaultId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousTokenId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    AccountNumber = V1TokensWalletRequestAccountNumber.FromString("String1"),
    TermsAgree = true,
    TermsAgreeIp = "192.168.0.10",
    Title = "Test CC Account",
    WalletKeyId = "11ee2bd392f32cb8aefd5bb5",
};

try
{
    ResponseToken result = await tokensController.CreateANewWalletTokenAsync(body);
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
  "type": "Token",
  "data": {
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
    "routing_number": "051904524",
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
    "activeRecurrings": [
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
      }
    ],
    "is_deletable": true,
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
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
    "account_vault_cau_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "account_vault_cau_product_transactions": [
      {
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


# Delete a Single Token Record

```csharp
DeleteASingleTokenRecordAsync(
    string tokenId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tokenId` | `string` | Template, Required | A unique, system-generated identifier for the Token. |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
string tokenId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseToken result = await tokensController.DeleteASingleTokenRecordAsync(tokenId);
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
  "type": "Token",
  "data": {
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
    "routing_number": "051904524",
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
    "activeRecurrings": [
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
      }
    ],
    "is_deletable": true,
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
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
    "account_vault_cau_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "account_vault_cau_product_transactions": [
      {
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
      }
    ]
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# View Single Token Record

```csharp
ViewSingleTokenRecordAsync(
    string tokenId,
    List<Models.Expand44Enum> expand = null,
    List<Models.Field49Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tokenId` | `string` | Template, Required | A unique, system-generated identifier for the Token. |
| `expand` | [`List<Expand44Enum>`](../../doc/models/expand-44-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `fields` | [`List<Field49Enum>`](../../doc/models/field-49-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
string tokenId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseToken result = await tokensController.ViewSingleTokenRecordAsync(tokenId);
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
  "type": "Token",
  "data": {
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
    "routing_number": "051904524",
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
    "activeRecurrings": [
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
      }
    ],
    "is_deletable": true,
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
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
    "account_vault_cau_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "account_vault_cau_product_transactions": [
      {
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
      }
    ]
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# List All Tokens Related

```csharp
ListAllTokensRelatedAsync(
    Models.Page page = null,
    List<Models.Order19> order = null,
    List<Models.FilterBy> filterBy = null,
    List<Models.Expand44Enum> expand = null,
    Models.Format1Enum? format = null,
    string typeahead = null,
    List<Models.Field49Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `order` | [`List<Order19>`](../../doc/models/order-19.md) | Query, Optional | Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json.<br><br>> /endpoint?order=[{ "key": "created_ts", "operator": "asc"}]<br>> <br>> /endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] |
| `filterBy` | [`List<FilterBy>`](../../doc/models/filter-by.md) | Query, Optional | Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.<br><br>> /endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }]<br>> <br>> /endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }]<br>> <br>> /endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }]<br>> <br>> /endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] |
| `expand` | [`List<Expand44Enum>`](../../doc/models/expand-44-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `format` | [`Format1Enum?`](../../doc/models/format-1-enum.md) | Query, Optional | Reporting format, valid values: csv, tsv |
| `typeahead` | `string` | Query, Optional | You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains. |
| `fields` | [`List<Field49Enum>`](../../doc/models/field-49-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseTokensCollection>`](../../doc/models/response-tokens-collection.md)

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
    ResponseTokensCollection result = await tokensController.ListAllTokensRelatedAsync(
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
  "type": "TokensCollection",
  "list": [
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
      "routing_number": "051904524",
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
      "activeRecurrings": [
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
        }
      ],
      "is_deletable": true,
      "signature": {
        "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
        "resource": "Transaction",
        "resource_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992
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
      "account_vault_cau_logs": [
        {
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
          "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
          "created_ts": 1422040992,
          "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
        }
      ],
      "account_vault_cau_product_transactions": [
        {
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


# Update ACH Token

```csharp
UpdateACHTokenAsync(
    string tokenId,
    Models.V1TokensAchRequest1 body,
    List<Models.Expand44Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tokenId` | `string` | Template, Required | A unique, system-generated identifier for the Token. |
| `body` | [`V1TokensAchRequest1`](../../doc/models/v1-tokens-ach-request-1.md) | Body, Required | - |
| `expand` | [`List<Expand44Enum>`](../../doc/models/expand-44-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
string tokenId = "11e95f8ec39de8fbdb0a4f1a";
V1TokensAchRequest1 body = new V1TokensAchRequest1
{
    AccountHolderName = "John Smith",
    AccountVaultApiId = "accountvaultabcd",
    TokenApiId = "tokenabcd",
    AccountvaultC1 = "accountvault custom 1",
    AccountvaultC2 = "accountvault custom 2",
    AccountvaultC3 = "accountvault custom 3",
    TokenC1 = "token custom 1",
    TokenC2 = "token custom 2",
    TokenC3 = "token custom 3",
    AchSecCode = AchSecCode3Enum.WEB,
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    CustomerId = "123456",
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousAccountVaultApiId = "previousaccountvault123456",
    PreviousTokenApiId = "previousaccountvault123456",
    PreviousAccountVaultId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousTokenId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    AccountNumber = V1TokensAchRequest1AccountNumber.FromString("String1"),
    TermsAgree = true,
    TermsAgreeIp = "192.168.0.10",
    Title = "Test CC Account",
    AccountType = AccountType8Enum.Savings,
};

try
{
    ResponseToken result = await tokensController.UpdateACHTokenAsync(
        tokenId,
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
  "type": "Token",
  "data": {
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
    "routing_number": "051904524",
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
    "activeRecurrings": [
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
      }
    ],
    "is_deletable": true,
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
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
    "account_vault_cau_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "account_vault_cau_product_transactions": [
      {
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


# Update CC Token

```csharp
UpdateCCTokenAsync(
    string tokenId,
    Models.V1TokensCcRequest1 body,
    List<Models.Expand44Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tokenId` | `string` | Template, Required | A unique, system-generated identifier for the Token. |
| `body` | [`V1TokensCcRequest1`](../../doc/models/v1-tokens-cc-request-1.md) | Body, Required | - |
| `expand` | [`List<Expand44Enum>`](../../doc/models/expand-44-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseToken>`](../../doc/models/response-token.md)

## Example Usage

```csharp
string tokenId = "11e95f8ec39de8fbdb0a4f1a";
V1TokensCcRequest1 body = new V1TokensCcRequest1
{
    AccountHolderName = "John Smith",
    AccountVaultApiId = "accountvaultabcd",
    TokenApiId = "tokenabcd",
    AccountvaultC1 = "accountvault custom 1",
    AccountvaultC2 = "accountvault custom 2",
    AccountvaultC3 = "accountvault custom 3",
    TokenC1 = "token custom 1",
    TokenC2 = "token custom 2",
    TokenC3 = "token custom 3",
    AchSecCode = AchSecCode3Enum.WEB,
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    CustomerId = "123456",
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousAccountVaultApiId = "previousaccountvault123456",
    PreviousTokenApiId = "previousaccountvault123456",
    PreviousAccountVaultId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousTokenId = "11e95f8ec39de8fbdb0a4f1a",
    PreviousTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    AccountNumber = V1TokensCcRequest1AccountNumber.FromString("String1"),
    TermsAgree = true,
    TermsAgreeIp = "192.168.0.10",
    Title = "Test CC Account",
    ExpDate = "0929",
};

try
{
    ResponseToken result = await tokensController.UpdateCCTokenAsync(
        tokenId,
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
  "type": "Token",
  "data": {
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
    "routing_number": "051904524",
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
    "activeRecurrings": [
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
      }
    ],
    "is_deletable": true,
    "signature": {
      "signature": "iVBORw0KGgoAAAANSUhEUgAAANwAAAAsCAYAAAAOyNaYAAACvklEQVR4nO3bLZOqUBjA8ScaNxqNRiKRaCQaiXwEG7cRiUajH8FINBqJRCKR+NxyD4OIXtaXw2H3/5s5MwZ39rgz/zkvuKKqgar+YTAYnx/y7wUACwgOsIjgAIsIznFlWerlcpl6GngTgnNYVVW6WCxURDTLsqmngzcgOMdtNhsVERURDYJA8zyfekp4AcE5oCgKzfN8cOvYNM1VdCKiURRNMEu8A8FNrCzLm5j68Q1Fx2o3TwTngCzLNAiCq6D6UTVNo0mS6NfXF+HNGME5or+KeZ7XxrVcLjWOY83zXOu6vnqfeQ/bzHkgOIf0VzHP83Sz2eh6vW4D831fy7JsowvDsH1NdO4jOAfVdX0VXhRFWhSFRlHUrmr7/b4NLU3T9jVbTLcRnMO620ezep1Op3bF832/3XIORQr3EJzjumc7E9HQBUoYhjdnPKJzD8E5xjyT647T6aSr1UpFRPf7ffveuq41TdOHZzyicwvBTeBeVGEY3jwaGBrmWV3/Z82K1z/jca5zB8F9wFBQY6JaLBYax7EmSXJ3DD2v624rzUpoVrsgCDjXOWRWwVVVNfUUrvTDGrNK3YsqTdNRn69pGs2y7NshssV0w2yCK4pCRUSPx+Okc/hfWI9WqbFRPaMbYjc+s7ptt1uic8BsgsvzXEVED4fDR3/P2PPVUFifDOo7THxmPiY03/fZXk7s1wR371z1zPnKlbDGuvc9TKKz78cE9yio3W436vbv1fOV6/oPx010/Ee5PbMLbrfbPRWU53kPb/9+SlRj9L8ALcJ/lNsym+DO5/PTQaVpqnVdT/0RnGLOed0LlikvpH6L2QSnqoPX4QT1mu4FC3/Dz5tVcMDcERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGARwQEWERxgEcEBFhEcYBHBARYRHGDRX+EC0ah++pNrAAAAAElFTkSuQmCC",
      "resource": "Transaction",
      "resource_id": "11e95f8ec39de8fbdb0a4f1a",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992
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
    "account_vault_cau_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
        "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "account_vault_cau_product_transactions": [
      {
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

