using VaultSharp.Framework.Data.SQLiteDB.Tables.Person;

namespace VaultSharp.Framework.Data.InternalModels
{
  public class TableOptions
  {
    public int Page { get; } = 1;
    public int PageSize { get; } = 5;
    public Column? SortColumn { get; }
    public string? SortDirection { get; }

    public TableOptions(
      int page = 1,
      int pageSize = 5,
      Column? sortColumn = null,
      string? sortDirection = null
    )
    {
      Page = page;
      PageSize = pageSize;
      SortColumn = sortColumn;
      SortDirection = sortDirection;
    }

    public TableOptions NextPage()
    {
      return new TableOptions(Page + 1, PageSize, SortColumn, SortDirection);
    }

    public TableOptions PrevPage()
    {
      return new TableOptions(Page - 1, PageSize, SortColumn, SortDirection);
    }
  }
}
