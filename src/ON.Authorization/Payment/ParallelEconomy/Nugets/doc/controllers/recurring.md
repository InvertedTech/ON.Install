# Recurring

The recurrings endpoint is used to run a recurring transaction one or more times. There are two different types of recurrings:

1. **ongoing** (recurring_type_id="o") - a recurring that runs until it is deleted or an end date has been set.
2. **installment** (recurring_type_id="i") - a recurring that runs a fixed number of times, regardless of approval or decline.

When setting up a reccuring, it isn't necessarily linked directly to a contact, it is linked to an account vault through the account_vault_id or account_vault_api_id field. The account vault is then in turn linked to a contact. So in order to create a recurring, you must first create a contact, then create an account vault for that contact. Then the id of the account vault can be used for the recurring as account_vault_id.

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

Create a new recurring record

```csharp
CreateANewRecurringRecordAsync(
    Models.V1RecurringsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1RecurringsRequest`](../../doc/models/v1-recurrings-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseRecurring>`](../../doc/models/response-recurring.md)

## Example Usage

```csharp
var body = new V1RecurringsRequest();
body.AccountVaultId = "11e95f8ec39de8fbdb0a4f1a";
body.Interval = 1;
body.IntervalType = IntervalTypeEnum.D;
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.StartDate = "2021-12-01";
body.TransactionAmount = 28.86;

try
{
    ResponseRecurring result = await recurringController.CreateANewRecurringRecordAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Recurring",
  "data": {
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": 1,
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
    "transaction_amount": 3,
    "terms_agree": true,
    "terms_agree_ip": "192.168.0.10",
    "recurring_c1": "recurring custom data 1",
    "recurring_c2": "recurring custom data 2",
    "recurring_c3": "recurring custom data 3",
    "send_to_proc_as_recur": true,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "next_run_date": "2021-12-01",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "recurring_type_id": "i"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# List All Recurring Record

List all recurring record

```csharp
ListAllRecurringRecordAsync(
    Models.Page page = null,
    Models.Sort6 sort = null,
    Models.Filter6 filter = null,
    List<string> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Models.Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `sort` | [`Models.Sort6`](../../doc/models/sort-6.md) | Query, Optional | You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods:<br><br>> /endpoint?sort={ "field_name": "asc", "field_name2": "desc" }<br>> <br>> /endpoint?sort[field_name]=asc&sort[field_name2]=desc |
| `filter` | [`Models.Filter6`](../../doc/models/filter-6.md) | Query, Optional | You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods:<br><br>> /endpoint?filter={ "field_name": "Value" }<br>> <br>> /endpoint?filter[field_name]=Value |
| `expand` | `List<string>` | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request.<br>**Constraints**: *Unique Items Required*, *Pattern*: `^[\w]+$` |

## Response Type

[`Task<Models.ResponseRecurringsCollection>`](../../doc/models/response-recurrings-collection.md)

## Example Usage

```csharp
try
{
    ResponseRecurringsCollection result = await recurringController.ListAllRecurringRecordAsync(null, null, null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "RecurringsCollection",
  "list": [
    {
      "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
      "active": 1,
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
      "transaction_amount": 3,
      "terms_agree": true,
      "terms_agree_ip": "192.168.0.10",
      "recurring_c1": "recurring custom data 1",
      "recurring_c2": "recurring custom data 2",
      "recurring_c3": "recurring custom data 3",
      "send_to_proc_as_recur": true,
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "next_run_date": "2021-12-01",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "recurring_type_id": "i"
    }
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Delete Recurring Record

Delete recurring record

```csharp
DeleteRecurringRecordAsync(
    string recurringId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `recurringId` | `string` | Template, Required | Recurring ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseRecurring>`](../../doc/models/response-recurring.md)

## Example Usage

```csharp
string recurringId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseRecurring result = await recurringController.DeleteRecurringRecordAsync(recurringId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Recurring",
  "data": {
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": 1,
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
    "transaction_amount": 3,
    "terms_agree": true,
    "terms_agree_ip": "192.168.0.10",
    "recurring_c1": "recurring custom data 1",
    "recurring_c2": "recurring custom data 2",
    "recurring_c3": "recurring custom data 3",
    "send_to_proc_as_recur": true,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "next_run_date": "2021-12-01",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "recurring_type_id": "i"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# View Single Recurring Record

View single recurring record

```csharp
ViewSingleRecurringRecordAsync(
    string recurringId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `recurringId` | `string` | Template, Required | Recurring ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseRecurring>`](../../doc/models/response-recurring.md)

## Example Usage

```csharp
string recurringId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseRecurring result = await recurringController.ViewSingleRecurringRecordAsync(recurringId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Recurring",
  "data": {
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": 1,
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
    "transaction_amount": 3,
    "terms_agree": true,
    "terms_agree_ip": "192.168.0.10",
    "recurring_c1": "recurring custom data 1",
    "recurring_c2": "recurring custom data 2",
    "recurring_c3": "recurring custom data 3",
    "send_to_proc_as_recur": true,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "next_run_date": "2021-12-01",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "recurring_type_id": "i"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Update Recurring Payment

Update recurring payment

```csharp
UpdateRecurringPaymentAsync(
    string recurringId,
    Models.V1RecurringsRequest1 body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `recurringId` | `string` | Template, Required | Recurring ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1RecurringsRequest1`](../../doc/models/v1-recurrings-request-1.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseRecurring>`](../../doc/models/response-recurring.md)

## Example Usage

```csharp
string recurringId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1RecurringsRequest1();

try
{
    ResponseRecurring result = await recurringController.UpdateRecurringPaymentAsync(recurringId, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Recurring",
  "data": {
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": 1,
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
    "transaction_amount": 3,
    "terms_agree": true,
    "terms_agree_ip": "192.168.0.10",
    "recurring_c1": "recurring custom data 1",
    "recurring_c2": "recurring custom data 2",
    "recurring_c3": "recurring custom data 3",
    "send_to_proc_as_recur": true,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "next_run_date": "2021-12-01",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "recurring_type_id": "i"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Activate Recurring Payment

Activate recurring payment

```csharp
ActivateRecurringPaymentAsync(
    string recurringId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `recurringId` | `string` | Template, Required | Recurring ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseRecurring>`](../../doc/models/response-recurring.md)

## Example Usage

```csharp
string recurringId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseRecurring result = await recurringController.ActivateRecurringPaymentAsync(recurringId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Recurring",
  "data": {
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": 1,
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
    "transaction_amount": 3,
    "terms_agree": true,
    "terms_agree_ip": "192.168.0.10",
    "recurring_c1": "recurring custom data 1",
    "recurring_c2": "recurring custom data 2",
    "recurring_c3": "recurring custom data 3",
    "send_to_proc_as_recur": true,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "next_run_date": "2021-12-01",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "recurring_type_id": "i"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Defer Recurring Payment

Defer recurring payment

```csharp
DeferRecurringPaymentAsync(
    string recurringId,
    Models.V1RecurringsDeferPaymentRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `recurringId` | `string` | Template, Required | Recurring ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1RecurringsDeferPaymentRequest`](../../doc/models/v1-recurrings-defer-payment-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseRecurring>`](../../doc/models/response-recurring.md)

## Example Usage

```csharp
string recurringId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1RecurringsDeferPaymentRequest();
body.DeferCount = 5;

try
{
    ResponseRecurring result = await recurringController.DeferRecurringPaymentAsync(recurringId, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Recurring",
  "data": {
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": 1,
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
    "transaction_amount": 3,
    "terms_agree": true,
    "terms_agree_ip": "192.168.0.10",
    "recurring_c1": "recurring custom data 1",
    "recurring_c2": "recurring custom data 2",
    "recurring_c3": "recurring custom data 3",
    "send_to_proc_as_recur": true,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "next_run_date": "2021-12-01",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "recurring_type_id": "i"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Place on Hold Recurring Payment

Place on hold recurring payment

```csharp
PlaceOnHoldRecurringPaymentAsync(
    string recurringId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `recurringId` | `string` | Template, Required | Recurring ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseRecurring>`](../../doc/models/response-recurring.md)

## Example Usage

```csharp
string recurringId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseRecurring result = await recurringController.PlaceOnHoldRecurringPaymentAsync(recurringId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Recurring",
  "data": {
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": 1,
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
    "transaction_amount": 3,
    "terms_agree": true,
    "terms_agree_ip": "192.168.0.10",
    "recurring_c1": "recurring custom data 1",
    "recurring_c2": "recurring custom data 2",
    "recurring_c3": "recurring custom data 3",
    "send_to_proc_as_recur": true,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "next_run_date": "2021-12-01",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "recurring_type_id": "i"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Skip Recurring Payment

Skip recurring payment

```csharp
SkipRecurringPaymentAsync(
    string recurringId,
    Models.V1RecurringsSkipPaymentRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `recurringId` | `string` | Template, Required | Recurring ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1RecurringsSkipPaymentRequest`](../../doc/models/v1-recurrings-skip-payment-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseRecurring>`](../../doc/models/response-recurring.md)

## Example Usage

```csharp
string recurringId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1RecurringsSkipPaymentRequest();
body.SkipCount = 7;

try
{
    ResponseRecurring result = await recurringController.SkipRecurringPaymentAsync(recurringId, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "Recurring",
  "data": {
    "account_vault_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": 1,
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
    "transaction_amount": 3,
    "terms_agree": true,
    "terms_agree_ip": "192.168.0.10",
    "recurring_c1": "recurring custom data 1",
    "recurring_c2": "recurring custom data 2",
    "recurring_c3": "recurring custom data 3",
    "send_to_proc_as_recur": true,
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "next_run_date": "2021-12-01",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "recurring_type_id": "i"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |

