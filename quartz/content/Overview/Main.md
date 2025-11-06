# What Is Vault Sharp?
---
### Quick-Links
- [[Getting_Started/Main|VaultSharp Setup and Quick Start]]
- [[Codebase/Main|Learn the Codebase]]
- [[Overview/Current_Features|Current Features]]

---

VaultSharp is meant to tie together the read-ability of Obsidian markdown documents and the flexibility of C# into one project. By using URI links in markdown files, we can trigger C# functions from within our markdown file. This gives us a dead simple Front End and Back End, with the md file / files serving as our Front End / UI, and our local C# project serving as our Back End. This allows us to do anything C# can do within markdown by defining an associated URI command within our C#. The whole project is fully open-source, and the codebase is meant to be actively edited by the user, to best suit the user. I provide base code, but you make it yours.

The project is split into 2 major parts, Framework, and Features. "Framework" serves as the foundation of the whole project, and is a requirement for most features to work right off the bat. In short, Framework provides necessary functionality for the rest of the project, such as command routing, helpers, and utils, that are used across many features. "Features" are the actual features of the project. Some "Features" are codependent, so for the "DBDashboard" feature to work, you'd need the "System" feature as well. Each feature is meant to be its own stand-alone project with unique functionality that fits into the VaultSharp codebase. In simple terms, Framework is the required foundational code, and features are kind of like add-ons that give VaultSharp new functionality. You can pick and choose which features you want, add it to your codebase, and build the project to easily add new functionality.