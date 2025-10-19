using VaultSharp.Framework.Data.Interfaces;
using C = VaultSharp.Framework.Rendering.Markdown.Components;

namespace VaultSharp.Features.DBDashboard
{
  public static partial class DBComponents
  {
    public static string Table<T>(
      List<string> headers,
      List<T> entities,
      Func<int, string> buildViewLink
    )
      where T : ITableEntity
    {
      List<string> tableHeaders = new List<string>(headers);
      tableHeaders.Add("Actions");

      List<List<string>> rows = entities
        .Select(entity =>
        {
          var row = entity.ToRow();
          row.Add(buildViewLink(entity.Id));
          return row;
        })
        .ToList();

      return C.Table(tableHeaders, rows);
    }

    public static string Pagination(
      int currentPage,
      int totalPages,
      int pageSize,
      Func<string, int, int, bool, string> buildLink
    )
    {
      string prevLink = buildLink("<- Previous", currentPage - 1, pageSize, currentPage <= 1);
      string nextLink = buildLink("Next ->", currentPage + 1, pageSize, currentPage >= totalPages);

      return $"{prevLink}  |  Page {currentPage} of {totalPages}  |  {nextLink}";
    }
  }
}
