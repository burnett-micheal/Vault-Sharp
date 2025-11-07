**Namespace:** `VaultSharp.Features.System.Commands.Navigation`  
**Link Method:** `string Link(string label = "Back")`

**Description:** Navigates to the previous URI in the navigation history. Automatically disabled if no history exists.

**Example:**
```csharp
string link = Back.Link();  // "Back"

// Custom label
string customLabelLink = Back.Link(label: "← Previous");
```
