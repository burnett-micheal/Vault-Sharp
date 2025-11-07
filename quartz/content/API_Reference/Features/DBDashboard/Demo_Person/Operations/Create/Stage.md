**Namespace:** `VaultSharp.Features.DBDashboard.Commands.Person.Operations.Create`  
**Link Method:** `string Link(string label = "Create Person", bool disabled = false)`

**Description:** Opens the staging form for creating a new Person record. Creates a template JSON file in the staged folder and opens it in VSCode for editing.

**Example:**
```csharp
string link = Stage.Link();  // "Create Person"

// Custom label
string customLabelLink = Stage.Link(label: "➕ Add New Person");

// Disable the link. ( No Command Routing on Click )
string disabledLink = Stage.Link(disabled: true);
```
