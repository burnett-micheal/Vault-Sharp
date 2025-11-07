**Namespace:** `VaultSharp.Features.DBDashboard.Commands.Person.Operations.Delete`  
**Link Method:** `string Link(string label = "Delete Person", int personId = 0, bool disabled = false)`

**Parameters:**
- `label` (string, optional) - Display text for the link. Default: "Delete Person"
- `personId` (int, required) - The ID of the Person to delete
- `disabled` (bool, optional) - Whether the link should be disabled. Default: false

**Description:** Permanently deletes the specified Person record from the database. This action cannot be undone.

**Example:**
```csharp
string link = Confirm.Link(personId: 123);  // "Delete Person"

// Custom label
string customLabelLink = Confirm.Link(label: "Confirm Delete", personId: 123);

// Disable the link. ( No Command Routing on Click )
string disabledLink = Confirm.Link(personId: 123, disabled: true);
```
