namespace VaultSharp.Framework.Routing
{
  public class UriData
  {
    public string FullUri { get; set; } = string.Empty;
    public string Command { get; set; } = string.Empty;
    public Dictionary<string, string> Params { get; set; } = new();

    public UriData(string fullUri, string command, Dictionary<string, string> parameters)
    {
      FullUri = fullUri;
      Command = command;
      Params = parameters;
    }

    public string GetParam(string key, string defaultValue = "")
    {
      return Params.TryGetValue(key, out var value) ? value : defaultValue;
    }

    public bool HasParam(string key)
    {
      return Params.ContainsKey(key);
    }
  }
}
