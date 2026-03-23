using VaultSharp.Framework.Data.InternalModels;
using VaultSharp.Framework.Data.SQLiteDB;
using VaultSharp.Framework.Data.SQLiteDB.Tables.Person;
using VaultSharp.Framework.Utils.Enums;
using C = VaultSharp.Framework.Rendering.Markdown.Components;
using DBC = VaultSharp.Features.DBDashboard.DBComponents;
using PersonModel = VaultSharp.Framework.Data.SQLiteDB.Tables.Person.Model;
using PersonRepo = VaultSharp.Framework.Data.SQLiteDB.Tables.Person.Repository;
using StageCreatePerson = VaultSharp.Features.DBDashboard.Commands.Person.Operations.Create.Stage;

namespace VaultSharp.Features.DBDashboard.Commands.Person.Pages
{
  public static partial class Table
  {
    private static string Page(TableOptions tableOptions)
    {
      int page = tableOptions.Page;
      int pageSize = tableOptions.PageSize;
      Column sortColumn = tableOptions.SortColumn ?? Columns.LastName;
      string sortDirection = tableOptions.SortDirection ?? SortDirection.Ascending;

      var connection = DatabaseContext.GetConnection();

      // Calculate pagination

      var people = PersonRepo.GetList(connection, tableOptions);
      int totalCount = PersonRepo.GetCount(connection);
      int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

      // Build sort-aware headers
      List<string> headers = Columns
        .All.Select(col =>
        {
          bool isActive = col == sortColumn;

          string nextDir =
            isActive && sortDirection == SortDirection.Ascending
              ? SortDirection.Descending
              : SortDirection.Ascending;

          string label = isActive
            ? (sortDirection == SortDirection.Ascending ? $"{col.Name} ↑" : $"{col.Name} ↓")
            : col.Name;

          TableOptions nextOptions = new TableOptions(1, pageSize, col, nextDir);
          return Table.Link(label, nextOptions);
        })
        .ToList();

      // Build content
      List<string> parts = [C.NavBar()];
      parts.Add(C.Header("Person Table", 1));

      int offset = (page - 1) * pageSize;
      parts.Add(
        $"Showing {offset + 1}-{Math.Min(offset + pageSize, totalCount)} of {totalCount} people"
      );

      Func<int, string> buildLink = id => Detail.Link("view", id);
      string noneStr = "*No people found. Create your first person.*";
      parts.Add(totalCount > 0 ? DBC.Table(headers, people, buildLink) : noneStr);

      if (totalPages > 1)
        parts.Add(DBC.Pagination(tableOptions, totalPages, Link));

      parts.Add(StageCreatePerson.Link("Create Person"));

      parts.Add(HomePage.Link("<- Back to Home"));

      return C.Join(parts);
    }
  }
}
