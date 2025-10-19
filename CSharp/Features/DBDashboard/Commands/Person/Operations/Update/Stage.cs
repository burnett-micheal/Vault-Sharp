using VaultSharp.Features.System.Commands.Integrations;
using VaultSharp.Framework.Data;
using VaultSharp.Framework.Data.SQLiteDB;
using VaultSharp.Framework.Integrations;
using VaultSharp.Framework.IO.DocumentEditors;
using VaultSharp.Framework.Navigation;
using VaultSharp.Framework.Rendering.Markdown.Views;
using VaultSharp.Framework.Routing;
using VaultSharp.Framework.Utils.Extensions.String;
using C = VaultSharp.Framework.Rendering.Markdown.Components;
using PersonModel = VaultSharp.Framework.Data.SQLiteDB.Tables.Person.Model;
using PersonRepo = VaultSharp.Framework.Data.SQLiteDB.Tables.Person.Repository;
using VSUriBuilder = VaultSharp.Framework.Routing.UriBuilder;

namespace VaultSharp.Features.DBDashboard.Commands.Person.Operations.Update
{
  public static class Stage
  {
    public const string Command = "dbdashboard/person/operations/update/stage";

    public static void Handler(UriData uriData)
    {
      int personId = uriData.GetParam("id").ToInt();
      var connection = DatabaseContext.GetConnection();
      var person = PersonRepo.GetById(connection, personId);

      if (person == null)
      {
        Cmd.Show("Person not found!");
        return;
      }

      var editor = new JsonDocEditor($"{AppConfig.USER_STAGED_DATA_PATH}/person.json");
      editor.Write(person);

      VSCode.OpenFolder(AppConfig.USER_STAGED_DATA_PATH, "person.json");

      NavManager.NavTo(uriData.FullUri);
      Main.Render(Page(personId));
    }

    public static string Link(string label = "Update", int personId = 0, bool disabled = false)
    {
      string uri = VSUriBuilder.Build(Command, "id", personId.ToString());
      return C.Link(label, uri, disabled);
    }

    private static string Page(int personId)
    {
      List<string> parts = [C.NavBar()];

      parts.Add(C.Header("Updating Person", 1));
      parts.Add(C.Header("Staged Files", 2));
      parts.Add("📄 person.json - Edit in VSCode, then confirm below");

      parts.Add(OpenStagedFolder.Link("📁 Re-open VSCode"));

      parts.Add(C.Header("Actions", 2));
      string confirmBtn = Confirm.Link("Confirm Update", personId);
      string cancelBtn = Pages.Detail.Link("Cancel", personId);
      parts.Add($"{confirmBtn}  |  {cancelBtn}");

      return C.Join(parts);
    }

    public static void RegisterCommand()
    {
      CommandRegistry.Register(Command, Handler);
    }
  }
}
