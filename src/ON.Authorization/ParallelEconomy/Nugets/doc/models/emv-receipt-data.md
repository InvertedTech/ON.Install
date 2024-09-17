
# Emv Receipt Data

This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM

## Structure

`EmvReceiptData`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AID` | `string` | Optional | This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM |
| `APPLAB` | `string` | Optional | This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM |
| `APPN` | `string` | Optional | This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM |
| `CVM` | `string` | Optional | This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM |
| `TSI` | `string` | Optional | This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM |
| `TVR` | `string` | Optional | This field is a read only field. This field will only be populated for EMV transactions and will contain proper JSON formatted data with some or all of the following fields: TC,TVR,AID,TSI,ATC,APPLAB,APPN,CVM |

## Example (as JSON)

```json
{
  "AID": "a0000000042203",
  "APPLAB": "US Maestro",
  "APPN": "US Maestro",
  "CVM": "Pin Verified",
  "TSI": "e800",
  "TVR": "0800008000"
}
```

