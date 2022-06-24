# Contacts

Below you will find information on all of the available endpoint actions, fields, requirements, and responses.

```csharp
ContactsController contactsController = client.ContactsController;
```

## Class Name

`ContactsController`

## Methods

* [Create a New Contact](../../doc/controllers/contacts.md#create-a-new-contact)
* [List All Contacts](../../doc/controllers/contacts.md#list-all-contacts)
* [Delete Contact](../../doc/controllers/contacts.md#delete-contact)
* [View Single Contact](../../doc/controllers/contacts.md#view-single-contact)
* [Update Contact](../../doc/controllers/contacts.md#update-contact)


# Create a New Contact

Create a new Contact

```csharp
CreateANewContactAsync(
    Models.V1ContactsRequest body,
    List<Models.ExpandEnum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1ContactsRequest`](../../doc/models/v1-contacts-request.md) | Body, Required | - |
| `expand` | [`List<Models.ExpandEnum>`](../../doc/models/expand-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request.<br>**Constraints**: *Unique Items Required*, *Pattern*: `^[\w]+$` |

## Response Type

[`Task<Models.ResponseContact>`](../../doc/models/response-contact.md)

## Example Usage

```csharp
var body = new V1ContactsRequest();
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.LastName = "Smith";

try
{
    ResponseContact result = await contactsController.CreateANewContactAsync(body, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Contact",
  "data": {
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
      "country": "US",
      "street": "43155 Main Street STE 2310-C"
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
    "active": 1
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# List All Contacts

List all Contacts

```csharp
ListAllContactsAsync(
    Models.Page page = null,
    Models.Sort1 sort = null,
    Models.Filter1 filter = null,
    List<Models.ExpandEnum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Models.Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `sort` | [`Models.Sort1`](../../doc/models/sort-1.md) | Query, Optional | You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods:<br><br>> /endpoint?sort={ "field_name": "asc", "field_name2": "desc" }<br>> <br>> /endpoint?sort[field_name]=asc&sort[field_name2]=desc |
| `filter` | [`Models.Filter1`](../../doc/models/filter-1.md) | Query, Optional | You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods:<br><br>> /endpoint?filter={ "field_name": "Value" }<br>> <br>> /endpoint?filter[field_name]=Value |
| `expand` | [`List<Models.ExpandEnum>`](../../doc/models/expand-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request.<br>**Constraints**: *Unique Items Required*, *Pattern*: `^[\w]+$` |

## Response Type

[`Task<Models.ResponseContactsCollection>`](../../doc/models/response-contacts-collection.md)

## Example Usage

```csharp
try
{
    ResponseContactsCollection result = await contactsController.ListAllContactsAsync(null, null, null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "ContactsCollection",
  "list": [
    {
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
        "country": "US",
        "street": "43155 Main Street STE 2310-C"
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
      "active": 1
    }
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Delete Contact

Delete Contact

```csharp
DeleteContactAsync(
    string contactId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `contactId` | `string` | Template, Required | Contact ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseContact>`](../../doc/models/response-contact.md)

## Example Usage

```csharp
string contactId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseContact result = await contactsController.DeleteContactAsync(contactId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Contact",
  "data": {
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
      "country": "US",
      "street": "43155 Main Street STE 2310-C"
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
    "active": 1
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# View Single Contact

View Single Contact

```csharp
ViewSingleContactAsync(
    string contactId,
    List<Models.ExpandEnum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `contactId` | `string` | Template, Required | Contact ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `expand` | [`List<Models.ExpandEnum>`](../../doc/models/expand-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request.<br>**Constraints**: *Unique Items Required*, *Pattern*: `^[\w]+$` |

## Response Type

[`Task<Models.ResponseContact>`](../../doc/models/response-contact.md)

## Example Usage

```csharp
string contactId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseContact result = await contactsController.ViewSingleContactAsync(contactId, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Contact",
  "data": {
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
      "country": "US",
      "street": "43155 Main Street STE 2310-C"
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
    "active": 1
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Update Contact

Update Contact

```csharp
UpdateContactAsync(
    string contactId,
    Models.V1ContactsRequest1 body,
    List<Models.ExpandEnum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `contactId` | `string` | Template, Required | Contact ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1ContactsRequest1`](../../doc/models/v1-contacts-request-1.md) | Body, Required | - |
| `expand` | [`List<Models.ExpandEnum>`](../../doc/models/expand-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request.<br>**Constraints**: *Unique Items Required*, *Pattern*: `^[\w]+$` |

## Response Type

[`Task<Models.ResponseContact>`](../../doc/models/response-contact.md)

## Example Usage

```csharp
string contactId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1ContactsRequest1();

try
{
    ResponseContact result = await contactsController.UpdateContactAsync(contactId, body, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Contact",
  "data": {
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
      "country": "US",
      "street": "43155 Main Street STE 2310-C"
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
    "active": 1
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |

