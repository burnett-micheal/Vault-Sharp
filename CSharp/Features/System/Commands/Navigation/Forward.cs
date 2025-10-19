using VaultSharp.Framework.Navigation;
using VaultSharp.Framework.Rendering.Markdown;
using VaultSharp.Framework.Routing;
using VSUriBuilder = VaultSharp.Framework.Routing.UriBuilder;

namespace VaultSharp.Features.System.Commands.Navigation
{
  public static class Forward
  {
    public const string Command = "system/navigation/forward";

    public static void Handler(UriData uriData)
    {
      string? newUriString = NavManager.GoForward();

      if (newUriString == null)
        return;

      Router.Route(newUriString);
    }

    public static string Link(string label = "Forward")
    {
      string uri = VSUriBuilder.Build(Command);
      bool isDisabled = !NavManager.CanGoForward();
      return Components.Link(label, uri, isDisabled);
    }

    public static void RegisterCommand()
    {
      CommandRegistry.Register(Command, Handler);
    }
  }
}
