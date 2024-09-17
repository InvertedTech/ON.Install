# Users

```csharp
UsersController usersController = client.UsersController;
```

## Class Name

`UsersController`

## Methods

* [Create a New API Key](../../doc/controllers/users.md#create-a-new-api-key)
* [Create a New User](../../doc/controllers/users.md#create-a-new-user)
* [List All User](../../doc/controllers/users.md#list-all-user)
* [Delete a User Record](../../doc/controllers/users.md#delete-a-user-record)
* [View Single User Record](../../doc/controllers/users.md#view-single-user-record)
* [Update a User Record](../../doc/controllers/users.md#update-a-user-record)
* [View Self Record](../../doc/controllers/users.md#view-self-record)
* [Remove Verification](../../doc/controllers/users.md#remove-verification)
* [Send Verification](../../doc/controllers/users.md#send-verification)


# Create a New API Key

```csharp
CreateANewAPIKeyAsync(
    string userId,
    List<Models.Expand95Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userId` | `string` | Template, Required | User ID |
| `expand` | [`List<Expand95Enum>`](../../doc/models/expand-95-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseUserApiKey>`](../../doc/models/response-user-api-key.md)

## Example Usage

```csharp
string userId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseUserApiKey result = await usersController.CreateANewAPIKeyAsync(userId);
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
  "type": "UserApiKey",
  "data": {
    "user_api_key": "234bas8dfn8238f923w2"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Create a New User

```csharp
CreateANewUserAsync(
    Models.V1UsersRequest body,
    List<Models.Expand95Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1UsersRequest`](../../doc/models/v1-users-request.md) | Body, Required | - |
| `expand` | [`List<Expand95Enum>`](../../doc/models/expand-95-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseUser>`](../../doc/models/response-user.md)

## Example Usage

```csharp
V1UsersRequest body = new V1UsersRequest
{
    Email = "email@domain.com",
    LastName = "Smith",
    PrimaryLocationId = "11e95f8ec39de8fbdb0a4f1a",
    Username = "{user_name}",
    UserTypeCode = UserTypeCodeEnum.Enum100,
    AccountNumber = "5454545454545454",
    BrandingDomainUrl = "{branding_domain_url}",
    CellPhone = "3339998822",
    CompanyName = "Fortis Payment Systems, LLC",
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    DateOfBirth = "2021-12-01",
    DomainId = "11e95f8ec39de8fbdb0a4f1a",
    EmailTrxReceipt = true,
    HomePhone = "3339998822",
    FirstName = "John",
    Locale = "en-US",
    OfficePhone = "3339998822",
    OfficeExtPhone = "5",
    TermsConditionCode = "20220308",
    Tz = "America/New_York",
    UserApiKey = "234bas8dfn8238f923w2",
    Zip = "48375",
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    StatusCode = StatusCodeEnum.Enum1,
    ApiOnly = false,
    IsInvitation = false,
};

try
{
    ResponseUser result = await usersController.CreateANewUserAsync(body);
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
  "type": "User",
  "data": {
    "account_number": "5454545454545454",
    "branding_domain_url": "{branding_domain_url}",
    "cell_phone": "3339998822",
    "company_name": "Fortis Payment Systems, LLC",
    "contact_id": "Sample contact ID",
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
    "log_api_response_body_ts": 1422040992,
    "locations": [
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
    ],
    "primary_location": {
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
    "received_emails": [
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
    "isDeletable": true,
    "active_notification_alerts": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "date_start": "2021-12-01 10:10:00",
        "date_end": "2021-12-01 10:10:00",
        "user_location": true,
        "user_contact": true,
        "include_children": true,
        "alert_type": 1,
        "alert_type_id": 1,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "location_users": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "location_api_id": null,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "auth_roles": [
      {
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "auth_role_code": 110,
        "code": 83931,
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
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
    "resources": {
      "title": "My terminal",
      "priv": null,
      "resource_name": "v2.addons.iframe.get",
      "id": 5693,
      "last_used_date": 1422040992,
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "domain": {
      "url": "fortispayrbyn9y.sandbox.zeamster.com",
      "title": "Test Brand Domain Title 2",
      "logo": "",
      "support_email": "email@domain.com",
      "allow_contact_signup": true,
      "allow_contact_registration": true,
      "allow_contact_login": true,
      "registration_fields": [
        "account_number"
      ],
      "company_name": null,
      "nav_color": null,
      "button_primary_color": null,
      "logo_background_color": null,
      "icon_background_color": null,
      "menu_text_background_color": null,
      "menu_text_color": null,
      "right_menu_background_color": null,
      "right_menu_text_color": null,
      "button_primary_text_color": null,
      "nav_logo": null,
      "fav_icon": null,
      "aes_key": null,
      "help_text": null,
      "email_reply_to": "email@domain.com",
      "email": "email@domain.com",
      "custom_javascript": null,
      "custom_theme": null,
      "custom_css": null,
      "contact_user_default_entry_page": "dashboard",
      "contact_user_default_auth_roles": [
        null
      ],
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
    "location_marketplaces": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "marketplace_id": "11e95f8ec39de8fbdb0a4f1a",
        "location_api_id": null,
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "email_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    },
    "helppage": {
      "user_type_code": 100,
      "body": "Sample Body",
      "title": "Sample Title",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# List All User

```csharp
ListAllUserAsync(
    Models.Page page = null,
    List<Models.Order19> order = null,
    List<Models.FilterBy> filterBy = null,
    List<Models.Expand95Enum> expand = null,
    Models.Format1Enum? format = null,
    string typeahead = null,
    List<Models.Field54Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `order` | [`List<Order19>`](../../doc/models/order-19.md) | Query, Optional | Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json.<br><br>> /endpoint?order=[{ "key": "created_ts", "operator": "asc"}]<br>> <br>> /endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] |
| `filterBy` | [`List<FilterBy>`](../../doc/models/filter-by.md) | Query, Optional | Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.<br><br>> /endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }]<br>> <br>> /endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }]<br>> <br>> /endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }]<br>> <br>> /endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] |
| `expand` | [`List<Expand95Enum>`](../../doc/models/expand-95-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `format` | [`Format1Enum?`](../../doc/models/format-1-enum.md) | Query, Optional | Reporting format, valid values: csv, tsv |
| `typeahead` | `string` | Query, Optional | You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains. |
| `fields` | [`List<Field54Enum>`](../../doc/models/field-54-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseUsersCollection>`](../../doc/models/response-users-collection.md)

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
    ResponseUsersCollection result = await usersController.ListAllUserAsync(
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
  "type": "UsersCollection",
  "list": [
    {
      "account_number": "5454545454545454",
      "branding_domain_url": "{branding_domain_url}",
      "cell_phone": "3339998822",
      "company_name": "Fortis Payment Systems, LLC",
      "contact_id": "Sample contact ID",
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
      "log_api_response_body_ts": 1422040992,
      "locations": [
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
      ],
      "primary_location": {
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
      "received_emails": [
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
      "isDeletable": true,
      "active_notification_alerts": [
        {
          "location_id": "11e95f8ec39de8fbdb0a4f1a",
          "date_start": "2021-12-01 10:10:00",
          "date_end": "2021-12-01 10:10:00",
          "user_location": true,
          "user_contact": true,
          "include_children": true,
          "alert_type": 1,
          "alert_type_id": 1,
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "created_ts": 1422040992,
          "modified_ts": 1422040992,
          "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
          "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
        }
      ],
      "location_users": [
        {
          "location_id": "11e95f8ec39de8fbdb0a4f1a",
          "user_id": "11e95f8ec39de8fbdb0a4f1a",
          "location_api_id": null,
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "created_ts": 1422040992,
          "modified_ts": 1422040992,
          "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
          "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
        }
      ],
      "auth_roles": [
        {
          "user_id": "11e95f8ec39de8fbdb0a4f1a",
          "auth_role_code": 110,
          "code": 83931,
          "created_ts": 1422040992,
          "modified_ts": 1422040992,
          "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
          "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
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
      "resources": {
        "title": "My terminal",
        "priv": null,
        "resource_name": "v2.addons.iframe.get",
        "id": 5693,
        "last_used_date": 1422040992,
        "created_ts": 1422040992,
        "modified_ts": 1422040992
      },
      "domain": {
        "url": "fortispayrbyn9y.sandbox.zeamster.com",
        "title": "Test Brand Domain Title 2",
        "logo": "",
        "support_email": "email@domain.com",
        "allow_contact_signup": true,
        "allow_contact_registration": true,
        "allow_contact_login": true,
        "registration_fields": [
          "account_number"
        ],
        "company_name": null,
        "nav_color": null,
        "button_primary_color": null,
        "logo_background_color": null,
        "icon_background_color": null,
        "menu_text_background_color": null,
        "menu_text_color": null,
        "right_menu_background_color": null,
        "right_menu_text_color": null,
        "button_primary_text_color": null,
        "nav_logo": null,
        "fav_icon": null,
        "aes_key": null,
        "help_text": null,
        "email_reply_to": "email@domain.com",
        "email": "email@domain.com",
        "custom_javascript": null,
        "custom_theme": null,
        "custom_css": null,
        "contact_user_default_entry_page": "dashboard",
        "contact_user_default_auth_roles": [
          null
        ],
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
      "location_marketplaces": [
        {
          "location_id": "11e95f8ec39de8fbdb0a4f1a",
          "marketplace_id": "11e95f8ec39de8fbdb0a4f1a",
          "location_api_id": null,
          "user_id": "11e95f8ec39de8fbdb0a4f1a",
          "id": "11e95f8ec39de8fbdb0a4f1a",
          "created_ts": 1422040992,
          "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
        }
      ],
      "email_blacklist": {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "isBlacklisted": true,
        "detail": true,
        "created_ts": 1422040992
      },
      "helppage": {
        "user_type_code": 100,
        "body": "Sample Body",
        "title": "Sample Title",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
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


# Delete a User Record

```csharp
DeleteAUserRecordAsync(
    string userId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userId` | `string` | Template, Required | User ID |

## Response Type

[`Task<Models.ResponseUser>`](../../doc/models/response-user.md)

## Example Usage

```csharp
string userId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseUser result = await usersController.DeleteAUserRecordAsync(userId);
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
  "type": "User",
  "data": {
    "account_number": "5454545454545454",
    "branding_domain_url": "{branding_domain_url}",
    "cell_phone": "3339998822",
    "company_name": "Fortis Payment Systems, LLC",
    "contact_id": "Sample contact ID",
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
    "log_api_response_body_ts": 1422040992,
    "locations": [
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
    ],
    "primary_location": {
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
    "received_emails": [
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
    "isDeletable": true,
    "active_notification_alerts": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "date_start": "2021-12-01 10:10:00",
        "date_end": "2021-12-01 10:10:00",
        "user_location": true,
        "user_contact": true,
        "include_children": true,
        "alert_type": 1,
        "alert_type_id": 1,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "location_users": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "location_api_id": null,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "auth_roles": [
      {
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "auth_role_code": 110,
        "code": 83931,
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
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
    "resources": {
      "title": "My terminal",
      "priv": null,
      "resource_name": "v2.addons.iframe.get",
      "id": 5693,
      "last_used_date": 1422040992,
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "domain": {
      "url": "fortispayrbyn9y.sandbox.zeamster.com",
      "title": "Test Brand Domain Title 2",
      "logo": "",
      "support_email": "email@domain.com",
      "allow_contact_signup": true,
      "allow_contact_registration": true,
      "allow_contact_login": true,
      "registration_fields": [
        "account_number"
      ],
      "company_name": null,
      "nav_color": null,
      "button_primary_color": null,
      "logo_background_color": null,
      "icon_background_color": null,
      "menu_text_background_color": null,
      "menu_text_color": null,
      "right_menu_background_color": null,
      "right_menu_text_color": null,
      "button_primary_text_color": null,
      "nav_logo": null,
      "fav_icon": null,
      "aes_key": null,
      "help_text": null,
      "email_reply_to": "email@domain.com",
      "email": "email@domain.com",
      "custom_javascript": null,
      "custom_theme": null,
      "custom_css": null,
      "contact_user_default_entry_page": "dashboard",
      "contact_user_default_auth_roles": [
        null
      ],
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
    "location_marketplaces": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "marketplace_id": "11e95f8ec39de8fbdb0a4f1a",
        "location_api_id": null,
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "email_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    },
    "helppage": {
      "user_type_code": 100,
      "body": "Sample Body",
      "title": "Sample Title",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# View Single User Record

```csharp
ViewSingleUserRecordAsync(
    string userId,
    List<Models.Expand95Enum> expand = null,
    List<Models.Field54Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userId` | `string` | Template, Required | User ID |
| `expand` | [`List<Expand95Enum>`](../../doc/models/expand-95-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `fields` | [`List<Field54Enum>`](../../doc/models/field-54-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseUser>`](../../doc/models/response-user.md)

## Example Usage

```csharp
string userId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseUser result = await usersController.ViewSingleUserRecordAsync(userId);
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
  "type": "User",
  "data": {
    "account_number": "5454545454545454",
    "branding_domain_url": "{branding_domain_url}",
    "cell_phone": "3339998822",
    "company_name": "Fortis Payment Systems, LLC",
    "contact_id": "Sample contact ID",
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
    "log_api_response_body_ts": 1422040992,
    "locations": [
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
    ],
    "primary_location": {
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
    "received_emails": [
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
    "isDeletable": true,
    "active_notification_alerts": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "date_start": "2021-12-01 10:10:00",
        "date_end": "2021-12-01 10:10:00",
        "user_location": true,
        "user_contact": true,
        "include_children": true,
        "alert_type": 1,
        "alert_type_id": 1,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "location_users": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "location_api_id": null,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "auth_roles": [
      {
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "auth_role_code": 110,
        "code": 83931,
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
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
    "resources": {
      "title": "My terminal",
      "priv": null,
      "resource_name": "v2.addons.iframe.get",
      "id": 5693,
      "last_used_date": 1422040992,
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "domain": {
      "url": "fortispayrbyn9y.sandbox.zeamster.com",
      "title": "Test Brand Domain Title 2",
      "logo": "",
      "support_email": "email@domain.com",
      "allow_contact_signup": true,
      "allow_contact_registration": true,
      "allow_contact_login": true,
      "registration_fields": [
        "account_number"
      ],
      "company_name": null,
      "nav_color": null,
      "button_primary_color": null,
      "logo_background_color": null,
      "icon_background_color": null,
      "menu_text_background_color": null,
      "menu_text_color": null,
      "right_menu_background_color": null,
      "right_menu_text_color": null,
      "button_primary_text_color": null,
      "nav_logo": null,
      "fav_icon": null,
      "aes_key": null,
      "help_text": null,
      "email_reply_to": "email@domain.com",
      "email": "email@domain.com",
      "custom_javascript": null,
      "custom_theme": null,
      "custom_css": null,
      "contact_user_default_entry_page": "dashboard",
      "contact_user_default_auth_roles": [
        null
      ],
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
    "location_marketplaces": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "marketplace_id": "11e95f8ec39de8fbdb0a4f1a",
        "location_api_id": null,
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "email_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    },
    "helppage": {
      "user_type_code": 100,
      "body": "Sample Body",
      "title": "Sample Title",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Update a User Record

```csharp
UpdateAUserRecordAsync(
    string userId,
    Models.V1UsersRequest1 body,
    List<Models.Expand95Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userId` | `string` | Template, Required | User ID |
| `body` | [`V1UsersRequest1`](../../doc/models/v1-users-request-1.md) | Body, Required | - |
| `expand` | [`List<Expand95Enum>`](../../doc/models/expand-95-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseUser>`](../../doc/models/response-user.md)

## Example Usage

```csharp
string userId = "11e95f8ec39de8fbdb0a4f1a";
V1UsersRequest1 body = new V1UsersRequest1
{
    AccountNumber = "5454545454545454",
    BrandingDomainUrl = "{branding_domain_url}",
    CellPhone = "3339998822",
    CompanyName = "Fortis Payment Systems, LLC",
    ContactId = "11e95f8ec39de8fbdb0a4f1a",
    DateOfBirth = "2021-12-01",
    DomainId = "11e95f8ec39de8fbdb0a4f1a",
    Email = "email@domain.com",
    EmailTrxReceipt = true,
    HomePhone = "3339998822",
    FirstName = "John",
    LastName = "Smith",
    Locale = "en-US",
    OfficePhone = "3339998822",
    OfficeExtPhone = "5",
    PrimaryLocationId = "11e95f8ec39de8fbdb0a4f1a",
    TermsConditionCode = "20220308",
    Tz = "America/New_York",
    Username = "{user_name}",
    UserApiKey = "234bas8dfn8238f923w2",
    UserTypeCode = UserTypeCodeEnum.Enum100,
    Zip = "48375",
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    StatusCode = StatusCodeEnum.Enum1,
    ApiOnly = false,
    IsInvitation = false,
};

try
{
    ResponseUser result = await usersController.UpdateAUserRecordAsync(
        userId,
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
  "type": "User",
  "data": {
    "account_number": "5454545454545454",
    "branding_domain_url": "{branding_domain_url}",
    "cell_phone": "3339998822",
    "company_name": "Fortis Payment Systems, LLC",
    "contact_id": "Sample contact ID",
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
    "log_api_response_body_ts": 1422040992,
    "locations": [
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
    ],
    "primary_location": {
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
    "received_emails": [
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
    "isDeletable": true,
    "active_notification_alerts": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "date_start": "2021-12-01 10:10:00",
        "date_end": "2021-12-01 10:10:00",
        "user_location": true,
        "user_contact": true,
        "include_children": true,
        "alert_type": 1,
        "alert_type_id": 1,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "location_users": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "location_api_id": null,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "auth_roles": [
      {
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "auth_role_code": 110,
        "code": 83931,
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
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
    "resources": {
      "title": "My terminal",
      "priv": null,
      "resource_name": "v2.addons.iframe.get",
      "id": 5693,
      "last_used_date": 1422040992,
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "domain": {
      "url": "fortispayrbyn9y.sandbox.zeamster.com",
      "title": "Test Brand Domain Title 2",
      "logo": "",
      "support_email": "email@domain.com",
      "allow_contact_signup": true,
      "allow_contact_registration": true,
      "allow_contact_login": true,
      "registration_fields": [
        "account_number"
      ],
      "company_name": null,
      "nav_color": null,
      "button_primary_color": null,
      "logo_background_color": null,
      "icon_background_color": null,
      "menu_text_background_color": null,
      "menu_text_color": null,
      "right_menu_background_color": null,
      "right_menu_text_color": null,
      "button_primary_text_color": null,
      "nav_logo": null,
      "fav_icon": null,
      "aes_key": null,
      "help_text": null,
      "email_reply_to": "email@domain.com",
      "email": "email@domain.com",
      "custom_javascript": null,
      "custom_theme": null,
      "custom_css": null,
      "contact_user_default_entry_page": "dashboard",
      "contact_user_default_auth_roles": [
        null
      ],
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
    "location_marketplaces": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "marketplace_id": "11e95f8ec39de8fbdb0a4f1a",
        "location_api_id": null,
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "email_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    },
    "helppage": {
      "user_type_code": 100,
      "body": "Sample Body",
      "title": "Sample Title",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# View Self Record

```csharp
ViewSelfRecordAsync(
    List<Models.Expand95Enum> expand = null,
    List<Models.Field54Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `expand` | [`List<Expand95Enum>`](../../doc/models/expand-95-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `fields` | [`List<Field54Enum>`](../../doc/models/field-54-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseUser>`](../../doc/models/response-user.md)

## Example Usage

```csharp
try
{
    ResponseUser result = await usersController.ViewSelfRecordAsync();
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
  "type": "User",
  "data": {
    "account_number": "5454545454545454",
    "branding_domain_url": "{branding_domain_url}",
    "cell_phone": "3339998822",
    "company_name": "Fortis Payment Systems, LLC",
    "contact_id": "Sample contact ID",
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
    "log_api_response_body_ts": 1422040992,
    "locations": [
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
    ],
    "primary_location": {
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
    "received_emails": [
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
    "isDeletable": true,
    "active_notification_alerts": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "date_start": "2021-12-01 10:10:00",
        "date_end": "2021-12-01 10:10:00",
        "user_location": true,
        "user_contact": true,
        "include_children": true,
        "alert_type": 1,
        "alert_type_id": 1,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "location_users": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "location_api_id": null,
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "auth_roles": [
      {
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "auth_role_code": 110,
        "code": 83931,
        "created_ts": 1422040992,
        "modified_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
        "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
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
    "resources": {
      "title": "My terminal",
      "priv": null,
      "resource_name": "v2.addons.iframe.get",
      "id": 5693,
      "last_used_date": 1422040992,
      "created_ts": 1422040992,
      "modified_ts": 1422040992
    },
    "domain": {
      "url": "fortispayrbyn9y.sandbox.zeamster.com",
      "title": "Test Brand Domain Title 2",
      "logo": "",
      "support_email": "email@domain.com",
      "allow_contact_signup": true,
      "allow_contact_registration": true,
      "allow_contact_login": true,
      "registration_fields": [
        "account_number"
      ],
      "company_name": null,
      "nav_color": null,
      "button_primary_color": null,
      "logo_background_color": null,
      "icon_background_color": null,
      "menu_text_background_color": null,
      "menu_text_color": null,
      "right_menu_background_color": null,
      "right_menu_text_color": null,
      "button_primary_text_color": null,
      "nav_logo": null,
      "fav_icon": null,
      "aes_key": null,
      "help_text": null,
      "email_reply_to": "email@domain.com",
      "email": "email@domain.com",
      "custom_javascript": null,
      "custom_theme": null,
      "custom_css": null,
      "contact_user_default_entry_page": "dashboard",
      "contact_user_default_auth_roles": [
        null
      ],
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
    "location_marketplaces": [
      {
        "location_id": "11e95f8ec39de8fbdb0a4f1a",
        "marketplace_id": "11e95f8ec39de8fbdb0a4f1a",
        "location_api_id": null,
        "user_id": "11e95f8ec39de8fbdb0a4f1a",
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "created_ts": 1422040992,
        "created_user_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ],
    "email_blacklist": {
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "isBlacklisted": true,
      "detail": true,
      "created_ts": 1422040992
    },
    "helppage": {
      "user_type_code": 100,
      "body": "Sample Body",
      "title": "Sample Title",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a"
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Remove Verification

Remove the pending user

```csharp
RemoveVerificationAsync(
    string userId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userId` | `string` | Template, Required | - |

## Response Type

[`Task<Models.ResponseRemoveVerification>`](../../doc/models/response-remove-verification.md)

## Example Usage

```csharp
string userId = "user_id8";
try
{
    ResponseRemoveVerification result = await usersController.RemoveVerificationAsync(userId);
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
  "type": "RemoveVerification",
  "data": {
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "user_id": "11e95f8ec39de8fbdb0a4f1a",
    "hash": "123456781234567812345678",
    "created_ts": 1422040992
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Send Verification

Send an verification email to the pending user

```csharp
SendVerificationAsync(
    string userId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userId` | `string` | Template, Required | - |

## Response Type

[`Task<Models.ResponseSendVerification>`](../../doc/models/response-send-verification.md)

## Example Usage

```csharp
string userId = "user_id8";
try
{
    ResponseSendVerification result = await usersController.SendVerificationAsync(userId);
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
  "type": "SendVerification",
  "data": {
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "user_id": "11e95f8ec39de8fbdb0a4f1a",
    "hash": "123456781234567812345678",
    "created_ts": 1422040992
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |

