**Namespace:** `VaultSharp.Features.DBDashboard.Commands.Person.Pages`  
**Link Method:** `string Link(string label = "Person Table", int page = 1, int pageSize = 5, bool disabled = false)`

**Parameters:**
- `label` (string, optional) - Display text for the link. Default: "Person Table"
- `page` (int, optional) - The page number to display. Starts at 1. Default: 1
- `pageSize` (int, optional) - Number of records per page. Default: 5
- `disabled` (bool, optional) - Whether the link should be disabled. Default: false

**Description:** Displays a paginated table of all Person records with action buttons for Create, Update, and Delete operations.

**Example:**
```csharp
string link = Table.Link();  // "Person Table", page 1, 5 per page

// Custom label
string customLabelLink = Table.Link(label: "👤 View People");

// Different page
string pageLink = Table.Link(page: 2);

// Different page size
string pageSizeLink = Table.Link(pageSize: 10);

// Disable the link. ( No Command Routing on Click )
string disabledLink = Table.Link(disabled: true);
```
