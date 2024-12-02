
# Data 8

## Structure

`Data8`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Action` | [`ActionEnum?`](../../doc/models/action-enum.md) | Optional | The action to be performed<br>**Default**: `ActionEnum.sale` |
| `DigitalWalletsOnly` | `bool?` | Optional | **Default**: `false` |
| `Methods` | [`List<Method3>`](../../doc/models/method-3.md) | Optional | By default the system will try to offer all the availables payment methods from your account. But if you like, you can specify exactly what services you want to use.<br>**Constraints**: *Minimum Items*: `1`, *Unique Items Required* |
| `Amount` | [`Data8Amount`](../../doc/models/containers/data-8-amount.md) | Optional | This is a container for any-of cases. |
| `TaxAmount` | [`Data8TaxAmount`](../../doc/models/containers/data-8-tax-amount.md) | Optional | This is a container for any-of cases.<br>**Constraints**: `>= 1`, `<= 999999999` |
| `SecondaryAmount` | [`Data8SecondaryAmount`](../../doc/models/containers/data-8-secondary-amount.md) | Optional | This is a container for any-of cases.<br>**Constraints**: `>= 0`, `<= 999999999` |
| `LocationId` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ContactId` | `string` | Optional | Contact ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `SaveAccount` | [`Data8SaveAccount`](../../doc/models/containers/data-8-save-account.md) | Optional | This is a container for any-of cases. |
| `SaveAccountTitle` | [`Data8SaveAccountTitle`](../../doc/models/containers/data-8-save-account-title.md) | Optional | This is a container for any-of cases.<br>**Constraints**: *Maximum Length*: `16` |
| `Title` | [`Data8Title`](../../doc/models/containers/data-8-title.md) | Optional | This is a container for any-of cases.<br>**Constraints**: *Maximum Length*: `16` |
| `AchSecCode` | [`AchSecCodeEnum?`](../../doc/models/ach-sec-code-enum.md) | Optional | SEC code for the transaction if it's an ACH transaction<br>**Default**: `AchSecCodeEnum.WEB` |
| `BankFundedOnlyOverride` | [`Data8BankFundedOnlyOverride`](../../doc/models/containers/data-8-bank-funded-only-override.md) | Optional | This is a container for any-of cases. |
| `AllowPartialAuthorizationOverride` | [`Data8AllowPartialAuthorizationOverride`](../../doc/models/containers/data-8-allow-partial-authorization-override.md) | Optional | This is a container for any-of cases. |
| `AutoDeclineCvvOverride` | [`Data8AutoDeclineCvvOverride`](../../doc/models/containers/data-8-auto-decline-cvv-override.md) | Optional | This is a container for any-of cases. |
| `AutoDeclineStreetOverride` | [`Data8AutoDeclineStreetOverride`](../../doc/models/containers/data-8-auto-decline-street-override.md) | Optional | This is a container for any-of cases. |
| `AutoDeclineZipOverride` | [`Data8AutoDeclineZipOverride`](../../doc/models/containers/data-8-auto-decline-zip-override.md) | Optional | This is a container for any-of cases. |
| `Message` | `string` | Optional | A custom text message that displays after the payment is processed.<br>**Constraints**: *Maximum Length*: `120` |
| `ClientToken` | `string` | Required | A JWT to be used to create the elements.<br><br>> This is a one-time only use token.<br>> Do not store for long term use, it expires after 48 hours. |

## Example (as JSON)

```json
{
  "action": "sale",
  "digitalWalletsOnly": false,
  "location_id": "11e95f8ec39de8fbdb0a4f1a",
  "contact_id": "11e95f8ec39de8fbdb0a4f1a",
  "ach_sec_code": "WEB",
  "client_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",
  "methods": [
    {
      "type": "ach",
      "product_transaction_id": "product_transaction_id4"
    },
    {
      "type": "ach",
      "product_transaction_id": "product_transaction_id4"
    },
    {
      "type": "ach",
      "product_transaction_id": "product_transaction_id4"
    }
  ],
  "amount": 154,
  "tax_amount": 194
}
```

