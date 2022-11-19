
# Alt Bank Account

The Alternative Bank Account.

## Structure

`AltBankAccount`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `RoutingNumber` | `string` | Optional | Nine-digit Bank routing number.<br>**Constraints**: *Maximum Length*: `9` |
| `AccountNumber` | `string` | Optional | Bank account number.<br>**Constraints**: *Maximum Length*: `17` |
| `AccountHolderName` | `string` | Optional | Name on bank account.<br>**Constraints**: *Maximum Length*: `40` |
| `DepositType` | `string` | Optional | Deposit type. |

## Example (as JSON)

```json
{
  "routing_number": null,
  "account_number": null,
  "account_holder_name": null,
  "deposit_type": null
}
```

