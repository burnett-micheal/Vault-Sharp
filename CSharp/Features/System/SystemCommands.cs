using Integrations = VaultSharp.Features.System.Commands.Integrations;
using Navigation = VaultSharp.Features.System.Commands.Navigation;

namespace VaultSharp.Features.System
{
  public static class SystemCommands
  {
    public static void RegisterCommands()
    {
      Navigation.Back.RegisterCommand();
      Navigation.Forward.RegisterCommand();
      Integrations.OpenStagedFolder.RegisterCommand();
      Integrations.OpenMainView.RegisterCommand();
    }
  }
}
