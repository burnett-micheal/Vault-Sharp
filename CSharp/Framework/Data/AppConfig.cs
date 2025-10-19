using VaultSharp.Features.DBDashboard.Commands;

namespace VaultSharp.Framework.Data
{
  public static class AppConfig
  {
    public static string VAULT_BRIDGE_ROOT = "C:/CodeStuff/VaultBridge";
    public static readonly string MAIN_VIEW_PATH = $"{VAULT_BRIDGE_ROOT}/ObsidianVault/Test.md";
    public static readonly string NAV_PATH =
      $"{VAULT_BRIDGE_ROOT}/AppData/session_data/app_state/nav.json";
    public static readonly string USER_STAGED_DATA_PATH =
      $"{VAULT_BRIDGE_ROOT}/AppData/session_data/user_input/staged_data";
    public static readonly string VAULT_BRIDGE_URI_SCHEME = "vaultbridge";
    public static readonly string INIT_VAULT_SHARP_COMMAND = HomePage.Command;
    public static readonly string INIT_VAULT_SHARP_URI =
      $"{VAULT_BRIDGE_URI_SCHEME}://{INIT_VAULT_SHARP_COMMAND}";

    public static readonly string DATABASE_PATH = $"{VAULT_BRIDGE_ROOT}/AppData/database.db";
  }
}
