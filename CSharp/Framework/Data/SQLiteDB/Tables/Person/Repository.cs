using Microsoft.Data.Sqlite;

namespace VaultSharp.Framework.Data.SQLiteDB.Tables.Person
{
  public static class Repository
  {
    public static int Create(SqliteConnection connection, Model person)
    {
      var command = connection.CreateCommand();
      command.CommandText =
        @"
        INSERT INTO People (FirstName, MiddleName, LastName)
        VALUES ($firstName, $middleName, $lastName);
        SELECT last_insert_rowid();
      ";

      command.Parameters.AddWithValue("$firstName", person.FirstName);
      command.Parameters.AddWithValue("$middleName", person.MiddleName ?? (object)DBNull.Value);
      command.Parameters.AddWithValue("$lastName", person.LastName);

      var result = command.ExecuteScalar();
      return Convert.ToInt32(result);
    }

    public static Model? GetById(SqliteConnection connection, int id)
    {
      var command = connection.CreateCommand();
      command.CommandText =
        @"
        SELECT Id, FirstName, MiddleName, LastName
        FROM People
        WHERE Id = $id;
      ";

      command.Parameters.AddWithValue("$id", id);

      using var reader = command.ExecuteReader();
      if (reader.Read())
      {
        return new Model
        {
          Id = reader.GetInt32(0),
          FirstName = reader.GetString(1),
          MiddleName = reader.IsDBNull(2) ? null : reader.GetString(2),
          LastName = reader.GetString(3),
        };
      }

      return null;
    }

    public static List<Model> GetList(SqliteConnection connection, int limit = 50, int offset = 0)
    {
      var people = new List<Model>();

      var command = connection.CreateCommand();
      command.CommandText =
        @"
        SELECT Id, FirstName, MiddleName, LastName
        FROM People
        ORDER BY LastName, FirstName
        LIMIT $limit OFFSET $offset;
      ";

      command.Parameters.AddWithValue("$limit", limit);
      command.Parameters.AddWithValue("$offset", offset);

      using var reader = command.ExecuteReader();
      while (reader.Read())
      {
        people.Add(
          new Model
          {
            Id = reader.GetInt32(0),
            FirstName = reader.GetString(1),
            MiddleName = reader.IsDBNull(2) ? null : reader.GetString(2),
            LastName = reader.GetString(3),
          }
        );
      }

      return people;
    }

    public static int GetCount(SqliteConnection connection)
    {
      var command = connection.CreateCommand();
      command.CommandText = "SELECT COUNT(*) FROM People;";

      var result = command.ExecuteScalar();
      return Convert.ToInt32(result);
    }

    public static void Update(SqliteConnection connection, Model person)
    {
      var command = connection.CreateCommand();
      command.CommandText =
        @"
        UPDATE People
        SET FirstName = $firstName,
            MiddleName = $middleName,
            LastName = $lastName
        WHERE Id = $id;
      ";

      command.Parameters.AddWithValue("$id", person.Id);
      command.Parameters.AddWithValue("$firstName", person.FirstName);
      command.Parameters.AddWithValue("$middleName", person.MiddleName ?? (object)DBNull.Value);
      command.Parameters.AddWithValue("$lastName", person.LastName);

      command.ExecuteNonQuery();
    }

    public static void Delete(SqliteConnection connection, int id)
    {
      var command = connection.CreateCommand();
      command.CommandText = "DELETE FROM People WHERE Id = $id;";
      command.Parameters.AddWithValue("$id", id);
      command.ExecuteNonQuery();
    }
  }
}
