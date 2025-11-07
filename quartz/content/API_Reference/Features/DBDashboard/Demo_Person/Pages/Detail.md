**Namespace:** `VaultSharp.Features.DBDashboard.Commands.Person.Pages`  
**Link Method:** `string Link(string label = "View", int personId = 0, bool disabled = false)`

**Parameters:**
- `label` (string, optional) - Display text for the link. Default: "View"
- `personId` (int, required) - The ID of the Person to display
- `disabled` (bool, optional) - Whether the link should be disabled. Default: false

**Description:** Displays detailed view of a specific Person record including all fields and available operations.

**Example:**
```csharp
string link = Detail.Link(personId: 123);  // "View"

// Custom label
string customLabelLink = Detail.Link(label: "View John", personId: 123);

// Disable the link. ( No Command Routing on Click )
string disabledLink = Detail.Link(personId: 123, disabled: true);
```
