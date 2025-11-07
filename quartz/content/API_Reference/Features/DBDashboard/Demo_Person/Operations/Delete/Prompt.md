**Namespace:** `VaultSharp.Features.DBDashboard.Commands.Person.Operations.Delete`  
**Link Method:** `string Link(string label = "Delete", int personId = 0, bool disabled = false)`

**Parameters:**
- `label` (string, optional) - Display text for the link. Default: "Delete"
- `personId` (int, required) - The ID of the Person to delete
- `disabled` (bool, optional) - Whether the link should be disabled. Default: false

**Description:** Displays a confirmation prompt before deleting a Person record. Shows the record details and asks for user confirmation before proceeding with deletion.

**Example:**
```csharp
string link = Prompt.Link(personId: 123);  // "Delete"

// Custom label
string customLabelLink = Prompt.Link(label: "Remove Person", personId: 123);

// Disable the link. ( No Command Routing on Click )
string disabledLink = Prompt.Link(personId: 123, disabled: true);
```
