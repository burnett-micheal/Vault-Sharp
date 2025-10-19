using VaultSharp.Framework.Data.Interfaces;
using VaultSharp.Framework.Data.InternalModels;
using VaultSharp.Framework.Utils.Extensions.String;

namespace VaultSharp.Framework.Data.SQLiteDB.Tables.Person
{
  public class Model : ITableEntity
  {
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = "";

    public string FullName()
    {
      string result = "";
      result += FirstName;
      if (MiddleName.IsValidString())
        result += $" {MiddleName}";
      result += $" {LastName}";
      return result;
    }

    public static Model Template()
    {
      var template = new Model
      {
        FirstName = "First",
        MiddleName = "Middle",
        LastName = "Last",
      };
      return template;
    }

    public static List<string> ToHeaders()
    {
      return new List<string> { "ID", "First Name", "Middle Name", "Last Name" };
    }

    public List<string> ToRow()
    {
      return new List<string> { Id.ToString(), FirstName, MiddleName ?? "", LastName };
    }

    public List<Field> ToFields()
    {
      return new List<Field>
      {
        new Field("ID", Id.ToString()),
        new Field("First Name", FirstName),
        new Field("Middle Name", MiddleName ?? "(none)"),
        new Field("Last Name", LastName),
      };
    }
  }
}
