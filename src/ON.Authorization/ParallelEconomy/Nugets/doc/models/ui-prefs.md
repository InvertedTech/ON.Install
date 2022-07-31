
# Ui Prefs

Ui Prefs

## Structure

`UiPrefs`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `EntryPage` | `string` | Optional | Ui Prefs Entry Page |
| `PageSize` | `int?` | Optional | Ui Prefs Page Size<br>**Constraints**: `>= 0`, `<= 99` |
| `ReportExportType` | [`Models.ReportExportTypeEnum?`](../../doc/models/report-export-type-enum.md) | Optional | Ui Prefs Export Type |
| `ProcessMethod` | [`Models.ProcessMethodEnum?`](../../doc/models/process-method-enum.md) | Optional | Ui Prefs Process Method |
| `DefaultTerminal` | `string` | Optional | Ui Prefs Default Termianl<br>**Constraints**: *Pattern*: `^(([0-9a-fA-F]{24})\|(([0-9a-fA-F]{8})-(([0-9a-fA-F]{4}\-){3})([0-9a-fA-F]{12})))$` |

## Example (as JSON)

```json
{
  "entry_page": null,
  "page_size": null,
  "report_export_type": null,
  "process_method": null,
  "default_terminal": null
}
```

