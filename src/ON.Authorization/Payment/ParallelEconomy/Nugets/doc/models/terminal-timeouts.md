
# Terminal Timeouts

The following options outlines some configurable timeout values that can be used to customize the experience at the terminal for the cardholder.

## Structure

`TerminalTimeouts`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CardEntryTimeout` | `int?` | Optional | How long to wait for input from cardholder.<br>**Default**: `120`<br>**Constraints**: `>= 20`, `<= 120` |
| `DeviceTermsPromptTimeout` | `int?` | Optional | How long the terms will be displayed on the device.<br>**Default**: `60`<br>**Constraints**: `>= 5`, `<= 300` |
| `OverallTimeout` | `int?` | Optional | How long to wait for response from /v2/routertransactions endpoint.<br>**Default**: `300`<br>**Constraints**: `>= 30`, `<= 300` |
| `PinEntryTimeout` | `int?` | Optional | How long to wait for pin entry by cardholder.<br>**Default**: `30`<br>**Constraints**: `>= 20`, `<= 50` |
| `SignatureInputTimeout` | `int?` | Optional | How long to wait for first "touch" to signature.<br>**Default**: `10`<br>**Constraints**: `>= 10`, `<= 50` |
| `SignatureSubmitTimeout` | `int?` | Optional | How long to wait for signature to be submitted.<br>**Default**: `30`<br>**Constraints**: `>= 20`, `<= 50` |
| `StatusDisplayTime` | `int?` | Optional | How long the approve/decline status message stays on screen.<br>**Default**: `7`<br>**Constraints**: `>= 1`, `<= 30` |
| `TipCashbackTimeout` | `int?` | Optional | How long to wait for input on a tip or cashback screen.<br>**Default**: `30`<br>**Constraints**: `>= 20`, `<= 50` |
| `TransactionTimeout` | `int?` | Optional | How long to wait for response from the processor.<br>**Default**: `10`<br>**Constraints**: `>= 10`, `<= 20` |

## Example (as JSON)

```json
{
  "card_entry_timeout": null,
  "device_terms_prompt_timeout": null,
  "overall_timeout": null,
  "pin_entry_timeout": null,
  "signature_input_timeout": null,
  "signature_submit_timeout": null,
  "status_display_time": null,
  "tip_cashback_timeout": null,
  "transaction_timeout": null
}
```

