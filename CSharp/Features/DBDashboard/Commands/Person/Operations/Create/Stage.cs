using VaultSharp.Features.System.Commands.Integrations;
using VaultSharp.Framework.Data;
using VaultSharp.Framework.Integrations;
using VaultSharp.Framework.IO.DocumentEditors;
using VaultSharp.Framework.Navigation;
using VaultSharp.Framework.Rendering.Markdown.Views;
using VaultSharp.Framework.Routing;
using C = VaultSharp.Framework.Rendering.Markdown.Components;
using PersonModel = VaultSharp.Framework.Data.SQLiteDB.Tables.Person.Model;
using VSUriBuilder = VaultSharp.Framework.Routing.UriBuilder;

namespace VaultSharp.Features.DBDashboard.Commands.Person.Operations.Create
{
  public static class Stage
  {
    public const string Command = "dbdashboard/person/operations/create/stage";

    public static void Handler(UriData uriData)
    {
      var editor = new JsonDocEditor($"{AppConfig.USER_STAGED_DATA_PATH}/person.json");
      editor.Write(PersonModel.Template());

      VSCode.OpenFolder(AppConfig.USER_STAGED_DATA_PATH, "person.json");

      NavManager.NavTo(uriData.FullUri);
      Main.Render(Page());
    }

    public static string Link(string label = "Create Person", bool disabled = false)
    {
      string uri = VSUriBuilder.Build(Command);
      return C.Link(label, uri, disabled);
    }

    private static string Page()
    {
      List<string> parts = [C.NavBar()];

      parts.Add(C.Header("Creating Person", 1));
      parts.Add(C.Header("Staged Files", 2));
      parts.Add("📄 person.json - Edit in VSCode, then confirm below");

      parts.Add(OpenStagedFolder.Link("📁 Re-open VSCode"));

      parts.Add(C.Header("Actions", 2));
      string confirmBtn = Confirm.Link("Confirm Create");
      string cancelBtn = Pages.Table.Link("Cancel");
      parts.Add($"{confirmBtn}  |  {cancelBtn}");

      return C.Join(parts);
    }

    public static void RegisterCommand()
    {
      CommandRegistry.Register(Command, Handler);
    }
  }
}
