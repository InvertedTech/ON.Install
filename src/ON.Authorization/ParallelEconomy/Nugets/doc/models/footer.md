
# Footer

Footer

## Structure

`Footer`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Settings` | [`Settings`](../../doc/models/settings.md) | Required | - |
| `Fields` | [`List<Field16>`](../../doc/models/field-16.md) | Required | - |

## Example (as JSON)

```json
{
  "settings": {
    "enabled": true,
    "columns": 1.0,
    "rows": 1.0
  },
  "fields": [
    {
      "id": "transaction_amount",
      "label": "Header",
      "field_type": "heading",
      "position": [
        "1",
        "0",
        "1",
        "1"
      ],
      "required": true,
      "readonly": true,
      "visible": true,
      "value": "value0"
    }
  ]
}
```

