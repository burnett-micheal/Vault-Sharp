namespace VaultSharp.Framework.Data.InternalModels
{
  public class Column
  {
    public string Name { get; }
    public string Sql { get; }

    public Column(string name, string sql)
    {
      Name = name;
      Sql = sql;
    }
  }
}
