
# Filter 2

You can use any `field_name` from this endpoint results as a filter, and you can also use more than one field to create AND conditions. You can use one of the following methods:

> /endpoint?filter={ "field_name": "Value" }
> 
> /endpoint?filter[field_name]=Value

## Structure

`Filter2`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationId` | `string` | Optional | Location ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `TerminalId` | `string` | Optional | Terminal ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `RequireSignature` | `bool?` | Optional | Set to true or 1 to require a signature from the customer |
| `DeviceTermApiId` | `string` | Optional | Can be used for associating record to external systems. Must be unique per location.<br>**Constraints**: *Maximum Length*: `64` |
| `TermsConditions` | `string` | Optional | This is the message that is displayed on the screen when prompting for a signature.<br>**Constraints**: *Maximum Length*: `4096` |
| `Id` | `string` | Optional | Device term ID<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `ReasonCodeId` | `int?` | Optional | Reason code ID |
| `Signature` | [`Models.Signature`](../../doc/models/signature.md) | Optional | A JSON object containing all the info about and including the signature blob (base64). |
| `CreatedTs` | `int?` | Optional | Created Time Stamp |
| `ModifiedTs` | `int?` | Optional | Modified Time Stamp |
| `CreatedUserId` | `string` | Optional | System generated id for user who created record<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "location_id": null,
  "terminal_id": null,
  "require_signature": null,
  "device_term_api_id": null,
  "terms_conditions": null,
  "id": null,
  "reason_code_id": null,
  "signature": null,
  "created_ts": null,
  "modified_ts": null,
  "created_user_id": null
}
```

