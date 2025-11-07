**Namespace:** `VaultSharp.Features.DBDashboard.Commands.Person.Operations.Update`  
**Link Method:** `string Link(string label = "Update", int personId = 0, bool disabled = false)`

**Parameters:**
- `label` (string, optional) - Display text for the link. Default: "Update"
- `personId` (int, required) - The ID of the Person to update
- `disabled` (bool, optional) - Whether the link should be disabled. Default: false

**Description:** Opens the staging form for updating an existing Person record. Loads the current record data into a JSON file in the staged folder and opens it in VSCode for editing.

**Example:**
```csharp
string link = Stage.Link(personId: 123);  // "Update"

// Custom label
string customLabelLink = Stage.Link(label: "Edit Person", personId: 123);

// Disable the link. ( No Command Routing on Click )
string disabledLink = Stage.Link(personId: 123, disabled: true);
```
