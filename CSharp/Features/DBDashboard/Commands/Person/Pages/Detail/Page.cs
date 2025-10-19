using VaultSharp.Framework.Data.InternalModels;
using VaultSharp.Framework.Data.SQLiteDB;
using C = VaultSharp.Framework.Rendering.Markdown.Components;
using PersonOps = VaultSharp.Features.DBDashboard.Commands.Person.Operations;
using PersonRepo = VaultSharp.Framework.Data.SQLiteDB.Tables.Person.Repository;

namespace VaultSharp.Features.DBDashboard.Commands.Person.Pages
{
  public static partial class Detail
  {
    private static string Page(int personId)
    {
      var connection = DatabaseContext.GetConnection();
      var person = PersonRepo.GetById(connection, personId);

      List<string> parts = [C.NavBar()];

      if (person == null)
      {
        parts.Add(C.Header("Person not found in database.", 5));
        return C.Join(parts);
      }

      parts.Add(C.Header($"{person.FullName()}", 1));
      parts.Add(C.Fields(person.ToFields()));

      parts.Add(C.Header("Actions", 2));
      string updateBtn = PersonOps.Update.Stage.Link(personId: person.Id);
      string deleteBtn = PersonOps.Delete.Prompt.Link(personId: person.Id);
      parts.Add($"{updateBtn} | {deleteBtn}");

      parts.Add(Table.Link("<- Back to Table"));

      return C.Join(parts);
    }
  }
}
