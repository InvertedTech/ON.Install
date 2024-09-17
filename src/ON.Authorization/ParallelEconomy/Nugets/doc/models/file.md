
# File

## Structure

`File`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `File` | `object` | Required | File Object |
| `ResourceId` | `string` | Required | Resource Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `Resource` | [`Resource2Enum`](../../doc/models/resource-2-enum.md) | Required | Resource |
| `ProductFileId` | `string` | Optional | Product File Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `FileCategoryId` | `string` | Optional | File Category Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `VisibilityGroupId` | `string` | Optional | Visibility Group Id<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `FileDescription` | `string` | Optional | File Description<br>**Constraints**: *Maximum Length*: `128` |
| `Id` | `string` | Required | Resource<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |
| `FileName` | `string` | Optional | File Name |
| `FileExtension` | `string` | Optional | File Extension<br>**Constraints**: *Maximum Length*: `4` |
| `FileSizeBytes` | `int?` | Optional | File Size Bytes |
| `CreatedTs` | `int` | Required | Created Time Stamp |
| `ModifiedTs` | `int` | Required | Modified Time Stamp |
| `CreatedUserId` | `string` | Optional | User ID Created the register<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "file": {
    "key1": "val1",
    "key2": "val2"
  },
  "resource_id": "resource_id6",
  "resource": "Location",
  "product_file_id": "product_file_id8",
  "file_category_id": "file_category_id6",
  "visibility_group_id": "visibility_group_id2",
  "file_description": "file_description2",
  "id": "id0",
  "file_name": "file_name8",
  "created_ts": 146,
  "modified_ts": 70
}
```

