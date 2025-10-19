using System.Diagnostics;

namespace VaultSharp.Framework.Integrations
{
  public static class Cmd
  {
    public static void Show(string message)
    {
      // Using /K keeps the window open after displaying the message
      var process = new Process
      {
        StartInfo = new ProcessStartInfo
        {
          FileName = "cmd.exe",
          Arguments =
            $"/K echo {message} && echo. && echo Press any key to close... && pause > nul",
          UseShellExecute = true,
          CreateNoWindow = false,
        },
      };
      process.Start();
    }
  }
}
