**Namespace:** `VaultSharp.Features.DBDashboard.Commands`  
**Link Method:** `string Link(string label = "🏠 Home", bool disabled = false)`

**Description:** Displays the main database dashboard with links to all available entity tables.

**Example:**
```csharp
string link = HomePage.Link();  // "🏠 Home"

// Custom label
string customLabelLink = HomePage.Link(label: "Dashboard Home");

// Disable the link. ( No Command Routing on Click )
string disabledLink = HomePage.Link(disabled: true);
```
