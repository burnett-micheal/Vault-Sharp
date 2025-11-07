# Codebase Documentation
---

This page serves as a central hub linking to detailed documentation for all namespaces in the VaultSharp codebase.

---
## Framework
The Framework provides core infrastructure and utilities that power VaultSharp's functionality.
- [[Codebase/Framework/Data|Data]] - Configuration, interfaces, database context, and entity models
- [[Codebase/Framework/Integrations|Integrations]] - External tool integrations (Cmd, Obsidian, VSCode)
- [[Codebase/Framework/IO|IO]] - File system operations and document editors (JSON, Markdown)
- [[Codebase/Framework/Navigation|Navigation]] - Navigation state management and history tracking
- [[Codebase/Framework/Rendering|Rendering]] - Markdown component generation and view rendering
- [[Codebase/Framework/Routing|Routing]] - URI parsing, building, command registry, and routing logic
- [[Codebase/Framework/Utils|Utils]] - Helper functions and extension methods

---
## Features
Features are self-contained modules that provide specific functionality.
- [[Codebase/Features/System|System]] - Core system commands for navigation and integrations
- [[Codebase/Features/DBDashboard|DBDashboard]] - Database management dashboard and CRUD operations

---

**Suggested order:**

1. **Utils** ← Start here
2. **Integrations** - Also simple, just 3 classes launching external programs
3. **IO** - Document editors are straightforward, depends on nothing but System.IO
4. **Rendering** - Markdown components, clean and focused
5. **Routing** - Core system, but now you'll have practice and momentum
6. **Navigation** - Depends on IO (JsonDocEditor) which you'll have documented
7. **Data** - Most complex, but by now you'll have established patterns
8. Features/System
9. Features/DBDashboard