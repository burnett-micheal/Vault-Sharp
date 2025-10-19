using VaultSharp.Framework.Data.SQLiteDB;
using VaultSharp.Framework.Integrations;
using VaultSharp.Framework.Navigation;
using VaultSharp.Framework.Routing;
using VaultSharp.Framework.Utils.Extensions.String;
using C = VaultSharp.Framework.Rendering.Markdown.Components;
using PersonRepo = VaultSharp.Framework.Data.SQLiteDB.Tables.Person.Repository;
using VSUriBuilder = VaultSharp.Framework.Routing.UriBuilder;

namespace VaultSharp.Features.DBDashboard.Commands.Person.Operations.Delete
{
  public static class Confirm
  {
    public const string Command = "dbdashboard/person/operations/delete/confirm";

    public static void Handler(UriData uriData)
    {
      int personId = uriData.GetParam("id").ToInt();

      var connection = DatabaseContext.GetConnection();
      PersonRepo.Delete(connection, personId);

      // Optional: Show success message
      Cmd.Show("Person deleted successfully!");

      // Redirect to table
      string tableUri = VSUriBuilder.Build(
        Pages.Table.Command,
        new Dictionary<string, string> { { "page", "1" }, { "pageSize", "5" } }
      );

      Router.Route(tableUri);
    }

    public static string Link(
      string label = "Delete Person",
      int personId = 0,
      bool disabled = false
    )
    {
      string uri = VSUriBuilder.Build(Command, "id", personId.ToString());
      return C.Link(label, uri, disabled);
    }

    public static void RegisterCommand()
    {
      CommandRegistry.Register(Command, Handler);
    }
  }
}
