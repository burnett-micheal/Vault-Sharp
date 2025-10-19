using Operations = VaultSharp.Features.DBDashboard.Commands.Person.Operations;
using Pages = VaultSharp.Features.DBDashboard.Commands.Person.Pages;

namespace VaultSharp.Features.DBDashboard.Commands.Person
{
  public static class PersonCommands
  {
    public static void RegisterCommands()
    {
      // Pages
      Pages.Detail.RegisterCommand();
      Pages.Table.RegisterCommand();

      // Operations
      Operations.Create.Stage.RegisterCommand();
      Operations.Create.Confirm.RegisterCommand();
      Operations.Update.Stage.RegisterCommand();
      Operations.Update.Confirm.RegisterCommand();
      Operations.Delete.Prompt.RegisterCommand();
      Operations.Delete.Confirm.RegisterCommand();
    }
  }
}
