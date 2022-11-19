
# Data 15

## Structure

`Data15`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `IssuerBankName` | `string` | Required | The Issuer Bank name for the BIN<br>**Constraints**: *Maximum Length*: `60` |
| `CountryCode` | `string` | Required | VISA - Three character alpha country code<br>MC - Three character alpha country code<br>Maestro - Three character alpha country code<br>Amex - Space Filled<br>Discover - Three character alpha country code or spaces when Discover doesn't share issuer country.<br>**Constraints**: *Maximum Length*: `2` |
| `DetailCardProduct` | `string` | Required | V - Visa<br>M - MasterCard<br>A - American Express<br>D - Discover<br>N - PIN Only (Non-Visa/MasterCard/AMEX/Discover<br>**Constraints**: *Maximum Length*: `1` |
| `DetailCardIndicator` | `string` | Required | Left justified, Space filled<br>**Constraints**: *Maximum Length*: `2` |
| `FsaIndicator` | `string` | Required | Left justified, Space filled<br>**Constraints**: *Maximum Length*: `1` |
| `PrepaidIndicator` | `string` | Required | P = Prepaid Card<br>Default: Space filled<br>**Constraints**: *Maximum Length*: `1` |
| `ProductId` | `string` | Required | P = Prepaid Card<br>Default: Space filled<br>**Constraints**: *Maximum Length*: `3` |
| `RegulatorIndicator` | `string` | Required | P = Prepaid Card<br>Default: Space filled<br>**Constraints**: *Maximum Length*: `1` |
| `VisaProductSubType` | `string` | Optional | This is used to identify product sub-types, i.e. further classification of product.<br>**Constraints**: *Maximum Length*: `2` |
| `VisaLargeTicketIndicator` | `string` | Optional | L = Visa Large Ticket.<br>Default: Space filled<br>**Constraints**: *Maximum Length*: `1` |
| `AccountFundSource` | `string` | Required | For Visa, MasterCard, and Discover.  Identifies the source of the funds associated with the primary account for the card.<br>**Constraints**: *Maximum Length*: `1` |
| `CardClass` | `string` | Optional | Categorizes the BIN as a Business card, Corporate T&E card, Purchase card or Consumer card. Assists the POS device with prompting decisions – to collect addenda or not.  Visa, MasterCard and Discover only.<br>**Constraints**: *Maximum Length*: `1` |
| `TokenInd` | `string` | Optional | Token Indicator values:<br>Y = Token BIN<br>Default: Space filled<br>VISA, MC, and Discover Only<br>**Constraints**: *Maximum Length*: `1` |
| `IssuingNetwork` | `string` | Optional | For Discover card types<br>00 - Discover<br>01 - Diners<br>02 - JCB (Japanese Credit Bank)<br>03 - CUP (China Union Pay)<br>04 PayPal<br>**Constraints**: *Maximum Length*: `2` |

## Example (as JSON)

```json
{
  "issuer_bank_name": "Cartasi S.P.A.",
  "country_code": "US",
  "detail_card_product": "V",
  "detail_card_indicator": "X",
  "fsa_indicator": "F",
  "prepaid_indicator": "P",
  "product_id": "G",
  "regulator_indicator": "N",
  "account_fund_source": "C"
}
```

