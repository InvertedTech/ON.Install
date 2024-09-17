
# Ui Prefs

Ui Prefs

## Structure

`UiPrefs`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `EntryPage` | `string` | Optional | Ui Prefs Entry Page |
| `PageSize` | `int?` | Optional | Ui Prefs Page Size<br>**Constraints**: `>= 0`, `<= 99` |
| `ReportExportType` | [`ReportExportTypeEnum?`](../../doc/models/report-export-type-enum.md) | Optional | Ui Prefs Export Type |
| `ProcessMethod` | [`ProcessMethodEnum?`](../../doc/models/process-method-enum.md) | Optional | Ui Prefs Process Method |
| `DefaultTerminal` | `string` | Optional | Ui Prefs Default Termianl<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F\-]{24,36})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "entry_page": "dashboard",
  "page_size": 2,
  "report_export_type": "csv",
  "process_method": "virtual_terminal",
  "default_terminal": "11e95f8ec39de8fbdb0a4f1a"
}
```

