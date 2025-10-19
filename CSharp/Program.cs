using VaultSharp.Framework.Data;
using VaultSharp.Framework.Data.SQLiteDB;
using VaultSharp.Framework.Routing;
using VaultSharp.Framework.Utils.Extensions.String;

namespace VaultSharp
{
  partial class Program
  {
    static void Main(string[] args)
    {
      Initialize();

      if (!IsUriInput(args))
        return;

      string uriString = args[0];
      Router.Route(uriString);
    }

    private static void Initialize()
    {
      DatabaseContext.InitializeDatabase();
      CommandRegistry.Initialize();
    }

    private static bool IsUriInput(string[] args)
    {
      if (args.Length == 0)
        return false;
      return args[0].StartsWith($"{AppConfig.VAULT_BRIDGE_URI_SCHEME}://", caseSensitive: false);
    }
  }
}
