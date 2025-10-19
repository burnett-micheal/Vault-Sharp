using VaultSharp.Framework.Data.SQLiteDB;
using VaultSharp.Framework.Integrations;
using VaultSharp.Framework.Navigation;
using VaultSharp.Framework.Rendering.Markdown;
using VaultSharp.Framework.Rendering.Markdown.Views;
using VaultSharp.Framework.Routing;
using VaultSharp.Framework.Utils.Extensions.String;
using PersonModel = VaultSharp.Framework.Data.SQLiteDB.Tables.Person;
using VSUriBuilder = VaultSharp.Framework.Routing.UriBuilder;

namespace VaultSharp.Features.DBDashboard.Commands.Person.Pages
{
  public static partial class Detail
  {
    public const string Command = "dbdashboard/person/pages/detail";

    public static void Handler(UriData uriData)
    {
      int personId = uriData.GetParam("id").ToInt();
      NavManager.NavTo(uriData.FullUri);
      Main.Render(Page(personId));
    }

    public static string Link(string label = "View", int personId = 0, bool disabled = false)
    {
      string uri = VSUriBuilder.Build(Command, "id", personId.ToString());
      return Components.Link(label, uri, disabled);
    }

    public static void RegisterCommand()
    {
      CommandRegistry.Register(Command, Handler);
    }
  }
}
