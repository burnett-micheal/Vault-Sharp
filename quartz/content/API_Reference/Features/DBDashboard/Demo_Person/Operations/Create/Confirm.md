**Namespace:** `VaultSharp.Features.DBDashboard.Commands.Person.Operations.Create`  
**Link Method:** `string Link(string label = "Confirm Create", bool disabled = false)`

**Description:** Validates and commits the staged Person creation to the database. Reads from the staged JSON file, validates required fields, and inserts the new record.

**Example:**
```csharp
string link = Confirm.Link();  // "Confirm Create"

// Custom label
string customLabelLink = Confirm.Link(label: "Save Person");

// Disable the link. ( No Command Routing on Click )
string disabledLink = Confirm.Link(disabled: true);
```
