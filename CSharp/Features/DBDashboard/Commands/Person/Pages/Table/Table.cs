using VaultSharp.Framework.Data.SQLiteDB;
using VaultSharp.Framework.Navigation;
using VaultSharp.Framework.Rendering.Markdown;
using VaultSharp.Framework.Rendering.Markdown.Views;
using VaultSharp.Framework.Routing;
using VaultSharp.Framework.Utils.Extensions.String;
using VSUriBuilder = VaultSharp.Framework.Routing.UriBuilder;

namespace VaultSharp.Features.DBDashboard.Commands.Person.Pages
{
  public static partial class Table
  {
    public const string Command = "dbdashboard/person/pages/table";

    public static void Handler(UriData uriData)
    {
      int page = uriData.GetParam("page", "1").ToInt();
      int pageSize = uriData.GetParam("pageSize", "5").ToInt();

      NavManager.NavTo(uriData.FullUri);
      Main.Render(Page(page, pageSize));
    }

    public static string Link(
      string label = "Person Table",
      int page = 1,
      int pageSize = 5,
      bool disabled = false
    )
    {
      var parameters = new Dictionary<string, string>
      {
        { "page", page.ToString() },
        { "pageSize", pageSize.ToString() },
      };

      string uri = VSUriBuilder.Build(Command, parameters);
      return Components.Link(label, uri, disabled);
    }

    public static void RegisterCommand()
    {
      CommandRegistry.Register(Command, Handler);
    }
  }
}
