namespace VaultSharp.Framework.Data.SQLiteDB.Tables.Person
{
  public static class Schema
  {
    private static string CreateTableSql =>
      @"
        CREATE TABLE IF NOT EXISTS People (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            FirstName TEXT NOT NULL,
            MiddleName TEXT,
            LastName TEXT NOT NULL
        );
    ";

    private static string CreateIndexesSql =>
      @"
        CREATE INDEX IF NOT EXISTS idx_people_lastname ON People(LastName);
        CREATE INDEX IF NOT EXISTS idx_people_firstname ON People(FirstName);
    ";

    public static string CreateSql = CreateTableSql + CreateIndexesSql + ";";
  }
}
