using System.IO;
using System.Text.Json;

namespace VaultSharp.Framework.IO.DocumentEditors
{
  public class JsonDocEditor
  {
    private readonly string filePath;
    private static readonly JsonSerializerOptions options = new()
    {
      WriteIndented = true,
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    public JsonDocEditor(string jsonFilePath)
    {
      filePath = jsonFilePath;
    }

    public T? Read<T>()
    {
      if (!File.Exists(filePath))
        return default;

      string json = File.ReadAllText(filePath);
      return JsonSerializer.Deserialize<T>(json, options);
    }

    public Dictionary<string, object>? ReadAsDictionary()
    {
      if (!File.Exists(filePath))
        return null;

      string json = File.ReadAllText(filePath);
      return JsonSerializer.Deserialize<Dictionary<string, object>>(json, options);
    }

    public void Write<T>(T data)
    {
      string json = JsonSerializer.Serialize(data, options);
      File.WriteAllText(filePath, json);
    }
  }
}
