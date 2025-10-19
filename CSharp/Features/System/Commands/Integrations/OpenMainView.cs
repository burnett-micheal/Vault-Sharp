using VaultSharp.Features;
using VaultSharp.Framework.Data;
using VaultSharp.Framework.Integrations;
using VaultSharp.Framework.Navigation;
using VaultSharp.Framework.Rendering.Markdown;
using VaultSharp.Framework.Routing;
using VSUriBuilder = VaultSharp.Framework.Routing.UriBuilder;

namespace VaultSharp.Features.System.Commands.Integrations
{
  public static class OpenMainView
  {
    public const string Command = "system/integrations/openmainview";

    public static void Handler(UriData uriData)
    {
      NavManager.ResetNavFile();
      Obsidian.OpenFile(AppConfig.MAIN_VIEW_PATH);
      Router.Route(VSUriBuilder.Build(DBDashboard.Commands.HomePage.Command));
    }

    public static string Link(string label = "Open Main View", bool disabled = false)
    {
      string uri = VSUriBuilder.Build(Command);
      return Components.Link(label, uri, disabled);
    }

    public static void RegisterCommand()
    {
      CommandRegistry.Register(Command, Handler);
    }
  }
}
