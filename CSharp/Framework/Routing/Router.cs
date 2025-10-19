using VaultSharp.Framework.Integrations;
using VaultSharp.Framework.Navigation;

namespace VaultSharp.Framework.Routing
{
  public static class Router
  {
    public static void Route(string uriString)
    {
      try
      {
        UriData uriData = UriParser.Parse(uriString);
        var handler = CommandRegistry.GetCommandHandler(uriData.Command);
        handler(uriData);
      }
      catch (Exception error)
      {
        NavManager.ResetNavigationFlag();
        Cmd.Show(error.ToString());
      }
    }
  }
}
