**Namespace:** `VaultSharp.Features.System.Commands.Integrations`  
**Link Method:** `string Link(string label = "Open Main View", bool disabled = false)`

**Description:** Opens the main view file in Obsidian and navigates to the DB Dashboard home page. Resets navigation state before opening.

**Example:**
```csharp
string link = OpenMainView.Link();  // "Open Main View"

// Custom label
string customLabelLink = OpenMainView.Link(label: "🏠 Home Page");

// Disable the link. ( No Command Routing on Click )
string disabledLink = OpenMainView.Link(disabled: true);
```
