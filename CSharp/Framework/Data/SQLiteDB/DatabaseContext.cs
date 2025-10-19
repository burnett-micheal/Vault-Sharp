using Microsoft.Data.Sqlite;
using VaultSharp.Framework.Data;
using Tables = VaultSharp.Framework.Data.SQLiteDB.Tables;

namespace VaultSharp.Framework.Data.SQLiteDB
{
  public static class DatabaseContext
  {
    private static SqliteConnection? _connection;
    private static string _connectionString =
      $"Data Source={Path.GetFullPath(AppConfig.DATABASE_PATH)}";

    public static SqliteConnection GetConnection()
    {
      if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
      {
        _connection = new SqliteConnection(_connectionString);
        _connection.Open();
      }
      return _connection;
    }

    public static void InitializeDatabase()
    {
      using var connection = new SqliteConnection(_connectionString);
      connection.Open();

      var command = connection.CreateCommand();
      command.CommandText += Tables.Person.Schema.CreateSql;
      // Add other table schemas as project grows
      command.ExecuteNonQuery();

      Console.WriteLine("Database initialized successfully");
    }

    public static void CloseConnection()
    {
      _connection?.Close();
      _connection?.Dispose();
      _connection = null;
    }
  }
}
