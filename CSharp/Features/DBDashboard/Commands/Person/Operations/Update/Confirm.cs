using VaultSharp.Framework.Data;
using VaultSharp.Framework.Data.SQLiteDB;
using VaultSharp.Framework.Integrations;
using VaultSharp.Framework.IO.DocumentEditors;
using VaultSharp.Framework.Navigation;
using VaultSharp.Framework.Routing;
using VaultSharp.Framework.Utils.Extensions.String;
using C = VaultSharp.Framework.Rendering.Markdown.Components;
using PersonModel = VaultSharp.Framework.Data.SQLiteDB.Tables.Person.Model;
using PersonRepo = VaultSharp.Framework.Data.SQLiteDB.Tables.Person.Repository;
using VSUriBuilder = VaultSharp.Framework.Routing.UriBuilder;

namespace VaultSharp.Features.DBDashboard.Commands.Person.Operations.Update
{
  public static class Confirm
  {
    public const string Command = "dbdashboard/person/operations/update/confirm";

    public static void Handler(UriData uriData)
    {
      int personId = uriData.GetParam("id").ToInt();

      try
      {
        var editor = new JsonDocEditor($"{AppConfig.USER_STAGED_DATA_PATH}/person.json");
        var person = editor.Read<PersonModel>();

        if (person == null)
        {
          Cmd.Show("Error: Failed to read person data from JSON file.");
          return;
        }

        if (person.FirstName == "" || person.LastName == "")
        {
          Cmd.Show("Error: First Name and Last Name are required.");
          return;
        }

        person.Id = personId;

        // Update in database
        var connection = DatabaseContext.GetConnection();
        PersonRepo.Update(connection, person);
        Cmd.Show("Person updated successfully!");

        string detailUri = VSUriBuilder.Build(Pages.Detail.Command, "id", personId.ToString());
        Router.Route(detailUri);
      }
      catch (Exception ex)
      {
        Cmd.Show($"Error updating person: {ex.Message}");
      }
    }

    public static string Link(
      string label = "Confirm Update",
      int personId = 0,
      bool disabled = false
    )
    {
      string uri = VSUriBuilder.Build(Command, "id", personId.ToString());
      return C.Link(label, uri, disabled);
    }

    public static void RegisterCommand()
    {
      CommandRegistry.Register(Command, Handler);
    }
  }
}
