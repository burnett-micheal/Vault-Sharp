namespace VaultSharp.Features.DBDashboard
{
  public static class DBDashboardSetup
  {
    public static void RegisterCommands()
    {
      Commands.Person.PersonCommands.RegisterCommands();
      Commands.HomePage.RegisterCommand();
    }
  }
}
