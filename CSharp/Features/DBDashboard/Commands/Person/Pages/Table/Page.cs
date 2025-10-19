using VaultSharp.Framework.Data.SQLiteDB;
using C = VaultSharp.Framework.Rendering.Markdown.Components;
using DBC = VaultSharp.Features.DBDashboard.DBComponents;
using PersonModel = VaultSharp.Framework.Data.SQLiteDB.Tables.Person.Model;
using PersonRepo = VaultSharp.Framework.Data.SQLiteDB.Tables.Person.Repository;
using StageCreatePerson = VaultSharp.Features.DBDashboard.Commands.Person.Operations.Create.Stage;

namespace VaultSharp.Features.DBDashboard.Commands.Person.Pages
{
  public static partial class Table
  {
    private static string Page(int page = 1, int pageSize = 5)
    {
      var connection = DatabaseContext.GetConnection();

      // Calculate pagination
      int offset = (page - 1) * pageSize;
      var people = PersonRepo.GetList(connection, pageSize, offset);
      int totalCount = PersonRepo.GetCount(connection);
      int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

      // Build content
      List<string> parts = [C.NavBar()];
      parts.Add(C.Header("Person Table", 1));

      parts.Add(
        $"Showing {offset + 1}-{Math.Min(offset + pageSize, totalCount)} of {totalCount} people"
      );

      List<string> headers = PersonModel.ToHeaders();
      Func<int, string> buildLink = id => Detail.Link("view", id);
      string noneStr = "*No people found. Create your first person.*";
      parts.Add(totalCount > 0 ? DBC.Table(headers, people, buildLink) : noneStr);

      if (totalPages > 1)
        parts.Add(DBC.Pagination(page, totalPages, pageSize, Link));

      parts.Add(StageCreatePerson.Link("Create Person"));

      parts.Add(HomePage.Link("<- Back to Home"));

      return C.Join(parts);
    }
  }
}
