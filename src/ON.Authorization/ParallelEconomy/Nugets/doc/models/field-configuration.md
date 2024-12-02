
# Field Configuration

field_configuration

## Structure

`FieldConfiguration`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CssMini` | `bool` | Required | CSS Mini |
| `Stack` | [`StackEnum`](../../doc/models/stack-enum.md) | Required | Stack |
| `Header` | [`Header`](../../doc/models/header.md) | Optional | Header |
| `Body` | [`Body`](../../doc/models/body.md) | Required | Body |
| `Footer` | [`Footer`](../../doc/models/footer.md) | Required | Footer |

## Example (as JSON)

```json
{
  "css_mini": true,
  "stack": "vertical",
  "body": {
    "settings": {
      "enabled": true,
      "columns": 1,
      "rows": 1
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
        "visible": true
      }
    ]
  },
  "footer": {
    "settings": {
      "enabled": true,
      "columns": 1,
      "rows": 1
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
        "visible": true
      }
    ]
  },
  "header": {
    "settings": {
      "enabled": false,
      "columns": 202.28,
      "rows": 235.78
    },
    "fields": [
      {
        "id": "id8",
        "label": "label8",
        "field_type": "field_type4",
        "position": [
          "position7",
          "position8",
          "position9"
        ],
        "required": false,
        "readonly": false,
        "visible": false,
        "value": "value0"
      }
    ]
  }
}
```

