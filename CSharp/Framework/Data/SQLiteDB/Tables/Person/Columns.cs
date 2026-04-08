using System.Data.Common;
using VaultSharp.Framework.Data.InternalModels;

namespace VaultSharp.Framework.Data.SQLiteDB.Tables.Person
{
  public static class Columns
  {
    public static Column Id = new("ID", "Id");
    public static readonly Column FirstName = new("First Name", "FirstName");
    public static readonly Column MiddleName = new("Middle Name", "MiddleName");
    public static readonly Column LastName = new("Last Name", "LastName");

    public static readonly List<Column> All = [Id, FirstName, MiddleName, LastName];

    public static readonly Dictionary<string, Column> NameToColumn = All.ToDictionary(c => c.Name);
    public static readonly Dictionary<string, Column> SqlToColumn = All.ToDictionary(c => c.Sql);
  }
}
