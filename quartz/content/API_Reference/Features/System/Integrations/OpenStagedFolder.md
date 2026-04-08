**Namespace:** `VaultSharp.Features.System.Commands.Integrations`  
**Link Method:** `string Link(string label = "Open Staged Folder", bool disabled = false)`

**Description:** Opens the staged data folder in VSCode for editing staged files during Create and Update operations.

**Example:**
```csharp
string link = OpenStagedFolder.Link();  // "Open Staged Folder"

// Custom label
string customLabelLink = OpenStagedFolder.Link(label: "📁 Edit Files");

// Disable the link. ( No Command Routing on Click )
string disabledLink = OpenStagedFolder.Link(disabled: true);
```
