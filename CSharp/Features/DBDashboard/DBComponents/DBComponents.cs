using VaultSharp.Framework.Data.Interfaces;
using VaultSharp.Framework.Data.InternalModels;
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
      TableOptions tableOptions,
      int totalPages,
      Func<string, TableOptions, bool, string> buildLink
    )
    {
      int currentPage = tableOptions.Page;

      string prevLink = buildLink("<- Previous", tableOptions.PrevPage(), currentPage <= 1);
      string nextLink = buildLink("Next ->", tableOptions.NextPage(), currentPage >= totalPages);

      return $"{prevLink}  |  Page {currentPage} of {totalPages}  |  {nextLink}";
    }
  }
}
