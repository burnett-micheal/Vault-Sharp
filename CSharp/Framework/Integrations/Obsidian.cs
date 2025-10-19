using System.Diagnostics;

namespace VaultSharp.Framework.Integrations
{
  public static class Obsidian
  {
    public static void OpenFile(string markdownFilePath)
    {
      var encodedPath = Uri.EscapeDataString(markdownFilePath);
      var uri = $"obsidian://open?path={encodedPath}";
      Process.Start(new ProcessStartInfo { FileName = uri, UseShellExecute = true });
    }
  }
}
