# Level 3 Data

The Level 3 Data endpoint is used to create/update/retrieve/delete Level 3 Data associated with a transaction.

For Locations/Merchants that have Level 3 Data enabled:

1. The Level 3 Data endpoint can be used to supply all the extra data necessary to help qualify the transactions. The Level 3 Data is submitted the same for every processor, but is submitted differently for Visa vs Mastercard transactions (see examples below).
2. The initial Level 3 Data is submitted by the API up front.
   1. Each transaction that is run with a commercial (or purchasing) card will have default Level 3 Data sent to the processor. This is helpful so that even if a merchant doesn't update the transaction with the necessary Level 3 Data, it will still contain a basic record of Level 3 Data to help with the qualifications.
3. If a merchant needs to update the Level 3 Data to supply more specific information, this is done by an additional POST request to the `/v1/transactions/{transaction_id}/level3/{card_type}` endpoint.
   1. Every POST will overwrite any previous Level 3 Data submitted for the transaction.
      1. Additional POSTs will need to contain ALL the Level 3 Data that needs to be submitted to the processor.
      2. Omitting a previously supplied value will clear that value from the transaction record.

If you are not sure if you can use the Level 3 Data endpoint, perform these steps to determine whether you are able:

1. Run a transaction.

2. Once the initial transaction is complete, submit a GET request to:
   
   `/v1/transactions/{transaction_id}?expand=transaction_level3`

3. You should get a response with typical transaction data, but you should also notice an extra field in the response called "transaction_level3".

4. If the transaction_level3 field has Level 3 Data then you can use the Level 3 Data endpoint.

5. If this field is null then you cannot use the Level 3 Data endpoint.

### Industry Support by Processor

| Industry         | TSYS     | FirstData | Vantiv   |
|------------------|----------|-----------|----------|
| Retail           | &#10003; | &#10003;  | &#10003; |
| Ecommerce        | &#10003; | &#10003;  | &#10003; |
| Direct Marketing | &#10003; | &#10003;  | &#10003; |
| Lodging          |          | &#10003;  |          |

```csharp
Level3DataController level3DataController = client.Level3DataController;
```

## Class Name

`Level3DataController`

## Methods

* [Create a New Level 3 Entry for a Master Card](../../doc/controllers/level-3-data.md#create-a-new-level-3-entry-for-a-master-card)
* [Create a New Level 3 Entry for a Visa](../../doc/controllers/level-3-data.md#create-a-new-level-3-entry-for-a-visa)
* [Delete a Single Level 3 Record](../../doc/controllers/level-3-data.md#delete-a-single-level-3-record)
* [View Single Level 3 Record](../../doc/controllers/level-3-data.md#view-single-level-3-record)


# Create a New Level 3 Entry for a Master Card

Create a new Level3 entry for a MasterCard

```csharp
CreateANewLevel3EntryForAMasterCardAsync(
    Models.V1TransactionsLevel3MasterCardRequest body,
    string transactionId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TransactionsLevel3MasterCardRequest`](../../doc/models/v1-transactions-level-3-master-card-request.md) | Body, Required | - |
| `transactionId` | `string` | Template, Required | - |

## Response Type

[`Task<Models.ResponseTransationLevel3Master>`](../../doc/models/response-transation-level-3-master.md)

## Example Usage

```csharp
var body = new V1TransactionsLevel3MasterCardRequest();
body.Level3Data = new Level3Data3();
body.Level3Data.LineItems = new List<LineItem3>();

var bodyLevel3DataLineItems0 = new LineItem3();
bodyLevel3DataLineItems0.Description = "cool drink";
bodyLevel3DataLineItems0.ProductCode = "coke12345678";
bodyLevel3DataLineItems0.UnitCode = "gll";
bodyLevel3DataLineItems0.UnitCost = 47.21;
body.Level3Data.LineItems.Add(bodyLevel3DataLineItems0);

string transactionId = "transaction_id8";

try
{
    ResponseTransationLevel3Master result = await level3DataController.CreateANewLevel3EntryForAMasterCardAsync(body, transactionId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "TransationLevel3Master",
  "data": {
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "level3_data": {
      "destination_country_code": "840",
      "duty_amount": 0,
      "freight_amount": 0,
      "national_tax": 2,
      "sales_tax": 200,
      "shipfrom_zip_code": "AZ1234",
      "shipto_zip_code": "FL1234",
      "tax_amount": 10,
      "tax_exempt": 0,
      "customer_vat_registration": "12345678",
      "merchant_vat_registration": "123456",
      "order_date": "171006",
      "summary_commodity_code": "C1K2",
      "tax_rate": 0,
      "unique_vat_ref_number": "vat1234",
      "line_items": [
        {
          "description": "cool drink",
          "commodity_code": "cc123456",
          "discount_amount": 0,
          "other_tax_amount": 0,
          "product_code": "fanta123456",
          "quantity": 12,
          "tax_amount": 4,
          "tax_rate": 0,
          "unit_code": "gll",
          "unit_cost": 3,
          "alternate_tax_id": "1234",
          "debit_credit": "C",
          "discount_rate": 11,
          "tax_type_applied": "22",
          "tax_type_id": "11"
        }
      ]
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Create a New Level 3 Entry for a Visa

Create a new Level3 entry for a Visa

```csharp
CreateANewLevel3EntryForAVisaAsync(
    Models.V1TransactionsLevel3VisaRequest body,
    string transactionId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1TransactionsLevel3VisaRequest`](../../doc/models/v1-transactions-level-3-visa-request.md) | Body, Required | - |
| `transactionId` | `string` | Template, Required | - |

## Response Type

[`Task<Models.ResponseTransationLevel3Visa>`](../../doc/models/response-transation-level-3-visa.md)

## Example Usage

```csharp
var body = new V1TransactionsLevel3VisaRequest();
body.Level3Data = new Level3Data4();
body.Level3Data.LineItems = new List<LineItem4>();

var bodyLevel3DataLineItems0 = new LineItem4();
bodyLevel3DataLineItems0.Description = "cool drink";
bodyLevel3DataLineItems0.CommodityCode = "cc123456";
bodyLevel3DataLineItems0.ProductCode = "fanta123456";
bodyLevel3DataLineItems0.UnitCode = "gll";
bodyLevel3DataLineItems0.UnitCost = 47.21;
body.Level3Data.LineItems.Add(bodyLevel3DataLineItems0);

string transactionId = "transaction_id8";

try
{
    ResponseTransationLevel3Visa result = await level3DataController.CreateANewLevel3EntryForAVisaAsync(body, transactionId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "TransationLevel3Visa",
  "data": {
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "level3_data": {
      "destination_country_code": "840",
      "duty_amount": 0,
      "freight_amount": 0,
      "national_tax": 2,
      "sales_tax": 200,
      "shipfrom_zip_code": "AZ1234",
      "shipto_zip_code": "FL1234",
      "tax_amount": 10,
      "tax_exempt": 0,
      "customer_vat_registration": "12345678",
      "merchant_vat_registration": "123456",
      "order_date": "171006",
      "summary_commodity_code": "C1K2",
      "tax_rate": 0,
      "unique_vat_ref_number": "vat1234",
      "line_items": [
        {
          "description": "cool drink",
          "commodity_code": "cc123456",
          "discount_amount": 0,
          "other_tax_amount": 0,
          "product_code": "fanta123456",
          "quantity": 12,
          "tax_amount": 4,
          "tax_rate": 0,
          "unit_code": "gll",
          "unit_cost": 3,
          "alternate_tax_id": "1234",
          "debit_credit": "C",
          "discount_rate": 11,
          "tax_type_applied": "22",
          "tax_type_id": "11"
        }
      ]
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |
| 412 | Precondition Failed | [`Response412Exception`](../../doc/models/response-412-exception.md) |


# Delete a Single Level 3 Record

Delete a single level3 record

```csharp
DeleteASingleLevel3RecordAsync(
    string transactionId,
    string level3Id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `transactionId` | `string` | Template, Required | - |
| `level3Id` | `string` | Template, Required | - |

## Response Type

[`Task<Models.ResponseTransationLevel3>`](../../doc/models/response-transation-level-3.md)

## Example Usage

```csharp
string transactionId = "transaction_id8";
string level3Id = "level3_id6";

try
{
    ResponseTransationLevel3 result = await level3DataController.DeleteASingleLevel3RecordAsync(transactionId, level3Id);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "TransationLevel3",
  "data": {
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "level3_data": {
      "destination_country_code": "840",
      "duty_amount": 0,
      "freight_amount": 0,
      "national_tax": 2,
      "sales_tax": 200,
      "shipfrom_zip_code": "AZ1234",
      "shipto_zip_code": "FL1234",
      "tax_amount": 10,
      "tax_exempt": 0,
      "customer_vat_registration": "12345678",
      "merchant_vat_registration": "123456",
      "order_date": "171006",
      "summary_commodity_code": "C1K2",
      "tax_rate": 0,
      "unique_vat_ref_number": "vat1234",
      "line_items": [
        {
          "description": "cool drink",
          "commodity_code": "cc123456",
          "discount_amount": 0,
          "other_tax_amount": 0,
          "product_code": "fanta123456",
          "quantity": 12,
          "tax_amount": 4,
          "tax_rate": 0,
          "unit_code": "gll",
          "unit_cost": 3,
          "alternate_tax_id": "1234",
          "debit_credit": "C",
          "discount_rate": 11,
          "tax_type_applied": "22",
          "tax_type_id": "11"
        }
      ]
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |


# View Single Level 3 Record

View single level3 record

```csharp
ViewSingleLevel3RecordAsync(
    string transactionId,
    string level3Id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `transactionId` | `string` | Template, Required | - |
| `level3Id` | `string` | Template, Required | - |

## Response Type

[`Task<Models.ResponseTransationLevel3>`](../../doc/models/response-transation-level-3.md)

## Example Usage

```csharp
string transactionId = "transaction_id8";
string level3Id = "level3_id6";

try
{
    ResponseTransationLevel3 result = await level3DataController.ViewSingleLevel3RecordAsync(transactionId, level3Id);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "type": "TransationLevel3",
  "data": {
    "id": "11e95f8ec39de8fbdb0a4f1a",
    "transaction_id": "11e95f8ec39de8fbdb0a4f1a",
    "level3_data": {
      "destination_country_code": "840",
      "duty_amount": 0,
      "freight_amount": 0,
      "national_tax": 2,
      "sales_tax": 200,
      "shipfrom_zip_code": "AZ1234",
      "shipto_zip_code": "FL1234",
      "tax_amount": 10,
      "tax_exempt": 0,
      "customer_vat_registration": "12345678",
      "merchant_vat_registration": "123456",
      "order_date": "171006",
      "summary_commodity_code": "C1K2",
      "tax_rate": 0,
      "unique_vat_ref_number": "vat1234",
      "line_items": [
        {
          "description": "cool drink",
          "commodity_code": "cc123456",
          "discount_amount": 0,
          "other_tax_amount": 0,
          "product_code": "fanta123456",
          "quantity": 12,
          "tax_amount": 4,
          "tax_rate": 0,
          "unit_code": "gll",
          "unit_cost": 3,
          "alternate_tax_id": "1234",
          "debit_credit": "C",
          "discount_rate": 11,
          "tax_type_applied": "22",
          "tax_type_id": "11"
        }
      ]
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`Response401tokenException`](../../doc/models/response-401-token-exception.md) |

