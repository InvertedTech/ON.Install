
# Sort 9

You can use any `field_name` from this endpoint results, and you can combine more than one field for more complex sorting. You can use one of the following methods:

> /endpoint?sort={ "field_name": "asc", "field_name2": "desc" }
> 
> /endpoint?sort[field_name]=asc&sort[field_name2]=desc

## Structure

`Sort9`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationId` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `DefaultProductTransactionId` | `string` | Optional | Product Transaction ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `TerminalApplicationId` | `string` | Optional | Terminal Application ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `TerminalCvmId` | `string` | Optional | Terminal CVM ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `TerminalManufacturerCode` | [`Models.TerminalManufacturerCodeEnum?`](../../doc/models/terminal-manufacturer-code-enum.md) | Optional | Terminal Manufacturer Code |
| `Title` | `string` | Optional | Terminal Name<br>**Constraints**: *Maximum Length*: `64` |
| `MacAddress` | `string` | Optional | Terminal MAC Address<br>**Constraints**: *Pattern*: `^([0-9a-fA-F]{2}[:-]?){5}([0-9a-fA-F]{2})$` |
| `LocalIpAddress` | `string` | Optional | Terminal Local IP Address |
| `Port` | `int?` | Optional | Terminal Port<br>**Default**: `10009`<br>**Constraints**: `>= 0`, `<= 65535` |
| `SerialNumber` | `string` | Optional | Terminal Serial Number<br>**Constraints**: *Maximum Length*: `24`, *Pattern*: `^[a-zA-Z0-9]*$` |
| `TerminalNumber` | `string` | Optional | Terminal Number<br>**Constraints**: *Minimum Length*: `15`, *Maximum Length*: `15` |
| `TerminalTimeouts` | [`Models.TerminalTimeouts`](../../doc/models/terminal-timeouts.md) | Optional | The following options outlines some configurable timeout values that can be used to customize the experience at the terminal for the cardholder. |
| `TipPercents` | [`Models.TipPercents`](../../doc/models/tip-percents.md) | Optional | A JSON of tip percents the JSON MUST contain only these three fields: percent_1, percent_2, percent_3 |
| `LocationApiId` | `string` | Optional | Location Api ID<br>**Constraints**: *Maximum Length*: `64` |
| `TerminalApiId` | `string` | Optional | Terminal Api ID<br>**Constraints**: *Maximum Length*: `64` |
| `HeaderLine1` | `string` | Optional | Header Line 1<br>**Constraints**: *Maximum Length*: `32` |
| `HeaderLine2` | `string` | Optional | Header Line 2<br>**Constraints**: *Maximum Length*: `32` |
| `HeaderLine3` | `string` | Optional | Header Line 3<br>**Constraints**: *Maximum Length*: `32` |
| `HeaderLine4` | `string` | Optional | Header Line 4<br>**Constraints**: *Maximum Length*: `32` |
| `HeaderLine5` | `string` | Optional | Header Line 5<br>**Constraints**: *Maximum Length*: `32` |
| `TrailerLine1` | `string` | Optional | Trailer Line 1<br>**Constraints**: *Maximum Length*: `32` |
| `TrailerLine2` | `string` | Optional | Trailer Line 2<br>**Constraints**: *Maximum Length*: `32` |
| `TrailerLine3` | `string` | Optional | Trailer Line 3<br>**Constraints**: *Maximum Length*: `32` |
| `TrailerLine4` | `string` | Optional | Trailer Line 4<br>**Constraints**: *Maximum Length*: `32` |
| `TrailerLine5` | `string` | Optional | Trailer Line 5<br>**Constraints**: *Maximum Length*: `32` |
| `DefaultCheckin` | `string` | Optional | Default Checkin<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `DefaultCheckout` | `string` | Optional | Default Checkout<br>**Constraints**: *Maximum Length*: `10`, *Pattern*: `^[\d]{4}-[\d]{2}-[\d]{2}$` |
| `DefaultRoomRate` | `double?` | Optional | Default Room Rate<br>**Constraints**: `>= 0`, `<= 100` |
| `DefaultRoomNumber` | `string` | Optional | Default Room Number<br>**Constraints**: *Maximum Length*: `12` |
| `Debit` | `bool?` | Optional | Debit |
| `Emv` | `bool?` | Optional | EMV |
| `CashbackEnable` | `bool?` | Optional | Cashback Enable |
| `PrintEnable` | `bool?` | Optional | Print Enable |
| `SigCaptureEnable` | `bool?` | Optional | Sig Capture Enable |
| `IsProvisioned` | `bool?` | Optional | Is Provisioned |
| `TipEnable` | `bool?` | Optional | Tip Enable |
| `ValidatedDecryption` | `bool?` | Optional | Validated Decryption |
| `CommunicationType` | [`Models.CommunicationTypeEnum?`](../../doc/models/communication-type-enum.md) | Optional | Communication Type |
| `Id` | `string` | Optional | Terminal ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int?` | Optional | Created Time Stamp |
| `ModifiedTs` | `int?` | Optional | Modified Time Stamp |
| `LastRegistrationTs` | `int?` | Optional | Modified Time Stamp |
| `CreatedUserId` | `string` | Optional | User ID Created the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ModifiedUserId` | `string` | Optional | Last User ID that updated the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "location_id": null,
  "default_product_transaction_id": null,
  "terminal_application_id": null,
  "terminal_cvm_id": null,
  "terminal_manufacturer_code": null,
  "title": null,
  "mac_address": null,
  "local_ip_address": null,
  "port": null,
  "serial_number": null,
  "terminal_number": null,
  "terminal_timeouts": null,
  "tip_percents": null,
  "location_api_id": null,
  "terminal_api_id": null,
  "header_line_1": null,
  "header_line_2": null,
  "header_line_3": null,
  "header_line_4": null,
  "header_line_5": null,
  "trailer_line_1": null,
  "trailer_line_2": null,
  "trailer_line_3": null,
  "trailer_line_4": null,
  "trailer_line_5": null,
  "default_checkin": null,
  "default_checkout": null,
  "default_room_rate": null,
  "default_room_number": null,
  "debit": null,
  "emv": null,
  "cashback_enable": null,
  "print_enable": null,
  "sig_capture_enable": null,
  "is_provisioned": null,
  "tip_enable": null,
  "validated_decryption": null,
  "communication_type": null,
  "id": null,
  "created_ts": null,
  "modified_ts": null,
  "last_registration_ts": null,
  "created_user_id": null,
  "modified_user_id": null
}
```

