
# Addon

## Structure

`Addon`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Title` | `string` | Required | Title<br>**Constraints**: *Maximum Length*: `24` |
| `Secret` | `string` | Required | Secret<br>**Constraints**: *Maximum Length*: `36` |
| `IframeUrl` | `string` | Required | Iframe URL<br>**Constraints**: *Maximum Length*: `512` |
| `LocationSetupUrl` | `string` | Optional | Location Setup URL<br>**Constraints**: *Maximum Length*: `512` |
| `UserSetupUrl` | `string` | Optional | User Setup URL<br>**Constraints**: *Maximum Length*: `512` |
| `EncryptUrlParams` | `bool?` | Optional | Encrypt URL Params |

## Example (as JSON)

```json
{
  "title": " ",
  "secret": " ",
  "iframe_url": " ",
  "encrypt_url_params": true,
  "location_setup_url": "location_setup_url0",
  "user_setup_url": "user_setup_url6"
}
```

