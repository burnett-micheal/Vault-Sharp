using VaultSharp.Framework.Data.SQLiteDB;
using VaultSharp.Framework.Integrations;
using VaultSharp.Framework.Navigation;
using VaultSharp.Framework.Rendering.Markdown.Views;
using VaultSharp.Framework.Routing;
using VaultSharp.Framework.Utils.Extensions.String;
using C = VaultSharp.Framework.Rendering.Markdown.Components;
using PersonRepo = VaultSharp.Framework.Data.SQLiteDB.Tables.Person.Repository;
using VSUriBuilder = VaultSharp.Framework.Routing.UriBuilder;

namespace VaultSharp.Features.DBDashboard.Commands.Person.Operations.Delete
{
  public static class Prompt
  {
    public const string Command = "dbdashboard/person/operations/delete/prompt";

    public static void Handler(UriData uriData)
    {
      int personId = uriData.GetParam("id").ToInt();

      NavManager.NavTo(uriData.FullUri);
      Main.Render(Page(personId));
    }

    public static string Link(string label = "Delete", int personId = 0, bool disabled = false)
    {
      string uri = VSUriBuilder.Build(Command, "id", personId.ToString());
      return C.Link(label, uri, disabled);
    }

    private static string Page(int personId)
    {
      var connection = DatabaseContext.GetConnection();
      var person = PersonRepo.GetById(connection, personId);

      List<string> parts = [C.NavBar()];

      if (person == null)
      {
        Cmd.Show("Person not found!");
        return C.Join(parts);
      }

      parts.Add(C.Header("⚠️ Confirm Deletion", 1));
      parts.Add($"Are you sure you want to delete **{person.FullName()}**?");
      parts.Add("This action cannot be undone.");

      parts.Add(C.Header("Actions", 2));
      string finalizeBtn = Confirm.Link("Delete Person", personId);
      string cancelBtn = Pages.Detail.Link("Cancel", personId);
      parts.Add($"{finalizeBtn}  |  {cancelBtn}");

      return C.Join(parts);
    }

    public static void RegisterCommand()
    {
      CommandRegistry.Register(Command, Handler);
    }
  }
}
