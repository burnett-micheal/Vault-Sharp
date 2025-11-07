## **VaultSharp** (Root Namespace)

### Program (partial class)

- `static void Main(string[] args)` - private
- `static void Initialize()` - private
- `static bool IsUriInput(string[] args)` - private

---

## **VaultSharp.Framework.Data**

### AppConfig (static class)

- `string VAULT_BRIDGE_ROOT` - public static field
- `string MAIN_VIEW_PATH` - public static readonly field
- `string NAV_PATH` - public static readonly field
- `string USER_STAGED_DATA_PATH` - public static readonly field
- `string VAULT_BRIDGE_URI_SCHEME` - public static readonly field
- `string INIT_VAULT_SHARP_COMMAND` - public static readonly field
- `string INIT_VAULT_SHARP_URI` - public static readonly field
- `string DATABASE_PATH` - public static readonly field

---

## **VaultSharp.Framework.Data.Interfaces**

### ITableEntity (interface)

- `int Id { get; }` - property getter
- `List<string> ToRow()` - method

---

## **VaultSharp.Framework.Data.InternalModels**

### Field (class)

- `string Label { get; set; }` - public property
- `string Value { get; set; }` - public property
- `Field(string label, string value)` - public constructor

---

## **VaultSharp.Framework.Data.SQLiteDB**

### DatabaseContext (static class)

- `static SqliteConnection GetConnection()` - public
- `static void InitializeDatabase()` - public
- `static void CloseConnection()` - public

---

## **VaultSharp.Framework.Data.SQLiteDB.Tables.Person**

### Model (class : ITableEntity)

- `int Id { get; set; }` - public property
- `string FirstName { get; set; }` - public property
- `string? MiddleName { get; set; }` - public property
- `string LastName { get; set; }` - public property
- `string FullName()` - public
- `static Model Template()` - public
- `static List<string> ToHeaders()` - public
- `List<string> ToRow()` - public
- `List<Field> ToFields()` - public

### Repository (static class)

- `static int Create(SqliteConnection connection, Model person)` - public
- `static Model? GetById(SqliteConnection connection, int id)` - public
- `static List<Model> GetList(SqliteConnection connection, int limit = 50, int offset = 0)` - public
- `static int GetCount(SqliteConnection connection)` - public
- `static void Update(SqliteConnection connection, Model person)` - public
- `static void Delete(SqliteConnection connection, int id)` - public

### Schema (static class)

- `string CreateSql` - public static field

---

## **VaultSharp.Framework.Integrations**

### Cmd (static class)

- `static void Show(string message)` - public

### Obsidian (static class)

- `static void OpenFile(string markdownFilePath)` - public

### VSCode (static class)

- `static void OpenFile(string filePath)` - public
- `static void OpenFolder(string folderPath, string? focusFile = null)` - public

---

## **VaultSharp.Framework.IO.DocumentEditors**

### JsonDocEditor (class)

- `JsonDocEditor(string jsonFilePath)` - public constructor
- `T? Read<T>()` - public
- `Dictionary<string, object>? ReadAsDictionary()` - public
- `void Write<T>(T data)` - public

### MDDocEditor (class)

- `string FilePath { get; }` - public property
- `bool IsLoaded { get; }` - public property
- `MDDocEditor(string filePath)` - public constructor
- `bool Load()` - public
- `string GetContent()` - public
- `void SetContent(string newContent)` - public
- `bool Save()` - public
- `bool LoadModifySave(Func<string, string> modifyFunc)` - public

---

## **VaultSharp.Framework.IO.FileSystem**

### Doc (static class)

- `static void Delete(string filePath)` - public
- `static bool Exists(string filePath)` - public
- `static void ClearDirectory(string directoryPath)` - public

---

## **VaultSharp.Framework.Navigation**

### NavManager (static class)

- `static bool IsNavigating()` - public
- `static void ResetNavigationFlag()` - public
- `static void ResetNavFile()` - public
- `static NavState Load()` - public
- `static void Save(NavState nav)` - public
- `static void NavTo(string uri)` - public
- `static bool CanGoBack()` - public
- `static bool CanGoForward()` - public
- `static string? GoBack()` - public
- `static string? GoForward()` - public

### NavState (class)

- `int Index { get; set; }` - public property
- `List<string> History { get; set; }` - public property
- `NavState(int index, List<string> history)` - public constructor

---

## **VaultSharp.Framework.Rendering.Markdown**

### Components (class)

- `static string NavBar()` - public
- `static string LineBreak(int numOfLineBreaks = 1)` - public
- `static string Link(string label, string url, bool disabled = false)` - public
- `static string Header(string text, int level = 1)` - public
- `static string Table(List<string> headers, List<List<string>> rows)` - public
- `static string Field(string label, string value)` - public
- `static string Fields(List<Field> fields)` - public
- `static string FieldsAsTable(List<Field> fields)` - public
- `static string Join(List<string> parts, string? seperator = null)` - public

---

## **VaultSharp.Framework.Rendering.Markdown.Views**

### Main (class)

- `static void Render(string content)` - public

---

## **VaultSharp.Framework.Routing**

### CommandRegistry (static class)

- `static void Initialize()` - public
- `static void Register(string command, Action<UriData> handler)` - public
- `static Action<UriData> GetCommandHandler(string command)` - public
- `static bool IsCommandRegistered(string command)` - public

### Router (static class)

- `static void Route(string uriString)` - public

### UriBuilder (static class)

- `static string Build(string command, Dictionary<string, string>? parameters = null)` - public
- `static string Build(string command, string paramKey, string paramValue)` - public

### UriData (class)

- `string FullUri { get; set; }` - public property
- `string Command { get; set; }` - public property
- `Dictionary<string, string> Params { get; set; }` - public property
- `UriData(string fullUri, string command, Dictionary<string, string> parameters)` - public constructor
- `string GetParam(string key, string defaultValue = "")` - public
- `bool HasParam(string key)` - public

### UriParser (static class)

- `static UriData Parse(string uriString)` - public

---

## **VaultSharp.Framework.Utils**

### DataTypeUtils.String (static nested class)

- `static string Query(Dictionary<string, string>? queryParams)` - public

---

## **VaultSharp.Framework.Utils.Extensions.String**

### StringExtensions (static class)

- `static bool StartsWith(this string str, string prefix, bool caseSensitive = true)` - public
- `static bool IsValidString(this string? str)` - public
- `static int ToInt(this string str)` - public
- `static float ToFloat(this string str)` - public

---

## **VaultSharp.Features.DBDashboard**

### DBDashboardSetup (static class)

- `static void RegisterCommands()` - public

### DBComponents (static partial class)

- `static string Table<T>(List<string> headers, List<T> entities, Func<int, string> buildViewLink) where T : ITableEntity` - public
- `static string Pagination(int currentPage, int totalPages, int pageSize, Func<string, int, int, bool, string> buildLink)` - public

---

## **VaultSharp.Features.DBDashboard.Commands**

### HomePage (static class)

- `string Command` - public const field
- `static void Handler(UriData uriData)` - public
- `static string Link(string label = "🏠 Home", bool disabled = false)` - public
- `static void RegisterCommand()` - public

---

## **VaultSharp.Features.DBDashboard.Commands.Person**

### PersonCommands (static class)

- `static void RegisterCommands()` - public

---

## **VaultSharp.Features.DBDashboard.Commands.Person.Operations.Create**

### Stage (static class)

- `string Command` - public const field
- `static void Handler(UriData uriData)` - public
- `static string Link(string label = "Create Person", bool disabled = false)` - public
- `static void RegisterCommand()` - public

### Confirm (static class)

- `string Command` - public const field
- `static void Handler(UriData uriData)` - public
- `static string Link(string label = "Confirm Create", bool disabled = false)` - public
- `static void RegisterCommand()` - public

---

## **VaultSharp.Features.DBDashboard.Commands.Person.Operations.Update**

### Stage (static class)

- `string Command` - public const field
- `static void Handler(UriData uriData)` - public
- `static string Link(string label = "Update", int personId = 0, bool disabled = false)` - public
- `static void RegisterCommand()` - public

### Confirm (static class)

- `string Command` - public const field
- `static void Handler(UriData uriData)` - public
- `static string Link(string label = "Confirm Update", int personId = 0, bool disabled = false)` - public
- `static void RegisterCommand()` - public

---

## **VaultSharp.Features.DBDashboard.Commands.Person.Operations.Delete**

### Prompt (static class)

- `string Command` - public const field
- `static void Handler(UriData uriData)` - public
- `static string Link(string label = "Delete", int personId = 0, bool disabled = false)` - public
- `static void RegisterCommand()` - public

### Confirm (static class)

- `string Command` - public const field
- `static void Handler(UriData uriData)` - public
- `static string Link(string label = "Delete Person", int personId = 0, bool disabled = false)` - public
- `static void RegisterCommand()` - public

---

## **VaultSharp.Features.DBDashboard.Commands.Person.Pages**

### Detail (static partial class)

- `string Command` - public const field
- `static void Handler(UriData uriData)` - public
- `static string Link(string label = "View", int personId = 0, bool disabled = false)` - public
- `static void RegisterCommand()` - public

### Table (static partial class)

- `string Command` - public const field
- `static void Handler(UriData uriData)` - public
- `static string Link(string label = "Person Table", int page = 1, int pageSize = 5, bool disabled = false)` - public
- `static void RegisterCommand()` - public

---

## **VaultSharp.Features.System**

### SystemCommands (static class)

- `static void RegisterCommands()` - public

---

## **VaultSharp.Features.System.Commands.Navigation**

### Back (static class)

- `string Command` - public const field
- `static void Handler(UriData uriData)` - public
- `static string Link(string label = "Back")` - public
- `static void RegisterCommand()` - public

### Forward (static class)

- `string Command` - public const field
- `static void Handler(UriData uriData)` - public
- `static string Link(string label = "Forward")` - public
- `static void RegisterCommand()` - public

---

## **VaultSharp.Features.System.Commands.Integrations**

### OpenMainView (static class)

- `string Command` - public const field
- `static void Handler(UriData uriData)` - public
- `static string Link(string label = "Open Main View", bool disabled = false)` - public
- `static void RegisterCommand()` - public

### OpenStagedFolder (static class)

- `string Command` - public const field
- `static void Handler(UriData uriData)` - public
- `static string Link(string label = "Open Staged Folder", bool disabled = false)` - public
- `static void RegisterCommand()` - public