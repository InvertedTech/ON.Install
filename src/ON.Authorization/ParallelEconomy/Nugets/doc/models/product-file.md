
# Product File

## Structure

`ProductFile`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Title` | `string` | Required | Title<br>**Constraints**: *Maximum Length*: `64` |
| `ProductFileCredentialId` | `string` | Required | Product File Credential Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `FreeBytes` | `double?` | Optional | Free Bytes |
| `ByteIncrement` | `double?` | Optional | Byte Increment |
| `MaxFileSizeBytes` | `double?` | Optional | Max File Size Bytes |
| `IncrementCost` | `double?` | Optional | Increment Cost |
| `MonthlyFee` | `int?` | Optional | Monthly Fee |
| `FileExtAllowed` | `string` | Optional | File Ext Allowed<br>**Constraints**: *Maximum Length*: `64` |
| `Container` | `string` | Optional | Container<br>**Constraints**: *Maximum Length*: `128` |
| `Id` | `string` | Required | Product File Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `CreatedTs` | `int?` | Optional | Created Time Stamp |
| `ModifiedTs` | `int?` | Optional | Modified Time Stamp |
| `Active` | `bool` | Required | Active |
| `CreatedUserId` | `string` | Optional | User ID Created the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "title": "My terminal",
  "product_file_credential_id": "11e95f8ec39de8fbdb0a4f1a",
  "id": "11e95f8ec39de8fbdb0a4f1a",
  "created_ts": 1422040992,
  "modified_ts": 1422040992,
  "active": true,
  "created_user_id": "11e95f8ec39de8fbdb0a4f1a",
  "free_bytes": 216.62,
  "byte_increment": 219.94,
  "max_file_size_bytes": 237.34,
  "increment_cost": 213.22,
  "monthly_fee": 98
}
```

