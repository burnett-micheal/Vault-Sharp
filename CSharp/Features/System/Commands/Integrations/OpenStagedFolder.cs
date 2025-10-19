using VaultSharp.Framework.Data;
using VaultSharp.Framework.Integrations;
using VaultSharp.Framework.Rendering.Markdown;
using VaultSharp.Framework.Routing;
using VSUriBuilder = VaultSharp.Framework.Routing.UriBuilder;

namespace VaultSharp.Features.System.Commands.Integrations
{
  public static class OpenStagedFolder
  {
    public const string Command = "system/integrations/openstagedfolder";

    public static void Handler(UriData uriData)
    {
      VSCode.OpenFolder(AppConfig.USER_STAGED_DATA_PATH);
    }

    public static string Link(string label = "Open Staged Folder", bool disabled = false)
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
