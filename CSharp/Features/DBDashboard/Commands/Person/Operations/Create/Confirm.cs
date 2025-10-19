using VaultSharp.Framework.Data;
using VaultSharp.Framework.Data.SQLiteDB;
using VaultSharp.Framework.Integrations;
using VaultSharp.Framework.IO.DocumentEditors;
using VaultSharp.Framework.Navigation;
using VaultSharp.Framework.Routing;
using C = VaultSharp.Framework.Rendering.Markdown.Components;
using PersonModel = VaultSharp.Framework.Data.SQLiteDB.Tables.Person.Model;
using PersonRepo = VaultSharp.Framework.Data.SQLiteDB.Tables.Person.Repository;
using VSUriBuilder = VaultSharp.Framework.Routing.UriBuilder;

namespace VaultSharp.Features.DBDashboard.Commands.Person.Operations.Create
{
  public static class Confirm
  {
    public const string Command = "dbdashboard/person/operations/create/confirm";

    public static void Handler(UriData uriData)
    {
      try
      {
        // Read the JSON file
        var editor = new JsonDocEditor($"{AppConfig.USER_STAGED_DATA_PATH}/person.json");
        var person = editor.Read<PersonModel>();

        if (person == null)
        {
          Cmd.Show("Error: Failed to read person data from JSON file.");
          return;
        }

        // Validate
        if (
          string.IsNullOrWhiteSpace(person.FirstName) || string.IsNullOrWhiteSpace(person.LastName)
        )
        {
          Cmd.Show("Error: First Name and Last Name are required.");
          return;
        }

        // Create in database
        var connection = DatabaseContext.GetConnection();
        int newId = PersonRepo.Create(connection, person);

        // Show success and redirect to detail page
        Cmd.Show("Person created successfully!");

        string detailUri = VSUriBuilder.Build(Pages.Detail.Command, "id", newId.ToString());
        Router.Route(detailUri);
      }
      catch (Exception ex)
      {
        Cmd.Show($"Error creating person: {ex.Message}");
      }
    }

    public static string Link(string label = "Confirm Create", bool disabled = false)
    {
      string uri = VSUriBuilder.Build(Command);
      return C.Link(label, uri, disabled);
    }

    public static void RegisterCommand()
    {
      CommandRegistry.Register(Command, Handler);
    }
  }
}
