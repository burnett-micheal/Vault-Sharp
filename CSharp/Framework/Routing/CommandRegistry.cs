namespace VaultSharp.Framework.Routing
{
  public static class CommandRegistry
  {
    private static readonly Dictionary<string, Action<UriData>> CommandHandlers = new();

    public static void Initialize()
    {
      Features.DBDashboard.DBDashboardSetup.RegisterCommands();
      Features.System.SystemCommands.RegisterCommands();
    }

    public static void Register(string command, Action<UriData> handler)
    {
      CommandHandlers.Add(command, handler);
    }

    public static Action<UriData> GetCommandHandler(string command)
    {
      if (!CommandHandlers.ContainsKey(command))
        throw new Exception($"Command: {command} --- is not registered in Command Registry!");
      return CommandHandlers[command];
    }

    public static bool IsCommandRegistered(string command)
    {
      return CommandHandlers.ContainsKey(command);
    }
  }
}
