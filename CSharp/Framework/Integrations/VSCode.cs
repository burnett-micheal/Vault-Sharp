using System.Diagnostics;

namespace VaultSharp.Framework.Integrations
{
  public static class VSCode
  {
    private static string FormatPath(string path)
    {
      return $"\"{path}\"";
    }

    public static void OpenFile(string filePath)
    {
      Process.Start(
        new ProcessStartInfo
        {
          FileName = "code",
          Arguments = FormatPath(filePath),
          UseShellExecute = true,
        }
      );
    }

    public static void OpenFolder(string folderPath, string? focusFile = null)
    {
      string args = FormatPath(folderPath);

      if (focusFile != null)
      {
        string filePath = Path.Combine(folderPath, focusFile);
        args += $" {FormatPath(filePath)}";
      }

      Process.Start(
        new ProcessStartInfo
        {
          FileName = "code",
          Arguments = args,
          UseShellExecute = true,
        }
      );
    }
  }
}
