# Tags

```csharp
TagsController tagsController = client.TagsController;
```

## Class Name

`TagsController`

## Methods

* [Create a New Tag](../../doc/controllers/tags.md#create-a-new-tag)
* [List All Tags Related](../../doc/controllers/tags.md#list-all-tags-related)
* [Delete Tag Record](../../doc/controllers/tags.md#delete-tag-record)
* [View Single Tags Record](../../doc/controllers/tags.md#view-single-tags-record)
* [Update Tag Record](../../doc/controllers/tags.md#update-tag-record)


# Create a New Tag

```csharp
CreateANewTagAsync(
    Models.V1TagsRequest body,
    List<Models.Expand34Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1TagsRequest`](../../doc/models/v1-tags-request.md) | Body, Required | - |
| `expand` | [`List<Expand34Enum>`](../../doc/models/expand-34-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseTag>`](../../doc/models/response-tag.md)

## Example Usage

```csharp
V1TagsRequest body = new V1TagsRequest
{
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    Title = "My terminal",
};

try
{
    ResponseTag result = await tagsController.CreateANewTagAsync(body);
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
  "type": "Tag",
  "data": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "title": "My terminal",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
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
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# List All Tags Related

```csharp
ListAllTagsRelatedAsync(
    Models.Page page = null,
    List<Models.Order19> order = null,
    List<Models.FilterBy> filterBy = null,
    List<Models.Expand34Enum> expand = null,
    Models.Format1Enum? format = null,
    string typeahead = null,
    List<Models.Field43Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `order` | [`List<Order19>`](../../doc/models/order-19.md) | Query, Optional | Criteria used in query string parameters to order results.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.  Array objects must be valid json.<br><br>> /endpoint?order=[{ "key": "created_ts", "operator": "asc"}]<br>> <br>> /endpoint?order=[{ "key": "balance", "operator": "desc"},{ "key": "created_ts", "operator": "asc"}] |
| `filterBy` | [`List<FilterBy>`](../../doc/models/filter-by.md) | Query, Optional | Filter criteria that can be used in query string parameters.  Most fields from the endpoint results can be used as a `key`.  Unsupported fields or operators will return a `412`.<br><br>> /endpoint?filter_by=[{ "key": "first_name", "operator": "=", "value": "Fred" }]<br>> <br>> /endpoint?filter_by=[{ "key": "account_type", "operator": "=", "value": "VISA" }]<br>> <br>> /endpoint?filter_by=[{ "key": "created_ts", "operator": ">=", "value": "946702799" }, { "key": "created_ts", "operator": "<=", value: "1695061891" }]<br>> <br>> /endpoint?filter_by=[{ "key": "last_name", "operator": "IN", "value": "Williams,Brown,Allman" }] |
| `expand` | [`List<Expand34Enum>`](../../doc/models/expand-34-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `format` | [`Format1Enum?`](../../doc/models/format-1-enum.md) | Query, Optional | Reporting format, valid values: csv, tsv |
| `typeahead` | `string` | Query, Optional | You can use any `field_name` from this endpoint results to order the list using the value provided as filter for the same `field_name`. It will be ordered using the following rules: 1) Exact match, 2) Starts with, 3) Contains. |
| `fields` | [`List<Field43Enum>`](../../doc/models/field-43-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseTagsCollection>`](../../doc/models/response-tags-collection.md)

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
    ResponseTagsCollection result = await tagsController.ListAllTagsRelatedAsync(
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
  "type": "TagsCollection",
  "list": [
    {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": "My terminal",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
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


# Delete Tag Record

```csharp
DeleteTagRecordAsync(
    string tagId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tagId` | `string` | Template, Required | Tag ID |

## Response Type

[`Task<Models.ResponseTag>`](../../doc/models/response-tag.md)

## Example Usage

```csharp
string tagId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseTag result = await tagsController.DeleteTagRecordAsync(tagId);
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
  "type": "Tag",
  "data": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "title": "My terminal",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
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
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# View Single Tags Record

```csharp
ViewSingleTagsRecordAsync(
    string tagId,
    List<Models.Expand34Enum> expand = null,
    List<Models.Field43Enum> fields = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tagId` | `string` | Template, Required | Tag ID |
| `expand` | [`List<Expand34Enum>`](../../doc/models/expand-34-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |
| `fields` | [`List<Field43Enum>`](../../doc/models/field-43-enum.md) | Query, Optional | You can use any `field_name` from this endpoint results to filter the list of fields returned on the response. |

## Response Type

[`Task<Models.ResponseTag>`](../../doc/models/response-tag.md)

## Example Usage

```csharp
string tagId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseTag result = await tagsController.ViewSingleTagsRecordAsync(tagId);
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
  "type": "Tag",
  "data": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "title": "My terminal",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
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
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Update Tag Record

```csharp
UpdateTagRecordAsync(
    string tagId,
    Models.V1TagsRequest1 body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tagId` | `string` | Template, Required | Tag ID |
| `body` | [`V1TagsRequest1`](../../doc/models/v1-tags-request-1.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTag>`](../../doc/models/response-tag.md)

## Example Usage

```csharp
string tagId = "11e95f8ec39de8fbdb0a4f1a";
V1TagsRequest1 body = new V1TagsRequest1
{
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    Title = "My terminal",
};

try
{
    ResponseTag result = await tagsController.UpdateTagRecordAsync(
        tagId,
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
  "type": "Tag",
  "data": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "title": "My terminal",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
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
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |

