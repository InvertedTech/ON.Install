
# Terminal Application

Terminal Application Information on `expand`

## Structure

`TerminalApplication`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Standalone` | `bool` | Required | Standalone |
| `EmvCapable` | `bool` | Required | Emv Capable |
| `NfcCapable` | `bool` | Required | Nfc Capable |
| `PinCapable` | `bool` | Required | Pin Capable |
| `PrintCapable` | `bool` | Required | Print Capable |
| `MsrCapable` | `bool` | Required | Msr Capable |
| `SigCaptureCapable` | `bool` | Required | Sig Capture Capable |
| `MposTerminal` | `bool` | Required | Mpos Terminal |
| `Title` | `string` | Optional | Title<br>**Constraints**: *Maximum Length*: `48` |
| `Description` | `string` | Optional | Description<br>**Constraints**: *Maximum Length*: `256` |
| `Id` | `string` | Required | Terminal Application Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int?` | Optional | Created Time Stamp |
| `ModifiedTs` | `int?` | Optional | Modified Time Stamp |
| `CreatedUserId` | `string` | Optional | User ID Created the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "standalone": true,
  "emv_capable": true,
  "nfc_capable": false,
  "pin_capable": true,
  "print_capable": false,
  "msr_capable": true,
  "sig_capture_capable": false,
  "mpos_terminal": false,
  "title": "Ingenico Link2500",
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "description": "description6"
}
```

