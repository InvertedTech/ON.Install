# Quick Invoices

Quick Invoices is a way for a merchant to send an email to a customer with a link to make a payment. This link, when clicked, opens a browser containing the Quick Invoice of whatever it is that the customer purchased. Each Quick Invoice email will have the ability to be customized by the merchant. There will be a default template provided for the merchant as a starting point. Once paid, the customer will receive an email thanking them for their payment. The system will send the customer email notifications prior to the due date, on the due date, and past the due at the discretion of the merchant. There will also be reporting provided to the merchant.

### Quick Invoice Process

The detail listed below in this document explains how to use the API to create and update quick invoices. Once an invoice is created, the system will send an email with the details of the quick invoice and a link on how to make a payment towards the invoice.

The email will contain a link that looks something like the following:

`https://{url}/quickinvoice/?id={quick_invoice_id}`

When the end user receives this email, they will be able to click on the link and it will take them to a page that looks like the image below. This page is where they will be making their payment(s).

![Quick-invoice sample](https://docs.zeamster.com/download_file/view_inline/22)

Once a payment is made on the quick invoice, the transaction will show up in the transaction listing with a reference to the quick invoice.

```csharp
QuickInvoicesController quickInvoicesController = client.QuickInvoicesController;
```

## Class Name

`QuickInvoicesController`

## Methods

* [Create a New Quick Invoice](../../doc/controllers/quick-invoices.md#create-a-new-quick-invoice)
* [List All Quick Invoices Related](../../doc/controllers/quick-invoices.md#list-all-quick-invoices-related)
* [Resend Notification Email](../../doc/controllers/quick-invoices.md#resend-notification-email)
* [Associate Transaction With Ouick Invoice](../../doc/controllers/quick-invoices.md#associate-transaction-with-ouick-invoice)
* [Remove Transaction From Quick Invoice](../../doc/controllers/quick-invoices.md#remove-transaction-from-quick-invoice)
* [Delete Quick Invoice](../../doc/controllers/quick-invoices.md#delete-quick-invoice)
* [View Single Quick Invoice Record](../../doc/controllers/quick-invoices.md#view-single-quick-invoice-record)
* [Update Quick Invoice](../../doc/controllers/quick-invoices.md#update-quick-invoice)


# Create a New Quick Invoice

Create a new quick invoice

```csharp
CreateANewQuickInvoiceAsync(
    Models.V1QuickInvoicesRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1QuickInvoicesRequest`](../../doc/models/v1-quick-invoices-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseQuickInvoice>`](../../doc/models/response-quick-invoice.md)

## Example Usage

```csharp
var body = new V1QuickInvoicesRequest();
body.LocationId = "11e95f8ec39de8fbdb0a4f1a";
body.Title = "My terminal";
body.CcProductTransactionId = "11e95f8ec39de8fbdb0a4f1a";
body.DueDate = "2021-12-01";
body.ItemList = new List<ItemList>();

var bodyItemList0 = new ItemList();
bodyItemList0.Name = "Bread";
bodyItemList0.Amount = 20.15;
body.ItemList.Add(bodyItemList0);

var bodyItemList1 = new ItemList();
bodyItemList1.Name = "Bread";
bodyItemList1.Amount = 20.15;
body.ItemList.Add(bodyItemList1);

var bodyItemList2 = new ItemList();
bodyItemList2.Name = "Bread";
bodyItemList2.Amount = 20.15;
body.ItemList.Add(bodyItemList2);


try
{
    ResponseQuickInvoice result = await quickInvoicesController.CreateANewQuickInvoiceAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "QuickInvoice",
  "data": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "title": "My terminal",
    "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "due_date": "2021-12-01",
    "item_list": [
      {
        "name": "Bread",
        "amount": 20.15
      }
    ],
    "allow_overpayment": true,
    "email": "email@domain.com",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "contact_api_id": "contact12345",
    "customer_id": "11e95f8ec39de8fbdb0a4f1a",
    "expire_date": "2021-12-01",
    "allow_partial_pay": true,
    "attach_files_to_email": true,
    "send_email": true,
    "invoice_number": "invoice12345",
    "item_header": "Quick invoice header sample",
    "item_footer": "Thank you",
    "amount_due": 245.36,
    "notification_email": "email@domain.com",
    "payment_status_id": 1,
    "status_id": 1,
    "note": "some note",
    "notification_days_before_due_date": 3,
    "notification_days_after_due_date": 7,
    "notification_on_due_date": true,
    "send_text_to_pay": true,
    "files": [
      null
    ],
    "remaining_balance": 245.36,
    "single_payment_min_amount": 5,
    "single_payment_max_amount": 5000,
    "cell_phone": "3339998822",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": true,
    "is_active": true
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# List All Quick Invoices Related

List all quick invoices related

```csharp
ListAllQuickInvoicesRelatedAsync(
    Models.Page page = null,
    Models.Sort5 sort = null,
    Models.Filter5 filter = null,
    List<string> expand = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | [`Models.Page`](../../doc/models/page.md) | Query, Optional | Use this field to specify paginate your results, by using page size and number. You can use one of the following methods:<br><br>> /endpoint?page={ "number": 1, "size": 50 }<br>> <br>> /endpoint?page[number]=1&page[size]=50 |
| `sort` | [`Models.Sort5`](../../doc/models/sort-5.md) | Query, Optional | You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods:<br><br>> /endpoint?sort={ "field_name": "asc", "field_name2": "desc" }<br>> <br>> /endpoint?sort[field_name]=asc&sort[field_name2]=desc |
| `filter` | [`Models.Filter5`](../../doc/models/filter-5.md) | Query, Optional | You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods:<br><br>> /endpoint?filter={ "field_name": "Value" }<br>> <br>> /endpoint?filter[field_name]=Value |
| `expand` | `List<string>` | Query, Optional | Most endpoints in the API have a way to retrieve extra data related to the current record being retrieved. For example, if the API request is for the accountvaults endpoint, and the end user also needs to know which contact the account vault belongs to, this data can be returned in the accountvaults endpoint request.<br>**Constraints**: *Unique Items Required*, *Pattern*: `^[\w]+$` |

## Response Type

[`Task<Models.ResponseQuickInvoicesCollection>`](../../doc/models/response-quick-invoices-collection.md)

## Example Usage

```csharp
try
{
    ResponseQuickInvoicesCollection result = await quickInvoicesController.ListAllQuickInvoicesRelatedAsync(null, null, null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "QuickInvoicesCollection",
  "list": [
    {
      "location_id": "11e95f8ec39de8fbdb0a4f1a",
      "title": "My terminal",
      "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
      "due_date": "2021-12-01",
      "item_list": [
        {
          "name": "Bread",
          "amount": 20.15
        }
      ],
      "allow_overpayment": true,
      "email": "email@domain.com",
      "contact_id": "11e95f8ec39de8fbdb0a4f1a",
      "contact_api_id": "contact12345",
      "customer_id": "11e95f8ec39de8fbdb0a4f1a",
      "expire_date": "2021-12-01",
      "allow_partial_pay": true,
      "attach_files_to_email": true,
      "send_email": true,
      "invoice_number": "invoice12345",
      "item_header": "Quick invoice header sample",
      "item_footer": "Thank you",
      "amount_due": 245.36,
      "notification_email": "email@domain.com",
      "payment_status_id": 1,
      "status_id": 1,
      "note": "some note",
      "notification_days_before_due_date": 3,
      "notification_days_after_due_date": 7,
      "notification_on_due_date": true,
      "send_text_to_pay": true,
      "files": [
        null
      ],
      "remaining_balance": 245.36,
      "single_payment_min_amount": 5,
      "single_payment_max_amount": 5000,
      "cell_phone": "3339998822",
      "id": "11e95f8ec39de8fbdb0a4f1a",
      "created_ts": 1422040992,
      "modified_ts": 1422040992,
      "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
      "active": true,
      "is_active": true
    }
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Resend Notification Email

Resend Notification Email

```csharp
ResendNotificationEmailAsync(
    string quickInvoiceId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `quickInvoiceId` | `string` | Template, Required | Quick Invoice ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseQuickInvoice>`](../../doc/models/response-quick-invoice.md)

## Example Usage

```csharp
string quickInvoiceId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseQuickInvoice result = await quickInvoicesController.ResendNotificationEmailAsync(quickInvoiceId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "QuickInvoice",
  "data": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "title": "My terminal",
    "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "due_date": "2021-12-01",
    "item_list": [
      {
        "name": "Bread",
        "amount": 20.15
      }
    ],
    "allow_overpayment": true,
    "email": "email@domain.com",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "contact_api_id": "contact12345",
    "customer_id": "11e95f8ec39de8fbdb0a4f1a",
    "expire_date": "2021-12-01",
    "allow_partial_pay": true,
    "attach_files_to_email": true,
    "send_email": true,
    "invoice_number": "invoice12345",
    "item_header": "Quick invoice header sample",
    "item_footer": "Thank you",
    "amount_due": 245.36,
    "notification_email": "email@domain.com",
    "payment_status_id": 1,
    "status_id": 1,
    "note": "some note",
    "notification_days_before_due_date": 3,
    "notification_days_after_due_date": 7,
    "notification_on_due_date": true,
    "send_text_to_pay": true,
    "files": [
      null
    ],
    "remaining_balance": 245.36,
    "single_payment_min_amount": 5,
    "single_payment_max_amount": 5000,
    "cell_phone": "3339998822",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": true,
    "is_active": true
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Associate Transaction With Ouick Invoice

Associate Transaction with Ouick Invoice

```csharp
AssociateTransactionWithOuickInvoiceAsync(
    string quickInvoiceId,
    Models.V1QuickInvoicesTransactionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `quickInvoiceId` | `string` | Template, Required | Quick Invoice ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1QuickInvoicesTransactionRequest`](../../doc/models/v1-quick-invoices-transaction-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseQuickInvoice>`](../../doc/models/response-quick-invoice.md)

## Example Usage

```csharp
string quickInvoiceId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1QuickInvoicesTransactionRequest();
body.TransactionId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseQuickInvoice result = await quickInvoicesController.AssociateTransactionWithOuickInvoiceAsync(quickInvoiceId, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "QuickInvoice",
  "data": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "title": "My terminal",
    "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "due_date": "2021-12-01",
    "item_list": [
      {
        "name": "Bread",
        "amount": 20.15
      }
    ],
    "allow_overpayment": true,
    "email": "email@domain.com",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "contact_api_id": "contact12345",
    "customer_id": "11e95f8ec39de8fbdb0a4f1a",
    "expire_date": "2021-12-01",
    "allow_partial_pay": true,
    "attach_files_to_email": true,
    "send_email": true,
    "invoice_number": "invoice12345",
    "item_header": "Quick invoice header sample",
    "item_footer": "Thank you",
    "amount_due": 245.36,
    "notification_email": "email@domain.com",
    "payment_status_id": 1,
    "status_id": 1,
    "note": "some note",
    "notification_days_before_due_date": 3,
    "notification_days_after_due_date": 7,
    "notification_on_due_date": true,
    "send_text_to_pay": true,
    "files": [
      null
    ],
    "remaining_balance": 245.36,
    "single_payment_min_amount": 5,
    "single_payment_max_amount": 5000,
    "cell_phone": "3339998822",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": true,
    "is_active": true
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Remove Transaction From Quick Invoice

Remove transaction from Quick Invoice

```csharp
RemoveTransactionFromQuickInvoiceAsync(
    string quickInvoiceId,
    Models.V1QuickInvoicesTransactionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `quickInvoiceId` | `string` | Template, Required | Quick Invoice ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1QuickInvoicesTransactionRequest`](../../doc/models/v1-quick-invoices-transaction-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseQuickInvoice>`](../../doc/models/response-quick-invoice.md)

## Example Usage

```csharp
string quickInvoiceId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1QuickInvoicesTransactionRequest();
body.TransactionId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseQuickInvoice result = await quickInvoicesController.RemoveTransactionFromQuickInvoiceAsync(quickInvoiceId, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "QuickInvoice",
  "data": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "title": "My terminal",
    "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "due_date": "2021-12-01",
    "item_list": [
      {
        "name": "Bread",
        "amount": 20.15
      }
    ],
    "allow_overpayment": true,
    "email": "email@domain.com",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "contact_api_id": "contact12345",
    "customer_id": "11e95f8ec39de8fbdb0a4f1a",
    "expire_date": "2021-12-01",
    "allow_partial_pay": true,
    "attach_files_to_email": true,
    "send_email": true,
    "invoice_number": "invoice12345",
    "item_header": "Quick invoice header sample",
    "item_footer": "Thank you",
    "amount_due": 245.36,
    "notification_email": "email@domain.com",
    "payment_status_id": 1,
    "status_id": 1,
    "note": "some note",
    "notification_days_before_due_date": 3,
    "notification_days_after_due_date": 7,
    "notification_on_due_date": true,
    "send_text_to_pay": true,
    "files": [
      null
    ],
    "remaining_balance": 245.36,
    "single_payment_min_amount": 5,
    "single_payment_max_amount": 5000,
    "cell_phone": "3339998822",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": true,
    "is_active": true
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Delete Quick Invoice

Delete quick Invoice

```csharp
DeleteQuickInvoiceAsync(
    string quickInvoiceId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `quickInvoiceId` | `string` | Template, Required | Quick Invoice ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseQuickInvoice>`](../../doc/models/response-quick-invoice.md)

## Example Usage

```csharp
string quickInvoiceId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseQuickInvoice result = await quickInvoicesController.DeleteQuickInvoiceAsync(quickInvoiceId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "QuickInvoice",
  "data": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "title": "My terminal",
    "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "due_date": "2021-12-01",
    "item_list": [
      {
        "name": "Bread",
        "amount": 20.15
      }
    ],
    "allow_overpayment": true,
    "email": "email@domain.com",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "contact_api_id": "contact12345",
    "customer_id": "11e95f8ec39de8fbdb0a4f1a",
    "expire_date": "2021-12-01",
    "allow_partial_pay": true,
    "attach_files_to_email": true,
    "send_email": true,
    "invoice_number": "invoice12345",
    "item_header": "Quick invoice header sample",
    "item_footer": "Thank you",
    "amount_due": 245.36,
    "notification_email": "email@domain.com",
    "payment_status_id": 1,
    "status_id": 1,
    "note": "some note",
    "notification_days_before_due_date": 3,
    "notification_days_after_due_date": 7,
    "notification_on_due_date": true,
    "send_text_to_pay": true,
    "files": [
      null
    ],
    "remaining_balance": 245.36,
    "single_payment_min_amount": 5,
    "single_payment_max_amount": 5000,
    "cell_phone": "3339998822",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": true,
    "is_active": true
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# View Single Quick Invoice Record

View single quick invoice record

```csharp
ViewSingleQuickInvoiceRecordAsync(
    string quickInvoiceId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `quickInvoiceId` | `string` | Template, Required | Quick Invoice ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Response Type

[`Task<Models.ResponseQuickInvoice>`](../../doc/models/response-quick-invoice.md)

## Example Usage

```csharp
string quickInvoiceId = "11e95f8ec39de8fbdb0a4f1a";

try
{
    ResponseQuickInvoice result = await quickInvoicesController.ViewSingleQuickInvoiceRecordAsync(quickInvoiceId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "QuickInvoice",
  "data": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "title": "My terminal",
    "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "due_date": "2021-12-01",
    "item_list": [
      {
        "name": "Bread",
        "amount": 20.15
      }
    ],
    "allow_overpayment": true,
    "email": "email@domain.com",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "contact_api_id": "contact12345",
    "customer_id": "11e95f8ec39de8fbdb0a4f1a",
    "expire_date": "2021-12-01",
    "allow_partial_pay": true,
    "attach_files_to_email": true,
    "send_email": true,
    "invoice_number": "invoice12345",
    "item_header": "Quick invoice header sample",
    "item_footer": "Thank you",
    "amount_due": 245.36,
    "notification_email": "email@domain.com",
    "payment_status_id": 1,
    "status_id": 1,
    "note": "some note",
    "notification_days_before_due_date": 3,
    "notification_days_after_due_date": 7,
    "notification_on_due_date": true,
    "send_text_to_pay": true,
    "files": [
      null
    ],
    "remaining_balance": 245.36,
    "single_payment_min_amount": 5,
    "single_payment_max_amount": 5000,
    "cell_phone": "3339998822",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": true,
    "is_active": true
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# Update Quick Invoice

Update quick invoice

```csharp
UpdateQuickInvoiceAsync(
    string quickInvoiceId,
    Models.V1QuickInvoicesRequest1 body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `quickInvoiceId` | `string` | Template, Required | Quick Invoice ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `body` | [`Models.V1QuickInvoicesRequest1`](../../doc/models/v1-quick-invoices-request-1.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseQuickInvoice>`](../../doc/models/response-quick-invoice.md)

## Example Usage

```csharp
string quickInvoiceId = "11e95f8ec39de8fbdb0a4f1a";
var body = new V1QuickInvoicesRequest1();

try
{
    ResponseQuickInvoice result = await quickInvoicesController.UpdateQuickInvoiceAsync(quickInvoiceId, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "QuickInvoice",
  "data": {
    "location_id": "11e95f8ec39de8fbdb0a4f1a",
    "title": "My terminal",
    "cc_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "ach_product_transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "due_date": "2021-12-01",
    "item_list": [
      {
        "name": "Bread",
        "amount": 20.15
      }
    ],
    "allow_overpayment": true,
    "email": "email@domain.com",
    "contact_id": "11e95f8ec39de8fbdb0a4f1a",
    "contact_api_id": "contact12345",
    "customer_id": "11e95f8ec39de8fbdb0a4f1a",
    "expire_date": "2021-12-01",
    "allow_partial_pay": true,
    "attach_files_to_email": true,
    "send_email": true,
    "invoice_number": "invoice12345",
    "item_header": "Quick invoice header sample",
    "item_footer": "Thank you",
    "amount_due": 245.36,
    "notification_email": "email@domain.com",
    "payment_status_id": 1,
    "status_id": 1,
    "note": "some note",
    "notification_days_before_due_date": 3,
    "notification_days_after_due_date": 7,
    "notification_on_due_date": true,
    "send_text_to_pay": true,
    "files": [
      null
    ],
    "remaining_balance": 245.36,
    "single_payment_min_amount": 5,
    "single_payment_max_amount": 5000,
    "cell_phone": "3339998822",
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "created_ts": 1422040992,
    "modified_ts": 1422040992,
    "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "modified_user_id": "11e95f8ec39de8fbdb0a4f1a",
    "active": true,
    "is_active": true
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |

