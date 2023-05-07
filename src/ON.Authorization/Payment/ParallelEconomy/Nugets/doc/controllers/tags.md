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

Create a new tag

```csharp
CreateANewTagAsync(
    Models.V1TagsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TagsRequest`](../../doc/models/v1-tags-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTag>`](../../doc/models/response-tag.md)

## Example Usage

```csharp
var body = new V1TagsRequest();
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.Title = "My terminal";

try
{
    ResponseTag result = await tagsController.CreateANewTagAsync(body);
}
catch (ApiException e){};
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
    "modified_ts": 1422040992
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# List All Tags Related

List all tags related

```csharp
ListAllTagsRelatedAsync(
    Models.Page page = null,
    Models.Sort8 sort = null,
    Models.Filter8 filter = null,
    List<string> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Models.Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `sort` | [`Models.Sort8`](../../doc/models/sort-8.md) | Query, Optional | You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods:<br><br>> /endpoint?sort={ "field_name": "asc", "field_name2": "desc" }<br>> <br>> /endpoint?sort[field_name]=asc&sort[field_name2]=desc |
| `filter` | [`Models.Filter8`](../../doc/models/filter-8.md) | Query, Optional | You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods:<br><br>> /endpoint?filter={ "field_name": "Value" }<br>> <br>> /endpoint?filter[field_name]=Value |
| `expand` | `List<string>` | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request.<br>**Constraints**: *Unique Items Required*, *Pattern*: `^[\w]+$` |

## Response Type

[`Task<Models.ResponseTagsCollection>`](../../doc/models/response-tags-collection.md)

## Example Usage

```csharp
try
{
    ResponseTagsCollection result = await tagsController.ListAllTagsRelatedAsync(null, null, null, null);
}
catch (ApiException e){};
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
      "modified_ts": 1422040992
    }
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Delete Tag Record

Delete tag record

```csharp
DeleteTagRecordAsync(
    string tagId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tagId` | `string` | Template, Required | Tag ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseTag>`](../../doc/models/response-tag.md)

## Example Usage

```csharp
string tagId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseTag result = await tagsController.DeleteTagRecordAsync(tagId);
}
catch (ApiException e){};
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
    "modified_ts": 1422040992
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# View Single Tags Record

View single tags record

```csharp
ViewSingleTagsRecordAsync(
    string tagId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tagId` | `string` | Template, Required | Tag ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseTag>`](../../doc/models/response-tag.md)

## Example Usage

```csharp
string tagId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseTag result = await tagsController.ViewSingleTagsRecordAsync(tagId);
}
catch (ApiException e){};
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
    "modified_ts": 1422040992
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Update Tag Record

Update tag record

```csharp
UpdateTagRecordAsync(
    string tagId,
    Models.V1TagsRequest1 body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tagId` | `string` | Template, Required | Tag ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1TagsRequest1`](../../doc/models/v1-tags-request-1.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTag>`](../../doc/models/response-tag.md)

## Example Usage

```csharp
string tagId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1TagsRequest1();

try
{
    ResponseTag result = await tagsController.UpdateTagRecordAsync(tagId, body);
}
catch (ApiException e){};
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
    "modified_ts": 1422040992
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |

