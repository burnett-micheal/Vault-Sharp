using VaultSharp.Framework.Navigation;
using VaultSharp.Framework.Rendering.Markdown;
using VaultSharp.Framework.Routing;
using VSUriBuilder = VaultSharp.Framework.Routing.UriBuilder;

namespace VaultSharp.Features.System.Commands.Navigation
{
  public static class Back
  {
    public const string Command = "system/navigation/back";

    public static void Handler(UriData uriData)
    {
      string? newUriString = NavManager.GoBack();

      if (newUriString == null)
        return;

      Router.Route(newUriString);
    }

    public static string Link(string label = "Back")
    {
      string uri = VSUriBuilder.Build(Command);
      bool isDisabled = !NavManager.CanGoBack();
      return Components.Link(label, uri, isDisabled);
    }

    public static void RegisterCommand()
    {
      CommandRegistry.Register(Command, Handler);
    }
  }
}
