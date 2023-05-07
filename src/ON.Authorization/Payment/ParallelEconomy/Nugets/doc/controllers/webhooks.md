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

Create a new transaction batch postback config

```csharp
CreateANewTransactionBatchPostbackConfigAsync(
    Models.V1WebhooksBatchRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1WebhooksBatchRequest`](../../doc/models/v1-webhooks-batch-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseWebhook>`](../../doc/models/response-webhook.md)

## Example Usage

```csharp
var body = new V1WebhooksBatchRequest();
body.IsActive = true;
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.OnCreate = OnCreateEnum.Enum1;
body.OnUpdate = OnUpdateEnum.Enum1;
body.OnDelete = OnDeleteEnum.Enum1;
body.ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a";
body.NumberOfAttempts = 1;
body.Url = "https://127.0.0.1/receiver";

try
{
    ResponseWebhook result = await webhooksController.CreateANewTransactionBatchPostbackConfigAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Webhook",
  "data": {
    "attempt_interval": 300,
    "basic_auth_username": "tester",
    "basic_auth_password": "Test@522",
    "expands": "changelogs,tags",
    "format": "api-default",
    "is_active": true,
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "on_create": 1,
    "on_update": 1,
    "on_delete": 1,
    "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "resource": "contact",
    "number_of_attempts": 1,
    "url": "https://127.0.0.1/receiver",
    "id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Create a New Contact Postback Config

Create a new contact postback config

```csharp
CreateANewContactPostbackConfigAsync(
    Models.V1WebhooksContactRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1WebhooksContactRequest`](../../doc/models/v1-webhooks-contact-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseWebhook>`](../../doc/models/response-webhook.md)

## Example Usage

```csharp
var body = new V1WebhooksContactRequest();
body.IsActive = true;
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.OnCreate = OnCreateEnum.Enum1;
body.OnUpdate = OnUpdateEnum.Enum1;
body.OnDelete = OnDeleteEnum.Enum1;
body.NumberOfAttempts = 1;
body.Url = "https://127.0.0.1/receiver";

try
{
    ResponseWebhook result = await webhooksController.CreateANewContactPostbackConfigAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Webhook",
  "data": {
    "attempt_interval": 300,
    "basic_auth_username": "tester",
    "basic_auth_password": "Test@522",
    "expands": "changelogs,tags",
    "format": "api-default",
    "is_active": true,
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "on_create": 1,
    "on_update": 1,
    "on_delete": 1,
    "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "resource": "contact",
    "number_of_attempts": 1,
    "url": "https://127.0.0.1/receiver",
    "id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Create a New Transaction Postback Config

Create a new transaction postback config

```csharp
CreateANewTransactionPostbackConfigAsync(
    Models.V1WebhooksTransactionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1WebhooksTransactionRequest`](../../doc/models/v1-webhooks-transaction-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseWebhook>`](../../doc/models/response-webhook.md)

## Example Usage

```csharp
var body = new V1WebhooksTransactionRequest();
body.IsActive = true;
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.OnCreate = OnCreateEnum.Enum1;
body.OnUpdate = OnUpdateEnum.Enum1;
body.OnDelete = OnDeleteEnum.Enum1;
body.ProductTransactionId = "11e95f8ec39de8fbdb0a4f1a";
body.NumberOfAttempts = 1;
body.Url = "https://127.0.0.1/receiver";

try
{
    ResponseWebhook result = await webhooksController.CreateANewTransactionPostbackConfigAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Webhook",
  "data": {
    "attempt_interval": 300,
    "basic_auth_username": "tester",
    "basic_auth_password": "Test@522",
    "expands": "changelogs,tags",
    "format": "api-default",
    "is_active": true,
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "on_create": 1,
    "on_update": 1,
    "on_delete": 1,
    "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "resource": "contact",
    "number_of_attempts": 1,
    "url": "https://127.0.0.1/receiver",
    "id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Delete a Postback Config

Delete a postback config

```csharp
DeleteAPostbackConfigAsync(
    string webhookId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `webhookId` | `string` | Template, Required | Postback Config ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseWebhook>`](../../doc/models/response-webhook.md)

## Example Usage

```csharp
string webhookId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseWebhook result = await webhooksController.DeleteAPostbackConfigAsync(webhookId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Webhook",
  "data": {
    "attempt_interval": 300,
    "basic_auth_username": "tester",
    "basic_auth_password": "Test@522",
    "expands": "changelogs,tags",
    "format": "api-default",
    "is_active": true,
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "on_create": 1,
    "on_update": 1,
    "on_delete": 1,
    "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "resource": "contact",
    "number_of_attempts": 1,
    "url": "https://127.0.0.1/receiver",
    "id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Update Transaction Batch Postback Config

Update transaction batch postback config

```csharp
UpdateTransactionBatchPostbackConfigAsync(
    string webhookId,
    Models.V1WebhooksBatchRequest1 body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `webhookId` | `string` | Template, Required | Postback Config ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1WebhooksBatchRequest1`](../../doc/models/v1-webhooks-batch-request-1.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseWebhook>`](../../doc/models/response-webhook.md)

## Example Usage

```csharp
string webhookId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1WebhooksBatchRequest1();

try
{
    ResponseWebhook result = await webhooksController.UpdateTransactionBatchPostbackConfigAsync(webhookId, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Webhook",
  "data": {
    "attempt_interval": 300,
    "basic_auth_username": "tester",
    "basic_auth_password": "Test@522",
    "expands": "changelogs,tags",
    "format": "api-default",
    "is_active": true,
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "on_create": 1,
    "on_update": 1,
    "on_delete": 1,
    "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "resource": "contact",
    "number_of_attempts": 1,
    "url": "https://127.0.0.1/receiver",
    "id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Update Contact Postback Config

Update contact postback config

```csharp
UpdateContactPostbackConfigAsync(
    string webhookId,
    Models.V1WebhooksContactRequest1 body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `webhookId` | `string` | Template, Required | Postback Config ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1WebhooksContactRequest1`](../../doc/models/v1-webhooks-contact-request-1.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseWebhook>`](../../doc/models/response-webhook.md)

## Example Usage

```csharp
string webhookId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1WebhooksContactRequest1();

try
{
    ResponseWebhook result = await webhooksController.UpdateContactPostbackConfigAsync(webhookId, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Webhook",
  "data": {
    "attempt_interval": 300,
    "basic_auth_username": "tester",
    "basic_auth_password": "Test@522",
    "expands": "changelogs,tags",
    "format": "api-default",
    "is_active": true,
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "on_create": 1,
    "on_update": 1,
    "on_delete": 1,
    "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "resource": "contact",
    "number_of_attempts": 1,
    "url": "https://127.0.0.1/receiver",
    "id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Update Transaction Postback Config

Update transaction postback config

```csharp
UpdateTransactionPostbackConfigAsync(
    string webhookId,
    Models.V1WebhooksTransactionRequest1 body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `webhookId` | `string` | Template, Required | Postback Config ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1WebhooksTransactionRequest1`](../../doc/models/v1-webhooks-transaction-request-1.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseWebhook>`](../../doc/models/response-webhook.md)

## Example Usage

```csharp
string webhookId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1WebhooksTransactionRequest1();

try
{
    ResponseWebhook result = await webhooksController.UpdateTransactionPostbackConfigAsync(webhookId, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Webhook",
  "data": {
    "attempt_interval": 300,
    "basic_auth_username": "tester",
    "basic_auth_password": "Test@522",
    "expands": "changelogs,tags",
    "format": "api-default",
    "is_active": true,
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "on_create": 1,
    "on_update": 1,
    "on_delete": 1,
    "postback_config_id": "11e95f8ec39de8fbdb0a4f1a",
    "product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "resource": "contact",
    "number_of_attempts": 1,
    "url": "https://127.0.0.1/receiver",
    "id": "11e95f8ec39de8fbdb0a4f1a"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |

