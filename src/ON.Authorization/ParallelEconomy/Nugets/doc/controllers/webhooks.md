# Webhooks

```csharp
WebhooksController webhooksController = client.WebhooksController;
```

## Class Name

`WebhooksController`

## Methods

* [Create a New Transaction Batch Postback Config](../../doc/controllers/webhooks.md#create-a-new-transaction-batch-postback-config)
* [Create a New Contact Postback Config](../../doc/controllers/webhooks.md#create-a-new-contact-postback-config)
* [Create a New Transaction Postback Config](../../doc/controllers/webhooks.md#create-a-new-transaction-postback-config)
* [Delete a Postback Config](../../doc/controllers/webhooks.md#delete-a-postback-config)
* [Update Transaction Batch Postback Config](../../doc/controllers/webhooks.md#update-transaction-batch-postback-config)
* [Update Contact Postback Config](../../doc/controllers/webhooks.md#update-contact-postback-config)
* [Update Transaction Postback Config](../../doc/controllers/webhooks.md#update-transaction-postback-config)


# Create a New Transaction Batch Postback Config

```csharp
CreateANewTransactionBatchPostbackConfigAsync(
    Models.V1WebhooksBatchRequest body,
    List<Models.Expand101Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1WebhooksBatchRequest`](../../doc/models/v1-webhooks-batch-request.md) | Body, Required | - |
| `expand` | [`List<Expand101Enum>`](../../doc/models/expand-101-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseWebhook>`](../../doc/models/response-webhook.md)

## Example Usage

```csharp
V1WebhooksBatchRequest body = new V1WebhooksBatchRequest
{
    IsActive = true,
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    OnCreate = true,
    OnUpdate = true,
    OnDelete = true,
    ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    NumberOfAttempts = 1,
    Url = "https://127.0.0.1/receiver",
    AttemptInterval = 300,
    BasicAuthUsername = "tester",
    BasicAuthPassword = "Test@522",
    Expands = "changelogs,tags",
    Format = FormatEnum.Apidefault,
    PostbackConfigId = "11e95f8ec39de8fbdb0a4f1a",
    Resource = Resource12Enum.Contact,
};

try
{
    ResponseWebhook result = await webhooksController.CreateANewTransactionBatchPostbackConfigAsync(body);
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
  "type": "Webhook",
  "data": {
    "attempt_interval": 300,
    "basic_auth_username": "username",
    "basic_auth_password": "password",
    "expands": "changelogs,tags",
    "format": "api-default",
    "is_active": true,
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "on_create": true,
    "on_update": true,
    "on_delete": true,
    "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "resource": "contact",
    "number_of_attempts": 1,
    "url": "https://127.0.0.1/receiver",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "postback_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
        "next_run_ts": 1422040992,
        "created_ts": 1422040992,
        "model_id": "11e95f8ec39de8fbdb0a4f1a"
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


# Create a New Contact Postback Config

```csharp
CreateANewContactPostbackConfigAsync(
    Models.V1WebhooksContactRequest body,
    List<Models.Expand101Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1WebhooksContactRequest`](../../doc/models/v1-webhooks-contact-request.md) | Body, Required | - |
| `expand` | [`List<Expand101Enum>`](../../doc/models/expand-101-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseWebhook>`](../../doc/models/response-webhook.md)

## Example Usage

```csharp
V1WebhooksContactRequest body = new V1WebhooksContactRequest
{
    IsActive = true,
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    OnCreate = true,
    OnUpdate = true,
    OnDelete = true,
    NumberOfAttempts = 1,
    Url = "https://127.0.0.1/receiver",
    AttemptInterval = 300,
    BasicAuthUsername = "tester",
    BasicAuthPassword = "Test@522",
    Expands = "changelogs,tags",
    Format = FormatEnum.Apidefault,
    PostbackConfigId = "11e95f8ec39de8fbdb0a4f1a",
    ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    Resource = Resource12Enum.Contact,
};

try
{
    ResponseWebhook result = await webhooksController.CreateANewContactPostbackConfigAsync(body);
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
  "type": "Webhook",
  "data": {
    "attempt_interval": 300,
    "basic_auth_username": "username",
    "basic_auth_password": "password",
    "expands": "changelogs,tags",
    "format": "api-default",
    "is_active": true,
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "on_create": true,
    "on_update": true,
    "on_delete": true,
    "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "resource": "contact",
    "number_of_attempts": 1,
    "url": "https://127.0.0.1/receiver",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "postback_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
        "next_run_ts": 1422040992,
        "created_ts": 1422040992,
        "model_id": "11e95f8ec39de8fbdb0a4f1a"
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


# Create a New Transaction Postback Config

```csharp
CreateANewTransactionPostbackConfigAsync(
    Models.V1WebhooksTransactionRequest body,
    List<Models.Expand101Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`V1WebhooksTransactionRequest`](../../doc/models/v1-webhooks-transaction-request.md) | Body, Required | - |
| `expand` | [`List<Expand101Enum>`](../../doc/models/expand-101-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseWebhook>`](../../doc/models/response-webhook.md)

## Example Usage

```csharp
V1WebhooksTransactionRequest body = new V1WebhooksTransactionRequest
{
    IsActive = true,
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    OnCreate = true,
    OnUpdate = true,
    OnDelete = true,
    ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    NumberOfAttempts = 1,
    Url = "https://127.0.0.1/receiver",
    AttemptInterval = 300,
    BasicAuthUsername = "tester",
    BasicAuthPassword = "Test@522",
    Expands = "changelogs,tags",
    Format = FormatEnum.Apidefault,
    PostbackConfigId = "11e95f8ec39de8fbdb0a4f1a",
    Resource = Resource12Enum.Contact,
};

try
{
    ResponseWebhook result = await webhooksController.CreateANewTransactionPostbackConfigAsync(body);
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
  "type": "Webhook",
  "data": {
    "attempt_interval": 300,
    "basic_auth_username": "username",
    "basic_auth_password": "password",
    "expands": "changelogs,tags",
    "format": "api-default",
    "is_active": true,
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "on_create": true,
    "on_update": true,
    "on_delete": true,
    "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "resource": "contact",
    "number_of_attempts": 1,
    "url": "https://127.0.0.1/receiver",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "postback_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
        "next_run_ts": 1422040992,
        "created_ts": 1422040992,
        "model_id": "11e95f8ec39de8fbdb0a4f1a"
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


# Delete a Postback Config

```csharp
DeleteAPostbackConfigAsync(
    string webhookId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `webhookId` | `string` | Template, Required | Postback Config ID |

## Response Type

[`Task<Models.ResponseWebhook>`](../../doc/models/response-webhook.md)

## Example Usage

```csharp
string webhookId = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseWebhook result = await webhooksController.DeleteAPostbackConfigAsync(webhookId);
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
  "type": "Webhook",
  "data": {
    "attempt_interval": 300,
    "basic_auth_username": "username",
    "basic_auth_password": "password",
    "expands": "changelogs,tags",
    "format": "api-default",
    "is_active": true,
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "on_create": true,
    "on_update": true,
    "on_delete": true,
    "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "resource": "contact",
    "number_of_attempts": 1,
    "url": "https://127.0.0.1/receiver",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "postback_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
        "next_run_ts": 1422040992,
        "created_ts": 1422040992,
        "model_id": "11e95f8ec39de8fbdb0a4f1a"
      }
    ]
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Update Transaction Batch Postback Config

```csharp
UpdateTransactionBatchPostbackConfigAsync(
    string webhookId,
    Models.V1WebhooksBatchRequest1 body,
    List<Models.Expand101Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `webhookId` | `string` | Template, Required | Postback Config ID |
| `body` | [`V1WebhooksBatchRequest1`](../../doc/models/v1-webhooks-batch-request-1.md) | Body, Required | - |
| `expand` | [`List<Expand101Enum>`](../../doc/models/expand-101-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseWebhook>`](../../doc/models/response-webhook.md)

## Example Usage

```csharp
string webhookId = "11e95f8ec39de8fbdb0a4f1a";
V1WebhooksBatchRequest1 body = new V1WebhooksBatchRequest1
{
    AttemptInterval = 300,
    BasicAuthUsername = "tester",
    BasicAuthPassword = "Test@522",
    Expands = "changelogs,tags",
    Format = FormatEnum.Apidefault,
    IsActive = true,
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    OnCreate = true,
    OnUpdate = true,
    OnDelete = true,
    PostbackConfigId = "11e95f8ec39de8fbdb0a4f1a",
    ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    Resource = Resource12Enum.Contact,
    NumberOfAttempts = 1,
    Url = "https://127.0.0.1/receiver",
};

try
{
    ResponseWebhook result = await webhooksController.UpdateTransactionBatchPostbackConfigAsync(
        webhookId,
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
  "type": "Webhook",
  "data": {
    "attempt_interval": 300,
    "basic_auth_username": "username",
    "basic_auth_password": "password",
    "expands": "changelogs,tags",
    "format": "api-default",
    "is_active": true,
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "on_create": true,
    "on_update": true,
    "on_delete": true,
    "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "resource": "contact",
    "number_of_attempts": 1,
    "url": "https://127.0.0.1/receiver",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "postback_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
        "next_run_ts": 1422040992,
        "created_ts": 1422040992,
        "model_id": "11e95f8ec39de8fbdb0a4f1a"
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


# Update Contact Postback Config

```csharp
UpdateContactPostbackConfigAsync(
    string webhookId,
    Models.V1WebhooksContactRequest1 body,
    List<Models.Expand101Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `webhookId` | `string` | Template, Required | Postback Config ID |
| `body` | [`V1WebhooksContactRequest1`](../../doc/models/v1-webhooks-contact-request-1.md) | Body, Required | - |
| `expand` | [`List<Expand101Enum>`](../../doc/models/expand-101-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseWebhook>`](../../doc/models/response-webhook.md)

## Example Usage

```csharp
string webhookId = "11e95f8ec39de8fbdb0a4f1a";
V1WebhooksContactRequest1 body = new V1WebhooksContactRequest1
{
    AttemptInterval = 300,
    BasicAuthUsername = "tester",
    BasicAuthPassword = "Test@522",
    Expands = "changelogs,tags",
    Format = FormatEnum.Apidefault,
    IsActive = true,
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    OnCreate = true,
    OnUpdate = true,
    OnDelete = true,
    PostbackConfigId = "11e95f8ec39de8fbdb0a4f1a",
    ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    Resource = Resource12Enum.Contact,
    NumberOfAttempts = 1,
    Url = "https://127.0.0.1/receiver",
};

try
{
    ResponseWebhook result = await webhooksController.UpdateContactPostbackConfigAsync(
        webhookId,
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
  "type": "Webhook",
  "data": {
    "attempt_interval": 300,
    "basic_auth_username": "username",
    "basic_auth_password": "password",
    "expands": "changelogs,tags",
    "format": "api-default",
    "is_active": true,
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "on_create": true,
    "on_update": true,
    "on_delete": true,
    "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "resource": "contact",
    "number_of_attempts": 1,
    "url": "https://127.0.0.1/receiver",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "postback_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
        "next_run_ts": 1422040992,
        "created_ts": 1422040992,
        "model_id": "11e95f8ec39de8fbdb0a4f1a"
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


# Update Transaction Postback Config

```csharp
UpdateTransactionPostbackConfigAsync(
    string webhookId,
    Models.V1WebhooksTransactionRequest1 body,
    List<Models.Expand101Enum> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `webhookId` | `string` | Template, Required | Postback Config ID |
| `body` | [`V1WebhooksTransactionRequest1`](../../doc/models/v1-webhooks-transaction-request-1.md) | Body, Required | - |
| `expand` | [`List<Expand101Enum>`](../../doc/models/expand-101-enum.md) | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the token belongs to, this data can be returned in the accountvaults endpoint request. |

## Response Type

[`Task<Models.ResponseWebhook>`](../../doc/models/response-webhook.md)

## Example Usage

```csharp
string webhookId = "11e95f8ec39de8fbdb0a4f1a";
V1WebhooksTransactionRequest1 body = new V1WebhooksTransactionRequest1
{
    AttemptInterval = 300,
    BasicAuthUsername = "tester",
    BasicAuthPassword = "Test@522",
    Expands = "changelogs,tags",
    Format = FormatEnum.Apidefault,
    IsActive = true,
    LocationId = "11e95f8ec39de8fbdb0a4f1a",
    OnCreate = true,
    OnUpdate = true,
    OnDelete = true,
    PostbackConfigId = "11e95f8ec39de8fbdb0a4f1a",
    ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a",
    Resource = Resource12Enum.Contact,
    NumberOfAttempts = 1,
    Url = "https://127.0.0.1/receiver",
};

try
{
    ResponseWebhook result = await webhooksController.UpdateTransactionPostbackConfigAsync(
        webhookId,
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
  "type": "Webhook",
  "data": {
    "attempt_interval": 300,
    "basic_auth_username": "username",
    "basic_auth_password": "password",
    "expands": "changelogs,tags",
    "format": "api-default",
    "is_active": true,
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "on_create": true,
    "on_update": true,
    "on_delete": true,
    "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "resource": "contact",
    "number_of_attempts": 1,
    "url": "https://127.0.0.1/receiver",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "postback_logs": [
      {
        "id": "11e95f8ec39de8fbdb0a4f1a",
        "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
        "changelog_id": "11e95f8ec39de8fbdb0a4f1a",
        "next_run_ts": 1422040992,
        "created_ts": 1422040992,
        "model_id": "11e95f8ec39de8fbdb0a4f1a"
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

