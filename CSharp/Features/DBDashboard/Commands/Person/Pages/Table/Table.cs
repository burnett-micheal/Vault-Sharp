using VaultSharp.Framework.Data.InternalModels;
using VaultSharp.Framework.Data.SQLiteDB.Tables.Person;
using VaultSharp.Framework.Navigation;
using VaultSharp.Framework.Rendering.Markdown;
using VaultSharp.Framework.Rendering.Markdown.Views;
using VaultSharp.Framework.Routing;
using VaultSharp.Framework.Utils.Enums;
using VaultSharp.Framework.Utils.Extensions.String;
using SQLPerson = VaultSharp.Framework.Data.SQLiteDB.Tables.Person;
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
      string sortName = uriData.GetParam("sortName", SQLPerson.Columns.LastName.Name);
      string sortDirection = uriData.GetParam("sortDirection", SortDirection.Ascending);

      Column? sortColumn = Columns.NameToColumn.GetValueOrDefault(sortName);

      TableOptions tableOptions = new TableOptions(page, pageSize, sortColumn, sortDirection);

      NavManager.NavTo(uriData.FullUri);
      Main.Render(Page(tableOptions));
    }

    public static string Link(
      string label = "Person Table",
      TableOptions? tableOptions = null,
      bool disabled = false
    )
    {
      string page = (tableOptions?.Page ?? 1).ToString();
      string pageSize = (tableOptions?.PageSize ?? 5).ToString();
      Column sortColumn = tableOptions?.SortColumn ?? SQLPerson.Columns.LastName;
      string sortDirection = tableOptions?.SortDirection ?? SortDirection.Ascending;

      var parameters = new Dictionary<string, string>
      {
        { "page", page },
        { "pageSize", pageSize },
        { "sortName", sortColumn.Name },
        { "sortDirection", sortDirection },
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
