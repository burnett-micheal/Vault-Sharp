using System.IO;

namespace VaultSharp.Framework.IO.FileSystem
{
  public static class Doc
  {
    public static void Delete(string filePath)
    {
      if (File.Exists(filePath))
        File.Delete(filePath);
    }

    public static bool Exists(string filePath)
    {
      return File.Exists(filePath);
    }

    public static void ClearDirectory(string directoryPath)
    {
      if (Directory.Exists(directoryPath))
      {
        Directory.Delete(directoryPath, recursive: true);
      }
      Directory.CreateDirectory(directoryPath);
    }
  }
}
