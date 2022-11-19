# Users

```csharp
UsersController usersController = client.UsersController;
```

## Class Name

`UsersController`

## Methods

* [Create a New API Key](../../doc/controllers/users.md#create-a-new-api-key)
* [Create a New User](../../doc/controllers/users.md#create-a-new-user)
* [List All User Related](../../doc/controllers/users.md#list-all-user-related)
* [Delete a User Record](../../doc/controllers/users.md#delete-a-user-record)
* [View Single User Record](../../doc/controllers/users.md#view-single-user-record)
* [Update a User Record](../../doc/controllers/users.md#update-a-user-record)
* [View Self Record](../../doc/controllers/users.md#view-self-record)


# Create a New API Key

Create a new API key

```csharp
CreateANewAPIKeyAsync(
    string userId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userId` | `string` | Template, Required | User ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseUser>`](../../doc/models/response-user.md)

## Example Usage

```csharp
string userId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseUser result = await usersController.CreateANewAPIKeyAsync(userId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "User",
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

Create a new user

```csharp
CreateANewUserAsync(
    Models.V1UsersRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1UsersRequest`](../../doc/models/v1-users-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseUser>`](../../doc/models/response-user.md)

## Example Usage

```csharp
var body = new V1UsersRequest();
body.Email = "email@domain.com";
body.LastName = "Smith";
body.PrimaryLocationId = "11e95f8ec39de8fbdb0a4f1a";
body.Username = "{user_name}";
body.UserTypeCode = UserTypeCodeEnum.Enum100;

try
{
    ResponseUser result = await usersController.CreateANewUserAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "User",
  "data": {
    "account_number": "5454545454545454",
    "address": "43155 Main Street STE 2310-C",
    "branding_domain_url": "{branding_domain_url}",
    "cell_phone": "3339998822",
    "city": "Novi",
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
    "state": "Michigan",
    "terms_condition_id": "11e95f8ec39de8fbdb0a4f1a",
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
    "status_id": true,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "status": true,
    "login_attempts": 0,
    "last_login_ts": 1422040992,
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "terms_accepted_ts": 1422040992,
    "terms_agree_ip": "192.168.0.10",
    "current_date_time": "2019-03-11T10:38:26-0700"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# List All User Related

List all user related

```csharp
ListAllUserRelatedAsync(
    Models.Page page = null,
    Models.Sort12 sort = null,
    Models.Filter12 filter = null,
    List<string> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Models.Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `sort` | [`Models.Sort12`](../../doc/models/sort-12.md) | Query, Optional | You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods:<br><br>> /endpoint?sort={ "field_name": "asc", "field_name2": "desc" }<br>> <br>> /endpoint?sort[field_name]=asc&sort[field_name2]=desc |
| `filter` | [`Models.Filter12`](../../doc/models/filter-12.md) | Query, Optional | You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods:<br><br>> /endpoint?filter={ "field_name": "Value" }<br>> <br>> /endpoint?filter[field_name]=Value |
| `expand` | `List<string>` | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request.<br>**Constraints**: *Unique Items Required*, *Pattern*: `^[\w]+$` |

## Response Type

[`Task<Models.ResponseUsersCollection>`](../../doc/models/response-users-collection.md)

## Example Usage

```csharp
try
{
    ResponseUsersCollection result = await usersController.ListAllUserRelatedAsync(null, null, null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "UsersCollection",
  "list": [
    {
      "account_number": "5454545454545454",
      "address": "43155 Main Street STE 2310-C",
      "branding_domain_url": "{branding_domain_url}",
      "cell_phone": "3339998822",
      "city": "Novi",
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
      "state": "Michigan",
      "terms_condition_id": "11e95f8ec39de8fbdb0a4f1a",
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
      "status_id": true,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "status": true,
      "login_attempts": 0,
      "last_login_ts": 1422040992,
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "terms_accepted_ts": 1422040992,
      "terms_agree_ip": "192.168.0.10",
      "current_date_time": "2019-03-11T10:38:26-0700"
    }
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Delete a User Record

Delete a user record

```csharp
DeleteAUserRecordAsync(
    string userId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userId` | `string` | Template, Required | - |

## Response Type

[`Task<Models.ResponseUser>`](../../doc/models/response-user.md)

## Example Usage

```csharp
string userId = "user_id8";

try
{
    ResponseUser result = await usersController.DeleteAUserRecordAsync(userId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "User",
  "data": {
    "account_number": "5454545454545454",
    "address": "43155 Main Street STE 2310-C",
    "branding_domain_url": "{branding_domain_url}",
    "cell_phone": "3339998822",
    "city": "Novi",
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
    "state": "Michigan",
    "terms_condition_id": "11e95f8ec39de8fbdb0a4f1a",
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
    "status_id": true,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "status": true,
    "login_attempts": 0,
    "last_login_ts": 1422040992,
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "terms_accepted_ts": 1422040992,
    "terms_agree_ip": "192.168.0.10",
    "current_date_time": "2019-03-11T10:38:26-0700"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# View Single User Record

View single user record

```csharp
ViewSingleUserRecordAsync(
    string userId,
    List<string> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userId` | `string` | Template, Required | User ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `expand` | `List<string>` | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request.<br>**Constraints**: *Unique Items Required*, *Pattern*: `^[\w]+$` |

## Response Type

[`Task<Models.ResponseUser>`](../../doc/models/response-user.md)

## Example Usage

```csharp
string userId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseUser result = await usersController.ViewSingleUserRecordAsync(userId, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "User",
  "data": {
    "account_number": "5454545454545454",
    "address": "43155 Main Street STE 2310-C",
    "branding_domain_url": "{branding_domain_url}",
    "cell_phone": "3339998822",
    "city": "Novi",
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
    "state": "Michigan",
    "terms_condition_id": "11e95f8ec39de8fbdb0a4f1a",
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
    "status_id": true,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "status": true,
    "login_attempts": 0,
    "last_login_ts": 1422040992,
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "terms_accepted_ts": 1422040992,
    "terms_agree_ip": "192.168.0.10",
    "current_date_time": "2019-03-11T10:38:26-0700"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Update a User Record

Update a user record

```csharp
UpdateAUserRecordAsync(
    string userId,
    Models.V1UsersRequest1 body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userId` | `string` | Template, Required | User ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1UsersRequest1`](../../doc/models/v1-users-request-1.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseUser>`](../../doc/models/response-user.md)

## Example Usage

```csharp
string userId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1UsersRequest1();

try
{
    ResponseUser result = await usersController.UpdateAUserRecordAsync(userId, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "User",
  "data": {
    "account_number": "5454545454545454",
    "address": "43155 Main Street STE 2310-C",
    "branding_domain_url": "{branding_domain_url}",
    "cell_phone": "3339998822",
    "city": "Novi",
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
    "state": "Michigan",
    "terms_condition_id": "11e95f8ec39de8fbdb0a4f1a",
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
    "status_id": true,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "status": true,
    "login_attempts": 0,
    "last_login_ts": 1422040992,
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "terms_accepted_ts": 1422040992,
    "terms_agree_ip": "192.168.0.10",
    "current_date_time": "2019-03-11T10:38:26-0700"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# View Self Record

View self record

```csharp
ViewSelfRecordAsync(
    List<string> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `expand` | `List<string>` | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request.<br>**Constraints**: *Unique Items Required*, *Pattern*: `^[\w]+$` |

## Response Type

[`Task<Models.ResponseUser>`](../../doc/models/response-user.md)

## Example Usage

```csharp
try
{
    ResponseUser result = await usersController.ViewSelfRecordAsync(null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "User",
  "data": {
    "account_number": "5454545454545454",
    "address": "43155 Main Street STE 2310-C",
    "branding_domain_url": "{branding_domain_url}",
    "cell_phone": "3339998822",
    "city": "Novi",
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
    "state": "Michigan",
    "terms_condition_id": "11e95f8ec39de8fbdb0a4f1a",
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
    "status_id": true,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "status": true,
    "login_attempts": 0,
    "last_login_ts": 1422040992,
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "terms_accepted_ts": 1422040992,
    "terms_agree_ip": "192.168.0.10",
    "current_date_time": "2019-03-11T10:38:26-0700"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |

