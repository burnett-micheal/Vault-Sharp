**Namespace:** `VaultSharp.Features.System.Commands.Navigation`  
**Link Method:** `string Link(string label = "Forward")`

**Description:** Navigates to the next URI in the navigation history. Automatically disabled if no history exists.

**Example:**
```csharp
string link = Forward.Link();  // "Forward"

// Custom label
string customLabelLink = Forward.Link(label: "Next →");
```
