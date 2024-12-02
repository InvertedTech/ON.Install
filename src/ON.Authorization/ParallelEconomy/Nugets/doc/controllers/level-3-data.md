# Level 3 Data

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

```csharp
CreateANewLevel3EntryForAMasterCardAsync(
    string transactionId,
    Models.V1TransactionsLevel3MasterCardRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `transactionId` | `string` | Template, Required | Transaction ID |
| `body` | [`V1TransactionsLevel3MasterCardRequest`](../../doc/models/v1-transactions-level-3-master-card-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransactionLevel3Master>`](../../doc/models/response-transaction-level-3-master.md)

## Example Usage

```csharp
string transactionId = "11e95f8ec39de8fbdb0a4f1a";
V1TransactionsLevel3MasterCardRequest body = new V1TransactionsLevel3MasterCardRequest
{
    Level3Data = new Level3Data5
    {
        LineItems = new List<Models.LineItem5>
        {
            new LineItem5
            {
                Description = "cool drink",
                ProductCode = "coke12345678",
                UnitCode = "gll",
                UnitCost = 10,
                AlternateTaxId = "1234",
                DebitCredit = DebitCreditEnum.C,
                DiscountAmount = 10,
                DiscountRate = 11,
                Quantity = 5,
                TaxAmount = 3,
                TaxRate = 0,
                TaxTypeApplied = "22",
                TaxTypeId = "11",
            },
        },
        DestinationCountryCode = "840",
        DutyAmount = 0,
        FreightAmount = 0,
        NationalTax = 2,
        SalesTax = 200,
        ShipfromZipCode = "AZ12345",
        ShiptoZipCode = "MI48335",
        TaxAmount = 0,
        TaxExempt = TaxExemptEnum.Enum0,
    },
};

try
{
    ResponseTransactionLevel3Master result = await level3DataController.CreateANewLevel3EntryForAMasterCardAsync(
        transactionId,
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
  "type": "TransactionLevel3Master",
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
      "tax_exempt": "0",
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

```csharp
CreateANewLevel3EntryForAVisaAsync(
    string transactionId,
    Models.V1TransactionsLevel3VisaRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `transactionId` | `string` | Template, Required | Transaction ID |
| `body` | [`V1TransactionsLevel3VisaRequest`](../../doc/models/v1-transactions-level-3-visa-request.md) | Body, Required | - |

## Response Type

[`Task<Models.ResponseTransactionLevel3Visa>`](../../doc/models/response-transaction-level-3-visa.md)

## Example Usage

```csharp
string transactionId = "11e95f8ec39de8fbdb0a4f1a";
V1TransactionsLevel3VisaRequest body = new V1TransactionsLevel3VisaRequest
{
    Level3Data = new Level3Data6
    {
        LineItems = new List<Models.LineItem6>
        {
            new LineItem6
            {
                Description = "cool drink",
                CommodityCode = "cc123456",
                ProductCode = "fanta123456",
                UnitCode = "gll",
                UnitCost = 3,
                DiscountAmount = 0,
                OtherTaxAmount = 0,
                Quantity = 12,
                TaxAmount = 4,
                TaxRate = 0,
            },
        },
        DestinationCountryCode = "840",
        DutyAmount = 0,
        FreightAmount = 0,
        NationalTax = 2,
        SalesTax = 200,
        ShipfromZipCode = "AZ1234",
        ShiptoZipCode = "FL1234",
        TaxAmount = 10,
        TaxExempt = TaxExemptEnum.Enum0,
        CustomerVatRegistration = "12345678",
        MerchantVatRegistration = "123456",
        OrderDate = "171006",
        SummaryCommodityCode = "C1K2",
        TaxRate = 0,
        UniqueVatRefNumber = "vat1234",
    },
};

try
{
    ResponseTransactionLevel3Visa result = await level3DataController.CreateANewLevel3EntryForAVisaAsync(
        transactionId,
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
  "type": "TransactionLevel3Visa",
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
      "tax_exempt": "0",
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

```csharp
DeleteASingleLevel3RecordAsync(
    string transactionId,
    string level3Id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `transactionId` | `string` | Template, Required | Transaction ID |
| `level3Id` | `string` | Template, Required | Level 3 ID |

## Response Type

[`Task<Models.ResponseTransactionLevel3>`](../../doc/models/response-transaction-level-3.md)

## Example Usage

```csharp
string transactionId = "11e95f8ec39de8fbdb0a4f1a";
string level3Id = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseTransactionLevel3 result = await level3DataController.DeleteASingleLevel3RecordAsync(
        transactionId,
        level3Id
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
  "type": "TransactionLevel3",
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
      "tax_exempt": "0",
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

```csharp
ViewSingleLevel3RecordAsync(
    string transactionId,
    string level3Id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `transactionId` | `string` | Template, Required | Transaction ID |
| `level3Id` | `string` | Template, Required | Level 3 ID |

## Response Type

[`Task<Models.ResponseTransactionLevel3>`](../../doc/models/response-transaction-level-3.md)

## Example Usage

```csharp
string transactionId = "11e95f8ec39de8fbdb0a4f1a";
string level3Id = "11e95f8ec39de8fbdb0a4f1a";
try
{
    ResponseTransactionLevel3 result = await level3DataController.ViewSingleLevel3RecordAsync(
        transactionId,
        level3Id
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
  "type": "TransactionLevel3",
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
      "tax_exempt": "0",
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

