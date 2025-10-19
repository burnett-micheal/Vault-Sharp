using VaultSharp.Framework.Navigation;
using VaultSharp.Framework.Rendering.Markdown;
using VaultSharp.Framework.Rendering.Markdown.Views;
using VaultSharp.Framework.Routing;
using C = VaultSharp.Framework.Rendering.Markdown.Components;
using VSUriBuilder = VaultSharp.Framework.Routing.UriBuilder;

namespace VaultSharp.Features.DBDashboard.Commands
{
  public static class HomePage
  {
    public const string Command = "dbdashboard/homepage";

    public static void Handler(UriData uriData)
    {
      NavManager.NavTo(uriData.FullUri);
      Main.Render(Page());
    }

    public static string Link(string label = "🏠 Home", bool disabled = false)
    {
      string uri = VSUriBuilder.Build(Command);
      return Components.Link(label, uri, disabled);
    }

    private static string Page()
    {
      List<string> parts = [C.NavBar()];

      parts.Add(C.Header("Database Dashboard", 1));
      parts.Add("Welcome to the VaultSharp Database Dashboard!");

      parts.Add(C.Header("Available Tables", 2));
      parts.Add(Person.Pages.Table.Link("👤 Person Table"));
      // TODO: Add more table links as you implement them
      // parts.Add(Company.Pages.Table.Link("🏢 Company Table"));
      // parts.Add(Task.Pages.Table.Link("📋 Task Table"));

      return C.Join(parts);
    }

    public static void RegisterCommand()
    {
      CommandRegistry.Register(Command, Handler);
    }
  }
}
