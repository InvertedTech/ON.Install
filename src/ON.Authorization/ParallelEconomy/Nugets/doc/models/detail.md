
# Detail

## Structure

`Detail`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Message` | `string` | Optional | - |
| `Path` | `List<string>` | Optional | - |
| `Type` | `string` | Optional | - |
| `Context` | [`Context`](../../doc/models/context.md) | Optional | - |

## Example (as JSON)

```json
{
  "message": "\"fieldName\" is required",
  "type": "any.required",
  "path": [
    "path8",
    "path9"
  ],
  "context": {
    "key": "key2",
    "label": "label2"
  }
}
```

